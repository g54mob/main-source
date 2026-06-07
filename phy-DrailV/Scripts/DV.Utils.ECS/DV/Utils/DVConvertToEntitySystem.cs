using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace DV.Utils
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
	[UpdateBefore(typeof(BeginSimulationEntityCommandBufferSystem))]
	public class DVConvertToEntitySystem : SystemBase
	{
		public readonly struct Operation
		{
			public enum Type
			{
				Enable = 0,
				Disable = 1,
				Destroy = 2
			}

			public readonly DVConvertToEntity entity;

			public readonly Type type;

			public Operation(DVConvertToEntity entity, Type type)
			{
				this.entity = entity;
				this.type = type;
			}
		}

		private readonly struct ArchetypeConvertData
		{
			private static readonly int transformTypeIndex = TypeManager.GetTypeIndex<Transform>();

			public readonly bool archetypeHasTransform;

			public readonly List<DVConvertToEntity> objectsToConvert;

			public ArchetypeConvertData(EntityArchetype archetype, DVConvertToEntity objectToConvert)
			{
				archetypeHasTransform = false;
				objectsToConvert = new List<DVConvertToEntity>(1) { objectToConvert };
				NativeArray<ComponentType> componentTypes = archetype.GetComponentTypes();
				for (int i = 0; i < componentTypes.Length; i++)
				{
					if (componentTypes[i].TypeIndex == transformTypeIndex)
					{
						archetypeHasTransform = true;
						break;
					}
				}
			}
		}

		private BeginSimulationEntityCommandBufferSystem beginSimulationEcbSystem;

		private readonly List<Operation> operations = new List<Operation>();

		private readonly Dictionary<EntityArchetype, ArchetypeConvertData> objectsToConvert = new Dictionary<EntityArchetype, ArchetypeConvertData>();

		protected override void OnCreate()
		{
			beginSimulationEcbSystem = base.World.GetExistingSystem<BeginSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			if (operations.Count > 0)
			{
				EntityCommandBuffer ecb = beginSimulationEcbSystem.CreateCommandBuffer();
				foreach (Operation operation in operations)
				{
					switch (operation.type)
					{
					case Operation.Type.Enable:
						ecb.RemoveComponent<Disabled>(operation.entity);
						operation.entity.OnEntityEnabled(ecb);
						break;
					case Operation.Type.Disable:
						ecb.AddComponent<Disabled>(operation.entity);
						operation.entity.OnEntityDisabled(ecb);
						break;
					case Operation.Type.Destroy:
						ecb.DestroyEntity(operation.entity);
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
				}
				operations.Clear();
			}
			foreach (KeyValuePair<EntityArchetype, ArchetypeConvertData> item in objectsToConvert)
			{
				List<DVConvertToEntity> list = item.Value.objectsToConvert;
				if (list.Count == 0)
				{
					continue;
				}
				bool archetypeHasTransform = item.Value.archetypeHasTransform;
				NativeArray<Entity> nativeArray = base.EntityManager.CreateEntity(item.Key, list.Count, Allocator.Temp);
				for (int i = 0; i < list.Count; i++)
				{
					DVConvertToEntity dVConvertToEntity = list[i];
					Entity entity = nativeArray[i];
					if (archetypeHasTransform)
					{
						base.EntityManager.AddComponentObject(entity, dVConvertToEntity.transform);
					}
					dVConvertToEntity.ConvertToEntity(base.EntityManager, entity);
				}
				list.Clear();
				nativeArray.Dispose();
			}
		}

		public void QueueOperation(DVConvertToEntity entity, Operation.Type type)
		{
			operations.Add(new Operation(entity, type));
		}

		public void AddObjectToConvert(DVConvertToEntity convertToEntity, EntityArchetype archetype)
		{
			if (objectsToConvert.TryGetValue(archetype, out var value))
			{
				value.objectsToConvert.Add(convertToEntity);
			}
			else
			{
				objectsToConvert.Add(archetype, new ArchetypeConvertData(archetype, convertToEntity));
			}
		}

		public void RemoveObjectToConvert(DVConvertToEntity convertToEntity, EntityArchetype archetype)
		{
			if (objectsToConvert.TryGetValue(archetype, out var value))
			{
				int num = value.objectsToConvert.IndexOf(convertToEntity);
				if (num != -1)
				{
					value.objectsToConvert.RemoveAtSwapBack(num);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
