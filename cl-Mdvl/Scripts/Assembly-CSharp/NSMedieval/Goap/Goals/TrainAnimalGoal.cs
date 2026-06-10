using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GOAP.Action;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class TrainAnimalGoal : Goal
	{
		private const int TrainingPoints = 70;

		public TrainAnimalGoal(Agent selfAgent)
			: base("TrainAnimalGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestAnimal));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<AnimalManager>.IsInstantiated())
			{
				return MonoSingleton<AnimalManager>.Instance.HasAnimalWithOrder(AnimalOrderType.Train);
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHarvestAgent;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>().GetGoapAgent()?.StartTicker();
			base.EndGoalWith(condition);
			if (condition != GoalCondition.Succeeded)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\TrainAnimalGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TrainAnimalGoal ended, goal condition: ");
					messageBuilder.AppendFormatted(condition);
				}
				Log.Info(messageBuilder);
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToHarvestAnimalTarget(TargetIndex.A, useFrontPosOnly: true).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange)
				.FailAtCondition(() => IsUnavailable(GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>()))
				.StopAnimalTickerWhenInRange(TargetIndex.A)
				.RestoreAnimalTickerOnFail(TargetIndex.A);
			AnimalInstance animalInstance = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			IHarvestAgent harvestAgent = null;
			HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
			GoapAction trainingAction = new GoapAction("TrainingAction")
			{
				CompleteMode = ActionCompleteMode.Delay
			};
			trainingAction.OnInit = delegate
			{
				harvestAgent = base.AgentOwner as IHarvestAgent;
				float num = harvestAgent.GetAttributeValue(AttributeType.TrainAnimalSpeed);
				if (num == 0f)
				{
					num = 1f;
				}
				float trainingDuration = animalInstance.Blueprint.TrainingDuration;
				float time = trainingDuration / num;
				trainingAction.CompleteAfterTimeExpires(time);
				((IProductionAgent)base.AgentOwner).FaceObject(MonoSingleton<AnimalManager>.Instance.GetView(animalInstance).transform);
				string text = animalInstance.Blueprint.TrainingAnimation;
				if (string.IsNullOrEmpty(text))
				{
					text = "Training";
				}
				((IToolAgent)base.AgentOwner).SetTool("TrainingHorn");
				trainingAction.TriggerAnimation(text, ActionAnimationMode.Interrupt);
				trainingAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => trainingAction.TotalTickingTime / time).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
			};
			trainingAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			trainingAction.FailIfTargetReservationReleases(TargetIndex.A);
			trainingAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (animalInstance != null && !animalInstance.HasDisposed && !animalInstance.HasDied && !(animalInstance.Blueprint == null))
				{
					animalInstance.TrainingAttemptCompleted();
					if (base.AgentOwner != null && !(base.AgentOwner.GetTransform() == null) && animalInstance.Stats != null)
					{
						((IToolAgent)base.AgentOwner).HideTool();
						if (status != ActionCompletionStatus.Success || RollForFail(animalInstance))
						{
							humanoidInstance?.AddExperience(SkillType.AnimalHandling, animalInstance.Blueprint.TameTryFailXp);
							DamagePopup.Create(base.AgentOwner.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("train_failed_message"), ColorUtils.GetColor("red"));
							animalInstance.SetLastTrainingAttemptInfo(humanoidInstance, greatSuccess: false);
						}
						else
						{
							StatInstance stat = animalInstance.Stats.GetStat(StatType.AnimalUntrained);
							if (stat != null)
							{
								stat.SetCurrent(stat.Current - 70f);
								humanoidInstance?.AddExperience(SkillType.AnimalHandling, animalInstance.Blueprint.TameTrySuccessfulXp);
								if (stat.Current <= stat.Blueprint.ThresholdAttributes.First().BaseValue)
								{
									animalInstance.SetAnimalType(AnimalType.Pet);
									MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, animalInstance);
									if (animalInstance.HasHarvestableProduction())
									{
										MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animalInstance);
									}
									LogAnimalTrained(humanoidInstance, animalInstance);
								}
								else
								{
									DamagePopup.Create(base.AgentOwner.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("training_successful_message"), ColorUtils.GetColor("green"));
									MonoSingleton<AnimalManager>.Instance.GetView(animalInstance)?.TrainParticles();
								}
								animalInstance.SetLastTrainingAttemptInfo(humanoidInstance, greatSuccess: true);
							}
						}
					}
				}
			};
			trainingAction.FailAtCondition(() => IsUnavailable(GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>()));
			yield return trainingAction;
		}

		private void LogAnimalTrained(HumanoidInstance humanoidInstance, AnimalInstance animalInstance)
		{
			string text = TextFormatting.FormatAnimalTamingText(MonoSingleton<LocalizationController>.Instance.GetText("animal_is_pet_message"), humanoidInstance.Info.GetFullName(), AnimalUtils.GetAnimalName(animalInstance));
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
			LifeEventLogStruct miscLog = LifeEventUtils.GetMiscLog(text);
			humanoidInstance.LogLifeEvent(miscLog);
			animalInstance.LogLifeEvent(miscLog);
		}

		private bool RollForFail(AnimalInstance animalInstance)
		{
			float value = Random.value;
			float attributeValue = animalInstance.GetAttributeValue(AttributeType.AnimalTrainChance);
			float num = (base.AgentOwner as HumanoidInstance)?.GetAttributeValue(AttributeType.TrainChanceMultiplier) ?? 1f;
			return value > attributeValue * num;
		}

		private bool FindClosestAnimal()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				AnimalInstance objectAs = target.GetObjectAs<AnimalInstance>();
				if (!CombatUtils.IsNullOrDisposed(objectAs) && objectAs.OrderType == AnimalOrderType.Train && objectAs.CanTryTraining && !objectAs.IsSleeping && !objectAs.IsFormingCaravan() && objectAs.GetNode() != null && objectAs.GetNode().GetLayerRampObject() == null && !objectAs.PathDriver.IsClimbing && !IsUnavailable(objectAs) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			int workerAnimalHandlingSkill = (base.AgentOwner as HumanoidInstance)?.Skills.GetSkill(SkillType.AnimalHandling).Level ?? 0;
			List<TargetObject> list = PathfinderAnimals.FindAnimals((IPathfindingAgent)base.AgentOwner, MonoSingleton<AnimalManager>.Instance.Animals.Keys.Where((AnimalInstance x) => x.OrderType == AnimalOrderType.Train && x.CanTryTraining && workerAnimalHandlingSkill >= x.Blueprint.MinTrainSkill && !x.IsSleeping && !x.IsFormingCaravan() && !x.PathDriver.IsClimbing && !IsUnavailable(x)), 1);
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
			if (objectAs == null)
			{
				return true;
			}
			if (objectAs.IsSleeping)
			{
				return true;
			}
			if (objectAs.OrderType != AnimalOrderType.Train)
			{
				return true;
			}
			if (!objectAs.CanTryTraining)
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
			if (objectAs.GetNode().Tag.HasFlag(MapNodeTags.Ladder))
			{
				return true;
			}
			return MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(objectAs) > 0;
		}

		private static bool IsUnavailable(AnimalInstance animalInstance)
		{
			if (animalInstance == null || animalInstance.HasDisposed || animalInstance.IsOnFire)
			{
				return true;
			}
			if (animalInstance.Map.FireSimLogic.GetFireData(animalInstance.GetNode().Index) > 0f)
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
