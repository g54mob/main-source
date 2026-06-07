using System;
using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Terraces", "A planet modifier that takes a data input value and converts it to a terraced data output value. This modifier allows an unlimited number of terrace sections with the ability to configure the percentage of 'flat' area for a section as well configure the strength of the slope up to the next terrace section.")]
	public class Terraces2 : VertexDataCommonPassPlanetModifier
	{
		private class TerracesSection
		{
			[NonSerialized]
			public double FlatEndValue;

			[SerializeField]
			[Range(0f, 1f)]
			[InspectorProperty(null, false, Label = "Flatness", Order = 30, Tooltip = "The percentage of this terrace section that will be completely flat. The terrace section extends from the start value to the start value of the next section. This defines the percentage of that range in which the output will always be set to the start value for this section. The remaining range is considered the slope to the next terrace section.")]
			public double Flatness = 0.5;

			[NonSerialized]
			public double OneOverSlopeRange;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Slope Exponent", Order = 20, Tooltip = "The exponent that defines how this terrace section's slope is interpolated from its start value to the start value of the next section. A value of 1 would result in the slope using linear interpolation from this section to the next.")]
			public double SlopeExponent = 4.0;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Start Value", Order = 10, Tooltip = "The data input value at which this terrace section starts.")]
			public double StartValue;
		}

		[SerializeField]
		[InspectorProperty(null, false, Label = "Clamp Max", Order = 20, Tooltip = "If enabled, input values beyond the 'Start Value' of the final terrace section will be clamped to that 'Start Value'. If disabled, the input values that exceed the final 'Start Value' will just be passed untouched to the output.")]
		private bool _clampMax;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Clamp Min", Order = 10, Tooltip = "If enabled, input values below the 'Start Value' of the first terrace section will be clamped to that 'Start Value'. If disabled, the input values that fall below the first 'Start Value' will just be passed untouched to the output.")]
		private bool _clampMin;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input value to convert to a terraced output value. This value can be in any range, as long as the corresponding start values for each section use the same range of values.")]
		private int _dataIndexInput;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The data output of the modifier.")]
		private int _dataIndexOutput;

		[SerializeField]
		[InspectorProperty(null, false, Order = 30)]
		private TerracesSection[] _terraces;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			double num2 = 0.0;
			if (num <= _terraces[0].StartValue)
			{
				num2 = (_clampMin ? _terraces[0].StartValue : num);
			}
			else if (num >= _terraces[_terraces.Length - 1].StartValue)
			{
				num2 = (_clampMax ? _terraces[_terraces.Length - 1].StartValue : num);
			}
			else
			{
				for (int i = 1; i < _terraces.Length; i++)
				{
					TerracesSection terracesSection = _terraces[i];
					if (num < terracesSection.StartValue)
					{
						TerracesSection terracesSection2 = _terraces[i - 1];
						if (num > terracesSection2.FlatEndValue)
						{
							double d = (num - terracesSection2.FlatEndValue) * terracesSection2.OneOverSlopeRange;
							d = Mathd.Pow(d, terracesSection2.SlopeExponent);
							num2 = Mathd.Lerp(terracesSection2.StartValue, terracesSection.StartValue, d);
						}
						else
						{
							num2 = terracesSection2.StartValue;
						}
						break;
					}
				}
			}
			data.Data[_dataIndexOutput] = num2;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInput];
			double num2 = 0.0;
			if (num <= _terraces[0].StartValue)
			{
				num2 = (_clampMin ? _terraces[0].StartValue : num);
			}
			else if (num >= _terraces[_terraces.Length - 1].StartValue)
			{
				num2 = (_clampMax ? _terraces[_terraces.Length - 1].StartValue : num);
			}
			else
			{
				for (int i = 1; i < _terraces.Length; i++)
				{
					TerracesSection terracesSection = _terraces[i];
					if (num < terracesSection.StartValue)
					{
						TerracesSection terracesSection2 = _terraces[i - 1];
						if (num > terracesSection2.FlatEndValue)
						{
							double d = (num - terracesSection2.FlatEndValue) * terracesSection2.OneOverSlopeRange;
							d = Mathd.Pow(d, terracesSection2.SlopeExponent);
							num2 = Mathd.Lerp(terracesSection2.StartValue, terracesSection.StartValue, d);
						}
						else
						{
							num2 = terracesSection2.StartValue;
						}
						break;
					}
				}
			}
			data.Data[_dataIndexOutput] = num2;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			if (_terraces == null || _terraces.Length < 2)
			{
				throw new Exception("The terraces modifier requires at least 2 entries to function correctly.");
			}
			for (int i = 0; i < _terraces.Length - 1; i++)
			{
				TerracesSection terracesSection = _terraces[i];
				double num = _terraces[i + 1].StartValue - terracesSection.StartValue;
				terracesSection.FlatEndValue = terracesSection.StartValue + num * terracesSection.Flatness;
				terracesSection.OneOverSlopeRange = 1.0 / (num * (1.0 - terracesSection.Flatness));
			}
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_dataIndexInput = (_dataIndexOutput = (parentModifier?.GetDataSlots().FirstOrDefault(delegate(DataSlotField x)
			{
				DataSlotAttribute attribute = x.Attribute;
				return attribute != null && attribute.DataSlotType == DataSlotType.Output && x.DataIndex >= 0;
			})?.DataIndex).GetValueOrDefault());
			_terraces = new TerracesSection[3]
			{
				new TerracesSection
				{
					StartValue = -0.25,
					SlopeExponent = 4.0,
					Flatness = 0.75
				},
				new TerracesSection
				{
					StartValue = 0.0,
					SlopeExponent = 4.0,
					Flatness = 0.75
				},
				new TerracesSection
				{
					StartValue = 0.25,
					SlopeExponent = 4.0,
					Flatness = 0.75
				}
			};
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("clampMin", _clampMin);
			xml.SetAttributeValue("clampMax", _clampMax);
			TerracesSection[] terraces = _terraces;
			foreach (TerracesSection terracesSection in terraces)
			{
				xml.Add(new XElement("Terrace", new XAttribute("startValue", terracesSection.StartValue), new XAttribute("slopeExponent", terracesSection.SlopeExponent), new XAttribute("flatness", terracesSection.Flatness)));
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_clampMin = (bool)xml.Attribute("clampMin");
			_clampMax = (bool)xml.Attribute("clampMax");
			_terraces = (from x in xml.Elements("Terrace")
				select new TerracesSection
				{
					StartValue = (double)x.Attribute("startValue"),
					SlopeExponent = (double)x.Attribute("slopeExponent"),
					Flatness = (double)x.Attribute("flatness")
				} into x
				orderby x.StartValue
				select x).ToArray();
		}
	}
}
