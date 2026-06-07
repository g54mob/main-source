using System;

namespace Noesis
{
	internal struct TimeSpanStruct
	{
		private long _ticks;

		public long Ticks => 0L;

		public static implicit operator TimeSpan(TimeSpanStruct n)
		{
			return default(TimeSpan);
		}

		public static implicit operator TimeSpanStruct(TimeSpan n)
		{
			return default(TimeSpanStruct);
		}

		public TimeSpanStruct(long ticks)
		{
			_ticks = 0L;
		}

		public static TimeSpanStruct operator +(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return default(TimeSpanStruct);
		}

		public static TimeSpanStruct operator -(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return default(TimeSpanStruct);
		}

		public static bool operator ==(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return false;
		}

		public static bool operator !=(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return false;
		}

		public static bool operator <(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return false;
		}

		public static bool operator <=(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return false;
		}

		public static bool operator >(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return false;
		}

		public static bool operator >=(TimeSpanStruct t0, TimeSpanStruct t1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(TimeSpanStruct v)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
