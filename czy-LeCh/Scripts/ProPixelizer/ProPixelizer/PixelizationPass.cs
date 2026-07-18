using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ProPixelizer
{
	public class PixelizationPass : ProPixelizerPass
	{
		[Serializable]
		public sealed class ShaderResources
		{
			public Shader PixelizationMap;

			public Shader CopyDepth;

			public Shader CopyMainTexAndDepth;

			public Shader ApplyPixelizationMap;

			public ShaderResources Load()
			{
				PixelizationMap = Shader.Find("Hidden/ProPixelizer/SRP/Pixelization Map");
				CopyDepth = Shader.Find("Hidden/ProPixelizer/SRP/BlitCopyDepth");
				ApplyPixelizationMap = Shader.Find("Hidden/ProPixelizer/SRP/ApplyPixelizationMap");
				CopyMainTexAndDepth = Shader.Find("Hidden/ProPixelizer/SRP/BlitCopyMainTexAndDepth");
				return this;
			}
		}

		public sealed class MaterialLibrary
		{
			private ShaderResources Resources;

			private Material _PixelizationMap;

			private Material _CopyDepth;

			private Material _CopyMainTexAndDepth;

			private Material _ApplyPixelizationMap;

			public Material PixelizationMap
			{
				get
				{
					if (_PixelizationMap == null)
					{
						_PixelizationMap = new Material(Resources.PixelizationMap);
					}
					return _PixelizationMap;
				}
			}

			public Material CopyDepth
			{
				get
				{
					if (_CopyDepth == null)
					{
						_CopyDepth = new Material(Resources.CopyDepth);
					}
					return _CopyDepth;
				}
			}

			public Material CopyMainTexAndDepth
			{
				get
				{
					if (_CopyMainTexAndDepth == null)
					{
						_CopyMainTexAndDepth = new Material(Resources.CopyMainTexAndDepth);
					}
					return _CopyMainTexAndDepth;
				}
			}

			public Material ApplyPixelizationMap
			{
				get
				{
					if (_ApplyPixelizationMap == null)
					{
						_ApplyPixelizationMap = new Material(Resources.ApplyPixelizationMap);
					}
					return _ApplyPixelizationMap;
				}
			}

			public MaterialLibrary(ShaderResources resources)
			{
				Resources = resources;
			}
		}

		public enum PixelizationSource
		{
			SceneColor = 0,
			ProPixelizerMetadata = 1
		}

		private MaterialLibrary Materials;

		private OutlineDetectionPass OutlinePass;

		private int _PixelizationMap;

		private int _OriginalScene;

		private int _CameraColorTexture;

		private int _PixelatedScene;

		private int _PixelatedScene_Depth;

		private int _CameraDepthAttachment;

		private int _CameraDepthAttachmentTemp;

		private int _CameraDepthTexture;

		private int _ProPixelizerOutline;

		private int _ProPixelizerOutlineObject;

		private const string CopyDepthShaderName = "Hidden/ProPixelizer/SRP/BlitCopyDepth";

		private const string CopyMainTexAndDepthShaderName = "Hidden/ProPixelizer/SRP/BlitCopyMainTexAndDepth";

		private const string PixelizationMapShaderName = "Hidden/ProPixelizer/SRP/Pixelization Map";

		private const string ApplyPixelizationMapShaderName = "Hidden/ProPixelizer/SRP/ApplyPixelizationMap";

		private Vector4 TexelSize;

		public PixelizationSource SourceBuffer;

		public const string PROFILER_TAG = "PIXELISATION";

		public PixelizationPass(ShaderResources shaders, OutlineDetectionPass outlines)
		{
			base.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
			SourceBuffer = PixelizationSource.SceneColor;
			Materials = new MaterialLibrary(shaders);
			OutlinePass = outlines;
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			base.OnCameraSetup(cmd, ref renderingData);
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			cameraTextureDescriptor.useMipMap = false;
			RenderTextureDescriptor desc = cameraTextureDescriptor;
			desc.colorFormat = RenderTextureFormat.Depth;
			RenderTextureDescriptor desc2 = cameraTextureDescriptor;
			desc2.colorFormat = RenderTextureFormat.ARGB32;
			desc2.graphicsFormat = GraphicsFormat.R8G8B8A8_UNorm;
			desc2.depthBufferBits = 0;
			_PixelizationMap = Shader.PropertyToID("_PixelizationMap");
			_CameraColorTexture = Shader.PropertyToID("_CameraColorTexture");
			_PixelatedScene = Shader.PropertyToID("_PixelatedScene");
			_PixelatedScene_Depth = Shader.PropertyToID("_PixelatedScene_Depth");
			_OriginalScene = Shader.PropertyToID("_OriginalScene");
			_ProPixelizerOutline = Shader.PropertyToID("_ProPixelizerOutlines");
			_ProPixelizerOutlineObject = Shader.PropertyToID("ProPixelizerMetadata");
			RenderTextureDescriptor desc3 = cameraTextureDescriptor;
			desc3.depthBufferBits = 0;
			cmd.GetTemporaryRT(_PixelatedScene, desc3);
			cmd.GetTemporaryRT(_PixelatedScene_Depth, cameraTextureDescriptor.width, cameraTextureDescriptor.height, 32, FilterMode.Point, RenderTextureFormat.Depth);
			cmd.GetTemporaryRT(_OriginalScene, cameraTextureDescriptor, FilterMode.Point);
			_CameraDepthAttachment = Shader.PropertyToID("_CameraDepthAttachment");
			_CameraDepthAttachmentTemp = Shader.PropertyToID("_CameraDepthAttachmentTemp");
			_CameraDepthTexture = Shader.PropertyToID("_CameraDepthTexture");
			cmd.GetTemporaryRT(_CameraDepthAttachment, desc);
			cmd.GetTemporaryRT(_CameraDepthAttachmentTemp, desc);
			cmd.GetTemporaryRT(_PixelizationMap, desc2);
			TexelSize = new Vector4(1f / (float)cameraTextureDescriptor.width, 1f / (float)cameraTextureDescriptor.height, cameraTextureDescriptor.width, cameraTextureDescriptor.height);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("PIXELISATION");
			commandBuffer.name = "ProPixelizer Pixelisation";
			if (renderingData.cameraData.camera.orthographic)
			{
				Materials.PixelizationMap.EnableKeyword("ORTHO_PROJECTION");
			}
			else
			{
				Materials.PixelizationMap.DisableKeyword("ORTHO_PROJECTION");
			}
			if (renderingData.cameraData.camera.GetUniversalAdditionalCameraData().renderType == CameraRenderType.Overlay)
			{
				Materials.PixelizationMap.EnableKeyword("OVERLAY_CAMERA");
			}
			else
			{
				Materials.PixelizationMap.DisableKeyword("OVERLAY_CAMERA");
			}
			RenderTargetIdentifier cameraColorTarget = renderingData.cameraData.renderer.cameraColorTarget;
			RenderTargetIdentifier cameraDepthTarget = renderingData.cameraData.renderer.cameraDepthTarget;
			if (1 == 0)
			{
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
				return;
			}
			Blit(commandBuffer, cameraColorTarget, _OriginalScene);
			bool flag = renderingData.cameraData.camera.GetUniversalAdditionalCameraData().renderType == CameraRenderType.Overlay;
			if (SourceBuffer == PixelizationSource.SceneColor)
			{
				commandBuffer.SetGlobalTexture("_MainTex", _OriginalScene);
				if (flag)
				{
					commandBuffer.SetGlobalTexture("_SourceDepthTexture", cameraDepthTarget);
					commandBuffer.SetGlobalTexture("_SceneDepthTexture", cameraDepthTarget);
				}
				else
				{
					commandBuffer.SetGlobalTexture("_SourceDepthTexture", _CameraDepthTexture);
					commandBuffer.SetGlobalTexture("_SceneDepthTexture", _CameraDepthTexture);
				}
			}
			else
			{
				commandBuffer.SetGlobalTexture("_MainTex", _ProPixelizerOutlineObject);
				commandBuffer.SetGlobalTexture("_SourceDepthTexture", OutlinePass._OutlineObjectBuffer_Depth, RenderTextureSubElement.Depth);
				if (renderingData.cameraData.camera.GetUniversalAdditionalCameraData().renderType == CameraRenderType.Overlay)
				{
					commandBuffer.SetGlobalTexture("_SceneDepthTexture", renderingData.cameraData.renderer.cameraDepthTarget);
				}
				else
				{
					commandBuffer.SetGlobalTexture("_SceneDepthTexture", _CameraDepthTexture);
				}
			}
			Blit(commandBuffer, _OriginalScene, _PixelizationMap, Materials.PixelizationMap);
			commandBuffer.SetGlobalTexture("_MainTex", _OriginalScene);
			commandBuffer.SetGlobalTexture("_PixelizationMap", _PixelizationMap);
			commandBuffer.SetRenderTarget((RenderTargetIdentifier)_PixelatedScene, (RenderTargetIdentifier)_PixelatedScene_Depth);
			commandBuffer.SetViewMatrix(Matrix4x4.identity);
			commandBuffer.SetProjectionMatrix(Matrix4x4.identity);
			commandBuffer.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, Materials.ApplyPixelizationMap);
			commandBuffer.SetGlobalTexture("_MainTex", _PixelatedScene);
			commandBuffer.SetGlobalTexture("_SourceTex", _PixelatedScene);
			commandBuffer.SetGlobalTexture("_Depth", _PixelatedScene_Depth);
			if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Metal)
			{
				commandBuffer.SetRenderTarget(cameraColorTarget, cameraDepthTarget);
			}
			else
			{
				commandBuffer.SetRenderTarget(cameraColorTarget);
			}
			commandBuffer.SetViewMatrix(Matrix4x4.identity);
			commandBuffer.SetProjectionMatrix(Matrix4x4.identity);
			commandBuffer.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, Materials.CopyMainTexAndDepth);
			commandBuffer.SetGlobalTexture("_MainTex", _PixelatedScene_Depth);
			commandBuffer.SetRenderTarget(_CameraDepthAttachmentTemp);
			commandBuffer.SetViewMatrix(Matrix4x4.identity);
			commandBuffer.SetProjectionMatrix(Matrix4x4.identity);
			commandBuffer.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, Materials.CopyDepth);
			commandBuffer.SetViewMatrix(renderingData.cameraData.GetViewMatrix());
			commandBuffer.SetProjectionMatrix(renderingData.cameraData.GetProjectionMatrix());
			if (!flag)
			{
				Blit(commandBuffer, _CameraDepthAttachmentTemp, _CameraDepthTexture, Materials.CopyDepth);
			}
			Blit(commandBuffer, _CameraDepthAttachmentTemp, _CameraDepthAttachment, Materials.CopyDepth);
			if (!flag)
			{
				commandBuffer.SetGlobalTexture("_CameraDepthTexture", _CameraDepthTexture);
			}
			commandBuffer.SetViewMatrix(renderingData.cameraData.GetViewMatrix());
			commandBuffer.SetProjectionMatrix(renderingData.cameraData.GetProjectionMatrix());
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			cmd.ReleaseTemporaryRT(_PixelizationMap);
			cmd.ReleaseTemporaryRT(_CameraDepthAttachment);
			cmd.ReleaseTemporaryRT(_CameraDepthAttachmentTemp);
			cmd.ReleaseTemporaryRT(_PixelatedScene);
			cmd.ReleaseTemporaryRT(_PixelatedScene_Depth);
			cmd.ReleaseTemporaryRT(_OriginalScene);
		}
	}
}
