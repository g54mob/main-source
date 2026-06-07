using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
	public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/Saves/";

	public static void Init()
	{
		if (!Directory.Exists(SAVE_FOLDER))
		{
			Directory.CreateDirectory(SAVE_FOLDER);
		}
	}

	public static void SaveJsonFile(string path, string targetJsonName, string saveContent)
	{
		Init();
		string text = Path.Combine(path, targetJsonName + ".txt");
		try
		{
			using (FileStream stream = new FileStream(text, FileMode.Create, FileAccess.Write))
			{
				using StreamWriter streamWriter = new StreamWriter(stream);
				streamWriter.Write(saveContent);
			}
			Debug.Log("Save successful: " + text);
		}
		catch (Exception ex)
		{
			Debug.LogError("Error saving file: " + ex.Message);
		}
	}

	public static string LoadJsonFile(string path, string targetJsonName)
	{
		if (path == null)
		{
			return null;
		}
		if (File.Exists(Path.Combine(path, targetJsonName + ".txt")))
		{
			return File.ReadAllText(Path.Combine(path, targetJsonName + ".txt"));
		}
		return null;
	}

	public static string SearchAndReturnTheContentPathByName(string nameToSearch, string parentFolderPath)
	{
		if (!Directory.Exists(parentFolderPath))
		{
			return null;
		}
		string[] directories = Directory.GetDirectories(parentFolderPath);
		foreach (string text in directories)
		{
			if (text.Contains(nameToSearch))
			{
				return text;
			}
		}
		return null;
	}

	public static string CreateNewSaveFile(string parentFolderPath, string saveFileName, string saveContent)
	{
		string text = Path.Combine(parentFolderPath, saveFileName);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, saveFileName + ".txt");
		try
		{
			using (FileStream stream = new FileStream(text2, FileMode.Create, FileAccess.Write))
			{
				using StreamWriter streamWriter = new StreamWriter(stream);
				streamWriter.Write(saveContent);
			}
			Debug.Log("Save successful: " + text2);
		}
		catch (Exception ex)
		{
			Debug.LogError("Error saving file: " + ex.Message);
		}
		return text2;
	}

	public static void RenameFolder(string oldPath, string newPath)
	{
		if (Directory.Exists(oldPath))
		{
			Directory.Move(oldPath, newPath);
		}
	}

	public static void DeleteFolder(string path)
	{
		Debug.Log(path);
		try
		{
			if (Directory.Exists(path))
			{
				Directory.Delete(path, recursive: true);
			}
			else
			{
				Debug.LogWarning("Folder does not exist: " + path);
			}
		}
		catch (IOException ex)
		{
			Debug.LogError("Error deleting folder: " + path + "\n" + ex.Message);
		}
	}

	public static string ReturnSaveFilePathInAllSaveFolders(string saveFileName)
	{
		string[] directories = Directory.GetDirectories(SAVE_FOLDER);
		foreach (string text in directories)
		{
			if (File.Exists(text + "/" + saveFileName + ".txt"))
			{
				return text + "/" + saveFileName + ".txt";
			}
		}
		return null;
	}

	public static string[] GetEachFolderPathInParentFolder(string parentFolderPath)
	{
		return Directory.GetDirectories(parentFolderPath);
	}

	public static string GetJsonFileContentOfTxtFile(string path)
	{
		string result = null;
		string[] files = Directory.GetFiles(path, "*.txt");
		if (files.Length != 0)
		{
			result = File.ReadAllText(files[0]);
		}
		return result;
	}

	public static Texture2D GetFirstScreenshotJpgFoundInPath(string targetDirectoryPath)
	{
		string[] files = Directory.GetFiles(targetDirectoryPath, "*.jpg");
		if (files.Length != 0)
		{
			byte[] data = File.ReadAllBytes(files[0]);
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			return texture2D;
		}
		return null;
	}

	public static string TakeScreenshot(string parentFolderName, string saveFileName)
	{
		string text = Path.Combine(SAVE_FOLDER, parentFolderName);
		if (Directory.Exists(text))
		{
			int num = 960;
			int num2 = (int)((float)num / Camera.main.aspect);
			RenderTexture renderTexture = new RenderTexture(num, num2, 24);
			Camera.main.targetTexture = renderTexture;
			Camera.main.Render();
			RenderTexture.active = renderTexture;
			Texture2D texture2D = new Texture2D(num, num2, TextureFormat.RGB24, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
			byte[] bytes = texture2D.EncodeToJPG();
			File.WriteAllBytes(text + "/" + saveFileName + ".jpg", bytes);
			Camera.main.targetTexture = null;
			RenderTexture.active = null;
		}
		return text + "/" + saveFileName + ".jpg";
	}

	public static Texture2D LoadScreenshot(string parentFolderName, string screenshotFileName)
	{
		string text = Path.Combine(SAVE_FOLDER, parentFolderName);
		if (File.Exists(text + "/" + screenshotFileName + ".jpg"))
		{
			byte[] data = File.ReadAllBytes(text + "/" + screenshotFileName + ".jpg");
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			return texture2D;
		}
		return null;
	}
}
