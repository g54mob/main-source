using System;
using System.IO;
using System.Text;
using Ionic.Zip;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.State;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NSMedieval.Tools.BugReporting
{
	public static class BugReporterUtils
	{
		public static string GetSystemSpecs()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("----");
			stringBuilder.AppendLine("*SYSTEM SPECS*");
			stringBuilder.AppendLine("OS: " + SystemInfo.operatingSystem);
			stringBuilder.AppendLine($"Memory: {SystemInfo.systemMemorySize}");
			stringBuilder.AppendLine("Graphics: " + SystemInfo.graphicsDeviceName);
			stringBuilder.AppendLine("Processor: " + SystemInfo.processorType);
			stringBuilder.AppendLine($"Supports Audio: {SystemInfo.supportsAudio}");
			stringBuilder.AppendLine("Platform: " + GetStorePlatform());
			stringBuilder.AppendLine("----");
			stringBuilder.AppendLine("*SAVE DATA*");
			if (GlobalSaveController.CurrentVillageData != null)
			{
				stringBuilder.AppendLine("Save file name: " + GlobalSaveController.CurrentVillageData.FileName);
				stringBuilder.AppendLine("Save Created on version: " + GlobalSaveController.CurrentVillageData.CreatedOnGameVersion);
				stringBuilder.AppendLine("Save Last modified on version: " + GlobalSaveController.CurrentVillageData.ModifiedOnGameVersion);
				stringBuilder.AppendLine("Scenario name: " + GlobalSaveController.CurrentVillageData.Scenario?.GetID());
				stringBuilder.AppendLine("----");
				stringBuilder.AppendLine("*SECOND MAP DATA*");
				stringBuilder.AppendLine($"Is Second Map Transition: {MonoSingleton<GlobalSaveController>.Instance.IsSecondMapTransition}");
				stringBuilder.AppendLine($"Is Second Map Loading: {MonoSingleton<GlobalSaveController>.Instance.IsLoadingSecondMap}");
				stringBuilder.AppendLine($"Is Second Map: {GlobalSaveController.CurrentVillageData.IsSecondMap}");
				if (GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					stringBuilder.AppendLine("Second Map ID: " + GlobalSaveController.CurrentVillageData.SecondMapId);
				}
				stringBuilder.AppendLine("----");
				stringBuilder.AppendLine("*MAP DATA*");
				stringBuilder.AppendLine("MapType: " + GlobalSaveController.CurrentVillageData.MapTypeID);
				stringBuilder.AppendLine("Seed: " + GlobalSaveController.CurrentVillageData.MapSeed);
				stringBuilder.AppendLine("Map Size: " + GlobalSaveController.CurrentVillageData.MapSizeID);
				Vec3Int mapSize = GlobalSaveController.CurrentVillageData.MapSize;
				stringBuilder.AppendLine($"Map Size (vec3): {mapSize.x} {mapSize.y} {mapSize.z}");
				MapSize byID = Repository<MapSizeRepository, MapSize>.Instance.GetByID(GlobalSaveController.CurrentVillageData.MapSizeID);
				if (byID != null)
				{
					stringBuilder.AppendLine($"Map Size (from repo): {byID.Width} {byID.Height} {byID.Length}");
				}
			}
			else
			{
				stringBuilder.AppendLine("GlobalSaveController.CurrentVillageData is null!");
			}
			stringBuilder.AppendLine("----");
			stringBuilder.AppendLine("*BUILD & FILE INTEGRITY*");
			stringBuilder.AppendLine("Development build: false");
			stringBuilder.AppendLine("Demo build: false");
			stringBuilder.AppendLine("IL2CPP build: false");
			if (GlobalSaveController.CurrentVillageData != null)
			{
				stringBuilder.AppendLine($"Dev tools on: {MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools}");
			}
			stringBuilder.AppendLine($"Unity files integrity: {IntegrityChecker.UnityGenuine}");
			stringBuilder.AppendLine($"StreamingAssets integrity: {IntegrityChecker.StreamingAssetsGenuine}");
			stringBuilder.AppendLine("Has mods: " + IntegrityChecker.GetModsList());
			stringBuilder.AppendLine($"Going Medieval_Data integrity: {IntegrityChecker.BuildDataGenuine}");
			stringBuilder.AppendLine("----");
			stringBuilder.AppendLine("*UNITY SCENE INFO*");
			try
			{
				stringBuilder.AppendLine("Active Unity scene: " + SceneManager.GetActiveScene().name);
			}
			catch (Exception arg)
			{
				stringBuilder.AppendLine($"Failed to retrieve active unity scene, exception: {arg}");
			}
			try
			{
				int sceneCount = SceneManager.sceneCount;
				stringBuilder.AppendLine($"Unity scenes in the hierarchy: {sceneCount}");
				for (int i = 0; i < sceneCount; i++)
				{
					Scene sceneAt = SceneManager.GetSceneAt(i);
					stringBuilder.AppendLine($"- {sceneAt.name}, isLoaded = {sceneAt.isLoaded}");
				}
			}
			catch (Exception arg2)
			{
				stringBuilder.AppendLine($"Failed to retrieve active Unity scenes in the hierarchy, exception: {arg2}");
			}
			stringBuilder.AppendLine($"Is Application Quitting: {MonoSingleton<LoadingController>.IsApplicationIsQuitting()}");
			stringBuilder.AppendLine($"LoadingController.IsLeavingMainScene: {LoadingController.IsLeavingMainScene}");
			stringBuilder.AppendLine($"LoadingController.IsSceneTransition: {LoadingController.IsSceneTransition}");
			return stringBuilder.ToString();
		}

		public static string GetStorePlatform()
		{
			return string.Empty + "Steam";
		}

		public static string GenerateZipFile(out string exceptionWhileSaving)
		{
			ZipFile zipFile = new ZipFile();
			string arg = "Player-prev.log";
			string text = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}{arg}";
			if (File.Exists(text))
			{
				zipFile.AddFile(text, "");
			}
			arg = "Player.log";
			text = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}{arg}";
			if (File.Exists(text))
			{
				zipFile.AddFile(text, "");
			}
			arg = "user.bin";
			text = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}{arg}";
			if (File.Exists(text))
			{
				zipFile.AddFile(text, "");
			}
			arg = "global.config";
			text = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}{arg}";
			if (File.Exists(text))
			{
				zipFile.AddFile(text, "");
			}
			exceptionWhileSaving = string.Empty;
			VillageSaveInfo villageSaveInfo = null;
			if (MonoSingleton<GlobalSaveController>.Instance.SavesList.Count > 0)
			{
				villageSaveInfo = MonoSingleton<GlobalSaveController>.Instance.GetLastPlayedProfile();
			}
			if (villageSaveInfo != null && GlobalSaveController.CurrentVillageData != null)
			{
				DateTime now = DateTime.Now;
				string directoryPathInArchive = string.Format("{0}/bug_reporter_last_save_{1}_{2}-{3}-{4}_{5}-{6}", "VillageSaves", GlobalSaveController.CurrentVillageData.Name, now.Year, now.Month, now.Day, now.Hour, now.Minute);
				arg = villageSaveInfo.FileName;
				text = GlobalSaveController.GetAbsoluteSaveFilename(arg, villageSaveInfo.FolderName);
				if (File.Exists(text))
				{
					zipFile.AddFile(text, directoryPathInArchive);
				}
				string text2 = text + ".meta";
				if (File.Exists(text2))
				{
					zipFile.AddFile(text2, directoryPathInArchive);
				}
				string text3 = text.Replace(".sav", ".gmevents");
				if (File.Exists(text3))
				{
					zipFile.AddFile(text3, directoryPathInArchive);
				}
				if (GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					string text4 = text.Replace(arg, "[primary_map]_" + arg).Replace(".sav", ".gmevents");
					if (File.Exists(text4))
					{
						zipFile.AddFile(text4, directoryPathInArchive);
					}
				}
			}
			villageSaveInfo = null;
			if (GlobalSaveController.CurrentVillageData != null)
			{
				string text5 = string.Empty;
				string text6 = string.Empty;
				try
				{
					VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
					text5 = currentVillageData.FolderName;
					text6 = currentVillageData.FileName;
					currentVillageData.SetFolderName("../_bug_reporter_save");
					villageSaveInfo = MonoSingleton<GlobalSaveController>.Instance.SaveCurrentVillage("bug_reporter_save.sav");
					GlobalSaveController.CurrentVillageData.SetFileName(text6, text5);
					GlobalSaveController.CurrentVillageData.SetFolderName(text5);
				}
				catch (Exception ex)
				{
					if (!string.IsNullOrEmpty(text6) && !string.IsNullOrEmpty(text5))
					{
						GlobalSaveController.CurrentVillageData.SetFileName(text6, text5);
						GlobalSaveController.CurrentVillageData.SetFolderName(text5);
					}
					exceptionWhileSaving = ex.Message + "\n\nStack trace:\n" + ex.StackTrace;
				}
			}
			if (villageSaveInfo != null)
			{
				arg = villageSaveInfo.FileName;
				text = GlobalSaveController.GetAbsoluteSaveFilename(arg, villageSaveInfo.FolderName);
				if (File.Exists(text))
				{
					DateTime now2 = DateTime.Now;
					string directoryPathInArchive2 = string.Format("{0}/bug_reporter_{1}_{2}-{3}-{4}_{5}-{6}", "VillageSaves", GlobalSaveController.CurrentVillageData.Name, now2.Year, now2.Month, now2.Day, now2.Hour, now2.Minute);
					if (string.IsNullOrEmpty(exceptionWhileSaving))
					{
						zipFile.AddFile(text, directoryPathInArchive2);
					}
					if (File.Exists(text))
					{
						zipFile.AddFile(text + ".meta", directoryPathInArchive2);
					}
					string text7 = text.Replace(".sav", ".gmevents");
					if (File.Exists(text7))
					{
						zipFile.AddFile(text7, directoryPathInArchive2);
					}
				}
			}
			arg = "ManageGroupPresets.json";
			text = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}UserData{Path.DirectorySeparatorChar}{arg}";
			if (File.Exists(text))
			{
				zipFile.AddFile(text, "UserData");
			}
			arg = "CharacterPresets.json";
			text = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}UserData{Path.DirectorySeparatorChar}{arg}";
			if (File.Exists(text))
			{
				zipFile.AddFile(text, "UserData");
			}
			string text8 = "Scenarios";
			string text9 = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}UserData{Path.DirectorySeparatorChar}{text8}";
			if (Directory.Exists(text9))
			{
				zipFile.AddDirectory(text9, $"UserData{Path.DirectorySeparatorChar}{text8}");
			}
			string text10 = string.Format("{0}{1}{2}Z-R.zip", Application.persistentDataPath, Path.DirectorySeparatorChar, "_bug_reporter_save");
			zipFile.Save(text10);
			MonoSingleton<GlobalSaveController>.Instance.DeleteBugReporterSaves();
			return text10;
		}
	}
}
