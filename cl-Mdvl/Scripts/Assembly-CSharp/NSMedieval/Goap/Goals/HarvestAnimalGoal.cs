using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GOAP.Action;
using NSEipix;
using NSEipix.Base;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.View.Animals;
using NSMedieval.Village.Map;
using NSMedieval.Water;

namespace NSMedieval.Goap.Goals
{
	public class HarvestAnimalGoal : Goal
	{
		public HarvestAnimalGoal(Agent selfAgent)
			: base("HarvestAnimalGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestAnimal));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<AnimalManager>.IsInstantiated())
			{
				return MonoSingleton<AnimalManager>.Instance.HasAnimalWithOrder(AnimalOrderType.Harvest);
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHarvestAgent;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			objectAs.GetGoapAgent()?.StartTicker();
			base.EndGoalWith(condition);
			if (condition != GoalCondition.Succeeded)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HarvestAnimalGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("HarvestAnimalGoal ended, goal condition: ");
					messageBuilder.AppendFormatted(condition);
				}
				Log.Info(messageBuilder);
			}
			((IToolAgent)base.AgentOwner).HideTool();
			AnimalView view = MonoSingleton<AnimalManager>.Instance.GetView(objectAs);
			if (view != null)
			{
				view.StopShearParticles();
				view.RemoveMilkBucket();
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToHarvestAnimalTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange)
				.FailAtCondition(() => UnderWater(GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>()))
				.StopAnimalTickerWhenInRange(TargetIndex.A)
				.RestoreAnimalTickerOnFail(TargetIndex.A);
			AnimalInstance animalInstance = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			AnimalView animalView = MonoSingleton<AnimalManager>.Instance.GetView(animalInstance);
			AnimalProductionInstance api = null;
			IHarvestAgent harvestAgent = null;
			GoapAction harvestingAction = new GoapAction("HarvestAnimalAction")
			{
				CompleteMode = ActionCompleteMode.Delay
			};
			harvestingAction.OnInit = delegate
			{
				api = animalInstance.GetFirstHarvestableProduction();
				if (api == null)
				{
					Log.Error("Animal harvest action failed initialization - no valid animal production found.", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HarvestAnimalGoal.cs");
					harvestingAction.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					harvestAgent = base.AgentOwner as IHarvestAgent;
					float num = harvestAgent.GetAttributeValue(AttributeType.MotorFunction);
					if (num == 0f)
					{
						num = 1f;
					}
					float num2 = harvestAgent.GetAttributeValue(AttributeType.GlobalWorkSpeed);
					if (num2 == 0f)
					{
						num2 = 1f;
					}
					float num3 = harvestAgent.GetAttributeValue(AttributeType.HarvestAnimalSpeed);
					if (num3 == 0f)
					{
						num3 = 1f;
					}
					float harvestDuration = api.Blueprint.HarvestDuration;
					float time = harvestDuration / (num2 * num * num3);
					harvestingAction.CompleteAfterTimeExpires(time);
					((IProductionAgent)base.AgentOwner).FaceObject(MonoSingleton<AnimalManager>.Instance.GetView(animalInstance).transform);
					string text = api.Blueprint.HarvestAnimationId;
					if (string.IsNullOrEmpty(text))
					{
						text = "Stirring";
					}
					if (text == "Milking")
					{
						animalView.Milking();
					}
					if (text == "Shearing")
					{
						((IToolAgent)base.AgentOwner).SetTool("shears_right_item");
						animalView.ShearParticles();
					}
					harvestingAction.TriggerAnimation(text, ActionAnimationMode.Interrupt);
					harvestingAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => harvestingAction.TotalTickingTime / time).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
				}
			};
			harvestingAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			harvestingAction.FailIfTargetReservationReleases(TargetIndex.A);
			harvestingAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (animalInstance != null && !animalInstance.HasDisposed && status == ActionCompletionStatus.Success)
				{
					((IToolAgent)base.AgentOwner).HideTool();
					animalView.StopShearParticles();
					animalView.RemoveMilkBucket();
					if (api != null)
					{
						float attributeValue = harvestAgent.GetAttributeValue(AttributeType.AnimalHarvestYeald);
						int amountToSpawn = (int)((float)api.Blueprint.AmountToSpawn * attributeValue);
						ResourcePileInstance spawnedPile = api.HarvestCompleted(amountToSpawn);
						animalInstance.HarvestCompleted();
						HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
						humanoidInstance?.AddExperience(SkillType.AnimalHandling, api.Blueprint.HarvestXp);
						if (spawnedPile != null && humanoidInstance != null && ((uint?)humanoidInstance.WorkerBehaviour?.ActiveJobCombination & 1u) == 1)
						{
							MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(spawnedPile);
							if (MonoSingleton<StorageCommonManager>.Instance.CanStoreAnywhere(spawnedPile.GetStoredResource()) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(spawnedPile, base.AgentOwner))
							{
								MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(base.AgentOwner, spawnedPile);
								base.Agent.ForceNextGoal("StockpileHaulingGoal");
								MonoSingleton<TaskController>.Instance.WaitFor(1.5f).Then(delegate
								{
									if (!base.Agent.HasDisposed && !spawnedPile.HasDisposed && !base.Agent.CurrentGoalName.Equals("StockpileHaulingGoal"))
									{
										MonoSingleton<ReservationManager>.Instance.ReleaseObject(spawnedPile, base.AgentOwner);
									}
								});
							}
						}
					}
				}
			};
			harvestingAction.FailAtCondition(() => UnderWater(GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>()));
			yield return harvestingAction;
		}

		private bool FindClosestAnimal()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				AnimalInstance objectAs = target.GetObjectAs<AnimalInstance>();
				if (objectAs.HasHarvestableProduction() && !objectAs.IsSleeping && !objectAs.IsOnFire && !objectAs.IsFormingCaravan() && !objectAs.PathDriver.IsClimbing && !UnderWater(objectAs) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			List<TargetObject> list = PathfinderAnimals.FindAnimals((IPathfindingAgent)base.AgentOwner, MonoSingleton<AnimalManager>.Instance.Animals.Keys.Where((AnimalInstance x) => !CombatUtils.IsNullOrDisposed(x) && (x.AnimalType == AnimalType.Domestic || x.AnimalType == AnimalType.Pet) && x.HasHarvestableProduction() && !x.IsSleeping && !x.IsOnFire && !x.IsFormingCaravan() && x.GetNode() != null && x.GetNode().GetLayerRampObject() == null && !x.PathDriver.IsClimbing && !UnderWater(x)), 1);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}

		private bool FailWhenConditionsChange()
		{
			AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			if (CombatUtils.IsNullOrDisposed(objectAs))
			{
				return true;
			}
			if (!objectAs.HasHarvestableProduction())
			{
				return true;
			}
			if (objectAs.IsFormingCaravan())
			{
				return true;
			}
			if (objectAs.PathDriver.IsClimbing)
			{
				return true;
			}
			if (objectAs.IsOnFire)
			{
				return true;
			}
			if (objectAs.GetNode().Tag.HasFlag(MapNodeTags.Ladder))
			{
				return true;
			}
			return MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(objectAs) > 0;
		}

		private bool UnderWater(AnimalInstance animalInstance)
		{
			if (animalInstance == null || animalInstance.HasDisposed)
			{
				return true;
			}
			WaterDepthLevel waterDepthLevel = animalInstance.GetWaterDepthLevel();
			if (waterDepthLevel != WaterDepthLevel.Medium)
			{
				return waterDepthLevel == WaterDepthLevel.High;
			}
			return true;
		}
	}
}
