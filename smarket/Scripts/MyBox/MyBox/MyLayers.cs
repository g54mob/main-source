using UnityEngine;

namespace MyBox
{
	public static class MyLayers
	{
		public static LayerMask ToLayerMask(int layer)
		{
			return default(LayerMask);
		}

		public static bool LayerInMask(this LayerMask mask, int layer)
		{
			return false;
		}
	}
}
