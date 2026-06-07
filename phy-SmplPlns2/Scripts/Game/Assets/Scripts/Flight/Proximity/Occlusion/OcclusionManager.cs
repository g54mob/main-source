using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public class OcclusionManager : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker AddTilesFromBakedBlock = new ProfilerMarker("OcclusionManager.AddTilesFromBakedBlock");

			public static readonly ProfilerMarker CreateFeatureData = new ProfilerMarker("OcclusionManager.CreateFeatureData");

			public static readonly ProfilerMarker DifferentialCullingUpdate = new ProfilerMarker("OcclusionManager.DifferentialCullingUpdate");

			public static readonly ProfilerMarker FullCullingUpdate = new ProfilerMarker("OcclusionManager.FullCullingUpdate");

			public static readonly ProfilerMarker GetFeatureDataByID = new ProfilerMarker("OcclusionManager.GetFeatureDataByID");

			public static readonly ProfilerMarker RegisterFeature = new ProfilerMarker("OcclusionManager.RegisterFeature");

			public static readonly ProfilerMarker RemoveUnregisteredFeatures = new ProfilerMarker("OcclusionManager.RemoveUnregisteredFeatures");

			public static readonly ProfilerMarker SetVisibleAll = new ProfilerMarker("OcclusionManager.SetVisibleAll");

			public static readonly ProfilerMarker UnregisterFeature = new ProfilerMarker("OcclusionManager.UnregisterFeature");

			public static readonly ProfilerMarker Update = new ProfilerMarker("OcclusionManager.Update");
		}

		private readonly Dictionary<int, FeatureData> _features = new Dictionary<int, FeatureData>();

		[Tooltip("We only re-check occlusion if altitude changes by this threshold while in the same tile.")]
		[SerializeField]
		private float _altitudeRecheckThreshold = 50f;

		private int _currentActiveIndex;

		private List<FeatureResult> _currentOcclusionCandidates = new List<FeatureResult>();

		private bool _featureAdded;

		private float _lastAltitude = float.MinValue;

		private float _lastCameraFov;

		private int _lastScreenHeight;

		private Vector2Int _lastTileIndex = new Vector2Int(int.MaxValue, int.MaxValue);

		[SerializeField]
		private float _minPixelSize = 5f;

		private HashSet<int> _removedFeatureIDs = new HashSet<int>();

		private BakedTileBlockManager _tileBlockManager;

		private Dictionary<Vector2Int, TileData> _tileMap = new Dictionary<Vector2Int, TileData>();

		private bool _withinBoundsOfBakedTiles;

		public static OcclusionManager Instance { get; private set; }

		public FeatureData CreateFeatureData(IOccludableFeature feature)
		{
			using (Profile.CreateFeatureData.Auto())
			{
				return new FeatureData
				{
					feature = feature,
					featureID = StringUtility.GetStableHashCode(feature.FeatureName)
				};
			}
		}

		public void RegisterFeature(IOccludableFeature feature)
		{
			using (Profile.RegisterFeature.Auto())
			{
				FeatureData featureData = CreateFeatureData(feature);
				if (_features.ContainsKey(featureData.featureID))
				{
					throw new InvalidOperationException("Occludable feature '" + feature.FeatureName + "' has already been registered");
				}
				_features[featureData.featureID] = featureData;
				_featureAdded = true;
			}
		}

		public void UnregisterFeature(IOccludableFeature feature)
		{
			using (Profile.UnregisterFeature.Auto())
			{
				int stableHashCode = StringUtility.GetStableHashCode(feature.FeatureName);
				_features.Remove(stableHashCode);
				_removedFeatureIDs.Add(stableHashCode);
			}
		}

		protected void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				_tileBlockManager = GetComponent<BakedTileBlockManager>();
			}
			else
			{
				Debug.LogError("Another Occlusion Manager already exists in the scene. Multiple Occlusion Managers in the same scene are not currently supported.", base.gameObject);
			}
		}

		protected void OnDestroy()
		{
			Instance = null;
		}

		protected void OnDisable()
		{
			SetVisibleAll(visible: true);
		}

		protected void OnEnable()
		{
			_lastCameraFov = -1f;
		}

		protected void Update()
		{
			using (Profile.Update.Auto())
			{
				_tileBlockManager.ProcessMainThreadActions();
				float tileSize = _tileBlockManager.TileSize;
				Camera mainCamera = FlightSceneScript.Instance.CameraScript.MainCamera;
				if (!mainCamera)
				{
					return;
				}
				Vector3 vector = base.transform.InverseTransformPoint(mainCamera.transform.position);
				Vector2Int vector2Int = new Vector2Int(Mathf.FloorToInt(vector.x / tileSize), Mathf.FloorToInt(vector.z / tileSize));
				float y = vector.y;
				bool flag = vector2Int != _lastTileIndex;
				bool flag2 = Mathf.Abs(y - _lastAltitude) > _altitudeRecheckThreshold;
				bool flag3 = (int)mainCamera.fieldOfView != (int)_lastCameraFov;
				bool flag4 = Screen.height != _lastScreenHeight;
				if (_featureAdded)
				{
					_featureAdded = false;
					_tileMap.Clear();
					_removedFeatureIDs.Clear();
					flag = true;
				}
				else if (_removedFeatureIDs.Count > 0)
				{
					RemoveUnregisteredFeatures();
				}
				if (flag || flag3 || flag4)
				{
					_lastCameraFov = mainCamera.fieldOfView;
					_lastScreenHeight = Screen.height;
					_lastTileIndex = vector2Int;
					_lastAltitude = y;
					if (!_tileMap.TryGetValue(vector2Int, out var value))
					{
						_withinBoundsOfBakedTiles = _tileBlockManager.IsTileWithinBounds(vector2Int);
						if (_withinBoundsOfBakedTiles)
						{
							BakedTileBlock blockForTile = _tileBlockManager.GetBlockForTile(vector2Int);
							if (blockForTile != null)
							{
								AddTilesFromBakedBlock(blockForTile);
								_tileMap.TryGetValue(vector2Int, out value);
							}
						}
					}
					if (value != null)
					{
						FullCullingUpdate(value, y);
					}
					else
					{
						SetVisibleAll(_withinBoundsOfBakedTiles);
					}
				}
				else if (flag2)
				{
					DifferentialCullingUpdate(y);
					_lastAltitude = y;
				}
			}
		}

		private void AddTilesFromBakedBlock(BakedTileBlock block)
		{
			using (Profile.AddTilesFromBakedBlock.Auto())
			{
				Parallel.For(0, block.tiles.Count, delegate(int i)
				{
					BakedTileData bakedTileData = block.tiles[i];
					Vector2Int key = new Vector2Int(block.startX + bakedTileData.tileX, block.startY + bakedTileData.tileY);
					TileData tileData = new TileData
					{
						results = new List<FeatureResult>(bakedTileData.sortedFeatureResults.Count)
					};
					foreach (BakedSortedFeatureResult sortedFeatureResult in bakedTileData.sortedFeatureResults)
					{
						if (_features.TryGetValue(sortedFeatureResult.featureID, out var value))
						{
							FeatureResult item = new FeatureResult
							{
								feature = value,
								result = 
								{
									angularSize = sortedFeatureResult.angularSize,
									minAltitude = sortedFeatureResult.minAltitude
								}
							};
							tileData.results.Add(item);
						}
					}
					lock (_tileMap)
					{
						_tileMap[key] = tileData;
					}
				});
			}
		}

		private void DifferentialCullingUpdate(float newAltitude)
		{
			using (Profile.DifferentialCullingUpdate.Auto())
			{
				while (_currentActiveIndex < _currentOcclusionCandidates.Count && newAltitude >= _currentOcclusionCandidates[_currentActiveIndex].result.minAltitude)
				{
					_currentOcclusionCandidates[_currentActiveIndex].feature.feature.SetVisible(visible: true);
					_currentActiveIndex++;
				}
				while (_currentActiveIndex > 0 && newAltitude < _currentOcclusionCandidates[_currentActiveIndex - 1].result.minAltitude)
				{
					_currentOcclusionCandidates[_currentActiveIndex - 1].feature.feature.SetVisible(visible: false);
					_currentActiveIndex--;
				}
			}
		}

		private void FullCullingUpdate(TileData td, float cameraAltitude)
		{
			using (Profile.FullCullingUpdate.Auto())
			{
				List<FeatureResult> list = new List<FeatureResult>();
				foreach (FeatureResult result in td.results)
				{
					if (result.result.angularSize / _lastCameraFov * (float)_lastScreenHeight > _minPixelSize)
					{
						list.Add(result);
					}
					else
					{
						result.feature.feature.SetVisible(visible: false);
					}
				}
				_currentOcclusionCandidates = list;
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					if (cameraAltitude >= list[i].result.minAltitude)
					{
						list[i].feature.feature.SetVisible(visible: true);
						num++;
					}
					else
					{
						list[i].feature.feature.SetVisible(visible: false);
					}
				}
				_currentActiveIndex = num;
			}
		}

		private FeatureData GetFeatureDataByID(int featureID)
		{
			using (Profile.GetFeatureDataByID.Auto())
			{
				if (_features.TryGetValue(featureID, out var value))
				{
					return value;
				}
				return null;
			}
		}

		private void RemoveUnregisteredFeatures()
		{
			if (_removedFeatureIDs.Count == 0)
			{
				return;
			}
			using (Profile.UnregisterFeature.Auto())
			{
				Parallel.ForEach(_tileMap.Values, delegate(TileData td)
				{
					for (int num2 = td.results.Count - 1; num2 >= 0; num2--)
					{
						if (_removedFeatureIDs.Contains(td.results[num2].feature.featureID))
						{
							td.results.RemoveAt(num2);
						}
					}
				});
				for (int num = _currentOcclusionCandidates.Count - 1; num >= 0; num--)
				{
					if (_removedFeatureIDs.Contains(_currentOcclusionCandidates[num].feature.featureID))
					{
						_currentOcclusionCandidates.RemoveAt(num);
					}
				}
				_currentActiveIndex = Mathf.Min(_currentActiveIndex, _currentOcclusionCandidates.Count);
				_removedFeatureIDs.Clear();
			}
		}

		private void SetVisibleAll(bool visible)
		{
			using (Profile.SetVisibleAll.Auto())
			{
				foreach (FeatureData value in _features.Values)
				{
					value.feature.SetVisible(visible);
				}
			}
		}
	}
}
