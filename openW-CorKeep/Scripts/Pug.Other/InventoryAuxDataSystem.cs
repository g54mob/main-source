using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class InventoryAuxDataSystem : PugSimulationSystemBase
{
	private class CleanUpSystemDataCD : IComponentData, IQueryTypeParameter, IDisposable
	{
		public InventoryAuxDataSystemDataCD Value;

		public void Dispose()
		{
			Value._typeIndexToTypeHash.Dispose();
			Value._typeHashToLookup.Dispose();
			Value._typeHashToPrefabEntity.Dispose();
			Value._freeIndicesList.Dispose();
			Value._indexCounter.Dispose();
		}

		[Preserve]
		public CleanUpSystemDataCD()
		{
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000021CA_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000021CA_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000021CA_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public EntityCommandBuffer ecb;

		public NativeParallelHashMap<uint, UnsafeList<Entity>> localExtraInventoryDataLookUp;

		public int localCurrentMaxIndex;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataCD> __inventoryAuxDataTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataPrefabCD> __inventoryAuxDataPrefabTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in InventoryAuxDataCD inventoryAuxData, [NoAlias] in InventoryAuxDataPrefabCD inventoryAuxDataPrefab)
		{
			int index = inventoryAuxData.Index;
			if (index == 0)
			{
				ecb.DestroyEntity(entity);
				return;
			}
			ecb.RemoveComponent<InventoryAuxDataNeedsInitializationCD>(entity);
			if (localCurrentMaxIndex < index)
			{
				localCurrentMaxIndex = index;
			}
			uint typeHash = inventoryAuxDataPrefab.TypeHash;
			if (!localExtraInventoryDataLookUp.ContainsKey(typeHash))
			{
				UnsafeList<Entity> item = new UnsafeList<Entity>(localCurrentMaxIndex, Allocator.Persistent);
				localExtraInventoryDataLookUp.Add(typeHash, item);
			}
			foreach (KeyValue<uint, UnsafeList<Entity>> item2 in localExtraInventoryDataLookUp)
			{
				for (int i = item2.Value.Length; i <= localCurrentMaxIndex; i++)
				{
					item2.Value.Add(Entity.Null);
				}
			}
			UnsafeList<Entity> value = localExtraInventoryDataLookUp[typeHash];
			value[index] = entity;
			localExtraInventoryDataLookUp[typeHash] = value;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __inventoryAuxDataTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __inventoryAuxDataPrefabTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataPrefabCD>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataPrefabCD>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataPrefabCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataPrefabCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000021CA_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000021CA_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000021CE_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000021CE_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000021CE_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public BufferLookup<ContainedObjectsBuffer> containerLookUp;

		public NativeParallelHashSet<int> indices;

		public int maxIndex;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity)
		{
			foreach (ContainedObjectsBuffer item in containerLookUp[entity])
			{
				if (item.auxDataIndex > 0)
				{
					if (!indices.Contains(item.auxDataIndex))
					{
						indices.Add(item.auxDataIndex);
					}
					if (item.auxDataIndex > maxIndex)
					{
						maxIndex = item.auxDataIndex;
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000021CE_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000021CE_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000021D2_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000021D2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000021D2_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public EntityCommandBuffer ecb;

		public NativeParallelHashSet<int> indices;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataCD> __extraInventoryDataTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in InventoryAuxDataCD extraInventoryData)
		{
			if (!indices.Contains(extraInventoryData.Index))
			{
				ecb.DestroyEntity(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __extraInventoryDataTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000021D2_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000021D2_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataCD> __InventoryAuxDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataPrefabCD> __InventoryAuxDataPrefabCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__InventoryAuxDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InventoryAuxDataCD>(isReadOnly: true);
			__InventoryAuxDataPrefabCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InventoryAuxDataPrefabCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		}
	}

	private InventoryAuxDataSystemDataCD _systemData;

	private bool _cleanUpDone;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_883585384_0;

	private EntityQuery __query_883585384_1;

	private EntityQuery __query_883585384_2;

	private EntityQuery __query_883585384_3;

	public InventoryAuxDataSystemDataCD SystemData => _systemData;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		RequireForUpdate<InventoryAuxDataPrefabBuffer>();
		InventoryAuxDataSystemExtensions.InitSerializers();
		_systemData._typeHashToLookup = new NativeParallelHashMap<uint, UnsafeList<Entity>>(0, Allocator.Persistent);
		_systemData._typeIndexToTypeHash = new NativeParallelHashMap<int, uint>(0, Allocator.Persistent);
		_systemData._typeHashToPrefabEntity = new NativeParallelHashMap<uint, Entity>(0, Allocator.Persistent);
		_systemData._freeIndicesList = new NativeList<int>(0, Allocator.Persistent);
		_systemData._indexCounter = new NativeReference<int>(Allocator.Persistent);
		Entity entity = base.EntityManager.CreateEntity(typeof(InventoryAuxDataSystemDataCD));
		base.EntityManager.SetComponentData(entity, _systemData);
		Entity entity2 = base.EntityManager.CreateEntity();
		base.EntityManager.AddComponentObject(entity2, new CleanUpSystemDataCD
		{
			Value = _systemData
		});
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		base.OnDestroy();
		foreach (KeyValue<uint, UnsafeList<Entity>> item in _systemData._typeHashToLookup)
		{
			item.Value.Dispose();
		}
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (_systemData._typeHashToPrefabEntity.Count() == 0)
		{
			DynamicBuffer<InventoryAuxDataPrefabBuffer> singletonBuffer = __query_883585384_3.GetSingletonBuffer<InventoryAuxDataPrefabBuffer>();
			for (int i = 0; i < singletonBuffer.Length; i++)
			{
				Entity entity = singletonBuffer[i].Entity;
				uint typeHash = singletonBuffer[i].TypeHash;
				NativeArray<ComponentType> componentTypes = base.EntityManager.GetComponentTypes(entity);
				_systemData._typeHashToPrefabEntity.Add(typeHash, entity);
				_systemData._typeHashToLookup.Add(typeHash, new UnsafeList<Entity>(64, Allocator.Persistent));
				foreach (ComponentType item in componentTypes)
				{
					if (item.GetManagedType().IsDefined(typeof(InventoryAuxDataComponentAttribute)))
					{
						if (_systemData._typeIndexToTypeHash.ContainsKey(item.TypeIndex))
						{
							Debug.LogError($"Same component ({item}) in multiple inventory aux data prefabs");
						}
						else
						{
							_systemData._typeIndexToTypeHash.Add(item.TypeIndex, typeHash);
						}
					}
				}
			}
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
		BufferLookup<ContainedObjectsBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		NativeParallelHashMap<uint, UnsafeList<Entity>> localExtraInventoryDataLookUp = _systemData._typeHashToLookup;
		if (!base.World.IsClient())
		{
			_systemData._indexCounter.Value = ServerUpdate(_systemData._indexCounter.Value, ecb, bufferLookup);
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
			ecb = new EntityCommandBuffer(Allocator.Temp);
		}
		int localCurrentMaxIndex = _systemData._indexCounter.Value;
		InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Execute(ref ecb, ref localExtraInventoryDataLookUp, ref localCurrentMaxIndex);
		_systemData._indexCounter.Value = localCurrentMaxIndex;
		ecb.Playback(base.EntityManager);
		ecb.Dispose();
		base.OnUpdate();
	}

	private int ServerUpdate(int localCurrentMaxIndex, EntityCommandBuffer ecb, BufferLookup<ContainedObjectsBuffer> containerLookUp)
	{
		NativeList<int> freeIndicesList = _systemData._freeIndicesList;
		if (!_cleanUpDone)
		{
			NativeParallelHashSet<int> indices = new NativeParallelHashSet<int>(0, Allocator.Temp);
			int maxIndex = 0;
			InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Execute(ref containerLookUp, ref indices, ref maxIndex);
			InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Execute(ref ecb, ref indices);
			for (int i = 1; i < maxIndex; i++)
			{
				if (!indices.Contains(i))
				{
					freeIndicesList.Add(in i);
				}
			}
			localCurrentMaxIndex = maxIndex;
			indices.Dispose();
			_cleanUpDone = true;
		}
		foreach (KeyValue<uint, UnsafeList<Entity>> item in _systemData._typeHashToLookup)
		{
			item.Value.Resize(localCurrentMaxIndex + 1, NativeArrayOptions.ClearMemory);
		}
		return localCurrentMaxIndex;
	}

	private void InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref NativeParallelHashMap<uint, UnsafeList<Entity>> localExtraInventoryDataLookUp, ref int localCurrentMaxIndex)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__InventoryAuxDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__InventoryAuxDataPrefabCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Job value = new InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Job
		{
			ecb = ecb,
			localExtraInventoryDataLookUp = localExtraInventoryDataLookUp,
			localCurrentMaxIndex = localCurrentMaxIndex,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__inventoryAuxDataTypeHandle = __TypeHandle.__InventoryAuxDataCD_RO_ComponentTypeHandle,
			__inventoryAuxDataPrefabTypeHandle = __TypeHandle.__InventoryAuxDataPrefabCD_RO_ComponentTypeHandle
		};
		if (!__query_883585384_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			InventoryAuxDataSystem_17B41EDC_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_883585384_0, jobPtr);
		}
		ecb = value.ecb;
		localExtraInventoryDataLookUp = value.localExtraInventoryDataLookUp;
		localCurrentMaxIndex = value.localCurrentMaxIndex;
	}

	private void InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Execute(ref BufferLookup<ContainedObjectsBuffer> containerLookUp, ref NativeParallelHashSet<int> indices, ref int maxIndex)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Job value = new InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Job
		{
			containerLookUp = containerLookUp,
			indices = indices,
			maxIndex = maxIndex,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
		};
		if (!__query_883585384_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			InventoryAuxDataSystem_5B4D9CFA_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_883585384_1, jobPtr);
		}
		containerLookUp = value.containerLookUp;
		indices = value.indices;
		maxIndex = value.maxIndex;
	}

	private void InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Execute(ref EntityCommandBuffer ecb, ref NativeParallelHashSet<int> indices)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__InventoryAuxDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Job value = new InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Job
		{
			ecb = ecb,
			indices = indices,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__extraInventoryDataTypeHandle = __TypeHandle.__InventoryAuxDataCD_RO_ComponentTypeHandle
		};
		if (!__query_883585384_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			InventoryAuxDataSystem_5B4D9CFA_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_883585384_2, jobPtr);
		}
		ecb = value.ecb;
		indices = value.indices;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<InventoryAuxDataPrefabCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<InventoryAuxDataNeedsInitializationCD>();
		__query_883585384_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_883585384_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataCD>();
		__query_883585384_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<InventoryAuxDataPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_883585384_3 = entityQueryBuilder2.Build(ref state);
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
	public InventoryAuxDataSystem()
	{
	}
}
