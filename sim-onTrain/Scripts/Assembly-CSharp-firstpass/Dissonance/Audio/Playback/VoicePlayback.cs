using System.Collections.Generic;
using Dissonance.Networking;
using NAudio.Wave;
using UnityEngine;

namespace Dissonance.Audio.Playback
{
	public class VoicePlayback : MonoBehaviour, IVoicePlaybackInternal, IRemoteChannelProvider, IVoicePlayback, IVolumeProvider
	{
		private static readonly Log Log = Logs.Create(LogCategory.Playback, "Voice Playback Component");

		private readonly SpeechSessionStream _sessions;

		private PlaybackOptions _cachedPlaybackOptions;

		private SamplePlaybackComponent _player;

		private CodecSettings _codecSettings;

		private FrameFormat _frameFormat;

		private float? _savedSpatialBlend;

		public AudioSource AudioSource { get; private set; }

		bool IVoicePlaybackInternal.AllowPositionalPlayback { get; set; }

		public bool IsActive => base.isActiveAndEnabled;

		public string PlayerName
		{
			get
			{
				return _sessions.PlayerName;
			}
			internal set
			{
				_sessions.PlayerName = value;
			}
		}

		public CodecSettings CodecSettings
		{
			get
			{
				return _codecSettings;
			}
			internal set
			{
				_codecSettings = value;
				if (_frameFormat.Codec != _codecSettings.Codec || _frameFormat.FrameSize != _codecSettings.FrameSize || _frameFormat.WaveFormat == null || _frameFormat.WaveFormat.SampleRate != _codecSettings.SampleRate)
				{
					_frameFormat = new FrameFormat(_codecSettings.Codec, new WaveFormat(_codecSettings.SampleRate, 1), _codecSettings.FrameSize);
				}
			}
		}

		public bool IsSpeaking
		{
			get
			{
				if (_player != null)
				{
					return _player.HasActiveSession;
				}
				return false;
			}
		}

		public float Amplitude
		{
			get
			{
				if (!(_player == null))
				{
					return _player.ARV;
				}
				return 0f;
			}
		}

		public ChannelPriority Priority
		{
			get
			{
				if (_player == null)
				{
					return ChannelPriority.None;
				}
				if (!_player.Session.HasValue)
				{
					return ChannelPriority.None;
				}
				return _cachedPlaybackOptions.Priority;
			}
		}

		bool IVoicePlaybackInternal.IsMuted { get; set; }

		float IVoicePlaybackInternal.PlaybackVolume { get; set; }

		private bool IsApplyingAudioSpatialization { get; set; }

		bool IVoicePlaybackInternal.IsApplyingAudioSpatialization => IsApplyingAudioSpatialization;

		internal IPriorityManager PriorityManager { get; set; }

		float? IVoicePlayback.PacketLoss
		{
			get
			{
				SpeechSession? session = _player.Session;
				if (!session.HasValue)
				{
					return null;
				}
				return session.Value.PacketLoss;
			}
		}

		float IVoicePlayback.Jitter => ((IJitterEstimator)_sessions).Jitter;

		[CanBeNull]
		internal IVolumeProvider VolumeProvider { get; set; }

		float IVolumeProvider.TargetVolume
		{
			get
			{
				if (((IVoicePlaybackInternal)this).IsMuted)
				{
					return 0f;
				}
				if (PriorityManager != null && PriorityManager.TopPriority > Priority)
				{
					return 0f;
				}
				float num = VolumeProvider?.TargetVolume ?? 1f;
				return ((IVoicePlaybackInternal)this).PlaybackVolume * num;
			}
		}

		public VoicePlayback()
		{
			_sessions = new SpeechSessionStream(this);
			((IVoicePlaybackInternal)this).PlaybackVolume = 1f;
		}

		public void Awake()
		{
			AudioSource = GetComponent<AudioSource>();
			_player = GetComponent<SamplePlaybackComponent>();
			((IVoicePlaybackInternal)this).Reset();
		}

		void IVoicePlaybackInternal.Reset()
		{
			((IVoicePlaybackInternal)this).IsMuted = false;
			((IVoicePlaybackInternal)this).PlaybackVolume = 1f;
		}

		public void OnEnable()
		{
			AudioSource.Stop();
			if (AudioSource.spatialize)
			{
				IsApplyingAudioSpatialization = false;
				AudioSource.clip = null;
				_player.MultiplyBySource = false;
			}
			else
			{
				IsApplyingAudioSpatialization = true;
				AudioSource.clip = AudioClip.Create("Flatline", 4096, 1, AudioSettings.outputSampleRate, stream: true, delegate(float[] buf)
				{
					for (int i = 0; i < buf.Length; i++)
					{
						buf[i] = 1f;
					}
				});
				_player.MultiplyBySource = true;
			}
			AudioSource.Play();
		}

		public void OnDisable()
		{
			_sessions.StopSession(logNoSessionError: false);
		}

		public void Update()
		{
			if (!_player.HasActiveSession)
			{
				SpeechSession? speechSession = _sessions.TryDequeueSession();
				if (speechSession.HasValue)
				{
					_cachedPlaybackOptions = speechSession.Value.PlaybackOptions;
					_player.Play(speechSession.Value);
				}
			}
			else
			{
				AudioSource.pitch = _player.CorrectedPlaybackSpeed;
			}
			if (AudioSource.mute)
			{
				Log.Warn("Voice AudioSource was muted, unmuting source. To mute a specific Dissonance player see: https://dissonance.readthedocs.io/en/latest/Reference/Other/VoicePlayerState/#islocallymuted-bool");
				AudioSource.mute = false;
			}
			UpdatePositionalPlayback();
		}

		private void UpdatePositionalPlayback()
		{
			SpeechSession? session = _player.Session;
			if (!session.HasValue)
			{
				return;
			}
			_cachedPlaybackOptions = session.Value.PlaybackOptions;
			if (((IVoicePlaybackInternal)this).AllowPositionalPlayback && _cachedPlaybackOptions.IsPositional)
			{
				if (_savedSpatialBlend.HasValue)
				{
					AudioSource.spatialBlend = _savedSpatialBlend.Value;
					_savedSpatialBlend = null;
				}
			}
			else if (!_savedSpatialBlend.HasValue)
			{
				_savedSpatialBlend = AudioSource.spatialBlend;
				AudioSource.spatialBlend = 0f;
			}
		}

		void IVoicePlaybackInternal.SetTransform(Vector3 pos, Quaternion rot)
		{
			Transform obj = base.transform;
			obj.position = pos;
			obj.rotation = rot;
		}

		void IVoicePlaybackInternal.StartPlayback()
		{
			_sessions.StartSession(_frameFormat);
		}

		void IVoicePlaybackInternal.StopPlayback()
		{
			_sessions.StopSession();
		}

		void IVoicePlaybackInternal.ReceiveAudioPacket(VoicePacket packet)
		{
			_sessions.ReceiveFrame(packet);
		}

		void IRemoteChannelProvider.GetRemoteChannels(List<RemoteChannel> output)
		{
			output.Clear();
			if (!(_player == null))
			{
				SpeechSession? session = _player.Session;
				if (session.HasValue)
				{
					session.Value.Channels.GetRemoteChannels(output);
				}
			}
		}
	}
}
