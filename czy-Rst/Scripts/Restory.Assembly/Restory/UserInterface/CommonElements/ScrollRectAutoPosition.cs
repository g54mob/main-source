using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	[RequireComponent(typeof(ScrollRect))]
	public sealed class ScrollRectAutoPosition : BaseScrollRectAutoPosition
	{
		private GameObject currentElement;

		private RectTransform currentElementRectTransform;

		public bool IsRolling { get; set; }

		private void OnEnable()
		{
			IsRolling = false;
			if (!(currentElementRectTransform == null))
			{
				UpdatePosition(currentElementRectTransform);
			}
		}

		private void Update()
		{
			UpdateSelected();
		}

		private void UpdateSelected()
		{
			EventSystem current = EventSystem.current;
			if (current == null)
			{
				return;
			}
			GameObject currentSelectedGameObject = current.currentSelectedGameObject;
			if (currentSelectedGameObject == null || (currentSelectedGameObject == currentElement && !IsRolling))
			{
				return;
			}
			if (currentSelectedGameObject != currentElement)
			{
				if (!currentSelectedGameObject.transform.IsChildOf(scrollRect.content))
				{
					return;
				}
				currentElement = currentSelectedGameObject;
				currentElementRectTransform = currentSelectedGameObject.GetComponent<RectTransform>();
				if (currentElementRectTransform == null)
				{
					return;
				}
			}
			UpdatePosition(currentElementRectTransform);
		}

		public void UpdateForced()
		{
			currentElement = null;
			UpdateSelected();
		}

		public void ResetPosition()
		{
			currentElement = null;
			scrollRect.verticalNormalizedPosition = 1f;
		}
	}
}
