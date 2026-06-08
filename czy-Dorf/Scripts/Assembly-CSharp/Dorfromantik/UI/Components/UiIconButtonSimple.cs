using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI.Components
{
	public class UiIconButtonSimple : UiIconButton
	{
		[SerializeField]
		private float punchDuration = 0.25f;

		[SerializeField]
		protected float hoveredScaleFactor = 0.15f;

		[SerializeField]
		protected float hoveredScaleDuration = 0.3f;

		[SerializeField]
		protected bool shouldOverrideImageColor;

		[SerializeField]
		protected float hoveredImageColorDuration = 0.3f;

		[SerializeField]
		protected Color hoveredImageColor = Color.white;

		[SerializeField]
		private Image simpleImage;

		private Color enabledImageColor;

		protected override void Awake()
		{
			base.Awake();
			if (simpleImage == null)
			{
				simpleImage = base.UiVisualStateInfoEnabled.canvasGroup.GetComponentInChildren<Image>();
			}
			enabledImageColor = simpleImage.color;
		}

		internal override void SetVisualStateEnabled(bool shouldSetEnabled)
		{
			base.SetVisualStateEnabled(shouldSetEnabled: true);
		}

		internal override void SetVisualStateHovered(bool shouldSetHovered, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsHovered != shouldSetHovered || shouldIgnoreCurrentState) && base.UiVisualStateInfoHovered.isAvailable)
			{
				onHoveredSequence = ResetInteractionSequence(onHoveredSequence);
				Vector2 one = Vector2.one;
				if (shouldSetHovered)
				{
					one += one * hoveredScaleFactor;
				}
				TweenSettingsExtensions.Insert(onHoveredSequence, 0f, ShortcutExtensions.DOScale(base.UiVisualStateInfoHovered.groupContainer.GetComponent<RectTransform>(), one, hoveredScaleDuration));
				TweenSettingsExtensions.Insert(onHoveredSequence, 0f, DOTweenModuleUI.DOColor(simpleImage, shouldSetHovered ? hoveredImageColor : enabledImageColor, hoveredImageColorDuration));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onHoveredSequence);
				SetState(UiState.Hovered, shouldSetHovered);
			}
		}
	}
}
