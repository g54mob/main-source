using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Debug Visualize (Biomes)", "A planet modifier used in debugging to render each biome as a single flat color in order to easily identify the biomes of the celestial body.")]
	public class DebugVisualizeBiomes : VertexDataCommonPassPlanetModifier, ICustomObjectInspectorModel
	{
		private static Color[] _defaultColors = new Color[8]
		{
			new Color(0f, 0f, 0f),
			new Color(1f, 0f, 0f),
			new Color(1f, 1f, 0f),
			new Color(0f, 1f, 0f),
			new Color(0f, 1f, 1f),
			new Color(0f, 0f, 1f),
			new Color(1f, 0f, 1f),
			new Color(1f, 1f, 1f)
		};

		[SerializeField]
		private Color[] _biomeColors;

		public bool CreateGroup => false;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			List<PlanetBiome> biomes = base.TerrainData.Biomes;
			for (int i = 0; i < _biomeColors.Length; i++)
			{
				int index = i;
				string label = ((index < biomes.Count) ? (biomes[index].Name ?? "Unknown Biome") : "Unknown Biome");
				model.Add(new ColorModel(label, () => _biomeColors[index], delegate(Color x)
				{
					_biomeColors[index] = x;
				}));
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Color = Color.clear;
			data.DebugColorsOnly = true;
			PlanetVertexBiomeData[] biomes = data.Biomes;
			int num = System.Math.Min(_biomeColors.Length, biomes.Length);
			for (int i = 0; i < num; i++)
			{
				data.Color += _biomeColors[i].linear * biomes[i].Strength;
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			List<PlanetBiome> biomes = base.TerrainData.Biomes;
			_biomeColors = new Color[biomes.Count];
			for (int i = 0; i < biomes.Count; i++)
			{
				_biomeColors[i] = ((i < _defaultColors.Length) ? _defaultColors[i] : Color.white);
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			if (_biomeColors != null)
			{
				for (int i = 0; i < _biomeColors.Length; i++)
				{
					Utilities.SetColorAttribute(xml, "c" + i, _biomeColors[i]);
				}
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			List<Color> list = new List<Color>();
			int num = 0;
			for (XAttribute xAttribute = xml.Attribute("c" + num); xAttribute != null; xAttribute = xml.Attribute("c" + num))
			{
				list.Add(Utilities.GetColorAttribute(xAttribute, Color.clear));
				num++;
			}
			_biomeColors = list.ToArray();
		}
	}
}
