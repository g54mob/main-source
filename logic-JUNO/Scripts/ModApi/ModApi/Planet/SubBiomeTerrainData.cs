using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.CustomData;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class SubBiomeTerrainData
	{
		[SerializeField]
		[ColorUsage(false, true)]
		[InspectorProperty(null, false, Label = "Color", Order = 0, Tooltip = "The color of the terrain for this sub-biome.")]
		private Color _color;

		[NonSerialized]
		[Range(0f, 1f)]
		[InspectorGroup("Mod Data")]
		[InspectorProperty(null, false, Label = "Mod Data", Order = 100, AllowArrayReorder = false, AllowArrayAddRemove = false, ShowArrayGroup = false, Tooltip = "Custom data that can be defined and used by mods.")]
		private CustomSubBiomeTerrainData[] _customData;

		[SerializeField]
		[Range(0f, 1f)]
		[InspectorProperty(null, false, Label = "Emissiveness", Order = 40, Tooltip = "The emissiveness of the terrain for this sub-biome.")]
		private float _emissiveness;

		[SerializeField]
		[Range(0f, 1f)]
		[InspectorProperty(null, false, Label = "Metallicness", Order = 30, Tooltip = "The metallicness of the terrain for this sub-biome.")]
		private float _metallicness;

		[SerializeField]
		[Range(0f, 1f)]
		[InspectorProperty(null, false, Label = "Smoothness", Order = 20, Tooltip = "The smoothness of the terrain for this sub-biome.")]
		private float _smoothness;

		[SerializeField]
		[Range(-1f, 7f)]
		[InspectorProperty(null, false, Label = "Texture Index", Order = 50, Tooltip = "The index of the terrain detail texture (defined in the terrain splatmap modifier) used for for this sub-biome.")]
		private int _textureIndex;

		[SerializeField]
		[Range(0f, 1f)]
		[InspectorProperty(null, false, Label = "Tire Track Strength", Order = 60, Tooltip = "The strength of the tire tracks on the terrain for this sub-biome.")]
		private float _tireTrackStrength;

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public Color ColorLinear { get; private set; }

		public CustomSubBiomeTerrainData[] CustomData => _customData ?? (_customData = CustomSubBiomeTerrainData.Create().ToArray());

		public float Emissiveness
		{
			get
			{
				return _emissiveness;
			}
			set
			{
				_emissiveness = value;
			}
		}

		public float Metallicness
		{
			get
			{
				return _metallicness;
			}
			set
			{
				_metallicness = value;
			}
		}

		public float Smoothness
		{
			get
			{
				return _smoothness;
			}
			set
			{
				_smoothness = value;
			}
		}

		public int TextureIndex
		{
			get
			{
				return _textureIndex;
			}
			set
			{
				_textureIndex = value;
			}
		}

		public float TireTrackStrength
		{
			get
			{
				return _tireTrackStrength;
			}
			set
			{
				_tireTrackStrength = value;
			}
		}

		public static SubBiomeTerrainData CreateFromXml(XElement xml)
		{
			SubBiomeTerrainData subBiomeTerrainData = new SubBiomeTerrainData
			{
				_emissiveness = ((float?)xml.Attribute("emissiveness")).GetValueOrDefault(),
				_metallicness = (float)xml.Attribute("metallicness"),
				_smoothness = (float)xml.Attribute("smoothness"),
				_textureIndex = (int)xml.Attribute("textureIndex"),
				_tireTrackStrength = (float)xml.Attribute("tireTrackStrength"),
				_color = Utilities.GetColorAttribute(xml, "color", Color.black)
			};
			subBiomeTerrainData._textureIndex = ((subBiomeTerrainData._textureIndex >= 0 && subBiomeTerrainData._textureIndex <= 7) ? subBiomeTerrainData._textureIndex : 8);
			subBiomeTerrainData.ColorLinear = subBiomeTerrainData.Color.linear;
			List<CustomSubBiomeTerrainData> list = CustomSubBiomeTerrainData.Create();
			foreach (XElement item in xml.Elements("CustomData"))
			{
				string id = (string)item.Attribute("id");
				CustomSubBiomeTerrainData customSubBiomeTerrainData = list.FirstOrDefault((CustomSubBiomeTerrainData x) => x.Id == id);
				if (customSubBiomeTerrainData != null)
				{
					customSubBiomeTerrainData.RestoreFromXml(item);
				}
				else
				{
					list.Add(new CustomSubBiomeTerrainDataUnavailable(id, item.ToString()));
				}
			}
			subBiomeTerrainData._customData = list.ToArray();
			return subBiomeTerrainData;
		}

		public XElement SaveXml(XElement xml)
		{
			xml.SetAttributeValue("emissiveness", _emissiveness);
			xml.SetAttributeValue("metallicness", _metallicness);
			xml.SetAttributeValue("smoothness", _smoothness);
			xml.SetAttributeValue("textureIndex", _textureIndex);
			xml.SetAttributeValue("tireTrackStrength", _tireTrackStrength);
			Utilities.SetColorAttribute(xml, "color", _color);
			if (_customData != null)
			{
				CustomSubBiomeTerrainData[] customData = _customData;
				foreach (CustomSubBiomeTerrainData customSubBiomeTerrainData in customData)
				{
					XElement customDataXml = new XElement("CustomData", new XAttribute("id", customSubBiomeTerrainData.Id));
					xml.Add(customSubBiomeTerrainData.SaveXml(customDataXml));
				}
			}
			return xml;
		}
	}
}
