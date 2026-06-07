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
	[PlanetModifierInfo("Sub-Biomes (Altitude Based)", "A modifier that runs within a biome and defines the sub-biomes it contains. These sub-biomes are defined based on altitude ranges.")]
	public class AltitudeBasedSubBiomes : VertexDataCommonPassPlanetModifier, ISubBiomePlanetModifier
	{
		[Serializable]
		public class AltitudeRange
		{
			[SerializeField]
			[InspectorProperty(null, false, Label = "Altitude Range", Order = 0, Tooltip = "The altitude range (in meters) for this sub-biome. This is defined in min and max heights in meters. The min/max values should overlap neighboring sub-biomes so there is a smooth transition between those sub-biomes.")]
			public MinMaxValue Altitude;

			[NonSerialized]
			public float OneOverBlendRange;

			[SerializeField]
			[InspectorGroup(null)]
			[InspectorProperty(null, false, Label = "Sub-Biome Data", Order = 10)]
			public SubBiomeData SubBiome;

			public static AltitudeRange CreateFromXml(XElement xml)
			{
				return new AltitudeRange
				{
					Altitude = (MinMaxValue)xml.Attribute("altitude"),
					SubBiome = SubBiomeData.CreateFromXml(xml.Element("Data"))
				};
			}

			public XElement SaveXml()
			{
				return new XElement("SubBiome", new XAttribute("altitude", Altitude), SubBiome.SaveXml(new XElement("Data")));
			}
		}

		[SerializeField]
		[InspectorGroup("Height Variance")]
		[InspectorProperty(null, false, Label = "Max Height Variance", Order = 10, Tooltip = "The height (in meters) that the current height can vary for purposes of determining to which sub-biome it belongs. This does not change the actual height, it just gives some variation to the height ranges of the sub-biomes. The strength of this variation is determined by the height variance data input value, which acts as a multiplier to this value.")]
		private float _heightVarianceAmount;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Blend Range", Order = 20, Tooltip = "The min and max heights, in meters, that define the range over which the height variance achieves full strength. At or below the minimum value, the height variance will not apply. Above the maximum height value, the variance will apply 100%. Between the min and max values, the strength of the variance (defined by the data input value) will be linearly scaled from 0% to 100%.")]
		private MinMaxValue _heightVarianceBlend;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Height Variance", false, true, Tooltip = "If height variance is used, this input data defines the strength of the height variance (typically a value between 0 and 1).")]
		private int _heightVarianceDataIndex;

		[NonSerialized]
		private float _heightVarianceOneOverBlendRange;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Use Common Data", Order = 30, Tooltip = "If running in a biome specific pass, this determines whether the input data value comes from the common pass or from this biome specific pass.")]
		private bool _heightVarianceUsesCommonData;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Sub-Biome", Order = 0, AllowArrayReorder = false, Tooltip = "The list of sub-biomes and thier associated data defined for this biome.")]
		private AltitudeRange[] _subBiomes;

		public AltitudeRange[] SubBiomes => _subBiomes;

		public override VertexDataType VertexDataType => VertexDataType.Biome;

		public void DeleteSubBiome(int index)
		{
			int num = _subBiomes.Length;
			if (index < 0 || index >= num)
			{
				throw new IndexOutOfRangeException($"Unable to delete sub-biome. Index '{index}' out of range. Sub-biomes size: {_subBiomes.Length}");
			}
			MinMaxValue altitude = _subBiomes[index].Altitude;
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
					_subBiomes[index].Altitude.MinValue = altitude.MinValue;
				}
			}
			else if (index >= num2)
			{
				_subBiomes[index - 1].Altitude.MaxValue = altitude.MaxValue;
			}
			else
			{
				AltitudeRange obj = _subBiomes[index - 1];
				AltitudeRange altitudeRange = _subBiomes[index];
				obj.Altitude.MaxValue = altitude.MaxValue;
				altitudeRange.Altitude.MinValue = altitude.MinValue;
			}
		}

		public void GetSubBiomes(List<SubBiomeData> list)
		{
			AltitudeRange[] subBiomes = _subBiomes;
			foreach (AltitudeRange altitudeRange in subBiomes)
			{
				list.Add(altitudeRange.SubBiome);
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support non-biome-specific vertex data.");
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			float num = (float)(data.Height + data.CommonData.Height);
			if (_heightVarianceAmount != 0f && num > _heightVarianceBlend.MinValue)
			{
				float num2 = (float)(_heightVarianceUsesCommonData ? data.CommonData.Data : data.Data)[_heightVarianceDataIndex];
				if (num < _heightVarianceBlend.MaxValue)
				{
					num2 *= (num - _heightVarianceBlend.MinValue) * _heightVarianceOneOverBlendRange;
				}
				num += _heightVarianceAmount * num2;
			}
			PlanetVertexBiomeData planetVertexBiomeData = data.CommonData.Biomes[data.BiomeIndex];
			float strength = planetVertexBiomeData.Strength;
			for (int i = 0; i < _subBiomes.Length; i++)
			{
				if (num < _subBiomes[i].Altitude.MaxValue)
				{
					int num3 = i + 1;
					if (num3 != _subBiomes.Length && num > _subBiomes[num3].Altitude.MinValue)
					{
						AltitudeRange altitudeRange = _subBiomes[num3];
						float num4 = (num - altitudeRange.Altitude.MinValue) * altitudeRange.OneOverBlendRange * strength;
						planetVertexBiomeData.PrimarySubBiomeStrength = strength - num4;
						planetVertexBiomeData.PrimarySubBiome = _subBiomes[i].SubBiome;
						planetVertexBiomeData.SecondarySubBiomeStrength = num4;
						planetVertexBiomeData.SecondarySubBiome = _subBiomes[num3].SubBiome;
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
			_heightVarianceOneOverBlendRange = 1f / (_heightVarianceBlend.MaxValue - _heightVarianceBlend.MinValue);
			for (int i = 1; i < _subBiomes.Length; i++)
			{
				_subBiomes[i].OneOverBlendRange = 1f / (_subBiomes[i - 1].Altitude.MaxValue - _subBiomes[i].Altitude.MinValue);
			}
		}

		public AltitudeRange InsertSubBiome(int index)
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
			MinMaxValue altitude;
			if (index == 0)
			{
				if (num == 0)
				{
					altitude = new MinMaxValue(0f, 1000f);
				}
				else
				{
					AltitudeRange altitudeRange = _subBiomes[index + 1];
					altitude = new MinMaxValue(altitudeRange.Altitude.MinValue - 1000f, altitudeRange.Altitude.MinValue);
				}
			}
			else if (index >= num)
			{
				AltitudeRange altitudeRange2 = _subBiomes[index - 1];
				altitude = new MinMaxValue(altitudeRange2.Altitude.MaxValue, altitudeRange2.Altitude.MaxValue + 1000f);
			}
			else
			{
				AltitudeRange altitudeRange3 = _subBiomes[index - 1];
				AltitudeRange altitudeRange4 = _subBiomes[index + 1];
				altitude = new MinMaxValue(altitudeRange4.Altitude.MinValue, altitudeRange3.Altitude.MaxValue);
				altitudeRange3.Altitude.MaxValue = altitude.MinValue;
				altitudeRange4.Altitude.MinValue = altitude.MaxValue;
			}
			_subBiomes[index] = new AltitudeRange
			{
				Altitude = altitude,
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
			xml.SetAttributeValue("heightVarianceDataIndex", _heightVarianceDataIndex);
			xml.SetAttributeValue("heightVarianceAmount", _heightVarianceAmount);
			xml.SetAttributeValue("heightVarianceBlend", _heightVarianceBlend);
			xml.SetAttributeValue("heightVarianceUsesCommonData", _heightVarianceUsesCommonData);
			_subBiomes = _subBiomes.OrderBy((AltitudeRange x) => x.Altitude.MinValue).ToArray();
			AltitudeRange[] subBiomes = _subBiomes;
			foreach (AltitudeRange altitudeRange in subBiomes)
			{
				xml.Add(altitudeRange.SaveXml());
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_heightVarianceDataIndex = ((int?)xml.Attribute("heightVarianceDataIndex")).GetValueOrDefault();
			_heightVarianceAmount = ((float?)xml.Attribute("heightVarianceAmount")).GetValueOrDefault();
			_heightVarianceBlend = ((MinMaxValue?)xml.Attribute("heightVarianceBlend")).GetValueOrDefault();
			_heightVarianceUsesCommonData = (bool?)xml.Attribute("heightVarianceUsesCommonData") == true;
			_subBiomes = (from x in xml.Elements("SubBiome")
				select AltitudeRange.CreateFromXml(x)).ToArray();
			float planetScale = base.PlanetScale;
			_heightVarianceAmount *= planetScale;
			_heightVarianceBlend.MinValue *= planetScale;
			_heightVarianceBlend.MaxValue *= planetScale;
			AltitudeRange[] subBiomes = _subBiomes;
			foreach (AltitudeRange obj in subBiomes)
			{
				obj.Altitude.MinValue *= planetScale;
				obj.Altitude.MaxValue *= planetScale;
			}
		}
	}
}
