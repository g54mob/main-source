using System.Linq;
using Lofelt.NiceVibrations;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	public class AudioToHapticConverter
	{
		public static NVHapticData GenerateHapticFile(AudioClip audioClip, string outputFolder, string outputFileName, bool normalizeAmplitude = false, float normalizeAmplitudeFactor = 1f, bool normalizeFrequency = false, float normalizeFrequencyFactor = 1f, int sampleCount = 100)
		{
			return null;
		}

		protected static GamepadRumble ConvertRumbleData(NVHapticData data, int totalDurationMs, bool normalizeAmplitude = false, float normalizeAmplitudeFactor = 1f, bool normalizeFrequency = false, float normalizeFrequencyFactor = 1f)
		{
			GamepadRumble result = new GamepadRumble
			{
				totalDurationMs = totalDurationMs,
				durationsMs = new int[data.AmplitudePoints.Count],
				highFrequencyMotorSpeeds = new float[data.AmplitudePoints.Count],
				lowFrequencyMotorSpeeds = new float[data.AmplitudePoints.Count]
			};
			for (int i = 0; i < data.AmplitudePoints.Count; i++)
			{
				result.durationsMs[i] = Mathf.RoundToInt(totalDurationMs / data.AmplitudePoints.Count);
				result.highFrequencyMotorSpeeds[i] = data.AmplitudePoints[i].emphasis.amplitude;
				result.lowFrequencyMotorSpeeds[i] = data.FrequencyPoints[i].frequency * result.highFrequencyMotorSpeeds[i];
			}
			if (normalizeAmplitude)
			{
				result.highFrequencyMotorSpeeds = Normalize(result.highFrequencyMotorSpeeds, normalizeAmplitudeFactor);
			}
			if (normalizeFrequency)
			{
				result.lowFrequencyMotorSpeeds = Normalize(result.lowFrequencyMotorSpeeds, normalizeFrequencyFactor);
			}
			return result;
		}

		protected static float[] Normalize(float[] data, float maxDesiredValue)
		{
			float num = data.Max();
			if (num > 0f)
			{
				float num2 = maxDesiredValue / num;
				for (int i = 0; i < data.Length; i++)
				{
					data[i] *= num2;
				}
			}
			return data;
		}

		protected static float EstimateFrequencyZCR(float[] frame, int sampleRate)
		{
			int num = 0;
			for (int i = 1; i < frame.Length; i++)
			{
				if ((frame[i - 1] >= 0f && frame[i] < 0f) || (frame[i - 1] < 0f && frame[i] >= 0f))
				{
					num++;
				}
			}
			float num2 = (float)frame.Length / (float)sampleRate;
			return Mathf.Clamp01((float)num / (2f * num2) / 1000f);
		}
	}
}
