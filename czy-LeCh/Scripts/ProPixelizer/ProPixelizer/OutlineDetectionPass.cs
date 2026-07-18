using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ProPixelizer
{
	public class OutlineDetectionPass : ProPixelizerPass
	{
		[Serializable]
		public sealed class ShaderResources
		{
			public Shader OutlineDetection;

			public ShaderResources Load()
			{
				OutlineDetection = Shader.Find("Hidden/ProPixelizer/SRP/OutlineDetection");
				return this;
			}
		}

		public sealed class MaterialLibrary
		{
			private ShaderResources Resources;

			private Material _OutlineDetection;

			public Material OutlineDetection
			{
				get
				{
					if (_OutlineDetection == null)
					{
						_OutlineDetection = new Material(Resources.OutlineDetection);
					}
					return _OutlineDetection;
				}
			}

			public MaterialLibrary(ShaderResources resources)
			{
				Resources = resources;
			}
		}

		private MaterialLibrary Materials;

		public bool DepthTestOutlines;

		public float DepthTestThreshold;

		public bool UseNormalsForEdgeDetection = true;

		public float NormalEdgeDetectionSensitivity = 1f;

		private int _OutlineObjectBuffer;

		public int _OutlineObjectBuffer_Depth;

		private int _OutlineBuffer;

		private static ShaderTagId ProPixelizerShaderTagID = new ShaderTagId("ProPixelizer");

		private const string OutlineDetectionShader = "Hidden/ProPixelizer/SRP/OutlineDetection";

		private Vector4 TexelSize;

		public const string PROPIXELIZER_OBJECT_BUFFER = "ProPixelizerMetadata";

		public const string OUTLINE_BUFFER = "_ProPixelizerOutlines";

		private const string PROPIXELIZER_SHADER_TAG = "ProPixelizer";

		public const string PROFILER_TAG = "ProPixelizerOutlines";

		public OutlineDetectionPass(ShaderResources resources)
		{
			base.renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;
			Materials = new MaterialLibrary(resources);
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			RenderTextureDescriptor desc = cameraTextureDescriptor;
			desc.useMipMap = false;
			desc.colorFormat = RenderTextureFormat.ARGB32;
			desc.graphicsFormat = GraphicsFormat.R8G8B8A8_UNorm;
			_OutlineObjectBuffer = Shader.PropertyToID("ProPixelizerMetadata");
			_OutlineObjectBuffer_Depth = _OutlineObjectBuffer;
			_OutlineBuffer = Shader.PropertyToID("_ProPixelizerOutlines");
			cmd.GetTemporaryRT(_OutlineObjectBuffer, desc, FilterMode.Point);
			cmd.GetTemporaryRT(_OutlineBuffer, desc, FilterMode.Point);
			TexelSize = new Vector4(1f / (float)cameraTextureDescriptor.width, 1f / (float)cameraTextureDescriptor.height, cameraTextureDescriptor.width, cameraTextureDescriptor.height);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			cmd.ReleaseTemporaryRT(_OutlineObjectBuffer);
			cmd.ReleaseTemporaryRT(_OutlineBuffer);
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			Prepare(cmd, ref renderingData);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (DepthTestOutlines)
			{
				Materials.OutlineDetection.EnableKeyword("DEPTH_TEST_OUTLINES_ON");
				Materials.OutlineDetection.SetFloat("_OutlineDepthTestThreshold", DepthTestThreshold);
			}
			else
			{
				Materials.OutlineDetection.DisableKeyword("DEPTH_TEST_OUTLINES_ON");
			}
			if (UseNormalsForEdgeDetection)
			{
				Materials.OutlineDetection.SetFloat("_NormalEdgeDetectionSensitivity", NormalEdgeDetectionSensitivity);
			}
			CommandBuffer commandBuffer = CommandBufferPool.Get("ProPixelizerOutlines");
			commandBuffer.name = "ProPixelizer Outline Pass";
			if (UseNormalsForEdgeDetection)
			{
				commandBuffer.EnableShaderKeyword("NORMAL_EDGE_DETECTION_ON");
			}
			else
			{
				commandBuffer.DisableShaderKeyword("NORMAL_EDGE_DETECTION_ON");
			}
			commandBuffer.SetViewMatrix(renderingData.cameraData.GetViewMatrix());
			commandBuffer.SetProjectionMatrix(renderingData.cameraData.GetProjectionMatrix());
			commandBuffer.SetRenderTarget(_OutlineObjectBuffer);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.white);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
			DrawingSettings drawingSettings = new DrawingSettings(sortingSettings: new SortingSettings(renderingData.cameraData.camera), shaderPassName: ProPixelizerShaderTagID);
			FilteringSettings filteringSettings = new FilteringSettings(RenderQueueRange.all);
			context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings);
			commandBuffer = CommandBufferPool.Get("ProPixelizerOutlines");
			commandBuffer.name = "ProPixelizer Outline Detection";
			commandBuffer.SetGlobalTexture("_MainTex", _OutlineObjectBuffer);
			commandBuffer.SetGlobalTexture("_MainTex_Depth", _OutlineObjectBuffer_Depth, RenderTextureSubElement.Depth);
			commandBuffer.SetGlobalVector("_TexelSize", TexelSize);
			Blit(commandBuffer, _OutlineObjectBuffer, _OutlineBuffer, Materials.OutlineDetection);
			commandBuffer.SetGlobalTexture("_ProPixelizerOutlines", _OutlineBuffer);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
