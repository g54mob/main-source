using UnityEngine;

namespace JBooth.MicroSplat
{
	public class MicroSplatPropData : ScriptableObject
	{
		public enum PerTexVector2
		{
			SplatUVScale = 0,
			SplatUVOffset = 2
		}

		public enum PerTexColor
		{
			Tint = 4,
			SSSRTint = 72,
			TraxTint = 84,
			RimLightColor = 108,
			OutlineColor = 112
		}

		public enum PerTexFloat
		{
			InterpolationContrast = 5,
			NormalStrength = 8,
			Smoothness = 9,
			AO = 10,
			Metallic = 11,
			Brightness = 12,
			Contrast = 13,
			Porosity = 14,
			Foam = 15,
			DetailNoiseStrength = 16,
			DistanceNoiseStrength = 17,
			DistanceResample = 18,
			DisplacementMip = 19,
			GeoTexStrength = 20,
			GeoTintStrength = 21,
			GeoNormalStrength = 22,
			GlobalSmoothMetalAOStength = 23,
			DisplacementStength = 24,
			DisplacementBias = 25,
			DisplacementOffset = 26,
			GlobalEmisStength = 27,
			NoiseNormal0Strength = 28,
			NoiseNormal1Strength = 29,
			NoiseNormal2Strength = 30,
			WindParticulateStrength = 31,
			SnowAmount = 32,
			GlitterAmount = 33,
			GeoHeightFilter = 34,
			GeoHeightFilterStrength = 35,
			TriplanarMode = 36,
			TriplanarContrast = 37,
			StochatsicEnabled = 38,
			Saturation = 39,
			TextureClusterContrast = 40,
			TextureClusterBoost = 41,
			HeightOffset = 42,
			HeightContrast = 43,
			AntiTileArrayNormalStrength = 56,
			AntiTileArrayDetailStrength = 57,
			AntiTileArrayDistanceStrength = 58,
			DisplaceShaping = 59,
			UVRotation = 64,
			TriplanarRotationX = 65,
			TriplanarRotationY = 66,
			FuzzyShadingCore = 68,
			FuzzyShadingEdge = 69,
			FuzzyShadingPower = 70,
			SSSThickness = 75,
			CurveInterpolator = 76,
			TraxDigDepth = 80,
			TraxOpacity = 81,
			TraxNormalStrength = 82,
			NoiseHeightFrequency = 88,
			NoiseHeightAmplitude = 89,
			NoiseUVFrequency = 90,
			NoiseUVAmplitude = 91,
			ColorIntensity = 92,
			ScatterBlendMode = 98,
			ScatterAlphaMult = 99,
			ScatterDistanceFade = 104,
			RimPower = 105,
			RimIntensity = 111,
			OutlineIntensity = 115,
			SlopeTextureAngle = 116,
			SlopeTextureContrast = 117
		}

		public const int sMaxAttributes = 32;

		[HideInInspector]
		public Color[] values = new Color[1024];

		[HideInInspector]
		public Texture2D propTex;

		[HideInInspector]
		public AnimationCurve geoCurve = AnimationCurve.Linear(0f, 0f, 0f, 0f);

		[HideInInspector]
		public Texture2D geoTex;

		[HideInInspector]
		public AnimationCurve geoSlopeFilter = AnimationCurve.Linear(0f, 0.2f, 0.4f, 1f);

		[HideInInspector]
		public Texture2D geoSlopeTex;

		[HideInInspector]
		public AnimationCurve globalSlopeFilter = AnimationCurve.Linear(0f, 0.2f, 0.4f, 1f);

		[HideInInspector]
		public Texture2D globalSlopeTex;

		[HideInInspector]
		public int maxTextures = 32;

		private void ClearPropTex()
		{
			if (propTex != null)
			{
				Object.DestroyImmediate(propTex);
			}
		}

		public void RevisionData()
		{
			if (values.Length == 256)
			{
				ClearPropTex();
				Color[] array = new Color[maxTextures * 32];
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						array[j * maxTextures + i] = values[j * 32 + i];
					}
				}
				values = array;
			}
			else if (values.Length == 512)
			{
				ClearPropTex();
				Color[] array2 = new Color[maxTextures * 32];
				for (int k = 0; k < 32; k++)
				{
					for (int l = 0; l < 16; l++)
					{
						array2[l * maxTextures + k] = values[l * 32 + k];
					}
				}
				values = array2;
			}
			else if (values.Length == 8192 && maxTextures == 32)
			{
				ClearPropTex();
				Color[] array3 = new Color[maxTextures * 32];
				for (int m = 0; m < 32; m++)
				{
					for (int n = 0; n < 32; n++)
					{
						array3[n * maxTextures + m] = values[n * 32 + m];
					}
				}
				values = array3;
			}
			else
			{
				if (values.Length != 1024 || maxTextures != 256)
				{
					return;
				}
				ClearPropTex();
				Color[] array4 = new Color[maxTextures * 32];
				for (int num = 0; num < 32; num++)
				{
					for (int num2 = 0; num2 < 32; num2++)
					{
						array4[num2 * maxTextures + num] = values[num2 * 32 + num];
					}
				}
				for (int num3 = 32; num3 < 256; num3++)
				{
					for (int num4 = 0; num4 < 32; num4++)
					{
						array4[num4 * maxTextures + num3] = values[num4 * 32];
					}
				}
				values = array4;
			}
		}

		public Color GetValue(int x, int y)
		{
			RevisionData();
			return values[y * maxTextures + x];
		}

		public void SetValue(int x, int y, Color c)
		{
			RevisionData();
			values[y * maxTextures + x] = c;
		}

		public void SetValue(int x, int y, int channel, float value)
		{
			RevisionData();
			int num = y * maxTextures + x;
			Color color = values[num];
			color[channel] = value;
			values[num] = color;
		}

		public void SetValue(int x, int y, int channel, Vector2 value)
		{
			RevisionData();
			int num = y * maxTextures + x;
			Color color = values[num];
			if (channel == 0)
			{
				color.r = value.x;
				color.g = value.y;
			}
			else
			{
				color.b = value.x;
				color.a = value.y;
			}
			values[num] = color;
		}

		public void SetValue(int textureIndex, PerTexFloat channel, float value)
		{
			float num = (float)channel / 4f;
			int num2 = (int)num;
			int channel2 = Mathf.RoundToInt((num - (float)num2) * 4f);
			SetValue(textureIndex, num2, channel2, value);
		}

		public void SetValue(int textureIndex, PerTexColor channel, Color value)
		{
			int y = (int)((float)channel / 4f);
			SetValue(textureIndex, y, value);
		}

		public void SetValue(int textureIndex, PerTexVector2 channel, Vector2 value)
		{
			float num = (float)channel / 4f;
			int num2 = (int)num;
			int channel2 = Mathf.RoundToInt((num - (float)num2) * 4f);
			SetValue(textureIndex, num2, channel2, value);
		}

		public Color[] GetAllValues(int textureIndex)
		{
			RevisionData();
			Color[] array = new Color[32];
			for (int i = 0; i < 32; i++)
			{
				array[i] = GetValue(textureIndex, i);
			}
			return array;
		}

		public void SetAllValues(int textureIndex, Color[] c)
		{
			RevisionData();
			for (int i = 0; i < c.Length; i++)
			{
				SetValue(textureIndex, i, c[i]);
			}
		}

		public Texture2D GetTexture()
		{
			RevisionData();
			if (propTex == null)
			{
				if (SystemInfo.SupportsTextureFormat(TextureFormat.RGBAFloat))
				{
					propTex = new Texture2D(maxTextures, 32, TextureFormat.RGBAFloat, mipChain: false, linear: true);
				}
				else if (SystemInfo.SupportsTextureFormat(TextureFormat.RGBAHalf))
				{
					propTex = new Texture2D(maxTextures, 32, TextureFormat.RGBAHalf, mipChain: false, linear: true);
				}
				else
				{
					Debug.LogError("Could not create RGBAFloat or RGBAHalf format textures, per texture properties will be clamped to 0-1 range, which will break things");
					propTex = new Texture2D(maxTextures, 32, TextureFormat.RGBA32, mipChain: false, linear: true);
				}
				propTex.wrapMode = TextureWrapMode.Clamp;
				propTex.filterMode = FilterMode.Point;
				propTex.hideFlags = HideFlags.None;
			}
			propTex.SetPixels(values);
			propTex.Apply();
			return propTex;
		}

		public Texture2D GetGeoCurve()
		{
			if (geoTex == null)
			{
				geoTex = new Texture2D(256, 1, TextureFormat.RHalf, mipChain: false, linear: true);
			}
			for (int i = 0; i < 256; i++)
			{
				float num = geoCurve.Evaluate((float)i / 255f);
				geoTex.SetPixel(i, 0, new Color(num, num, num, num));
			}
			geoTex.Apply();
			return geoTex;
		}

		public Texture2D GetGeoSlopeFilter()
		{
			if (geoSlopeTex == null)
			{
				geoSlopeTex = new Texture2D(256, 1, TextureFormat.Alpha8, mipChain: false, linear: true);
			}
			for (int i = 0; i < 256; i++)
			{
				float num = geoSlopeFilter.Evaluate((float)i / 255f);
				geoSlopeTex.SetPixel(i, 0, new Color(num, num, num, num));
			}
			geoSlopeTex.Apply();
			return geoSlopeTex;
		}

		public Texture2D GetGlobalSlopeFilter()
		{
			if (globalSlopeTex == null)
			{
				globalSlopeTex = new Texture2D(256, 1, TextureFormat.Alpha8, mipChain: false, linear: true);
			}
			for (int i = 0; i < 256; i++)
			{
				float num = globalSlopeFilter.Evaluate((float)i / 255f);
				globalSlopeTex.SetPixel(i, 0, new Color(num, num, num, num));
			}
			globalSlopeTex.Apply();
			return globalSlopeTex;
		}
	}
}
