using System.Collections.Generic;
using UnityEngine;

namespace MateoRyhr
{
	public static class TransformUtil
	{
		public static List<Transform> GetAllChildren(Transform parent)
		{
			List<Transform> list = new List<Transform>();
			foreach (Transform item in parent)
			{
				list.Add(item);
				list.AddRange(GetAllChildren(item));
			}
			return list;
		}
	}
}
