using System;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public abstract class UnityAudioCapture : MonoBehaviour
	{
		public virtual int OverflowCount => 0;

		public abstract int SampleRate { get; }

		public abstract int ChannelCount { get; }

		public abstract void PrepareCapture();

		public abstract void StartCapture();

		public abstract void StopCapture();

		public abstract void PauseCapture();

		public abstract void ResumeCapture();

		public abstract void FlushBuffer();

		public virtual IntPtr ReadData(out int length)
		{
			length = default(int);
			return (IntPtr)0;
		}

		public static int GetUnityAudioChannelCount()
		{
			return 0;
		}

		private static int GetChannelCount(AudioSpeakerMode mode)
		{
			return 0;
		}
	}
}
