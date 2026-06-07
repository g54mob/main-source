using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Legacy Modifier - Do Not Use", IsHidden = true)]
	public class AltitudeColorGradient : VertexDataPlanetModifier
	{
		private float _altitudeRange;

		[SerializeField]
		private Gradient _color;

		[SerializeField]
		private Gradient _colorLinear;

		[SerializeField]
		private float _maxAltitude;

		[SerializeField]
		private float _minAltitude;

		[Range(-1f, 7f)]
		[SerializeField]
		private int _textureIndex = -1;

		private int _textureIndexSplatmap;

		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Final;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public override QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			QuadMeshDataFlags quadMeshDataFlags = QuadMeshDataFlags.Color;
			if (_textureIndexSplatmap != 8)
			{
				quadMeshDataFlags |= QuadMeshDataFlags.UV | QuadMeshDataFlags.UV2;
			}
			return quadMeshDataFlags;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (!data.DebugColorsOnly)
			{
				data.Color += _colorLinear.Evaluate(((float)data.Height - _minAltitude) / _altitudeRange);
				data.SplatMapData[_textureIndexSplatmap] = 1f;
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_altitudeRange = Mathf.Max(1E-05f, _maxAltitude - _minAltitude);
			_textureIndexSplatmap = _textureIndex;
			if (_textureIndexSplatmap > 7 || _textureIndexSplatmap < 0)
			{
				_textureIndexSplatmap = 8;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("minAltitude", _minAltitude);
			xml.SetAttributeValue("maxAltitude", _maxAltitude);
			xml.SetAttributeValue("textureIndex", _textureIndex);
			Utilities.SetGradientAttribute(xml, "color", includeAlphaKeys: true, _color);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_minAltitude = (float)xml.Attribute("minAltitude") * base.PlanetScale;
			_maxAltitude = (float)xml.Attribute("maxAltitude") * base.PlanetScale;
			_textureIndex = ((int?)xml.Attribute("textureIndex")) ?? (-1);
			_color = Utilities.GetGradientAttribute(xml, "color", includeAlphaKeys: true);
			_colorLinear = _color.ToLinear();
		}
	}
}
