using SDroid.Interfaces;
using SharpWorker.WebApi.Attributes;

namespace SDroid.SharpWorkerBridge
{
    [WebApiTypeDiscriminator]
    public class SteamKitBotOptions : SteamBotOptions, ISteamKitBotSettings
    {
        /// <inheritdoc />
        public string LoginKey { get; set; }

        /// <inheritdoc />
        public int LoginTimeout { get; set; }

        /// <inheritdoc />
        public byte[] SentryFile { get; set; }

        /// <inheritdoc />
        public byte[] SentryFileHash { get; set; }

        /// <inheritdoc />
        public string SentryFileName { get; set; }
    }
}