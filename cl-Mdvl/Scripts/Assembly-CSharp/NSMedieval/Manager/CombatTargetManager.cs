using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;

namespace NSMedieval.Manager
{
	public class CombatTargetManager : MonoSingleton<CombatTargetManager>
	{
		private readonly Dictionary<IDamageTakingAgent, HashSet<IDamageDealAgent>> targetDictionary = new Dictionary<IDamageTakingAgent, HashSet<IDamageDealAgent>>();

		private readonly Dictionary<IDamageDealAgent, IDamageTakingAgent> preferredTargets = new Dictionary<IDamageDealAgent, IDamageTakingAgent>();

		private readonly object preferredTargetsLock = new object();

		protected override void OnDestroy()
		{
			base.OnDestroy();
			foreach (HashSet<IDamageDealAgent> value in targetDictionary.Values)
			{
				value.Clear();
			}
			targetDictionary.Clear();
			lock (preferredTargetsLock)
			{
				preferredTargets.Clear();
			}
		}

		public HashSet<IDamageDealAgent> GetAttackersForTarget(IDamageTakingAgent target)
		{
			if (target == null)
			{
				return null;
			}
			if (targetDictionary.ContainsKey(target))
			{
				return targetDictionary[target];
			}
			return null;
		}

		public bool HasAttackers(IDamageTakingAgent target)
		{
			HashSet<IDamageDealAgent> attackersForTarget = GetAttackersForTarget(target);
			if (attackersForTarget != null)
			{
				return attackersForTarget.Count > 0;
			}
			return false;
		}

		public void SetPreferredTarget(IDamageDealAgent agent, IDamageTakingAgent target)
		{
			if (agent == null)
			{
				return;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(32, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatTargetManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetPreferredTarget '");
				messageBuilder.AppendFormatted(target);
				messageBuilder.AppendLiteral("' for agent ");
				messageBuilder.AppendFormatted(agent);
			}
			Log.Trace(messageBuilder);
			IDamageTakingAgent value = null;
			lock (preferredTargetsLock)
			{
				if (target == null)
				{
					if (!preferredTargets.Remove(agent, out value))
					{
						return;
					}
				}
				else if (!preferredTargets.TryAdd(agent, target))
				{
					value = preferredTargets[agent];
					preferredTargets[agent] = target;
				}
			}
			MonoSingleton<CombatController>.Instance.OnPreferedTargetUpdated(agent, target, value);
		}

		public bool RemovePreferredTarget(IDamageDealAgent agent)
		{
			lock (preferredTargetsLock)
			{
				if (!preferredTargets.ContainsKey(agent))
				{
					return false;
				}
			}
			SetPreferredTarget(agent, null);
			return true;
		}

		public IDamageTakingAgent GetPreferredTarget(IDamageDealAgent agent)
		{
			if (agent == null)
			{
				return null;
			}
			IDamageTakingAgent damageTakingAgent;
			lock (preferredTargetsLock)
			{
				if (!preferredTargets.ContainsKey(agent))
				{
					return null;
				}
				damageTakingAgent = preferredTargets[agent];
			}
			if (!ValidateAgentState(damageTakingAgent))
			{
				RemovePreferredTarget(agent);
				return null;
			}
			return damageTakingAgent;
		}

		public bool HasPreferredTarget(IDamageDealAgent agent, Predicate<IDamageTakingAgent> targetPredicate = null)
		{
			IDamageTakingAgent damageTakingAgent = null;
			lock (preferredTargetsLock)
			{
				if (preferredTargets.ContainsKey(agent))
				{
					damageTakingAgent = preferredTargets[agent];
				}
			}
			if (damageTakingAgent != null && ValidateAgentState(damageTakingAgent))
			{
				return targetPredicate?.Invoke(damageTakingAgent) ?? true;
			}
			return false;
		}

		public bool IsPreferredTarget(IDamageTakingAgent agent)
		{
			lock (preferredTargetsLock)
			{
				return preferredTargets.ContainsValue(agent);
			}
		}

		public void ClearAttackers(IDamageTakingAgent agent)
		{
			List<KeyValuePair<IDamageDealAgent, IDamageTakingAgent>> list;
			lock (preferredTargetsLock)
			{
				list = preferredTargets.Where((KeyValuePair<IDamageDealAgent, IDamageTakingAgent> item) => item.Value == agent).ToList();
			}
			foreach (KeyValuePair<IDamageDealAgent, IDamageTakingAgent> item in list)
			{
				SetPreferredTarget(item.Key, null);
			}
		}

		public IDamageDealAgent GetFirstPreferedAttacker(IDamageTakingAgent agent)
		{
			lock (preferredTargetsLock)
			{
				foreach (KeyValuePair<IDamageDealAgent, IDamageTakingAgent> preferredTarget in preferredTargets)
				{
					if (preferredTarget.Value == agent)
					{
						return preferredTarget.Key;
					}
				}
			}
			return null;
		}

		public int CountPreferedAttackers(IDamageTakingAgent agent)
		{
			lock (preferredTargetsLock)
			{
				return preferredTargets.Count((KeyValuePair<IDamageDealAgent, IDamageTakingAgent> pair) => pair.Value == agent);
			}
		}

		public IDamageDealAgent FindAttacker(IDamageTakingAgent take, Predicate<IDamageDealAgent> attackerPredicate)
		{
			HashSet<IDamageDealAgent> attackersForTarget = GetAttackersForTarget(take);
			if (attackersForTarget == null)
			{
				return null;
			}
			foreach (IDamageDealAgent item in attackersForTarget)
			{
				if (attackerPredicate(item))
				{
					return item;
				}
			}
			return null;
		}

		private void DamageTakingAgentRemoved(IDamageTakingAgent agent)
		{
			targetDictionary.Remove(agent);
			List<KeyValuePair<IDamageDealAgent, IDamageTakingAgent>> list;
			lock (preferredTargetsLock)
			{
				list = preferredTargets.Where((KeyValuePair<IDamageDealAgent, IDamageTakingAgent> item) => item.Value == agent).ToList();
			}
			foreach (KeyValuePair<IDamageDealAgent, IDamageTakingAgent> item in list)
			{
				SetPreferredTarget(item.Key, null);
			}
			foreach (IDamageDealAgent item2 in MonoSingleton<CombatAgentManager>.Instance.GetDamageDealAgentsSafe((IDamageDealAgent item) => item.GetTarget() == agent))
			{
				item2.SetTarget(null);
			}
		}

		private void DamageDealingAgentRemoved(IDamageDealAgent agent)
		{
			foreach (HashSet<IDamageDealAgent> value in targetDictionary.Values)
			{
				if (value != null && value.Contains(agent))
				{
					value.Remove(agent);
				}
			}
			lock (preferredTargetsLock)
			{
				preferredTargets.Remove(agent);
			}
		}

		private void OnTargetChanged(IDamageDealAgent agent, IDamageTakingAgent oldTarget)
		{
			HashSet<IDamageDealAgent> attackersForTarget = GetAttackersForTarget(oldTarget);
			if (attackersForTarget != null)
			{
				targetDictionary[oldTarget].Remove(agent);
			}
			if (agent.GetTarget() != null)
			{
				IDamageTakingAgent target = agent.GetTarget();
				attackersForTarget = GetAttackersForTarget(target);
				if (attackersForTarget == null)
				{
					attackersForTarget = new HashSet<IDamageDealAgent> { agent };
					targetDictionary[target] = attackersForTarget;
				}
				attackersForTarget.Add(agent);
				IDamageTakingAgent preferredTarget = GetPreferredTarget(agent);
				if (preferredTarget != null && preferredTarget != target)
				{
					RemovePreferredTarget(agent);
				}
			}
		}

		private bool ValidateAgentState(IDamageCommonAgent agent)
		{
			if (agent != null)
			{
				return CombatUtils.IsAlive(agent);
			}
			return false;
		}

		private void Start()
		{
			MonoSingleton<CombatController>.Instance.DamageAgentRemovedEvent += HandleOnAgentRemovedEvent;
			MonoSingleton<CombatController>.Instance.AgentDiedEvent += HandleOnAgentRemovedEvent;
			MonoSingleton<CombatController>.Instance.TargetChangedEvent += OnTargetChanged;
			MonoSingleton<CombatTargetManager>.Instance.GetAttackersForTarget(null);
			void HandleOnAgentRemovedEvent(IDamageCommonAgent agent)
			{
				if (agent is IDamageTakingAgent agent2)
				{
					DamageTakingAgentRemoved(agent2);
				}
				if (agent is IDamageDealAgent agent3)
				{
					DamageDealingAgentRemoved(agent3);
				}
			}
		}
	}
}
