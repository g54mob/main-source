using System.Collections.Generic;
using UnityEngine;

namespace MateoRyhr
{
	public static class LayerUtil
	{
		public static bool LayerContains(this LayerMask layerMask, int layer)
		{
			return (int)layerMask == ((int)layerMask | (1 << layer));
		}

		public static void ChangeLayer(List<Transform> objects, int layer)
		{
			foreach (Transform @object in objects)
			{
				@object.gameObject.layer = layer;
			}
		}
	}
}
