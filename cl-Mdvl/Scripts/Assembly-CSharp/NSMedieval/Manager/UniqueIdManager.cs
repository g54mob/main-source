using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.WorldMap;

namespace NSMedieval.Manager
{
	public class UniqueIdManager : MonoSingleton<UniqueIdManager>
	{
		private Dictionary<UniqueIdType, TrackingUniqueIdProvider> providers;

		private Dictionary<UniqueIdType, List<int>> tempUniqueIds = new Dictionary<UniqueIdType, List<int>>();

		private Dictionary<UniqueIdType, int> tempUniqueId = new Dictionary<UniqueIdType, int>();

		private void Start()
		{
			MonoSingleton<GlobalSaveController>.Instance.OnSaveLoaded += LoadData;
		}

		private void LoadData(VillageSaveData data)
		{
			providers = data.UniqueIdData.Providers;
			MigrateOldIds(data);
			LoadTempIds();
			if (!data.IsSecondMap)
			{
				RemoveDuplicateIdCreatures(data);
			}
		}

		private static void RemoveDuplicateIdCreatures(VillageSaveData data)
		{
			bool isEnabled;
			foreach (AnimalInstance item in data.Animals.Where((AnimalInstance animal) => data.Animals.Any((AnimalInstance animalInstance) => animal != animalInstance && animal.UniqueId == animalInstance.UniqueId) || data.Workers.Any((HumanoidInstance humanoidInstance3) => humanoidInstance3.UniqueId == animal.UniqueId) || data.NPCs.Any((HumanoidInstance humanoidInstance3) => humanoidInstance3.UniqueId == animal.UniqueId)).ToList())
			{
				if (RemoveCreature(item, data.Animals, data))
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(115, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\UniqueIdManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Corrupted save detected, attempting autofix: : removing animal ");
						messageBuilder.AppendFormatted(item);
						messageBuilder.AppendLiteral(" because of an ID conflict with a different creature");
					}
					Log.Error(messageBuilder);
				}
			}
			foreach (HumanoidInstance npc in data.NPCs.Where((HumanoidInstance humanoidInstance3) => data.NPCs.Any((HumanoidInstance humanoidInstance4) => humanoidInstance3 != humanoidInstance4 && humanoidInstance3.UniqueId == humanoidInstance4.UniqueId) || data.Workers.Any((HumanoidInstance humanoidInstance4) => humanoidInstance4.UniqueId == humanoidInstance3.UniqueId)).ToList())
			{
				HumanoidInstance humanoidInstance = data.NPCs.FirstOrDefault((HumanoidInstance npci) => npci != npc && npc.UniqueId == npci.UniqueId);
				if (humanoidInstance == null)
				{
					if (RemoveCreature(npc, data.NPCs, data))
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(99, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\UniqueIdManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Corrupted save detected, attempting autofix: : removed NPC ");
							messageBuilder.AppendFormatted(npc);
							messageBuilder.AppendLiteral(" because of an ID conflict with a worker");
						}
						Log.Error(messageBuilder);
					}
				}
				else if (humanoidInstance.SpawnTime > npc.SpawnTime)
				{
					if (RemoveCreature(humanoidInstance, data.NPCs, data))
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(104, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\UniqueIdManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Corrupted save detected, attempting autofix: : removed NPC ");
							messageBuilder.AppendFormatted(humanoidInstance);
							messageBuilder.AppendLiteral(" because of an ID conflict with another NPC: ");
							messageBuilder.AppendFormatted(npc);
						}
						Log.Error(messageBuilder);
					}
				}
				else if (RemoveCreature(npc, data.NPCs, data))
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(104, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\UniqueIdManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Corrupted save detected, attempting autofix: : removed NPC ");
						messageBuilder.AppendFormatted(npc);
						messageBuilder.AppendLiteral(" because of an ID conflict with another NPC: ");
						messageBuilder.AppendFormatted(humanoidInstance);
					}
					Log.Error(messageBuilder);
				}
			}
			foreach (HumanoidInstance worker in data.Workers.Where((HumanoidInstance humanoidInstance3) => data.Workers.Any((HumanoidInstance humanoidInstance4) => humanoidInstance3 != humanoidInstance4 && humanoidInstance3.UniqueId == humanoidInstance4.UniqueId)).ToList())
			{
				HumanoidInstance humanoidInstance2 = data.Workers.FirstOrDefault((HumanoidInstance workeri) => workeri != worker && worker.UniqueId == workeri.UniqueId);
				if (humanoidInstance2 != null && humanoidInstance2.SpawnTime > worker.SpawnTime)
				{
					if (RemoveCreature(humanoidInstance2, data.Workers, data))
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(111, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\UniqueIdManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Corrupted save detected, attempting autofix: : removing worker ");
							messageBuilder.AppendFormatted(humanoidInstance2);
							messageBuilder.AppendLiteral(" because of an ID conflict with another worker: ");
							messageBuilder.AppendFormatted(worker);
						}
						Log.Error(messageBuilder);
					}
				}
				else if (RemoveCreature(worker, data.Workers, data))
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(111, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\UniqueIdManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Corrupted save detected, attempting autofix: : removing worker ");
						messageBuilder.AppendFormatted(worker);
						messageBuilder.AppendLiteral(" because of an ID conflict with another worker: ");
						messageBuilder.AppendFormatted(humanoidInstance2);
					}
					Log.Error(messageBuilder);
				}
			}
		}

		private static bool RemoveCreature<T>(T creature, ICollection<T> collection, VillageSaveData data) where T : IEventParticipant
		{
			if (!collection.Remove(creature))
			{
				return false;
			}
			if (data.PlayerTriggeredEventSaveData.GetRunningEvent(out var playerTriggeredEventInstance) && playerTriggeredEventInstance.HasParticipant(creature))
			{
				data.PlayerTriggeredEventSaveData.RemoveRunningEvent(playerTriggeredEventInstance, data.DateAndTime.HoursTotal);
			}
			return true;
		}

		private void MigrateOldIds(VillageSaveData data)
		{
			if (!providers.ContainsKey(UniqueIdType.WorldObject))
			{
				providers.Add(UniqueIdType.WorldObject, new TrackingUniqueIdProvider());
				foreach (WorldObject worldObject in data.PlayerVillage.WorldObjectStorage.WorldObjects)
				{
					if (worldObject.GetUniqueId() != 0)
					{
						providers[UniqueIdType.WorldObject].AddUsedId(worldObject.GetUniqueId());
					}
				}
			}
			if (providers.ContainsKey(UniqueIdType.Creature))
			{
				return;
			}
			providers.Add(UniqueIdType.Creature, new TrackingUniqueIdProvider());
			foreach (HumanoidInstance worker in data.Workers)
			{
				if (worker.GetUniqueId() != 0)
				{
					providers[UniqueIdType.Creature].AddUsedId(worker.GetUniqueId());
				}
			}
			foreach (AnimalInstance animal in data.Animals)
			{
				if (animal.GetUniqueId() != 0)
				{
					providers[UniqueIdType.Creature].AddUsedId(animal.GetUniqueId());
				}
			}
			foreach (HumanoidInstance nPC in data.NPCs)
			{
				if (nPC.GetUniqueId() != 0)
				{
					providers[UniqueIdType.Creature].AddUsedId(nPC.GetUniqueId());
				}
			}
			foreach (CaravanInstance caravan in data.WorldMapData.Caravans)
			{
				foreach (HumanoidInstance worker2 in caravan.Workers)
				{
					if (worker2.GetUniqueId() != 0)
					{
						providers[UniqueIdType.Creature].AddUsedId(worker2.GetUniqueId());
					}
				}
				foreach (CreatureBase creature in caravan.Creatures)
				{
					if (creature.GetUniqueId() != 0)
					{
						providers[UniqueIdType.Creature].AddUsedId(creature.GetUniqueId());
					}
				}
			}
		}

		private void LoadTempIds()
		{
			if (tempUniqueIds.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<UniqueIdType, List<int>> tempUniqueId in tempUniqueIds)
			{
				foreach (int item in tempUniqueId.Value)
				{
					providers[tempUniqueId.Key].AddUsedId(item);
				}
			}
			tempUniqueIds.Clear();
			this.tempUniqueId.Clear();
		}

		public void ClearData()
		{
			tempUniqueIds.Clear();
			tempUniqueId.Clear();
			providers = null;
		}

		public int GetUniqueId(UniqueIdType type)
		{
			if (providers == null)
			{
				tempUniqueId.TryAdd(type, 0);
				tempUniqueId[type]--;
				if (!tempUniqueIds.ContainsKey(type))
				{
					tempUniqueIds.Add(type, new List<int>());
				}
				tempUniqueIds[type].Add(tempUniqueId[type]);
				return tempUniqueId[type];
			}
			if (!providers.ContainsKey(type))
			{
				providers.Add(type, new TrackingUniqueIdProvider());
			}
			return providers[type].GetUniqueId();
		}

		public void ReleaseUniqueId(UniqueIdType type, int id)
		{
			if (id != 0)
			{
				if (!providers.ContainsKey(type))
				{
					throw new Exception("Unique Id for " + type.ToString() + " doesn't exist");
				}
				providers[type].ReleaseId(id);
			}
		}
	}
}
