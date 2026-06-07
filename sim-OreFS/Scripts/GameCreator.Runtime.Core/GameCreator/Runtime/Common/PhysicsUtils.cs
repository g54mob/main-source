using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class PhysicsUtils
	{
		public class RaycastCompareAscending : IComparer<RaycastHit>
		{
			public int Compare(RaycastHit x, RaycastHit y)
			{
				return x.distance.CompareTo(y.distance);
			}
		}

		public class RaycastCompareDescending : IComparer<RaycastHit>
		{
			public int Compare(RaycastHit x, RaycastHit y)
			{
				return x.distance.CompareTo(y.distance) * -1;
			}
		}

		public static readonly RaycastCompareAscending CompareHitsAscending = new RaycastCompareAscending();

		public static readonly RaycastCompareDescending CompareHitsDescending = new RaycastCompareDescending();
	}
}
