using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Utility
{
	public struct Version : IComparable<Version>
	{
		public int V0;

		public int V1;

		public int V2;

		public int V3;

		public int Alpha;

		private static Regex format = new Regex("^[0-9]+(\\.[0-9]+)(\\.[0-9]+)?(\\.[0-9]+)?([aA][0-9]+)?$");

		public static Version Present => Parse(Application.version);

		public static Version Null => new Version(-1);

		private int this[int a]
		{
			set
			{
				if (a < 0 || a > 4)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				switch (a)
				{
				case 0:
					V0 = value;
					break;
				case 1:
					V1 = value;
					break;
				case 2:
					V2 = value;
					break;
				case 3:
					V3 = value;
					break;
				case 4:
					Alpha = value;
					break;
				}
			}
		}

		public Version(int v0 = 0, int v1 = 0, int v2 = 0, int a = 0)
		{
			V0 = v0;
			V1 = v1;
			V2 = v2;
			V3 = 0;
			Alpha = a;
		}

		public Version(int v0, int v1, int v2, int v3, int a = 0)
		{
			V0 = v0;
			V1 = v1;
			V2 = v2;
			V3 = v3;
			Alpha = a;
		}

		public override string ToString()
		{
			return V0 + "." + V1 + "." + V2 + ((V3 != 0) ? ("." + V3) : "") + ((Alpha != 0) ? ("a" + Alpha) : "");
		}

		public int CompareTo(Version obj)
		{
			if (!(this < obj))
			{
				if (!(this > obj))
				{
					return 0;
				}
				return 1;
			}
			return -1;
		}

		public static Version Parse(string s)
		{
			if (CanParse(s))
			{
				Version result = default(Version);
				Regex regex = new Regex("[0-9]+");
				Regex regex2 = new Regex("[aA]");
				MatchCollection matchCollection = regex.Matches(s);
				if (regex2.IsMatch(s))
				{
					result.Alpha = int.Parse(matchCollection[matchCollection.Count - 1].Value);
					for (int num = matchCollection.Count - 2; num >= 0; num--)
					{
						result[num] = int.Parse(matchCollection[num].Value);
					}
				}
				else
				{
					for (int num2 = matchCollection.Count - 1; num2 >= 0; num2--)
					{
						result[num2] = int.Parse(matchCollection[num2].Value);
					}
				}
				return result;
			}
			throw new Exception("Could not parse string into Version.");
		}

		public static bool CanParse(string s)
		{
			if (s != null)
			{
				return format.IsMatch(s);
			}
			return false;
		}

		public static bool operator >(Version v1, Version v2)
		{
			if (v1.V0 > v2.V0)
			{
				return true;
			}
			if (v1.V0 < v2.V0)
			{
				return false;
			}
			if (v1.V1 > v2.V1)
			{
				return true;
			}
			if (v1.V1 < v2.V1)
			{
				return false;
			}
			if (v1.V2 > v2.V2)
			{
				return true;
			}
			if (v1.V2 < v2.V2)
			{
				return false;
			}
			if (v1.V3 > v2.V3)
			{
				return true;
			}
			if (v1.V3 < v2.V3)
			{
				return false;
			}
			if (v1.Alpha == 0 || v1.Alpha > v2.Alpha)
			{
				return v2.Alpha > 0;
			}
			return false;
		}

		public static bool operator >=(Version v1, Version v2)
		{
			return !(v1 < v2);
		}

		public static bool operator <(Version v1, Version v2)
		{
			if (v1.V0 < v2.V0)
			{
				return true;
			}
			if (v1.V0 > v2.V0)
			{
				return false;
			}
			if (v1.V1 < v2.V1)
			{
				return true;
			}
			if (v1.V1 > v2.V1)
			{
				return false;
			}
			if (v1.V2 < v2.V2)
			{
				return true;
			}
			if (v1.V2 > v2.V2)
			{
				return false;
			}
			if (v1.V3 < v2.V3)
			{
				return true;
			}
			if (v1.V3 > v2.V3)
			{
				return false;
			}
			if (v2.Alpha == 0 || v1.Alpha < v2.Alpha)
			{
				return v1.Alpha > 0;
			}
			return false;
		}

		public static bool operator <=(Version v1, Version v2)
		{
			return !(v1 > v2);
		}

		public static bool operator ==(Version v1, Version v2)
		{
			if (v1.V0 == v2.V0 && v1.V1 == v2.V1 && v1.V2 == v2.V2 && v1.V3 == v2.V3)
			{
				return v1.Alpha == v2.Alpha;
			}
			return false;
		}

		public static bool operator !=(Version v1, Version v2)
		{
			if (v1.V0 == v2.V0 && v1.V1 == v2.V1 && v1.V2 == v2.V2 && v1.V3 == v2.V3)
			{
				return v1.Alpha != v2.Alpha;
			}
			return true;
		}

		public bool Equals(Version other)
		{
			return this == other;
		}

		public override bool Equals(object obj)
		{
			if (obj is Version other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((((((((397 + V0) * 397) ^ (V1 + 4)) * 397) ^ (V2 + 3)) * 397) ^ (V3 + 2)) * 397) ^ (Alpha + 1);
		}
	}
}
