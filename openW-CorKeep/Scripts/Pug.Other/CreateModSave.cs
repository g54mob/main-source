using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using I2.Loc;
using Pug.Platform;
using PugMod;
using QFSW.QC;
using UnityEngine;

public static class CreateModSave
{
	[Command("createModSaveZipOnDesktop", "Creates a mod containing the world save on the desktop.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void CreateModSaveZipOnDesktop(int saveSlot)
	{
		WorldInfo worldInfo = Manager.saves.GetWorldInfo(saveSlot);
		if (worldInfo != null)
		{
			FileInfo fileInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SaveMod-" + worldInfo.name + ".zip");
			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}
			CreateModSaveZip(fileInfo.FullName, worldInfo.name, saveSlot);
			string text = string.Format(LocalizationManager.GetTranslation("Menu/HasBeenCreatedOnDesktop"), fileInfo.Name);
			Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: false, TextManager.FontFace.boldMedium, delegate
			{
			}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f);
		}
	}

	public static void CreateModSaveZip(string destPath, string name, int saveSlot)
	{
		using ZipArchive zipArchive = ZipFile.Open(destPath, ZipArchiveMode.Create);
		List<FilesystemManager.File> obj = new List<FilesystemManager.File>
		{
			new FilesystemManager.File(FilesystemManager.FileID.WorldSave, saveSlot),
			new FilesystemManager.File(FilesystemManager.FileID.WorldInfo, saveSlot),
			new FilesystemManager.File(FilesystemManager.FileID.WorldGenerationParameters, saveSlot),
			new FilesystemManager.File(FilesystemManager.FileID.ServerMapParts, saveSlot)
		};
		List<ModFile> list = new List<ModFile>();
		foreach (FilesystemManager.File item in obj)
		{
			if (!item.Exists())
			{
				continue;
			}
			try
			{
				byte[] array = item.Read(raw: true);
				string text = Path.Combine("Saves", Manager.filesystemManager.GetFilePath(item));
				using Stream stream = zipArchive.CreateEntry(text).Open();
				stream.Write(array, 0, array.Length);
				list.Add(new ModFile
				{
					path = text
				});
			}
			catch (Exception exception)
			{
				Debug.LogError("Encountered exception when reading file type " + item.fileTypeId);
				Debug.LogException(exception);
			}
		}
		ModMetadata modMetadata = new ModMetadata
		{
			guid = Guid.NewGuid().ToString("N"),
			name = name,
			files = list
		};
		byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(modMetadata, prettyPrint: true));
		string entryName = "ModManifest.json";
		using (Stream stream2 = zipArchive.CreateEntry(entryName).Open())
		{
			stream2.Write(bytes, 0, bytes.Length);
		}
		byte[] bytes2 = Encoding.UTF8.GetBytes("This is a mod containing an exported world save from Core Keeper.\n\nYou can upload this zip to a mod at mod.io to share your world with others.\n\nThe format is very easy to understand if you want to add this to another mod or add more saves to the same mod. The files in the Saves subfolder should have the same structure as the saves folder in the game's data folder and the manifest file should be in the root of the zip file and contain all files included in the mod.\n");
		string entryName2 = "README.txt";
		using Stream stream3 = zipArchive.CreateEntry(entryName2).Open();
		stream3.Write(bytes2, 0, bytes2.Length);
	}
}
