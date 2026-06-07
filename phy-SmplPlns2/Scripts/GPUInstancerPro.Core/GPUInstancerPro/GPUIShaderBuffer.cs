using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public class GPUIShaderBuffer : IGPUIDisposable, IDisposable
	{
		private bool _isBufferToTextureFloat4;

		private bool _isDataRequested;

		private bool _isRequestedDataInvalid;

		private AsyncGPUReadbackRequest _readbackRequest;

		private readonly Action<AsyncGPUReadbackRequest> _requestCallbackInternal;

		private Action<NativeArray<Matrix4x4>> _requestCallbackExternal;

		private NativeArray<Matrix4x4> _requestedData;

		public GraphicsBuffer Buffer { get; private set; }

		public RenderTexture Texture { get; private set; }

		public int BufferSize { get; private set; }

		public GPUIShaderBuffer(int bufferSize, int stride)
		{
			if (bufferSize > GPUIConstants.MAX_BUFFER_SIZE)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + bufferSize.ToString("#,0") + " exceeds maximum allowed buffer size (" + GPUIConstants.MAX_BUFFER_SIZE.ToString("#,0") + ").");
				return;
			}
			if (bufferSize > 0)
			{
				Buffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, bufferSize, stride);
			}
			BufferSize = bufferSize;
			if (GPUIRuntimeSettings.Instance.DisableShaderBuffers)
			{
				int num = Mathf.CeilToInt((float)bufferSize / (float)GPUIConstants.TEXTURE_MAX_SIZE);
				Texture = new RenderTexture((num == 1) ? bufferSize : GPUIConstants.TEXTURE_MAX_SIZE, num * Mathf.CeilToInt((float)stride / 16f), 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear)
				{
					isPowerOfTwo = false,
					enableRandomWrite = true,
					filterMode = FilterMode.Point,
					useMipMap = false,
					autoGenerateMips = false,
					useDynamicScale = false,
					wrapMode = TextureWrapMode.Clamp
				};
				Texture.Create();
				_isBufferToTextureFloat4 = stride <= 16;
			}
			_requestCallbackInternal = AsyncDataRequestCallback;
		}

		public void ReleaseBuffers()
		{
			BufferSize = 0;
			if (_isDataRequested)
			{
				_isRequestedDataInvalid = true;
				_readbackRequest.WaitForCompletion();
			}
			if (Buffer != null)
			{
				Buffer.Dispose();
			}
			Buffer = null;
			Texture.DestroyRenderTexture();
			Texture = null;
		}

		public void Dispose()
		{
			ReleaseBuffers();
		}

		public void OnDataModified()
		{
			if (Buffer == null)
			{
				return;
			}
			if (GPUIRuntimeSettings.Instance.DisableShaderBuffers)
			{
				ComputeShader cS_BufferToTexture = GPUIConstants.CS_BufferToTexture;
				if (_isBufferToTextureFloat4)
				{
					cS_BufferToTexture.EnableKeyword("GPUI_FLOAT4_BUFFER");
				}
				else
				{
					cS_BufferToTexture.DisableKeyword("GPUI_FLOAT4_BUFFER");
				}
				cS_BufferToTexture.SetBuffer(0, GPUIConstants.PROP_sourceBuffer, Buffer);
				cS_BufferToTexture.SetTexture(0, GPUIConstants.PROP_targetTexture, Texture);
				cS_BufferToTexture.SetInt(GPUIConstants.PROP_count, BufferSize);
				cS_BufferToTexture.SetInt(GPUIConstants.PROP_maxTextureSize, GPUIConstants.TEXTURE_MAX_SIZE);
				cS_BufferToTexture.DispatchX(0, Buffer.count);
				Texture.IncrementUpdateCount();
			}
			if (_isDataRequested)
			{
				_isRequestedDataInvalid = true;
			}
		}

		public void SetBuffer(ComputeShader cs, int kernelIndex, int nameID)
		{
			if (Buffer != null)
			{
				cs.SetBuffer(kernelIndex, nameID, Buffer);
			}
			else if (Texture != null)
			{
				cs.SetTexture(kernelIndex, nameID, Texture);
			}
		}

		public void CompleteAsyncRequests()
		{
			if (_isDataRequested)
			{
				_readbackRequest.WaitForCompletion();
			}
		}

		public void AsyncRequestIntoNativeArray(Action<NativeArray<Matrix4x4>> onSuccessfulReadback)
		{
			if (Buffer == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Buffer is not created.");
				return;
			}
			if (_isDataRequested)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "There is already an active async readback request!");
				return;
			}
			_requestedData = new NativeArray<Matrix4x4>(BufferSize, Allocator.Persistent);
			_isDataRequested = true;
			_requestCallbackExternal = onSuccessfulReadback;
			_readbackRequest = AsyncGPUReadback.RequestIntoNativeArray(ref _requestedData, Buffer, _requestCallbackInternal);
		}

		private void AsyncDataRequestCallback(AsyncGPUReadbackRequest readbackRequest)
		{
			_isDataRequested = false;
			if (_isRequestedDataInvalid)
			{
				_isRequestedDataInvalid = false;
				if (_requestedData.IsCreated)
				{
					if (BufferSize == 0 || _requestedData.Length != BufferSize || Buffer == null)
					{
						_requestedData.Dispose();
					}
					else
					{
						AsyncRequestIntoNativeArray(_requestCallbackExternal);
					}
				}
			}
			else if (readbackRequest.hasError)
			{
				if (_requestedData.IsCreated)
				{
					_requestedData.Dispose();
				}
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Async data request has encountered an error.");
			}
			else
			{
				_requestCallbackExternal(_requestedData);
			}
		}
	}
}
