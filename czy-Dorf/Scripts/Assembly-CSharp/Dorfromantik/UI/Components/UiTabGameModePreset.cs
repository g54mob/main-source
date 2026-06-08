using DG.Tweening;
using LeTai.Asset.TranslucentImage;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dorfromantik.UI.Components
{
	public class UiTabGameModePreset : UiTab
	{
		[SerializeField]
		protected float transitionDuration = 0.25f;

		[SerializeField]
		protected float disabledTransparency = 0.5f;

		private UiIconButton uiIconButton;

		private TranslucentImage backgroundImage;

		private Ui_BiomeAffected biomeAffectedUi;

		protected Sequence onActivatedSequence;

		protected Sequence onHoveredSequence;

		protected Sequence onEnabledSequence;

		protected Sequence onDisabledSequence;

		protected Sequence onPressedSequence;

		protected override void Awake()
		{
			base.Awake();
			Validate();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			Validate();
		}

		protected override void Start()
		{
			base.Start();
			SetInitial();
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		protected override void Validate()
		{
			if (biomeAffectedUi == null)
			{
				biomeAffectedUi = GetComponent<Ui_BiomeAffected>();
			}
			if (uiIconButton == null)
			{
				uiIconButton = GetComponentInChildren<UiIconButton>(includeInactive: true);
			}
			if (backgroundImage == null)
			{
				backgroundImage = GetComponent<TranslucentImage>();
			}
		}

		protected override void SetVisualStateEnabled(bool shouldSetEnabled)
		{
			SetState(UiState.Enabled, shouldSetEnabled);
		}

		protected override void SetVisualStateHovered(bool shouldSetHovered, bool shouldIgnoreCurrentState = false)
		{
			if (base.IsHovered != shouldSetHovered || shouldIgnoreCurrentState)
			{
				SetState(UiState.Hovered, shouldSetHovered);
			}
		}

		public override void SetVisualStateActivated(bool shouldSetActivated, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsActivated != shouldSetActivated || shouldIgnoreCurrentState) && base.UiVisualStateInfoActivated.isAvailable)
			{
				onActivatedSequence = ResetInteractionSequence(onActivatedSequence);
				TweenSettingsExtensions.Insert(onActivatedSequence, 0f, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, shouldSetActivated ? 1f : 0f, transitionDuration));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onActivatedSequence);
				base.SetVisualStateActivated(shouldSetActivated);
			}
		}

		protected override void SetVisualStateDisabled(bool shouldSetDisabled, bool shouldIgnoreCurrentState = false)
		{
			if (base.IsDisabled != shouldSetDisabled || shouldIgnoreCurrentState)
			{
				base.UiVisualStateInfoDisabled.canvasGroup.alpha = (shouldSetDisabled ? disabledTransparency : 1f);
				SetState(UiState.Disabled, shouldSetDisabled);
			}
		}
	}
}
