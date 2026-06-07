using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk;

namespace Gh
{
	public abstract class LoggedValue<T> : IPersistable
	{
		public bool AutotrimLog;

		public int TrimCutoffInHours;

		public virtual T Value { get; protected set; }

		public List<LogEntry<T>> Log { get; private set; }

		public event Action<T> ValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public LoggedValue()
		{
		}

		public T Adjust(T adjustment, string text = null, bool disableLogging = false, bool appendLastLogEntry = false)
		{
			return default(T);
		}

		protected void Trim()
		{
		}

		protected abstract T Add(T a, T b);

		protected void OnValueChanged()
		{
		}

		public Dictionary<string, T> GetCategorizedSums()
		{
			return null;
		}

		public virtual string GetTooltipText()
		{
			return null;
		}

		public abstract int CompareTo(LoggedValue<T> other);
	}
}
