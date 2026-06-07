using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureAudioFromWwise : UnityAudioCapture
	{
		[SerializeField]
		private CaptureBase _capture;

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

		private void Awake()
		{
		}

		public override void PrepareCapture()
		{
		}

		public override void FlushBuffer()
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
	}
}
