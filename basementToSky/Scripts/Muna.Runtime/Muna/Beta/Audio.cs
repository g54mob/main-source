using Newtonsoft.Json;

namespace Muna.Beta
{
	[Preserve]
	public readonly struct Audio
	{
		[JsonIgnore]
		public readonly float[] samples;

		public readonly int sampleRate;

		public readonly int channelCount;

		public readonly int sampleCount;

		private unsafe readonly float* nativeSamples;

		public unsafe Audio(float[] samples, int sampleRate, int channelCount)
		{
			this.samples = samples;
			nativeSamples = null;
			this.sampleRate = sampleRate;
			this.channelCount = channelCount;
			sampleCount = samples.Length;
		}

		public unsafe Audio(float* samples, int sampleCount, int sampleRate, int channelCount)
		{
			this.samples = null;
			nativeSamples = samples;
			this.sampleRate = sampleRate;
			this.channelCount = channelCount;
			this.sampleCount = sampleCount;
		}

		public unsafe ref float GetPinnableReference()
		{
			if (nativeSamples != null)
			{
				return ref *nativeSamples;
			}
			return ref samples[0];
		}

		internal unsafe Tensor<float> AsTensor()
		{
			int num = sampleCount / channelCount;
			int[] shape = new int[2] { num, channelCount };
			if (nativeSamples == null)
			{
				return new Tensor<float>(samples, shape);
			}
			return new Tensor<float>(nativeSamples, shape);
		}
	}
}
