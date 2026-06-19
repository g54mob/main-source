using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	public static class ExtContentTextureUtils
	{
		public class ExtContentTexturesConfig
		{
			public bool bTest = true;

			public string[] SupportedTextureFileExtensions;

			public bool ApplySourceTextureFileSizeLimits = true;

			public int MinSourceTextureFileSize = 128;

			public int MaxSourceTextureFileSize = 209715200;

			public int MinTextureDimension = 16;

			public int MaxStagedMainTextureDimension = 512;

			public int MaxStagedIconTextureDimension = 256;

			public string GameItemIconBGImageFileName = "Workshop/DefaultPreviewImages/GameItemIconBG.png";

			public Color DefaultImageBgColour;

			public IconGenParams DefaultIconGenParams;
		}

		public class ScaleTexture2DCoroutineRetParams
		{
			public bool _bUpdatedOK;

			public Texture2D _updateTexture;
		}

		public const string cTargetTextureFileExtension = "png";

		public const string cTargetTextureFileExtensionWithDot = ".png";

		public const bool cUpdateMipmaps = false;

		public static Color cColourNull = new Color(0f, 0f, 0f, 0f);

		private const int cNumPixelsPerYield = 102400;

		public static void EnsureValidTargetTextureFileExtension(ref string fileSpec)
		{
			if (ExtContentUtils.GetPathExtensionWithoutDot(fileSpec) != "png")
			{
				fileSpec = Path.ChangeExtension(fileSpec, ".png");
			}
		}

		public static string GetValidTargetTextureFileExtension(string fileSpec)
		{
			string fileSpec2 = fileSpec;
			EnsureValidTargetTextureFileExtension(ref fileSpec2);
			return fileSpec2;
		}

		public static bool CheckImageFileExtensionSupported(string textureFileSpec)
		{
			return CheckImageFileExtensionSupported(textureFileSpec, ExtContentUtils.TexturesConfig.SupportedTextureFileExtensions);
		}

		public static bool CheckImageFileExtensionSupported(string textureFileSpec, string[] supportedTextureFileExtensions)
		{
			bool flag = false;
			string pathExtensionWithoutDot = ExtContentUtils.GetPathExtensionWithoutDot(textureFileSpec);
			for (int i = 0; i < supportedTextureFileExtensions.Length; i++)
			{
				if (supportedTextureFileExtensions[i].ToLower() == pathExtensionWithoutDot.ToLower())
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.UnsupportedImageFileType), textureFileSpec));
			}
			return flag;
		}

		public static string GetStreamingAssetsFolderSpec()
		{
			return Application.streamingAssetsPath;
		}

		private static void GetTexture2DPixels(Texture2D texture2D, ref Color[] retColorArray)
		{
			retColorArray = texture2D.GetPixels();
		}

		private static void SetTexture2DPixels(Texture2D texture2D, Color[] pixels)
		{
			texture2D.SetPixels(pixels);
		}

		private static void GetTexture2DPixels(Texture2D texture2D, ref Color32[] retColorArray)
		{
			retColorArray = texture2D.GetPixels32();
		}

		private static void SetTexture2DPixels(Texture2D texture2D, Color32[] pixels)
		{
			texture2D.SetPixels32(pixels);
		}

		public static bool ValidateTextureFileSpecForLoading(string textureFileSpec)
		{
			bool result = false;
			if (!textureFileSpec.IsNullOrEmpty())
			{
				if (File.Exists(textureFileSpec))
				{
					long length = new FileInfo(textureFileSpec).Length;
					if (!ExtContentUtils.TexturesConfig.ApplySourceTextureFileSizeLimits || (length >= ExtContentUtils.TexturesConfig.MinSourceTextureFileSize && length <= ExtContentUtils.TexturesConfig.MaxSourceTextureFileSize))
					{
						if (CheckImageFileExtensionSupported(textureFileSpec))
						{
							result = true;
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidSourceImageFileSize), textureFileSpec, length, ExtContentUtils.TexturesConfig.MinSourceTextureFileSize, ExtContentUtils.TexturesConfig.MaxSourceTextureFileSize));
					}
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidFileSpecGeneral), textureFileSpec));
				}
			}
			return result;
		}

		public static Texture2D LoadTexture2D(string textureFileSpec)
		{
			Texture2D texture2D = null;
			if (ValidateTextureFileSpecForLoading(textureFileSpec))
			{
				bool flag = false;
				string arg = string.Empty;
				try
				{
					byte[] array = File.ReadAllBytes(textureFileSpec);
					Texture2D texture2D2 = new Texture2D(2, 2);
					try
					{
						if (texture2D2.LoadImage(array, markNonReadable: false))
						{
							if (texture2D2 != null)
							{
								int minTextureDimension = ExtContentUtils.TexturesConfig.MinTextureDimension;
								if (texture2D2.width >= minTextureDimension && texture2D2.height >= minTextureDimension)
								{
									texture2D = texture2D2;
								}
								else
								{
									flag = true;
									arg = $"Texture dimensions (W: {texture2D2.width}, H: {texture2D2.height}) are less than allowed mininum of {minTextureDimension}";
								}
							}
							else
							{
								flag = true;
								arg = $"Failed to create texture from {array} raw image bytes";
							}
							if (texture2D != null)
							{
								ExtContentMessages.LogDebug($"Successfully loaded texture into Texture2D: '{Path.GetFileName(textureFileSpec)}' W:{texture2D.width}, H:{texture2D.height}, Format:{texture2D.format.ToString()}, MipCount:{texture2D.mipmapCount}, FileSize:{array.Length}, Spec:'{textureFileSpec}'");
							}
						}
					}
					catch (Exception ex)
					{
						flag = true;
						arg = $"Exception: '{ex.ToString()}'";
					}
				}
				catch (Exception ex2)
				{
					flag = true;
					arg = $"Exception: '{ex2.ToString()}'";
				}
				if (flag)
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorReadingImageFileGeneral), textureFileSpec, arg));
				}
			}
			return texture2D;
		}

		public static int GetTexture2DFileSize(Texture2D texture2D)
		{
			int result = 0;
			if (texture2D != null)
			{
				result = texture2D.EncodeToPNG().Length;
			}
			return result;
		}

		public static bool SaveTexture2D(Texture2D texture2D, string textureFileSpec)
		{
			bool result = false;
			if (texture2D != null)
			{
				byte[] array = texture2D.EncodeToPNG();
				try
				{
					EnsureValidTargetTextureFileExtension(ref textureFileSpec);
					File.WriteAllBytes(textureFileSpec, array);
					result = true;
					ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Successfully saved to disk image file '{0}' with size {1} bytes"), textureFileSpec, array.Length));
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorWritingImageFileGeneral), textureFileSpec, ex.ToString()));
				}
			}
			return result;
		}

		public static Texture2D CreateTexture2D(Texture2D texture2DSource, bool bUseOverrideTextureFormat = false, TextureFormat overrideTextureFormat = TextureFormat.ARGB32)
		{
			Texture2D result = null;
			if (texture2DSource != null)
			{
				TextureFormat textureFormat = (bUseOverrideTextureFormat ? overrideTextureFormat : texture2DSource.format);
				result = new Texture2D(texture2DSource.width, texture2DSource.height, textureFormat, mipChain: false);
			}
			return result;
		}

		public static Texture2D CreateTexture2DCopy(Texture2D texture2DSource, bool bUseOverrideTextureFormat = false, TextureFormat overrideTextureFormat = TextureFormat.ARGB32)
		{
			Texture2D texture2D = null;
			if (texture2DSource != null)
			{
				texture2D = CreateTexture2D(texture2DSource, bUseOverrideTextureFormat, overrideTextureFormat);
				if (texture2D != null)
				{
					if (texture2DSource.mipmapCount != texture2D.mipmapCount)
					{
						Graphics.CopyTexture(texture2DSource, 0, 0, texture2D, 0, 0);
					}
					else
					{
						Graphics.CopyTexture(texture2DSource, texture2D);
					}
				}
			}
			return texture2D;
		}

		public static Texture2D CreateTexture2DForSelectionArea(Texture2D sourceTexture2D, ImageSelectionArea sourceSelectionArea, int sourceTextureRotationCount = 0, int maxImageDimension = 0)
		{
			return CreateTexture2DForSelectionAreaInternal(sourceTexture2D, sourceSelectionArea, bUseImageBGColour: false, cColourNull, sourceTextureRotationCount, maxImageDimension);
		}

		public static Texture2D CreateTexture2DForSelectionArea(Texture2D sourceTexture2D, ImageSelectionArea sourceSelectionArea, Color imageBGColour, int sourceTextureRotationCount = 0, int maxImageDimension = 0)
		{
			return CreateTexture2DForSelectionAreaInternal(sourceTexture2D, sourceSelectionArea, bUseImageBGColour: true, imageBGColour, sourceTextureRotationCount, maxImageDimension);
		}

		private static Texture2D CreateTexture2DForSelectionAreaInternal(Texture2D sourceTexture2D, ImageSelectionArea sourceSelectionArea, bool bUseImageBGColour, Color imageBGColour, int sourceTextureRotationCount = 0, int maxImageDimension = 0)
		{
			Texture2D result = null;
			if (sourceTexture2D != null)
			{
				float scalingFactor = 1f;
				if (maxImageDimension > 0)
				{
					int num = (int)((float)sourceTexture2D.width * sourceSelectionArea.W);
					int num2 = (int)((float)sourceTexture2D.height * sourceSelectionArea.H);
					if (num > maxImageDimension || num2 > maxImageDimension)
					{
						int num3 = ((num - maxImageDimension > num2 - maxImageDimension) ? num : num2);
						scalingFactor = (float)maxImageDimension / (float)num3;
					}
				}
				Texture2D sourceTexture2D2 = sourceTexture2D;
				if (sourceTextureRotationCount != 0)
				{
					Texture2D texture2D = RotateTexture2D(sourceTexture2D, sourceTextureRotationCount);
					if (texture2D != null)
					{
						sourceTexture2D2 = texture2D;
					}
				}
				result = CreateScaledTexture2D(sourceTexture2D2, scalingFactor, sourceSelectionArea, bUseImageBGColour, imageBGColour);
			}
			return result;
		}

		public static Texture2D CreateUncompressedTexture2D(Texture2D texture2DCompressed)
		{
			Color[] pixels = texture2DCompressed.GetPixels();
			Texture2D texture2D = new Texture2D(texture2DCompressed.width, texture2DCompressed.height, TextureFormat.ARGB32, mipChain: false, linear: true);
			texture2D.SetPixels(pixels);
			return texture2D;
		}

		public static Texture2D CreateScaledTexture2D(Texture2D sourceTexture2D, float scalingFactor, ImageSelectionArea sourceSelectionArea, bool bUseImageBGColour, Color imageBGColour)
		{
			Texture2D texture2D = sourceTexture2D;
			if (sourceTexture2D != null)
			{
				if (sourceSelectionArea == null)
				{
					sourceSelectionArea = new ImageSelectionArea();
				}
				if (scalingFactor != 0f && (scalingFactor != 1f || sourceSelectionArea.W != 1f || sourceSelectionArea.H != 1f))
				{
					int num = (int)((float)sourceTexture2D.width * sourceSelectionArea.W);
					int num2 = (int)((float)sourceTexture2D.height * sourceSelectionArea.H);
					if (num > 0 && num2 > 0)
					{
						int num3 = (int)((float)num * scalingFactor);
						int num4 = (int)((float)num2 * scalingFactor);
						float num5 = sourceSelectionArea.CentreX - sourceSelectionArea.W * 0.5f;
						float num6 = sourceSelectionArea.CentreY - sourceSelectionArea.H * 0.5f;
						float num7 = 1f / (float)num3;
						float num8 = 1f / (float)num4;
						texture2D = new Texture2D(num3, num4, sourceTexture2D.format, mipChain: false);
						Color[] pixels = texture2D.GetPixels(0);
						Color color = cColourNull;
						color.a = 1f;
						for (int i = 0; i < num4; i++)
						{
							for (int j = 0; j < num3; j++)
							{
								float num9 = (float)j * num7;
								float num10 = (float)i * num8;
								float u = num5 + num9 * sourceSelectionArea.W;
								float v = num6 + num10 * sourceSelectionArea.H;
								int num11 = i * num3 + j;
								Color pixelBilinear = sourceTexture2D.GetPixelBilinear(u, v);
								if (bUseImageBGColour)
								{
									if (pixelBilinear.a < 1f)
									{
										if (pixelBilinear.a > 0f)
										{
											color.r = Mathf.Lerp(imageBGColour.r, pixelBilinear.r, pixelBilinear.a);
											color.g = Mathf.Lerp(imageBGColour.g, pixelBilinear.g, pixelBilinear.a);
											color.b = Mathf.Lerp(imageBGColour.b, pixelBilinear.b, pixelBilinear.a);
											pixels[num11] = color;
										}
										else
										{
											pixels[num11] = imageBGColour;
										}
									}
									else
									{
										pixels[num11] = pixelBilinear;
									}
								}
								else
								{
									pixels[num11] = pixelBilinear;
								}
							}
						}
						texture2D.SetPixels(pixels, 0);
						texture2D.Apply();
					}
				}
			}
			if (texture2D == null)
			{
				texture2D = CreateTexture2DCopy(sourceTexture2D);
			}
			return texture2D;
		}

		public static Texture2D RotateTexture2D(Texture2D sourceTexture2D, int rotationCount)
		{
			Texture2D texture2D = null;
			if (sourceTexture2D != null)
			{
				rotationCount %= 4;
				if (rotationCount != 0)
				{
					int width = sourceTexture2D.width;
					int height = sourceTexture2D.height;
					int num = width;
					int num2 = height;
					if (rotationCount != 2)
					{
						num = height;
						num2 = width;
					}
					texture2D = new Texture2D(num, num2, sourceTexture2D.format, mipChain: false);
					if (texture2D != null)
					{
						int num3 = width / 2;
						int num4 = height / 2;
						int num5 = num / 2;
						int num6 = num2 / 2;
						int num7 = 0;
						int num8 = 0;
						Color[] pixels = sourceTexture2D.GetPixels(0);
						Color[] pixels2 = texture2D.GetPixels(0);
						for (int i = 0; i < width; i++)
						{
							for (int j = 0; j < height; j++)
							{
								int num9 = j * width + i;
								Color color = pixels[num9];
								switch (rotationCount)
								{
								case 1:
									num7 = j - num4 + num5;
									num8 = -(i - num3) + num6;
									break;
								case 2:
									num7 = -(i - num3) + num5;
									num8 = -(j - num4) + num6;
									break;
								case 3:
									num7 = -(j - num4) + num5;
									num8 = i - num3 + num6;
									break;
								}
								if (num7 >= 0 && num8 >= 0 && num7 < num && num8 < num2)
								{
									int num10 = num8 * num + num7;
									pixels2[num10] = color;
								}
							}
						}
						texture2D.SetPixels(pixels2, 0);
						texture2D.Apply();
					}
				}
			}
			if (texture2D == null)
			{
				texture2D = CreateTexture2DCopy(sourceTexture2D);
			}
			return texture2D;
		}

		public static bool CopyTextureFileSelection(ExtContentImageSpec sourceImageSpec, ExtContentImageSpec targetImageSpec, Color imageBGColour, int maxImageDimension = 0)
		{
			bool result = false;
			Texture2D texture2D = LoadTexture2D(sourceImageSpec.FileSpec);
			if (texture2D != null)
			{
				Texture2D texture2D2 = CreateTexture2DForSelectionArea(texture2D, sourceImageSpec.SelectionArea, imageBGColour, sourceImageSpec.RotationIndex, maxImageDimension);
				if (texture2D2 != null && SaveTexture2D(texture2D2, targetImageSpec.FileSpec))
				{
					result = true;
				}
			}
			return result;
		}

		public static bool CopyTextureFileSelectionCompositeIcon(bool bIconOverrideSpecified, ExtContentImageSpec sourceImageSpec, ExtContentImageSpec targetImageSpec, IconGenParams iconGenParams, Color imageBGColour, int maxImageDimension = 0)
		{
			bool result = false;
			if (iconGenParams != null)
			{
				Texture2D texture2D = LoadTexture2D(sourceImageSpec.FileSpec);
				if (texture2D != null)
				{
					Texture2D texture2D2 = CreateTexture2DForSelectionArea(texture2D, sourceImageSpec.SelectionArea, imageBGColour, sourceImageSpec.RotationIndex, maxImageDimension);
					if (texture2D2 != null && iconGenParams.GetTexture2D() != null)
					{
						if (!bIconOverrideSpecified && iconGenParams._rotateIconImageCount != 0)
						{
							texture2D2 = RotateTexture2D(texture2D2, iconGenParams._rotateIconImageCount);
						}
						float mainImagePreferredAsepctRatio = (float)texture2D2.width / (float)texture2D2.height;
						float iconImageAspectRatio = iconGenParams.GetIconImageAspectRatio(mainImagePreferredAsepctRatio);
						ImageSelectionArea imageSelectionArea = new ImageSelectionArea();
						imageSelectionArea.ScaleToFitAspectRatios((float)texture2D2.width / (float)texture2D2.height, iconImageAspectRatio);
						Texture2D texture2D3 = CreateTexture2DForSelectionArea(texture2D2, imageSelectionArea, imageBGColour);
						if (texture2D3 != null)
						{
							Texture2D texture2D4 = CreateTargetTextureWithSourceIcon(texture2D3, iconGenParams, imageBGColour);
							if (texture2D4 != null && SaveTexture2D(texture2D4, targetImageSpec.FileSpec))
							{
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		public static bool ConstrainTexture2D(ref Texture2D texture2DToUpdate, int maxDimension)
		{
			bool result = false;
			if (texture2DToUpdate != null && maxDimension > 0 && (texture2DToUpdate.width > maxDimension || texture2DToUpdate.height > maxDimension))
			{
				int num = ((texture2DToUpdate.width - maxDimension > texture2DToUpdate.height - maxDimension) ? texture2DToUpdate.width : texture2DToUpdate.height);
				float num2 = (float)maxDimension / (float)num;
				if (num2 != 1f)
				{
					ScaleTexture2D(ref texture2DToUpdate, num2);
					result = true;
				}
			}
			return result;
		}

		public static bool ScaleTexture2D(ref Texture2D texture2DToUpdate, float scalingFactor)
		{
			bool result = false;
			if (texture2DToUpdate != null && scalingFactor != 0f && scalingFactor != 1f)
			{
				int width = texture2DToUpdate.width;
				int height = texture2DToUpdate.height;
				if (width > 0 && height > 0)
				{
					int num = (int)((float)width * scalingFactor);
					int num2 = (int)((float)height * scalingFactor);
					float num3 = 1f / (float)num;
					float num4 = 1f / (float)num2;
					Texture2D texture2D = new Texture2D(num, num2, texture2DToUpdate.format, mipChain: false);
					Color[] pixels = texture2D.GetPixels(0);
					for (int i = 0; i < num2; i++)
					{
						float v = (float)i * num4;
						for (int j = 0; j < num; j++)
						{
							float u = (float)j * num3;
							int num5 = i * num + j;
							pixels[num5] = texture2DToUpdate.GetPixelBilinear(u, v);
						}
					}
					texture2D.SetPixels(pixels, 0);
					texture2D.Apply();
					texture2DToUpdate = texture2D;
					result = true;
				}
			}
			return result;
		}

		public static bool ScaleTexture2DQuick(ref Texture2D texture2DToUpdate, float scalingFactor)
		{
			bool result = false;
			if (texture2DToUpdate != null && scalingFactor != 0f && scalingFactor != 1f)
			{
				int width = texture2DToUpdate.width;
				int height = texture2DToUpdate.height;
				if (width > 0 && height > 0)
				{
					int num = (int)((float)width * scalingFactor);
					int num2 = (int)((float)height * scalingFactor);
					int max = width - 1;
					int max2 = height - 1;
					float num3 = 1f / scalingFactor;
					Texture2D texture2D = new Texture2D(num, num2, texture2DToUpdate.format, mipChain: false);
					Color[] pixels = texture2DToUpdate.GetPixels(0);
					Color[] pixels2 = texture2D.GetPixels(0);
					for (int i = 0; i < num2; i++)
					{
						int num4 = Mathf.Clamp((int)((float)i * num3), 0, max2);
						for (int j = 0; j < num; j++)
						{
							int num5 = Mathf.Clamp((int)((float)j * num3), 0, max);
							int num6 = num4 * width + num5;
							int num7 = i * num + j;
							pixels2[num7] = pixels[num6];
						}
					}
					texture2D.SetPixels(pixels2, 0);
					texture2D.Apply();
					texture2DToUpdate = texture2D;
					result = true;
				}
			}
			return result;
		}

		public static IEnumerator ScaleTexture2DCoroutine(ScaleTexture2DCoroutineRetParams retParams, Texture2D texture2DSource, float scalingFactor)
		{
			retParams._bUpdatedOK = false;
			retParams._updateTexture = texture2DSource;
			if (retParams._updateTexture != null && scalingFactor != 0f && scalingFactor != 1f)
			{
				int width = retParams._updateTexture.width;
				int height = retParams._updateTexture.height;
				if (width > 0 && height > 0)
				{
					int targetW = (int)((float)width * scalingFactor);
					int targetH = (int)((float)height * scalingFactor);
					float normFactorX = 1f / (float)targetW;
					float normFactorY = 1f / (float)targetH;
					Texture2D texture2DTarget = new Texture2D(targetW, targetH, retParams._updateTexture.format, mipChain: false);
					Color[] targetPixels = texture2DTarget.GetPixels(0);
					int numPixelsSinceLastYield = 0;
					int ty = 0;
					while (ty < targetH)
					{
						float sourceYNorm = (float)ty * normFactorY;
						int num2;
						for (int tx = 0; tx < targetW; tx = num2)
						{
							float u = (float)tx * normFactorX;
							int num = ty * targetW + tx;
							targetPixels[num] = texture2DSource.GetPixelBilinear(u, sourceYNorm);
							numPixelsSinceLastYield++;
							if (numPixelsSinceLastYield >= 102400)
							{
								numPixelsSinceLastYield = 0;
								yield return null;
							}
							num2 = tx + 1;
						}
						num2 = ty + 1;
						ty = num2;
					}
					texture2DTarget.SetPixels(targetPixels, 0);
					texture2DTarget.Apply();
					retParams._updateTexture = texture2DTarget;
					retParams._bUpdatedOK = true;
				}
			}
			yield return null;
		}

		public static IEnumerator ScaleTexture2DQuickCoroutine(ScaleTexture2DCoroutineRetParams retParams, Texture2D texture2DSource, float scalingFactor)
		{
			retParams._bUpdatedOK = false;
			retParams._updateTexture = texture2DSource;
			if (retParams._updateTexture != null && scalingFactor != 0f && scalingFactor != 1f)
			{
				int sw = retParams._updateTexture.width;
				int height = retParams._updateTexture.height;
				if (sw > 0 && height > 0)
				{
					int tw = (int)((float)sw * scalingFactor);
					int th = (int)((float)height * scalingFactor);
					int sxmax = sw - 1;
					int symax = height - 1;
					float invScalingFactor = 1f / scalingFactor;
					Texture2D texture2DTarget = new Texture2D(tw, th, retParams._updateTexture.format, mipChain: false);
					Color[] sourcePixels = retParams._updateTexture.GetPixels(0);
					Color[] targetPixels = texture2DTarget.GetPixels(0);
					int numPixelsSinceLastYield = 0;
					int ty = 0;
					while (ty < th)
					{
						int sy = Mathf.Clamp((int)((float)ty * invScalingFactor), 0, symax);
						int num4;
						for (int tx = 0; tx < tw; tx = num4)
						{
							int num = Mathf.Clamp((int)((float)tx * invScalingFactor), 0, sxmax);
							int num2 = sy * sw + num;
							int num3 = ty * tw + tx;
							targetPixels[num3] = sourcePixels[num2];
							numPixelsSinceLastYield++;
							if (numPixelsSinceLastYield >= 102400)
							{
								numPixelsSinceLastYield = 0;
								yield return null;
							}
							num4 = tx + 1;
						}
						num4 = ty + 1;
						ty = num4;
					}
					texture2DTarget.SetPixels(targetPixels, 0);
					texture2DTarget.Apply();
					retParams._updateTexture = texture2DTarget;
					retParams._bUpdatedOK = true;
				}
			}
			yield return null;
		}

		public static bool UpdateImageTexture(ref Image imageToUpdate, Texture2D texture2D, bool bScaleToCompletelyFillParent = false)
		{
			bool result = false;
			if (imageToUpdate != null)
			{
				bool flag = true;
				if (texture2D != null)
				{
					float num = texture2D.width;
					float num2 = texture2D.height;
					float num3 = num / num2;
					if (!bScaleToCompletelyFillParent)
					{
						Sprite sprite = CreateTextureSprite(texture2D);
						if (sprite != null)
						{
							result = true;
							imageToUpdate.overrideSprite = sprite;
							imageToUpdate.color = Color.white;
							ResizeGameObjectToFitParentMaintainingAspectRatio(imageToUpdate.gameObject, num3);
							flag = false;
						}
					}
					else
					{
						RectTransform rectTransform = (RectTransform)imageToUpdate.transform.parent;
						float reqdAspectRatio = rectTransform.rect.width / rectTransform.rect.height;
						ImageSelectionArea imageSelectionArea = new ImageSelectionArea();
						imageSelectionArea.ScaleToFitAspectRatios(num3, reqdAspectRatio);
						Texture2D texture2D2 = CreateTexture2DForSelectionArea(texture2D, imageSelectionArea);
						if (texture2D2 != null)
						{
							Sprite sprite2 = CreateTextureSprite(texture2D2);
							if (sprite2 != null)
							{
								result = true;
								imageToUpdate.overrideSprite = sprite2;
								imageToUpdate.color = Color.white;
								FitGameObjectToParent(imageToUpdate.gameObject);
								flag = false;
							}
						}
					}
				}
				if (flag)
				{
					SetImageDefaultBG(ref imageToUpdate);
					FitGameObjectToParent(imageToUpdate.gameObject);
				}
			}
			return result;
		}

		public static void FitGameObjectToParent(GameObject gameObject)
		{
			if (gameObject != null)
			{
				RectTransform rectTransform = (RectTransform)gameObject.transform.parent;
				RectTransform rect = (RectTransform)gameObject.transform;
				rect.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, 0f, rectTransform.rect.height);
				rect.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Left, 0f, rectTransform.rect.width);
			}
		}

		public static bool ResizeGameObjectToFitParentMaintainingAspectRatio(GameObject gameObjectToUpdate, float aspectRatio)
		{
			bool result = false;
			if (gameObjectToUpdate != null && aspectRatio > 0f)
			{
				RectTransform rectTransform = (RectTransform)gameObjectToUpdate.transform.parent;
				if (rectTransform != null)
				{
					RectTransform rectTransform2 = (RectTransform)gameObjectToUpdate.transform;
					float width = rectTransform.rect.width;
					float height = rectTransform.rect.height;
					if (width > 0f && height > 0f)
					{
						float num = width / height;
						bool num2 = aspectRatio > num;
						bool flag = aspectRatio < num;
						if (num2)
						{
							float num3 = width / aspectRatio;
							float num4 = (height - num3) * 0.5f;
							if (num4 < 0f)
							{
								num4 = 0f;
							}
							if (num3 > height)
							{
								num3 = height;
							}
							rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, num4, num3);
							rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, width);
						}
						else if (flag)
						{
							float num5 = height * aspectRatio;
							float num6 = (width - num5) * 0.5f;
							if (num6 < 0f)
							{
								num6 = 0f;
							}
							if (num5 > width)
							{
								num5 = width;
							}
							rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, height);
							rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, num6, num5);
						}
						else
						{
							rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, width);
							rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, height);
						}
						result = true;
					}
				}
			}
			return result;
		}

		public static Sprite CreateTextureSprite(Texture2D texture2D)
		{
			Sprite result = null;
			if (texture2D != null)
			{
				result = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f));
			}
			return result;
		}

		public static bool SetImageDefaultBG(ref Image imageToUpdate)
		{
			return SetImageTextureSprite(ref imageToUpdate, Texture2D.blackTexture, bUseMinDimensions: true);
		}

		public static bool SetImageTextureSprite(ref Image imageToUpdate, Texture2D texture2D, bool bUseMinDimensions = false)
		{
			bool result = false;
			if (imageToUpdate != null && texture2D != null)
			{
				int num = ((!bUseMinDimensions) ? texture2D.width : 2);
				int num2 = ((!bUseMinDimensions) ? texture2D.height : 2);
				Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, num, num2), new Vector2(0f, 0f));
				if (sprite != null)
				{
					imageToUpdate.overrideSprite = sprite;
					imageToUpdate.color = Color.white;
					result = true;
				}
			}
			return result;
		}

		public static void ScaleDimensionsToFitParentMaintainingAspectRatio(float targetAspectRatio, int parentW, int parentH, ref int outTargetW, ref int outTargetH)
		{
			float outTargetW2 = outTargetW;
			float outTargetH2 = outTargetH;
			ScaleDimensionsToFitParentMaintainingAspectRatio(targetAspectRatio, parentW, parentH, ref outTargetW2, ref outTargetH2, bNormalise: false);
			outTargetW = (int)outTargetW2;
			outTargetH = (int)outTargetH2;
		}

		public static void ScaleDimensionsToFitParentMaintainingAspectRatio(float targetAspectRatio, float parentW, float parentH, ref float outTargetW, ref float outTargetH, bool bNormalise = true)
		{
			float num = parentW;
			float num2 = parentH;
			float num3 = parentW / parentH;
			if (targetAspectRatio > num3)
			{
				num2 = parentW / targetAspectRatio;
			}
			else
			{
				num = parentH * targetAspectRatio;
			}
			if (num > parentW)
			{
				num = parentW;
			}
			if (num2 > parentH)
			{
				num2 = parentH;
			}
			if (bNormalise)
			{
				num /= parentW;
				num2 /= parentH;
			}
			outTargetW = num;
			outTargetH = num2;
		}

		public static Texture2D CreateTargetTextureWithSourceIcon(Texture2D sourceTexture2D, IconGenParams iconGenParams, Color imageBGColour, bool editorUIEnabled = false, int editorUIVertexIndex1 = 0, int editorUIVertexIndex2 = 0)
		{
			Texture2D texture2D = null;
			if (iconGenParams._bUseIconMaskMethod)
			{
				return CreateTargetTextureWithSourceIconInternalMasked(sourceTexture2D, iconGenParams, imageBGColour, editorUIEnabled, editorUIVertexIndex1, editorUIVertexIndex2);
			}
			return CreateTargetTextureWithSourceIconInternal(sourceTexture2D, iconGenParams, imageBGColour);
		}

		private static Texture2D CreateTargetTextureWithSourceIconInternal(Texture2D sourceTexture2D, IconGenParams iconGenParams, Color imageBGColour)
		{
			Texture2D result = null;
			Texture2D texture2D = iconGenParams.GetTexture2D();
			if (sourceTexture2D != null && texture2D != null)
			{
				Vector2[] obj = new Vector2[4]
				{
					new Vector2(iconGenParams._UVs[0].x, iconGenParams._UVs[0].y),
					new Vector2(iconGenParams._UVs[1].x, iconGenParams._UVs[1].y),
					new Vector2(iconGenParams._UVs[2].x, iconGenParams._UVs[2].y),
					new Vector2(iconGenParams._UVs[3].x, iconGenParams._UVs[3].y)
				};
				float x = obj[0].x;
				float x2 = obj[1].x;
				float x3 = obj[2].x;
				float x4 = obj[3].x;
				float y = obj[1].y;
				float y2 = obj[0].y;
				float y3 = obj[3].y;
				float y4 = obj[2].y;
				texture2D = CreateTexture2DCopy(texture2D);
				Texture2D texture2D2 = sourceTexture2D;
				Texture2D texture2D3 = texture2D;
				float num = Mathf.Max(x3 - x2, x4 - x) * (float)texture2D3.width;
				float num2 = Mathf.Max(y - y2, y4 - y3) * (float)texture2D3.height;
				float num3 = texture2D2.width;
				float num4 = texture2D2.height;
				if (num3 < num || num4 < num2)
				{
					float scalingFactor = ((num - num3 > num2 - num4) ? (num / num3) : (num2 / num4));
					texture2D2 = CreateScaledTexture2D(texture2D2, scalingFactor, null, bUseImageBGColour: false, cColourNull);
				}
				int width = texture2D2.width;
				int height = texture2D2.height;
				float num5 = width;
				float num6 = height;
				int width2 = texture2D3.width;
				int height2 = texture2D3.height;
				float num7 = width2;
				float num8 = height2;
				Color[] pixels = texture2D2.GetPixels(0);
				Color[] pixels2 = texture2D3.GetPixels(0);
				if (iconGenParams._borderSize > 0)
				{
					int borderSize = iconGenParams._borderSize;
					Color borderColor = iconGenParams._borderColor;
					Vector2[] array = new Vector2[8]
					{
						new Vector2(-1f, -1f),
						new Vector2(-1f, 0f),
						new Vector2(-1f, 1f),
						new Vector2(0f, 1f),
						new Vector2(1f, 1f),
						new Vector2(1f, 0f),
						new Vector2(1f, -1f),
						new Vector2(0f, -1f)
					};
					List<Vector2> list = new List<Vector2>();
					int num9 = borderSize * borderSize;
					for (int i = -borderSize; i <= borderSize; i++)
					{
						int num10 = i * i;
						for (int j = -borderSize; j <= borderSize; j++)
						{
							if (j * j + num10 >= num9)
							{
								list.Add(new Vector2(j, i));
							}
						}
					}
					int count = list.Count;
					for (int k = 0; k < width; k++)
					{
						for (int l = 0; l < height; l++)
						{
							int num11 = l * width + k;
							Color color = pixels[num11];
							bool flag = false;
							if (color.a <= 0f)
							{
								bool flag2 = false;
								for (int m = 0; m < 8; m++)
								{
									int num12 = k + (int)array[m].x;
									int num13 = l + (int)array[m].y;
									if (num12 >= 0 && num12 < width && num13 >= 0 && num13 < height)
									{
										int num14 = num13 * width + num12;
										if (pixels[num14].a > 0f)
										{
											flag2 = true;
											break;
										}
									}
								}
								if (flag2)
								{
									flag = true;
								}
							}
							else if (k < borderSize || l < borderSize || k > width - borderSize || l > height - borderSize)
							{
								flag = true;
							}
							if (!flag)
							{
								continue;
							}
							float num15 = (float)k / num5;
							float num16 = (float)l / num6;
							float num17 = x + (x2 - x) * num16;
							float num18 = x4 + (x3 - x4) * num16;
							float num19 = num17 + (num18 - num17) * num15;
							float num20 = y2 + (y3 - y2) * num15;
							float num21 = y + (y4 - y) * num15;
							float num22 = num20 + (num21 - num20) * num16;
							for (int n = 0; n < count; n++)
							{
								int num23 = (int)(num19 * num7 + list[n].x);
								int num24 = (int)(num22 * num8 + list[n].y);
								if (num23 >= 0 && num23 < width2 && num24 >= 0 && num24 < height2)
								{
									int num25 = num24 * width2 + num23;
									pixels2[num25] = borderColor;
								}
							}
						}
					}
				}
				for (int num26 = 0; num26 < width; num26++)
				{
					for (int num27 = 0; num27 < height; num27++)
					{
						int num28 = num27 * width + num26;
						Color color2 = pixels[num28];
						if (color2.a > 0f)
						{
							float num29 = (float)num26 / num5;
							float num30 = (float)num27 / num6;
							float num31 = x + (x2 - x) * num30;
							float num32 = x4 + (x3 - x4) * num30;
							float num33 = num31 + (num32 - num31) * num29;
							float num34 = y2 + (y3 - y2) * num29;
							float num35 = y + (y4 - y) * num29;
							float num36 = num34 + (num35 - num34) * num30;
							int num37 = (int)(num33 * num7);
							int num38 = (int)(num36 * num8) * width2 + num37;
							pixels2[num38] = color2;
						}
					}
				}
				texture2D3.SetPixels(pixels2, 0);
				texture2D3.Apply();
				result = texture2D3;
			}
			return result;
		}

		private static Texture2D CreateTargetTextureWithSourceIconInternalMasked(Texture2D sourceTexture2D, IconGenParams iconGenParams, Color imageBGColour, bool editorUIEnabled = false, int editorUIVertexIndex1 = 0, int editorUIVertexIndex2 = 0)
		{
			Texture2D result = null;
			Texture2D texture2D = iconGenParams.GetTexture2D();
			if (sourceTexture2D != null && texture2D != null)
			{
				Vector2[] obj = new Vector2[4]
				{
					new Vector2(iconGenParams._UVs[0].x, iconGenParams._UVs[0].y),
					new Vector2(iconGenParams._UVs[1].x, iconGenParams._UVs[1].y),
					new Vector2(iconGenParams._UVs[2].x, iconGenParams._UVs[2].y),
					new Vector2(iconGenParams._UVs[3].x, iconGenParams._UVs[3].y)
				};
				float x = obj[0].x;
				float x2 = obj[1].x;
				float x3 = obj[2].x;
				float x4 = obj[3].x;
				float y = obj[1].y;
				float y2 = obj[0].y;
				float y3 = obj[3].y;
				float y4 = obj[2].y;
				Texture2D texture2D2 = CreateTexture2D(texture2D);
				Texture2D texture2D3 = sourceTexture2D;
				Texture2D texture2D4 = texture2D;
				Texture2D texture2D5 = texture2D2;
				Color[] array = null;
				Color[] array2 = null;
				Color[] array3 = null;
				float num = Mathf.Max(x3 - x2, x4 - x) * (float)texture2D4.width;
				float num2 = Mathf.Max(y - y2, y4 - y3) * (float)texture2D4.height;
				float num3 = texture2D3.width;
				float num4 = texture2D3.height;
				if (num3 < num || num4 < num2)
				{
					float a = num / num3;
					float b = num2 / num4;
					float num5 = Mathf.Max(a, b);
					num5 *= 1.25f;
					texture2D3 = CreateScaledTexture2D(texture2D3, num5, null, bUseImageBGColour: false, cColourNull);
				}
				int width = texture2D3.width;
				int height = texture2D3.height;
				float num6 = width;
				float num7 = height;
				int width2 = texture2D4.width;
				int height2 = texture2D4.height;
				float num8 = width2;
				float num9 = height2;
				array = texture2D3.GetPixels(0);
				array2 = texture2D4.GetPixels(0);
				array3 = texture2D5.GetPixels(0);
				Color color = new Color(0f, 0f, 0f, 0f);
				int i = 0;
				for (int num10 = array3.Length; i < num10; i++)
				{
					array3[i] = color;
				}
				int rotateUVsCount = iconGenParams._rotateUVsCount;
				rotateUVsCount %= 4;
				if (rotateUVsCount < 0)
				{
					rotateUVsCount += 4;
				}
				float num11 = num6;
				float num12 = num7;
				if (rotateUVsCount == 1 || rotateUVsCount == 3)
				{
					num11 = num7;
					num12 = num6;
				}
				for (int j = 0; j < width; j++)
				{
					for (int k = 0; k < height; k++)
					{
						int num13 = k * width + j;
						Color color2 = array[num13];
						float num14 = j;
						float num15 = k;
						switch (rotateUVsCount)
						{
						case 1:
							num14 = k;
							num15 = j;
							break;
						case 2:
							num14 = width - j;
							num15 = height - k;
							break;
						case 3:
							num14 = height - k;
							num15 = width - j;
							break;
						}
						float num16 = num14 / num11;
						float num17 = num15 / num12;
						float num18 = x + (x2 - x) * num17;
						float num19 = x4 + (x3 - x4) * num17;
						float num20 = num18 + (num19 - num18) * num16;
						float num21 = y2 + (y3 - y2) * num16;
						float num22 = y + (y4 - y) * num16;
						float num23 = num21 + (num22 - num21) * num17;
						int num24 = (int)(num20 * num8);
						int num25 = (int)(num23 * num9) * width2 + num24;
						if (color2.a > 0f)
						{
							array3[num25] = color2;
						}
						else
						{
							array3[num25] = imageBGColour;
						}
					}
				}
				Color color3 = cColourNull;
				int l = 0;
				for (int num26 = array2.Length; l < num26; l++)
				{
					Color color4 = array2[l];
					if (color4.a < 1f)
					{
						if (color4.a > 0f)
						{
							Color color5 = array3[l];
							color3.r = Mathf.Lerp(color5.r, color4.r, color4.a);
							color3.g = Mathf.Lerp(color5.g, color4.g, color4.a);
							color3.b = Mathf.Lerp(color5.b, color4.b, color4.a);
							color3.a = Mathf.Lerp(color5.a, color4.a, color4.a);
							array3[l] = color3;
						}
					}
					else
					{
						array3[l] = color4;
					}
				}
				texture2D5.SetPixels(array3, 0);
				texture2D5.Apply();
				result = texture2D5;
			}
			return result;
		}

		public static void OverlayTextures2DAt(Texture2D texture2DToUpdate, Texture2D texture2DToOverlay, float normPosX, float normPosY)
		{
			if (!(texture2DToUpdate != null) || !(texture2DToOverlay != null))
			{
				return;
			}
			Color[] pixels = texture2DToUpdate.GetPixels(0);
			Color[] pixels2 = texture2DToOverlay.GetPixels(0);
			int width = texture2DToOverlay.width;
			int height = texture2DToOverlay.height;
			int width2 = texture2DToUpdate.width;
			int height2 = texture2DToUpdate.height;
			int num = (int)((float)width2 * normPosX);
			int num2 = (int)((float)height2 * normPosY);
			int num3 = 0;
			int num4 = num;
			while (num3 < width)
			{
				int num5 = 0;
				int num6 = num2;
				while (num5 < height)
				{
					if (num4 >= 0 && num4 < width2 && num6 >= 0 && num6 < height2)
					{
						int num7 = num6 * width2 + num4;
						int num8 = num5 * width + num3;
						Color color = pixels[num7];
						Color color2 = pixels2[num8];
						if (color2.a < 1f)
						{
							if (color2.a > 0f)
							{
								color.r = Mathf.Lerp(color.r, color2.r, color2.a);
								color.g = Mathf.Lerp(color.g, color2.g, color2.a);
								color.b = Mathf.Lerp(color.b, color2.b, color2.a);
								color.a = 1f;
								pixels[num7] = color;
							}
						}
						else
						{
							pixels[num7] = color2;
						}
					}
					num5++;
					num6++;
				}
				num3++;
				num4++;
			}
			texture2DToUpdate.SetPixels(pixels, 0);
			texture2DToUpdate.Apply();
		}
	}
}
