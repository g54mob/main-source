using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.CombatAi
{
	public class AnimalAttackHungerAiPlanGoal : CombatAiPlanningGoal
	{
		private readonly AnimalInstance animal;

		private PathfinderAgentDriver pathfinderAgentDriver;

		private CreatureBase target;

		private AnimalAttackGroup attackGroupSelected;

		private bool isAttackEnabled;

		protected AnimalAttackHungerAiPlanGoal(string id, Agent selfAgent)
			: base(id, selfAgent)
		{
			animal = (AnimalInstance)base.CombatAgent;
			Init();
		}

		public AnimalAttackHungerAiPlanGoal(Agent selfAgent)
			: base("AnimalAttackHungerAiPlanGoal", selfAgent)
		{
			animal = (AnimalInstance)base.CombatAgent;
			Init();
		}

		private void Init()
		{
			AddInitStep(new ThreadSequenceStep(AssignTarget));
			AnimalGoapAgent animalGoapAgent = (AnimalGoapAgent)animal.GetGoapAgent();
			if (animalGoapAgent != null)
			{
				animalGoapAgent.GetGoalInitializer().OnInitSequenceFailedEvent += OnGoalFailed;
			}
		}

		private void OnGoalFailed(ThreadSequenceJobCompleteStatus status, Goal goal)
		{
			if (!(goal.Id != "AnimalHungerGoal") && status != ThreadSequenceJobCompleteStatus.Success && !(animal.AttackGroup == null) && !animal.IsSleeping && !animal.IsLeavingMap && !animal.IsBeingCarried && !animal.IsReceivingWoundTreatman)
			{
				isAttackEnabled = true;
			}
		}

		public override bool CanStart(bool isForced = false)
		{
			if (string.IsNullOrEmpty(animal?.GetGoapAgent()?.CurrentGoalName) || animal?.GetGoapAgent()?.CurrentGoalName == "SleepGoal")
			{
				return false;
			}
			attackGroupSelected = null;
			if (animal == null || animal.HasDied || animal.HasDisposed)
			{
				return false;
			}
			if (animal.IsSleeping || animal.IsLeavingMap || animal.IsBeingCarried || animal.IsReceivingWoundTreatman)
			{
				return false;
			}
			if (MonoSingleton<CombatTargetManager>.Instance.HasPreferredTarget(animal))
			{
				return false;
			}
			AnimalAttackGroup pestGroup = animal.PestGroup;
			if (pestGroup != null && animal.CanPestControlGoalStart && MonoSingleton<AnimalAttackGroupManager>.Instance.AnyReachableAgentsOnMap(animal, pestGroup))
			{
				attackGroupSelected = pestGroup;
				return true;
			}
			if (isAttackEnabled)
			{
				AnimalAttackGroup attackGroup = animal.AttackGroup;
				if (attackGroup != null)
				{
					attackGroupSelected = attackGroup;
					return MonoSingleton<AnimalAttackGroupManager>.Instance.AnyReachableAgentsOnMap(animal, attackGroup);
				}
			}
			return false;
		}

		private bool AssignTarget()
		{
			if (attackGroupSelected == null)
			{
				return false;
			}
			target = MonoSingleton<AnimalAttackGroupManager>.Instance.PickAgentFromMap(animal, attackGroupSelected);
			if (target == null)
			{
				return false;
			}
			if (target == null || target.HasDied || target.HasDisposed || !CombatUtils.IsAlive(target) || !CombatUtils.IsAttackPossible(animal, target))
			{
				return false;
			}
			animal.SetTarget(target);
			MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(animal, target);
			isAttackEnabled = false;
			return true;
		}
	}
}
