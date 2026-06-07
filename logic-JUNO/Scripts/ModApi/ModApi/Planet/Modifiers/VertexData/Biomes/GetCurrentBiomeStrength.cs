using System;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Get Biome Strength (Current)", "A planet modifier that runs in a biome specific pass, gets the strength of that biome, and stores it in a data ouptput.")]
	public class GetCurrentBiomeStrength : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The output data to contain the strength of the current biome (typically a value between 0 and 1).")]
		private int _dataIndexOutput;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[4]
		{
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal,
			VertexDataPlanetModifierPassType.Final,
			VertexDataPlanetModifierPassType.Water
		};

		public override VertexDataType VertexDataType => VertexDataType.Biome;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support non-biome-specific vertex data.");
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Data[_dataIndexOutput] = data.CommonData.Biomes[data.BiomeIndex].Strength;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
		}
	}
}
