using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PSX
{
	public class CRTPass : ScriptableRenderPass
	{
		private static readonly string shaderPath = "PostEffect/CRTShader";

		private static readonly string k_RenderTag = "Render CRT Effects";

		private static readonly int MainTexId = Shader.PropertyToID("_MainTex");

		private static readonly int TempTargetId = Shader.PropertyToID("_TempTargetCRT");

		private static readonly int ScanLinesWeight = Shader.PropertyToID("_ScanlinesWeight");

		private static readonly int NoiseWeight = Shader.PropertyToID("_NoiseWeight");

		private static readonly int ScreenBendX = Shader.PropertyToID("_ScreenBendX");

		private static readonly int ScreenBendY = Shader.PropertyToID("_ScreenBendY");

		private static readonly int VignetteAmount = Shader.PropertyToID("_VignetteAmount");

		private static readonly int VignetteSize = Shader.PropertyToID("_VignetteSize");

		private static readonly int VignetteRounding = Shader.PropertyToID("_VignetteRounding");

		private static readonly int VignetteSmoothing = Shader.PropertyToID("_VignetteSmoothing");

		private static readonly int ScanLinesDensity = Shader.PropertyToID("_ScanLinesDensity");

		private static readonly int ScanLinesSpeed = Shader.PropertyToID("_ScanLinesSpeed");

		private static readonly int NoiseAmount = Shader.PropertyToID("_NoiseAmount");

		private static readonly int ChromaticRed = Shader.PropertyToID("_ChromaticRed");

		private static readonly int ChromaticGreen = Shader.PropertyToID("_ChromaticGreen");

		private static readonly int ChromaticBlue = Shader.PropertyToID("_ChromaticBlue");

		private static readonly int GrilleOpacity = Shader.PropertyToID("_GrilleOpacity");

		private static readonly int GrilleCounterOpacity = Shader.PropertyToID("_GrilleCounterOpacity");

		private static readonly int GrilleResolution = Shader.PropertyToID("_GrilleResolution");

		private static readonly int GrilleCounterResolution = Shader.PropertyToID("_GrilleCounterResolution");

		private static readonly int GrilleBrightness = Shader.PropertyToID("_GrilleBrightness");

		private static readonly int GrilleUvRotation = Shader.PropertyToID("_GrilleUvRotation");

		private static readonly int GrilleUvMidPoint = Shader.PropertyToID("_GrilleUvMidPoint");

		private static readonly int GrilleShift = Shader.PropertyToID("_GrilleShift");

		private Crt m_Crt;

		private Material crtMaterial;

		private RenderTargetIdentifier currentTarget;

		public CRTPass(RenderPassEvent evt)
		{
			base.renderPassEvent = evt;
			Shader shader = Shader.Find(shaderPath);
			if (shader == null)
			{
				Debug.LogError("Shader not found (crt).");
			}
			else
			{
				crtMaterial = CoreUtils.CreateEngineMaterial(shader);
			}
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (crtMaterial == null)
			{
				Debug.LogError("Material not created.");
			}
			else if (renderingData.cameraData.postProcessEnabled)
			{
				VolumeStack stack = VolumeManager.instance.stack;
				m_Crt = stack.GetComponent<Crt>();
				if (!(m_Crt == null) && m_Crt.IsActive())
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get(k_RenderTag);
					Render(commandBuffer, ref renderingData);
					context.ExecuteCommandBuffer(commandBuffer);
					CommandBufferPool.Release(commandBuffer);
				}
			}
		}

		public void Setup(in RenderTargetIdentifier currentTarget)
		{
			this.currentTarget = currentTarget;
		}

		private void Render(CommandBuffer cmd, ref RenderingData renderingData)
		{
			ref CameraData cameraData = ref renderingData.cameraData;
			RenderTargetIdentifier renderTargetIdentifier = currentTarget;
			int tempTargetId = TempTargetId;
			int scaledPixelWidth = cameraData.camera.scaledPixelWidth;
			int scaledPixelHeight = cameraData.camera.scaledPixelHeight;
			cameraData.camera.depthTextureMode = cameraData.camera.depthTextureMode | DepthTextureMode.Depth;
			crtMaterial.SetFloat(ScanLinesWeight, m_Crt.scanlinesWeight.value);
			crtMaterial.SetFloat(NoiseWeight, m_Crt.noiseWeight.value);
			crtMaterial.SetFloat(ScreenBendX, m_Crt.screenBendX.value);
			crtMaterial.SetFloat(ScreenBendY, m_Crt.screenBendY.value);
			crtMaterial.SetFloat(VignetteAmount, m_Crt.vignetteAmount.value);
			crtMaterial.SetFloat(VignetteSize, m_Crt.vignetteSize.value);
			crtMaterial.SetFloat(VignetteRounding, m_Crt.vignetteRounding.value);
			crtMaterial.SetFloat(VignetteSmoothing, m_Crt.vignetteSmoothing.value);
			crtMaterial.SetFloat(ScanLinesDensity, m_Crt.scanlinesDensity.value);
			crtMaterial.SetFloat(ScanLinesSpeed, m_Crt.scanlinesSpeed.value);
			crtMaterial.SetFloat(NoiseAmount, m_Crt.noiseAmount.value);
			crtMaterial.SetVector(ChromaticRed, m_Crt.chromaticRed.value);
			crtMaterial.SetVector(ChromaticGreen, m_Crt.chromaticGreen.value);
			crtMaterial.SetVector(ChromaticBlue, m_Crt.chromaticBlue.value);
			crtMaterial.SetFloat(GrilleOpacity, m_Crt.grilleOpacity.value);
			crtMaterial.SetFloat(GrilleCounterOpacity, m_Crt.grilleCounterOpacity.value);
			crtMaterial.SetFloat(GrilleResolution, m_Crt.grilleResolution.value);
			crtMaterial.SetFloat(GrilleCounterResolution, m_Crt.grilleCounterResolution.value);
			crtMaterial.SetFloat(GrilleBrightness, m_Crt.grilleBrightness.value);
			crtMaterial.SetFloat(GrilleUvRotation, m_Crt.grilleUvRotation.value);
			crtMaterial.SetFloat(GrilleUvMidPoint, m_Crt.grilleUvMidPoint.value);
			crtMaterial.SetVector(GrilleShift, m_Crt.grilleShift.value);
			int pass = 0;
			cmd.SetGlobalTexture(MainTexId, renderTargetIdentifier);
			cmd.GetTemporaryRT(tempTargetId, scaledPixelWidth, scaledPixelHeight, 0, FilterMode.Point, RenderTextureFormat.Default);
			cmd.Blit(renderTargetIdentifier, tempTargetId);
			cmd.Blit(tempTargetId, renderTargetIdentifier, crtMaterial, pass);
		}
	}
}
