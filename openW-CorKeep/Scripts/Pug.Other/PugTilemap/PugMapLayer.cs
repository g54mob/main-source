using System.Collections.Generic;
using PugTilemap.Quads;
using PugTilemap.Workshop;
using UnityEngine;

namespace PugTilemap
{
	public class PugMapLayer : MonoBehaviour
	{
		public LayerName layerDefKey;

		public PugMapLayerMesh mesh;

		private PugMap _map;

		private PugMultiMap _multiMap;

		public int tilesetKey = -1;

		private QuadGenerator _def;

		private QuadCache quadCache;

		public PugMap map
		{
			get
			{
				if (_map == null)
				{
					_map = GetComponentInParent<PugMap>();
				}
				return _map;
			}
		}

		public PugMultiMap multiMap
		{
			get
			{
				if (_multiMap == null)
				{
					_multiMap = GetComponentInParent<PugMultiMap>();
				}
				return _multiMap;
			}
		}

		public PugMapTileset tileset => TilesetTypeUtility.GetTileset(tilesetKey);

		public QuadGenerator def
		{
			get
			{
				if (_def != null && Application.isPlaying)
				{
					return _def;
				}
				return _def = tileset.GetDef(layerDefKey);
			}
		}

		public int triangleCount
		{
			get
			{
				if (!(mesh == null))
				{
					return mesh.triangleCount;
				}
				return 0;
			}
		}

		private void InitMesh()
		{
			QuadGenerator quadGenerator = def;
			bool flag = quadGenerator != null && quadGenerator.meshFillType == QuadGenerator.FillType.CustomFill;
			Texture2D texture2D = null;
			Texture2D emissiveTexture = null;
			Texture2D effectMaskTexture = null;
			Texture2D normalsTexture = null;
			Material material = null;
			if (tilesetKey != -1)
			{
				if (def.isUsingFullAdaptiveTexture)
				{
					texture2D = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.REGULAR);
					emissiveTexture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.EMISSIVE);
					effectMaskTexture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.EFFECT_MASK);
					normalsTexture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.NORMALS);
				}
				else
				{
					texture2D = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.REGULAR);
					emissiveTexture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.EMISSIVE);
					effectMaskTexture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.EFFECT_MASK);
					normalsTexture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.NORMALS);
				}
				material = TilesetTypeUtility.GetEditorOverrideMaterial(tilesetKey, def.layerName);
				if (material == null)
				{
					material = TilesetTypeUtility.GetOverrideMaterial(tilesetKey, def.layerName);
				}
				if (material == null)
				{
					material = def.overrideEditorMaterial;
				}
				if (material == null)
				{
					material = def.overrideMaterial;
				}
				if (material == null)
				{
					material = tileset.tilesetMaterial;
				}
			}
			texture2D = ((texture2D == null) ? tileset.tilesetTexture : texture2D);
			mesh.Init(flag ? def.customTexture : texture2D, emissiveTexture, effectMaskTexture, normalsTexture, flag ? def.customMaterial : material, def);
		}

		public void Init()
		{
			if (def != null && def.HasTileset(tilesetKey))
			{
				if (def.hasQuads)
				{
					GameObject gameObject = map.NewInternalMapGO(def.layerName.ToString() + " mesh", base.transform);
					mesh = gameObject.AddComponent<PugMapLayerMesh>();
					InitMesh();
				}
				tileset.InitLookupTables();
				quadCache = new QuadCache();
			}
		}

		public void Build(List<TileData>[,] tileLookup, HashSet<Vector3Int> tilesChangedSinceLastBuild, BoundsInt bounds, bool onlyResolveQuads = false)
		{
			if (quadCache == null)
			{
				quadCache = new QuadCache();
			}
			if (!def.hasQuads || !def.HasTileset(tilesetKey))
			{
				return;
			}
			if (def.targetTile == TileType.none)
			{
				Debug.LogWarning("You shouldn't extrude from none!");
				return;
			}
			if (map.GetLayer(tilesetKey, def.targetTile) == null)
			{
				Debug.LogWarning("No parent layer");
				return;
			}
			quadCache.ResolveQuads(multiMap, map, this, tileLookup, tilesChangedSinceLastBuild, bounds);
			if (!onlyResolveQuads)
			{
				if (mesh != null && !Application.isPlaying)
				{
					InitMesh();
				}
				mesh.BuildMesh(quadCache, bounds, def, multiMap, map, def.dataTile);
				mesh.gameObject.layer = def.layer;
			}
		}
	}
}
