using System;
using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Legacy Modifier - Do Not Use", IsHidden = true)]
	public class Terraces : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true)]
		private int _dataIndexInput;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true)]
		private int _dataIndexOutput;

		[SerializeField]
		private double _powerExponent = 2.0;

		[SerializeField]
		private double[] _terraces;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = _terraces.Length - 1;
			if (num < _terraces[0])
			{
				num2 = -1.0;
				num3 = System.Math.Abs(_terraces[0] + 1.0);
			}
			else if (num > _terraces[num4])
			{
				num2 = _terraces[num4];
				num3 = 1.0 - num2;
			}
			else
			{
				for (int i = 1; i < _terraces.Length; i++)
				{
					if (num < _terraces[i])
					{
						num2 = _terraces[i - 1];
						num3 = System.Math.Abs(_terraces[i] - num2);
						break;
					}
				}
			}
			double num5 = System.Math.Pow((num - num2) / num3, _powerExponent) * num3;
			num2 += num5;
			data.Data[_dataIndexOutput] = num2;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = _terraces.Length - 1;
			if (num < _terraces[0])
			{
				num2 = -1.0;
				num3 = System.Math.Abs(_terraces[0] + 1.0);
			}
			else if (num > _terraces[num4])
			{
				num2 = _terraces[num4];
				num3 = 1.0 - num2;
			}
			else
			{
				for (int i = 1; i < _terraces.Length; i++)
				{
					if (num < _terraces[i])
					{
						num2 = _terraces[i - 1];
						num3 = System.Math.Abs(_terraces[i] - num2);
						break;
					}
				}
			}
			double num5 = System.Math.Pow((num - num2) / num3, _powerExponent) * num3;
			num2 += num5;
			data.Data[_dataIndexOutput] = num2;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("terraces", string.Join(",", _terraces.Select((double x) => DataIO.ToString(x)).ToArray()));
			xml.SetAttributeValue("powerExponent", _powerExponent);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_terraces = (from x in ((string)xml.Attribute("terraces")).Split(',')
				select DataIO.ParseDouble(x)).ToArray();
			_powerExponent = (double)xml.Attribute("powerExponent");
		}
	}
}
