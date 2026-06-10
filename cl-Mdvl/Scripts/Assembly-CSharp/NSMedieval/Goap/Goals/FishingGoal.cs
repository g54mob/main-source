using System;
using System.Collections.Generic;
using System.Linq;
using Effects;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Managers;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FishingGoal : Goal
	{
		private const string FishingLineEffectPrefab = "FishingLineEffect";

		private const float FishingRadius = 6f;

		private GameObject fishingLineEffect;

		private List<TargetObject> fishToFish;

		private bool repeatAfterFail;

		private FishMapResourceInstance fishMapResourceInstance;

		public FishingGoal(Agent selfAgent)
			: base("FishingGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<FishMapResourceInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData, HandleReservations));
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.IsOnFire)
			{
				return false;
			}
			return creatureBase.Map.GetObjectCount(GridDataType.FishMapResource) > 0;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			(base.AgentOwner as IToolAgent)?.HideTool();
			FishMapResourceInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<FishMapResourceInstance>();
			if (objectAs != null)
			{
				fishMapResourceInstance = objectAs;
			}
			if (fishingLineEffect != null)
			{
				UnityEngine.Object.Destroy(fishingLineEffect);
				fishingLineEffect = null;
			}
			fishToFish.Clear();
			repeatAfterFail = false;
			base.EndGoalWith(condition);
			if (condition == GoalCondition.Succeeded)
			{
				HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
				if (obj != null && obj.WorkerBehaviour.ActiveJobCombination.HasFlag(JobType.Hauling))
				{
					MonoSingleton<GoapController>.Instance.OnGoalStartedEvent += OnGoalStarted;
					base.AgentOwner.OnDisposedEvent += OnAgentOwnerDestroyed;
					goto IL_00da;
				}
			}
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
			goto IL_00da;
			IL_00da:
			if (condition == GoalCondition.Succeeded)
			{
				MonoSingleton<AchievementManager>.Instance.IncreaseStat("FISHING_CNT");
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(OrderLost);
			CreatureBase ownerCreature = (CreatureBase)base.AgentOwner;
			GoapAction goapAction = MapResourceActions.StartObtaining(TargetIndex.A, OrderType.Fishing, hideToolAtComplete: false, MapResourceActions.FailType.FailAction);
			GoapAction secondTryJumpPoint = GeneralActions.Instant("SecondTryJumpPoint");
			GoapAction fishingSuccessJumpPoint = GeneralActions.Instant("FishingSuccessJumpPoint");
			goapAction.TriggerAnimation("Fishing", ActionAnimationMode.Interrupt);
			goapAction.OnInit = delegate
			{
				ownerCreature.FaceObject(GetTarget(TargetIndex.A).ObjectInstance.GetPosition().SnapToGrid());
				CreateFishingLine();
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Fail)
				{
					DamagePopup.Create(((IHarvestAgent)base.AgentOwner).GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("fishing_failed"), Color.red);
					if (repeatAfterFail)
					{
						repeatAfterFail = false;
						JumpToAction(secondTryJumpPoint);
					}
				}
				else
				{
					JumpToAction(fishingSuccessJumpPoint);
				}
			};
			yield return goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A).FailAtCondition(OrderLost);
			yield return secondTryJumpPoint;
			GoapAction goapAction2 = MapResourceActions.StartObtaining(TargetIndex.A, OrderType.Fishing, hideToolAtComplete: false);
			goapAction2.TriggerAnimation("Fishing", ActionAnimationMode.Interrupt);
			goapAction2.OnInit = delegate
			{
				ownerCreature.FaceObject(GetTarget(TargetIndex.A).ObjectInstance.GetPosition().SnapToGrid());
				CreateFishingLine();
			};
			goapAction2.OnComplete = delegate
			{
				if (base.State == GoalState.Ended)
				{
					DamagePopup.Create(((IHarvestAgent)base.AgentOwner).GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("fishing_failed"), Color.red);
				}
			};
			yield return goapAction2.FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A).FailAtCondition(OrderLost);
			yield return fishingSuccessJumpPoint;
			yield return PostFishingClarity();
			GoapAction spawnFishPileCustom = new GoapAction("SpawnFishPileCustom");
			spawnFishPileCustom.OnInit = delegate
			{
				MapResourceInstance objectAs = spawnFishPileCustom.Goal.GetTarget(TargetIndex.A).GetObjectAs<MapResourceInstance>();
				HarvestParametars miningParameters = objectAs.GetMiningParameters();
				IHarvestAgent harvestAgent = (IHarvestAgent)spawnFishPileCustom.Goal.AgentOwner;
				int totalResources;
				List<ResourceInstance> obtainableResources = MapResourceActions.GetObtainableResources(objectAs, OrderType.Fishing, miningParameters, harvestAgent, out totalResources);
				harvestAgent.AddExperience(miningParameters.RewardedSkill, miningParameters.RewardAmount);
				((FishMapResourceInstance)objectAs)?.OnFishCatch();
				bool flag = false;
				foreach (ResourceInstance item in obtainableResources)
				{
					if (item == null || item.Blueprint == null)
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FishingGoal.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("This should never happen... ");
							messageBuilder.AppendFormatted(spawnFishPileCustom.AgentOwner);
						}
						Log.Error(messageBuilder);
					}
					else
					{
						flag |= item.Blueprint.Nutrition > 0f;
						ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(item, harvestAgent.GetPosition());
						if (!(resourcePileView == null))
						{
							MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(resourcePileView.ResourcePileInstance);
							MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileView.ResourcePileInstance, base.AgentOwner);
						}
					}
				}
				ListPool<ResourceInstance>.Return(obtainableResources);
			};
			yield return spawnFishPileCustom;
		}

		private bool FindFishingSpot(TargetObject fishTargetObject, out Vec3Int fishingPosition)
		{
			Vec3Int ownerPosition = ((CreatureBase)base.AgentOwner).GetGridPosition();
			float fishSpotScore = float.PositiveInfinity;
			MapNode nodeForFishing = null;
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			Vec3Int fishPosition = fishTargetObject.ObjectInstance.GetGridPosition();
			MapNode fishNode = VillageManager.ActiveVillage.Map.GetNode(fishPosition);
			CheckCurrentAgentPosition();
			TryFindValidNode(fishNode.GetNodeAbove());
			TryFindValidNode(fishNode.GetNodeAbove()?.GetNodeAbove());
			if (nodeForFishing == null && fishNode.WaterLevel == WaterDepthLevel.Low)
			{
				TryFindValidNode(fishNode);
			}
			if (nodeForFishing != null)
			{
				fishingPosition = nodeForFishing.Position;
				return true;
			}
			fishingPosition = Vec3Int.zero;
			return false;
			void CheckCurrentAgentPosition()
			{
				if (!CombatUtils.IsNullOrDisposed(pathfindingAgent) && !(Vector3.Distance(fishNode.WorldPosition, pathfindingAgent.GetPosition()) > 6f))
				{
					MapNode node = pathfindingAgent.GetNode();
					if ((node.WaterDepthLevel == WaterDepthLevel.None || node.WaterDepthLevel == WaterDepthLevel.Low) && CombatUtils.HasCombatLos(node.WorldPosition, fishNode.GetNodeAbove().WorldPosition))
					{
						float num = 0f;
						num += (float)Vec3Int.DistanceSquared(node.Position, in fishPosition) * 5f;
						num += (float)Vec3Int.DistanceSquared(node.Position, in ownerPosition);
						if (node.DataType.HasFlag(GridDataType.PlantMapResource))
						{
							num -= 300f;
						}
						fishSpotScore = num;
						nodeForFishing = node;
					}
				}
			}
			void TryFindValidNode(MapNode startNode)
			{
				if (startNode != null)
				{
					MapNodeUtils.ForEachConnectedInRadius(startNode, 0f, 6f, delegate(MapNode node)
					{
						if (!PathfinderUtil.IsPathPossible(pathfindingAgent, node.Position))
						{
							return true;
						}
						if (node == startNode)
						{
							return true;
						}
						if (node.Position.x == startNode.Position.x && node.Position.z == startNode.Position.z)
						{
							return true;
						}
						if (node.Map.FireSimLogic.GetFireData(node.Index) > 0f)
						{
							return true;
						}
						if (node.IsWalkable && (node.WaterDepthLevel == WaterDepthLevel.None || node.WaterDepthLevel == WaterDepthLevel.Low))
						{
							float num = 0f;
							if (node.Map.CreaturesOnNodes.TryGetValue(node.Index, out var value) && value.Count >= 1 && !value.Contains(pathfindingAgent as CreatureBase))
							{
								return true;
							}
							if (!CombatUtils.HasCombatLos(node.WorldPosition, fishNode.GetNodeAbove().WorldPosition))
							{
								return true;
							}
							num += (float)Vec3Int.DistanceSquared(node.Position, in fishPosition) * 5f;
							num += (float)Vec3Int.DistanceSquared(node.Position, in ownerPosition);
							if (node.DataType.HasFlag(GridDataType.PlantMapResource))
							{
								num += 300f;
							}
							if (!(num < fishSpotScore))
							{
								return true;
							}
							fishSpotScore = num;
							nodeForFishing = node;
						}
						return true;
					});
				}
			}
		}

		private GoapAction PostFishingClarity()
		{
			GoapAction goapAction = GeneralActions.Wait(2f);
			goapAction.OnComplete = delegate
			{
				(base.AgentOwner as IToolAgent)?.HideTool();
			};
			return goapAction;
		}

		private void CreateFishingLine()
		{
			WorkerView agentView = ((CreatureBase)base.AgentOwner).GetAgentView<WorkerView>();
			if (!(agentView == null))
			{
				GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("FishingLineEffect");
				fishingLineEffect = UnityEngine.Object.Instantiate(byAddress);
				FishingLineEffect componentInChildren = fishingLineEffect.GetComponentInChildren<FishingLineEffect>();
				Transform particleTransform = agentView.GetCurrentTool().GetComponent<ToolHelper>().ParticleTransform;
				Transform transform = MonoSingleton<FishResourceManager>.Instance.GetView(GetTarget(TargetIndex.A).GetObjectAs<FishMapResourceInstance>()).transform;
				componentInChildren.SetStart(particleTransform);
				componentInChildren.SetTarget(transform);
			}
		}

		private bool PrepareData()
		{
			repeatAfterFail = true;
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				if (target.GetObjectAs<FishMapResourceInstance>().CurrentOrder == OrderType.Fishing && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					fishToFish = new List<TargetObject> { target };
					return true;
				}
				base.PreferredReservableHandler.ClearTarget();
			}
			IPathfindingAgent pathfindingAgent = base.AgentOwner as IPathfindingAgent;
			fishToFish = new List<TargetObject>();
			foreach (FishMapResourceInstance item in PathfinderCore.FetchList(GridDataType.FishMapResource))
			{
				if (item != null && !item.HasDisposed && item.CurrentOrder == OrderType.Fishing)
				{
					if (PathfinderUtil.IsPathPossible(pathfindingAgent, item))
					{
						fishToFish.Add(new TargetObject(item, item.GridDataPosition));
					}
					MapNode startNode = item.GetNode()?.GetNodeAbove().GetNodeAbove();
					FoundValidNodeAbove(startNode, item);
				}
			}
			if (fishToFish != null)
			{
				return fishToFish.Count != 0;
			}
			return false;
			bool FoundValidNodeAbove(MapNode mapNode, FishMapResourceInstance fishMapResourceInstance2)
			{
				if (mapNode == null)
				{
					return false;
				}
				bool result = false;
				MapNodeUtils.ForEachConnectedInRadius(mapNode, 0f, 6f, delegate(MapNode node)
				{
					if (!PathfinderUtil.IsPathPossible(pathfindingAgent, node.Position))
					{
						return true;
					}
					fishToFish.Add(new TargetObject(fishMapResourceInstance2, fishMapResourceInstance2.GridDataPosition));
					result = true;
					return false;
				});
				return result;
			}
		}

		private bool HandleReservations()
		{
			foreach (TargetObject item in fishToFish)
			{
				if (MonoSingleton<ReservationManager>.Instance.CanReserve(item.GetAsReservable(), base.AgentOwner) && FindFishingSpot(item, out var fishingPosition) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(item.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, item);
					SetTarget(TargetIndex.B, new TargetObject(fishingPosition));
					return true;
				}
			}
			return false;
		}

		private bool OrderLost()
		{
			return GetTarget(TargetIndex.A).GetObjectAs<FishMapResourceInstance>().CurrentOrder != OrderType.Fishing;
		}

		private void TryToHaulProducedItems(FishMapResourceInstance fishMapResourceInstance)
		{
			if (fishMapResourceInstance == null)
			{
				return;
			}
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			Resource fishResourceBlueprint = fishMapResourceInstance.Blueprint.StoredResources.First().Blueprint;
			if (fishResourceBlueprint == null)
			{
				return;
			}
			ResourcePileInstance bestPile = null;
			FloodFillUtil.FloodFillConnections(humanoidInstance.Map, humanoidInstance.GetGridPosition(), 5f, delegate(MapNode node)
			{
				if (!(node.GetWorldObject(GridDataType.ResourcePile) is ResourcePileInstance { CanBeHauled: not false } resourcePileInstance))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (resourcePileInstance.Blueprint == fishResourceBlueprint)
				{
					bestPile = ((bestPile == null) ? resourcePileInstance : ((resourcePileInstance.Blueprint.HaulPriority > bestPile.Blueprint.HaulPriority) ? resourcePileInstance : bestPile));
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			if (bestPile == null || !MonoSingleton<ReservationManager>.Instance.TryReserveObject(bestPile, base.AgentOwner))
			{
				return;
			}
			MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(base.AgentOwner, bestPile);
			base.Agent.ForceNextGoal("StockpileHaulingGoal");
			MonoSingleton<TaskController>.Instance.WaitFor(1.5f).Then(delegate
			{
				if (!base.Agent.HasDisposed && !bestPile.HasDisposed && !base.Agent.CurrentGoalName.Equals("StockpileHaulingGoal"))
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(bestPile, base.AgentOwner);
				}
			});
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
					TryToHaulProducedItems(fishMapResourceInstance);
				}
				MonoSingleton<GoapController>.Instance.OnGoalStartedEvent -= OnGoalStarted;
			}
		}
	}
}
