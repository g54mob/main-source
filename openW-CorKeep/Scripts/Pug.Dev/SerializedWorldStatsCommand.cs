using System.Collections.Generic;
using System.Linq;
using System.Text;
using QFSW.QC;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

public static class SerializedWorldStatsCommand
{
	[Preserve]
	[Command("serializedWorldStats", "Logs statistics about ObjectDataSerialized occurrences in the serialized worlds.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void LogSerializedWorldStats()
	{
		World serverWorld = Manager.ecs.ServerWorld;
		if (serverWorld == null)
		{
			Manager.menu.quantumConsole.LogToConsole("Must be the server host to inspect serialized world data.");
			return;
		}
		using EntityQuery entityQuery = serverWorld.EntityManager.CreateEntityQuery(typeof(SerializeWorldDataCD));
		if (entityQuery.IsEmpty)
		{
			Manager.menu.quantumConsole.LogToConsole("SerializeWorldDataCD singleton not found. World may not be loaded yet.");
			return;
		}
		EntityManager entityManager = entityQuery.GetSingleton<SerializeWorldDataCD>().entityManager;
		if (entityManager == default(EntityManager))
		{
			Manager.menu.quantumConsole.LogToConsole("Serialized world EntityManager is not initialized yet.");
			return;
		}
		using NativeArray<ArchetypeChunk> nativeArray = entityManager.GetAllChunks();
		ComponentTypeHandle<ObjectDataSerializedCD> componentTypeHandle = entityManager.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
		Dictionary<ObjectID, int> dictionary = new Dictionary<ObjectID, int>();
		int num = 0;
		int num2 = 0;
		foreach (ArchetypeChunk item in nativeArray)
		{
			if (item.Has<ObjectDataSerializedCD>())
			{
				NativeArray<ObjectDataSerializedCD> nativeArray2 = item.GetNativeArray(componentTypeHandle);
				for (int i = 0; i < nativeArray2.Length; i++)
				{
					ObjectID objectID = nativeArray2[i].ObjectID;
					if (dictionary.TryGetValue(objectID, out var value))
					{
						dictionary[objectID] = value + 1;
					}
					else
					{
						dictionary[objectID] = 1;
					}
				}
				num += item.Count;
			}
			else
			{
				num2 += item.Count;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== Serialized World Object Statistics ===");
		stringBuilder.AppendLine($"Total chunks: {nativeArray.Length}");
		stringBuilder.AppendLine($"Entities with ObjectDataSerializedCD: {num}");
		stringBuilder.AppendLine($"Entities without ObjectDataSerializedCD: {num2}");
		stringBuilder.AppendLine($"Unique ObjectIDs: {dictionary.Count}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Object ID counts (sorted by count descending):");
		foreach (KeyValuePair<ObjectID, int> item2 in dictionary.OrderByDescending((KeyValuePair<ObjectID, int> kvp) => kvp.Value))
		{
			stringBuilder.AppendLine($"  {item2.Key} : {item2.Value}");
		}
		Debug.Log(stringBuilder.ToString());
		Manager.menu.quantumConsole.LogToConsole(stringBuilder.ToString());
	}

	[Preserve]
	[Command("serverWorldStats", "Logs statistics about ObjectDataCD occurrences in the server world.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void LogServerWorldStats()
	{
		World serverWorld = Manager.ecs.ServerWorld;
		if (serverWorld == null)
		{
			Manager.menu.quantumConsole.LogToConsole("Must be the server host to inspect server world data.");
		}
		else
		{
			LogWorldObjectDataStats(serverWorld, "Server World");
		}
	}

	[Preserve]
	[Command("clientWorldStats", "Logs statistics about ObjectDataCD occurrences in the client world.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void LogClientWorldStats()
	{
		World clientWorld = Manager.ecs.ClientWorld;
		if (clientWorld == null)
		{
			Manager.menu.quantumConsole.LogToConsole("Client world is not available.");
		}
		else
		{
			LogWorldObjectDataStats(clientWorld, "Client World");
		}
	}

	private static void LogWorldObjectDataStats(World world, string worldName)
	{
		EntityManager entityManager = world.EntityManager;
		using NativeArray<ArchetypeChunk> nativeArray = entityManager.GetAllChunks();
		ComponentTypeHandle<ObjectDataCD> componentTypeHandle = entityManager.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
		Dictionary<ObjectID, int> dictionary = new Dictionary<ObjectID, int>();
		int num = 0;
		int num2 = 0;
		foreach (ArchetypeChunk item in nativeArray)
		{
			if (item.Has<ObjectDataCD>())
			{
				NativeArray<ObjectDataCD> nativeArray2 = item.GetNativeArray(componentTypeHandle);
				for (int i = 0; i < nativeArray2.Length; i++)
				{
					ObjectID objectID = nativeArray2[i].objectID;
					if (dictionary.TryGetValue(objectID, out var value))
					{
						dictionary[objectID] = value + 1;
					}
					else
					{
						dictionary[objectID] = 1;
					}
				}
				num += item.Count;
			}
			else
			{
				num2 += item.Count;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== " + worldName + " Object Statistics ===");
		stringBuilder.AppendLine($"Total chunks: {nativeArray.Length}");
		stringBuilder.AppendLine($"Entities with ObjectDataCD: {num}");
		stringBuilder.AppendLine($"Entities without ObjectDataCD: {num2}");
		stringBuilder.AppendLine($"Unique ObjectIDs: {dictionary.Count}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Object ID counts (sorted by count descending):");
		foreach (KeyValuePair<ObjectID, int> item2 in dictionary.OrderByDescending((KeyValuePair<ObjectID, int> kvp) => kvp.Value))
		{
			stringBuilder.AppendLine($"  {item2.Key} : {item2.Value}");
		}
		Debug.Log(stringBuilder.ToString());
		Manager.menu.quantumConsole.LogToConsole(stringBuilder.ToString());
	}
}
