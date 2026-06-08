using UnityEngine;

[ExecuteInEditMode]
public class CameraMultiChannelDepthEffect : ImageEffectBase
{
	public bool disableBanding;

	protected override void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
	}

	private void OnDestroy()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
		if (disableBanding)
		{
			base.material.SetFloat("_DisableBanding", 1f);
		}
		else
		{
			base.material.SetFloat("_DisableBanding", 0f);
		}
		Graphics.Blit(src, dest, base.material);
	}
}
