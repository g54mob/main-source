using UnityEngine;

[ExecuteInEditMode]
public class CameraDotOverlay : ImageEffectBase
{
	public Texture DotTexture;

	public float DotTextureDensity = 1f;

	public Color Color1 = Color.red;

	public Color Color2 = Color.green;

	public Color Color3 = Color.blue;

	public Color Color4 = Color.white;

	public bool DebugShowOriginal;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (DotTexture != null)
		{
			base.material.SetTexture("_DotTex", DotTexture);
		}
		else
		{
			Debug.Log("No/Invalid Noise Texture!");
		}
		base.material.SetFloat("_DotDensity", DotTextureDensity);
		base.material.SetColor("_Color1", Color1);
		base.material.SetColor("_Color2", Color2);
		base.material.SetColor("_Color3", Color3);
		base.material.SetColor("_Color4", Color4);
		if (DebugShowOriginal)
		{
			base.material.SetFloat("_ShowOriginal", 1f);
		}
		else
		{
			base.material.SetFloat("_ShowOriginal", 0f);
		}
		Graphics.Blit(src, dest, base.material);
	}
}
