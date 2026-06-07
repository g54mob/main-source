using System;
using System.IO;
using UnityEngine;

public static class CustomBoxArtUtility
{
	public static BoxArtTexture TextureGame(this BoxArt key)
	{
		return key.Texture(Database.State.Metrics.Releases.Value);
	}

	public static BoxArtTexture TextureSequel(this BoxArt key)
	{
		return key.Texture(Database.State.Metrics.Releases.Value + 1);
	}

	public static BoxArtTexture Texture(this BoxArt key, int release)
	{
		if (!SteamManager.User.DlcInstalled(4510400u) || key != BoxArt.Custom)
		{
			return new BoxArtTexture(key, key.Value());
		}
		return new BoxArtTexture(key, LoadCustomTexture(release));
	}

	public static void Select(Action<byte[]> callback)
	{
		CustomImagePicker.OpenFilePicker(delegate(byte[] raw)
		{
			Save(raw);
			callback?.Invoke(raw);
		}, CustomImagePicker.Config.Cover(600, 1000));
	}

	public static byte[] Load(int release)
	{
		string boxArtFilePath = FilePaths.GetBoxArtFilePath(Database.Profile, release);
		if (File.Exists(boxArtFilePath))
		{
			return File.ReadAllBytes(boxArtFilePath);
		}
		return null;
	}

	public static void Save(byte[] raw)
	{
		Directory.CreateDirectory(FilePaths.BoxArtFolderPath(Database.Profile));
		File.WriteAllBytes(FilePaths.GetBoxArtFilePath(Database.Profile, Database.State.Metrics.Releases.Value + 1), raw);
	}

	public static void Delete()
	{
		File.Delete(FilePaths.GetBoxArtFilePath(Database.Profile, Database.State.Metrics.Releases.Value + 1));
	}

	private static Texture LoadCustomTexture(int release)
	{
		Texture2D texture2D = new Texture2D(600, 1000);
		if (texture2D.LoadImage(Load(release)))
		{
			return texture2D;
		}
		UnityEngine.Object.Destroy(texture2D);
		return null;
	}
}
