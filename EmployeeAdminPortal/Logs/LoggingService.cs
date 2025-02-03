using NLog;
namespace EmployeeAdminPortal.Logs
{
    public class LoggingService : ILoggingService
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogError(string message, Exception? ex = null)
        {
            logger.Error(ex, message);
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }

}

