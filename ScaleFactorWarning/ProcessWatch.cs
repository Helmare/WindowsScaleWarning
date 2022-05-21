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
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonIgnore]
        public bool Opened { get; set; } = false;
    }
}
