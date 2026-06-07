using System;

namespace NAudio.Midi
{
	public class MidiOut : IDisposable
	{
		private IntPtr hMidiOut;

		private bool disposed;

		private MidiInterop.MidiOutCallback callback;

		public static int NumberOfDevices => 0;

		public int Volume
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static MidiOutCapabilities DeviceInfo(int midiOutDeviceNumber)
		{
			return default(MidiOutCapabilities);
		}

		public MidiOut(int deviceNo)
		{
		}

		public void Close()
		{
		}

		public void Dispose()
		{
		}

		public void Reset()
		{
		}

		public void SendDriverMessage(int message, int param1, int param2)
		{
		}

		public void Send(int message)
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private void Callback(IntPtr midiInHandle, MidiInterop.MidiOutMessage message, IntPtr userData, IntPtr messageParameter1, IntPtr messageParameter2)
		{
		}

		public void SendBuffer(byte[] byteBuffer)
		{
		}

		~MidiOut()
		{
		}
	}
}
