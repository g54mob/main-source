using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CompassNavigatorPro
{
	public class MiniMapInteraction : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[NonSerialized]
		public CompassPro compass;

		private bool isDragging;

		private Vector3 dragStartWorldPosition;

		private Vector3 dampDir;

		private int dragEndFrame;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (compass != null)
			{
				compass.BubbleEvent(compass.OnMiniMapMouseEnter, eventData.position);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (compass != null)
			{
				compass.BubbleEvent(compass.OnMiniMapMouseExit, eventData.position);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (compass != null && !isDragging && dragEndFrame != Time.frameCount && compass.miniMapIconEvents)
			{
				Vector3 worldPositionFromPointerEvent = compass.GetWorldPositionFromPointerEvent(eventData.position);
				compass.BubbleEvent(compass.OnMiniMapMouseClick, worldPositionFromPointerEvent, (int)eventData.button);
			}
			isDragging = false;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				isDragging = true;
				if (compass != null && compass.currentMiniMapAllowsUserDrag)
				{
					dragStartWorldPosition = compass.GetWorldPositionFromPointerEvent(eventData.position);
				}
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (isDragging && compass != null && compass.currentMiniMapAllowsUserDrag)
			{
				Vector3 worldPositionFromPointerEvent = compass.GetWorldPositionFromPointerEvent(eventData.position);
				dampDir = worldPositionFromPointerEvent - dragStartWorldPosition;
				UpdateOffset();
			}
		}

		private void UpdateOffset()
		{
			if (!(compass == null))
			{
				compass.miniMapFollowOffset -= dampDir;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			isDragging = false;
			dragEndFrame = Time.frameCount;
			if (compass != null)
			{
				if (compass.miniMapFullScreenState && compass.miniMapFullScreenAutoResetDrag)
				{
					compass.ResetDragOffset();
				}
				else if (!compass.miniMapFullScreenState && compass.miniMapAutoResetDrag)
				{
					compass.ResetDragOffset();
				}
			}
		}
	}
}
