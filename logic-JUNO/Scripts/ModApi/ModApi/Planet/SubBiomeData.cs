using System;
using System.Xml.Linq;
using ModApi.Common;
using ModApi.Common.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class SubBiomeData
	{
		[SerializeField]
		[InspectorProperty(null, false, Label = "Sub-Biome Name", Order = 0, Tooltip = "The display name of the sub-biome. This is not required.")]
		private string _name;

		[SerializeField]
		[MinMaxValue(0f, 0.5f)]
		[InspectorProperty(null, false, Label = "Slope Range", Order = 10, Tooltip = "The slope range defines the range over which the terrain blends from using the primary sub-biome data to the slope sub-biome data. The minimum value defines where the slope sub-biome data begins to transition in and the primary sub-biome data begins to transition out. The maximum value defines where the slope sub-biome data reaches 100% strength and the primary sub-biome data is no longer used. These values are defined as the result of one minus the dot product of the normalized planet position (on a unit sphere) and the normal vector of the terrain.")]
		private MinMaxValue _slopeRange;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Primary Data", Order = 20, Tooltip = "The sub-biome data used when the terrain is relatively flat (defined by the slope range setting).")]
		private SubBiomeTerrainData _primaryData;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Slope Data", Order = 30, Tooltip = "The sub-biome data used when the terrain is relatively sloped (defined by the slope range setting).")]
		private SubBiomeTerrainData _slopeData;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public SubBiomeTerrainData PrimaryData => _primaryData;

		public SubBiomeTerrainData SlopeData => _slopeData;

		public MinMaxValue SlopeRange
		{
			get
			{
				return _slopeRange;
			}
			set
			{
				_slopeRange = value;
			}
		}

		internal float OneOverSlopeBlendRange { get; private set; }

		public SubBiomeData()
		{
			_primaryData = new SubBiomeTerrainData();
			_slopeData = new SubBiomeTerrainData();
		}

		public static SubBiomeData CreateFromXml(XElement xml)
		{
			if (xml == null)
			{
				return new SubBiomeData();
			}
			SubBiomeData subBiomeData = new SubBiomeData
			{
				_name = (string)xml.Attribute("name"),
				_slopeRange = (MinMaxValue)xml.Attribute("slopeRange"),
				_primaryData = SubBiomeTerrainData.CreateFromXml(xml.Element("PrimaryData")),
				_slopeData = SubBiomeTerrainData.CreateFromXml(xml.Element("SlopeData"))
			};
			subBiomeData.OneOverSlopeBlendRange = 1f / (subBiomeData.SlopeRange.MaxValue - subBiomeData.SlopeRange.MinValue);
			return subBiomeData;
		}

		public XElement SaveXml(XElement xml)
		{
			xml.SetAttributeValue("name", _name);
			xml.SetAttributeValue("slopeRange", _slopeRange);
			xml.Add(_primaryData.SaveXml(new XElement("PrimaryData")));
			xml.Add(_slopeData.SaveXml(new XElement("SlopeData")));
			return xml;
		}
	}
}
