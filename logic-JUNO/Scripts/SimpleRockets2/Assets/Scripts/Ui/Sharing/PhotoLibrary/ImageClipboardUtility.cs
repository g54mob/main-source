using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class ImageClipboardUtility
	{
		public enum CopyImageResult
		{
			Succeeded = 0,
			Failed = 1,
			NotSupported = 2
		}

		public const string ExecutableName = "SimpleRockets2_ClipboardImage.exe";

		public static CopyImageResult CopyImageToClipboard(string imagePath)
		{
			string empty = string.Empty;
			if (Game.Instance.Device.IsUnityEditor)
			{
				empty = "..\\Utility\\ClipboardImage\\SimpleRockets2_ClipboardImage.exe";
			}
			else
			{
				if (!Game.Instance.Device.IsWindowsBuild)
				{
					return CopyImageResult.NotSupported;
				}
				empty = Path.Combine(Application.dataPath, "..\\Utility\\SimpleRockets2_ClipboardImage.exe");
			}
			try
			{
				Process process = new Process();
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				FileInfo fileInfo = new FileInfo(empty);
				process.StartInfo.FileName = $"\"{fileInfo.FullName}\"";
				process.StartInfo.Arguments = $"\"{imagePath}\"";
				process.EnableRaisingEvents = true;
				process.Start();
				process.WaitForExit();
				return (process.ExitCode != 1) ? CopyImageResult.Failed : CopyImageResult.Succeeded;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
			return CopyImageResult.Failed;
		}
	}
}
