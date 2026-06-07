using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMCameraOrthographicSizeShakeEvent
	{
		public delegate void Delegate(AnimationCurve animCurve, float duration, float remapMin, float remapMax, bool relativeValue = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMCameraOrthographicSizeShakeEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(AnimationCurve animCurve, float duration, float remapMin, float remapMax, bool relativeValue = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			MMCameraOrthographicSizeShakeEvent.OnEvent?.Invoke(animCurve, duration, remapMin, remapMax, relativeValue, feedbacksIntensity, channelData, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop, restore);
		}
	}
}
