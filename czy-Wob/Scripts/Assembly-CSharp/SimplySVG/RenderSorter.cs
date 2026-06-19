using UnityEngine;

namespace SimplySVG
{
	public class RenderSorter : MonoBehaviour
	{
		public bool autoUpdate;

		public int sortingLayerID;

		public void Sort()
		{
			int orderCounter = 0;
			UpdateChildren(base.transform, ref orderCounter);
		}

		private void Update()
		{
			if (autoUpdate)
			{
				Sort();
			}
		}

		private void UpdateChildren(Transform node, ref int orderCounter)
		{
			Renderer component = node.GetComponent<Renderer>();
			RendererProperties component2 = node.GetComponent<RendererProperties>();
			if (component2 != null)
			{
				if (component2.layerId == sortingLayerID)
				{
					component2.SetRenderOrder(orderCounter);
					orderCounter++;
				}
			}
			else if (component != null && component.sortingLayerID == sortingLayerID)
			{
				component.sortingOrder = orderCounter;
				orderCounter++;
			}
			for (int i = 0; i < node.childCount; i++)
			{
				Transform child = node.GetChild(i);
				UpdateChildren(child, ref orderCounter);
			}
		}
	}
}
