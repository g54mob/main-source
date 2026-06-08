using System;

namespace Kitchen
{
	public struct Priority
	{
		public int Value;

		public Priority AddPriority(int level)
		{
			return Value + (int)Math.Pow(2.0, level);
		}

		public Priority RemovePriority(int level)
		{
			return Value - (int)Math.Pow(2.0, level);
		}

		public static implicit operator int(Priority p)
		{
			return p.Value;
		}

		public static implicit operator Priority(int p)
		{
			return new Priority
			{
				Value = p
			};
		}

		public static Priority operator +(Priority p, int value)
		{
			return p.AddPriority(value);
		}

		public static Priority operator -(Priority p, int value)
		{
			return p.RemovePriority(value);
		}
	}
}
