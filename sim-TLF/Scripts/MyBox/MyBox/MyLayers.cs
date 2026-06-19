using JetBrains.Annotations;
using UnityEngine;

namespace MyBox
{
	[PublicAPI]
	public static class MyLayers
	{
		public static LayerMask AddLayer(LayerMask mask, int layer)
		{
			return (int)mask | (1 << layer);
		}

		public static LayerMask AddLayer(LayerMask mask, string layer)
		{
			return AddLayer(mask, LayerMask.NameToLayer(layer));
		}

		public static LayerMask RemoveLayer(LayerMask mask, int layer)
		{
			return (int)mask & ~(1 << layer);
		}

		public static LayerMask RemoveLayer(LayerMask mask, string layer)
		{
			return RemoveLayer(mask, LayerMask.NameToLayer(layer));
		}

		public static LayerMask ToggleLayer(LayerMask mask, int layer)
		{
			return (int)mask ^ (1 << layer);
		}

		public static LayerMask ToggleLayer(LayerMask mask, string layer)
		{
			return ToggleLayer(mask, LayerMask.NameToLayer(layer));
		}

		public static LayerMask SetLayer(LayerMask mask, int layer, bool include)
		{
			if (!include)
			{
				return RemoveLayer(mask, layer);
			}
			return AddLayer(mask, layer);
		}

		public static LayerMask SetLayer(LayerMask mask, string layer, bool include)
		{
			return SetLayer(mask, LayerMask.NameToLayer(layer), include);
		}

		public static LayerMask ToLayerMask(int layer)
		{
			return 1 << layer;
		}

		public static LayerMask ToLayerMask(string layer)
		{
			return ToLayerMask(LayerMask.NameToLayer(layer));
		}

		public static bool LayerInMask(this LayerMask mask, int layer)
		{
			return ((1 << layer) & (int)mask) != 0;
		}

		public static bool LayerInMask(this LayerMask mask, string layer)
		{
			return mask.LayerInMask(LayerMask.NameToLayer(layer));
		}
	}
}
