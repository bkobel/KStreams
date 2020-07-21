using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EventsProducer
{
    public class PlatformEventModel
    {
        public PlatformEventHeader Headers { get; set; }

        public JObject Payload { get; set; }
    }
}