using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioRenderClient : IDisposable
	{
		private IAudioRenderClient audioRenderClientInterface;

		internal AudioRenderClient(IAudioRenderClient audioRenderClientInterface)
		{
		}

		public IntPtr GetBuffer(int numFramesRequested)
		{
			return (IntPtr)0;
		}

		public void ReleaseBuffer(int numFramesWritten, AudioClientBufferFlags bufferFlags)
		{
		}

		public void Dispose()
		{
		}
	}
}
