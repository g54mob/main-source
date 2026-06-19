using UnityEngine;

[ExecuteAlways]
public class CustomPostProcessing : MonoBehaviour
{
	public Material material;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, material);
	}
}
