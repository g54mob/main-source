using UnityEngine;

namespace CTS
{
	public struct NamedLayerMask
	{
		private LayerMask? mask;

		private string[] names;

		public static implicit operator LayerMask(NamedLayerMask p_namedLayerMask)
		{
			LayerMask? layerMask = p_namedLayerMask.mask;
			if (layerMask.HasValue)
			{
				return p_namedLayerMask.mask.Value;
			}
			p_namedLayerMask.mask = default(LayerMask);
			string[] array = p_namedLayerMask.names;
			foreach (string layerName in array)
			{
				ref LayerMask? reference = ref p_namedLayerMask.mask;
				reference = (int?)reference | (1 << LayerMask.NameToLayer(layerName));
			}
			return p_namedLayerMask.mask.Value;
		}

		public static implicit operator int(NamedLayerMask p_namedLayerMask)
		{
			return (LayerMask)p_namedLayerMask;
		}

		public NamedLayerMask(params string[] p_layers)
		{
			names = p_layers;
			mask = null;
		}
	}
}
