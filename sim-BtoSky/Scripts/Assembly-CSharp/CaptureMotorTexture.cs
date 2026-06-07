using UnityEngine;

public class CaptureMotorTexture : MonoBehaviour
{
	public Camera captureCamera;

	public int resolution = 512;

	public void CaptureAndSaveAsSprite(string fileName)
	{
		RenderTexture renderTexture = new RenderTexture(resolution, resolution, 24, RenderTextureFormat.ARGB32);
		captureCamera.targetTexture = renderTexture;
		captureCamera.Render();
		RenderTexture.active = renderTexture;
		Texture2D texture2D = new Texture2D(resolution, resolution, TextureFormat.ARGB32, mipChain: false);
		texture2D.ReadPixels(new Rect(0f, 0f, resolution, resolution), 0, 0);
		texture2D.Apply();
		ES3.SaveImage(texture2D, fileName + ".png");
		captureCamera.targetTexture = null;
		RenderTexture.active = null;
		Object.Destroy(renderTexture);
		Object.Destroy(texture2D);
	}
}
