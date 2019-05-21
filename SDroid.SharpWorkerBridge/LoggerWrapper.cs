using System.Threading.Tasks;
using SharpWorker.Log;

namespace SDroid.SharpWorkerBridge
{
    internal class LoggerWrapper : IBotLogger
    {
        public Logger UnderlyingLogger { get; }
        public string WorkerName { get; }


        public LoggerWrapper(string workerName, Logger logger)
        {
            WorkerName = workerName;
            UnderlyingLogger = logger;
        }

        /// <inheritdoc />
        public Task Debug(string scope, string message, params object[] formatParams)
        {
            UnderlyingLogger.Log(WorkerName, scope, LogType.Debug, message, formatParams);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task Error(string scope, string message, params object[] formatParams)
        {
            UnderlyingLogger.Log(WorkerName, scope, LogType.Error, message, formatParams);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task Info(string scope, string message, params object[] formatParams)
        {
            UnderlyingLogger.Log(WorkerName, scope, LogType.Info, message, formatParams);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task Success(string scope, string message, params object[] formatParams)
        {
            UnderlyingLogger.Log(WorkerName, scope, LogType.Info, message, formatParams);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task Warning(string scope, string message, params object[] formatParams)
        {
            UnderlyingLogger.Log(WorkerName, scope, LogType.Warning, message, formatParams);

            return Task.CompletedTask;
        }
    }
}