namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureStats
	{
		private uint _numDroppedFrames;

		private uint _numDroppedEncoderFrames;

		private uint _numEncodedFrames;

		private float _totalEncodedSeconds;

		private uint _totalBuffersAvailable;

		private uint _numBufferedFrames;

		private ulong _activeWorkers;

		private int _maxActiveWorkers;

		private AudioCaptureSource _audioCaptureSource;

		private int _unityAudioSampleRate;

		private int _unityAudioChannelCount;

		private float _fps;

		private int _frameTotal;

		private int _frameCount;

		private float _startFrameTime;

		public float FPS => 0f;

		public float FramesTotal => 0f;

		public uint NumDroppedFrames
		{
			get
			{
				return 0u;
			}
			internal set
			{
			}
		}

		public uint NumDroppedEncoderFrames
		{
			get
			{
				return 0u;
			}
			internal set
			{
			}
		}

		public uint NumEncodedFrames
		{
			get
			{
				return 0u;
			}
			internal set
			{
			}
		}

		public float TotalEncodedSeconds
		{
			get
			{
				return 0f;
			}
			internal set
			{
			}
		}

		public uint TotalBuffersAvailable
		{
			get
			{
				return 0u;
			}
			internal set
			{
			}
		}

		public uint NumBufferedFrames
		{
			get
			{
				return 0u;
			}
			internal set
			{
			}
		}

		public ulong ActiveWorkers
		{
			get
			{
				return 0uL;
			}
			internal set
			{
			}
		}

		public int MaxActiveWorkers
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public AudioCaptureSource AudioCaptureSource
		{
			get
			{
				return default(AudioCaptureSource);
			}
			internal set
			{
			}
		}

		public int UnityAudioSampleRate
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public int UnityAudioChannelCount
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		internal void ResetFPS()
		{
		}

		internal void UpdateFPS()
		{
		}
	}
}
