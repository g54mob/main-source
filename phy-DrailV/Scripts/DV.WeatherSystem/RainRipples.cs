using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public abstract class RainRipples : MonoBehaviour
{
	private readonly int rainAmountID = Shader.PropertyToID("_rainAmount");

	private readonly int wetnessID = Shader.PropertyToID("_wetness");

	private readonly int _TimeScaleID = Shader.PropertyToID("_TimeScale");

	private readonly int _IntensityID = Shader.PropertyToID("_Intensity");

	private readonly int _OC_RainRippleTexID = Shader.PropertyToID("_OC_RainRippleTex");

	private readonly int _OC_RainFlowTexID = Shader.PropertyToID("_OC_RainFlowTex");

	private readonly int _OC_GlobalWetnessParamsID = Shader.PropertyToID("_OC_GlobalWetnessParams");

	private readonly int _OC_GlobalRainParamsID = Shader.PropertyToID("_OC_GlobalRainParams");

	private readonly int _OC_GlobalRainParams2ID = Shader.PropertyToID("_OC_GlobalRainParams2");

	private static Mesh s_Quad;

	public static float rainAmount;

	public static float wetness;

	public static float rippleMultiplier;

	public static float flowMultiplier;

	public RainRippleSettings settings;

	private CommandBuffer wetnessBuffer;

	private Material screenMat;

	private Material rippleMat;

	private Camera camera;

	private VRTextureUsage vrUsage;

	private readonly RenderTargetIdentifier[] m_WetnessMRT = new RenderTargetIdentifier[3]
	{
		BuiltinRenderTextureType.GBuffer0,
		BuiltinRenderTextureType.GBuffer1,
		BuiltinRenderTextureType.CameraTarget
	};

	public static Mesh quad
	{
		get
		{
			if (s_Quad != null)
			{
				return s_Quad;
			}
			Vector3[] vertices = new Vector3[4]
			{
				new Vector3(-1f, -1f, 0f),
				new Vector3(1f, 1f, 0f),
				new Vector3(1f, -1f, 0f),
				new Vector3(-1f, 1f, 0f)
			};
			Vector2[] uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 1f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f)
			};
			int[] triangles = new int[6] { 0, 1, 2, 1, 0, 3 };
			s_Quad = new Mesh
			{
				vertices = vertices,
				uv = uv,
				triangles = triangles
			};
			s_Quad.RecalculateNormals();
			s_Quad.RecalculateBounds();
			return s_Quad;
		}
	}

	private void Awake()
	{
		camera = GetComponent<Camera>();
		vrUsage = GetVRUsageFromCamera(camera);
		screenMat = new Material(settings.screenPassShader);
		rippleMat = new Material(settings.rippleNormalsShader);
	}

	private void OnPreRender()
	{
		UpdateRaymarchingMatrices(camera);
		UpdateShaderVariables();
		int width = camera.pixelWidth * ((vrUsage != VRTextureUsage.TwoEyes) ? 1 : 2);
		int pixelHeight = camera.pixelHeight;
		if (wetnessBuffer == null && camera.renderingPath == RenderingPath.DeferredShading)
		{
			wetnessBuffer = new CommandBuffer();
			wetnessBuffer.name = "Rain, man";
			camera.AddCommandBuffer(CameraEvent.BeforeReflections, wetnessBuffer);
		}
		if (wetnessBuffer != null)
		{
			wetnessBuffer.Clear();
			wetnessBuffer.SetGlobalTexture("_GBuffer2", BuiltinRenderTextureType.GBuffer2);
			if (!Mathf.Approximately(settings.albedoDarken, 0f) || !Mathf.Approximately(settings.roughnessDecrease, 0f))
			{
				wetnessBuffer.SetRenderTarget(m_WetnessMRT, BuiltinRenderTextureType.CameraTarget);
				wetnessBuffer.DrawMesh(quad, Matrix4x4.identity, screenMat, 0, 0);
			}
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, pixelHeight, RenderTextureFormat.ARGB2101010, 0);
			desc.vrUsage = vrUsage;
			int num = Shader.PropertyToID("_GBuffer2Copy");
			wetnessBuffer.GetTemporaryRT(num, desc);
			wetnessBuffer.SetGlobalTexture("_GBuffer2Copy", num);
			wetnessBuffer.Blit(BuiltinRenderTextureType.GBuffer2, num);
			wetnessBuffer.SetGlobalFloat("vrMult", (vrUsage == VRTextureUsage.TwoEyes) ? 0.5f : 1f);
			wetnessBuffer.SetRenderTarget(BuiltinRenderTextureType.GBuffer2, BuiltinRenderTextureType.CameraTarget);
			wetnessBuffer.DrawMesh(quad, Matrix4x4.identity, screenMat, 0, 1);
			wetnessBuffer.ReleaseTemporaryRT(num);
			camera.RemoveCommandBuffer(CameraEvent.BeforeReflections, wetnessBuffer);
			camera.AddCommandBuffer(CameraEvent.BeforeReflections, wetnessBuffer);
		}
	}

	private void UpdateShaderVariables()
	{
		rippleMat.SetFloat(_TimeScaleID, 40f * Time.timeScale);
		rippleMat.SetFloat(_IntensityID, 1f);
		Graphics.Blit(settings.rippleTexture, settings.rippleRT, rippleMat);
		Shader.SetGlobalTexture(_OC_RainRippleTexID, settings.rippleRT);
		Shader.SetGlobalTexture(_OC_RainFlowTexID, settings.flowTexture);
		Shader.SetGlobalVector(_OC_GlobalWetnessParamsID, new Vector4(0f, settings.albedoDarken, settings.roughnessDecrease, 0f));
		Shader.SetGlobalVector(_OC_GlobalRainParams2ID, new Vector2(settings.rippleTimescale * 100f, settings.flowTimescale * 2f));
		Shader.SetGlobalVector(_OC_GlobalRainParamsID, new Vector4(settings.rippleIntensity * rippleMultiplier, settings.rippleScale, settings.flowIntensity * flowMultiplier, settings.flowScale));
		Shader.SetGlobalFloat(rainAmountID, rainAmount);
		Shader.SetGlobalFloat(wetnessID, wetness);
	}

	public abstract VRTextureUsage GetVRUsageFromCamera(Camera camera);

	private void UpdateRaymarchingMatrices(Camera camera)
	{
		if (GetVRUsageFromCamera(camera) == VRTextureUsage.None || XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass)
		{
			Matrix4x4 cameraToWorldMatrix = camera.cameraToWorldMatrix;
			Matrix4x4 inverse = GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true).inverse;
			inverse[1, 1] *= -1f;
			Shader.SetGlobalMatrix("_WorldFromView", cameraToWorldMatrix);
			Shader.SetGlobalMatrix("_ViewFromScreen", inverse);
			return;
		}
		Matrix4x4 inverse2 = camera.GetStereoViewMatrix(Camera.StereoscopicEye.Left).inverse;
		Matrix4x4 inverse3 = camera.GetStereoViewMatrix(Camera.StereoscopicEye.Right).inverse;
		Matrix4x4 stereoProjectionMatrix = camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
		Matrix4x4 stereoProjectionMatrix2 = camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
		Matrix4x4 inverse4 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix, renderIntoTexture: true).inverse;
		Matrix4x4 inverse5 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix2, renderIntoTexture: true).inverse;
		inverse4[1, 1] *= -1f;
		inverse5[1, 1] *= -1f;
		Shader.SetGlobalMatrix("_LeftWorldFromView", inverse2);
		Shader.SetGlobalMatrix("_RightWorldFromView", inverse3);
		Shader.SetGlobalMatrix("_LeftViewFromScreen", inverse4);
		Shader.SetGlobalMatrix("_RightViewFromScreen", inverse5);
	}
}
