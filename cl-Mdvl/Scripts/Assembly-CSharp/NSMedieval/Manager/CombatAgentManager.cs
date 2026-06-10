using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Manager
{
	public class CombatAgentManager : MonoSingleton<CombatAgentManager>
	{
		private HashSet<IDamageCommonAgent> allCombatAgents = new HashSet<IDamageCommonAgent>();

		private HashSet<IDamageTakingAgent> damageTakingAgents = new HashSet<IDamageTakingAgent>();

		private HashSet<IDamageDealAgent> damageDealingAgents = new HashSet<IDamageDealAgent>();

		private readonly object damageTakingAgentsSetLock = new object();

		private readonly object damageDealingAgentsSetLock = new object();

		public IEnumerable<IDamageDealAgent> DamageDealingAgents
		{
			get
			{
				lock (damageDealingAgentsSetLock)
				{
					foreach (IDamageDealAgent damageDealingAgent in damageDealingAgents)
					{
						yield return damageDealingAgent;
					}
				}
			}
		}

		public bool RegisterCommonCombatAgent(IDamageCommonAgent agent)
		{
			if (!allCombatAgents.Add(agent))
			{
				return false;
			}
			if (agent is IDamageTakingAgent item)
			{
				lock (damageTakingAgentsSetLock)
				{
					damageTakingAgents.Add(item);
				}
			}
			if (agent is IDamageDealAgent item2)
			{
				lock (damageDealingAgentsSetLock)
				{
					damageDealingAgents.Add(item2);
				}
			}
			MonoSingleton<CombatController>.Instance.OnDamageAgentRegister(agent);
			return true;
		}

		public bool RemoveCommonCombatAgent(IDamageCommonAgent agent)
		{
			if (LoadingController.IsSceneTransition)
			{
				return false;
			}
			if (!allCombatAgents.Remove(agent))
			{
				return false;
			}
			if (agent is IDamageTakingAgent agent2)
			{
				RemoveDamageTakingAgent(agent2);
			}
			if (agent is IDamageDealAgent agent3)
			{
				RemoveDamageDealingAgent(agent3);
			}
			MonoSingleton<CombatController>.Instance.OnDamageAgentRemove(agent);
			return true;
		}

		public List<IDamageTakingAgent> DamageTakingAgentsSafeForEach(DamageTakingAgentType type, Func<IDamageTakingAgent, bool> filter = null)
		{
			lock (damageTakingAgentsSetLock)
			{
				if (type == DamageTakingAgentType.All && filter == null)
				{
					return new List<IDamageTakingAgent>(damageTakingAgents);
				}
				return damageTakingAgents.Where((IDamageTakingAgent agent) => (agent.DamageAgentType & type) != DamageTakingAgentType.None && (filter == null || filter(agent))).ToList();
			}
		}

		public List<IDamageDealAgent> GetDamageDealAgentsSafe(Func<IDamageDealAgent, bool> filter = null)
		{
			lock (damageDealingAgentsSetLock)
			{
				return (filter == null) ? new List<IDamageDealAgent>(damageDealingAgents) : damageDealingAgents.Where(filter.Invoke).ToList();
			}
		}

		public void DamageDealAgentSafeForEach(Action<IDamageDealAgent> operation)
		{
			lock (damageDealingAgentsSetLock)
			{
				foreach (IDamageDealAgent damageDealingAgent in damageDealingAgents)
				{
					operation(damageDealingAgent);
				}
			}
		}

		public void DamageDealAgentSafeForEach(Func<IDamageDealAgent, bool> operation)
		{
			lock (damageDealingAgentsSetLock)
			{
				foreach (IDamageDealAgent damageDealingAgent in damageDealingAgents)
				{
					if (!operation(damageDealingAgent))
					{
						break;
					}
				}
			}
		}

		public void DamageTakingAgentsSafeForEach(Func<IDamageTakingAgent, bool> operation)
		{
			lock (damageDealingAgentsSetLock)
			{
				foreach (IDamageTakingAgent damageTakingAgent in damageTakingAgents)
				{
					if (!operation(damageTakingAgent))
					{
						break;
					}
				}
			}
		}

		private bool RemoveDamageTakingAgent(IDamageTakingAgent agent)
		{
			lock (damageTakingAgentsSetLock)
			{
				if (!damageTakingAgents.Remove(agent))
				{
					return false;
				}
			}
			return true;
		}

		private bool RemoveDamageDealingAgent(IDamageDealAgent agent)
		{
			lock (damageDealingAgentsSetLock)
			{
				if (!damageDealingAgents.Remove(agent))
				{
					return false;
				}
			}
			return true;
		}

		private void OnAgentDied(IDamageCommonAgent agent)
		{
			RemoveCommonCombatAgent(agent);
		}

		private void OnAgentDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (!CombatUtils.IsAlive(take))
			{
				return;
			}
			List<DamageTakingAgentSettings> settings = Repository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>.Instance.GetSettings(take.DamageAgentType);
			if (settings.Count == 0)
			{
				return;
			}
			if (take is CreatureBase)
			{
				foreach (DamageTakingAgentSettings item in settings)
				{
					if (item.OnDamageTakenEffectors != null)
					{
						string[] onDamageTakenEffectors = item.OnDamageTakenEffectors;
						foreach (string effectorId in onDamageTakenEffectors)
						{
							take.Stats.StartEffector(effectorId);
						}
					}
				}
			}
			MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(take as IGoapAgentOwner, "TakeDamage");
		}

		private void OnTrapDamageTaken(TrapComponentInstance trapComponentInstance, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (!CombatUtils.IsAlive(take))
			{
				return;
			}
			List<DamageTakingAgentSettings> settings = Repository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>.Instance.GetSettings(take.DamageAgentType);
			if (settings.Count == 0)
			{
				return;
			}
			foreach (DamageTakingAgentSettings item in settings)
			{
				if (item?.OnDamageTakenEffectors == null)
				{
					continue;
				}
				string[] array = item?.OnDamageTakenEffectors;
				foreach (string text in array)
				{
					if (!string.IsNullOrEmpty(text) && take.Stats != null)
					{
						take.Stats.StartEffector(text);
					}
				}
			}
			MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(take as IGoapAgentOwner, "TakeDamage");
		}

		private void OnAgentDamageTaken(IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (!CombatUtils.IsAlive(take))
			{
				return;
			}
			List<DamageTakingAgentSettings> settings = Repository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>.Instance.GetSettings(take.DamageAgentType);
			if (settings.Count == 0)
			{
				return;
			}
			foreach (DamageTakingAgentSettings item in settings)
			{
				if (item?.OnDamageTakenEffectors == null)
				{
					continue;
				}
				string[] array = item?.OnDamageTakenEffectors;
				foreach (string text in array)
				{
					if (!string.IsNullOrEmpty(text) && take.Stats != null)
					{
						take.Stats.StartEffector(text);
					}
				}
			}
			MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(take as IGoapAgentOwner, "TakeDamage");
		}

		private void Start()
		{
			MonoSingleton<CombatController>.Instance.AgentDiedEvent += OnAgentDied;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnAgentDamageTaken;
			MonoSingleton<CombatController>.Instance.TrapDamageTakenEvent += OnTrapDamageTaken;
			MonoSingleton<CombatController>.Instance.GateDamageTakenEvent += OnAgentDamageTaken;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			allCombatAgents.Clear();
			allCombatAgents = null;
			lock (damageDealingAgentsSetLock)
			{
				damageDealingAgents.Clear();
				damageDealingAgents = null;
			}
			lock (damageTakingAgentsSetLock)
			{
				damageTakingAgents.Clear();
				damageTakingAgents = null;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.AgentDiedEvent -= OnAgentDied;
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnAgentDamageTaken;
				MonoSingleton<CombatController>.Instance.TrapDamageTakenEvent -= OnTrapDamageTaken;
				MonoSingleton<CombatController>.Instance.GateDamageTakenEvent -= OnAgentDamageTaken;
			}
		}
	}
}
