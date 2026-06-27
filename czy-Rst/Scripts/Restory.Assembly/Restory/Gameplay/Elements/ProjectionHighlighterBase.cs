using System.Collections.Generic;
using DG.Tweening;
using EPOOutline;
using Restory.Data.Outline;
using Restory.Gameplay.Common;
using Restory.Utils;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public abstract class ProjectionHighlighterBase : MonoBehaviour
	{
		[SerializeField]
		private Outlinable outlinable;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		[SerializeField]
		private OutlineSettingsPreset highlightProjectionPreset;

		[SerializeField]
		private Color baseColor = Color.white;

		[SerializeField]
		private Color highlightColor = Color.yellow;

		[SerializeField]
		private float peakScale = 1.25f;

		[SerializeField]
		private float toPeakDuration = 0.5f;

		[SerializeField]
		private float toBaseDuration = 0.5f;

		[SerializeField]
		private Ease toPeakEase = Ease.InOutSine;

		[SerializeField]
		private Ease toBaseEase = Ease.InOutSine;

		private Outlinable.OutlineProperties frontOutlineProperties;

		private Outlinable.OutlineProperties backOutlineProperties;

		protected readonly List<ElementProjection> highlightedProjections = new List<ElementProjection>();

		protected TweenSequencesService tweenSequences;

		protected OutlineSettingsPreset outlinePresetInstance;

		protected Sequence transitionSequence;

		protected bool isSequenceJustCompleted;

		private void OnEnable()
		{
			outlinePresetInstance = Object.Instantiate(highlightProjectionPreset);
			outlinableAdapter.OverridePreset = outlinePresetInstance;
			InitFrontOutlineProperties();
			InitBackOutlineProperties();
			if (frontOutlineProperties == null)
			{
				Debug.LogError("ElementProjectionHighlighter failed to initialize front outline properties");
			}
		}

		private void OnDisable()
		{
			if (transitionSequence != null)
			{
				transitionSequence.Kill();
				transitionSequence = null;
			}
			if ((bool)outlinePresetInstance)
			{
				Object.Destroy(outlinePresetInstance);
				outlinePresetInstance = null;
			}
		}

		private void InitFrontOutlineProperties()
		{
			switch (outlinable.RenderStyle)
			{
			case RenderStyle.Single:
				if (outlinable.OutlineParameters != null && outlinable.OutlineParameters.Enabled)
				{
					frontOutlineProperties = outlinable.OutlineParameters;
				}
				break;
			case RenderStyle.FrontBack:
				if (outlinable.FrontParameters != null && outlinable.FrontParameters.Enabled)
				{
					frontOutlineProperties = outlinable.FrontParameters;
				}
				break;
			}
			if (frontOutlineProperties != null)
			{
				frontOutlineProperties.Color = baseColor;
			}
		}

		private void InitBackOutlineProperties()
		{
			if (outlinable.RenderStyle == RenderStyle.FrontBack && outlinable.BackParameters.Enabled)
			{
				backOutlineProperties = outlinable.BackParameters;
				backOutlineProperties.Color = baseColor;
			}
		}

		protected void PlaySequence(Sequence sequence)
		{
			if (sequence == null)
			{
				Debug.LogError("Failed to play sequence, it is null");
				return;
			}
			frontOutlineProperties.Color = baseColor;
			if (backOutlineProperties != null)
			{
				backOutlineProperties.Color = baseColor;
			}
			Vector3 currentScale = Vector3.one;
			sequence.Append(TweenColor(frontOutlineProperties, highlightColor, toPeakDuration, toPeakEase));
			sequence.Join(TweenScale(peakScale, toPeakDuration, toPeakEase));
			if (backOutlineProperties != null)
			{
				sequence.Join(TweenColor(backOutlineProperties, highlightColor, toPeakDuration, toPeakEase));
			}
			sequence.Append(TweenColor(frontOutlineProperties, baseColor, toBaseDuration, toBaseEase));
			sequence.Join(TweenScale(1f, toBaseDuration, toBaseEase));
			if (backOutlineProperties != null)
			{
				sequence.Join(TweenColor(backOutlineProperties, baseColor, toBaseDuration, toBaseEase));
			}
			sequence.OnComplete(CompleteTransitionSequence);
			static Tween TweenColor(Outlinable.OutlineProperties properties, Color targetColor, float duration, Ease ease)
			{
				return DOTween.To(() => properties.Color, delegate(Color x)
				{
					properties.Color = x;
				}, targetColor, duration).SetEase(ease);
			}
			Tween TweenScale(float targetScale, float duration, Ease ease)
			{
				return DOTween.To(() => currentScale, delegate(Vector3 scale)
				{
					currentScale = scale;
					SetHighlightedProjectionsScale(scale);
				}, Vector3.one * targetScale, duration).SetEase(ease);
			}
		}

		private void SetHighlightedProjectionsScale(Vector3 scale)
		{
			foreach (ElementProjection highlightedProjection in highlightedProjections)
			{
				if (!highlightedProjection || !highlightedProjection.gameObject.activeSelf)
				{
					transitionSequence.Complete();
					break;
				}
				highlightedProjection.transform.localScale = scale;
			}
		}

		protected abstract void CompleteTransitionSequence();
	}
}
