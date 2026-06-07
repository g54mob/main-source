using System;

namespace Epic.OnlineServices.Stats
{
	public class Stat : ISettable
	{
		public string Name { get; set; }

		public DateTimeOffset? StartTime { get; set; }

		public DateTimeOffset? EndTime { get; set; }

		public int Value { get; set; }

		internal void Set(StatInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
