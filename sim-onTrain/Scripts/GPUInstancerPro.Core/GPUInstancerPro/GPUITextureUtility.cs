using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public static class GPUITextureUtility
	{
		public static void CopyTextureWithComputeShader(Texture source, Texture destination, int offsetX, int sourceMip = 0, int destinationMip = 0)
		{
			int num = source.width;
			int num2 = source.height;
			for (int i = 0; i < sourceMip; i++)
			{
				num >>= 1;
				num2 >>= 1;
			}
			ComputeShader cS_TextureUtility = GPUIConstants.CS_TextureUtility;
			int kernelIndex = 0;
			cS_TextureUtility.SetTexture(kernelIndex, GPUIConstants.PROP_source, source, sourceMip);
			cS_TextureUtility.SetTexture(kernelIndex, GPUIConstants.PROP_destination, destination, destinationMip);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_offsetX, offsetX);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_sourceSizeX, num);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_sourceSizeY, num2);
			cS_TextureUtility.DispatchXY(kernelIndex, num, num2);
		}

		public static void CopyHiZTextureWithComputeShader(Texture source, Texture destination, int offsetX, int sourceMip = 0, int destinationMip = 0, bool reverseZ = true)
		{
			int num = source.width;
			int num2 = source.height;
			for (int i = 0; i < sourceMip; i++)
			{
				num >>= 1;
				num2 >>= 1;
			}
			ComputeShader cS_HiZTextureCopy = GPUIConstants.CS_HiZTextureCopy;
			int kernelIndex = 0;
			cS_HiZTextureCopy.SetTexture(kernelIndex, GPUIConstants.PROP_source, source, sourceMip);
			cS_HiZTextureCopy.SetTexture(kernelIndex, GPUIConstants.PROP_destination, destination, destinationMip);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_offsetX, offsetX);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_sourceSizeX, num);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_sourceSizeY, num2);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_reverseZ, (reverseZ && GPUIRuntimeSettings.Instance.ReversedZBuffer) ? 1 : 0);
			cS_HiZTextureCopy.DispatchXY(kernelIndex, num, num2);
		}

		public static void CopyHiZTextureWithComputeShader(CommandBuffer commandBuffer, RenderTargetIdentifier sourceIdentifier, RenderTextureSubElement sourceSubElement, int sourceW, int sourceH, RenderTargetIdentifier destinationIdentifier, RenderTextureSubElement destinationSubElement, int offsetX, int sourceMip = 0, int destinationMip = 0, bool reverseZ = true)
		{
			for (int i = 0; i < sourceMip; i++)
			{
				sourceW >>= 1;
				sourceH >>= 1;
			}
			ComputeShader cS_HiZTextureCopy = GPUIConstants.CS_HiZTextureCopy;
			int kernelIndex = 0;
			commandBuffer.SetComputeTextureParam(cS_HiZTextureCopy, kernelIndex, GPUIConstants.PROP_source, sourceIdentifier, sourceMip, sourceSubElement);
			commandBuffer.SetComputeTextureParam(cS_HiZTextureCopy, kernelIndex, GPUIConstants.PROP_destination, destinationIdentifier, destinationMip, destinationSubElement);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_offsetX, offsetX);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_sourceSizeX, sourceW);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_sourceSizeY, sourceH);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_reverseZ, (reverseZ && GPUIRuntimeSettings.Instance.ReversedZBuffer) ? 1 : 0);
			commandBuffer.DispatchCompute(cS_HiZTextureCopy, kernelIndex, Mathf.CeilToInt((float)sourceW / GPUIConstants.CS_THREAD_COUNT_2D), Mathf.CeilToInt((float)sourceH / GPUIConstants.CS_THREAD_COUNT_2D), 1);
		}

		public static void CopyHiZTextureArrayWithComputeShader(Texture source, Texture destination, int offsetX, int textureArrayIndex, int sourceMip = 0, int destinationMip = 0, bool reverseZ = true)
		{
			int num = source.width;
			int num2 = source.height;
			for (int i = 0; i < sourceMip; i++)
			{
				num >>= 1;
				num2 >>= 1;
			}
			ComputeShader cS_HiZTextureCopy = GPUIConstants.CS_HiZTextureCopy;
			int kernelIndex = 1;
			cS_HiZTextureCopy.SetTexture(kernelIndex, GPUIConstants.PROP_textureArray, source, sourceMip);
			cS_HiZTextureCopy.SetTexture(kernelIndex, GPUIConstants.PROP_destination, destination, destinationMip);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_offsetX, offsetX);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_textureArrayIndex, textureArrayIndex);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_sourceSizeX, num);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_sourceSizeY, num2);
			cS_HiZTextureCopy.SetInt(GPUIConstants.PROP_reverseZ, (reverseZ && GPUIRuntimeSettings.Instance.ReversedZBuffer) ? 1 : 0);
			cS_HiZTextureCopy.DispatchXY(kernelIndex, num, num2);
		}

		public static void CopyHiZTextureArrayWithComputeShader(CommandBuffer commandBuffer, RenderTargetIdentifier sourceIdentifier, RenderTextureSubElement sourceSubElement, int sourceW, int sourceH, RenderTargetIdentifier destinationIdentifier, RenderTextureSubElement destinationSubElement, int offsetX, int textureArrayIndex, int sourceMip = 0, int destinationMip = 0, bool reverseZ = true)
		{
			for (int i = 0; i < sourceMip; i++)
			{
				sourceW >>= 1;
				sourceH >>= 1;
			}
			ComputeShader cS_HiZTextureCopy = GPUIConstants.CS_HiZTextureCopy;
			int kernelIndex = 1;
			commandBuffer.SetComputeTextureParam(cS_HiZTextureCopy, kernelIndex, GPUIConstants.PROP_textureArray, sourceIdentifier, sourceMip, sourceSubElement);
			commandBuffer.SetComputeTextureParam(cS_HiZTextureCopy, kernelIndex, GPUIConstants.PROP_destination, destinationIdentifier, destinationMip, destinationSubElement);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_offsetX, offsetX);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_sourceSizeX, sourceW);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_sourceSizeY, sourceH);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_reverseZ, (reverseZ && GPUIRuntimeSettings.Instance.ReversedZBuffer) ? 1 : 0);
			commandBuffer.SetComputeIntParam(cS_HiZTextureCopy, GPUIConstants.PROP_textureArrayIndex, textureArrayIndex);
			commandBuffer.DispatchCompute(cS_HiZTextureCopy, kernelIndex, Mathf.CeilToInt((float)sourceW / GPUIConstants.CS_THREAD_COUNT_2D), Mathf.CeilToInt((float)sourceH / GPUIConstants.CS_THREAD_COUNT_2D), 1);
		}

		public static void ReduceTextureWithComputeShader(Texture source, Texture destination, int offsetX, int sourceMip = 0, int destinationMip = 0)
		{
			int num = source.width;
			int num2 = source.height;
			int num3 = destination.width;
			int num4 = destination.height;
			for (int i = 0; i < sourceMip; i++)
			{
				num >>= 1;
				num2 >>= 1;
			}
			for (int j = 0; j < destinationMip; j++)
			{
				num3 >>= 1;
				num4 >>= 1;
			}
			if (num3 != 0 && num4 != 0)
			{
				ComputeShader cS_TextureReduce = GPUIConstants.CS_TextureReduce;
				int kernelIndex = 0;
				cS_TextureReduce.SetTexture(kernelIndex, GPUIConstants.PROP_source, source, sourceMip);
				cS_TextureReduce.SetTexture(kernelIndex, GPUIConstants.PROP_destination, destination, destinationMip);
				cS_TextureReduce.SetInt(GPUIConstants.PROP_offsetX, offsetX);
				cS_TextureReduce.SetInt(GPUIConstants.PROP_sourceSizeX, num);
				cS_TextureReduce.SetInt(GPUIConstants.PROP_sourceSizeY, num2);
				cS_TextureReduce.SetInt(GPUIConstants.PROP_destinationSizeX, num3);
				cS_TextureReduce.SetInt(GPUIConstants.PROP_destinationSizeY, num4);
				cS_TextureReduce.DispatchXY(kernelIndex, num3, num4);
			}
		}

		public static void ReduceTextureWithComputeShader(CommandBuffer commandBuffer, RenderTargetIdentifier sourceIdentifier, RenderTextureSubElement sourceSubElement, int sourceW, int sourceH, RenderTargetIdentifier destinationIdentifier, RenderTextureSubElement destinationSubElement, int offsetX, int sourceMip = 0, int destinationMip = 0)
		{
			int num = sourceW;
			int num2 = sourceH;
			for (int i = 0; i < sourceMip; i++)
			{
				sourceW >>= 1;
				sourceH >>= 1;
			}
			for (int j = 0; j < destinationMip; j++)
			{
				num >>= 1;
				num2 >>= 1;
			}
			if (num != 0 && num2 != 0)
			{
				ComputeShader cS_TextureReduce = GPUIConstants.CS_TextureReduce;
				int kernelIndex = 0;
				commandBuffer.SetComputeTextureParam(cS_TextureReduce, kernelIndex, GPUIConstants.PROP_source, sourceIdentifier, sourceMip, sourceSubElement);
				commandBuffer.SetComputeTextureParam(cS_TextureReduce, kernelIndex, GPUIConstants.PROP_destination, destinationIdentifier, destinationMip, destinationSubElement);
				commandBuffer.SetComputeIntParam(cS_TextureReduce, GPUIConstants.PROP_offsetX, offsetX);
				commandBuffer.SetComputeIntParam(cS_TextureReduce, GPUIConstants.PROP_sourceSizeX, sourceW);
				commandBuffer.SetComputeIntParam(cS_TextureReduce, GPUIConstants.PROP_sourceSizeY, sourceH);
				commandBuffer.SetComputeIntParam(cS_TextureReduce, GPUIConstants.PROP_destinationSizeX, num);
				commandBuffer.SetComputeIntParam(cS_TextureReduce, GPUIConstants.PROP_destinationSizeY, num2);
				commandBuffer.DispatchCompute(cS_TextureReduce, kernelIndex, Mathf.CeilToInt((float)num / GPUIConstants.CS_THREAD_COUNT_2D), Mathf.CeilToInt((float)num2 / GPUIConstants.CS_THREAD_COUNT_2D), 1);
			}
		}

		public static Texture2D RenderTextureToTexture2D(RenderTexture renderTexture, TextureFormat textureFormat, bool linear)
		{
			Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, textureFormat, mipChain: false, linear);
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			RenderTexture.active = null;
			return texture2D;
		}

		public static void DestroyRenderTexture(this RenderTexture rt)
		{
			if (rt != null)
			{
				rt.Release();
				rt.DestroyGeneric();
			}
		}
	}
}
