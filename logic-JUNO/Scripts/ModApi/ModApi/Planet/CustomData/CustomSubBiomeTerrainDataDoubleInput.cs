using System;
using System.Xml.Linq;
using ModApi.Ui.Inspector;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataDoubleInput : CustomSubBiomeTerrainData<CustomPlanetVertexDataDouble>, ICustomObjectInspectorModel
	{
		public bool CreateGroup => false;

		public Func<double, string> DisplayFormatter { get; }

		public string Label { get; }

		public double? MaxValue { get; }

		public double? MinValue { get; }

		public string Tooltip { get; }

		public double Value { get; set; }

		public CustomSubBiomeTerrainDataDoubleInput(string label, string tooltip, double? minValue = null, double? maxValue = null, Func<double, string> displayFormatter = null)
		{
			Label = label;
			Tooltip = tooltip;
			MinValue = minValue;
			MaxValue = maxValue;
			DisplayFormatter = displayFormatter;
		}

		public override void ApplyBiomeData(CustomPlanetVertexDataDouble vertexData, float biomeStrength)
		{
			vertexData.Value += Value * (double)biomeStrength;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new NumericInputModel(Label, () => Value, delegate(double x)
			{
				Value = x;
			}, MinValue, MaxValue, DisplayFormatter)).Model.Tooltip = Tooltip;
		}

		public override void RestoreFromXml(XElement xmlCustomData)
		{
			Value = ((double?)xmlCustomData.Attribute("value")).GetValueOrDefault();
		}

		public override void SaveToXml(XElement customDataXml)
		{
			customDataXml.SetAttributeValue("value", Value);
		}
	}
}
