using System;

namespace ModIO.Implementation
{
	internal struct ModIOVersion : IComparable<ModIOVersion>
	{
		public static readonly ModIOVersion Current;

		public int year;

		public int month;

		public int patch;

		public string suffix;

		public ModIOVersion(int year, int month, int patch, string suffix = null)
		{
			this.year = 0;
			this.month = 0;
			this.patch = 0;
			this.suffix = null;
		}

		public int CompareTo(ModIOVersion other)
		{
			return 0;
		}

		public static bool operator >(ModIOVersion a, ModIOVersion b)
		{
			return false;
		}

		public static bool operator <(ModIOVersion a, ModIOVersion b)
		{
			return false;
		}

		public static bool operator >=(ModIOVersion a, ModIOVersion b)
		{
			return false;
		}

		public static bool operator <=(ModIOVersion a, ModIOVersion b)
		{
			return false;
		}

		public string ToHeaderString()
		{
			return null;
		}
	}
}
