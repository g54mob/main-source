using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Platforms
{
	public interface IAsyncFileSystem
	{
		event Action<string> OnFileSystemChange;

		event Action OnClearFileSystemChanges;

		Task<byte[]> ReadAllBytes(string path);

		Task WriteAllBytes(string path, byte[] bytes);

		Task CreateDirectory(string directory);

		Task DeleteFile(string path);

		Task<IEnumerable<FileReference>> GetFiles(string path, string ext, bool filter_empty);
	}
}
