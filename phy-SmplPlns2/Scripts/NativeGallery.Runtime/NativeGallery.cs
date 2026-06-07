using System;
using System.Globalization;
using System.IO;
using UnityEngine;

public static class NativeGallery
{
	public struct ImageProperties
	{
		public readonly int width;

		public readonly int height;

		public readonly string mimeType;

		public readonly ImageOrientation orientation;

		public ImageProperties(int width, int height, string mimeType, ImageOrientation orientation)
		{
			this.width = width;
			this.height = height;
			this.mimeType = mimeType;
			this.orientation = orientation;
		}
	}

	public struct VideoProperties
	{
		public readonly int width;

		public readonly int height;

		public readonly long duration;

		public readonly float rotation;

		public VideoProperties(int width, int height, long duration, float rotation)
		{
			this.width = width;
			this.height = height;
			this.duration = duration;
			this.rotation = rotation;
		}
	}

	public enum PermissionType
	{
		Read = 0,
		Write = 1
	}

	public enum Permission
	{
		Denied = 0,
		Granted = 1,
		ShouldAsk = 2
	}

	[Flags]
	public enum MediaType
	{
		Image = 1,
		Video = 2,
		Audio = 4
	}

	public enum ImageOrientation
	{
		Unknown = -1,
		Normal = 0,
		Rotate90 = 1,
		Rotate180 = 2,
		Rotate270 = 3,
		FlipHorizontal = 4,
		Transpose = 5,
		FlipVertical = 6,
		Transverse = 7
	}

	public delegate void MediaSaveCallback(bool success, string path);

	public delegate void MediaPickCallback(string path);

	public delegate void MediaPickMultipleCallback(string[] paths);

	private const bool PermissionFreeMode = true;

	public static Permission CheckPermission(PermissionType permissionType)
	{
		return Permission.Granted;
	}

	public static Permission RequestPermission(PermissionType permissionType)
	{
		return Permission.Granted;
	}

	private static void TryExtendLimitedAccessPermission()
	{
		IsMediaPickerBusy();
	}

	public static bool CanOpenSettings()
	{
		return true;
	}

	public static void OpenSettings()
	{
	}

	public static Permission SaveImageToGallery(byte[] mediaBytes, string album, string filename, MediaSaveCallback callback = null)
	{
		return SaveToGallery(mediaBytes, album, filename, MediaType.Image, callback);
	}

	public static Permission SaveImageToGallery(string existingMediaPath, string album, string filename, MediaSaveCallback callback = null)
	{
		return SaveToGallery(existingMediaPath, album, filename, MediaType.Image, callback);
	}

	public static Permission SaveImageToGallery(Texture2D image, string album, string filename, MediaSaveCallback callback = null)
	{
		if (image == null)
		{
			throw new ArgumentException("Parameter 'image' is null!");
		}
		if (filename.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) || filename.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
		{
			return SaveToGallery(GetTextureBytes(image, isJpeg: true), album, filename, MediaType.Image, callback);
		}
		if (filename.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
		{
			return SaveToGallery(GetTextureBytes(image, isJpeg: false), album, filename, MediaType.Image, callback);
		}
		return SaveToGallery(GetTextureBytes(image, isJpeg: false), album, filename + ".png", MediaType.Image, callback);
	}

	public static Permission SaveVideoToGallery(byte[] mediaBytes, string album, string filename, MediaSaveCallback callback = null)
	{
		return SaveToGallery(mediaBytes, album, filename, MediaType.Video, callback);
	}

	public static Permission SaveVideoToGallery(string existingMediaPath, string album, string filename, MediaSaveCallback callback = null)
	{
		return SaveToGallery(existingMediaPath, album, filename, MediaType.Video, callback);
	}

	private static Permission SaveAudioToGallery(byte[] mediaBytes, string album, string filename, MediaSaveCallback callback = null)
	{
		return SaveToGallery(mediaBytes, album, filename, MediaType.Audio, callback);
	}

	private static Permission SaveAudioToGallery(string existingMediaPath, string album, string filename, MediaSaveCallback callback = null)
	{
		return SaveToGallery(existingMediaPath, album, filename, MediaType.Audio, callback);
	}

	public static bool CanSelectMultipleFilesFromGallery()
	{
		return false;
	}

	public static bool CanSelectMultipleMediaTypesFromGallery()
	{
		return false;
	}

	public static Permission GetImageFromGallery(MediaPickCallback callback, string title = "", string mime = "image/*")
	{
		return GetMediaFromGallery(callback, MediaType.Image, mime, title);
	}

	public static Permission GetVideoFromGallery(MediaPickCallback callback, string title = "", string mime = "video/*")
	{
		return GetMediaFromGallery(callback, MediaType.Video, mime, title);
	}

	public static Permission GetAudioFromGallery(MediaPickCallback callback, string title = "", string mime = "audio/*")
	{
		return GetMediaFromGallery(callback, MediaType.Audio, mime, title);
	}

	public static Permission GetMixedMediaFromGallery(MediaPickCallback callback, MediaType mediaTypes, string title = "")
	{
		return GetMediaFromGallery(callback, mediaTypes, "*/*", title);
	}

	public static Permission GetImagesFromGallery(MediaPickMultipleCallback callback, string title = "", string mime = "image/*")
	{
		return GetMultipleMediaFromGallery(callback, MediaType.Image, mime, title);
	}

	public static Permission GetVideosFromGallery(MediaPickMultipleCallback callback, string title = "", string mime = "video/*")
	{
		return GetMultipleMediaFromGallery(callback, MediaType.Video, mime, title);
	}

	public static Permission GetAudiosFromGallery(MediaPickMultipleCallback callback, string title = "", string mime = "audio/*")
	{
		return GetMultipleMediaFromGallery(callback, MediaType.Audio, mime, title);
	}

	public static Permission GetMixedMediasFromGallery(MediaPickMultipleCallback callback, MediaType mediaTypes, string title = "")
	{
		return GetMultipleMediaFromGallery(callback, mediaTypes, "*/*", title);
	}

	public static bool IsMediaPickerBusy()
	{
		return false;
	}

	public static MediaType GetMediaTypeOfFile(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return (MediaType)0;
		}
		string extension = Path.GetExtension(path);
		if (string.IsNullOrEmpty(extension))
		{
			return (MediaType)0;
		}
		if (extension[0] == '.')
		{
			if (extension.Length == 1)
			{
				return (MediaType)0;
			}
			extension = extension.Substring(1);
		}
		return (MediaType)0;
	}

	private static Permission SaveToGallery(byte[] mediaBytes, string album, string filename, MediaType mediaType, MediaSaveCallback callback)
	{
		Permission num = RequestPermission(PermissionType.Write);
		if (num == Permission.Granted)
		{
			if (mediaBytes == null || mediaBytes.Length == 0)
			{
				throw new ArgumentException("Parameter 'mediaBytes' is null or empty!");
			}
			if (album == null || album.Length == 0)
			{
				throw new ArgumentException("Parameter 'album' is null or empty!");
			}
			if (filename == null || filename.Length == 0)
			{
				throw new ArgumentException("Parameter 'filename' is null or empty!");
			}
			if (string.IsNullOrEmpty(Path.GetExtension(filename)))
			{
				Debug.LogWarning("'filename' doesn't have an extension, this might result in unexpected behaviour!");
			}
			string temporarySavePath = GetTemporarySavePath(filename);
			File.WriteAllBytes(temporarySavePath, mediaBytes);
			SaveToGalleryInternal(temporarySavePath, album, mediaType, callback);
		}
		return num;
	}

	private static Permission SaveToGallery(string existingMediaPath, string album, string filename, MediaType mediaType, MediaSaveCallback callback)
	{
		Permission num = RequestPermission(PermissionType.Write);
		if (num == Permission.Granted)
		{
			if (!File.Exists(existingMediaPath))
			{
				throw new FileNotFoundException("File not found at " + existingMediaPath);
			}
			if (album == null || album.Length == 0)
			{
				throw new ArgumentException("Parameter 'album' is null or empty!");
			}
			if (filename == null || filename.Length == 0)
			{
				throw new ArgumentException("Parameter 'filename' is null or empty!");
			}
			if (string.IsNullOrEmpty(Path.GetExtension(filename)))
			{
				string extension = Path.GetExtension(existingMediaPath);
				if (string.IsNullOrEmpty(extension))
				{
					Debug.LogWarning("'filename' doesn't have an extension, this might result in unexpected behaviour!");
				}
				else
				{
					filename += extension;
				}
			}
			string temporarySavePath = GetTemporarySavePath(filename);
			File.Copy(existingMediaPath, temporarySavePath, overwrite: true);
			SaveToGalleryInternal(temporarySavePath, album, mediaType, callback);
		}
		return num;
	}

	private static void SaveToGalleryInternal(string path, string album, MediaType mediaType, MediaSaveCallback callback)
	{
		callback?.Invoke(success: true, null);
	}

	private static string GetTemporarySavePath(string filename)
	{
		string text = Path.Combine(Application.persistentDataPath, "NGallery");
		Directory.CreateDirectory(text);
		return Path.Combine(text, filename);
	}

	private static Permission GetMediaFromGallery(MediaPickCallback callback, MediaType mediaType, string mime, string title)
	{
		Permission num = RequestPermission(PermissionType.Read);
		if (num == Permission.Granted && !IsMediaPickerBusy())
		{
			callback?.Invoke(null);
		}
		return num;
	}

	private static Permission GetMultipleMediaFromGallery(MediaPickMultipleCallback callback, MediaType mediaType, string mime, string title)
	{
		Permission num = RequestPermission(PermissionType.Read);
		if (num == Permission.Granted && !IsMediaPickerBusy())
		{
			if (CanSelectMultipleFilesFromGallery())
			{
				if (callback != null)
				{
					callback(null);
					return num;
				}
			}
			else
			{
				callback?.Invoke(null);
			}
		}
		return num;
	}

	private static byte[] GetTextureBytes(Texture2D texture, bool isJpeg)
	{
		try
		{
			return isJpeg ? texture.EncodeToJPG(100) : texture.EncodeToPNG();
		}
		catch (UnityException)
		{
			return GetTextureBytesFromCopy(texture, isJpeg);
		}
		catch (ArgumentException)
		{
			return GetTextureBytesFromCopy(texture, isJpeg);
		}
	}

	private static byte[] GetTextureBytesFromCopy(Texture2D texture, bool isJpeg)
	{
		Debug.LogWarning("Saving non-readable textures is slower than saving readable textures");
		Texture2D texture2D = null;
		RenderTexture temporary = RenderTexture.GetTemporary(texture.width, texture.height);
		RenderTexture active = RenderTexture.active;
		try
		{
			Graphics.Blit(texture, temporary);
			RenderTexture.active = temporary;
			texture2D = new Texture2D(texture.width, texture.height, isJpeg ? TextureFormat.RGB24 : TextureFormat.RGBA32, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, texture.width, texture.height), 0, 0, recalculateMipMaps: false);
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: false);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			UnityEngine.Object.DestroyImmediate(texture2D);
			return null;
		}
		finally
		{
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
		}
		try
		{
			return isJpeg ? texture2D.EncodeToJPG(100) : texture2D.EncodeToPNG();
		}
		catch (Exception exception2)
		{
			Debug.LogException(exception2);
			return null;
		}
		finally
		{
			UnityEngine.Object.DestroyImmediate(texture2D);
		}
	}

	public static Texture2D LoadImageAtPath(string imagePath, int maxSize = -1, bool markTextureNonReadable = true, bool generateMipmaps = true, bool linearColorSpace = false)
	{
		if (string.IsNullOrEmpty(imagePath))
		{
			throw new ArgumentException("Parameter 'imagePath' is null or empty!");
		}
		if (!File.Exists(imagePath))
		{
			throw new FileNotFoundException("File not found at " + imagePath);
		}
		if (maxSize <= 0)
		{
			maxSize = SystemInfo.maxTextureSize;
		}
		string text = Path.GetExtension(imagePath).ToLowerInvariant();
		TextureFormat textureFormat = ((text == ".jpg" || text == ".jpeg") ? TextureFormat.RGB24 : TextureFormat.RGBA32);
		Texture2D texture2D = new Texture2D(2, 2, textureFormat, generateMipmaps, linearColorSpace);
		try
		{
			if (!texture2D.LoadImage(File.ReadAllBytes(imagePath), markTextureNonReadable))
			{
				UnityEngine.Object.DestroyImmediate(texture2D);
				return null;
			}
			return texture2D;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			UnityEngine.Object.DestroyImmediate(texture2D);
			return null;
		}
		finally
		{
			if (imagePath != imagePath)
			{
				try
				{
					File.Delete(imagePath);
				}
				catch
				{
				}
			}
		}
	}

	public static Texture2D GetVideoThumbnail(string videoPath, int maxSize = -1, double captureTimeInSeconds = -1.0, bool markTextureNonReadable = true)
	{
		if (maxSize <= 0)
		{
			maxSize = SystemInfo.maxTextureSize;
		}
		string text = null;
		if (!string.IsNullOrEmpty(text))
		{
			return LoadImageAtPath(text, maxSize, markTextureNonReadable);
		}
		return null;
	}

	public static ImageProperties GetImageProperties(string imagePath)
	{
		if (!File.Exists(imagePath))
		{
			throw new FileNotFoundException("File not found at " + imagePath);
		}
		string text = null;
		int result = 0;
		int result2 = 0;
		string text2 = null;
		ImageOrientation orientation = ImageOrientation.Unknown;
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split('>');
			if (array != null && array.Length >= 4)
			{
				if (!int.TryParse(array[0].Trim(), out result))
				{
					result = 0;
				}
				if (!int.TryParse(array[1].Trim(), out result2))
				{
					result2 = 0;
				}
				text2 = array[2].Trim();
				if (text2.Length == 0)
				{
					switch (Path.GetExtension(imagePath).ToLowerInvariant())
					{
					case ".png":
						text2 = "image/png";
						break;
					case ".jpg":
					case ".jpeg":
						text2 = "image/jpeg";
						break;
					case ".gif":
						text2 = "image/gif";
						break;
					case ".bmp":
						text2 = "image/bmp";
						break;
					default:
						text2 = null;
						break;
					}
				}
				if (int.TryParse(array[3].Trim(), out var result3))
				{
					orientation = (ImageOrientation)result3;
				}
			}
		}
		return new ImageProperties(result, result2, text2, orientation);
	}

	public static VideoProperties GetVideoProperties(string videoPath)
	{
		if (!File.Exists(videoPath))
		{
			throw new FileNotFoundException("File not found at " + videoPath);
		}
		string text = null;
		int result = 0;
		int result2 = 0;
		long result3 = 0L;
		float result4 = 0f;
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split('>');
			if (array != null && array.Length >= 4)
			{
				if (!int.TryParse(array[0].Trim(), out result))
				{
					result = 0;
				}
				if (!int.TryParse(array[1].Trim(), out result2))
				{
					result2 = 0;
				}
				if (!long.TryParse(array[2].Trim(), out result3))
				{
					result3 = 0L;
				}
				if (!float.TryParse(array[3].Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out result4))
				{
					result4 = 0f;
				}
			}
		}
		if (result4 == -90f)
		{
			result4 = 270f;
		}
		return new VideoProperties(result, result2, result3, result4);
	}
}
