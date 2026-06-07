using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataColorInput : CustomSubBiomeTerrainData<CustomPlanetVertexDataVector4>, ICustomObjectInspectorModel
	{
		public bool AllowHDR { get; }

		public bool CreateGroup => false;

		public string Label { get; }

		public string Tooltip { get; }

		public Color Value { get; set; }

		public CustomSubBiomeTerrainDataColorInput(string label, string tooltip, bool allowHDR)
		{
			Label = label;
			Tooltip = tooltip;
			AllowHDR = allowHDR;
		}

		public override void ApplyBiomeData(CustomPlanetVertexDataVector4 vertexData, float biomeStrength)
		{
			vertexData.Value += (Vector4)Value * biomeStrength;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new ColorModel(Label, () => Value, delegate(Color x)
			{
				Value = x;
			}, allowTransparency: true, callbackOnPreviewColorChange: false, AllowHDR)).Model.Tooltip = Tooltip;
		}

		public override void RestoreFromXml(XElement xmlCustomData)
		{
			Value = xmlCustomData.GetColorAttribute("value") ?? Color.clear;
		}

		public override void SaveToXml(XElement customDataXml)
		{
			customDataXml.SetAttributeValue("value", Value.ToXAttributeValue());
		}
	}
}
