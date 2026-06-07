using UnityEngine;

public class RenderTarget
{
	public string Name;

	public RenderTexture Target;

	public RenderTargetDownSample DownSampled = RenderTargetDownSample.FULL;

	public Camera LinkedCamera;

	public event OnResizeDelegate OnResize;

	public RenderTarget(string name, RenderTargetDownSample downsampled, int renderedLayers, bool orthgraphicCamera, int depth, Camera mainCam)
	{
		Name = name;
		DownSampled = downsampled;
		Target = new RenderTexture(Screen.width / (int)DownSampled, Screen.height / (int)DownSampled, 24);
		Target.name = name;
		mainCam.cullingMask &= ~renderedLayers;
		if (orthgraphicCamera)
		{
			GameObject gameObject = new GameObject(name + "Camera");
			LinkedCamera = gameObject.AddComponent<Camera>();
			LinkedCamera.CopyFrom(mainCam);
			LinkedCamera.cullingMask = renderedLayers;
			LinkedCamera.depth = depth;
			LinkedCamera.targetTexture = Target;
			LinkedCamera.orthographic = true;
			LinkedCamera.clearFlags = CameraClearFlags.Color;
			LinkedCamera.depthTextureMode = DepthTextureMode.None;
			LinkedCamera.transform.parent = mainCam.transform;
			LinkedCamera.transform.localPosition = Vector3.zero;
			LinkedCamera.transform.localRotation = Quaternion.identity;
			LinkedCamera.transform.localScale = Vector3.one;
		}
		else
		{
			GameObject gameObject2 = new GameObject(name + "Camera");
			LinkedCamera = gameObject2.AddComponent<Camera>();
			LinkedCamera.CopyFrom(mainCam);
			LinkedCamera.cullingMask = renderedLayers;
			LinkedCamera.depth = depth;
			LinkedCamera.targetTexture = Target;
			LinkedCamera.orthographic = false;
			LinkedCamera.clearFlags = CameraClearFlags.Color;
			LinkedCamera.depthTextureMode = DepthTextureMode.None;
			LinkedCamera.transform.parent = mainCam.transform;
		}
	}

	public void ReSize()
	{
		RenderTexture renderTexture = new RenderTexture(Screen.width / (int)DownSampled, Screen.height / (int)DownSampled, 24);
		renderTexture.anisoLevel = Target.anisoLevel;
		renderTexture.antiAliasing = Target.antiAliasing;
		renderTexture.depth = Target.depth;
		renderTexture.enableRandomWrite = Target.enableRandomWrite;
		renderTexture.filterMode = Target.filterMode;
		renderTexture.format = Target.format;
		renderTexture.autoGenerateMips = Target.autoGenerateMips;
		renderTexture.hideFlags = Target.hideFlags;
		renderTexture.dimension = Target.dimension;
		renderTexture.isPowerOfTwo = Target.isPowerOfTwo;
		renderTexture.dimension = Target.dimension;
		renderTexture.mipMapBias = Target.mipMapBias;
		renderTexture.name = Target.name;
		renderTexture.useMipMap = Target.useMipMap;
		renderTexture.volumeDepth = Target.volumeDepth;
		renderTexture.wrapMode = Target.wrapMode;
		Target.Release();
		Target = renderTexture;
		LinkedCamera.targetTexture = Target;
		if (this.OnResize != null)
		{
			this.OnResize(this);
		}
	}

	public void Update()
	{
		if (LinkedCamera.orthographic)
		{
			LinkedCamera.transform.position = new Vector3(0f, 100f, 0f);
			LinkedCamera.transform.rotation = Quaternion.LookRotation(Vector3.down);
		}
	}
}
