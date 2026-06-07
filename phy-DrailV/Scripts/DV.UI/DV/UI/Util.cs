using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public static class Util
	{
		public static void RunOnce(UnityEngine.Object context, [CallerMemberName] string caller = "unknown")
		{
			UnityEngine.Debug.LogError("The method '" + caller + "' (" + context?.GetType().Name + ") is intended to be called only once during the lifetime of the object", context);
		}

		public static void OpenURL(string url)
		{
			SingletonBehaviour<APlatformProvider>.Instance.OpenURL(url);
		}

		public static void OpenFolder(string folderPath)
		{
			EnsureCanOpen();
			folderPath = NormalizeSeparators(folderPath);
			if (!Directory.Exists(folderPath))
			{
				throw new InvalidOperationException("Tried to open directory '" + folderPath + "', but it doesn't exist.");
			}
			Process.Start("explorer.exe", folderPath);
			SingletonBehaviour<APlatformProvider>.Instance.OnFileOrFolderOpened();
		}

		public static void OpenFile(string filePath)
		{
			EnsureCanOpen();
			filePath = NormalizeSeparators(filePath);
			if (!File.Exists(filePath))
			{
				throw new InvalidOperationException("Tried to open file '" + filePath + "', but it doesn't exist.");
			}
			Process.Start("explorer.exe", "/select," + filePath);
			SingletonBehaviour<APlatformProvider>.Instance.OnFileOrFolderOpened();
		}

		private static string NormalizeSeparators(string path)
		{
			switch (Path.DirectorySeparatorChar)
			{
			case '\\':
				return path.Replace('/', '\\');
			case '/':
				return path.Replace('\\', '/');
			default:
				return path;
			}
		}

		private static void EnsureCanOpen()
		{
			if (SingletonBehaviour<APlatformProvider>.Instance.MustStayInGame)
			{
				throw new InvalidOperationException("Cannot open folder/file since we must stay in-game!");
			}
		}
	}
}
