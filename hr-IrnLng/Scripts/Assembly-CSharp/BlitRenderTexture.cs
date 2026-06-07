using UnityEngine;

[ExecuteInEditMode]
public class BlitRenderTexture : MonoBehaviour
{
	public RenderTexture BlitTex;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (BlitTex != null)
		{
			Graphics.Blit(BlitTex, dest);
		}
	}
}
