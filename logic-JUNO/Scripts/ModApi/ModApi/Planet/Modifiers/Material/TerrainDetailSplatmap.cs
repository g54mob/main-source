using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Common;
using ModApi.Common.Collections;
using ModApi.Common.Extensions;
using ModApi.Common.SimpleTypes;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace ModApi.Planet.Modifiers.Material
{
	public class TerrainDetailSplatmap : TerrainMaterialModifier
	{
		public enum TerrainDetailSplatmapType
		{
			DistanceBlendedScales = 1,
			FadedMipMaps = 2
		}

		[Serializable]
		public class DistanceBlendedSplatTextures : SplatTextures, ISerializationCallbackReceiver
		{
			[SerializeField]
			private DistanceBlendedTexturesConfiguration _tilingConfiguration;

			public override TerrainDetailSplatmapType SplatmapType => TerrainDetailSplatmapType.DistanceBlendedScales;

			public DistanceBlendedTexturesConfiguration TilingConfiguration => _tilingConfiguration;

			public static DistanceBlendedSplatTextures CreateFromXml(XElement xml)
			{
				if (xml == null)
				{
					xml = new XElement("DistanceBlendedTextures");
				}
				DistanceBlendedSplatTextures distanceBlendedSplatTextures = new DistanceBlendedSplatTextures();
				distanceBlendedSplatTextures.RestoreXml(xml);
				return distanceBlendedSplatTextures;
			}

			public void Awake()
			{
				if (_tilingConfiguration == null)
				{
					_tilingConfiguration = new DistanceBlendedTexturesConfiguration();
				}
				_tilingConfiguration.InitializeLevels();
			}

			public void OnAfterDeserialize()
			{
				if (_tilingConfiguration != null)
				{
					_tilingConfiguration.OnAfterDeserialize();
				}
			}

			public void OnBeforeSerialize()
			{
			}

			public override XElement SaveXml(XElement xml)
			{
				xml = base.SaveXml(xml);
				xml.Add(_tilingConfiguration.SaveXml(new XElement("TilingConfig")));
				return xml;
			}

			protected override void RestoreXml(XElement xml)
			{
				base.RestoreXml(xml);
				_tilingConfiguration = new DistanceBlendedTexturesConfiguration();
				_tilingConfiguration.RestoreXml(xml.Element("TilingConfig"));
			}
		}

		[Serializable]
		public class GroundDetailSplatTextures : SplatTextures
		{
			[SerializeField]
			private MinMaxValue _mipmapFadeRange = new MinMaxValue(4f, 8f);

			[SerializeField]
			private float _tilingScale = 2000f;

			public MinMaxValue MipmapFadeRange
			{
				get
				{
					return _mipmapFadeRange;
				}
				set
				{
					_mipmapFadeRange = value;
				}
			}

			public override TerrainDetailSplatmapType SplatmapType => TerrainDetailSplatmapType.FadedMipMaps;

			public float TilingScale
			{
				get
				{
					return _tilingScale;
				}
				set
				{
					_tilingScale = value;
				}
			}

			public static GroundDetailSplatTextures CreateFromXml(XElement xml)
			{
				if (xml == null)
				{
					xml = new XElement("GroundDetailTextures");
				}
				GroundDetailSplatTextures groundDetailSplatTextures = new GroundDetailSplatTextures();
				groundDetailSplatTextures.RestoreXml(xml);
				return groundDetailSplatTextures;
			}

			public override XElement SaveXml(XElement xml)
			{
				xml = base.SaveXml(xml);
				xml.SetAttributeValue("mipmapFadeRange", MipmapFadeRange);
				xml.SetAttributeValue("tilingScale", TilingScale);
				return xml;
			}

			protected override void RestoreXml(XElement xml)
			{
				base.RestoreXml(xml);
				MipmapFadeRange = ((MinMaxValue?)xml.Attribute("mipmapFadeRange")) ?? new MinMaxValue(4f, 8f);
				TilingScale = ((float?)xml.Attribute("tilingScale")) ?? 1f;
			}
		}

		[Serializable]
		public abstract class SplatTextures
		{
			[Serializable]
			public class SplatTexture
			{
				[SerializeField]
				[Range(-0.5f, 0.5f)]
				private float _colorAdjustment;

				[SerializeField]
				private float _colorStrength = 1f;

				[SerializeField]
				private bool _convertToGrayscale;

				[SerializeField]
				private Texture2D _texture;

				public float ColorAdjustment
				{
					get
					{
						return _colorAdjustment;
					}
					set
					{
						_colorAdjustment = value;
					}
				}

				public float ColorStrength
				{
					get
					{
						return _colorStrength;
					}
					set
					{
						_colorStrength = value;
					}
				}

				public bool ConvertToGrayscale
				{
					get
					{
						return _convertToGrayscale;
					}
					set
					{
						_convertToGrayscale = value;
					}
				}

				public string Path { get; set; }

				public Texture2D Texture
				{
					get
					{
						return _texture;
					}
					set
					{
						_texture = value;
					}
				}

				public static SplatTexture CreateFromXml(XElement xml)
				{
					return new SplatTexture
					{
						Path = (string)xml.Attribute("path"),
						ConvertToGrayscale = ((bool?)xml.Attribute("convertToGrayscale") == true),
						ColorAdjustment = ((float?)xml.Attribute("colorAdjustment")).GetValueOrDefault(),
						ColorStrength = (((float?)xml.Attribute("colorStrength")) ?? 1f)
					};
				}

				public XElement CreateXml()
				{
					return new XElement("Texture", string.IsNullOrWhiteSpace(Path) ? null : new XAttribute("path", Path), (!_convertToGrayscale) ? null : new XAttribute("convertToGrayscale", _convertToGrayscale), (_colorAdjustment == 0f) ? null : new XAttribute("colorAdjustment", _colorAdjustment), (_colorStrength == 1f) ? null : new XAttribute("colorStrength", _colorStrength));
				}
			}

			[SerializeField]
			private List<SplatTexture> _textures;

			public int Count => _textures.Count;

			public abstract TerrainDetailSplatmapType SplatmapType { get; }

			public List<SplatTexture> Textures
			{
				get
				{
					return _textures;
				}
				set
				{
					_textures = value;
				}
			}

			public bool TexturesLoaded { get; private set; }

			public void LoadTextures(PlanetTerrainDataScript terrainData)
			{
				if (TexturesLoaded)
				{
					return;
				}
				foreach (SplatTexture texture in Textures)
				{
					try
					{
						if (string.IsNullOrWhiteSpace(texture.Path))
						{
							texture.Texture = null;
							goto IL_0089;
						}
						CelestialFile supportFile = terrainData.PlanetData.FileData.GetSupportFile(texture.Path);
						if (supportFile == null)
						{
							Debug.LogError("Unable to find terrain texture with id '" + texture.Path + "'");
							continue;
						}
						texture.Texture = supportFile.LoadTexture(mipmaps: false, linear: false, markNonReadable: false);
						texture.Texture.wrapMode = TextureWrapMode.Clamp;
						goto IL_0089;
						IL_0089:
						_ = texture.Texture == null;
					}
					catch (Exception exception)
					{
						texture.Texture = null;
						Debug.LogException(exception);
					}
				}
				TexturesLoaded = true;
			}

			public virtual XElement SaveXml(XElement xml)
			{
				if (_textures != null)
				{
					foreach (SplatTexture texture in _textures)
					{
						if (texture != null)
						{
							xml.Add(texture.CreateXml());
						}
					}
				}
				return xml;
			}

			public void UnloadTextures()
			{
				TexturesLoaded = false;
				foreach (SplatTexture texture in Textures)
				{
					if (texture.Texture != null)
					{
						UnityEngine.Object.Destroy(texture.Texture);
						texture.Texture = null;
					}
				}
			}

			protected virtual void RestoreXml(XElement xml)
			{
				Textures = new List<SplatTexture>();
				foreach (XElement item in xml.Elements("Texture"))
				{
					Textures.Add(SplatTexture.CreateFromXml(item));
				}
			}
		}

		private Texture2D _distanceBlendedTexture1;

		private Texture2D _distanceBlendedTexture2;

		[SerializeField]
		private DistanceBlendedSplatTextures _distanceBlendedTextures;

		private Texture2D _groundDetailTexture1;

		private Texture2D _groundDetailTexture2;

		[SerializeField]
		private GroundDetailSplatTextures _groundDetailTextures;

		[SerializeField]
		[Range(0f, 1f)]
		private float _lightingFresnelBias;

		private bool _shaderDistanceBlendDataInitialized;

		private bool _splatTexturesInitialized;

		private bool _useDistanceBlendedSplatmaps;

		private bool _useGroundDetailSplatmaps;

		public DistanceBlendedSplatTextures DistanceBlendedTextures => _distanceBlendedTextures;

		public static void GenerateFadedMipMaps(SplatTextures splatTextures, Texture2D tex, Color[] pixels, bool markAsNoLongerReadable)
		{
			int width = tex.width;
			int height = tex.height;
			Color[][] array = new Color[tex.mipmapCount][];
			array[0] = pixels;
			int num = height;
			int num2 = width;
			for (int i = 1; i < tex.mipmapCount; i++)
			{
				int num3 = ((num2 >= 2) ? (num2 / 2) : num2);
				int num4 = ((num >= 2) ? (num / 2) : num);
				array[i] = new Color[num3 * num4];
				int num5 = 0;
				for (int j = 0; j < num; j += 2)
				{
					for (int k = 0; k < num2; k += 2)
					{
						int num6 = i - 1;
						int num7 = j * num2 + k;
						int num8 = 1;
						Color color = array[num6][num7];
						if (num2 > 1)
						{
							num8++;
							color += array[num6][num7 + 1];
						}
						if (num > 1)
						{
							num8++;
							color += array[num6][num7 + num2];
						}
						if (num2 > 1 && num > 1)
						{
							num8++;
							color += array[num6][num7 + num2 + 1];
						}
						array[i][num5] = color / num8;
						num5++;
					}
				}
				num2 = num3;
				num = num4;
			}
			Color color2 = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			MinMaxValue mipmapFadeRange = ((GroundDetailSplatTextures)splatTextures).MipmapFadeRange;
			float minValue = mipmapFadeRange.MinValue;
			float maxValue = mipmapFadeRange.MaxValue;
			for (int l = 1; l < tex.mipmapCount; l++)
			{
				if ((float)l - minValue > 0f)
				{
					if ((float)l - maxValue >= 0f)
					{
						for (int m = 0; m < array[l].Length; m++)
						{
							array[l][m] = color2;
						}
					}
					else
					{
						float t = Mathf.Clamp01(((float)l - minValue) / (maxValue - minValue));
						for (int n = 0; n < array[l].Length; n++)
						{
							array[l][n] = Color.Lerp(array[l][n], color2, t);
						}
					}
				}
				tex.SetPixels(array[l], l);
			}
			tex.Apply(updateMipmaps: false, markAsNoLongerReadable);
		}

		public override QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			QuadMeshDataFlags quadMeshDataFlags = QuadMeshDataFlags.Color | QuadMeshDataFlags.UV4;
			if (_useDistanceBlendedSplatmaps && _distanceBlendedTextures.Count > 0)
			{
				quadMeshDataFlags |= QuadMeshDataFlags.UV;
				quadMeshDataFlags |= QuadMeshDataFlags.UV2;
				if (_distanceBlendedTextures.Count > 4)
				{
					quadMeshDataFlags |= QuadMeshDataFlags.UV3;
				}
			}
			if (_useGroundDetailSplatmaps && _groundDetailTextures.Count > 0)
			{
				quadMeshDataFlags |= QuadMeshDataFlags.UV;
				quadMeshDataFlags |= QuadMeshDataFlags.UV2;
				if (_groundDetailTextures.Count > 4)
				{
					quadMeshDataFlags |= QuadMeshDataFlags.UV3;
				}
			}
			return quadMeshDataFlags;
		}

		public override List<string> GetSupportFileReferences()
		{
			List<string> list = DistanceBlendedTextures?.Textures?.Select((SplatTextures.SplatTexture x) => x.Path).ToList() ?? new List<string>();
			List<string> list2 = _groundDetailTextures?.Textures?.Select((SplatTextures.SplatTexture x) => x.Path).ToList();
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(list2);
			}
			return list;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			IGameQualitySettings qualitySettings = ModApi.Common.Game.Instance.QualitySettings;
			UpdateQualitySettings(qualitySettings.Terrain);
		}

		public override void InitializeQuadSphere(IQuadSphere quadSphere)
		{
			base.InitializeQuadSphere(quadSphere);
			TerrainQualitySettings terrain = ModApi.Common.Game.Instance.QualitySettings.Terrain;
			terrain.Changed += OnTerrainQualityChanged;
			if (_lightingFresnelBias != 0f)
			{
				base.SharedMaterial.SetFloat("_lightingFresnelBias", _lightingFresnelBias);
			}
			ApplyQualitySettings(terrain);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			if (_lightingFresnelBias != 0f)
			{
				xml.SetAttributeValue("fresnelBias", _lightingFresnelBias);
			}
			xml.Add(_distanceBlendedTextures.SaveXml(new XElement("DistanceBlendedTextures")));
			xml.Add(_groundDetailTextures.SaveXml(new XElement("GroundDetailTextures")));
		}

		public void UpdateTilingConfiguration(DistanceBlendedTexturesConfiguration tilingConfiguration)
		{
			_distanceBlendedTextures.TilingConfiguration.CopyFrom(tilingConfiguration);
			UpdateShaderDistanceBlendData();
		}

		protected override void Awake()
		{
			if (_distanceBlendedTextures != null)
			{
				_distanceBlendedTextures.Awake();
			}
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (focus && _shaderDistanceBlendDataInitialized)
			{
				UpdateShaderDistanceBlendData();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ModApi.Common.Game.Instance.QualitySettings.Terrain.Changed -= OnTerrainQualityChanged;
			_distanceBlendedTextures?.UnloadTextures();
			_groundDetailTextures?.UnloadTextures();
			if (_distanceBlendedTexture1 != null)
			{
				UnityEngine.Object.Destroy(_distanceBlendedTexture1);
				_distanceBlendedTexture1 = null;
			}
			if (_distanceBlendedTexture2 != null)
			{
				UnityEngine.Object.Destroy(_distanceBlendedTexture2);
				_distanceBlendedTexture2 = null;
			}
			if (_groundDetailTexture1 != null)
			{
				UnityEngine.Object.Destroy(_groundDetailTexture1);
				_groundDetailTexture1 = null;
			}
			if (_groundDetailTexture2 != null)
			{
				UnityEngine.Object.Destroy(_groundDetailTexture2);
				_groundDetailTexture2 = null;
			}
		}

		protected virtual void OnValidate()
		{
			if (_shaderDistanceBlendDataInitialized)
			{
				UpdateShaderDistanceBlendData();
			}
		}

		protected virtual void Reset()
		{
			if (_distanceBlendedTextures == null)
			{
				_distanceBlendedTextures = new DistanceBlendedSplatTextures();
			}
			_distanceBlendedTextures.Awake();
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_lightingFresnelBias = xml.GetFloatAttribute("fresnelBias");
			_distanceBlendedTextures = DistanceBlendedSplatTextures.CreateFromXml(xml.Element("DistanceBlendedTextures") ?? xml.Element("Textures"));
			_groundDetailTextures = GroundDetailSplatTextures.CreateFromXml(xml.Element("GroundDetailTextures"));
		}

		private void ApplyQualitySettings(TerrainQualitySettings quality)
		{
			if (quality.Textures.Value == TerrainQualitySettings.TextureQuality.Off)
			{
				base.SharedMaterial.DisableKeyword("DETAIL_SPLATMAP_4_TEXTURES");
				base.SharedMaterial.DisableKeyword("DETAIL_SPLATMAP_8_TEXTURES");
				base.SharedMaterial.DisableKeyword("GROUND_DETAIL_SPLATMAP_4_TEXTURES");
				base.SharedMaterial.DisableKeyword("GROUND_DETAIL_SPLATMAP_8_TEXTURES");
				return;
			}
			if (_useDistanceBlendedSplatmaps)
			{
				InitializeSplatTextures();
				if (_distanceBlendedTexture1 != null)
				{
					base.SharedMaterial.SetTexture("_detailSplatTexture1", _distanceBlendedTexture1);
					UpdateShaderDistanceBlendData();
					if (_distanceBlendedTexture2 != null)
					{
						base.SharedMaterial.EnableKeyword("DETAIL_SPLATMAP_8_TEXTURES");
						base.SharedMaterial.SetTexture("_detailSplatTexture2", _distanceBlendedTexture2);
					}
					else
					{
						base.SharedMaterial.EnableKeyword("DETAIL_SPLATMAP_4_TEXTURES");
					}
					if (quality.Textures.Value == TerrainQualitySettings.TextureQuality.BlendedFast)
					{
						base.SharedMaterial.EnableKeyword("DISTANCE_BLENDED_TEXTURES_FAST");
					}
					else
					{
						base.SharedMaterial.DisableKeyword("DISTANCE_BLENDED_TEXTURES_FAST");
					}
				}
			}
			if (_useGroundDetailSplatmaps && _groundDetailTexture1 != null)
			{
				base.SharedMaterial.SetTexture("_groundDetailSplatTexture1", _groundDetailTexture1);
				base.SharedMaterial.SetFloat("_groundDetailSplatTilingScale", _groundDetailTextures.TilingScale * base.PlanetScale);
				if (_groundDetailTexture2 != null)
				{
					base.SharedMaterial.EnableKeyword("GROUND_DETAIL_SPLATMAP_8_TEXTURES");
					base.SharedMaterial.SetTexture("_groundDetailSplatTexture2", _groundDetailTexture2);
				}
				else
				{
					base.SharedMaterial.EnableKeyword("GROUND_DETAIL_SPLATMAP_4_TEXTURES");
				}
			}
		}

		private Texture2D CreateSplatTexture(SplatTextures splatTextures, int index)
		{
			SplatTextures.SplatTexture[] array = new SplatTextures.SplatTexture[4];
			List<SplatTextures.SplatTexture> textures = splatTextures.Textures;
			for (int i = 0; i < 4; i++)
			{
				int num = index * 4 + i;
				array[i] = ((textures.Count <= num) ? null : textures[num]);
			}
			int num2 = 512;
			int num3 = 512;
			for (int j = 0; j < 4; j++)
			{
				Texture2D texture2D = array[j]?.Texture;
				if (texture2D != null && texture2D.width == texture2D.height)
				{
					num2 = System.Math.Max(num2, texture2D.width);
					num3 = System.Math.Max(num3, texture2D.height);
				}
			}
			Texture2D texture2D2 = new Texture2D(num2, num3, TextureFormat.RGBA32, mipChain: true, linear: true);
			Color[] pixels = texture2D2.GetPixels();
			for (int k = 0; k < 4; k++)
			{
				SplatTextures.SplatTexture splatTexture = array[k];
				Texture2D texture2D3 = splatTexture?.Texture;
				if (texture2D3 == null)
				{
					for (int l = 0; l < pixels.Length; l++)
					{
						pixels[l][k] = 0.5f;
					}
					continue;
				}
				int num4 = 0;
				float num5 = 1f / (float)num2;
				float num6 = 1f / (float)num3;
				bool flag = texture2D3.width != num2 || texture2D3.height != num3;
				if (splatTexture.ConvertToGrayscale)
				{
					if (splatTexture.ColorAdjustment == 0f)
					{
						if (flag)
						{
							for (int m = 0; m < num3; m++)
							{
								float v = (float)m * num6;
								for (int n = 0; n < num2; n++)
								{
									float u = (float)n * num5;
									Color pixelBilinear = texture2D3.GetPixelBilinear(u, v);
									pixels[num4++][k] = pixelBilinear.r * 0.299f + pixelBilinear.g * 0.587f + pixelBilinear.b * 0.114f;
								}
							}
						}
						else
						{
							RawTextureDataWrapperARGB32 rawTextureDataWrapperARGB = RawTextureDataWrapperARGB32.Create(texture2D3);
							for (int num7 = 0; num7 < pixels.Length; num7++)
							{
								ColorARGB32 colorARGB = rawTextureDataWrapperARGB[num7];
								pixels[num7][k] = ((float)(int)colorARGB.r * 0.299f + (float)(int)colorARGB.g * 0.587f + (float)(int)colorARGB.b * 0.114f) * 0.003921569f;
							}
						}
					}
					else if (flag)
					{
						for (int num8 = 0; num8 < num3; num8++)
						{
							float v2 = (float)num8 * num6;
							for (int num9 = 0; num9 < num2; num9++)
							{
								float u2 = (float)num9 * num5;
								Color pixelBilinear2 = texture2D3.GetPixelBilinear(u2, v2);
								pixels[num4++][k] = pixelBilinear2.r * 0.299f + pixelBilinear2.g * 0.587f + pixelBilinear2.b * 0.114f + splatTexture.ColorAdjustment;
							}
						}
					}
					else
					{
						RawTextureDataWrapperARGB32 rawTextureDataWrapperARGB2 = RawTextureDataWrapperARGB32.Create(texture2D3);
						for (int num10 = 0; num10 < pixels.Length; num10++)
						{
							ColorARGB32 colorARGB2 = rawTextureDataWrapperARGB2[num10];
							pixels[num10][k] = ((float)(int)colorARGB2.r * 0.299f + (float)(int)colorARGB2.g * 0.587f + (float)(int)colorARGB2.b * 0.114f) * 0.003921569f + splatTexture.ColorAdjustment;
						}
					}
				}
				else if (splatTexture.ColorAdjustment == 0f)
				{
					if (flag)
					{
						for (int num11 = 0; num11 < num3; num11++)
						{
							float v3 = (float)num11 * num6;
							for (int num12 = 0; num12 < num2; num12++)
							{
								float u3 = (float)num12 * num5;
								Color pixelBilinear3 = texture2D3.GetPixelBilinear(u3, v3);
								pixels[num4++][k] = pixelBilinear3.r;
							}
						}
					}
					else
					{
						RawTextureDataWrapperARGB32 rawTextureDataWrapperARGB3 = RawTextureDataWrapperARGB32.Create(texture2D3);
						for (int num13 = 0; num13 < pixels.Length; num13++)
						{
							pixels[num13][k] = (float)(int)rawTextureDataWrapperARGB3.Red(num13) * 0.003921569f;
						}
					}
				}
				else if (flag)
				{
					for (int num14 = 0; num14 < num3; num14++)
					{
						float v4 = (float)num14 * num6;
						for (int num15 = 0; num15 < num2; num15++)
						{
							float u4 = (float)num15 * num5;
							Color pixelBilinear4 = texture2D3.GetPixelBilinear(u4, v4);
							pixels[num4++][k] = pixelBilinear4.r + splatTexture.ColorAdjustment;
						}
					}
				}
				else
				{
					RawTextureDataWrapperARGB32 rawTextureDataWrapperARGB4 = RawTextureDataWrapperARGB32.Create(texture2D3);
					for (int num16 = 0; num16 < pixels.Length; num16++)
					{
						pixels[num16][k] = (float)(int)rawTextureDataWrapperARGB4.Red(num16) * 0.003921569f + splatTexture.ColorAdjustment;
					}
				}
				if (splatTexture.ColorStrength != 1f)
				{
					for (int num17 = 0; num17 < pixels.Length; num17++)
					{
						pixels[num17][k] = 0.5f + (pixels[num17][k] - 0.5f) * splatTexture.ColorStrength;
					}
				}
			}
			texture2D2.SetPixels(pixels, 0);
			if (splatTextures.SplatmapType == TerrainDetailSplatmapType.FadedMipMaps)
			{
				GenerateFadedMipMaps(splatTextures, texture2D2, pixels, markAsNoLongerReadable: false);
			}
			else
			{
				texture2D2.Apply(updateMipmaps: true);
			}
			return texture2D2;
		}

		private Texture2D InitializeSplatTexture(SplatTextures splatTextures, string name, int index)
		{
			CelestialDatabaseGeneratedData generatedData = base.TerrainData.PlanetData.GeneratedData;
			bool num = ModApi.Common.Game.Instance.SceneManager.CurrentScene == "PlanetStudio";
			Texture2D texture2D = null;
			if (num || !generatedData.FileExists(name))
			{
				splatTextures.LoadTextures(base.TerrainData);
				texture2D = CreateSplatTexture(splatTextures, index);
				generatedData.SaveTextureAsPng(name, texture2D);
			}
			else
			{
				bool flag = splatTextures.SplatmapType == TerrainDetailSplatmapType.FadedMipMaps;
				texture2D = generatedData.LoadTexture(name, mipmaps: true, linear: true, !flag);
				if (flag)
				{
					GenerateFadedMipMaps(splatTextures, texture2D, texture2D.GetPixels(), markAsNoLongerReadable: true);
				}
			}
			texture2D.name = name;
			return texture2D;
		}

		private void InitializeSplatTextures()
		{
			if (_splatTexturesInitialized)
			{
				return;
			}
			_splatTexturesInitialized = true;
			string text = base.TerrainData.PlanetData.Name;
			if (_distanceBlendedTextures.Count > 0)
			{
				_distanceBlendedTexture1 = InitializeSplatTexture(_distanceBlendedTextures, text + "-DetailSplatMap-1.png", 0);
				if (_distanceBlendedTextures.Count > 4)
				{
					_distanceBlendedTexture2 = InitializeSplatTexture(_distanceBlendedTextures, text + "-DetailSplatMap-2.png", 1);
				}
			}
			if (_groundDetailTextures.Count > 0)
			{
				_groundDetailTexture1 = InitializeSplatTexture(_groundDetailTextures, text + "-GroundDetailSplatMap-1.png", 0);
				if (_groundDetailTextures.Count > 4)
				{
					_groundDetailTexture2 = InitializeSplatTexture(_groundDetailTextures, text + "-GroundDetailSplatMap-2.png", 1);
				}
			}
			if (_distanceBlendedTextures.TexturesLoaded && !ModApi.Common.Game.Instance.Device.IsUnityEditor)
			{
				_distanceBlendedTextures.UnloadTextures();
			}
			if (_groundDetailTextures.TexturesLoaded && !ModApi.Common.Game.Instance.Device.IsUnityEditor)
			{
				_groundDetailTextures.UnloadTextures();
			}
		}

		private void OnTerrainQualityChanged(object sender, SettingsChangedEventArgs<TerrainQualitySettings> e)
		{
			UpdateQualitySettings(e.Category);
			ApplyQualitySettings(e.Category);
		}

		private void UpdateQualitySettings(TerrainQualitySettings quality)
		{
			_useDistanceBlendedSplatmaps = quality.Textures.Value != TerrainQualitySettings.TextureQuality.Off;
			_useGroundDetailSplatmaps = quality.Textures.Value != TerrainQualitySettings.TextureQuality.Off;
		}

		private void UpdateShaderDistanceBlendData()
		{
			base.SharedMaterial.SetVectorArray("_distanceBlendLookup", _distanceBlendedTextures.TilingConfiguration.GetShaderData(base.PlanetScale));
			_shaderDistanceBlendDataInitialized = true;
		}
	}
}
