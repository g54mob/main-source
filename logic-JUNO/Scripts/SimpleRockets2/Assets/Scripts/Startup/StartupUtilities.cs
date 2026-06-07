using System;
using System.Diagnostics;
using System.IO;
using Assets.Scripts.OperatingSystem;
using Microsoft.Win32;
using ModApi;
using ModApi.Settings.Core;
using UnityEngine;

namespace Assets.Scripts.Startup
{
	public class StartupUtilities
	{
		public static void CleanFileAssociation(string extension)
		{
			RegistryKey currentUser = Registry.CurrentUser;
			string text = $"Software\\Classes\\Jundroo.SimpleRockets2.{extension}.1";
			string text2 = $"Software\\Classes\\.{extension}";
			RegistryKey registryKey = currentUser.OpenSubKey(text);
			if (registryKey != null)
			{
				registryKey.Close();
				currentUser.DeleteSubKeyTree(text);
			}
			registryKey = currentUser.OpenSubKey(text2);
			if (registryKey != null)
			{
				registryKey.Close();
				currentUser.DeleteSubKeyTree(text2);
			}
		}

		public static string GetDeviceInformation()
		{
			bool num = !Game.Instance.Device.IsMobileBuild;
			string text = "Game Version: " + Game.Instance.VersionWithSuffix;
			string text2 = (num ? $"Launch Command: {Environment.CommandLine}" : "N/A");
			string text3 = $"Craft Designs Folder: {Game.Instance.CraftDesigns.RootFolderPath}";
			string text4 = "Unknown";
			text4 = (num ? $"SimpleRockets2: {Process.GetCurrentProcess().MainModule.FileName}" : "N/A");
			string deviceCaps = Game.Instance.Device.DeviceCaps;
			string text5 = "Device Flags: " + CurrentDevice.GetCurrentFlagsAsString();
			string text6 = DirectXAdapterInfo.ToString(DirectXAdapterInfo.QueryAll());
			return text + "\n" + text2 + "\n" + text4 + "\n" + text3 + "\n" + deviceCaps + "\n" + text5 + "\n" + text6 + "\n\n";
		}

		public static void LogDeviceInformation()
		{
			try
			{
				UnityEngine.Debug.Log(GetDeviceInformation());
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}

		public static void UpdateFileAssociation(string extension)
		{
			if (!Device.IsUnityEditor)
			{
				CleanFileAssociation(extension);
			}
		}

		internal static void Uninstall()
		{
			try
			{
				UnityEngine.Debug.Log("Uninstalling game data");
				DirectoryInfo directoryInfo = new DirectoryInfo(Game.PersistentDataPath);
				if (!directoryInfo.Exists)
				{
					UnityEngine.Debug.Log("Data directory does not exist, nothing to do: " + directoryInfo.FullName);
					return;
				}
				FileInfo[] files = directoryInfo.GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					if (!(fileInfo.Name == "output_log.txt") && !(fileInfo.Name == "Player.log") && !(fileInfo.Name == "Player-prev.log") && !(fileInfo.Name == "ModLoadLog.txt"))
					{
						try
						{
							UnityEngine.Debug.Log("Deleting file...  " + fileInfo.FullName);
							fileInfo.Delete();
						}
						catch (Exception exception)
						{
							UnityEngine.Debug.LogError("Unable to delete file: " + fileInfo.FullName);
							UnityEngine.Debug.LogException(exception);
						}
					}
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				foreach (DirectoryInfo directoryInfo2 in directories)
				{
					if (!(directoryInfo2.Name == "UserData") && !(directoryInfo2.Name == "Mods"))
					{
						try
						{
							UnityEngine.Debug.Log("Deleting directory...  " + directoryInfo2.FullName);
							directoryInfo2.Delete(recursive: true);
						}
						catch (Exception exception2)
						{
							UnityEngine.Debug.LogError("Unable to delete directory: " + directoryInfo2.FullName);
							UnityEngine.Debug.LogException(exception2);
						}
					}
				}
				UnityEngine.Debug.Log("Uninstall complete");
			}
			catch (Exception exception3)
			{
				UnityEngine.Debug.LogError("An error occurred uninstalling the game.");
				UnityEngine.Debug.LogException(exception3);
			}
		}

		private static bool SupportsRenderTextureFormat(RenderTextureFormat format)
		{
			try
			{
				return SystemInfo.SupportsRenderTextureFormat(format);
			}
			catch
			{
				return false;
			}
		}

		private static bool SupportsTextureFormat(TextureFormat format)
		{
			try
			{
				return SystemInfo.SupportsTextureFormat(format);
			}
			catch
			{
				return false;
			}
		}
	}
}
