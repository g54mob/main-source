using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Get Constant", "A simple planet modifier that takes a constant value and stores it in a data output.")]
	public class GetConstant : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The data output to store the constant value.")]
		private int _dataIndexOutput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Constant Value", Order = 0, Tooltip = "The constant value to store in the data output.")]
		private float _value;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Data[_dataIndexOutput] = _value;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Data[_dataIndexOutput] = _value;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("value", _value);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_value = (float)xml.Attribute("value");
		}
	}
}
