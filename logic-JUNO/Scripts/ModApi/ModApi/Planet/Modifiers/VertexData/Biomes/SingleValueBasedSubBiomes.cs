using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Sub-Biomes (Value Based)", "A modifier that runs within a biome and defines the sub-biomes it contains. These sub-biomes are defined based on values from a data input.")]
	public class SingleValueBasedSubBiomes : VertexDataCommonPassPlanetModifier, ISubBiomePlanetModifier
	{
		[Serializable]
		public class ValueRange
		{
			[NonSerialized]
			public float OneOverBlendRange;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Range", Order = 0, Tooltip = "The value range for this sub-biome. This is defined as min and max values coming from the input data that defines this sub-biome.The min/max values should overlap neighboring sub-biomes so there is a smooth transition between those sub-biomes.")]
			public MinMaxValue Range;

			[SerializeField]
			[InspectorGroup(null)]
			[InspectorProperty(null, false, Label = "Sub-Biome Data", Order = 10)]
			public SubBiomeData SubBiome;

			public static ValueRange CreateFromXml(XElement xml)
			{
				return new ValueRange
				{
					Range = (MinMaxValue)xml.Attribute("range"),
					SubBiome = SubBiomeData.CreateFromXml(xml.Element("Data"))
				};
			}

			public XElement SaveXml()
			{
				return new XElement("SubBiome", new XAttribute("range", Range), SubBiome.SaveXml(new XElement("Data")));
			}
		}

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input containing the values that define the sub-biomes.")]
		private int _dataIndexInput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Sub-Biome", Order = 0, AllowArrayReorder = false, Tooltip = "The list of sub-biomes and their associated data defined for this biome.")]
		private ValueRange[] _subBiomes;

		public ValueRange[] SubBiomes => _subBiomes;

		public override VertexDataType VertexDataType => VertexDataType.Biome;

		public void DeleteSubBiome(int index)
		{
			int num = _subBiomes.Length;
			if (index < 0 || index >= num)
			{
				throw new IndexOutOfRangeException($"Unable to delete sub-biome. Index '{index}' out of range. Sub-biomes size: {_subBiomes.Length}");
			}
			MinMaxValue range = _subBiomes[index].Range;
			int num2 = num - 1;
			for (int i = index; i < num2; i++)
			{
				_subBiomes[i] = _subBiomes[i + 1];
			}
			Array.Resize(ref _subBiomes, num2);
			if (index == 0)
			{
				if (num2 > 0)
				{
					_subBiomes[index].Range.MinValue = range.MinValue;
				}
			}
			else if (index >= num2)
			{
				_subBiomes[index - 1].Range.MaxValue = range.MaxValue;
			}
			else
			{
				ValueRange obj = _subBiomes[index - 1];
				ValueRange valueRange = _subBiomes[index];
				obj.Range.MaxValue = range.MaxValue;
				valueRange.Range.MinValue = range.MinValue;
			}
		}

		public void GetSubBiomes(List<SubBiomeData> list)
		{
			ValueRange[] subBiomes = _subBiomes;
			foreach (ValueRange valueRange in subBiomes)
			{
				list.Add(valueRange.SubBiome);
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support non-biome-specific vertex data.");
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			float num = (float)data.Data[_dataIndexInput];
			PlanetVertexBiomeData planetVertexBiomeData = data.CommonData.Biomes[data.BiomeIndex];
			float strength = planetVertexBiomeData.Strength;
			for (int i = 0; i < _subBiomes.Length; i++)
			{
				if (num < _subBiomes[i].Range.MaxValue)
				{
					int num2 = i + 1;
					if (num2 != _subBiomes.Length && num > _subBiomes[num2].Range.MinValue)
					{
						ValueRange valueRange = _subBiomes[num2];
						float num3 = (num - valueRange.Range.MinValue) * valueRange.OneOverBlendRange * strength;
						planetVertexBiomeData.PrimarySubBiomeStrength = strength - num3;
						planetVertexBiomeData.PrimarySubBiome = _subBiomes[i].SubBiome;
						planetVertexBiomeData.SecondarySubBiomeStrength = num3;
						planetVertexBiomeData.SecondarySubBiome = _subBiomes[num2].SubBiome;
					}
					else
					{
						planetVertexBiomeData.PrimarySubBiomeStrength = strength;
						planetVertexBiomeData.PrimarySubBiome = _subBiomes[i].SubBiome;
						planetVertexBiomeData.SecondarySubBiomeStrength = 0f;
						planetVertexBiomeData.SecondarySubBiome = null;
					}
					return;
				}
			}
			planetVertexBiomeData.PrimarySubBiomeStrength = strength;
			planetVertexBiomeData.PrimarySubBiome = _subBiomes[_subBiomes.Length - 1].SubBiome;
			planetVertexBiomeData.SecondarySubBiomeStrength = 0f;
			planetVertexBiomeData.SecondarySubBiome = null;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			for (int i = 1; i < _subBiomes.Length; i++)
			{
				_subBiomes[i].OneOverBlendRange = 1f / (_subBiomes[i - 1].Range.MaxValue - _subBiomes[i].Range.MinValue);
			}
		}

		public ValueRange InsertSubBiome(int index)
		{
			int num = _subBiomes.Length;
			if (index < 0 || index > num)
			{
				throw new IndexOutOfRangeException($"Unable to insert sub-biome. Index '{index}' out of range. Sub-biomes size: {num}");
			}
			Array.Resize(ref _subBiomes, num + 1);
			for (int num2 = num; num2 > index; num2--)
			{
				_subBiomes[num2] = _subBiomes[num2 - 1];
			}
			MinMaxValue range;
			if (index == 0)
			{
				if (num == 0)
				{
					range = new MinMaxValue(0f, 1f);
				}
				else
				{
					ValueRange valueRange = _subBiomes[index + 1];
					range = new MinMaxValue(valueRange.Range.MinValue - (valueRange.Range.MaxValue - valueRange.Range.MinValue), valueRange.Range.MinValue);
				}
			}
			else if (index >= num)
			{
				ValueRange valueRange2 = _subBiomes[index - 1];
				range = new MinMaxValue(valueRange2.Range.MaxValue, valueRange2.Range.MaxValue + (valueRange2.Range.MaxValue - valueRange2.Range.MinValue));
			}
			else
			{
				ValueRange valueRange3 = _subBiomes[index - 1];
				ValueRange valueRange4 = _subBiomes[index + 1];
				range = new MinMaxValue(valueRange4.Range.MinValue, valueRange3.Range.MaxValue);
				valueRange3.Range.MaxValue = range.MinValue;
				valueRange4.Range.MinValue = range.MaxValue;
			}
			_subBiomes[index] = new ValueRange
			{
				Range = range,
				SubBiome = new SubBiomeData
				{
					SlopeRange = new MinMaxValue(0f, 1f)
				}
			};
			return _subBiomes[index];
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			_subBiomes = _subBiomes.OrderBy((ValueRange x) => x.Range.MinValue).ToArray();
			ValueRange[] subBiomes = _subBiomes;
			foreach (ValueRange valueRange in subBiomes)
			{
				xml.Add(valueRange.SaveXml());
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_subBiomes = (from x in xml.Elements("SubBiome")
				select ValueRange.CreateFromXml(x)).ToArray();
		}
	}
}
