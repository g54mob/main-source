using System.Xml.Linq;
using ModApi.Ui.Inspector;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataFloatSliderInput : CustomSubBiomeTerrainData<CustomPlanetVertexDataFloat>, ICustomObjectInspectorModel
	{
		public bool AllowManualInput { get; }

		public bool CreateGroup => false;

		public string Label { get; }

		public float MaxValue { get; }

		public float MinValue { get; }

		public string Tooltip { get; }

		public float Value { get; set; }

		public bool WholeNumbers { get; }

		public CustomSubBiomeTerrainDataFloatSliderInput(string label, string tooltip, float minValue, float maxValue, bool wholeNumbers = false, bool allowManualInput = true)
		{
			Label = label;
			Tooltip = tooltip;
			MinValue = minValue;
			MaxValue = maxValue;
			WholeNumbers = wholeNumbers;
			AllowManualInput = allowManualInput;
		}

		public override void ApplyBiomeData(CustomPlanetVertexDataFloat vertexData, float biomeStrength)
		{
			vertexData.Value += Value * biomeStrength;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new SliderModel(Label, () => Value, delegate(float x)
			{
				Value = x;
			}, MinValue, MaxValue, WholeNumbers, AllowManualInput)).Model.Tooltip = Tooltip;
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
