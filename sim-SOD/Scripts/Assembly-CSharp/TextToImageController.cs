using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class TextToImageController : MonoBehaviour
{
	[Serializable]
	public class TextToImageSettings
	{
		public string textString;

		public float textSize;

		public TMP_FontAsset font;

		public bool enableProcessing;

		public float contrast;

		public bool trim;

		public int trimPadding;

		public bool useAlpha;

		public Color color;
	}

	[Header("Components")]
	public RectTransform captureTextCanvasRect;

	public TextMeshProUGUI captureText;

	public Material newsTickerMaterial;

	public TMP_FontAsset newsTickerFont;

	public float newsTickerFontSize;

	public float newsTickerDivider;

	public float newsTickerSpeedDivider;

	[Header("Settings")]
	public bool saveDebugScreenshot;

	public Vector2 maxSize;

	public TextToImageSettings defaultSettings;

	[Header("Preview")]
	public string lastText;

	[ReadOnly]
	public float lastFontSize;

	[ReadOnly]
	public Vector2 lastDimenstions;

	[ShowAssetPreview(64, 64)]
	public Texture2D currentShot;

	[ShowAssetPreview(64, 64)]
	public Texture2D tickerImg;

	private static TextToImageController _instance;

	public static TextToImageController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public Texture2D CaptureTextToImage(TextToImageSettings settings = null, bool returnReadOnly = true)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateNewsTickerHeadline(string newString = "")
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ProcessImage(TextToImageSettings settings = null)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SavePNG()
	{
	}
}
