using System;
using System.IO;
using UnityEngine;

public static class ImageSharingUtility
{
	public static Diagnostics.Log.Channel Log = new Diagnostics.Log.Channel("ImageSharingUtility");

	public static readonly string PNG = ".png";

	public static readonly string GIF = ".gif";

	public static readonly int MaximumNumberofSaveAttempts = 256;

	public static bool SaveScreenshotToPictures(string name, string parentFolder, int superSize = 1)
	{
		string uniqueImagePath = GetUniqueImagePath(name, parentFolder);
		if (uniqueImagePath == null)
		{
			return false;
		}
		ScreenCapture.CaptureScreenshot(uniqueImagePath, superSize);
		return true;
	}

	public static bool SaveGIF(byte[] gifData, string name, string parentFolder)
	{
		string uniqueImagePath = GetUniqueImagePath(name, parentFolder);
		Log.Info("Saving gif to {0}", uniqueImagePath);
		try
		{
			using FileStream fileStream = File.Open(uniqueImagePath, FileMode.Create);
			if (fileStream == null)
			{
				return false;
			}
			fileStream.Write(gifData, 0, gifData.Length);
			fileStream.Close();
			Log.Info("Saved gif to {0}!", uniqueImagePath);
			return true;
		}
		catch (Exception ex)
		{
			Log.Warn("Failed to save GIF. {0}", ex);
			return false;
		}
	}

	public static bool SaveScreenshotToPictures(Texture2D screenshot, string name, string parentFolder)
	{
		string uniqueImagePath = GetUniqueImagePath(name, parentFolder);
		if (uniqueImagePath == null)
		{
			return false;
		}
		byte[] buffer = screenshot.EncodeToPNG();
		try
		{
			using FileStream fileStream = File.Open(uniqueImagePath, FileMode.Create);
			if (fileStream == null)
			{
				return false;
			}
			using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			if (binaryWriter == null)
			{
				return false;
			}
			binaryWriter.Write(buffer);
			Log.Info("Wrote screenshot to {0}", uniqueImagePath);
			return true;
		}
		catch (Exception ex)
		{
			Log.Info("Failed to save screenshot.");
			Log.Info(ex.ToString());
			return false;
		}
	}

	public static string GetUniqueImagePath(string filename, string parentFolder)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), parentFolder);
		string text2 = text;
		int num = 1;
		while (true)
		{
			if (Directory.Exists(text2))
			{
				if (HasWriteAccessToFolder(text2))
				{
					break;
				}
				goto IL_0065;
			}
			try
			{
				Directory.CreateDirectory(text2);
			}
			catch (Exception ex)
			{
				Log.Info("Unable to create a directory at {0}", text2);
				Log.Info("Failed due to: {0}", ex);
				goto IL_0065;
			}
			break;
			IL_0065:
			text2 = $"{text} {num}";
			num++;
			if (num > MaximumNumberofSaveAttempts)
			{
				return null;
			}
		}
		string arg = "";
		int num2 = filename.LastIndexOf('.');
		if (num2 > 0)
		{
			arg = filename.Substring(num2);
			filename = filename.Substring(0, num2);
		}
		num = 0;
		string text3;
		do
		{
			string path = string.Format("{0}{1}{2}", filename, (num == 0) ? "" : (" " + num), arg);
			text3 = Path.Combine(text2, path);
			num++;
			if (num > MaximumNumberofSaveAttempts)
			{
				return null;
			}
		}
		while (File.Exists(text3));
		return text3;
	}

	private static bool HasWriteAccessToFolder(string folderPath)
	{
		try
		{
			string path = Path.Combine(folderPath, "accessCheck");
			FileStream fileStream = File.Create(path);
			if (fileStream == null)
			{
				return false;
			}
			fileStream.Close();
			File.Delete(path);
			return true;
		}
		catch (Exception ex)
		{
			Log.Info("Unable to write to this directory! {0}", folderPath);
			Log.Info("Failed due to: {0}", ex);
		}
		return false;
	}
}
