using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace NAudio.Wave
{
	internal class ComStream : Stream, IStream
	{
		private Stream stream;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public ComStream(Stream stream)
		{
		}

		internal ComStream(Stream stream, bool synchronizeStream)
		{
		}

		void IStream.Clone(out IStream ppstm)
		{
			ppstm = null;
		}

		void IStream.Commit(int grfCommitFlags)
		{
		}

		void IStream.CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
		{
		}

		void IStream.LockRegion(long libOffset, long cb, int dwLockType)
		{
		}

		void IStream.Read(byte[] pv, int cb, IntPtr pcbRead)
		{
		}

		void IStream.Revert()
		{
		}

		void IStream.Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
		{
		}

		void IStream.SetSize(long libNewSize)
		{
		}

		void IStream.Stat(out STATSTG pstatstg, int grfStatFlag)
		{
			pstatstg = default(STATSTG);
		}

		void IStream.UnlockRegion(long libOffset, long cb, int dwLockType)
		{
		}

		void IStream.Write(byte[] pv, int cb, IntPtr pcbWritten)
		{
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Close()
		{
		}
	}
}
