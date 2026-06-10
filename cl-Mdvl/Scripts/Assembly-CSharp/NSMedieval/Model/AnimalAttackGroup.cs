using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AnimalAttackGroup : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<AnimalAttackGroupEntry> entries;

		private bool initFriendlyFactionEntry;

		private bool initEnemyEntry;

		private bool initWorkerEntry;

		private AnimalAttackGroupEntry workerEntry;

		private AnimalAttackGroupEntry enemyEntry;

		private AnimalAttackGroupEntry friendlyFactionEntry;

		private readonly Dictionary<AnimalType, Dictionary<Animal, bool>> canTargetCache = new Dictionary<AnimalType, Dictionary<Animal, bool>>();

		private readonly Dictionary<AnimalType, Dictionary<Animal, AnimalAttackGroupEntry>> entriesCache = new Dictionary<AnimalType, Dictionary<Animal, AnimalAttackGroupEntry>>();

		public bool CanAttackWorker => GetWorkerEntry() != null;

		public IEnumerable<AnimalAttackGroupEntry> Entries => entries;

		private bool CanAttackFriendlyFaction => GetFriendlyFactionEntry() != null;

		private bool CanAttackEnemy => GetEnemyEntry() != null;

		public override string GetID()
		{
			return id;
		}

		public bool CanTarget(CreatureBase creature)
		{
			if (creature is HumanoidInstance { WorkerBehaviour: not null })
			{
				return CanAttackWorker;
			}
			if (creature is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsNpc())
			{
				return CanTarget(humanoidInstance2);
			}
			return CanTarget((AnimalInstance)creature);
		}

		public float GetPriority(CreatureBase creature, CreatureBase target, out bool success)
		{
			AnimalAttackGroupEntry groupEntry = GetGroupEntry(target);
			if (groupEntry == null)
			{
				success = false;
				return 0f;
			}
			success = true;
			return (float)groupEntry.Priority + groupEntry.PriorityPerDistanceUnit * Vec3Int.Distance(creature.GetGridPosition(), target.GetGridPosition());
		}

		private bool CanTarget(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance == null)
			{
				return false;
			}
			if (humanoidInstance.IsFriendlyFaction())
			{
				return CanAttackFriendlyFaction;
			}
			return CanAttackEnemy;
		}

		private bool CanTarget(AnimalInstance animalInstance)
		{
			if (animalInstance == null)
			{
				return false;
			}
			return CanTarget(animalInstance.AnimalType, animalInstance.Blueprint);
		}

		private bool CanTarget(AnimalType animalType, Animal blueprint)
		{
			if (!canTargetCache.ContainsKey(animalType))
			{
				canTargetCache.Add(animalType, new Dictionary<Animal, bool>());
			}
			if (!canTargetCache[animalType].ContainsKey(blueprint))
			{
				bool flag = entries.Any((AnimalAttackGroupEntry entry) => entry.CanTargetAnimal(animalType, blueprint));
				canTargetCache[animalType].Add(blueprint, flag);
				return flag;
			}
			return canTargetCache[animalType][blueprint];
		}

		private AnimalAttackGroupEntry GetGroupEntry(CreatureBase creatureBase)
		{
			if (creatureBase.GetType() == typeof(AnimalInstance))
			{
				AnimalInstance animalInstance = (AnimalInstance)creatureBase;
				return GetGroupEntry(animalInstance.AnimalType, animalInstance.Blueprint);
			}
			if (creatureBase.GetType() == typeof(HumanoidInstance))
			{
				return GetWorkerEntry();
			}
			if (creatureBase.GetType() == typeof(HumanoidInstance))
			{
				if (((HumanoidInstance)creatureBase).IsFriendlyFaction())
				{
					return GetFriendlyFactionEntry();
				}
				return GetEnemyEntry();
			}
			return null;
		}

		private AnimalAttackGroupEntry GetWorkerEntry()
		{
			if (!initWorkerEntry)
			{
				initWorkerEntry = true;
				workerEntry = entries.FirstOrDefault((AnimalAttackGroupEntry entry) => entry.Type == AnimalAttackGroupEntryType.Workers);
			}
			return workerEntry;
		}

		private AnimalAttackGroupEntry GetFriendlyFactionEntry()
		{
			if (!initFriendlyFactionEntry)
			{
				initFriendlyFactionEntry = true;
				friendlyFactionEntry = entries.FirstOrDefault((AnimalAttackGroupEntry entry) => entry.Type == AnimalAttackGroupEntryType.FriendlyFaction);
			}
			return friendlyFactionEntry;
		}

		private AnimalAttackGroupEntry GetEnemyEntry()
		{
			if (!initEnemyEntry)
			{
				initEnemyEntry = true;
				enemyEntry = entries.FirstOrDefault((AnimalAttackGroupEntry entry) => entry.Type == AnimalAttackGroupEntryType.Enemies);
			}
			return enemyEntry;
		}

		private AnimalAttackGroupEntry GetGroupEntry(AnimalType animalType, Animal blueprint)
		{
			if (!entriesCache.ContainsKey(animalType))
			{
				entriesCache.Add(animalType, new Dictionary<Animal, AnimalAttackGroupEntry>());
			}
			if (!entriesCache[animalType].ContainsKey(blueprint))
			{
				AnimalAttackGroupEntry animalAttackGroupEntry = entries.FirstOrDefault((AnimalAttackGroupEntry entry) => entry.CanTargetAnimal(animalType, blueprint));
				entriesCache[animalType].Add(blueprint, animalAttackGroupEntry);
				return animalAttackGroupEntry;
			}
			return entriesCache[animalType][blueprint];
		}
	}
}
