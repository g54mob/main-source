using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Remap (Linear Mirror)", "A planet modifier used to linearly remap a data input from one range of values to another. This differs from a regular linear remap in that it mirrors the remapping above and below zero. \n\nExample: Suppose you have values between -1 and 1 that you need to remap to -3 to -2 below zero and 2 to 3 above zero. This modifier would be then configured to remap the 0 to 1 range to the 2 to 3 range. Values above zero would remap as expected. Values below zero would be remapped from the -1 to 0 range into the -3 to -2 range.")]
	public class RemapLinearDual : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input values to be remapped.")]
		private int _dataIndexInput;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The output results of the modifier.")]
		private int _dataIndexOutput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "From Max Value", Order = 20, Tooltip = "The maximum value of the range from which values are being remapped. Input values at or beyond this value will be remapped to 'To Max Value'. Input values between 'From Min Value' and this will be linearly interpolated between 'To Min Value' and 'To Max Value'. These results are mirrored about zero when the input value is below zero.")]
		private double _fromMaxValue = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "From Min Value", Order = 10, Tooltip = "The minimum value of the range from which values are being remapped. Input values at or below this value will be remapped to 'To Min Value'. Input values between this and 'From Max Value' will be linearly interpolated between 'To Min Value' and 'To Max Value'. These results are mirrored about zero when the input value is below zero.")]
		private double _fromMinValue;

		private double _lerpToRange;

		private double _oneOverLerpFromRange;

		[SerializeField]
		[InspectorProperty(null, false, Label = "To Max Value", Order = 40, Tooltip = "The maximum value of the range to which values are being remapped. Input values at or beyond 'From Max Value' will be remapped to this. Input values between 'From Min Value' and 'From Max Value' will be linearly interpolated between 'To Min Value' and this. These results are mirrored about zero when the input value is below zero.")]
		private double _toMaxValue = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "To Min Value", Order = 30, Tooltip = "The minimum value of the range to which values are being remapped. Input values at or below 'From Min Value' will be remapped to this. Input values between 'From Min Value' and 'From Max Value' will be linearly interpolated between this and 'To Max Value'. These results are mirrored about zero when the input value is below zero.")]
		private double _toMinValue = -1.0;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			if (num < 0.0)
			{
				double num2 = (0.0 - num - _fromMinValue) * _oneOverLerpFromRange;
				if (num2 >= 1.0)
				{
					data.Data[_dataIndexOutput] = 0.0 - _toMaxValue;
				}
				else if (num2 <= 0.0)
				{
					data.Data[_dataIndexOutput] = 0.0 - _toMinValue;
				}
				else
				{
					data.Data[_dataIndexOutput] = 0.0 - (_toMinValue + num2 * _lerpToRange);
				}
			}
			else
			{
				double num3 = (num - _fromMinValue) * _oneOverLerpFromRange;
				if (num3 >= 1.0)
				{
					data.Data[_dataIndexOutput] = _toMaxValue;
				}
				else if (num3 <= 0.0)
				{
					data.Data[_dataIndexOutput] = _toMinValue;
				}
				else
				{
					data.Data[_dataIndexOutput] = _toMinValue + num3 * _lerpToRange;
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			if (num < 0.0)
			{
				double num2 = (0.0 - num - _fromMinValue) * _oneOverLerpFromRange;
				if (num2 >= 1.0)
				{
					data.Data[_dataIndexOutput] = 0.0 - _toMaxValue;
				}
				else if (num2 <= 0.0)
				{
					data.Data[_dataIndexOutput] = 0.0 - _toMinValue;
				}
				else
				{
					data.Data[_dataIndexOutput] = 0.0 - (_toMinValue + num2 * _lerpToRange);
				}
			}
			else
			{
				double num3 = (num - _fromMinValue) * _oneOverLerpFromRange;
				if (num3 >= 1.0)
				{
					data.Data[_dataIndexOutput] = _toMaxValue;
				}
				else if (num3 <= 0.0)
				{
					data.Data[_dataIndexOutput] = _toMinValue;
				}
				else
				{
					data.Data[_dataIndexOutput] = _toMinValue + num3 * _lerpToRange;
				}
			}
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_oneOverLerpFromRange = 1.0 / (_fromMaxValue - _fromMinValue);
			_lerpToRange = _toMaxValue - _toMinValue;
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_dataIndexInput = (_dataIndexOutput = (parentModifier?.GetDataSlots().FirstOrDefault(delegate(DataSlotField x)
			{
				DataSlotAttribute attribute = x.Attribute;
				return attribute != null && attribute.DataSlotType == DataSlotType.Output && x.DataIndex >= 0;
			})?.DataIndex).GetValueOrDefault());
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("fromMinValue", _fromMinValue);
			xml.SetAttributeValue("fromMaxValue", _fromMaxValue);
			xml.SetAttributeValue("toMinValue", _toMinValue);
			xml.SetAttributeValue("toMaxValue", _toMaxValue);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_fromMinValue = (double)xml.Attribute("fromMinValue");
			_fromMaxValue = (double)xml.Attribute("fromMaxValue");
			_toMinValue = (double)xml.Attribute("toMinValue");
			_toMaxValue = (double)xml.Attribute("toMaxValue");
		}
	}
}
