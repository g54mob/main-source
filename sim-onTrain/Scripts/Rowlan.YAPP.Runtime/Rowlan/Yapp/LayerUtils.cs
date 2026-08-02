using UnityEngine;

namespace Rowlan.Yapp
{
	public class LayerUtils
	{
		public enum LayerIndex
		{
			Nothing = 0,
			Everything = int.MaxValue,
			IgnoreRaycast = 2
		}

		public static LayerIndex PreviewLayerIndex = LayerIndex.IgnoreRaycast;

		public static LayerMask GetPreviewLayerMask(LayerMask layerMask)
		{
			if (ApplicationSettings.useInstanceAsPreview)
			{
				return (int)layerMask & ~(1 << (int)PreviewLayerIndex);
			}
			return layerMask;
		}

		public static void SetLayer(Transform parent, int layer)
		{
			parent.gameObject.layer = layer;
			for (int i = 0; i < parent.childCount; i++)
			{
				SetLayer(parent.GetChild(i), layer);
			}
		}
	}
}
