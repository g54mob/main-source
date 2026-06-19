using UnityEngine;

namespace SimplySVG
{
	[ExecuteInEditMode]
	public class RendererProperties : MonoBehaviour
	{
		private Renderer render;

		public int layerId = int.MaxValue;

		public int order = int.MaxValue;

		public void SetRenderLayer(int newLayerId)
		{
			layerId = newLayerId;
			if (CheckLayerId(newLayerId))
			{
				GetTargetRenderer().sortingLayerID = newLayerId;
			}
		}

		public void SetRenderOrder(int order)
		{
			this.order = order;
			GetTargetRenderer().sortingOrder = order;
		}

		private static bool CheckLayerId(int layerId)
		{
			for (int i = 0; i < SortingLayer.layers.Length; i++)
			{
				if (SortingLayer.layers[i].id == layerId)
				{
					return true;
				}
			}
			return true;
		}

		public void Save()
		{
			if (CheckLayerId(layerId))
			{
				GetTargetRenderer().sortingLayerID = layerId;
			}
			if (order != int.MaxValue)
			{
				GetTargetRenderer().sortingOrder = order;
			}
		}

		public void OnEnable()
		{
			if (CheckLayerId(layerId))
			{
				SetRenderLayer(layerId);
			}
			if (order != int.MaxValue)
			{
				SetRenderOrder(order);
			}
		}

		public Renderer GetTargetRenderer()
		{
			if (render == null)
			{
				render = GetComponent<Renderer>();
			}
			if (Application.isEditor && render == null)
			{
				Debug.LogError("Simply SVG renderer properties should only be within game objects that have a renderer!");
			}
			return render;
		}
	}
}
