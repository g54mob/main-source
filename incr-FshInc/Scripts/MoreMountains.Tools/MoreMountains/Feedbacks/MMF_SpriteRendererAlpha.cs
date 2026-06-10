using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the alpha of a target sprite renderer over time.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Renderer/SpriteRenderer Alpha")]
	public class MMF_SpriteRendererAlpha : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1,
			ToDestinationAlpha = 2,
			ToDestinationAlphaAndBack = 3
		}

		public enum InitialAlphaModes
		{
			InitialAlphaOnInit = 0,
			InitialAlphaOnPlay = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Sprite Renderer", true, 51, true, false)]
		[Tooltip("the SpriteRenderer to affect when playing the feedback")]
		public SpriteRenderer BoundSpriteRenderer;

		[Tooltip("whether the feedback should affect the sprite renderer instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the sprite renderer should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public float Duration = 0.2f;

		[Tooltip("whether or not that sprite renderer should be turned off on start")]
		public bool StartsOff;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("whether to grab the initial color to (potentially) go back to at init or when the feedback plays")]
		public InitialAlphaModes InitialAlphaMode = InitialAlphaModes.InitialAlphaOnPlay;

		[Tooltip("the alpha to apply to the sprite renderer over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public AnimationCurve AlphaOverTime = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Tooltip("the alpha to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantAlpha;

		[Tooltip("the alpha to move to in ToDestinationAlpha mode")]
		[MMFEnumCondition("Mode", new int[] { 2, 3 })]
		public float ToDestinationAlpha = 0.5f;

		[Tooltip("the curve on which to tween in ToDestinationAlpha modes")]
		[MMFEnumCondition("Mode", new int[] { 2, 3 })]
		public AnimationCurve ToDestinationAlphaCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		protected Coroutine _coroutine;

		protected float _initialAlpha;

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
				Duration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundSpriteRenderer = FindAutomatedTarget<SpriteRenderer>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && StartsOff)
			{
				Turn(status: false);
			}
			if (BoundSpriteRenderer != null && InitialAlphaMode == InitialAlphaModes.InitialAlphaOnInit)
			{
				_initialAlpha = BoundSpriteRenderer.color.a;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (BoundSpriteRenderer == null)
			{
				Debug.LogWarning("[Sprite Renderer Feedback] The sprite renderer feedback on " + Owner.name + " doesn't have a BoundSpriteRenderer, it won't work. You need to specify one in its inspector.");
				return;
			}
			if (InitialAlphaMode == InitialAlphaModes.InitialAlphaOnPlay)
			{
				_initialAlpha = BoundSpriteRenderer.color.a;
			}
			ComputeIntensity(feedbacksIntensity, position);
			Turn(status: true);
			switch (Mode)
			{
			case Modes.Instant:
			{
				float alpha = (NormalPlayDirection ? InstantAlpha : _initialAlpha);
				SetAlpha(alpha);
				break;
			}
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(SpriteRendererSequence());
				}
				break;
			case Modes.ToDestinationAlpha:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(SpriteRendererToDestinationSequence(andBack: false));
				}
				break;
			case Modes.ToDestinationAlphaAndBack:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(SpriteRendererToDestinationSequence(andBack: true));
				}
				break;
			}
		}

		protected virtual IEnumerator SpriteRendererSequence()
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float spriteRendererValues = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetSpriteRendererValues(spriteRendererValues);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetSpriteRendererValues(FinalNormalizedTime);
			if (StartsOff)
			{
				Turn(status: false);
			}
			_coroutine = null;
			IsPlaying = false;
			yield return null;
		}

		protected virtual IEnumerator SpriteRendererToDestinationSequence(bool andBack)
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float num = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				if (andBack)
				{
					num = ((num < 0.5f) ? MMFeedbacksHelpers.Remap(num, 0f, 0.5f, 0f, 1f) : MMFeedbacksHelpers.Remap(num, 0.5f, 1f, 1f, 0f));
				}
				float alpha = MMMaths.Remap(ToDestinationAlphaCurve.Evaluate(num), 0f, 1f, _initialAlpha, ToDestinationAlpha);
				SetAlpha(alpha);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			float alpha2 = (andBack ? _initialAlpha : ToDestinationAlpha);
			SetAlpha(alpha2);
			if (StartsOff)
			{
				Turn(status: false);
			}
			_coroutine = null;
			IsPlaying = false;
			yield return null;
		}

		protected virtual void SetSpriteRendererValues(float time)
		{
			float alpha = AlphaOverTime.Evaluate(time);
			SetAlpha(alpha);
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				Owner.StopCoroutine(_coroutine);
				IsPlaying = false;
				_coroutine = null;
			}
		}

		protected virtual void Turn(bool status)
		{
			BoundSpriteRenderer.gameObject.SetActive(status);
			BoundSpriteRenderer.enabled = status;
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized && BoundSpriteRenderer != null)
			{
				SetAlpha(_initialAlpha);
			}
		}

		protected virtual void SetAlpha(float newAlpha)
		{
			BoundSpriteRenderer.color = BoundSpriteRenderer.color.MMAlpha(newAlpha);
		}

		public override void OnDisable()
		{
			_coroutine = null;
		}
	}
}
