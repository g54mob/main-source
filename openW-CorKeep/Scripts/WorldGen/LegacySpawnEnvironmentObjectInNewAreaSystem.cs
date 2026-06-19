using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class LegacySpawnEnvironmentObjectInNewAreaSystem : PugSimulationSystemBase
{
	private struct AfterSpawnCleanup : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		public Entity AreaEntityRef;
	}

	[NoAlias]
	[BurstCompile]
	private struct LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000042_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000042_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000042_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public EntityArchetype spawnEnvArchetypeLocal;

		public WorldGenerationType worldGenerationType;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<LegacySpawnEnvironmentObjectsInAreaCD> __spawnEnvInAreaTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ProceduralSpawnArea> __areaTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref LegacySpawnEnvironmentObjectsInAreaCD spawnEnvInArea, [NoAlias] in ProceduralSpawnArea area)
		{
			if (worldGenerationType == WorldGenerationType.Creative)
			{
				ecb.RemoveComponent<LegacySpawnEnvironmentObjectsInAreaCD>(entity);
				ecb.AddComponent<LegacySpawnTerritoriesInAreaCD>(entity);
				return;
			}
			if (spawnEnvInArea.hasSpawnedSubParts)
			{
				if (spawnEnvInArea.pendingSubAreas == 0)
				{
					ecb.RemoveComponent<LegacySpawnEnvironmentObjectsInAreaCD>(entity);
					ecb.AddComponent<LegacySpawnTerritoriesInAreaCD>(entity);
				}
				return;
			}
			spawnEnvInArea.hasSpawnedSubParts = true;
			SpawnEnvironmentObjectsCD component = new SpawnEnvironmentObjectsCD
			{
				fillPartialSubMap = spawnEnvInArea.fillPartialSubMap
			};
			AfterSpawnCleanup component2 = new AfterSpawnCleanup
			{
				AreaEntityRef = entity
			};
			if (math.any(area.Size % component.size != 0))
			{
				Debug.LogError("big spawn area not a multiple of env spawn area");
			}
			int num = area.Size.y / component.size.y;
			int num2 = area.Size.x / component.size.x;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					component.position = area.Position + new int2(j * component.size.x, i * component.size.y);
					Entity e = ecb.CreateEntity(spawnEnvArchetypeLocal);
					ecb.SetComponent(e, component);
					ecb.SetComponent(e, component2);
					spawnEnvInArea.pendingSubAreas++;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __spawnEnvInAreaTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __areaTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnEnvironmentObjectsInAreaCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnEnvironmentObjectsInAreaCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnEnvironmentObjectsInAreaCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnEnvironmentObjectsInAreaCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000042_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000042_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000046_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000046_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000046_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public ComponentLookup<LegacySpawnEnvironmentObjectsInAreaCD> spawnEnvironmentObjectsInAreaLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<AfterSpawnCleanup> __cleanupTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in AfterSpawnCleanup cleanup)
		{
			if (cleanup.AreaEntityRef != Entity.Null)
			{
				LegacySpawnEnvironmentObjectsInAreaCD value = spawnEnvironmentObjectsInAreaLookup[cleanup.AreaEntityRef];
				value.pendingSubAreas--;
				spawnEnvironmentObjectsInAreaLookup[cleanup.AreaEntityRef] = value;
			}
			ecb.RemoveComponent<AfterSpawnCleanup>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __cleanupTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000046_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000046_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<LegacySpawnEnvironmentObjectsInAreaCD> __LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<AfterSpawnCleanup> __LegacySpawnEnvironmentObjectInNewAreaSystem_AfterSpawnCleanup_RO_ComponentTypeHandle;

		public ComponentLookup<LegacySpawnEnvironmentObjectsInAreaCD> __LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LegacySpawnEnvironmentObjectsInAreaCD>();
			__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
			__LegacySpawnEnvironmentObjectInNewAreaSystem_AfterSpawnCleanup_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AfterSpawnCleanup>(isReadOnly: true);
			__LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentLookup = state.GetComponentLookup<LegacySpawnEnvironmentObjectsInAreaCD>();
		}
	}

	private EntityArchetype _subAreaArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1259129973_0;

	private EntityQuery __query_1259129973_1;

	private EntityQuery __query_1259129973_2;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		_subAreaArchetype = base.EntityManager.CreateArchetype(typeof(SpawnEnvironmentObjectsCD), typeof(AfterSpawnCleanup));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		EntityArchetype spawnEnvArchetypeLocal = _subAreaArchetype;
		WorldGenerationType worldGenerationType = __query_1259129973_2.GetSingleton<WorldGenerationTypeCD>().Value;
		if (worldGenerationType != WorldGenerationType.FullRelease)
		{
			LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Execute(ref ecb, ref spawnEnvArchetypeLocal, ref worldGenerationType);
			ComponentLookup<LegacySpawnEnvironmentObjectsInAreaCD> spawnEnvironmentObjectsInAreaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentLookup, ref base.CheckedStateRef);
			LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Execute(ref ecb, ref spawnEnvironmentObjectsInAreaLookup);
			base.OnUpdate();
		}
	}

	private void LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref EntityArchetype spawnEnvArchetypeLocal, ref WorldGenerationType worldGenerationType)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Job value = new LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Job
		{
			ecb = ecb,
			spawnEnvArchetypeLocal = spawnEnvArchetypeLocal,
			worldGenerationType = worldGenerationType,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__spawnEnvInAreaTypeHandle = __TypeHandle.__LegacySpawnEnvironmentObjectsInAreaCD_RW_ComponentTypeHandle,
			__areaTypeHandle = __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle
		};
		if (!__query_1259129973_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1259129973_0, jobPtr);
		}
		ecb = value.ecb;
		spawnEnvArchetypeLocal = value.spawnEnvArchetypeLocal;
		worldGenerationType = value.worldGenerationType;
	}

	private void LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Execute(ref EntityCommandBuffer ecb, ref ComponentLookup<LegacySpawnEnvironmentObjectsInAreaCD> spawnEnvironmentObjectsInAreaLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LegacySpawnEnvironmentObjectInNewAreaSystem_AfterSpawnCleanup_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Job value = new LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Job
		{
			ecb = ecb,
			spawnEnvironmentObjectsInAreaLookup = spawnEnvironmentObjectsInAreaLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__cleanupTypeHandle = __TypeHandle.__LegacySpawnEnvironmentObjectInNewAreaSystem_AfterSpawnCleanup_RO_ComponentTypeHandle
		};
		if (!__query_1259129973_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_1259129973_1, jobPtr);
		}
		ecb = value.ecb;
		spawnEnvironmentObjectsInAreaLookup = value.spawnEnvironmentObjectsInAreaLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LegacySpawnEnvironmentObjectsInAreaCD>();
		__query_1259129973_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<SpawnEnvironmentObjectsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AfterSpawnCleanup>();
		__query_1259129973_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1259129973_2 = entityQueryBuilder2.Build(ref state);
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
	public LegacySpawnEnvironmentObjectInNewAreaSystem()
	{
	}
}
