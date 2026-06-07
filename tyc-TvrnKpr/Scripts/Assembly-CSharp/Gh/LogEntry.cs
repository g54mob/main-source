using Gh.Tk;

namespace Gh
{
	public class LogEntry<T> : IPersistable
	{
		public float Timestamp { get; set; }

		public T Value { get; set; }

		public string Text { get; private set; }

		public LogEntry()
		{
		}

		public LogEntry(T value, string text)
		{
		}
	}
}
