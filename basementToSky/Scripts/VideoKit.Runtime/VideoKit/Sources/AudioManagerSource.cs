using System;
using VideoKit.Clocks;

namespace VideoKit.Sources
{
	internal sealed class AudioManagerSource : IDisposable
	{
		private readonly VideoKitAudioManager audioManager;

		private readonly Action<AudioBuffer> handler;

		private readonly IClock? clock;

		public AudioManagerSource(VideoKitAudioManager audioManager, Action<AudioBuffer> handler, IClock? clock = null)
		{
			this.audioManager = audioManager;
			this.handler = handler;
			this.clock = clock;
			audioManager.OnAudioBuffer += OnAudioBuffer;
		}

		public void Dispose()
		{
			audioManager.OnAudioBuffer -= OnAudioBuffer;
		}

		private void OnAudioBuffer(AudioBuffer srcBuffer)
		{
			AudioBuffer obj = new AudioBuffer(srcBuffer.sampleRate, srcBuffer.channelCount, srcBuffer.data, clock?.timestamp ?? 0);
			try
			{
				handler(obj);
			}
			finally
			{
				((IDisposable)obj/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
