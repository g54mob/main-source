using System;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Interpolate", "A planet modifier that interpolates between two data input values based of another data input.")]
	public class Interpolate : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input A (From)", false, true, Order = 1, Tooltip = "The 'A' input to be interpolated. The result will be interpolated from input 'A' to input 'B'.")]
		private int _dataIndexInputA;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input B (To)", false, true, Order = 2, Tooltip = "The 'B' input to be interpolated. The result will be interpolated from input 'A' to input 'B'.")]
		private int _dataIndexInputB;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Interpolation Value Input", false, true, Order = 3, Tooltip = "The value used to interpolate between the two inputs. If this value is below the min input value, the output will be input 'A'. If this value is above the max input value, the output will be input 'B'. If this value is in between those two values, the output will be interpolated based on where this value falls in the specified min/max range.")]
		private int _dataIndexInputC;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Order = 4, Tooltip = "The result of the interpolation.")]
		private int _dataIndexOutput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Max Input Value", Order = 20, Tooltip = "The maximum input value used to create the range for the interpolation value input.")]
		private double _inputMaxValue = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Min Input Value", Order = 10, Tooltip = "The minimum input value used to create the range for the interpolation value input.")]
		private double _inputMinValue = -1.0;

		private double _inputRange;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Power Exponent", Order = 30, Tooltip = "The exponent that determines the power to which the interpolation value will be raised after remapping it into the 0 to 1 range based off the min/max input values. A value of 1 will result in linear interpolation. A value above or below one will result in interpolation occuring over a curve.")]
		private double _powerExponent = 1.0;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInputA];
			double num2 = data.Data[_dataIndexInputB];
			double num3 = (data.Data[_dataIndexInputC] - _inputMinValue) / _inputRange;
			num3 = ((_powerExponent == 1.0) ? num3 : System.Math.Pow(num3, _powerExponent));
			data.Data[_dataIndexOutput] = num * (1.0 - num3) + num2 * num3;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInputA];
			double num2 = data.Data[_dataIndexInputB];
			double num3 = (data.Data[_dataIndexInputC] - _inputMinValue) / _inputRange;
			num3 = ((_powerExponent == 1.0) ? num3 : System.Math.Pow(num3, _powerExponent));
			data.Data[_dataIndexOutput] = num * num3 + num2 * (1.0 - num3);
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_inputRange = _inputMaxValue - _inputMinValue;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInputA", _dataIndexInputA);
			xml.SetAttributeValue("dataIndexInputB", _dataIndexInputB);
			xml.SetAttributeValue("dataIndexInputC", _dataIndexInputC);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("inputMinValue", _inputMinValue);
			xml.SetAttributeValue("inputMaxValue", _inputMaxValue);
			xml.SetAttributeValue("powerExponent", _powerExponent);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInputA = (int)xml.Attribute("dataIndexInputA");
			_dataIndexInputB = (int)xml.Attribute("dataIndexInputB");
			_dataIndexInputC = (int)xml.Attribute("dataIndexInputC");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_inputMinValue = (double)xml.Attribute("inputMinValue");
			_inputMaxValue = (double)xml.Attribute("inputMaxValue");
			_powerExponent = (double)xml.Attribute("powerExponent");
		}
	}
}
