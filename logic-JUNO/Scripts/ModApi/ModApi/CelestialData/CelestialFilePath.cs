using System;
using System.IO;

namespace ModApi.CelestialData
{
	public class CelestialFilePath
	{
		private static string _rootPathString;

		private static Uri _rootPathUri;

		private string _fullPath;

		private string _relativePath;

		public string FileName
		{
			get
			{
				string relativePath = RelativePath;
				return relativePath.Substring(relativePath.LastIndexOf('/') + 1);
			}
		}

		public string FullPath => _fullPath ?? (_fullPath = GetFullFilePath(_relativePath ?? throw new InvalidOperationException()));

		public bool InGameData => RelativePath.StartsWith("GameData/");

		public bool InUserData => RelativePath.StartsWith("UserData/");

		public string RelativePath => _relativePath ?? (_relativePath = GetRelativeFilePath(_fullPath ?? throw new InvalidOperationException()));

		static CelestialFilePath()
		{
			string text = Game.PersistentDataPath;
			if (!text.EndsWith("/") && !text.EndsWith("\\"))
			{
				string text2 = text;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				text = text2 + directorySeparatorChar;
			}
			_rootPathString = text;
			_rootPathUri = new Uri(_rootPathString);
		}

		public CelestialFilePath(string path, bool isRelative)
		{
			if (path == null)
			{
				throw new ArgumentNullException(path);
			}
			if (isRelative)
			{
				_fullPath = null;
				_relativePath = path;
			}
			else
			{
				_fullPath = path;
				_relativePath = null;
			}
		}

		public static CelestialFilePath FromFullPath(string fullPath)
		{
			if (fullPath != null)
			{
				return new CelestialFilePath(fullPath, isRelative: false);
			}
			return null;
		}

		public static CelestialFilePath FromRelativePath(string relativePath)
		{
			if (relativePath != null)
			{
				return new CelestialFilePath(relativePath, isRelative: true);
			}
			return null;
		}

		public static string GetFullFilePath(string relativeFilePath)
		{
			if (!string.IsNullOrEmpty(relativeFilePath))
			{
				return Path.Combine(_rootPathString, relativeFilePath.Replace('/', Path.DirectorySeparatorChar));
			}
			return relativeFilePath;
		}

		public static string GetRelativeFilePath(string fullFilePath)
		{
			if (string.IsNullOrEmpty(fullFilePath))
			{
				return fullFilePath;
			}
			Uri uri = new Uri(fullFilePath);
			return Uri.UnescapeDataString(_rootPathUri.MakeRelativeUri(uri).ToString()).Replace(Path.DirectorySeparatorChar, '/').Replace(Path.AltDirectorySeparatorChar, '/');
		}
	}
}
