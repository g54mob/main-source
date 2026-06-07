using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Common;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Biome Redistribution", "A biome pass planet modifier used to redistribute the strength of a biome to different biomes based on an input data value. This modifier works similarly to the 'Biomes (Value Based)' modifier in that it defines a set of biomes with a values that overlap to smoothly transition between two biomes. The modifier determines which biome range the data input value falls into and re-assignes the strength of the source biome to the target biome(s). The biome will be fully re-assigned to the biome with the lowest min value if the input value falls below that min value. Likewise, it will be fully re-assigned to the biome with the highest min value if the input falls above that max value.")]
	public class SimpleBiomeRedistribution : VertexDataPlanetModifier, ICustomObjectInspectorModelFields, IBiomeListModifiedHandler
	{
		[Serializable]
		private class BiomeRange : ICustomObjectInspectorModelFields
		{
			[InspectorProperty(null, false, Order = 0)]
			public int BiomeIndex;

			[NonSerialized]
			public string Name;

			[NonSerialized]
			public float OneOverBlendRange;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Range", Order = 10, Tooltip = "The range of of the input values that will be re-assigned to this biome. Biome ranges are ordered and evaluated by the min values. The max value of one range should overlap with the min value for the next range in order for biomes to smoothly transition from one to the other. Input values outside of the specified ranges will still be re-assigned, with low values being assigned to the first biome range and high values assigned to the last biome range.")]
			public MinMaxValue Range;

			public static BiomeRange CreateFromXml(XElement xml)
			{
				return new BiomeRange
				{
					BiomeIndex = (int)xml.Attribute("biomeIndex"),
					Range = (MinMaxValue)xml.Attribute("range")
				};
			}

			public bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex)
			{
				if (member.Name == "BiomeIndex")
				{
					List<PlanetBiome> biomes = (inspectorObject.Target as SimpleBiomeRedistribution)?.TerrainData?.Biomes;
					if (biomes == null)
					{
						Debug.LogError("Unable to get the biomes for custom field models in the object inspector for the SimpleBiomeRedistribution modifier.");
						return true;
					}
					groupModel.AddAndBuild(new SliderModel("Biome", () => BiomeIndex, delegate(float x)
					{
						BiomeIndex = (int)x;
					}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
					{
						x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
					}).Build(delegate(SliderModel x)
					{
						x.Tooltip = "The biome for this target biome range.";
					});
					return true;
				}
				return false;
			}

			public XElement SaveXml()
			{
				return new XElement("Biome", new XAttribute("biomeIndex", BiomeIndex), new XAttribute("range", Range));
			}
		}

		[SerializeField]
		[InspectorProperty(null, false, Order = 0)]
		private int _biomeIndex;

		[SerializeField]
		[InspectorProperty(null, false, Order = 10)]
		private BiomeRange[] _biomes;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data input value that, along with the biome range values, determines the biome(s) to which the source biome's strength should be re-assigned.")]
		private int _dataIndexInput;

		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Biome;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex)
		{
			if (member.Name == "_biomeIndex")
			{
				List<PlanetBiome> biomes = base.TerrainData.Biomes;
				groupModel.AddAndBuild(new SliderModel("Source Biome", () => _biomeIndex, delegate(float x)
				{
					_biomeIndex = (int)x;
				}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
				{
					x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
				}).Build(delegate(SliderModel x)
				{
					x.Tooltip = "The source biome whose strength will be re-assigned to the target biome(s).";
				});
				return true;
			}
			return false;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			PlanetVertexBiomeData planetVertexBiomeData = data.Biomes[_biomeIndex];
			float strength = planetVertexBiomeData.Strength;
			if ((double)strength <= 0.0001)
			{
				return;
			}
			planetVertexBiomeData.Strength = 0f;
			float num = (float)data.Data[_dataIndexInput];
			PlanetVertexBiomeData[] biomes = data.Biomes;
			for (int i = 0; i < _biomes.Length; i++)
			{
				BiomeRange biomeRange = _biomes[i];
				if (num < biomeRange.Range.MaxValue)
				{
					int num2 = i + 1;
					if (num2 != _biomes.Length && num > _biomes[num2].Range.MinValue)
					{
						BiomeRange biomeRange2 = _biomes[num2];
						float num3 = (num - biomeRange2.Range.MinValue) * biomeRange2.OneOverBlendRange * strength;
						biomes[biomeRange.BiomeIndex].Strength = strength - num3;
						biomes[biomeRange2.BiomeIndex].Strength = num3;
					}
					else
					{
						biomes[biomeRange.BiomeIndex].Strength = strength;
					}
					return;
				}
			}
			biomes[_biomes[_biomes.Length - 1].BiomeIndex].Strength = strength;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			if (_biomes.Length > base.TerrainData.Biomes.Count)
			{
				Debug.LogError($"Biome count '{_biomes.Length}' on vertex data modifier '{base.Name}' " + $"is greater than the expected biome count '{base.TerrainData.Biomes.Count}'.");
				Array.Resize(ref _biomes, base.TerrainData.Biomes.Count);
			}
			for (int i = 1; i < _biomes.Length; i++)
			{
				_biomes[i].OneOverBlendRange = 1f / (_biomes[i - 1].Range.MaxValue - _biomes[i].Range.MinValue);
			}
		}

		public void OnBiomeAdded(int index)
		{
			if (_biomeIndex >= index)
			{
				_biomeIndex++;
			}
			BiomeRange[] biomes = _biomes;
			foreach (BiomeRange biomeRange in biomes)
			{
				if (biomeRange.BiomeIndex >= index)
				{
					biomeRange.BiomeIndex++;
				}
			}
		}

		public void OnBiomeDeleted(int index)
		{
			if (_biomeIndex > index)
			{
				_biomeIndex--;
			}
			BiomeRange[] biomes = _biomes;
			foreach (BiomeRange biomeRange in biomes)
			{
				if (biomeRange.BiomeIndex > index)
				{
					biomeRange.BiomeIndex--;
				}
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("biomeIndex", _biomeIndex);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			_biomes = (_biomes ?? new BiomeRange[0]).OrderBy((BiomeRange x) => x.Range.MinValue).ToArray();
			BiomeRange[] biomes = _biomes;
			foreach (BiomeRange biomeRange in biomes)
			{
				xml.Add(biomeRange.SaveXml());
			}
		}

		protected virtual void OnValidate()
		{
			UpdateBiomeNames();
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_biomeIndex = (int)xml.Attribute("biomeIndex");
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_biomes = (from x in xml.Elements("Biome")
				select BiomeRange.CreateFromXml(x)).ToArray();
			UpdateBiomeNames();
		}

		private void UpdateBiomeNames()
		{
			if (_biomes == null)
			{
				return;
			}
			List<PlanetBiome> list = base.TerrainData?.Biomes;
			if (list == null)
			{
				list = GetComponentInParent<PlanetTerrainDataScript>()?.Biomes ?? new List<PlanetBiome>();
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (_biomes.Length <= i)
				{
					continue;
				}
				BiomeRange biomeRange = _biomes[i];
				PlanetBiome planetBiome = list[biomeRange.BiomeIndex];
				string value = planetBiome.Name;
				if (string.IsNullOrWhiteSpace(value))
				{
					value = planetBiome.name;
					if (string.IsNullOrWhiteSpace(value))
					{
						value = "Unnamed Biome";
					}
				}
				biomeRange.Name = value;
			}
		}
	}
}
