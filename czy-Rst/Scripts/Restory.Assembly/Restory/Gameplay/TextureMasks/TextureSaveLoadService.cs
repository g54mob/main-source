using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Mandragora.PWS;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace Restory.Gameplay.TextureMasks
{
	public class TextureSaveLoadService : MonoBehaviour
	{
		public enum TextureSaveFileFormat
		{
			PNG = 0,
			JPG = 1,
			EXR = 2,
			TGA = 3
		}

		private struct RawTextureData
		{
			public byte[] Bytes;

			public int Width;

			public int Height;

			public GraphicsFormat Format;
		}

		[SerializeField]
		private TextureSaveFileFormat saveFileFormat;

		[SerializeField]
		private int jpegImageQuality = 75;

		[SerializeField]
		private bool saveIn16BitTextureFormat;

		[SerializeField]
		private string savedTextureFilesFolderPath = "Assets/TEMP/";

		private void SaveDirtMaskTextureToFile(TextureMaskHolder textureMaskHolder)
		{
			SaveTexture(textureMaskHolder.WorkTexture);
		}

		private void SavePaintTextureToFile(PaintingTextureHolder textureHolder)
		{
			SaveTexture(textureHolder.PaintingTexture);
		}

		private void LoadDirtMaskTextureFromFile(string filePath, TextureMaskHolder textureMaskHolder)
		{
			Texture2D restoredTexture = LoadTextureFromFile(filePath, TextureFormat.RGBA32, isTargetTextureLinear: false);
			textureMaskHolder.RestoreWorkTexture(restoredTexture);
		}

		private void LoadPaintTextureFromFile(string filePath, PaintingTextureHolder textureHolder)
		{
			Texture2D newWorkTexture = LoadTextureFromFile(filePath, TextureFormat.RGBAHalf, isTargetTextureLinear: true);
			textureHolder.SetNewWorkTexture(newWorkTexture);
		}

		public byte[] ConvertTextureToData(Texture2D texture)
		{
			Texture2D textureToSave = GetTextureToSave(texture);
			return GetDataFromTexture(textureToSave);
		}

		public Texture2D ConvertDataToTexture(byte[] textureData, TextureFormat textureFormat, bool isTargetTextureLinear)
		{
			return GetTextureFromData(textureData, textureFormat, isTargetTextureLinear);
		}

		public async Task<byte[]> ConvertTextureToDataAsync(Texture2D texture, CancellationToken cancellationToken)
		{
			TextureSaveFileFormat textureSaveFileFormat = saveFileFormat;
			Texture2D texture2 = (((textureSaveFileFormat == TextureSaveFileFormat.JPG || textureSaveFileFormat == TextureSaveFileFormat.TGA) && !texture.isDataSRGB) ? GetGammaSpaceTextureFromLinearSpaceTexture(texture) : texture);
			RawTextureData data = await CaptureRawDataAsync(texture2);
			return await Task.Run(delegate
			{
				cancellationToken.ThrowIfCancellationRequested();
				uint blockSize = GraphicsFormatUtility.GetBlockSize(data.Format);
				uint rowBytes = (uint)data.Width * blockSize;
				return saveFileFormat switch
				{
					TextureSaveFileFormat.PNG => ImageConversion.EncodeArrayToPNG(data.Bytes, data.Format, (uint)data.Width, (uint)data.Height, rowBytes), 
					TextureSaveFileFormat.JPG => ImageConversion.EncodeArrayToJPG(data.Bytes, data.Format, (uint)data.Width, (uint)data.Height, rowBytes, jpegImageQuality), 
					TextureSaveFileFormat.EXR => ImageConversion.EncodeArrayToEXR(data.Bytes, data.Format, (uint)data.Width, (uint)data.Height, rowBytes, Texture2D.EXRFlags.CompressZIP), 
					TextureSaveFileFormat.TGA => ImageConversion.EncodeArrayToTGA(data.Bytes, data.Format, (uint)data.Width, (uint)data.Height, rowBytes), 
					_ => throw new NotImplementedException(), 
				};
			}, cancellationToken);
		}

		private async Task<RawTextureData> CaptureRawDataAsync(Texture2D texture)
		{
			TaskCompletionSource<RawTextureData> taskCompletionSource = new TaskCompletionSource<RawTextureData>();
			GraphicsFormat graphicsFormat = texture.graphicsFormat;
			RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(texture.width, texture.height);
			renderTextureDescriptor.graphicsFormat = graphicsFormat;
			renderTextureDescriptor.sRGB = texture.isDataSRGB;
			renderTextureDescriptor.depthBufferBits = 0;
			RenderTextureDescriptor desc = renderTextureDescriptor;
			RenderTexture temporaryRenderTexture = RenderTexture.GetTemporary(desc);
			Graphics.Blit(texture, temporaryRenderTexture);
			AsyncGPUReadback.Request(temporaryRenderTexture, 0, delegate(AsyncGPUReadbackRequest request)
			{
				if (request.hasError)
				{
					taskCompletionSource.SetException(new Exception("[TextureSaveLoadService] tried to get data from texture, but GPU Readback failed!"));
				}
				else
				{
					taskCompletionSource.SetResult(new RawTextureData
					{
						Bytes = request.GetData<byte>().ToArray(),
						Width = texture.width,
						Height = texture.height,
						Format = graphicsFormat
					});
				}
				RenderTexture.ReleaseTemporary(temporaryRenderTexture);
			});
			return await taskCompletionSource.Task;
		}

		private void SaveTexture(Texture2D texture)
		{
			Texture2D textureToSave = GetTextureToSave(texture);
			byte[] dataFromTexture = GetDataFromTexture(textureToSave);
			SaveToFile(dataFromTexture, out var _);
		}

		private Texture2D LoadTextureFromFile(string filePath, TextureFormat textureFormat, bool isTargetTextureLinear)
		{
			byte[] textureData = LoadDataFromFile(filePath);
			return GetTextureFromData(textureData, textureFormat, isTargetTextureLinear);
		}

		private Texture2D GetTextureToSave(Texture2D texture)
		{
			bool flag = !texture.isDataSRGB;
			TextureFormat format = texture.format;
			RenderTextureFormat correspondingRenderTextureFormat = GetCorrespondingRenderTextureFormat(format);
			RenderTexture temporary = RenderTexture.GetTemporary(texture.width, texture.height, 0, correspondingRenderTextureFormat, flag ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
			Graphics.Blit(texture, temporary);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			bool flag2 = TextureFormatSupportsAlpha(texture.format);
			Texture2D obj = new Texture2D(textureFormat: (!saveIn16BitTextureFormat) ? (flag2 ? TextureFormat.RGBA32 : TextureFormat.RGB24) : ((!flag2) ? TextureFormat.RGB565 : ((format == TextureFormat.RGBAHalf) ? TextureFormat.RGBAHalf : TextureFormat.RGBA64)), width: texture.width, height: texture.height, mipChain: false, linear: flag);
			obj.ReadPixels(new Rect(0f, 0f, texture.width, texture.height), 0, 0);
			obj.Apply();
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			return obj;
		}

		private static bool TextureFormatSupportsAlpha(TextureFormat format)
		{
			switch (format)
			{
			case TextureFormat.Alpha8:
			case TextureFormat.ARGB4444:
			case TextureFormat.RGBA32:
			case TextureFormat.ARGB32:
			case TextureFormat.DXT5:
			case TextureFormat.RGBA4444:
			case TextureFormat.BGRA32:
			case TextureFormat.RGBAHalf:
			case TextureFormat.RGBAFloat:
			case TextureFormat.PVRTC_RGBA2:
			case TextureFormat.PVRTC_RGBA4:
			case TextureFormat.ETC2_RGBA8:
			case TextureFormat.RGBA64:
				return true;
			default:
				return false;
			}
		}

		private byte[] GetDataFromTexture(Texture2D textureToSave)
		{
			return saveFileFormat switch
			{
				TextureSaveFileFormat.PNG => textureToSave.EncodeToPNG(), 
				TextureSaveFileFormat.JPG => textureToSave.isDataSRGB ? textureToSave.EncodeToJPG(jpegImageQuality) : GetGammaSpaceTextureFromLinearSpaceTexture(textureToSave).EncodeToJPG(jpegImageQuality), 
				TextureSaveFileFormat.EXR => textureToSave.EncodeToEXR(Texture2D.EXRFlags.CompressZIP), 
				TextureSaveFileFormat.TGA => textureToSave.isDataSRGB ? textureToSave.EncodeToTGA() : GetGammaSpaceTextureFromLinearSpaceTexture(textureToSave).EncodeToTGA(), 
				_ => throw new NotImplementedException(), 
			};
		}

		private void SaveToFile(byte[] textureData, out string filePath)
		{
			string text = savedTextureFilesFolderPath;
			string text2 = ((text[text.Length - 1] == '/') ? string.Empty : "/");
			string text3 = Guid.NewGuid().ToString();
			filePath = string.Concat(str2: saveFileFormat switch
			{
				TextureSaveFileFormat.PNG => text3 + ".png", 
				TextureSaveFileFormat.JPG => text3 + ".jpg", 
				TextureSaveFileFormat.EXR => text3 + ".exr", 
				TextureSaveFileFormat.TGA => text3 + ".tga", 
				_ => throw new NotImplementedException(), 
			}, str0: savedTextureFilesFolderPath, str1: text2);
			File.WriteAllBytes(filePath, textureData);
		}

		private byte[] LoadDataFromFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Debug.LogError("[TextureSaveLoadService] could not load file. Reason - file not found at path '" + filePath + "'.");
				return null;
			}
			return File.ReadAllBytes(filePath);
		}

		private Texture2D GetTextureFromData(byte[] textureData, TextureFormat targetTextureFormat, bool isTargetTextureLinear)
		{
			Texture2D texture2D = new Texture2D(2, 2, targetTextureFormat, mipChain: false, isTargetTextureLinear);
			if (texture2D.LoadImage(textureData))
			{
				texture2D.filterMode = FilterMode.Bilinear;
				texture2D.wrapMode = TextureWrapMode.Clamp;
				Debug.Log("Texture converted successfully");
				texture2D = GetRawOrConvertedLoadedTexture(texture2D, isTargetTextureLinear);
				Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, targetTextureFormat, mipChain: false, isTargetTextureLinear);
				RenderTexture renderTexture = RenderTexture.GetTemporary(format: GetCorrespondingRenderTextureFormat(targetTextureFormat), width: texture2D.width, height: texture2D.height, depthBuffer: 0, readWrite: isTargetTextureLinear ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
				Graphics.Blit(texture2D, renderTexture);
				RenderTexture.active = renderTexture;
				texture2D2.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
				texture2D2.Apply();
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(renderTexture);
				UnityEngine.Object.Destroy(texture2D);
				return texture2D2;
			}
			Debug.LogError("[TextureSaveLoadService] could not convert texture data. File might be corrupted or it might have an unrecognizable format.");
			UnityEngine.Object.Destroy(texture2D);
			return null;
		}

		private static RenderTextureFormat GetCorrespondingRenderTextureFormat(TextureFormat targetTextureFormat)
		{
			return targetTextureFormat switch
			{
				TextureFormat.RGBA32 => RenderTextureFormat.ARGB32, 
				TextureFormat.RGBA64 => RenderTextureFormat.ARGB64, 
				TextureFormat.RGBAHalf => RenderTextureFormat.ARGBHalf, 
				TextureFormat.R8 => RenderTextureFormat.R8, 
				_ => throw new NotImplementedException(), 
			};
		}

		private Texture2D GetRawOrConvertedLoadedTexture(Texture2D loadedTexture, bool isTargetColorSpaceLinear)
		{
			if (isTargetColorSpaceLinear)
			{
				if (loadedTexture.isDataSRGB)
				{
					return GetLinearSpaceTextureFromGammaSpaceTexture(loadedTexture);
				}
				return loadedTexture;
			}
			if (!loadedTexture.isDataSRGB)
			{
				return GetGammaSpaceTextureFromLinearSpaceTexture(loadedTexture);
			}
			return loadedTexture;
		}

		private static Texture2D GetLinearSpaceTextureFromGammaSpaceTexture(Texture2D sourceTexture)
		{
			Color[] pixels = sourceTexture.GetPixels();
			Color[] array = new Color[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i].r = Mathf.GammaToLinearSpace(pixels[i].r);
				array[i].g = Mathf.GammaToLinearSpace(pixels[i].g);
				array[i].b = Mathf.GammaToLinearSpace(pixels[i].b);
				array[i].a = pixels[i].a;
			}
			Texture2D texture2D = new Texture2D(sourceTexture.width, sourceTexture.height, TextureFormat.RGBAHalf, mipChain: false, linear: true);
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}

		private static Texture2D GetGammaSpaceTextureFromLinearSpaceTexture(Texture2D sourceTexture)
		{
			Color[] pixels = sourceTexture.GetPixels();
			Color[] array = new Color[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i].r = Mathf.LinearToGammaSpace(pixels[i].r);
				array[i].g = Mathf.LinearToGammaSpace(pixels[i].g);
				array[i].b = Mathf.LinearToGammaSpace(pixels[i].b);
				array[i].a = pixels[i].a;
			}
			Texture2D texture2D = new Texture2D(sourceTexture.width, sourceTexture.height, TextureFormat.RGBAHalf, mipChain: false, linear: false);
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}
	}
}
