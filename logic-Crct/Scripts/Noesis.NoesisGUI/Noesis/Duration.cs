using System;

namespace Noesis
{
	public struct Duration
	{
		private enum DurationType
		{
			Automatic = 0,
			TimeSpan = 1,
			Forever = 2
		}

		private DurationType _durationType;

		private TimeSpanStruct _timeSpan;

		public bool HasTimeSpan => false;

		public TimeSpan TimeSpan => default(TimeSpan);

		public static Duration Automatic => default(Duration);

		public static Duration Forever => default(Duration);

		public Duration(TimeSpan timeSpan)
		{
			_durationType = default(DurationType);
			_timeSpan = default(TimeSpanStruct);
		}

		public static implicit operator Duration(TimeSpan timeSpan)
		{
			return default(Duration);
		}

		public static Duration operator +(Duration t0, Duration t1)
		{
			return default(Duration);
		}

		public static Duration operator -(Duration t0, Duration t1)
		{
			return default(Duration);
		}

		public static bool operator ==(Duration t0, Duration t1)
		{
			return false;
		}

		public static bool operator !=(Duration t0, Duration t1)
		{
			return false;
		}

		public static bool operator <(Duration t0, Duration t1)
		{
			return false;
		}

		public static bool operator <=(Duration t0, Duration t1)
		{
			return false;
		}

		public static bool operator >(Duration t0, Duration t1)
		{
			return false;
		}

		public static bool operator >=(Duration t0, Duration t1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Duration v)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static Duration Parse(string str)
		{
			return default(Duration);
		}

		public static bool TryParse(string str, out Duration result)
		{
			result = default(Duration);
			return false;
		}
	}
}
