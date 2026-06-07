using System;
using System.IO;

public static class CustomBackgroundUtility
{
	public static void Select(Action<byte[]> callback)
	{
		CustomImagePicker.OpenFilePicker(delegate(byte[] raw)
		{
			Save(raw);
			callback?.Invoke(raw);
		}, CustomImagePicker.Config.Contain(1920, 1080));
	}

	public static byte[] Load()
	{
		string backgroundFilePath = FilePaths.GetBackgroundFilePath(Database.Profile);
		if (File.Exists(backgroundFilePath))
		{
			return File.ReadAllBytes(backgroundFilePath);
		}
		return null;
	}

	public static void Save(byte[] raw)
	{
		File.WriteAllBytes(FilePaths.GetBackgroundFilePath(Database.Profile), raw);
	}

	public static void Delete()
	{
		File.Delete(FilePaths.GetBackgroundFilePath(Database.Profile));
	}
}
