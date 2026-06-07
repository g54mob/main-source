using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Color Blend", "A planet modifier used to blend a specified color into the final color based on the blending rules configured for the modifier. Source color (specified by this modifier) is multiplied by the source blend type value, the existing destination color is multiplied by the destination blend type value, and then the two values are added together to generate the final color.")]
	public class ColorBlend : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "Color", Order = 0, Tooltip = "The color value to be blended in to the existing color.")]
		private Color _color = Color.white;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Alpha Source", true, true, Tooltip = "This is an optional input that can specify a data value to use as the source alpha channel rather than using the alpha value defined in the source color.")]
		private int _dataIndexAlpha = -1;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Destination Blend", Order = 20, Tooltip = "The blend type used for the destination color (the existing color prior to applying this modifier). This is essentially selecting the value by which the destination color will be multiplied.")]
		private ColorBlendType _destination = ColorBlendType.OneMinusSourceAlpha;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Source Blend", Order = 10, Tooltip = "The blend type used for the source color (specified in this modifier). This is essentially selecting the value by which the source color will be multiplied.")]
		private ColorBlendType _source = ColorBlendType.SourceAlpha;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (!data.DebugColorsOnly)
			{
				Color color = _color;
				if (_dataIndexAlpha >= 0)
				{
					color.a = (float)data.Data[_dataIndexAlpha];
				}
				data.Color = GetColor(data.Color, _destination, color, data.Color) + GetColor(color, _source, color, data.Color);
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			if (!data.CommonData.DebugColorsOnly)
			{
				Color color = _color;
				if (_dataIndexAlpha >= 0)
				{
					color.a = (float)data.Data[_dataIndexAlpha];
				}
				data.Color = GetColor(data.Color, _destination, color, data.Color) + GetColor(color, _source, color, data.Color);
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttribute("color", (Vector4)_color);
			xml.SetAttributeValue("source", _source);
			xml.SetAttributeValue("destination", _destination);
			xml.SetAttributeValue("dataIndexAlpha", _dataIndexAlpha);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_color = xml.GetVector4Attribute("color");
			_source = xml.GetEnumAttribute("source", ColorBlendType.One);
			_destination = xml.GetEnumAttribute("destination", ColorBlendType.One);
			_dataIndexAlpha = xml.GetIntAttribute("dataIndexAlpha", -1);
		}

		private static Color GetColor(Color color, ColorBlendType blendType, Color sourceColor, Color destinationColor)
		{
			return blendType switch
			{
				ColorBlendType.One => color, 
				ColorBlendType.Zero => Color.clear, 
				ColorBlendType.SourceColor => color * sourceColor, 
				ColorBlendType.SourceAlpha => color * sourceColor.a, 
				ColorBlendType.DestinationColor => color * destinationColor, 
				ColorBlendType.DestinationAlpha => color * destinationColor.a, 
				ColorBlendType.OneMinusSourceColor => color * (Color.white - sourceColor), 
				ColorBlendType.OneMinusSourceAlpha => color * (1f - sourceColor.a), 
				ColorBlendType.OneMinusDestinationColor => color * (Color.white - destinationColor), 
				ColorBlendType.OneMinusDestinationAlpha => color * (1f - destinationColor.a), 
				_ => throw new NotSupportedException(), 
			};
		}
	}
}
