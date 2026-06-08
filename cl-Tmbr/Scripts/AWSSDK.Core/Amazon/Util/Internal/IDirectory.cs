using System.IO;

namespace Amazon.Util.Internal
{
	public interface IDirectory
	{
		DirectoryInfo CreateDirectory(string path);

		string[] GetFiles(string path, string searchPattern);
	}
}
