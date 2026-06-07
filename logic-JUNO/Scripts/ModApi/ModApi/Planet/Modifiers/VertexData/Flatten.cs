using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Flatten", "A planet modifier that flattens the terrain based on an input data value.")]
	public class Flatten : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input values to act as a mask. At 1.0, the terrain is completely flattened, fading out to the original height at 0.0.")]
		private int _dataIndexInput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Elevation", Order = 10, Tooltip = "The height, in meters, to which the terrain should be flattened.")]
		private double _elevation;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Use Smooth Step", Order = 35, Tooltip = "If enabled, the input value will have a smoothstep function applied to it prior to use as a flatten mask.")]
		private bool _smoothStep = true;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[3]
		{
			VertexDataPlanetModifierPassType.Biome,
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
			if (!(num > 0.0))
			{
				return;
			}
			if (num >= 1.0)
			{
				data.Height = _elevation;
				return;
			}
			double num2 = num;
			if (_smoothStep)
			{
				num2 = (3.0 - 2.0 * num2) * num2 * num2;
			}
			data.Height += (_elevation - data.Height) * num2;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
			if (!(num > 0.0))
			{
				return;
			}
			if (num >= 1.0)
			{
				data.Height = _elevation;
				return;
			}
			double num2 = num;
			if (_smoothStep)
			{
				num2 = (3.0 - 2.0 * num2) * num2 * num2;
			}
			data.Height += (_elevation - data.Height) * num2;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			xml.SetAttributeValue("elevation", _elevation);
			xml.SetAttributeValue("smoothStep", _smoothStep);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_elevation = (double)xml.Attribute("elevation");
			_smoothStep = (bool?)xml.Attribute("smoothStep") == true;
			float planetScale = base.PlanetScale;
			_elevation *= planetScale;
		}
	}
}
