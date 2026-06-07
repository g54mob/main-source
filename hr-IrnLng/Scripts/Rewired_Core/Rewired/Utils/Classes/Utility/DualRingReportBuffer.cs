using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int rijFcvcuNuYYRJPEuwvSPEbGeRTw;

		private readonly int rPWFQLuVOujTRshHCSznCAdDHbI;

		private readonly int aQFEYMxCBbxrgNzMJHqnhhWacJsk;

		private NativeRingBuffer ycJGxwIPoAiqvjZPmYYDAEEbmBQ;

		private NativeRingBuffer HXmvGcSqIBclXBhETbsYnxDFmax;

		private byte[] BVzHZgqJolPuLPZOHqIdLqdLiso;

		private byte[] YuUDNpcmUbKfXoKBDzkUGEdFikA;

		private int rwVtMdoGgJcjLdaAxUOXOqSUbyhD;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public int BufferLength => rijFcvcuNuYYRJPEuwvSPEbGeRTw;

		public int BytesInBuffer => HXmvGcSqIBclXBhETbsYnxDFmax.BytesInBuffer;

		public int EntriesInBuffer => HXmvGcSqIBclXBhETbsYnxDFmax.BytesInBuffer / rPWFQLuVOujTRshHCSznCAdDHbI;

		public byte[] ReadBuffer => YuUDNpcmUbKfXoKBDzkUGEdFikA;

		public int LastNumBytesRead => rwVtMdoGgJcjLdaAxUOXOqSUbyhD;

		public DualRingReportBuffer(int entryByteLength, int entryCapacity)
		{
			if (entryByteLength <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (entryCapacity < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			rPWFQLuVOujTRshHCSznCAdDHbI = entryByteLength;
			aQFEYMxCBbxrgNzMJHqnhhWacJsk = entryCapacity;
			rijFcvcuNuYYRJPEuwvSPEbGeRTw = entryByteLength * entryCapacity;
			ycJGxwIPoAiqvjZPmYYDAEEbmBQ = new NativeRingBuffer(rijFcvcuNuYYRJPEuwvSPEbGeRTw);
			HXmvGcSqIBclXBhETbsYnxDFmax = new NativeRingBuffer(rijFcvcuNuYYRJPEuwvSPEbGeRTw);
			BVzHZgqJolPuLPZOHqIdLqdLiso = new byte[entryByteLength];
			YuUDNpcmUbKfXoKBDzkUGEdFikA = new byte[entryByteLength];
		}

		public int StartRead()
		{
			oulbBMnBJHRTZTVibPJPbSvVRUQ();
			return HXmvGcSqIBclXBhETbsYnxDFmax.BytesInBuffer;
		}

		public int Read()
		{
			int result = 0;
			lock (HXmvGcSqIBclXBhETbsYnxDFmax)
			{
				result = HXmvGcSqIBclXBhETbsYnxDFmax.Read(YuUDNpcmUbKfXoKBDzkUGEdFikA, rPWFQLuVOujTRshHCSznCAdDHbI);
			}
			rwVtMdoGgJcjLdaAxUOXOqSUbyhD = result;
			return result;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (numBytesToRead < 0 || numBytesToRead > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int result = 0;
			lock (HXmvGcSqIBclXBhETbsYnxDFmax)
			{
				result = HXmvGcSqIBclXBhETbsYnxDFmax.Read(buffer, numBytesToRead);
			}
			rwVtMdoGgJcjLdaAxUOXOqSUbyhD = result;
			return result;
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			if (numBytesToRead < 0 || numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int result = 0;
			lock (HXmvGcSqIBclXBhETbsYnxDFmax)
			{
				result = HXmvGcSqIBclXBhETbsYnxDFmax.Read(buffer, bufferLength, bufferLength);
			}
			rwVtMdoGgJcjLdaAxUOXOqSUbyhD = result;
			return result;
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (numBytesToWrite < 0 || numBytesToWrite > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (ycJGxwIPoAiqvjZPmYYDAEEbmBQ)
			{
				return ycJGxwIPoAiqvjZPmYYDAEEbmBQ.Write(buffer, numBytesToWrite);
			}
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			if (numBytesToWrite < 0 || numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (ycJGxwIPoAiqvjZPmYYDAEEbmBQ)
			{
				return ycJGxwIPoAiqvjZPmYYDAEEbmBQ.Write(buffer, bufferLength, numBytesToWrite);
			}
		}

		public void Clear()
		{
			lock (ycJGxwIPoAiqvjZPmYYDAEEbmBQ)
			{
				lock (HXmvGcSqIBclXBhETbsYnxDFmax)
				{
					HXmvGcSqIBclXBhETbsYnxDFmax.Reset();
					ycJGxwIPoAiqvjZPmYYDAEEbmBQ.Reset();
				}
			}
		}

		private void oulbBMnBJHRTZTVibPJPbSvVRUQ()
		{
			lock (ycJGxwIPoAiqvjZPmYYDAEEbmBQ)
			{
				lock (HXmvGcSqIBclXBhETbsYnxDFmax)
				{
					MiscTools.Swap(ref ycJGxwIPoAiqvjZPmYYDAEEbmBQ, ref HXmvGcSqIBclXBhETbsYnxDFmax);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~DualRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
