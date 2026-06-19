using UnityEngine;

[ExecuteInEditMode]
public class ShaderTesting : MonoBehaviour
{
	public Material mat;

	private void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, mat);
	}
}
