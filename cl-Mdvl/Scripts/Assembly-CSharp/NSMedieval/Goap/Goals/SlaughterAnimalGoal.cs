using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GOAP.Action;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Water;

namespace NSMedieval.Goap.Goals
{
	public class SlaughterAnimalGoal : Goal
	{
		public SlaughterAnimalGoal(Agent selfAgent)
			: base("SlaughterAnimalGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestAnimal));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<AnimalManager>.IsInstantiated())
			{
				return MonoSingleton<AnimalManager>.Instance.HasAnimalWithOrder(AnimalOrderType.Slaughter);
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHarvestAgent;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (condition != GoalCondition.Succeeded)
			{
				GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>().GetGoapAgent()?.StartTicker();
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SlaughterAnimalGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SlaughterAnimalGoal ended, goal condition: ");
					messageBuilder.AppendFormatted(condition);
				}
				Log.Info(messageBuilder);
			}
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToHarvestAnimalTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange)
				.StopAnimalTickerWhenInRange(TargetIndex.A)
				.RestoreAnimalTickerOnFail(TargetIndex.A);
			goapAction.OnPostInit = delegate
			{
				((IToolAgent)base.AgentOwner).SetTool("cooking_knife_item");
			};
			yield return goapAction;
			AnimalInstance animalInstance = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			GoapAction goapAction2 = GeneralActions.WaitForever().TriggerAnimation("Slaughter", ActionAnimationMode.Interrupt).CompleteActionOnAnimationGoapEvent("AnimalSlaughtered", ActionCompletionStatus.Success);
			goapAction2.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (animalInstance != null && !animalInstance.HasDisposed && status == ActionCompletionStatus.Success)
				{
					MonoSingleton<AnimalController>.Instance.DepletedHealth(animalInstance);
					(base.AgentOwner as HumanoidInstance)?.AddExperience(SkillType.AnimalHandling, animalInstance.Blueprint.SlaughterXp);
				}
			};
			goapAction2.FailAtCondition(FailWhenConditionsChange);
			goapAction2.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction2.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction2.FailAtCondition(() => UnderWater(GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>()));
			yield return goapAction2;
		}

		private bool FindClosestAnimal()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				AnimalInstance objectAs = target.GetObjectAs<AnimalInstance>();
				if (objectAs.OrderType == AnimalOrderType.Slaughter && (objectAs.AnimalType == AnimalType.Domestic || objectAs.AnimalType == AnimalType.Pet) && !objectAs.IsFormingCaravan() && !objectAs.PathDriver.IsClimbing && !UnderWater(objectAs) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			List<TargetObject> list = PathfinderAnimals.FindAnimals((IPathfindingAgent)base.AgentOwner, MonoSingleton<AnimalManager>.Instance.Animals.Keys.Where((AnimalInstance x) => !CombatUtils.IsNullOrDisposed(x) && x.OrderType == AnimalOrderType.Slaughter && (x.AnimalType == AnimalType.Domestic || x.AnimalType == AnimalType.Pet) && !x.IsFormingCaravan() && x.GetNode() != null && x.GetNode().GetLayerRampObject() == null && !x.PathDriver.IsClimbing && !UnderWater(x)), 1);
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
			if (objectAs.OrderType != AnimalOrderType.Slaughter)
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
			if (UnderWater(GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>()))
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
