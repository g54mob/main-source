using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine;
using UnityEngine.Scripting;

[DisableAutoCreation]
public class DefaultConvertSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2004407700_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InternalCompilerInterface.UncheckedRefRW<ObjectDataSerializedCD> Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetUncheckedRefRW<ObjectDataSerializedCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<ObjectDataSerializedCD> item1_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ObjectDataSerializedCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<InternalCompilerInterface.UncheckedRefRW<ObjectDataSerializedCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public InternalCompilerInterface.UncheckedRefRW<ObjectDataSerializedCD> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<ObjectDataSerializedCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2004407700_1
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<ContainedObjectsSerializedBuffer> item1_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public DynamicBuffer<ContainedObjectsSerializedBuffer> Get(int index)
			{
				return item1_BufferAccessor[index];
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<ContainedObjectsSerializedBuffer> item1_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedObjectsSerializedBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<DynamicBuffer<ContainedObjectsSerializedBuffer>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public DynamicBuffer<ContainedObjectsSerializedBuffer> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<ContainedObjectsSerializedBuffer>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2004407700_2
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<DropsLootSerializedBuffer> item1_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public DynamicBuffer<DropsLootSerializedBuffer> Get(int index)
			{
				return item1_BufferAccessor[index];
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<DropsLootSerializedBuffer> item1_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<DropsLootSerializedBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<DynamicBuffer<DropsLootSerializedBuffer>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public DynamicBuffer<DropsLootSerializedBuffer> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<DropsLootSerializedBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_2004407700_0.TypeHandle __IFE_2004407700_0_TypeHandle;

		public IFE_2004407700_1.TypeHandle __IFE_2004407700_1_TypeHandle;

		public IFE_2004407700_2.TypeHandle __IFE_2004407700_2_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_2004407700_0_TypeHandle = new IFE_2004407700_0.TypeHandle(ref state);
			__IFE_2004407700_1_TypeHandle = new IFE_2004407700_1.TypeHandle(ref state);
			__IFE_2004407700_2_TypeHandle = new IFE_2004407700_2.TypeHandle(ref state);
		}
	}

	private static readonly int NamePropertyId = Property.StringToHash("name");

	private static readonly int CookedFoodPropertyId = Property.StringToHash("isCookedFood");

	public DatabaseCD NewDatabase;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2004407700_0;

	private EntityQuery __query_2004407700_1;

	private EntityQuery __query_2004407700_2;

	private EntityQuery __query_2004407700_3;

	private EntityQuery __query_2004407700_4;

	[Preserve]
	protected override void OnUpdate()
	{
		if (!NewDatabase.ObjectPropertyLookup.IsCreated)
		{
			Debug.LogError("Failed to convert: missing database");
			return;
		}
		if (!__query_2004407700_3.TryGetSingleton<ObjectPropertiesSerializedCD>(out var value))
		{
			Debug.Log("No previous object properties, skip remap");
			return;
		}
		int removedObjectsCount = 0;
		PropertyLookupBuilder propertyLookupBuilder = new PropertyLookupBuilder();
		PropertyLookup previousRemoved = default(PropertyLookup);
		if (__query_2004407700_4.TryGetSingleton<RemovedObjectPropertiesSerializedCD>(out var value2))
		{
			previousRemoved = value2.ObjectPropertyLookup;
		}
		PropertyLookup objectPropertyLookup = value.ObjectPropertyLookup;
		PropertyLookup objectPropertyLookup2 = NewDatabase.ObjectPropertyLookup;
		Dictionary<ObjectID, int> remapRemoved = new Dictionary<ObjectID, int>();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (PropertyLookup.Entry property in objectPropertyLookup2.GetProperties(NamePropertyId))
		{
			dictionary.Add(objectPropertyLookup2.GetPropertyString(property.Index, property.Property), property.Index);
		}
		foreach (InternalCompilerInterface.UncheckedRefRW<ObjectDataSerializedCD> item in IFE_2004407700_0.Query(__query_2004407700_0, __TypeHandle.__IFE_2004407700_0_TypeHandle, ref base.CheckedStateRef))
		{
			UpdateObjectData(ref item.ValueRW, objectPropertyLookup, previousRemoved, dictionary, propertyLookupBuilder, ref removedObjectsCount, remapRemoved);
		}
		foreach (DynamicBuffer<ContainedObjectsSerializedBuffer> item2 in IFE_2004407700_1.Query(__query_2004407700_1, __TypeHandle.__IFE_2004407700_1_TypeHandle, ref base.CheckedStateRef))
		{
			for (int i = 0; i < item2.Length; i++)
			{
				UpdateObjectData(ref item2.ElementAt(i).ObjectData, objectPropertyLookup, previousRemoved, dictionary, propertyLookupBuilder, ref removedObjectsCount, remapRemoved);
			}
		}
		foreach (DynamicBuffer<DropsLootSerializedBuffer> item3 in IFE_2004407700_2.Query(__query_2004407700_2, __TypeHandle.__IFE_2004407700_2_TypeHandle, ref base.CheckedStateRef))
		{
			for (int j = 0; j < item3.Length; j++)
			{
				item3.ElementAt(j).ObjectID = GetNewObjectID(item3[j].ObjectID, objectPropertyLookup, previousRemoved, dictionary, propertyLookupBuilder, ref removedObjectsCount, remapRemoved);
			}
		}
		if (!__query_2004407700_4.TryGetSingletonEntity<RemovedObjectPropertiesSerializedCD>(out var value3))
		{
			value3 = base.EntityManager.CreateEntity(typeof(RemovedObjectPropertiesSerializedCD));
		}
		base.EntityManager.SetComponentData(value3, new RemovedObjectPropertiesSerializedCD
		{
			ObjectPropertyLookup = propertyLookupBuilder.CreateLookup(Manager.ecs.BlobAssetStore)
		});
	}

	private static void UpdateObjectData(ref ObjectDataSerializedCD objectData, PropertyLookup previous, PropertyLookup previousRemoved, Dictionary<string, int> nameToObjectID, PropertyLookupBuilder removedObjects, ref int removedObjectsCount, Dictionary<ObjectID, int> remapRemoved)
	{
		if ((objectData.ObjectID >= ObjectID.None && previous.IsCreated && previous.HasProperty((int)objectData.ObjectID, CookedFoodPropertyId)) || (objectData.ObjectID < ObjectID.None && previousRemoved.IsCreated && previousRemoved.HasProperty(0 - objectData.ObjectID, CookedFoodPropertyId)))
		{
			int variation = objectData.Variation;
			ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(variation);
			ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(variation);
			primaryIngredientFromVariation = GetNewObjectID(primaryIngredientFromVariation, previous, previousRemoved, nameToObjectID, removedObjects, ref removedObjectsCount, remapRemoved);
			secondaryIngredientFromVariation = GetNewObjectID(secondaryIngredientFromVariation, previous, previousRemoved, nameToObjectID, removedObjects, ref removedObjectsCount, remapRemoved);
			objectData.Variation = CookedFoodCD.GetFoodVariation(primaryIngredientFromVariation, secondaryIngredientFromVariation);
		}
		ObjectID newObjectID = GetNewObjectID(objectData.ObjectID, previous, previousRemoved, nameToObjectID, removedObjects, ref removedObjectsCount, remapRemoved);
		objectData.ObjectID = newObjectID;
	}

	private static ObjectID GetNewObjectID(ObjectID oldObjectId, PropertyLookup previous, PropertyLookup previousRemoved, Dictionary<string, int> nameToObjectID, PropertyLookupBuilder removedObjects, ref int removedObjectsCount, Dictionary<ObjectID, int> remapRemoved)
	{
		if (oldObjectId == ObjectID.None)
		{
			return ObjectID.None;
		}
		if (oldObjectId > ObjectID.None && oldObjectId < (ObjectID)32767)
		{
			return oldObjectId;
		}
		int value = 0;
		string value2 = null;
		if (oldObjectId >= ObjectID.None && !previous.TryGetPropertyString((int)oldObjectId, NamePropertyId, out value2))
		{
			Debug.Log($"failed to get prop string for {oldObjectId}");
		}
		else if (oldObjectId < ObjectID.None && previousRemoved.IsCreated && !previousRemoved.TryGetPropertyString(0 - oldObjectId, NamePropertyId, out value2))
		{
			Debug.Log($"failed to get prop string for removed object {oldObjectId}");
		}
		if (value2 != null)
		{
			nameToObjectID.TryGetValue(value2, out value);
		}
		if (value == 0 && !remapRemoved.TryGetValue(oldObjectId, out value))
		{
			value = --removedObjectsCount;
			remapRemoved.Add(oldObjectId, value);
			if (oldObjectId >= ObjectID.None)
			{
				removedObjects.Add(previous, (int)oldObjectId, -value);
			}
			else if (previousRemoved.IsCreated)
			{
				removedObjects.Add(previousRemoved, 0 - oldObjectId, -value);
			}
			else
			{
				Debug.LogError("got negative object id, but no removed lookup");
			}
		}
		if (value < 0)
		{
			return ObjectID.None;
		}
		return (ObjectID)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ObjectDataSerializedCD>();
		__query_2004407700_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ContainedObjectsSerializedBuffer>();
		__query_2004407700_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<DropsLootSerializedBuffer>();
		__query_2004407700_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectPropertiesSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2004407700_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<RemovedObjectPropertiesSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2004407700_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public DefaultConvertSystem()
	{
	}
}
