using System.Collections.Generic;
using Newtonsoft.Json;

namespace EventsProducer
{
    public class PlatformEventHeader
    {
        [JsonProperty("eventType", Required = Required.Always)]
        public PlatformEventType EventType { get; set; }

        [JsonProperty("eventTime")]
        public string EventTime { get; set; }

        [JsonProperty("content")]
        public PlatformEventContent Content { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("correlationId")]
        public string Id { get; set; }

        public Dictionary<string, object> CustomHeaders { get; set; }
    }
}