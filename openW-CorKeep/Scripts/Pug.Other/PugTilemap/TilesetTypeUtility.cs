using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap.Quads;
using PugTilemap.Workshop;
using UnityEngine;

namespace PugTilemap
{
	public static class TilesetTypeUtility
	{
		public struct TilesetAndLayer
		{
			public int tilesetIndex;

			public LayerName layerName;
		}

		[ClearOnReload]
		private static MapWorkshopTilesetBank _tilesetBank;

		private static MapWorkshopTilesetBank tilesetBank
		{
			get
			{
				if (_tilesetBank == null)
				{
					_tilesetBank = Resources.Load<MapWorkshopTilesetBank>("MapWorkshop/MapWorkshopTilesetBank");
					if (_tilesetBank == null)
					{
						MapWorkshopTilesetBank[] array = Resources.FindObjectsOfTypeAll<MapWorkshopTilesetBank>();
						_tilesetBank = ((array != null) ? array[0] : null);
					}
					if (_tilesetBank != null)
					{
						foreach (MapWorkshopTilesetBank.Tileset tileset in _tilesetBank.tilesets)
						{
							tileset.layers?.InitLookupTables();
						}
					}
				}
				return _tilesetBank;
			}
		}

		public static PugMapTileset GetTileset(int index)
		{
			return tilesetBank.tilesets[index].layers;
		}

		public static List<MapWorkshopTilesetBank.Tileset> GetTilesets()
		{
			return tilesetBank.tilesets;
		}

		public static int GetNumberOfAvailableTilesets()
		{
			return tilesetBank?.tilesets.Count ?? 0;
		}

		public static MapWorkshopTilesetBank.TilesetTextures GetTilesetTextures(int tilesetIndex)
		{
			return tilesetBank.tilesets[tilesetIndex].tilesetTextures;
		}

		public static Texture2D GetTexture(int tilesetIndex, LayerName layerName, TextureType textureType)
		{
			if (Application.isPlaying && textureType == TextureType.REGULAR && Manager.prefs.season != Season.None && tilesetBank.tilesets[tilesetIndex].tilesetTextures.seasonalTextures != null)
			{
				foreach (MapWorkshopTilesetBank.SeasonalTexture seasonalTexture in tilesetBank.tilesets[tilesetIndex].tilesetTextures.seasonalTextures)
				{
					if (seasonalTexture.season == Manager.prefs.season && seasonalTexture.texture != null)
					{
						return seasonalTexture.texture;
					}
				}
			}
			return textureType switch
			{
				TextureType.EMISSIVE => tilesetBank.tilesets[tilesetIndex].tilesetTextures.emissiveTexture, 
				TextureType.EFFECT_MASK => tilesetBank.tilesets[tilesetIndex].tilesetTextures.effectMaskTexture, 
				TextureType.NORMALS => tilesetBank.tilesets[tilesetIndex].tilesetTextures.normalsTexture, 
				_ => tilesetBank.tilesets[tilesetIndex].tilesetTextures.texture, 
			};
		}

		public static Texture2D GetAdaptiveTexture(int tilesetIndex, LayerName layerName, TextureType textureType)
		{
			return tilesetBank.GetAdaptiveTexture(tilesetIndex, layerName, textureType);
		}

		private static TilesetAndLayer GetOverrideTextureTilesetAndLayer(int tilesetIndex, LayerName layerName)
		{
			TilesetAndLayer result = new TilesetAndLayer
			{
				tilesetIndex = tilesetIndex,
				layerName = layerName
			};
			if (Application.isPlaying && Manager.prefs.season == Season.Halloween)
			{
				result.tilesetIndex = 1;
			}
			return result;
		}

		public static void SetAdaptiveTexture(int tilesetIndex, LayerName layerName, Season season, Texture2D texture, TextureType textureType)
		{
			tilesetBank.SetAdaptiveTexture(tilesetIndex, layerName, season, texture, textureType);
		}

		public static void ClearAdaptiveTexturesDictionary(int tilesetIndex)
		{
			tilesetBank.tilesets[tilesetIndex].adaptiveTilesetTextures = new SerializableDictionary<LayerName, MapWorkshopTilesetBank.TilesetTextures>();
		}

		public static Material GetOverrideMaterial(int tilesetIndex, LayerName layerName)
		{
			Material result = null;
			MapWorkshopTilesetBank.Tileset tileset = tilesetBank.tilesets[tilesetIndex];
			if (tileset != null)
			{
				for (int i = 0; i < tileset.overrideMaterials.Count; i++)
				{
					if (tileset.overrideMaterials[i].layerName != layerName)
					{
						continue;
					}
					result = tileset.overrideMaterials[i].overrideMaterial;
					for (int j = 0; j < tileset.overrideMaterials[i].seasonalOverrideMaterial.Count; j++)
					{
						if (Application.isPlaying && tileset.overrideMaterials[i].seasonalOverrideMaterial[j].season == Manager.prefs.season)
						{
							result = tileset.overrideMaterials[i].seasonalOverrideMaterial[j].overrideMaterial;
							break;
						}
					}
					break;
				}
			}
			return result;
		}

		public static Material GetEditorOverrideMaterial(int tilesetIndex, LayerName tileName)
		{
			MapWorkshopTilesetBank.Tileset tileset = tilesetBank.tilesets[tilesetIndex];
			if (tileset != null)
			{
				for (int i = 0; i < tileset.overrideMaterials.Count; i++)
				{
					if (tileset.overrideMaterials[i].layerName == tileName)
					{
						return tileset.overrideMaterials[i].editorOverrideMaterial;
					}
				}
			}
			return null;
		}

		public static ParticleSystem GetOverrideParticles(int tilesetIndex, LayerName tileName)
		{
			MapWorkshopTilesetBank.Tileset tileset = tilesetBank.tilesets[tilesetIndex];
			if (tileset != null)
			{
				for (int i = 0; i < tileset.overrideParticles.Count; i++)
				{
					if (tileset.overrideParticles[i].layerName == tileName)
					{
						return tileset.overrideParticles[i].overrideParticlePrefab;
					}
				}
			}
			return null;
		}

		public static Sprite GetIcon(int index)
		{
			return tilesetBank.tilesets[index].icon;
		}

		public static string GetFriendlyName(int index)
		{
			return tilesetBank.tilesets[index].friendlyName;
		}
	}
}
