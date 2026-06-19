using System.IO;
using IdSharp.Utils;

namespace IdSharp.Tagging.ID3v1
{
	public static class ID3v1Helper
	{
		public static IID3v1 CreateID3v1()
		{
			return new ID3v1();
		}

		public static IID3v1 CreateID3v1(string path)
		{
			Guard.ArgumentNotNullOrEmptyString(path, "path");
			IID3v1 iID3v = new ID3v1();
			iID3v.Read(path);
			return iID3v;
		}

		public static IID3v1 CreateID3v1(Stream stream)
		{
			Guard.ArgumentNotNull(stream, "stream");
			IID3v1 iID3v = new ID3v1();
			iID3v.ReadStream(stream);
			return iID3v;
		}

		public static int GetTagSize(Stream stream)
		{
			Guard.ArgumentNotNull(stream, "stream");
			if (stream.Length >= 128)
			{
				stream.Seek(-128L, SeekOrigin.End);
				byte[] array = new byte[3];
				stream.Read(array, 0, 3);
				if (array[0] == 84 && array[1] == 65 && array[2] == 71)
				{
					return 128;
				}
			}
			return 0;
		}

		public static int GetTagSize(string path)
		{
			Guard.ArgumentNotNullOrEmptyString(path, "path");
			using FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			return GetTagSize(stream);
		}

		public static bool DoesTagExist(Stream stream)
		{
			Guard.ArgumentNotNull(stream, "stream");
			return GetTagSize(stream) != 0;
		}

		public static bool DoesTagExist(string path)
		{
			Guard.ArgumentNotNull(path, "path");
			return GetTagSize(path) != 0;
		}

		public static bool RemoveTag(string path)
		{
			Guard.ArgumentNotNull(path, "path");
			using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
			{
				if (!DoesTagExist(fileStream))
				{
					return false;
				}
				fileStream.SetLength(fileStream.Length - 128);
			}
			return true;
		}
	}
}
