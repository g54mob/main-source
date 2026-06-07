using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_VRInputModule_DV : VRTK_VRInputModule
	{
		private bool pressedLastFrame;

		protected override bool IsEligibleClick(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			if (pointer.pointerEventData.eligibleForClick)
			{
				for (int i = 0; i < results.Count; i++)
				{
					RaycastResult pointerPressRaycast = results[i];
					if (ValidElement(pointerPressRaycast.gameObject))
					{
						GameObject gameObject = ExecuteEvents.ExecuteHierarchy(pointerPressRaycast.gameObject, pointer.pointerEventData, ExecuteEvents.pointerDownHandler);
						if (gameObject != null)
						{
							pointer.pointerEventData.pressPosition = pointer.pointerEventData.position;
							pointer.pointerEventData.pointerPressRaycast = pointerPressRaycast;
							pointer.pointerEventData.pointerPress = gameObject;
						}
						return true;
					}
				}
			}
			return false;
		}

		protected override void Drag(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			bool flag = pressedLastFrame;
			pointer.pointerEventData.dragging = pointer.IsSelectionButtonPressed() && pointer.pointerEventData.delta != Vector2.zero;
			pressedLastFrame = pointer.IsSelectionButtonPressed();
			if (pointer.CanDrag && (bool)pointer.pointerEventData.pointerDrag)
			{
				if (!ValidElement(pointer.pointerEventData.pointerDrag))
				{
					pointer.pointerEventData.pointerDrag = null;
					return;
				}
				if (pointer.pointerEventData.dragging)
				{
					if (IsHovering(pointer))
					{
						ExecuteEvents.ExecuteHierarchy(pointer.pointerEventData.pointerDrag, pointer.pointerEventData, ExecuteEvents.dragHandler);
					}
					return;
				}
				ExecuteEvents.ExecuteHierarchy(pointer.pointerEventData.pointerDrag, pointer.pointerEventData, ExecuteEvents.dragHandler);
				ExecuteEvents.ExecuteHierarchy(pointer.pointerEventData.pointerDrag, pointer.pointerEventData, ExecuteEvents.endDragHandler);
				for (int i = 0; i < results.Count; i++)
				{
					ExecuteEvents.ExecuteHierarchy(results[i].gameObject, pointer.pointerEventData, ExecuteEvents.dropHandler);
				}
				pointer.pointerEventData.pointerDrag = null;
			}
			else
			{
				if (!pointer.pointerEventData.dragging || flag)
				{
					return;
				}
				for (int j = 0; j < results.Count; j++)
				{
					RaycastResult raycastResult = results[j];
					if (ValidElement(raycastResult.gameObject))
					{
						ExecuteEvents.ExecuteHierarchy(raycastResult.gameObject, pointer.pointerEventData, ExecuteEvents.initializePotentialDrag);
						ExecuteEvents.ExecuteHierarchy(raycastResult.gameObject, pointer.pointerEventData, ExecuteEvents.beginDragHandler);
						GameObject gameObject = ExecuteEvents.ExecuteHierarchy(raycastResult.gameObject, pointer.pointerEventData, ExecuteEvents.dragHandler);
						if (gameObject != null)
						{
							pointer.pointerEventData.pointerDrag = gameObject;
						}
						break;
					}
				}
			}
		}
	}
}
