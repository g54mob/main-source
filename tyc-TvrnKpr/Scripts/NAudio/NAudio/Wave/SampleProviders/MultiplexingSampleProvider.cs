using System.Collections.Generic;

namespace NAudio.Wave.SampleProviders
{
	public class MultiplexingSampleProvider : ISampleProvider
	{
		private readonly IList<ISampleProvider> inputs;

		private readonly WaveFormat waveFormat;

		private readonly int outputChannelCount;

		private readonly int inputChannelCount;

		private readonly List<int> mappings;

		private float[] inputBuffer;

		public WaveFormat WaveFormat => null;

		public int InputChannelCount => 0;

		public int OutputChannelCount => 0;

		public MultiplexingSampleProvider(IEnumerable<ISampleProvider> inputs, int numberOfOutputChannels)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		public void ConnectInputToOutput(int inputChannel, int outputChannel)
		{
		}
	}
}
