using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace PugMod
{
	public class ModAPIServer : IServer
	{
		public World World => Manager.ecs.ServerWorld;

		public bool HasWorldCreatedSubscribers => this.OnWorldCreated != null;

		public bool HasWorldDestroyedSubscribers => this.OnWorldDestroyed != null;

		public bool HasObjectCreatedSubscribers => this.OnObjectCreated != null;

		public bool HasObjectDestroyedSubscribers => this.OnObjectDestroyed != null;

		private PugQuerySystem QuerySystem => World.GetExistingSystemManaged<PugQuerySystem>();

		public event Action OnWorldCreated;

		public event Action OnWorldDestroyed;

		public event IServer.ObjectCreated OnObjectCreated;

		public event IServer.ObjectDestroyed OnObjectDestroyed;

		public void BroadcastMessage<T>(int messageType, Entity entity, int value0, int value1) where T : IMod
		{
			if (World == null)
			{
				Debug.LogError("BroadcastMessage called without server world");
				return;
			}
			throw new NotImplementedException();
		}

		public Entity InstantiateObject(int objectId, int variation, float3 position)
		{
			World world = World;
			if (world == null)
			{
				return Entity.Null;
			}
			if (!world.GetExistingSystemManaged<PugQuerySystem>().TryGetSingleton<PugDatabase.DatabaseBankCD>(out var value))
			{
				return Entity.Null;
			}
			return EntityUtility.CreateEntity(world, position, (ObjectID)objectId, 1, value.databaseBankBlob, variation);
		}

		public Entity DropObject(int objectId, int variation, int amount, float3 position)
		{
			World world = World;
			if (world == null)
			{
				return Entity.Null;
			}
			if (!world.GetExistingSystemManaged<PugQuerySystem>().TryGetSingleton<PugDatabase.DatabaseBankCD>(out var value))
			{
				return Entity.Null;
			}
			ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = (ObjectID)objectId,
					variation = variation,
					amount = amount
				}
			};
			return EntityUtility.DropNewEntity(world, containedObject, position, value.databaseBankBlob);
		}

		public EntityQuery GetEntityQuery(params ComponentType[] componentTypes)
		{
			if (World == null)
			{
				return default(EntityQuery);
			}
			using EntityQueryBuilder builder = new EntityQueryBuilder(Allocator.Temp);
			for (int i = 0; i < componentTypes.Length; i++)
			{
				ComponentType t = componentTypes[i];
				switch (t.AccessModeType)
				{
				case ComponentType.AccessMode.ReadWrite:
				case ComponentType.AccessMode.ReadOnly:
					builder.AddAll(t);
					break;
				case ComponentType.AccessMode.Exclude:
					builder.AddNone(t);
					break;
				}
			}
			return QuerySystem.GetEntityQuery(in builder);
		}

		public void AddMainThreadSystem(SystemBase system)
		{
			World.GetExistingSystemManaged<RunSystemGroup>().AddSystemToUpdateList(system);
		}

		public void AddScheduledSystem(SystemBase system)
		{
			World.GetExistingSystemManaged<SimulationSystemGroup>().AddSystemToUpdateList(system);
		}

		public void WorldCreated()
		{
			this.OnWorldCreated?.Invoke();
		}

		public void WorldDestroyed()
		{
			this.OnWorldDestroyed?.Invoke();
		}

		public void ObjectCreated(Entity entity, EntityManager entityManager)
		{
			this.OnObjectCreated?.Invoke(entity, entityManager);
		}

		public void ObjectDestroyed(Entity entity, EntityManager entityManager)
		{
			this.OnObjectDestroyed?.Invoke(entity, entityManager);
		}
	}
}
