using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	[Tooltip("VideoKit audio manager for streaming audio from audio devices.")]
	[HelpURL("https://videokit.ai/reference/videokitaudiomanager")]
	[DisallowMultipleComponent]
	public sealed class VideoKitAudioManager : MonoBehaviour
	{
		public enum SampleRate
		{
			MatchUnity = 0,
			_8000 = 8000,
			_16000 = 16000,
			_22050 = 22050,
			_24000 = 24000,
			_44100 = 44100,
			_48000 = 48000
		}

		public enum ChannelCount
		{
			MatchUnity = 0,
			[InspectorName("Mono")]
			_1 = 1,
			[InspectorName("Stereo")]
			_2 = 2
		}

		[Header("Configuration")]
		[Tooltip("Configure the application audio session on awake. This only applies on iOS.")]
		public bool configureOnAwake = true;

		[Header("Format")]
		[Tooltip("Audio sample rate.")]
		public SampleRate sampleRate = SampleRate._44100;

		[Tooltip("Audio channel count.")]
		public ChannelCount channelCount = ChannelCount._1;

		[Tooltip("Request echo cancellation if the device supports it.")]
		public bool echoCancellation;

		private AudioDevice _device;

		public AudioDevice device
		{
			get
			{
				return _device;
			}
			set
			{
				if (running)
				{
					_device.StopRunning();
					_device = value;
					_device?.StartRunning(OnSampleBuffer);
				}
				else
				{
					_device = value;
				}
			}
		}

		public bool running => _device?.running ?? false;

		public event Action<AudioBuffer> OnAudioBuffer;

		public async void StartRunning()
		{
			await StartRunningAsync();
		}

		public async Task StartRunningAsync()
		{
			if (!base.isActiveAndEnabled)
			{
				throw new InvalidOperationException("VideoKit: Audio manager failed to start running because component is disabled");
			}
			if (!running)
			{
				if (await AudioDevice.CheckPermissions() != MediaDevice.PermissionStatus.Authorized)
				{
					throw new InvalidOperationException("VideoKit: User did not grant microphone permissions");
				}
				AudioDevice[] source = await AudioDevice.Discover(configureAudioSession: false);
				if (_device == null)
				{
					_device = source.FirstOrDefault();
				}
				if (_device == null)
				{
					throw new InvalidOperationException("VideoKit: Audio manager failed to start running because no audio device is available");
				}
				_device.sampleRate = ((sampleRate == SampleRate.MatchUnity) ? AudioSettings.outputSampleRate : ((int)sampleRate));
				_device.channelCount = ((channelCount == ChannelCount.MatchUnity) ? ((int)AudioSettings.speakerMode) : ((int)channelCount));
				_device.echoCancellation = echoCancellation;
				_device.StartRunning(OnSampleBuffer);
				VideoKitEvents instance = VideoKitEvents.Instance;
				instance.onPause += OnPause;
				instance.onResume += OnResume;
			}
		}

		public void StopRunning()
		{
			VideoKitEvents optionalInstance = VideoKitEvents.OptionalInstance;
			if (optionalInstance != null)
			{
				optionalInstance.onPause -= OnPause;
				optionalInstance.onResume -= OnResume;
			}
			if (running)
			{
				_device.StopRunning();
			}
		}

		private void Awake()
		{
			if (configureOnAwake)
			{
				VideoKit.Internal.VideoKit.ConfigureAudioSession();
			}
		}

		private void OnSampleBuffer(AudioBuffer audioBuffer)
		{
			this.OnAudioBuffer?.Invoke(audioBuffer);
		}

		private void OnPause()
		{
			_device?.StopRunning();
		}

		private void OnResume()
		{
			if (_device != null)
			{
				_device.StartRunning(OnSampleBuffer);
			}
		}

		private void OnDestroy()
		{
			StopRunning();
		}
	}
}
