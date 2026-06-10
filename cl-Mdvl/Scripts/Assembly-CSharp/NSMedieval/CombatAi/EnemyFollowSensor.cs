using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class EnemyFollowSensor : CombatAiSensor
	{
		private const float MeleeRefreshTime = 1f;

		private bool wasSet;

		private int raidId;

		private float lastMeleeTimeCheck;

		public EnemyFollowSensor(CombatAiAgent agent)
			: base(agent)
		{
			if (!(((HumanoidInstance)base.CombatAgent).ActiveBehaviour is EnemyBehaviour enemyBehaviour))
			{
				raidId = 0;
			}
			else
			{
				raidId = enemyBehaviour.RaidId;
			}
		}

		internal override void InitStates()
		{
			base.CombatAi.SetState(CombatAiState.FollowTarget, null);
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (CombatUtils.GetAttackType(base.CombatAgent) == AttackType.Melee)
			{
				if (Time.unscaledTime - lastMeleeTimeCheck < 1f)
				{
					return;
				}
				lastMeleeTimeCheck = Time.unscaledTime;
			}
			if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget))
			{
				if (wasSet)
				{
					wasSet = false;
					base.CombatAi.SetState(CombatAiState.FollowTarget, null);
				}
				return;
			}
			CreatureBase state = base.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget);
			if (state == null)
			{
				FindCreatureToFollow();
				return;
			}
			if (state.HasFainted || state.HasDisposed)
			{
				FindCreatureToFollow();
				return;
			}
			bool flag = state.CombatAi?.IsStateSet(CombatAiState.PreferedTarget) ?? false;
			if (CombatUtils.GetAttackType(state) != AttackType.Melee && !flag)
			{
				FindCreatureToFollow();
			}
			else if (!flag)
			{
				FindCreatureToFollow(followOnlyCreaturesThatHaveTarget: true);
			}
		}

		private void FindCreatureToFollow(bool followOnlyCreaturesThatHaveTarget = false)
		{
			float closestDist = float.MaxValue;
			CreatureBase closest = null;
			using PooledList<HumanoidInstance> pooledList = MonoSingleton<NPCManager>.Instance.GetNPCsPooled(delegate(HumanoidInstance item)
			{
				if (raidId != 0 && item.ActiveBehaviour is EnemyBehaviour enemyBehaviour && enemyBehaviour.RaidId != raidId)
				{
					return false;
				}
				if (item == base.CombatAgent)
				{
					return false;
				}
				bool flag = item.GetTarget() != null;
				if (item.CombatAi.IsStateSet(CombatAiState.PreferedTarget))
				{
					flag = true;
				}
				if (!flag)
				{
					return true;
				}
				float num = Vector3.Distance(item.GetPosition(), base.CombatAgent.GetPosition());
				if (num < closestDist)
				{
					closestDist = num;
					closest = item;
				}
				return false;
			});
			if (closest == null)
			{
				if (followOnlyCreaturesThatHaveTarget || pooledList.Count == 0)
				{
					return;
				}
				{
					foreach (HumanoidInstance item in pooledList)
					{
						if (CombatUtils.GetAttackType(item) == AttackType.Melee)
						{
							base.CombatAi.SetState(CombatAiState.FollowTarget, item);
							wasSet = true;
							break;
						}
					}
					return;
				}
			}
			base.CombatAi.SetState(CombatAiState.FollowTarget, closest);
			wasSet = true;
		}
	}
}
