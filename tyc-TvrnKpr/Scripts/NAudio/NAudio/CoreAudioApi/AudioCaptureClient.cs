using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioCaptureClient : IDisposable
	{
		private IAudioCaptureClient audioCaptureClientInterface;

		internal AudioCaptureClient(IAudioCaptureClient audioCaptureClientInterface)
		{
		}

		public IntPtr GetBuffer(out int numFramesToRead, out AudioClientBufferFlags bufferFlags, out long devicePosition, out long qpcPosition)
		{
			numFramesToRead = default(int);
			bufferFlags = default(AudioClientBufferFlags);
			devicePosition = default(long);
			qpcPosition = default(long);
			return (IntPtr)0;
		}

		public IntPtr GetBuffer(out int numFramesToRead, out AudioClientBufferFlags bufferFlags)
		{
			numFramesToRead = default(int);
			bufferFlags = default(AudioClientBufferFlags);
			return (IntPtr)0;
		}

		public int GetNextPacketSize()
		{
			return 0;
		}

		public void ReleaseBuffer(int numFramesWritten)
		{
		}

		public void Dispose()
		{
		}
	}
}
