using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	[RequireComponent(typeof(ScrollRect))]
	public class UiDropdownScrollRectAutoScroll : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private InputActionReference inputAction;

		public float scrollSpeed = 10f;

		private bool isMouseOver;

		private List<Selectable> selectables = new List<Selectable>();

		private ScrollRect scrollRect;

		private Vector2 nextScrollPosition = Vector2.up;

		public void OnEnable()
		{
			if ((bool)scrollRect)
			{
				scrollRect.content.GetComponentsInChildren(selectables);
			}
		}

		public void Awake()
		{
			scrollRect = GetComponent<ScrollRect>();
		}

		public void Start()
		{
			if ((bool)scrollRect)
			{
				scrollRect.content.GetComponentsInChildren(selectables);
			}
			ScrollToSelected(shouldQuickScroll: true);
		}

		public void Update()
		{
			if (SystemInfo.deviceType != DeviceType.Handheld || UnityEngine.InputSystem.Gamepad.all.Count > 1)
			{
				InputScroll();
				if (!isMouseOver)
				{
					scrollRect.normalizedPosition = Vector2.Lerp(scrollRect.normalizedPosition, nextScrollPosition, scrollSpeed * Time.unscaledDeltaTime);
				}
				else
				{
					nextScrollPosition = scrollRect.normalizedPosition;
				}
			}
		}

		private void InputScroll()
		{
			if (selectables.Count > 0)
			{
				ScrollToSelected(shouldQuickScroll: false);
			}
		}

		private void ScrollToSelected(bool shouldQuickScroll)
		{
			int num = -1;
			Selectable selectable = (EventSystem.current.currentSelectedGameObject ? EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>() : null);
			if ((bool)selectable)
			{
				num = selectables.IndexOf(selectable);
			}
			if (num > -1)
			{
				if (shouldQuickScroll)
				{
					scrollRect.normalizedPosition = new Vector2(0f, 1f - (float)num / ((float)selectables.Count - 1f));
					nextScrollPosition = scrollRect.normalizedPosition;
				}
				else
				{
					nextScrollPosition = new Vector2(0f, 1f - (float)num / ((float)selectables.Count - 1f));
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isMouseOver = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isMouseOver = false;
			ScrollToSelected(shouldQuickScroll: false);
		}
	}
}
