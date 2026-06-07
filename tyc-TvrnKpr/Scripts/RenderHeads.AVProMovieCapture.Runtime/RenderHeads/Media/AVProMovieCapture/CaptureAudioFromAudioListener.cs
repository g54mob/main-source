using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Audio/Capture Audio (From AudioListener)", 500)]
	[RequireComponent(typeof(AudioListener))]
	public class CaptureAudioFromAudioListener : UnityAudioCapture
	{
		[SerializeField]
		private bool _debugLogging;

		[SerializeField]
		private bool _muteAudio;

		private const int BufferSize = 16;

		private float[] _buffer;

		private float[] _readBuffer;

		private int _bufferIndex;

		private GCHandle _bufferHandle;

		private int _numChannels;

		private int _overflowCount;

		private object _lockObject;

		private bool _paused;

		public float[] Buffer => null;

		public int BufferLength => 0;

		public IntPtr BufferPtr => (IntPtr)0;

		public override int OverflowCount => 0;

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

		public override IntPtr ReadData(out int length)
		{
			length = default(int);
			return (IntPtr)0;
		}

		public override void FlushBuffer()
		{
		}

		private void OnAudioFilterRead(float[] data, int channels)
		{
		}
	}
}
