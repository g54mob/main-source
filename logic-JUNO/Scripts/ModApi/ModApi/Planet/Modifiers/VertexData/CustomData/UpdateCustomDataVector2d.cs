using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.CustomData;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.CustomData
{
	[PlanetModifierInfo("Update Custom Data (Vector2d)", "A planet modifier used to add the specified data input slots to the custom vertex data with the specified ID (to be used by a game mod).")]
	public class UpdateCustomDataVector2d : UpdateCustomData<CustomPlanetVertexDataVector2d>
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input X", false, true, Order = 1, Tooltip = "The data input used to update the X component of the custom data value.")]
		private int _dataIndexX;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input Y", false, true, Order = 2, Tooltip = "The data input used to update the Y component of the custom data value.")]
		private int _dataIndexY;

		public override List<FieldInfo> GetInspectorFields()
		{
			List<FieldInfo> inspectorFields = base.GetInspectorFields();
			inspectorFields.Add(typeof(UpdateCustomDataVector2d).GetField("_dataIndexX", BindingFlags.Instance | BindingFlags.NonPublic));
			inspectorFields.Add(typeof(UpdateCustomDataVector2d).GetField("_dataIndexY", BindingFlags.Instance | BindingFlags.NonPublic));
			return inspectorFields;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexX", _dataIndexX);
			xml.SetAttributeValue("dataIndexY", _dataIndexY);
		}

		protected override void GetVertexData(double[] data, CustomPlanetVertexDataVector2d customData)
		{
			customData.Value += new Vector2d(data[_dataIndexX], data[_dataIndexY]);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexX = (int)xml.Attribute("dataIndexX");
			_dataIndexY = (int)xml.Attribute("dataIndexY");
		}
	}
}
