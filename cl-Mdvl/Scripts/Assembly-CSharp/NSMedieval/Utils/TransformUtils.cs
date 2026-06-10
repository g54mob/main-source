using UnityEngine;

namespace NSMedieval.Utils
{
	public static class TransformUtils
	{
		public static Transform FindChildWithTag(this Transform transform, string tag)
		{
			foreach (Transform item in transform)
			{
				if (item.CompareTag(tag))
				{
					return item;
				}
			}
			return null;
		}
	}
}
