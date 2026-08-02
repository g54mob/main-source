using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
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
			URPScriptableRenderPass = 4
		}

		private Camera _activeCamera;

		private bool _isVRCulling;

		private int _hiZMipLevels;

		private bool _isDepthTex2DArray;

		private bool _vrMultiPassMono;

		private bool _isHiZDepthUpdated;

		private CommandBuffer _occlusionCommandBuffer;

		private RenderTargetIdentifier _unityDepthIdentifier;

		private RenderTargetIdentifier _hiZIdentifier;

		private RenderTextureSubElement _unityDepthSubElement;

		private const string GPUI_HiZ_DepthTexture_NAME = "GPUI_HiZDepthTexture";

		private const string GPUI_HiZ_CommandBuffer_NAME = "GPUI.HiZDepthTexture";

		public RenderTexture HiZDepthTexture { get; private set; }

		public int2 HiZTextureSize { get; private set; }

		public Texture UnityDepthTexture { get; private set; }

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

		private bool IsUseCommandBuffer
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
			_isVRCulling = isVRCulling;
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
			DisposeHiZDepthTexture();
			DisposeOcclusionCommandBuffer();
			DisposeScriptableRenderPass();
			UnityDepthTexture = null;
		}

		private void DetermineOcclusionCullingMode(GPUIOcclusionCullingMode cullingMode)
		{
			switch (cullingMode)
			{
			case GPUIOcclusionCullingMode.Auto:
				if (_isVRCulling)
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.DirectTextureAccess;
				}
				else if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.CommandBufferAddedToCamera;
				}
				else if (GPUIRuntimeSettings.Instance.IsHDRP)
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.CommandBufferExecutedOnEndRendering;
				}
				else
				{
					ActiveCullingMode = GPUIOcclusionCullingMode.DirectTextureAccess;
				}
				break;
			case GPUIOcclusionCullingMode.URPScriptableRenderPass:
				if (!GPUIRuntimeSettings.Instance.IsURP)
				{
					Debug.LogWarning("OcclusionCullingMode.URPScriptableRenderPass is only supported in Universal Render Pipeline! Switching to OcclusionCullingMode.Auto.");
					DetermineOcclusionCullingMode(GPUIOcclusionCullingMode.Auto);
				}
				else
				{
					Debug.LogWarning("OcclusionCullingMode.URPScriptableRenderPass is only supported for Unity versions 6000 or higher! Switching to OcclusionCullingMode.Auto.");
					DetermineOcclusionCullingMode(GPUIOcclusionCullingMode.Auto);
				}
				break;
			default:
				ActiveCullingMode = cullingMode;
				break;
			}
		}

		private bool CreateHiZDepthTexture(int2 screenSize)
		{
			DisposeOcclusionCommandBuffer();
			HiZTextureSize = screenSize;
			_hiZMipLevels = 1 + Mathf.FloorToInt(Mathf.Log(Mathf.Max(HiZTextureSize.x, HiZTextureSize.y), 2f));
			DisposeHiZDepthTexture();
			if (HiZTextureSize.x <= 0 || HiZTextureSize.y <= 0 || _hiZMipLevels == 0)
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
		}

		private int2 GetScreenSize()
		{
			int2 zero = int2.zero;
			if (_isVRCulling)
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
			if (GPUIRuntimeSettings.Instance.IsURP && GPUIRuntimeSettings.Instance.TryGetURPAsset(out var urpAsset) && urpAsset.renderScale != 1f)
			{
				zero.x = Mathf.FloorToInt((float)zero.x * urpAsset.renderScale);
				zero.y = Mathf.FloorToInt((float)zero.y * urpAsset.renderScale);
			}
			return zero;
		}

		internal void CheckScreenSize()
		{
			int2 screenSize = GetScreenSize();
			if (screenSize.x != HiZTextureSize.x || screenSize.y != HiZTextureSize.y)
			{
				Dispose();
			}
		}

		internal void UpdateHiZTexture(ScriptableRenderContext context)
		{
			_isHiZDepthUpdated = false;
			if (ActiveCullingMode != GPUIOcclusionCullingMode.URPScriptableRenderPass && UnityDepthTexture == null)
			{
				DisposeOcclusionCommandBuffer();
				UnityDepthTexture = Shader.GetGlobalTexture(GPUIConstants.PROP_CameraDepthTexture);
				if (UnityDepthTexture == null || UnityDepthTexture.name == "UnityBlack")
				{
					UnityDepthTexture = null;
					return;
				}
				_isDepthTex2DArray = UnityDepthTexture.dimension == TextureDimension.Tex2DArray;
			}
			if (HiZDepthTexture == null)
			{
				DisposeScriptableRenderPass();
				DisposeOcclusionCommandBuffer();
				if (!CreateHiZDepthTexture(GetScreenSize()))
				{
					return;
				}
			}
			if (IsUseCommandBuffer && _occlusionCommandBuffer == null)
			{
				CreateOcclusionCommandBuffer();
			}
			switch (ActiveCullingMode)
			{
			case GPUIOcclusionCullingMode.URPScriptableRenderPass:
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
		}

		private void DirectTextureAccessUpdate()
		{
			if (_isVRCulling)
			{
				if (XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass)
				{
					if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Left)
					{
						UpdateTextureWithComputeShader(0);
					}
					else if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Right)
					{
						UpdateTextureWithComputeShader(HiZTextureSize.x / 2);
					}
					else if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
					{
						if (!_vrMultiPassMono)
						{
							UpdateTextureWithComputeShader(0);
							_vrMultiPassMono = true;
						}
						else
						{
							UpdateTextureWithComputeShader(HiZTextureSize.x / 2);
							_vrMultiPassMono = false;
						}
					}
				}
				else if (_isDepthTex2DArray && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
				{
					UpdateTextureWithComputeShader(0);
					UpdateTextureWithComputeShader(HiZTextureSize.x / 2, 1);
				}
				else
				{
					UpdateTextureWithComputeShader(0);
				}
			}
			else if (_isDepthTex2DArray && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced && _activeCamera.stereoTargetEye == StereoTargetEyeMask.Right)
			{
				UpdateTextureWithComputeShader(0, 1);
			}
			else
			{
				UpdateTextureWithComputeShader(0);
			}
		}

		private void UpdateTextureWithComputeShader(int offset, int textureArrayIndex = 0)
		{
			if (_isDepthTex2DArray)
			{
				GPUITextureUtility.CopyHiZTextureArrayWithComputeShader(UnityDepthTexture, HiZDepthTexture, offset, textureArrayIndex);
			}
			else
			{
				GPUITextureUtility.CopyHiZTextureWithComputeShader(UnityDepthTexture, HiZDepthTexture, offset);
			}
			for (int i = 0; i < _hiZMipLevels - 1; i++)
			{
				GPUITextureUtility.ReduceTextureWithComputeShader(HiZDepthTexture, HiZDepthTexture, offset, i, i + 1);
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
			if (HiZDepthTexture == null || UnityDepthTexture == null)
			{
				return;
			}
			if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
			{
				_unityDepthIdentifier = new RenderTargetIdentifier(BuiltinRenderTextureType.Depth);
			}
			else
			{
				_unityDepthIdentifier = new RenderTargetIdentifier(UnityDepthTexture);
			}
			_unityDepthSubElement = (GPUIRuntimeSettings.Instance.IsBuiltInRP ? RenderTextureSubElement.Depth : RenderTextureSubElement.Color);
			_hiZIdentifier = new RenderTargetIdentifier(HiZDepthTexture);
			_occlusionCommandBuffer = new CommandBuffer();
			_occlusionCommandBuffer.name = "GPUI.HiZDepthTexture";
			if (_isVRCulling)
			{
				if (XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass)
				{
					if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Left || _activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
					{
						UpdateTextureWithComputeShaderCB(0);
					}
					else
					{
						UpdateTextureWithComputeShaderCB(HiZTextureSize.x / 2);
					}
					if (_activeCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
					{
						UpdateTextureWithComputeShaderCB(HiZTextureSize.x / 2);
					}
				}
				else if (_isDepthTex2DArray && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
				{
					UpdateTextureWithComputeShaderCB(0);
					UpdateTextureWithComputeShaderCB(HiZTextureSize.x / 2, 1);
				}
				else
				{
					UpdateTextureWithComputeShaderCB(0);
				}
			}
			else
			{
				UpdateTextureWithComputeShaderCB(0);
			}
			if (ActiveCullingMode == GPUIOcclusionCullingMode.CommandBufferAddedToCamera)
			{
				_activeCamera.AddCommandBuffer(CameraEvent.AfterDepthTexture, _occlusionCommandBuffer);
			}
		}

		private void UpdateTextureWithComputeShaderCB(int offset, int textureArrayIndex = 0)
		{
			if (_isDepthTex2DArray)
			{
				GPUITextureUtility.CopyHiZTextureArrayWithComputeShader(_occlusionCommandBuffer, _unityDepthIdentifier, _unityDepthSubElement, UnityDepthTexture.width, UnityDepthTexture.height, _hiZIdentifier, RenderTextureSubElement.Color, offset, textureArrayIndex);
			}
			else
			{
				GPUITextureUtility.CopyHiZTextureWithComputeShader(_occlusionCommandBuffer, _unityDepthIdentifier, _unityDepthSubElement, UnityDepthTexture.width, UnityDepthTexture.height, _hiZIdentifier, RenderTextureSubElement.Color, offset);
			}
			for (int i = 0; i < _hiZMipLevels - 1; i++)
			{
				GPUITextureUtility.ReduceTextureWithComputeShader(_occlusionCommandBuffer, _hiZIdentifier, RenderTextureSubElement.Color, HiZDepthTexture.width, HiZDepthTexture.height, _hiZIdentifier, RenderTextureSubElement.Color, offset, i, i + 1);
			}
		}
	}
}
