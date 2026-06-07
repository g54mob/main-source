using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class ScrollRectAutoScroll : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect m_scrollRect;

		[SerializeField]
		private RectTransform m_viewport;

		[SerializeField]
		private Transform m_content;

		[SerializeField]
		private List<UINavElement> m_allElementsInView = new List<UINavElement>();

		private void Start()
		{
			RefreshScrollView();
		}

		private void OnDestroy()
		{
			UnsubscribeElements();
		}

		public void RefreshScrollView()
		{
			UnsubscribeElements();
			SetScrollViewElements();
		}

		private void UnsubscribeElements()
		{
			foreach (UINavElement item in m_allElementsInView)
			{
				if (!(item == null))
				{
					item.SelectElementEvent = (Action<RectTransform>)Delegate.Remove(item.SelectElementEvent, new Action<RectTransform>(UpdateAutoScroll));
				}
			}
		}

		private void SetScrollViewElements()
		{
			if (!IsScrollRectValid(m_scrollRect))
			{
				return;
			}
			foreach (UINavElement item in m_allElementsInView)
			{
				if (!(item == null))
				{
					RectTransform rectTransformReference = item.GetRectTransformReference();
					if (IsPartOfScrollRectContent(m_scrollRect, rectTransformReference))
					{
						item.SelectElementEvent = (Action<RectTransform>)Delegate.Combine(item.SelectElementEvent, new Action<RectTransform>(UpdateAutoScroll));
					}
				}
			}
		}

		public void AddElement(UINavElement element)
		{
			m_allElementsInView.Add(element);
		}

		public void AddElements(List<UINavElement> elements)
		{
			if (elements == null || elements.Count < 1)
			{
				return;
			}
			foreach (UINavElement element in elements)
			{
				AddElement(element);
			}
		}

		public void FindAllElements()
		{
			m_allElementsInView.Clear();
			for (int i = 0; i < m_content.childCount; i++)
			{
				UINavElement componentInChildren = m_content.GetChild(i).GetComponentInChildren<UINavElement>();
				if (componentInChildren != null)
				{
					AddElement(componentInChildren);
				}
			}
		}

		private void UpdateAutoScroll(RectTransform target)
		{
			RectBoundary rectBoundaryInTargetLocalSpace = target.GetRectBoundaryInTargetLocalSpace(m_viewport);
			bool num = rectBoundaryInTargetLocalSpace.Max.y > m_viewport.rect.yMax;
			bool flag = rectBoundaryInTargetLocalSpace.Min.y < m_viewport.rect.yMin;
			if (num)
			{
				ScrollUp(m_scrollRect, m_viewport, rectBoundaryInTargetLocalSpace);
			}
			else if (flag)
			{
				ScrollDown(m_scrollRect, m_viewport, rectBoundaryInTargetLocalSpace);
			}
		}

		private static void ScrollUp(ScrollRect scrollRect, RectTransform viewport, RectBoundary scrollTarget)
		{
			float scrollDelta = scrollTarget.Max.y - viewport.rect.yMax;
			Scroll(scrollRect, viewport.rect.height, scrollDelta);
		}

		private static void ScrollDown(ScrollRect scrollRect, RectTransform viewport, RectBoundary scrollTarget)
		{
			float scrollDelta = scrollTarget.Min.y - viewport.rect.yMin;
			Scroll(scrollRect, viewport.rect.height, scrollDelta);
		}

		private static void Scroll(ScrollRect scrollRect, float viewPortHeight, float scrollDelta)
		{
			float num = scrollRect.content.rect.height - viewPortHeight;
			float num2 = 1f / num;
			scrollRect.verticalNormalizedPosition += scrollDelta * num2;
		}

		private static bool IsScrollRectValid(ScrollRect scrollRect)
		{
			return scrollRect != null;
		}

		private static bool IsPartOfScrollRectContent(ScrollRect scrollRect, RectTransform rectTransform)
		{
			if (rectTransform != null)
			{
				return rectTransform.IsChildOf(scrollRect.content);
			}
			return false;
		}

		private static RectTransform GetCurrentSelectedRectTransform()
		{
			GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
			if (currentSelectedGameObject != null)
			{
				return currentSelectedGameObject.GetComponent<RectTransform>();
			}
			return null;
		}
	}
}
