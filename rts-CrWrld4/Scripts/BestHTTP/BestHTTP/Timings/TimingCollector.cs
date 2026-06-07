using System;
using System.Collections.Generic;

namespace BestHTTP.Timings
{
	public sealed class TimingCollector
	{
		public DateTime Start { get; private set; }

		public List<TimingEvent> Events { get; private set; }

		public void Add(string name)
		{
		}

		public void Add(string name, TimeSpan duration)
		{
		}

		public TimingEvent FindFirst(string name)
		{
			return default(TimingEvent);
		}

		public TimingEvent FindLast(string name)
		{
			return default(TimingEvent);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
