using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	public struct MMPostProcessingVolumeAutoBlendURPShakeEvent
	{
		private static MMPostProcessingVolumeAutoBlendURPShakeEvent e;

		public MMChannelData ChannelData;

		public MMGlobalPostProcessingVolumeAutoBlend_URP TargetAutoBlend;

		public MMF_GlobalPPVolumeAutoBlend_URP.Modes Mode;

		public MMF_GlobalPPVolumeAutoBlend_URP.Actions BlendAction;

		public float BlendDuration;

		public AnimationCurve BlendCurve;

		public float InitialWeight;

		public float FinalWeight;

		public bool ResetToInitialValueOnEnd;

		public bool NormalPlayDirection;

		public MMGlobalPostProcessingVolumeAutoBlend_URP.TimeScales TimeScale;

		public static void Trigger(MMChannelData channelData, MMGlobalPostProcessingVolumeAutoBlend_URP targetAutoBlend, MMF_GlobalPPVolumeAutoBlend_URP.Modes mode, MMF_GlobalPPVolumeAutoBlend_URP.Actions blendAction, float blendDuration, AnimationCurve blendCurve, float initialWeight, float finalWeight, bool resetToInitialValueOnEnd, bool normalPlayDirection, MMGlobalPostProcessingVolumeAutoBlend_URP.TimeScales timeScale)
		{
			e.ChannelData = channelData;
			e.TargetAutoBlend = targetAutoBlend;
			e.Mode = mode;
			e.BlendAction = blendAction;
			e.BlendDuration = blendDuration;
			e.BlendCurve = blendCurve;
			e.InitialWeight = initialWeight;
			e.FinalWeight = finalWeight;
			e.ResetToInitialValueOnEnd = resetToInitialValueOnEnd;
			e.NormalPlayDirection = normalPlayDirection;
			e.TimeScale = timeScale;
			MMEventManager.TriggerEvent(e);
		}
	}
}
