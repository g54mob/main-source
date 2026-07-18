using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/PixelBoy")]
public class PixelBoy : MonoBehaviour
{
	public int w = 720;

	private int h;

	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		float num = (float)Camera.main.pixelHeight / (float)Camera.main.pixelWidth;
		h = Mathf.RoundToInt((float)w * num);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		source.filterMode = FilterMode.Point;
		RenderTexture temporary = RenderTexture.GetTemporary(w, h, -1);
		temporary.filterMode = FilterMode.Point;
		Graphics.Blit(source, temporary);
		Graphics.Blit(temporary, destination);
		RenderTexture.ReleaseTemporary(temporary);
	}
}
