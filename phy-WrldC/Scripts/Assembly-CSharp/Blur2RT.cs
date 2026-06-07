using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Blur2RT : BlurOptimized
{
	public RenderTexture renderTexture;

	public bool renderTextureOnly = true;

	private new void Start()
	{
		base.Start();
		blurShader = Shader.Find("Hidden/FastBlur");
		if (blurShader == null)
		{
			base.enabled = false;
		}
	}

	public new void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (renderTexture != null)
		{
			base.OnRenderImage(source, renderTexture);
		}
		if (renderTextureOnly)
		{
			Graphics.Blit(source, destination);
		}
		else if (renderTexture == null)
		{
			base.OnRenderImage(source, destination);
		}
		else
		{
			Graphics.Blit(renderTexture, destination);
		}
	}
}
