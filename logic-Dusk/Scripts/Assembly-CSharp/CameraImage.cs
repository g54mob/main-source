using UnityEngine;

public class CameraImage : ImageEffectBase
{
	public RenderTexture rtToDisplay;

	public Texture2D imageToDisplay2;

	private void OnPostRender()
	{
		Graphics.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), imageToDisplay2);
	}
}
