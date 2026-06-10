using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CreatureManager : MonoSingleton<CreatureManager>
	{
		[NonSerialized]
		private List<CreatureBase> creatures;

		[NonSerialized]
		private Dictionary<int, CreatureBase> creaturesByCreationId;

		[NonSerialized]
		private List<CreatureBase> disposeSchedule;

		[field: NonSerialized]
		public HashSet<CreatureBase> WoundedCreatures { get; private set; }

		public IReadOnlyList<CreatureBase> Creatures => creatures;

		public event Action<CreatureBase, MapNode> CreatureChangedNodeEvent;

		public event Action<CreatureBase> CreatureCreatedEvent;

		public event Action<CreatureBase> CreatureDestroyedEvent;

		public CreatureBase GetByCreationId(int creationId)
		{
			return creaturesByCreationId.GetValueOrDefault(creationId);
		}

		private void OnCreatureAdded(CreatureBase creature)
		{
			if (creatures.Contains(creature))
			{
				return;
			}
			creatures.Add(creature);
			bool isEnabled;
			if (creaturesByCreationId.ContainsKey(creature.UniqueId))
			{
				int uniqueId = creature.UniqueId;
				creature.ResetUniqueId();
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(38, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CreatureManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("UniqueId re-set for animal ");
					messageBuilder.AppendFormatted(creature.ToString());
					messageBuilder.AppendLiteral(", from ");
					messageBuilder.AppendFormatted(uniqueId);
					messageBuilder.AppendLiteral(" to ");
					messageBuilder.AppendFormatted(creature.UniqueId);
				}
				Log.Info(messageBuilder);
			}
			if (creaturesByCreationId.ContainsKey(creature.UniqueId))
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(72, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CreatureManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Skipping adding creature ");
					messageBuilder.AppendFormatted(creature.ToString());
					messageBuilder.AppendLiteral(" (id:");
					messageBuilder.AppendFormatted(creature.UniqueId);
					messageBuilder.AppendLiteral(") to CreatureManager.creaturesByCreationId");
				}
				Log.Info(messageBuilder);
				return;
			}
			creaturesByCreationId.Add(creature.UniqueId, creature);
			creature.OnGridSpaceChangedEvent += OnCreatureNodeChanged;
			MapNode node = creature.GetNode();
			node?.AddCreature(creature);
			node?.ForceRefresh();
			Region region = node?.Region;
			if (region != null)
			{
				RefreshRegionAttributes(region, creature, isAdded: true);
			}
			this.CreatureCreatedEvent?.Invoke(creature);
		}

		private void OnCreatureRemoved(CreatureBase creature)
		{
			if (creatures.Remove(creature))
			{
				creaturesByCreationId.Remove(creature.UniqueId);
				creature.OnGridSpaceChangedEvent -= OnCreatureNodeChanged;
				MapNode node = creature.GetNode();
				node?.RemoveCreature(creature);
				Region region = node?.Region;
				if (region != null)
				{
					RefreshRegionAttributes(region, creature, isAdded: false);
				}
				this.CreatureDestroyedEvent?.Invoke(creature);
			}
		}

		private void OnFainted(StatsInstance stats)
		{
			(stats.Owner as CreatureBase)?.GetNode()?.ForceRefresh();
		}

		private void OnWakeUpAfterFaint(StatsInstance stats)
		{
			(stats.Owner as CreatureBase)?.GetNode()?.ForceRefresh();
		}

		private void OnCreatureNodeChanged(CreatureBase creature, MapNode oldNode, MapNode newNode)
		{
			this.CreatureChangedNodeEvent?.Invoke(creature, oldNode);
			oldNode?.RemoveCreature(creature);
			newNode?.AddCreature(creature);
			Region region = oldNode?.Region;
			Region region2 = newNode?.Region;
			if (region != region2)
			{
				if (region != null)
				{
					RefreshRegionAttributes(region, creature, isAdded: false);
				}
				if (region2 != null)
				{
					RefreshRegionAttributes(region2, creature, isAdded: true);
				}
			}
		}

		private void RefreshRegionAttributes(Region region, CreatureBase creature, bool isAdded)
		{
			if (creature.DamageAgentType == DamageTakingAgentType.NPC && ((HumanoidInstance)creature).IsEnemy())
			{
				ushort num = region.GetAttributeValue(RegionAttribute.Danger);
				if (isAdded)
				{
					num++;
				}
				else if (num > 0)
				{
					num--;
				}
				region.SetAttributeValue(RegionAttribute.Danger, num);
			}
		}

		private void Start()
		{
			creatures = new List<CreatureBase>();
			creaturesByCreationId = new Dictionary<int, CreatureBase>();
			WoundedCreatures = new HashSet<CreatureBase>();
			disposeSchedule = new List<CreatureBase>();
			MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent += OnCreatureAdded;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnCreatureRemoved;
			MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent += OnCreatureAdded;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnCreatureRemoved;
			MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent += OnCreatureAdded;
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnCreatureRemoved;
			MonoSingleton<LifeController>.Instance.OnFaintEvent += OnFainted;
			MonoSingleton<LifeController>.Instance.WakeUpAfterFaintEvent += OnWakeUpAfterFaint;
		}

		protected override void OnDestroy()
		{
			creatures = null;
			creaturesByCreationId = null;
			WoundedCreatures = null;
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent -= OnCreatureAdded;
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnCreatureRemoved;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent -= OnCreatureAdded;
				MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent -= OnCreatureRemoved;
			}
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent -= OnCreatureAdded;
				MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnCreatureRemoved;
			}
			if (MonoSingleton<LifeController>.IsInstantiated())
			{
				MonoSingleton<LifeController>.Instance.OnFaintEvent -= OnFainted;
				MonoSingleton<LifeController>.Instance.WakeUpAfterFaintEvent -= OnWakeUpAfterFaint;
			}
			base.OnDestroy();
			DisposeAllScheduled();
		}

		public void ScheduleDispose(CreatureBase creatureBase)
		{
			if (!disposeSchedule.Contains(creatureBase))
			{
				disposeSchedule.Add(creatureBase);
			}
		}

		private void Update()
		{
			if (!PathPool.IsInitialized)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			if (!(deltaTime > 0f))
			{
				return;
			}
			for (int num = creatures.Count - 1; num >= 0; num--)
			{
				if (num >= creatures.Count)
				{
					num--;
				}
				else
				{
					creatures[num]?.Tick(deltaTime);
				}
			}
		}

		public void LateUpdate()
		{
			DisposeAllScheduled();
		}

		private void DisposeAllScheduled()
		{
			if (MonoSingleton<LoadingController>.IsApplicationIsQuitting())
			{
				return;
			}
			while (disposeSchedule.Count > 0)
			{
				CreatureBase creatureBase = disposeSchedule[0];
				disposeSchedule.RemoveAt(0);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CreatureManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Disposing Creature ");
					messageBuilder.AppendFormatted(creatureBase);
				}
				Log.Info(messageBuilder);
				creatureBase.FinalizeDispose();
			}
		}
	}
}
