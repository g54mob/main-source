using UnityEngine;

[ExecuteInEditMode]
public class ScreenSpaceGradient : MonoBehaviour
{
	public Texture2D SnowTexture;

	public Color SnowColor = Color.white;

	public float SnowTextureScale = 0.1f;

	[Range(0f, 1f)]
	public float BottomThreshold;

	[Range(0f, 1f)]
	public float TopThreshold = 1f;

	private Material material;

	private void OnEnable()
	{
		material = new Material(Shader.Find("Minamolc/ScreenSpaceGradient"));
		GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		material.SetMatrix("_CamToWorld", GetComponent<Camera>().cameraToWorldMatrix);
		material.SetColor("_SnowColor", SnowColor);
		material.SetFloat("_BottomThreshold", BottomThreshold);
		material.SetFloat("_TopThreshold", TopThreshold);
		material.SetTexture("_SnowTex", SnowTexture);
		material.SetFloat("_SnowTexScale", SnowTextureScale);
		Graphics.Blit(src, dest, material);
	}
}
