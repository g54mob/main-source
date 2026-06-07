using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.Common;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Test Modifier - Do Not Use", IsHidden = true)]
	public class LatLong8TextureData : VertexDataCommonPassPlanetModifier
	{
		[Serializable]
		private class TextureDataItem
		{
			[TextureFileReference]
			[InspectorProperty(null, false, Label = "Texture", Order = 0, Tooltip = "The texture.")]
			public string Path;

			[NonSerialized]
			public Texture2D Texture;

			public TextureDataItem()
			{
			}

			public TextureDataItem(XElement xml)
			{
				RestoreXml(xml);
			}

			public XElement CreateXml()
			{
				return new XElement("Texture", string.IsNullOrWhiteSpace(Path) ? null : new XAttribute("path", Path));
			}

			public void LoadTexture(PlanetTerrainDataScript terrainData)
			{
				if (Texture != null)
				{
					return;
				}
				try
				{
					Texture = null;
					if (!string.IsNullOrWhiteSpace(Path))
					{
						CelestialFile supportFile = terrainData.PlanetData.FileData.GetSupportFile(Path);
						Texture = supportFile.LoadTexture(mipmaps: false, linear: true, markNonReadable: false);
					}
				}
				catch (Exception exception)
				{
					Texture = null;
					Debug.LogException(exception);
				}
			}

			public void RestoreXml(XElement xml)
			{
				Path = (string)xml.Attribute("path");
			}

			public void UnloadTexture()
			{
				if (Texture != null)
				{
					UnityEngine.Object.Destroy(Texture);
					Texture = null;
				}
			}
		}

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true)]
		private int _dataIndexOutput;

		[SerializeField]
		[Range(0f, 3f)]
		private int _textureChannel;

		[SerializeField]
		private int _textureChannelBitsPerPixel = 8;

		[SerializeField]
		private TextureDataItem[] _textures = new TextureDataItem[8];

		private ISingleChannelTextureDataSampler[] _textureSamplers;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			float num = 0f;
			float num2 = 0f;
			ISingleChannelTextureDataSampler singleChannelTextureDataSampler = null;
			Vector3d position = input.Position;
			double num3 = System.Math.Atan2(position.z, position.x);
			double num4 = System.Math.Acos(position.y);
			if (num3 < -System.Math.PI / 2.0)
			{
				num = (float)((num3 + System.Math.PI) / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[0];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[4];
				}
			}
			else if (num3 < 0.0)
			{
				num = (float)((num3 + System.Math.PI / 2.0) / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[1];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[5];
				}
			}
			else if (num3 < System.Math.PI / 2.0)
			{
				num = (float)(num3 / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[2];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[6];
				}
			}
			else
			{
				num = (float)((num3 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[3];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[7];
				}
			}
			float[][] mapSampleArray = data.CacheData.MapSampleArray;
			float num5 = singleChannelTextureDataSampler?.SampleBicubic(num, num2, mapSampleArray) ?? 0f;
			data.Data[_dataIndexOutput] = num5;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			float num = 0f;
			float num2 = 0f;
			ISingleChannelTextureDataSampler singleChannelTextureDataSampler = null;
			Vector3d position = input.Position;
			double num3 = System.Math.Atan2(position.z, position.x);
			double num4 = System.Math.Acos(position.y);
			if (num3 < -System.Math.PI / 2.0)
			{
				num = (float)((num3 + System.Math.PI) / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[0];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[4];
				}
			}
			else if (num3 < 0.0)
			{
				num = (float)((num3 + System.Math.PI / 2.0) / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[1];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[5];
				}
			}
			else if (num3 < System.Math.PI / 2.0)
			{
				num = (float)(num3 / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[2];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[6];
				}
			}
			else
			{
				num = (float)((num3 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
				if (num4 <= System.Math.PI / 2.0)
				{
					num2 = 1f - (float)(num4 / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[3];
				}
				else
				{
					num2 = 1f - (float)((num4 - System.Math.PI / 2.0) / (System.Math.PI / 2.0));
					singleChannelTextureDataSampler = _textureSamplers[7];
				}
			}
			float[][] mapSampleArray = data.CommonData.CacheData.MapSampleArray;
			float num5 = singleChannelTextureDataSampler?.SampleBicubic(num, num2, mapSampleArray) ?? 0f;
			data.Data[_dataIndexOutput] = num5;
		}

		public override void Initialize(IPlanetData planetData)
		{
			InitializeTextureSamplers();
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("textureChannel", _textureChannel);
			if (_textureChannelBitsPerPixel != 8)
			{
				xml.SetAttributeValue("textureChannelBitsPerPixel", _textureChannelBitsPerPixel);
			}
			XElement xElement = new XElement("Textures");
			if (_textures != null)
			{
				TextureDataItem[] textures = _textures;
				foreach (TextureDataItem textureDataItem in textures)
				{
					xElement.Add(textureDataItem.CreateXml());
				}
			}
			xml.Add(xElement);
		}

		protected virtual void OnValidate()
		{
			if (_textures == null)
			{
				_textures = new TextureDataItem[8];
			}
			else if (_textures.Length != 8)
			{
				Array.Resize(ref _textures, 8);
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_textureChannel = ((int?)xml.Attribute("textureChannel")).GetValueOrDefault();
			_textureChannelBitsPerPixel = ((int?)xml.Attribute("textureChannelBitsPerPixel")) ?? 8;
			List<TextureDataItem> list = new List<TextureDataItem>();
			foreach (XElement item in xml.Elements("Textures").Elements("Texture"))
			{
				list.Add(new TextureDataItem(item));
			}
			_textures = list.ToArray();
		}

		private ISingleChannelTextureDataSampler CreateSamplerFromTexture(TextureDataItem textureDataItem)
		{
			ISingleChannelTextureDataSampler result = null;
			bool num = textureDataItem.Texture != null;
			if (!num)
			{
				textureDataItem.LoadTexture(base.TerrainData);
			}
			if (textureDataItem.Texture != null)
			{
				ISingleChannelTextureDataSampler singleChannelTextureDataSampler2;
				if (_textureChannelBitsPerPixel > 8)
				{
					ISingleChannelTextureDataSampler singleChannelTextureDataSampler = new SingleChannelFloatTextureDataSampler(textureDataItem.Texture, _textureChannel);
					singleChannelTextureDataSampler2 = singleChannelTextureDataSampler;
				}
				else
				{
					ISingleChannelTextureDataSampler singleChannelTextureDataSampler = new SingleChannelByteTextureDataSampler(textureDataItem.Texture, _textureChannel);
					singleChannelTextureDataSampler2 = singleChannelTextureDataSampler;
				}
				result = singleChannelTextureDataSampler2;
			}
			if (!num)
			{
				textureDataItem.UnloadTexture();
			}
			return result;
		}

		private ISingleChannelTextureDataSampler InitializeTextureSampler(TextureDataItem textureDataItem)
		{
			if (textureDataItem == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(textureDataItem.Path))
			{
				return null;
			}
			CelestialFile supportFile = base.TerrainData.PlanetData.FileData.GetSupportFile(textureDataItem.Path);
			string fileName = $"LatLong8TextureData_{supportFile.Id}";
			string filePath = base.TerrainData.PlanetData.GeneratedData.GetFilePath(fileName, createDirectory: true);
			ISingleChannelTextureDataSampler singleChannelTextureDataSampler = null;
			if (!File.Exists(filePath))
			{
				singleChannelTextureDataSampler = CreateSamplerFromTexture(textureDataItem);
				using FileStream output = new FileStream(filePath, FileMode.Create);
				using BinaryWriter writer = new BinaryWriter(output);
				singleChannelTextureDataSampler.Save(writer);
			}
			else
			{
				using FileStream input = new FileStream(filePath, FileMode.Open);
				using BinaryReader reader = new BinaryReader(input);
				ISingleChannelTextureDataSampler singleChannelTextureDataSampler3;
				if (_textureChannelBitsPerPixel > 8)
				{
					ISingleChannelTextureDataSampler singleChannelTextureDataSampler2 = SingleChannelFloatTextureDataSampler.Load(reader);
					singleChannelTextureDataSampler3 = singleChannelTextureDataSampler2;
				}
				else
				{
					ISingleChannelTextureDataSampler singleChannelTextureDataSampler2 = SingleChannelByteTextureDataSampler.Load(reader);
					singleChannelTextureDataSampler3 = singleChannelTextureDataSampler2;
				}
				singleChannelTextureDataSampler = singleChannelTextureDataSampler3;
			}
			return singleChannelTextureDataSampler;
		}

		private void InitializeTextureSamplers()
		{
			if (_textures == null || _textures.Length != 8)
			{
				Debug.LogError("Texture array for " + typeof(LatLong8TextureData).FullName + " modifier '" + base.Name + "' is invalid. Expected 8 textures.");
			}
			ISingleChannelTextureDataSampler[] textureSamplers = new SingleChannelFloatTextureDataSampler[8];
			_textureSamplers = textureSamplers;
			for (int i = 0; i < 8; i++)
			{
				_textureSamplers[i] = InitializeTextureSampler(_textures[i]);
			}
			if (_textureSamplers.Any((ISingleChannelTextureDataSampler x) => x == null))
			{
				Debug.LogError("One or more textures could not be loaded for " + typeof(LatLong8TextureData).FullName + " modifier '" + base.Name + "'.");
			}
		}
	}
}
