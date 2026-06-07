namespace VoxelBusters.CoreLibrary
{
	public static class IOServices
	{
		public static string CombinePath(params string[] paths)
		{
			return null;
		}

		public static string GetAbsolutePath(string path)
		{
			return null;
		}

		public static string GetRelativePath(string referencePath, string path)
		{
			return null;
		}

		public static bool IsDirectory(string path)
		{
			return false;
		}

		public static bool CreateDirectory(string path, bool overwrite = false)
		{
			return false;
		}

		public static void DeleteDirectory(string path, bool recursive = true, bool throwError = false)
		{
		}

		public static void ClearDirectory(string path)
		{
		}

		public static string GetDirectoryName(string path)
		{
			return null;
		}

		public static void CopyDirectory(string root, string dest, bool recursive, string filePattern = null)
		{
		}

		public static void MoveDirectory(string source, string destination)
		{
		}

		public static bool DirectoryExists(string path)
		{
			return false;
		}

		public static bool IsSubDirectory(string parent, string path)
		{
			return false;
		}

		private static string GetUriSafePath(string path)
		{
			return null;
		}

		public static string GetUniquePath(string path)
		{
			return null;
		}

		public static string GenerateFileName(string prefix, string extension)
		{
			return null;
		}

		public static bool FileExists(string path)
		{
			return false;
		}

		public static string GetFileName(string path)
		{
			return null;
		}

		public static void CreateFile(string path, string contents)
		{
		}

		public static void CreateFile(string path, byte[] contents)
		{
		}

		public static string ReadFile(string path)
		{
			return null;
		}

		public static byte[] ReadFileData(string path)
		{
			return null;
		}

		public static void CopyFile(string source, string destination, bool overwrite = true)
		{
		}

		public static void MoveFile(string source, string destination)
		{
		}

		public static void DeleteFile(string path, bool throwError = false)
		{
		}

		public static void DeleteFileOrDirectory(string path, bool throwError = false)
		{
		}

		public static string GetFileNameWithoutExtension(string path)
		{
			return null;
		}

		public static string GetExtension(string path)
		{
			return null;
		}
	}
}
