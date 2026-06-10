using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	internal class CombatAiTargetSwitcherEnemy : CombatAiTargetSwitcherDefault
	{
		private const float CallForBackupRange = 15f;

		private int originalWalkableFlags;

		private HashSet<HumanoidInstance> enemies;

		private bool shouldRefillEnemiesList;

		private EnemyBehaviour enemyBehaviour;

		public override void SetAgent(CombatAiAgent agent)
		{
			base.SetAgent(agent);
			FillInAgentsList();
			MonoSingleton<CombatController>.Instance.DamageAgentRegisteredEvent += OnCombatAgentRegistered;
			enemyBehaviour = (agent.AgentOwner as HumanoidInstance)?.EnemyBehaviour;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageAgentRegisteredEvent -= OnCombatAgentRegistered;
			}
			enemies?.Clear();
			enemies = null;
		}

		public override bool DoProcessing()
		{
			if (enemyBehaviour?.CurrentOrder != null)
			{
				return false;
			}
			if (!base.DoProcessing())
			{
				return false;
			}
			if (enemies == null || enemies.Count == 0 || shouldRefillEnemiesList)
			{
				shouldRefillEnemiesList = false;
				FillInAgentsList();
			}
			IDamageTakingAgent state = base.Agent.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			if (state is CreatureBase)
			{
				TryCallForBackup(state);
			}
			return true;
		}

		private void FillInAgentsList()
		{
			if (enemies == null)
			{
				enemies = new HashSet<HumanoidInstance>();
			}
			else
			{
				enemies.Clear();
			}
			MonoSingleton<CombatAgentManager>.Instance.DamageDealAgentSafeForEach(delegate(IDamageDealAgent item)
			{
				if (item != base.Agent.AgentOwner && item is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy() && !humanoidInstance.HasDied && !humanoidInstance.HasDisposed && humanoidInstance.CombatAi != null)
				{
					enemies.Add(humanoidInstance);
				}
			});
		}

		private void OnCombatAgentRegistered(IDamageCommonAgent agent)
		{
			if (!(agent is HumanoidInstance humanoidInstance) || (humanoidInstance.IsEnemy() && humanoidInstance != base.Agent.AgentOwner))
			{
				shouldRefillEnemiesList = true;
			}
		}

		private void TryCallForBackup(IDamageTakingAgent target)
		{
			if (target is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy())
			{
				Log.Warning("Enemy tried to call for backup to attack other enemy! Breaking here...", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiTargetSwitcherEnemy.cs");
				return;
			}
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.Agent.AgentOwner;
			foreach (HumanoidInstance enemy in enemies)
			{
				if (enemy.HasDied || enemy.HasDisposed || Vector3.Distance(enemy.GetPosition(), damageDealAgent.GetPosition()) > 15f)
				{
					break;
				}
				IDamageTakingAgent state = enemy.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
				if (state != null && !(state is BaseBuildingInstance))
				{
					break;
				}
				enemy.CombatAi.SetState(CombatAiState.NextTarget, target);
			}
		}
	}
}
