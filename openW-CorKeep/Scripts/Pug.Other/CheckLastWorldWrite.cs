using System;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

public class CheckLastWorldWrite : MonoBehaviour
{
	private const double warningEveryNMinutes = 10.0;

	private SerializeWorldSystem serializeWorldSystem;

	private bool warningIsActive;

	private DateTime lastWarning;

	private DateTime lastPause;

	private void Start()
	{
		lastWarning = DateTime.Now;
		lastPause = DateTime.Now;
	}

	private void Update()
	{
		if (Manager.ecs.ServerWorld == null)
		{
			return;
		}
		if (serializeWorldSystem == null)
		{
			serializeWorldSystem = Manager.ecs.ServerWorld.GetExistingSystemManaged<SerializeWorldSystem>();
		}
		if (serializeWorldSystem == null)
		{
			return;
		}
		if (Time.timeScale == 0f)
		{
			lastPause = DateTime.Now;
			return;
		}
		DateTime now = DateTime.Now;
		if (!warningIsActive && (now - lastPause).TotalMinutes < 10.0)
		{
			return;
		}
		double num = math.max((now - Manager.filesystemManager.LastWrite).TotalMinutes, (now - serializeWorldSystem.LastWorldWrite).TotalMinutes);
		if (num >= 10.0)
		{
			if (!warningIsActive || (now - lastWarning).TotalMinutes >= 10.0)
			{
				Debug.LogWarning($"no world write lastRequest={serializeWorldSystem.LastWorldWrite} lastCompletedWrite={Manager.filesystemManager.LastWrite}");
				string message = $"Error/NoWorldWriteWarning\t{(int)math.floor(num)}";
				SendRPC(message, Manager.ecs.ServerWorld);
				lastWarning = DateTime.Now;
				warningIsActive = true;
			}
		}
		else if (warningIsActive)
		{
			warningIsActive = false;
			string message2 = "Error/NoWorldWriteWarningEnd";
			SendRPC(message2, Manager.ecs.ServerWorld);
		}
	}

	private unsafe void SendRPC(string message, World world)
	{
		using (EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(NetworkStreamInGame)))
		{
			if (entityQuery.IsEmpty)
			{
				Debug.Log("not sending autosave warning since no connections");
				return;
			}
		}
		EntityArchetype archetype = world.EntityManager.CreateArchetype(typeof(NetworkCommMessageRPC));
		EntityArchetype archetype2 = world.EntityManager.CreateArchetype(typeof(NetworkCommDataMessageRPC));
		NetworkCommMessageRPC componentData = new NetworkCommMessageRPC
		{
			messageNumber = UnityEngine.Random.Range(int.MinValue, 0),
			messageType = NetworkCommMessageType.System
		};
		NetworkCommDataMessageRPC componentData2 = default(NetworkCommDataMessageRPC);
		byte[] bytes = Encoding.UTF8.GetBytes(message);
		int num = bytes.Length;
		int entityCount = (num - 1) / componentData2.messagePart.Size + 1;
		componentData.totalSize = num;
		Entity entity = world.EntityManager.CreateEntity(archetype);
		world.EntityManager.SetComponentData(entity, componentData);
		using NativeArray<Entity> nativeArray = world.EntityManager.CreateEntity(archetype2, entityCount, Allocator.Temp);
		componentData2.messageNumber = componentData.messageNumber;
		fixed (byte* ptr = bytes)
		{
			int num2 = num;
			for (ushort num3 = 0; num3 < nativeArray.Length; num3++)
			{
				componentData2.startByte = num3 * componentData2.messagePart.Size;
				UnsafeUtility.MemCpy(componentData2.messagePart.GetUnsafePtr(), ptr + componentData2.startByte, math.min(componentData2.messagePart.Size, num2));
				world.EntityManager.SetComponentData(nativeArray[num3], componentData2);
				num2 -= componentData2.messagePart.Size;
			}
		}
	}
}
