using System;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public interface IClient
	{
		public delegate void ObjectSpawnedOnClient(Entity entity, EntityManager entityManager, GameObject graphicalObject);

		public delegate void ObjectDespawnedOnClient(Entity entity, EntityManager entityManager, GameObject graphicalObject);

		World World { get; }

		GameObject LocalPlayer { get; }

		event Action OnWorldCreated;

		event Action OnWorldDestroyed;

		event ObjectSpawnedOnClient OnObjectSpawnedOnClient;

		event ObjectDespawnedOnClient OnObjectDespawnedOnClient;

		GameObject GetGraphicalGameObject(Entity entity);

		Entity GetEntity(GameObject graphicalGameObject);

		EntityQuery GetEntityQuery(params ComponentType[] componentTypes);

		void AddMainThreadSystem(SystemBase system);

		void AddScheduledSystem(SystemBase system);
	}
}
