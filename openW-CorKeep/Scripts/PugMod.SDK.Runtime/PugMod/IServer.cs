using System;
using Unity.Entities;
using Unity.Mathematics;

namespace PugMod
{
	public interface IServer
	{
		public delegate void ObjectCreated(Entity entity, EntityManager entityManager);

		public delegate void ObjectDestroyed(Entity entity, EntityManager entityManager);

		World World { get; }

		event Action OnWorldCreated;

		event Action OnWorldDestroyed;

		event ObjectCreated OnObjectCreated;

		event ObjectDestroyed OnObjectDestroyed;

		Entity InstantiateObject(int objectId, int variation, float3 position);

		Entity DropObject(int objectId, int variation, int amount, float3 position);

		EntityQuery GetEntityQuery(params ComponentType[] componentTypes);

		void AddMainThreadSystem(SystemBase system);

		void AddScheduledSystem(SystemBase system);
	}
}
