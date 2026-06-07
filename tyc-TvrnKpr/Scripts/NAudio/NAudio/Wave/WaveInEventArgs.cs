using System;

namespace NAudio.Wave
{
	public class WaveInEventArgs : EventArgs
	{
		private byte[] buffer;

		private int bytes;

		public byte[] Buffer => null;

		public int BytesRecorded => 0;

		public WaveInEventArgs(byte[] buffer, int bytes)
		{
		}
	}
}
