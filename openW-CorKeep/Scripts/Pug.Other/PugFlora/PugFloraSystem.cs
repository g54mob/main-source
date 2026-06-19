using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine.Scripting;

namespace PugFlora
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public struct PugFloraSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		public struct Grower
		{
			public Entity entity;

			public FixedList64Bytes<Tileset> tilesets;

			public bool blocked;
		}

		[BurstCompile]
		private struct GrowerTimerJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<PugFloraGrowerCD> __PugFloraGrowerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PugFloraGrowerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PugFloraGrowerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PugFloraGrowerCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAllRW<PugFloraGrowerCD>().Build(ref state);
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
				public void Run(ref GrowerTimerJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref GrowerTimerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref GrowerTimerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref GrowerTimerJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref GrowerTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref GrowerTimerJob job, EntityManager entityManager)
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

			public NativeParallelMultiHashMap<int2, Grower> growersThisFrame;

			public EntityCommandBuffer ecb;

			public bool forceGrowLocal;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref PugFloraGrowerCD grower)
			{
				grower.timer--;
				if (grower.timer <= 0 || forceGrowLocal)
				{
					growersThisFrame.Add(grower.position, new Grower
					{
						entity = grower.entity,
						tilesets = grower.tilesets,
						blocked = false
					});
					ecb.DestroyEntity(entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PugFloraGrowerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraGrowerCD>(nativeArrayPtr2, i));
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
							Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraGrowerCD>(nativeArrayPtr2, nextRangeBegin));
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
						Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraGrowerCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraGrowerCD>(nativeArrayPtr2, k));
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
		private struct BlockGrowersJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<PugFloraBlockingCD> __PugFlora_PugFloraBlockingCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PugFlora_PugFloraBlockingCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugFloraBlockingCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__PugFlora_PugFloraBlockingCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAll<PugFloraBlockingCD>().Build(ref state);
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
				public void Run(ref BlockGrowersJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref BlockGrowersJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref BlockGrowersJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref BlockGrowersJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref BlockGrowersJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref BlockGrowersJob job, EntityManager entityManager)
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

			public NativeParallelMultiHashMap<int2, Grower> growersThisFrame;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in PugFloraBlockingCD block)
			{
				if (growersThisFrame.TryGetFirstValue(block.position, out var item, out var it))
				{
					NativeList<Grower> nativeList = new NativeList<Grower>(Allocator.Temp);
					do
					{
						item.blocked = true;
						nativeList.Add(in item);
					}
					while (growersThisFrame.TryGetNextValue(out item, ref it));
					growersThisFrame.Remove(block.position);
					for (int i = 0; i < nativeList.Length; i++)
					{
						growersThisFrame.Add(block.position, nativeList[i]);
					}
					nativeList.Dispose();
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugFlora_PugFloraBlockingCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingCD>(nativeArrayPtr, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingCD>(nativeArrayPtr, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingCD>(nativeArrayPtr, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraBlockingCD>(nativeArrayPtr, k));
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
		private struct FloraGrowJob : IJob
		{
			public NativeParallelMultiHashMap<int2, Grower> growersThisFrame;

			public TileAccessor tileLookup;

			[ReadOnly]
			public CollisionWorld collisionWorld;

			public EntityCommandBuffer ecb;

			public Unity.Mathematics.Random rng;

			public void Execute()
			{
				NativeKeyValueArrays<int2, Grower> keyValueArrays = growersThisFrame.GetKeyValueArrays(Allocator.Temp);
				NativeParallelHashSet<Entity> nativeParallelHashSet = new NativeParallelHashSet<Entity>(keyValueArrays.Length * 2, Allocator.Temp);
				int num = keyValueArrays.Length;
				for (int i = 0; i < num; i++)
				{
					nativeParallelHashSet.Add(keyValueArrays.Values[i].entity);
				}
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					if (keyValueArrays.Values[num2].blocked)
					{
						num--;
						ref NativeArray<int2> keys = ref keyValueArrays.Keys;
						int index = num2;
						ref NativeArray<int2> keys2 = ref keyValueArrays.Keys;
						int index2 = num;
						int2 int5 = keyValueArrays.Keys[num];
						int2 int6 = keyValueArrays.Keys[num2];
						int2 int7 = (keys[index] = int5);
						int7 = (keys2[index2] = int6);
						ref NativeArray<Grower> values = ref keyValueArrays.Values;
						index2 = num2;
						ref NativeArray<Grower> values2 = ref keyValueArrays.Values;
						index = num;
						Grower grower = keyValueArrays.Values[num];
						Grower grower2 = keyValueArrays.Values[num2];
						Grower grower3 = (values[index2] = grower);
						grower3 = (values2[index] = grower2);
					}
				}
				for (int num3 = num - 1; num3 >= 0; num3--)
				{
					TileCD top = tileLookup.GetTop(keyValueArrays.Keys[num3]);
					if (top.tileType.CanGrowOn())
					{
						int j;
						for (j = 0; j < keyValueArrays.Values[num3].tilesets.Length && keyValueArrays.Values[num3].tilesets[j] != (Tileset)top.tileset; j++)
						{
						}
						if (j == 0 || j != keyValueArrays.Values[num3].tilesets.Length)
						{
							continue;
						}
					}
					num--;
					ref NativeArray<int2> keys3 = ref keyValueArrays.Keys;
					int index = num3;
					ref NativeArray<int2> keys2 = ref keyValueArrays.Keys;
					int index2 = num;
					int2 int6 = keyValueArrays.Keys[num];
					int2 int5 = keyValueArrays.Keys[num3];
					int2 int7 = (keys3[index] = int6);
					int7 = (keys2[index2] = int5);
					ref NativeArray<Grower> values3 = ref keyValueArrays.Values;
					index2 = num3;
					ref NativeArray<Grower> values2 = ref keyValueArrays.Values;
					index = num;
					Grower grower2 = keyValueArrays.Values[num];
					Grower grower = keyValueArrays.Values[num3];
					Grower grower3 = (values3[index2] = grower2);
					grower3 = (values2[index] = grower);
				}
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 131935u
				};
				for (int num4 = num - 1; num4 >= 0; num4--)
				{
					if (collisionWorld.CheckSphere(keyValueArrays.Keys[num4].ToFloat3(), 0.49f, filter))
					{
						num--;
						ref NativeArray<int2> keys4 = ref keyValueArrays.Keys;
						int index = num4;
						ref NativeArray<int2> keys2 = ref keyValueArrays.Keys;
						int index2 = num;
						int2 int5 = keyValueArrays.Keys[num];
						int2 int6 = keyValueArrays.Keys[num4];
						int2 int7 = (keys4[index] = int5);
						int7 = (keys2[index2] = int6);
						ref NativeArray<Grower> values4 = ref keyValueArrays.Values;
						index2 = num4;
						ref NativeArray<Grower> values2 = ref keyValueArrays.Values;
						index = num;
						Grower grower = keyValueArrays.Values[num];
						Grower grower2 = keyValueArrays.Values[num4];
						Grower grower3 = (values4[index2] = grower);
						grower3 = (values2[index] = grower2);
					}
				}
				for (int k = 0; k < num; k++)
				{
					for (int num5 = num - 1; num5 > k; num5--)
					{
						if (!(keyValueArrays.Values[k].entity != keyValueArrays.Values[num5].entity))
						{
							ref NativeArray<int2> keys2;
							int2 int5;
							int2 int6;
							int2 int7;
							int index2;
							ref NativeArray<Grower> values2;
							int index;
							Grower grower;
							Grower grower2;
							Grower grower3;
							if (rng.NextBool())
							{
								ref NativeArray<int2> keys5 = ref keyValueArrays.Keys;
								index = k;
								keys2 = ref keyValueArrays.Keys;
								index2 = num5;
								int6 = keyValueArrays.Keys[num5];
								int5 = keyValueArrays.Keys[k];
								int7 = (keys5[index] = int6);
								int7 = (keys2[index2] = int5);
								ref NativeArray<Grower> values5 = ref keyValueArrays.Values;
								index2 = k;
								values2 = ref keyValueArrays.Values;
								index = num5;
								grower2 = keyValueArrays.Values[num5];
								grower = keyValueArrays.Values[k];
								grower3 = (values5[index2] = grower2);
								grower3 = (values2[index] = grower);
							}
							num--;
							ref NativeArray<int2> keys6 = ref keyValueArrays.Keys;
							index = num5;
							keys2 = ref keyValueArrays.Keys;
							index2 = num;
							int5 = keyValueArrays.Keys[num];
							int6 = keyValueArrays.Keys[num5];
							int7 = (keys6[index] = int5);
							int7 = (keys2[index2] = int6);
							ref NativeArray<Grower> values6 = ref keyValueArrays.Values;
							index2 = num5;
							values2 = ref keyValueArrays.Values;
							index = num;
							grower = keyValueArrays.Values[num];
							grower2 = keyValueArrays.Values[num5];
							grower3 = (values6[index2] = grower);
							grower3 = (values2[index] = grower2);
						}
					}
				}
				for (int l = 0; l < num; l++)
				{
					ecb.AddComponent(keyValueArrays.Values[l].entity, new PugFloraDoGrowCD
					{
						position = keyValueArrays.Keys[l]
					});
					nativeParallelHashSet.Remove(keyValueArrays.Values[l].entity);
				}
				using NativeArray<Entity> nativeArray = nativeParallelHashSet.ToNativeArray(Allocator.Temp);
				for (int m = 0; m < nativeArray.Length; m++)
				{
					ecb.AddComponent(nativeArray[m], new PugFloraDoGrowCD
					{
						initialize = true
					});
				}
				nativeParallelHashSet.Dispose();
				keyValueArrays.Dispose();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct ForceGrowKey
		{
		}

		private struct TypeHandle
		{
			public GrowerTimerJob.InternalCompilerQueryAndHandleData __PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle;

			public BlockGrowersJob.InternalCompilerQueryAndHandleData __PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00006F96_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00006F96_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00006F96_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
				__codegen__OnCreate_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_00006F97_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00006F97_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00006F97_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private static readonly SharedStatic<bool> forceGrow = SharedStatic<bool>.GetOrCreateUnsafe(0u, 6936765740278950476L, 0L);

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_4194153_0;

		private EntityQuery __query_4194153_1;

		[Preserve]
		[Conditional("UNITY_EDITOR")]
		[Conditional("FORCE_DEBUG_MODE")]
		[Conditional("PUG_MARKETING_BUILD")]
		[Command("growAllRoots", "Make all roots grow immediately.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void ForceGrowAllPlants()
		{
			forceGrow.Data = true;
		}

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
		}

		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			Unity.Mathematics.Random rng = PugRandom.GetRng();
			EntityCommandBuffer ecb = __query_4194153_0.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			_tileAccessor.Update(ref state);
			NativeParallelMultiHashMap<int2, Grower> growersThisFrame = new NativeParallelMultiHashMap<int2, Grower>(256, state.WorldUpdateAllocator);
			bool data = forceGrow.Data;
			forceGrow.Data = false;
			state.Dependency = __ScheduleViaJobChunkExtension_0(new GrowerTimerJob
			{
				growersThisFrame = growersThisFrame,
				ecb = ecb,
				forceGrowLocal = data
			}, __TypeHandle.__PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new BlockGrowersJob
			{
				growersThisFrame = growersThisFrame
			}, __TypeHandle.__PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = IJobExtensions.Schedule(new FloraGrowJob
			{
				growersThisFrame = growersThisFrame,
				tileLookup = _tileAccessor,
				collisionWorld = __query_4194153_1.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				ecb = ecb,
				rng = rng
			}, state.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(GrowerTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugFlora_PugFloraSystem_GrowerTimerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(BlockGrowersJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugFlora_PugFloraSystem_BlockGrowersJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_4194153_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_4194153_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			__codegen__OnCreate_00006F96_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00006F97_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((PugFloraSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((PugFloraSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugFloraSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugFloraSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugFloraSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
