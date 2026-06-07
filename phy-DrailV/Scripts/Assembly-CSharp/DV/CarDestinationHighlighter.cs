using System;
using UnityEngine;

namespace DV
{
	public class CarDestinationHighlighter
	{
		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private GameObject highlighterGO;

		private Renderer highlighterRenderer;

		private GameObject directionArrowGO;

		private Renderer[] directionArrowRenderers;

		public Renderer Renderer => highlighterRenderer;

		public CarDestinationHighlighter(GameObject highlighterGO, GameObject directionArrowGO)
		{
			this.highlighterGO = highlighterGO;
			highlighterGO.transform.SetParent(WorldMover.OriginShiftParent);
			highlighterRenderer = highlighterGO.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			this.directionArrowGO = directionArrowGO;
			if ((bool)directionArrowGO)
			{
				directionArrowGO.transform.SetParent(WorldMover.OriginShiftParent);
				Renderer[] componentsInChildren = directionArrowGO.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				directionArrowRenderers = componentsInChildren;
			}
			else
			{
				directionArrowRenderers = Array.Empty<Renderer>();
			}
			TurnOff();
		}

		public void Highlight(Vector3 position, Vector3 forward, Bounds bounds, Material highlightMaterial)
		{
			highlighterRenderer.material = highlightMaterial;
			Renderer[] array = directionArrowRenderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].material = highlightMaterial;
			}
			highlighterGO.transform.localScale = bounds.size + HIGHLIGHT_BOUNDS_EXTENSION;
			float num = highlighterGO.transform.localScale.y / 2f;
			highlighterGO.transform.SetPositionAndRotation(position + Vector3.up * num, Quaternion.LookRotation(forward));
			if ((bool)directionArrowGO)
			{
				directionArrowGO.transform.SetPositionAndRotation(position + Vector3.up * num, Quaternion.LookRotation(forward));
			}
			highlighterGO.SetActive(value: true);
			if ((bool)directionArrowGO)
			{
				directionArrowGO.SetActive(value: true);
			}
		}

		public void TurnOff()
		{
			highlighterGO.SetActive(value: false);
			if ((bool)directionArrowGO)
			{
				directionArrowGO.SetActive(value: false);
			}
		}

		public void Destroy()
		{
			if (highlighterGO != null)
			{
				UnityEngine.Object.Destroy(highlighterGO.gameObject);
			}
			if (directionArrowGO != null)
			{
				UnityEngine.Object.Destroy(directionArrowGO.gameObject);
			}
		}
	}
}
