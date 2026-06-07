using System.Collections.Generic;

namespace NAudio.Wave
{
	public class MultiplexingWaveProvider : IWaveProvider
	{
		private readonly IList<IWaveProvider> inputs;

		private readonly int outputChannelCount;

		private readonly int inputChannelCount;

		private readonly List<int> mappings;

		private readonly int bytesPerSample;

		private byte[] inputBuffer;

		public WaveFormat WaveFormat { get; }

		public int InputChannelCount => 0;

		public int OutputChannelCount => 0;

		public MultiplexingWaveProvider(IEnumerable<IWaveProvider> inputs)
		{
		}

		public MultiplexingWaveProvider(IEnumerable<IWaveProvider> inputs, int numberOfOutputChannels)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public void ConnectInputToOutput(int inputChannel, int outputChannel)
		{
		}
	}
}
