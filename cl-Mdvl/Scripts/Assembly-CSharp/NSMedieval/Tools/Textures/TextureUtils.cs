using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Tools.Textures
{
	public static class TextureUtils
	{
		public static Texture2D ConvertHeightmapToTexture(float[,] heightmap, float heightMultiplier = 1f)
		{
			int length = heightmap.GetLength(0);
			int length2 = heightmap.GetLength(1);
			Texture2D texture2D = new Texture2D(length, length2);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					float v = heightmap[i, j] * heightMultiplier;
					Color color = Color.HSVToRGB(0f, 0f, v);
					texture2D.SetPixel(i, j, color);
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		public static void SaveTextureAsPng(Texture2D texture, string filename)
		{
			byte[] bytes = texture.EncodeToPNG();
			File.WriteAllBytes(filename, bytes);
		}

		public static Texture2D LoadTexture2D(string fileName)
		{
			Texture2D texture2D = AssetUtils.GetTexture2D(fileName);
			if (texture2D != null)
			{
				return texture2D;
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\Texture Manipulation\\TextureUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Could not load heightmap @ address: ");
				messageBuilder.AppendFormatted(fileName);
			}
			Log.Warning(messageBuilder);
			return null;
		}

		public static byte[,] LoadTextureData(Texture2D texture, int heightSmoothingFactor)
		{
			int width = texture.width;
			int height = texture.height;
			byte[,] array = new byte[width, height];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					float num = 1f / (float)width * (float)j * (float)width;
					float num2 = 1f / (float)height * (float)i * (float)height;
					float grayscale = texture.GetPixel((int)num, (int)num2).grayscale;
					float num3 = grayscale * grayscale * grayscale;
					array[j, i] = (byte)(num3 * (float)heightSmoothingFactor);
				}
			}
			return array;
		}

		public static byte[,] FlipXAxis(byte[,] heightmap)
		{
			int length = heightmap.GetLength(0);
			byte[,] array = new byte[length, length];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length; j++)
				{
					array[i, j] = heightmap[length - i - 1, j];
				}
			}
			return array;
		}

		public static byte[,] FlipZAxis(byte[,] heightmap)
		{
			int length = heightmap.GetLength(0);
			byte[,] array = new byte[length, length];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length; j++)
				{
					array[i, j] = heightmap[i, length - j - 1];
				}
			}
			return array;
		}

		public static byte[,] RotateClockwise90(byte[,] heightmap)
		{
			int length = heightmap.GetLength(0);
			byte[,] array = new byte[length, length];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length; j++)
				{
					array[i, j] = heightmap[length - j - 1, i];
				}
			}
			return array;
		}

		public static byte[,] RotateAntiClockwise90(byte[,] heightmap)
		{
			int length = heightmap.GetLength(0);
			byte[,] array = new byte[length, length];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length; j++)
				{
					array[i, j] = heightmap[j, length - i - 1];
				}
			}
			return array;
		}

		public static void Create3DTexture(ref RenderTexture texture3D, Vec3Int resolution, RenderTextureFormat format, FilterMode filterMode = FilterMode.Bilinear)
		{
			if (texture3D == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\Texture Manipulation\\TextureUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Creating 3d texture, resolution: ");
					messageBuilder.AppendFormatted(resolution);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				texture3D = new RenderTexture(resolution.x, resolution.y, 0, format, RenderTextureReadWrite.Linear);
				texture3D.dimension = TextureDimension.Tex3D;
				texture3D.volumeDepth = resolution.z;
				texture3D.useMipMap = false;
				texture3D.filterMode = filterMode;
				texture3D.enableRandomWrite = true;
				texture3D.anisoLevel = 0;
				texture3D.Create();
			}
			else
			{
				Log.Info("Not creating texture, already exists.", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\Texture Manipulation\\TextureUtils.cs");
			}
		}

		public static void Fill3dTextureWhereNoGround(RenderTexture texture, ComputeBuffer combinedBuffer)
		{
			ComputeShader computeShader = UnityEngine.Resources.Load<ComputeShader>("Shaders/Compute/Fill3dTextureWhereNoGround");
			int kernelIndex = computeShader.FindKernel("CSMain");
			computeShader.GetKernelThreadGroupSizes(kernelIndex, out var x, out var y, out var z);
			int threadGroupsX = Mathf.CeilToInt((float)texture.width / (float)x);
			int threadGroupsY = Mathf.CeilToInt((float)texture.height / (float)y);
			int threadGroupsZ = Mathf.CeilToInt((float)texture.volumeDepth / (float)z);
			computeShader.SetBuffer(kernelIndex, "combinedBuffer", combinedBuffer);
			computeShader.SetTexture(kernelIndex, "outputTexture3D", texture);
			computeShader.SetInts("resolution", texture.width, texture.height, texture.volumeDepth);
			computeShader.Dispatch(kernelIndex, threadGroupsX, threadGroupsY, threadGroupsZ);
		}

		public static Sprite GetSpriteFromPath(string filePath, float pixelsPerUnit = 100f)
		{
			return GetSpriteFromTexture(GetTextureFormPath(filePath), pixelsPerUnit);
		}

		public static Sprite GetSpriteFromTexture(Texture2D texture, float pixelsPerUnit = 100f)
		{
			return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0f, 0f), pixelsPerUnit);
		}

		public static Texture2D GetTextureFormPath(string filePath, int size = 1024)
		{
			if (!File.Exists(filePath))
			{
				return null;
			}
			Texture2D texture2D = new Texture2D(size, size);
			byte[] data = File.ReadAllBytes(filePath);
			if (!texture2D.LoadImage(data))
			{
				return null;
			}
			return texture2D;
		}

		public static Texture2D CopyTexture(Texture2D original, int width = 0, int height = 0)
		{
			int num = ((width == 0) ? original.width : width);
			int num2 = ((height == 0) ? original.height : height);
			RenderTexture renderTexture = (RenderTexture.active = RenderTexture.GetTemporary(num, num2));
			Graphics.Blit(original, renderTexture);
			Texture2D texture2D = new Texture2D(num, num2);
			texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
			texture2D.Apply();
			RenderTexture.ReleaseTemporary(renderTexture);
			return texture2D;
		}
	}
}
