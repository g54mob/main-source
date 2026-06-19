using System.IO;

namespace Sentry.Internal
{
	internal class ReadOnlyFileSystem : FileSystemBase
	{
		public override bool CreateDirectory(string path)
		{
			return false;
		}

		public override bool DeleteDirectory(string path, bool recursive = false)
		{
			return false;
		}

		public override bool CreateFileForWriting(string path, out Stream fileStream)
		{
			fileStream = Stream.Null;
			return false;
		}

		public override bool WriteAllTextToFile(string path, string contents)
		{
			return false;
		}

		public override bool MoveFile(string sourceFileName, string destFileName, bool overwrite = false)
		{
			return false;
		}

		public override bool DeleteFile(string path)
		{
			return false;
		}
	}
}
