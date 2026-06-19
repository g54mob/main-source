using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class CustomBootstrap : ClientServerBootstrap
{
	[Preserve]
	public override bool Initialize(string defaultWorldName)
	{
		World.DefaultGameObjectInjectionWorld = ClientServerBootstrap.CreateLocalWorld("Default World");
		if (World.DefaultGameObjectInjectionWorld == null)
		{
			Debug.LogError("Failed to load default world");
			return false;
		}
		List<Type> list = new List<Type>();
		list.Add(typeof(GhostComponentSerializerCollectionSystemGroup));
		list.Add(typeof(GhostCollectionSystem));
		list.Add(typeof(GhostSimulationSystemGroup));
		list.Add(typeof(NetDebugSystem));
		foreach (Type system in TypeManager.GetSystems())
		{
			if (typeof(IGhostComponentSerializerRegistration).IsAssignableFrom(system) || system.IsSubclassOf(typeof(DefaultVariantSystemBase)))
			{
				list.Add(system);
			}
		}
		list.Add(typeof(DefaultVariantSystemGroup));
		TypeManager.SortSystemTypesInCreationOrder(list);
		DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(World.DefaultGameObjectInjectionWorld, list);
		TransformSystemGroup existingSystemManaged = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<TransformSystemGroup>();
		World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<SimulationSystemGroup>().RemoveSystemFromUpdateList(existingSystemManaged);
		PhysicsSystemGroup existingSystemManaged2 = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PhysicsSystemGroup>();
		World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<FixedStepSimulationSystemGroup>().RemoveSystemFromUpdateList(existingSystemManaged2);
		return true;
	}
}
