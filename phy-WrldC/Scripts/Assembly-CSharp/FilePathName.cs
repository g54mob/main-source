using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class FilePathName
{
	public enum SaveFormat
	{
		NONE = -1,
		GIF = 0,
		JPG = 1,
		PNG = 2
	}

	public enum AppPath
	{
		PersistentDataPath = 0,
		TemporaryCachePath = 1,
		StreamingAssetsPath = 2,
		DataPath = 3
	}

	private static string _lastGeneratedFileNameWithoutExt_fff = "";

	private static int _lastSameFileNameCounter_fff = 1;

	private static string _lastGeneratedFileNameWithoutExt = "";

	private static int _lastSameFileNameCounter = 1;

	private static FilePathName fpn = null;

	public static FilePathName Instance
	{
		get
		{
			if (fpn == null)
			{
				fpn = new FilePathName();
			}
			return fpn;
		}
	}

	public string GetAppPath(AppPath appPath)
	{
		string result = "";
		switch (appPath)
		{
		case AppPath.PersistentDataPath:
			result = Application.persistentDataPath;
			break;
		case AppPath.TemporaryCachePath:
			result = Application.temporaryCachePath;
			break;
		case AppPath.StreamingAssetsPath:
			result = Application.streamingAssetsPath;
			break;
		case AppPath.DataPath:
			result = Application.dataPath;
			break;
		}
		return result;
	}

	public string GetSaveDirectory(bool isTemporaryPath = false, string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		string text = "";
		text = ((!isTemporaryPath) ? Application.persistentDataPath : Application.temporaryCachePath);
		text = (string.IsNullOrEmpty(subFolder) ? text : Path.Combine(text, subFolder));
		if (createDirectoryIfNotExist && !Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	public string GetFileNameWithoutExt(bool millisecond = false)
	{
		if (millisecond)
		{
			return _GetComparedFileName(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff"), _lastGeneratedFileNameWithoutExt_fff, _lastSameFileNameCounter_fff, out _lastGeneratedFileNameWithoutExt_fff, out _lastSameFileNameCounter_fff);
		}
		return _GetComparedFileName(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), _lastGeneratedFileNameWithoutExt, _lastSameFileNameCounter, out _lastGeneratedFileNameWithoutExt, out _lastSameFileNameCounter);
	}

	private string _GetComparedFileName(string newFileName, string lastGeneratedFileName, int sameFileNameCounter, out string outLastGeneratedFileName, out int outSameFileNameCounter)
	{
		sameFileNameCounter = ((!(lastGeneratedFileName == newFileName)) ? 1 : (sameFileNameCounter + 1));
		outLastGeneratedFileName = newFileName;
		outSameFileNameCounter = sameFileNameCounter;
		if (sameFileNameCounter > 1)
		{
			newFileName = newFileName + " " + sameFileNameCounter;
		}
		return newFileName;
	}

	public string EnsureValidPath(string pathOrUrl)
	{
		string text = pathOrUrl;
		if (!text.StartsWith("http") && !text.StartsWith("/idbfs/"))
		{
			text = EnsureLocalPath(text);
		}
		return text;
	}

	public string EnsureLocalPath(string path)
	{
		if (!path.ToLower().StartsWith("jar:") && !path.ToLower().StartsWith("file:///"))
		{
			while (path.StartsWith("/"))
			{
				path = path.Remove(0, 1);
			}
			path = "file:///" + path;
		}
		return path;
	}

	public string EnsureValidFileName(string fileName)
	{
		string text = "[:\\\\/*\"?|<>']";
		for (int i = 0; i < text.Length; i++)
		{
			if (fileName.Contains(text[i]))
			{
				fileName = fileName.Replace(text[i], '_');
			}
		}
		return fileName;
	}

	public string GetGifFileName()
	{
		string fileNameWithoutExt = GetFileNameWithoutExt();
		return "GIF_" + fileNameWithoutExt;
	}

	public string GetGifFullPath(string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		return GetSaveDirectory(isTemporaryPath: false, subFolder, createDirectoryIfNotExist) + "/" + GetGifFileName() + ".gif";
	}

	public string GetDownloadedGifSaveFullPath(string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		return GetSaveDirectory(isTemporaryPath: false, subFolder, createDirectoryIfNotExist) + "/" + GetGifFileName() + ".gif";
	}

	public string GetJpgFileName(string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		string fileNameWithoutExt = GetFileNameWithoutExt(millisecond: true);
		return "Photo_" + fileNameWithoutExt;
	}

	public string GetJpgFullPath(string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		return GetSaveDirectory(isTemporaryPath: false, subFolder, createDirectoryIfNotExist) + "/" + GetJpgFileName() + ".jpg";
	}

	public string GetPngFileName(string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		string fileNameWithoutExt = GetFileNameWithoutExt(millisecond: true);
		return "Photo_" + fileNameWithoutExt;
	}

	public string GetPngFullPath(string subFolder = "", bool createDirectoryIfNotExist = false)
	{
		return GetSaveDirectory(isTemporaryPath: false, subFolder, createDirectoryIfNotExist) + "/" + GetPngFileName() + ".png";
	}

	public byte[] ReadFileToBytes(string fromFullPath)
	{
		if (!File.Exists(fromFullPath))
		{
			return null;
		}
		return File.ReadAllBytes(fromFullPath);
	}

	public void WriteBytesToFile(string toFullPath, byte[] byteArray)
	{
		CheckToCreateDirectory(Path.GetDirectoryName(toFullPath));
		File.WriteAllBytes(toFullPath, byteArray);
	}

	public void CopyFile(string fromFullPath, string toFullPath, bool overwrite = false)
	{
		if (File.Exists(fromFullPath))
		{
			CheckToCreateDirectory(Path.GetDirectoryName(toFullPath));
			File.Copy(fromFullPath, toFullPath, overwrite);
		}
	}

	public void MoveFile(string fromFullPath, string toFullPath)
	{
		if (File.Exists(fromFullPath))
		{
			CheckToCreateDirectory(Path.GetDirectoryName(toFullPath));
			File.Move(fromFullPath, toFullPath);
		}
	}

	public void DeleteFile(string fileFullPath)
	{
		if (File.Exists(fileFullPath))
		{
			File.Delete(fileFullPath);
		}
	}

	public void CheckToCreateDirectory(string directory)
	{
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
	}

	public bool PathIsDirectory(string path)
	{
		if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
		{
			return true;
		}
		return false;
	}

	public void RenameFile(string originFilePath, string newFileName)
	{
		string toFullPath = Path.Combine(Path.GetDirectoryName(originFilePath), newFileName);
		CopyFile(originFilePath, toFullPath, overwrite: true);
	}

	public bool FileStreamTo(string fileFullpath, byte[] byteArray)
	{
		try
		{
			CheckToCreateDirectory(Path.GetDirectoryName(fileFullpath));
			using (FileStream fileStream = new FileStream(fileFullpath, FileMode.Create, FileAccess.Write))
			{
				fileStream.Write(byteArray, 0, byteArray.Length);
				return true;
			}
		}
		catch (Exception arg)
		{
			Console.WriteLine("Exception caught in process: {0}", arg);
			return false;
		}
	}

	public void WriteBytesToText(byte[] bytes, string toFileFullPath, string separator = "", bool toChar = true)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (string.IsNullOrEmpty(separator))
		{
			if (toChar)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					stringBuilder.Append((char)bytes[i]);
				}
			}
			else
			{
				for (int j = 0; j < bytes.Length; j++)
				{
					stringBuilder.Append(bytes[j]);
				}
			}
		}
		else if (toChar)
		{
			for (int k = 0; k < bytes.Length; k++)
			{
				stringBuilder.Append((char)bytes[k]);
				stringBuilder.Append(separator);
			}
		}
		else
		{
			for (int l = 0; l < bytes.Length; l++)
			{
				stringBuilder.Append(bytes[l]);
				stringBuilder.Append(separator);
			}
		}
		CheckToCreateDirectory(Path.GetDirectoryName(toFileFullPath));
		File.WriteAllText(toFileFullPath, stringBuilder.ToString());
	}

	public string SaveTextureAs(Texture2D texture2D, SaveFormat format = SaveFormat.JPG)
	{
		string text = string.Empty;
		switch (format)
		{
		case SaveFormat.JPG:
			text = GetJpgFullPath();
			WriteBytesToFile(text, texture2D.EncodeToJPG(90));
			break;
		case SaveFormat.PNG:
			text = GetPngFullPath();
			WriteBytesToFile(text, texture2D.EncodeToPNG());
			break;
		}
		return text;
	}

	public string SaveTextureAs(Texture2D texture2D, AppPath appPath, string subFolder, bool isJPG)
	{
		string text = GetAppPath(appPath);
		if (!string.IsNullOrEmpty(subFolder))
		{
			text = Path.Combine(text, subFolder);
		}
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		text = Path.Combine(text, GetFileNameWithoutExt(millisecond: true) + (isJPG ? ".jpg" : ".png"));
		WriteBytesToFile(text, isJPG ? texture2D.EncodeToJPG(90) : texture2D.EncodeToPNG());
		return text;
	}

	public Texture2D LoadImage(string fullFilePath)
	{
		if (!File.Exists(fullFilePath))
		{
			return null;
		}
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.LoadImage(ReadFileToBytes(fullFilePath));
		return texture2D;
	}

	public List<Texture2D> LoadImages(string directory, List<string> fileExtensions = null)
	{
		if (fileExtensions == null || fileExtensions.Count <= 0)
		{
			fileExtensions = new List<string> { ".jpg", ".png", ".gif" };
		}
		List<Texture2D> list = new List<Texture2D>();
		foreach (string filePath in GetFilePaths(directory, fileExtensions))
		{
			if (fileExtensions.Contains(Path.GetExtension(filePath).ToLower()))
			{
				list.Add(LoadImage(filePath));
			}
		}
		return list;
	}

	public List<byte[]> LoadFiles(string directory, List<string> fileExtensions = null)
	{
		List<byte[]> list = new List<byte[]>();
		foreach (string filePath in GetFilePaths(directory, fileExtensions))
		{
			list.Add(ReadFileToBytes(filePath));
		}
		return list;
	}

	public List<string> GetFilePaths(string directory, List<string> fileExtensions = null)
	{
		if (!Directory.Exists(directory))
		{
			return null;
		}
		string[] files = Directory.GetFiles(directory);
		if (fileExtensions == null || ((fileExtensions.Count <= 0) ? true : false))
		{
			return files.ToList();
		}
		if (fileExtensions == null)
		{
			fileExtensions = new List<string>();
		}
		else
		{
			for (int i = 0; i < fileExtensions.Count; i++)
			{
				fileExtensions[i] = fileExtensions[i].ToLower();
			}
		}
		List<string> list = new List<string>();
		string[] array = files;
		foreach (string text in array)
		{
			if (fileExtensions.Contains(Path.GetExtension(text).ToLower()))
			{
				list.Add(text);
			}
		}
		return list;
	}

	public IEnumerator LoadFileUWR(string url, Action<byte[]> onLoadCompleted = null, Action<UnityWebRequest> onLoadCompletedUWR = null)
	{
		string text = url;
		if (!text.StartsWith("http"))
		{
			text = EnsureLocalPath(text);
		}
		using (UnityWebRequest uwr = UnityWebRequest.Get(text))
		{
			uwr.SendWebRequest();
			while (!uwr.isDone)
			{
				yield return null;
			}
			_ = uwr.isDone;
			onLoadCompletedUWR?.Invoke(uwr);
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				Debug.LogError("File load error.\n" + uwr.error);
				onLoadCompleted(null);
			}
			else
			{
				onLoadCompleted(uwr.downloadHandler.data);
			}
		}
	}

	public Sprite Texture2DToSprite(Texture2D texture2D)
	{
		if (texture2D == null)
		{
			return null;
		}
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		float pixelsPerUnit = 100f;
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot, pixelsPerUnit);
	}
}
