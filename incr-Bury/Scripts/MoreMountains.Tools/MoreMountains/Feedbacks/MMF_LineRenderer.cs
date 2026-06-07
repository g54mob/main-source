using System.Collections;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the width and color of a target line renderer over time")]
	[FeedbackPath("Renderer/Line Renderer")]
	public class MMF_LineRenderer : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Line Renderer", true, 24, true, false)]
		[Tooltip("the line renderer whose properties you want to modify")]
		public LineRenderer TargetLineRenderer;

		[Tooltip("whether the feedback should affect the sprite renderer instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the sprite renderer should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float Duration = 2f;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("a curve to use to animate the line renderer's density over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType Transition = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "", "");

		[MMFInspectorGroup("Width", true, 25, false, false)]
		[Tooltip("whether or not to modify the line renderer's width")]
		public bool ModifyWidth = true;

		[Tooltip("a curve defining the new width of the line renderer, describing the world space width of the line at each point along its length")]
		public AnimationCurve NewWidth = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

		[MMFInspectorGroup("Color", true, 28, false, false)]
		[Tooltip("whether or not to modify the line renderer's color")]
		public bool ModifyColor = true;

		[Tooltip("the colors to apply to the sprite renderer over time")]
		public Gradient NewColor = new Gradient();

		protected Coroutine _coroutine;

		protected Gradient _initialColor;

		protected AnimationCurve _initialWidth;

		protected Gradient _firstColor;

		protected AnimationCurve _firstWidth;

		public override bool HasRandomness => true;

		public override bool HasCustomInspectors => true;

		public override float FeedbackDuration
		{
			get
			{
				if (Mode != Modes.Instant)
				{
					return ApplyTimeMultiplier(Duration);
				}
				return 0f;
			}
			set
			{
				if (Mode != Modes.Instant)
				{
					Duration = value;
				}
			}
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active)
			{
				if (TargetLineRenderer == null)
				{
					Debug.LogWarning("[Line Renderer Feedback] The line renderer feedback on " + Owner.name + " doesn't have a TargetLineRenderer, it won't work. You need to specify one in its inspector.");
					return;
				}
				_firstColor = TargetLineRenderer.colorGradient;
				_firstWidth = TargetLineRenderer.widthCurve;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetLineRenderer == null)
			{
				return;
			}
			_initialColor = TargetLineRenderer.colorGradient;
			_initialWidth = TargetLineRenderer.widthCurve;
			float intensityMultiplier = ComputeIntensity(feedbacksIntensity, position);
			switch (Mode)
			{
			case Modes.Instant:
				if (ModifyColor)
				{
					TargetLineRenderer.colorGradient = (NormalPlayDirection ? NewColor : _firstColor);
				}
				if (ModifyWidth)
				{
					TargetLineRenderer.widthCurve = (NormalPlayDirection ? NewWidth : _firstWidth);
				}
				break;
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(LineRendererSequence(intensityMultiplier));
				}
				break;
			}
		}

		protected virtual IEnumerator LineRendererSequence(float intensityMultiplier)
		{
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float t = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				t = Transition.Evaluate(t);
				SetLineRendererValues(t, intensityMultiplier);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetLineRendererValues(Transition.Evaluate(FinalNormalizedTime), intensityMultiplier);
			_coroutine = null;
			IsPlaying = false;
			yield return null;
		}

		protected virtual void SetLineRendererValues(float time, float intensityMultiplier)
		{
			if (ModifyColor)
			{
				if (NormalPlayDirection)
				{
					TargetLineRenderer.colorGradient = MMColors.LerpGradients(_initialColor, NewColor, time);
				}
				else
				{
					TargetLineRenderer.colorGradient = MMColors.LerpGradients(NewColor, _firstColor, time);
				}
			}
			if (ModifyWidth)
			{
				if (NormalPlayDirection)
				{
					TargetLineRenderer.widthCurve = MMAnimationCurves.LerpAnimationCurves(_initialWidth, NewWidth, time);
				}
				else
				{
					TargetLineRenderer.widthCurve = MMAnimationCurves.LerpAnimationCurves(NewWidth, _firstWidth, time);
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				Owner.StopCoroutine(_coroutine);
				_coroutine = null;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetLineRenderer.widthCurve = _firstWidth;
				TargetLineRenderer.colorGradient = _firstColor;
			}
		}
	}
}
