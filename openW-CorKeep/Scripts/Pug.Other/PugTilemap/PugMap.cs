using System;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using PugTilemap.Quads;
using UnityEngine;

namespace PugTilemap
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class PugMap : MonoBehaviour
	{
		public PugMapUndo undoHandler;

		[SerializeField]
		public BoundsInt constantBounds;

		private PugMultiMap _multiMap;

		[SerializeField]
		private PugMapDataModifier dataModifier;

		[SerializeField]
		private int tileCount;

		public GameObject layerRoot;

		private readonly List<PugMapLayer> _volatileAllLayers = new List<PugMapLayer>(16);

		[Header("For info only, may not be accurate")]
		public int totalTris;

		public string lastBuilt = "unknown";

		private PugMapData data
		{
			get
			{
				if (dataModifier == null)
				{
					data = new PugMapData(constantBounds);
				}
				return dataModifier.GetMapData();
			}
			set
			{
				dataModifier = new PugMapDataModifier(value);
				_InitFromData();
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

		public HashSet<Vector3Int> tilesChangedSinceLastBuild { get; private set; } = new HashSet<Vector3Int>();

		public bool hasDirtyTiles => tilesChangedSinceLastBuild.Count > 0;

		public bool isEmpty => tileCount == 0;

		public BoundsInt bounds
		{
			get
			{
				if (dataModifier == null)
				{
					data = new PugMapData();
				}
				return dataModifier.GetMapData().bounds;
			}
		}

		public List<PugMapLayer> allLayers
		{
			get
			{
				if (_volatileAllLayers.Count == 0)
				{
					ResetVolatileLayerLookupTable();
				}
				return _volatileAllLayers;
			}
		}

		public Vector3 center => ToWorldCoordF(data.bounds.center);

		private void Awake()
		{
			undoHandler = GetComponent<PugMapUndo>();
			if (undoHandler == null)
			{
				undoHandler = base.gameObject.AddComponent<PugMapUndo>();
			}
		}

		public void ReloadData()
		{
			base.gameObject.name = "Map_" + (base.transform.RoundedPositionInt() / 10).ToString();
			multiMap.AddMap(this);
			_InitFromData();
		}

		public void ResolveQuads()
		{
			Build(onlyResolveQuads: true);
		}

		public PugMapLayer GetLayer(int tileset, LayerName key)
		{
			return allLayers.FirstOrDefault(delegate(PugMapLayer q)
			{
				if (q.tilesetKey == tileset)
				{
					QuadGenerator def = q.def;
					if (def == null)
					{
						return false;
					}
					return def.layerName == key;
				}
				return false;
			});
		}

		public PugMapLayer GetLayer(int tileset, TileType key)
		{
			return allLayers.FirstOrDefault(delegate(PugMapLayer q)
			{
				if (q.tilesetKey == tileset)
				{
					QuadGenerator def = q.def;
					if (def == null)
					{
						return false;
					}
					return def.dataTile == key;
				}
				return false;
			});
		}

		public List<PugMapLayer> GetLayers(TileType key)
		{
			return allLayers.FindAll(delegate(PugMapLayer q)
			{
				QuadGenerator def = q.def;
				return def != null && def.dataTile == key;
			});
		}

		private void ResetVolatileLayerLookupTable()
		{
			_volatileAllLayers.Clear();
			if (layerRoot == null)
			{
				return;
			}
			foreach (Transform item in layerRoot.transform)
			{
				PugMapLayer component = item.GetComponent<PugMapLayer>();
				if (component.def != null)
				{
					_volatileAllLayers.Add(component);
				}
			}
			for (int i = 0; i < _volatileAllLayers.Count; i++)
			{
				_volatileAllLayers[i].transform.SetSiblingIndex(i);
			}
		}

		private PugMapLayer CreateLayer(int tilesetKey, LayerName key)
		{
			if (layerRoot == null)
			{
				layerRoot = NewInternalMapGO("PugMapLayers", base.transform);
				layerRoot.transform.SetAsFirstSibling();
			}
			string text = TilesetTypeUtility.GetFriendlyName(tilesetKey) + " " + key;
			PugMapLayer pugMapLayer = NewInternalMapGO(text, layerRoot.transform).AddComponent<PugMapLayer>();
			pugMapLayer.tilesetKey = tilesetKey;
			pugMapLayer.layerDefKey = key;
			pugMapLayer.Init();
			ResetVolatileLayerLookupTable();
			return pugMapLayer;
		}

		public PugMapLayer EnsureLayerPresent(int tileset, LayerName key)
		{
			PugMapLayer pugMapLayer = GetLayer(tileset, key);
			if (null == pugMapLayer)
			{
				pugMapLayer = CreateLayer(tileset, key);
			}
			return pugMapLayer;
		}

		private void RemoveLayer(PugMapLayer layer)
		{
			UnityEngine.Object.DestroyImmediate(layer.gameObject);
			ResetVolatileLayerLookupTable();
		}

		public void ClearLayers()
		{
			UnityEngine.Object.DestroyImmediate(layerRoot);
			layerRoot = null;
			ResetVolatileLayerLookupTable();
			ResetDirty();
		}

		private void CleanUpAndFixMapData()
		{
			if (Application.isPlaying)
			{
				return;
			}
			for (int num = data.layers.Count - 1; num >= 0; num--)
			{
				PugMapLayerData pugMapLayerData = data.layers[num];
				for (int num2 = pugMapLayerData.tileDataChunks.Count - 1; num2 >= 0; num2--)
				{
					if (pugMapLayerData.tileDataChunks[num2].s == pugMapLayerData.tileDataChunks[num2].e)
					{
						pugMapLayerData.tileDataChunks.RemoveAt(num2);
					}
				}
				if (pugMapLayerData.tileDataChunks.Count == 0)
				{
					data.layers.RemoveAt(num);
				}
			}
			ClearLayers();
			_InitFromData();
		}

		public void Build(bool onlyResolveQuads = false, bool cleanUp = false)
		{
			Build(null, onlyResolveQuads, cleanUp);
		}

		public void Build(PugMapData mapData, bool onlyResolveQuads = false, bool cleanUpAndFixMap = false)
		{
			if (!Application.isPlaying && cleanUpAndFixMap)
			{
				CleanUpAndFixMapData();
			}
			if (mapData != null)
			{
				Clear();
				data = mapData;
			}
			_ = DateTime.Now;
			totalTris = 0;
			List<Tuple<int, LayerName>> list = new List<Tuple<int, LayerName>>();
			foreach (PugMapLayer allLayer in allLayers)
			{
				if (allLayer.def == null)
				{
					continue;
				}
				foreach (QuadGenerator layersDependentOnMyDatum in allLayer.def.layersDependentOnMyData)
				{
					list.Add(Tuple.Create(allLayer.tilesetKey, layersDependentOnMyDatum.layerName));
				}
			}
			foreach (Tuple<int, LayerName> item in list)
			{
				EnsureLayerPresent(item.Item1, item.Item2);
			}
			PugMapLayer[] array = allLayers.ToArray();
			foreach (PugMapLayer pugMapLayer in array)
			{
				pugMapLayer.Build(multiMap.tileLookup, tilesChangedSinceLastBuild, data.bounds, onlyResolveQuads);
				totalTris += pugMapLayer.triangleCount;
			}
			if (!Application.isPlaying)
			{
				lastBuilt = DateTime.Now.ToString("o");
			}
			ResetDirty();
		}

		public void Commit()
		{
		}

		public Vector3Int ToMapCoord(Vector3 worldPoint)
		{
			return base.transform.InverseTransformPoint(worldPoint).RoundToInt();
		}

		public Vector3 ToMapCoordF(Vector3 worldPoint)
		{
			return base.transform.InverseTransformPoint(worldPoint);
		}

		public Vector3 ToWorldCoord(Vector3Int localPoint)
		{
			return base.transform.TransformPoint(localPoint.x, localPoint.y, localPoint.z);
		}

		public Vector3 ToWorldCoordF(Vector3 localPoint)
		{
			return base.transform.TransformPoint(localPoint.x, localPoint.y, localPoint.z);
		}

		public int WorldCoordToTileIndex(Vector3 worldPoint)
		{
			return MapCoordToTileIndex(ToMapCoord(worldPoint));
		}

		public int MapCoordToTileIndex(Vector3Int localPoint)
		{
			return localPoint.z * 10 + localPoint.x;
		}

		public Vector3Int LocalCoordToTileLookUpPosition(int x, int z)
		{
			return new Vector3Int(100 + Mathf.RoundToInt(base.transform.position.x) + x, 0, 100 + Mathf.RoundToInt(base.transform.position.z) + z);
		}

		private bool IsPointInBounds_Local(Vector3Int localPoint)
		{
			return data.bounds.Contains(localPoint);
		}

		public bool IsPointInBounds(Vector3 worldPoint)
		{
			return IsPointInBounds_Local(ToMapCoord(worldPoint));
		}

		public void SetDirty(Vector3Int p, bool isLocalPos = false)
		{
			Vector3Int item = (isLocalPos ? p : ToMapCoord(p));
			tilesChangedSinceLastBuild.Add(item);
		}

		public void ResetDirty()
		{
			tilesChangedSinceLastBuild.Clear();
		}

		public IEnumerable<Transform> GetYankableChildren()
		{
			return from Transform child in base.transform
				where (child.hideFlags & HideFlags.DontSave) == 0 && !child.CompareTag("EditorJunk") && !child.name.StartsWith("__") && child.gameObject != layerRoot
				select child;
		}

		public List<MonoBehaviour> GetYankableChildrenComponentsAtPosition(Vector3 position)
		{
			List<MonoBehaviour> list = new List<MonoBehaviour>();
			foreach (Transform yankableChild in GetYankableChildren())
			{
				if (yankableChild.position.Round() == position.Round())
				{
					MonoBehaviour component = yankableChild.GetComponent<MonoBehaviour>();
					if (component != null)
					{
						list.Add(component);
					}
				}
			}
			return list;
		}

		public GameObject NewInternalMapGO(string name, Transform parent)
		{
			GameObject obj = new GameObject(name);
			obj.hideFlags = HideFlags.NotEditable;
			obj.transform.SetParent(parent, worldPositionStays: false);
			return obj;
		}

		public void Clear()
		{
			foreach (Transform item in GetYankableChildren().ToList())
			{
				UnityEngine.Object.DestroyImmediate(item.gameObject);
			}
			ClearLayers();
			if (constantBounds.size != Vector3Int.zero)
			{
				data = new PugMapData(constantBounds);
			}
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					Vector3Int vector3Int = LocalCoordToTileLookUpPosition(j, i);
					multiMap.tileLookup[vector3Int.x, vector3Int.z].Clear();
				}
			}
			tileCount = 0;
		}

		public void LockManualEditingOfLayerGameObjects(bool locked)
		{
			HideFlags hideFlags = (locked ? HideFlags.HideInHierarchy : HideFlags.None);
			foreach (PugMapLayer allLayer in allLayers)
			{
				if (!(allLayer == null))
				{
					allLayer.gameObject.hideFlags = hideFlags;
				}
			}
		}

		public void ClearTile(Vector3 worldPos, bool rebuild = true)
		{
			Vector3Int vector3Int = ToMapCoord(worldPos);
			_ClearTile(vector3Int);
			SetDirty(vector3Int, isLocalPos: true);
			if (rebuild)
			{
				Build();
			}
		}

		public void ClearTileOfType(Vector3 worldPos, TileType tileType, bool rebuild = true)
		{
			Vector3Int vector3Int = ToMapCoord(worldPos);
			_ClearTileOfType(vector3Int, tileType);
			SetDirty(vector3Int, isLocalPos: true);
			if (rebuild)
			{
				Build();
			}
		}

		private void _InitFromData()
		{
			tileCount = 0;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					Vector3Int vector3Int = LocalCoordToTileLookUpPosition(j, i);
					multiMap.tileLookup[vector3Int.x, vector3Int.z] = new List<TileData>();
				}
			}
			foreach (PugMapLayerData layer in data.layers)
			{
				PugMapLayer pugMapLayer = EnsureLayerPresent(layer.tileData.tilesetType, TileTypeToLayerName.GetLayerName(layer.tileData.tileType));
				if (pugMapLayer == null || pugMapLayer.def == null)
				{
					continue;
				}
				foreach (PugMapLayerData.TileLayerChunk tileDataChunk in layer.tileDataChunks)
				{
					for (int k = tileDataChunk.s; k < tileDataChunk.e; k++)
					{
						Vector3Int vector3Int2 = data.bounds.PositionFromCellIndex(k);
						_SetInCache(vector3Int2, pugMapLayer.tilesetKey, pugMapLayer.def.dataTile, 0);
						SetDirty(vector3Int2, isLocalPos: true);
					}
				}
			}
		}

		private void _ClearTile(Vector3Int localPos)
		{
			foreach (PugMapLayer allLayer in allLayers)
			{
				if (allLayer.def.isDataLayer)
				{
					dataModifier.Set(localPos, allLayer.tilesetKey, allLayer.def.dataTile, value: false);
					_SetInCache(localPos, allLayer.tilesetKey, allLayer.def.dataTile, 0, value: false);
					SetDirty(localPos, isLocalPos: true);
				}
			}
		}

		private void _ClearTileOfType(Vector3Int localPos, TileType type)
		{
			bool flag = type.IsBaseGroundTile();
			foreach (PugMapLayer allLayer in allLayers)
			{
				if (allLayer.def.dataTile == type || (flag && allLayer.def.dataTile.IsBaseGroundTile()))
				{
					dataModifier.Set(localPos, allLayer.tilesetKey, allLayer.def.dataTile, value: false);
					_SetInCache(localPos, 0, allLayer.def.dataTile, 0, value: false);
					SetDirty(localPos, isLocalPos: true);
				}
			}
		}

		private void _SetInCache(Vector3Int localPos, int tileset, TileType tileType, int state, bool value = true)
		{
			Vector3Int vector3Int = LocalCoordToTileLookUpPosition(localPos.x, localPos.z);
			TileData tileData = multiMap.tileLookup[vector3Int.x, vector3Int.z].Find((TileData x) => x.info.tileType == tileType);
			if (value)
			{
				if (tileData == null)
				{
					Vector3 position = base.transform.position + localPos;
					multiMap.tileLookup[vector3Int.x, vector3Int.z].Add(new TileData(new TileInfo(tileset, tileType, state), position));
					tileCount++;
				}
				else
				{
					tileData.info.tileset = tileset;
					tileData.info.state = state;
				}
			}
			else if (tileData != null)
			{
				multiMap.tileLookup[vector3Int.x, vector3Int.z].Remove(tileData);
				tileCount--;
			}
		}

		public void SetTile(Vector3 worldPos, int tileset, TileType tiletype, int state, bool rebuild = true)
		{
			PugMapLayer pugMapLayer = EnsureLayerPresent(tileset, TileTypeToLayerName.GetLayerName(tiletype));
			if (pugMapLayer == null)
			{
				Debug.LogError("no such tileset/type");
				return;
			}
			QuadGenerator def = pugMapLayer.def;
			Vector3Int vector3Int = ToMapCoord(worldPos);
			if (def == null)
			{
				Debug.Log(tileset + " " + tiletype);
			}
			_ClearTileOfType(vector3Int, def.dataTile);
			if (def.isDataLayer)
			{
				dataModifier.Set(vector3Int, pugMapLayer.tilesetKey, pugMapLayer.def.dataTile);
				_SetInCache(vector3Int, tileset, def.dataTile, state);
				SetDirty(vector3Int, isLocalPos: true);
			}
			if (rebuild)
			{
				Build();
			}
		}

		public void MergeAnyOverlappingChunks()
		{
			foreach (PugMapLayer allLayer in allLayers)
			{
				if (allLayer.def.dataTile != TileType.none)
				{
					dataModifier.MergeAnyOverlappingChunks(allLayer.tilesetKey, allLayer.def.dataTile);
				}
			}
		}

		public Type RemoveObject(int preferedPrefabRemove, Vector2 position)
		{
			Transform transform = null;
			Type result = null;
			foreach (Transform yankableChild in GetYankableChildren())
			{
				if (!(yankableChild.Position2D().Round() == position.Round()))
				{
					continue;
				}
				Component component = yankableChild.GetComponent(typeof(IEntityMonoBehaviourData));
				if (component != null)
				{
					int objectIndex = PugMapObjectUtility.GetObjectIndex(component as IEntityMonoBehaviourData);
					transform = yankableChild;
					result = component.GetType();
					if (objectIndex == preferedPrefabRemove)
					{
						break;
					}
				}
			}
			if (transform != null)
			{
				UnityEngine.Object.DestroyImmediate(transform.gameObject);
			}
			return result;
		}

		public void RemoveAllObjectsAtPosition(Vector2 position)
		{
			List<Transform> list = new List<Transform>();
			foreach (Transform yankableChild in GetYankableChildren())
			{
				if (yankableChild.Position2D().Round() == position.Round())
				{
					list.Add(yankableChild);
				}
			}
			foreach (Transform item in list)
			{
				UnityEngine.Object.DestroyImmediate(item.gameObject);
			}
		}

		public void LoadMapDataJson(string json)
		{
			PugMapData pugMapData = new PugMapData(bounds);
			JsonUtility.FromJsonOverwrite(json, pugMapData);
			Build(pugMapData);
		}

		public string SaveMapDataJson()
		{
			return JsonUtility.ToJson(data);
		}

		public PugMapData SaveMapData()
		{
			return new PugMapData(data);
		}
	}
}
