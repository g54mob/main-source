using System;

namespace Gh.Tk
{
	[Serializable]
	public class LogEntry<T> : IPersistable
	{
		public float Timestamp;

		public T Item;

		private LogEntry()
		{
		}

		public LogEntry(T item)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
