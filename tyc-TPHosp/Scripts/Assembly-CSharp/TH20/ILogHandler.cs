namespace TH20
{
	public interface ILogHandler
	{
		void Log(LogEntry logEntry);

		bool RequestsCallstackAtLevel(LogLevel logLevel);
	}
}
