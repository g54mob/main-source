using System.Collections.Generic;

namespace GAudio
{
	public class GATDynamicPanInfo : AGATPanInfo, GATPlayer.IPlayerWillMixHandler, GATPlayer.IPlayerDidMixHandler
	{
		public readonly List<GATDynamicChannelGain> channelGains;

		private GATDynamicChannelGain[] _indexedChannelGains;

		private GATPlayer _player;

		private bool _needsUpdate;

		private bool _active;

		public bool Active
		{
			get
			{
				return _active;
			}
			set
			{
				if (_active == value)
				{
					return;
				}
				if (_player != null)
				{
					if (value)
					{
						_player.OnPlayerWillMix_Subscribe(this);
						_player.OnPlayerDidMix_Subscribe(this);
					}
					else
					{
						_player.OnPlayerWillMix_Unsubscribe(this);
						_player.OnPlayerDidMix_Unsubscribe(this);
					}
				}
				_active = value;
			}
		}

		public override bool IsAudible
		{
			get
			{
				foreach (GATDynamicChannelGain channelGain in channelGains)
				{
					if (channelGain.Gain > 0f)
					{
						return true;
					}
				}
				return false;
			}
		}

		public GATDynamicPanInfo(GATPlayer player, bool startsActive = true)
		{
			channelGains = new List<GATDynamicChannelGain>(GATInfo.NbOfChannels);
			_indexedChannelGains = new GATDynamicChannelGain[GATInfo.NbOfChannels];
			_player = player;
			Active = startsActive;
		}

		public void SetGainForChannel(float gain, int channel)
		{
			if (channel < _indexedChannelGains.Length)
			{
				GATDynamicChannelGain gATDynamicChannelGain = _indexedChannelGains[channel];
				if (gATDynamicChannelGain == null)
				{
					_indexedChannelGains[channel] = new GATDynamicChannelGain(channel, gain);
					channelGains.Add(_indexedChannelGains[channel]);
				}
				else
				{
					gATDynamicChannelGain.NextGain = gain;
				}
				_needsUpdate = true;
			}
		}

		public float GetGainForChannel(int channel)
		{
			if (_indexedChannelGains[channel] == null)
			{
				return -1f;
			}
			return _indexedChannelGains[channel].Gain;
		}

		public override void SetGains(float[] gains)
		{
			for (int i = 0; i < gains.Length; i++)
			{
				SetGainForChannel(gains[i], i);
			}
		}

		public void CleanUp()
		{
			Active = false;
		}

		public override void PanMixSample(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f)
		{
			if (gain == 1f)
			{
				for (int i = 0; i < channelGains.Count; i++)
				{
					if (channelGains[i].ShouldInterpolate && !sample.IsFirstChunk)
					{
						sample.AudioData.SmoothedGainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, sample.NextIndex, length, channelGains[i]);
					}
					else if (channelGains[i].Gain != 0f)
					{
						sample.AudioData.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, sample.NextIndex, length, channelGains[i]);
					}
				}
				return;
			}
			for (int i = 0; i < channelGains.Count; i++)
			{
				if (channelGains[i].ShouldInterpolate && !sample.IsFirstChunk)
				{
					sample.AudioData.SmoothedGainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, sample.NextIndex, length, channelGains[i], gain);
				}
				else if (channelGains[i].Gain != 0f)
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
					if (channelGains[i].ShouldInterpolate && !sample.IsFirstChunk)
					{
						sample.ProcessingBuffer.SmoothedGainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, 0, length, channelGains[i]);
					}
					else if (channelGains[i].Gain != 0f)
					{
						sample.ProcessingBuffer.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, 0, length, channelGains[i]);
					}
				}
				return;
			}
			for (int i = 0; i < channelGains.Count; i++)
			{
				if (channelGains[i].ShouldInterpolate && !sample.IsFirstChunk)
				{
					sample.ProcessingBuffer.SmoothedGainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, 0, length, channelGains[i], gain);
				}
				else if (channelGains[i].Gain != 0f)
				{
					sample.ProcessingBuffer.GainMixToInterlaced(audioBuffer, sample.OffsetInBuffer * GATInfo.NbOfChannels, 0, length, channelGains[i], gain);
				}
			}
		}

		public void OnPlayerWillMix()
		{
			if (_needsUpdate)
			{
				for (int i = 0; i < channelGains.Count; i++)
				{
					channelGains[i].PlayerWillMix();
				}
				_needsUpdate = false;
			}
		}

		public void OnPlayerDidMix()
		{
			for (int i = 0; i < channelGains.Count; i++)
			{
				channelGains[i].PlayerDidMix();
			}
		}
	}
}
