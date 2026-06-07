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
	public class AltitudeSlopeBiomeColorAndTexture : VertexDataPlanetModifier
	{
		[Serializable]
		private class AltitudeRange
		{
			public float AltitudeMax;

			public float AltitudeMin;

			public BiomeRange[] Biomes;

			public float BlendRange;

			public string Name;

			public static AltitudeRange CreateFromXml(XElement xml)
			{
				return new AltitudeRange
				{
					Name = (string)xml.Attribute("name"),
					AltitudeMin = (float)xml.Attribute("min"),
					AltitudeMax = (float)xml.Attribute("max"),
					Biomes = (from x in xml.Elements("Biome")
						select BiomeRange.CreateFromXml(x)).ToArray()
				};
			}

			public XElement SaveXml()
			{
				XElement xElement = new XElement("AltitudeRange", new XAttribute("name", Name), new XAttribute("min", AltitudeMin), new XAttribute("max", AltitudeMax));
				BiomeRange[] biomes = Biomes;
				foreach (BiomeRange biomeRange in biomes)
				{
					xElement.Add(biomeRange.SaveXml());
				}
				return xElement;
			}

			public Color UpdateSplatmapAndGetColor(float[] splatmapData, float biomeValue, float slope, float strength)
			{
				if (Biomes.Length == 1)
				{
					return Biomes[0].UpdateSplatmapAndGetColor(splatmapData, slope, strength);
				}
				for (int i = 0; i < Biomes.Length; i++)
				{
					int num = i + 1;
					if (biomeValue < Biomes[i].MaxValue)
					{
						if (num != Biomes.Length && biomeValue > Biomes[num].MinValue)
						{
							BiomeRange biomeRange = Biomes[i];
							BiomeRange biomeRange2 = Biomes[num];
							float num2 = (biomeValue - biomeRange2.MinValue) / (biomeRange.MaxValue - biomeRange2.MinValue);
							Color a = biomeRange.UpdateSplatmapAndGetColor(splatmapData, slope, strength * (1f - num2));
							Color b = biomeRange2.UpdateSplatmapAndGetColor(splatmapData, slope, strength * num2);
							return Color.LerpUnclamped(a, b, num2);
						}
						return Biomes[i].UpdateSplatmapAndGetColor(splatmapData, slope, strength);
					}
				}
				return Biomes[Biomes.Length - 1].UpdateSplatmapAndGetColor(splatmapData, slope, strength);
			}
		}

		[Serializable]
		private class BiomeRange
		{
			public float MaxValue;

			public float MinValue;

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

			public static BiomeRange CreateFromXml(XElement xml)
			{
				BiomeRange biomeRange = new BiomeRange
				{
					Name = (string)xml.Attribute("name"),
					MinValue = (float)xml.Attribute("min"),
					MaxValue = (float)xml.Attribute("max"),
					PrimaryColor = Utilities.GetColorAttribute(xml, "primaryColor", Color.red),
					SlopeColor = Utilities.GetColorAttribute(xml, "slopeColor", Color.red),
					_primaryTextureIndex = (((int?)xml.Attribute("primaryTexture")) ?? (-1)),
					_slopeTextureIndex = (((int?)xml.Attribute("slopeTexture")) ?? (-1)),
					SlopeBlend = (((MinMaxValue?)xml.Attribute("slopeBlend")) ?? new MinMaxValue(0.25f, 0.45f))
				};
				biomeRange.PrimaryTextureIndex = ((biomeRange._primaryTextureIndex >= 0 && biomeRange._primaryTextureIndex <= 7) ? biomeRange._primaryTextureIndex : 8);
				biomeRange.SlopeTextureIndex = ((biomeRange._slopeTextureIndex >= 0 && biomeRange._slopeTextureIndex <= 7) ? biomeRange._slopeTextureIndex : 8);
				biomeRange.SlopeBlendRange = biomeRange.SlopeBlend.MaxValue - biomeRange.SlopeBlend.MinValue;
				biomeRange._primaryColorLinear = biomeRange.PrimaryColor.linear;
				biomeRange._slopeColorLinear = biomeRange.SlopeColor.linear;
				return biomeRange;
			}

			public XElement SaveXml()
			{
				XElement xElement = new XElement("Biome", new XAttribute("name", Name), new XAttribute("min", MinValue), new XAttribute("max", MaxValue), new XAttribute("primaryTexture", _primaryTextureIndex), new XAttribute("slopeTexture", _slopeTextureIndex), new XAttribute("slopeBlend", SlopeBlend));
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

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Biome Value", false, true)]
		private int _biomeValueDataIndex;

		[SerializeField]
		private AltitudeRange[] _colors = new AltitudeRange[0];

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
			float biomeValue = (float)data.Data[_biomeValueDataIndex];
			float slope = 1f - (float)Vector3d.Dot(input.Position, input.Normal);
			if (_heightVarianceAmount != 0f && num > _heightVarianceBlend.MinValue)
			{
				float num2 = (float)data.Data[_heightVarianceDataIndex];
				if (num < _heightVarianceBlend.MaxValue)
				{
					num2 *= (num - _heightVarianceBlend.MinValue) / _heightVarianceBlendRange;
				}
				num += _heightVarianceAmount * num2;
			}
			for (int i = 0; i < _colors.Length; i++)
			{
				int num3 = i + 1;
				if (num < _colors[i].AltitudeMax)
				{
					if (num3 != _colors.Length && num > _colors[num3].AltitudeMin)
					{
						AltitudeRange obj = _colors[i];
						AltitudeRange altitudeRange = _colors[num3];
						float num4 = (num - altitudeRange.AltitudeMin) / altitudeRange.BlendRange;
						Color a = obj.UpdateSplatmapAndGetColor(data.SplatMapData, biomeValue, slope, 1f - num4);
						Color b = altitudeRange.UpdateSplatmapAndGetColor(data.SplatMapData, biomeValue, slope, num4);
						data.Color += Color.LerpUnclamped(a, b, num4);
					}
					else
					{
						data.Color += _colors[i].UpdateSplatmapAndGetColor(data.SplatMapData, biomeValue, slope, 1f);
					}
					return;
				}
			}
			data.Color += _colors[_colors.Length - 1].UpdateSplatmapAndGetColor(data.SplatMapData, biomeValue, slope, 1f);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_heightVarianceBlendRange = _heightVarianceBlend.MaxValue - _heightVarianceBlend.MinValue;
			for (int i = 1; i < _colors.Length; i++)
			{
				_colors[i].BlendRange = _colors[i - 1].AltitudeMax - _colors[i].AltitudeMin;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("biomeValueDataIndex", _biomeValueDataIndex);
			xml.SetAttributeValue("heightVarianceDataIndex", _heightVarianceDataIndex);
			xml.SetAttributeValue("heightVarianceAmount", _heightVarianceAmount);
			xml.SetAttributeValue("heightVarianceBlend", _heightVarianceBlend);
			_colors = _colors.OrderBy((AltitudeRange x) => x.AltitudeMin).ToArray();
			AltitudeRange[] colors = _colors;
			foreach (AltitudeRange obj in colors)
			{
				obj.Biomes = obj.Biomes.OrderBy((BiomeRange x) => x.MinValue).ToArray();
			}
			colors = _colors;
			foreach (AltitudeRange altitudeRange in colors)
			{
				xml.Add(altitudeRange.SaveXml());
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_biomeValueDataIndex = ((int?)xml.Attribute("biomeValueDataIndex")).GetValueOrDefault();
			_heightVarianceDataIndex = ((int?)xml.Attribute("heightVarianceDataIndex")).GetValueOrDefault();
			_heightVarianceAmount = ((float?)xml.Attribute("heightVarianceAmount")).GetValueOrDefault();
			_heightVarianceBlend = ((MinMaxValue?)xml.Attribute("heightVarianceBlend")).GetValueOrDefault();
			_colors = (from x in xml.Elements("AltitudeRange")
				select AltitudeRange.CreateFromXml(x)).ToArray();
			float planetScale = base.PlanetScale;
			_heightVarianceAmount *= planetScale;
			_heightVarianceBlend.MinValue *= planetScale;
			_heightVarianceBlend.MaxValue *= planetScale;
			AltitudeRange[] colors = _colors;
			foreach (AltitudeRange obj in colors)
			{
				obj.AltitudeMin *= planetScale;
				obj.AltitudeMax *= planetScale;
			}
		}
	}
}
