using UnityEngine;

[ExecuteInEditMode]
public class CameraTextureWhereViewed : ImageEffectBase
{
	public Texture2D textureWhenLit;

	public RenderTexture maskRT;

	public LayerMask cameraLayerMaskOverride;

	public Color textureTint = Color.green;

	public Color textureTintInCone = Color.green;

	public bool showTextureInCone;

	private LayerMask originalLayerMaskOverride;

	public void OnPreCull()
	{
		originalLayerMaskOverride = GetComponent<Camera>().cullingMask;
		GetComponent<Camera>().cullingMask = cameraLayerMaskOverride;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (textureWhenLit != null)
		{
			base.material.SetTexture("_OutputTex", textureWhenLit);
		}
		if (maskRT != null)
		{
			base.material.SetTexture("_MaskTex", maskRT);
		}
		base.material.SetFloat("_CamOffsetPosX", GetComponent<Camera>().transform.position.x);
		base.material.SetFloat("_CamOffsetPosY", GetComponent<Camera>().transform.position.y);
		base.material.SetColor("_ColorOfOutput", textureTint);
		base.material.SetColor("_ColorOfOutputInCone", textureTintInCone);
		if (showTextureInCone)
		{
			base.material.SetFloat("_IncludeInCone", 1f);
		}
		else
		{
			base.material.SetFloat("_IncludeInCone", 0f);
		}
		Graphics.Blit(src, dest, base.material);
	}

	private void OnPostRender()
	{
		GetComponent<Camera>().cullingMask = originalLayerMaskOverride;
	}
}
