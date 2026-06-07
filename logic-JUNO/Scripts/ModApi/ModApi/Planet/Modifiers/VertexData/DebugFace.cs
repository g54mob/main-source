using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Debug Visualize (Cubemap)", "A planet modifier used in debugging that helps visualize the 6 faces of the planet cubemap.")]
	public class DebugFace : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "X Negative", Order = 0, Tooltip = "The debug color used to identify the X-negative face of the cubemap.")]
		private Color _colorXNegative = new Color(1f, 0f, 0f, 1f);

		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "X Positive", Order = 10, Tooltip = "The debug color used to identify the X-positive face of the cubemap.")]
		private Color _colorXPositive = new Color(0f, 1f, 1f, 1f);

		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "Y Negative", Order = 20, Tooltip = "The debug color used to identify the Y-negative face of the cubemap.")]
		private Color _colorYNegative = new Color(0f, 1f, 0f, 1f);

		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "Y Positive", Order = 30, Tooltip = "The debug color used to identify the Y-positive face of the cubemap.")]
		private Color _colorYPositive = new Color(1f, 0f, 1f, 1f);

		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "Z Negative", Order = 40, Tooltip = "The debug color used to identify the Z-negative face of the cubemap.")]
		private Color _colorZNegative = new Color(0f, 0f, 1f, 1f);

		[SerializeField]
		[ColorUsage(true, true)]
		[InspectorProperty(null, false, Label = "Z Positive", Order = 50, Tooltip = "The debug color used to identify the Z-positive face of the cubemap.")]
		private Color _colorZPositive = new Color(1f, 1f, 0f, 1f);

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			SetColor(input.Position, data);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			SetColor(input.Position, data.CommonData);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttribute("colorXPositive", _colorXPositive);
			xml.SetAttribute("colorXNegative", _colorXNegative);
			xml.SetAttribute("colorYPositive", _colorYPositive);
			xml.SetAttribute("colorYNegative", _colorYNegative);
			xml.SetAttribute("colorZPositive", _colorZPositive);
			xml.SetAttribute("colorZNegative", _colorZNegative);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_colorXPositive = xml.GetColorAttribute("colorXPositive", Color.clear);
			_colorXNegative = xml.GetColorAttribute("colorXNegative", Color.clear);
			_colorYPositive = xml.GetColorAttribute("colorYPositive", Color.clear);
			_colorYNegative = xml.GetColorAttribute("colorYNegative", Color.clear);
			_colorZPositive = xml.GetColorAttribute("colorZPositive", Color.clear);
			_colorZNegative = xml.GetColorAttribute("colorZNegative", Color.clear);
		}

		private void SetColor(Vector3d position, PlanetVertexData data)
		{
			double num = Mathd.Abs(position.x);
			double num2 = Mathd.Abs(position.y);
			double num3 = Mathd.Abs(position.z);
			Color? color = null;
			color = ((num >= num2) ? ((!(num >= num3)) ? new Color?((position.z >= 0.0) ? _colorZPositive : _colorZNegative) : new Color?((position.x >= 0.0) ? _colorXPositive : _colorXNegative)) : ((!(num2 >= num3)) ? new Color?((position.z >= 0.0) ? _colorZPositive : _colorZNegative) : new Color?((position.y >= 0.0) ? _colorYPositive : _colorYNegative)));
			if (color.HasValue)
			{
				Color value = color.Value;
				if (value.a > 0f)
				{
					data.DebugColorsOnly = true;
					data.Color = Color.Lerp(data.Color, value.linear, value.a);
				}
			}
		}
	}
}
