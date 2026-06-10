using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.VFX;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you apply basic controls to a target VisualEffect")]
	[FeedbackPath("Particles/VisualEffect")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.VisualEffectGraph", null)]
	public class MMF_VisualEffect : MMF_Feedback
	{
		public enum Modes
		{
			Play = 0,
			Stop = 1,
			Pause = 2,
			Unpause = 3,
			AdvanceOneFrame = 4,
			Reinit = 5,
			SetPlayRate = 6,
			Simulate = 7
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Visual Effect", true, 41, false, false)]
		[Tooltip("the duration for the player to consider. This won't impact your visual effect, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual visual effect, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[Tooltip("the visual effect to control when playing this feedback")]
		public VisualEffect TargetVisualEffect;

		[Tooltip("the selected mode, the instruction to send to the target visual effect when playing this feedback")]
		public Modes Mode;

		[Tooltip("when in SetPlayRate mode, the new play rate to apply")]
		[MMFEnumCondition("Mode", new int[] { 6 })]
		public float NewPlayRate = 1f;

		[Tooltip("when in Simulate mode, the delta time to use")]
		[MMFEnumCondition("Mode", new int[] { 7 })]
		public float StepDeltaTime = 1f;

		[Tooltip("when in Simulate mode, the number of steps to simulate")]
		[MMFEnumCondition("Mode", new int[] { 7 })]
		public uint StepCount = 5u;

		[Tooltip("whether or not to stop the visual effect when stopping this feedback")]
		public bool StopVisualEffectOnStopFeedback;

		[Tooltip("whether or not to stop the visual effect when resetting this feedback")]
		public bool StopVisualEffectOnReset;

		[Tooltip("whether or not to stop the visual effect when initializing this feedback")]
		public bool StopVisualEffectOnInit;

		protected VFXEventAttribute _eventAttribute;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DeclaredDuration);
			}
			set
			{
				DeclaredDuration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (StopVisualEffectOnInit)
			{
				StopVisualEffect();
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float attenuation = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetVisualEffect == null))
			{
				switch (Mode)
				{
				case Modes.Play:
					TargetVisualEffect.Play();
					break;
				case Modes.Stop:
					StopVisualEffect();
					break;
				case Modes.Pause:
					TargetVisualEffect.pause = true;
					break;
				case Modes.Unpause:
					TargetVisualEffect.pause = false;
					break;
				case Modes.AdvanceOneFrame:
					TargetVisualEffect.AdvanceOneFrame();
					break;
				case Modes.Reinit:
					TargetVisualEffect.Reinit();
					break;
				case Modes.SetPlayRate:
					TargetVisualEffect.playRate = NewPlayRate;
					break;
				case Modes.Simulate:
					TargetVisualEffect.Simulate(StepDeltaTime, StepCount);
					break;
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				if (StopVisualEffectOnStopFeedback)
				{
					StopVisualEffect();
				}
			}
		}

		protected override void CustomReset()
		{
			base.CustomReset();
			if (!InCooldown && StopVisualEffectOnReset)
			{
				StopVisualEffect();
			}
		}

		protected virtual void StopVisualEffect()
		{
			if (!(TargetVisualEffect == null))
			{
				TargetVisualEffect.Stop();
			}
		}
	}
}
