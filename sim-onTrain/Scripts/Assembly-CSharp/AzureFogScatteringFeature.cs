using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AzureFogScatteringFeature : ScriptableRendererFeature
{
	private class AzureFogScatteringPass : ScriptableRenderPass
	{
		public Material blitMaterial;

		private RenderTargetIdentifier source;

		private RenderTargetIdentifier destination;

		private int temporaryRTId = Shader.PropertyToID("_TempRT");

		private int sourceId;

		private int destinationId;

		private string m_ProfilerTag;

		private Camera m_camera;

		private Vector3[] m_frustumCorners = new Vector3[4];

		private Transform m_cameraTransform;

		private Rect m_rect = new Rect(0f, 0f, 1f, 1f);

		private Matrix4x4 m_frustumCornersArray;

		public FilterMode filterMode { get; set; }

		public AzureFogScatteringPass(string tag)
		{
			m_ProfilerTag = tag;
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.depthBufferBits = 0;
			ScriptableRenderer renderer = renderingData.cameraData.renderer;
			sourceId = -1;
			source = renderer.cameraColorTarget;
			destinationId = temporaryRTId;
			cmd.GetTemporaryRT(destinationId, cameraTargetDescriptor, filterMode);
			destination = new RenderTargetIdentifier(destinationId);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get(m_ProfilerTag);
			m_camera = renderingData.cameraData.camera;
			m_cameraTransform = m_camera.transform;
			m_camera.CalculateFrustumCorners(m_rect, m_camera.farClipPlane, m_camera.stereoActiveEye, m_frustumCorners);
			m_frustumCornersArray = Matrix4x4.identity;
			m_frustumCornersArray.SetRow(0, m_cameraTransform.TransformVector(m_frustumCorners[0]));
			m_frustumCornersArray.SetRow(2, m_cameraTransform.TransformVector(m_frustumCorners[1]));
			m_frustumCornersArray.SetRow(3, m_cameraTransform.TransformVector(m_frustumCorners[2]));
			m_frustumCornersArray.SetRow(1, m_cameraTransform.TransformVector(m_frustumCorners[3]));
			blitMaterial.SetMatrix("_FrustumCorners", m_frustumCornersArray);
			Blit(commandBuffer, source, destination, blitMaterial, -1);
			Blit(commandBuffer, destination, source);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			if (destinationId != -1)
			{
				cmd.ReleaseTemporaryRT(destinationId);
			}
			if (source == destination && sourceId != -1)
			{
				cmd.ReleaseTemporaryRT(sourceId);
			}
		}
	}

	public Material blitMaterial;

	public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingSkybox;

	private AzureFogScatteringPass m_azureFogScatteringPass;

	public override void Create()
	{
		m_azureFogScatteringPass = new AzureFogScatteringPass(base.name);
		m_azureFogScatteringPass.blitMaterial = blitMaterial;
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (blitMaterial == null)
		{
			Debug.LogWarningFormat("Missing Blit Material. {0} blit pass will not execute. Check for missing reference in the assigned renderer.", GetType().Name);
		}
		else
		{
			m_azureFogScatteringPass.renderPassEvent = renderPassEvent;
			renderer.EnqueuePass(m_azureFogScatteringPass);
		}
	}
}
