namespace EmployeeAdminPortal.Logs
{
    public interface ILoggingService
    {
        void LogInfo(string message);
        void LogError(string message, Exception? ex = null);
        void LogDebug(string message);
        void LogWarning(string message);
    }
}
