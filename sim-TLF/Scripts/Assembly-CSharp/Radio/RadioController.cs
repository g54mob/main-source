using System;
using UnityEngine;

namespace Radio
{
	[RequireComponent(typeof(RadioStateMachine))]
	[RequireComponent(typeof(RadioChannelManager))]
	[RequireComponent(typeof(RadioPlaybackManager))]
	[RequireComponent(typeof(RadioAudioPlayer))]
	[RequireComponent(typeof(RadioSignalChecker))]
	[RequireComponent(typeof(RadioConditionProcessor))]
	public class RadioController : MonoBehaviour
	{
		private RadioStateMachine _stateMachine;

		private RadioChannelManager _channels;

		private RadioPlaybackManager _playback;

		private RadioConditionProcessor _conditions;

		private RadioAudioPlayer _player;

		private bool _isMuted;

		public RadioState CurrentState => _stateMachine.ActiveState;

		public RadioChannel CurrentChannel => _channels.CurrentChannel;

		public RadioConditionProcessor Conditions => _conditions;

		public event Action<RadioState> OnStateChanged;

		public event Action<RadioChannel> OnChannelChanged;

		public event Action<RadioTrack> OnTrackChanged;

		private void Awake()
		{
			_stateMachine = GetComponent<RadioStateMachine>();
			_channels = GetComponent<RadioChannelManager>();
			_playback = GetComponent<RadioPlaybackManager>();
			_conditions = GetComponent<RadioConditionProcessor>();
			_player = GetComponent<RadioAudioPlayer>();
			_stateMachine.OnStateChanged += delegate(RadioState s)
			{
				this.OnStateChanged?.Invoke(s);
			};
			_playback.OnTrackChanged += delegate(RadioTrack t)
			{
				this.OnTrackChanged?.Invoke(t);
			};
			_channels.OnChannelChanged += delegate(RadioChannel ch)
			{
				_playback.ResetAdCounter();
				this.OnChannelChanged?.Invoke(ch);
			};
		}

		private void Start()
		{
			TurnOn();
			_player.MusicSource.volume = 0f;
			_isMuted = true;
		}

		public void TurnOn()
		{
			_stateMachine.RequestOn();
		}

		public void TurnOff()
		{
			_stateMachine.RequestOff();
		}

		public void Toggle()
		{
			_isMuted = !_isMuted;
			if (_isMuted)
			{
				_player.StopStatic();
			}
			else
			{
				_player.PlayStatic();
			}
			_player.MusicSource.volume = (_isMuted ? 0f : _playback.Volume);
			_player.StaticSource.volume = (_isMuted ? 0f : (0.3f * _playback.Volume));
		}

		public void SetVolume(float value)
		{
			_playback.Volume = value;
		}

		public float GetVolume()
		{
			return _playback.Volume;
		}

		public void SetChannel(int index)
		{
			_channels.SetChannel(index);
		}

		public void NextChannel()
		{
			_channels.Next();
		}

		public void PreviousChannel()
		{
			_channels.Previous();
		}
	}
}
