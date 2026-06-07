using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.CustomData;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.CustomData
{
	[PlanetModifierInfo("Update Custom Data (Vector3d)", "A planet modifier used to add the specified data input slots to the custom vertex data with the specified ID (to be used by a game mod).")]
	public class UpdateCustomDataVector3d : UpdateCustomData<CustomPlanetVertexDataVector3d>
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input X", false, true, Order = 1, Tooltip = "The data input used to update the X component of the custom data value.")]
		private int _dataIndexX;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input Y", false, true, Order = 2, Tooltip = "The data input used to update the Y component of the custom data value.")]
		private int _dataIndexY;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input Z", false, true, Order = 3, Tooltip = "The data input used to update the Z component of the custom data value.")]
		private int _dataIndexZ;

		public override List<FieldInfo> GetInspectorFields()
		{
			List<FieldInfo> inspectorFields = base.GetInspectorFields();
			inspectorFields.Add(typeof(UpdateCustomDataVector3d).GetField("_dataIndexX", BindingFlags.Instance | BindingFlags.NonPublic));
			inspectorFields.Add(typeof(UpdateCustomDataVector3d).GetField("_dataIndexY", BindingFlags.Instance | BindingFlags.NonPublic));
			inspectorFields.Add(typeof(UpdateCustomDataVector3d).GetField("_dataIndexZ", BindingFlags.Instance | BindingFlags.NonPublic));
			return inspectorFields;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexX", _dataIndexX);
			xml.SetAttributeValue("dataIndexY", _dataIndexY);
			xml.SetAttributeValue("dataIndexZ", _dataIndexZ);
		}

		protected override void GetVertexData(double[] data, CustomPlanetVertexDataVector3d customData)
		{
			customData.Value += new Vector3d(data[_dataIndexX], data[_dataIndexY], data[_dataIndexZ]);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexX = (int)xml.Attribute("dataIndexX");
			_dataIndexY = (int)xml.Attribute("dataIndexY");
			_dataIndexZ = (int)xml.Attribute("dataIndexZ");
		}
	}
}
