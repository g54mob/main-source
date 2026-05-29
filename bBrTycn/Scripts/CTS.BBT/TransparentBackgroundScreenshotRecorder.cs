using System;
using System.Collections;
using System.IO;
using NaughtyAttributes;
using UnityEngine;

public class TransparentBackgroundScreenshotRecorder : MonoBehaviour
{
	[Tooltip("A folder will be created with this base name in your project root")]
	public string folderBaseName = "Screenshots";

	[SerializeField]
	private int nameNumber;

	private string _folderName = "";

	private Camera _whiteCam;

	private Camera _blackCam;

	private Camera _mainCam;

	private int _screenWidth;

	private int _screenHeight;

	private Texture2D _textureBlack;

	private Texture2D _textureWhite;

	private Texture2D _textureTransparentBackground;

	private bool _takeScreenshot;

	private void Awake()
	{
		_mainCam = base.gameObject.GetComponent<Camera>();
		if ((bool)_mainCam)
		{
			CreateBlackAndWhiteCameras();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			MonoBehaviour.print("Screenshot done");
			StartCoroutine(CaptureFrame());
		}
	}

	[Button(null, EButtonEnableMode.Always)]
	private void CaptureScreenShot()
	{
		if (Application.isPlaying && (bool)_mainCam)
		{
			StartCoroutine(CaptureFrame());
		}
	}

	private IEnumerator CaptureFrame()
	{
		yield return new WaitForEndOfFrame();
		CameraClearFlags clearFlags = _mainCam.clearFlags;
		_mainCam.clearFlags = CameraClearFlags.Color;
		CreateNewFolderForScreenshots();
		CacheAndInitialiseFields();
		RenderCamToTexture(_blackCam, _textureBlack);
		RenderCamToTexture(_whiteCam, _textureWhite);
		CalculateOutputTexture();
		SavePng();
		_mainCam.clearFlags = clearFlags;
		nameNumber++;
	}

	private void RenderCamToTexture(Camera cam, Texture2D tex)
	{
		cam.enabled = true;
		cam.Render();
		WriteScreenImageToTexture(tex);
		cam.enabled = false;
	}

	private void CreateBlackAndWhiteCameras()
	{
		GameObject gameObject = new GameObject
		{
			name = "White Background Camera"
		};
		_whiteCam = gameObject.AddComponent<Camera>();
		_whiteCam.CopyFrom(_mainCam);
		_whiteCam.clearFlags = CameraClearFlags.Color;
		_whiteCam.backgroundColor = Color.white;
		gameObject.transform.SetParent(base.gameObject.transform, worldPositionStays: true);
		_whiteCam.enabled = false;
		GameObject gameObject2 = new GameObject
		{
			name = "Black Background Camera"
		};
		_blackCam = gameObject2.AddComponent<Camera>();
		_blackCam.CopyFrom(_mainCam);
		_blackCam.clearFlags = CameraClearFlags.Color;
		_blackCam.backgroundColor = Color.black;
		gameObject2.transform.SetParent(base.gameObject.transform, worldPositionStays: true);
		_blackCam.enabled = false;
	}

	private void CreateNewFolderForScreenshots()
	{
		_folderName = folderBaseName;
		if (!Directory.Exists(_folderName))
		{
			Directory.CreateDirectory(_folderName);
		}
	}

	private void WriteScreenImageToTexture(Texture2D tex)
	{
		tex.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
		tex.Apply();
	}

	private void CalculateOutputTexture()
	{
		for (int i = 0; i < _textureTransparentBackground.height; i++)
		{
			for (int j = 0; j < _textureTransparentBackground.width; j++)
			{
				float num = _textureWhite.GetPixel(j, i).r - _textureBlack.GetPixel(j, i).r;
				num = 1f - num;
				Color color = ((num != 0f) ? (_textureBlack.GetPixel(j, i) / num) : Color.clear);
				color.a = num;
				_textureTransparentBackground.SetPixel(j, i, color);
			}
		}
	}

	private void SavePng()
	{
		string path = string.Format($"{_folderName}/shot_{DateTime.Now.ToBinary()}.png");
		byte[] bytes = _textureTransparentBackground.EncodeToPNG();
		File.WriteAllBytes(path, bytes);
	}

	private void CacheAndInitialiseFields()
	{
		_textureBlack = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, mipChain: false);
		_textureWhite = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, mipChain: false);
		_textureTransparentBackground = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, mipChain: false);
	}
}
