using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Light
{
	[CreateAssetMenu(menuName = "Restory/Light/LightTimePresets", fileName = "LightTimePresets")]
	public class LightTimePresets : ScriptableObject
	{
		[SerializeField]
		private LightTimePreset[] presets = Array.Empty<LightTimePreset>();

		private bool isSorted;

		public IReadOnlyCollection<LightTimePreset> Presets => presets;

		private void OnValidate()
		{
			isSorted = false;
		}

		public void Sort()
		{
			Array.Sort(presets, (LightTimePreset a, LightTimePreset b) => a.TimeOfDay.TotalSeconds.CompareTo(b.TimeOfDay.TotalSeconds));
			isSorted = true;
		}

		public void Get(TimeSpan time, out float intensity, out float temperatureK, out Color color)
		{
			if (presets == null || presets.Length == 0)
			{
				intensity = 0f;
				temperatureK = 0f;
				color = Color.black;
				return;
			}
			if (!isSorted)
			{
				Sort();
			}
			LightTimePreset lightTimePreset = null;
			LightTimePreset lightTimePreset2 = null;
			for (int i = 0; i < presets.Length; i++)
			{
				if (presets[i].TimeOfDay.InTimeSpan() <= time)
				{
					lightTimePreset = presets[i];
				}
				else if (lightTimePreset2 == null)
				{
					lightTimePreset2 = presets[i];
					break;
				}
			}
			if (lightTimePreset == null)
			{
				lightTimePreset = presets[presets.Length - 1];
				lightTimePreset2 = presets[0];
			}
			else if (lightTimePreset2 == null)
			{
				lightTimePreset2 = presets[0];
			}
			float t = CalculateInterpolationFactor(time, lightTimePreset.TimeOfDay.InTimeSpan(), lightTimePreset2.TimeOfDay.InTimeSpan());
			intensity = Mathf.Lerp(lightTimePreset.Intensity, lightTimePreset2.Intensity, t);
			temperatureK = Mathf.Lerp(lightTimePreset.ColorTemperature, lightTimePreset2.ColorTemperature, t);
			color = Color.Lerp(lightTimePreset.Color, lightTimePreset2.Color, t);
		}

		private float CalculateInterpolationFactor(TimeSpan time, TimeSpan prevTime, TimeSpan nextTime)
		{
			double totalSeconds = time.TotalSeconds;
			double totalSeconds2 = prevTime.TotalSeconds;
			double totalSeconds3 = nextTime.TotalSeconds;
			if (totalSeconds3 < totalSeconds2)
			{
				if (totalSeconds >= totalSeconds2)
				{
					double num = 86400.0 - totalSeconds2 + totalSeconds3;
					return (float)((totalSeconds - totalSeconds2) / num);
				}
				double num2 = 86400.0 - totalSeconds2 + totalSeconds3;
				return (float)((86400.0 - totalSeconds2 + totalSeconds) / num2);
			}
			double num3 = totalSeconds3 - totalSeconds2;
			double num4 = totalSeconds - totalSeconds2;
			if (!(num3 > 0.0))
			{
				return 0f;
			}
			return (float)(num4 / num3);
		}
	}
}
