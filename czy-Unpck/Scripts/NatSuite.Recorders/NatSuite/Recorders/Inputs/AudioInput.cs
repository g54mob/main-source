using System;
using NatSuite.Recorders.Clocks;
using UnityEngine;

namespace NatSuite.Recorders.Inputs
{
	public sealed class AudioInput : IDisposable
	{
		private class AudioInputAttachment : MonoBehaviour
		{
			public Action<float[]> sampleBufferDelegate;

			private void OnAudioFilterRead(float[] data, int channels)
			{
				sampleBufferDelegate?.Invoke(data);
			}
		}

		private readonly IMediaRecorder recorder;

		private readonly IClock clock;

		private readonly AudioInputAttachment attachment;

		private readonly bool mute;

		public AudioInput(IMediaRecorder recorder, AudioListener audioListener)
			: this(recorder, null, audioListener)
		{
		}

		public AudioInput(IMediaRecorder recorder, IClock clock, AudioListener audioListener)
			: this(recorder, clock, audioListener.gameObject)
		{
		}

		public AudioInput(IMediaRecorder recorder, IClock clock, GameObject audio)
			: this(recorder, clock, audio, false)
		{
		}

		public AudioInput(IMediaRecorder recorder, AudioSource audioSource, bool mute = false)
			: this(recorder, null, audioSource, mute)
		{
		}

		public AudioInput(IMediaRecorder recorder, IClock clock, AudioSource audioSource, bool mute = false)
			: this(recorder, clock, audioSource.gameObject, mute)
		{
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(attachment);
		}

		private AudioInput(IMediaRecorder recorder, IClock clock, GameObject gameObject, bool mute = false)
		{
			this.recorder = recorder;
			this.clock = clock;
			attachment = gameObject.AddComponent<AudioInputAttachment>();
			attachment.sampleBufferDelegate = OnSampleBuffer;
			this.mute = mute;
		}

		private void OnSampleBuffer(float[] data)
		{
			AndroidJNI.AttachCurrentThread();
			recorder.CommitSamples(data, clock?.timestamp ?? 0);
			if (mute)
			{
				Array.Clear(data, 0, data.Length);
			}
		}
	}
}
