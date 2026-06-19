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
using Unity.Transforms;
using UnityEngine.Scripting;

namespace PugEntitiesUtil
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	public class SpawnCompanionsSystem : SystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct SpawnCompanionsSystem_79D12C75_LambdaJob_0_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00006D6B_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00006D6B_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00006D6B_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<CompanionEntityBuffer> __entityBufferTypeHandle;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<CompanionEntityBuffer> entityBuffer)
			{
				DynamicBuffer<CompanionInstantiatedEntityBuffer> dynamicBuffer = ecb.AddBuffer<CompanionInstantiatedEntityBuffer>(entity);
				for (int i = 0; i < entityBuffer.Length; i++)
				{
					dynamicBuffer.Add(new CompanionInstantiatedEntityBuffer
					{
						Value = ecb.Instantiate(entityBuffer[i].Value)
					});
					if (__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(entityBuffer[i].Value))
					{
						LocalTransform component = __Unity_Transforms_LocalTransform_ComponentLookup[entity];
						component.Position += entityBuffer[i].SpawnOffset;
						ecb.SetComponent(dynamicBuffer[i].Value, component);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<CompanionEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __entityBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i]);
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l]);
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00006D6B_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00006D6B_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SpawnCompanionsSystem_79D12C75_LambdaJob_0_Job>(jobPtr), ref query);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct SpawnCompanionsSystem_79D12C75_LambdaJob_1_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00006D6F_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00006D6F_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00006D6F_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<CompanionInstantiatedEntityBuffer> __instantiatedEntityBufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<CompanionInstantiatedEntityBuffer> instantiatedEntityBuffer)
			{
				ecb.RemoveComponent<CompanionInstantiatedEntityBuffer>(entity);
				for (int i = 0; i < instantiatedEntityBuffer.Length; i++)
				{
					ecb.DestroyEntity(instantiatedEntityBuffer[i].Value);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<CompanionInstantiatedEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __instantiatedEntityBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i]);
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l]);
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00006D6F_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00006D6F_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SpawnCompanionsSystem_79D12C75_LambdaJob_1_Job>(jobPtr), ref query);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct SpawnCompanionsSystem_79D12C75_LambdaJob_2_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00006D73_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00006D73_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00006D73_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

			public ComponentLookup<LocalTransform> localTransformLookup;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<CompanionInstantiatedEntityBuffer> __instantiatedEntityBufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<CompanionInstantiatedEntityBuffer> instantiatedEntityBuffer)
			{
				LocalTransform value = localTransformLookup[entity];
				for (int i = 0; i < instantiatedEntityBuffer.Length; i++)
				{
					Entity value2 = instantiatedEntityBuffer[i].Value;
					if (localTransformLookup.HasComponent(value2))
					{
						localTransformLookup[value2] = value;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<CompanionInstantiatedEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __instantiatedEntityBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i]);
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l]);
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00006D73_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00006D73_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SpawnCompanionsSystem_79D12C75_LambdaJob_2_Job>(jobPtr), ref query);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public BufferTypeHandle<CompanionEntityBuffer> __CompanionEntityBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public BufferTypeHandle<CompanionInstantiatedEntityBuffer> __PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle;

			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__CompanionEntityBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CompanionEntityBuffer>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CompanionInstantiatedEntityBuffer>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_378127872_0;

		private EntityQuery __query_378127872_1;

		private EntityQuery __query_378127872_2;

		[Preserve]
		protected override void OnUpdate()
		{
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			SpawnCompanionsSystem_79D12C75_LambdaJob_0_Execute(ref ecb);
			SpawnCompanionsSystem_79D12C75_LambdaJob_1_Execute(ref ecb);
			ComponentLookup<LocalTransform> localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref base.CheckedStateRef);
			SpawnCompanionsSystem_79D12C75_LambdaJob_2_Execute(ref localTransformLookup);
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
		}

		private void SpawnCompanionsSystem_79D12C75_LambdaJob_0_Execute(ref EntityCommandBuffer ecb)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__CompanionEntityBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
			SpawnCompanionsSystem_79D12C75_LambdaJob_0_Job value = new SpawnCompanionsSystem_79D12C75_LambdaJob_0_Job
			{
				ecb = ecb,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__entityBufferTypeHandle = __TypeHandle.__CompanionEntityBuffer_RO_BufferTypeHandle,
				__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup
			};
			if (!__query_378127872_0.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				SpawnCompanionsSystem_79D12C75_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_378127872_0, jobPtr);
			}
			ecb = value.ecb;
		}

		private void SpawnCompanionsSystem_79D12C75_LambdaJob_1_Execute(ref EntityCommandBuffer ecb)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			SpawnCompanionsSystem_79D12C75_LambdaJob_1_Job value = new SpawnCompanionsSystem_79D12C75_LambdaJob_1_Job
			{
				ecb = ecb,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__instantiatedEntityBufferTypeHandle = __TypeHandle.__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle
			};
			if (!__query_378127872_1.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				SpawnCompanionsSystem_79D12C75_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_378127872_1, jobPtr);
			}
			ecb = value.ecb;
		}

		private void SpawnCompanionsSystem_79D12C75_LambdaJob_2_Execute(ref ComponentLookup<LocalTransform> localTransformLookup)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			SpawnCompanionsSystem_79D12C75_LambdaJob_2_Job value = new SpawnCompanionsSystem_79D12C75_LambdaJob_2_Job
			{
				localTransformLookup = localTransformLookup,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__instantiatedEntityBufferTypeHandle = __TypeHandle.__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle
			};
			if (!__query_378127872_2.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				SpawnCompanionsSystem_79D12C75_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_378127872_2, jobPtr);
			}
			localTransformLookup = value.localTransformLookup;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<CompanionInstantiatedEntityBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<CompanionEntityBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_378127872_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<CompanionEntityBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<CompanionInstantiatedEntityBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_378127872_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<CompanionInstantiatedEntityBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<UpdateCompanionTranslationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_378127872_2 = entityQueryBuilder2.Build(ref state);
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
		public SpawnCompanionsSystem()
		{
		}
	}
}
