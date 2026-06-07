using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Jundroo.Common.Platform;
using UnityEngine;
using UnityEngine.Networking;

namespace Jundroo.Common.Utils
{
	public static class FileIOUtility
	{
		public enum ExceptionHandling
		{
			Throw = 0,
			Log = 1,
			Ignore = 2
		}

		private static readonly char[] _invalidPathChars = Path.GetInvalidPathChars();

		private static readonly Regex _validFileOrDirectoryNameRegex = new Regex("^[\\p{L}\\p{N}\\p{M}._()\\[\\]{}!@#$%^&+=,;'\\- ]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		private static readonly HashSet<string> _windowsReservedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6",
			"COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7",
			"LPT8", "LPT9"
		};

		public static string CombinePaths(params string[] paths)
		{
			return Path.Combine(paths).Replace('\\', '/');
		}

		public static string CombinePaths(string path1, string path2)
		{
			return Path.Combine(path1, path2).Replace('\\', '/');
		}

		public static string CombinePaths(string path1, string path2, string path3)
		{
			return Path.Combine(path1, path2, path3).Replace('\\', '/');
		}

		public static string CombinePaths(string path1, string path2, string path3, string path4)
		{
			return Path.Combine(path1, path2, path3, path4).Replace('\\', '/');
		}

		public static void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool copySubDirectories, bool overwriteFiles)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirectoryPath);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException("Source directory does not exist: " + sourceDirectoryPath);
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			if (!Directory.Exists(destinationDirectoryPath))
			{
				Directory.CreateDirectory(destinationDirectoryPath);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string destFileName = Path.Combine(destinationDirectoryPath, fileInfo.Name);
				fileInfo.CopyTo(destFileName, overwriteFiles);
			}
			if (copySubDirectories)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					string destinationDirectoryPath2 = Path.Combine(destinationDirectoryPath, directoryInfo2.Name);
					CopyDirectory(directoryInfo2.FullName, destinationDirectoryPath2, copySubDirectories, overwriteFiles);
				}
			}
		}

		public static void DeleteDirectory(string path)
		{
			string[] directories = Directory.GetDirectories(path);
			for (int i = 0; i < directories.Length; i++)
			{
				DeleteDirectory(directories[i]);
			}
			try
			{
				Directory.Delete(path, recursive: true);
			}
			catch (IOException)
			{
				Directory.Delete(path, recursive: true);
			}
			catch (UnauthorizedAccessException)
			{
				Directory.Delete(path, recursive: true);
			}
		}

		public static void DeleteDirectoryFromPersistentData(string path, bool recursive = false)
		{
			if (path.Contains(Project.PersistentDataPath))
			{
				Directory.Delete(path, recursive);
				return;
			}
			throw new ArgumentException("Attempted to delete directory outside of persistent data path: " + path);
		}

		public static bool IsValidDirectoryOrFileName(string name, out string validationMessage)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				validationMessage = "Name cannot be null, empty, or whitespace.";
				return false;
			}
			if (name.IndexOf('/') >= 0 || name.IndexOf('\\') >= 0)
			{
				validationMessage = "Name cannot contain path separator characters.";
				return false;
			}
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i] <= '\u001f')
				{
					validationMessage = "Name cannot contain ASCII control characters.";
					return false;
				}
			}
			if (name.EndsWith(" ", StringComparison.Ordinal) || name.EndsWith(".", StringComparison.Ordinal))
			{
				validationMessage = "Name cannot end with a space or dot.";
				return false;
			}
			if (!_validFileOrDirectoryNameRegex.IsMatch(name))
			{
				validationMessage = "Name contains invalid characters.";
				return false;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);
			if (_windowsReservedNames.Contains(fileNameWithoutExtension))
			{
				validationMessage = "Name cannot be a reserved device name: " + fileNameWithoutExtension;
				return false;
			}
			validationMessage = null;
			return true;
		}

		public static bool IsValidPath(string path, out string validationMessage)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				validationMessage = "Path cannot be null, empty, or whitespace.";
				return false;
			}
			path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			string[] array = path.Split(Path.DirectorySeparatorChar);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (!string.IsNullOrEmpty(text) && (i != 0 || text.Length != 2 || !char.IsLetter(text[0]) || text[1] != ':') && !IsValidDirectoryOrFileName(text, out validationMessage))
				{
					return false;
				}
			}
			validationMessage = null;
			return true;
		}

		public static void MoveFile(string sourcePath, string destinationPath)
		{
			TryDeleteFile(destinationPath);
			File.Move(sourcePath, destinationPath);
		}

		public static string NormalizePath(string path, bool preserveCasing)
		{
			string text = Path.GetFullPath(new Uri(path).LocalPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			if (!preserveCasing)
			{
				return text.ToLowerInvariant();
			}
			return text;
		}

		public static byte[] ReadStreamingAssetsFileAsBytes(string path)
		{
			return ReadStreamingAssetsFile<byte[]>(path);
		}

		public static string ReadStreamingAssetsFileAsText(string path)
		{
			return ReadStreamingAssetsFile<string>(path);
		}

		public static string RemoveFileExtension(string fileName)
		{
			int num = fileName.LastIndexOf('.');
			if (num > 0)
			{
				fileName = fileName.Remove(num);
			}
			return fileName;
		}

		public static string ScrubFileName(string name, string allowedCharacters = "!%()_-=+[{]};',. ")
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(name))
			{
				while (name.Contains(".."))
				{
					name = name.Replace("..", string.Empty);
				}
				string text2 = name;
				for (int i = 0; i < text2.Length; i++)
				{
					char c = text2[i];
					text = ((!char.IsLetterOrDigit(c) && !allowedCharacters.Contains(c)) ? (text + " ") : (text + c));
				}
			}
			return text.Trim();
		}

		public static bool TryDeleteFile(string filePath, ExceptionHandling exceptionHandling = ExceptionHandling.Ignore)
		{
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
					return true;
				}
			}
			catch (Exception exception)
			{
				switch (exceptionHandling)
				{
				case ExceptionHandling.Throw:
					throw;
				case ExceptionHandling.Log:
					Debug.LogException(exception);
					break;
				}
			}
			return false;
		}

		public static bool TryMoveFile(string sourcePath, string destinationPath, ExceptionHandling exceptionHandling = ExceptionHandling.Ignore)
		{
			try
			{
				if (File.Exists(sourcePath))
				{
					TryDeleteFile(destinationPath, exceptionHandling);
					File.Move(sourcePath, destinationPath);
					return true;
				}
			}
			catch (Exception exception)
			{
				switch (exceptionHandling)
				{
				case ExceptionHandling.Throw:
					throw;
				case ExceptionHandling.Log:
					Debug.LogException(exception);
					break;
				}
			}
			return false;
		}

		private static T ReadStreamingAssetsFile<T>(string path)
		{
			string text = Path.Combine(Application.streamingAssetsPath, path);
			DownloadHandler downloadHandler = null;
			if (Device.IsAndroidBuild)
			{
				UnityWebRequest unityWebRequest = UnityWebRequest.Get(text);
				unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
				UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = unityWebRequest.SendWebRequest();
				while (!unityWebRequestAsyncOperation.isDone)
				{
					Thread.Sleep(10);
				}
				if (unityWebRequest.result != UnityWebRequest.Result.Success)
				{
					throw new Exception("An error occurred reading streaming assets file '" + text + "': " + unityWebRequest.error);
				}
				downloadHandler = unityWebRequest.downloadHandler;
			}
			if (typeof(T) == typeof(string))
			{
				return (T)(object)((downloadHandler == null) ? File.ReadAllText(text) : downloadHandler.text);
			}
			if (typeof(T) == typeof(byte[]))
			{
				return (T)(object)((downloadHandler == null) ? File.ReadAllBytes(text) : downloadHandler.data);
			}
			throw new NotSupportedException();
		}
	}
}
