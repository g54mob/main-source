using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap.Quads;
using UnityEngine;

namespace PugTilemap.Workshop
{
	[CreateAssetMenu(fileName = "TilesetBank", menuName = "Pug/PugMap/MapWorkshopTilesetBank", order = 2)]
	public class MapWorkshopTilesetBank : ScriptableObject
	{
		[Serializable]
		public class Tileset
		{
			public string friendlyName;

			public Sprite icon;

			public PugMapTileset layers;

			[ArrayElementTitle("layerName")]
			public List<TileTypeOverrideMaterial> overrideMaterials;

			[ArrayElementTitle("layerName")]
			public List<TileTypeOverrideParticles> overrideParticles;

			public TilesetTextures tilesetTextures;

			public SerializableDictionary<LayerName, TilesetTextures> adaptiveTilesetTextures;
		}

		[Serializable]
		public class TilesetTextures
		{
			public Texture2D texture;

			public Texture2D emissiveTexture;

			public Texture2D effectMaskTexture;

			public Texture2D normalsTexture;

			public List<SeasonalTexture> seasonalTextures;

			public Texture2D GetTexture(TextureType type)
			{
				return type switch
				{
					TextureType.EMISSIVE => emissiveTexture, 
					TextureType.EFFECT_MASK => effectMaskTexture, 
					TextureType.NORMALS => normalsTexture, 
					_ => texture, 
				};
			}

			public void SetTexture(TextureType type, Texture2D texture)
			{
				switch (type)
				{
				case TextureType.REGULAR:
					this.texture = texture;
					break;
				case TextureType.EMISSIVE:
					emissiveTexture = texture;
					break;
				case TextureType.EFFECT_MASK:
					effectMaskTexture = texture;
					break;
				case TextureType.NORMALS:
					normalsTexture = texture;
					break;
				}
			}
		}

		[Serializable]
		public class SeasonalTexture
		{
			public Season season;

			public Texture2D texture;
		}

		[Serializable]
		public class TileTypeOverrideParticles
		{
			public LayerName layerName;

			public ParticleSystem overrideParticlePrefab;
		}

		[Serializable]
		public class TileTypeOverrideMaterial
		{
			public LayerName layerName;

			public Material overrideMaterial;

			public Material editorOverrideMaterial;

			public List<SeasonalTileTypeOverrideMaterial> seasonalOverrideMaterial;
		}

		[Serializable]
		public class SeasonalTileTypeOverrideMaterial
		{
			public Season season;

			public Material overrideMaterial;
		}

		public List<Tileset> tilesets;

		public Texture2D GetAdaptiveTexture(int tilesetIndex, LayerName layerKey, TextureType textureType)
		{
			if (!tilesets[tilesetIndex].adaptiveTilesetTextures.TryGetValue(layerKey, out var value))
			{
				return null;
			}
			if (Application.isPlaying && textureType == TextureType.REGULAR && Manager.prefs.season != Season.None && value.seasonalTextures != null)
			{
				foreach (SeasonalTexture seasonalTexture in value.seasonalTextures)
				{
					if (seasonalTexture.season == Manager.prefs.season && seasonalTexture.texture != null)
					{
						return seasonalTexture.texture;
					}
				}
			}
			return value.GetTexture(textureType);
		}

		public void SetAdaptiveTexture(int tilesetIndex, LayerName layerKey, Season season, Texture2D texture, TextureType textureType)
		{
			if (!tilesets[tilesetIndex].adaptiveTilesetTextures.TryGetValue(layerKey, out var value))
			{
				value = new TilesetTextures();
				tilesets[tilesetIndex].adaptiveTilesetTextures.Add(layerKey, value);
			}
			if (season == Season.None)
			{
				value.SetTexture(textureType, texture);
			}
			else
			{
				if (textureType != TextureType.REGULAR)
				{
					return;
				}
				bool flag = false;
				if (value.seasonalTextures == null)
				{
					value.seasonalTextures = new List<SeasonalTexture>();
				}
				foreach (SeasonalTexture seasonalTexture in value.seasonalTextures)
				{
					if (seasonalTexture.season == season)
					{
						seasonalTexture.texture = texture;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					value.seasonalTextures.Add(new SeasonalTexture
					{
						season = season,
						texture = texture
					});
				}
			}
		}
	}
}
