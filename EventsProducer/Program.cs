using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsProducer
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "kafka:9092" };
            var topicName = "test-platform-evt-n";

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                // Note: you can specify more than one schema registry url using the
                // schema.registry.url property for redundancy (comma separated list).
                // The property name is not plural to follow the convention set by
                // the Java implementation.
                Url = "http://schema-registry:8081"
            };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            using var producer = new ProducerBuilder<Null, PlatformEventModel>(config)
                .SetValueSerializer(new JsonSerializer<PlatformEventModel>(schemaRegistry))
                .Build();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);

                try
                {
                    var dr = await producer.ProduceAsync(topicName, GenPlatformEvt());
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        private static Message<Null, PlatformEventModel> GenPlatformEvt()
        {
            var result =  new Message<Null, PlatformEventModel>
            {
                Value = new PlatformEventModel
                {
                    Headers = new PlatformEventHeader
                    {
                        Id = Guid.NewGuid().ToString(),
                        EventTime = DateTime.Now.ToLongDateString(),
                        EventType = PlatformEventType.ObjectModelCreated,
                        Content = PlatformEventContent.full,
                        CustomHeaders = BuildCustomHeaders()
                    },
                    Payload = ObjectModelPayload
                }
            };


            result.Headers = new Headers
            {
                new Header("id", Guid.NewGuid().ToByteArray()),
                new Header("type", Encoding.UTF32.GetBytes(PlatformEventType.ObjectModelCreated.ToString())),
                new Header("Content", Encoding.UTF32.GetBytes(PlatformEventContent.full.ToString()))
            };

            return result;
        }

        private static Dictionary<string, object> BuildCustomHeaders()
        {
            return new Dictionary<string, object>
            {
                { "objectId", Guid.NewGuid() },
                { "model", "test.device" },
                { "type", "test.type" },
                { "tenantId", Guid.NewGuid() }
            };
        }

        private static JObject ObjectModelPayload => JObject.Parse(@"{
              ""objectId"": ""c66bcb85-b6e6-481f-b642-3973e3f8683a"",
              ""type"": ""type@1"",
              ""model"": ""abb.ability.device"",
              ""properties"": {
                ""name"": {
                  ""value"": ""value""
                }
              }
            }"
        );
    }
}