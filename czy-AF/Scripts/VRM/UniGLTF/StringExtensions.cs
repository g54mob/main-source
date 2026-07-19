using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace UniGLTF
{
	public static class StringExtensions
	{
		private static string m_unityBasePath;

		private static readonly char[] EscapeChars = new char[9] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

		public static string UnityBasePath
		{
			get
			{
				if (m_unityBasePath == null)
				{
					m_unityBasePath = Path.GetFullPath(Application.dataPath + "/..").Replace("\\", "/");
				}
				return m_unityBasePath;
			}
		}

		public static string ToLowerCamelCase(this string lower)
		{
			return lower.Substring(0, 1).ToLower() + lower.Substring(1);
		}

		public static string ToUpperCamelCase(this string lower)
		{
			return lower.Substring(0, 1).ToUpper() + lower.Substring(1);
		}

		public static string AssetPathToFullPath(this string path)
		{
			return UnityBasePath + "/" + path;
		}

		public static bool StartsWithUnityAssetPath(this string path)
		{
			return path.Replace("\\", "/").StartsWith(UnityBasePath + "/Assets");
		}

		public static string ToUnityRelativePath(this string path)
		{
			path = path.Replace("\\", "/");
			if (path.StartsWith(UnityBasePath))
			{
				return path.Substring(UnityBasePath.Length + 1);
			}
			return path;
		}

		public static string EscapeFilePath(this string path)
		{
			path = Regex.Replace(path, "[\\u0000-\\u001F\\u007F]", "+");
			char[] escapeChars = EscapeChars;
			foreach (char oldChar in escapeChars)
			{
				path = path.Replace(oldChar, '+');
			}
			return path;
		}
	}
}
