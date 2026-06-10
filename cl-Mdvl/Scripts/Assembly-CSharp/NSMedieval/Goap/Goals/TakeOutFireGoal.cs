using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Fire;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using Unity.Collections;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class TakeOutFireGoal : Goal
	{
		private const float LargeFireWaterDistance = 60f;

		private const float SmallFireWaterDistance = 30f;

		private const float LargeFireShorelineDistance = 20f;

		private const float SmallFireShorelineDistance = 10f;

		private const int SmallFireLimit = 10;

		private readonly Resource waterBucketBlueprint;

		private int selectedFireNeighbor;

		private int selectedFireNode;

		private bool isGoalForced;

		private bool useWaterBucket;

		private bool isTargetSmallFire;

		private float maxDistance;

		private float maxDistanceSquared;

		private MapNode waterNode;

		private MapNode wellWaterNode;

		private MapNode closestWaterNode;

		private TempPathfindingPointInstance shoreInstance;

		private ReservablePosition reservablePosition;

		public TakeOutFireGoal(Agent selfAgent)
			: base("TakeOutFireGoal", selfAgent)
		{
			waterBucketBlueprint = Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket");
			AddInitStep(new ThreadSequenceStep(null, PrepareDataOnThread));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
			ClearTargets();
			shoreInstance?.Dispose();
			shoreInstance = null;
			if (isGoalForced && condition == GoalCondition.Succeeded)
			{
				HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
				if (obj != null && obj.WorkerBehaviour.ActiveJobCombination.HasFlag(JobType.FireFight))
				{
					MonoSingleton<GoapController>.Instance.OnGoalStartedEvent += OnGoalStarted;
					base.AgentOwner.OnDisposedEvent += OnAgentOwnerDestroyed;
				}
			}
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "StompFire", value: false);
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
			reservablePosition?.Release(base.AgentOwner);
			reservablePosition = null;
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase asCreature = GetAsCreature();
			if (asCreature.Map.FireSimLogic.GetFlameCount(0) > 0)
			{
				return !asCreature.IsOnFire;
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction jumpWork = GeneralActions.Instant("JumpWork");
			GoapAction jumpPileCollection = GeneralActions.Instant("JumpPileCollection");
			GoapAction jumpWellWaterCollection = GeneralActions.Instant("JumpWellWaterCollection");
			yield return JumpActions.ConditionalJump(jumpPileCollection, delegate
			{
				TargetObject target = GetTarget(TargetIndex.B);
				return target.IsInitialized && target.ObjectInstance is ResourcePileInstance;
			});
			yield return JumpActions.ConditionalJump(jumpWellWaterCollection, () => GetTarget(TargetIndex.B).ObjectInstance is WellComponentInstance);
			yield return JumpActions.ConditionalJump(jumpWork, () => !useWaterBucket);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition);
			GoapAction goapAction = ResourceActions.ObtainWater(TargetIndex.B, waterBucketBlueprint, (int)(UnityEngine.Random.Range(5f, 10f) / waterBucketBlueprint.FireExtinguisher), null, closestWaterNode);
			goapAction.OnInit = delegate
			{
				if (reservablePosition != null)
				{
					WellComponentInstance wellComponentInstance = GetTarget(TargetIndex.B).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WellComponentInstance>();
					if (wellComponentInstance != null)
					{
						WellComponent component = wellComponentInstance.Map.WellComponentManager.GetComponent(wellComponentInstance);
						if (component != null)
						{
							((HumanoidInstance)base.AgentOwner).FaceObject(component.BuildingUsePositionsComponent.GetUsePositionTransform(reservablePosition.Position));
						}
					}
				}
			};
			yield return goapAction;
			yield return JumpActions.Jump(jumpWork);
			yield return jumpPileCollection;
			GoapAction goToWaterPile = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition);
			goToWaterPile.OnPreTick = delegate
			{
				if (GetAsCreature().Map.FireSimLogic.GetFireData(selectedFireNode) <= 0f)
				{
					goToWaterPile.Complete(ActionCompletionStatus.Fail);
				}
			};
			yield return goToWaterPile.FailAtCondition(NoFire);
			ResourcePileInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ResourcePileInstance>();
			float num = 1f;
			if (objectAs?.Blueprint != null)
			{
				num = objectAs.Blueprint.FireExtinguisher;
			}
			int requestedAmount = (int)(UnityEngine.Random.Range(5f, 10f) / num);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, requestedAmount).FailIfTargetDisposedOrNull(TargetIndex.B).FailAtCondition(NoFire);
			yield return JumpActions.Jump(jumpWork);
			yield return jumpWellWaterCollection;
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).FailIfTargetReservationReleases(TargetIndex.B)
				.FailAtCondition(NoFire);
			yield return ResourceActions.ObtainWater(TargetIndex.B, waterBucketBlueprint, (int)(UnityEngine.Random.Range(5f, 10f) / waterBucketBlueprint.FireExtinguisher)).FailAtCondition(NoFire);
			yield return JumpActions.Jump(jumpWork);
			yield return jumpWork;
			yield return GoToFireAction((!useWaterBucket) ? PathCompleteMode.ExactPosition : PathCompleteMode.Touch).FailAtCondition(NoFire);
			if (useWaterBucket)
			{
				yield return GetPourWaterOnFireAction();
			}
			else
			{
				yield return GetStompFireAction();
			}
			yield return GeneralActions.Wait(1f);
		}

		private bool PrepareDataOnThread()
		{
			TargetObject target = GetTarget(TargetIndex.A);
			isGoalForced = false;
			useWaterBucket = false;
			if (target.IsInitialized && !target.ReachablePosition.Equals(Vec3Int.zero))
			{
				selectedFireNode = GridDataIndexTools.FastTo1DIndexNoCheck(target.ReachablePosition);
				GetAsCreature().Map.FireSimLogic.NodesOnFireSafeOperation(SearchFireNeighbor);
			}
			else
			{
				GetAsCreature().Map.FireSimLogic.NodesOnFireSafeOperation(SearchFireAndNeighborNode);
			}
			if (selectedFireNeighbor == -1 || selectedFireNode == -1)
			{
				return false;
			}
			bool flag = GetAsCreature().Map.FireSimLogic.GetFlameCount(0) < 10;
			maxDistance = (flag ? 60f : 30f);
			maxDistanceSquared = maxDistance * maxDistance;
			ResourcePileInstance resourcePileInstance = SearchForWaterPile();
			ClearTargets();
			WellComponentInstance wellComponentInstance = null;
			Vec3Int shorePos = Vec3Int.zero;
			waterNode = null;
			wellWaterNode = null;
			closestWaterNode = null;
			if (FindWell())
			{
				wellComponentInstance = GetTarget(TargetIndex.B).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WellComponentInstance>();
				ClearTargets();
			}
			if (FindBodyOfWater())
			{
				shorePos = GetTarget(TargetIndex.B).ReachablePosition;
				ClearTargets();
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			if (FindClosestWaterSource(resourcePileInstance, wellComponentInstance, shorePos, base.AgentOwner as IPathfindingAgent, out var result))
			{
				foreach (TargetObject item in result)
				{
					ResourcePileInstance objectAs = item.GetObjectAs<ResourcePileInstance>();
					if (objectAs != null)
					{
						if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
						{
							SetTarget(TargetIndex.B, new TargetObject(objectAs));
							useWaterBucket = true;
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(wellComponentInstance, base.AgentOwner);
							break;
						}
						continue;
					}
					BaseBuildingInstance objectAs2 = item.GetObjectAs<BaseBuildingInstance>();
					if (objectAs2 != null)
					{
						WellComponentInstance componentInstance = objectAs2.GetComponentInstance<WellComponentInstance>();
						bool flag2 = false;
						if (componentInstance.ReservablePositionsComponentInstance.FreeSpace <= 0 || !componentInstance.ReservablePositionsComponentInstance.ReservablePositions.Any((ReservablePosition x) => !x.Reserved))
						{
							continue;
						}
						foreach (ReservablePosition reservablePosition in componentInstance.ReservablePositionsComponentInstance.ReservablePositions)
						{
							if (!reservablePosition.Reserved && PathfinderUtil.IsPathPossible(pathfindingAgent, reservablePosition.Position))
							{
								this.reservablePosition = reservablePosition;
								reservablePosition.Reserve(base.AgentOwner);
								SetTarget(TargetIndex.B, new TargetObject(objectAs2, reservablePosition.Position));
								closestWaterNode = wellWaterNode;
								useWaterBucket = true;
								MonoSingleton<ReservationManager>.Instance.ReleaseObject(resourcePileInstance, base.AgentOwner);
								flag2 = true;
								break;
							}
						}
						if (flag2)
						{
							break;
						}
					}
					else
					{
						TempPathfindingPointInstance objectAs3 = item.GetObjectAs<TempPathfindingPointInstance>();
						if (objectAs3 != null)
						{
							useWaterBucket = true;
							closestWaterNode = waterNode;
							SetTarget(TargetIndex.B, new TargetObject(objectAs3.GridDataPosition));
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(wellComponentInstance, base.AgentOwner);
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(resourcePileInstance, base.AgentOwner);
							break;
						}
					}
				}
			}
			SetTarget(TargetIndex.A, new TargetObject(GridDataIndexTools.FastTo3DIndex(selectedFireNeighbor)));
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
					if (componentInstance == null || componentInstance.HasDisposed || componentInstance.OwnerBuilding == null || componentInstance.OwnerBuilding.HasDisposed)
					{
						return false;
					}
					if (Vector3.SqrMagnitude(item.WorldPosition - pathfindingAgent.GetPosition()) > maxDistanceSquared)
					{
						return false;
					}
					return componentInstance.CanBeUsed ? true : false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					WellComponentInstance componentInstance = ((BaseBuildingInstance)item).GetComponentInstance<WellComponentInstance>();
					wellWaterNode = componentInstance.WaterSourceNode;
					SetTarget(TargetIndex.B, new TargetObject(item, pos));
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
		}

		private bool FindBodyOfWater()
		{
			HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
			bool foundCoast = false;
			FloodFillUtil.FloodFillConnections(humanoid.Map, humanoid.GetGridPosition(), isTargetSmallFire ? 30f : 60f, delegate(MapNode node)
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
						SetTarget(TargetIndex.B, target);
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
							waterNode = neighbour;
							TargetObject target2 = new TargetObject(node.Position);
							SetTarget(TargetIndex.B, target2);
							foundCoast = true;
							return FloodFillUtil.ScanStatus.Abort;
						}
					}
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			return foundCoast;
		}

		private ResourcePileInstance SearchForWaterPile()
		{
			GridDataType gridData = GridDataType.ResourcePile;
			ResourcePileInstance waterPileFound = null;
			CreatureBase asCreature = GetAsCreature();
			Vec3Int creaturePosition = asCreature.GetGridPosition();
			Vector3 creatureWorldPosition = asCreature.GetPosition();
			float minDist = -1f;
			int foundCount = 0;
			PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = gridData,
				DoQuickSearch = true,
				Condition = delegate(WorldObject obj)
				{
					if (obj.Map.WaterManager.GetWaterLevelAsDepth(obj.GridDataPosition) == WaterDepthLevel.High)
					{
						return false;
					}
					if (obj.IsOnFire)
					{
						return false;
					}
					if (!obj.OwnedByPlayer())
					{
						return false;
					}
					if (Vector3.SqrMagnitude(obj.WorldPosition - creatureWorldPosition) > maxDistanceSquared)
					{
						return false;
					}
					ResourcePileInstance resourcePileInstance = (ResourcePileInstance)obj;
					if (resourcePileInstance.IsForbidden)
					{
						return false;
					}
					if (resourcePileInstance.Frozen)
					{
						return false;
					}
					return resourcePileInstance.Blueprint.FireExtinguisher > 0f;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
					if (!MonoSingleton<ReservationManager>.Instance.CanReserve(item, base.AgentOwner))
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					foundCount++;
					float magnitude = (pos - creaturePosition).magnitude;
					if (magnitude < minDist || minDist < 0f)
					{
						minDist = magnitude;
						waterPileFound = (ResourcePileInstance)item;
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					if (magnitude <= 3f)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					if (foundCount > 15 && magnitude <= 10f)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					return (foundCount <= 100) ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
			if (waterPileFound != null)
			{
				MonoSingleton<ReservationManager>.Instance.TryReserveObject(waterPileFound, base.AgentOwner);
			}
			return waterPileFound;
		}

		private void SearchFireAndNeighborNode(NativeArray<int> nodesOnFireArray, int nodesOnFireArrayCount, NativeArray<float> flameData, NativeArray<byte> flameType)
		{
			CreatureBase asCreature = GetAsCreature();
			FireSimLogic fireSimLogic = asCreature.Map.FireSimLogic;
			HomeArea homeArea = asCreature.Map.HomeArea;
			Vec3Int b = asCreature.GetGridPosition();
			float num = 0f;
			selectedFireNeighbor = -1;
			selectedFireNode = -1;
			foreach (int item in fireSimLogic.IsFireNeighbor)
			{
				if ((fireSimLogic.NeighborFlameTypesFront[item] & 1) == 0 || flameData[item] > 0f)
				{
					continue;
				}
				float num2 = (GridDataIndexTools.FastTo3DIndex(item) - b).sqrMagnitude;
				if (selectedFireNeighbor != -1 && !(num2 < num))
				{
					continue;
				}
				MapNode mapNode = asCreature.Map.GridSpaceData[item];
				if (!PathfinderUtil.IsPathPossible(asCreature, mapNode))
				{
					continue;
				}
				int num3 = -1;
				Vec3Int[] firePossibleNeighbors3d = FireSimLogic.FirePossibleNeighbors3d;
				for (int i = 0; i < firePossibleNeighbors3d.Length; i++)
				{
					Vec3Int b2 = firePossibleNeighbors3d[i];
					int num4 = GridDataIndexTools.FastTo1DIndex(mapNode.Position + b2);
					if (num4 != -1 && flameData[num4] > 0f && homeArea.IsHomeArea(num4))
					{
						num3 = num4;
						break;
					}
				}
				if (num3 != -1)
				{
					num = num2;
					selectedFireNeighbor = item;
					selectedFireNode = num3;
				}
			}
		}

		private void SearchFireNeighbor(NativeArray<int> nodesOnFireArray, int nodesOnFireArrayCount, NativeArray<float> flameData, NativeArray<byte> flameType)
		{
			selectedFireNeighbor = -1;
			foreach (MapNode neighbour in GetAsCreature().Map.GridSpaceData[selectedFireNode].Neighbours)
			{
				if (neighbour.IsWalkable)
				{
					selectedFireNeighbor = neighbour.Index;
					isGoalForced = true;
					break;
				}
			}
		}

		private GoapAction GetStompFireAction()
		{
			GoapAction action = GeneralActions.WaitForever("StompFireAction");
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "StompFire", value: true);
			action.OnInit = delegate
			{
				GetAsCreature().SetImmuneToFire(isImmuneToFire: true);
			};
			action.OnTick = delegate(float delta)
			{
				if (selectedFireNode == -1)
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					MapNode mapNode = GetAsCreature().Map.GridSpaceData[selectedFireNode];
					if (mapNode.WorldObjects.Count > 0)
					{
						foreach (WorldObject worldObject in mapNode.WorldObjects)
						{
							foreach (MapNode item in worldObject.Nodes())
							{
								DecreaseFireSize(item, delta);
							}
						}
					}
					else
					{
						DecreaseFireSize(mapNode, delta);
					}
					if (!mapNode.IsFire)
					{
						action.Complete(ActionCompletionStatus.Success);
					}
				}
			};
			action.OnComplete = delegate
			{
				GetAsCreature().SetImmuneToFire(isImmuneToFire: false);
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "StompFire", value: false);
				MonoSingleton<AnimationController>.Instance.ResetTriggers(base.AgentOwner);
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
			};
			return action;
			static void DecreaseFireSize(MapNode node, float deltaTime)
			{
				FireSimLogic fireSimLogic = node.Map.FireSimLogic;
				float fireData = fireSimLogic.GetFireData(node.Index);
				fireData -= 0.8f * deltaTime;
				fireSimLogic.SetFireData(node.Index, Mathf.Clamp01(fireData));
			}
		}

		private GoapAction GetPourWaterOnFireAction()
		{
			GoapAction goapAction = GeneralActions.WaitForever("PourWaterOnFireAction");
			goapAction.OnPreInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status != ActionCompletionStatus.Success || selectedFireNode == -1)
				{
					return;
				}
				CreatureBase asCreature = GetAsCreature();
				foreach (ResourceInstance resource in asCreature.Storage.Resources)
				{
					float num = resource.Amount;
					asCreature.Storage.DeleteResource(resource);
					PourWaterAt(selectedFireNode, resource.Blueprint.FireExtinguisher * num, 8f);
				}
			};
			goapAction.TriggerAnimation("PourWaterOnFire", ActionAnimationMode.WaitForCompletion);
			return goapAction;
		}

		private void PourWaterAt(int nodeIndex, float damageToFire, float maxRange)
		{
			MapNode mapNode = GetAsCreature().Map.GridSpaceData[nodeIndex];
			FireSimLogic fireSimLogic = mapNode.Map.FireSimLogic;
			SnowGrassWetnessManager snowGrassWetnessManager = mapNode.Map.SnowGrassWetnessManager;
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(mapNode, maxRange))
			{
				float num = Mathf.Clamp01((float)(mapNode.Position - item.Position).sqrMagnitude / maxRange);
				float fireData = fireSimLogic.GetFireData(item.Index);
				if (fireSimLogic.GetFlameType(item.Index) != 1)
				{
					fireSimLogic.SetFireData(item.Index, Mathf.Clamp01(fireData - damageToFire * (1f - num)));
				}
				byte wetness = snowGrassWetnessManager.GetWetness(item.Index);
				int num2 = (int)Math.Clamp(Mathf.Lerp(255f, (int)wetness, num), 0f, 255f);
				snowGrassWetnessManager.SetWetness(item.Index, (byte)num2);
				if (!fireSimLogic.IsPlantCanopyOnFire(item.Index) || !(item.GetWorldObject(WorldObjectType.MapResource) is PlantMapResourceInstance plantMapResourceInstance))
				{
					continue;
				}
				foreach (Vec3Int shadowCasterPosition in plantMapResourceInstance.ShadowCasterPositions)
				{
					if (shadowCasterPosition.y != item.Position.y)
					{
						MapNode node = mapNode.Map.GetNode(shadowCasterPosition);
						if (node != null)
						{
							fireSimLogic.SetFireData(node.Index, 0f);
						}
					}
				}
			}
		}

		private GoapAction GoToFireAction(PathCompleteMode pathCompleteMode)
		{
			CreatureBase creature = GetAsCreature();
			GoapAction action = GoToActions.GoToTarget(TargetIndex.A, pathCompleteMode);
			FireSimLogic fireSimLogic = creature.Map.FireSimLogic;
			action.OnPreTick = delegate
			{
				MapNode node = creature.Map.GetNode(creature.GetGridPosition());
				if (node != null)
				{
					int index = node.Index;
					bool hasFire = fireSimLogic.GetFireData(index) > 0f;
					if (!isGoalForced && !hasFire)
					{
						MapNode mapNode = node.ConnectionsSafeSearch(delegate(MapNode conn)
						{
							if (conn.Index == -1)
							{
								return false;
							}
							hasFire = fireSimLogic.GetFireData(conn.Index) > 0f;
							return hasFire && fireSimLogic.OilBlobHealth[conn.Index] <= 0f;
						});
						if (mapNode != null)
						{
							index = mapNode.Index;
							selectedFireNode = index;
						}
					}
					if (hasFire)
					{
						action.Complete(ActionCompletionStatus.Success);
						creature.PathDriver.Abort();
					}
					else if (creature.Map.FireSimLogic.GetFireData(selectedFireNode) <= 0f)
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
				}
			};
			return action;
		}

		private CreatureBase GetAsCreature()
		{
			return (CreatureBase)base.AgentOwner;
		}

		private bool NoFire()
		{
			return GetAsCreature().Map.FireSimLogic.GetFireData(selectedFireNode) <= 0f;
		}

		private bool FindClosestWaterSource(ResourcePileInstance pile, WellComponentInstance well, Vec3Int shorePos, IPathfindingAgent agent, out List<TargetObject> result)
		{
			shoreInstance = new TempPathfindingPointInstance(shorePos.ToVector3World());
			result = PathfinderUtil.FindClosestWaterSource(pile, well, shoreInstance, agent);
			if (result != null)
			{
				return result.Count != 0;
			}
			return false;
		}

		private void OnAgentOwnerDestroyed(IDisposable disposable)
		{
			if (MonoSingleton<GoapController>.IsInstantiated())
			{
				MonoSingleton<GoapController>.Instance.OnGoalStartedEvent -= OnGoalStarted;
			}
		}

		private void OnGoalStarted(Agent agent, Goal goal)
		{
			if (base.Agent == agent)
			{
				if (goal.Id != base.Id)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
					base.Agent.ForceNextGoal("TakeOutFireGoal");
				}
				MonoSingleton<GoapController>.Instance.OnGoalStartedEvent -= OnGoalStarted;
			}
		}
	}
}
