using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the color of a target Image over time. You can also use it to command one or many MMImageShakers.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("UI/Image")]
	public class MMF_Image : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Image", true, 54, true, false)]
		[Tooltip("the Image to affect when playing the feedback")]
		public Image BoundImage;

		[Tooltip("whether the feedback should affect the Image instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the Image should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float Duration = 0.2f;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("whether or not to modify the color of the image")]
		public bool ModifyColor = true;

		[Tooltip("the colors to apply to the Image over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Gradient ColorOverTime;

		[Tooltip("the color to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public Color InstantColor;

		[Tooltip("whether or not that Image should be turned off on start")]
		[FormerlySerializedAs("StartsOff")]
		public bool DisableOnInit;

		[Tooltip("if this is true, the target will be enabled when this feedback gets played")]
		public bool EnableOnPlay = true;

		[Tooltip("if this is true, the target disabled after the color over time change ends")]
		public bool DisableOnSequenceEnd;

		[Tooltip("if this is true, the target will be disabled when this feedbacks is stopped")]
		public bool DisableOnStop;

		protected Coroutine _coroutine;

		protected Color _initialColor;

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

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundImage = FindAutomatedTarget<Image>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && DisableOnInit)
			{
				Turn(status: false);
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			_initialColor = BoundImage.color;
			if (EnableOnPlay)
			{
				Turn(status: true);
			}
			switch (Mode)
			{
			case Modes.Instant:
				if (ModifyColor)
				{
					BoundImage.color = InstantColor;
				}
				break;
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(ImageSequence());
				}
				break;
			}
		}

		protected virtual IEnumerator ImageSequence()
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float imageValues = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetImageValues(imageValues);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetImageValues(FinalNormalizedTime);
			if (DisableOnSequenceEnd)
			{
				Turn(status: false);
			}
			IsPlaying = false;
			_coroutine = null;
			yield return null;
		}

		protected virtual void SetImageValues(float time)
		{
			if (ModifyColor)
			{
				BoundImage.color = ColorOverTime.Evaluate(time);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				IsPlaying = false;
				base.CustomStopFeedback(position, feedbacksIntensity);
				if (Active && DisableOnStop)
				{
					Turn(status: false);
				}
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				_coroutine = null;
			}
		}

		protected virtual void Turn(bool status)
		{
			BoundImage.gameObject.SetActive(status);
			BoundImage.enabled = status;
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				BoundImage.color = _initialColor;
			}
		}
	}
}
