using System;
using UnityEngine;

namespace ScheduleOne.Levelling
{
	[Serializable]
	public struct FullRank
	{
		public const int TIER_COUNT = 5;

		public ERank Rank;

		[Range(1f, 5f)]
		public int Tier;

		public FullRank(ERank rank, int tier)
		{
			Rank = default(ERank);
			Tier = 0;
		}

		public override string ToString()
		{
			return null;
		}

		public FullRank NextRank()
		{
			return default(FullRank);
		}

		public float ToFloat()
		{
			return 0f;
		}

		public int GetRankIndex()
		{
			return 0;
		}

		public static string GetString(FullRank rank)
		{
			return null;
		}

		public static bool operator >(FullRank a, FullRank b)
		{
			return false;
		}

		public static bool operator <(FullRank a, FullRank b)
		{
			return false;
		}

		public static bool operator <=(FullRank a, FullRank b)
		{
			return false;
		}

		public static bool operator >=(FullRank a, FullRank b)
		{
			return false;
		}

		public static bool operator ==(FullRank a, FullRank b)
		{
			return false;
		}

		public static bool operator !=(FullRank a, FullRank b)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int CompareTo(FullRank other)
		{
			return 0;
		}
	}
}
