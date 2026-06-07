using System;
using System.Collections.Generic;

public interface IiCloudCache
{
	bool HasFile(string filepath);

	byte[] ReadFile(string filepath);

	bool WriteFile(string filepath, byte[] data);

	bool HasSpaceToWriteFile(string filepath, int dataLength, out int bytesNeededToDelete);

	IEnumerable<string> GetFilenamesInDirectory(string directory);

	IEnumerable<string> GetDirectoriesInDirectory(string directory);

	int GetFileSize(string filepath);

	bool MoveFile(string filepath, string directory);

	bool DeleteFile(string filepath);

	void CopyNewFilesInDirectory(string sourceDirectory, string destinationDirectory);

	DateTime GetFileModifiedTime(string filepath);
}
