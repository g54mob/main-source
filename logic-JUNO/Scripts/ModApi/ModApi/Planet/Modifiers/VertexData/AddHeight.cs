using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Add Height", "A planet modifier that adds a constant height value to the planet or biome.")]
	public class AddHeight : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[InspectorProperty(null, false, Label = "Height", Order = 0, Tooltip = "The height, in meters, to add to the planet or biome.")]
		private double _height;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[3]
		{
			VertexDataPlanetModifierPassType.Biome,
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Height += _height;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Height += _height;
		}

		public override Vector2d LegacyGetMinMaxHeight(Vector2d minMaxHeight)
		{
			return minMaxHeight + new Vector2d(_height, _height);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("height", _height);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_height = (double)xml.Attribute("height") * (double)base.PlanetScale;
		}
	}
}
