using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

namespace GPUInstancerPro
{
	public class GPUIOcclusionCullingData : IDisposable
	{
		public enum GPUIOcclusionCullingMode
		{
			Auto = 0,
			DirectTextureAccess = 1,
			CommandBufferAddedToCamera = 2,
			CommandBufferExecutedOnEndRendering = 3,
			URPScriptableRenderPass = 4,
			HDRPCustomPass = 5
		}

		private class GPUIOcclusionPassData
		{
			public ComputeShader copyCS;

			public ComputeShader reduceCS;

			public bool isVRCulling;

			public bool isDepth2DArray;

			public int hiZMipLevels;

			public Vector2Int hiZTextureSize;

			public void CopyTo(GPUIOcclusionPassData other)
			{
				other.copyCS = copyCS;
				other.reduceCS = reduceCS;
				other.isVRCulling = isVRCulling;
				other.isDepth2DArray = isDepth2DArray;
				other.hiZMipLevels = hiZMipLevels;
				other.hiZTextureSize = hiZTextureSize;
			}
		}

		private class GPUIHiZGeneratorRenderPass : ScriptableRenderPass, IDisposable
		{
			private class PassData : GPUIOcclusionPassData
			{
				public TextureHandle cameraDepthHandle;

				public TextureHandle hiZTextureHandle;

				public int eyeIndex;
			}

			private GPUIOcclusionCullingData _occlusionCullingData;

			private BaseRenderFunc<PassData, ComputeGraphContext> _renderFunc;

			private RTHandle _hiZTextureHandle;

			private int _eyeIndex;

			private CommandBuffer _compatibilityCB;

			public bool IsSetup { get; private set; }

			public GPUIHiZGeneratorRenderPass(GPUIOcclusionCullingData occlusionCullingData)
			{
				_occlusionCullingData = occlusionCullingData;
			}

			public void Setup(RenderTexture renderTexture, int eyeIndex = 0)
			{
				_hiZTextureHandle = RTHandles.Alloc(renderTexture);
				_eyeIndex = eyeIndex;
				IsSetup = true;
				ConfigureInput(ScriptableRenderPassInput.Depth);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				TextureHandle cameraDepthTexture = frameData.Get<UniversalResourceData>().cameraDepthTexture;
				TextureHandle hiZTextureHandle = renderGraph.ImportTexture(_hiZTextureHandle);
				int slices = cameraDepthTexture.GetDescriptor(renderGraph).slices;
				if (_renderFunc == null)
				{
					_renderFunc = CopyAndReducePass;
				}
				PassData passData;
				using IComputeRenderGraphBuilder computeRenderGraphBuilder = renderGraph.AddComputePass<PassData>("GPUI.HiZDepthPass", out passData, ".\\Packages\\com.gurbu.gpui-pro\\Runtime\\Scripts\\Data\\GPUIOcclusionCullingData.cs", 653);
				_occlusionCullingData._occlusionPassData.CopyTo(passData);
				passData.cameraDepthHandle = cameraDepthTexture;
				passData.hiZTextureHandle = hiZTextureHandle;
				passData.isDepth2DArray = slices > 1;
				passData.eyeIndex = _eyeIndex;
				computeRenderGraphBuilder.UseTexture(in cameraDepthTexture);
				computeRenderGraphBuilder.UseTexture(in hiZTextureHandle, AccessFlags.Write);
				computeRenderGraphBuilder.SetRenderFunc(_renderFunc);
			}

			private static void CopyAndReducePass(PassData data, ComputeGraphContext cgContext)
			{
				int num = (data.isVRCulling ? (data.hiZTextureSize.x / 2) : data.hiZTextureSize.x);
				if (data.isDepth2DArray)
				{
					GPUIHiZDepthTextureUtility.CopyHiZTextureArrayWithComputeShader(data.copyCS, cgContext.cmd, data.cameraDepthHandle, num, data.hiZTextureSize.y, data.hiZTextureHandle, 0, 0);
					if (data.isVRCulling)
					{
						GPUIHiZDepthTextureUtility.CopyHiZTextureArrayWithComputeShader(data.copyCS, cgContext.cmd, data.cameraDepthHandle, num, data.hiZTextureSize.y, data.hiZTextureHandle, num, 1);
					}
				}
				else if (data.eyeIndex == 0)
				{
					GPUIHiZDepthTextureUtility.CopyHiZTextureWithComputeShader(data.copyCS, cgContext.cmd, data.cameraDepthHandle, num, data.hiZTextureSize.y, data.hiZTextureHandle, 0);
				}
				else if (data.isVRCulling)
				{
					GPUIHiZDepthTextureUtility.CopyHiZTextureWithComputeShader(data.copyCS, cgContext.cmd, data.cameraDepthHandle, num, data.hiZTextureSize.y, data.hiZTextureHandle, num);
				}
				for (int i = 0; i < data.hiZMipLevels - 1; i++)
				{
					GPUIHiZDepthTextureUtility.ReduceTextureWithComputeShader(data.reduceCS, cgContext.cmd, data.hiZTextureHandle, data.hiZTextureSize.x, data.hiZTextureSize.y, i, i + 1);
				}
			}

			public void Dispose()
			{
				_hiZTextureHandle.Release();
				IsSetup = false;
				if (_compatibilityCB != null)
				{
					_compatibilityCB.Dispose();
					_compatibilityCB = null;
				}
			}
		}

		private Camera _activeCamera;

		private bool _vrMultiPassMono;

		private bool _isHiZDepthUpdated;

		private GPUIOcclusionPassData _occlusionPassData;

		private CommandBuffer _occlusionCommandBuffer;

		private RenderTargetIdentifier _hiZDepthIdentifier;

		private const string GPUI_HiZ_DepthTexture_NAME = "GPUI_HiZDepthTexture";

		private const string GPUI_HiZ_CommandBuffer_NAME = "GPUI.HiZDepthPass";

		private GPUIHiZGeneratorRenderPass _hiZGeneratorRenderPass;

		private GPUIHiZGeneratorRenderPass _hiZGeneratorRenderPassRightEye;

		private int _renderPassQueuedFrameCount;

		public RenderTexture HiZDepthTexture { get; private set; }

		public Vector2Int HiZTextureSize => _occlusionPassData.hiZTextureSize;

		public int HiZMipLevels => _occlusionPassData.hiZMipLevels;

		public Texture CameraDepthTexture { get; private set; }

		public GPUIOcclusionCullingMode ActiveCullingMode { get; private set; }

		public bool IsHiZDepthUpdated
		{
			get
			{
				if (HiZDepthTexture != null)
				{
					return _isHiZDepthUpdated;
				}
				return false;
			}
		}

		private bool IsDirectCameraDepthAccessRequired
		{
			get
			{
				if (ActiveCullingMode != GPUIOcclusionCullingMode.DirectTextureAccess)
				{
					return ActiveCullingMode == GPUIOcclusionCullingMode.CommandBufferExecutedOnEndRendering;
				}
				return true;
			}
		}

		private bool IsCommandBufferRequired
		{
			get
			{
				if (ActiveCullingMode != GPUIOcclusionCullingMode.CommandBufferAddedToCamera)
				{
					return ActiveCullingMode == GPUIOcclusionCullingMode.CommandBufferExecutedOnEndRendering;
				}
				return true;
			}
		}

		public GPUIOcclusionCullingData(Camera camera, GPUIOcclusionCullingMode cullingMode, bool isVRCulling)
		{
			_activeCamera = camera;
			_occlusionPassData = new GPUIOcclusionPassData
			{
				copyCS = GPUIConstants.CS_HiZTextureCopy,
				reduceCS = GPUIConstants.CS_TextureReduce,
				isVRCulling = isVRCulling,
				isDepth2DArray = GPUIRuntimeSettings.Instance.IsHDRP
			};
			Initialize(cullingMode);
		}

		public void Initialize(GPUIOcclusionCullingMode cullingMode)
		{
			Dispose();
			_activeCamera.depthTextureMode |= DepthTextureMode.Depth;
			DetermineOcclusionCullingMode(cullingMode);
		}

		public void Dispose()
		{
			DisposeOcclusionCommandBuffer();
			DisposeScriptableRenderPass();
			DisposeCustomPass();
			DisposeHiZDepthTexture();
			CameraDepthTexture = null;
			_isHiZDepthUpdated = false;
		}

		private void OnHiZTextureSizeChanged()
		{
			DisposeOcclusionCommandBuffer();
			DisposeScriptableRenderPass();
			DisposeHiZDepthTexture();
			_isHiZDepthUpdated = false;
		}

		private void OnScreenSizeChanged()
		{
			DisposeOcclusionCommandBuffer();
			_isHiZDepthUpdated = false;
		}

		private void DetermineOcclusionCullingMode(GPUIOcclusionCullingMode cullingMode)
		{
			switch (cullingMode)
			{
			case GPUIOcclusionCullingMode.Auto:
				if (GPUIRuntimeSettings.Instance.IsURP && !GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.URPScriptableRenderPass;
				}
				else if (_occlusionPassData.isVRCulling)
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.DirectTextureAccess;
				}
				else if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
				{
					if (_activeCamera.actualRenderingPath == RenderingPath.DeferredShading)
					{
						ActiveCullingMode = GPUIOcclusionCullingMode.DirectTextureAccess;
					}
					else
					{
						ActiveCullingMode = GPUIOcclusionCullingMode.CommandBufferAddedToCamera;
					}
				}
				else
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.DirectTextureAccess;
				}
				return;
			case GPUIOcclusionCullingMode.URPScriptableRenderPass:
				if (!GPUIRuntimeSettings.Instance.IsURP)
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "OcclusionCullingMode.URPScriptableRenderPass is only supported in Universal Render Pipeline! Switching to OcclusionCullingMode.Auto.");
					DetermineOcclusionCullingMode(GPUIOcclusionCullingMode.Auto);
					return;
				}
				break;
			}
			if (cullingMode == GPUIOcclusionCullingMode.HDRPCustomPass && !GPUIRuntimeSettings.Instance.IsHDRP)
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "OcclusionCullingMode.HDRPCustomPass is only supported in HDRP! Switching to OcclusionCullingMode.Auto.");
				DetermineOcclusionCullingMode(GPUIOcclusionCullingMode.Auto);
			}
			else
			{
				ActiveCullingMode = cullingMode;
			}
		}

		private bool CreateHiZDepthTexture(Vector2Int screenSize)
		{
			OnHiZTextureSizeChanged();
			_occlusionPassData.hiZTextureSize = screenSize;
			_occlusionPassData.hiZMipLevels = GetMipLevelCount();
			if (HiZTextureSize.x <= 0 || HiZTextureSize.y <= 0 || _occlusionPassData.hiZMipLevels == 0)
			{
				return false;
			}
			HiZDepthTexture = new RenderTexture(HiZTextureSize.x, HiZTextureSize.y, 0, RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear)
			{
				name = "GPUI_HiZDepthTexture",
				filterMode = FilterMode.Point,
				useMipMap = true,
				autoGenerateMips = false,
				enableRandomWrite = true,
				hideFlags = HideFlags.HideAndDontSave
			};
			HiZDepthTexture.Create();
			HiZDepthTexture.GenerateMips();
			_hiZDepthIdentifier = new RenderTargetIdentifier(HiZDepthTexture);
			return true;
		}

		private void DisposeHiZDepthTexture()
		{
			if (HiZDepthTexture != null)
			{
				HiZDepthTexture.DestroyRenderTexture();
				HiZDepthTexture = null;
			}
		}

		private void DisposeScriptableRenderPass()
		{
			if (_hiZGeneratorRenderPass != null)
			{
				_hiZGeneratorRenderPass.Dispose();
				_hiZGeneratorRenderPass = null;
			}
			if (_hiZGeneratorRenderPassRightEye != null)
			{
				_hiZGeneratorRenderPassRightEye.Dispose();
				_hiZGeneratorRenderPassRightEye = null;
			}
		}

		private void DisposeCustomPass()
		{
		}

		private Vector2Int GetScreenSize()
		{
			Vector2Int zero = Vector2Int.zero;
			if (_occlusionPassData.isVRCulling)
			{
				zero.x = XRSettings.eyeTextureWidth;
				zero.y = XRSettings.eyeTextureHeight;
				zero.x *= 2;
			}
			else
			{
				zero.x = _activeCamera.pixelWidth;
				zero.y = _activeCamera.pixelHeight;
			}
			if (!_occlusionPassData.isVRCulling && GPUIRuntimeSettings.Instance.IsURP && GPUIRuntimeSettings.TryGetURPAsset(out var urpAsset) && urpAsset.renderScale != 1f)
			{
				zero.x = Mathf.FloorToInt((float)zero.x * urpAsset.renderScale);
				zero.y = Mathf.FloorToInt((float)zero.y * urpAsset.renderScale);
			}
			return zero;
		}

		private int GetMipLevelCount()
		{
			return 1 + Mathf.FloorToInt(Mathf.Log(Mathf.Max(HiZTextureSize.x, HiZTextureSize.y), 2f));
		}

		internal void CheckScreenSize()
		{
			if (HiZDepthTexture == null)
			{
				return;
			}
			Vector2Int screenSize = GetScreenSize();
			if (screenSize.x != HiZTextureSize.x || screenSize.y != HiZTextureSize.y)
			{
				if (screenSize.x <= HiZDepthTexture.width && screenSize.y <= HiZDepthTexture.height)
				{
					_occlusionPassData.hiZTextureSize = screenSize;
					_occlusionPassData.hiZMipLevels = GetMipLevelCount();
					OnScreenSizeChanged();
					HiZDepthTexture.ClearRenderTexture(Color.white);
					HiZDepthTexture.GenerateMips();
				}
				else
				{
					OnHiZTextureSizeChanged();
				}
				CameraDepthTexture = null;
			}
		}

		internal void UpdateHiZTexture(ScriptableRenderContext context)
		{
			_isHiZDepthUpdated = false;
			if (IsDirectCameraDepthAccessRequired && CameraDepthTexture == null)
			{
				DisposeOcclusionCommandBuffer();
				CameraDepthTexture = Shader.GetGlobalTexture(GPUIConstants.PROP_CameraDepthTexture);
				if (CameraDepthTexture == null || CameraDepthTexture.name == "UnityBlack")
				{
					CameraDepthTexture = null;
					return;
				}
				_occlusionPassData.isDepth2DArray = CameraDepthTexture.dimension == TextureDimension.Tex2DArray;
			}
			if (HiZDepthTexture == null && !CreateHiZDepthTexture(GetScreenSize()))
			{
				return;
			}
			if (ActiveCullingMode == GPUIOcclusionCullingMode.URPScriptableRenderPass)
			{
				_isHiZDepthUpdated = true;
				if (_hiZGeneratorRenderPass == null)
				{
					_hiZGeneratorRenderPass = new GPUIHiZGeneratorRenderPass(this);
					_isHiZDepthUpdated = false;
				}
				if (!_hiZGeneratorRenderPass.IsSetup)
				{
					_hiZGeneratorRenderPass.Setup(HiZDepthTexture);
					_isHiZDepthUpdated = false;
				}
				if (_occlusionPassData.isVRCulling && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass && _hiZGeneratorRenderPassRightEye == null)
				{
					_hiZGeneratorRenderPassRightEye = new GPUIHiZGeneratorRenderPass(this);
					_isHiZDepthUpdated = false;
				}
				if (_hiZGeneratorRenderPassRightEye != null && !_hiZGeneratorRenderPassRightEye.IsSetup)
				{
					_hiZGeneratorRenderPassRightEye.Setup(HiZDepthTexture, 1);
					_isHiZDepthUpdated = false;
				}
				return;
			}
			if (IsCommandBufferRequired && _occlusionCommandBuffer == null)
			{
				CreateOcclusionCommandBuffer();
				if (ActiveCullingMode == GPUIOcclusionCullingMode.CommandBufferAddedToCamera)
				{
					_activeCamera.AddCommandBuffer(CameraEvent.AfterDepthTexture, _occlusionCommandBuffer);
					return;
				}
			}
			switch (ActiveCullingMode)
			{
			case GPUIOcclusionCullingMode.URPScriptableRenderPass:
			case GPUIOcclusionCullingMode.HDRPCustomPass:
				_isHiZDepthUpdated = true;
				break;
			case GPUIOcclusionCullingMode.CommandBufferAddedToCamera:
				_isHiZDepthUpdated = true;
				break;
			case GPUIOcclusionCullingMode.CommandBufferExecutedOnEndRendering:
				if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
				{
					Graphics.ExecuteCommandBuffer(_occlusionCommandBuffer);
				}
				else
				{
					context.ExecuteCommandBuffer(_occlusionCommandBuffer);
				}
				_isHiZDepthUpdated = true;
				break;
			case GPUIOcclusionCullingMode.DirectTextureAccess:
				DirectTextureAccessUpdate();
				_isHiZDepthUpdated = true;
				break;
			}
		}

		internal void UpdateHiZTextureOnBeginRendering(Camera camera, ScriptableRenderContext context)
		{
			if (ActiveCullingMode != GPUIOcclusionCullingMode.URPScriptableRenderPass || _hiZGeneratorRenderPass == null)
			{
				return;
			}
			if (_occlusionPassData.isVRCulling && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass && _hiZGeneratorRenderPassRightEye != null)
			{
				if (_renderPassQueuedFrameCount != Time.frameCount)
				{
					camera.GetUniversalAdditionalCameraData().scriptableRenderer.EnqueuePass(_hiZGeneratorRenderPass);
				}
				else
				{
					camera.GetUniversalAdditionalCameraData().scriptableRenderer.EnqueuePass(_hiZGeneratorRenderPassRightEye);
				}
				_renderPassQueuedFrameCount = Time.frameCount;
			}
			else
			{
				camera.GetUniversalAdditionalCameraData().scriptableRenderer.EnqueuePass(_hiZGeneratorRenderPass);
			}
		}

		private void DirectTextureAccessUpdate()
		{
			if (_occlusionPassData.isVRCulling)
			{
				int num = HiZTextureSize.x / 2;
				if (XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass)
				{
					if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Left)
					{
						UpdateTextureWithComputeShader(num, 0);
					}
					else if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Right)
					{
						UpdateTextureWithComputeShader(num, num);
					}
					else if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
					{
						if (!_vrMultiPassMono)
						{
							UpdateTextureWithComputeShader(num, 0);
							_vrMultiPassMono = true;
						}
						else
						{
							UpdateTextureWithComputeShader(num, num);
							_vrMultiPassMono = false;
						}
					}
				}
				else if (_occlusionPassData.isDepth2DArray && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
				{
					UpdateTextureWithComputeShader(num, 0);
					UpdateTextureWithComputeShader(num, num, 1);
				}
				else
				{
					UpdateTextureWithComputeShader(HiZTextureSize.x, 0);
				}
			}
			else if (_occlusionPassData.isDepth2DArray && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced && _activeCamera.stereoTargetEye == StereoTargetEyeMask.Right)
			{
				UpdateTextureWithComputeShader(0, 0, 1);
			}
			else
			{
				UpdateTextureWithComputeShader(HiZTextureSize.x, 0);
			}
			for (int i = 0; i < _occlusionPassData.hiZMipLevels - 1; i++)
			{
				GPUIHiZDepthTextureUtility.ReduceTextureWithComputeShader(_occlusionPassData.reduceCS, HiZDepthTexture, HiZTextureSize.x, HiZTextureSize.y, i, i + 1);
			}
		}

		private void UpdateTextureWithComputeShader(int sourceWidth, int offset, int textureArrayIndex = 0)
		{
			if (_occlusionPassData.isDepth2DArray)
			{
				GPUIHiZDepthTextureUtility.CopyHiZTextureArrayWithComputeShader(_occlusionPassData.copyCS, CameraDepthTexture, HiZDepthTexture, offset, textureArrayIndex);
			}
			else
			{
				GPUIHiZDepthTextureUtility.CopyHiZTextureWithComputeShader(_occlusionPassData.copyCS, CameraDepthTexture, HiZDepthTexture, offset);
			}
		}

		private void DisposeOcclusionCommandBuffer()
		{
			if (_occlusionCommandBuffer != null)
			{
				if (ActiveCullingMode == GPUIOcclusionCullingMode.CommandBufferAddedToCamera)
				{
					_activeCamera.RemoveCommandBuffer(CameraEvent.AfterDepthTexture, _occlusionCommandBuffer);
				}
				_occlusionCommandBuffer.Dispose();
				_occlusionCommandBuffer = null;
			}
		}

		private void CreateOcclusionCommandBuffer()
		{
			DisposeOcclusionCommandBuffer();
			RenderTargetIdentifier unityDepthIdentifier = ((!GPUIRuntimeSettings.Instance.IsBuiltInRP) ? new RenderTargetIdentifier(CameraDepthTexture) : new RenderTargetIdentifier(BuiltinRenderTextureType.Depth));
			_occlusionCommandBuffer = new CommandBuffer();
			_occlusionCommandBuffer.name = "GPUI.HiZDepthPass";
			CreateOcclusionCommandBuffer(_occlusionCommandBuffer, unityDepthIdentifier);
		}

		private void CreateOcclusionCommandBuffer(CommandBuffer commandBuffer, RenderTargetIdentifier unityDepthIdentifier)
		{
			if (HiZDepthTexture == null)
			{
				return;
			}
			if (_occlusionPassData.isVRCulling)
			{
				int num = HiZTextureSize.x / 2;
				if (XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass)
				{
					if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Left || _activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
					{
						UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, num, 0);
					}
					else
					{
						UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, num, num);
					}
					if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
					{
						UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, num, num);
					}
				}
				else if (_occlusionPassData.isDepth2DArray && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
				{
					UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, num, 0);
					UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, num, num, 1);
				}
				else
				{
					UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, num, 0);
				}
			}
			else
			{
				UpdateTextureWithComputeShaderCB(commandBuffer, unityDepthIdentifier, _hiZDepthIdentifier, HiZTextureSize.x, 0);
			}
			for (int i = 0; i < _occlusionPassData.hiZMipLevels - 1; i++)
			{
				GPUIHiZDepthTextureUtility.ReduceTextureWithComputeShader(_occlusionPassData.reduceCS, commandBuffer, _hiZDepthIdentifier, HiZTextureSize.x, HiZTextureSize.y, i, i + 1);
			}
		}

		private void UpdateTextureWithComputeShaderCB(CommandBuffer commandBuffer, RenderTargetIdentifier unityDepthIdentifier, RenderTargetIdentifier hiZIdentifier, int sourceWidth, int offset, int textureArrayIndex = 0)
		{
			if (_occlusionPassData.isDepth2DArray)
			{
				GPUIHiZDepthTextureUtility.CopyHiZTextureArrayWithComputeShader(_occlusionPassData.copyCS, commandBuffer, unityDepthIdentifier, HiZTextureSize.x, HiZTextureSize.y, hiZIdentifier, offset, textureArrayIndex);
			}
			else
			{
				GPUIHiZDepthTextureUtility.CopyHiZTextureWithComputeShader(_occlusionPassData.copyCS, commandBuffer, unityDepthIdentifier, HiZTextureSize.x, HiZTextureSize.y, hiZIdentifier, offset);
			}
		}
	}
}
