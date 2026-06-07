using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

namespace GPUInstancerPro
{
	public class GPUICameraData : IGPUIDisposable, IDisposable
	{
		private Camera _camera;

		private bool _isCullingInitialized;

		internal GPUIVisibilityBuffer _visibilityBuffer;

		internal GPUIDataBuffer<GraphicsBuffer.IndirectDrawIndexedArgs> _commandBuffer;

		internal Dictionary<int, int> _visibilityBufferIndexes;

		protected Transform _cachedTransform;

		protected ComputeShader _CS_CommandBufferUtility;

		protected ComputeShader _CS_CameraVisibility;

		protected ComputeShader _CS_OptionalRenderer;

		private Matrix4x4 _mvpMatrix;

		private Vector4 _cameraPositionAndHalfAngle;

		private Vector4 _additionalValues;

		private Quaternion _cameraRotation;

		private int[] _sizeAndIndexes;

		private int[] _sizeAndIndexes2;

		public string name;

		internal int _instanceCountMultiplier = 1;

		public bool autoInitializeOcclusionCulling;

		private float _dynamicOcclusionOffsetIntensity;

		private int[] _hiZTextureSize;

		private Matrix4x4 _mvpMatrix2;

		private bool _isVRCulling;

		public Camera ActiveCamera => _camera;

		public GPUIOcclusionCullingData OcclusionCullingData { get; private set; }

		public RenderTexture HiZDepthTexture
		{
			get
			{
				if (OcclusionCullingData != null)
				{
					return OcclusionCullingData.HiZDepthTexture;
				}
				return null;
			}
		}

		public Vector2Int HiZTextureSize
		{
			get
			{
				if (OcclusionCullingData != null)
				{
					return OcclusionCullingData.HiZTextureSize;
				}
				return Vector2Int.zero;
			}
		}

		public bool IsVRCulling => _isVRCulling;

		public GPUICameraData(Camera camera)
		{
			_camera = camera;
			_cachedTransform = _camera.transform;
			name = camera.name;
			_CS_CommandBufferUtility = GPUIConstants.CS_CommandBufferUtility;
			_CS_CameraVisibility = GPUIConstants.CS_CameraVisibility;
			_CS_OptionalRenderer = GPUIConstants.CS_OptionalRenderer;
			_visibilityBuffer = new GPUIVisibilityBuffer(this, "Visibility");
			_visibilityBufferIndexes = new Dictionary<int, int>();
			_commandBuffer = new GPUIDataBuffer<GraphicsBuffer.IndirectDrawIndexedArgs>("Command", 0, GraphicsBuffer.Target.IndirectArguments);
			_sizeAndIndexes = new int[4];
			_sizeAndIndexes2 = new int[4];
			_hiZTextureSize = new int[4];
		}

		public void ReleaseBuffers()
		{
			DisableOcclusionCulling();
			if (_visibilityBuffer != null)
			{
				_visibilityBuffer.ReleaseBuffers();
			}
			if (_visibilityBufferIndexes != null)
			{
				_visibilityBufferIndexes.Clear();
			}
			if (_commandBuffer != null)
			{
				_commandBuffer.ReleaseBuffers();
			}
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.RenderSourceGroupProvider.DisposeCameraData(this);
			}
		}

		public void Dispose()
		{
			ReleaseBuffers();
			if (OcclusionCullingData != null)
			{
				OcclusionCullingData.Dispose();
				OcclusionCullingData = null;
			}
			_isCullingInitialized = false;
		}

		internal bool InitializeCulling()
		{
			GPUIRuntimeSettings.Instance.SetRuntimeSettings();
			_instanceCountMultiplier = 1;
			_isVRCulling = false;
			if (GPUIRuntimeSettings.Instance.IsVREnabled)
			{
				if (XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
				{
					_instanceCountMultiplier = 2;
				}
				_isVRCulling = _camera.stereoTargetEye == StereoTargetEyeMask.Both && !GPUIRuntimeSettings.Instance.IsHDRP;
				if (_isVRCulling)
				{
					_CS_CameraVisibility = GPUIConstants.CS_CameraVisibilityXR;
					if (_CS_CameraVisibility == null)
					{
						Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find XR visibility compute shader for camera. Make sure to import the XR support package by selecting Tools -> GPU Instancer Pro -> Reimport Packages or by manually importing the unity package under Packages/GPU Instancer Pro - Core/Editor/Extras/XR_Support_GPUIPro.", _camera);
						return false;
					}
				}
			}
			_isCullingInitialized = true;
			return true;
		}

		private void InitializeOcclusionCulling()
		{
			if (!_isCullingInitialized && !InitializeCulling())
			{
				return;
			}
			autoInitializeOcclusionCulling = false;
			if (!GPUIRuntimeSettings.Instance.DisableOcclusionCulling && GPUIRuntimeSettings.Instance.occlusionCullingCondition != GPUIOcclusionCullingCondition.Never && (GPUIRuntimeSettings.Instance.occlusionCullingCondition != GPUIOcclusionCullingCondition.IfDepthAvailable || ActiveCamera.IsDepthTextureAvailable()))
			{
				if (GPUIRuntimeSettings.Instance.IsVREnabled && GPUIRuntimeSettings.Instance.IsHDRP)
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "GPU Instancer Pro currently does not support Occlusion Culling for VR devices on HDRP. Occlusion culling will be disabled.");
				}
				else if (OcclusionCullingData == null)
				{
					OcclusionCullingData = new GPUIOcclusionCullingData(ActiveCamera, GPUIRuntimeSettings.Instance.occlusionCullingMode, _isVRCulling);
				}
			}
		}

		public void DisableOcclusionCulling()
		{
			autoInitializeOcclusionCulling = false;
			if (OcclusionCullingData != null)
			{
				OcclusionCullingData.Dispose();
				OcclusionCullingData = null;
			}
		}

		internal void UpdateHiZTexture(ScriptableRenderContext context)
		{
			if (OcclusionCullingData != null)
			{
				OcclusionCullingData.UpdateHiZTexture(context);
				_hiZTextureSize[0] = OcclusionCullingData.HiZTextureSize.x;
				_hiZTextureSize[1] = OcclusionCullingData.HiZTextureSize.y;
				if (OcclusionCullingData.HiZDepthTexture != null)
				{
					_hiZTextureSize[2] = OcclusionCullingData.HiZDepthTexture.width;
					_hiZTextureSize[3] = OcclusionCullingData.HiZDepthTexture.height;
				}
			}
		}

		internal void UpdateHiZTextureOnBeginRendering(Camera camera, ScriptableRenderContext context)
		{
			if (OcclusionCullingData != null)
			{
				OcclusionCullingData.UpdateHiZTextureOnBeginRendering(camera, context);
			}
		}

		public virtual void UpdateCameraData()
		{
			if (!_isCullingInitialized && !InitializeCulling())
			{
				return;
			}
			if (autoInitializeOcclusionCulling)
			{
				InitializeOcclusionCulling();
			}
			_commandBuffer.UpdateBufferData();
			Matrix4x4 worldToCameraMatrix = _camera.worldToCameraMatrix;
			if (GPUIRuntimeSettings.Instance.IsVREnabled)
			{
				if (_camera.stereoEnabled)
				{
					if (_isVRCulling)
					{
						_mvpMatrix = _camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left) * worldToCameraMatrix;
						_mvpMatrix2 = _camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right) * worldToCameraMatrix;
					}
					else if (_camera.stereoTargetEye == StereoTargetEyeMask.Left)
					{
						_mvpMatrix = _camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left) * worldToCameraMatrix;
					}
					else if (_camera.stereoTargetEye == StereoTargetEyeMask.Right)
					{
						_mvpMatrix = _camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right) * worldToCameraMatrix;
					}
					else
					{
						_mvpMatrix = _camera.projectionMatrix * worldToCameraMatrix;
					}
				}
				else
				{
					_mvpMatrix = _camera.projectionMatrix * worldToCameraMatrix;
				}
			}
			else
			{
				_mvpMatrix = _camera.projectionMatrix * worldToCameraMatrix;
			}
			Vector3 position = _cachedTransform.position;
			if (OcclusionCullingData != null)
			{
				if (_dynamicOcclusionOffsetIntensity > 0f)
				{
					Quaternion rotation = _cachedTransform.rotation;
					_additionalValues.y = MathF.Max(Vector3.Distance(position, _cameraPositionAndHalfAngle) * 0.01f, (1f - Mathf.Abs(Quaternion.Dot(rotation, _cameraRotation))) * 100f) * _dynamicOcclusionOffsetIntensity;
					_cameraRotation = rotation;
				}
				else
				{
					_additionalValues.y = 0f;
				}
				OcclusionCullingData.CheckScreenSize();
			}
			_cameraPositionAndHalfAngle.x = position.x;
			_cameraPositionAndHalfAngle.y = position.y;
			_cameraPositionAndHalfAngle.z = position.z;
			_cameraPositionAndHalfAngle.w = Mathf.Tan(MathF.PI / 180f * _camera.fieldOfView * 0.25f);
			MakeVisibilityCalculations();
		}

		protected void MakeVisibilityCalculations()
		{
			bool flag = _visibilityBuffer.UpdateBufferData();
			if (_visibilityBuffer.Buffer == null || GPUIRenderingSystem.Instance.ParameterBuffer.Buffer == null)
			{
				return;
			}
			int frameCount = Time.frameCount;
			if (!flag)
			{
				if (_visibilityBuffer.IsDataRequested())
				{
					_visibilityBuffer.WaitForReadbackCompletion();
				}
				_CS_CommandBufferUtility.SetBuffer(0, GPUIConstants.PROP_visibilityBuffer, _visibilityBuffer);
				_CS_CommandBufferUtility.SetInt(GPUIConstants.PROP_bufferSize, _visibilityBuffer.Length);
				_CS_CommandBufferUtility.DispatchX(0, _visibilityBuffer.Length);
			}
			_CS_CameraVisibility.SetMatrix(GPUIConstants.PROP_mvpMatrix, _mvpMatrix);
			_CS_CameraVisibility.SetVector(GPUIConstants.PROP_cameraPositionAndHalfAngle, _cameraPositionAndHalfAngle);
			_CS_CameraVisibility.SetBuffer(0, GPUIConstants.PROP_parameterBuffer, GPUIRenderingSystem.Instance.ParameterBuffer);
			_CS_CameraVisibility.SetBuffer(0, GPUIConstants.PROP_visibilityBuffer, _visibilityBuffer);
			bool flag2 = OcclusionCullingData != null && OcclusionCullingData.IsHiZDepthUpdated && _hiZTextureSize[2] > 0 && _hiZTextureSize[3] > 0;
			int maximumLODLevel = QualitySettings.maximumLODLevel;
			foreach (GPUIRenderSourceGroup value in GPUIRenderingSystem.Instance.RenderSourceGroupProvider.Values)
			{
				GPUILODGroupData lODGroupData = value.LODGroupData;
				if (value.BufferSize <= 0 || value.InstanceCount <= 0 || lODGroupData == null || !_visibilityBufferIndexes.TryGetValue(value.Key, out _sizeAndIndexes[1]) || !value.Profile.TryGetParameterBufferIndex(out _sizeAndIndexes[2]) || !lODGroupData.TryGetParameterBufferIndex(out _sizeAndIndexes[3]))
				{
					continue;
				}
				bool flag3 = lODGroupData.Length > 1 || lODGroupData.transitionValues[0] > 0f;
				_sizeAndIndexes[0] = value.BufferSize;
				GPUITransformBufferData transformBufferData = value.TransformBufferData;
				transformBufferData.ApplyTransformDataUpdates();
				GPUIShaderBuffer transformBuffer = transformBufferData.GetTransformBuffer(this);
				if (transformBuffer.Buffer == null)
				{
					continue;
				}
				_additionalValues.z = Mathf.Max(maximumLODLevel, value.Profile.maximumLODLevel);
				GPUIShaderBuffer instanceDataBuffer = transformBufferData.GetInstanceDataBuffer(this);
				_CS_CameraVisibility.SetBuffer(0, GPUIConstants.PROP_gpuiTransformBuffer, transformBuffer.Buffer);
				instanceDataBuffer.SetBuffer(_CS_CameraVisibility, 0, GPUIConstants.PROP_gpuiInstanceDataBuffer);
				if (flag3)
				{
					if (value.Profile.isLODCrossFade)
					{
						if (value.Profile.isAnimateCrossFade && !transformBufferData.IsCameraBasedBuffer)
						{
							_CS_CameraVisibility.DisableKeyword("GPUI_LOD");
							_CS_CameraVisibility.DisableKeyword("GPUI_LOD_CROSSFADE");
							_CS_CameraVisibility.EnableKeyword("GPUI_LOD_CROSSFADE_ANIMATE");
							_additionalValues.x = ((transformBufferData.resetCrossFadeDataFrame == frameCount) ? 0f : GPUIRenderingSystem.Instance.TimeSinceLastDrawCall);
						}
						else
						{
							_CS_CameraVisibility.DisableKeyword("GPUI_LOD");
							_CS_CameraVisibility.EnableKeyword("GPUI_LOD_CROSSFADE");
							_CS_CameraVisibility.DisableKeyword("GPUI_LOD_CROSSFADE_ANIMATE");
						}
					}
					else
					{
						_CS_CameraVisibility.EnableKeyword("GPUI_LOD");
						_CS_CameraVisibility.DisableKeyword("GPUI_LOD_CROSSFADE");
						_CS_CameraVisibility.DisableKeyword("GPUI_LOD_CROSSFADE_ANIMATE");
					}
				}
				else
				{
					_CS_CameraVisibility.DisableKeyword("GPUI_LOD");
					_CS_CameraVisibility.DisableKeyword("GPUI_LOD_CROSSFADE");
					_CS_CameraVisibility.DisableKeyword("GPUI_LOD_CROSSFADE_ANIMATE");
				}
				if (value.Profile.isShadowCasting)
				{
					if (value.Profile.isShadowFrustumCulling || value.Profile.isShadowOcclusionCulling)
					{
						_CS_CameraVisibility.DisableKeyword("GPUI_SHADOWCASTING");
						_CS_CameraVisibility.EnableKeyword("GPUI_SHADOWCULLED");
					}
					else
					{
						_CS_CameraVisibility.EnableKeyword("GPUI_SHADOWCASTING");
						_CS_CameraVisibility.DisableKeyword("GPUI_SHADOWCULLED");
					}
				}
				else
				{
					_CS_CameraVisibility.DisableKeyword("GPUI_SHADOWCASTING");
					_CS_CameraVisibility.DisableKeyword("GPUI_SHADOWCULLED");
				}
				if (value.Profile.isOcclusionCulling && flag2)
				{
					_CS_CameraVisibility.EnableKeyword("GPUI_OCCLUSION_CULLING");
					_CS_CameraVisibility.SetTexture(0, GPUIConstants.PROP_hiZMap, OcclusionCullingData.HiZDepthTexture);
					_CS_CameraVisibility.SetInts(GPUIConstants.PROP_hiZTxtrSize, _hiZTextureSize);
				}
				else
				{
					_CS_CameraVisibility.DisableKeyword("GPUI_OCCLUSION_CULLING");
				}
				if (_isVRCulling)
				{
					_CS_CameraVisibility.SetMatrix(GPUIConstants.PROP_mvpMatrix2, _mvpMatrix2);
				}
				_CS_CameraVisibility.SetInts(GPUIConstants.PROP_sizeAndIndexes, _sizeAndIndexes);
				_CS_CameraVisibility.SetVector(GPUIConstants.PROP_additionalValues, _additionalValues);
				for (int i = 0; i < value.RenderSources.Count; i++)
				{
					GPUIRenderSource gPUIRenderSource = value.RenderSources[i];
					int num = (transformBufferData.IsCameraBasedBuffer ? value.BufferSize : gPUIRenderSource.instanceCount);
					if (num > 0 && gPUIRenderSource.bufferStartIndex >= 0)
					{
						_sizeAndIndexes2[0] = num;
						_sizeAndIndexes2[1] = gPUIRenderSource.bufferStartIndex;
						_CS_CameraVisibility.SetInts(GPUIConstants.PROP_sizeAndIndexes2, _sizeAndIndexes2);
						_CS_CameraVisibility.DispatchXHeavy(0, num);
					}
				}
				SetOptionalRendererInstanceData(value, lODGroupData, instanceDataBuffer);
				instanceDataBuffer.OnDataModified();
			}
			SetCommandBufferInstanceCounts(_instanceCountMultiplier);
		}

		private void SetOptionalRendererInstanceData(GPUIRenderSourceGroup rsg, GPUILODGroupData lodGroupData, GPUIShaderBuffer instanceDataBuffer)
		{
			if (lodGroupData.optionalRendererCount <= 0)
			{
				return;
			}
			GraphicsBuffer optionalRendererStatusBuffer = rsg.TransformBufferData.GetOptionalRendererStatusBuffer();
			if (optionalRendererStatusBuffer != null)
			{
				int kernelIndex = 0;
				_sizeAndIndexes[2] = lodGroupData.optionalRendererCount;
				_CS_OptionalRenderer.SetInts(GPUIConstants.PROP_sizeAndIndexes, _sizeAndIndexes);
				if (rsg.Profile.isShadowCasting)
				{
					_CS_OptionalRenderer.EnableKeyword("GPUI_SHADOWCASTING");
				}
				else
				{
					_CS_OptionalRenderer.DisableKeyword("GPUI_SHADOWCASTING");
				}
				_CS_OptionalRenderer.SetBuffer(kernelIndex, GPUIConstants.PROP_visibilityBuffer, _visibilityBuffer);
				instanceDataBuffer.SetBuffer(_CS_OptionalRenderer, kernelIndex, GPUIConstants.PROP_gpuiInstanceDataBuffer);
				_CS_OptionalRenderer.SetBuffer(kernelIndex, GPUIConstants.PROP_optionalRendererStatusBuffer, optionalRendererStatusBuffer);
				_CS_OptionalRenderer.DispatchXY(kernelIndex, _sizeAndIndexes[0], lodGroupData.optionalRendererCount);
			}
		}

		internal void SetCommandBufferInstanceCounts(int instanceCountMultiplier)
		{
			if (_commandBuffer.Length != 0)
			{
				_CS_CommandBufferUtility.SetBuffer(1, GPUIConstants.PROP_visibilityBuffer, _visibilityBuffer);
				_CS_CommandBufferUtility.SetBuffer(1, GPUIConstants.PROP_commandBuffer, _commandBuffer);
				_CS_CommandBufferUtility.SetInt(GPUIConstants.PROP_bufferSize, _visibilityBuffer.Length);
				_CS_CommandBufferUtility.SetInt(GPUIConstants.PROP_multiplier, instanceCountMultiplier);
				_CS_CommandBufferUtility.DispatchX(1, _visibilityBuffer.Length);
			}
		}

		internal void ClearVisibilityData()
		{
			_visibilityBuffer.ReleaseBuffers();
			_visibilityBufferIndexes.Clear();
			_commandBuffer.ReleaseBuffers();
		}

		public GPUIVisibilityData[] GetVisibilityDataArray()
		{
			return _visibilityBuffer.GetBufferData();
		}

		public bool TryGetVisibilityBufferIndex(GPUIRenderSourceGroup renderSourceGroup, out int visibilityBufferIndex)
		{
			return TryGetVisibilityBufferIndex(renderSourceGroup.Key, out visibilityBufferIndex);
		}

		public bool TryGetVisibilityBufferIndex(int renderSourceGroupKey, out int visibilityBufferIndex)
		{
			visibilityBufferIndex = -1;
			if (_visibilityBuffer.Length == 0)
			{
				return false;
			}
			if (_visibilityBufferIndexes.TryGetValue(renderSourceGroupKey, out visibilityBufferIndex))
			{
				return true;
			}
			return false;
		}

		public bool TryGetShaderBuffer(GPUIManager manager, int prototypeIndex, out GPUIShaderBuffer shaderBuffer)
		{
			if (manager == null)
			{
				shaderBuffer = null;
				return false;
			}
			return TryGetShaderBuffer(manager.GetRenderKey(prototypeIndex), out shaderBuffer);
		}

		public bool TryGetShaderBuffer(int renderKey, out GPUIShaderBuffer shaderBuffer)
		{
			shaderBuffer = null;
			if (renderKey == 0)
			{
				return false;
			}
			if (!GPUIRenderingSystem.Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				return false;
			}
			GPUIRenderSourceGroup renderSourceGroup = result.renderSourceGroup;
			if (renderSourceGroup != null && renderSourceGroup.TransformBufferData != null)
			{
				shaderBuffer = renderSourceGroup.TransformBufferData.GetTransformBuffer(this);
				if (shaderBuffer != null && shaderBuffer.BufferSize > 0)
				{
					return true;
				}
			}
			return false;
		}

		public GPUIDataBuffer<GPUIVisibilityData> GetVisibilityBuffer()
		{
			_visibilityBuffer.UpdateBufferData();
			return _visibilityBuffer;
		}

		public Vector3 GetCameraPosition()
		{
			return _cameraPositionAndHalfAngle;
		}

		public GraphicsBuffer.IndirectDrawIndexedArgs GetCommandDataAtIndex(int index)
		{
			return _commandBuffer[index];
		}

		public int GetCommandDataLength()
		{
			return _commandBuffer.Length;
		}

		public void SetDynamicOcclusionOffsetIntensity(float intensity)
		{
			_dynamicOcclusionOffsetIntensity = intensity;
		}
	}
}
