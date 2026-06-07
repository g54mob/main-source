using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Clamp", "A planet modifier used to clamp a data input value between a minimum and maximum value.")]
	public class Clamp : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[InspectorProperty(null, false, Label = "Max", Order = 10, Tooltip = "The maximum value to which the output value will be clamped.")]
		private double _clampMax = 1.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Min", Order = 0, Tooltip = "The minimum value to which the output value will be clamped.")]
		private double _clampMin;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input value to be clamped.")]
		private int _dataIndexInput;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The clamped output value, which should be between the specified minimum and maximum value.")]
		private int _dataIndexOutput;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Data[_dataIndexOutput] = Mathd.Clamp(data.Data[_dataIndexInput], _clampMin, _clampMax);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Data[_dataIndexOutput] = Mathd.Clamp(data.Data[_dataIndexInput], _clampMin, _clampMax);
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
			xml.SetAttributeValue("clampMin", _clampMin);
			xml.SetAttributeValue("clampMax", _clampMax);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_clampMin = (double)xml.Attribute("clampMin");
			_clampMax = (double)xml.Attribute("clampMax");
		}
	}
}
