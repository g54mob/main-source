using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	internal class AcmStreamHeader : IDisposable
	{
		private AcmStreamHeaderStruct streamHeader;

		private byte[] sourceBuffer;

		private GCHandle hSourceBuffer;

		private byte[] destBuffer;

		private GCHandle hDestBuffer;

		private IntPtr streamHandle;

		private bool firstTime;

		private bool disposed;

		public byte[] SourceBuffer => null;

		public byte[] DestBuffer => null;

		public AcmStreamHeader(IntPtr streamHandle, int sourceBufferLength, int destBufferLength)
		{
		}

		private void Prepare()
		{
		}

		private void Unprepare()
		{
		}

		public void Reposition()
		{
		}

		public int Convert(int bytesToConvert, out int sourceBytesConverted)
		{
			sourceBytesConverted = default(int);
			return 0;
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		~AcmStreamHeader()
		{
		}
	}
}
