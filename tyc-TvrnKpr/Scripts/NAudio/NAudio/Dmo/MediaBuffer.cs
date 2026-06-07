using System;

namespace NAudio.Dmo
{
	public class MediaBuffer : IMediaBuffer, IDisposable
	{
		private IntPtr buffer;

		private int length;

		private readonly int maxLength;

		public int Length
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public MediaBuffer(int maxLength)
		{
		}

		public void Dispose()
		{
		}

		~MediaBuffer()
		{
		}

		int IMediaBuffer.SetLength(int length)
		{
			return 0;
		}

		int IMediaBuffer.GetMaxLength(out int maxLength)
		{
			maxLength = default(int);
			return 0;
		}

		int IMediaBuffer.GetBufferAndLength(IntPtr bufferPointerPointer, IntPtr validDataLengthPointer)
		{
			return 0;
		}

		public void LoadData(byte[] data, int bytes)
		{
		}

		public void RetrieveData(byte[] data, int offset)
		{
		}
	}
}
