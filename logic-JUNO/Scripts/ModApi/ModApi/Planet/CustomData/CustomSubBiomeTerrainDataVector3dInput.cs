using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataVector3dInput : CustomSubBiomeTerrainData<CustomPlanetVertexDataVector3d>, ICustomObjectInspectorModel
	{
		public bool CreateGroup => false;

		public string Label { get; }

		public string Tooltip { get; }

		public Vector3d Value { get; set; }

		public CustomSubBiomeTerrainDataVector3dInput(string label, string tooltip)
		{
			Label = label;
			Tooltip = tooltip;
		}

		public override void ApplyBiomeData(CustomPlanetVertexDataVector3d vertexData, float biomeStrength)
		{
			vertexData.Value += Value * biomeStrength;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new Vector3dInputModel(Label, () => Value, delegate(Vector3d x)
			{
				Value = x;
			})).Model.Tooltip = Tooltip;
		}

		public override void RestoreFromXml(XElement xmlCustomData)
		{
			Value = xmlCustomData.GetVector3dAttributeOrNull("value") ?? Vector3d.zero;
		}

		public override void SaveToXml(XElement customDataXml)
		{
			customDataXml.SetAttributeValue("value", Utilities.Vector3dToString(Value));
		}
	}
}
