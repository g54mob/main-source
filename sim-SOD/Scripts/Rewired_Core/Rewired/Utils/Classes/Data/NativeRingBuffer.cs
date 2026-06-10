using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer hCndoKQsMNpgzOdAMJcBzizUMqM;

		private readonly int rtqrHvewxklzNjBhCjGqlvHCVXC;

		private long SXGbGgzONOzsmlJCVgULhfawKkJt;

		private long VvGpBVQBzRTxgxeLrpWQSERBpLw;

		private int FwbKuvJSVdOkWhJYZLHqdSPkBKS;

		private bool rsmQiOFfsmGMHqXcvbTpXNGMCDz;

		private uint escMaIVYFwLLVrOLsaYjgniUxcCU;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public int Capacity => 0;

		public int BytesInBuffer => 0;

		public bool BufferOverrun => false;

		public int ReadPosition => 0;

		public long WritePosition => 0L;

		public NativeRingBuffer(int capacity)
		{
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			passId = default(uint);
			return (IntPtr)0;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = default(int);
			passId = default(uint);
			return 0;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = default(int);
			passId = default(uint);
			return 0;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			return 0;
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			return 0;
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			return 0;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			return 0;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			return 0;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			return 0;
		}

		public IntPtr GetPointerFromReadPosition(int offset)
		{
			return (IntPtr)0;
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			return 0;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			return false;
		}

		public void CopyFrom(NativeRingBuffer other)
		{
		}

		public void Reset()
		{
		}

		private void rgiPIisFxQouwsUfbvvSuDzhQDL(int P_0)
		{
		}

		private void XYieMDhJwkdgIZhbvwMgffwgWCKG(int P_0)
		{
		}

		private void TckEGLVNRlmGWpRbuNHzOANxdsDc()
		{
		}

		public void Dispose()
		{
		}

		~NativeRingBuffer()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
