using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Hemisphere Biome Swap", "A planet modifier that takes a source biome in the southern hemisphere and swaps it out with a target biome. This can be useful in situations where you have a single polar biome and want to split it into two separate (northern and southern) polar biomes.")]
	public class HemisphereBiomeSwap : VertexDataPlanetModifier, ICustomObjectInspectorModel, IBiomeListModifiedHandler
	{
		[SerializeField]
		private int _sourceBiomeIndex;

		[SerializeField]
		private int _targetBiomeIndex;

		public bool CreateGroup => false;

		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Biome;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			List<PlanetBiome> biomes = base.TerrainData.Biomes;
			model.AddAndBuild(new SliderModel("Source Biome", () => _sourceBiomeIndex, delegate(float x)
			{
				_sourceBiomeIndex = (int)x;
			}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The biome in the southern hemisphere to be replaced with the target biome.";
			});
			model.AddAndBuild(new SliderModel("Target Biome", () => _targetBiomeIndex, delegate(float x)
			{
				_targetBiomeIndex = (int)x;
			}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The biome to replace the source biome in the southern hemisphere.";
			});
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (input.Position.y < 0.0)
			{
				PlanetVertexBiomeData planetVertexBiomeData = data.Biomes[_sourceBiomeIndex];
				data.Biomes[_targetBiomeIndex].Strength = planetVertexBiomeData.Strength;
				planetVertexBiomeData.Strength = 0f;
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public void OnBiomeAdded(int index)
		{
			if (_sourceBiomeIndex >= index)
			{
				_sourceBiomeIndex++;
			}
			if (_targetBiomeIndex >= index)
			{
				_targetBiomeIndex++;
			}
		}

		public void OnBiomeDeleted(int index)
		{
			if (_sourceBiomeIndex > index)
			{
				_sourceBiomeIndex--;
			}
			if (_targetBiomeIndex > index)
			{
				_targetBiomeIndex--;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("sourceBiomeIndex", _sourceBiomeIndex);
			xml.SetAttributeValue("targetBiomeIndex", _targetBiomeIndex);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_sourceBiomeIndex = (int)xml.Attribute("sourceBiomeIndex");
			_targetBiomeIndex = (int)xml.Attribute("targetBiomeIndex");
		}
	}
}
