using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Pug.Platform;
using UnityEngine;

public class ZipSaveFolder : MonoBehaviour
{
	public bool onlyAllowZipOnce = true;

	private bool hasZipped;

	private static readonly string zipFileName = "CoreKeeperSaves";

	private static string calcDestPath
	{
		get
		{
			DateTime now = DateTime.Now;
			return $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{zipFileName}_{now.Hour}_{now.Minute}_{now.Second}.zip";
		}
	}

	private void Update()
	{
		if ((onlyAllowZipOnce && hasZipped) || !Input.GetKey(KeyCode.LeftControl) || !Input.GetKey(KeyCode.LeftAlt) || !Input.GetKey(KeyCode.B))
		{
			return;
		}
		hasZipped = true;
		string text = calcDestPath;
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		using (ZipArchive zipArchive = ZipFile.Open(text, ZipArchiveMode.Create))
		{
			foreach (FilesystemManager.File allFile in Manager.filesystemManager.GetAllFiles())
			{
				try
				{
					byte[] array = allFile.Read(raw: true);
					using Stream stream = zipArchive.CreateEntry(Manager.filesystemManager.GetFilePath(allFile)).Open();
					stream.Write(array, 0, array.Length);
				}
				catch (Exception exception)
				{
					Debug.LogError("Encountered exception when reading file type " + allFile.fileTypeId);
					Debug.LogException(exception);
				}
			}
			try
			{
				string path = Application.persistentDataPath + "/Player-prev.log";
				if (File.Exists(path))
				{
					using Stream stream2 = zipArchive.CreateEntry("Player-prev.log").Open();
					byte[] array2 = File.ReadAllBytes(path);
					stream2.Write(array2, 0, array2.Length);
				}
			}
			catch (Exception exception2)
			{
				Debug.LogError("Encountered exception when reading Player-prev.log");
				Debug.LogException(exception2);
			}
			try
			{
				string path2 = Application.persistentDataPath + "/Player.log";
				if (File.Exists(path2))
				{
					using Stream stream3 = zipArchive.CreateEntry("Player.log").Open();
					byte[] array3 = File.ReadAllBytes(path2);
					stream3.Write(array3, 0, array3.Length);
				}
			}
			catch (Exception exception3)
			{
				Debug.LogError("Encountered exception when reading Player.log");
				Debug.LogException(exception3);
			}
		}
		Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/CreatedSaveBackup", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, DummyCallBack, new List<string> { "ok" }, 10f, 0.95f, 0, 18f, secondOptionPopsAllMenus: false, pauseGame: false);
	}

	private void DummyCallBack(PopupResponse response)
	{
	}
}
