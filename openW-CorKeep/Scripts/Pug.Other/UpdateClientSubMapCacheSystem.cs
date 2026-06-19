using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[UpdateBefore(typeof(CreateMapPhysicsSystem))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup), OrderFirst = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct UpdateClientSubMapCacheSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct ClearSubMapRegistryJob : IJob
	{
		public NativeList<Entity> FreeList;

		public NativeParallelHashMap<int2, Entity> IndexToEntity;

		public BufferLookup<SubMapLayerBuffer> SubMapLayerBufferLookup;

		public void Execute()
		{
			foreach (KeyValue<int2, Entity> item in IndexToEntity)
			{
				Entity value = item.Value;
				SubMapLayerBufferLookup[value].Clear();
				FreeList.Add(in value);
			}
			IndexToEntity.Clear();
		}
	}

	[BurstCompile]
	private struct UpdateSubMapRegistryJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<ClientSubMapLayerCD> __ClientSubMapLayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ClientSubMapLayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientSubMapLayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__ClientSubMapLayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<ClientSubMapLayerCD>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref UpdateSubMapRegistryJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateSubMapRegistryJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateSubMapRegistryJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeList<Entity> FreeList;

		public NativeParallelHashMap<int2, Entity> IndexToEntity;

		public ComponentLookup<SubMapCD> SubMapLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(in ClientSubMapLayerCD clientSubMapLayerCD)
		{
			int2 int5 = new int2(64, 48);
			int2 int6 = clientSubMapLayerCD.data.viewPoint - int5 / 2;
			EnsurePositionInRegistry(int6);
			EnsurePositionInRegistry(int6 + new int2(0, 48));
			EnsurePositionInRegistry(int6 + new int2(64, 0));
			EnsurePositionInRegistry(int6 + int5);
		}

		private void EnsurePositionInRegistry(int2 position)
		{
			int2 int5 = (position & -64) >> 6;
			if (!IndexToEntity.ContainsKey(int5))
			{
				if (FreeList.Length == 0)
				{
					UnityEngine.Debug.LogError("No free submap entities available");
					return;
				}
				Entity entity = FreeList[FreeList.Length - 1];
				FreeList.RemoveAt(FreeList.Length - 1);
				IndexToEntity.Add(int5, entity);
				SubMapLookup.GetRefRW(entity).ValueRW.index = int5 << 6;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientSubMapLayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct UpdateClientSubMapCacheJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<ClientSubMapLayerCD> __ClientSubMapLayerCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ClientSubMapLayerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ClientSubMapLayerCD>();
				}

				public void Update(ref SystemState state)
				{
					__ClientSubMapLayerCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAllRW<ClientSubMapLayerCD>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref UpdateClientSubMapCacheJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateClientSubMapCacheJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateClientSubMapCacheJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateClientSubMapCacheJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateClientSubMapCacheJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateClientSubMapCacheJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public BufferLookup<SubMapLayerBuffer> SubMapLayerBufferLookup;

		public NativeParallelHashMap<int2, Entity> SubMapIndexToEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(ref ClientSubMapLayerCD clientSubMapLayerCD)
		{
			int2 int5 = new int2(64, 48);
			int2 int6 = clientSubMapLayerCD.data.viewPoint - int5 / 2;
			int2 int7 = int6 + int5;
			int2 int8 = (int6 & -64) >> 6;
			int2 int9 = (int7 & -64) >> 6;
			ref ClientSubMapLayer data = ref clientSubMapLayerCD.data;
			for (int i = int8.y; i <= int9.y; i++)
			{
				for (int j = int8.x; j <= int9.x; j++)
				{
					int2 int10 = new int2(j, i);
					if (SubMapIndexToEntity.TryGetValue(int10, out var item))
					{
						int2 int11 = int10 << 6;
						int2 y = int11 + 64;
						DynamicBuffer<SubMapLayerBuffer> dynamicBuffer = SubMapLayerBufferLookup[item];
						int k;
						for (k = 0; k < dynamicBuffer.Length && !dynamicBuffer[k].data.layer.Equals(clientSubMapLayerCD.layer); k++)
						{
						}
						if (k == dynamicBuffer.Length)
						{
							dynamicBuffer.Add(new SubMapLayerBuffer
							{
								data = new SubMapLayer
								{
									layer = clientSubMapLayerCD.layer
								}
							});
						}
						ref SubMapLayerBuffer reference = ref dynamicBuffer.ElementAt(k);
						int2 int12 = math.max(int6, int11);
						int2 int13 = math.min(int7, y) - int12;
						int2 int14 = int12 - int11;
						int2 int15 = int12 - int6;
						int n = int15.x - int14.x;
						ulong num = 0uL;
						for (int l = int15.x; l < int15.x + int13.x; l++)
						{
							num |= (ulong)(1L << l);
						}
						for (int m = 0; m < int13.y; m++)
						{
							int index = int15.y + m;
							int index2 = int14.y + m;
							ulong num2 = data.Row(index);
							num2 &= num;
							num2.Ror(n);
							reference.data.Row(index2) |= num2;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ClientSubMapLayerCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public BufferLookup<SubMapLayerBuffer> __SubMapLayerBuffer_RW_BufferLookup;

		public ComponentLookup<SubMapCD> __SubMapCD_RW_ComponentLookup;

		public UpdateSubMapRegistryJob.InternalCompilerQueryAndHandleData __UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle;

		public UpdateClientSubMapCacheJob.InternalCompilerQueryAndHandleData __UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SubMapLayerBuffer_RW_BufferLookup = state.GetBufferLookup<SubMapLayerBuffer>();
			__SubMapCD_RW_ComponentLookup = state.GetComponentLookup<SubMapCD>();
			__UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00004454_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00004454_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00004454_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_00004455_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00004455_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00004455_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	private const int SUB_MAP_ENTITY_POOL_SIDE = 16;

	private EntityArchetype _subMapArchetype;

	private NativeList<Entity> _freeSubMapEntity;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1250093893_0;

	public void OnCreate(ref SystemState state)
	{
		state.EntityManager.CreateSingleton(new SubMapRegistry
		{
			IndexToEntity = new NativeParallelHashMap<int2, Entity>(16, Allocator.Persistent)
		});
		_subMapArchetype = state.EntityManager.CreateArchetype(typeof(SubMapCD), typeof(SubMapLayerBuffer), typeof(LocalTransform));
		_freeSubMapEntity = new NativeList<Entity>(16, Allocator.Persistent);
		for (int i = 0; i < 16; i++)
		{
			_freeSubMapEntity.Add(state.EntityManager.CreateEntity(_subMapArchetype));
			state.EntityManager.SetComponentData(_freeSubMapEntity[i], new SubMapCD
			{
				index = -2147483647
			});
		}
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_freeSubMapEntity.Dispose();
		__query_1250093893_0.GetSingleton<SubMapRegistry>().IndexToEntity.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NativeParallelHashMap<int2, Entity> indexToEntity = __query_1250093893_0.GetSingleton<SubMapRegistry>().IndexToEntity;
		ClearSubMapRegistryJob jobData = new ClearSubMapRegistryJob
		{
			FreeList = _freeSubMapEntity,
			IndexToEntity = indexToEntity,
			SubMapLayerBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SubMapLayerBuffer_RW_BufferLookup, ref state)
		};
		state.Dependency = IJobExtensions.ScheduleByRef(ref jobData, state.Dependency);
		UpdateSubMapRegistryJob job = new UpdateSubMapRegistryJob
		{
			FreeList = _freeSubMapEntity,
			IndexToEntity = indexToEntity,
			SubMapLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SubMapCD_RW_ComponentLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		UpdateClientSubMapCacheJob job2 = new UpdateClientSubMapCacheJob
		{
			SubMapIndexToEntity = indexToEntity,
			SubMapLayerBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SubMapLayerBuffer_RW_BufferLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_1(ref job2, __TypeHandle.__UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UpdateClientSubMapCacheSystem_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ref UpdateClientSubMapCacheJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UpdateClientSubMapCacheSystem_UpdateClientSubMapCacheJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapRegistry>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1250093893_0 = entityQueryBuilder2.Build(ref state);
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
		((UpdateClientSubMapCacheSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00004454_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00004455_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateClientSubMapCacheSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateClientSubMapCacheSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateClientSubMapCacheSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
