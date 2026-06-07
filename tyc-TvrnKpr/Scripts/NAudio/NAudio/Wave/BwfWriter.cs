using System;
using System.IO;

namespace NAudio.Wave
{
	public class BwfWriter : IDisposable
	{
		private readonly WaveFormat format;

		private readonly BinaryWriter writer;

		private readonly long dataChunkSizePosition;

		private long dataLength;

		private bool isDisposed;

		public BwfWriter(string filename, WaveFormat format, BextChunkInfo bextChunkInfo)
		{
		}

		public void Write(byte[] buffer, int offset, int count)
		{
		}

		public void Flush()
		{
		}

		private void FixUpChunkSizes(bool restorePosition)
		{
		}

		public void Dispose()
		{
		}

		private static byte[] GetAsBytes(string message, int byteSize)
		{
			return null;
		}
	}
}
