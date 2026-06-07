using System;
using System.IO;
using UnityEngine;

public static class MobileMedia
{
	public enum ImageFormat
	{
		JPG = 0,
		PNG = 1,
		GIF = 2
	}

	public enum Permission
	{
		Denied = 0,
		Granted = 1,
		Ask = 2
	}

	public static bool CanOpenSettings => true;

	public static bool IsMediaPickerBusy => false;

	private static bool IsEditor
	{
		get
		{
			if (Application.platform != RuntimePlatform.LinuxEditor && Application.platform != RuntimePlatform.OSXEditor)
			{
				return Application.platform == RuntimePlatform.WindowsEditor;
			}
			return true;
		}
	}

	public static Permission CheckPermission()
	{
		_ = IsEditor;
		return Permission.Granted;
	}

	public static Permission RequestPermission()
	{
		_ = IsEditor;
		return Permission.Granted;
	}

	public static void OpenSettings()
	{
		_ = IsEditor;
	}

	public static string SaveBytes(byte[] mediaBytes, string folderName, string fileName, string extensionName, bool isImage)
	{
		string result = "";
		if (RequestPermission() == Permission.Granted)
		{
			if (mediaBytes == null || mediaBytes.Length == 0)
			{
				throw new ArgumentException("mediaBytes is null or empty!");
			}
			if (string.IsNullOrEmpty(folderName) || folderName.Length == 0)
			{
				throw new ArgumentException("folderName is null or empty!");
			}
			if (string.IsNullOrEmpty(fileName) || fileName.Length == 0)
			{
				throw new ArgumentException("fileName is null or empty!");
			}
			if (string.IsNullOrEmpty(extensionName) || extensionName.Length == 0)
			{
				throw new ArgumentException("extensionName is null or empty!");
			}
			string path = (result = _GetSavePath(folderName, fileName + extensionName));
			File.WriteAllBytes(path, mediaBytes);
			mediaBytes = null;
			_SaveInternal(path, folderName, isImage);
		}
		return result;
	}

	public static string CopyMedia(string existingMediaPath, string folderName, string fileName, string extensionName, bool isImage)
	{
		string result = "";
		if (RequestPermission() == Permission.Granted)
		{
			if (!File.Exists(existingMediaPath))
			{
				throw new FileNotFoundException("File not found at " + existingMediaPath);
			}
			if (string.IsNullOrEmpty(folderName) || folderName.Length == 0)
			{
				throw new ArgumentException("folderName is null or empty!");
			}
			if (string.IsNullOrEmpty(fileName) || fileName.Length == 0)
			{
				throw new ArgumentException("fileName is null or empty!");
			}
			if (string.IsNullOrEmpty(extensionName) || extensionName.Length == 0)
			{
				throw new ArgumentException("extensionName is null or empty!");
			}
			string text = _GetSavePath(folderName, fileName + extensionName);
			result = text;
			File.Copy(existingMediaPath, text, overwrite: true);
			_SaveInternal(text, folderName, isImage);
		}
		return result;
	}

	public static string SaveImage(Texture2D texture2d, string folderName, string fileName, ImageFormat imageFormat = ImageFormat.JPG, int quality = 90)
	{
		if (texture2d == null)
		{
			throw new ArgumentException("image is null!");
		}
		quality = Mathf.Clamp(quality, 1, 100);
		string result = "";
		switch (imageFormat)
		{
		case ImageFormat.JPG:
			result = SaveBytes(texture2d.EncodeToJPG(quality), folderName, fileName, ".jpg", isImage: true);
			break;
		case ImageFormat.PNG:
			result = SaveBytes(texture2d.EncodeToPNG(), folderName, fileName, ".png", isImage: true);
			break;
		}
		return result;
	}

	public static string SaveVideo(byte[] mediaBytes, string folderName, string fileName, string extensionName)
	{
		return SaveBytes(mediaBytes, folderName, fileName, extensionName, isImage: false);
	}

	private static void _SaveInternal(string path, string iOSAlbumName, bool isImage)
	{
		_ = IsEditor;
	}

	private static string _GetSavePath(string folderName, string filenameWithExtension)
	{
		string text = Path.Combine(Application.persistentDataPath, folderName);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		if (filenameWithExtension.Contains("{0}"))
		{
			int num = 0;
			string text2;
			do
			{
				text2 = Path.Combine(text, string.Format(filenameWithExtension, ++num));
			}
			while (File.Exists(text2));
			return text2;
		}
		return Path.Combine(text, filenameWithExtension);
	}

	public static void PickImage(Action<string> onReceived, string title = "", string androidMimeType = "image/*", bool iOS_UsePopup = false, string iOS_TempImageNameWithoutExtension = "temp")
	{
		PickMediaSingle(onReceived, isImage: true, androidMimeType, title, iOS_UsePopup, iOS_TempImageNameWithoutExtension);
	}

	public static void PickVideo(Action<string> onReceived, string title = "", string androidMimeType = "video/*", bool iOS_UsePopup = false)
	{
		PickMediaSingle(onReceived, isImage: false, androidMimeType, title, iOS_UsePopup);
	}

	public static void PickImageIOS(Action<string> onReceived, bool iOS_UsePopup = false, string iOS_TempImageNameWithoutExtension = "temp")
	{
		PickMediaSingle(onReceived, isImage: true, "", "", iOS_UsePopup, iOS_TempImageNameWithoutExtension);
	}

	public static void PickVideoIOS(Action<string> onReceived, bool iOS_UsePopup)
	{
		PickMediaSingle(onReceived, isImage: false, "", "", iOS_UsePopup);
	}

	public static void PickMediaSingle(Action<string> onReceived, bool isImage, string androidMimeType, string title, bool iOS_UsePopup = false, string iOS_TempImageNameWithoutExtension = "temp")
	{
		if (RequestPermission() == Permission.Granted && !IsMediaPickerBusy)
		{
			if (IsEditor)
			{
				onReceived?.Invoke(null);
			}
		}
		else
		{
			onReceived?.Invoke(null);
		}
	}

	public static void GetMediaPreviewPhoto_IOS(Action<string> onReceived, int mediaType, int mediaIndex = 0, int targetSize = 100, string iOS_TempImageNameWithoutExtension = "temp")
	{
		if (RequestPermission() == Permission.Granted && !IsMediaPickerBusy)
		{
			if (IsEditor)
			{
				onReceived?.Invoke(null);
			}
			else
			{
				onReceived?.Invoke(null);
			}
		}
		else
		{
			onReceived?.Invoke(null);
		}
	}
}
