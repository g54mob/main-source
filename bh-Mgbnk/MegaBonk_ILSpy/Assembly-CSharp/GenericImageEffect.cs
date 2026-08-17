using UnityEngine;

public class GenericImageEffect : MonoBehaviour
{
	public Material material;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (!(material != null))
		{
			Graphics.Blit(src, dest);
		}
		else
		{
			Graphics.Blit(src, dest, material);
		}
	}
}
