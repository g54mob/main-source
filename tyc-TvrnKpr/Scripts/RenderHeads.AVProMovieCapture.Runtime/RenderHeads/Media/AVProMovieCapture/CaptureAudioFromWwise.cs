using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Audio/Capture Audio (From Wwise)", 500)]
	public class CaptureAudioFromWwise : UnityAudioCapture
	{
		[SerializeField]
		private CaptureBase _capture;

		private int _audioChannelCount;

		private int _audioSampleRate;

		private ulong _outputDeviceId;

		private bool _isRendererRecording;

		public CaptureBase Capture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int SampleRate => 0;

		public override int ChannelCount => 0;

		public override void PrepareCapture()
		{
		}

		public override void StartCapture()
		{
		}

		public override void StopCapture()
		{
		}

		public override void PauseCapture()
		{
		}

		public override void ResumeCapture()
		{
		}

		public override void FlushBuffer()
		{
		}

		private void Update()
		{
		}
	}
}
