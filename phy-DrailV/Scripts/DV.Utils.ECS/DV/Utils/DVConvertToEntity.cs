using System;
using Unity.Entities;
using UnityEngine;

namespace DV.Utils
{
	[DisallowMultipleComponent]
	public class DVConvertToEntity : MonoBehaviour
	{
		private static DVConvertToEntitySystem convertSystem;

		private EntityArchetype startingArchetype;

		public static DVConvertToEntitySystem ConvertSystem => convertSystem;

		public EntityManager EntityManager { get; private set; }

		public Entity Entity { get; private set; }

		public bool IsConverted { get; private set; }

		public bool DisableAutoEnableDisable { get; set; }

		public event Action<EntityManager, Entity> OnConverted;

		public event Action<EntityCommandBuffer, Entity> OnEnabled;

		public event Action<EntityCommandBuffer, Entity> OnDisabled;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void StaticInit()
		{
			DVWorldBootstrap.WorldInitialized -= OnWorldInitialized;
			DVWorldBootstrap.WorldInitialized += OnWorldInitialized;
		}

		private static void OnWorldInitialized(World world)
		{
			DVWorldBootstrap.WorldInitialized -= OnWorldInitialized;
			convertSystem = world.GetOrCreateSystem<DVConvertToEntitySystem>();
		}

		public void Initialize(EntityArchetype archetype)
		{
			startingArchetype = archetype;
			convertSystem.AddObjectToConvert(this, archetype);
		}

		private void OnEnable()
		{
			if (IsConverted && !DisableAutoEnableDisable)
			{
				convertSystem.QueueOperation(this, DVConvertToEntitySystem.Operation.Type.Enable);
			}
		}

		private void OnDisable()
		{
			if (IsConverted && !DisableAutoEnableDisable && !UnloadWatcher.isQuitting)
			{
				convertSystem.QueueOperation(this, DVConvertToEntitySystem.Operation.Type.Disable);
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isQuitting)
			{
				if (IsConverted)
				{
					convertSystem.QueueOperation(this, DVConvertToEntitySystem.Operation.Type.Destroy);
				}
				else
				{
					convertSystem.RemoveObjectToConvert(this, startingArchetype);
				}
			}
		}

		internal void ConvertToEntity(EntityManager entityManager, Entity entity)
		{
			EntityManager = entityManager;
			Entity = entity;
			IsConverted = true;
			if (!DisableAutoEnableDisable && !base.isActiveAndEnabled)
			{
				entityManager.AddComponent<Disabled>(entity);
			}
			this.OnConverted?.Invoke(entityManager, entity);
			this.OnConverted = null;
		}

		internal void OnEntityEnabled(EntityCommandBuffer ecb)
		{
			this.OnEnabled?.Invoke(ecb, Entity);
		}

		internal void OnEntityDisabled(EntityCommandBuffer ecb)
		{
			this.OnDisabled?.Invoke(ecb, Entity);
		}

		public Option<T> TryGetComponentData<T>() where T : struct, IComponentData
		{
			if (!EntityManager.HasComponent<T>(Entity))
			{
				return Option<T>.None;
			}
			return Option<T>.Some(EntityManager.GetComponentData<T>(Entity));
		}

		public bool HasComponent<T>()
		{
			return EntityManager.HasComponent<T>(Entity);
		}

		public T GetComponentData<T>() where T : struct, IComponentData
		{
			return EntityManager.GetComponentData<T>(Entity);
		}

		public void SetComponentData<T>(T componentData) where T : struct, IComponentData
		{
			EntityManager.SetComponentData(Entity, componentData);
		}

		public void AddComponentData<T>(T componentData) where T : struct, IComponentData
		{
			EntityManager.AddComponentData(Entity, componentData);
		}

		public void RemoveComponent<T>()
		{
			EntityManager.RemoveComponent<T>(Entity);
		}

		public void AddComponentObject<T>(T componentObject)
		{
			EntityManager.AddComponentObject(Entity, componentObject);
		}

		public T GetComponentObject<T>()
		{
			return EntityManager.GetComponentObject<T>(Entity);
		}

		public static implicit operator Entity(DVConvertToEntity convertToEntity)
		{
			return convertToEntity.Entity;
		}
	}
}
