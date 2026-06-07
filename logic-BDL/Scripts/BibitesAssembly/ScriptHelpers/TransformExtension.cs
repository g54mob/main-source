using System.Collections.Generic;
using UnityEngine;

namespace ScriptHelpers
{
	public static class TransformExtension
	{
		public static List<GameObject> GetAllChilds(this GameObject Go)
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < Go.transform.childCount; i++)
			{
				list.Add(Go.transform.GetChild(i).gameObject);
			}
			return list;
		}
	}
}
