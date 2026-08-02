using System;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIShaderBuffer : IGPUIDisposable, IDisposable
	{
		private bool _isBufferToTextureFloat4;

		public GraphicsBuffer Buffer { get; private set; }

		public RenderTexture Texture { get; private set; }

		public int BufferSize { get; private set; }

		public GPUIShaderBuffer(int bufferSize, int stride)
		{
			if (bufferSize > GPUIConstants.MAX_BUFFER_SIZE)
			{
				Debug.LogError(bufferSize.ToString("#,0") + " exceeds maximum allowed buffer size (" + GPUIConstants.MAX_BUFFER_SIZE.ToString("#,0") + ").");
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
		}

		public void ReleaseBuffers()
		{
			if (Buffer != null)
			{
				Buffer.Release();
			}
			Buffer = null;
			Texture.DestroyRenderTexture();
			Texture = null;
			BufferSize = 0;
		}

		public void Dispose()
		{
			ReleaseBuffers();
		}

		public void OnDataModified()
		{
			if (GPUIRuntimeSettings.Instance.DisableShaderBuffers && Buffer != null)
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
	}
}
