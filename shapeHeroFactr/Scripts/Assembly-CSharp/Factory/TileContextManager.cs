using System.Collections.Generic;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Factory
{
	public class TileContextManager : SingletonMonoBehaviour<TileContextManager>
	{
		public static readonly Vector3 ArriveLeaveAnimationPosition;

		public static readonly float ArriveAnimationDuration;

		public static readonly float LeaveAnimationDuration;

		[Header("自動設定")]
		[SerializeField]
		private Tilemap[] tileMaps;

		private static Tilemap[] _sTileMaps;

		private static Dictionary<TileContextID, TileContext> _db;

		public static Vector3Int WorldToCell(Vector3 worldPosition)
		{
			return default(Vector3Int);
		}

		public static Vector3 CellToWorld(Vector3Int cellPosition)
		{
			return default(Vector3);
		}

		public static Vector3 CellToWorld(TileLayer layer, RectInt gridRect)
		{
			return default(Vector3);
		}

		public static Vector3 CellToWorld(TileLayer layer, Vector2IntBundle gridRect)
		{
			return default(Vector3);
		}

		public static Vector3 CellToScreenSpaceOverlay(Camera camera, Vector3Int cellPosition)
		{
			return default(Vector3);
		}

		public static Vector3 CellToScreenSpaceOverlay(Camera camera, Vector3Int cellPosition, out Vector3 worldPosition)
		{
			worldPosition = default(Vector3);
			return default(Vector3);
		}

		public static Vector3 CellToScreenPoint(Camera camera, Vector3Int cellPosition, out Vector3 worldPosition)
		{
			worldPosition = default(Vector3);
			return default(Vector3);
		}

		private void Awake()
		{
		}

		public static TileContext Prepare(TileLayer layer, Vector3Int gridPos, TileBase tile, string partsName, bool hasBillboard, bool billboardOnly = false, bool billboardRotation = false)
		{
			return null;
		}

		public static void Clear(TileLayer layer, Vector3Int gridPos)
		{
		}

		public static void SetTile(TileLayer layer, Vector3Int gridPos, TileBase tile, string partsName, bool hasBillboard, bool billboardRotation = false)
		{
		}

		public static void SetTileSimple(TileLayer layer, Vector3Int gridPos, DTileBase2 tile, string partsName, bool hasBillboard)
		{
		}

		public static void SetTilesSimple(TileLayer layer, Vector2IntBundle gridBundle, DTileBase2 tile, string[] partsName)
		{
		}

		public static TileContext SetBubbleIconTile(TileLayer layer, Vector3Int gridPos, DTileBase2 tile, string partsName, bool hasBillboard, bool billboardAnimation)
		{
			return null;
		}

		public static void AnimationLayerRotateZForInserterGuide(TileLayer layer, Vector3Int gridPos, Dir.Rot rot)
		{
		}

		public static void SetRotatableAnimatedTile(TileLayer layer, Vector3Int gridPos, float rotZ, TileBase tile)
		{
		}

		private static void SetPreparedTile(TileContext context)
		{
		}

		public static void SetPartsName(TileLayer layer, Vector3Int gridPos, string partsName)
		{
		}

		public static void SetPartsNameSuffix(TileLayer layer, Vector3Int gridPos, string partsNameSuffix)
		{
		}

		public static void SetAnimationSpeed(TileLayer layer, Vector3Int gridPos, float animationSpeed)
		{
		}

		public static void SetAnimationSpeedLoop(TileLayer layer, Vector3Int gridPos, float animationSpeed, bool isLoop)
		{
		}

		public static void SetManualAnimationFrame(TileLayer layer, Vector3Int gridPos, int animationFrame)
		{
		}

		public static void SetLoopOnce(TileLayer layer, Vector3Int gridPos, bool play)
		{
		}

		public static TileContext GetTileContext(TileLayer layer, Vector3Int position)
		{
			return null;
		}

		public static TileContext GetTileContext(ITilemap iTile, Vector3Int position)
		{
			return null;
		}

		public static string GetPartsName(ITilemap iTile, Vector3Int position)
		{
			return null;
		}

		public static void ClearTiles(TileLayer layer, RectInt grid)
		{
		}

		public static void ClearTile(TileLayer layer, Vector3Int position)
		{
		}

		public static void FillTiles(TileLayer layer, RectInt grid, TileBase tile)
		{
		}

		public static void FillTiles(TileLayer layer, Vector2IntBundle grid, TileBase tile)
		{
		}

		public static void FillTiles(TileLayer layer, List<RectInt> gridRectList, TileBase tile)
		{
		}

		public static void FillTilesSimple(TileLayer layer, RectInt grid, TileBase tile)
		{
		}

		public static void FillTilesSimple(TileLayer layer, Vector2IntBundle grid, TileBase tile, int? length = null)
		{
		}

		public static void SetCursorTiles(TileLayer layer, Vector2IntBundle grid, TileDetail[] tileDetailAry, TileLayer portLayer, TileLayer guideConveyerLayer, TileLayer guidePipeLayer, DTileBase2 portTile, DTileBase2 portGuideConveyerTile, DTileBase2 portGuidePipeTile, bool isStream, bool hasBillboard, int? manualAnimationIndex, bool billboardRotation)
		{
		}

		public static void SetPortTiles(TileLayer layer, Vector3Int position, List<TileAppend> tileAppends, DTileBase2 portTile)
		{
		}

		public static void SetPortGuideTiles(TileLayer layer, Vector3Int position, List<TileAppend> tileAppends, DTileBase2 portTile, eTileAppendKind kind)
		{
		}

		public static void SetProductGuideTiles(TileLayer layer, Vector3Int position, List<TileAppend> tileAppends, DTileBase2 productGuideTile)
		{
		}

		public static void RefreshTile(TileLayer layer, Vector3Int position)
		{
		}

		public static void RefreshTile(TileLayer layer, Vector3Int position, string partsName)
		{
		}

		public static void RefreshTileSetAnimationSpeed(TileLayer layer, Vector3Int position, float animationSpeed)
		{
		}

		public static int GetAnimationFrameCount(TileLayer layer, Vector3Int position)
		{
			return 0;
		}

		public static void RefreshTileSetAnimationSpeedAndSuffix(TileLayer layer, Vector3Int position, float animationSpeed, string partsNameSuffix, int? specificFrame = null)
		{
		}

		public static void RefreshTile(TileLayer layer, Vector3Int position, string partsName, float animationSpeed, int animationFrame)
		{
		}

		public static void RefreshTileManualAnimationFrame(TileLayer layer, Vector3Int position, int animationFrame)
		{
		}

		public static void RefreshTileLoopOnce(TileLayer layer, Vector3Int position, bool play)
		{
		}

		public static void RefreshTile(TileLayer layer, Vector3Int position, string partsName, float animationSpeed, bool isLoopAnimation)
		{
		}

		public static void RefreshTile(TileLayer layer, Vector3Int position, Color color)
		{
		}

		public static void RefreshTiles(TileLayer layer, RectInt gridRect, Color color)
		{
		}

		public static bool HasTile(TileLayer layer, Vector3Int position)
		{
			return false;
		}

		public static bool HasAnyTile(TileLayer layer, RectInt gridRect)
		{
			return false;
		}

		public static void DumpTile(TileLayer layer, Vector3Int position)
		{
		}

		public static void SetLayerColor(TileLayer layer, Color color)
		{
		}

		public static int GetLayerOrder(TileLayer layer)
		{
			return 0;
		}

		public static void SetLayerOrder(TileLayer layer, int order)
		{
		}

		public static void ClearLayer(TileLayer layer)
		{
		}

		public static Tilemap GetOriginalTilemap(TileLayer layer)
		{
			return null;
		}
	}
}
