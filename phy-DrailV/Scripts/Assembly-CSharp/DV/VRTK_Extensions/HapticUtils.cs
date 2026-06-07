using System;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public static class HapticUtils
	{
		private static Dictionary<HapticIntensityType, float> hapticIntensities = new Dictionary<HapticIntensityType, float>();

		private static float defaultIntensity = 0.5f;

		public static void SetHapticIntensities(params (HapticIntensityType hapticType, float intensity)[] typeIntensities)
		{
			if (hapticIntensities.Count != Enum.GetValues(typeof(HapticIntensityType)).Length)
			{
				for (int i = 0; i < typeIntensities.Length; i++)
				{
					(HapticIntensityType, float) tuple = typeIntensities[i];
					hapticIntensities[tuple.Item1] = tuple.Item2;
				}
			}
		}

		public static void DoHapticPulse(VRTK_ControllerReference controllerReference, HapticIntensityType intensityType)
		{
			if (!hapticIntensities.TryGetValue(intensityType, out var value))
			{
				value = defaultIntensity;
			}
			VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, value);
		}

		public static void DoHapticPulse(VRTK_ControllerReference controllerReference, float strength)
		{
			HapticIntensityType intensityType = (HapticIntensityType)Math.Min(Mathf.FloorToInt(strength * (float)hapticIntensities.Count), hapticIntensities.Count - 1);
			DoHapticPulse(controllerReference, intensityType);
		}

		public static void DoHapticPulse(VRTK_ControllerReference controllerReference, HapticIntensityType intensityType, float duration, float pulseInterval)
		{
			if (!hapticIntensities.TryGetValue(intensityType, out var value))
			{
				value = defaultIntensity;
			}
			VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, value, duration, pulseInterval);
		}
	}
}
