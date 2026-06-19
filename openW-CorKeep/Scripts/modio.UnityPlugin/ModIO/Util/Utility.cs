using System;
using System.Collections.Generic;
using ModIO.Implementation.Platform;
using UnityEngine;

namespace ModIO.Util
{
	public static class Utility
	{
		public static string GenerateHumanReadableNumber(long number)
		{
			if (number >= 1000000)
			{
				return ((float)number / 1000000f).ToString("0.0") + "M";
			}
			if (number >= 1000)
			{
				return ((float)number / 1000f).ToString("0.0") + "K";
			}
			return number.ToString();
		}

		public static string GenerateHumanReadableTimeStringFromSeconds(int seconds)
		{
			if ((float)seconds < 60f)
			{
				return seconds + " seconds";
			}
			if (seconds < 3600)
			{
				int num = seconds / 60;
				int num2 = seconds % 60;
				return $"{num}:{num2:00}";
			}
			int num3 = seconds / 3600;
			int num4 = seconds % 3600 / 60;
			int num5 = seconds % 3600 % 60;
			return $"{num3}:{num4:00}:{num5:00}";
		}

		public static string GenerateHumanReadableStringForBytes(long bytes)
		{
			if (bytes > 1048576)
			{
				return ((float)bytes / 1048576f).ToString("0.0") + "MB";
			}
			return (bytes / 1024).ToString("0.0") + "KB";
		}

		public static string GetModStatusAsString(ProgressHandle handle)
		{
			return handle.OperationType switch
			{
				ModManagementOperationType.None_AlreadyInstalled => "Installed", 
				ModManagementOperationType.None_ErrorOcurred => "<color=red>Problem occurred</color>", 
				ModManagementOperationType.Install => $"Installing {(int)(handle.Progress * 100f)}%", 
				ModManagementOperationType.Download => $"Downloading {(int)(handle.Progress * 100f)}%", 
				ModManagementOperationType.Uninstall => "Uninstalling", 
				ModManagementOperationType.Update => $"Updating {(int)(handle.Progress * 100f)}%", 
				_ => "", 
			};
		}

		public static string GetModStatusAsString(SubscribedMod mod)
		{
			return mod.status switch
			{
				SubscribedModStatus.Installed => "Installed", 
				SubscribedModStatus.WaitingToDownload => "Waiting to download", 
				SubscribedModStatus.WaitingToInstall => "Waiting to install", 
				SubscribedModStatus.WaitingToUpdate => "Waiting to Update", 
				SubscribedModStatus.Downloading => "Downloading", 
				SubscribedModStatus.Installing => "Installing", 
				SubscribedModStatus.Uninstalling => "Deleting", 
				SubscribedModStatus.Updating => "Updating", 
				SubscribedModStatus.ProblemOccurred => "Problem occurred", 
				_ => "", 
			};
		}

		public static string EncodeEncryptedSteamAppTicket(byte[] ticketData, uint ticketSize)
		{
			byte[] array = new byte[ticketSize];
			Array.Copy(ticketData, array, ticketSize);
			string result = null;
			try
			{
				result = Convert.ToBase64String(array);
			}
			catch (Exception ex)
			{
				Debug.LogError("[mod.io Browser] Unable to convert the app ticket to a base64 string, caught exception: " + ex.Message + " - " + ex.InnerException?.Message);
			}
			return result;
		}

		public static List<T> FindEverythingInScene<T>() where T : Component
		{
			List<T> list = new List<T>();
			T[] array = Resources.FindObjectsOfTypeAll<T>();
			foreach (T val in array)
			{
				if (val.gameObject.scene.isLoaded)
				{
					list.Add(val);
				}
			}
			return list;
		}

		public static void ForceSetPlatformHeader(RestApiPlatform platform)
		{
			PlatformConfiguration.RESTAPI_HEADER = platform.ToString();
		}
	}
}
