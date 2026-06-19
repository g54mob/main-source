using UnityEngine;

[ExecuteInEditMode]
public class PP_BlackBorders : PP_Base
{
	public float letterboxWidth = 0.01f;

	public float letterboxHeight = 0.01f;

	public float aspectRatio = 1.7777778f;

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		base.material.SetFloat("_Width", letterboxWidth);
		base.material.SetFloat("_Height", letterboxHeight);
		base.material.SetFloat("_Aspect", aspectRatio);
		Graphics.Blit(sourceTexture, destTexture, base.material);
	}
}
