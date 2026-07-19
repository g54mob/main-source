using System.IO;

namespace UniGLTF.Zip
{
	internal class CentralDirectoryFileHeader : CommonHeader
	{
		public ushort VersionMadeBy;

		public ushort FileCommentLength;

		public ushort DiskNumberWhereFileStarts;

		public ushort InternalFileAttributes;

		public int ExternalFileAttributes;

		public int RelativeOffsetOfLocalFileHeader;

		public override int Signature => 33639248;

		public override int FixedFieldLength => 46;

		public string FileComment => Encoding.GetString(Bytes, Offset + 46 + FileNameLength + ExtraFieldLength, FileCommentLength);

		public override int Length => FixedFieldLength + FileNameLength + ExtraFieldLength + FileCommentLength;

		public CentralDirectoryFileHeader(byte[] bytes, int offset)
			: base(bytes, offset)
		{
		}

		public override void ReadBefore(BinaryReader r)
		{
			VersionMadeBy = r.ReadUInt16();
		}

		public override void ReadAfter(BinaryReader r)
		{
			FileCommentLength = r.ReadUInt16();
			DiskNumberWhereFileStarts = r.ReadUInt16();
			InternalFileAttributes = r.ReadUInt16();
			ExternalFileAttributes = r.ReadInt32();
			RelativeOffsetOfLocalFileHeader = r.ReadInt32();
		}
	}
}
