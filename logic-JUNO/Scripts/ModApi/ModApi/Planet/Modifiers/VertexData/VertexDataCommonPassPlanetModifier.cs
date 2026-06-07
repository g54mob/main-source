using System;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	public abstract class VertexDataCommonPassPlanetModifier : VertexDataPlanetModifier
	{
		private static VertexDataPlanetModifierPassType[] _allPassTypes = new VertexDataPlanetModifierPassType[5]
		{
			VertexDataPlanetModifierPassType.Biome,
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal,
			VertexDataPlanetModifierPassType.Final,
			VertexDataPlanetModifierPassType.Water
		};

		[SerializeField]
		private VertexDataPlanetModifierPassType _pass = VertexDataPlanetModifierPassType.Height;

		public override VertexDataPlanetModifierPassType Pass => _pass;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => _allPassTypes;

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("pass", _pass.ToString());
		}

		public override void SetPass(VertexDataPlanetModifierPassType pass, PlanetBiome biome)
		{
			if (SupportedPassTypes.Contains(pass))
			{
				_pass = pass;
				base.Biome = biome;
				return;
			}
			throw new ArgumentException($"Modifier {base.Name} does not support the '{pass}' pass");
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			string value = (string)xml.Attribute("pass");
			_pass = (string.IsNullOrEmpty(value) ? VertexDataPlanetModifierPassType.Height : ((VertexDataPlanetModifierPassType)Enum.Parse(typeof(VertexDataPlanetModifierPassType), value, ignoreCase: true)));
		}
	}
}
