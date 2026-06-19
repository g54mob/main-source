using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap.Grid;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace PugTilemap.Quads
{
	[Serializable]
	public class QuadGenerator
	{
		public enum ColliderType
		{
			NoCollider = 0,
			OptimizedBlock = 1,
			SquareBlock = 2,
			OptimizedTrigger = 3,
			SquareTrigger = 4
		}

		public enum FillType
		{
			NoFill = 0,
			RandomFill = 1,
			AdaptativeFill = 2,
			AdaptativeExtrude = 3,
			CustomFill = 4,
			RandomFillEditorOnly = 5
		}

		public enum TileFace
		{
			TOP = 0,
			BOTTOM = 1,
			FRONT = 2,
			BACK = 3,
			LEFT = 4,
			RIGHT = 5
		}

		[Serializable]
		public class SpriteUVS
		{
			public List<Rect> spriteUVS = new List<Rect>();
		}

		public enum AdaptiveLUTType
		{
			NineWay = 0,
			GeneratedTexture = 1,
			SubTile = 2
		}

		public const byte kSheetUnsetCell = 0;

		public const byte kSheetPlaceholderCell = 128;

		public LayerName layerName;

		[Tooltip("Any layers with a non-none data tile will have a data bitmap.")]
		[FormerlySerializedAs("tile")]
		public TileType dataTile;

		[NonSerialized]
		public readonly List<QuadGenerator> layersDependentOnMyData = new List<QuadGenerator>();

		[SerializeField]
		[Layer]
		public int layer;

		[SerializeField]
		[SortingLayer]
		public int sortingLayer;

		public bool excludeFromTilesetInstead;

		public List<Tileset> onlyDrawForTilesets;

		public List<Tileset> dontDrawForTilesets;

		public Material overrideMaterial;

		public Material overrideEditorMaterial;

		public Texture2D emissiveTexture;

		public ParticleSystem meshParticlePrefab;

		public ShadowCastingMode shadowCastingMode = ShadowCastingMode.On;

		public bool receiveShadows = true;

		public List<TileFace> tileFaces;

		public Vector3 offset;

		public float heightStretch;

		public float padding;

		public bool skewInTopVertices;

		public bool layerIgnoresVertexOffsets;

		public bool hideInteriorFaces;

		public bool hideUnderNonTransparentWall;

		public bool actAsCeilingLight;

		public CeilingLightRenderOrderPass ceilingLightRenderOrderPass;

		public TileType overrideTileTypeForMeshAdjustments = TileType.__illegal__;

		public FillType meshFillType;

		public Vector2Int quadSize = new Vector2Int(16, 16);

		public bool ignoreDiagonalQuads;

		public bool ignoreVerticalAndDiagonalQuads;

		public bool ignoreVerticalQuads;

		public bool ignoreHorizontalQuads;

		public bool generateFullAdaptiveTexture;

		public bool onlyAdaptToOwnTileset;

		public TileType dontAdaptIfTilePresent;

		public List<TileType> drawOn = new List<TileType>();

		public TileType targetTile;

		public const int MAX_STATES = 3;

		public SpriteUVS[] allSpriteUVs = new SpriteUVS[3]
		{
			new SpriteUVS(),
			new SpriteUVS(),
			new SpriteUVS()
		};

		public byte[] generatedTextureAdaptativeDirBitsAvailable = new byte[3];

		public byte[] adaptativeDirBitsAvailable = new byte[3];

		public byte[] adaptativeSubtileDirBitsAvailable = new byte[3];

		public AdaptativeSpriteLookupTable[] generatedTextureAdaptativeSpriteLookupTable = new AdaptativeSpriteLookupTable[3]
		{
			new AdaptativeSpriteLookupTable(null),
			new AdaptativeSpriteLookupTable(null),
			new AdaptativeSpriteLookupTable(null)
		};

		public AdaptativeSpriteLookupTable[] adaptativeSpriteLookupTable = new AdaptativeSpriteLookupTable[3]
		{
			new AdaptativeSpriteLookupTable(null),
			new AdaptativeSpriteLookupTable(null),
			new AdaptativeSpriteLookupTable(null)
		};

		public AdaptativeSpriteLookupTable[] adaptativeSubtileSpriteLookupTable = new AdaptativeSpriteLookupTable[3]
		{
			new AdaptativeSpriteLookupTable(null),
			new AdaptativeSpriteLookupTable(null),
			new AdaptativeSpriteLookupTable(null)
		};

		public Material customMaterial;

		public Texture2D customTexture;

		public bool isUsingFullAdaptiveTexture => generateFullAdaptiveTexture;

		public bool isDataLayer => dataTile != TileType.none;

		public bool hasQuads => meshFillType != FillType.NoFill;

		public bool isWalkable => dataTile.IsWalkableTile();

		public byte[] GetAdaptativeDirBitsAvailable(AdaptiveLUTType adaptiveLUTType)
		{
			return adaptiveLUTType switch
			{
				AdaptiveLUTType.NineWay => adaptativeDirBitsAvailable, 
				AdaptiveLUTType.SubTile => adaptativeSubtileDirBitsAvailable, 
				AdaptiveLUTType.GeneratedTexture => generatedTextureAdaptativeDirBitsAvailable, 
				_ => adaptativeDirBitsAvailable, 
			};
		}

		public AdaptativeSpriteLookupTable[] GetAdaptativeSpriteLookupTable(AdaptiveLUTType adaptiveLUTType)
		{
			return adaptiveLUTType switch
			{
				AdaptiveLUTType.NineWay => adaptativeSpriteLookupTable, 
				AdaptiveLUTType.GeneratedTexture => generatedTextureAdaptativeSpriteLookupTable, 
				AdaptiveLUTType.SubTile => adaptativeSubtileSpriteLookupTable, 
				_ => adaptativeSpriteLookupTable, 
			};
		}

		public bool HasTileset(int tileset)
		{
			List<Tileset> list = (excludeFromTilesetInstead ? dontDrawForTilesets : onlyDrawForTilesets);
			if (list.Count == 0)
			{
				return true;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == (Tileset)tileset)
				{
					return !excludeFromTilesetInstead;
				}
			}
			return excludeFromTilesetInstead;
		}

		private static bool PositionSetIn(List<BitGrid> targetLayerDataOtherTilesets, Vector2Int pos)
		{
			foreach (BitGrid targetLayerDataOtherTileset in targetLayerDataOtherTilesets)
			{
				if (targetLayerDataOtherTileset.Get(pos))
				{
					return true;
				}
			}
			return false;
		}
	}
}
