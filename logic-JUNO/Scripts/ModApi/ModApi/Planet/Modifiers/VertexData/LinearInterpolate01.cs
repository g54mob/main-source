using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Interpolate (Linear 0 to 1)", "A planet modifier that linearly interpolates between two data input values based of another data input in the range of zero to one. This modifier is very similiar to the 'Interpolate' modifier, but it is more efficient if the interpolation value input is already in the zero to one range and linear interpolation is being used. The interpolation input value will not be clamped so odd behaviour could result if it is out of the expected zero to one range.")]
	public class LinearInterpolate01 : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input A (From)", false, true, Order = 1, Tooltip = "The 'A' input to be interpolated. The result will be interpolated from input 'A' to input 'B'.")]
		private int _dataIndexInputA;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input B (To)", false, true, Order = 2, Tooltip = "The 'B' input to be interpolated. The result will be interpolated from input 'A' to input 'B'.")]
		private int _dataIndexInputB;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Interpolation Value Input", false, true, Order = 3, Tooltip = "The value used to interpolate between the two inputs. If this value is below the min input value, the output will be input 'A'. If this value is above the max input value, the output will be input 'B'. If this value is in between those two values, the output will be linearly interpolated based on where this value falls between zero and one.")]
		private int _dataIndexInputC;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Order = 4, Tooltip = "The result of the interpolation.")]
		private int _dataIndexOutput;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInputA];
			double num2 = data.Data[_dataIndexInputB];
			double num3 = data.Data[_dataIndexInputC];
			data.Data[_dataIndexOutput] = num * (1.0 - num3) + num2 * num3;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInputA];
			double num2 = data.Data[_dataIndexInputB];
			double num3 = data.Data[_dataIndexInputC];
			data.Data[_dataIndexOutput] = num * num3 + num2 * (1.0 - num3);
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInputA", _dataIndexInputA);
			xml.SetAttributeValue("dataIndexInputB", _dataIndexInputB);
			xml.SetAttributeValue("dataIndexInputC", _dataIndexInputC);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInputA = (int)xml.Attribute("dataIndexInputA");
			_dataIndexInputB = (int)xml.Attribute("dataIndexInputB");
			_dataIndexInputC = (int)xml.Attribute("dataIndexInputC");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
		}
	}
}
