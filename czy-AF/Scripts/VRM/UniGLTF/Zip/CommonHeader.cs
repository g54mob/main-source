using System;
using System.IO;
using System.Text;

namespace UniGLTF.Zip
{
	internal abstract class CommonHeader
	{
		public Encoding Encoding = Encoding.UTF8;

		public byte[] Bytes;

		public int Offset;

		public ushort VersionNeededToExtract;

		public ushort GeneralPurposeBitFlag;

		public CompressionMethod CompressionMethod;

		public ushort FileLastModificationTime;

		public ushort FileLastModificationDate;

		public int CRC32;

		public int CompressedSize;

		public int UncompressedSize;

		public ushort FileNameLength;

		public ushort ExtraFieldLength;

		public abstract int Signature { get; }

		public abstract int FixedFieldLength { get; }

		public abstract int Length { get; }

		public string FileName => Encoding.GetString(Bytes, Offset + FixedFieldLength, FileNameLength);

		public ArraySegment<byte> ExtraField => new ArraySegment<byte>(Bytes, Offset + FixedFieldLength + FileNameLength, ExtraFieldLength);

		protected CommonHeader(byte[] bytes, int offset)
		{
			int num = BitConverter.ToInt32(bytes, offset);
			if (num != Signature)
			{
				throw new ZipParseException("invalid central directory file signature: " + num);
			}
			Bytes = bytes;
			Offset = offset;
			int num2 = offset + 4;
			using MemoryStream input = new MemoryStream(bytes, num2, bytes.Length - num2, writable: false);
			using BinaryReader r = new BinaryReader(input);
			ReadBefore(r);
			Read(r);
			ReadAfter(r);
		}

		public override string ToString()
		{
			return $"<file {FileName}({CompressedSize}/{UncompressedSize} {CompressionMethod})>";
		}

		public abstract void ReadBefore(BinaryReader r);

		public void Read(BinaryReader r)
		{
			VersionNeededToExtract = r.ReadUInt16();
			GeneralPurposeBitFlag = r.ReadUInt16();
			CompressionMethod = (CompressionMethod)r.ReadUInt16();
			FileLastModificationTime = r.ReadUInt16();
			FileLastModificationDate = r.ReadUInt16();
			CRC32 = r.ReadInt32();
			CompressedSize = r.ReadInt32();
			UncompressedSize = r.ReadInt32();
			FileNameLength = r.ReadUInt16();
			ExtraFieldLength = r.ReadUInt16();
		}

		public abstract void ReadAfter(BinaryReader r);
	}
}
