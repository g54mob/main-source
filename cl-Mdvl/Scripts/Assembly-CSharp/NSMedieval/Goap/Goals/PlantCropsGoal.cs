using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class PlantCropsGoal : Goal
	{
		private const float ShouldNotBeInterruptedForTime = 15f;

		private const int MaxSeedCarryCount = 10;

		private readonly WorldDate cachedWorldDate;

		private SimpleResourceCount resourceOrder;

		private Queue<Vec3Int> occupied = new Queue<Vec3Int>();

		private CropfieldInstance targetCropfield;

		private PlantMapResource plantToGrow;

		private List<TargetObject> foundCrops = new List<TargetObject>();

		public PlantCropsGoal(Agent selfAgent)
			: base("PlantCropsGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<CropfieldInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindCrops, PickCropAndSetMaxSeedCount));
			AddInitStep(new ThreadSequenceStep(null, FindSeedPiles, ReserveSeedsAndCrop));
			cachedWorldDate = GlobalSaveController.CurrentVillageData.DateAndTime;
			base.InitJob.OnStepFailedEvent += delegate(ThreadSequenceJobCompleteStatus status)
			{
				if (status != ThreadSequenceJobCompleteStatus.Success)
				{
					ClearReservedSpaces();
				}
			};
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IToolAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<CropsManager>.IsInstantiated())
			{
				return false;
			}
			return MonoSingleton<CropsManager>.Instance.CanPlantCrops();
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			((IToolAgent)base.AgentOwner).HideTool();
			ClearReservedSpaces();
			base.EndGoalWith(condition);
		}

		public override void HandleConsecutiveFail()
		{
			if (!GetTarget(TargetIndex.B).IsInitialized)
			{
				return;
			}
			ResourcePileInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ResourcePileInstance>();
			if (objectAs != null)
			{
				if (objectAs.InstanceStorage == null)
				{
					objectAs.IsForbidden = true;
					string localizedResourcePileName = ResourceUtils.GetLocalizedResourcePileName(objectAs.Blueprint.GetID());
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedResourcePileName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, objectAs.WorldPosition);
				}
				else if (objectAs.InstanceStorage.GetOwner is ShelfComponentInstance shelfComponentInstance)
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
			return base.CanBeInterrupted();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			CropfieldInstance cropTarget = GetTarget(TargetIndex.A).GetObjectAs<CropfieldInstance>();
			if (CropsManager.UseSeeds)
			{
				GoapAction deliverStartAction = StorageActions.CompleteIfNoResourceInStorage(resourceOrder.Blueprint);
				GoapAction beginCheck = JumpActions.JumpIfNoTargetsInQueue(deliverStartAction, TargetIndex.B);
				yield return beginCheck;
				yield return GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.B);
				yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(beginCheck, TargetIndex.B).FailAtCondition(() => CropConfigChanged(cropTarget) || !SowJobActive() || SowTimeOutOfRange());
				yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, (Resource blueprint) => resourceOrder.Amount, delegate(Resource blueprint, int amount)
				{
					resourceOrder = new SimpleResourceCount(resourceOrder.Blueprint, resourceOrder.Amount - amount);
				}).JumpIfTargetDisposedOrNull(beginCheck, TargetIndex.B);
				yield return JumpActions.ConditionalJump(beginCheck, () => resourceOrder.Amount > 0);
				yield return deliverStartAction;
			}
			IToolAgent agent = (IToolAgent)base.AgentOwner;
			IStorageAgent storageAgent = (IStorageAgent)base.AgentOwner;
			GoapAction updatePlantCropGridSpacePosition = new GoapAction("UpdatePlantCropGridSpacePosition")
			{
				OnInit = delegate
				{
					if (occupied.Count == 0)
					{
						EndGoalWith(GoalCondition.Incompletable);
					}
					else
					{
						Vec3Int pos = occupied.Dequeue();
						SetSelectedTargetReachablePosition(TargetIndex.A, pos);
						MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
					}
				}
			};
			yield return updatePlantCropGridSpacePosition;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailAtCondition(() => CropConfigChanged(cropTarget) || !SowJobActive() || SowTimeOutOfRange() || TargetPositionMissing(GetTarget(TargetIndex.A)));
			GoapAction plantCropsAction = null;
			float time = 0f;
			plantCropsAction = new GoapAction("PlantCropsAction")
			{
				OnInit = delegate
				{
					CropfieldInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<CropfieldInstance>();
					SowingParameters sowingParameters = objectAs.CultivablePlant.GetSowingParameters();
					float sowTime = objectAs.CultivablePlant.SowTime;
					float attributeValue = agent.GetAttributeValue(sowingParameters.DurationAttribute);
					time = sowTime / attributeValue;
					AttributeInstance attribute = ((IProductionAgent)base.AgentOwner).GetAttribute(AttributeType.GlobalWorkSpeed);
					if (attribute != null)
					{
						time /= attribute.Value;
					}
					agent.SetTool("hoe_item");
					plantCropsAction.CompleteAfterTimeExpires(time);
				},
				OnComplete = delegate(ActionCompletionStatus status)
				{
					TargetObject target = GetTarget(TargetIndex.A);
					CropfieldInstance objectAs = target.GetObjectAs<CropfieldInstance>();
					SowingParameters sowingParameters = objectAs.CultivablePlant.GetSowingParameters();
					objectAs.RemoveOccupied(target.ReachablePosition);
					agent.HideTool();
					if (status == ActionCompletionStatus.Success)
					{
						using (ProfilerSampleJanitor.Begin("PlantCrop"))
						{
							objectAs.PlantCrop(target.ReachablePosition);
						}
						agent.AddExperience(sowingParameters.RewardedSkill, sowingParameters.RewardAmount);
						if (CropsManager.UseSeeds)
						{
							storageAgent.Storage.Take(objectAs.Blueprint.SeedBlueprint, 1);
						}
						else
						{
							storageAgent.Storage.ClearAll();
						}
					}
					else
					{
						while (occupied.Count > 0)
						{
							objectAs.RemoveOccupied(occupied.Dequeue());
						}
					}
				}
			};
			plantCropsAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => plantCropsAction.TotalTickingTime / time).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
			yield return plantCropsAction.TriggerAnimation("Planting", ActionAnimationMode.Interrupt).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailAtCondition(() => CropConfigChanged(cropTarget) || !SowJobActive() || TargetPositionMissing(GetTarget(TargetIndex.A)));
			yield return JumpActions.ConditionalJump(updatePlantCropGridSpacePosition, () => occupied.Count > 0 && !storageAgent.Storage.IsEmpty() && plantCropsAction.CompletionStatus == ActionCompletionStatus.Success);
		}

		private bool FindCrops()
		{
			foundCrops.Clear();
			resourceOrder = default(SimpleResourceCount);
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				CropfieldInstance objectAs = target.GetObjectAs<CropfieldInstance>();
				if (objectAs.HasFreeSpace() && !objectAs.IsOnFire)
				{
					foundCrops.Add(target);
					return true;
				}
			}
			int num = ((HumanoidInstance)(IStorageAgent)base.AgentOwner).Skills.GetSkill(SkillType.Botanical)?.Level ?? 0;
			IPathfindingAgent pathfindingAgent = base.AgentOwner as IPathfindingAgent;
			foreach (CropfieldInstance cropfield in MonoSingleton<CropsManager>.Instance.Cropfields)
			{
				if (cropfield.OwnedByPlayer() && PathfinderUtil.IsPathPossible(pathfindingAgent, cropfield) && ((!CropsManager.UseSeeds) ? (!cropfield.DontSow && cropfield.HasFreeSpace() && num >= cropfield.CultivablePlant.MinBotanicalSkill) : (!cropfield.DontSow && cropfield.HasFreeSpace() && num >= cropfield.CultivablePlant.MinBotanicalSkill && MonoSingleton<ResourcePileTracker>.Instance.GetCount(cropfield.Blueprint.SeedBlueprint).AllowedCount > 0)))
				{
					foundCrops.Add(new TargetObject(cropfield));
				}
			}
			return foundCrops.Count > 0;
		}

		private bool PickCropAndSetMaxSeedCount()
		{
			if (foundCrops.Count == 0)
			{
				return false;
			}
			foundCrops = foundCrops.OrderByDescending((TargetObject x) => (int)x.GetObjectAs<CropfieldInstance>().Priority).ToList();
			ClearTargetsQueue(TargetIndex.A);
			QueueTargets(TargetIndex.A, foundCrops);
			IStorageAgent storageAgent = (IStorageAgent)base.AgentOwner;
			int num = ((HumanoidInstance)storageAgent).Skills.GetSkill(SkillType.Botanical)?.Level ?? 0;
			int dayOfYear = cachedWorldDate.DayOfYear;
			while (SelectNextTarget(TargetIndex.A))
			{
				CropfieldInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<CropfieldInstance>();
				int minBotanicalSkill = objectAs.CultivablePlant.MinBotanicalSkill;
				if (dayOfYear < objectAs.MinSowDate - 1 || dayOfYear > objectAs.MaxSowDate - 1 || num < minBotanicalSkill || objectAs.GetUnreservedCount() <= 0)
				{
					continue;
				}
				if (CropsManager.UseSeeds)
				{
					SimpleResourceCount seedsOrder = objectAs.GetSeedsOrder();
					if (seedsOrder.Equals(default(SimpleResourceCount)) || seedsOrder.Amount <= 0 || !resourceOrder.Equals(default(SimpleResourceCount)))
					{
						continue;
					}
					resourceOrder = seedsOrder;
					int num2 = storageAgent.Storage.GetMaximumStorableCount(resourceOrder.Blueprint);
					if (num2 > 10)
					{
						num2 = ((10 > seedsOrder.Amount) ? seedsOrder.Amount : 10);
						resourceOrder = new SimpleResourceCount(resourceOrder.Blueprint, num2);
					}
					if (num2 > 0)
					{
						List<Vec3Int> list = objectAs.AvailableGridspaces();
						for (int num3 = 0; num3 < num2 && num3 < list.Count; num3++)
						{
							occupied.Enqueue(list[num3]);
							objectAs.SetOccupied(list[num3]);
						}
						targetCropfield = objectAs;
						plantToGrow = targetCropfield.CultivablePlant;
						break;
					}
					continue;
				}
				List<Vec3Int> list2 = objectAs.AvailableGridspaces();
				int unreservedCount = objectAs.GetUnreservedCount();
				for (int num4 = 0; num4 < unreservedCount && num4 < 10; num4++)
				{
					occupied.Enqueue(list2[num4]);
					objectAs.SetOccupied(list2[num4]);
				}
				targetCropfield = objectAs;
				plantToGrow = targetCropfield.CultivablePlant;
				break;
			}
			ClearTargetsQueue(TargetIndex.A);
			if (CropsManager.UseSeeds && (resourceOrder.Equals(default(SimpleResourceCount)) || resourceOrder.Amount == 0))
			{
				return false;
			}
			QueueTarget(TargetIndex.A, GetTarget(TargetIndex.A));
			return true;
		}

		private bool FindSeedPiles()
		{
			if (!CropsManager.UseSeeds)
			{
				return true;
			}
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.ResourcePile,
				Condition = (WorldObject pile) => !pile.HasDisposed && !((ResourcePileInstance)pile).IsForbidden && ((ResourcePileInstance)pile).Blueprint.Equals(resourceOrder.Blueprint) && !pile.IsOnFire,
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					QueueTarget(TargetIndex.B, new TargetObject(item, pos));
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
		}

		private bool ReserveSeedsAndCrop()
		{
			if (!ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
			{
				return false;
			}
			TargetObject target = GetTarget(TargetIndex.A);
			CropfieldInstance objectAs = target.GetObjectAs<CropfieldInstance>();
			if (HasFreeSpaceOrReserved(objectAs) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
			{
				SetTarget(TargetIndex.A, target);
				if (!CropsManager.UseSeeds)
				{
					return true;
				}
				int reservedAmount = 0;
				GetTargetQueue(TargetIndex.B).RemoveAll(delegate(TargetObject item)
				{
					if (item.GetAsReservable().HasDisposed || reservedAmount >= resourceOrder.Amount)
					{
						return true;
					}
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(item.GetAsReservable(), base.AgentOwner))
					{
						return true;
					}
					reservedAmount += item.GetObjectAs<ResourcePileInstance>().GetStoredResource().Amount;
					if (reservedAmount > 10)
					{
						reservedAmount = 10;
					}
					return false;
				});
				return reservedAmount > 0;
			}
			return false;
		}

		private bool HasFreeSpaceOrReserved(CropfieldInstance cropfieldInstance)
		{
			if (cropfieldInstance.HasFreeSpace())
			{
				return true;
			}
			foreach (Vec3Int item in occupied)
			{
				if (cropfieldInstance.Reserved.Contains(item))
				{
					return true;
				}
			}
			return false;
		}

		private bool CropConfigChanged(CropfieldInstance targetCrop)
		{
			if (targetCropfield != targetCrop)
			{
				return false;
			}
			if (!(plantToGrow != targetCrop.CultivablePlant))
			{
				return targetCrop.DontSow;
			}
			return true;
		}

		private bool SowJobActive()
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (humanoidInstance.IsCaptive())
			{
				return true;
			}
			return humanoidInstance.WorkerBehaviour.ActiveJobCombination.HasFlag(JobType.PlantCropfields);
		}

		private bool SowTimeOutOfRange()
		{
			CropfieldInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<CropfieldInstance>();
			int dayOfYear = cachedWorldDate.DayOfYear;
			if (dayOfYear >= objectAs.MinSowDate - 1)
			{
				return dayOfYear > objectAs.MaxSowDate - 1;
			}
			return true;
		}

		private bool TargetPositionMissing(TargetObject targetCrop)
		{
			Vec3Int reachablePosition = targetCrop.ReachablePosition;
			return !targetCrop.GetObjectAs<CropfieldInstance>().Positions.Contains(reachablePosition);
		}

		private void ClearReservedSpaces()
		{
			CropfieldInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<CropfieldInstance>();
			if (GetTarget(TargetIndex.A).IsInitialized)
			{
				objectAs?.RemoveOccupied(GetTarget(TargetIndex.A).ReachablePosition);
			}
			while (occupied.Count > 0)
			{
				objectAs?.RemoveOccupied(occupied.Dequeue());
			}
		}
	}
}
