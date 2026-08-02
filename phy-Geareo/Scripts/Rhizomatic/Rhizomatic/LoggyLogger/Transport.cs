namespace Rhizomatic.LoggyLogger
{
	public abstract class Transport
	{
		public LogLevel levelMask;

		protected abstract void Log(Log log);

		public abstract void Dispose();

		public void TryLog(Log log)
		{
		}
	}
}
