using UnityEngine;

namespace Pug.RP
{
	public class AvgFloat
	{
		public int index;

		private int m_avgSampleCount;

		public float value { get; private set; }

		public float min { get; private set; }

		public float max { get; private set; }

		public float latest { get; private set; }

		public float[] samples { get; private set; }

		public AvgFloat(int sampleCount, int sampleCountHistory)
		{
			sampleCount = Mathf.Max(1, sampleCount);
			sampleCountHistory = Mathf.Max(sampleCount, sampleCountHistory);
			m_avgSampleCount = sampleCount;
			samples = new float[sampleCountHistory];
			index = 0;
		}

		private int mod(int x, int m)
		{
			return (x % m + m) % m;
		}

		public void AddSample(float sample)
		{
			latest = sample;
			samples[index] = sample;
			value = 0f;
			min = float.MaxValue;
			max = float.MinValue;
			for (int i = 0; i < m_avgSampleCount; i++)
			{
				int num = mod(index - i, samples.Length);
				value += samples[num] / (float)m_avgSampleCount;
				min = Mathf.Min(min, samples[num]);
				max = Mathf.Max(max, samples[num]);
			}
			index = (index + 1) % samples.Length;
		}

		public void SetMaterialProperties(Material material)
		{
			material.SetFloatArray("_Samples", samples);
			material.SetFloat("_SampleCount", samples.Length);
			material.SetFloat("_SampleIndex", index);
		}
	}
}
