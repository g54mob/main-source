using UnityEngine;

[ExecuteInEditMode]
public class DroneEyes : ImageEffectBase
{
	public Material DepthMapMaterial;

	public bool InvertYAxis;

	protected override void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		base.Start();
	}

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		DepthMapMaterial.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		Graphics.Blit(src, dest, DepthMapMaterial);
	}
}
