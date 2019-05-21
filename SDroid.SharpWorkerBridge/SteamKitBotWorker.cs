using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharpWorker;
using SharpWorker.DataStore;
using SharpWorker.Log;

namespace SDroid.SharpWorkerBridge
{
    public abstract class SteamKitBotWorker : SteamKitBot, ICustomizableWorker
    {
        /// <inheritdoc />
        // ReSharper disable once TooManyDependencies
        protected SteamKitBotWorker(
            SteamKitBotOptions options,
            DataStoreBase dataStore,
            Coordinator coordinator,
            WorkerConfiguration configuration,
            Logger logger) :
            base(
                options,
                new LoggerWrapper(configuration.Alias ?? configuration.WorkerType + " [" + options.Username + "]",
                    logger)
            )
        {
            DataStore = dataStore;
            Coordinator = coordinator;
            Configuration = configuration;
            options.Coordinator = coordinator;
            Options = options;
        }

        protected WorkerConfiguration Configuration { get; }
        protected Coordinator Coordinator { get; }
        protected DataStoreBase DataStore { get; }

        [JsonIgnore]
        public SteamKitBotOptions Options { get; }

        /// <inheritdoc />
        WorkerOptions ICustomizableWorker.Options
        {
            get => Options;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc />
        public long DataPoints { get; protected set; }

        /// <inheritdoc />
        public DataTopic[] DataTopics { get; protected set; }

        /// <inheritdoc />
        public abstract WorkerScheduledAction[] GetScheduledActions();

        /// <inheritdoc />
        [JsonIgnore]
        Logger IWorker.Logger
        {
            get => (BotLogger as LoggerWrapper)?.UnderlyingLogger;
        }

        /// <inheritdoc />
        public virtual string Name
        {
            get => Configuration.Alias ?? Configuration.WorkerType + " [" + Options.Username + "]";
        }

        /// <inheritdoc />
        Task IWorker.Start()
        {
            return StartBot();
        }

        /// <inheritdoc />
        Task IWorker.Stop()
        {
            return StopBot();
        }

        /// <inheritdoc />
        public event EventHandler Terminated;

        protected override Task OnTerminate()
        {
            var task = base.OnTerminate();

            try
            {
                Terminated?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                // ignored
            }

            return task;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception e)
            {
                BotLogger?.Error("OnPropertyChanged", e.Message);
            }
        }
    }
}