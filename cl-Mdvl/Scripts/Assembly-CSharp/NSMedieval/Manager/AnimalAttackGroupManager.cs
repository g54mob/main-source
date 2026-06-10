using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class AnimalAttackGroupManager : MonoSingleton<AnimalAttackGroupManager>
	{
		private readonly Dictionary<AnimalAttackGroup, HashSet<CreatureBase>> agentsByGroup = new Dictionary<AnimalAttackGroup, HashSet<CreatureBase>>();

		private WorldDate dateTime;

		private void Start()
		{
			foreach (AnimalAttackGroup allItem in Repository<AnimalAttackGroupRepository, AnimalAttackGroup>.Instance.GetAllItems())
			{
				agentsByGroup.Add(allItem, new HashSet<CreatureBase>());
			}
			dateTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent += OnSpawnAgent;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnRemovedAgent;
			MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent += OnSpawnAgent;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnRemovedAgent;
			MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent += OnSpawnAgent;
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnRemovedAgent;
			CaravanController caravanController = MonoSingleton<CaravanController>.Instance;
			caravanController.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Combine(caravanController.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanStarted));
			CaravanController caravanController2 = MonoSingleton<CaravanController>.Instance;
			caravanController2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Combine(caravanController2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanEnded));
			MonoSingleton<CombatController>.Instance.OnAgentKilledEvent += OnAgentKilled;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent -= OnSpawnAgent;
				MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnRemovedAgent;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent -= OnSpawnAgent;
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnRemovedAgent;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent -= OnSpawnAgent;
				MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= OnRemovedAgent;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController caravanController = MonoSingleton<CaravanController>.Instance;
				caravanController.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Remove(caravanController.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanStarted));
				CaravanController caravanController2 = MonoSingleton<CaravanController>.Instance;
				caravanController2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Remove(caravanController2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanEnded));
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.OnAgentKilledEvent -= OnAgentKilled;
			}
			base.OnDestroy();
		}

		private bool IsTargetCreatureValid(CreatureBase creature)
		{
			if (creature.HasDisposed || creature.HasDied)
			{
				return false;
			}
			if (creature is AnimalInstance animalInstance)
			{
				if (animalInstance.AnimalType == AnimalType.DomesticNpc)
				{
					return false;
				}
				if (animalInstance.RopedTo() != null)
				{
					return false;
				}
				if (animalInstance.PredatorCannotTargetUntil > 0 && dateTime != null && dateTime.MinutesTotal < animalInstance.PredatorCannotTargetUntil)
				{
					return false;
				}
				if (animalInstance.IsProtectorInProximity())
				{
					return false;
				}
			}
			return true;
		}

		public bool AnyReachableAgentsOnMap(CreatureBase creature, AnimalAttackGroup group)
		{
			if (CombatUtils.IsNullOrDisposed(creature) || creature?.PathTraversalProvider == null || !agentsByGroup.ContainsKey(group) || agentsByGroup[group] == null)
			{
				return false;
			}
			PathTraversalProvider pathTraversalProvider = creature.PathTraversalProvider;
			MapNode node = creature.GetNode();
			VillageMap map = creature.Map;
			foreach (CreatureBase item in agentsByGroup[group])
			{
				if (!CombatUtils.IsNullOrDisposed(item) && item != creature && IsTargetCreatureValid(item) && PathfinderUtil.IsAreaReachable(pathTraversalProvider, map, node.Area, item.GetNode().Area))
				{
					return true;
				}
			}
			return false;
		}

		public CreatureBase PickAgentFromMap(CreatureBase creature, AnimalAttackGroup group, Dictionary<CreatureBase, float> creaturesByPriority = null)
		{
			if (CombatUtils.IsNullOrDisposed(creature) || creature?.PathTraversalProvider == null || !agentsByGroup.ContainsKey(group) || agentsByGroup[group] == null)
			{
				return null;
			}
			PathTraversalProvider pathTraversalProvider = creature.PathTraversalProvider;
			MapNode node = creature.GetNode();
			VillageMap map = creature.Map;
			float num = 0f;
			CreatureBase creatureBase = null;
			foreach (CreatureBase item in agentsByGroup[group])
			{
				if (CombatUtils.IsNullOrDisposed(item) || item == creature || !IsTargetCreatureValid(item) || !PathfinderUtil.IsAreaReachable(pathTraversalProvider, map, node.Area, item.GetNode().Area))
				{
					continue;
				}
				bool success;
				float priority = group.GetPriority(creature, item, out success);
				if (success)
				{
					if (creaturesByPriority != null && !creaturesByPriority.ContainsKey(item))
					{
						creaturesByPriority.Add(item, priority);
					}
					if (creatureBase == null || priority < num)
					{
						num = priority;
						creatureBase = item;
					}
				}
			}
			return creatureBase;
		}

		private void OnSpawnAgent(CreatureBase agent)
		{
			AddAgent(agent);
		}

		private void OnRemovedAgent(CreatureBase agent)
		{
			RemoveAgent(agent);
		}

		private void OnCaravanEnded(CaravanInstance caravanInstance)
		{
			if (caravanInstance == null)
			{
				return;
			}
			if (caravanInstance.Creatures != null)
			{
				foreach (CreatureBase creature in caravanInstance.Creatures)
				{
					if (creature != null && !creature.HasDied && !creature.HasDisposed)
					{
						AddAgent(creature);
					}
				}
			}
			if (caravanInstance.Workers == null)
			{
				return;
			}
			foreach (HumanoidInstance worker in caravanInstance.Workers)
			{
				if (worker != null && !worker.HasDied && !worker.HasDisposed)
				{
					AddAgent(worker);
				}
			}
		}

		private void OnCaravanStarted(CaravanInstance caravanInstance)
		{
			if (caravanInstance == null)
			{
				return;
			}
			if (caravanInstance.Creatures != null)
			{
				foreach (CreatureBase creature in caravanInstance.Creatures)
				{
					if (creature is AnimalInstance agent)
					{
						RemoveAgent(agent);
					}
				}
			}
			if (caravanInstance.Workers == null)
			{
				return;
			}
			foreach (HumanoidInstance worker in caravanInstance.Workers)
			{
				if (worker != null)
				{
					RemoveAgent(worker);
				}
			}
		}

		private void AddAgent(CreatureBase agent)
		{
			if (agent == null || agent.HasDied || agent.HasDisposed)
			{
				return;
			}
			foreach (AnimalAttackGroup key in agentsByGroup.Keys)
			{
				if (!agentsByGroup[key].Contains(agent) && key.CanTarget(agent))
				{
					agentsByGroup[key].Add(agent);
				}
			}
		}

		private void RemoveAgent(CreatureBase agent)
		{
			if (agent == null)
			{
				return;
			}
			foreach (AnimalAttackGroup key in agentsByGroup.Keys)
			{
				if (agentsByGroup[key].Contains(agent) && key.CanTarget(agent))
				{
					agentsByGroup[key].Remove(agent);
				}
			}
		}

		private static void OnAgentKilled(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (deal is AnimalInstance animalInstance && animalInstance.Blueprint.FirePestControlEndEffectorChance > 0.0 && (double)UnityEngine.Random.value <= animalInstance.Blueprint.FirePestControlEndEffectorChance)
			{
				float durationModifier = animalInstance.Blueprint.PestControlEndEffectorDuration.Random();
				string pestControlEndEffectorName = animalInstance.Blueprint.PestControlEndEffectorName;
				animalInstance.Stats.StartEffector(pestControlEndEffectorName, durationModifier);
			}
		}
	}
}
