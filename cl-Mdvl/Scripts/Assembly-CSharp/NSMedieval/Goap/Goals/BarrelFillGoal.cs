using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class BarrelFillGoal : Goal
	{
		private const float MaxContinuousBuildingDistance = 6f;

		private const int MaxContinuousBuildingsCount = 6;

		private Resource waterBucketBlueprint;

		private VillageMap map;

		private int resourceCarryAmount;

		private MapNode waterNode;

		private readonly HashSet<IStorage> reservedStorages = new HashSet<IStorage>();

		public BarrelFillGoal(Agent selfAgent)
			: base("BarrelFillGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			waterBucketBlueprint = Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket");
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<ShelfComponentInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, FindBarrels));
			AddInitStep(new ThreadSequenceStep(null, FindWaterSource));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			waterBucketBlueprint = null;
			reservedStorages.Clear();
			waterNode = null;
		}

		public override bool CanStart(bool isForced = false)
		{
			return map.ShelfComponentManager.BarrelInstanceComponent.Count > 0;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IStorageAgent;
		}

		internal override void ClearTargets(bool extraSafety = false)
		{
			ReleaseStorageReservations();
			base.ClearTargets(extraSafety);
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (base.PreferredReservableHandler != null && base.PreferredReservableHandler.HasTarget())
			{
				base.PreferredReservableHandler.ClearTarget();
			}
			ReleaseStorageReservations();
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction deliverStartAction = StorageActions.CompleteIfNoResourceInStorage(waterBucketBlueprint);
			yield return GoalUtilActions.CompleteIfNoTargetsInQueue(TargetIndex.B);
			if (GetTarget(TargetIndex.A).ObjectInstance != null)
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A);
			}
			else
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			}
			yield return ResourceActions.ObtainWater(TargetIndex.A, waterBucketBlueprint, resourceCarryAmount, null, waterNode);
			yield return deliverStartAction;
			yield return GoalUtilActions.CompleteIfNoTargetsInQueue(TargetIndex.B);
			GoapAction goapAction = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.B);
			GoapAction reserveAndQueueStorageSpaces = StorageActions.ReserveAndQueueStoragePlaces(TargetIndex.B, TargetIndex.C, delegate(IStorage storage, Vec3Int i)
			{
				reservedStorages.Add(storage);
			});
			reserveAndQueueStorageSpaces.OnPreInit = ReleaseStorageReservations;
			yield return goapAction;
			yield return reserveAndQueueStorageSpaces;
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).FailIfTargetReservationReleases(TargetIndex.B)
				.FailAtCondition(FailBarrelConditions);
			GoapAction action = ResourceActions.StoreResourceOnStockpile(TargetIndex.B).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B).FailAtCondition(FailBarrelConditions);
			yield return action.SkipOnFailure();
			yield return JumpActions.JumpIfHaveResourceInStorage(deliverStartAction, waterBucketBlueprint);
		}

		private void ReleaseStorageReservations()
		{
			if (reservedStorages.Count <= 0)
			{
				return;
			}
			foreach (IStorage reservedStorage in reservedStorages)
			{
				reservedStorage.ReleaseReservations((CreatureBase)base.AgentOwner);
			}
			reservedStorages.Clear();
		}

		private bool FindBarrels()
		{
			IStorageAgent agent = (IStorageAgent)base.AgentOwner;
			resourceCarryAmount = 0;
			BaseBuildingInstance firstBarrelFound = null;
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			if (CombatUtils.IsNullOrDisposed(pathfindingAgent))
			{
				return false;
			}
			if (base.PreferredReservableHandler.HasTarget())
			{
				ShelfComponentInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<ShelfComponentInstance>();
				if (objectAs != null && !objectAs.HasDisposed)
				{
					BaseBuildingInstance ownerBuilding = objectAs.OwnerBuilding;
					if (ownerBuilding != null && !ownerBuilding.HasDisposed && objectAs.OwnerBuilding.OwnedByPlayer() && PathfinderUtil.IsPathPossible(pathfindingAgent, objectAs.OwnerBuilding))
					{
						int maximumStorableCount = agent.Storage.GetMaximumStorableCount(waterBucketBlueprint);
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(objectAs, base.AgentOwner);
						if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
						{
							resourceCarryAmount += objectAs.GetStorageAmountForOverridenStackingLimit();
							QueueTarget(TargetIndex.B, new TargetObject(objectAs));
							if (resourceCarryAmount > maximumStorableCount)
							{
								resourceCarryAmount = maximumStorableCount;
							}
							return true;
						}
					}
				}
			}
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = pathfindingAgent,
				GridData = GridDataType.Furniture,
				Condition = delegate(WorldObject item)
				{
					if (!(item is BaseBuildingInstance { HasDisposed: false, IsForbidden: false } baseBuildingInstance))
					{
						return false;
					}
					if (baseBuildingInstance.IsOnFire)
					{
						return false;
					}
					if (!baseBuildingInstance.OwnedByPlayer())
					{
						return false;
					}
					ShelfComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ShelfComponentInstance>();
					if (componentInstance == null || !componentInstance.Blueprint.Barrel)
					{
						return false;
					}
					if (componentInstance.GetFreeSpace() <= 0)
					{
						return false;
					}
					if (componentInstance.IsForbidden())
					{
						return false;
					}
					foreach (UniversalStorage item in componentInstance.AllStorage)
					{
						if (!StorageUtils.ShouldRefill(item, componentInstance.RefillPercentageThreshold))
						{
							return false;
						}
					}
					return (firstBarrelFound == null || !(Vector3.Distance(firstBarrelFound.GetPosition(), baseBuildingInstance.GetPosition()) > 6f)) ? true : false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					MapNode node = VillageManager.ActiveVillage.Map.GetNode(pos);
					MapNode nodeAbove = node.GetNodeAbove();
					if (node.WaterLevel == WaterDepthLevel.High && nodeAbove != null && nodeAbove.IsWater && nodeAbove.WaterLevel != WaterDepthLevel.Low)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
					}
					if (GetTargetQueue(TargetIndex.A).Count > 6)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					BaseBuildingInstance baseBuildingInstance = item as BaseBuildingInstance;
					bool flag = false;
					foreach (WellComponentInstance componentInstance2 in map.WellComponentManager.ComponentInstances)
					{
						if (PathfinderUtil.IsPathPossible(pathfindingAgent, componentInstance2))
						{
							flag = true;
							break;
						}
					}
					uint area = pathfindingAgent.GetNode().Area;
					using PooledList<uint> pooledList = map.RegionAreaManager.Areas.Keys.ToPooledListJanitor();
					foreach (uint item2 in pooledList)
					{
						if (map.RegionAreaManager.Areas[item2].Regions.Any((Region x) => x.IsWater) && PathfinderUtil.IsPathPossible(pathfindingAgent.WalkableModel, area, item2, map))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
					}
					ShelfComponentInstance shelfComponentInstance = baseBuildingInstance?.GetComponentInstance<ShelfComponentInstance>();
					if (shelfComponentInstance == null || shelfComponentInstance.HasDisposed || shelfComponentInstance.OwnerBuilding == null || shelfComponentInstance.HasDisposed || shelfComponentInstance.LockState == LockState.AlwaysOpen)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
					}
					if (firstBarrelFound == null)
					{
						firstBarrelFound = baseBuildingInstance;
					}
					int maximumStorableCount2 = agent.Storage.GetMaximumStorableCount(waterBucketBlueprint);
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(firstBarrelFound, base.AgentOwner);
					if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(shelfComponentInstance, base.AgentOwner))
					{
						resourceCarryAmount += shelfComponentInstance.GetStorageAmountForOverridenStackingLimit();
						QueueTarget(TargetIndex.B, new TargetObject(shelfComponentInstance, pos));
					}
					if (resourceCarryAmount > maximumStorableCount2)
					{
						resourceCarryAmount = maximumStorableCount2;
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
				}
			});
		}

		private bool FindWaterSource()
		{
			waterNode = null;
			if (!FindWell())
			{
				return FindBodyOfWater();
			}
			return true;
		}

		private bool FindWell()
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = pathfindingAgent,
				GridData = GridDataType.Furniture,
				DoQuickSearch = true,
				Condition = delegate(WorldObject item)
				{
					if (!(item is BaseBuildingInstance { HasDisposed: false, IsForbidden: false } baseBuildingInstance))
					{
						return false;
					}
					if (baseBuildingInstance.IsOnFire)
					{
						return false;
					}
					if (!baseBuildingInstance.OwnedByPlayer())
					{
						return false;
					}
					WellComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<WellComponentInstance>();
					return (componentInstance != null && !componentInstance.HasDisposed && componentInstance.OwnerBuilding != null && !componentInstance.OwnerBuilding.HasDisposed && componentInstance.CanBeUsed) ? true : false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					WellComponentInstance componentInstance = ((BaseBuildingInstance)item).GetComponentInstance<WellComponentInstance>();
					waterNode = componentInstance.WaterSourceNode;
					SetTarget(TargetIndex.A, new TargetObject(item, pos));
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
		}

		private bool FindBodyOfWater()
		{
			HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
			bool foundCoast = false;
			FloodFillUtil.FloodFillConnections(humanoid.Map, humanoid.GetGridPosition(), 100f, delegate(MapNode node)
			{
				if (!node.IsWalkable)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (!PathfinderUtil.IsPathPossible(humanoid, node))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (node.IsWater)
				{
					if (node.WaterLevel == WaterDepthLevel.Low)
					{
						if (node.Map.StairsComponentManager.GetComponentInstance(node.Position) != null)
						{
							return FloodFillUtil.ScanStatus.Continue;
						}
						waterNode = node;
						TargetObject target = new TargetObject(node.Position);
						SetTarget(TargetIndex.A, target);
						foundCoast = true;
						return FloodFillUtil.ScanStatus.Abort;
					}
					return FloodFillUtil.ScanStatus.Continue;
				}
				MapNode nodeBelow = node.GetNodeBelow();
				if (nodeBelow == null)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				foreach (MapNode neighbour in nodeBelow.Neighbours)
				{
					if (neighbour.IsWater && !neighbour.IsFire && node.Position.y - neighbour.Position.y <= 1 && neighbour.WaterLevel != WaterDepthLevel.Low)
					{
						using PooledList<BaseBuildingInstance> pooledList = node.Map.BuildingsManagerMain.GetBuildings(neighbour.Position + Vec3Int.up, (BaseBuildingInstance x) => x.BuildingType != BuildingType.Beam && x.Blueprint.PlacementType != PlacementType.WallSocket);
						if (pooledList.Count <= 0 && !MonoSingleton<GroundManager>.Instance.GroundExists(neighbour.Position + Vec3Int.up))
						{
							TargetObject target2 = new TargetObject(node.Position);
							SetTarget(TargetIndex.A, target2);
							foundCoast = true;
							waterNode = neighbour;
							return FloodFillUtil.ScanStatus.Abort;
						}
					}
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			return foundCoast;
		}

		private bool FailBarrelConditions()
		{
			return GetTarget(TargetIndex.B).GetObjectAs<ShelfComponentInstance>()?.IsOpen ?? false;
		}
	}
}
