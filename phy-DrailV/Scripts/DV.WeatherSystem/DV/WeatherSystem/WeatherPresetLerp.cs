using UnityEngine;

namespace DV.WeatherSystem
{
	public class WeatherPresetLerp
	{
		public float lerpFactor;

		public WeatherSnapshot result;

		public Weather24hPresetSO a;

		public Weather24hPresetSO b;

		private WeatherSnapshot lerpA;

		private WeatherSnapshot lerpB;

		private static WeatherSnapshot s_lerpA = new WeatherSnapshot();

		private static WeatherSnapshot s_lerpB = new WeatherSnapshot();

		public WeatherPresetLerp()
		{
			result = new WeatherSnapshot();
		}

		public static float InverseLerpTime(float timeA, float timeB, float timeOfDay)
		{
			if (timeA > timeB)
			{
				timeB += 1f;
			}
			float num = Mathf.InverseLerp(timeA, timeB, timeOfDay);
			if (num > 1f)
			{
				num -= 1f;
			}
			return num;
		}

		public void Lerp(float timeOfDay, bool highZone)
		{
			Lerp(a, b, timeOfDay, lerpFactor, highZone, result, lerpA, lerpB);
		}

		public static WeatherSnapshot Lerp(Weather24hPresetSO a, Weather24hPresetSO b, float timeOfDay, float lerpFactor, bool highZone, WeatherSnapshot result = null, WeatherSnapshot lerpA = null, WeatherSnapshot lerpB = null)
		{
			if (result == null)
			{
				result = new WeatherSnapshot();
			}
			if (lerpA == null)
			{
				lerpA = s_lerpA;
			}
			if (lerpB == null)
			{
				lerpB = s_lerpB;
			}
			if (highZone)
			{
				a = a.HighZoneOrDefault;
				b = b.HighZoneOrDefault;
			}
			var (weatherSnapshot, weatherSnapshot2) = a.GetPairForTime(timeOfDay);
			var (weatherSnapshot3, weatherSnapshot4) = b.GetPairForTime(timeOfDay);
			WeatherSnapshotLerp.Lerp(weatherSnapshot, weatherSnapshot2, InverseLerpTime(weatherSnapshot.startTime, weatherSnapshot2.startTime, timeOfDay), lerpA);
			WeatherSnapshotLerp.Lerp(weatherSnapshot3, weatherSnapshot4, InverseLerpTime(weatherSnapshot3.startTime, weatherSnapshot4.startTime, timeOfDay), lerpB);
			lerpA.startTime = 0f;
			lerpB.startTime = 1f;
			WeatherSnapshotLerp.Lerp(lerpA, lerpB, lerpFactor, result);
			return result;
		}

		public static WeatherSnapshot Lerp(WeatherSnapshot a, Weather24hPresetSO b, float timeOfDay, float lerpFactor, bool highZone, WeatherSnapshot result = null, WeatherSnapshot lerpB = null)
		{
			if (result == null)
			{
				result = new WeatherSnapshot();
			}
			if (lerpB == null)
			{
				lerpB = s_lerpB;
			}
			if (highZone)
			{
				b = b.HighZoneOrDefault;
			}
			var (weatherSnapshot, weatherSnapshot2) = b.GetPairForTime(timeOfDay);
			WeatherSnapshotLerp.Lerp(weatherSnapshot, weatherSnapshot2, InverseLerpTime(weatherSnapshot.startTime, weatherSnapshot2.startTime, timeOfDay), lerpB);
			a.startTime = 0f;
			lerpB.startTime = 1f;
			WeatherSnapshotLerp.Lerp(a, lerpB, lerpFactor, result);
			return result;
		}
	}
}
