using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public class ClippingObjectBehaviour
	{
		public enum ELayerType
		{
			DEFAULT = 0,
			NO_CLIPPING = 1
		}

		[SerializeField]
		private Renderer[] m_renderers;

		[SerializeField]
		private GameObject[] m_others;

		public void ValidateRenderersLayer()
		{
			Renderer[] renderers = m_renderers;
			foreach (Renderer renderer in renderers)
			{
				if (!(renderer == null))
				{
					int layer = renderer.gameObject.layer;
					if (layer != ClippingObjectSettings.DefaultLayer && layer != ClippingObjectSettings.NoClippingLayer)
					{
						Debug.LogError("The current layer is " + LayerMask.LayerToName(renderer.gameObject.layer) + " but will be updated to " + LayerMask.LayerToName(ClippingObjectSettings.NoClippingLayer), renderer);
					}
				}
			}
			GameObject[] others = m_others;
			foreach (GameObject gameObject in others)
			{
				if (!(gameObject == null))
				{
					int layer2 = gameObject.layer;
					if (layer2 != ClippingObjectSettings.DefaultLayer && layer2 != ClippingObjectSettings.NoClippingLayer)
					{
						Debug.LogError("The current layer is " + LayerMask.LayerToName(gameObject.layer) + " but will be updated to " + LayerMask.LayerToName(ClippingObjectSettings.NoClippingLayer), gameObject);
					}
				}
			}
		}

		public void SetRenderersLayer(ELayerType layerType)
		{
			int layerByType = GetLayerByType(layerType);
			Renderer[] renderers = m_renderers;
			foreach (Renderer renderer in renderers)
			{
				if (renderer != null)
				{
					renderer.gameObject.layer = layerByType;
				}
			}
			GameObject[] others = m_others;
			foreach (GameObject gameObject in others)
			{
				if (gameObject != null)
				{
					gameObject.layer = layerByType;
				}
			}
		}

		private int GetLayerByType(ELayerType layerType)
		{
			if (layerType != ELayerType.DEFAULT)
			{
				return ClippingObjectSettings.NoClippingLayer;
			}
			return ClippingObjectSettings.DefaultLayer;
		}
	}
}
