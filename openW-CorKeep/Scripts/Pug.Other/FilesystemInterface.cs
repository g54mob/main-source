using System;
using System.Collections.Generic;

public interface FilesystemInterface
{
	bool IsInitialized { get; }

	bool DirectoryExists(string path);

	void CreateDirectory(string path);

	void DeleteDirectory(string path);

	void CopyDirectory(string from, string to);

	bool FileExists(string path);

	byte[] Read(string path);

	void BeginWrite();

	void EndWrite();

	void Write(string name, string path, byte[] data);

	void Delete(string path);

	IEnumerable<string> GetAllFiles();

	IEnumerable<string> GetFiles(string path);

	DateTime GetFileTime(string path);

	ulong GetRemainingBytes();
}
