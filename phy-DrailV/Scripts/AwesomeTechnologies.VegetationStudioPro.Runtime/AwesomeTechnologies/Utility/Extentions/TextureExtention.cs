using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.Utility.Extentions
{
	public static class TextureExtention
	{
		public static void FixBillboardArtifact(Texture2D texture, BillboardQuality billboardQuality)
		{
			int billboardQualityRowCount = BillboardAtlasRenderer.GetBillboardQualityRowCount(billboardQuality);
			int billboardQualityTileWidth = BillboardAtlasRenderer.GetBillboardQualityTileWidth(billboardQuality);
			int num = billboardQualityTileWidth / 64;
			int width = texture.width;
			for (int i = 0; i <= billboardQualityRowCount - 1; i++)
			{
				for (int j = 0; j <= num - 1; j++)
				{
					for (int k = 0; k <= width - 1; k++)
					{
						Color pixel = texture.GetPixel(k, i * billboardQualityTileWidth + j);
						pixel.a = 0f;
						texture.SetPixel(k, i * billboardQualityTileWidth + j, pixel);
					}
				}
			}
			texture.Apply();
		}

		public static void ReplaceAlpha(Texture2D targetTexture, Texture2D alphaTexture)
		{
			NativeArray<Color32> rawTextureData = targetTexture.GetRawTextureData<Color32>();
			NativeArray<Color32> rawTextureData2 = alphaTexture.GetRawTextureData<Color32>();
			for (int i = 0; i < rawTextureData.Length; i++)
			{
				Color32 value = rawTextureData[i];
				if (rawTextureData2[i].r > 128)
				{
					value.a = byte.MaxValue;
				}
				else
				{
					value.a = 0;
				}
				rawTextureData[i] = value;
			}
			targetTexture.Apply();
		}

		public static Texture2D CreatePaddedTexture(Texture2D sourceTexture, int paddingPassCount = 1024)
		{
			if (!SystemInfo.supportsComputeShaders)
			{
				return null;
			}
			ComputeShader computeShader = (ComputeShader)Resources.Load("AlphaPadding");
			bool flag = false;
			computeShader.SetBool("Linear", flag);
			int kernelIndex = computeShader.FindKernel("ApplyAlphaPadding");
			int kernelIndex2 = computeShader.FindKernel("ReadSourceTexture");
			int width = sourceTexture.width;
			int height = sourceTexture.height;
			RenderTexture renderTexture;
			RenderTexture renderTexture2;
			if (flag)
			{
				renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				renderTexture2 = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			}
			else
			{
				renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
				renderTexture2 = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
			}
			renderTexture.enableRandomWrite = true;
			renderTexture.Create();
			renderTexture2.enableRandomWrite = true;
			renderTexture2.Create();
			computeShader.SetTexture(kernelIndex2, "SourceTexture", sourceTexture);
			computeShader.SetTexture(kernelIndex2, "OutputTexture", renderTexture);
			computeShader.Dispatch(kernelIndex2, width / 8, height / 8, 1);
			RenderTexture renderTexture3 = renderTexture;
			RenderTexture renderTexture4 = renderTexture2;
			for (int i = 0; i <= paddingPassCount - 1; i++)
			{
				computeShader.SetTexture(kernelIndex, "InputTexture", renderTexture3);
				computeShader.SetTexture(kernelIndex, "OutputTexture", renderTexture4);
				computeShader.Dispatch(kernelIndex, width / 8, height / 8, 1);
				RenderTexture renderTexture5 = renderTexture3;
				renderTexture3 = renderTexture4;
				renderTexture4 = renderTexture5;
			}
			RenderTexture.active = renderTexture3;
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, mipChain: true, flag);
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = null;
			Color32[] pixels = texture2D.GetPixels32();
			Color32[] pixels2 = sourceTexture.GetPixels32();
			for (int j = 0; j < pixels.Length; j++)
			{
				pixels[j].a = pixels2[j].a;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			Object.DestroyImmediate(renderTexture);
			Object.DestroyImmediate(renderTexture2);
			return texture2D;
		}

		public static void SaveToFile(this Texture2D texture, string fileName)
		{
		}
	}
}
