using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
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
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class TameAnimalGoal : Goal
	{
		private const int DomesticationPoints = 70;

		private AnimalInstance animal;

		public TameAnimalGoal(Agent selfAgent)
			: base("TameAnimalGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindPaths, ReserveAnimals));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<AnimalManager>.IsInstantiated())
			{
				return MonoSingleton<AnimalManager>.Instance.HasAnimalWithOrder(AnimalOrderType.Tame);
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IDamageDealAgent;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			animal?.GetGoapAgent()?.StartTicker();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToHarvestAnimalTarget(TargetIndex.A, useFrontPosOnly: true).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange);
			GoapAction tamingAction = new GoapAction("TamingAction")
			{
				CompleteMode = ActionCompleteMode.Delay
			};
			animal = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			IProductionAgent productionAgent = (IProductionAgent)base.AgentOwner;
			HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
			float retaliateChanceTime = 0f;
			tamingAction.OnInit = delegate
			{
				float tamingDuration = animal.Blueprint.TamingDuration;
				float num = humanoidInstance?.GetAttributeValue(AttributeType.TameAnimalSpeed) ?? 1f;
				tamingDuration /= num;
				tamingAction.CompleteAfterTimeExpires(tamingDuration);
				tamingAction.TriggerAnimation("Taming", ActionAnimationMode.Interrupt);
				((IToolAgent)base.AgentOwner).SetTool("eating_bread_item");
				tamingAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => tamingAction.TotalTickingTime / tamingDuration).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
				retaliateChanceTime = Random.Range(0f, tamingDuration);
				animal.GetGoapAgent().StopTicker();
				Transform transform = MonoSingleton<AnimalManager>.Instance.GetView(animal).transform;
				productionAgent.FaceObject(transform);
			};
			tamingAction.OnTick = delegate
			{
				if (tamingAction.TotalTickingTime >= retaliateChanceTime)
				{
					retaliateChanceTime = float.MaxValue;
					float value = Random.value;
					float value2 = animal.Stats.GetAttributeInstance(AttributeType.TameRetaliateChance).Value;
					float value3 = humanoidInstance.Stats.GetAttributeInstance(AttributeType.TameRetaliateChance).Value;
					if (!(value > value2 * value3))
					{
						IDamageTakingAgent obj = CombatAiUtils.PickBestTarget(animal, humanoidInstance, humanoidInstance);
						animal.CombatAi.SetState(CombatAiState.NextTarget, obj);
						DamagePopup.Create(animal.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("general_retaliate"), ColorUtils.GetColor("red"));
						MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
						{
							tamingAction.Goal.EndGoalWith(GoalCondition.Error);
						});
					}
				}
			};
			tamingAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (animal != null && !animal.HasDisposed && base.AgentOwner != null && !base.AgentOwner.HasDisposed)
				{
					animal.TamingAttemptCompleted();
					((IToolAgent)base.AgentOwner).HideTool();
					if (status != ActionCompletionStatus.Success || RollForFail(animal))
					{
						humanoidInstance?.AddExperience(SkillType.AnimalHandling, animal.Blueprint.TameTryFailXp);
						DamagePopup.Create(base.AgentOwner.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("tame_failed_message"), ColorUtils.GetColor("red"));
						animal.SetLastTamingAttemptInfo(humanoidInstance, greatSuccess: false);
					}
					else
					{
						StatInstance stat = animal.Stats.GetStat(StatType.AnimalWild);
						stat.SetCurrent(stat.Current - 70f);
						humanoidInstance?.AddExperience(SkillType.AnimalHandling, animal.Blueprint.TameTrySuccessfulXp);
						if (stat.Current <= stat.Blueprint.ThresholdAttributes.First().BaseValue)
						{
							animal.SetAnimalType(AnimalType.Domestic);
							MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, animal);
							if (animal.HasHarvestableProduction())
							{
								MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animal);
							}
							LogAnimalTamed(humanoidInstance, animal);
							string text = animal.Blueprint?.UnlockAchievementOnTame;
							if (!string.IsNullOrEmpty(text))
							{
								MonoSingleton<AchievementManager>.Instance.UnlockAchievement(text);
							}
							text = animal.Blueprint?.IncreaseAchievementCountOnTame;
							if (!string.IsNullOrEmpty(text))
							{
								MonoSingleton<AchievementManager>.Instance.IncreaseStat(text);
							}
						}
						else
						{
							DamagePopup.Create(base.AgentOwner.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("tame_successful_message"), ColorUtils.GetColor("green"));
							MonoSingleton<AnimalManager>.Instance.GetView(animal).TameParticlesSuccess();
						}
						animal.SetLastTamingAttemptInfo(humanoidInstance, greatSuccess: true);
					}
				}
			};
			tamingAction.FailAtCondition(FailWhenConditionsChange);
			tamingAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			tamingAction.FailIfTargetReservationReleases(TargetIndex.A);
			yield return tamingAction;
		}

		private void LogAnimalTamed(HumanoidInstance humanoidInstance, AnimalInstance animalInstance)
		{
			string text = TextFormatting.FormatAnimalTamingText(MonoSingleton<LocalizationController>.Instance.GetText("animal_is_domestic_message"), humanoidInstance.Info.GetFullName(), AnimalUtils.GetLocalizedName(animalInstance.Blueprint));
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
			LifeEventLogStruct miscLog = LifeEventUtils.GetMiscLog(text);
			humanoidInstance.LogLifeEvent(miscLog);
			animalInstance.LogLifeEvent(miscLog);
		}

		private bool RollForFail(AnimalInstance animalInstance)
		{
			float value = Random.value;
			float attributeValue = animalInstance.GetAttributeValue(AttributeType.AnimalTameChance);
			float num = (base.AgentOwner as HumanoidInstance)?.GetAttributeValue(AttributeType.TameChanceMultiplier) ?? 1f;
			return value > attributeValue * num;
		}

		private bool FindPaths()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				AnimalInstance objectAs = target.GetObjectAs<AnimalInstance>();
				if (objectAs.OrderType == AnimalOrderType.Tame && objectAs.CanTryTaming && !objectAs.IsSleeping && !objectAs.IsOnFire && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					QueueTarget(TargetIndex.A, target);
					return true;
				}
			}
			int workerAnimalHandlingSkill = (base.AgentOwner as HumanoidInstance)?.Skills.GetSkill(SkillType.AnimalHandling).Level ?? 0;
			List<TargetObject> list = PathfinderAnimals.FindAnimals((IPathfindingAgent)base.AgentOwner, from x in MonoSingleton<AnimalManager>.Instance.Animals.Keys.ToArray()
				where x.OrderType == AnimalOrderType.Tame && x.CanTryTaming && workerAnimalHandlingSkill >= x.Blueprint.MinTameSkill && !x.IsSleeping && !x.IsOnFire
				select x, MonoSingleton<WorkerManager>.Instance.GetWorkersCount(), (AnimalInstance x) => MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(x) == 0);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return true;
		}

		private bool ReserveAnimals()
		{
			while (SelectNextTarget(TargetIndex.A))
			{
				AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
				if (objectAs != null && objectAs.CanTryTaming && MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
				{
					ClearTargetsQueue(TargetIndex.A);
					QueueTarget(TargetIndex.A, new TargetObject(objectAs));
					return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
				}
			}
			return false;
		}

		private bool FailWhenConditionsChange()
		{
			AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			if (objectAs == null || objectAs.HasDisposed)
			{
				return true;
			}
			if (objectAs.IsSleeping)
			{
				return true;
			}
			if (!objectAs.OrderType.HasFlag(AnimalOrderType.Tame))
			{
				return true;
			}
			if (!objectAs.CanTryTaming)
			{
				return true;
			}
			if (objectAs.IsOnFire)
			{
				return true;
			}
			MapNode node = objectAs.GetNode();
			if (node.Tag.HasFlag(MapNodeTags.Ladder) || node.Map.FireSimLogic.GetFireData(node.Index) > 0f)
			{
				return true;
			}
			return MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(objectAs) > 0;
		}
	}
}
