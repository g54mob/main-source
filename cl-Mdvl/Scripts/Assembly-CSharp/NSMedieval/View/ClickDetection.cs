using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.View
{
	public class ClickDetection : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		private bool isMouseOverElement;

		public bool IsMouseOverElement => isMouseOverElement;

		public event Action<Vector3> Clicked;

		public event Action<Vector3> RightClick;

		public event Action<Vector3> OnEnter;

		public event Action<Vector3> OnExit;

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				this.Clicked?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
			}
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				this.RightClick?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.OnEnter?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
			isMouseOverElement = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.OnExit?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
			isMouseOverElement = false;
		}

		private void OnDestroy()
		{
			this.OnEnter = null;
			this.OnExit = null;
			this.Clicked = null;
			this.RightClick = null;
		}

		public void OnLeavingMainScene()
		{
			this.OnEnter = null;
			this.OnExit = null;
			this.Clicked = null;
			this.RightClick = null;
		}
	}
}
