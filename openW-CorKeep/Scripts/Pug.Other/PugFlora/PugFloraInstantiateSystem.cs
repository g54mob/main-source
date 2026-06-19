using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace PugFlora
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class PugFloraInstantiateSystem : PugSimulationSystemBase
	{
		public struct PugFloraBlockingEntityRefCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
		{
			public Entity Value;
		}

		[BurstCompile]
		private struct PugFloraCreateBlockingEntityJob : IJobChunk
		{
			public EntityCommandBuffer Ecb;

			[ReadOnly]
			public NativeArray<Entity> BlockingEntities;

			[ReadOnly]
			public EntityTypeHandle Entity;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> LocalTransform;

			public ComponentLookup<PugFloraBlockingCD> PugFloraBlockingLookup;

			[ReadOnly]
			public NativeArray<int> chunkBaseEntityIndices;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				int num = chunkBaseEntityIndices[unfilteredChunkIndex];
				NativeArray<Entity> nativeArray = chunk.GetNativeArray(Entity);
				NativeArray<LocalTransform> nativeArray2 = chunk.GetNativeArray(LocalTransform);
				int num2 = 0;
				ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex;
				while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
				{
					Entity entity = BlockingEntities[num + num2];
					PugFloraBlockingLookup[entity] = new PugFloraBlockingCD
					{
						position = nativeArray2[nextIndex].Position.RoundToInt2()
					};
					Ecb.AddComponent(nativeArray[nextIndex], new PugFloraBlockingEntityRefCD
					{
						Value = entity
					});
					num2++;
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct DestroyBlockingWithDestroyed_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00006F85_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00006F85_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00006F85_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

			[ReadOnly]
			public ComponentTypeHandle<PugFloraBlockingEntityRefCD> __entityRefTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in PugFloraBlockingEntityRefCD entityRef)
			{
				ecb.DestroyEntity(entityRef.Value);
				ecb.RemoveComponent<PugFloraBlockingEntityRefCD>(entity);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __entityRefTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00006F85_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00006F85_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<DestroyBlockingWithDestroyed_Job>(jobPtr), ref query);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct DestroyBlockingIsDestroyed_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00006F89_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00006F89_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00006F89_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

			[ReadOnly]
			public ComponentTypeHandle<PugFloraBlockingEntityRefCD> __entityRefTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in PugFloraBlockingEntityRefCD entityRef)
			{
				ecb.DestroyEntity(entityRef.Value);
				ecb.RemoveComponent<PugFloraBlockingEntityRefCD>(entity);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __entityRefTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingEntityRefCD>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00006F89_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00006F89_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<DestroyBlockingIsDestroyed_Job>(jobPtr), ref query);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<PugFloraBlockingEntityRefCD> __PugFlora_PugFloraInstantiateSystem_PugFloraBlockingEntityRefCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

			public ComponentLookup<PugFloraBlockingCD> __PugFlora_PugFloraBlockingCD_RW_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugFlora_PugFloraInstantiateSystem_PugFloraBlockingEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugFloraBlockingEntityRefCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				__PugFlora_PugFloraBlockingCD_RW_ComponentLookup = state.GetComponentLookup<PugFloraBlockingCD>();
			}
		}

		private EntityQuery _addPugFloraBlockingQuery;

		private EntityArchetype _blockingArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_738357218_0;

		private EntityQuery __query_738357218_1;

		private EntityQuery __query_738357218_2;

		[Preserve]
		protected override void OnCreate()
		{
			UpdatesInRunGroup();
			_blockingArchetype = base.EntityManager.CreateArchetype(typeof(PugFloraBlockingCD));
			EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
			entityQueryDesc.All = new ComponentType[2]
			{
				typeof(LocalTransform),
				typeof(BlocksFlora)
			};
			entityQueryDesc.None = new ComponentType[4]
			{
				typeof(PugFloraBlockingEntityRefCD),
				typeof(PhysicsVelocity),
				typeof(EntityDestroyedCD),
				typeof(TileCD)
			};
			entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
			EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
			_addPugFloraBlockingQuery = base.EntityManager.CreateEntityQuery(entityQueryDesc2);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			NetworkTime singleton = __query_738357218_2.GetSingleton<NetworkTime>();
			if (!VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, singleton, 13, 1f))
			{
				base.OnUpdate();
				return;
			}
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);
			if (!_addPugFloraBlockingQuery.IsEmpty)
			{
				NativeArray<Entity> blockingEntities = base.EntityManager.CreateEntity(_blockingArchetype, _addPugFloraBlockingQuery.CalculateEntityCount(), Allocator.TempJob);
				NativeArray<int> chunkBaseEntityIndices = _addPugFloraBlockingQuery.CalculateBaseEntityIndexArray(Allocator.TempJob);
				JobChunkExtensions.Run(new PugFloraCreateBlockingEntityJob
				{
					Ecb = ecb,
					Entity = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref base.CheckedStateRef),
					LocalTransform = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle, ref base.CheckedStateRef),
					BlockingEntities = blockingEntities,
					PugFloraBlockingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PugFlora_PugFloraBlockingCD_RW_ComponentLookup, ref base.CheckedStateRef),
					chunkBaseEntityIndices = chunkBaseEntityIndices
				}, _addPugFloraBlockingQuery);
				chunkBaseEntityIndices.Dispose();
				blockingEntities.Dispose();
			}
			DestroyBlockingWithDestroyed_Execute(ref ecb);
			DestroyBlockingIsDestroyed_Execute(ref ecb);
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
			base.OnUpdate();
		}

		private void DestroyBlockingWithDestroyed_Execute(ref EntityCommandBuffer ecb)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugFlora_PugFloraInstantiateSystem_PugFloraBlockingEntityRefCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			DestroyBlockingWithDestroyed_Job value = new DestroyBlockingWithDestroyed_Job
			{
				ecb = ecb,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__entityRefTypeHandle = __TypeHandle.__PugFlora_PugFloraInstantiateSystem_PugFloraBlockingEntityRefCD_RO_ComponentTypeHandle
			};
			if (!__query_738357218_0.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				DestroyBlockingWithDestroyed_Job.RunWithoutJobSystem(ref __query_738357218_0, jobPtr);
			}
			ecb = value.ecb;
		}

		private void DestroyBlockingIsDestroyed_Execute(ref EntityCommandBuffer ecb)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugFlora_PugFloraInstantiateSystem_PugFloraBlockingEntityRefCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			DestroyBlockingIsDestroyed_Job value = new DestroyBlockingIsDestroyed_Job
			{
				ecb = ecb,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__entityRefTypeHandle = __TypeHandle.__PugFlora_PugFloraInstantiateSystem_PugFloraBlockingEntityRefCD_RO_ComponentTypeHandle
			};
			if (!__query_738357218_1.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				DestroyBlockingIsDestroyed_Job.RunWithoutJobSystem(ref __query_738357218_1, jobPtr);
			}
			ecb = value.ecb;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugFloraBlockingEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<BlocksFlora>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_738357218_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<BlocksFlora>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugFloraBlockingEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_738357218_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_738357218_2 = entityQueryBuilder2.Build(ref state);
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
		public PugFloraInstantiateSystem()
		{
		}
	}
}
