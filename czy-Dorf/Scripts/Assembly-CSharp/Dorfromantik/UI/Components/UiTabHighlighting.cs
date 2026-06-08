using DG.Tweening;
using LeTai.Asset.TranslucentImage;
using UnityEngine;

namespace Dorfromantik.UI.Components
{
	public class UiTabHighlighting : MonoBehaviour
	{
		[SerializeField]
		private bool shouldHighlight = true;

		[SerializeField]
		private UiColorModifier highlightColorModifier;

		[SerializeField]
		private TranslucentImage backgroundImage;

		[SerializeField]
		private float animationHighlightUpDuration = 1f;

		[SerializeField]
		private float animationHighlightDelayBetween = 1f;

		[SerializeField]
		private float animationHighlightDownDuration = 1f;

		[SerializeField]
		private Color initialBackgroundColor;

		[SerializeField]
		private Color highlightBackgroundColor;

		[SerializeField]
		private Ui_BiomeAffected biomeAffectedUi;

		private Coroutine highlightCoroutine;

		private Sequence onHighlightSequence;

		private void Awake()
		{
			if ((object)backgroundImage == null)
			{
				backgroundImage = GetComponent<TranslucentImage>();
			}
			if ((object)biomeAffectedUi == null)
			{
				biomeAffectedUi = GetComponent<Ui_BiomeAffected>();
			}
		}

		private void OnEnable()
		{
			GetInitialBackgroundColor();
			GetHighlightBackgroundColor();
			Highlight();
		}

		private void OnDisable()
		{
			Reset();
		}

		private void OnDestroy()
		{
			Reset();
		}

		private void Highlight(bool shouldLoop = true)
		{
			Sequence sequence = onHighlightSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			onHighlightSequence = DOTween.Sequence();
			TweenSettingsExtensions.Append(onHighlightSequence, DOTweenModuleUI.DOColor(backgroundImage, highlightBackgroundColor, animationHighlightUpDuration));
			TweenSettingsExtensions.AppendInterval(onHighlightSequence, animationHighlightDelayBetween);
			TweenSettingsExtensions.Append(onHighlightSequence, DOTweenModuleUI.DOColor(backgroundImage, initialBackgroundColor, animationHighlightDownDuration));
			TweenSettingsExtensions.AppendInterval(onHighlightSequence, animationHighlightDelayBetween);
			if (shouldLoop)
			{
				TweenSettingsExtensions.SetLoops(onHighlightSequence, -1);
			}
		}

		private void Reset()
		{
			Sequence sequence = onHighlightSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			backgroundImage.color = initialBackgroundColor;
		}

		private void GetInitialBackgroundColor()
		{
			initialBackgroundColor = backgroundImage.color;
		}

		private void GetHighlightBackgroundColor()
		{
			highlightBackgroundColor = biomeAffectedUi.ApplyColorModifier(initialBackgroundColor, highlightColorModifier, backgroundImage.color.a);
		}
	}
}
