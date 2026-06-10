using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class AutoEquipGoal : Goal
	{
		private const int GoalCooldownHours = 2;

		private Cooldown goalCooldown;

		public AutoEquipGoal(Agent selfAgent)
			: base("AutoEquipGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(ResetCooldown, PrepareData));
			goalCooldown = Cooldown.FromNowMinutes(1, TutorialManager.IsTutorialActive);
		}

		private bool ResetCooldown()
		{
			int durationMinutes = Goal.DateTime.MinutesInHour * 2 + Random.Range(Goal.DateTime.MinutesInHour / 2, Goal.DateTime.MinutesInHour * 2);
			goalCooldown = Cooldown.FromNowMinutes(durationMinutes, TutorialManager.IsTutorialActive);
			return true;
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				if (!humanoidInstance.IsWorker())
				{
					return humanoidInstance.IsCaptive();
				}
				return true;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!isForced && !goalCooldown.HasEnded)
			{
				return false;
			}
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (humanoidInstance == null || humanoidInstance.HasFainted)
			{
				return false;
			}
			return true;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction selectNextTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			yield return selectNextTarget;
			GoapAction gotoTarget = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			gotoTarget.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			gotoTarget.FailIfResourcePileHasNoResources(TargetIndex.A);
			gotoTarget.TickOnInterval(1f, delegate
			{
				if (ShouldAbort())
				{
					gotoTarget.Complete(ActionCompletionStatus.Fail);
				}
			});
			yield return gotoTarget;
			yield return GeneralActions.WaitForever().TriggerAnimation("PickUpPile", ActionAnimationMode.Interrupt).CompleteActionOnAnimationGoapEvent("ItemPickup", ActionCompletionStatus.Success)
				.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			yield return ResourceActions.EquipItem(TargetIndex.A, (IEquipableAgent)base.AgentOwner).FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			yield return GeneralActions.Wait(0.5f);
			yield return JumpActions.JumpIfHaveTargetsInQueue(selectNextTarget, TargetIndex.A);
		}

		private bool PrepareData()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AutoEquipGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting auto equip goal for ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Trace(messageBuilder);
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			EquipmentSlotType slotsToFill;
			using PooledDictionary<Resource, ManageGroupPreset> pooledDictionary = EquipmentUtils.CalculateWantedResources(humanoidInstance, Goal.DateTime, dropInvalidForceUnequip: true, out slotsToFill);
			if (slotsToFill == EquipmentSlotType.None)
			{
				isEnabled = false;
				return isEnabled;
			}
			using PooledList<ResourcePileInstance> pooledList = ListPool<ResourcePileInstance>.GetJanitor();
			foreach (ResourcePileInstance item in MonoSingleton<ResourcePileManager>.Instance.IterateCategoryPiles(ResourceCategory.CtgItem))
			{
				if (item.IsForbidden || item.HasDisposed || item.IsOnFire || !item.IsStoredOnStockpile() || (humanoidInstance.IsCaptive() && (item.GetRoom() == null || !item.GetRoom().RoomType.Prison)))
				{
					continue;
				}
				Equipment equipmentBlueprint = item.Blueprint.EquipmentBlueprint;
				if (equipmentBlueprint == null || (slotsToFill & equipmentBlueprint.EquipmentSlots) == 0)
				{
					continue;
				}
				if (humanoidInstance.IsWorker())
				{
					if ((item.GetRoom() != null && item.GetRoom().RoomType.Prison) || !pooledDictionary.ContainsKey(item.Blueprint))
					{
						continue;
					}
					StatInstance stat = item.GetStat(StatType.Health);
					if (stat == null)
					{
						continue;
					}
					ManageGroupPreset manageGroupPreset = pooledDictionary[item.Blueprint];
					if (manageGroupPreset != null)
					{
						float num = Mathf.Ceil(stat.Current / stat.Max * 100f);
						float num2 = Mathf.Round(manageGroupPreset.HitpointsMin * 100f);
						float num3 = Mathf.Round(manageGroupPreset.HitpointsMax * 100f);
						if (num < num2 || num > num3)
						{
							continue;
						}
					}
				}
				pooledList.Add(item);
			}
			pooledList.Sort((ResourcePileInstance pile1, ResourcePileInstance pile2) => pile2.Blueprint.EquipmentBlueprint.EquipmentSlots.CompareTo(pile1.Blueprint.EquipmentBlueprint.EquipmentSlots));
			foreach (ResourcePileInstance item2 in pooledList)
			{
				if (slotsToFill == EquipmentSlotType.None)
				{
					break;
				}
				Equipment equipmentBlueprint2 = item2.Blueprint.EquipmentBlueprint;
				if ((slotsToFill & equipmentBlueprint2.EquipmentSlots) != EquipmentSlotType.None && MonoSingleton<ReservationManager>.Instance.TryReserveObject(item2, humanoidInstance))
				{
					int num4 = (int)(~equipmentBlueprint2.EquipmentSlots);
					slotsToFill = (EquipmentSlotType)((int)slotsToFill & num4);
					QueueTarget(TargetIndex.A, new TargetObject(item2));
				}
			}
			isEnabled = GetTargetQueue(TargetIndex.A).Count > 0;
			return isEnabled;
		}

		private bool ShouldAbort()
		{
			ResourcePileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>();
			if (objectAs == null || objectAs.Blueprint?.EquipmentBlueprint == null)
			{
				return true;
			}
			if (objectAs.IsOnFire)
			{
				return true;
			}
			CaptiveNpcBehaviour captiveNpcBehaviour = ((HumanoidInstance)base.AgentOwner).CaptiveNpcBehaviour;
			if (captiveNpcBehaviour != null)
			{
				return !captiveNpcBehaviour.AutoEquipSlots.HasFlag(objectAs.Blueprint.EquipmentBlueprint.EquipmentSlots);
			}
			return false;
		}
	}
}
