using System;

namespace ModIO.Implementation
{
	internal struct ModIOVersion : IComparable<ModIOVersion>
	{
		public static readonly ModIOVersion Current = new ModIOVersion(2023, 7, 1, "beta");

		public int year;

		public int month;

		public int patch;

		public string suffix;

		public ModIOVersion(int year, int month, int patch, string suffix = null)
		{
			this.year = year;
			this.month = month;
			this.patch = patch;
			if (suffix == null)
			{
				suffix = string.Empty;
			}
			this.suffix = suffix;
		}

		public int CompareTo(ModIOVersion other)
		{
			int num = year.CompareTo(other.year);
			if (num == 0)
			{
				num = month.CompareTo(other.month);
			}
			if (num == 0)
			{
				num = patch.CompareTo(other.patch);
			}
			return num;
		}

		public static bool operator >(ModIOVersion a, ModIOVersion b)
		{
			return a.CompareTo(b) == 1;
		}

		public static bool operator <(ModIOVersion a, ModIOVersion b)
		{
			return a.CompareTo(b) == -1;
		}

		public static bool operator >=(ModIOVersion a, ModIOVersion b)
		{
			return a.CompareTo(b) >= 0;
		}

		public static bool operator <=(ModIOVersion a, ModIOVersion b)
		{
			return a.CompareTo(b) <= 0;
		}

		public string ToHeaderString()
		{
			return "modio-" + year + "." + month + "." + patch + "-" + suffix;
		}
	}
}
