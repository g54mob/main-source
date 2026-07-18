using System;
using UnityEngine;
using UnityEngine.UI;

public class PixelatedCamera : MonoBehaviour
{
	public enum PixelScreenMode
	{
		Resize = 0,
		Scale = 1
	}

	[Serializable]
	public struct ScreenSize
	{
		public int width;

		public int height;
	}

	public static PixelatedCamera main;

	private Camera renderCamera;

	private RenderTexture renderTexture;

	private int screenWidth;

	private int screenHeight;

	[Header("Screen scaling settings")]
	public PixelScreenMode mode;

	public ScreenSize targetScreenSize = new ScreenSize
	{
		width = 256,
		height = 144
	};

	public uint screenScaleFactor = 1u;

	[Header("Display")]
	public RawImage display;

	private void Awake()
	{
		if (main == null)
		{
			main = this;
		}
	}

	private void Start()
	{
		Init();
	}

	private void Update()
	{
		if (CheckScreenResize())
		{
			Init();
		}
	}

	public void Init()
	{
		if (!renderCamera)
		{
			renderCamera = GetComponent<Camera>();
		}
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		if (screenScaleFactor < 1)
		{
			screenScaleFactor = 1u;
		}
		if (targetScreenSize.width < 1)
		{
			targetScreenSize.width = 1;
		}
		if (targetScreenSize.height < 1)
		{
			targetScreenSize.height = 1;
		}
		int width = ((mode == PixelScreenMode.Resize) ? targetScreenSize.width : (screenWidth / (int)screenScaleFactor));
		int height = ((mode == PixelScreenMode.Resize) ? targetScreenSize.height : (screenHeight / (int)screenScaleFactor));
		renderTexture = new RenderTexture(width, height, 24)
		{
			filterMode = FilterMode.Point,
			antiAliasing = 1
		};
		renderCamera.targetTexture = renderTexture;
		display.texture = renderTexture;
	}

	public bool CheckScreenResize()
	{
		if (Screen.width == screenWidth)
		{
			return Screen.height != screenHeight;
		}
		return true;
	}
}
