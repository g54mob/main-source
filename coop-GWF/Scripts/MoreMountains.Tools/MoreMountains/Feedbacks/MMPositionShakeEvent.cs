using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPositionShakeEvent
	{
		public delegate void Delegate(float duration, float shakeSpeed, float shakeRange, Vector3 shakeMainDirection, bool randomizeDirection, Vector3 shakeAltDirection, bool randomizeDirectionOnPlay, bool randomizeDirectionX, bool randomizeDirectionY, bool randomizeDirectionZ, bool addDirectionalNoise, Vector3 directionalNoiseStrengthMin, Vector3 directionalNoiseStrengthMax, Vector3 randomnessSeed, bool randomizeSeedOnShake, bool useAttenuation, AnimationCurve attenuationCurve, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPositionShakeEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(float duration, float shakeSpeed, float shakeRange, Vector3 shakeMainDirection, bool randomizeDirection, Vector3 shakeAltDirection, bool randomizeDirectionOnPlay, bool randomizeDirectionX, bool randomizeDirectionY, bool randomizeDirectionZ, bool addDirectionalNoise, Vector3 directionalNoiseStrengthMin, Vector3 directionalNoiseStrengthMax, Vector3 randomnessSeed, bool randomizeSeedOnShake, bool useAttenuation, AnimationCurve attenuationCurve, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			MMPositionShakeEvent.OnEvent?.Invoke(duration, shakeSpeed, shakeRange, shakeMainDirection, randomizeDirection, shakeAltDirection, randomizeDirectionOnPlay, randomizeDirectionX, randomizeDirectionY, randomizeDirectionZ, addDirectionalNoise, directionalNoiseStrengthMin, directionalNoiseStrengthMax, randomnessSeed, randomizeSeedOnShake, useAttenuation, attenuationCurve, useRange, rangeDistance, useRangeFalloff, rangeFalloff, remapRangeFalloff, rangePosition, feedbacksIntensity, channelData, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop, restore);
		}
	}
}
