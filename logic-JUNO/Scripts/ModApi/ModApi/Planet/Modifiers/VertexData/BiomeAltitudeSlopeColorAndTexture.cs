using System;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common;
using ModApi.Common.Attributes;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Legacy Modifier - Do Not Use", IsHidden = true)]
	public class BiomeAltitudeSlopeColorAndTexture : VertexDataPlanetModifier
	{
		[Serializable]
		private class AltitudeRange
		{
			public float AltitudeMax;

			public float AltitudeMin;

			public string Name;

			public Color PrimaryColor;

			[NonSerialized]
			public int PrimaryTextureIndex;

			[MinMaxValue(0f, 0.5f)]
			public MinMaxValue SlopeBlend = new MinMaxValue(0.25f, 0.45f);

			[NonSerialized]
			public float SlopeBlendRange;

			public Color SlopeColor;

			[NonSerialized]
			public int SlopeTextureIndex;

			private Color _primaryColorLinear;

			[Range(-1f, 7f)]
			[SerializeField]
			private int _primaryTextureIndex;

			private Color _slopeColorLinear;

			[Range(-1f, 7f)]
			[SerializeField]
			private int _slopeTextureIndex;

			public static AltitudeRange CreateFromXml(XElement xml)
			{
				AltitudeRange altitudeRange = new AltitudeRange
				{
					Name = (string)xml.Attribute("name"),
					AltitudeMin = (float)xml.Attribute("min"),
					AltitudeMax = (float)xml.Attribute("max"),
					PrimaryColor = Utilities.GetColorAttribute(xml, "primaryColor", Color.red),
					SlopeColor = Utilities.GetColorAttribute(xml, "slopeColor", Color.red),
					_primaryTextureIndex = (((int?)xml.Attribute("primaryTexture")) ?? (-1)),
					_slopeTextureIndex = (((int?)xml.Attribute("slopeTexture")) ?? (-1)),
					SlopeBlend = (((MinMaxValue?)xml.Attribute("slopeBlend")) ?? new MinMaxValue(0.25f, 0.45f))
				};
				altitudeRange.PrimaryTextureIndex = ((altitudeRange._primaryTextureIndex >= 0 && altitudeRange._primaryTextureIndex <= 7) ? altitudeRange._primaryTextureIndex : 8);
				altitudeRange.SlopeTextureIndex = ((altitudeRange._slopeTextureIndex >= 0 && altitudeRange._slopeTextureIndex <= 7) ? altitudeRange._slopeTextureIndex : 8);
				altitudeRange.SlopeBlendRange = altitudeRange.SlopeBlend.MaxValue - altitudeRange.SlopeBlend.MinValue;
				altitudeRange._primaryColorLinear = altitudeRange.PrimaryColor.linear;
				altitudeRange._slopeColorLinear = altitudeRange.SlopeColor.linear;
				return altitudeRange;
			}

			public XElement SaveXml()
			{
				XElement xElement = new XElement("Altitude", new XAttribute("name", Name), new XAttribute("min", AltitudeMin), new XAttribute("max", AltitudeMax), new XAttribute("primaryTexture", _primaryTextureIndex), new XAttribute("slopeTexture", _slopeTextureIndex), new XAttribute("slopeBlend", SlopeBlend));
				Utilities.SetColorAttribute(xElement, "primaryColor", PrimaryColor);
				Utilities.SetColorAttribute(xElement, "slopeColor", SlopeColor);
				return xElement;
			}

			public Color UpdateSplatmapAndGetColor(float[] splatmapData, float slope, float strength)
			{
				Color result;
				if (slope <= SlopeBlend.MinValue)
				{
					result = _primaryColorLinear;
					splatmapData[PrimaryTextureIndex] += strength;
				}
				else if (slope >= SlopeBlend.MaxValue)
				{
					result = _slopeColorLinear;
					splatmapData[SlopeTextureIndex] += strength;
				}
				else
				{
					float num = (slope - SlopeBlend.MinValue) / SlopeBlendRange;
					result = Color.LerpUnclamped(_primaryColorLinear, _slopeColorLinear, num);
					splatmapData[PrimaryTextureIndex] += strength * (1f - num);
					splatmapData[SlopeTextureIndex] += strength * num;
				}
				return result;
			}
		}

		[Serializable]
		private class BiomeRange
		{
			public AltitudeRange[] Altitudes;

			public float BiomeMax;

			public float BiomeMin;

			[NonSerialized]
			public float BlendRange;

			public string Name;

			public static BiomeRange CreateFromXml(XElement xml)
			{
				return new BiomeRange
				{
					Name = (string)xml.Attribute("name"),
					BiomeMin = (float)xml.Attribute("min"),
					BiomeMax = (float)xml.Attribute("max"),
					Altitudes = (from x in xml.Elements("Altitude")
						select AltitudeRange.CreateFromXml(x)).ToArray()
				};
			}

			public XElement SaveXml()
			{
				XElement xElement = new XElement("Biome", new XAttribute("name", Name), new XAttribute("min", BiomeMin), new XAttribute("max", BiomeMax));
				AltitudeRange[] altitudes = Altitudes;
				foreach (AltitudeRange altitudeRange in altitudes)
				{
					xElement.Add(altitudeRange.SaveXml());
				}
				return xElement;
			}

			public Color UpdateSplatmapAndGetColor(float[] splatmapData, float height, float slope, float strength)
			{
				if (Altitudes.Length == 1)
				{
					return Altitudes[0].UpdateSplatmapAndGetColor(splatmapData, slope, strength);
				}
				for (int i = 0; i < Altitudes.Length; i++)
				{
					int num = i + 1;
					if (height < Altitudes[i].AltitudeMax)
					{
						if (num != Altitudes.Length && height > Altitudes[num].AltitudeMin)
						{
							AltitudeRange altitudeRange = Altitudes[i];
							AltitudeRange altitudeRange2 = Altitudes[num];
							float num2 = (height - altitudeRange2.AltitudeMin) / (altitudeRange.AltitudeMax - altitudeRange2.AltitudeMin);
							Color a = altitudeRange.UpdateSplatmapAndGetColor(splatmapData, slope, strength * (1f - num2));
							Color b = altitudeRange2.UpdateSplatmapAndGetColor(splatmapData, slope, strength * num2);
							return Color.LerpUnclamped(a, b, num2);
						}
						return Altitudes[i].UpdateSplatmapAndGetColor(splatmapData, slope, strength);
					}
				}
				return Altitudes[Altitudes.Length - 1].UpdateSplatmapAndGetColor(splatmapData, slope, strength);
			}
		}

		[SerializeField]
		private BiomeRange[] _biomes = new BiomeRange[0];

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Biome Value", false, true)]
		private int _biomeValueDataIndex;

		[SerializeField]
		private float _heightVarianceAmount;

		[SerializeField]
		private MinMaxValue _heightVarianceBlend;

		[NonSerialized]
		private float _heightVarianceBlendRange;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Height Variance", false, true)]
		private int _heightVarianceDataIndex;

		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Final;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (data.DebugColorsOnly)
			{
				return;
			}
			float num = (float)data.Height;
			float num2 = (float)data.Data[_biomeValueDataIndex];
			float slope = 1f - (float)Vector3d.Dot(input.Position, input.Normal);
			if (_heightVarianceAmount != 0f && num > _heightVarianceBlend.MinValue)
			{
				float num3 = (float)data.Data[_heightVarianceDataIndex];
				if (num < _heightVarianceBlend.MaxValue)
				{
					num3 *= (num - _heightVarianceBlend.MinValue) / _heightVarianceBlendRange;
				}
				num += _heightVarianceAmount * num3;
			}
			for (int i = 0; i < _biomes.Length; i++)
			{
				int num4 = i + 1;
				if (num2 < _biomes[i].BiomeMax)
				{
					if (num4 != _biomes.Length && num2 > _biomes[num4].BiomeMin)
					{
						BiomeRange obj = _biomes[i];
						BiomeRange biomeRange = _biomes[num4];
						float num5 = (num2 - biomeRange.BiomeMin) / biomeRange.BlendRange;
						Color a = obj.UpdateSplatmapAndGetColor(data.SplatMapData, num, slope, 1f - num5);
						Color b = biomeRange.UpdateSplatmapAndGetColor(data.SplatMapData, num, slope, num5);
						data.Color += Color.LerpUnclamped(a, b, num5);
					}
					else
					{
						data.Color += _biomes[i].UpdateSplatmapAndGetColor(data.SplatMapData, num, slope, 1f);
					}
					return;
				}
			}
			data.Color += _biomes[_biomes.Length - 1].UpdateSplatmapAndGetColor(data.SplatMapData, num, slope, 1f);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_heightVarianceBlendRange = _heightVarianceBlend.MaxValue - _heightVarianceBlend.MinValue;
			for (int i = 1; i < _biomes.Length; i++)
			{
				_biomes[i].BlendRange = _biomes[i - 1].BiomeMax - _biomes[i].BiomeMin;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("biomeValueDataIndex", _biomeValueDataIndex);
			xml.SetAttributeValue("heightVarianceDataIndex", _heightVarianceDataIndex);
			xml.SetAttributeValue("heightVarianceAmount", _heightVarianceAmount);
			xml.SetAttributeValue("heightVarianceBlend", _heightVarianceBlend);
			_biomes = _biomes.OrderBy((BiomeRange x) => x.BiomeMin).ToArray();
			BiomeRange[] biomes = _biomes;
			foreach (BiomeRange obj in biomes)
			{
				obj.Altitudes = obj.Altitudes.OrderBy((AltitudeRange x) => x.AltitudeMin).ToArray();
			}
			biomes = _biomes;
			foreach (BiomeRange biomeRange in biomes)
			{
				xml.Add(biomeRange.SaveXml());
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_biomeValueDataIndex = ((int?)xml.Attribute("biomeValueDataIndex")).GetValueOrDefault();
			_heightVarianceDataIndex = ((int?)xml.Attribute("heightVarianceDataIndex")).GetValueOrDefault();
			_heightVarianceAmount = ((float?)xml.Attribute("heightVarianceAmount")).GetValueOrDefault();
			_heightVarianceBlend = ((MinMaxValue?)xml.Attribute("heightVarianceBlend")).GetValueOrDefault();
			_biomes = (from x in xml.Elements("Biome")
				select BiomeRange.CreateFromXml(x)).ToArray();
			float planetScale = base.PlanetScale;
			_heightVarianceAmount *= planetScale;
			_heightVarianceBlend.MinValue *= planetScale;
			_heightVarianceBlend.MaxValue *= planetScale;
			BiomeRange[] biomes = _biomes;
			for (int num = 0; num < biomes.Length; num++)
			{
				AltitudeRange[] altitudes = biomes[num].Altitudes;
				foreach (AltitudeRange obj in altitudes)
				{
					obj.AltitudeMin *= planetScale;
					obj.AltitudeMax *= planetScale;
				}
			}
		}
	}
}
