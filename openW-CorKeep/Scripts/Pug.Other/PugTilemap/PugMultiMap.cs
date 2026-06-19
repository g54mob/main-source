using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap.Quads;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PugTilemap
{
	[ExecuteAlways]
	public class PugMultiMap : MonoBehaviour
	{
		[SerializeField]
		public SerializableDictionary<Vector3Int, PugMap> maps = new SerializableDictionary<Vector3Int, PugMap>();

		private List<PugMap> dirtymaps = new List<PugMap>();

		private PugMap[,] mapsArray = new PugMap[20, 20];

		public List<TileData>[,] tileLookup;

		[HideInInspector]
		public BoundsInt bounds;

		private PugMap tmpMap;

		private List<TileData> tmpTileTypes;

		private List<Vector3Int> emptyMapKeysToRemove = new List<Vector3Int>();

		private List<PugMap> mapsToBuild = new List<PugMap>();

		private Vector3 quadOffsetVector = new Vector3(0.5f, 0f, 0.5f);

		public Vector3 center => Vector3.zero;

		private void Awake()
		{
			if (!Application.isPlaying)
			{
				ReloadMaps();
			}
		}

		public void ReloadMaps()
		{
			if (Application.isPlaying)
			{
				return;
			}
			tileLookup = new List<TileData>[200, 200];
			mapsArray = new PugMap[20, 20];
			foreach (KeyValuePair<Vector3Int, PugMap> map in maps)
			{
				if (map.Value != null)
				{
					map.Value.ReloadData();
					mapsArray[10 + map.Key.x, 10 + map.Key.z] = map.Value;
				}
			}
			foreach (KeyValuePair<Vector3Int, PugMap> map2 in maps)
			{
				if (map2.Value != null)
				{
					map2.Value.Build();
				}
			}
		}

		public void Init()
		{
			tileLookup = new List<TileData>[200, 200];
			PugMap[] array = Object.FindObjectsOfType<PugMap>();
			foreach (PugMap newMap in array)
			{
				AddMap(newMap);
			}
			UpdateMultiMapBounds();
		}

		public void AddMap(PugMap newMap)
		{
			Vector3Int key = WorldPosToMapPos(newMap.transform.position);
			if (!maps.ContainsKey(key))
			{
				maps.Add(key, newMap);
				mapsArray[10 + key.x, 10 + key.z] = newMap;
			}
			UpdateMultiMapBoundsFromMap(newMap);
		}

		public void RemoveMap(Vector3Int mapPos)
		{
			maps.Remove(mapPos);
			mapsArray[10 + mapPos.x, 10 + mapPos.z] = null;
			UpdateMultiMapBounds();
		}

		public void UpdateMultiMapBounds()
		{
			bounds = default(BoundsInt);
			foreach (KeyValuePair<Vector3Int, PugMap> map in maps)
			{
				if (map.Value != null)
				{
					UpdateMultiMapBoundsFromMap(map.Value);
				}
			}
		}

		private void UpdateMultiMapBoundsFromMap(PugMap map)
		{
			BoundsInt otherBounds = new BoundsInt(map.transform.position.RoundToInt(), map.bounds.size);
			bounds = bounds.Fit(otherBounds);
		}

		public float GetRadius()
		{
			float num = 0f;
			for (int i = bounds.xMin; i <= bounds.xMax; i++)
			{
				for (int j = bounds.zMin; j <= bounds.zMax; j++)
				{
					Vector3 vector = new Vector3(i, 0f, j);
					float num2 = math.distance(vector, bounds.center);
					if (num2 > num && HasAnyTileAt(vector))
					{
						num = num2;
					}
				}
			}
			return math.ceil(num);
		}

		public bool IsPointInBounds(Vector3 worldPoint)
		{
			PugMap mapAtPosition = GetMapAtPosition(worldPoint);
			if (mapAtPosition != null)
			{
				return mapAtPosition.IsPointInBounds(worldPoint);
			}
			return false;
		}

		public TileData GetSurfaceTileAt(Vector3 position)
		{
			return TileTypeUtility.GetHighestSurfacePriority(GetTileTypesAt(position));
		}

		public TileData GetSurfaceTileAt(Vector3Int position)
		{
			return TileTypeUtility.GetHighestSurfacePriority(GetTileTypesAt(position));
		}

		public int GetSurfaceTilesetAt(Vector3 position)
		{
			return 0;
		}

		public List<TileData> GetTileTypesAt(Vector3Int position)
		{
			return tileLookup[100 + position.x, 100 + position.z];
		}

		public List<TileData> GetTileTypesAt(Vector3 position)
		{
			return GetTileTypesAt(position.RoundToInt());
		}

		public bool IsTileTypeAt(Vector3 position, TileType type)
		{
			tmpTileTypes = GetTileTypesAt(position);
			if (tmpTileTypes != null)
			{
				for (int i = 0; i < tmpTileTypes.Count; i++)
				{
					if (tmpTileTypes[i].info.tileType == type)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool IsTileTypeAt(Vector3 position, TileType type, int tileset)
		{
			tmpTileTypes = GetTileTypesAt(position);
			if (tmpTileTypes != null)
			{
				for (int i = 0; i < tmpTileTypes.Count; i++)
				{
					if (tmpTileTypes[i].info.tileType == type && tmpTileTypes[i].info.tileset == tileset)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasAnyTileAt(Vector3 position)
		{
			tmpTileTypes = GetTileTypesAt(position);
			if (tmpTileTypes != null)
			{
				return tmpTileTypes.Count > 0;
			}
			return false;
		}

		private PugMap CreateMapAtPosition(Vector3 position)
		{
			Vector3Int vector3Int = WorldPosToMapPos(position);
			Vector3Int vector3Int2 = vector3Int;
			GameObject obj = new GameObject("Map_" + vector3Int2.ToString());
			obj.transform.SetParent(base.transform);
			PugMap pugMap = obj.AddComponent<PugMap>();
			obj.transform.position = vector3Int * 10;
			vector3Int2 = vector3Int;
			obj.name = "Map_" + vector3Int2.ToString();
			pugMap.constantBounds = new BoundsInt(Vector3Int.zero, new Vector3Int(10, 10, 10));
			pugMap.Clear();
			AddMap(pugMap);
			return pugMap;
		}

		public void SetTile(Vector3 position, int tileset, TileType tiletype, bool rebuild = true, int state = 0)
		{
			PugMap pugMap = GetMapAtPosition(position);
			if (pugMap == null)
			{
				pugMap = CreateMapAtPosition(position);
			}
			pugMap.SetTile(position, tileset, tiletype, state, rebuild);
		}

		public void ClearTile(Vector3 position, bool rebuild = true)
		{
			PugMap mapAtPosition = GetMapAtPosition(position);
			if (mapAtPosition != null)
			{
				mapAtPosition.ClearTile(position, rebuild);
			}
		}

		public void ClearTileOfType(Vector3 position, TileType tileType, bool rebuild = true)
		{
			PugMap mapAtPosition = GetMapAtPosition(position);
			if (mapAtPosition != null)
			{
				mapAtPosition.ClearTileOfType(position, tileType, rebuild);
			}
		}

		public List<IEntityMonoBehaviourData> GetObjects(Vector3Int position)
		{
			GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
			List<IEntityMonoBehaviourData> list = new List<IEntityMonoBehaviourData>();
			GameObject[] array = rootGameObjects;
			for (int i = 0; i < array.Length; i++)
			{
				Component component = array[i].GetComponent(typeof(IEntityMonoBehaviourData));
				if (component is IEntityMonoBehaviourData && component.transform.position.RoundToInt() == position)
				{
					list.Add(component as IEntityMonoBehaviourData);
				}
			}
			return list;
		}

		public List<IEntityMonoBehaviourData> GetObjects()
		{
			GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
			List<IEntityMonoBehaviourData> list = new List<IEntityMonoBehaviourData>();
			GameObject[] array = rootGameObjects;
			for (int i = 0; i < array.Length; i++)
			{
				Component component = array[i].GetComponent(typeof(IEntityMonoBehaviourData));
				if (component is IEntityMonoBehaviourData)
				{
					list.Add(component as IEntityMonoBehaviourData);
				}
			}
			return list;
		}

		public void Rebuild()
		{
			Build(fullRebuild: true, cleanUpAndFixMap: true);
		}

		public void Build(bool fullRebuild = false, bool cleanUpAndFixMap = false)
		{
			emptyMapKeysToRemove.Clear();
			mapsToBuild.Clear();
			foreach (KeyValuePair<Vector3Int, PugMap> map in maps)
			{
				if (cleanUpAndFixMap && map.Value.isEmpty)
				{
					emptyMapKeysToRemove.Add(map.Key);
				}
				else if (map.Value.hasDirtyTiles || fullRebuild)
				{
					mapsToBuild.Add(map.Value);
					dirtymaps.Add(map.Value);
				}
			}
			if (cleanUpAndFixMap)
			{
				foreach (PugMap value in maps.Values)
				{
					value.MergeAnyOverlappingChunks();
				}
				for (int i = 0; i < 200; i++)
				{
					for (int j = 0; j < 200; j++)
					{
						if (tileLookup[j, i] == null)
						{
							continue;
						}
						Vector3 position = new Vector3(j - 100, 0f, i - 100);
						TileData[] array = new TileData[tileLookup[j, i].Count];
						tileLookup[j, i].CopyTo(array);
						TileData[] array2 = array;
						foreach (TileData tileData in array2)
						{
							SetTile(position, tileData.info.tileset, tileData.info.tileType, rebuild: false);
						}
						TileData tileData2 = tileLookup[j, i].Find((TileData t) => t.info.tileType == TileType.wall);
						bool num = tileData2 != null;
						bool flag = tileLookup[j, i].Find((TileData t) => t.info.tileType == TileType.ground) != null;
						bool flag2 = tileLookup[j, i].Find((TileData t) => t.info.tileType == TileType.water) != null;
						bool flag3 = tileLookup[j, i].Find((TileData t) => t.info.tileType == TileType.pit) != null;
						bool flag4 = tileLookup[j, i].Find((TileData t) => t.info.tileType == TileType.bridge) != null;
						bool flag5 = tileLookup[j, i].Find((TileData t) => t.info.tileType == TileType.roofHole) != null;
						if (num && !flag && !flag4)
						{
							PugMapTileset tileset = TilesetTypeUtility.GetTileset(tileData2.info.tileset);
							if (tileset != null && tileset.GetDef(LayerName.ground) != null)
							{
								SetTile(position, tileData2.info.tileset, TileType.ground, rebuild: false);
							}
							else
							{
								SetTile(position, 0, TileType.ground, rebuild: false);
							}
							flag = true;
						}
						if (flag2 && flag)
						{
							ClearTileOfType(position, TileType.water, rebuild: false);
							flag2 = false;
						}
						if (flag3 && flag)
						{
							ClearTileOfType(position, TileType.pit, rebuild: false);
							flag3 = false;
						}
						if (flag4 && !flag2 && !flag3)
						{
							SetTile(position, 0, TileType.pit, rebuild: false);
							flag3 = true;
						}
						if (flag5 && !flag && !flag2 && !flag3)
						{
							SetTile(position, 0, TileType.pit, rebuild: false);
							flag3 = true;
						}
						ClearTileOfType(position, TileType.roof, rebuild: false);
					}
				}
			}
			int num2 = 0;
			num2 = ((!Application.isPlaying) ? mapsToBuild.Count : Mathf.CeilToInt((float)mapsToBuild.Count / 3f));
			for (int num3 = 0; num3 < num2; num3++)
			{
				mapsToBuild[num3].Build(onlyResolveQuads: false, cleanUpAndFixMap);
			}
			foreach (Vector3Int item in emptyMapKeysToRemove)
			{
				Object.DestroyImmediate(maps[item].gameObject);
				RemoveMap(item);
			}
		}

		public void Clear()
		{
			foreach (KeyValuePair<Vector3Int, PugMap> map in maps)
			{
				mapsArray[10 + map.Key.x, 10 + map.Key.z] = null;
				Object.Destroy(map.Value.gameObject);
			}
			maps.Clear();
		}

		public void LoadMapData(string json)
		{
			PugMapData pugMapData = new PugMapData();
			JsonUtility.FromJsonOverwrite(json, pugMapData);
			PugMap mapAtPosition = GetMapAtPosition(pugMapData.bounds.position);
			if (mapAtPosition == null)
			{
				CreateMapAtPosition(pugMapData.bounds.position);
			}
			mapAtPosition.Build(pugMapData);
		}

		public string SaveMapData()
		{
			return "";
		}

		public void Commit()
		{
			foreach (PugMap dirtymap in dirtymaps)
			{
				dirtymap.Commit();
			}
			dirtymaps.Clear();
		}

		public PugMapLayer EnsureLayerPresent(Vector3 position, int tileset, LayerName key, bool createMapIfNotExisting = true)
		{
			PugMap pugMap = GetMapAtPosition(position);
			if (pugMap == null)
			{
				if (!createMapIfNotExisting)
				{
					return null;
				}
				pugMap = CreateMapAtPosition(position);
			}
			return pugMap.EnsureLayerPresent(tileset, key);
		}

		public void SetDirty(Vector3Int p)
		{
			PugMap mapAtPosition = GetMapAtPosition(p);
			if (mapAtPosition != null)
			{
				mapAtPosition.SetDirty(p);
			}
		}

		public void LockManualEditingOfLayerGameObjects(bool locked)
		{
			foreach (KeyValuePair<Vector3Int, PugMap> map in maps)
			{
				map.Value.LockManualEditingOfLayerGameObjects(locked);
			}
		}

		public PugMap GetMapAtPosition(Vector3 worldPos)
		{
			Vector3Int vector3Int = WorldPosToMapPos(worldPos);
			return mapsArray[10 + vector3Int.x, 10 + vector3Int.z];
		}

		public Vector3Int WorldPosToMapPos(Vector3 worldPos)
		{
			worldPos += quadOffsetVector;
			return new Vector3Int((int)((worldPos.x < 0f) ? (worldPos.x - 10f) : worldPos.x), 0, (int)((worldPos.z < 0f) ? (worldPos.z - 10f) : worldPos.z)) / 10;
		}
	}
}
