using System;
using System.Collections.Generic;
using System.IO;

namespace DV.UserManagement.Storage
{
	public interface IStorageProvider
	{
		bool FileExists(string path);

		bool DirectoryExists(string path);

		bool DeleteFile(string path);

		bool DeleteDirectory(string path);

		bool CreateDirectory(string path);

		List<string> ListFiles(string path, string searchPattern = "");

		List<string> ListDirectories(string path, string searchPattern = "");

		byte[] ReadFileToBytes(string path, byte[] key = null);

		string ReadFileToString(string path, byte[] key = null);

		IStreamProvider OpenFileForReading(string path);

		void WriteFile(string path, string data, byte[] key = null);

		void WriteFile(string path, byte[] data, byte[] key = null);

		void CopyFile(string sourcePath, string destinationPath);

		Stream OpenFileForWriting(string path);

		string SanitizeName(string name);

		string GetFilesystemPath(string internalPath);

		DateTime GetLastWriteTime(string path);

		string GetDirectoryName(string path);

		byte[] EncryptData(byte[] data, byte[] key);

		byte[] DecryptData(byte[] data, byte[] key);
	}
}
