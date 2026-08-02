using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUITransformBufferData : IGPUIDisposable, IDisposable
	{
		private GPUIRenderSourceGroup _renderSourceGroup;

		private Dictionary<int, GPUIShaderBuffer> _transformBufferDict;

		private int _previousFrameBufferFrameNo;

		private Dictionary<int, GPUIShaderBuffer> _instanceDataBufferDict;

		public int resetCrossFadeDataFrame;

		public GraphicsBuffer PreviousFrameTransformBuffer { get; private set; }

		public bool HasPreviousFrameTransformBuffer { get; private set; }

		public bool IsCameraBasedBuffer => _renderSourceGroup.TransformBufferType == GPUITransformBufferType.CameraBased;

		public bool IsDefaultBuffer => _renderSourceGroup.TransformBufferType == GPUITransformBufferType.Default;

		public GPUITransformBufferData(GPUIRenderSourceGroup renderSourceGroup)
		{
			_renderSourceGroup = renderSourceGroup;
		}

		public void ReleaseBuffers()
		{
			ReleaseTransformBuffers();
			ReleaseInstanceDataBuffers();
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

		internal void SetTransformBufferData<T>(NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			GPUIShaderBuffer transformBuffer = GetTransformBuffer();
			transformBuffer.Buffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			if (isOverwritePreviousFrameBuffer && HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null && graphicsBufferStartIndex < PreviousFrameTransformBuffer.count)
			{
				PreviousFrameTransformBuffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, Math.Min(count, PreviousFrameTransformBuffer.count - graphicsBufferStartIndex));
			}
			transformBuffer.OnDataModified();
		}

		internal void SetTransformBufferData<T>(T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			GPUIShaderBuffer transformBuffer = GetTransformBuffer();
			transformBuffer.Buffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			if (isOverwritePreviousFrameBuffer && HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null && graphicsBufferStartIndex < PreviousFrameTransformBuffer.count)
			{
				PreviousFrameTransformBuffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, Math.Min(count, PreviousFrameTransformBuffer.count - graphicsBufferStartIndex));
			}
			transformBuffer.OnDataModified();
		}

		internal void SetTransformBufferData<T>(List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			GPUIShaderBuffer transformBuffer = GetTransformBuffer();
			transformBuffer.Buffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count);
			if (isOverwritePreviousFrameBuffer && HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null && graphicsBufferStartIndex < PreviousFrameTransformBuffer.count)
			{
				PreviousFrameTransformBuffer.SetData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, Math.Min(count, PreviousFrameTransformBuffer.count - graphicsBufferStartIndex));
			}
			transformBuffer.OnDataModified();
		}

		internal void RemoveIndexes(int startIndex, int count)
		{
			if (IsCameraBasedBuffer)
			{
				Debug.LogError("RemoveIndexes method can not be used with Camera Based transform buffers.");
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
			gPUIShaderBuffer.OnDataModified();
		}

		private GPUIShaderBuffer CreateTransformBuffer()
		{
			ReleaseInstanceDataBuffers();
			return new GPUIShaderBuffer(_renderSourceGroup.BufferSize, 64);
		}

		private GPUIShaderBuffer CreateInstanceDataBuffer(int instanceDataBufferSize)
		{
			resetCrossFadeDataFrame = Time.frameCount;
			return new GPUIShaderBuffer(instanceDataBufferSize, 16);
		}

		public GPUIShaderBuffer GetTransformBuffer()
		{
			if (IsCameraBasedBuffer)
			{
				Debug.LogError("GetTransformBuffer method can not be used with Camera Based transform buffers.");
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
			if (!IsCameraBasedBuffer)
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
			int num = _renderSourceGroup.BufferSize * (lODGroupData.Length * ((!_renderSourceGroup.Profile.isShadowCasting) ? 1 : 2) + ((_renderSourceGroup.Profile.isLODCrossFade && _renderSourceGroup.Profile.isAnimateCrossFade && !IsCameraBasedBuffer) ? 1 : 0));
			if (!_instanceDataBufferDict.TryGetValue(instanceID, out var value) || value == null || value.BufferSize != num)
			{
				value?.Dispose();
				value = CreateInstanceDataBuffer(num);
				_instanceDataBufferDict[instanceID] = value;
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
				bool flag = HasPreviousFrameTransformBuffer && PreviousFrameTransformBuffer != null;
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
			}
			mpb.SetFloat(GPUIConstants.PROP_transformBufferSize, _renderSourceGroup.BufferSize);
			mpb.SetFloat(GPUIConstants.PROP_instanceDataBufferSize, instanceDataBuffer.BufferSize);
			mpb.SetFloat(GPUIConstants.PROP_maxTextureSize, GPUIConstants.TEXTURE_MAX_SIZE);
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
	}
}
