using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUITransformBufferData : IGPUIDisposable, IDisposable
	{
		private GPUIRenderSourceGroup _renderSourceGroup;

		private Dictionary<int, GPUIShaderBuffer> _transformBufferDict;

		private bool _hasPreviousFrameTransformBuffer;

		private int _previousFrameBufferFrameNo;

		internal GraphicsBuffer _perInstanceLightProbesBuffer;

		private bool _hasPerInstanceLightProbes;

		private bool _isAllowPerInstanceLightProbes;

		private Dictionary<int, GPUIShaderBuffer> _instanceDataBufferDict;

		public int resetCrossFadeDataFrame;

		private GraphicsBuffer _optionalRendererStatusBuffer;

		private int _shaderCommandParamsStartIndex;

		private bool _transformDataModified;

		private bool _requiresInstancingBoundsUpdate;

		internal int _instancingBoundsIndex = -1;

		internal Bounds _instancingBounds;

		public GPUIRenderSourceGroup RenderSourceGroup => _renderSourceGroup;

		public Dictionary<int, GPUIShaderBuffer>.ValueCollection TransformBufferValues
		{
			get
			{
				if (_transformBufferDict != null)
				{
					return _transformBufferDict.Values;
				}
				return null;
			}
		}

		public GraphicsBuffer PreviousFrameTransformBuffer { get; private set; }

		public bool HasPreviousFrameTransformBuffer
		{
			get
			{
				return _hasPreviousFrameTransformBuffer;
			}
			private set
			{
				if (_hasPreviousFrameTransformBuffer == value)
				{
					return;
				}
				_hasPreviousFrameTransformBuffer = value;
				if (!GPUIShaderBindings.Instance.stripObjectMotionVectorVariants)
				{
					if (value)
					{
						if (_renderSourceGroup.AddShaderKeyword("GPUI_OBJECT_MOTION_VECTOR_ON"))
						{
							_renderSourceGroup.RemoveReplacementMaterials();
						}
					}
					else if (_renderSourceGroup.RemoveShaderKeyword("GPUI_OBJECT_MOTION_VECTOR_ON"))
					{
						_renderSourceGroup.RemoveReplacementMaterials();
					}
				}
				else if (value)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not generate Per Object Motion Vector data. Disabled by the Editor Settings.");
					_hasPreviousFrameTransformBuffer = false;
				}
			}
		}

		public bool HasPerInstanceLightProbes
		{
			get
			{
				return _hasPerInstanceLightProbes;
			}
			private set
			{
				if (_hasPerInstanceLightProbes == value)
				{
					return;
				}
				_hasPerInstanceLightProbes = value;
				if (!GPUIShaderBindings.Instance.stripPerInstanceLightProbeVariants)
				{
					if (value)
					{
						if (_renderSourceGroup.AddShaderKeyword("GPUI_PER_INSTANCE_LIGHTPROBES_ON"))
						{
							_renderSourceGroup.RemoveReplacementMaterials();
						}
					}
					else if (_renderSourceGroup.RemoveShaderKeyword("GPUI_PER_INSTANCE_LIGHTPROBES_ON"))
					{
						_renderSourceGroup.RemoveReplacementMaterials();
					}
				}
				else if (value)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not generate Per Instance Light Probe data. Disabled by the Editor Settings.");
					_hasPerInstanceLightProbes = false;
				}
			}
		}

		public bool IsCameraBasedBuffer => _renderSourceGroup.TransformBufferType == GPUITransformBufferType.CameraBased;

		public bool IsGeneratePerInstanceLightProbes
		{
			get
			{
				if (_isAllowPerInstanceLightProbes)
				{
					return _renderSourceGroup.Profile.lightProbeSetting == GPUILightProbeSetting.PerInstance;
				}
				return false;
			}
		}

		public bool HasInstancingBounds { get; internal set; }

		public GPUITransformBufferData(GPUIRenderSourceGroup renderSourceGroup)
		{
			_renderSourceGroup = renderSourceGroup;
			if (Application.isPlaying && !IsCameraBasedBuffer && !GPUIRuntimeSettings.Instance.DisablePreviousFrameTransformBuffer && !GPUIRuntimeSettings.Instance.IsBuiltInRP && renderSourceGroup.LODGroupData != null && renderSourceGroup.Profile != null && renderSourceGroup.Profile.enablePerObjectMotionVectors && !GPUIShaderBindings.Instance.stripObjectMotionVectorVariants && renderSourceGroup.LODGroupData.HasObjectMotion())
			{
				HasPreviousFrameTransformBuffer = true;
				_previousFrameBufferFrameNo = -1;
			}
			_isAllowPerInstanceLightProbes = Application.isPlaying && !IsCameraBasedBuffer && !GPUIRuntimeSettings.Instance.DisablePerInstanceLightProbesBuffer && !GPUIRuntimeSettings.IsAdaptiveProbeVolumesEnabled() && !GPUIShaderBindings.Instance.stripPerInstanceLightProbeVariants;
			HasInstancingBounds = false;
			_instancingBoundsIndex = -1;
		}

		public void ReleaseBuffers()
		{
			ReleaseTransformBuffers();
			ReleaseInstanceDataBuffers();
			ReleaseOptionalRendererBuffers();
			ReleaseLightProbeBuffers();
		}

		internal void ReleaseTransformBuffers()
		{
			if (_transformBufferDict != null)
			{
				foreach (GPUIShaderBuffer value in _transformBufferDict.Values)
				{
					value?.Dispose();
				}
				_transformBufferDict = null;
			}
			if (PreviousFrameTransformBuffer != null)
			{
				PreviousFrameTransformBuffer.Dispose();
			}
		}

		internal void ReleaseInstanceDataBuffers()
		{
			if (_instanceDataBufferDict == null)
			{
				return;
			}
			foreach (GPUIShaderBuffer value in _instanceDataBufferDict.Values)
			{
				value?.Dispose();
			}
			_instanceDataBufferDict = null;
		}

		internal void ReleaseOptionalRendererBuffers()
		{
			if (_optionalRendererStatusBuffer != null)
			{
				_optionalRendererStatusBuffer.Dispose();
				_optionalRendererStatusBuffer = null;
			}
		}

		internal void ReleaseLightProbeBuffers()
		{
			HasPerInstanceLightProbes = false;
			if (_perInstanceLightProbesBuffer != null)
			{
				_perInstanceLightProbesBuffer.Dispose();
				_perInstanceLightProbesBuffer = null;
			}
		}

		internal void ReleaseInstanceDataBuffers(GPUICameraData cameraData)
		{
			int instanceID = cameraData.ActiveCamera.GetInstanceID();
			if (_instanceDataBufferDict != null && _instanceDataBufferDict.TryGetValue(instanceID, out var value))
			{
				value?.Dispose();
				_instanceDataBufferDict.Remove(instanceID);
			}
		}

		public void Dispose()
		{
			ReleaseBuffers();
			_transformBufferDict = null;
			_instanceDataBufferDict = null;
			HasInstancingBounds = false;
			_instancingBoundsIndex = -1;
		}

		internal void Dispose(GPUICameraData cameraData)
		{
			if (IsCameraBasedBuffer && cameraData != null && cameraData.ActiveCamera != null)
			{
				int instanceID = cameraData.ActiveCamera.GetInstanceID();
				if (_transformBufferDict != null && _transformBufferDict.TryGetValue(instanceID, out var value))
				{
					value.Dispose();
					_transformBufferDict.Remove(instanceID);
				}
				if (_instanceDataBufferDict != null && _instanceDataBufferDict.TryGetValue(instanceID, out var value2))
				{
					value2.Dispose();
					_instanceDataBufferDict.Remove(instanceID);
				}
			}
		}

		internal void ResizeTransformBuffer(bool isCopyPreviousData)
		{
			if (IsCameraBasedBuffer)
			{
				Dispose();
				return;
			}
			if (_transformBufferDict == null)
			{
				_transformBufferDict = new Dictionary<int, GPUIShaderBuffer>();
			}
			_transformBufferDict.TryGetValue(0, out var value);
			bool num = value != null;
			int num2 = (num ? value.BufferSize : 0);
			if (num && num2 == _renderSourceGroup.BufferSize)
			{
				return;
			}
			GPUIShaderBuffer gPUIShaderBuffer = CreateTransformBuffer();
			_transformBufferDict[0] = gPUIShaderBuffer;
			if (value != null)
			{
				if (isCopyPreviousData)
				{
					gPUIShaderBuffer.Buffer.SetData(value.Buffer, 0, 0, Math.Min(_renderSourceGroup.BufferSize, num2));
				}
				value.Dispose();
			}
		}

		internal bool ResizeTransformBuffer(out GPUIShaderBuffer previousTransformBuffer, out GPUIShaderBuffer transformBuffer)
		{
			previousTransformBuffer = null;
			transformBuffer = null;
			if (IsCameraBasedBuffer)
			{
				Dispose();
				return false;
			}
			if (_transformBufferDict == null)
			{
				_transformBufferDict = new Dictionary<int, GPUIShaderBuffer>();
			}
			_transformBufferDict.TryGetValue(0, out previousTransformBuffer);
			bool num = previousTransformBuffer != null;
			int num2 = (num ? previousTransformBuffer.BufferSize : 0);
			if (!num || num2 != _renderSourceGroup.BufferSize)
			{
				transformBuffer = CreateTransformBuffer();
				_transformBufferDict[0] = transformBuffer;
				return true;
			}
			return false;
		}

		public unsafe void CalculateInterpolatedLightAndOcclusionProbes<T>(NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) where T : unmanaged
		{
			if (IsGeneratePerInstanceLightProbes)
			{
				HasPerInstanceLightProbes = true;
				Vector3 lightProbePositionOffset = _renderSourceGroup.Profile.lightProbePositionOffset;
				lightProbePositionOffset += _renderSourceGroup.LODGroupData.bounds.center;
				GPUIRenderingSystem.Instance.CalculateInterpolatedLightAndOcclusionProbes(this, matrices.GetUnsafeReadOnlyPtr(), managedBufferStartIndex, graphicsBufferStartIndex, count, _renderSourceGroup.BufferSize, lightProbePositionOffset);
			}
			else if (HasPerInstanceLightProbes)
			{
				ReleaseLightProbeBuffers();
			}
		}

		public unsafe void CalculateInterpolatedLightAndOcclusionProbes<T>(T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) where T : unmanaged
		{
			if (IsGeneratePerInstanceLightProbes)
			{
				HasPerInstanceLightProbes = true;
				Vector3 lightProbePositionOffset = _renderSourceGroup.Profile.lightProbePositionOffset;
				lightProbePositionOffset += _renderSourceGroup.LODGroupData.bounds.center;
				fixed (T* ptr = matrices)
				{
					void* p_matrices = ptr;
					GPUIRenderingSystem.Instance.CalculateInterpolatedLightAndOcclusionProbes(this, p_matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, _renderSourceGroup.BufferSize, lightProbePositionOffset);
				}
			}
			else if (HasPerInstanceLightProbes)
			{
				ReleaseLightProbeBuffers();
			}
		}

		public unsafe void CalculateInterpolatedLightAndOcclusionProbes<T>(List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) where T : unmanaged
		{
			if (IsGeneratePerInstanceLightProbes)
			{
				HasPerInstanceLightProbes = true;
				Vector3 lightProbePositionOffset = _renderSourceGroup.Profile.lightProbePositionOffset;
				lightProbePositionOffset += _renderSourceGroup.LODGroupData.bounds.center;
				fixed (T* listInternalArray = GPUIUtility.GetListInternalArray(matrices))
				{
					void* p_matrices = listInternalArray;
					GPUIRenderingSystem.Instance.CalculateInterpolatedLightAndOcclusionProbes(this, p_matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, _renderSourceGroup.BufferSize, lightProbePositionOffset);
				}
			}
			else if (HasPerInstanceLightProbes)
			{
				ReleaseLightProbeBuffers();
			}
		}

		internal void SetTransformBufferData<T>(NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : unmanaged
		{
			GetTransformBuffer().Buffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			if (isOverwritePreviousFrameBuffer && HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null && graphicsBufferStartIndex < PreviousFrameTransformBuffer.count)
			{
				PreviousFrameTransformBuffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, Math.Min(count, PreviousFrameTransformBuffer.count - graphicsBufferStartIndex));
			}
			CalculateInterpolatedLightAndOcclusionProbes(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			OnTransformDataModified();
		}

		internal void SetTransformBufferData<T>(T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : unmanaged
		{
			GetTransformBuffer().Buffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			if (isOverwritePreviousFrameBuffer && HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null && graphicsBufferStartIndex < PreviousFrameTransformBuffer.count)
			{
				PreviousFrameTransformBuffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, Math.Min(count, PreviousFrameTransformBuffer.count - graphicsBufferStartIndex));
			}
			CalculateInterpolatedLightAndOcclusionProbes(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			OnTransformDataModified();
		}

		internal void SetTransformBufferData<T>(List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : unmanaged
		{
			GetTransformBuffer().Buffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			if (isOverwritePreviousFrameBuffer && HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null && graphicsBufferStartIndex < PreviousFrameTransformBuffer.count)
			{
				PreviousFrameTransformBuffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, Math.Min(count, PreviousFrameTransformBuffer.count - graphicsBufferStartIndex));
			}
			CalculateInterpolatedLightAndOcclusionProbes(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			OnTransformDataModified();
		}

		internal void RemoveIndexes(int startIndex, int count)
		{
			if (IsCameraBasedBuffer)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "RemoveIndexes method can not be used with Camera Based transform buffers.");
				return;
			}
			GPUIShaderBuffer gPUIShaderBuffer = CreateTransformBuffer();
			if (_transformBufferDict.TryGetValue(0, out var value))
			{
				gPUIShaderBuffer.Buffer.SetData(value.Buffer, 0, 0, startIndex);
				gPUIShaderBuffer.Buffer.SetData(value.Buffer, startIndex + count, startIndex, _renderSourceGroup.BufferSize - startIndex);
				value.Dispose();
			}
			_transformBufferDict[0] = gPUIShaderBuffer;
			OnTransformDataModified();
		}

		private GPUIShaderBuffer CreateTransformBuffer()
		{
			ReleaseInstanceDataBuffers();
			return new GPUIShaderBuffer(_renderSourceGroup.BufferSize, 64);
		}

		private GPUIShaderBuffer CreateInstanceDataBuffer(int instanceDataBufferSize)
		{
			resetCrossFadeDataFrame = Time.frameCount;
			GPUIShaderBuffer gPUIShaderBuffer = new GPUIShaderBuffer(instanceDataBufferSize, 16);
			gPUIShaderBuffer.Buffer.SetData(_renderSourceGroup._shaderCommandParamsArray, 0, _shaderCommandParamsStartIndex, _renderSourceGroup._shaderCommandParamsArray.Length);
			return gPUIShaderBuffer;
		}

		public GPUIShaderBuffer GetTransformBuffer()
		{
			if (IsCameraBasedBuffer)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "GetTransformBuffer method can not be used with Camera Based transform buffers.");
				return null;
			}
			GPUIShaderBuffer value;
			if (_transformBufferDict == null)
			{
				_transformBufferDict = new Dictionary<int, GPUIShaderBuffer>();
			}
			else if (_transformBufferDict.TryGetValue(0, out value) && value != null)
			{
				return value;
			}
			GPUIShaderBuffer gPUIShaderBuffer = CreateTransformBuffer();
			_transformBufferDict[0] = gPUIShaderBuffer;
			return gPUIShaderBuffer;
		}

		public GPUIShaderBuffer GetTransformBuffer(GPUICameraData cameraData)
		{
			if (!IsCameraBasedBuffer || cameraData == null)
			{
				return GetTransformBuffer();
			}
			int instanceID = cameraData.ActiveCamera.GetInstanceID();
			if (_transformBufferDict == null)
			{
				_transformBufferDict = new Dictionary<int, GPUIShaderBuffer>();
			}
			if (!_transformBufferDict.TryGetValue(instanceID, out var value) || value == null)
			{
				value = CreateTransformBuffer();
				_transformBufferDict[instanceID] = value;
			}
			return value;
		}

		public GPUIShaderBuffer GetInstanceDataBuffer(GPUICameraData cameraData)
		{
			int instanceID = cameraData.ActiveCamera.GetInstanceID();
			if (_instanceDataBufferDict == null)
			{
				_instanceDataBufferDict = new Dictionary<int, GPUIShaderBuffer>();
			}
			GPUILODGroupData lODGroupData = _renderSourceGroup.LODGroupData;
			GPUIProfile profile = _renderSourceGroup.Profile;
			int num = (_shaderCommandParamsStartIndex = _renderSourceGroup.BufferSize * ((lODGroupData.Length + lODGroupData.optionalRendererCount) * ((!profile.isShadowCasting) ? 1 : 2) + ((profile.isLODCrossFade && profile.isAnimateCrossFade && !IsCameraBasedBuffer) ? 1 : 0))) + _renderSourceGroup._shaderCommandParamsArray.Length;
			if (!_instanceDataBufferDict.TryGetValue(instanceID, out var value) || value == null || value.BufferSize != num)
			{
				value?.Dispose();
				value = CreateInstanceDataBuffer(num);
				_instanceDataBufferDict[instanceID] = value;
				_renderSourceGroup._requireShaderCommandParamsUpdate = false;
			}
			if (_renderSourceGroup._requireShaderCommandParamsUpdate)
			{
				_renderSourceGroup._requireShaderCommandParamsUpdate = false;
				value.Buffer.SetData(_renderSourceGroup._shaderCommandParamsArray, 0, _shaderCommandParamsStartIndex, _renderSourceGroup._shaderCommandParamsArray.Length);
			}
			return value;
		}

		public void SetMPBBuffers(MaterialPropertyBlock mpb, GPUICameraData cameraData)
		{
			GPUIShaderBuffer transformBuffer = GetTransformBuffer(cameraData);
			GPUIShaderBuffer instanceDataBuffer = GetInstanceDataBuffer(cameraData);
			if (GPUIRuntimeSettings.Instance.DisableShaderBuffers)
			{
				mpb.SetTexture(GPUIConstants.PROP_gpuiTransformBufferTexture, transformBuffer.Texture);
				mpb.SetTexture(GPUIConstants.PROP_gpuiInstanceDataBufferTexture, instanceDataBuffer.Texture);
			}
			else
			{
				mpb.SetBuffer(GPUIConstants.PROP_gpuiTransformBuffer, transformBuffer.Buffer);
				mpb.SetBuffer(GPUIConstants.PROP_gpuiInstanceDataBuffer, instanceDataBuffer.Buffer);
				if (HasPreviousFrameTransformBuffer)
				{
					bool flag = PreviousFrameTransformBuffer != null;
					mpb.SetInt(GPUIConstants.PROP_hasPreviousFrameTransformBuffer, flag ? 1 : 0);
					if (flag)
					{
						int count = transformBuffer.Buffer.count;
						if (PreviousFrameTransformBuffer.count < count)
						{
							int count2 = PreviousFrameTransformBuffer.count;
							GraphicsBuffer graphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, count, 64);
							graphicsBuffer.SetData(PreviousFrameTransformBuffer, 0, 0, count2);
							graphicsBuffer.SetData(transformBuffer.Buffer, count2, count2, count - count2);
							PreviousFrameTransformBuffer.Release();
							PreviousFrameTransformBuffer = graphicsBuffer;
						}
						mpb.SetBuffer(GPUIConstants.PROP_gpuiPreviousFrameTransformBuffer, PreviousFrameTransformBuffer);
					}
					else
					{
						mpb.SetBuffer(GPUIConstants.PROP_gpuiPreviousFrameTransformBuffer, GPUIRenderingSystem.Instance.DummyGraphicsBuffer);
					}
				}
				if (HasPerInstanceLightProbes)
				{
					if (_renderSourceGroup.Profile.lightProbeSetting != GPUILightProbeSetting.PerInstance)
					{
						ReleaseLightProbeBuffers();
					}
					else
					{
						bool flag2 = _perInstanceLightProbesBuffer != null;
						mpb.SetInt(GPUIConstants.PROP_hasPerInstanceLightProbes, flag2 ? 1 : 0);
						if (flag2)
						{
							mpb.SetBuffer(GPUIConstants.PROP_gpuiPerInstanceLightProbesBuffer, _perInstanceLightProbesBuffer);
						}
						else
						{
							mpb.SetBuffer(GPUIConstants.PROP_gpuiPerInstanceLightProbesBuffer, GPUIRenderingSystem.Instance.DummyGraphicsBuffer);
						}
					}
				}
			}
			mpb.SetFloat(GPUIConstants.PROP_transformBufferSize, _renderSourceGroup.BufferSize);
			mpb.SetFloat(GPUIConstants.PROP_instanceDataBufferSize, instanceDataBuffer.BufferSize);
			mpb.SetFloat(GPUIConstants.PROP_maxTextureSize, GPUIConstants.TEXTURE_MAX_SIZE);
			mpb.SetInt(GPUIConstants.PROP_commandParamsStartIndex, _shaderCommandParamsStartIndex);
		}

		internal void UpdateData(int frameNo)
		{
			if (HasPreviousFrameTransformBuffer && _renderSourceGroup.BufferSize > 0 && frameNo > _previousFrameBufferFrameNo && _transformBufferDict.TryGetValue(0, out var value) && value.Buffer != null)
			{
				_previousFrameBufferFrameNo = frameNo;
				int count = value.Buffer.count;
				if (PreviousFrameTransformBuffer == null)
				{
					PreviousFrameTransformBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, count, 64);
				}
				else if (PreviousFrameTransformBuffer.count != count)
				{
					PreviousFrameTransformBuffer.Release();
					PreviousFrameTransformBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, count, 64);
				}
				PreviousFrameTransformBuffer.SetData(value.Buffer, 0, 0, count);
			}
		}

		public void OnTransformDataModified()
		{
			_transformDataModified = true;
		}

		public void RequireInstancingBoundsUpdate()
		{
			_requiresInstancingBoundsUpdate = true;
		}

		public void ApplyTransformDataUpdates()
		{
			if (_transformDataModified)
			{
				_transformDataModified = false;
				if (_transformBufferDict == null)
				{
					return;
				}
				foreach (GPUIShaderBuffer value in _transformBufferDict.Values)
				{
					value?.OnDataModified();
				}
				GPUIRenderingSystem.OnBufferDataModified?.Invoke(this);
				CalculateInstancingBounds();
			}
			else if (_requiresInstancingBoundsUpdate)
			{
				CalculateInstancingBounds();
			}
		}

		public void ResetPreviousFrameBuffer()
		{
			UpdateData(_previousFrameBufferFrameNo + 1);
			_previousFrameBufferFrameNo = -1;
		}

		public void SetOptionalRendererStatusBufferData(NativeArray<uint> optionalRendererStatusData, int bufferStartIndex)
		{
			int bufferSize = _renderSourceGroup.BufferSize;
			if (_optionalRendererStatusBuffer != null && _optionalRendererStatusBuffer.count != bufferSize)
			{
				_optionalRendererStatusBuffer.Dispose();
				_optionalRendererStatusBuffer = null;
			}
			if (_optionalRendererStatusBuffer == null)
			{
				_optionalRendererStatusBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, bufferSize, 4);
				_optionalRendererStatusBuffer.ClearBufferData();
			}
			_optionalRendererStatusBuffer.SetData(optionalRendererStatusData, 0, bufferStartIndex, Mathf.Min(optionalRendererStatusData.Length, bufferSize - bufferStartIndex));
		}

		public GraphicsBuffer GetOptionalRendererStatusBuffer()
		{
			if (_optionalRendererStatusBuffer == null)
			{
				return null;
			}
			int bufferSize = _renderSourceGroup.BufferSize;
			if (_optionalRendererStatusBuffer.count != bufferSize)
			{
				GraphicsBuffer optionalRendererStatusBuffer = _optionalRendererStatusBuffer;
				_optionalRendererStatusBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, bufferSize, 4);
				_optionalRendererStatusBuffer.ClearBufferData();
				_optionalRendererStatusBuffer.SetData(optionalRendererStatusBuffer, 0, 0, Mathf.Min(optionalRendererStatusBuffer.count, bufferSize));
				optionalRendererStatusBuffer.Dispose();
			}
			return _optionalRendererStatusBuffer;
		}

		private bool CalculateInstancingBounds()
		{
			HasInstancingBounds = false;
			if (IsCameraBasedBuffer || _renderSourceGroup.Profile == null || !_renderSourceGroup.Profile.isCalculateInstancingBounds)
			{
				return false;
			}
			GPUIShaderBuffer transformBuffer = GetTransformBuffer();
			int bufferSize = _renderSourceGroup.BufferSize;
			if (transformBuffer == null || transformBuffer.Buffer == null || bufferSize <= 0)
			{
				return false;
			}
			GPUILODGroupData lODGroupData = _renderSourceGroup.LODGroupData;
			if (lODGroupData == null)
			{
				return false;
			}
			if (GPUIRenderingSystem.Instance._instancingBoundsMinMaxBuffer.IsDataRequested() || GPUIRenderingSystem.Instance._requireInstancingBoundsDataRead)
			{
				_requiresInstancingBoundsUpdate = true;
				return false;
			}
			_requiresInstancingBoundsUpdate = false;
			if (_instancingBoundsIndex < 0 || GPUIRenderingSystem.Instance._instancingBoundsMinMaxBuffer.Length < _instancingBoundsIndex + 6)
			{
				_instancingBoundsIndex = GPUIRenderingSystem.Instance._instancingBoundsMinMaxBuffer.Length;
				GPUIRenderingSystem.Instance._instancingBoundsMinMaxBuffer.Resize(_instancingBoundsIndex + 6);
				GPUIRenderingSystem.Instance._instancingBoundsMinMaxBuffer.UpdateBufferData();
			}
			ComputeShader cS_CalculateInstancingBounds = GPUIConstants.CS_CalculateInstancingBounds;
			int kernelIndex = 0;
			cS_CalculateInstancingBounds.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, transformBuffer.Buffer);
			cS_CalculateInstancingBounds.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiBoundsMinMax, GPUIRenderingSystem.Instance._instancingBoundsMinMaxBuffer);
			cS_CalculateInstancingBounds.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
			cS_CalculateInstancingBounds.SetInt(GPUIConstants.PROP_startIndex, _instancingBoundsIndex);
			cS_CalculateInstancingBounds.SetVector(GPUIConstants.PROP_boundsCenter, lODGroupData.bounds.center);
			cS_CalculateInstancingBounds.SetVector(GPUIConstants.PROP_boundsExtents, lODGroupData.bounds.extents);
			cS_CalculateInstancingBounds.DispatchX(kernelIndex, bufferSize);
			GPUIRenderingSystem.Instance._requireInstancingBoundsDataRead = true;
			return true;
		}
	}
}
