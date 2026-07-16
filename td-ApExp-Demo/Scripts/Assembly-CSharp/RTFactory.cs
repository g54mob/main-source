using UnityEngine;

public static class RTFactory
{
	public static RenderTexture CreateRT(int width, int height)
	{
		RenderTexture renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
		renderTexture.antiAliasing = 1;
		renderTexture.useMipMap = false;
		renderTexture.autoGenerateMips = false;
		renderTexture.enableRandomWrite = false;
		renderTexture.name = "RuntimeRT_" + width + "x" + height;
		renderTexture.Create();
		return renderTexture;
	}
}
