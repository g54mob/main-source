using System;
using Easing;
using Screens;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class PaginatedScrollView : MonoBehaviour
	{
		[Serializable]
		public class PageSelectedEvent : UnityEvent<int>
		{
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("PaginatedScrollView");

		public bool isHorizontal;

		public DelegateCanvasGroup[] pages;

		[SerializeField]
		private VerticalLayoutGroup _layoutGroup;

		[SerializeField]
		private PageSelectedEvent _onPageSelected = new PageSelectedEvent();

		public ScrollRect scrollRect;

		public TweenFloat progressFloat = new TweenFloat();

		public int CurrentPage { get; private set; }

		public int TotalPages => pages.Length;

		public void SetPage(int pageNumber)
		{
			SetPage(pageNumber, instantly: false);
		}

		public void SetPage(int pageNumber, bool instantly)
		{
			if (CurrentPage == pageNumber)
			{
				return;
			}
			for (int i = 0; i < pages.Length; i++)
			{
				pages[i].gameObject.SetActive(i == pageNumber || i == CurrentPage);
				pages[i].SetInteractable(i == pageNumber);
			}
			if (!instantly)
			{
				if (pageNumber != CurrentPage)
				{
					SetScrollAmount((pageNumber >= CurrentPage) ? 1 : 0);
					float end = ((pageNumber < CurrentPage) ? 1 : 0);
					float start = (isHorizontal ? scrollRect.horizontalNormalizedPosition : scrollRect.verticalNormalizedPosition);
					progressFloat.Start(start, end, 0.4f, Easings.Functions.QuinticEaseOut);
				}
			}
			else
			{
				SetScrollAmount((pageNumber < CurrentPage) ? 1 : 0);
			}
			CurrentPage = pageNumber;
			_onPageSelected?.Invoke(CurrentPage);
		}

		private void Start()
		{
			RefreshPageTransforms();
		}

		public Selectable GetFirstSelectableOnCurrentPage()
		{
			return pages[CurrentPage].gameObject.GetComponentInChildren<Selectable>();
		}

		public void RefreshPageTransforms(int initialPageIndex = 0)
		{
			CurrentPage = 1;
			SetPage(initialPageIndex, instantly: true);
			if (!isHorizontal)
			{
				progressFloat.Stop();
				BaseScalingScreen componentInParent = GetComponentInParent<BaseScalingScreen>();
				Canvas componentInParent2 = GetComponentInParent<Canvas>();
				CanvasScaler componentInParent3 = componentInParent.GetComponentInParent<CanvasScaler>();
				RectTransform component = componentInParent.GetComponent<RectTransform>();
				Vector2 sizeDelta = component.sizeDelta;
				RectTransform component2 = component.GetComponentInChildren<SafeArea>().GetComponent<RectTransform>();
				float num = component2.anchorMax.y - component2.anchorMin.y;
				float num2;
				float spacing;
				switch (componentInParent2.renderMode)
				{
				case RenderMode.WorldSpace:
					num2 = sizeDelta.y * num;
					spacing = sizeDelta.y - num2;
					break;
				case RenderMode.ScreenSpaceOverlay:
					switch (componentInParent3.uiScaleMode)
					{
					case CanvasScaler.ScaleMode.ScaleWithScreenSize:
						switch (componentInParent3.screenMatchMode)
						{
						case CanvasScaler.ScreenMatchMode.Expand:
						{
							float num3 = sizeDelta.x / sizeDelta.y;
							float num4 = componentInParent3.referenceResolution.x / componentInParent3.referenceResolution.y;
							float num5 = ((num3 < num4) ? (num4 / num3) : 1f);
							num2 = componentInParent3.referenceResolution.y * num5 * num;
							spacing = componentInParent3.referenceResolution.y * num5 - num2;
							break;
						}
						default:
							Log.Error("Paginated Scroll View might not support screen match mode {0}. Please ensure/implement!", componentInParent3.screenMatchMode);
							num2 = componentInParent3.referenceResolution.y * num;
							spacing = componentInParent3.referenceResolution.y - num2;
							break;
						}
						break;
					default:
						Log.Error("Paginated Scroll View might not support ui scale mode {0}. Please ensure/implement!", componentInParent3.uiScaleMode);
						num2 = componentInParent3.referenceResolution.y * num;
						spacing = componentInParent3.referenceResolution.y - num2;
						break;
					}
					break;
				default:
					Log.Error("Paginated Scroll View might not support render mode {0}. Please ensure/implement!", componentInParent2.renderMode);
					num2 = componentInParent3.referenceResolution.y * num;
					spacing = componentInParent3.referenceResolution.y - num2;
					break;
				}
				_layoutGroup.spacing = spacing;
				for (int i = 0; i < scrollRect.content.childCount; i++)
				{
					RectTransform component3 = scrollRect.content.GetChild(i).GetComponent<RectTransform>();
					component3.sizeDelta = new Vector2(component3.sizeDelta.x, num2);
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content.GetComponent<RectTransform>());
				RefreshScrollAmount();
				return;
			}
			throw new NotImplementedException("Horizontal paginated scroll view is not yet supported.");
		}

		private void RefreshScrollAmount()
		{
			if (isHorizontal)
			{
				SetScrollAmount(Mathf.Round(scrollRect.horizontalNormalizedPosition));
			}
			else
			{
				SetScrollAmount(Mathf.Round(scrollRect.verticalNormalizedPosition));
			}
		}

		private void SetScrollAmount(float amount)
		{
			if (isHorizontal)
			{
				scrollRect.horizontalNormalizedPosition = amount;
			}
			else
			{
				scrollRect.verticalNormalizedPosition = amount;
			}
		}

		private void Update()
		{
			if (progressFloat.IsActive)
			{
				float scrollAmount = progressFloat.Tick(Time.deltaTime);
				SetScrollAmount(scrollAmount);
			}
		}
	}
}
