using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera Atmospheric Scattering")]
public class TOD_Scattering : TOD_ImageEffect
{
	public Shader ScatteringShader;

	public Texture2D DitheringTexture;

	[Range(0f, 1f)]
	public float GlobalDensity = 0.001f;

	[Range(0f, 1f)]
	public float HeightFalloff = 0.001f;

	public float ZeroLevel;

	private Material scatteringMaterial;

	protected void OnEnable()
	{
		if (!ScatteringShader)
		{
			ScatteringShader = Shader.Find("Hidden/Time of Day/Scattering");
		}
		scatteringMaterial = CreateMaterial(ScatteringShader);
	}

	protected void OnDisable()
	{
		if ((bool)scatteringMaterial)
		{
			Object.DestroyImmediate(scatteringMaterial);
		}
	}

	protected void OnPreCull()
	{
		if ((bool)sky && sky.Initialized)
		{
			sky.Components.AtmosphereRenderer.enabled = false;
		}
	}

	protected void OnPostRender()
	{
		if ((bool)sky && sky.Initialized)
		{
			sky.Components.AtmosphereRenderer.enabled = true;
		}
	}

	[ImageEffectOpaque]
	protected void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckSupport(needDepth: true))
		{
			Graphics.Blit(source, destination);
			return;
		}
		sky.Components.Scattering = this;
		float heightFalloff = HeightFalloff;
		float y = Mathf.Exp((0f - heightFalloff) * (cam.transform.position.y - ZeroLevel));
		float globalDensity = GlobalDensity;
		scatteringMaterial.SetMatrix("_FrustumCornersWS", FrustumCorners());
		scatteringMaterial.SetTexture("_DitheringTexture", DitheringTexture);
		scatteringMaterial.SetVector("_Density", new Vector4(heightFalloff, y, globalDensity, 0f));
		CustomBlit(source, destination, scatteringMaterial);
	}
}
