using System.Collections.Generic;

namespace Doozy.Engine.Utils
{
	public class FileUtils
	{
		public const bool IGNORE_META = true;

		public const string UNITY_METAFILE_EXTENSION = ".meta";

		public const string DOTSTART_HIDDEN_FILE_HEADSTRING = ".";

		public const char UNITY_FOLDER_SEPARATOR = '/';

		public static void RemakeDirectory(string localFolderPath)
		{
		}

		public static void CopyFile(string sourceFilePath, string targetFilePath)
		{
		}

		public static void CopyTemplateFile(string sourceFilePath, string targetFilePath, string srcName, string dstName)
		{
		}

		public static void DeleteFileThenDeleteFolderIfEmpty(string localTargetFilePath)
		{
		}

		public static List<string> GetAllFilePathsInFolder(string localFolderPath, bool includeHidden = false, bool includeMeta = false)
		{
			return null;
		}

		public static IEnumerable<string> GetFilePathsInFolder(string folderPath, bool includeHidden = false, bool includeMeta = false)
		{
			return null;
		}

		private static void GetFilePathsRecursively(string localFolderPath, List<string> filePaths, bool includeHidden = false, bool includeMeta = false)
		{
		}

		public static string PathCombine(params string[] paths)
		{
			return null;
		}

		private static string _PathCombine(string head, string tail)
		{
			return null;
		}

		public static string GetPathWithProjectPath(string pathUnderProjectFolder)
		{
			return null;
		}

		public static string GetPathWithAssetsPath(string pathUnderAssetsFolder)
		{
			return null;
		}

		public static string ProjectPathWithSlash()
		{
			return null;
		}

		public static bool IsMetaFile(string filePath)
		{
			return false;
		}

		public static bool ContainsHiddenFiles(string filePath)
		{
			return false;
		}

		public static void DeleteDirectory(string dirPath, bool isRecursive, bool forceDelete = true)
		{
		}

		public static void RemoveFileAttributes(string dirPath, bool isRecursive)
		{
		}

		public static string GetAbsoluteDirectoryPath(string directoryName, bool debug = false)
		{
			return null;
		}

		public static string GetRelativeDirectoryPath(string directoryName)
		{
			return null;
		}
	}
}
