using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class ClosestAttackableProximitySensor : CombatAiSensor
	{
		private IDamageTakingAgent combatAgent;

		public ClosestAttackableProximitySensor(CombatAiAgent agent)
			: base(agent)
		{
			combatAgent = base.CombatAgent as IDamageTakingAgent;
		}

		public override void Dispose()
		{
			base.Dispose();
			combatAgent = null;
		}

		internal override void InitStates()
		{
			base.CombatAi.SetState(CombatAiState.NearestHostile, null);
			if (base.CombatAi.TryGetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles, out var value))
			{
				value.Clear();
			}
			else
			{
				base.CombatAi.SetState(CombatAiState.PerceptionHostiles, new HashSet<IDamageDealAgent>());
			}
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (combatAgent == null)
			{
				return;
			}
			IDamageDealAgent dealAgent = (IDamageDealAgent)combatAgent;
			DamageTakingAgentType type = combatAgent.DamageAgentType;
			bool agentIsRanged = CombatUtils.GetAttackType(dealAgent) != AttackType.Melee;
			float meleePerceptionRange = combatAgent.Stats?.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? (-1f);
			if (dealAgent != null && !agentIsRanged)
			{
				meleePerceptionRange = combatAgent.Stats?.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? (-1f);
				if (meleePerceptionRange < 0f)
				{
					return;
				}
			}
			HashSet<IDamageDealAgent> hostilesInPerception = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			hostilesInPerception.RemoveWhere((IDamageDealAgent item) => item.HasDisposed);
			AnimalInstance thisAnimal = base.CombatAgent as AnimalInstance;
			IDamageDealAgent closestHostile = null;
			float closestHostileDistance = float.MaxValue;
			MonoSingleton<CombatAgentManager>.Instance.DamageDealAgentSafeForEach(delegate(IDamageDealAgent target)
			{
				if (!target.HasDisposed && target != combatAgent && (target.CanAttackTypes() & type) != DamageTakingAgentType.None && !(target is CreatureBase { HasFainted: not false }) && CombatUtils.IsAlive(target) && (thisAnimal == null || !(target is AnimalInstance other) || !thisAnimal.IsSameCategory(other)))
				{
					float num = Vector3.Distance(target.GetPosition(), combatAgent.GetPosition());
					bool flag;
					if (agentIsRanged)
					{
						flag = CombatUtils.IsInAttackRange(dealAgent, target as IDamageTakingAgent);
					}
					else
					{
						float num2 = meleePerceptionRange;
						if (dealAgent.GetPosition().y - target.GetPosition().y > 1f)
						{
							num2 = 1.4f * num2;
						}
						flag = num < num2;
					}
					if (flag)
					{
						if (num < closestHostileDistance)
						{
							closestHostileDistance = num;
							closestHostile = target;
						}
						hostilesInPerception.Add(target);
					}
					else
					{
						hostilesInPerception.Remove(target);
					}
				}
			});
			base.CombatAi.SetState(CombatAiState.NearestHostile, closestHostile);
		}

		public override void OnDamageAgentRemoved(IDamageCommonAgent agent)
		{
			if (agent != null && base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.NearestHostile) == agent)
			{
				base.CombatAi.SetState(CombatAiState.NearestHostile, null);
			}
		}
	}
}
