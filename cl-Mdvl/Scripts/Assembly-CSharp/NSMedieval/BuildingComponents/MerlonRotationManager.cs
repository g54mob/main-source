using System.Collections.Generic;
using NSMedieval.Enums;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class MerlonRotationManager : AutomaticMeshVariationManagerBase
	{
		private const string MerlonStraightVariation = "default";

		private const string MerlonCornerVariation = "corner";

		private const string MerlonInnerCorner = "corner_in";

		private static readonly Dictionary<string, string> VariationToEnumSuffix = new Dictionary<string, string>
		{
			{ "default", "Straight" },
			{ "corner", "Corner" },
			{ "corner_in", "InnerCorner" }
		};

		private readonly Dictionary<NInfo, Dictionary<int, NInfo>> neighbourAngleMap = new Dictionary<NInfo, Dictionary<int, NInfo>>();

		private readonly Dictionary<NInfo, Dictionary<string, NInfo>> neighbourTypeMap = new Dictionary<NInfo, Dictionary<string, NInfo>>();

		private readonly Dictionary<NInfo, MeshVariationRules> merlonRules = new Dictionary<NInfo, MeshVariationRules>();

		protected override BuildingType BuildingType => BuildingType.Merlon;

		public MerlonRotationManager(VillageMap map)
			: base(map)
		{
		}

		public override void Dispose()
		{
			merlonRules.Clear();
			neighbourAngleMap.Clear();
			neighbourTypeMap.Clear();
			base.Dispose();
		}

		public override void Run(IEnumerable<BaseBuildingInstance> buildings)
		{
			using PooledQueue<BaseBuildingInstance> queue = QueuePool<BaseBuildingInstance>.GetJanitor();
			foreach (BaseBuildingInstance building in buildings)
			{
				TryToRefreshMerlonVariation(building, queue, forceAddToQueue: true);
			}
			while (queue.Count > 0)
			{
				if (queue.TryDequeue(out var obj))
				{
					TryToRefreshMerlonVariation(obj, queue);
				}
			}
		}

		private void TryToRefreshMerlonVariation(BaseBuildingInstance buildingInstance, PooledQueue<BaseBuildingInstance> queue, bool forceAddToQueue = false)
		{
			NInfo buildingNeighboursFlags = GetBuildingNeighboursFlags(buildingInstance.GridDataPosition, buildingInstance, buildingsManagerMain);
			MeshVariationRules meshVariationRules = GetMeshVariationRules(buildingInstance, buildingNeighboursFlags);
			if (string.IsNullOrEmpty(meshVariationRules.VariationId) || !(LoadAndRotateBuildingMeshVariation(buildingInstance, meshVariationRules) || forceAddToQueue))
			{
				return;
			}
			NInfo[] neighbourSides = AutomaticMeshVariationManagerBase.NeighbourSides;
			foreach (NInfo key in neighbourSides)
			{
				if (AutomaticMeshVariationManagerBase.FlagToVec3Int.TryGetValue(key, out var value))
				{
					BaseBuildingInstance building = buildingsManagerMain.GetBuilding(buildingInstance.GridDataPosition + value, (BaseBuildingInstance x) => x.BuildingType == BuildingType && x != buildingInstance);
					if (building != null)
					{
						queue.Enqueue(building);
					}
				}
			}
		}

		public int GetAlignmentAngle(BaseBuildingInstance merlon, bool xAxisDrag)
		{
			if (merlon.IsMeshVariationApplied("default"))
			{
				return merlon.AdjustedAngle;
			}
			if (!merlon.IsMeshVariationApplied("corner"))
			{
				return -1;
			}
			if (xAxisDrag)
			{
				switch (merlon.AdjustedAngle)
				{
				case 90:
				case 180:
					return 90;
				case 0:
				case 270:
					return 270;
				}
			}
			else
			{
				switch (merlon.AdjustedAngle)
				{
				case 0:
				case 90:
					return 0;
				case 180:
				case 270:
					return 180;
				}
			}
			return -1;
		}

		public float GetPreviewAngleForFloorAttachment(Vec3Int gridPosition)
		{
			using PooledDictionary<NInfo, BaseBuildingInstance> pooledDictionary = GetNeighboursMap(gridPosition, BuildingType.Floor, buildingsManagerMain);
			if (pooledDictionary.Count != 1)
			{
				return -1f;
			}
			if (pooledDictionary.TryGetValue(NInfo.South, out var _))
			{
				return 90f;
			}
			if (pooledDictionary.TryGetValue(NInfo.East, out var _))
			{
				return 0f;
			}
			if (pooledDictionary.TryGetValue(NInfo.West, out var _))
			{
				return 180f;
			}
			if (pooledDictionary.TryGetValue(NInfo.North, out var _))
			{
				return 270f;
			}
			return -1f;
		}

		protected override void InitializeRules()
		{
			InitializeNeighbourInfoCache();
			InitializeRoofRules();
		}

		protected override MeshVariationRules GetMeshVariationRules(BaseBuildingInstance building, NInfo neighboursInfo)
		{
			if (!merlonRules.TryGetValue(neighboursInfo, out var value))
			{
				return default(MeshVariationRules);
			}
			return value;
		}

		protected override NInfo GetBuildingNeighboursFlags(Vec3Int centerPos, BaseBuildingInstance baseBuildingInstance, BuildingsManagerMain buildingsManager)
		{
			NInfo result = NInfo.None;
			AddToFlag(NInfo.West, centerPos + Vec3Int.left);
			AddToFlag(NInfo.North, centerPos + Vec3Int.forward);
			AddToFlag(NInfo.East, centerPos + Vec3Int.right);
			AddToFlag(NInfo.South, centerPos + Vec3Int.back);
			return result;
			void AddToFlag(NInfo location, Vec3Int position)
			{
				BaseBuildingInstance neighbour = buildingsManager.GetBuildingInstance(position, BuildingType);
				if (neighbour != null)
				{
					TryAddNeighbourLocationAndType("default");
					TryAddNeighbourLocationAndType("corner");
					TryAddNeighbourLocationAndType("corner_in");
					TryAddNeighbourAngleInfo();
				}
				void TryAddNeighbourAngleInfo()
				{
					if (neighbourAngleMap.TryGetValue(location, out var value) && value.TryGetValue(neighbour.AdjustedAngle, out var value2))
					{
						result |= value2;
					}
				}
				void TryAddNeighbourLocationAndType(string meshVariationId)
				{
					if (neighbour.IsMeshVariationApplied(meshVariationId) && neighbourTypeMap.TryGetValue(location, out var value) && value.TryGetValue(meshVariationId, out var value2))
					{
						result |= value2;
					}
				}
			}
		}

		private void InitializeNeighbourInfoCache()
		{
			neighbourAngleMap.Add(NInfo.North, new Dictionary<int, NInfo>
			{
				{
					0,
					NInfo.North0
				},
				{
					90,
					NInfo.North90
				},
				{
					180,
					NInfo.North180
				},
				{
					270,
					NInfo.North270
				}
			});
			neighbourAngleMap.Add(NInfo.South, new Dictionary<int, NInfo>
			{
				{
					0,
					NInfo.South0
				},
				{
					90,
					NInfo.South90
				},
				{
					180,
					NInfo.South180
				},
				{
					270,
					NInfo.South270
				}
			});
			neighbourAngleMap.Add(NInfo.East, new Dictionary<int, NInfo>
			{
				{
					0,
					NInfo.East0
				},
				{
					90,
					NInfo.East90
				},
				{
					180,
					NInfo.East180
				},
				{
					270,
					NInfo.East270
				}
			});
			neighbourAngleMap.Add(NInfo.West, new Dictionary<int, NInfo>
			{
				{
					0,
					NInfo.West0
				},
				{
					90,
					NInfo.West90
				},
				{
					180,
					NInfo.West180
				},
				{
					270,
					NInfo.West270
				}
			});
			neighbourTypeMap.Add(NInfo.North, new Dictionary<string, NInfo>
			{
				{
					"default",
					NInfo.NorthStraight
				},
				{
					"corner",
					NInfo.NorthCorner
				},
				{
					"corner_in",
					NInfo.NorthInnerCorner
				}
			});
			neighbourTypeMap.Add(NInfo.South, new Dictionary<string, NInfo>
			{
				{
					"default",
					NInfo.SouthStraight
				},
				{
					"corner",
					NInfo.SouthCorner
				},
				{
					"corner_in",
					NInfo.SouthInnerCorner
				}
			});
			neighbourTypeMap.Add(NInfo.East, new Dictionary<string, NInfo>
			{
				{
					"default",
					NInfo.EastStraight
				},
				{
					"corner",
					NInfo.EastCorner
				},
				{
					"corner_in",
					NInfo.EastInnerCorner
				}
			});
			neighbourTypeMap.Add(NInfo.West, new Dictionary<string, NInfo>
			{
				{
					"default",
					NInfo.WestStraight
				},
				{
					"corner",
					NInfo.WestCorner
				},
				{
					"corner_in",
					NInfo.WestInnerCorner
				}
			});
		}

		private void InitializeRoofRules()
		{
			merlonRules.Add(NInfo.None, new MeshVariationRules(-1, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.North0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.North90, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.North180, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.North270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.North0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.North180, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthInnerCorner | NInfo.North0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthInnerCorner | NInfo.North270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.EastCorner | NInfo.East0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.EastCorner | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.EastCorner | NInfo.East180, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.EastCorner | NInfo.East270, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.EastStraight | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.EastStraight | NInfo.East270, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.EastInnerCorner | NInfo.East0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.EastInnerCorner | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.South0, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.South90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.South180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.South270, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.South0, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.South180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthInnerCorner | NInfo.South180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthInnerCorner | NInfo.South90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.WestCorner | NInfo.West0, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.WestCorner | NInfo.West90, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.WestCorner | NInfo.West180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.WestCorner | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.WestStraight | NInfo.West90, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.WestStraight | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.WestInnerCorner | NInfo.West180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.WestInnerCorner | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.North0 | NInfo.South0, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.North0 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.North0 | NInfo.South270, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.South0 | NInfo.North90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.North90 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.South90 | NInfo.North180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.North180 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.North180 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.South0 | NInfo.North270, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthStraight | NInfo.South180 | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North0 | NInfo.South0, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.South0 | NInfo.North90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.South0 | NInfo.North180, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.South0 | NInfo.North270, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North0 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North90 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.South90 | NInfo.North180, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.South90 | NInfo.North270, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North0 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North90 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North180 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.South180 | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North0 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North90 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North180 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthStraight | NInfo.North270 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthInnerCorner | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.SouthInnerCorner | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North0 | NInfo.South0, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North0 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North0 | NInfo.South180, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North0 | NInfo.South270, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.South0 | NInfo.North90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North90 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North90 | NInfo.South180, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North90 | NInfo.South270, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.South0 | NInfo.North180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.South90 | NInfo.North180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North180 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North180 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.South0 | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.South90 | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.South180 | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthStraight | NInfo.North270 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.North0 | NInfo.South0, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.North0 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.South0 | NInfo.North90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.North90 | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.North180 | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.North180 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.South180 | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.North270 | NInfo.South270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.South90, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.SouthCorner | NInfo.South180, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.NorthInnerCorner | NInfo.North0, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.NorthInnerCorner | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthInnerCorner | NInfo.North0, new MeshVariationRules(0, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.NorthInnerCorner | NInfo.North270, new MeshVariationRules(180, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.West0 | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.West0 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.East0 | NInfo.West90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.West90 | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.West90 | NInfo.East180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.East90 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.West180 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.East0 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.East180 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastStraight | NInfo.West270 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West0 | NInfo.East0, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East0 | NInfo.West90, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East0 | NInfo.West180, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East0 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West0 | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West90 | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East90 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East90 | NInfo.West270, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West0 | NInfo.East180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West90 | NInfo.East180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East180 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.East180 | NInfo.West270, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West0 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West90 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West180 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.EastCorner | NInfo.WestStraight | NInfo.West270 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastInnerCorner | NInfo.East0 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestStraight | NInfo.EastInnerCorner | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West0 | NInfo.East0, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West0 | NInfo.East90, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West0 | NInfo.East180, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West0 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East0 | NInfo.West90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West90 | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West90 | NInfo.East180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West90 | NInfo.East270, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East0 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East90 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West180 | NInfo.East270, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East180 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East0 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East90 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.East180 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastStraight | NInfo.West270 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.West0 | NInfo.East0, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.East0 | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.West90 | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.East90 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.West90 | NInfo.East180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.East180 | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.West0 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastCorner | NInfo.West270 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastInnerCorner | NInfo.East0, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestCorner | NInfo.EastInnerCorner | NInfo.East90, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastStraight | NInfo.WestInnerCorner | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.EastStraight | NInfo.WestInnerCorner | NInfo.West270 | NInfo.East270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestInnerCorner | NInfo.EastInnerCorner | NInfo.West270, new MeshVariationRules(270, "default"));
			merlonRules.Add(NInfo.WestInnerCorner | NInfo.EastInnerCorner | NInfo.West180, new MeshVariationRules(90, "default"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.EastCorner | NInfo.South0 | NInfo.East180, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.EastCorner | NInfo.East0 | NInfo.South180, new MeshVariationRules(270, "corner_in"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.EastCorner | NInfo.South90 | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.EastStraight | NInfo.South180 | NInfo.East270, new MeshVariationRules(270, "corner_in"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.EastStraight | NInfo.South0 | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.EastStraight | NInfo.South90 | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.EastStraight | NInfo.South180 | NInfo.East270, new MeshVariationRules(270, "corner_in"));
			merlonRules.Add(NInfo.EastCorner | NInfo.SouthStraight | NInfo.South0 | NInfo.East90, new MeshVariationRules(90, "corner"));
			merlonRules.Add(NInfo.EastCorner | NInfo.SouthStraight | NInfo.East0 | NInfo.South180, new MeshVariationRules(270, "corner_in"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.WestCorner | NInfo.West90 | NInfo.South270, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.WestCorner | NInfo.South90 | NInfo.West270, new MeshVariationRules(0, "corner_in"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.WestCorner | NInfo.South180 | NInfo.West180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.WestStraight | NInfo.South0 | NInfo.West270, new MeshVariationRules(0, "corner_in"));
			merlonRules.Add(NInfo.SouthStraight | NInfo.WestStraight | NInfo.West90 | NInfo.South180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.WestStraight | NInfo.West90 | NInfo.South180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.SouthCorner | NInfo.WestStraight | NInfo.South90 | NInfo.West270, new MeshVariationRules(270, "corner_in"));
			merlonRules.Add(NInfo.WestCorner | NInfo.SouthStraight | NInfo.South180 | NInfo.West180, new MeshVariationRules(180, "corner"));
			merlonRules.Add(NInfo.WestCorner | NInfo.SouthStraight | NInfo.South0 | NInfo.West270, new MeshVariationRules(0, "corner_in"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.EastCorner | NInfo.North90 | NInfo.East270, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.EastCorner | NInfo.East90 | NInfo.North270, new MeshVariationRules(180, "corner_in"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.EastCorner | NInfo.North0 | NInfo.East0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.EastStraight | NInfo.East90 | NInfo.North180, new MeshVariationRules(180, "corner_in"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.EastStraight | NInfo.North0 | NInfo.East270, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.EastStraight | NInfo.North0 | NInfo.East270, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.EastStraight | NInfo.East90 | NInfo.North270, new MeshVariationRules(180, "corner_in"));
			merlonRules.Add(NInfo.EastCorner | NInfo.NorthStraight | NInfo.North0 | NInfo.East0, new MeshVariationRules(0, "corner"));
			merlonRules.Add(NInfo.EastCorner | NInfo.NorthStraight | NInfo.East90 | NInfo.North180, new MeshVariationRules(180, "corner_in"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.WestCorner | NInfo.West0 | NInfo.North180, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.WestCorner | NInfo.North0 | NInfo.West180, new MeshVariationRules(180, "corner_in"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.WestCorner | NInfo.North270 | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.WestStraight | NInfo.North0 | NInfo.West90, new MeshVariationRules(90, "corner_in"));
			merlonRules.Add(NInfo.NorthStraight | NInfo.WestStraight | NInfo.North180 | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.WestStraight | NInfo.North270 | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.NorthCorner | NInfo.WestStraight | NInfo.North0 | NInfo.West90, new MeshVariationRules(90, "corner_in"));
			merlonRules.Add(NInfo.WestCorner | NInfo.NorthStraight | NInfo.North180 | NInfo.West270, new MeshVariationRules(270, "corner"));
			merlonRules.Add(NInfo.WestCorner | NInfo.NorthStraight | NInfo.North0 | NInfo.West180, new MeshVariationRules(90, "corner_in"));
		}
	}
}
