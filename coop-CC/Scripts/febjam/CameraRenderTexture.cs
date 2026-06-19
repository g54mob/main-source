using Aggro.Core;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class CameraRenderTexture : AggroManagerBase<CameraRenderTexture>
{
	private RTHandle _rtHandle;

	private float _prevRenderScale;

	private int _prevScreenWidth;

	private int _prevScreenHeight;

	public RTHandle rtHandle => _rtHandle;

	protected override void OnEntityCreated()
	{
		CreateRenderTexture();
	}

	protected override void OnEntityDestroyed()
	{
		if (_rtHandle != null)
		{
			_rtHandle.Release();
			_rtHandle = null;
		}
	}

	private void CreateRenderTexture()
	{
		if (_rtHandle != null)
		{
			_rtHandle.Release();
			_rtHandle = null;
		}
		RenderTextureDescriptor desc = new RenderTextureDescriptor
		{
			dimension = TextureDimension.Tex2D,
			width = Mathf.CeilToInt(Options.renderScale * (float)Screen.width),
			height = Mathf.CeilToInt(Options.renderScale * (float)Screen.height),
			sRGB = true,
			colorFormat = RenderTextureFormat.ARGB32,
			depthStencilFormat = GraphicsFormat.D32_SFloat_S8_UInt,
			msaaSamples = 4,
			volumeDepth = 1
		};
		RenderTexture renderTexture = new RenderTexture(desc);
		renderTexture.name = $"Scaled Texture ({desc.width}x{desc.height})";
		GetComponent<Camera>().targetTexture = renderTexture;
		_rtHandle = RTHandles.Alloc(renderTexture);
		_prevRenderScale = Options.renderScale;
		_prevScreenWidth = Screen.width;
		_prevScreenHeight = Screen.height;
	}

	protected override void OnUpdatePresentation()
	{
		if (_prevRenderScale != Options.renderScale || _prevScreenWidth != Screen.width || _prevScreenHeight != Screen.height)
		{
			CreateRenderTexture();
		}
	}
}
