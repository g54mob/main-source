using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	public class DebugFlatten : VertexDataCommonPassPlanetModifier
	{
		public enum FlattenAxis
		{
			None = 0,
			XPositive = 1,
			XNegative = 2,
			YPositive = 3,
			YNegative = 4,
			ZPositive = 5,
			ZNegative = 6
		}

		public enum FlattenType
		{
			Height = 0,
			Color = 1,
			HeightAndColor = 2
		}

		[SerializeField]
		private FlattenAxis _axis1;

		[SerializeField]
		private FlattenAxis _axis2;

		[SerializeField]
		private FlattenAxis _axis3;

		[SerializeField]
		private FlattenType _flattenType;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[3]
		{
			VertexDataPlanetModifierPassType.Biome,
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			Vector3d position = input.Position;
			if (AxisMatch(position, _axis1) && AxisMatch(position, _axis2) && AxisMatch(position, _axis3))
			{
				if (_flattenType == FlattenType.Height)
				{
					data.Height = 0.0;
				}
				else if (_flattenType == FlattenType.Color)
				{
					data.DebugColorsOnly = true;
					data.Color = new Color(0f, 0f, 0f);
				}
				else if (_flattenType == FlattenType.HeightAndColor)
				{
					data.DebugColorsOnly = true;
					data.Height = 0.0;
					data.Color = new Color(0f, 0f, 0f);
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			Vector3d position = input.Position;
			if (AxisMatch(position, _axis1) && AxisMatch(position, _axis2) && AxisMatch(position, _axis3))
			{
				if (_flattenType == FlattenType.Height)
				{
					data.Height = 0.0;
				}
				else if (_flattenType == FlattenType.Color)
				{
					data.CommonData.DebugColorsOnly = true;
					data.Color = new Color(0f, 0f, 0f);
				}
				else if (_flattenType == FlattenType.HeightAndColor)
				{
					data.CommonData.DebugColorsOnly = true;
					data.Height = 0.0;
					data.Color = new Color(0f, 0f, 0f);
				}
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("axis1", _axis1);
			xml.SetAttributeValue("axis2", _axis2);
			xml.SetAttributeValue("axis3", _axis3);
			xml.SetAttributeValue("flattenType", _flattenType);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_axis1 = (FlattenAxis)Enum.Parse(typeof(FlattenAxis), (string)xml.Attribute("axis1"), ignoreCase: true);
			_axis2 = (FlattenAxis)Enum.Parse(typeof(FlattenAxis), (string)xml.Attribute("axis2"), ignoreCase: true);
			_axis3 = (FlattenAxis)Enum.Parse(typeof(FlattenAxis), (string)xml.Attribute("axis3"), ignoreCase: true);
			_flattenType = (FlattenType)Enum.Parse(typeof(FlattenType), (string)xml.Attribute("flattenType"), ignoreCase: true);
		}

		private bool AxisMatch(Vector3d position, FlattenAxis axis)
		{
			return axis switch
			{
				FlattenAxis.None => true, 
				FlattenAxis.XNegative => position.x <= 0.0, 
				FlattenAxis.XPositive => position.x >= 0.0, 
				FlattenAxis.YNegative => position.y <= 0.0, 
				FlattenAxis.YPositive => position.y >= 0.0, 
				FlattenAxis.ZNegative => position.z <= 0.0, 
				FlattenAxis.ZPositive => position.z >= 0.0, 
				_ => false, 
			};
		}
	}
}
