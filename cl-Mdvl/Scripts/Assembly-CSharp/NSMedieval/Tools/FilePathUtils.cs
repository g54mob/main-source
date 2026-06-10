using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using UnityEngine;

namespace NSMedieval.Tools
{
	public static class FilePathUtils
	{
		private static string[] pcUsernameCase;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnDomainReload()
		{
			pcUsernameCase = new string[4];
			string userName = Environment.UserName;
			pcUsernameCase[0] = "/" + userName + "/";
			pcUsernameCase[1] = "\\" + userName + "\\";
			pcUsernameCase[2] = "\\" + userName + "/";
			pcUsernameCase[3] = "/" + userName + "\\";
		}

		public static bool CanWriteToFolder(string folderPath)
		{
			if (Application.platform != RuntimePlatform.WindowsPlayer)
			{
				return CanWriteToFolderNotWindows(folderPath);
			}
			bool flag = false;
			bool flag2 = false;
			try
			{
				foreach (FileSystemAccessRule accessRule in Directory.GetAccessControl(folderPath).GetAccessRules(includeExplicit: true, includeInherited: true, typeof(SecurityIdentifier)))
				{
					flag = (accessRule.FileSystemRights & FileSystemRights.Write) != 0;
					flag2 = accessRule.AccessControlType == AccessControlType.Allow;
					if (flag && flag2)
					{
						return true;
					}
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				Log.Error(ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
				return false;
			}
			catch (Exception ex2)
			{
				Log.Error(ex2.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
				return false;
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(49, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Can't write to folder: ");
				messageBuilder.AppendFormatted(RemoveUserFromPath(folderPath));
				messageBuilder.AppendLiteral(". Log: canWrite=");
				messageBuilder.AppendFormatted(flag);
				messageBuilder.AppendLiteral(" , allow=");
				messageBuilder.AppendFormatted(flag2);
				messageBuilder.AppendLiteral(".");
			}
			Log.Warning(messageBuilder);
			return false;
		}

		private static bool CanWriteToFolderNotWindows(string folderPath)
		{
			bool isEnabled;
			try
			{
				string path = Path.Combine(folderPath, Path.GetRandomFileName());
				File.WriteAllText(path, "Test write access.");
				File.Delete(path);
				return true;
			}
			catch (UnauthorizedAccessException ex)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(55, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't write to folder (UnauthorizedAccessException): ");
					messageBuilder.AppendFormatted(RemoveUserFromPath(folderPath));
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Error(messageBuilder);
				return false;
			}
			catch (Exception ex2)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error checking write access to ");
					messageBuilder.AppendFormatted(RemoveUserFromPath(folderPath));
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(ex2.Message);
				}
				Log.Error(messageBuilder);
				return false;
			}
		}

		public static void CheckAndCreatePath(string fullPathToCheck)
		{
			string fullPath = Path.GetFullPath(fullPathToCheck);
			if (File.Exists(fullPath) || Directory.Exists(fullPath))
			{
				return;
			}
			if (!fullPath.Equals(fullPathToCheck))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Creating Different full path: ");
					messageBuilder.AppendFormatted(RemoveUserFromPath(fullPath));
					messageBuilder.AppendLiteral(" from: ");
					messageBuilder.AppendFormatted(RemoveUserFromPath(fullPathToCheck));
					messageBuilder.AppendLiteral(" ");
				}
				Log.Info(messageBuilder);
			}
			CreateMissingDirectories(fullPath);
		}

		private static void CreateMissingDirectories(string fullPath)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
			if (directoryInfo.Extension.Length > 0)
			{
				directoryInfo = directoryInfo.Parent;
			}
			if (directoryInfo == null)
			{
				return;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating missing directory: ");
				messageBuilder.AppendFormatted(RemoveUserFromPath(directoryInfo.FullName));
			}
			Log.Info(messageBuilder);
			try
			{
				Directory.CreateDirectory(directoryInfo.FullName);
			}
			catch (Exception ex)
			{
				MonoSingleton<LoadingController>.Instance.InvokeShowLoadingError("save_failed_directory");
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FilePathUtils.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Failed to create missing directory: ");
					messageBuilder2.AppendFormatted(RemoveUserFromPath(ex.ToString()));
				}
				Log.Error(messageBuilder2);
				throw;
			}
		}

		public static string RemoveUserFromPath(string path)
		{
			if (pcUsernameCase == null)
			{
				return path;
			}
			path = Replace(path, pcUsernameCase[0], "/<user_name>/");
			path = Replace(path, pcUsernameCase[1], "/<user_name>/");
			path = Replace(path, pcUsernameCase[2], "/<user_name>/");
			path = Replace(path, pcUsernameCase[3], "/<user_name>/");
			return path;
		}

		private static string Replace(string str, string oldValue, string newValue)
		{
			if (str.Contains(oldValue, StringComparison.InvariantCultureIgnoreCase))
			{
				return str.Replace(oldValue, newValue, StringComparison.OrdinalIgnoreCase);
			}
			return str;
		}
	}
}
