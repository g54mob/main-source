using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.CustomData;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.CustomData
{
	[PlanetModifierInfo("Update Custom Data (Double)", "A planet modifier used to add the specified data input slot to the custom vertex data with the specified ID (to be used by a game mod).")]
	public class UpdateCustomDataDouble : UpdateCustomData<CustomPlanetVertexDataDouble>
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Order = 1, Tooltip = "The data input used to update the custom data value.")]
		private int _dataIndex;

		public override List<FieldInfo> GetInspectorFields()
		{
			List<FieldInfo> inspectorFields = base.GetInspectorFields();
			inspectorFields.Add(typeof(UpdateCustomDataDouble).GetField("_dataIndex", BindingFlags.Instance | BindingFlags.NonPublic));
			return inspectorFields;
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_dataIndex = (parentModifier?.GetDataSlots().FirstOrDefault(delegate(DataSlotField x)
			{
				DataSlotAttribute attribute = x.Attribute;
				return attribute != null && attribute.DataSlotType == DataSlotType.Output && x.DataIndex >= 0;
			})?.DataIndex).GetValueOrDefault();
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndex", _dataIndex);
		}

		protected override void GetVertexData(double[] data, CustomPlanetVertexDataDouble customData)
		{
			customData.Value += data[_dataIndex];
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndex = (int)xml.Attribute("dataIndex");
		}
	}
}
