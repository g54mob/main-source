using System;
using System.Collections.Generic;
using FixMath;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	[RequireComponent(typeof(CitySchedulePlanner))]
	public class CityDefinition : MonoBehaviour
	{
		public enum DestinationVisualVariantType
		{
			Standard = 0,
			SpireShadows = 1
		}

		public TrafficSide trafficSide;

		[HideInInspector]
		public ZoomParameters cameraZoom = new ZoomParameters();

		[SerializeField]
		private SwapByFeature_CityTilemap _tilemap = new SwapByFeature_CityTilemap();

		public CitySchedulePlanner schedulePlanner;

		public UpgradeCycleDefinition upgradeDefinitions;

		public CityStartOffsets startingOffsets;

		public SpawnRampParameters spawnRamp;

		[SerializeField]
		[Tooltip("If the game mode (endless) uses this curve, it has a minimum house count at a particular day.")]
		[HideInInspector]
		private AnimationCurve _housesAtDay = AnimationCurve.Linear(0f, 0f, 400f, 100f);

		[HideInInspector]
		[SerializeField]
		private int[] _efficiencyMilestoneIntervals = new int[11]
		{
			10, 60, 100, 140, 180, 220, 260, 300, 340, 380,
			420
		};

		[SerializeField]
		private float _expectedPointAttrition = 0.65f;

		[SerializeField]
		private float _expectedTrafficPerHouse = 0.2f;

		public TextAsset audioLoadout;

		public GameObject[] bonusTreeGrassObjects;

		private bool _isCompiled;

		private RectInt _playableArea;

		public DestinationVisualVariantType destinationVisualVariantType;

		private readonly HashSet<UpgradeType> _availableUpgrades = new HashSet<UpgradeType>();

		public CityTilemapMeshGenerator CityTilemapMeshGenerator { get; private set; }

		public virtual CitySpawningLayerData TileWeightData => ((CityTilemap)_tilemap).TileWeightData;

		public RectInt PlayableArea => _playableArea;

		public int GetHousesAtDay(int day)
		{
			return (int)_housesAtDay.Evaluate(day);
		}

		protected virtual void Awake()
		{
			if (Application.isPlaying)
			{
				CityTilemapMeshGenerator = GetComponent<CityTilemapMeshGenerator>();
			}
		}

		public bool UsesUpgradeType(UpgradeType type)
		{
			if (_availableUpgrades.Count == 0)
			{
				UpgradePackageDefinition[] startingPackages = upgradeDefinitions.startingPackages;
				for (int i = 0; i < startingPackages.Length; i++)
				{
					UpgradePackageDefinition upgradePackageDefinition = startingPackages[i];
					if (!_availableUpgrades.Contains(upgradePackageDefinition.type))
					{
						_availableUpgrades.Add(upgradePackageDefinition.type);
					}
				}
				WeeklyUpgradeDefinition[] weeklyChoicePackages = upgradeDefinitions.weeklyChoicePackages;
				foreach (WeeklyUpgradeDefinition weeklyUpgradeDefinition in weeklyChoicePackages)
				{
					if (!_availableUpgrades.Contains(weeklyUpgradeDefinition.package.type))
					{
						_availableUpgrades.Add(weeklyUpgradeDefinition.package.type);
					}
				}
			}
			return _availableUpgrades.Contains(type);
		}

		public Fix64 GetEfficiencyMilestone(int index, int increaseAfterPrecalculatedIntervals)
		{
			int num = _efficiencyMilestoneIntervals.Length;
			if (index < num)
			{
				return (Fix64)_efficiencyMilestoneIntervals[index];
			}
			return (Fix64)(_efficiencyMilestoneIntervals[num - 1] + (index - num + 1) * increaseAfterPrecalculatedIntervals);
		}

		public void CompileTilemap()
		{
			if (!_isCompiled)
			{
				_isCompiled = true;
				Fix64 fix = City.PlayableRatio * cameraZoom.endSize;
				Fix64 endSize = cameraZoom.endSize;
				int num = Fix64.CeilToInt(-fix * Fix64Consts.OneHalf);
				int num2 = Fix64.CeilToInt(-endSize * Fix64Consts.OneHalf);
				int num3 = Fix64.FloorToInt(fix * Fix64Consts.OneHalf) + 1;
				int num4 = Fix64.FloorToInt(endSize * Fix64Consts.OneHalf) + 1;
				_playableArea = new RectInt
				{
					x = num,
					y = num2,
					width = num3 - num,
					height = num4 - num2
				};
				CityTilemap cityTilemap = (CityTilemap)_tilemap;
				if (cityTilemap != null)
				{
					cityTilemap.Compile(_playableArea);
				}
			}
		}

		public virtual DensityGroup DensityForPosition(Vector2Int position)
		{
			return ((CityTilemap)_tilemap).DensityForPosition((Vector3Int)position);
		}

		public virtual bool TileSupportsCircleDestinations(int groupIndex, Vector2Int position)
		{
			return ((CityTilemap)_tilemap).TileSupportsCircleDestinations(groupIndex, (Vector3Int)position);
		}

		public virtual IEnumerable<Tuple<Vector2Int, int>> GetTreeData(bool includeBonusTrees)
		{
			CityTilemap tilemap = (CityTilemap)_tilemap;
			if (!(tilemap != null))
			{
				yield break;
			}
			if ((UnityEngine.Object)(object)tilemap.treeTilemap != null)
			{
				foreach (Vector3Int item in tilemap.treeTilemap.cellBounds.allPositionsWithin)
				{
					TileBase tile = tilemap.treeTilemap.GetTile(item);
					if (tile is TreeTile)
					{
						TreeTile treeTile = tile as TreeTile;
						yield return new Tuple<Vector2Int, int>((Vector2Int)item, treeTile.prefabIndex);
					}
				}
			}
			if (!((UnityEngine.Object)(object)tilemap.bonusTreeTilemap != null && includeBonusTrees))
			{
				yield break;
			}
			foreach (Vector3Int item2 in tilemap.bonusTreeTilemap.cellBounds.allPositionsWithin)
			{
				TileBase tile2 = tilemap.bonusTreeTilemap.GetTile(item2);
				if (tile2 is TreeTile)
				{
					TreeTile treeTile2 = tile2 as TreeTile;
					yield return new Tuple<Vector2Int, int>((Vector2Int)item2, treeTile2.prefabIndex);
				}
			}
		}

		public virtual bool TileIsBuildable(Vector2Int tileCoordinates)
		{
			return ((CityTilemap)_tilemap).TileIsBuildable(tileCoordinates);
		}

		public virtual bool TileIsZoneable(Vector2Int tileCoordinates)
		{
			return ((CityTilemap)_tilemap).TileIsZoneable(tileCoordinates);
		}

		public virtual bool TileIsOverWater(Vector2Int tileCoordinates)
		{
			return ((CityTilemap)_tilemap).TileIsOverWater(tileCoordinates);
		}

		public virtual bool TileIsUnderAMountain(Vector2Int tileCoordinates)
		{
			return ((CityTilemap)_tilemap).TileIsUnderAMountain(tileCoordinates);
		}

		public virtual bool TileIsOverRail(Vector2Int tileCoordinates)
		{
			return ((CityTilemap)_tilemap).TileIsOverRail(tileCoordinates);
		}

		public virtual bool TileIsDriveable(Vector2Int tileCoordinates)
		{
			return ((CityTilemap)_tilemap).TileIsDriveable(tileCoordinates);
		}

		public Vector3Fixed GenerateCityStartOffset(PseudorandomGenerator pseudorandomGenerator)
		{
			if (startingOffsets.Count == 0)
			{
				return Vector3Fixed.zero;
			}
			int index = pseudorandomGenerator.Int(startingOffsets.Count);
			CityStartOffsetDefinition cityStartOffsetDefinition = startingOffsets.offsets[index];
			Fix64 variance = cityStartOffsetDefinition.variance;
			Fix64 fix = variance * (pseudorandomGenerator.Fix64(Fix64Consts.Two) - Fix64Consts.One);
			Fix64 fix2 = variance * (pseudorandomGenerator.Fix64(Fix64Consts.Two) - Fix64Consts.One);
			return new Vector3Fixed(cityStartOffsetDefinition.fixedPosition.x + fix, cityStartOffsetDefinition.fixedPosition.y + fix2, cityStartOffsetDefinition.fixedPosition.z);
		}

		public TrainNetworkDefinition GetTrainNetworkDefinition()
		{
			return TrainNetworkDefinition.CreateFromRailTileCoordinates(CompileRailTileCoordinates());
		}

		protected virtual Dictionary<Vector2Int, RailType> CompileRailTileCoordinates()
		{
			Dictionary<Vector2Int, RailType> dictionary = new Dictionary<Vector2Int, RailType>();
			Tilemap tilemap = ((CityTilemap)_tilemap)?.railTilemap;
			if ((UnityEngine.Object)(object)tilemap != null)
			{
				foreach (Vector3Int item in tilemap.cellBounds.allPositionsWithin)
				{
					TileBase tile = tilemap.GetTile(item);
					if (tile != null)
					{
						RailType value = RailType.Normal;
						if (tile is WeightTile weightTile && weightTile.sprite.name == "blank_s")
						{
							value = RailType.TrainOrigin;
						}
						dictionary.Add((Vector2Int)item, value);
					}
				}
			}
			return dictionary;
		}

		public BoatNetworkDefinition GetBoatPathNetworkDefinition()
		{
			return BoatNetworkDefinition.CreateFromBoatPathTileCoordinates(CompileBoatPathTileCoordinates());
		}

		protected virtual Dictionary<Vector2Int, BoatPathType> CompileBoatPathTileCoordinates()
		{
			Dictionary<Vector2Int, BoatPathType> dictionary = new Dictionary<Vector2Int, BoatPathType>();
			Tilemap tilemap = ((CityTilemap)_tilemap)?.boatPathTilemap;
			if ((UnityEngine.Object)(object)tilemap != null)
			{
				foreach (Vector3Int item in tilemap.cellBounds.allPositionsWithin)
				{
					TileBase tile = tilemap.GetTile(item);
					if (tile != null)
					{
						BoatPathType value = BoatPathType.Normal;
						if (tile is WeightTile weightTile && weightTile.sprite.name == "blank_s")
						{
							value = BoatPathType.BoatOrigin;
						}
						dictionary.Add((Vector2Int)item, value);
					}
				}
			}
			return dictionary;
		}

		private void OnValidate()
		{
			if (upgradeDefinitions.weeklyChoicePackages == null)
			{
				return;
			}
			WeeklyUpgradeDefinition[] weeklyChoicePackages = upgradeDefinitions.weeklyChoicePackages;
			foreach (WeeklyUpgradeDefinition weeklyUpgradeDefinition in weeklyChoicePackages)
			{
				if (weeklyUpgradeDefinition.expectedUpgradeTimeline != null && weeklyUpgradeDefinition.expectedUpgradeTimeline.Count > 1)
				{
					weeklyUpgradeDefinition.expectedUpgradeTimeline.Sort((ExpectedUpgradeTimeline x, ExpectedUpgradeTimeline y) => x.week.CompareTo(y.week));
				}
			}
		}
	}
}
