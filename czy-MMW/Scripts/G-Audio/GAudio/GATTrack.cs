using System;
using UnityEngine;

namespace GAudio
{
	[Serializable]
	public class GATTrack : ScriptableObject, IGATFilterableStream, IGATAudioThreadStreamOwner, GATPlayer.IPlayerWillMixHandler
	{
		[SerializeField]
		protected int _trackNb;

		protected GATDynamicPanInfo _panInfo;

		protected GATData _trackBuffer;

		[SerializeField]
		protected GATFiltersHandler _filtersHandler;

		protected IGATTrackContributor _contributor;

		[SerializeField]
		protected bool _nextMute;

		protected bool _mute;

		protected bool _shouldToggleMute;

		protected bool _hasData;

		protected bool _bufferIsDirty = true;

		[SerializeField]
		protected GATPlayer _player;

		protected volatile bool _active;

		[SerializeField]
		private float[] _gains;

		[SerializeField]
		protected float _stereoGain = 1f;

		[SerializeField]
		protected float _stereoPan = 0.5f;

		protected GATAudioThreadStreamProxy _audioThreadStreamProxy;

		public int TrackNb => _trackNb;

		public GATDynamicPanInfo PanInfo => _panInfo;

		public GATData TrackBuffer => _trackBuffer;

		public GATFiltersHandler FiltersHandler => _filtersHandler;

		public bool Mute
		{
			get
			{
				return _nextMute;
			}
			set
			{
				if (_nextMute != value)
				{
					_nextMute = value;
					_shouldToggleMute = true;
				}
			}
		}

		public float StereoGain
		{
			get
			{
				return _stereoGain;
			}
			set
			{
				if (value != _stereoGain)
				{
					_stereoGain = value;
					_gains[0] = (1f - _stereoPan) * _stereoGain;
					_gains[1] = _stereoPan * _stereoGain;
					_panInfo.SetGains(_gains);
				}
			}
		}

		public float StereoPan
		{
			get
			{
				return _stereoPan;
			}
			set
			{
				if (value != _stereoPan)
				{
					_stereoPan = value;
					_gains[0] = (1f - _stereoPan) * _stereoGain;
					_gains[1] = _stereoPan * _stereoGain;
					_panInfo.SetGains(_gains);
				}
			}
		}

		int IGATAudioThreadStreamOwner.NbOfStreams => 1;

		public static int NbOfMixedSamples { get; protected set; }

		public float GetGainForChannel(int channel)
		{
			if (channel >= _gains.Length)
			{
				return -1f;
			}
			return _gains[channel];
		}

		public void SetGainForChannel(float gain, int channel)
		{
			if (channel < _gains.Length && _gains[channel] != gain)
			{
				_gains[channel] = gain;
				_panInfo.SetGainForChannel(gain, channel);
			}
		}

		public bool SubscribeContributor(IGATTrackContributor contributor)
		{
			if (_contributor == contributor)
			{
				return true;
			}
			if (_contributor != null)
			{
				return false;
			}
			_contributor = contributor;
			return true;
		}

		public bool UnsubscribeContributor(IGATTrackContributor contributor)
		{
			if (_contributor == null)
			{
				return true;
			}
			if (_contributor != contributor)
			{
				return false;
			}
			_contributor = null;
			return true;
		}

		public IGATAudioThreadStream GetAudioThreadStream(int index = 0)
		{
			return _audioThreadStreamProxy;
		}

		public virtual void OnDisable()
		{
			_active = false;
			if (_player != null)
			{
				_player.OnPlayerWillMix_Unsubscribe(this);
			}
		}

		public virtual void InitTrack(GATPlayer parentPlayer, int trackNb)
		{
			_player = parentPlayer;
			_trackNb = trackNb;
			_filtersHandler = ScriptableObject.CreateInstance<GATFiltersHandler>();
			_filtersHandler.InitFiltersHandler(1);
			_gains = new float[GATInfo.NbOfChannels];
			for (int i = 0; i < _gains.Length; i++)
			{
				_gains[i] = 0.5f;
			}
			OnEnable();
		}

		public void TrackNbDidChange(int newNb)
		{
			_trackNb = newNb;
		}

		public bool FXAndMixTo(float[] audioBuffer)
		{
			if (!_active)
			{
				return false;
			}
			bool flag = false;
			if (!_hasData)
			{
				if (_bufferIsDirty)
				{
					_trackBuffer.Clear();
					_bufferIsDirty = false;
				}
				flag = true;
			}
			if (_contributor != null)
			{
				flag = !_contributor.MixToTrack(_trackBuffer, _trackNb);
			}
			if (_filtersHandler.HasFilters && _filtersHandler.ApplyFilters(_trackBuffer.ParentArray, _trackBuffer.MemOffset, GATInfo.AudioBufferSizePerChannel, flag))
			{
				flag = false;
			}
			if (flag)
			{
				_audioThreadStreamProxy.BroadcastStream(_trackBuffer.ParentArray, _trackBuffer.MemOffset, flag);
				return false;
			}
			if (_shouldToggleMute)
			{
				if (_nextMute)
				{
					_trackBuffer.FadeOut(GATInfo.AudioBufferSizePerChannel);
				}
				else
				{
					_trackBuffer.FadeIn(GATInfo.AudioBufferSizePerChannel);
					_mute = false;
				}
				_shouldToggleMute = false;
			}
			_bufferIsDirty = true;
			_audioThreadStreamProxy.BroadcastStream(_trackBuffer.ParentArray, _trackBuffer.MemOffset, isEmptyData: false);
			if (_mute)
			{
				return false;
			}
			for (int i = 0; i < _panInfo.channelGains.Count; i++)
			{
				GATDynamicChannelGain gATDynamicChannelGain = _panInfo.channelGains[i];
				if (gATDynamicChannelGain.ShouldInterpolate)
				{
					_trackBuffer.SmoothedGainMixToInterlaced(audioBuffer, 0, 0, GATInfo.AudioBufferSizePerChannel, gATDynamicChannelGain);
				}
				else if (gATDynamicChannelGain.Gain != 0f)
				{
					_trackBuffer.GainMixToInterlaced(audioBuffer, 0, 0, GATInfo.AudioBufferSizePerChannel, gATDynamicChannelGain);
				}
			}
			if (_nextMute)
			{
				_mute = true;
			}
			return !flag;
		}

		public void MixFrom(GATData data, int index, int offsetInBuffer, int length, float gain = 1f)
		{
			if (!_active)
			{
				return;
			}
			if (_bufferIsDirty)
			{
				if (offsetInBuffer + length < GATInfo.AudioBufferSizePerChannel || offsetInBuffer > 0)
				{
					_trackBuffer.Clear();
				}
				if (gain == 1f)
				{
					data.CopyTo(_trackBuffer, offsetInBuffer, index, length);
				}
				else
				{
					data.CopyGainTo(_trackBuffer, index, offsetInBuffer, length, gain);
				}
				_bufferIsDirty = false;
			}
			else if (gain == 1f)
			{
				data.MixTo(_trackBuffer, offsetInBuffer, index, length);
			}
			else
			{
				data.GainMixTo(_trackBuffer, index, offsetInBuffer, length, gain);
			}
			NbOfMixedSamples++;
			_hasData = true;
		}

		protected virtual void OnEnable()
		{
			if (GATInfo.NbOfChannels != 0 && _player != null)
			{
				_panInfo = new GATDynamicPanInfo(_player);
				_panInfo.SetGains(_gains);
				_trackBuffer = GATManager.GetFixedDataContainer(GATInfo.AudioBufferSizePerChannel, "track" + TrackNb + " buffer");
				_audioThreadStreamProxy = new GATAudioThreadStreamProxy(GATInfo.AudioBufferSizePerChannel, 1, _trackBuffer.GetPointer(), _trackBuffer.MemOffset, "Track " + _trackNb + " stream");
				_player.OnPlayerWillMix_Subscribe(this);
				_mute = _nextMute;
				_active = true;
			}
		}

		private void OnDestroy()
		{
			if (_panInfo != null)
			{
				_panInfo.CleanUp();
			}
			if (_filtersHandler != null)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(_filtersHandler);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(_filtersHandler);
				}
			}
		}

		public void OnPlayerWillMix()
		{
			_hasData = false;
			NbOfMixedSamples = 0;
		}
	}
}
