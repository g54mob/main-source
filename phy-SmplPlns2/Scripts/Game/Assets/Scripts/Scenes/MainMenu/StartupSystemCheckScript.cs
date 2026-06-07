using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Net;
using Assets.Scripts.Storage;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Assets.Scripts.Scenes.MainMenu
{
	public class StartupSystemCheckScript : MonoBehaviour
	{
		private const string BelowSpecNotificationId = "BelowMinSpecWarningSeen";

		private const int MaxBytesToCheck = 256000;

		private const int MinRAM = 7500;

		private const int MinVRAM = 2900;

		private List<string> _crashIndicators = new List<string> { "ScriptableRenderContext:Internal_Cull_Injected", "Crash!!!" };

		protected void Start()
		{
			if (Device.IsWindowsRuntime)
			{
				CheckHardwareAndCrash();
			}
		}

		private static string ReadLastBytesOfFile(string filePath, int maxBytes)
		{
			using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			long length = fileStream.Length;
			long num = Math.Max(0L, length - maxBytes);
			fileStream.Seek(num, SeekOrigin.Begin);
			int num2 = (int)(length - num);
			byte[] array = new byte[num2];
			int num3 = fileStream.Read(array, 0, num2);
			if (num3 < num2)
			{
				Array.Resize(ref array, num3);
			}
			return Encoding.UTF8.GetString(array);
		}

		private void CheckHardwareAndCrash()
		{
			try
			{
				bool flag = false;
				string path = GameData.GetPath("Player-prev.log");
				if (File.Exists(path))
				{
					string text = ReadLastBytesOfFile(path, 256000);
					foreach (string crashIndicator in _crashIndicators)
					{
						if (text.IndexOf(crashIndicator, StringComparison.OrdinalIgnoreCase) >= 0)
						{
							flag = true;
							break;
						}
					}
				}
				string graphicsDeviceName = SystemInfo.graphicsDeviceName;
				int graphicsMemorySize = SystemInfo.graphicsMemorySize;
				int systemMemorySize = SystemInfo.systemMemorySize;
				bool flag2 = IsIntegratedGPU(graphicsDeviceName, graphicsMemorySize);
				bool flag3 = systemMemorySize < 7500;
				bool num = flag2 || flag3;
				bool flag4 = Game.Instance.Settings.App.SeenNotifications.Contains("BelowMinSpecWarningSeen");
				if (num && !flag4)
				{
					Game.Instance.Settings.App.AddNotification("BelowMinSpecWarningSeen");
					MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
					messageDialogScript.ExtraWide = true;
					messageDialogScript.Title = "System Requirements Notice";
					StringBuilder stringBuilder = new StringBuilder();
					if (flag)
					{
						messageDialogScript.Title = "Crash Detected";
						stringBuilder.AppendLine("It looks like the game crashed during your last session.\n");
					}
					stringBuilder.AppendLine("Your computer appears to be below the minimum system requirements for this game:\n");
					if (flag2)
					{
						stringBuilder.AppendLine($"- Graphics: {graphicsDeviceName} ({graphicsMemorySize}MB VRAM detected). A Dedicated GPU with 3GB VRAM is required.");
						stringBuilder.AppendLine("  *If you have a dedicated graphics card, Windows may be running this game on integrated graphics by mistake. You can force 'High Performance' in Windows Display Graphics Settings.\n");
					}
					if (flag3)
					{
						stringBuilder.AppendLine($"- Memory: {systemMemorySize}MB RAM detected. 8GB RAM is required.\n");
					}
					stringBuilder.AppendLine("Playing on this device may result in poor performance or crashes.");
					messageDialogScript.MessageText = stringBuilder.ToString();
					messageDialogScript.OkayButtonText = "I Understand";
					messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
					{
						d.Close();
					};
				}
				else if (flag)
				{
					MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
					messageDialogScript2.ExtraWide = true;
					messageDialogScript2.Title = "Crash Detected";
					messageDialogScript2.MessageText = "It looks like the game crashed during your last session, and outdated graphics drivers might be the cause.\nYour detected graphics card:\n" + graphicsDeviceName + "\n\nUpdating your drivers may help resolve this issue. Would you like to submit a bug report?";
					messageDialogScript2.CancelButtonText = "Close";
					messageDialogScript2.MiddleButtonText = "Update Drivers";
					messageDialogScript2.MiddleClicked += delegate(MessageDialogScript d)
					{
						d.Close();
						WebUtility.OpenUrl("http://www.simpleplanes.com/r/UpdateGraphicsDrivers");
					};
					messageDialogScript2.OkayButtonText = "Submit Bug";
					messageDialogScript2.OkayClicked += delegate(MessageDialogScript d)
					{
						d.Close();
						XElement aircraftXml = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__editor__.xml", showErrorDialogs: true);
						Game.Instance.UserInterface.CreateUploadBugReportDialog(aircraftXml, null);
					};
				}
			}
			catch (Exception)
			{
			}
		}

		private bool IsIntegratedGPU(string gpuName, int vramMB)
		{
			if (vramMB < 2900)
			{
				return true;
			}
			string text = gpuName.ToLower();
			if (text.Contains("intel") && !text.Contains("arc"))
			{
				return true;
			}
			if (text == "amd radeon graphics" || text == "amd radeon(tm) graphics" || text.Contains("vega") || text.Contains("radeon r4") || text.Contains("radeon r5"))
			{
				return true;
			}
			return false;
		}
	}
}
