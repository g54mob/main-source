using UnityEngine;

[ExecuteInEditMode]
public class CameraSonarEffect : ImageEffectBase
{
	[Tooltip("The speed the line moves as a percentage (0 - 1)")]
	public float lineSpeed = 1f;

	[Tooltip("Thickness of the line")]
	public float lineThickness = 0.05f;

	private float ringRadius = 0.1f;

	private void onPreRender()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		ringRadius += 1f * Time.deltaTime * lineSpeed;
		if (ringRadius > 1f)
		{
			ringRadius = 0.1f;
		}
		base.material.SetFloat("_Radius", ringRadius);
		base.material.SetFloat("_RadiusThick", lineThickness);
		Graphics.Blit(src, dest, base.material);
	}
}
