using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using PugTilemap.Quads;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace PugTilemap
{
	[ExecuteAlways]
	public class MultiPugMap : MonoBehaviour
	{
		private readonly int2 subMapSize2 = new int2(64, 64);

		private readonly int2 middleSubMapPos = new int2(32, 32);

		private Dictionary<int2, SinglePugMap> mapLookup = new Dictionary<int2, SinglePugMap>();

		private List<int2> mapsToRemove = new List<int2>();

		private List<SinglePugMap> mapsBuiltThisFrame = new List<SinglePugMap>();

		private List<SinglePugMap> freeMaps = new List<SinglePugMap>();

		private SinglePugMap nullMap;

		private List<SinglePugMap> mapsCloseToPositionCache = new List<SinglePugMap>(9);

		private List<int2> positionsCloseToPositionCache = new List<int2>(9);

		public int2 Origo => Manager.camera.RenderOrigo.ToInt2();

		public void Start()
		{
			ClearAllMaps();
			if (Application.isPlaying)
			{
				GameObject gameObject = new GameObject("null");
				gameObject.transform.SetParent(base.transform);
				nullMap = gameObject.AddComponent<SinglePugMap>();
				gameObject.SetActive(value: false);
				UpdateMapPositions();
				CameraManager camera = Manager.camera;
				camera.RenderOrigoUpdated = (Action)Delegate.Combine(camera.RenderOrigoUpdated, new Action(UpdateMapPositions));
			}
		}

		private void OnApplicationQuit()
		{
			ClearAllMaps();
		}

		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				CameraManager camera = Manager.camera;
				camera.RenderOrigoUpdated = (Action)Delegate.Remove(camera.RenderOrigoUpdated, new Action(UpdateMapPositions));
			}
			ClearAllMaps();
			if (nullMap != null)
			{
				nullMap.Dispose();
			}
		}

		public void ClearAllMaps()
		{
			foreach (SinglePugMap value in mapLookup.Values)
			{
				value.Dispose();
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(value.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(value.gameObject);
				}
			}
			foreach (SinglePugMap freeMap in freeMaps)
			{
				if (!(freeMap == null))
				{
					freeMap.Dispose();
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(freeMap.gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(freeMap.gameObject);
					}
				}
			}
			mapLookup.Clear();
			mapsBuiltThisFrame.Clear();
			freeMaps.Clear();
		}

		private SinglePugMap CreateMap(int2 position)
		{
			SinglePugMap singlePugMap;
			if (freeMaps.Count == 0)
			{
				GameObject obj = new GameObject(position.ToString());
				obj.hideFlags |= HideFlags.DontSave | HideFlags.NotEditable;
				obj.transform.SetParent(base.transform);
				singlePugMap = obj.AddComponent<SinglePugMap>();
			}
			else
			{
				singlePugMap = freeMaps[freeMaps.Count - 1];
				freeMaps.RemoveAt(freeMaps.Count - 1);
				singlePugMap.name = position.ToString();
			}
			singlePugMap.Reset();
			return singlePugMap;
		}

		private void EnsureMapIsAtPosition(int2 mapPos)
		{
			if (!mapLookup.ContainsKey(mapPos))
			{
				SinglePugMap value = CreateMap(mapPos);
				mapLookup.Add(mapPos, value);
				UpdateMapPositions();
			}
		}

		private SinglePugMap GetMapAtPosition(int2 position, bool createIfMissing = true)
		{
			int2 mapPos = GetMapPos(position);
			if (createIfMissing)
			{
				EnsureMapIsAtPosition(mapPos);
			}
			if (mapLookup.TryGetValue(mapPos, out var value))
			{
				return value;
			}
			return nullMap;
		}

		private void GetMapsCloseToPosition(int2 position, out List<SinglePugMap> maps, out List<int2> localPositions)
		{
			maps = mapsCloseToPositionCache;
			maps.Clear();
			localPositions = positionsCloseToPositionCache;
			localPositions.Clear();
			float2 i;
			float2 x = ((!Application.isPlaying) ? math.modf(position / subMapSize2, out i) : math.modf((position + Manager.camera.RenderOrigo.ToFloat2()) / subMapSize2, out i));
			if (math.distancesq(x, 0.5f) < 0.16000001f)
			{
				return;
			}
			SinglePugMap mapAtPosition = GetMapAtPosition(position);
			int2 int5 = ToLocal(position);
			for (int j = 0; j < Direction.allEightClockwise.Length; j++)
			{
				Direction direction = Direction.allEightClockwise[j];
				int2 i2 = direction.i2;
				SinglePugMap mapAtPosition2 = GetMapAtPosition(position + i2);
				if (mapAtPosition != mapAtPosition2 && mapAtPosition2 != nullMap)
				{
					maps.Add(mapAtPosition2);
					localPositions.Add(int5 - i2 * 64);
				}
			}
		}

		private int2 GetMapPos(int2 position)
		{
			if (Application.isPlaying)
			{
				position += Manager.camera.RenderOrigo.ToInt2();
			}
			return (position & ~(subMapSize2 - 1)) / subMapSize2;
		}

		private void UpdateMapPositions()
		{
			int2 int5 = int2.zero;
			if (Application.isPlaying)
			{
				int5 = Manager.camera.RenderOrigo.ToInt2();
			}
			int5.ToFloat2();
			int2 int6 = (int5 & ~(subMapSize2 - 1)) / subMapSize2;
			float3 float5 = (int5 - int6 * subMapSize2).ToFloat3();
			foreach (KeyValuePair<int2, SinglePugMap> item in mapLookup)
			{
				int2 int7 = item.Key - int6;
				item.Value.transform.localPosition = (int7 * subMapSize2).ToFloat3();
			}
			base.transform.localPosition = -float5;
		}

		public void Update()
		{
			foreach (SinglePugMap value2 in mapLookup.Values)
			{
				if (value2.Build())
				{
					mapsBuiltThisFrame.Add(value2);
				}
			}
			mapsToRemove.Clear();
			foreach (KeyValuePair<int2, SinglePugMap> item in mapLookup)
			{
				SinglePugMap value = item.Value;
				if (value.IsEmpty)
				{
					mapsToRemove.Add(item.Key);
					value.name = "free";
					freeMaps.Add(value);
					if (!mapsBuiltThisFrame.Contains(value))
					{
						value.Build();
						mapsBuiltThisFrame.Add(value);
					}
				}
			}
			foreach (int2 item2 in mapsToRemove)
			{
				mapLookup.Remove(item2);
			}
		}

		public void LateUpdate()
		{
			foreach (SinglePugMap item in mapsBuiltThisFrame)
			{
				item.LateBuild();
			}
			mapsBuiltThisFrame.Clear();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int2 ToLocal(int2 worldPosition)
		{
			return (worldPosition % subMapSize2 + subMapSize2) % subMapSize2;
		}

		public NativeParallelMultiHashMap<int2, TileInfo>.Enumerator GetTiles(int2 worldPosition)
		{
			return GetMapAtPosition(worldPosition, createIfMissing: false).GetTileLayerLookup().GetTiles(ToLocal(worldPosition));
		}

		public bool HasTile(int2 worldPosition, TileType type)
		{
			return GetMapAtPosition(worldPosition, createIfMissing: false).GetTileLayerLookup().HasTile(ToLocal(worldPosition), type);
		}

		public bool HasTile(int2 worldPosition, TileType type, int tileset)
		{
			return GetMapAtPosition(worldPosition, createIfMissing: false).GetTileLayerLookup().HasTile(ToLocal(worldPosition), type, tileset);
		}

		public bool TryGetTileInfo(int2 worldPosition, TileType type, out TileInfo tileInfo)
		{
			return GetMapAtPosition(worldPosition, createIfMissing: false).GetTileLayerLookup().TryGetTileInfo(ToLocal(worldPosition), type, out tileInfo);
		}

		public TileInfo GetTopTile(int2 worldPosition)
		{
			return GetMapAtPosition(worldPosition, createIfMissing: false).GetTileLayerLookup().GetTopTile(ToLocal(worldPosition));
		}

		public TileInfo GetTopTile(int2 worldPosition, out bool hasWater)
		{
			return GetMapAtPosition(worldPosition, createIfMissing: false).GetTileLayerLookup().GetTopTileAndCheckWater(ToLocal(worldPosition), out hasWater);
		}

		public void ClearTileOfType(int2 worldPosition, TileType tileType)
		{
			GetMapsCloseToPosition(worldPosition, out var maps, out var localPositions);
			for (int i = 0; i < maps.Count; i++)
			{
				maps[i].ClearHiddenTileOfType(localPositions[i], tileType);
			}
			GetMapAtPosition(worldPosition).ClearTileOfType(ToLocal(worldPosition), tileType);
		}

		public void ClearTileOfTypeAndTileset(int2 worldPosition, TileType tileType, int tileset)
		{
			GetMapsCloseToPosition(worldPosition, out var maps, out var localPositions);
			for (int i = 0; i < maps.Count; i++)
			{
				maps[i].ClearHiddenTileOfTypeAndTileset(localPositions[i], tileType, tileset);
			}
			GetMapAtPosition(worldPosition).ClearTileOfTypeAndTileset(ToLocal(worldPosition), tileType, tileset);
		}

		public void SetTile(int2 worldPosition, int tileset, TileType tileType, int state = 0)
		{
			GetMapsCloseToPosition(worldPosition, out var maps, out var localPositions);
			for (int i = 0; i < maps.Count; i++)
			{
				maps[i].SetHiddenTile(localPositions[i], tileset, tileType, state);
			}
			GetMapAtPosition(worldPosition).SetTile(ToLocal(worldPosition), tileset, tileType, state);
		}

		public void SetHiddenTile(int2 worldPosition, int tileset, TileType tiletype, int state)
		{
			GetMapsCloseToPosition(worldPosition, out var maps, out var localPositions);
			for (int i = 0; i < maps.Count; i++)
			{
				maps[i].SetHiddenTile(localPositions[i], tileset, tiletype, state);
			}
			GetMapAtPosition(worldPosition).SetHiddenTile(ToLocal(worldPosition), tileset, tiletype, state);
		}

		public bool HasHiddenTile(int2 worldPosition, int tileset, TileType tiletype)
		{
			SinglePugMap mapAtPosition = GetMapAtPosition(worldPosition);
			if (mapAtPosition != null)
			{
				return mapAtPosition.HasHiddenTile(ToLocal(worldPosition), tileset, tiletype);
			}
			return false;
		}

		public void ClearHiddenTileOfType(int2 worldPosition, TileType tileType)
		{
			GetMapsCloseToPosition(worldPosition, out var maps, out var localPositions);
			for (int i = 0; i < maps.Count; i++)
			{
				maps[i].ClearHiddenTileOfType(localPositions[i], tileType);
			}
			GetMapAtPosition(worldPosition).ClearHiddenTileOfType(ToLocal(worldPosition), tileType);
		}

		public Sprite GetSpriteOfSurfaceTile(int2 worldPosition, out Material material)
		{
			material = null;
			TileInfo topTile = GetTopTile(worldPosition);
			if (topTile.tileType != TileType.none)
			{
				return GetSpriteOfTile(worldPosition, topTile.tileset, topTile.tileType, out material);
			}
			return null;
		}

		public Sprite GetSpriteOfTile(int2 worldPosition, int tileset, TileType tileType, out Material material)
		{
			material = null;
			SinglePugMap mapAtPosition = GetMapAtPosition(worldPosition, createIfMissing: false);
			if (mapAtPosition == null)
			{
				return null;
			}
			Quad quad = default(Quad);
			PugMapLayer2 layer = mapAtPosition.GetLayer(tileset, tileType);
			if (layer != null)
			{
				quad = layer.GetQuad(ToLocal(worldPosition));
				Texture2D texture = layer.texture;
				material = layer.material;
				if (texture != null)
				{
					Vector2Int size = texture.GetSize();
					Rect rect = new Rect(quad.spriteUV.min * size, quad.spriteUV.size * size);
					return Sprite.Create(texture, rect, Vector2.one * 0.5f, 16f);
				}
			}
			return null;
		}
	}
}
