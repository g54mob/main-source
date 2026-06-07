using System.Collections.Generic;
using System.IO;

namespace Gh
{
	public interface IStorageProvider
	{
		bool DoesFileExist(string relativeFilePath);

		IEnumerable<string> GetFilesInFolder(string relativeFilePath, bool includeSubFolders);

		string WriteFileSync(string relativeFilePath, Stream streamToWrite);

		Stream ReadFileSync(string relativeFilePath);

		void DeleteFile(string relativeFilePath);

		void DeleteFolder(string relativePath);
	}
}
