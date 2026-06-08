using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class Icon : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
	{
		[SerializeField]
		private bool hasSelfVisualFeedback = true;

		[SerializeField]
		private bool shouldRotate;

		[SerializeField]
		private bool shouldUseHighlightActiveImage;

		[SerializeField]
		private bool shouldUseSeparateHighlightActiveImage;

		[SerializeField]
		private Sprite highlightActiveSprite;

		[SerializeField]
		private bool shouldUseHighlightActiveColor;

		[SerializeField]
		private bool shouldOnlyAdditionalImageBeColored;

		[SerializeField]
		private Color highlightActiveColor = Constants.UI.Colors.SelectedBlack;

		[SerializeField]
		private UnityEvent onClick;

		[SerializeField]
		private AudioClipOptions clickSound;

		[SerializeField]
		private AudioClipOptions hoverSound;

		[SerializeField]
		private UiVisualState currentUiVisualState;

		private Image defaultImage;

		private Sprite defaultSprite;

		private Image separateHighlightActiveImage;

		private Transform defaultImageTransform;

		private Transform additionalImageTransform;

		private Sequence onInteractionSequence;

		protected override void Awake()
		{
			base.Awake();
			if (defaultImage == null)
			{
				defaultImage = GetComponentInChildren<Image>(includeInactive: true);
			}
			defaultSprite = defaultImage.sprite;
			defaultImageTransform = defaultImage.GetComponent<Transform>();
			if (shouldUseSeparateHighlightActiveImage)
			{
				separateHighlightActiveImage = Enumerable.First(GetComponentsInChildren<Image>(includeInactive: true), (Image x) => x != defaultImage);
				separateHighlightActiveImage.sprite = highlightActiveSprite;
				separateHighlightActiveImage.color = highlightActiveColor;
				separateHighlightActiveImage.gameObject.SetActive(shouldUseSeparateHighlightActiveImage);
				additionalImageTransform = separateHighlightActiveImage.GetComponent<Transform>();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetVisualState(currentUiVisualState);
		}

		protected override void Start()
		{
			base.Start();
			SetVisualState(currentUiVisualState, shouldOverride: true);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (hasSelfVisualFeedback)
			{
				SetVisualState(UiVisualState.Highlighted);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (hasSelfVisualFeedback)
			{
				SetVisualState(UiVisualState.Default);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (hasSelfVisualFeedback)
			{
				SetVisualState(UiVisualState.Active);
			}
			onClick?.Invoke();
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (hasSelfVisualFeedback)
			{
				SetVisualState(UiVisualState.Active);
			}
			onClick?.Invoke();
		}

		public void SetVisualState(int stateIndex)
		{
			SetVisualState((UiVisualState)stateIndex);
		}

		internal void SetVisualState(UiVisualState uiVisualState, bool shouldOverride = false, bool shouldPlayAnimation = true)
		{
			if (currentUiVisualState == uiVisualState && !shouldOverride)
			{
				return;
			}
			Sequence sequence = onInteractionSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			onInteractionSequence = DOTween.Sequence();
			switch (uiVisualState)
			{
			case UiVisualState.Default:
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOColor(defaultImage, Color.white, 0f));
				if (shouldUseSeparateHighlightActiveImage)
				{
					separateHighlightActiveImage.gameObject.SetActive(value: false);
				}
				else
				{
					TweenSettingsExtensions.InsertCallback(onInteractionSequence, 0f, delegate
					{
						defaultImage.sprite = defaultSprite;
					});
				}
				if (shouldPlayAnimation && shouldRotate)
				{
					TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DORotate(defaultImageTransform, Vector3.forward * 0f, 0.5f));
				}
				break;
			case UiVisualState.Highlighted:
				DoVisualChangesForHighlightedAndActiveState();
				if (shouldPlayAnimation && shouldRotate)
				{
					if (shouldUseSeparateHighlightActiveImage)
					{
						TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DORotate(additionalImageTransform, Vector3.forward * -10f, 0.5f));
					}
					TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DORotate(defaultImageTransform, Vector3.forward * -10f, 0.5f));
				}
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayGlobalSound(hoverSound);
				}
				break;
			case UiVisualState.Active:
				DoVisualChangesForHighlightedAndActiveState();
				if (shouldPlayAnimation)
				{
					if (shouldUseSeparateHighlightActiveImage)
					{
						TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DOPunchScale(additionalImageTransform, Vector3.one * 0.2f, 0.5f, 3));
					}
					TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DOPunchScale(defaultImageTransform, Vector3.one * 0.2f, 0.5f, 3));
				}
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayGlobalSound(clickSound);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("uiVisualState", uiVisualState, null);
			}
			currentUiVisualState = uiVisualState;
		}

		private void DoVisualChangesForHighlightedAndActiveState()
		{
			if (shouldUseHighlightActiveColor && !shouldOnlyAdditionalImageBeColored)
			{
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOColor(defaultImage, highlightActiveColor, 0f));
			}
			if (!shouldUseHighlightActiveImage)
			{
				return;
			}
			if (shouldUseSeparateHighlightActiveImage)
			{
				separateHighlightActiveImage.gameObject.SetActive(value: true);
				return;
			}
			TweenSettingsExtensions.InsertCallback(onInteractionSequence, 0f, delegate
			{
				defaultImage.sprite = highlightActiveSprite;
			});
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			SetVisualState(UiVisualState.Highlighted);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			SetVisualState(UiVisualState.Default);
		}

		private bool _003CAwake_003Eb__18_0(Image x)
		{
			return x != defaultImage;
		}

		private void _003CSetVisualState_003Eb__26_0()
		{
			defaultImage.sprite = defaultSprite;
		}

		private void _003CDoVisualChangesForHighlightedAndActiveState_003Eb__27_0()
		{
			defaultImage.sprite = highlightActiveSprite;
		}
	}
}
