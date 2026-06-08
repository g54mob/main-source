using UnityEngine;

[ExecuteInEditMode]
public class CameraGalaxyOverlay : ImageEffectBase
{
	public static CameraGalaxyOverlay Instance;

	public Texture BackgroundTexture;

	public Texture DepthMapTexture;

	public Texture CutoutTexture;

	public bool InvertYAxis;

	public Color GalaxyColorDenseMax = new Color(0.66f, 0f, 1.01f, 1f);

	public Color GalaxyColorDenseMin = new Color(0.66f, 0f, 1.01f, 1f);

	public Color GalaxyColorLight = new Color(0.66f, 0f, 1.01f, 1f);

	public float DenseBegin = 0.75f;

	public float LightBegin = 0.25f;

	public float BackgroundVisibilityFactor = 1f;

	public float VisibilityFactor = 1f;

	protected override void Start()
	{
		Instance = this;
		base.Start();
	}

	private void OnDestroy()
	{
		BackgroundTexture = null;
		DepthMapTexture = null;
		CutoutTexture = null;
	}

	private void Update()
	{
		if (GalaxyMapManager.depthMapSourceTexture != null)
		{
			DepthMapTexture = GalaxyMapManager.depthMapSourceTexture;
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		if (BackgroundTexture != null)
		{
			base.material.SetTexture("_BackgroundTex", BackgroundTexture);
		}
		else
		{
			Debug.Log("No/Invalid Background Texture!");
		}
		if (DepthMapTexture != null)
		{
			base.material.SetTexture("_DepthTex", DepthMapTexture);
		}
		else
		{
			Debug.Log("No/Invalid Depth Map Texture!");
		}
		if (CutoutTexture != null)
		{
			base.material.SetTexture("_CutoutTex", CutoutTexture);
		}
		else
		{
			Debug.Log("No/Invalid Cutout Texture!");
		}
		base.material.SetColor("_GalaxyColorDenseMax", GalaxyColorDenseMax);
		base.material.SetColor("_GalaxyColorDenseMin", GalaxyColorDenseMin);
		base.material.SetColor("_GalaxyColorLight", GalaxyColorLight);
		base.material.SetFloat("_DenseBegin", DenseBegin);
		base.material.SetFloat("_LightBegin", LightBegin);
		base.material.SetFloat("_BackgroundVisibility", BackgroundVisibilityFactor);
		base.material.SetFloat("_VisibilityFactor", VisibilityFactor);
		Graphics.Blit(src, dest, base.material);
	}
}
