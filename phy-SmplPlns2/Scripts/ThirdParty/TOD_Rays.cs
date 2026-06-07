using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera God Rays")]
public class TOD_Rays : TOD_ImageEffect
{
	public enum ResolutionType
	{
		Low = 0,
		Normal = 1,
		High = 2
	}

	public enum BlendModeType
	{
		Screen = 0,
		Add = 1
	}

	public Shader GodRayShader;

	public Shader ScreenClearShader;

	[Tooltip("The god ray rendering resolution.")]
	public ResolutionType Resolution = ResolutionType.Normal;

	[Tooltip("The god ray rendering blend mode.")]
	public BlendModeType BlendMode;

	[Tooltip("The number of blur iterations to be performed.")]
	[TOD_Range(0f, 4f)]
	public int BlurIterations = 2;

	[Tooltip("The radius to blur filter applied to the god rays.")]
	[TOD_Min(0f)]
	public float BlurRadius = 2f;

	[Tooltip("The intensity of the god rays.")]
	[TOD_Min(0f)]
	public float Intensity = 1f;

	[Tooltip("The maximum radius of the god rays.")]
	[TOD_Min(0f)]
	public float MaxRadius = 0.5f;

	[Tooltip("Whether or not to use the depth buffer.")]
	public bool UseDepthTexture = true;

	private Material godRayMaterial;

	private Material screenClearMaterial;

	private const int PASS_DEPTH = 2;

	private const int PASS_NODEPTH = 3;

	private const int PASS_RADIAL = 1;

	private const int PASS_SCREEN = 0;

	private const int PASS_ADD = 4;

	protected void OnEnable()
	{
		if (!GodRayShader)
		{
			GodRayShader = Shader.Find("Hidden/Time of Day/God Rays");
		}
		if (!ScreenClearShader)
		{
			ScreenClearShader = Shader.Find("Hidden/Time of Day/Screen Clear");
		}
		godRayMaterial = CreateMaterial(GodRayShader);
		screenClearMaterial = CreateMaterial(ScreenClearShader);
	}

	protected void OnDisable()
	{
		if ((bool)godRayMaterial)
		{
			Object.DestroyImmediate(godRayMaterial);
		}
		if ((bool)screenClearMaterial)
		{
			Object.DestroyImmediate(screenClearMaterial);
		}
	}

	protected void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckSupport(UseDepthTexture))
		{
			Graphics.Blit(source, destination);
			return;
		}
		sky.Components.Rays = this;
		int width;
		int height;
		int depthBuffer;
		if (Resolution == ResolutionType.High)
		{
			width = source.width;
			height = source.height;
			depthBuffer = 0;
		}
		else if (Resolution == ResolutionType.Normal)
		{
			width = source.width / 2;
			height = source.height / 2;
			depthBuffer = 0;
		}
		else
		{
			width = source.width / 4;
			height = source.height / 4;
			depthBuffer = 0;
		}
		Vector3 vector = cam.WorldToViewportPoint(sky.Components.LightTransform.position);
		godRayMaterial.SetVector("_BlurRadius4", new Vector4(1f, 1f, 0f, 0f) * BlurRadius);
		godRayMaterial.SetVector("_LightPosition", new Vector4(vector.x, vector.y, vector.z, MaxRadius));
		RenderTexture temporary = RenderTexture.GetTemporary(width, height, depthBuffer);
		RenderTexture renderTexture = null;
		if (UseDepthTexture)
		{
			Graphics.Blit(source, temporary, godRayMaterial, 2);
		}
		else
		{
			Graphics.Blit(source, temporary, godRayMaterial, 3);
		}
		DrawBorder(temporary, screenClearMaterial);
		float num = BlurRadius * 0.0013020834f;
		godRayMaterial.SetVector("_BlurRadius4", new Vector4(num, num, 0f, 0f));
		godRayMaterial.SetVector("_LightPosition", new Vector4(vector.x, vector.y, vector.z, MaxRadius));
		for (int i = 0; i < BlurIterations; i++)
		{
			renderTexture = RenderTexture.GetTemporary(width, height, depthBuffer);
			Graphics.Blit(temporary, renderTexture, godRayMaterial, 1);
			RenderTexture.ReleaseTemporary(temporary);
			num = BlurRadius * (((float)i * 2f + 1f) * 6f) / 768f;
			godRayMaterial.SetVector("_BlurRadius4", new Vector4(num, num, 0f, 0f));
			temporary = RenderTexture.GetTemporary(width, height, depthBuffer);
			Graphics.Blit(renderTexture, temporary, godRayMaterial, 1);
			RenderTexture.ReleaseTemporary(renderTexture);
			num = BlurRadius * (((float)i * 2f + 2f) * 6f) / 768f;
			godRayMaterial.SetVector("_BlurRadius4", new Vector4(num, num, 0f, 0f));
		}
		Color value = Color.black;
		if ((double)vector.z >= 0.0)
		{
			value = ((!sky.IsDay) ? (Intensity * sky.MoonVisibility * sky.MoonRayColor) : (Intensity * sky.SunVisibility * sky.SunRayColor));
		}
		godRayMaterial.SetColor("_LightColor", value);
		godRayMaterial.SetTexture("_ColorBuffer", temporary);
		if (BlendMode == BlendModeType.Screen)
		{
			Graphics.Blit(source, destination, godRayMaterial, 0);
		}
		else
		{
			Graphics.Blit(source, destination, godRayMaterial, 4);
		}
		RenderTexture.ReleaseTemporary(temporary);
	}
}
