using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	public struct MMPostProcessingVolumeAutoBlendShakeEvent
	{
		private static MMPostProcessingVolumeAutoBlendShakeEvent e;

		public MMChannelData ChannelData;

		public MMGlobalPostProcessingVolumeAutoBlend TargetAutoBlend;

		public MMF_GlobalPPVolumeAutoBlend.Modes Mode;

		public MMF_GlobalPPVolumeAutoBlend.Actions BlendAction;

		public float BlendDuration;

		public AnimationCurve BlendCurve;

		public float InitialWeight;

		public float FinalWeight;

		public bool ResetToInitialValueOnEnd;

		public bool NormalPlayDirection;

		public MMGlobalPostProcessingVolumeAutoBlend.TimeScales TimeScale;

		public static void Trigger(MMChannelData channelData, MMGlobalPostProcessingVolumeAutoBlend targetAutoBlend, MMF_GlobalPPVolumeAutoBlend.Modes mode, MMF_GlobalPPVolumeAutoBlend.Actions blendAction, float blendDuration, AnimationCurve blendCurve, float initialWeight, float finalWeight, bool resetToInitialValueOnEnd, bool normalPlayDirection, MMGlobalPostProcessingVolumeAutoBlend.TimeScales timeScale)
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
