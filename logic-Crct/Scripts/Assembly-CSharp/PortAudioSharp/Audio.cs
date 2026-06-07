using System;

namespace PortAudioSharp
{
	public class Audio : IDisposable
	{
		private readonly int inputDeviceIndex;

		private readonly int outputDeviceIndex;

		private readonly int inputChannels;

		private readonly int outputChannels;

		private readonly int frequency;

		private readonly uint framesPerBuffer;

		private readonly PortAudio.PaStreamCallbackDelegate paStreamCallback;

		private readonly PortAudio.PaDeviceInfo inputDeviceInfo;

		private readonly PortAudio.PaDeviceInfo outputDeviceInfo;

		private IntPtr stream;

		private static bool loggingEnabled;

		private bool disposed;

		private bool started;

		private IntPtr userData;

		public static bool LoggingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Audio(int inputDeviceIndex, int outputDeviceIndex, int inputChannels, int outputChannels, int frequency, uint framesPerBuffer, PortAudio.PaStreamCallbackDelegate paStreamCallback, IntPtr userData)
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		private void log(string logString)
		{
		}

		private bool errorCheck(string action, PortAudio.PaError errorCode)
		{
			return false;
		}

		private IntPtr streamOpen(int inputDevice, int inputChannels, int outputDevice, int outputChannels, int sampleRate, uint framesPerBuffer, IntPtr userData)
		{
			return (IntPtr)0;
		}

		private void streamClose(IntPtr stream)
		{
		}

		private void streamStart(IntPtr stream)
		{
		}

		private void streamStop(IntPtr stream)
		{
		}

		private void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		~Audio()
		{
		}
	}
}
