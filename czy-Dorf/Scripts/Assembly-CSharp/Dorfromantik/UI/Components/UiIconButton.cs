using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dorfromantik.UI.Components
{
	public class UiIconButton : UiInteractable
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<UiVisualStateInfo, bool> _003C_003E9__25_0;

			public static Func<UiVisualStateInfo, bool> _003C_003E9__29_0;

			internal bool _003CSetInitial_003Eb__25_0(UiVisualStateInfo visualStateInfo)
			{
				return visualStateInfo.canvasGroup != null;
			}

			internal bool _003CSetVisualStateDisabled_003Eb__29_0(UiVisualStateInfo visualStateInfo)
			{
				return visualStateInfo.isCurrentlyActive;
			}
		}

		[SerializeField]
		protected float transitionDuration = 0.25f;

		[SerializeField]
		protected GameObject activatedUnderline;

		[SerializeField]
		protected float activatedUnderlineWidth = 50f;

		[SerializeField]
		protected float pressedPunchScaleFactor = 0.15f;

		[SerializeField]
		protected float pressedPunchScaleDuration = 0.3f;

		[SerializeField]
		protected int pressedPunchScaleVibrato = 4;

		protected float groupAlphaVisible = 1f;

		protected Sequence onActivatedSequence;

		protected Sequence onHoveredSequence;

		protected Sequence onEnabledSequence;

		protected Sequence onDisabledSequence;

		protected Sequence onPressedSequence;

		private UiSelectable uiSelectable;

		protected override void Awake()
		{
			base.Awake();
			uiSelectable = GetComponent<UiSelectable>();
			if (uiSelectable != null)
			{
				uiSelectable.OnSelected += OnSelect;
				uiSelectable.OnDeselected += OnDeselect;
				uiSelectable.OnSubmitted += OnClick;
			}
		}

		protected void OnDestroy()
		{
			if (uiSelectable != null)
			{
				uiSelectable.OnSelected -= OnSelect;
				uiSelectable.OnDeselected -= OnDeselect;
				uiSelectable.OnSubmitted -= OnClick;
			}
		}

		protected override void Start()
		{
			base.Start();
			SetInitial();
			SetVisualStateEnabled(shouldSetEnabled: true);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			SetHovered();
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			SetEnabled();
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			Submit();
		}

		private void OnSelect()
		{
			SetHovered();
		}

		private void OnDeselect()
		{
			SetEnabled();
		}

		private void OnClick()
		{
			Submit();
		}

		private void SetHovered()
		{
			if (shouldTriggerInputItself || !base.UiVisualStateInfoHovered.isAvailable)
			{
				SetVisualStateHovered(shouldSetHovered: true);
				SetVisualStateEnabled(shouldSetEnabled: false);
				PlayAudio(hoverSound);
			}
		}

		private void SetEnabled()
		{
			if (shouldTriggerInputItself)
			{
				SetVisualStateEnabled(shouldSetEnabled: true);
				SetVisualStateHovered(shouldSetHovered: false);
			}
		}

		public void Submit()
		{
			if (shouldTriggerInputItself && base.UiVisualStateInfoActivated.isAvailable)
			{
				ToggleActivated();
			}
			if (base.IsDisabled)
			{
				PlayAudio(clickInvalidSound);
				return;
			}
			onClick?.Invoke(base.IsActivated);
			PlayAudio(clickSound);
			SetVisualStatePressed(shouldSetPressed: true);
		}

		protected virtual void SetInitial()
		{
			foreach (UiVisualStateInfo item in Enumerable.Where(availableVisualStateInfos, (UiVisualStateInfo visualStateInfo) => visualStateInfo.canvasGroup != null))
			{
				item.canvasGroup.alpha = 0f;
			}
			if (base.UiVisualStateInfoEnabled.canvasGroup != null)
			{
				base.UiVisualStateInfoEnabled.canvasGroup.alpha = 1f;
			}
			if (base.UiVisualStateInfoActivated.isAvailable)
			{
				SetVisualStateActivated(base.IsActivated, shouldIgnoreCurrentState: true);
			}
			if (base.UiVisualStateInfoHovered.isAvailable)
			{
				SetVisualStateHovered(base.IsHovered, shouldIgnoreCurrentState: true);
			}
			if (base.UiVisualStateInfoDisabled.isAvailable)
			{
				SetVisualStateDisabled(base.IsDisabled, shouldIgnoreCurrentState: true);
			}
		}

		internal virtual void SetVisualStateEnabled(bool shouldSetEnabled)
		{
			if (base.UiVisualStateInfoEnabled.isAvailable)
			{
				onEnabledSequence = ResetInteractionSequence(onEnabledSequence);
				TweenSettingsExtensions.Insert(onEnabledSequence, 0f, DOTweenModuleUI.DOFade(base.UiVisualStateInfoEnabled.canvasGroup, shouldSetEnabled ? groupAlphaVisible : 0f, transitionDuration));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onEnabledSequence);
				SetState(UiState.Enabled, shouldSetEnabled);
			}
		}

		internal virtual void SetVisualStateHovered(bool shouldSetHovered, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsHovered != shouldSetHovered || shouldIgnoreCurrentState) && base.UiVisualStateInfoHovered.isAvailable)
			{
				onHoveredSequence = ResetInteractionSequence(onHoveredSequence);
				TweenSettingsExtensions.Insert(onHoveredSequence, 0f, DOTweenModuleUI.DOFade(base.UiVisualStateInfoHovered.canvasGroup, shouldSetHovered ? groupAlphaVisible : 0f, transitionDuration));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onHoveredSequence);
				SetState(UiState.Hovered, shouldSetHovered);
			}
		}

		internal virtual void SetVisualStateActivated(bool shouldSetActivated, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsActivated != shouldSetActivated || shouldIgnoreCurrentState) && base.UiVisualStateInfoActivated.isAvailable)
			{
				onActivatedSequence = ResetInteractionSequence(onActivatedSequence);
				RectTransform component = activatedUnderline.GetComponent<RectTransform>();
				Vector2 sizeDelta = component.sizeDelta;
				TweenSettingsExtensions.Insert(onActivatedSequence, 0f, DOTweenModuleUI.DOSizeDelta(component, shouldSetActivated ? new Vector2(activatedUnderlineWidth, sizeDelta.y) : new Vector2(0f, sizeDelta.y), transitionDuration));
				if (shouldSetActivated)
				{
					TweenSettingsExtensions.Insert(onActivatedSequence, 0f, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, groupAlphaVisible, 0f));
				}
				else
				{
					TweenSettingsExtensions.Append(onActivatedSequence, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, 0f, 0f));
				}
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onActivatedSequence);
				SetState(UiState.Activated, shouldSetActivated);
			}
		}

		internal virtual void SetVisualStateDisabled(bool shouldSetDisabled, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsDisabled == shouldSetDisabled && !shouldIgnoreCurrentState) || !base.UiVisualStateInfoDisabled.isAvailable)
			{
				return;
			}
			onDisabledSequence = ResetInteractionSequence(onDisabledSequence);
			groupAlphaVisible = (shouldSetDisabled ? Constants.UI.UiStateAlpha.Disabled : Constants.UI.UiStateAlpha.Enabled);
			foreach (UiVisualStateInfo item in Enumerable.Where(availableVisualStateInfos, (UiVisualStateInfo visualStateInfo) => visualStateInfo.isCurrentlyActive))
			{
				TweenSettingsExtensions.Insert(onDisabledSequence, 0f, DOTweenModuleUI.DOFade(item.canvasGroup, groupAlphaVisible, transitionDuration));
			}
			TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onDisabledSequence);
			SetState(UiState.Disabled, shouldSetDisabled);
		}

		protected virtual TweenCallback SetStatePressed(bool shouldSetPressed)
		{
			SetState(UiState.Pressed, shouldSetPressed);
			return null;
		}

		internal virtual void SetVisualStatePressed(bool shouldSetPressed, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsPressed != shouldSetPressed || shouldIgnoreCurrentState) && base.UiVisualStateInfoPressed.isAvailable)
			{
				SetStatePressed(shouldSetPressed);
				onPressedSequence = ResetSequence(onPressedSequence, true);
				TweenSettingsExtensions.Insert(onPressedSequence, 0f, ShortcutExtensions.DOPunchScale(base.UiVisualStateInfoPressed.groupContainer.GetComponent<RectTransform>(), new Vector2(pressedPunchScaleFactor, pressedPunchScaleFactor), pressedPunchScaleDuration, pressedPunchScaleVibrato));
				TweenSettingsExtensions.AppendCallback(onPressedSequence, SetStatePressed(shouldSetPressed: false));
			}
		}

		internal void ToggleDisabled()
		{
			SetVisualStateDisabled(!base.IsDisabled);
		}

		internal void ToggleActivated()
		{
			SetVisualStateActivated(!base.IsActivated);
		}
	}
}
