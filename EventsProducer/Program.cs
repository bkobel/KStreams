using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ABB.Ability.SharedKernel.Common.Models;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Newtonsoft.Json;

namespace EventsProducer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                // Note: you can specify more than one schema registry url using the
                // schema.registry.url property for redundancy (comma separated list). 
                // The property name is not plural to follow the convention set by
                // the Java implementation.
                Url = "http://localhost:8081"
            };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
            using (var producer = new ProducerBuilder<Null, Person>(config)
                .SetValueSerializer(new JsonSerializer<Person>(schemaRegistry))
                .Build())
            {
                while (true)
                {
                    var message = Console.ReadLine();
                    if (message == "q")
                    {
                        break;
                    }

                    try
                    {
                        var dr = await producer.ProduceAsync("test",
                            new Message<Null, Person> { Value = new Person { FirstName = "Qwe", LastName = "Asd" } });
                        Console.WriteLine($"Delivered '{dr.Value.ToString()}' to '{dr.TopicPartitionOffset}'");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }
                }
            }
        }

        private static PlatformEventModel GeneratePlatformEvent()
        {
            return new PlatformEventModel
            {

            };
        }

        //private static JsonSerializer<PlatformEventModel> TestVar = new JsonSerializer<PlatformEventModel>();
    }

    public class Person
    {
        [JsonRequired] // use Newtonsoft.Json annotations
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonRequired]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Range(0, 150)] // or System.ComponentModel.DataAnnotations annotations
        [JsonProperty("age")]
        public int Age { get; set; } = 5;
    }

}
