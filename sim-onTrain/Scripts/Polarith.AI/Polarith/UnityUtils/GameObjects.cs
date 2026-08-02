using System.Collections.Generic;
using UnityEngine;

namespace Polarith.UnityUtils
{
	public static class GameObjects
	{
		public static GameObject[] FindGameObjectsWithLayer(int layer)
		{
			GameObject[] array = Object.FindObjectsOfType<GameObject>();
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].layer == layer)
				{
					list.Add(array[i]);
				}
			}
			return list.ToArray();
		}

		public static GameObject[] FindGameObjectsWithLayer(string layerName)
		{
			return FindGameObjectsWithLayer(LayerMask.NameToLayer(layerName));
		}
	}
}
