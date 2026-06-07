using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	internal class ZipHelperStream : Stream
	{
		private bool isOwner_;

		private Stream stream_;

		public bool IsStreamOwner
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanTimeout => false;

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

		public override bool CanWrite => false;

		public ZipHelperStream(string name)
		{
		}

		public ZipHelperStream(Stream stream)
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void Close()
		{
		}

		private void WriteLocalHeader(ZipEntry entry, EntryPatchData patchData)
		{
		}

		public long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			return 0L;
		}

		public void WriteZip64EndOfCentralDirectory(long noOfEntries, long sizeEntries, long centralDirOffset)
		{
		}

		public void WriteEndOfCentralDirectory(long noOfEntries, long sizeEntries, long startOfCentralDirectory, byte[] comment)
		{
		}

		public int ReadLEShort()
		{
			return 0;
		}

		public int ReadLEInt()
		{
			return 0;
		}

		public long ReadLELong()
		{
			return 0L;
		}

		public void WriteLEShort(int value)
		{
		}

		public void WriteLEUshort(ushort value)
		{
		}

		public void WriteLEInt(int value)
		{
		}

		public void WriteLEUint(uint value)
		{
		}

		public void WriteLELong(long value)
		{
		}

		public void WriteLEUlong(ulong value)
		{
		}

		public int WriteDataDescriptor(ZipEntry entry)
		{
			return 0;
		}

		public void ReadDataDescriptor(bool zip64, DescriptorData data)
		{
		}
	}
}
