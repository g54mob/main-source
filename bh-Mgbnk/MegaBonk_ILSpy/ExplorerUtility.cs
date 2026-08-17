using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ExplorerUtility : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static EventHandler _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COpenFileInExplorerNew_003Eb__2_0(object sender, EventArgs args)
		{
			Debug.Log("Explorer closed");
		}
	}

	public static void OpenInFileExplorer(string filePath)
	{
		if (!string.IsNullOrEmpty(filePath))
		{
			bool flag = string.IsNullOrWhiteSpace(filePath);
			string filePath2 = filePath;
			if (!flag)
			{
				string text = filePath.Replace('/', Path.DirectorySeparatorChar);
				string text2 = text.Replace('\\', Path.DirectorySeparatorChar);
				filePath2 = text2;
			}
			OpenFileInExplorerNew(filePath2);
		}
	}

	private static string NormalizeFilePath(string filePath)
	{
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return filePath;
		}
		if (filePath != null)
		{
			string text = filePath.Replace('/', Path.DirectorySeparatorChar);
			if (text != null)
			{
				return text.Replace('\\', Path.DirectorySeparatorChar);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static void OpenFileInExplorerNew(string filePath)
	{
		string arguments = "/select,\"" + filePath + "\"";
		Process process = new Process();
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		processStartInfo.fileName = "explorer.exe";
		processStartInfo.arguments = arguments;
		processStartInfo.useShellExecute = true;
		process.StartInfo = processStartInfo;
		process.EnableRaisingEvents = true;
		EventHandler value = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			value = (_003C_003Ec._003C_003E9__2_0 = delegate
			{
				Debug.Log("Explorer closed");
			});
		}
		process.Exited += value;
		bool flag = process.Start();
	}

	public static bool IsWindows()
	{
		return true;
	}

	public static bool IsOSX()
	{
		return false;
	}

	public static bool IsLinux()
	{
		return false;
	}
}
