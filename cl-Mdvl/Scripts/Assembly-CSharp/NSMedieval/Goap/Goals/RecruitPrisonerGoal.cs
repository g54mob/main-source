using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class RecruitPrisonerGoal : Goal
	{
		private const int RecruitmentPoints = 100;

		private const float RecruitDuration = 10f;

		private const float RecruitTrySuccessfulXp = 150f;

		private const float RecruitTryFailXp = 20f;

		private PrisonerBehaviour prisoner;

		public RecruitPrisonerGoal(Agent selfAgent)
			: base("RecruitPrisonerGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindPaths, ReservePrisoners));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<CaptiveNpcManager>.IsInstantiated())
			{
				return MonoSingleton<CaptiveNpcManager>.Instance.HasCaptivesWithRecruitOrder();
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				return humanoidInstance.WorkerBehaviour != null;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				humanoidInstance.HideTool();
			}
			prisoner?.GoapAgent.StartTicker();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange);
			HumanoidInstance recruiter = (HumanoidInstance)base.AgentOwner;
			prisoner = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().PrisonerBehaviour;
			Transform prisonerTransform = prisoner.Humanoid.GetAgentView<HumanoidView>().transform;
			GoapAction recruitAction = new GoapAction("RecruitAction")
			{
				CompleteMode = ActionCompleteMode.Delay
			};
			recruitAction.OnInit = delegate
			{
				float recruitDuration = 10f;
				float attributeValue = recruiter.GetAttributeValue(AttributeType.PrisonerRecruitSpeed);
				recruitDuration /= attributeValue;
				recruitAction.CompleteAfterTimeExpires(recruitDuration);
				recruitAction.TriggerAnimation("RecrutingPrisoner", ActionAnimationMode.Interrupt);
				recruiter.SetTool("eating_bread_item");
				recruitAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => recruitAction.TotalTickingTime / recruitDuration).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
				prisoner.GoapAgent.StopTicker();
				recruiter.FaceObject(prisonerTransform);
			};
			recruitAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (prisoner.Humanoid != null && !prisoner.Humanoid.HasDisposed)
				{
					bool flag = status != ActionCompletionStatus.Success || RollForFail(prisoner, recruiter);
					prisoner.RecruitAttemptCompleted(!flag);
					if (flag)
					{
						recruiter.AddExperience(SkillType.Speechcraft, 20f);
						DamagePopup.Create(recruiter.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("recruit_failed_message"), ColorUtils.GetColor("red"));
					}
					else
					{
						recruiter.AddExperience(SkillType.Speechcraft, 150f);
						StatInstance stat = prisoner.Humanoid.Stats.GetStat(StatType.PrisonerNotRecruited);
						float num = 100f * prisoner.Humanoid.GetAttributeValue(AttributeType.RecruitAddAmountMultiplier);
						stat.SetCurrent(stat.Current - num);
						if (stat.Current <= 0f)
						{
							if (prisoner.Shackled)
							{
								prisoner.Humanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.LeftHand, forbidDroppedItem: true);
							}
							WorkerBehaviour workerBehaviour = prisoner.Humanoid.SetActiveBehaviour<WorkerBehaviour>();
							string text = TextFormatting.FormatText(MonoSingleton<LocalizationController>.Instance.GetText("bbt_prisoner_has_recruited"), workerBehaviour.Humanoid);
							MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
							LifeEventLogStruct miscLog = LifeEventUtils.GetMiscLog(text);
							recruiter.LogLifeEvent(miscLog);
							workerBehaviour.Humanoid.LogLifeEvent(miscLog);
							MonoSingleton<AchievementManager>.Instance.IncreaseStat("REC_PRISONER_CNT");
						}
						else
						{
							DamagePopup.Create(recruiter.GetTransform().position, MonoSingleton<LocalizationController>.Instance.GetText("recruit_successful_message"), ColorUtils.GetColor("green"));
						}
					}
				}
			};
			recruitAction.FailAtCondition(FailWhenConditionsChange);
			recruitAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			recruitAction.FailIfTargetReservationReleases(TargetIndex.A);
			yield return recruitAction;
		}

		private bool FindPaths()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				PrisonerBehaviour prisonerBehaviour = target.GetObjectAs<HumanoidInstance>().PrisonerBehaviour;
				if (prisonerBehaviour.CanTryRecruiting() && !prisonerBehaviour.Humanoid.IsSleeping && !prisonerBehaviour.Humanoid.HasFainted && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					QueueTarget(TargetIndex.A, target);
					return true;
				}
			}
			List<TargetObject> list = PathfinderTargetable.FindObjects((IPathfindingAgent)base.AgentOwner, MonoSingleton<CaptiveNpcManager>.Instance.CaptivesHumanoids.Where((HumanoidInstance x) => x.PrisonerBehaviour != null), MonoSingleton<CaptiveNpcManager>.Instance.CaptivesCount, (HumanoidInstance x) => x.PrisonerBehaviour.CanTryRecruiting() && !x.IsSleeping);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return true;
		}

		private bool ReservePrisoners()
		{
			while (SelectNextTarget(TargetIndex.A))
			{
				PrisonerBehaviour prisonerBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().PrisonerBehaviour;
				if (prisonerBehaviour != null && prisonerBehaviour.CanTryRecruiting() && MonoSingleton<ReservationManager>.Instance.TryReserveObject(prisonerBehaviour.Humanoid, base.AgentOwner))
				{
					ClearTargetsQueue(TargetIndex.A);
					QueueTarget(TargetIndex.A, new TargetObject(prisonerBehaviour.Humanoid));
					return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
				}
			}
			return false;
		}

		private bool FailWhenConditionsChange()
		{
			PrisonerBehaviour prisonerBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>()?.PrisonerBehaviour;
			if (prisonerBehaviour == null || prisonerBehaviour.Humanoid.HasDisposed)
			{
				return true;
			}
			if (prisonerBehaviour.Humanoid.IsSleeping)
			{
				return true;
			}
			if (!prisonerBehaviour.CanTryRecruiting())
			{
				return true;
			}
			if (prisonerBehaviour.Humanoid.GetNode().Tag.HasFlag(MapNodeTags.Ladder))
			{
				return true;
			}
			return MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(prisonerBehaviour.Humanoid) > 0;
		}

		private bool RollForFail(HumanoidBehaviour prisoner, CreatureBase recruiter)
		{
			float value = Random.value;
			float attributeValue = prisoner.Humanoid.GetAttributeValue(AttributeType.BeingRecruitedChance);
			float attributeValue2 = recruiter.GetAttributeValue(AttributeType.RecruitChance);
			return value > attributeValue * attributeValue2;
		}
	}
}
