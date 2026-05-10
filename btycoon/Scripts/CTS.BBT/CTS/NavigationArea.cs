using System;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct NavigationArea : IEquatable<NavigationArea>, IEquatable<int>
	{
		[field: SerializeField]
		[field: NavArea(false)]
		public int Area { get; private set; }

		public NavigationArea(int area)
		{
			Area = area;
		}

		public static implicit operator int(NavigationArea area)
		{
			return area.Area;
		}

		public static implicit operator NavigationArea(int area)
		{
			return new NavigationArea(area);
		}

		public static NavigationArea operator +(NavigationArea area1, NavigationArea area2)
		{
			return new NavigationArea(area1.Area + area2.Area);
		}

		public static NavigationArea operator -(NavigationArea area1, NavigationArea area2)
		{
			return new NavigationArea(area1.Area - area2.Area);
		}

		public static bool operator ==(NavigationArea area1, NavigationArea area2)
		{
			return area1.Equals(area2);
		}

		public static bool operator !=(NavigationArea area1, NavigationArea area2)
		{
			return !area1.Equals(area2);
		}

		public static bool operator ==(NavigationArea area, int integer)
		{
			return area.Equals(integer);
		}

		public static bool operator !=(NavigationArea area, int integer)
		{
			return !area.Equals(integer);
		}

		public static bool operator ==(int integer, NavigationArea area)
		{
			return area.Equals(integer);
		}

		public static bool operator !=(int integer, NavigationArea area)
		{
			return !area.Equals(integer);
		}

		public readonly bool Equals(NavigationArea other)
		{
			return Equals(other.Area);
		}

		public readonly bool Equals(int other)
		{
			return Area == other;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is NavigationArea other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return Area;
		}

		public readonly bool IsInMask(int mask)
		{
			return (1 << Area).ExistsInMask(mask);
		}

		public readonly bool IsInMask(NavigationMask mask)
		{
			return mask.HasArea(this);
		}

		public readonly NavigationMask ToMask()
		{
			return this;
		}
	}
}
