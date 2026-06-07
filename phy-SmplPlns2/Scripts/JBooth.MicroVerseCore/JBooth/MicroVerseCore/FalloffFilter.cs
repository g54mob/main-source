using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[Serializable]
	public class FalloffFilter
	{
		public enum FilterType
		{
			Global = 0,
			Box = 1,
			Range = 2,
			Texture = 3,
			SplineArea = 4,
			PaintMask = 5
		}

		public enum FilterTypeNoGlobal
		{
			Box = 1,
			Range = 2,
			Texture = 3,
			SplineArea = 4,
			PaintMask = 5
		}

		public enum FilterTypeNoPaintMask
		{
			Global = 0,
			Box = 1,
			Range = 2,
			Texture = 3,
			SplineArea = 4
		}

		public enum FilterTypeNoGlobalNoPaintMask
		{
			Box = 1,
			Range = 2,
			Texture = 3,
			SplineArea = 4
		}

		public enum TextureChannel
		{
			R = 0,
			G = 1,
			B = 2,
			A = 3
		}

		[Serializable]
		public class PaintMask
		{
			public enum Size
			{
				k64 = 0x40,
				k128 = 0x80,
				k256 = 0x100,
				k512 = 0x200,
				k1024 = 0x400
			}

			public enum UpdateMode
			{
				EveryChange = 0,
				EndStroke = 1
			}

			[NonSerialized]
			public Texture2D texture;

			public byte[] bytes;

			public Size size = Size.k256;

			[NonSerialized]
			public bool painting;

			public UpdateMode updateMode;

			public void Clear()
			{
				if (texture != null)
				{
					UnityEngine.Object.DestroyImmediate(texture);
				}
				texture = null;
				bytes = null;
			}

			public void Resize(Size newSize)
			{
				if (newSize != size && texture != null)
				{
					size = newSize;
					RenderTexture temporary = RenderTexture.GetTemporary((int)newSize, (int)newSize, 0, RenderTextureFormat.R16, RenderTextureReadWrite.Linear);
					Graphics.Blit(texture, temporary);
					Clear();
					Unpack();
					RenderTexture.active = temporary;
					texture.ReadPixels(new Rect(0f, 0f, texture.width, texture.height), 0, 0);
					texture.Apply();
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(temporary);
					Pack();
				}
				else if (texture == null)
				{
					size = newSize;
				}
			}

			public void Fill(float val)
			{
				if (texture == null)
				{
					Unpack();
				}
				Color color = new Color(val, 0f, 0f, 0f);
				for (int i = 0; i < texture.width; i++)
				{
					for (int j = 0; j < texture.height; j++)
					{
						texture.SetPixel(i, j, color);
					}
				}
				texture.Apply(updateMipmaps: false, makeNoLongerReadable: false);
				Pack();
			}

			public void Unpack()
			{
				if (texture == null || texture.width != (int)size)
				{
					texture = new Texture2D((int)size, (int)size, TextureFormat.R16, mipChain: false, linear: true);
					texture.wrapMode = TextureWrapMode.Clamp;
					texture.hideFlags = HideFlags.DontSave;
				}
				if (bytes != null && bytes.Length == (int)size * (int)size * 2)
				{
					texture.LoadRawTextureData(bytes);
					texture.Apply();
					texture.hideFlags = HideFlags.DontSave;
				}
				else
				{
					Fill(1f);
					Pack();
				}
			}

			public void Pack()
			{
				if (texture != null)
				{
					bytes = texture.GetRawTextureData();
				}
			}

			public void Paint(float x, float y, float brushSize, float brushFalloff, float brushFlow, float targetValue, double deltaTime)
			{
				if (texture == null)
				{
					Unpack();
				}
				int width = texture.width;
				float num = brushSize * ((float)width / 512f);
				int num2 = Mathf.RoundToInt(Mathf.Clamp(x * (float)width - num, 0f, width));
				int num3 = Mathf.RoundToInt(Mathf.Clamp(y * (float)width - num, 0f, width));
				int num4 = Mathf.RoundToInt(Mathf.Clamp(x * (float)width + num, 0f, width));
				int num5 = Mathf.RoundToInt(Mathf.Clamp(y * (float)width + num, 0f, width));
				for (int i = num2; i < num4; i++)
				{
					for (int j = num3; j < num5; j++)
					{
						float value = Vector2.Distance(new Vector2(x * (float)width, y * (float)width), new Vector2(i, j)) / num;
						value = 1f - Mathf.Clamp01(value);
						value = Mathf.Pow(value, brushFalloff);
						value *= brushFlow;
						value *= (float)deltaTime;
						Color pixel = texture.GetPixel(i, j);
						pixel.r = Mathf.Lerp(pixel.r, targetValue, value);
						texture.SetPixel(i, j, pixel);
					}
				}
				texture.Apply();
				Pack();
			}

			public void Smooth(float x, float y, float brushSize, float brushFalloff, float brushFlow, float targetValue, double deltaTime)
			{
				if (texture == null)
				{
					Unpack();
				}
				int width = texture.width;
				int num = Mathf.RoundToInt(Mathf.Clamp(x * (float)width - brushSize, 0f, width));
				int num2 = Mathf.RoundToInt(Mathf.Clamp(y * (float)width - brushSize, 0f, width));
				int num3 = Mathf.RoundToInt(Mathf.Clamp(x * (float)width + brushSize, 0f, width));
				int num4 = Mathf.RoundToInt(Mathf.Clamp(y * (float)width + brushSize, 0f, width));
				int num5 = Mathf.RoundToInt(brushSize);
				for (int i = num - num5; i < num3 + num5; i++)
				{
					for (int j = num2 - num5; j < num4 + num5; j++)
					{
						if (i < 0 || i >= width || j < 0 || j >= width)
						{
							continue;
						}
						float num6 = 0f;
						Color b = new Color(0f, 0f, 0f, 0f);
						float value = Vector2.Distance(new Vector2(x * (float)width, y * (float)width), new Vector2(i, j)) / brushSize;
						value = 1f - Mathf.Clamp01(value);
						value = Mathf.Pow(value, brushFalloff);
						value *= brushFlow;
						value *= (float)deltaTime;
						value *= 10f;
						for (int k = -3; k < 3; k++)
						{
							for (int l = -3; l < 1; l++)
							{
								int num7 = i + k;
								int num8 = j + l;
								if (num7 >= 0 && num7 < width && num8 >= 0 && num8 < width)
								{
									float value2 = Vector2.Distance(new Vector2(i, j), new Vector2(num7, num8)) / brushSize;
									float num9 = Mathf.Pow(1f - Mathf.Clamp01(value2), brushFalloff);
									b += texture.GetPixel(num7, num8) * num9;
									num6 += num9;
								}
							}
						}
						if (num6 > 0f)
						{
							b /= num6;
							b = Color.Lerp(texture.GetPixel(i, j), b, value);
							texture.SetPixel(i, j, b);
						}
					}
				}
				texture.Apply();
				Pack();
			}
		}

		public FilterType filterType;

		public Texture2D texture;

		public TextureChannel textureChannel;

		public Vector2 textureParams = new Vector2(1f, 0f);

		public Vector4 textureRotationScale = new Vector4(0f, 1f, 0f, 0f);

		public bool clampTexture;

		public SplineArea splineArea;

		public float splineAreaFalloff;

		public float splineAreaFalloffBoost;

		public PaintFalloffArea paintArea;

		public Easing easing = new Easing();

		public Noise noise = new Noise();

		public Vector2 falloffRange = new Vector2(0.8f, 1f);

		public PaintMask paintMask = new PaintMask();

		private static int _Falloff = Shader.PropertyToID("_Falloff");

		private static int _FalloffTexture = Shader.PropertyToID("_FalloffTexture");

		private static int _FalloffTextureChannel = Shader.PropertyToID("_FalloffTextureChannel");

		private static int _FalloffTextureParams = Shader.PropertyToID("_FalloffTextureParams");

		private static int _FalloffTextureRotScale = Shader.PropertyToID("_FalloffTextureRotScale");

		private static int _FalloffAreaRange = Shader.PropertyToID("_FalloffAreaRange");

		private static int _FalloffAreaBoost = Shader.PropertyToID("_FalloffAreaBoost");

		private static int _PaintAreaMatrix = Shader.PropertyToID("_PaintAreaMatrix");

		private static int _PaintAreaFalloffTexture = Shader.PropertyToID("_PaintAreaFalloffTexture");

		private static int _PaintAreaClamp = Shader.PropertyToID("_PaintAreaClamp");

		private static int _TerrainSize = Shader.PropertyToID("_TerrainSize");

		private FalloffFilter useFilter;

		public static TTarget CastEnum<TSource, TTarget>(TSource source, TTarget fallback) where TSource : Enum where TTarget : Enum
		{
			string name = Enum.GetName(typeof(TSource), source);
			if (Enum.GetNames(typeof(TTarget)).Contains(name))
			{
				return (TTarget)Enum.Parse(typeof(TTarget), name);
			}
			return fallback;
		}

		private FalloffFilter GetUseFilter(Transform transform)
		{
			if (useFilter != null)
			{
				return useFilter;
			}
			FalloffOverride componentInParent = transform.GetComponentInParent<FalloffOverride>();
			useFilter = this;
			if (componentInParent != null)
			{
				useFilter = componentInParent.filter;
			}
			return useFilter;
		}

		public void PrepareTerrain(Material mat, Terrain terrain, Transform transform, List<string> keywords)
		{
			FalloffFilter falloffFilter = GetUseFilter(transform);
			if (falloffFilter.filterType == FilterType.SplineArea && falloffFilter.splineArea != null)
			{
				keywords.Add("_USEFALLOFFSPLINEAREA");
				mat.SetTexture(_FalloffTexture, falloffFilter.splineArea.GetSDF(terrain));
				mat.SetFloat(_FalloffAreaRange, falloffFilter.splineAreaFalloff);
				mat.SetFloat(_FalloffAreaBoost, falloffFilter.splineAreaFalloffBoost);
			}
			if (falloffFilter.paintArea != null)
			{
				keywords.Add("_USEFALLOFFPAINTAREA");
				if (falloffFilter.paintArea.paintMask.texture == null)
				{
					falloffFilter.paintArea.paintMask.Unpack();
				}
				mat.SetTexture(_PaintAreaFalloffTexture, falloffFilter.paintArea.paintMask.texture);
				mat.SetMatrix(_PaintAreaMatrix, falloffFilter.paintArea.transform.worldToLocalMatrix);
				mat.SetFloat(_PaintAreaClamp, falloffFilter.paintArea.clampOutsideOfBounds ? 1f : 0f);
				mat.SetVector(_TerrainSize, terrain.terrainData.size);
			}
		}

		public void PrepareMaterial(Material mat, Transform transform, List<string> keywords)
		{
			useFilter = null;
			FalloffFilter falloffFilter = GetUseFilter(transform);
			if (falloffFilter.filterType != FilterType.Global)
			{
				falloffFilter.easing.PrepareMaterial(mat, "_FALLOFF", keywords);
				falloffFilter.noise.PrepareMaterial(mat, "_FALLOFF", "_Falloff", keywords);
			}
			if (falloffFilter.filterType == FilterType.Box)
			{
				keywords.Add("_USEFALLOFF");
				mat.SetVector(_Falloff, falloffFilter.falloffRange);
			}
			else if (falloffFilter.filterType == FilterType.Range)
			{
				keywords.Add("_USEFALLOFFRANGE");
				mat.SetVector(_Falloff, falloffFilter.falloffRange);
			}
			else if (falloffFilter.filterType == FilterType.Texture)
			{
				keywords.Add("_USEFALLOFFTEXTURE");
				mat.SetTexture(_FalloffTexture, falloffFilter.texture);
				mat.SetFloat(_FalloffTextureChannel, (float)falloffFilter.textureChannel);
				mat.SetVector(_FalloffTextureParams, falloffFilter.textureParams);
				mat.SetVector(_FalloffTextureRotScale, falloffFilter.textureRotationScale);
				mat.SetVector(_Falloff, falloffFilter.falloffRange);
				if (clampTexture)
				{
					keywords.Add("_CLAMPFALLOFFTEXTURE");
				}
			}
			else if (falloffFilter.filterType == FilterType.PaintMask)
			{
				keywords.Add("_USEFALLOFFTEXTURE");
				keywords.Add("_CLAMPFALLOFFTEXTURE");
				if (falloffFilter.paintMask.texture == null)
				{
					falloffFilter.paintMask.Unpack();
				}
				mat.SetTexture(_FalloffTexture, falloffFilter.paintMask.texture);
				mat.SetFloat(_FalloffTextureChannel, 0f);
				mat.SetVector(_FalloffTextureParams, new Vector2(1f, 0f));
				mat.SetVector(_FalloffTextureRotScale, new Vector4(0f, 1f, 0f, 0f));
				mat.SetVector(_Falloff, Vector2.one);
			}
		}
	}
}
