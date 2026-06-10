using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class HostileProximitySensor : CombatAiSensor
	{
		private readonly IDamageTakingAgent combatAgent;

		public HostileProximitySensor(CombatAiAgent agent)
			: base(agent)
		{
			combatAgent = base.CombatAgent as IDamageTakingAgent;
		}

		public static bool IsHostile(IDamageDealAgent item, IDamageTakingAgent self)
		{
			DamageTakingAgentType damageAgentType = self.DamageAgentType;
			if (damageAgentType == DamageTakingAgentType.Worker && item is HumanoidInstance { WorkerBehaviour: not null })
			{
				return false;
			}
			if ((item.CanAttackTypes() & damageAgentType) == 0)
			{
				return false;
			}
			if (item is IDamageTakingAgent damageTakingAgent && damageTakingAgent.DamageAgentType == damageAgentType && item.GetTarget() != self)
			{
				CombatAiAgent combatAi = item.CombatAi;
				if (combatAi == null || !combatAi.IsStateSet(CombatAiState.IsAggressive))
				{
					return false;
				}
			}
			if (item is CreatureBase { HasFainted: not false } || !CombatUtils.IsAlive(item))
			{
				return false;
			}
			if (!(item is AnimalInstance animalInstance))
			{
				return true;
			}
			CombatAiAgent combatAi2 = animalInstance.CombatAi;
			if (combatAi2 != null && combatAi2.IsStateSet(CombatAiState.IsAggressive))
			{
				if (!(self is HumanoidInstance humanoidInstance2))
				{
					return true;
				}
				if (humanoidInstance2.IsWorker())
				{
					return true;
				}
				CombatAiAgent combatAi3 = animalInstance.CombatAi;
				if (combatAi3 != null && combatAi3.IsStateSet(CombatAiState.PreferedTarget))
				{
					return true;
				}
				return false;
			}
			IDamageTakingAgent damageTakingAgent2 = null;
			CombatAiAgent combatAi4 = animalInstance.CombatAi;
			if (combatAi4 != null && combatAi4.IsStateSet(CombatAiState.PreferedTarget))
			{
				damageTakingAgent2 = animalInstance.CombatAi?.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			}
			if (damageTakingAgent2 != null && (damageTakingAgent2.DamageAgentType & self.DamageAgentType) != DamageTakingAgentType.None)
			{
				return true;
			}
			return false;
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
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)combatAgent;
			float num = float.MaxValue;
			bool flag = CombatUtils.GetAttackType(damageDealAgent) != AttackType.Melee;
			float num2 = combatAgent.Stats?.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? (-1f);
			if (damageDealAgent != null && !flag)
			{
				num2 = combatAgent.Stats?.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? (-1f);
				if (num2 < 0f)
				{
					return;
				}
			}
			HashSet<IDamageDealAgent> state = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			state.RemoveWhere((IDamageDealAgent item) => item.HasDisposed);
			bool flag2 = combatAgent is HumanoidInstance;
			IDamageDealAgent obj = null;
			foreach (IDamageDealAgent damageDealingAgent in MonoSingleton<CombatAgentManager>.Instance.DamageDealingAgents)
			{
				if (damageDealingAgent.HasDisposed || damageDealingAgent == combatAgent || !IsHostile(damageDealingAgent, combatAgent))
				{
					continue;
				}
				Vector3 position = damageDealingAgent.GetPosition();
				Vector3 position2 = combatAgent.GetPosition();
				float num3 = Vector3.Distance(position, position2);
				bool flag3;
				if (flag)
				{
					flag3 = CombatUtils.IsInAttackRange(damageDealAgent, damageDealingAgent as IDamageTakingAgent);
				}
				else
				{
					float num4 = num2;
					if (damageDealAgent.GetPosition().y - damageDealingAgent.GetPosition().y > 1f)
					{
						num4 = 1.3f * num4;
					}
					flag3 = num3 < num4;
				}
				if (flag3)
				{
					if (flag2 && !CombatUtils.HasCombatLos(position.SnapToGrid(), position2.SnapToGrid()))
					{
						state.Remove(damageDealingAgent);
						continue;
					}
					if (num3 < num)
					{
						num = num3;
						obj = damageDealingAgent;
					}
					state.Add(damageDealingAgent);
				}
				else
				{
					state.Remove(damageDealingAgent);
				}
			}
			using (ProfilerSampleJanitor.Begin("CombatAi.SetState(NearestHostile)"))
			{
				base.CombatAi.SetState(CombatAiState.NearestHostile, obj);
			}
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
