using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MobileMediaTest : DImageDisplayHandler
{
	public CanvasScaler canvasScaler;

	public Image displayImage;

	public Toggle tog_Popup;

	public Text debugText;

	private string hints = "Mobile Media Plugin Demo\nTo test save/pick media to/from Native, please build Android, iOS app and test on device.\n\n";

	private void Start()
	{
		debugText.text = hints;
		if (Screen.width > Screen.height)
		{
			canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
		}
		else
		{
			canvasScaler.referenceResolution = new Vector2(1080f, 1920f);
		}
	}

	public void GetPhotoThumbnail_iOS(DImageDisplayHandler imageHandler)
	{
		Image getImage = imageHandler.GetComponent<Image>();
		int mediaType = 2;
		int mediaIndex = 0;
		int targetSize = 0;
		MobileMedia.GetMediaPreviewPhoto_IOS(delegate(string imagePath)
		{
			if (!string.IsNullOrEmpty(imagePath))
			{
				Debug.Log("Image Path: " + imagePath);
				debugText.text = hints + "Image Path: " + imagePath;
				Texture2D texture2D = new FilePathName().LoadImage(imagePath);
				if ((bool)texture2D)
				{
					imageHandler.SetImage(getImage, texture2D);
				}
			}
			else
			{
				debugText.text = hints + "Path is empty or null.";
				Debug.Log("Path is empty or null.");
			}
		}, mediaType, mediaIndex, targetSize, "thumbnail_temp");
	}

	public void PickImage()
	{
		MobileMedia.PickImage(delegate(string imagePath)
		{
			if (!string.IsNullOrEmpty(imagePath))
			{
				byte[] data = File.ReadAllBytes(imagePath);
				Texture2D texture2D = new Texture2D(1, 1, TextureFormat.ARGB32, mipChain: false);
				texture2D.LoadImage(data);
				_ShowImage(_ToSprite(texture2D));
				Debug.Log("Image Path: " + imagePath);
				debugText.text = hints + "Image Path: " + imagePath;
			}
			else
			{
				debugText.text = hints + "Path is empty or null.";
				Debug.Log("Path is empty or null.");
			}
		}, "Pick an Image", "image/*", tog_Popup.isOn);
	}

	public void PickVideo()
	{
		MobileMedia.PickVideo(delegate(string videoPath)
		{
			if (!string.IsNullOrEmpty(videoPath))
			{
				Debug.Log("Video Path: " + videoPath);
				debugText.text = hints + "Video Path: " + videoPath;
			}
			else
			{
				Debug.Log("Path is empty or null.");
			}
		}, "Pick a Video", "video/*", tog_Popup.isOn);
	}

	public void SaveJPG()
	{
		TakeScreenshot(delegate(Texture2D tex2D)
		{
			string text = MobileMedia.SaveImage(tex2D, "MobileMediaTest", new FilePathName().GetJpgFileName());
			_ShowImage(_ToSprite(tex2D));
			debugText.text = hints + "Save Path: " + text;
			Debug.Log("Save Path: " + text);
		});
	}

	public void SavePNG()
	{
		TakeScreenshot(delegate(Texture2D tex2D)
		{
			string text = MobileMedia.SaveImage(tex2D, "MobileMediaTest", new FilePathName().GetPngFileName(), MobileMedia.ImageFormat.PNG);
			_ShowImage(_ToSprite(tex2D));
			debugText.text = hints + "Save Path: " + text;
			Debug.Log("Save Path: " + text);
		});
	}

	public void SaveGIF()
	{
		string filePath = Path.Combine(Application.streamingAssetsPath, "SampleGIF.gif");
		if (!File.Exists(filePath))
		{
			Debug.LogWarning("To test save GIF file to Native. Put your GIF file in the Assets/StreamingAssets folder and rename it to SampleGIF.gif.");
			return;
		}
		string text = hints + "(SaveGIF) Origin file path: " + filePath;
		debugText.text = text;
		FilePathName filePathName = new FilePathName();
		StartCoroutine(filePathName.LoadFileUWR(filePath, delegate(byte[] bytes)
		{
			string text2 = MobileMedia.SaveBytes(bytes, "MobileMediaTest", Path.GetFileNameWithoutExtension(filePath), Path.GetExtension(filePath).ToLower(), isImage: true);
			Text text3 = debugText;
			text3.text = text3.text + "\n\nSave path: " + text2;
		}));
	}

	public void ConvertToGIF()
	{
		TakeScreenshot(delegate(Texture2D tex2D)
		{
			string text = MobileMedia.SaveImage(tex2D, "MobileMediaTest", new FilePathName().GetGifFileName(), MobileMedia.ImageFormat.GIF);
			_ShowImage(_ToSprite(tex2D));
			debugText.text = hints + "Save Path: " + text;
			Debug.Log("Save Path: " + text);
		});
	}

	public void SaveMP4()
	{
		string filePath = Path.Combine(Application.streamingAssetsPath, "SampleMP4.mp4");
		if (!File.Exists(filePath))
		{
			Debug.LogWarning("To test save MP4 file to Native. Put your MP4 file in the Assets/StreamingAssets folder and rename it to SampleMP4.mp4.");
			return;
		}
		string text = hints + "(SaveMP4) Origin file path: " + filePath;
		debugText.text = text;
		FilePathName filePathName = new FilePathName();
		StartCoroutine(filePathName.LoadFileUWR(filePath, delegate(byte[] bytes)
		{
			string text2 = MobileMedia.SaveBytes(bytes, "MobileMediaTest", Path.GetFileNameWithoutExtension(filePath), Path.GetExtension(filePath).ToLower(), isImage: false);
			Text text3 = debugText;
			text3.text = text3.text + "\n\nSave path: " + text2;
		}));
	}

	private void _ShowImage(Sprite sprite)
	{
		SetImage(displayImage, sprite);
	}

	public void MoreAssetsAndDocuments()
	{
		Application.OpenURL("https://www.swanob2.com/assets");
	}

	public void TakeScreenshot(Action<Texture2D> onComplete)
	{
		StartCoroutine(_TakeScreenshot(onComplete));
	}

	private IEnumerator _TakeScreenshot(Action<Texture2D> onComplete)
	{
		yield return new WaitForEndOfFrame();
		int width = Screen.width;
		int height = Screen.height;
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
		Rect source = new Rect(0f, 0f, width, height);
		texture2D.ReadPixels(source, 0, 0);
		texture2D.Apply();
		onComplete(texture2D);
	}

	private Sprite _ToSprite(Texture2D texture)
	{
		if (texture == null)
		{
			return null;
		}
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		float pixelsPerUnit = 100f;
		return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), pivot, pixelsPerUnit);
	}
}
