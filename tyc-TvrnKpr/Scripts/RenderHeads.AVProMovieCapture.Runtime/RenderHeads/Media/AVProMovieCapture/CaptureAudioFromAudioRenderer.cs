using Unity.Collections;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Audio/Capture Audio (From AudioRenderer)", 500)]
	public class CaptureAudioFromAudioRenderer : UnityAudioCapture
	{
		[SerializeField]
		private CaptureBase _capture;

		private int _unityAudioChannelCount;

		private bool _isRendererRecording;

		private NativeArray<float> _audioBuffer;

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

		private NativeArray<float> GetAudioBufferOfLength(int length)
		{
			return default(NativeArray<float>);
		}

		private void DisposeAudioBuffer(NativeArray<float> buffer)
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
