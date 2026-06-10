using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Models.Production;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class ProductionBaseGoal : Goal
	{
		private const float ShouldNotBeInterruptedForTime = 15f;

		private readonly Resource waterBucketBlueprint;

		private readonly ushort minutesInHour;

		private readonly JobType jobType;

		private ResourceInstance singleResourceOrder;

		private ProductionStepType stepType;

		private int collectAmount;

		private int waterAmount;

		private ProductionInstance production;

		private ReservablePosition reservablePosition;

		private bool useWaterNoPile;

		protected ProductionStepType StepType => stepType;

		protected ProductionBaseGoal(string id, Agent selfAgent, JobType jobType)
			: base(id, selfAgent, GoalInterruptMode.HigherPriority)
		{
			this.jobType = jobType;
			minutesInHour = (ushort)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
			waterBucketBlueprint = Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket");
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<ProductionComponentInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IProductionAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<ProductionManager>.Instance.AllAvailable.TryGetValue(jobType, out var value))
			{
				return false;
			}
			return value.Count > 0;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			NSMedieval.Model.Production blueprint = production?.Blueprint;
			production = null;
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
			reservablePosition?.Release(base.AgentOwner);
			reservablePosition = null;
			if (condition == GoalCondition.Succeeded)
			{
				HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
				if (obj != null && obj.WorkerBehaviour.ActiveJobCombination.HasFlag(JobType.Hauling))
				{
					TryToHaulProducedItems(blueprint);
				}
			}
		}

		public override void HandleConsecutiveFail()
		{
			if (GetTarget(TargetIndex.A).IsInitialized && GetTarget(TargetIndex.A).ObjectInstance is ResourcePileInstance resourcePileInstance)
			{
				if (resourcePileInstance.InstanceStorage == null)
				{
					resourcePileInstance.IsForbidden = true;
					string localizedResourcePileName = ResourceUtils.GetLocalizedResourcePileName(resourcePileInstance.Blueprint.GetID());
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedResourcePileName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, resourcePileInstance.WorldPosition);
				}
				else if (resourcePileInstance.InstanceStorage.GetOwner is ShelfComponentInstance shelfComponentInstance)
				{
					shelfComponentInstance.SetForbidden(isForbidden: true);
				}
			}
		}

		public override bool CanBeInterrupted()
		{
			if (base.TotalTickingTime < 15f)
			{
				return false;
			}
			ProductionInstance productionInstance = GetTarget(TargetIndex.B).GetObjectAs<ProductionComponentInstance>()?.ProductionSystemInstance?.CurrentProduction;
			if (productionInstance == null)
			{
				return true;
			}
			if (productionInstance.CurrentStep == null)
			{
				return true;
			}
			if (productionInstance.CurrentStep.Blueprint.Interruptible)
			{
				return base.CanBeInterrupted();
			}
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			if (StepType != ProductionStepType.WorkerProduce && StepType != ProductionStepType.Collect)
			{
				Log.Error("This should never happen! ", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ProductionBaseGoal.cs");
				yield return null;
			}
			GoapAction begin = GeneralActions.Instant("Begin");
			yield return begin;
			GoapAction jumpCollect = GeneralActions.Instant("JumpCollect");
			GoapAction jumpWork = GeneralActions.Instant("JumpWork");
			GoapAction jumpPileCollection = GeneralActions.Instant("JumpPileCollection");
			GoapAction jumpWaterCollection = GeneralActions.Instant("JumpWaterCollection");
			GoapAction jumpResourceDelivery = GeneralActions.Instant("JumpResourceDelivery");
			yield return JumpActions.ConditionalJump(jumpCollect, () => StepType == ProductionStepType.Collect);
			yield return JumpActions.ConditionalJump(jumpWork, () => StepType == ProductionStepType.WorkerProduce);
			GoapAction selectNext = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			yield return jumpCollect;
			yield return selectNext;
			yield return JumpActions.ConditionalJump(jumpPileCollection, delegate
			{
				TargetObject target = GetTarget(TargetIndex.A);
				return target.IsInitialized && target.ObjectInstance is ResourcePileInstance;
			});
			yield return JumpActions.ConditionalJump(jumpWaterCollection, () => useWaterNoPile);
			yield return jumpWaterCollection;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			GoapAction goapAction = ResourceActions.ObtainWater(TargetIndex.A, waterBucketBlueprint, CalculateMissingWaterPickup(), delegate(Resource res, int count)
			{
				collectAmount -= count;
			});
			goapAction.OnInit = delegate
			{
				if (reservablePosition != null)
				{
					WellComponentInstance wellComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WellComponentInstance>();
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
			yield return JumpActions.Jump(jumpResourceDelivery);
			yield return jumpPileCollection;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailAtCondition(ShouldAbort).FailIfTargetDisposedForbidenOrNull(TargetIndex.A)
				.FailIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.FailIfTargetReservationReleases(TargetIndex.A);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, (Resource resource) => collectAmount, delegate(Resource res, int count)
			{
				collectAmount -= count;
			}).FailAtCondition(ShouldAbort).FailIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.FailIfTargetReservationReleases(TargetIndex.B)
				.SkipIfCondition(() => collectAmount <= 0);
			yield return JumpActions.JumpIfHaveTargetsInQueue(selectNext, TargetIndex.A, () => !(base.AgentOwner is IStorageAgent storageAgent) || storageAgent.Storage.GetFreeSpace() > 0f);
			yield return jumpResourceDelivery;
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch).FailAtCondition(ShouldAbort).FailIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.FailIfTargetReservationReleases(TargetIndex.B);
			yield return ResourceActions.DeliverProductionResource(TargetIndex.B);
			GoapAction goapAction2 = GeneralActions.Wait(0.15f);
			goapAction2.OnComplete = delegate
			{
				ClearTargetsQueue(TargetIndex.A);
				if (TryPrepareProduction(GetTarget(TargetIndex.B).GetObjectAs<ProductionComponentInstance>().ProductionSystemInstance.CurrentProduction))
				{
					JumpToAction(begin);
				}
			};
			yield return goapAction2;
			yield return jumpWork;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailAtCondition(ShouldAbort).FailIfTargetDisposedForbidenOrNull(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A)
				.SkipIfCondition(() => StepType != ProductionStepType.WorkerProduce);
			GoapAction goapAction3 = ProductionActions.Produce(TargetIndex.A, production).FailAtCondition(ShouldAbort).FailIfTargetDisposedForbidenOrNull(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A)
				.SkipIfCondition(() => StepType != ProductionStepType.WorkerProduce);
			goapAction3.OnInit = ProduceActionOnInit;
			goapAction3.OnComplete = ProduceActionOnComplete;
			yield return goapAction3;
		}

		protected virtual void ProduceActionOnComplete(ActionCompletionStatus status)
		{
		}

		protected virtual void ProduceActionOnInit()
		{
		}

		private bool PrepareData()
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (base.PreferredReservableHandler.HasTarget())
			{
				ProductionComponentInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<ProductionComponentInstance>();
				if (CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, objectAs.GetRoom()))
				{
					ProductionInstance currentProduction = objectAs.ProductionSystemInstance.CurrentProduction;
					if (currentProduction != null && TryPrepareProduction(currentProduction) && humanoidInstance.WorkerBehaviour.IsJobActive(currentProduction.Blueprint.JobType))
					{
						production = currentProduction;
						Vec3Int reachablePosition = PathfinderProduction.FindWorkPosition((IPathfindingAgent)base.AgentOwner, production.OwnerProductionComponentInstance);
						messageBuilder = new FVLogTraceInterpolationHandler(54, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ProductionBaseGoal.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Set target prod instance to '");
							messageBuilder.AppendFormatted(currentProduction.BlueprintId);
							messageBuilder.AppendLiteral("' (obj hash ");
							messageBuilder.AppendFormatted(currentProduction.GetHashCode());
							messageBuilder.AppendLiteral(") at ");
							messageBuilder.AppendFormatted(currentProduction.OwnerSystem?.Owner?.GridPosition);
							messageBuilder.AppendLiteral(", agent ");
							messageBuilder.AppendFormatted(base.AgentOwner);
						}
						Log.Trace(messageBuilder);
						SetTarget(TargetIndex.B, new TargetObject(currentProduction.OwnerProductionComponentInstance, reachablePosition));
						return true;
					}
				}
			}
			ProductionInstance productionInstance = MonoSingleton<ProductionManager>.Instance.FindAvailableProduction(jobType, humanoidInstance, TryPrepareProduction);
			if (productionInstance == null)
			{
				return false;
			}
			production = productionInstance;
			Vec3Int reachablePosition2 = PathfinderProduction.FindWorkPosition((IPathfindingAgent)base.AgentOwner, production.OwnerProductionComponentInstance);
			messageBuilder = new FVLogTraceInterpolationHandler(54, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ProductionBaseGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Set target prod instance to '");
				messageBuilder.AppendFormatted(productionInstance.BlueprintId);
				messageBuilder.AppendLiteral("' (obj hash ");
				messageBuilder.AppendFormatted(productionInstance.GetHashCode());
				messageBuilder.AppendLiteral(") at ");
				messageBuilder.AppendFormatted(productionInstance.OwnerSystem?.Owner?.GridPosition);
				messageBuilder.AppendLiteral(", agent ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Trace(messageBuilder);
			SetTarget(TargetIndex.B, new TargetObject(productionInstance.OwnerProductionComponentInstance, reachablePosition2));
			return true;
		}

		private bool TryPrepareProduction(ProductionInstance production)
		{
			ProductionStepInstance productionStepInstance = production?.CurrentStep;
			stepType = ProductionStepType.None;
			collectAmount = 0;
			waterAmount = 0;
			if (productionStepInstance == null || productionStepInstance.IsCompleted || productionStepInstance.Type == ProductionStepType.PassiveProduce)
			{
				return false;
			}
			IProductionAgent productionAgent = (IProductionAgent)base.AgentOwner;
			if (!production.Blueprint.HasSkillsRequired(productionAgent))
			{
				return false;
			}
			if (production.OwnerCreatureId != 0 && production.OwnerCreatureId != base.AgentOwner.UniqueId)
			{
				return false;
			}
			if (production.Blueprint.RequiredSkills != null && production.Blueprint.RequiredSkills.Count > 0)
			{
				SkillLevelPair skillLevelPair = production.Blueprint.RequiredSkills.First();
				if (production.SkillLevelRange != null && !production.SkillLevelRange.InRange(productionAgent.GetSkillLevel(skillLevelPair.Key)))
				{
					return false;
				}
			}
			if (!PathfinderUtil.IsPathPossibleProduction((IPathfindingAgent)base.AgentOwner, production))
			{
				return false;
			}
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(production.OwnerProductionComponentInstance, base.AgentOwner))
			{
				return false;
			}
			bool flag;
			switch (productionStepInstance.Type)
			{
			case ProductionStepType.Collect:
				flag = PrepareCollectStep(productionStepInstance);
				break;
			case ProductionStepType.WorkerProduce:
				flag = PrepareProduceStep(productionStepInstance);
				break;
			default:
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ProductionBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("This should never happen. ");
					messageBuilder.AppendFormatted(productionStepInstance.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(productionStepInstance.OwnerProductionInstance.BlueprintId);
				}
				Log.Error(messageBuilder);
				flag = false;
				break;
			}
			}
			if (!flag)
			{
				MonoSingleton<ReservationManager>.Instance.ReleaseObject(production.OwnerProductionComponentInstance, base.AgentOwner);
				return false;
			}
			stepType = productionStepInstance.Type;
			return true;
		}

		private bool PrepareCollectStep(ProductionStepInstance step)
		{
			ProductionInstance instance = step.OwnerProductionInstance;
			ProductionStepCollect stepCollect = (ProductionStepCollect)step;
			if (!stepCollect.ResourcesAllowedAvailable)
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			List<ResourceSearchFilter> missing = stepCollect.MissingResources.ToPooledList();
			foreach (ResourceSearchFilter item in missing)
			{
				num++;
				if (MonoSingleton<ResourcePileTracker>.Instance.SearchForFilterHits(item) || stepCollect.HasWaterOnMap(item))
				{
					num2++;
				}
			}
			if (num != num2)
			{
				ListPool<ResourceSearchFilter>.Return(missing);
				return false;
			}
			IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
			int needCount = 0;
			int gotCount = 0;
			List<WorldObject> list = PathfinderUtil.FindNearbyObject(obj, obj.GetGridPosition(), -1f, delegate(WorldObject worldObject)
			{
				if (worldObject.Type != WorldObjectType.ResourcePile || !(worldObject is ResourcePileInstance { IsForbidden: false } resourcePileInstance))
				{
					return 0;
				}
				if (resourcePileInstance.PlacedOnAnimalFeeder)
				{
					return 0;
				}
				if (resourcePileInstance.InstanceStockpile != null && !resourcePileInstance.InstanceStockpile.CanBeUsedInProduction)
				{
					return 0;
				}
				if (resourcePileInstance.InstanceStorage != null && !resourcePileInstance.InstanceStorage.GetOwner.CanBeUsedInProduction)
				{
					return 0;
				}
				if (resourcePileInstance is HumanCarcassPileInstance { MarkedForStripping: not false })
				{
					return 0;
				}
				ResourceInstance storedResource = resourcePileInstance.GetStoredResource();
				if (!missing.Any((ResourceSearchFilter item) => item.Check(storedResource, ignoreCount: true)) || !instance.ResourceFilter.IsValid(storedResource))
				{
					return 0;
				}
				if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
				{
					return 0;
				}
				if (missing.Count > 1)
				{
					missing.RemoveAll((ResourceSearchFilter item) => !item.Check(storedResource, ignoreCount: true));
					if (missing.Count > 1)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ProductionBaseGoal.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Production ");
							messageBuilder.AppendFormatted(instance.BlueprintId);
							messageBuilder.AppendLiteral(" has something wrong with missing resources... ");
						}
						Log.Warning(messageBuilder);
					}
				}
				int maximumStorableCount2 = ((IStorageAgent)base.AgentOwner).Storage.GetMaximumStorableCount(resourcePileInstance.GetStoredResource().Blueprint);
				needCount = ((needCount > 0) ? needCount : (missing.FirstOrDefault()?.Count ?? 1));
				needCount = Mathf.Clamp(needCount, 1, maximumStorableCount2);
				gotCount += resourcePileInstance.GetStoredResource().Count.Amount;
				if (gotCount < needCount)
				{
					return 1;
				}
				gotCount = needCount;
				return 2;
			});
			useWaterNoPile = false;
			if ((gotCount < needCount || needCount == 0) && missing.Any((ResourceSearchFilter x) => stepCollect.HasWaterOnMap(x)) && instance.ResourceFilter.IsValid(waterBucketBlueprint) && FindWaterSource())
			{
				int maximumStorableCount = ((IStorageAgent)base.AgentOwner).Storage.GetMaximumStorableCount(waterBucketBlueprint);
				needCount = ((needCount > 0) ? needCount : (missing.FirstOrDefault()?.Count ?? 1));
				needCount = Mathf.Clamp(needCount, 1, maximumStorableCount);
				gotCount = needCount;
				useWaterNoPile = true;
			}
			ListPool<ResourceSearchFilter>.Return(missing);
			if (gotCount < needCount || needCount == 0)
			{
				ListPool<WorldObject>.Return(list);
				return false;
			}
			if (!useWaterNoPile)
			{
				Resource blueprint = ((ResourcePileInstance)list[0]).Blueprint;
				for (int num3 = 0; num3 < list.Count; num3++)
				{
					if (((ResourcePileInstance)list[num3]).Blueprint == blueprint)
					{
						QueueTarget(TargetIndex.A, new TargetObject(list[num3]));
					}
					else
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(list[num3], base.AgentOwner);
					}
				}
				ListPool<WorldObject>.Return(list);
			}
			collectAmount = needCount;
			if (useWaterNoPile)
			{
				waterAmount = needCount;
			}
			return true;
		}

		private int CalculateMissingWaterPickup()
		{
			if (!(GetTarget(TargetIndex.B).GetObjectAs<ProductionComponentInstance>().ProductionSystemInstance.CurrentProduction?.CurrentStep is ProductionStepCollect productionStepCollect))
			{
				return 0;
			}
			int maximumStorableCount = ((IStorageAgent)base.AgentOwner).Storage.GetMaximumStorableCount(waterBucketBlueprint);
			using PooledList<ResourceSearchFilter> pooledList = productionStepCollect.MissingResources.ToPooledListJanitor();
			ResourceSearchFilter resourceSearchFilter = null;
			foreach (ResourceSearchFilter item in pooledList)
			{
				if (item.Blueprint == waterBucketBlueprint || item.BlueprintOrCategoryId == waterBucketBlueprint.GetID())
				{
					resourceSearchFilter = item;
					break;
				}
			}
			return (resourceSearchFilter != null) ? Mathf.Clamp(resourceSearchFilter.Count, 1, maximumStorableCount) : 0;
		}

		private bool FindWaterSource()
		{
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
					WellComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<WellComponentInstance>();
					if (componentInstance == null || componentInstance.HasDisposed || componentInstance.OwnerBuilding == null || componentInstance.OwnerBuilding.HasDisposed || !componentInstance.CanBeUsed)
					{
						return false;
					}
					if (componentInstance.ReservablePositionsComponentInstance.FreeSpace <= 0 || componentInstance.ReservablePositionsComponentInstance.ReservablePositions.All((ReservablePosition x) => x.Reserved))
					{
						return false;
					}
					foreach (ReservablePosition reservablePosition in componentInstance.ReservablePositionsComponentInstance.ReservablePositions)
					{
						if (PathfinderUtil.IsPathPossible(pathfindingAgent, reservablePosition.Position))
						{
							return true;
						}
					}
					return false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					WellComponentInstance componentInstance = ((BaseBuildingInstance)item).GetComponentInstance<WellComponentInstance>();
					bool flag = false;
					foreach (ReservablePosition reservablePosition2 in componentInstance.ReservablePositionsComponentInstance.ReservablePositions)
					{
						if (!reservablePosition2.Reserved && PathfinderUtil.IsPathPossible(pathfindingAgent, reservablePosition2.Position))
						{
							reservablePosition = reservablePosition2;
							reservablePosition2.Reserve(base.AgentOwner);
							QueueTarget(TargetIndex.A, new TargetObject(item, reservablePosition2.Position));
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
							flag = true;
							break;
						}
					}
					return flag ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
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
						TargetObject target = new TargetObject(node.Position);
						QueueTarget(TargetIndex.A, target);
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
							QueueTarget(TargetIndex.A, target2);
							foundCoast = true;
							return FloodFillUtil.ScanStatus.Abort;
						}
					}
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			return foundCoast;
		}

		private bool PrepareProduceStep(ProductionStepInstance step)
		{
			ProductionInstance ownerProductionInstance = step.OwnerProductionInstance;
			if (((ProductionStepWorker)step).HasDisposed)
			{
				return false;
			}
			Vec3Int lhs = PathfinderProduction.FindWorkPosition((IPathfindingAgent)base.AgentOwner, ownerProductionInstance.OwnerProductionComponentInstance);
			if (lhs == Vec3Int.zero)
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(ownerProductionInstance.OwnerProductionComponentInstance, lhs));
			return true;
		}

		private bool ShouldAbort()
		{
			ProductionComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ProductionComponentInstance>();
			if (!CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, objectAs?.GetRoom()))
			{
				return true;
			}
			if (objectAs == null || objectAs.IsDisposedOrNull())
			{
				return true;
			}
			if (objectAs.OwnerBuilding.HasConstructionOrder())
			{
				return true;
			}
			ProductionSystemInstance productionSystemInstance = objectAs?.ProductionSystemInstance;
			ProductionInstance productionInstance = productionSystemInstance?.CurrentProduction;
			if (productionInstance == null || productionInstance.HasDisposed || productionSystemInstance.HasDisposed || production != productionInstance || production.HasDisposed)
			{
				return true;
			}
			if (productionInstance.Order == ProductionOrder.Pause)
			{
				return true;
			}
			if (objectAs.IsOnFire)
			{
				return true;
			}
			switch (productionInstance.State)
			{
			case ProductionState.None:
			case ProductionState.Paused:
			case ProductionState.TargetReached:
			case ProductionState.NoSkilledWorker:
				return true;
			case ProductionState.WaitingForResources:
			{
				ResourceInstance singleResource = ((IProductionAgent)base.AgentOwner).Storage.GetSingleResource();
				if (singleResource != null)
				{
					return !productionInstance.ResourceFilter.IsValid(singleResource);
				}
				ResourcePileInstance resourcePileInstance = GetTarget(TargetIndex.A).ObjectInstance as ResourcePileInstance;
				singleResource = resourcePileInstance?.GetStoredResource();
				if (singleResource == null)
				{
					return false;
				}
				if (resourcePileInstance is HumanCarcassPileInstance { MarkedForStripping: not false })
				{
					return true;
				}
				return !productionInstance.ResourceFilter.IsValid(singleResource);
			}
			case ProductionState.WaitingForWorker:
			case ProductionState.InProgress:
				return false;
			default:
				return true;
			}
		}

		private void TryToHaulProducedItems(NSMedieval.Model.Production blueprint)
		{
			if (blueprint == null)
			{
				return;
			}
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			ResourcePileInstance bestPile = null;
			FloodFillUtil.FloodFillConnections(humanoidInstance.Map, humanoidInstance.GetGridPosition(), 5f, delegate(MapNode node)
			{
				ResourcePileInstance pile = node.GetWorldObject(GridDataType.ResourcePile) as ResourcePileInstance;
				if (pile == null || !pile.CanBeHauled)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (blueprint.IsDismantle())
				{
					if ((pile.Blueprint.Category & (ResourceCategory.CtgClothMat | ResourceCategory.CtgBuildMat | ResourceCategory.CtgFuel)) != ResourceCategory.None)
					{
						bestPile = ((bestPile == null) ? pile : ((pile.Blueprint.HaulPriority > bestPile.Blueprint.HaulPriority) ? pile : bestPile));
					}
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (blueprint.Products != null && blueprint.Products.Count > 0 && blueprint.Products.Any((ProductModel item) => pile.BlueprintId.Contains(item.GetID())))
				{
					bestPile = ((bestPile == null) ? pile : ((pile.Blueprint.HaulPriority > bestPile.Blueprint.HaulPriority) ? pile : bestPile));
				}
				if (blueprint.CustomProducts != null && blueprint.CustomProducts.Count > 0 && blueprint.CustomProducts.Any((CustomProduct item) => item.Products.Any((ProductModel productModel) => pile.BlueprintId.Contains(productModel.GetID()))))
				{
					bestPile = ((bestPile == null) ? pile : ((pile.Blueprint.HaulPriority > bestPile.Blueprint.HaulPriority) ? pile : bestPile));
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
				if (base.Agent != null && !base.Agent.HasDisposed && !bestPile.HasDisposed && !base.Agent.CurrentGoalName.Equals("StockpileHaulingGoal"))
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(bestPile, base.AgentOwner);
				}
			});
		}
	}
}
