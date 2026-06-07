using System.Collections;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you control the length, width and color of a target TrailRenderer over time")]
	[FeedbackPath("Renderer/Trail Renderer")]
	public class MMF_TrailRenderer : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Trail Renderer", true, 24, true, false)]
		[Tooltip("the trail renderer whose properties you want to modify")]
		public TrailRenderer TargetTrailRenderer;

		[Tooltip("whether the feedback should affect the sprite renderer instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the sprite renderer should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float Duration = 2f;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("a curve to use to animate the trail renderer's density over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType Transition = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "", "");

		[MMFInspectorGroup("Width", true, 25, false, false)]
		[Tooltip("whether or not to modify the trail renderer's width")]
		public bool ModifyWidth = true;

		[Tooltip("a curve defining the new width of the trail renderer, describing the world space width of the trail at each point along its length")]
		public AnimationCurve NewWidth = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

		[MMFInspectorGroup("Color", true, 28, false, false)]
		[Tooltip("whether or not to modify the trail renderer's color")]
		public bool ModifyColor = true;

		[Tooltip("the colors to apply to the sprite renderer over time")]
		public Gradient NewColor = new Gradient();

		[MMFInspectorGroup("Trail Renderer Time", true, 28, false, false)]
		[Tooltip("whether or not to modify the trail renderer's time (how long the trail should be in seconds)")]
		public bool ModifyTime = true;

		[Tooltip("the new trail renderer's time (how long the trail should be in seconds) to apply")]
		public float NewTime = 2f;

		protected Coroutine _coroutine;

		protected Gradient _initialColor;

		protected AnimationCurve _initialWidth;

		protected float _initialTime;

		protected Gradient _firstColor;

		protected AnimationCurve _firstWidth;

		protected float _firstTime;

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
				if (TargetTrailRenderer == null)
				{
					Debug.LogWarning("[Trail Renderer Feedback] The trail renderer feedback on " + Owner.name + " doesn't have a TargetTrailRenderer, it won't work. You need to specify one in its inspector.");
					return;
				}
				_firstColor = TargetTrailRenderer.colorGradient;
				_firstWidth = TargetTrailRenderer.widthCurve;
				_firstTime = TargetTrailRenderer.time;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetTrailRenderer == null)
			{
				return;
			}
			_initialColor = TargetTrailRenderer.colorGradient;
			_initialWidth = TargetTrailRenderer.widthCurve;
			_initialTime = TargetTrailRenderer.time;
			float intensityMultiplier = ComputeIntensity(feedbacksIntensity, position);
			switch (Mode)
			{
			case Modes.Instant:
				if (ModifyColor)
				{
					TargetTrailRenderer.colorGradient = (NormalPlayDirection ? NewColor : _firstColor);
				}
				if (ModifyWidth)
				{
					TargetTrailRenderer.widthCurve = (NormalPlayDirection ? NewWidth : _firstWidth);
				}
				if (ModifyTime)
				{
					TargetTrailRenderer.time = (NormalPlayDirection ? NewTime : _firstTime);
				}
				break;
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(TrailRendererSequence(intensityMultiplier));
				}
				break;
			}
		}

		protected virtual IEnumerator TrailRendererSequence(float intensityMultiplier)
		{
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float t = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				t = Transition.Evaluate(t);
				SetTrailRendererValues(t, intensityMultiplier);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetTrailRendererValues(Transition.Evaluate(FinalNormalizedTime), intensityMultiplier);
			_coroutine = null;
			IsPlaying = false;
			yield return null;
		}

		protected virtual void SetTrailRendererValues(float time, float intensityMultiplier)
		{
			if (ModifyColor)
			{
				if (NormalPlayDirection)
				{
					TargetTrailRenderer.colorGradient = MMColors.LerpGradients(_initialColor, NewColor, time);
				}
				else
				{
					TargetTrailRenderer.colorGradient = MMColors.LerpGradients(NewColor, _firstColor, time);
				}
			}
			if (ModifyWidth)
			{
				if (NormalPlayDirection)
				{
					TargetTrailRenderer.widthCurve = MMAnimationCurves.LerpAnimationCurves(_initialWidth, NewWidth, time);
				}
				else
				{
					TargetTrailRenderer.widthCurve = MMAnimationCurves.LerpAnimationCurves(NewWidth, _firstWidth, time);
				}
			}
			if (ModifyTime)
			{
				if (NormalPlayDirection)
				{
					TargetTrailRenderer.time = MMMaths.Lerp(_initialTime, NewTime, time, FeedbackDeltaTime);
				}
				else
				{
					TargetTrailRenderer.time = MMMaths.Lerp(NewTime, _firstTime, time, FeedbackDeltaTime);
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
				TargetTrailRenderer.widthCurve = _firstWidth;
				TargetTrailRenderer.colorGradient = _firstColor;
			}
		}
	}
}
