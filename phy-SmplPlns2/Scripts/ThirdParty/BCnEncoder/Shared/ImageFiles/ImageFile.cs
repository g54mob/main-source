using System.IO;
using System.Linq;
using System.Text;

namespace BCnEncoder.Shared.ImageFiles
{
	public static class ImageFile
	{
		private static readonly byte[] ktx1Identifier = new byte[12]
		{
			171, 75, 84, 88, 32, 49, 49, 187, 13, 10,
			26, 10
		};

		public static ImageFileFormat DetermineImageFormat(Stream stream)
		{
			if (IsDds(stream))
			{
				return ImageFileFormat.Dds;
			}
			if (IsKtx(stream))
			{
				return ImageFileFormat.Ktx;
			}
			return ImageFileFormat.Unknown;
		}

		private static bool IsDds(Stream stream)
		{
			using BinaryReader binaryReader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);
			uint num = binaryReader.ReadUInt32();
			stream.Position -= 4L;
			return num == 542327876;
		}

		private static bool IsKtx(Stream stream)
		{
			using BinaryReader binaryReader = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true);
			byte[] first = binaryReader.ReadBytes(12);
			stream.Position -= 12L;
			return first.SequenceEqual(ktx1Identifier);
		}
	}
}
