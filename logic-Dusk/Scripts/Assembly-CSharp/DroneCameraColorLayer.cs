using UnityEngine;

[ExecuteInEditMode]
public class DroneCameraColorLayer : ImageEffectBase
{
	public bool InvertYAxis;

	public float ColorGradiantFactor = 30f;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetFloat("_GradFact", ColorGradiantFactor);
		base.material.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		Graphics.Blit(src, dest, base.material);
	}
}
