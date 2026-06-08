using UnityEngine;

[ExecuteInEditMode]
public class CameraTextureBomb : ImageEffectBase
{
	public static CameraTextureBomb Instance;

	public Texture2D sourceTexture;

	public Texture2D randomTexture;

	[Tooltip("The number of texture cells in the source texture.")]
	public int numberOfTexturesInSource = 5;

	[Tooltip("The scale of the uv coords in the source texture.\r\n\r\nNote that this is different than the scale for the results, which is defined by the user of the output.")]
	public float sourceUVScale = 160f;

	private void OnDestroy()
	{
		base.material.SetTexture("_SourceTex", null);
		base.material.SetTexture("_RandomTex", null);
		sourceTexture = null;
		randomTexture = null;
	}

	private void OnPreRender()
	{
		Instance = this;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetTexture("_SourceTex", sourceTexture);
		base.material.SetTexture("_RandomTex", randomTexture);
		base.material.SetFloat("_NumberOfImages", numberOfTexturesInSource);
		base.material.SetFloat("_ScaleOfSource", sourceUVScale);
		Graphics.Blit(src, dest, base.material);
	}
}
