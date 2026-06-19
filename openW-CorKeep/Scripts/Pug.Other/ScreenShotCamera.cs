using System;
using System.Collections;
using UnityEngine;

public class ScreenShotCamera : MonoBehaviour
{
	public Camera Cam;

	private const int size = 512;

	private Texture2D texture;

	private Vector2 worldPosition;

	private Action<byte[]> callback;

	private Action preScreenshotCallback;

	private void Awake()
	{
		texture = new Texture2D(512, 512);
	}

	public void GetScreenshot(Vector2 worldPosition, Action<byte[]> callback, Action preScreenshotCallback)
	{
		this.worldPosition = worldPosition;
		this.callback = callback;
		this.preScreenshotCallback = preScreenshotCallback;
		StartCoroutine(ScreenshotRoutine());
	}

	public IEnumerator ScreenshotRoutine()
	{
		yield return new WaitForEndOfFrame();
		if (preScreenshotCallback != null)
		{
			preScreenshotCallback();
		}
		Vector3 position = Manager.camera.gameCamera.transform.position;
		Manager.camera.gameCamera.transform.position = new Vector3(worldPosition.x, worldPosition.y, Manager.camera.gameCamera.transform.position.z);
		Manager.camera.gameCamera.Render();
		Manager.camera.gameCamera.transform.position = position;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = Cam.targetTexture;
		Cam.Render();
		int num = Cam.targetTexture.width / 2 - 256;
		int num2 = Cam.targetTexture.height / 2 - 256;
		texture.ReadPixels(new Rect(num, num2, 512f, 512f), 0, 0);
		texture.Apply();
		RenderTexture.active = active;
		callback(texture.EncodeToJPG(50));
	}
}
