using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
	public static List<Transform> GetChildrenTransforms(this Component component, bool includeInactive = true)
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in component.transform)
		{
			if (!(item == component.transform) && (includeInactive || item.gameObject.activeSelf))
			{
				list.Add(item);
			}
		}
		return list;
	}
}
