using UnityEngine;

namespace Cainos.Common
{
	public static class LayerUtils
	{
		public static bool Contains(this LayerMask layerMask, int layer)
		{
			return false;
		}

		public static void SetLayerAllChildren(this Transform root, int layer)
		{
		}
	}
}
