using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ReflectRenderPass : ScriptableRendererFeature
{
	private class SSR_Pass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material effectMaterial;

			internal int passIndex;

			internal bool requiresColor;

			internal bool isBeforeTransparents;

			public RTHandle copiedColor;
		}

		private Material m_PassMaterial;

		private int m_PassIndex;

		private bool m_RequiresColor;

		private bool m_IsBeforeTransparents;

		private PassData m_PassData;

		private RTHandle m_CopiedColor;

		private static readonly int m_BlitTextureShaderID = Shader.PropertyToID("_BlitTexture");

		private RTHandle ScreenSpaceRelfectionsTex;

		private int downSample;

		public void Setup(Material mat, int index, bool requiresColor, bool isBeforeTransparents, string featureName, int ds, in RenderingData renderingData)
		{
			m_PassMaterial = mat;
			m_PassIndex = index;
			m_RequiresColor = requiresColor;
			m_IsBeforeTransparents = isBeforeTransparents;
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateIfNeeded(ref m_CopiedColor, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_FullscreenPassColorCopy");
			ScreenSpaceRelfectionsTex = RTHandles.Alloc("SSRT", "SSRT");
			downSample = ds;
			if (m_PassData == null)
			{
				m_PassData = new PassData();
			}
		}

		public void Dispose()
		{
			m_CopiedColor?.Release();
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			cmd.SetGlobalTexture("_ScreenSpaceRelfectionsTex", Shader.PropertyToID(ScreenSpaceRelfectionsTex.name));
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			RenderTextureDescriptor renderTextureDescriptor = cameraTargetDescriptor;
			renderTextureDescriptor.msaaSamples = 1;
			renderTextureDescriptor.depthBufferBits = 0;
			cameraTargetDescriptor = renderTextureDescriptor;
			cameraTargetDescriptor.width /= downSample;
			cameraTargetDescriptor.height /= downSample;
			cameraTargetDescriptor.colorFormat = RenderTextureFormat.DefaultHDR;
			cmd.GetTemporaryRT(Shader.PropertyToID(ScreenSpaceRelfectionsTex.name), cameraTargetDescriptor, FilterMode.Bilinear);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			m_PassData.effectMaterial = m_PassMaterial;
			m_PassData.passIndex = m_PassIndex;
			m_PassData.requiresColor = m_RequiresColor;
			m_PassData.isBeforeTransparents = m_IsBeforeTransparents;
			m_PassData.copiedColor = m_CopiedColor;
			ExecutePass(m_PassData, ref renderingData, ref context);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			cmd.ReleaseTemporaryRT(Shader.PropertyToID(ScreenSpaceRelfectionsTex.name));
		}

		private void ExecutePass(PassData passData, ref RenderingData renderingData, ref ScriptableRenderContext context)
		{
			Material effectMaterial = passData.effectMaterial;
			_ = passData.passIndex;
			bool requiresColor = passData.requiresColor;
			bool isBeforeTransparents = passData.isBeforeTransparents;
			RTHandle copiedColor = passData.copiedColor;
			if (!(effectMaterial == null) && !renderingData.cameraData.isPreviewCamera)
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				CameraData cameraData = renderingData.cameraData;
				if (requiresColor)
				{
					RTHandle source = (isBeforeTransparents ? cameraData.renderer.cameraColorTargetHandle : cameraData.renderer.cameraColorTargetHandle);
					Blitter.BlitCameraTexture(commandBuffer, source, copiedColor);
					effectMaterial.SetTexture(m_BlitTextureShaderID, copiedColor);
				}
				CoreUtils.SetRenderTarget(commandBuffer, ScreenSpaceRelfectionsTex);
				CoreUtils.DrawFullScreen(commandBuffer, effectMaterial);
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
			}
		}
	}

	private class Composite_Pass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material effectMaterial;

			internal int passIndex;

			internal bool requiresColor;

			internal bool isBeforeTransparents;

			public RTHandle copiedColor;
		}

		private Material m_PassMaterial;

		private int m_PassIndex;

		private bool m_RequiresColor;

		private bool m_IsBeforeTransparents;

		private PassData m_PassData;

		private RTHandle m_CopiedColor;

		private static readonly int m_BlitTextureShaderID = Shader.PropertyToID("_BlitTexture");

		public void Setup(Material mat, int index, bool requiresColor, bool isBeforeTransparents, string featureName, in RenderingData renderingData)
		{
			m_PassMaterial = mat;
			m_PassIndex = index;
			m_RequiresColor = requiresColor;
			m_IsBeforeTransparents = isBeforeTransparents;
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateIfNeeded(ref m_CopiedColor, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_FullscreenPassColorCopy");
			if (m_PassData == null)
			{
				m_PassData = new PassData();
			}
		}

		public void Dispose()
		{
			m_CopiedColor?.Release();
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			m_PassData.effectMaterial = m_PassMaterial;
			m_PassData.passIndex = m_PassIndex;
			m_PassData.requiresColor = m_RequiresColor;
			m_PassData.isBeforeTransparents = m_IsBeforeTransparents;
			m_PassData.copiedColor = m_CopiedColor;
			ExecutePass(m_PassData, ref renderingData, ref context);
		}

		private void ExecutePass(PassData passData, ref RenderingData renderingData, ref ScriptableRenderContext context)
		{
			Material effectMaterial = passData.effectMaterial;
			_ = passData.passIndex;
			bool requiresColor = passData.requiresColor;
			bool isBeforeTransparents = passData.isBeforeTransparents;
			RTHandle copiedColor = passData.copiedColor;
			if (!(effectMaterial == null) && !renderingData.cameraData.isPreviewCamera)
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				CameraData cameraData = renderingData.cameraData;
				if (requiresColor)
				{
					RTHandle source = (isBeforeTransparents ? cameraData.renderer.cameraColorTargetHandle : cameraData.renderer.cameraColorTargetHandle);
					Blitter.BlitCameraTexture(commandBuffer, source, copiedColor);
					effectMaterial.SetTexture(m_BlitTextureShaderID, copiedColor);
				}
				CoreUtils.SetRenderTarget(commandBuffer, cameraData.renderer.cameraColorTargetHandle);
				CoreUtils.DrawFullScreen(commandBuffer, effectMaterial);
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
			}
		}
	}

	private Material passMaterial;

	private Material compositeMaterial;

	public RenderPassEvent renderPass = RenderPassEvent.BeforeRenderingPostProcessing;

	private ScriptableRenderPassInput requirements = ScriptableRenderPassInput.Color;

	[HideInInspector]
	public int passIndex;

	private SSR_Pass ssrPass;

	private Composite_Pass compositePass;

	private bool requiresColor;

	private bool injectedBeforeTransparents;

	private bool isEnabled;

	public override void Create()
	{
		ssrPass = new SSR_Pass();
		ssrPass.renderPassEvent = renderPass;
		compositePass = new Composite_Pass();
		compositePass.renderPassEvent = renderPass;
		ScriptableRenderPassInput scriptableRenderPassInput = requirements;
		requiresColor = (requirements & ScriptableRenderPassInput.Color) != 0;
		injectedBeforeTransparents = renderPass <= RenderPassEvent.BeforeRenderingTransparents;
		if (requiresColor && !injectedBeforeTransparents)
		{
			scriptableRenderPassInput ^= ScriptableRenderPassInput.Color;
		}
		ssrPass.ConfigureInput(scriptableRenderPassInput);
		compositePass.ConfigureInput(scriptableRenderPassInput);
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		ScreenSpaceReflections component = VolumeManager.instance.stack.GetComponent<ScreenSpaceReflections>();
		isEnabled = component.IsActive();
		if (!renderingData.postProcessingEnabled)
		{
			isEnabled = false;
		}
		if (isEnabled)
		{
			if (passMaterial == null)
			{
				passMaterial = (Material)Resources.Load("SSR_Renderer");
			}
			if (compositeMaterial == null)
			{
				compositeMaterial = (Material)Resources.Load("SSR_Composite");
			}
			if (passMaterial == null || compositeMaterial == null)
			{
				Debug.LogWarningFormat("Missing Post Processing effect Material. {0} Fullscreen pass will not execute. Check for missing reference in the assigned renderer.", GetType().Name);
				return;
			}
			passMaterial.SetFloat("_Samples", component.steps.value);
			passMaterial.SetFloat("_BinarySamples", component.samples.value);
			passMaterial.SetFloat("_StepSize", component.stepSize.value);
			passMaterial.SetFloat("_Thickness", component.thickness.value);
			passMaterial.SetFloat("_MinSmoothness", component.minSmoothness.value);
			ssrPass.Setup(passMaterial, passIndex, requiresColor, injectedBeforeTransparents, "SSR", component.downsample.value, in renderingData);
			compositePass.Setup(compositeMaterial, passIndex, requiresColor, injectedBeforeTransparents, "Comp", in renderingData);
			renderer.EnqueuePass(ssrPass);
			renderer.EnqueuePass(compositePass);
		}
	}

	protected override void Dispose(bool disposing)
	{
		ssrPass.Dispose();
		compositePass.Dispose();
	}
}
