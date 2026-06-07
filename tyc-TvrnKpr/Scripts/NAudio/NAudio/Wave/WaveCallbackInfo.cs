using System;

namespace NAudio.Wave
{
	public class WaveCallbackInfo
	{
		private WaveWindow waveOutWindow;

		private WaveWindowNative waveOutWindowNative;

		public WaveCallbackStrategy Strategy { get; private set; }

		public IntPtr Handle { get; private set; }

		public static WaveCallbackInfo FunctionCallback()
		{
			return null;
		}

		public static WaveCallbackInfo NewWindow()
		{
			return null;
		}

		public static WaveCallbackInfo ExistingWindow(IntPtr handle)
		{
			return null;
		}

		private WaveCallbackInfo(WaveCallbackStrategy strategy, IntPtr handle)
		{
		}

		internal void Connect(WaveInterop.WaveCallback callback)
		{
		}

		internal MmResult WaveOutOpen(out IntPtr waveOutHandle, int deviceNumber, WaveFormat waveFormat, WaveInterop.WaveCallback callback)
		{
			waveOutHandle = default(IntPtr);
			return default(MmResult);
		}

		internal MmResult WaveInOpen(out IntPtr waveInHandle, int deviceNumber, WaveFormat waveFormat, WaveInterop.WaveCallback callback)
		{
			waveInHandle = default(IntPtr);
			return default(MmResult);
		}

		internal void Disconnect()
		{
		}
	}
}
