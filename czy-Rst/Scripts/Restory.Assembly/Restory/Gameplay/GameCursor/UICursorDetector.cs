using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.Gameplay.GameCursor
{
	public sealed class UICursorDetector
	{
		private readonly EventSystem eventSystem;

		private readonly List<RaycastResult> hits = new List<RaycastResult>(4);

		private PointerEventData pointerData;

		public UICursorDetector()
		{
			eventSystem = EventSystem.current;
		}

		public bool TryToDetect(Vector2 pointerPosition, out GameObject hitObject)
		{
			hitObject = null;
			if (!eventSystem.IsPointerOverGameObject())
			{
				return false;
			}
			if (pointerData == null)
			{
				pointerData = new PointerEventData(eventSystem);
			}
			pointerData.position = pointerPosition;
			hits.Clear();
			eventSystem.RaycastAll(pointerData, hits);
			foreach (RaycastResult hit in hits)
			{
				if (hit.module is GraphicRaycaster)
				{
					hitObject = hit.gameObject;
					return true;
				}
			}
			return false;
		}
	}
}
