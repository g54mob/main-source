using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataVector2dInput : CustomSubBiomeTerrainData<CustomPlanetVertexDataVector2d>, ICustomObjectInspectorModel
	{
		public bool CreateGroup => false;

		public string Label { get; }

		public string Tooltip { get; }

		public Vector2d Value { get; set; }

		public CustomSubBiomeTerrainDataVector2dInput(string label, string tooltip)
		{
			Label = label;
			Tooltip = tooltip;
		}

		public override void ApplyBiomeData(CustomPlanetVertexDataVector2d vertexData, float biomeStrength)
		{
			vertexData.Value += Value * biomeStrength;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new Vector2dInputModel(Label, () => Value, delegate(Vector2d x)
			{
				Value = x;
			})).Model.Tooltip = Tooltip;
		}

		public override void RestoreFromXml(XElement xmlCustomData)
		{
			Value = xmlCustomData.GetVector2dAttributeOrNull("value") ?? Vector2d.zero;
		}

		public override void SaveToXml(XElement customDataXml)
		{
			customDataXml.SetAttributeValue("value", Utilities.Vector2dToString(Value));
		}
	}
}
