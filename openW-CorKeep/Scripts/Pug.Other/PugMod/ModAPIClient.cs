using System;
using Pug.ECS.Hybrid;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public class ModAPIClient : IClient
	{
		public World World => Manager.ecs.ClientWorld;

		public GameObject LocalPlayer => Manager.main.player?.gameObject;

		public bool HasObjectSpawnedOnClientSubscribers => this.OnObjectSpawnedOnClient != null;

		public bool HasObjectDepawnedOnClientSubscribers => this.OnObjectDespawnedOnClient != null;

		private PugQuerySystem QuerySystem => World.GetExistingSystemManaged<PugQuerySystem>();

		public event Action OnWorldCreated;

		public event Action OnWorldDestroyed;

		public event IClient.ObjectSpawnedOnClient OnObjectSpawnedOnClient;

		public event IClient.ObjectDespawnedOnClient OnObjectDespawnedOnClient;

		public GameObject GetGraphicalGameObject(Entity entity)
		{
			if (Manager.memory.entityMonoLookUp.TryGetValue(entity, out var value))
			{
				return value.gameObject;
			}
			CreateGraphicalObjectSystem existingSystemManaged = World.GetExistingSystemManaged<CreateGraphicalObjectSystem>();
			if (existingSystemManaged == null)
			{
				return null;
			}
			if (existingSystemManaged.GameObjectLookup.TryGetValue(entity, out var value2))
			{
				return value2;
			}
			return null;
		}

		public Entity GetEntity(GameObject graphicalGameObject)
		{
			EntityMonoBehaviour component = graphicalGameObject.GetComponent<EntityMonoBehaviour>();
			if (component != null)
			{
				return component.entity;
			}
			CreateGraphicalObjectSystem existingSystemManaged = World.GetExistingSystemManaged<CreateGraphicalObjectSystem>();
			if (existingSystemManaged == null)
			{
				return Entity.Null;
			}
			if (existingSystemManaged.EntityLookup.TryGetValue(graphicalGameObject, out var value))
			{
				return value;
			}
			return Entity.Null;
		}

		public void SendMessage<T>(int messageType, Entity entity, int value0, int value1) where T : IMod
		{
			if (World == null)
			{
				Debug.LogError("SendMessage called without client world");
				return;
			}
			throw new NotImplementedException();
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

		public void ObjectSpawnedOnClient(Entity entity, EntityManager entityManager, GameObject graphicalObject)
		{
			this.OnObjectSpawnedOnClient?.Invoke(entity, entityManager, graphicalObject);
		}

		public void ObjectDespawnedOnClient(Entity entity, EntityManager entityManager, GameObject graphicalObject)
		{
			this.OnObjectDespawnedOnClient?.Invoke(entity, entityManager, graphicalObject);
		}
	}
}
