using System.Collections.Generic;

namespace GAudio
{
	public class GATFixedPanInfo : AGATPanInfo
	{
		public readonly List<GATChannelGain> channelGains;

		public override bool IsAudible
		{
			get
			{
				foreach (GATChannelGain channelGain in channelGains)
				{
					if (channelGain.Gain > 0f)
					{
						return true;
					}
				}
				return false;
			}
		}

		public GATFixedPanInfo(float[] gains)
		{
			if (gains.Length != GATInfo.NbOfChannels)
			{
				throw new GATException("The array of gains should have as many items as there are channels. Use 0f gain in indexes where you need a silent channel.");
			}
			channelGains = new List<GATChannelGain>();
			SetGains(gains);
		}

		public GATFixedPanInfo()
		{
			channelGains = new List<GATChannelGain>();
		}

		public override void SetGains(float[] gains)
		{
			if (channelGains.Count != 0)
			{
				throw new GATException("GATFixedPanInfo gains per channel can only be set once. Use GATDynamicPanInfo for dynamic panning.");
			}
			if (gains.Length != GATInfo.NbOfChannels)
			{
				throw new GATException("The array of gains should have as many items as there are channels. Use 0f gain in indexes where you need a silent channel.");
			}
			for (int i = 0; i < GATInfo.NbOfChannels; i++)
			{
				if (gains[i] != 0f)
				{
					channelGains.Add(new GATChannelGain(i, gains[i]));
				}
			}
		}

		public override void PanMixSample(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f)
		{
			if (gain == 1f)
			{
				for (int i = 0; i < channelGains.Count; i++)
				{
					sample.AudioData.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, sample.NextIndex, length, channelGains[i]);
				}
			}
			else
			{
				for (int i = 0; i < channelGains.Count; i++)
				{
					sample.AudioData.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, sample.NextIndex, length, channelGains[i], gain);
				}
			}
		}

		public override void PanMixProcessingBuffer(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f)
		{
			if (gain == 1f)
			{
				for (int i = 0; i < channelGains.Count; i++)
				{
					sample.ProcessingBuffer.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, 0, length, channelGains[i]);
				}
			}
			else
			{
				for (int i = 0; i < channelGains.Count; i++)
				{
					sample.ProcessingBuffer.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, 0, length, channelGains[i], gain);
				}
			}
		}
	}
}
