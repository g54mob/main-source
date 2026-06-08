using UnityEngine;

[ExecuteInEditMode]
public class CameraStarSystemOverlay : ImageEffectBase
{
	public string ID = "[set to unique value]";

	public Texture StarTexture;

	public Texture StarThickTexture;

	public Texture StarMedTexture;

	public Texture StarThinTexture;

	public Texture CutoutTexture;

	public Color StarColor = Color.white;

	public float VisibilityFactor = 1f;

	public bool AlphaFromImage;

	public bool InvertYAxis;

	private void OnDestroy()
	{
		StarThickTexture = null;
		StarMedTexture = null;
		StarThinTexture = null;
		CutoutTexture = null;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetFloat("_AlphaFromImage", (!AlphaFromImage) ? 0f : 1f);
		base.material.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		if (StarTexture != null)
		{
			base.material.SetTexture("_StarTex", StarTexture);
		}
		else
		{
			Debug.Log("No/Invalid Type Map Texture!");
		}
		if (StarThickTexture != null)
		{
			base.material.SetTexture("_CloudThickTex", StarThickTexture);
		}
		else
		{
			Debug.Log("No/Invalid Thick Cloud Texture!");
		}
		if (StarMedTexture != null)
		{
			base.material.SetTexture("_CloudMedTex", StarMedTexture);
		}
		else
		{
			Debug.Log("No/Invalid Med Cloud Texture!");
		}
		if (StarThinTexture != null)
		{
			base.material.SetTexture("_CloudThinTex", StarThinTexture);
		}
		else
		{
			Debug.Log("No/Invalid Thin Cloud Texture!");
		}
		if (CutoutTexture != null)
		{
			base.material.SetTexture("_CutoutTex", CutoutTexture);
		}
		else
		{
			Debug.Log("No/Invalid Cutout Texture!");
		}
		base.material.SetFloat("_VisibilityFactor", VisibilityFactor);
		base.material.SetColor("_CloudColor", StarColor);
		Graphics.Blit(src, dest, base.material);
	}
}
