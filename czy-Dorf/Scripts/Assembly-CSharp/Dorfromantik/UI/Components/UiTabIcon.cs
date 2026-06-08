using DG.Tweening;
using LeTai.Asset.TranslucentImage;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik.UI.Components
{
	public class UiTabIcon : UiTab
	{
		[SerializeField]
		private TranslucentImage backgroundImage;

		[SerializeField]
		private Sprite defaultBackgroundSprite;

		[SerializeField]
		private Sprite alternateBackgroundSprite;

		[SerializeField]
		private bool hasSpecialBorder;

		[SerializeField]
		private Image borderImage;

		[SerializeField]
		private Sprite defaultBorderSprite;

		[SerializeField]
		private Sprite alternateBorderSprite;

		private UiIconButton uiIconButton;

		private Ui_BiomeAffected biomeAffectedUi;

		protected Sequence onActivatedSequence;

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

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		protected override void SetInitial()
		{
			base.SetInitial();
			SetBackgroundImages();
		}

		protected override void Validate()
		{
			if (biomeAffectedUi == null)
			{
				biomeAffectedUi = GetComponentInChildren<Ui_BiomeAffected>();
			}
			if (uiIconButton == null)
			{
				uiIconButton = GetComponentInChildren<UiIconButton>(includeInactive: true);
			}
			if (backgroundImage == null)
			{
				backgroundImage = GetComponentInChildren<TranslucentImage>();
			}
		}

		public override void Submit()
		{
			base.Submit();
			if (!base.IsDisabled)
			{
				uiIconButton.SetVisualStatePressed(shouldSetPressed: true);
			}
		}

		protected override void SetVisualStateEnabled(bool shouldSetEnabled)
		{
			uiIconButton.SetVisualStateEnabled(shouldSetEnabled);
			if (shouldSetEnabled)
			{
				biomeAffectedUi.ApplyNewColorModifier(UiColorModifier.Darker);
			}
			SetState(UiState.Enabled, shouldSetEnabled);
		}

		protected override void SetVisualStateHovered(bool shouldSetHovered, bool shouldIgnoreCurrentState = false)
		{
			if (base.IsHovered != shouldSetHovered || shouldIgnoreCurrentState)
			{
				uiIconButton.SetVisualStateHovered(shouldSetHovered);
				if (shouldSetHovered)
				{
					biomeAffectedUi.ApplyNewColorModifier(UiColorModifier.Lighter);
				}
				SetState(UiState.Hovered, shouldSetHovered);
			}
		}

		public override void SetVisualStateActivated(bool shouldSetActivated, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsActivated == shouldSetActivated && !shouldIgnoreCurrentState) || !base.UiVisualStateInfoActivated.isAvailable)
			{
				base.SetVisualStateActivated(shouldSetActivated, shouldIgnoreCurrentState);
				return;
			}
			onActivatedSequence = ResetInteractionSequence(onActivatedSequence);
			if ((bool)uiIconButton)
			{
				uiIconButton.SetVisualStateActivated(shouldSetActivated);
			}
			if (shouldSetActivated)
			{
				TweenSettingsExtensions.Insert(onActivatedSequence, 0f, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, 1f, 0f));
			}
			else
			{
				TweenSettingsExtensions.Append(onActivatedSequence, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, 0f, 0f));
			}
			TweenSettingsExtensions.Append(onInteractionSequence, onActivatedSequence);
			base.SetVisualStateActivated(shouldSetActivated, shouldIgnoreCurrentState);
		}

		protected override void SetVisualStateDisabled(bool shouldSetDisabled, bool shouldIgnoreCurrentState = false)
		{
			if (base.IsDisabled != shouldSetDisabled || shouldIgnoreCurrentState)
			{
				uiIconButton.SetVisualStateDisabled(shouldSetDisabled);
				SetState(UiState.Disabled, shouldSetDisabled);
			}
		}

		private void SetBackgroundImages()
		{
			if (backgroundImage != null)
			{
				backgroundImage.sprite = (isVisualAlternate ? alternateBackgroundSprite : defaultBackgroundSprite);
			}
			if (hasSpecialBorder && borderImage != null)
			{
				borderImage.sprite = (isVisualAlternate ? alternateBorderSprite : defaultBorderSprite);
			}
		}
	}
}
