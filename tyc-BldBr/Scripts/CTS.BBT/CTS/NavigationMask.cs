using System;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct NavigationMask : IEquatable<NavigationMask>, IEquatable<int>
	{
		[field: SerializeField]
		[field: NavArea(true)]
		public int Area { get; private set; }

		public NavigationMask(int area)
		{
			Area = area;
		}

		public static implicit operator int(NavigationMask area)
		{
			return area.Area;
		}

		public static implicit operator NavigationMask(int area)
		{
			return new NavigationMask(area);
		}

		public static implicit operator NavigationMask(NavigationArea area)
		{
			return new NavigationMask(1 << area.Area);
		}

		public static NavigationMask operator +(NavigationMask area1, NavigationMask area2)
		{
			return new NavigationMask(area1.Area + area2.Area);
		}

		public static NavigationMask operator -(NavigationMask area1, NavigationMask area2)
		{
			return new NavigationMask(area1.Area - area2.Area);
		}

		public static bool operator ==(NavigationMask area1, NavigationMask area2)
		{
			return area1.Equals(area2);
		}

		public static bool operator !=(NavigationMask area1, NavigationMask area2)
		{
			return !area1.Equals(area2);
		}

		public static bool operator ==(NavigationMask area, int integer)
		{
			return area.Equals(integer);
		}

		public static bool operator !=(NavigationMask area, int integer)
		{
			return !area.Equals(integer);
		}

		public static bool operator ==(int integer, NavigationMask area)
		{
			return area.Equals(integer);
		}

		public static bool operator !=(int integer, NavigationMask area)
		{
			return !area.Equals(integer);
		}

		public bool Equals(NavigationMask other)
		{
			return Equals(other.Area);
		}

		public bool Equals(int other)
		{
			return Area == other;
		}

		public override bool Equals(object obj)
		{
			if (obj is NavigationMask other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Area;
		}

		public readonly bool HasArea(int area)
		{
			return (1 << area).ExistsInMask(Area);
		}

		public readonly bool HasArea(NavigationArea area)
		{
			return HasArea(area.Area);
		}
	}
}
