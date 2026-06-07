using System;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Get Common Pass Data", "A planet modifier that runs in a biome specific pass to get a data channel from the common pass and store it in the biome specific data channel.")]
	public class GetCommonData : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The data from the common pass that is to be stored in the biome specific pass data channel.")]
		private int _dataIndexInput;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The biome specific pass data output.")]
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
			data.Data[_dataIndexOutput] = data.CommonData.Data[_dataIndexInput];
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInput", _dataIndexInput);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInput = (int)xml.Attribute("dataIndexInput");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
		}
	}
}
