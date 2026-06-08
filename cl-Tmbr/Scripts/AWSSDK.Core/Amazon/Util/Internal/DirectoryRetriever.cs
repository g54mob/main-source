using System.IO;

namespace Amazon.Util.Internal
{
	public class DirectoryRetriever : IDirectory
	{
		public DirectoryInfo CreateDirectory(string path)
		{
			return Directory.CreateDirectory(path);
		}

		public string[] GetFiles(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern);
		}
	}
}
