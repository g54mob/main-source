using System;
using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Add Biome", "A vertex data planet modifier that runs in the biome pass and adds a biome on top of any existing biomes. The new biome will blend with existing biomes but it has full priority, so 100% of the input value is added to the strength of the specified biome being added.")]
	public class AddBiome : VertexDataPlanetModifier, ICustomObjectInspectorModel, IBiomeListModifiedHandler
	{
		[SerializeField]
		private int _biomeIndex;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The input data that defines the strength of the biome to add. These values should be in the range of 0 to 1.")]
		private int _dataIndexInput;

		public bool CreateGroup => false;

		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Biome;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			int count = base.TerrainData.Biomes.Count;
			model.AddAndBuild(new SliderModel("Biome Index", () => _biomeIndex, delegate(float x)
			{
				_biomeIndex = (int)x;
			}, 0f, count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float value) => (int)value + " : " + (base.TerrainData.Biomes.ElementAtOrDefault((int)value)?.Name ?? "Not Defined");
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The index of the biome to add, with the strength of this biome defined by the modifier input value.";
			});
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			float num = (float)data.Data[_dataIndexInput];
			if (!(num > 0f))
			{
				return;
			}
			PlanetVertexBiomeData[] biomes = data.Biomes;
			float strength = biomes[_biomeIndex].Strength;
			float num2 = strength + num;
			if (num2 >= 1f)
			{
				for (int i = 0; i < biomes.Length; i++)
				{
					biomes[i].Strength = ((_biomeIndex == i) ? 1f : 0f);
				}
				return;
			}
			float num3 = (1f - num) / (1f - strength);
			for (int j = 0; j < biomes.Length; j++)
			{
				if (_biomeIndex == j)
				{
					biomes[j].Strength = num2;
				}
				else
				{
					biomes[j].Strength *= num3;
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public void OnBiomeAdded(int index)
		{
			if (_biomeIndex >= index)
			{
				_biomeIndex++;
			}
		}

		public void OnBiomeDeleted(int index)
		{
			if (_biomeIndex > index)
			{
				_biomeIndex--;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			xml.SetAttributeValue("biomeIndex", _biomeIndex);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_biomeIndex = (int)xml.Attribute("biomeIndex");
		}
	}
}
