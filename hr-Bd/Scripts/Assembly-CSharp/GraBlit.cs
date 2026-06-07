using UnityEngine;

[ExecuteInEditMode]
public class GraBlit : MonoBehaviour
{
	[SerializeField]
	private Material mat;

	private float size;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
		Graphics.Blit(src, temporary, mat, 0);
		RenderTexture temporary2 = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
		Graphics.Blit(temporary, temporary2, mat, 1);
		RenderTexture.ReleaseTemporary(temporary);
		temporary = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
		Graphics.Blit(temporary2, temporary, mat, 2);
		RenderTexture.ReleaseTemporary(temporary2);
		Graphics.Blit(temporary, dest, mat, 3);
		RenderTexture.ReleaseTemporary(temporary);
	}
}
