using System;
using System.Collections.Generic;

namespace PugMod
{
	public interface IConfigFilesystem
	{
		bool DirectoryExists(string path);

		void CreateDirectory(string path);

		void DeleteDirectory(string path);

		void CopyDirectory(string from, string to);

		bool FileExists(string path);

		byte[] Read(string path);

		void Write(string path, byte[] data);

		void Delete(string path);

		IEnumerable<string> GetAllFiles();

		IEnumerable<string> GetFiles(string path);

		DateTime GetFileTime(string path);
	}
}
