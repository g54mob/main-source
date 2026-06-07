using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer FvjtluoqgvmkKoUiikShMzTMacGo;

		private readonly int sAQALDiqsJlbIiewlMVvLvVFdQf;

		private long sPyJMQXpNKUyatheSWbJobxPFlvL;

		private long mfSuHMslEIZZlZZKoVvtrkKdpcRf;

		private int OzOfdBNcPbFPmBrhQRFQtIgyTELr;

		private bool qDoiVIjevoTbIoIniNmDasnBSRlB;

		private uint RRniJYWANFgDMvzCODUeLdlpEWBs;

		private bool ERzJEkxzBGuAahMugDjOTBsjXmGB;

		public int Capacity => 0;

		public int BytesInBuffer => 0;

		public bool BufferOverrun => false;

		public int ReadPosition => 0;

		public long WritePosition => 0L;

		public NativeRingBuffer(int P_0)
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

		private void texCcicWUceomBGUHFlqgZqxvsUkA(int P_0)
		{
		}

		private void RPEWReDlSwZzsCEGqvZLIGyHfjUg(int P_0)
		{
		}

		private void aVgizAkihQiCCBKxhjdfymLPrOAd()
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
