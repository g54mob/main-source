using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[DisableAutoCreation]
public struct DestroyClumpedItemsSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1149742881_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (ObjectDataSerializedCD, Translation) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataSerializedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Translation>(item2_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ObjectDataSerializedCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<Translation> item2_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<Translation>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(ObjectDataSerializedCD, Translation)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (ObjectDataSerializedCD, Translation) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataSerializedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<Translation>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1149742881_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<ContainedObjectsSerializedBuffer> item3_BufferAccessor;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation, DynamicBuffer<ContainedObjectsSerializedBuffer>> Get(int index)
			{
				return new QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation, DynamicBuffer<ContainedObjectsSerializedBuffer>>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataSerializedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Translation>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ObjectDataSerializedCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<Translation> item2_ComponentTypeHandle_RO;

			private BufferTypeHandle<ContainedObjectsSerializedBuffer> item3_BufferTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<Translation>(isReadOnly: true);
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedObjectsSerializedBuffer>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item3_BufferTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation, DynamicBuffer<ContainedObjectsSerializedBuffer>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation, DynamicBuffer<ContainedObjectsSerializedBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataSerializedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<Translation>();
			state.EntityManager.CompleteDependencyBeforeRW<ContainedObjectsSerializedBuffer>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1149742881_2
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation> Get(int index)
			{
				return new QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataSerializedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Translation>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ObjectDataSerializedCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<Translation> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<Translation>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataSerializedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<Translation>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1149742881_3
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation> Get(int index)
			{
				return new QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataSerializedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Translation>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ObjectDataSerializedCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<Translation> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<Translation>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataSerializedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<Translation>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1149742881_0.TypeHandle __IFE_1149742881_0_TypeHandle;

		public IFE_1149742881_1.TypeHandle __IFE_1149742881_1_TypeHandle;

		public IFE_1149742881_2.TypeHandle __IFE_1149742881_2_TypeHandle;

		public IFE_1149742881_3.TypeHandle __IFE_1149742881_3_TypeHandle;

		public BufferLookup<ContainedObjectsSerializedBuffer> __ContainedObjectsSerializedBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1149742881_0_TypeHandle = new IFE_1149742881_0.TypeHandle(ref state);
			__IFE_1149742881_1_TypeHandle = new IFE_1149742881_1.TypeHandle(ref state);
			__IFE_1149742881_2_TypeHandle = new IFE_1149742881_2.TypeHandle(ref state);
			__IFE_1149742881_3_TypeHandle = new IFE_1149742881_3.TypeHandle(ref state);
			__ContainedObjectsSerializedBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsSerializedBuffer>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_0000345D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000345D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000345D_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	private const int AREA_SIZE = 4;

	private const int MAX_CREATURES_PER_AREA = 512;

	private const int MAX_DROPPED_ITEMS_PER_AREA = 1024;

	private NativeHashSet<ObjectData> _creatures;

	private NativeHashSet<ObjectData> _canBeMerged;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1149742881_0;

	private EntityQuery __query_1149742881_1;

	public void OnCreate(ref SystemState state)
	{
		_creatures = new NativeHashSet<ObjectData>(64, Allocator.Persistent);
		_canBeMerged = new NativeHashSet<ObjectData>(64, Allocator.Persistent);
		foreach (var (objectDataCD2, objectInfo2) in PugDatabase.objectsByType)
		{
			if (objectInfo2.objectType == ObjectType.Creature)
			{
				_creatures.Add(objectDataCD2);
			}
			if (objectInfo2.isStackable && objectInfo2.rarity != Rarity.Legendary)
			{
				_canBeMerged.Add(objectDataCD2);
			}
		}
	}

	public void OnDestroy(ref SystemState state)
	{
		_creatures.Dispose();
		_canBeMerged.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NativeHashMap<int2, int> nativeHashMap = new NativeHashMap<int2, int>(1024, Allocator.Temp);
		NativeHashMap<int2, int> nativeHashMap2 = new NativeHashMap<int2, int>(1024, Allocator.Temp);
		foreach (var (obj, translation) in IFE_1149742881_0.Query(__query_1149742881_0, __TypeHandle.__IFE_1149742881_0_TypeHandle, ref state))
		{
			if (obj.ObjectID == ObjectID.DroppedItem)
			{
				int2 key = translation.Value.RoundToInt2() / 4;
				if (!nativeHashMap2.TryGetValue(key, out var item))
				{
					item = 0;
				}
				nativeHashMap2[key] = item + 1;
			}
			if (_creatures.Contains(ToObjectData(obj)))
			{
				int2 key2 = translation.Value.RoundToInt2() / 4;
				if (!nativeHashMap.TryGetValue(key2, out var item2))
				{
					item2 = 0;
				}
				nativeHashMap[key2] = item2 + 1;
			}
		}
		ObjectDataSerializedCD item3;
		Translation item4;
		Entity entity;
		foreach (KVPair<int2, int> item9 in nativeHashMap2)
		{
			int2 key3 = item9.Key;
			int value = item9.Value;
			if (value <= 1024)
			{
				continue;
			}
			int num = 0;
			EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
			NativeHashMap<ObjectData, Entity> nativeHashMap3 = new NativeHashMap<ObjectData, Entity>(64, Allocator.Temp);
			foreach (QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation, DynamicBuffer<ContainedObjectsSerializedBuffer>> item10 in IFE_1149742881_1.Query(__query_1149742881_1, __TypeHandle.__IFE_1149742881_1_TypeHandle, ref state))
			{
				item10.Deconstruct(out item3, out item4, out var item5, out entity);
				ObjectDataSerializedCD objectDataSerializedCD = item3;
				Translation translation2 = item4;
				DynamicBuffer<ContainedObjectsSerializedBuffer> dynamicBuffer = item5;
				Entity entity2 = entity;
				if (objectDataSerializedCD.ObjectID != ObjectID.DroppedItem || dynamicBuffer.Length != 1 || math.any(translation2.Value.RoundToInt2() / 4 != key3))
				{
					continue;
				}
				ObjectData objectData = ToObjectData(dynamicBuffer[0].ObjectData);
				if (_canBeMerged.Contains(objectData))
				{
					if (nativeHashMap3.TryGetValue(objectData, out var item6))
					{
						DynamicBuffer<ContainedObjectsSerializedBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__ContainedObjectsSerializedBuffer_RW_BufferLookup, ref state, item6);
						ObjectDataSerializedCD objectData2 = bufferAfterCompletingDependency[0].ObjectData;
						int num2 = math.min(math.max(0, 9999 - objectData2.Amount), objectData.amount);
						objectData2.Amount += num2;
						objectData.amount -= num2;
						bufferAfterCompletingDependency[0] = new ContainedObjectsSerializedBuffer
						{
							ObjectData = objectData2
						};
					}
					if (objectData.amount == 0)
					{
						entityCommandBuffer.DestroyEntity(entity2);
						num++;
						continue;
					}
					ref ContainedObjectsSerializedBuffer reference = ref dynamicBuffer.ElementAt(0);
					ContainedObjectsSerializedBuffer containedObjectsSerializedBuffer = default(ContainedObjectsSerializedBuffer);
					item3 = new ObjectDataSerializedCD
					{
						ObjectID = objectData.objectID,
						Variation = objectData.variation,
						Amount = objectData.amount
					};
					containedObjectsSerializedBuffer.ObjectData = item3;
					reference.ObjectData = containedObjectsSerializedBuffer;
					nativeHashMap3[objectData] = entity2;
				}
			}
			entityCommandBuffer.Playback(state.EntityManager);
			nativeHashMap3.Dispose();
			entityCommandBuffer.Dispose();
			Debug.LogWarning($"{key3 * 4} - {(key3 + 1) * 4 - 1} contained {value} > {1024} dropped items. Merged down to {value - num} separate stacks.");
		}
		foreach (KVPair<int2, int> item11 in nativeHashMap)
		{
			int2 key4 = item11.Key;
			int value2 = item11.Value;
			if (value2 <= 512)
			{
				continue;
			}
			float num3 = math.clamp(1f - 512f / (float)value2 + 0.05f, 0f, 0.99f);
			NativeHashMap<ObjectData, int> nativeHashMap4 = new NativeHashMap<ObjectData, int>(64, Allocator.Temp);
			foreach (QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation> item12 in IFE_1149742881_2.Query(__query_1149742881_0, __TypeHandle.__IFE_1149742881_2_TypeHandle, ref state))
			{
				item12.Deconstruct(out item3, out item4, out entity);
				ObjectDataSerializedCD obj2 = item3;
				Translation translation3 = item4;
				if (_creatures.Contains(ToObjectData(obj2)) && !math.any(translation3.Value.RoundToInt2() / 4 != key4))
				{
					ObjectData key5 = new ObjectData
					{
						objectID = obj2.ObjectID,
						variation = obj2.Variation,
						amount = obj2.Amount
					};
					if (!nativeHashMap4.TryGetValue(key5, out var item7))
					{
						item7 = 0;
					}
					nativeHashMap4[key5] = item7 + 1;
				}
			}
			NativeHashMap<ObjectData, int> nativeHashMap5 = new NativeHashMap<ObjectData, int>(64, Allocator.Temp);
			foreach (KVPair<ObjectData, int> item13 in nativeHashMap4)
			{
				ObjectData key6 = item13.Key;
				int value3 = (int)math.floor((float)item13.Value * num3);
				nativeHashMap5[key6] = value3;
			}
			int num4 = 0;
			EntityCommandBuffer entityCommandBuffer2 = new EntityCommandBuffer(Allocator.Temp);
			foreach (QueryEnumerableWithEntity<ObjectDataSerializedCD, Translation> item14 in IFE_1149742881_3.Query(__query_1149742881_0, __TypeHandle.__IFE_1149742881_3_TypeHandle, ref state))
			{
				item14.Deconstruct(out item3, out item4, out entity);
				ObjectDataSerializedCD obj3 = item3;
				Translation translation4 = item4;
				Entity e = entity;
				if (_creatures.Contains(ToObjectData(obj3)) && !math.any(translation4.Value.RoundToInt2() / 4 != key4))
				{
					ObjectData key7 = new ObjectData
					{
						objectID = obj3.ObjectID,
						variation = obj3.Variation,
						amount = obj3.Amount
					};
					if (nativeHashMap5.TryGetValue(key7, out var item8) && item8 > 0)
					{
						nativeHashMap5[key7] = item8 - 1;
						entityCommandBuffer2.DestroyEntity(e);
						num4++;
					}
				}
			}
			entityCommandBuffer2.Playback(state.EntityManager);
			nativeHashMap4.Dispose();
			nativeHashMap5.Dispose();
			entityCommandBuffer2.Dispose();
			Debug.LogWarning($"{key4 * 4} - {(key4 + 1) * 4 - 1} contained {value2} > {512} creatures. Despawned down to {value2 - num4}.");
		}
	}

	private static ObjectData ToObjectData(ObjectDataSerializedCD obj)
	{
		return new ObjectData
		{
			objectID = obj.ObjectID,
			variation = obj.Variation,
			amount = obj.Amount
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<Translation>();
		__query_1149742881_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<Translation>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsSerializedBuffer>();
		__query_1149742881_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((DestroyClumpedItemsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000345D_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		((DestroyClumpedItemsSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DestroyClumpedItemsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DestroyClumpedItemsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
