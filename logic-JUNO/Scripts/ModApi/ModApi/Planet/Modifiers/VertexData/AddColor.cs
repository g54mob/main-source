using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Add Color", "A planet modifier that adds color to the terrain or water based on 3 data input values represesnting the red, green, and blue color channels. Each individual color channel is typically in the range of 0 to 1.")]
	public class AddColor : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Blue", true, true, Order = 2, Tooltip = "The blue color channel input.")]
		private int _dataIndexBlue = -1;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Green", true, true, Order = 1, Tooltip = "The green color channel input.")]
		private int _dataIndexGreen = -1;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Red", true, true, Order = 0, Tooltip = "The red color channel input.")]
		private int _dataIndexRed = -1;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (!data.DebugColorsOnly)
			{
				if (_dataIndexRed >= 0)
				{
					data.Color.r += (float)data.Data[_dataIndexRed];
				}
				if (_dataIndexGreen >= 0)
				{
					data.Color.g += (float)data.Data[_dataIndexGreen];
				}
				if (_dataIndexBlue >= 0)
				{
					data.Color.b += (float)data.Data[_dataIndexBlue];
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			if (!data.CommonData.DebugColorsOnly)
			{
				if (_dataIndexRed >= 0)
				{
					data.Color.r += (float)data.Data[_dataIndexRed];
				}
				if (_dataIndexGreen >= 0)
				{
					data.Color.g += (float)data.Data[_dataIndexGreen];
				}
				if (_dataIndexBlue >= 0)
				{
					data.Color.b += (float)data.Data[_dataIndexBlue];
				}
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexRed", _dataIndexRed);
			xml.SetAttributeValue("dataIndexGreen", _dataIndexGreen);
			xml.SetAttributeValue("dataIndexBlue", _dataIndexBlue);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexRed = ((int?)xml.Attribute("dataIndexRed")) ?? (-1);
			_dataIndexGreen = ((int?)xml.Attribute("dataIndexGreen")) ?? (-1);
			_dataIndexBlue = ((int?)xml.Attribute("dataIndexBlue")) ?? (-1);
		}
	}
}
