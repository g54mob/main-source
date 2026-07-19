using System.IO;

namespace UniGLTF.Zip
{
	internal class LocalFileHeader : CommonHeader
	{
		public override int FixedFieldLength => 30;

		public override int Signature => 67324752;

		public override int Length => FixedFieldLength + FileNameLength + ExtraFieldLength;

		public LocalFileHeader(byte[] bytes, int offset)
			: base(bytes, offset)
		{
		}

		public override void ReadBefore(BinaryReader r)
		{
		}

		public override void ReadAfter(BinaryReader r)
		{
		}
	}
}
