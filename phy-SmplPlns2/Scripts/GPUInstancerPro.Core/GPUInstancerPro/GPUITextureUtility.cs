using UnityEngine;

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

		public static void CopyTextureSamplerWithComputeShader(Texture source, Texture destination)
		{
			int width = destination.width;
			int height = destination.height;
			ComputeShader cS_TextureUtility = GPUIConstants.CS_TextureUtility;
			int kernelIndex = 1;
			cS_TextureUtility.SetTexture(kernelIndex, GPUIConstants.PROP_source, source);
			cS_TextureUtility.SetTexture(kernelIndex, GPUIConstants.PROP_destination, destination);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_destinationSizeX, width);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_destinationSizeY, height);
			cS_TextureUtility.DispatchXY(kernelIndex, width, height);
		}

		public static void SetTextureDataWithComputeShaderSingleChannel(GraphicsBuffer textureData, Texture destination)
		{
			int width = destination.width;
			int height = destination.height;
			ComputeShader cS_TextureUtility = GPUIConstants.CS_TextureUtility;
			int kernelIndex = 2;
			cS_TextureUtility.SetBuffer(kernelIndex, GPUIConstants.PROP_textureDataSingleChannel, textureData);
			cS_TextureUtility.SetTexture(kernelIndex, GPUIConstants.PROP_destination, destination);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_destinationSizeX, width);
			cS_TextureUtility.SetInt(GPUIConstants.PROP_destinationSizeY, height);
			cS_TextureUtility.DispatchXY(kernelIndex, width, height);
		}

		public static Texture2D RenderTextureToTexture2D(RenderTexture renderTexture, TextureFormat textureFormat, bool linear, FilterMode filterMode = FilterMode.Bilinear)
		{
			Texture2D obj = new Texture2D(renderTexture.width, renderTexture.height, textureFormat, mipChain: false, linear)
			{
				name = renderTexture.name,
				filterMode = filterMode
			};
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			obj.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			obj.Apply(updateMipmaps: false);
			RenderTexture.active = active;
			return obj;
		}

		public static void DestroyRenderTexture(this RenderTexture rt)
		{
			if (!(rt == null))
			{
				if (RenderTexture.active == rt)
				{
					RenderTexture.active = null;
				}
				rt.Release();
				rt.DestroyGeneric();
			}
		}

		public static void ClearRenderTexture(this RenderTexture rt)
		{
			rt.ClearRenderTexture(Color.clear);
		}

		public static void ClearRenderTexture(this RenderTexture rt, Color color)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = rt;
			GL.Clear(clearDepth: true, clearColor: true, color);
			RenderTexture.active = active;
		}
	}
}
