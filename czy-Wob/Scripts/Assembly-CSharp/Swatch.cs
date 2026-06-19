using UnityEngine;

public class Swatch : MonoBehaviour
{
	public Renderer swatchRendererTiling;

	public Renderer swatchRendererNontiling;

	public void AssignMaterial(Material m, bool tiling, bool carpet)
	{
		swatchRendererTiling.gameObject.SetActive(tiling);
		swatchRendererNontiling.gameObject.SetActive(!tiling);
		Renderer renderer = swatchRendererTiling;
		if (!tiling)
		{
			renderer = swatchRendererNontiling;
		}
		renderer.material = m;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		renderer.GetPropertyBlock(materialPropertyBlock);
		if (tiling)
		{
			materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, 0f, 0f));
		}
		else if (carpet)
		{
			materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, 0.5f, 0.5f));
		}
		else
		{
			materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(0.5f, 0.5f, 0f, 0.5f));
		}
		renderer.SetPropertyBlock(materialPropertyBlock);
	}
}
