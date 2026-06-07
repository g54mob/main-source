using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you pilot a Global PostProcessing Volume AutoBlend URP component. A GPPVAB component is placed on a PostProcessing Volume, and will let you control and blend its weight over time on demand.")]
	[FeedbackPath("PostProcess/Global PP Volume Auto Blend URP")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.URP", null)]
	public class MMF_GlobalPPVolumeAutoBlend_URP : MMF_Feedback
	{
		public enum Modes
		{
			Default = 0,
			Override = 1
		}

		public enum Actions
		{
			Blend = 0,
			BlendBack = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("PostProcess Volume Blend", true, 22, true, false)]
		public MMGlobalPostProcessingVolumeAutoBlend_URP TargetAutoBlend;

		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Actions BlendAction;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float BlendDuration = 1f;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		public AnimationCurve BlendCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InitialWeight;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float FinalWeight = 1f;

		[Tooltip("whether or not to reset to the initial value at the end of the shake")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool ResetToInitialValueOnEnd = true;

		public override bool HasAutomatedTargetAcquisition => true;

		public override bool HasChannel => true;

		public override float FeedbackDuration
		{
			get
			{
				if (Mode == Modes.Override)
				{
					return ApplyTimeMultiplier(BlendDuration);
				}
				if (TargetAutoBlend == null)
				{
					return 0.1f;
				}
				return ApplyTimeMultiplier(TargetAutoBlend.BlendDuration);
			}
			set
			{
				BlendDuration = value;
				if (TargetAutoBlend != null)
				{
					TargetAutoBlend.BlendDuration = value;
				}
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetAutoBlend = FindAutomatedTarget<MMGlobalPostProcessingVolumeAutoBlend_URP>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMGlobalPostProcessingVolumeAutoBlend_URP.TimeScales timeScale = ((ComputedTimescaleMode != TimescaleModes.Scaled) ? MMGlobalPostProcessingVolumeAutoBlend_URP.TimeScales.Unscaled : MMGlobalPostProcessingVolumeAutoBlend_URP.TimeScales.Scaled);
				MMPostProcessingVolumeAutoBlendURPShakeEvent.Trigger(ChannelData, TargetAutoBlend, Mode, BlendAction, ApplyTimeMultiplier(BlendDuration), BlendCurve, InitialWeight, FinalWeight, ResetToInitialValueOnEnd, NormalPlayDirection, timeScale);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				if (TargetAutoBlend != null)
				{
					TargetAutoBlend.StopBlending();
				}
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetAutoBlend.RestoreInitialValues();
			}
		}
	}
}
