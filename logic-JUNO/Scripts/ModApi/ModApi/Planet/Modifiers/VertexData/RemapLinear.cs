using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Remap (Linear)", "A planet modifier used to linearly remap a data input from one range of values to another.")]
	public class RemapLinear : VertexDataCommonPassPlanetModifier
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
		[InspectorProperty(null, false, Label = "From Max Value", Order = 20, Tooltip = "The maximum value of the range from which values are being remapped. Input values at or beyond this value will be remapped to 'To Max Value'. Input values between 'From Min Value' and this will be linearly interpolated between 'To Min Value' and 'To Max Value'.")]
		private double _fromMaxValue = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "From Min Value", Order = 10, Tooltip = "The minimum value of the range from which values are being remapped. Input values at or below this value will be remapped to 'To Min Value'. Input values between this and 'From Max Value' will be linearly interpolated between 'To Min Value' and 'To Max Value'.")]
		private double _fromMinValue = -1.0;

		private double _lerpToRange;

		private double _oneOverLerpFromRange;

		[SerializeField]
		[InspectorProperty(null, false, Label = "To Max Value", Order = 40, Tooltip = "The maximum value of the range to which values are being remapped. Input values at or beyond 'From Max Value' will be remapped to this. Input values between 'From Min Value' and 'From Max Value' will be linearly interpolated between 'To Min Value' and this.")]
		private double _toMaxValue = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "To Min Value", Order = 30, Tooltip = "The minimum value of the range to which values are being remapped. Input values at or below 'From Min Value' will be remapped to this. Input values between 'From Min Value' and 'From Max Value' will be linearly interpolated between this and 'To Max Value'.")]
		private double _toMinValue = -1.0;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = (data.Data[_dataIndexInput] - _fromMinValue) * _oneOverLerpFromRange;
			num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
			data.Data[_dataIndexOutput] = _toMinValue + _lerpToRange * num;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = (data.Data[_dataIndexInput] - _fromMinValue) * _oneOverLerpFromRange;
			num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
			data.Data[_dataIndexOutput] = _toMinValue + _lerpToRange * num;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_lerpToRange = _toMaxValue - _toMinValue;
			_oneOverLerpFromRange = 1.0 / (_fromMaxValue - _fromMinValue);
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
