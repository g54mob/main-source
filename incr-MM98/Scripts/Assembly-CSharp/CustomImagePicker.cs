using System;
using SimpleFileBrowser;
using UnityEngine;
using UnityEngine.Localization;

public static class CustomImagePicker
{
	public readonly struct Config
	{
		public enum Type
		{
			Contain = 0,
			Cover = 1
		}

		public readonly Type Format;

		public readonly int Width;

		public readonly int Height;

		public readonly int Quality;

		public Config(Type format, int width, int height, int quality = 80)
		{
			Format = format;
			Width = width;
			Height = height;
			Quality = quality;
		}

		public static Config Contain(int width, int height, int quality = 80)
		{
			return new Config(Type.Contain, width, height, quality);
		}

		public static Config Cover(int width, int height, int quality = 80)
		{
			return new Config(Type.Cover, width, height, quality);
		}
	}

	private static readonly LocalizedString title;

	static CustomImagePicker()
	{
		title = LocalizationUtility.Find(LocTable.General, "customization_localfile");
		FileBrowser.SetFilters(false, new FileBrowser.Filter("Images", ".jpg", ".png"));
		FileBrowser.SetDefaultFilter(".jpg");
		FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
		FileBrowser.CanDeleteFiles = false;
		FileBrowser.CanRenameFiles = false;
	}

	public static void OpenFilePicker(Action<byte[]> callback, Config config)
	{
		FileBrowser.ShowLoadDialog(delegate(string[] paths)
		{
			HandleFilePicked(paths, callback, config);
		}, null, FileBrowser.PickMode.Files, allowMultiSelection: false, null, null, title.GetLocalizedString());
	}

	private static void HandleFilePicked(string[] paths, Action<byte[]> callback, Config config)
	{
		if (paths.Length == 1)
		{
			byte[] obj = Resize(FileBrowserHelpers.ReadBytesFromFile(paths[0]), config);
			callback(obj);
		}
	}

	private static byte[] Resize(byte[] source, Config config)
	{
		Texture2D texture2D = new Texture2D(2, 2);
		texture2D.LoadImage(source);
		Texture2D obj = ((config.Format == Config.Type.Contain) ? ResizeContain(texture2D, config.Width, config.Height) : ResizeCover(texture2D, config.Width, config.Height));
		byte[] result = obj.EncodeToJPG(config.Quality);
		UnityEngine.Object.Destroy(texture2D);
		UnityEngine.Object.Destroy(obj);
		return result;
	}

	private static Texture2D ResizeContain(Texture2D source, int width, int height)
	{
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false);
		Color color = new Color(0f, 0f, 0f, 1f);
		Color[] array = new Color[width * height];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = color;
		}
		texture2D.SetPixels(array);
		float num = (float)source.width / (float)source.height;
		float num2 = (float)width / (float)height;
		int num3;
		int num4;
		if (num > num2)
		{
			num3 = width;
			num4 = Mathf.RoundToInt((float)width / num);
		}
		else
		{
			num4 = height;
			num3 = Mathf.RoundToInt((float)height * num);
		}
		Texture2D texture2D2 = ResizeTexture(source, num3, num4);
		int x = (width - num3) / 2;
		int y = (height - num4) / 2;
		texture2D.SetPixels(x, y, num3, num4, texture2D2.GetPixels());
		texture2D.Apply();
		UnityEngine.Object.Destroy(texture2D2);
		return texture2D;
	}

	private static Texture2D ResizeCover(Texture2D source, int width, int height)
	{
		float num = (float)source.width / (float)source.height;
		float num2 = (float)width / (float)height;
		int num3;
		int num4;
		if (num > num2)
		{
			num3 = source.height;
			num4 = Mathf.RoundToInt((float)num3 * num2);
		}
		else
		{
			num4 = source.width;
			num3 = Mathf.RoundToInt((float)num4 / num2);
		}
		int x = (source.width - num4) / 2;
		int y = (source.height - num3) / 2;
		Color[] pixels = source.GetPixels(x, y, num4, num3);
		Texture2D texture2D = new Texture2D(num4, num3);
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		Texture2D result = ResizeTexture(texture2D, width, height);
		UnityEngine.Object.Destroy(texture2D);
		return result;
	}

	private static Texture2D ResizeTexture(Texture2D source, int width, int height)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(width, height);
		Graphics.Blit(source, temporary);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false);
		texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
		return texture2D;
	}
}
