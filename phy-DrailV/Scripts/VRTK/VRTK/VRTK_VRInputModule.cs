using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VRTK
{
	public class VRTK_VRInputModule : PointerInputModule
	{
		public List<VRTK_UIPointer> pointers = new List<VRTK_UIPointer>();

		public virtual void Initialise()
		{
			pointers.Clear();
		}

		public override bool IsModuleSupported()
		{
			return false;
		}

		public override void Process()
		{
			for (int i = 0; i < pointers.Count; i++)
			{
				VRTK_UIPointer vRTK_UIPointer = pointers[i];
				if (vRTK_UIPointer.gameObject.activeInHierarchy && vRTK_UIPointer.enabled)
				{
					List<RaycastResult> list = new List<RaycastResult>();
					if (vRTK_UIPointer.PointerActive())
					{
						list = CheckRaycasts(vRTK_UIPointer);
					}
					if (vRTK_UIPointer.CanHover)
					{
						HandlePointerExitAndEnter(vRTK_UIPointer.pointerEventData, (list.Count > 0) ? list[0].gameObject : null);
					}
					Click(vRTK_UIPointer, list);
					Drag(vRTK_UIPointer, list);
					Scroll(vRTK_UIPointer, list);
				}
			}
		}

		public void ClearPointerInteraction(VRTK_UIPointer pointer)
		{
			List<RaycastResult> results = new List<RaycastResult>();
			HandlePointerExitAndEnter(pointer.pointerEventData, null);
			Click(pointer, results);
			Drag(pointer, results);
			Scroll(pointer, results);
		}

		protected virtual List<RaycastResult> CheckRaycasts(VRTK_UIPointer pointer)
		{
			RaycastResult pointerCurrentRaycast = new RaycastResult
			{
				worldPosition = pointer.GetOriginPosition(),
				worldNormal = pointer.GetOriginForward()
			};
			pointer.pointerEventData.pointerCurrentRaycast = pointerCurrentRaycast;
			List<RaycastResult> list = new List<RaycastResult>();
			base.eventSystem.RaycastAll(pointer.pointerEventData, list);
			return list;
		}

		protected virtual bool CheckTransformTree(Transform target, Transform source)
		{
			if (target == null)
			{
				return false;
			}
			if (target == source)
			{
				return true;
			}
			return CheckTransformTree(target.transform.parent, source);
		}

		protected virtual bool NoValidCollision(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			if (results.Count != 0)
			{
				return !CheckTransformTree(results[0].gameObject.transform, pointer.pointerEventData.pointerEnter.transform);
			}
			return true;
		}

		protected virtual bool IsHovering(VRTK_UIPointer pointer)
		{
			for (int i = 0; i < pointer.pointerEventData.hovered.Count; i++)
			{
				GameObject gameObject = pointer.pointerEventData.hovered[i];
				if (pointer.pointerEventData.pointerEnter != null && gameObject != null && CheckTransformTree(gameObject.transform, pointer.pointerEventData.pointerEnter.transform))
				{
					return true;
				}
			}
			return false;
		}

		protected virtual bool ValidElement(GameObject obj)
		{
			VRTK_UICanvas componentInParent = obj.GetComponentInParent<VRTK_UICanvas>();
			if (!(componentInParent != null) || !componentInParent.enabled)
			{
				return false;
			}
			return true;
		}

		protected virtual void CheckPointerHoverClick(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			if (pointer.hoverDurationTimer > 0f)
			{
				pointer.hoverDurationTimer -= Time.deltaTime;
			}
			if (pointer.canClickOnHover && pointer.hoverDurationTimer <= 0f)
			{
				pointer.canClickOnHover = false;
				ClickOnDown(pointer, results, forceClick: true);
			}
		}

		protected virtual void Click(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			switch (pointer.clickMethod)
			{
			case VRTK_UIPointer.ClickMethods.ClickOnButtonUp:
				ClickOnUp(pointer, results);
				break;
			case VRTK_UIPointer.ClickMethods.ClickOnButtonDown:
				ClickOnDown(pointer, results);
				break;
			}
		}

		protected virtual void ClickOnUp(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			if (pointer.CanClickUp)
			{
				pointer.pointerEventData.eligibleForClick = pointer.ValidClick(checkLastClick: false);
				if (!AttemptClick(pointer))
				{
					IsEligibleClick(pointer, results);
				}
			}
		}

		protected virtual void ClickOnDown(VRTK_UIPointer pointer, List<RaycastResult> results, bool forceClick = false)
		{
			if (pointer.CanClickDown)
			{
				pointer.pointerEventData.eligibleForClick = forceClick || pointer.ValidClick(checkLastClick: true);
				if (IsEligibleClick(pointer, results))
				{
					pointer.pointerEventData.eligibleForClick = false;
					AttemptClick(pointer);
				}
			}
		}

		protected virtual bool IsEligibleClick(VRTK_UIPointer pointer, List<RaycastResult> results)
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
							return true;
						}
					}
				}
			}
			return false;
		}

		protected virtual bool AttemptClick(VRTK_UIPointer pointer)
		{
			if ((bool)pointer.pointerEventData.pointerPress)
			{
				if (!ValidElement(pointer.pointerEventData.pointerPress))
				{
					pointer.pointerEventData.pointerPress = null;
					return true;
				}
				if (pointer.pointerEventData.eligibleForClick)
				{
					if (!IsHovering(pointer))
					{
						ExecuteEvents.ExecuteHierarchy(pointer.pointerEventData.pointerPress, pointer.pointerEventData, ExecuteEvents.pointerUpHandler);
						pointer.pointerEventData.pointerPress = null;
					}
				}
				else
				{
					pointer.OnUIPointerElementClick(pointer.SetUIPointerEvent(pointer.pointerEventData.pointerPressRaycast, pointer.pointerEventData.pointerPress));
					ExecuteEvents.ExecuteHierarchy(pointer.pointerEventData.pointerPress, pointer.pointerEventData, ExecuteEvents.pointerClickHandler);
					ExecuteEvents.ExecuteHierarchy(pointer.pointerEventData.pointerPress, pointer.pointerEventData, ExecuteEvents.pointerUpHandler);
					pointer.pointerEventData.pointerPress = null;
				}
				return true;
			}
			return false;
		}

		protected virtual void Drag(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			pointer.pointerEventData.dragging = pointer.IsSelectionButtonPressed() && pointer.pointerEventData.delta != Vector2.zero;
			if ((bool)pointer.pointerEventData.pointerDrag)
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
				if (!pointer.pointerEventData.dragging)
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
							break;
						}
					}
				}
			}
		}

		protected virtual void Scroll(VRTK_UIPointer pointer, List<RaycastResult> results)
		{
			if (!pointer.CanScroll)
			{
				return;
			}
			pointer.pointerEventData.scrollDelta = ((pointer.controllerEvents != null) ? pointer.controllerEvents.GetTouchpadAxis() : Vector2.zero);
			bool state = false;
			for (int i = 0; i < results.Count; i++)
			{
				if (pointer.pointerEventData.scrollDelta != Vector2.zero && ExecuteEvents.ExecuteHierarchy(results[i].gameObject, pointer.pointerEventData, ExecuteEvents.scrollHandler) != null)
				{
					state = true;
				}
			}
			if (pointer.controllerRenderModel != null)
			{
				VRTK_SDK_Bridge.SetControllerRenderModelWheel(pointer.controllerRenderModel, state);
			}
		}
	}
}
