using Newtonsoft.Json;

namespace ScaleFactorWarning
{
    public class ProcessWatch
    {
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; } = "";
        [JsonProperty("process")]
        [JsonRequired]
        public string ProcessName { get; set; } = "";
        [JsonProperty("auto-kill")]
        public bool AutoKill { get; set; } = false;

        [JsonIgnore]
        public bool Open { get; set; } = false;
        [JsonIgnore]
        public bool Opened { get; set; } = false;
    }
}
