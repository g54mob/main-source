using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Namotion.Reflection.Infrastructure
{
	internal static class DynamicApis
	{
		public static bool SupportsFileApis => true;

		public static bool SupportsPathApis => true;

		public static bool SupportsDirectoryApis => true;

		public static bool SupportsXPathApis => true;

		public static string DirectoryGetCurrentDirectory()
		{
			return Directory.GetCurrentDirectory();
		}

		public static bool FileExists(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return false;
			}
			return File.Exists(filePath);
		}

		public static string FileReadAllText(string filePath)
		{
			return File.ReadAllText(filePath);
		}

		public static bool DirectoryExists(string directoryPath)
		{
			if (string.IsNullOrEmpty(directoryPath))
			{
				return false;
			}
			return Directory.Exists(directoryPath);
		}

		public static string[] DirectoryGetAllFiles(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
		}

		public static string[] DirectoryGetFiles(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern);
		}

		public static string PathCombine(string path1, string path2)
		{
			return Path.Combine(path1, path2);
		}

		public static string PathGetDirectoryName(string filePath)
		{
			return Path.GetDirectoryName(filePath);
		}

		public static object? XPathEvaluate(XDocument document, string path)
		{
			return document.XPathEvaluate(path);
		}
	}
}
