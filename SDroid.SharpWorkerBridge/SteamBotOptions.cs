using Newtonsoft.Json;
using SDroid.Interfaces;
using SDroid.SteamWeb;
using SharpWorker;
using SharpWorker.WebApi.Attributes;

namespace SDroid.SharpWorkerBridge
{
    [WebApiTypeDiscriminator]
    public class SteamBotOptions : WorkerOptions, IBotSettings
    {
        [JsonIgnore]
        internal Coordinator Coordinator { get; set; }

        /// <inheritdoc />
        public string ApiKey { get; set; }

        /// <inheritdoc />
        public string DomainName { get; set; }

        /// <inheritdoc />
        public string Proxy { get; set; }

        /// <inheritdoc />
        public string PublicIPAddress { get; set; }

        /// <inheritdoc />
        public WebSession Session { get; set; }

        /// <inheritdoc />
        public int SessionCheckInterval { get; set; } = 60;

        /// <inheritdoc />
        public string Username { get; set; }

        /// <inheritdoc />
        public void SaveSettings()
        {
            Coordinator?.FlushSettings();
        }
    }
}