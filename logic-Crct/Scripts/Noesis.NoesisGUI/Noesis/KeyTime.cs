using System;

namespace Noesis
{
	public struct KeyTime
	{
		private KeyTimeType _type;

		private float _percent;

		private TimeSpan _timeSpan;

		public KeyTimeType Type => default(KeyTimeType);

		public float Percent => 0f;

		public TimeSpan TimeSpan => default(TimeSpan);

		public static KeyTime Uniform => default(KeyTime);

		public static KeyTime Paced => default(KeyTime);

		public static KeyTime FromPercent(float percent)
		{
			return default(KeyTime);
		}

		public static KeyTime FromTimeSpan(TimeSpan timeSpan)
		{
			return default(KeyTime);
		}

		public static implicit operator KeyTime(TimeSpan timeSpan)
		{
			return default(KeyTime);
		}

		public static bool operator ==(KeyTime t0, KeyTime t1)
		{
			return false;
		}

		public static bool operator !=(KeyTime t0, KeyTime t1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(KeyTime v)
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

		public static KeyTime Parse(string str)
		{
			return default(KeyTime);
		}

		public static bool TryParse(string str, out KeyTime result)
		{
			result = default(KeyTime);
			return false;
		}
	}
}
