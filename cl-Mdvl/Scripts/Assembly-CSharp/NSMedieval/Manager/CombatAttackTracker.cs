using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CombatAttackTracker : MonoSingleton<CombatAttackTracker>
	{
		private readonly object threadLock = new object();

		private readonly Dictionary<Vec3Int, IDamageDealAgent> reservedPoints = new Dictionary<Vec3Int, IDamageDealAgent>();

		private readonly ConcurrentDictionary<IDamageTakingAgent, float> unreachableTargetCooldown = new ConcurrentDictionary<IDamageTakingAgent, float>();

		private readonly ConcurrentDictionary<IDamageTakingAgent, int> consecutiveUnreachableTargets = new ConcurrentDictionary<IDamageTakingAgent, int>();

		public bool CanBeReservedBy(Vec3Int position, IDamageDealAgent agent)
		{
			lock (threadLock)
			{
				if (!reservedPoints.TryGetValue(position, out var value))
				{
					return true;
				}
				return value == agent;
			}
		}

		public Path StartAttackPath(IDamageDealAgent agent, IDamageTakingAgent target = null)
		{
			if (target == null)
			{
				target = agent.GetTarget();
			}
			Path path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(agent, target);
			if (path == null)
			{
				return null;
			}
			path.OnCalculationsDoneEvent += delegate(Path path2)
			{
				if (!agent.HasDisposed && path2.State == PathState.Calculated)
				{
					StoreAttackPoint(agent, path2);
				}
			};
			return path;
		}

		public bool IsTargetOnCooldown(IDamageTakingAgent target, float currentUnscaledTime)
		{
			if (unreachableTargetCooldown.TryGetValue(target, out var value))
			{
				return currentUnscaledTime < value;
			}
			return false;
		}

		public void SetTargetCooldown(IDamageTakingAgent target, float currentUnscaledTime, float cooldownTime)
		{
			if (!consecutiveUnreachableTargets.ContainsKey(target))
			{
				consecutiveUnreachableTargets[target] = 0;
			}
			if (IsTargetOnCooldown(target, currentUnscaledTime))
			{
				consecutiveUnreachableTargets[target]++;
			}
			consecutiveUnreachableTargets[target] = Math.Min(consecutiveUnreachableTargets[target], 5);
			unreachableTargetCooldown[target] = currentUnscaledTime + cooldownTime * Mathf.Pow(2f, consecutiveUnreachableTargets[target]);
		}

		public void RemoveExpiredCooldownTargets(float currentUnscaledTime)
		{
			using PooledList<IDamageTakingAgent> pooledList = ListPool<IDamageTakingAgent>.GetJanitor();
			foreach (IDamageTakingAgent key in unreachableTargetCooldown.Keys)
			{
				pooledList.Add(key);
			}
			foreach (IDamageTakingAgent item in pooledList)
			{
				if (currentUnscaledTime >= unreachableTargetCooldown[item])
				{
					unreachableTargetCooldown.Remove(item, out var _);
				}
			}
		}

		public Path RecalculateAttackPath(IDamageDealAgent agent)
		{
			Path path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(agent, agent.GetTarget());
			if (path == null)
			{
				return null;
			}
			path.OnCalculationsDoneEvent += delegate(Path path2)
			{
				StoreAttackPoint(agent, null);
				if (!agent.HasDisposed && path.State == PathState.Calculated)
				{
					StoreAttackPoint(agent, path2);
				}
			};
			return path;
		}

		public void AttackPathDestinationReached(IDamageDealAgent agent)
		{
			StoreAttackPoint(agent, null);
		}

		public void AttackPathFailed(IDamageDealAgent agent)
		{
			StoreAttackPoint(agent, null);
		}

		private void StoreAttackPoint(IDamageDealAgent agent, Path path)
		{
		}
	}
}
