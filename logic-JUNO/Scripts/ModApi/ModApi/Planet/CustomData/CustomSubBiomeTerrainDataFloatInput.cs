using System;
using System.Xml.Linq;
using ModApi.Ui.Inspector;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataFloatInput : CustomSubBiomeTerrainData<CustomPlanetVertexDataFloat>, ICustomObjectInspectorModel
	{
		public bool CreateGroup => false;

		public Func<float, string> DisplayFormatter { get; }

		public string Label { get; }

		public float? MaxValue { get; }

		public float? MinValue { get; }

		public string Tooltip { get; }

		public float Value { get; set; }

		public CustomSubBiomeTerrainDataFloatInput(string label, string tooltip, float? minValue = null, float? maxValue = null, Func<float, string> displayFormatter = null)
		{
			Label = label;
			Tooltip = tooltip;
			MinValue = minValue;
			MaxValue = maxValue;
			DisplayFormatter = displayFormatter;
		}

		public override void ApplyBiomeData(CustomPlanetVertexDataFloat vertexData, float biomeStrength)
		{
			vertexData.Value += Value * biomeStrength;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new FloatInputModel(Label, () => Value, delegate(float x)
			{
				Value = x;
			}, MinValue, MaxValue, DisplayFormatter)).Model.Tooltip = Tooltip;
		}

		public override void RestoreFromXml(XElement xmlCustomData)
		{
			Value = ((float?)xmlCustomData.Attribute("value")).GetValueOrDefault();
		}

		public override void SaveToXml(XElement customDataXml)
		{
			customDataXml.SetAttributeValue("value", Value);
		}
	}
}
