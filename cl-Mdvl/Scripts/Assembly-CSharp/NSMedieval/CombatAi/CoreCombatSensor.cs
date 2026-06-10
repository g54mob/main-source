using System;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.CombatAi
{
	public class CoreCombatSensor : CombatAiSensor
	{
		private StatInstance health;

		public CoreCombatSensor(CombatAiAgent agent)
			: base(agent)
		{
			IDamageDealAgent combatAgent = base.CombatAgent;
			health = combatAgent.Stats.GetStat(StatType.Health);
			if (health == null)
			{
				Log.Error("This should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Sensors\\CoreCombatSensor.cs");
			}
		}

		public override void Dispose()
		{
			health = null;
			base.Dispose();
		}

		internal override void InitStates()
		{
			base.CombatAi.SetState(CombatAiState.IsDamaged, false);
			base.CombatAi.SetState(CombatAiState.TargetersCount, 0);
			base.CombatAi.SetState(CombatAiState.LastDamageTakenTime, 0L);
			base.CombatAi.SetState(CombatAiState.LastDamageTakenFrom, null);
			base.CombatAi.SetState(CombatAiState.LastMissFrom, null);
			base.CombatAi.SetState(CombatAiState.LastMissTime, 0L);
			base.CombatAi.SetState(CombatAiState.LastBlockFrom, null);
			base.CombatAi.SetState(CombatAiState.LastBlockTime, 0L);
			base.CombatAi.SetState(CombatAiState.IsFleeing, false);
			base.CombatAi.SetState(CombatAiState.PreferedTarget, null);
			base.CombatAi.SetState(CombatAiState.Fainted, (base.CombatAgent as CreatureBase)?.HasFainted);
			base.CombatAi.SetState(CombatAiState.IsInCombat, false);
			base.CombatAi.SetState(CombatAiState.WalkingToPosition, base.CombatAgent.GetPosition());
		}

		internal override void Refresh()
		{
			base.Refresh();
			bool flag = health.Current < health.Max - 1.5f;
			base.CombatAi.SetState(CombatAiState.IsDamaged, flag);
			if (!CombatUtils.IsAlive(base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget)))
			{
				base.CombatAi.SetState(CombatAiState.PreferedTarget, null);
			}
			UpdateWalkingDestination();
			UpdateCombatState();
		}

		public override void PreferredTargetUpdated(IDamageDealAgent agent, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget)
		{
			if (!CombatUtils.IsAlive(newTarget))
			{
				newTarget = null;
			}
			if (base.CombatAgent == agent)
			{
				if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget) && newTarget == null)
				{
					base.CombatAi.ForceRefreshSensors();
					base.CombatAi.ForceRefreshReactions();
				}
				base.CombatAi.SetState(CombatAiState.PreferedTarget, newTarget);
			}
			else if (base.CombatAgent == oldTarget)
			{
				int state = base.CombatAi.GetState<int>(CombatAiState.TargetersCount);
				state--;
				base.CombatAi.SetState(CombatAiState.TargetersCount, Math.Max(state, 0));
			}
			else if (base.CombatAgent == newTarget)
			{
				int state2 = base.CombatAi.GetState<int>(CombatAiState.TargetersCount);
				state2++;
				base.CombatAi.SetState(CombatAiState.TargetersCount, state2);
			}
		}

		public override void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (base.CombatAgent != null && take == base.CombatAgent)
			{
				base.CombatAi.SetState(CombatAiState.LastDamageTakenTime, GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware);
				base.CombatAi.SetState(CombatAiState.LastDamageTakenFrom, deal);
				UpdateCombatState();
			}
		}

		public override void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
			if (base.CombatAgent != null && take == base.CombatAgent)
			{
				base.CombatAi.SetState(CombatAiState.LastMissTime, GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware);
				base.CombatAi.SetState(CombatAiState.LastMissFrom, deal);
			}
		}

		public override void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitinfo)
		{
			if (base.CombatAgent != null && take == base.CombatAgent)
			{
				base.CombatAi.SetState(CombatAiState.LastBlockTime, GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware);
				base.CombatAi.SetState(CombatAiState.LastBlockFrom, deal);
			}
		}

		public override void OnDamageAgentRemoved(IDamageCommonAgent agent)
		{
			if (agent == null || agent == base.CombatAgent)
			{
				return;
			}
			int num = MonoSingleton<CombatTargetManager>.Instance.GetAttackersForTarget(base.CombatAgent as IDamageTakingAgent)?.Count ?? 0;
			base.CombatAi.SetState(CombatAiState.TargetersCount, num);
			if (base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget) == agent)
			{
				base.CombatAi.SetState(CombatAiState.PreferedTarget, null);
			}
			if (base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.NextTarget) == agent)
			{
				base.CombatAi.SetState(CombatAiState.NextTarget, null);
			}
			if (base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.NextTargetValidated) == agent)
			{
				base.CombatAi.SetState(CombatAiState.NextTargetValidated, null);
			}
			if (base.CombatAi.GetState<IDamageDealAgent>(CombatAiState.LastDamageTakenFrom) == agent)
			{
				base.CombatAi.SetState(CombatAiState.LastDamageTakenFrom, null);
			}
			if (base.CombatAi.GetState<IDamageDealAgent>(CombatAiState.LastMissFrom) == agent)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					base.CombatAi?.SetState(CombatAiState.LastDamageTakenFrom, null);
				});
			}
			if (base.CombatAi.GetState<IDamageDealAgent>(CombatAiState.LastBlockFrom) == agent)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					base.CombatAi?.SetState(CombatAiState.LastDamageTakenFrom, null);
				});
			}
			if (base.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget) == agent)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					base.CombatAi?.SetState(CombatAiState.FollowTarget, null);
				});
			}
			UpdateCombatState();
		}

		public override void OnFainted(StatsInstance stats)
		{
			if (stats.Owner == base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget))
			{
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, null);
			}
			else if (stats.Owner == base.CombatAgent)
			{
				base.CombatAi.SetState(CombatAiState.Fainted, true);
			}
		}

		public override void OnWokeUp(StatsInstance stats)
		{
			if (stats.Owner == base.CombatAgent)
			{
				base.CombatAi.SetState(CombatAiState.Fainted, false);
			}
		}

		private void UpdateCombatState()
		{
			base.CombatAi.SetState(CombatAiState.IsInCombat, CombatUtils.CheckIsInCombat(base.CombatAgent));
		}

		private void UpdateWalkingDestination()
		{
			PathfinderAgentDriver pathfinderAgentDriver = (base.CombatAgent as IPathfindingAgent)?.PathDriver;
			if (pathfinderAgentDriver != null)
			{
				if (!pathfinderAgentDriver.IsMoving)
				{
					base.CombatAi.SetState(CombatAiState.WalkingToPosition, pathfinderAgentDriver.Agent.GetPosition());
				}
				else
				{
					base.CombatAi.SetState(CombatAiState.WalkingToPosition, GridUtils.GetWorldPosition(pathfinderAgentDriver.FinalDestination));
				}
			}
		}
	}
}
