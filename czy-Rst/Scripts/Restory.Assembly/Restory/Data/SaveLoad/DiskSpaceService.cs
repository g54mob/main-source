using System;
using System.IO;
using Restory.Gameplay.SaveLoad.Services;
using UnityEngine;

namespace Restory.Data.SaveLoad
{
	public class DiskSpaceService : MonoBehaviour, IDiskSpaceService
	{
		[SerializeField]
		private SaveSystemSettings saveSystemSettings;

		public bool IsEnoughDiskSpace()
		{
			if (SaveSystemDebugConfiguration.IsNotEnoughFreeSpace)
			{
				return false;
			}
			return IsEnoughSpace(saveSystemSettings.RequiredSaveFilesSpaceMb);
		}

		private bool IsEnoughSpace(double requiredSpaceMb)
		{
			return IsEnoughSpace(requiredSpaceMb, Application.persistentDataPath);
		}

		private bool IsEnoughSpace(double requiredSpaceMb, string savePath)
		{
			DriveInfo drive = GetDrive(savePath);
			if (drive == null)
			{
				return true;
			}
			try
			{
				long availableFreeSpace = drive.AvailableFreeSpace;
				return ConvertBytesToMegabytes(availableFreeSpace) > requiredSpaceMb;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return true;
			}
		}

		private DriveInfo GetDrive(string path)
		{
			try
			{
				return new DriveInfo(Path.GetPathRoot(path));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		private double ConvertBytesToMegabytes(long bytes)
		{
			return (float)bytes / 1024f / 1024f;
		}
	}
}
