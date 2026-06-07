using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Common.SimpleTypes;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.Common;
using ModApi.PlanetStudio;
using ModApi.Ui.Inspector;
using Unity.Collections;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Texture Data (Cubemap)", "A planet modifier used to read data from a cubemap texture for the celestial body and store an output value based on that data. The cubemap texture should be in horizontal format (X+, X-, Y+, Y-, Z+, Z-)")]
	public class CubemapData : VertexDataCommonPassPlanetModifier, IBrushCubemapModifier, ICustomInspectorFields
	{
		[PlanetModifierInfo("Cubemap Builder", "An internal modifier used for generating cubemaps.", IsHidden = true)]
		private class CubemapBuilderModifier : VertexDataCommonPassPlanetModifier
		{
			private int _dataIndexInput;

			private double _maxValue;

			private double _minValue;

			private double _oneOverRange;

			public Guid Id { get; private set; }

			public double LastValue { get; private set; }

			public override VertexDataType VertexDataType => VertexDataType.Both;

			public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
			{
				LastValue = (data.Data[_dataIndexInput] - _minValue) * _oneOverRange;
			}

			public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
			{
				LastValue = (data.Data[_dataIndexInput] - _minValue) * _oneOverRange;
			}

			public override void Initialize(IPlanetData planetData)
			{
				base.Initialize(planetData);
				_oneOverRange = 1.0 / (_maxValue - _minValue);
			}

			public void Initialize(CubemapData sourceModifier, Guid id)
			{
				XElement xElement = new XElement("Modifier");
				sourceModifier.SaveXml(xElement);
				xElement.SetAttributeValue("enabledWithSymbols", null);
				xElement.SetAttributeValue("disabledWithSymbols", null);
				xElement.SetAttributeValue("cubemapBuilderId", id);
				xElement.SetAttributeValue("dataIndexInput", sourceModifier._defaultMapDataIndexInput);
				RestoreXml(xElement);
			}

			public override void SaveXml(XElement xml)
			{
				base.SaveXml(xml);
				xml.SetAttributeValue("cubemapBuilderId", Id);
				xml.SetAttributeValue("minValue", _minValue);
				xml.SetAttributeValue("maxValue", _maxValue);
				xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			}

			protected override void RestoreXml(XElement xml)
			{
				base.RestoreXml(xml);
				Id = (Guid)xml.Attribute("cubemapBuilderId");
				_minValue = ((double?)xml.Attribute("minValue")).GetValueOrDefault();
				_maxValue = ((double?)xml.Attribute("maxValue")) ?? 1.0;
				_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			}
		}

		private static readonly Gradient _mapColorGradientDefault;

		private static List<FieldInfo> _defaultInspectorFields;

		private static List<FieldInfo> _defaultPlusMapInspectorFields;

		private Guid? _buildCubemapId;

		private SingleChannelByteCubemapDataSampler _cubemap;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true)]
		private int _dataIndexOutput;

		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Default Cubemap Input", true, true)]
		private int _defaultMapDataIndexInput = -1;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Interpolation Method", Order = 4, Tooltip = "The interpolation method used when sampling the texture data. Bilinear should be much faster. Bicubic should be smoother, but may not always look better than bilinear as the look can be highly dependent on the texture content and resolution. It is recommended to stick with bilinear for performance reasons unless bicubic offers a far better visual result.")]
		private TextureDataSampleMode _interpolationMethod;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Map Color Gradient", Order = 8, Tooltip = "The color gradient used in planet studio when using a brush on this cubemap.")]
		private Gradient _mapColorGradient;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Map Name", Order = 7, ForceRefresh = true, Tooltip = "The cubemap display name associated with this modifier (if any). This is required for using the brush flyout with this cubemap modifier.")]
		private string _mapName;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Max Output Value", Order = 2, Tooltip = "The output value will be linearly interpolated between the min value and max value based on the value of the texture data's pixel.This also defines the maximum value of the source data when generating a default cubemap.")]
		private double _maxValue = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Min Output Value", Order = 1, Tooltip = "The output value will be linearly interpolated between the min value and max value based on the value of the texture data's pixel.This also defines the minimum value of the source data when generating a default cubemap.")]
		private double _minValue;

		private double _range;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Texture Channel", Order = 5, Tooltip = "The texture channel from which values should be used for this texture.")]
		private TextureDataChannel _textureChannel;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Bits Per Pixel", Order = 6, Tooltip = "The number of bits per pixel used at runtime to represent the texture data. A value of 32 could be slightly more efficient on the CPU, but it can take way more memory at runtime, especially for large textures. It is recommended that this value be left at 8 bits per pixel.")]
		private TextureDataBitsPerPixel _textureChannelBitsPerPixel = TextureDataBitsPerPixel._8;

		[SerializeField]
		[TextureFileReference(TextureFileReferenceFilterType.Cubemap)]
		[InspectorProperty(null, false, Label = "Texture", Order = 0, Tooltip = "The cubemap texture.")]
		private string _textureId;

		bool IBrushCubemapModifier.ApplyNoise
		{
			get
			{
				return false;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		bool IBrushCubemapModifier.CanApplyNoise => false;

		bool IBrushCubemapModifier.CanSkipOctaves => false;

		public Gradient MapColorGradient
		{
			get
			{
				return _mapColorGradient;
			}
			set
			{
				_mapColorGradient = value;
			}
		}

		public string MapDisplayName => _mapName;

		public string MapId
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(_mapName))
				{
					return "Cubemap - " + _mapName;
				}
				return null;
			}
		}

		int IBrushCubemapModifier.NoiseOctaveSkipCount
		{
			get
			{
				return 0;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		double IBrushCubemapModifier.NoiseStrength
		{
			get
			{
				return 0.0;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override VertexDataType VertexDataType => VertexDataType.Both;

		static CubemapData()
		{
			_mapColorGradientDefault = new Gradient
			{
				colorKeys = new GradientColorKey[2]
				{
					new GradientColorKey(Color.black, 0f),
					new GradientColorKey(Color.white, 1f)
				}
			};
			Type typeFromHandle = typeof(CubemapData);
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			_defaultInspectorFields = new List<FieldInfo>
			{
				typeFromHandle.GetField("_textureId", bindingAttr),
				typeFromHandle.GetField("_minValue", bindingAttr),
				typeFromHandle.GetField("_maxValue", bindingAttr),
				typeFromHandle.GetField("_interpolationMethod", bindingAttr),
				typeFromHandle.GetField("_textureChannel", bindingAttr),
				typeFromHandle.GetField("_mapName", bindingAttr),
				typeFromHandle.GetField("_dataIndexOutput", bindingAttr)
			};
			_defaultPlusMapInspectorFields = new List<FieldInfo>(_defaultInspectorFields);
			_defaultPlusMapInspectorFields.AddRange(new FieldInfo[2]
			{
				typeFromHandle.GetField("_mapColorGradient", bindingAttr),
				typeFromHandle.GetField("_defaultMapDataIndexInput", bindingAttr)
			});
		}

		public byte[] GenerateMap(int size)
		{
			Texture2D texture2D = null;
			string.IsNullOrWhiteSpace(_textureId);
			if (texture2D == null)
			{
				if (_defaultMapDataIndexInput == -1)
				{
					texture2D = new Texture2D(size * 6, size, TextureFormat.RGBA32, mipChain: false, linear: true);
					NativeArray<Color32> rawTextureData = texture2D.GetRawTextureData<Color32>();
					byte b = (byte)Mathf.Clamp(0, 0, 255);
					Color32 value = new Color32(b, b, b, byte.MaxValue);
					int num = size * size * 6;
					for (int i = 0; i < num; i++)
					{
						rawTextureData[i] = value;
					}
				}
				else
				{
					texture2D = BuildDefaultCubemap(size);
				}
			}
			byte[] result = texture2D.EncodeToPNG();
			UnityEngine.Object.Destroy(texture2D);
			return result;
		}

		public List<FieldInfo> GetInspectorFields()
		{
			if (!string.IsNullOrWhiteSpace(_mapName))
			{
				return _defaultPlusMapInspectorFields;
			}
			return _defaultInspectorFields;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = ((_interpolationMethod != TextureDataSampleMode.Bicubic) ? (_cubemap?.SampleBilinear(input.Position) ?? 0f) : (_cubemap?.SampleBicubic(input.Position, data.CacheData.MapSampleArray) ?? 0f));
			num = num * _range + _minValue;
			data.Data[_dataIndexOutput] = num;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = ((_interpolationMethod != TextureDataSampleMode.Bicubic) ? (_cubemap?.SampleBilinear(input.Position) ?? 0f) : (_cubemap?.SampleBicubic(input.Position, data.CommonData.CacheData.MapSampleArray) ?? 0f));
			num = num * _range + _minValue;
			data.Data[_dataIndexOutput] = num;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_range = _maxValue - _minValue;
			_cubemap = InitializeCubemapSampler(MapId) ?? InitializeCubemapSampler(_textureId);
		}

		public override void SaveXml(XElement xml)
		{
			Guid? buildCubemapId = _buildCubemapId;
			_buildCubemapId = null;
			if (buildCubemapId.HasValue)
			{
				CubemapBuilderModifier cubemapBuilderModifier = base.gameObject.AddComponent<CubemapBuilderModifier>();
				try
				{
					cubemapBuilderModifier.Initialize(this, buildCubemapId.Value);
					cubemapBuilderModifier.SaveXml(xml);
					return;
				}
				finally
				{
					if (cubemapBuilderModifier != null)
					{
						UnityEngine.Object.Destroy(cubemapBuilderModifier);
					}
				}
			}
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("textureId", _textureId);
			xml.SetAttributeValue("mapName", _mapName);
			xml.SetAttributeValue("interpolationMethod", _interpolationMethod);
			xml.SetAttributeValue("textureChannel", (int)_textureChannel);
			xml.SetAttributeValue("minValue", _minValue);
			xml.SetAttributeValue("maxValue", _maxValue);
			xml.SetAttributeValue("defaultMapDataIndexInput", _defaultMapDataIndexInput);
			if (_textureChannelBitsPerPixel != TextureDataBitsPerPixel._8)
			{
				xml.SetAttributeValue("textureChannelBitsPerPixel", (int)_textureChannelBitsPerPixel);
			}
			if (_mapColorGradient != null)
			{
				xml.SetAttribute("mapColorGradient", _mapColorGradient, includeAlphaKeys: false);
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_textureId = (string)xml.Attribute("textureId");
			_mapName = (string)xml.Attribute("mapName");
			_interpolationMethod = xml.GetEnumAttribute("interpolationMethod", TextureDataSampleMode.Bilinear);
			_textureChannel = (TextureDataChannel)((int?)xml.Attribute("textureChannel")).GetValueOrDefault();
			_textureChannelBitsPerPixel = (TextureDataBitsPerPixel)(((int?)xml.Attribute("textureChannelBitsPerPixel")) ?? 8);
			_minValue = ((double?)xml.Attribute("minValue")).GetValueOrDefault();
			_maxValue = ((double?)xml.Attribute("maxValue")) ?? 1.0;
			_defaultMapDataIndexInput = (int)xml.Attribute("defaultMapDataIndexInput");
			_mapColorGradient = xml.GetGradientAttribute("mapColorGradient", includeAlphaKeys: false, _mapColorGradientDefault);
		}

		private Texture2D BuildDefaultCubemap(int size)
		{
			Texture2D texture2D = null;
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFilePath celestialFilePath = CelestialFilePath.FromRelativePath(celestialDatabase.SpecialFiles.CelestialBodyCubemapModifierTemp.RelativePath);
			Guid tempId = Guid.NewGuid();
			try
			{
				_buildCubemapId = tempId;
				OperationResult operationResult = PlanetStudioBase.Instance.CelestialBodyDesigner.SaveCelestialBody(celestialFilePath.FullPath, useFilePaths: false);
				if (!operationResult.IsSuccess)
				{
					operationResult.Log();
					throw new Exception("An error occurred building the cubemap. The save operation failed.");
				}
			}
			finally
			{
				_buildCubemapId = null;
			}
			CelestialFile file = celestialDatabase.GetFile(celestialFilePath);
			PlanetDataScript planetDataScript = null;
			TerrainGenerator terrainGenerator = null;
			try
			{
				planetDataScript = PlanetDataScript.CreateFromFile(file, new CelestialBodyPlanetarySystemDefinedData(), null, null, createTerrainData: true, applyScaleAndOverrides: true);
				planetDataScript.TerrainData.Initialize();
				terrainGenerator = new TerrainGenerator(planetDataScript.LoadTerrainData());
				CubemapBuilderModifier cubemapBuilderModifier = planetDataScript.TerrainData.Modifiers.OfType<CubemapBuilderModifier>().FirstOrDefault((CubemapBuilderModifier x) => x.Id == tempId);
				if (cubemapBuilderModifier == null)
				{
					cubemapBuilderModifier = planetDataScript.TerrainData.Biomes.SelectMany((PlanetBiome planetBiome) => planetBiome.Modifiers.OfType<CubemapBuilderModifier>()).FirstOrDefault((CubemapBuilderModifier x) => x.Id == tempId);
					if (cubemapBuilderModifier == null)
					{
						throw new Exception("An error occurred building the cubemap. The builder modifier could not be found.");
					}
				}
				int num = size * 6;
				texture2D = new Texture2D(num, size, TextureFormat.RGB24, mipChain: false, linear: true);
				NativeArray<ColorRGB24> rawTextureData = texture2D.GetRawTextureData<ColorRGB24>();
				double num2 = 2.0 / ((double)size - 1.0);
				for (int num3 = 0; num3 < 6; num3++)
				{
					CubemapFace cubemapFace = (CubemapFace)num3;
					int num4 = num3 * size;
					for (int num5 = 0; num5 < size; num5++)
					{
						double num6 = (double)num5 * num2 - 1.0;
						for (int num7 = 0; num7 < size; num7++)
						{
							double num8 = (double)num7 * num2 - 1.0;
							Vector3d vector3d = default(Vector3d);
							Vector3d normalized = (cubemapFace switch
							{
								CubemapFace.PositiveX => new Vector3d(1.0, num6, 0.0 - num8), 
								CubemapFace.NegativeX => new Vector3d(-1.0, num6, num8), 
								CubemapFace.PositiveY => new Vector3d(num8, 1.0, 0.0 - num6), 
								CubemapFace.NegativeY => new Vector3d(num8, -1.0, num6), 
								CubemapFace.PositiveZ => new Vector3d(num8, num6, 1.0), 
								CubemapFace.NegativeZ => new Vector3d(0.0 - num8, num6, -1.0), 
								_ => throw new NotSupportedException(), 
							}).normalized;
							terrainGenerator.GetVertexData(VertexDataRequestType.AllData, normalized);
							byte b = (byte)Mathf.Clamp(Mathd.RoundToInt(cubemapBuilderModifier.LastValue * 255.0), 0, 255);
							rawTextureData[num5 * num + num4 + num7] = new ColorRGB24(b, b, b);
						}
					}
				}
				return texture2D;
			}
			finally
			{
				terrainGenerator?.Dispose();
				if (planetDataScript != null && planetDataScript.gameObject != null)
				{
					UnityEngine.Object.Destroy(planetDataScript.gameObject);
				}
			}
		}

		private SingleChannelByteCubemapDataSampler InitializeCubemapSampler(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return null;
			}
			Texture2D texture2D = ((id == PlanetBrushTextureOverride.MapId) ? PlanetBrushTextureOverride.GetTexture() : null);
			if (texture2D != null)
			{
				SingleChannelByteCubemapDataSampler result = new SingleChannelByteCubemapDataSampler(texture2D, 0);
				UnityEngine.Object.Destroy(texture2D);
				return result;
			}
			CelestialFile supportFile = base.TerrainData.PlanetData.FileData.GetSupportFile(id);
			if (supportFile == null)
			{
				if (id == _textureId)
				{
					Debug.LogError(typeof(Cubemap).FullName + " modifier '" + base.Name + "' has texture id '" + id + "' defined, but the file could not be found.");
				}
				return null;
			}
			string filePath = base.TerrainData.PlanetData.GeneratedData.GetFilePath(id, createDirectory: true);
			if (File.Exists(filePath))
			{
				using (FileStream input = File.OpenRead(filePath))
				{
					using BinaryReader reader = new BinaryReader(input);
					return SingleChannelByteCubemapDataSampler.Load(reader);
				}
			}
			Texture2D texture2D2 = supportFile.LoadTexture(mipmaps: false, linear: true, markNonReadable: false);
			if (texture2D2 == null)
			{
				return null;
			}
			SingleChannelByteCubemapDataSampler singleChannelByteCubemapDataSampler = new SingleChannelByteCubemapDataSampler(texture2D2, (int)_textureChannel);
			using (FileStream output = new FileStream(filePath, FileMode.Create, FileAccess.Write))
			{
				using BinaryWriter writer = new BinaryWriter(output);
				singleChannelByteCubemapDataSampler.Save(writer);
			}
			UnityEngine.Object.Destroy(texture2D2);
			return singleChannelByteCubemapDataSampler;
		}
	}
}
