using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using VideoKit.Clocks;
using VideoKit.Sources;
using VideoKit.UI;

namespace VideoKit
{
	[Tooltip("VideoKit recorder for recording videos.")]
	[HelpURL("https://videokit.ai/reference/videokitrecorder")]
	[DisallowMultipleComponent]
	public sealed class VideoKitRecorder : MonoBehaviour
	{
		public enum VideoMode
		{
			None = 0,
			Camera = 1,
			Screen = 2,
			Texture = 3,
			CameraDevice = 4
		}

		public enum AudioMode
		{
			None = 0,
			AudioDevice = 2,
			AudioListener = 1,
			AudioSource = 4
		}

		public enum Resolution
		{
			_240xAuto = 11,
			_320xAuto = 5,
			[InspectorName("480p Portrait")]
			_480xAuto = 6,
			[InspectorName("480p Landscape")]
			_640xAuto = 0,
			[InspectorName("720p Portrait")]
			_720xAuto = 7,
			[InspectorName("720p Landscape")]
			_1280xAuto = 1,
			[InspectorName("1080p Portrait")]
			_1080xAuto = 12,
			[InspectorName("1080p Landscape")]
			_1920xAuto = 2,
			[InspectorName("2K Portrait")]
			_1440xAuto = 13,
			[InspectorName("2K Landscape")]
			_2560xAuto = 3,
			[InspectorName("4K Portrait")]
			_2160xAuto = 14,
			[InspectorName("4K Landscape")]
			_3840xAuto = 4,
			Screen = 9,
			HalfScreen = 10,
			Custom = 8
		}

		public enum Status
		{
			Idle = 0,
			Recording = 1,
			Paused = 2
		}

		public enum WatermarkMode
		{
			None = 0,
			BottomLeft = 1,
			BottomRight = 2,
			UpperLeft = 3,
			UpperRight = 4,
			Custom = 5
		}

		[Flags]
		public enum RecordingAction
		{
			None = 0,
			CameraRoll = 2,
			Share = 4,
			Playback = 8,
			Custom = 0x20
		}

		public struct Configuration
		{
			public MediaRecorder.Format foamt;

			public int width;

			public int height;

			public float frameRate;

			public int sampleRate;

			public int channelCount;

			public int videoBitRate;

			public int keyframeInterval;

			public int audioBitRate;

			public string recordingPathPrefix;
		}

		[Header("Format")]
		[Tooltip("Recording format.")]
		public MediaRecorder.Format format;

		[Tooltip("Prepare the hardware encoders on awake. This prevents a noticeable stutter that occurs on the very first recording.")]
		public bool prepareOnAwake;

		[Header("Video")]
		[Tooltip("Video recording mode.")]
		public VideoMode videoMode = VideoMode.Camera;

		[Tooltip("Video recording resolution.")]
		public Resolution resolution = Resolution._1280xAuto;

		[Tooltip("Video recording custom resolution.")]
		public Vector2Int customResolution = new Vector2Int(1280, 720);

		[Tooltip("Game cameras to record.")]
		public Camera[] cameras = new Camera[0];

		[Tooltip("Recording texture for recording video frames from a texture.")]
		public Texture? texture;

		[Tooltip("Camera view for recording video frames from a camera device.")]
		public VideoKitCameraView? cameraView;

		[Tooltip("Frame rate for animated GIF images.")]
		[Range(5f, 30f)]
		[FormerlySerializedAs("frameRate")]
		public float _frameRate = 10f;

		[Tooltip("Number of successive camera frames to skip while recording.")]
		[Range(0f, 5f)]
		public int frameSkip;

		[Header("Watermark")]
		[Tooltip("Recording watermark mode for adding a watermark to videos.")]
		public WatermarkMode watermarkMode;

		[SerializeField]
		[FormerlySerializedAs("watermark")]
		[Tooltip("Recording watermark.")]
		private Texture? _watermark;

		[SerializeField]
		[FormerlySerializedAs("watermarkRect")]
		[Tooltip("Watermark display rect when `watermarkMode` is set to `WatermarkMode.Custom`")]
		private Rect _watermarkRect;

		[Header("Audio")]
		[Tooltip("Audio recording mode.")]
		public AudioMode audioMode;

		[Tooltip("Audio manager for recording audio from an audio device.")]
		public VideoKitAudioManager? audioManager;

		[Tooltip("Whether the recorder can configure the audio manager for recording.")]
		public bool configureAudioManager = true;

		[Tooltip("Audio listener for recording audio from an audio listener.")]
		public AudioListener? audioListener;

		[Tooltip("Audio source for recording audio from an audio source.")]
		public AudioSource? audioSource;

		[Header("Recording")]
		[Tooltip("Recording action.")]
		public RecordingAction recordingAction;

		[Tooltip("Event raised when a recording session is completed.")]
		public UnityEvent<MediaAsset>? OnRecordingCompleted;

		public string mediaPathPrefix = "";

		[HideInInspector]
		public int videoBitRate = 20000000;

		[HideInInspector]
		public int keyframeInterval = 2;

		[HideInInspector]
		public int audioBitRate = 64000;

		public Func<Configuration, Task<MediaRecorder>>? recorderFactory;

		private MediaRecorder? recorder;

		private RealtimeClock? clock;

		private IDisposable? videoInput;

		private IDisposable? audioInput;

		public Configuration configuration
		{
			get
			{
				Resolution resolution = this.resolution;
				int num = ((this.videoMode != VideoMode.None) ? ((this.videoMode == VideoMode.CameraDevice) ? cameraView.texture.width : (resolution switch
				{
					Resolution._240xAuto => 240, 
					Resolution._320xAuto => 320, 
					Resolution._480xAuto => 480, 
					Resolution._640xAuto => 640, 
					Resolution._720xAuto => 720, 
					Resolution._1080xAuto => 1080, 
					Resolution._1280xAuto => 1280, 
					Resolution._1920xAuto => 1920, 
					Resolution._1440xAuto => 1440, 
					Resolution._2560xAuto => 2560, 
					Resolution._3840xAuto => 3840, 
					Resolution.Screen => Screen.width >> 1 << 1, 
					Resolution.HalfScreen => Screen.width >> 2 << 1, 
					Resolution.Custom => customResolution.x, 
					_ => 1280, 
				})) : 0);
				int num2 = num;
				float num3 = this.videoMode switch
				{
					VideoMode.Camera => (float)Screen.width / (float)Screen.height, 
					VideoMode.Screen => (float)Screen.width / (float)Screen.height, 
					VideoMode.Texture => (float)texture.width / (float)texture.height, 
					_ => 0f, 
				};
				resolution = this.resolution;
				num = ((this.videoMode != VideoMode.None) ? ((this.videoMode == VideoMode.CameraDevice) ? cameraView.texture.height : (resolution switch
				{
					Resolution.Custom => customResolution.y, 
					Resolution.Screen => Screen.height >> 1 << 1, 
					Resolution.HalfScreen => Screen.height >> 2 << 1, 
					_ => Mathf.RoundToInt((float)num2 / num3) >> 1 << 1, 
				})) : 0);
				int height = num;
				VideoMode videoMode = this.videoMode;
				float num4 = ((format == MediaRecorder.Format.GIF) ? _frameRate : ((videoMode != VideoMode.CameraDevice) ? 30f : cameraView.device.frameRate));
				float frameRate = num4;
				int sampleRate = audioMode switch
				{
					AudioMode.AudioDevice => (audioManager?.device?.sampleRate).GetValueOrDefault(), 
					AudioMode.AudioListener => AudioSettings.outputSampleRate, 
					AudioMode.AudioSource => AudioSettings.outputSampleRate, 
					_ => 0, 
				};
				int channelCount = audioMode switch
				{
					AudioMode.AudioDevice => (audioManager?.device?.channelCount).GetValueOrDefault(), 
					AudioMode.AudioListener => (int)AudioSettings.speakerMode, 
					AudioMode.AudioSource => (int)AudioSettings.speakerMode, 
					_ => 0, 
				};
				return new Configuration
				{
					width = num2,
					height = height,
					frameRate = frameRate,
					sampleRate = sampleRate,
					channelCount = channelCount,
					videoBitRate = videoBitRate,
					keyframeInterval = keyframeInterval,
					audioBitRate = audioBitRate,
					recordingPathPrefix = mediaPathPrefix
				};
			}
		}

		public Texture? watermark
		{
			get
			{
				return GetTextureSource(videoInput)?.watermark ?? _watermark;
			}
			set
			{
				_watermark = value;
				TextureSource textureSource = GetTextureSource(videoInput);
				if (textureSource != null)
				{
					textureSource.watermark = value;
				}
			}
		}

		public Rect watermarkRect
		{
			get
			{
				TextureSource textureSource = GetTextureSource(videoInput);
				if (textureSource == null)
				{
					return _watermarkRect;
				}
				Configuration configuration = this.configuration;
				int num = recorder?.width ?? configuration.width;
				int num2 = recorder?.height ?? configuration.height;
				RectInt rectInt = textureSource.watermarkRect;
				return new Rect(rectInt.x / num, rectInt.y / num2, rectInt.width / num, rectInt.height / num2);
			}
			set
			{
				_watermarkRect = value;
				Configuration configuration = this.configuration;
				int num = recorder?.width ?? configuration.width;
				int num2 = recorder?.height ?? configuration.height;
				TextureSource textureSource = GetTextureSource(videoInput);
				if (textureSource != null)
				{
					textureSource.watermarkRect = new RectInt(Mathf.RoundToInt(value.x * (float)num), Mathf.RoundToInt(value.y * (float)num2), Mathf.RoundToInt(value.width * (float)num), Mathf.RoundToInt(value.height * (float)num2));
				}
			}
		}

		public Status status
		{
			get
			{
				bool? flag = clock?.paused;
				if (flag.HasValue)
				{
					if (flag == true)
					{
						return Status.Paused;
					}
					return Status.Recording;
				}
				return Status.Idle;
			}
		}

		public async void StartRecording()
		{
			await StartRecordingAsync();
		}

		public async Task StartRecordingAsync()
		{
			if (!base.isActiveAndEnabled)
			{
				throw new InvalidOperationException("VideoKitRecorder cannot start recording because component is disabled");
			}
			if (status != Status.Idle)
			{
				throw new InvalidOperationException("VideoKitRecorder cannot start recording because a recording session is already in progress");
			}
			if (videoMode == VideoMode.CameraDevice)
			{
				if (cameraView == null)
				{
					throw new InvalidOperationException("VideoKitRecorder cannot start recording because the video mode is set to `VideoMode.CameraDevice` but `cameraView` is null");
				}
				if (cameraView.texture == null)
				{
					throw new InvalidOperationException("VideoKitRecorder cannot start recording because the video mode is set to `VideoMode.CameraDevice` but the camera preview is not running");
				}
			}
			if (audioMode.HasFlag(AudioMode.AudioListener) && Application.platform == RuntimePlatform.WebGLPlayer)
			{
				Debug.LogWarning("VideoKitRecorder cannot record audio from AudioListener because WebGL does not support `OnAudioFilterRead`");
				audioMode &= (AudioMode)(-2);
			}
			if (audioMode.HasFlag(AudioMode.AudioDevice))
			{
				if (audioManager == null)
				{
					throw new InvalidOperationException("VideoKitRecorder cannot start recording because the audio mode includes `AudioMode.AudioDevice` but `audioManager` is null");
				}
				if (configureAudioManager)
				{
					if (audioMode.HasFlag(AudioMode.AudioListener))
					{
						audioManager.sampleRate = VideoKitAudioManager.SampleRate.MatchUnity;
						audioManager.channelCount = VideoKitAudioManager.ChannelCount.MatchUnity;
					}
					await audioManager.StartRunningAsync();
				}
			}
			if (format == MediaRecorder.Format.MP4 && Application.platform == RuntimePlatform.WebGLPlayer)
			{
				format = MediaRecorder.Format.WEBM;
				Debug.LogWarning("VideoKitRecorder will use WEBM format on WebGL because MP4 is not supported");
			}
			Configuration arg = configuration;
			if (recorderFactory != null)
			{
				recorder = await recorderFactory(arg);
			}
			else
			{
				recorder = await MediaRecorder.Create(format, arg.width, arg.height, arg.frameRate, arg.sampleRate, arg.channelCount, arg.videoBitRate, arg.keyframeInterval, 0.8f, arg.audioBitRate, arg.recordingPathPrefix);
			}
			clock = new RealtimeClock();
			videoInput = (recorder.canAppendPixelBuffer ? CreateVideoInput(recorder.width, recorder.height, recorder.Append) : null);
			audioInput = (recorder.canAppendAudioBuffer ? CreateAudioInput(recorder.Append) : null);
			TextureSource textureSource = GetTextureSource(videoInput);
			if (textureSource != null)
			{
				textureSource.watermark = watermark;
				textureSource.watermarkRect = CreateWatermarkRect(recorder.width, recorder.height);
			}
		}

		[Obsolete("Deprecated in VideoKit 0.0.20 and will be removed soon after.", false)]
		public void PauseRecording()
		{
			if (status != Status.Recording)
			{
				Debug.LogError("Cannot pause recording because no recording session is in progress");
				return;
			}
			if (configureAudioManager && audioManager != null)
			{
				audioManager.StopRunning();
			}
			videoInput?.Dispose();
			audioInput?.Dispose();
			videoInput = null;
			audioInput = null;
			clock.paused = true;
		}

		[Obsolete("Deprecated in VideoKit 0.0.20 and will be removed soon after.", false)]
		public void ResumeRecording()
		{
			if (status != Status.Paused)
			{
				Debug.LogError("Cannot resume recording because the recording session is not paused");
				return;
			}
			if (recorder == null)
			{
				Debug.LogError("Cannot resume recording because the recording session is invalid");
				return;
			}
			if (!base.isActiveAndEnabled)
			{
				Debug.LogError("Cannot resume recording because component is disabled");
				return;
			}
			if (configureAudioManager && audioManager != null)
			{
				audioManager.StartRunning();
			}
			clock.paused = false;
			videoInput = (recorder.canAppendPixelBuffer ? CreateVideoInput(recorder.width, recorder.height, recorder.Append) : null);
			audioInput = (recorder.canAppendAudioBuffer ? CreateAudioInput(recorder.Append) : null);
			TextureSource textureSource = GetTextureSource(videoInput);
			if (textureSource != null)
			{
				textureSource.watermark = watermark;
				textureSource.watermarkRect = CreateWatermarkRect(recorder.width, recorder.height);
			}
		}

		public async void StopRecording()
		{
			await StopRecordingAsync();
		}

		public async Task StopRecordingAsync()
		{
			if (status == Status.Idle)
			{
				Debug.LogWarning("Cannot stop recording because no recording session is in progress");
				return;
			}
			if (configureAudioManager && audioManager != null)
			{
				audioManager.StopRunning();
			}
			audioInput?.Dispose();
			videoInput?.Dispose();
			videoInput = null;
			audioInput = null;
			clock = null;
			MediaAsset asset = await recorder.FinishWriting();
			if (base.isActiveAndEnabled)
			{
				if (recordingAction.HasFlag(RecordingAction.Custom))
				{
					OnRecordingCompleted?.Invoke(asset);
				}
				if (recordingAction.HasFlag(RecordingAction.CameraRoll))
				{
					await asset.SaveToCameraRoll();
				}
				if (recordingAction.HasFlag(RecordingAction.Share))
				{
					await asset.Share();
				}
			}
		}

		public async Task<MediaAsset> CaptureScreenshot()
		{
			Configuration configuration = this.configuration;
			MediaRecorder recorder = await MediaRecorder.Create(MediaRecorder.Format.JPEG, configuration.width, configuration.height, 0f, 0, 0, 20000000, 2, 0.8f, 64000, configuration.recordingPathPrefix);
			TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
			using (IDisposable source = CreateVideoInput(recorder.width, recorder.height, delegate(PixelBuffer pixelBuffer)
			{
				if (!tcs.Task.IsCompleted)
				{
					recorder.Append(pixelBuffer);
					tcs.SetResult(result: true);
				}
			}))
			{
				TextureSource textureSource = GetTextureSource(source);
				if (textureSource != null)
				{
					textureSource.watermark = watermark;
					textureSource.watermarkRect = CreateWatermarkRect(recorder.width, recorder.height);
				}
				await tcs.Task;
			}
			return (await recorder.FinishWriting()).assets[0];
		}

		private void Reset()
		{
			cameras = Camera.allCameras;
			cameraView = UnityEngine.Object.FindFirstObjectByType<VideoKitCameraView>();
			audioManager = UnityEngine.Object.FindFirstObjectByType<VideoKitAudioManager>();
			audioListener = UnityEngine.Object.FindFirstObjectByType<AudioListener>();
		}

		private async void Awake()
		{
			if (prepareOnAwake)
			{
				await PrepareEncoder();
			}
		}

		private void OnDestroy()
		{
			if (status != Status.Idle)
			{
				StopRecording();
			}
		}

		private IDisposable? CreateVideoInput(int width, int height, Action<PixelBuffer> handler)
		{
			return videoMode switch
			{
				VideoMode.Screen => new ScreenSource(width, height, handler, clock)
				{
					frameSkip = frameSkip
				}, 
				VideoMode.Camera => new CameraSource(width, height, cameras, handler, clock)
				{
					frameSkip = frameSkip
				}, 
				VideoMode.Texture => new TextureSource(width, height, handler, clock)
				{
					texture = texture,
					frameSkip = frameSkip
				}, 
				VideoMode.CameraDevice => new CameraViewSource(cameraView, handler, clock)
				{
					frameSkip = frameSkip
				}, 
				_ => null, 
			};
		}

		private IDisposable? CreateAudioInput(Action<AudioBuffer> handler)
		{
			return audioMode switch
			{
				AudioMode.AudioDevice => new AudioManagerSource(audioManager, handler, clock), 
				AudioMode.AudioListener => new AudioComponentSource(audioListener, handler, clock), 
				AudioMode.AudioSource => new AudioComponentSource(audioSource, handler, clock), 
				_ => null, 
			};
		}

		private RectInt CreateWatermarkRect(int width, int height)
		{
			if (watermarkMode == WatermarkMode.None)
			{
				return default(RectInt);
			}
			if (watermarkMode == WatermarkMode.Custom)
			{
				return new RectInt(Mathf.RoundToInt(watermarkRect.x * (float)width), Mathf.RoundToInt(watermarkRect.y * (float)height), Mathf.RoundToInt(watermarkRect.width * (float)width), Mathf.RoundToInt(watermarkRect.height * (float)height));
			}
			Vector2 b = new Vector2(width, height);
			float num = 0.1f;
			float num2 = 0.3f;
			Rect rect = new Dictionary<WatermarkMode, Rect>
			{
				[WatermarkMode.BottomLeft] = new Rect(num, num, num2, num2),
				[WatermarkMode.BottomRight] = new Rect(1f - num2 - num, num, num2, num2),
				[WatermarkMode.UpperLeft] = new Rect(num, 1f - num2 - num, num2, num2),
				[WatermarkMode.UpperRight] = new Rect(1f - num2 - num, 1f - num2 - num, num2, num2)
			}[watermarkMode];
			return new RectInt(Vector2Int.RoundToInt(Vector2.Scale(rect.position, b)), Vector2Int.RoundToInt(Vector2.Scale(rect.size, b)));
		}

		private static async Task PrepareEncoder()
		{
			_ = 1;
			try
			{
				FixedClock clock = new FixedClock(30f);
				MediaRecorder mediaRecorder = await MediaRecorder.Create(MediaRecorder.Format.MP4, 1280, 720, 30f);
				using NativeArray<byte> pixelData = new NativeArray<byte>(mediaRecorder.width * mediaRecorder.height * 4, Allocator.Persistent);
				PixelBuffer.Format format = PixelBuffer.Format.RGBA8888;
				for (int i = 0; i < 3; i++)
				{
					using PixelBuffer pixelBuffer = new PixelBuffer(mediaRecorder.width, mediaRecorder.height, format, pixelData, 0, clock.timestamp);
					mediaRecorder.Append(pixelBuffer);
				}
				File.Delete((await mediaRecorder.FinishWriting()).path);
			}
			catch
			{
			}
		}

		private static TextureSource? GetTextureSource(IDisposable? videoInput)
		{
			if (!(videoInput is CameraSource cameraSource))
			{
				if (!(videoInput is ScreenSource screenSource))
				{
					if (videoInput is TextureSource result)
					{
						return result;
					}
					return null;
				}
				return screenSource.textureSource;
			}
			return cameraSource.textureSource;
		}
	}
}
