using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	internal class WaveInterop
	{
		[Flags]
		public enum WaveInOutOpenFlags
		{
			CallbackNull = 0,
			CallbackFunction = 0x30000,
			CallbackEvent = 0x50000,
			CallbackWindow = 0x10000,
			CallbackThread = 0x20000
		}

		public enum WaveMessage
		{
			WaveInOpen = 958,
			WaveInClose = 959,
			WaveInData = 960,
			WaveOutClose = 956,
			WaveOutDone = 957,
			WaveOutOpen = 955
		}

		public delegate void WaveCallback(IntPtr hWaveOut, WaveMessage message, IntPtr dwInstance, WaveHeader wavhdr, IntPtr dwReserved);

		[PreserveSig]
		public static extern int mmioStringToFOURCC(string s, int flags);

		[PreserveSig]
		public static extern int waveOutGetNumDevs();

		[PreserveSig]
		public static extern MmResult waveOutPrepareHeader(IntPtr hWaveOut, WaveHeader lpWaveOutHdr, int uSize);

		[PreserveSig]
		public static extern MmResult waveOutUnprepareHeader(IntPtr hWaveOut, WaveHeader lpWaveOutHdr, int uSize);

		[PreserveSig]
		public static extern MmResult waveOutWrite(IntPtr hWaveOut, WaveHeader lpWaveOutHdr, int uSize);

		[PreserveSig]
		public static extern MmResult waveOutOpen(out IntPtr hWaveOut, IntPtr uDeviceID, WaveFormat lpFormat, WaveCallback dwCallback, IntPtr dwInstance, WaveInOutOpenFlags dwFlags);

		[PreserveSig]
		public static extern MmResult waveOutOpenWindow(out IntPtr hWaveOut, IntPtr uDeviceID, WaveFormat lpFormat, IntPtr callbackWindowHandle, IntPtr dwInstance, WaveInOutOpenFlags dwFlags);

		[PreserveSig]
		public static extern MmResult waveOutReset(IntPtr hWaveOut);

		[PreserveSig]
		public static extern MmResult waveOutClose(IntPtr hWaveOut);

		[PreserveSig]
		public static extern MmResult waveOutPause(IntPtr hWaveOut);

		[PreserveSig]
		public static extern MmResult waveOutRestart(IntPtr hWaveOut);

		[PreserveSig]
		public static extern MmResult waveOutGetPosition(IntPtr hWaveOut, out MmTime mmTime, int uSize);

		[PreserveSig]
		public static extern MmResult waveOutSetVolume(IntPtr hWaveOut, int dwVolume);

		[PreserveSig]
		public static extern MmResult waveOutGetVolume(IntPtr hWaveOut, out int dwVolume);

		[PreserveSig]
		public static extern MmResult waveOutGetDevCaps(IntPtr deviceID, out WaveOutCapabilities waveOutCaps, int waveOutCapsSize);

		[PreserveSig]
		public static extern int waveInGetNumDevs();

		[PreserveSig]
		public static extern MmResult waveInGetDevCaps(IntPtr deviceID, out WaveInCapabilities waveInCaps, int waveInCapsSize);

		[PreserveSig]
		public static extern MmResult waveInAddBuffer(IntPtr hWaveIn, WaveHeader pwh, int cbwh);

		[PreserveSig]
		public static extern MmResult waveInClose(IntPtr hWaveIn);

		[PreserveSig]
		public static extern MmResult waveInOpen(out IntPtr hWaveIn, IntPtr uDeviceID, WaveFormat lpFormat, WaveCallback dwCallback, IntPtr dwInstance, WaveInOutOpenFlags dwFlags);

		[PreserveSig]
		public static extern MmResult waveInOpenWindow(out IntPtr hWaveIn, IntPtr uDeviceID, WaveFormat lpFormat, IntPtr callbackWindowHandle, IntPtr dwInstance, WaveInOutOpenFlags dwFlags);

		[PreserveSig]
		public static extern MmResult waveInPrepareHeader(IntPtr hWaveIn, WaveHeader lpWaveInHdr, int uSize);

		[PreserveSig]
		public static extern MmResult waveInUnprepareHeader(IntPtr hWaveIn, WaveHeader lpWaveInHdr, int uSize);

		[PreserveSig]
		public static extern MmResult waveInReset(IntPtr hWaveIn);

		[PreserveSig]
		public static extern MmResult waveInStart(IntPtr hWaveIn);

		[PreserveSig]
		public static extern MmResult waveInStop(IntPtr hWaveIn);
	}
}
