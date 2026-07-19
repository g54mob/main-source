using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	public static class IBoneExtensions
	{
		public static IEnumerable<IBone> Traverse(this IBone self)
		{
			yield return self;
			foreach (IBone child in self.Children)
			{
				foreach (IBone item in child.Traverse())
				{
					yield return item;
				}
			}
		}

		public static Vector3 CenterOfDescendant(this IBone self)
		{
			Vector3 zero = Vector3.zero;
			int num = 0;
			foreach (IBone item in self.Traverse())
			{
				zero += item.SkeletonLocalPosition;
				num++;
			}
			return zero / num;
		}
	}
}
