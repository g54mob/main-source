using System;
using UnityEngine;
using VideoKit.Clocks;

namespace VideoKit.Sources
{
	public sealed class AudioComponentSource : IDisposable
	{
		private sealed class AudioSourceAttachment : MonoBehaviour
		{
			public Action<float[], int>? sampleBufferDelegate;

			private void OnAudioFilterRead(float[] data, int channels)
			{
				sampleBufferDelegate?.Invoke(data, channels);
			}
		}

		private readonly AudioSourceAttachment attachment;

		public AudioComponentSource(AudioListener listener, Action<AudioBuffer> handler, IClock? clock = null)
			: this(listener.gameObject, handler, clock)
		{
		}

		public AudioComponentSource(AudioSource source, Action<AudioBuffer> handler, IClock? clock = null)
			: this(source.gameObject, handler, clock)
		{
		}

		public void Dispose()
		{
			UnityEngine.Object.DestroyImmediate(attachment);
		}

		private AudioComponentSource(GameObject gameObject, Action<AudioBuffer> handler, IClock? clock)
		{
			int sampleRate = AudioSettings.outputSampleRate;
			attachment = gameObject.AddComponent<AudioSourceAttachment>();
			attachment.sampleBufferDelegate = delegate(float[] data, int channels)
			{
				AudioBuffer obj = new AudioBuffer(sampleRate, channels, data, clock?.timestamp ?? 0);
				try
				{
					handler(obj);
				}
				finally
				{
					((IDisposable)obj/*cast due to .constrained prefix*/).Dispose();
				}
			};
		}
	}
}
