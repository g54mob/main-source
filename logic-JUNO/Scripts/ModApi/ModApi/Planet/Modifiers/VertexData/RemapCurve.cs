using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Animation;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Remap (Curve)", "A planet modifier that remaps a data input value based on a specified curve and stores the result in a data output.")]
	public class RemapCurve : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input values to be remapped.")]
		private int _dataIndexInput;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The output results of the modifier.")]
		private int _dataIndexOutput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Curve", Tooltip = "The curve used to remap the input values. The X-axis represents the input values and the y-Axis defines the values to which those input values will be remapped.")]
		private AnimationCurve _remapCurve;

		private AnimationCurveSampler _remapCurveSampler;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Data[_dataIndexOutput] = _remapCurveSampler.Sample((float)data.Data[_dataIndexInput]);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Data[_dataIndexOutput] = _remapCurveSampler.Sample((float)data.Data[_dataIndexInput]);
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_remapCurveSampler = new AnimationCurveSampler(_remapCurve);
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_remapCurve = new AnimationCurve(new Keyframe(-1f, 0f), new Keyframe(1f, 1f));
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
			Utilities.SetAnimationCurveAttribute(xml, "curve", _remapCurve);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_remapCurve = Utilities.GetAnimationCurveAttribute(xml, "curve");
		}
	}
}
