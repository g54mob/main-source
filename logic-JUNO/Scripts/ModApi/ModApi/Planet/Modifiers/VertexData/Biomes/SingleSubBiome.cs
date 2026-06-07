using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Sub-Biomes (Single)", "A modifier that runs within a biome and defines the single sub-biome it contains.")]
	public class SingleSubBiome : VertexDataCommonPassPlanetModifier, ISubBiomePlanetModifier
	{
		[SerializeField]
		[InspectorGroup(null)]
		[InspectorProperty(null, false, Label = "Sub-Biome Data", Order = 0)]
		private SubBiomeData _subBiome;

		public SubBiomeData SubBiome => _subBiome;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[3]
		{
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal,
			VertexDataPlanetModifierPassType.Final
		};

		public override VertexDataType VertexDataType => VertexDataType.Biome;

		public void GetSubBiomes(List<SubBiomeData> list)
		{
			list.Add(_subBiome);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			PlanetVertexBiomeData obj = data.CommonData.Biomes[data.BiomeIndex];
			float strength = obj.Strength;
			obj.PrimarySubBiome = _subBiome;
			obj.PrimarySubBiomeStrength = strength;
			obj.SecondarySubBiome = null;
			obj.SecondarySubBiomeStrength = 0f;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support non-biome-specific vertex data.");
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_subBiome = new SubBiomeData();
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			if (_subBiome != null)
			{
				xml.Add(_subBiome.SaveXml(new XElement("SubBiomeData")));
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_subBiome = SubBiomeData.CreateFromXml(xml.Element("SubBiomeData"));
		}
	}
}
