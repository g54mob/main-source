using System;
using System.Runtime.CompilerServices;

namespace NAudio.Midi
{
	public class MidiIn : IDisposable
	{
		private IntPtr hMidiIn;

		private bool disposed;

		private MidiInterop.MidiInCallback callback;

		public static int NumberOfDevices => 0;

		public event EventHandler<MidiInMessageEventArgs> MessageReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<MidiInMessageEventArgs> ErrorReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public MidiIn(int deviceNo)
		{
		}

		public void Close()
		{
		}

		public void Dispose()
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public void Reset()
		{
		}

		private void Callback(IntPtr midiInHandle, MidiInterop.MidiInMessage message, IntPtr userData, IntPtr messageParameter1, IntPtr messageParameter2)
		{
		}

		public static MidiInCapabilities DeviceInfo(int midiInDeviceNumber)
		{
			return default(MidiInCapabilities);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		~MidiIn()
		{
		}
	}
}
