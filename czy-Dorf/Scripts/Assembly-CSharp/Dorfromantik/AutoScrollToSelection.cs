using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	[RequireComponent(typeof(ScrollRect))]
	public class AutoScrollToSelection : MonoBehaviour
	{
		[SerializeField]
		private Vector2 scrollPadding = new Vector2(100f, 100f);

		[SerializeField]
		private bool scrollToTopOnEnable = true;

		private List<Selectable> childSelectables;

		private Tween scrollTween;

		private ScrollRect scrollRect;

		private RectTransform currentFocusTarget;

		private bool subscribedToSelectionManager;

		[SerializeField]
		private SaveGameScreen connectedSaveGameScreen;

		private void Awake()
		{
			scrollRect = GetComponent<ScrollRect>();
			if (!connectedSaveGameScreen)
			{
				UpdateChildSelectables();
			}
		}

		private void UpdateChildSelectables()
		{
			childSelectables = new List<Selectable>(GetComponentsInChildren<Selectable>());
		}

		private void OnEnable()
		{
			if ((bool)Singleton<UiSelectionManager>.Instance)
			{
				Singleton<UiSelectionManager>.Instance.OnSelect += ChangeSelection;
			}
			if ((bool)connectedSaveGameScreen)
			{
				UpdateChildSelectables();
				connectedSaveGameScreen.OnSaveFilesUpdated += UpdateChildSelectables;
			}
			if (scrollToTopOnEnable)
			{
				scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, 1f);
			}
		}

		private void ChangeSelection(Selectable newSelectable)
		{
			if (!base.gameObject.activeInHierarchy || !newSelectable.gameObject.activeInHierarchy || !childSelectables.Contains(newSelectable))
			{
				return;
			}
			RectTransform component = newSelectable.GetComponent<RectTransform>();
			if (!component)
			{
				Debug.LogError($"wants to scroll to {newSelectable}, but it doesn't have a RectTransform", newSelectable);
				return;
			}
			currentFocusTarget = component;
			Vector2 endValue = ((newSelectable.navigation.selectOnUp == null) ? new Vector2(scrollRect.normalizedPosition.x, 1f) : ScrollViewFocusFunctions.CalculateScrollPositionWhereTargetIsVisible(scrollRect, component, scrollPadding));
			TweenExtensions.Kill(scrollTween);
			scrollTween = DOTween.To(() => scrollRect.normalizedPosition, delegate(Vector2 x)
			{
				scrollRect.normalizedPosition = x;
			}, endValue, 0.3f);
		}

		private void CalculateScrollPosWhereTargetIsVisible()
		{
			ScrollViewFocusFunctions.CalculateScrollPositionWhereTargetIsVisible(scrollRect, currentFocusTarget, scrollPadding);
		}

		private void SetNormalizedPos(float normalizedYPos)
		{
			scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, normalizedYPos);
		}

		private void OnDisable()
		{
			if ((bool)connectedSaveGameScreen)
			{
				connectedSaveGameScreen.OnSaveFilesUpdated -= UpdateChildSelectables;
			}
			if ((bool)Singleton<UiSelectionManager>.Instance)
			{
				Singleton<UiSelectionManager>.Instance.OnSelect -= ChangeSelection;
			}
		}

		private Vector2 _003CChangeSelection_003Eb__11_0()
		{
			return scrollRect.normalizedPosition;
		}

		private void _003CChangeSelection_003Eb__11_1(Vector2 x)
		{
			scrollRect.normalizedPosition = x;
		}
	}
}
