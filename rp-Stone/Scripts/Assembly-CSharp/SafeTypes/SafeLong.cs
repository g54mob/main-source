using UnityEngine;

namespace SafeTypes
{
	public struct SafeLong
	{
		private long offset;

		private long value;

		public SafeLong(long value = 0L)
		{
			offset = Random.Range(-1000000, 1000000);
			this.value = value + offset;
		}

		public long GetValue()
		{
			return value - offset;
		}

		public void Dispose()
		{
			offset = 0L;
			value = 0L;
		}

		public override string ToString()
		{
			return GetValue().ToString();
		}

		public static SafeLong operator +(SafeLong f1, SafeLong f2)
		{
			return new SafeLong(f1.GetValue() + f2.GetValue());
		}

		public static SafeLong operator -(SafeLong f1, SafeLong f2)
		{
			return new SafeLong(f1.GetValue() - f2.GetValue());
		}
	}
}
