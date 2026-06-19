using System.IO;

namespace IdSharp.Tagging.ID3v2
{
	public static class ID3v2Helper
	{
		public static IID3v2 CreateID3v2()
		{
			return new ID3v2();
		}

		public static IID3v2 CreateID3v2(string path)
		{
			IID3v2 iID3v = new ID3v2();
			iID3v.Read(path);
			return iID3v;
		}

		public static IID3v2 CreateID3v2(Stream stream)
		{
			IID3v2 iID3v = new ID3v2();
			iID3v.ReadStream(stream);
			return iID3v;
		}

		public static int GetTagSize(Stream stream)
		{
			if (stream.Length >= 16)
			{
				stream.Position = 0L;
				byte[] array = Utils.Read(stream, 3);
				if (array[0] != 73 || array[1] != 68 || array[2] != 51)
				{
					return 0;
				}
				IID3v2Header iID3v2Header = new ID3v2Header(stream, readIdentifier: false);
				int tagSize = iID3v2Header.TagSize;
				if (tagSize != 0)
				{
					return tagSize + 10 + (iID3v2Header.IsFooterPresent ? 10 : 0);
				}
				return 0;
			}
			return 0;
		}

		public static int GetTagSize(string path)
		{
			using FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			return GetTagSize(stream);
		}

		public static bool DoesTagExist(Stream stream)
		{
			return GetTagSize(stream) != 0;
		}

		public static bool DoesTagExist(string path)
		{
			return GetTagSize(path) != 0;
		}

		public static bool RemoveTag(string path)
		{
			int tagSize = GetTagSize(path);
			if (tagSize > 0)
			{
				Utils.ReplaceBytes(path, tagSize, new byte[0]);
				return true;
			}
			return false;
		}
	}
}
