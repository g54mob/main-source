using System.Collections.Generic;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.CombatAi
{
	public sealed class AnimalFollowOwnerAiActionGoal : CombatAiActionGoal
	{
		private readonly AnimalInstance animalAgent;

		public AnimalFollowOwnerAiActionGoal(Agent selfAgent)
			: base("AnimalFollowOwnerAiActionGoal", selfAgent)
		{
			animalAgent = base.CombatAgent as AnimalInstance;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			animalAgent?.GoapAgent?.GoalScheduler?.EnableGoal("StockpileHaulingGoal");
			animalAgent?.GoapAgent?.GoalScheduler?.EnableGoal("StockpileUrgentHaulingGoal");
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			animalAgent.GoapAgent.GoalScheduler.DisableGoal("StockpileHaulingGoal");
			animalAgent.GoapAgent.GoalScheduler.DisableGoal("StockpileUrgentHaulingGoal");
			return base.GetNextAction();
		}

		public override bool CanStart(bool isForced = false)
		{
			if (animalAgent.AnimalType != AnimalType.Pet)
			{
				return false;
			}
			if (!(animalAgent.PetOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour.IsDrafting)
			{
				return animalAgent.PetBattleEnabled;
			}
			return false;
		}

		internal override void Update()
		{
			CreatureBase petOwner = animalAgent.PetOwner;
			if (petOwner == null || petOwner.HasFainted || petOwner.HasDisposed)
			{
				base.Update();
				return;
			}
			if (animalAgent.FollowCreature != petOwner)
			{
				animalAgent.SetFollowCreature(petOwner);
			}
			base.Update();
		}

		protected override bool ShouldAbort()
		{
			if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget) || base.CombatAi.IsStateSet(CombatAiState.NextTarget))
			{
				return true;
			}
			return base.ShouldAbort();
		}

		protected override void OnStart()
		{
			base.OnStart();
			ForceGoapAgentGoal("FollowGoal");
		}
	}
}
