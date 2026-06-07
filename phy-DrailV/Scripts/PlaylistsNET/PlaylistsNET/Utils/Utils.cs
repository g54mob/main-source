using System;
using System.IO;

namespace PlaylistsNET.Utils
{
	public class Utils
	{
		public static string MakeAbsolutePath(string folderPath, string filePath)
		{
			if (string.IsNullOrWhiteSpace(filePath))
			{
				return filePath;
			}
			if (IsStream(filePath))
			{
				return filePath;
			}
			if (IsAbsolutePath(filePath))
			{
				return filePath;
			}
			if (filePath[0] == '/' || filePath[0] == '\\')
			{
				filePath = filePath.Substring(1);
			}
			try
			{
				if (IsStream(folderPath))
				{
					if (!folderPath.EndsWith("/"))
					{
						folderPath += "/";
					}
					return Path.Combine(folderPath, filePath);
				}
				return Path.GetFullPath(Path.Combine(folderPath, filePath));
			}
			catch (ArgumentException)
			{
				return filePath;
			}
			catch (PathTooLongException)
			{
				return filePath;
			}
			catch (NotSupportedException)
			{
				return filePath;
			}
		}

		public static string MakeRelativePath(string folderPath, string fileAbsolutePath)
		{
			if (string.IsNullOrEmpty(folderPath))
			{
				throw new ArgumentNullException("folderPath");
			}
			if (string.IsNullOrEmpty(fileAbsolutePath))
			{
				throw new ArgumentNullException("filePath");
			}
			if (!folderPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
			{
				folderPath += Path.DirectorySeparatorChar;
			}
			Uri uri = new Uri(folderPath);
			Uri uri2 = new Uri(fileAbsolutePath);
			if (uri.Scheme != uri2.Scheme)
			{
				return fileAbsolutePath;
			}
			string text = Uri.UnescapeDataString(uri.MakeRelativeUri(uri2).ToString());
			if (uri2.Scheme.Equals("file", StringComparison.CurrentCultureIgnoreCase))
			{
				text = text.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}
			return text;
		}

		public static bool IsAbsolutePath(string path)
		{
			if (path.Length > 3 && path[1] == ':' && (path[2] == '\\' || path[2] == '/'))
			{
				return true;
			}
			return false;
		}

		public static bool IsRelativePath(string path)
		{
			if (path.StartsWith("/") || path.StartsWith("./") || path.StartsWith("../") || path.StartsWith("\\") || path.StartsWith(".\\") || path.StartsWith("..\\"))
			{
				return true;
			}
			return false;
		}

		public static bool IsStream(string path)
		{
			return path.Contains("://");
		}

		public static string UnEscape(string content)
		{
			if (content == null)
			{
				return content;
			}
			return content.Replace("&amp;", "&").Replace("&apos;", "'").Replace("&quot;", "\"")
				.Replace("&gt;", ">")
				.Replace("&lt;", "<");
		}

		public static string Escape(string content)
		{
			return content?.Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;")
				.Replace(">", "&gt;")
				.Replace("<", "&lt;");
		}
	}
}
