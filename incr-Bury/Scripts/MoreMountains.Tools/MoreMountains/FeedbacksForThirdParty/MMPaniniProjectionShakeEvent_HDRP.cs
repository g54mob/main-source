using System.Runtime.InteropServices;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPaniniProjectionShakeEvent_HDRP
	{
		public delegate void Delegate(AnimationCurve distance, float duration, float remapMin, float remapMax, bool relativeDistance = false, float attenuation = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPaniniProjectionShakeEvent_HDRP.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(AnimationCurve distance, float duration, float remapMin, float remapMax, bool relativeDistance = false, float attenuation = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			MMPaniniProjectionShakeEvent_HDRP.OnEvent?.Invoke(distance, duration, remapMin, remapMax, relativeDistance, attenuation, channelData, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop, restore);
		}
	}
}
