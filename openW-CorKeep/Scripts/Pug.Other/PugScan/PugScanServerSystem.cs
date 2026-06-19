using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

namespace PugScan
{
	[BurstCompile]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct PugScanServerSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct VerifyScannerAllowedJob : IJob
		{
			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> containedObjectBufferLookup;

			[ReadOnly]
			public ComponentLookup<ScannerCD> scannerLookup;

			[ReadOnly]
			public ComponentLookup<ConnectionAdminLevelCD> adminLevelLookup;

			public bool worldIsReadOnly;

			public NativeArray<ScanRequestCD> scanRequestCDs;

			public NativeList<PugScanReturnCode> returnCodes;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			public void Execute()
			{
				returnCodes.Resize(scanRequestCDs.Length, NativeArrayOptions.UninitializedMemory);
				for (int i = 0; i < returnCodes.Length; i++)
				{
					returnCodes[i] = PugScanReturnCode.NotFound;
				}
				for (int j = 0; j < scanRequestCDs.Length; j++)
				{
					ScanRequestCD scanRequestCD = scanRequestCDs[j];
					if (worldIsReadOnly && adminLevelLookup.GetAdminLevelOnServer(scanRequestCD.sourceConnectionEntity) <= 0)
					{
						returnCodes[j] = PugScanReturnCode.NotPermitted;
					}
					else
					{
						if (!scanRequestCD.consumeItemFromInventory)
						{
							continue;
						}
						if (!containedObjectBufferLookup.TryGetBuffer(scanRequestCD.inventory, out var bufferData))
						{
							returnCodes[j] = PugScanReturnCode.InventoryError;
							continue;
						}
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(bufferData[scanRequestCD.inventorySlot].objectData.objectID, databaseBankCD.databaseBankBlob);
						if (!scannerLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
						{
							returnCodes[j] = PugScanReturnCode.InventoryError;
						}
						else if (componentData.objectToScan != scanRequestCD.objectToScan.objectID)
						{
							returnCodes[j] = PugScanReturnCode.InventoryError;
						}
					}
				}
			}
		}

		[BurstCompile]
		[WithAll(new Type[] { typeof(Disabled) })]
		private struct ScanDisabledJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<CanBeScannedCD> __CanBeScannedCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__CanBeScannedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CanBeScannedCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__CanBeScannedCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CanBeScannedCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Disabled>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
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
				public void Run(ref ScanDisabledJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ScanDisabledJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ScanDisabledJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ScanDisabledJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ScanDisabledJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ScanDisabledJob job, EntityManager entityManager)
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

			[ReadOnly]
			public ComponentLookup<PugScanCD> pugScanLookup;

			public NativeArray<Entity> scanEntities;

			public NativeArray<ScanRequestCD> scanRequestCDs;

			public NativeArray<PugScanReturnCode> returnCodes;

			public EntityCommandBuffer ecb;

			public BufferLookup<ContainedObjectsBuffer> containedObjectBufferLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in CanBeScannedCD canBeScanned)
			{
				for (int i = 0; i < scanEntities.Length; i++)
				{
					PugScanCD pugScanCD = pugScanLookup[scanEntities[i]];
					if (!canBeScanned.objectData.Equals(pugScanCD.objectToScan))
					{
						continue;
					}
					bool flag = true;
					foreach (ScanRequestCD scanRequestCD in scanRequestCDs)
					{
						ObjectDataCD objectToScan = scanRequestCD.objectToScan;
						if (objectToScan.Equals(canBeScanned.objectData) && scanRequestCD.typeOfRequest == PugScanType.HideMarker)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						ecb.RemoveComponent<Disabled>(entity);
					}
					ecb.DestroyEntity(scanEntities[i]);
					return;
				}
				for (int j = 0; j < scanRequestCDs.Length; j++)
				{
					if (scanRequestCDs[j].typeOfRequest == PugScanType.Scan && (scanRequestCDs[j].mapMarkerToScan != entity || returnCodes[j] != PugScanReturnCode.NotFound || !scanRequestCDs[j].objectToScan.Equals(canBeScanned.objectData)))
					{
						continue;
					}
					if (scanRequestCDs[j].typeOfRequest == PugScanType.Summon)
					{
						if (scanRequestCDs[j].objectToScan.Equals(canBeScanned.objectData))
						{
							returnCodes[j] = PugScanReturnCode.AlreadyExists;
						}
					}
					else
					{
						if (scanRequestCDs[j].typeOfRequest == PugScanType.HideMarker)
						{
							continue;
						}
						if (scanRequestCDs[j].consumeItemFromInventory)
						{
							DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectBufferLookup[scanRequestCDs[j].inventory];
							ContainedObjectsBuffer value = dynamicBuffer[scanRequestCDs[j].inventorySlot];
							value.objectData.amount--;
							if (value.objectData.amount <= 0)
							{
								value = default(ContainedObjectsBuffer);
							}
							dynamicBuffer[scanRequestCDs[j].inventorySlot] = value;
						}
						ecb.RemoveComponent<Disabled>(entity);
						returnCodes[j] = PugScanReturnCode.Success;
						break;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__CanBeScannedCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, k));
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
		[WithNone(new Type[] { typeof(Disabled) })]
		private struct ScanEnabledJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<CanBeScannedCD> __CanBeScannedCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__CanBeScannedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CanBeScannedCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__CanBeScannedCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<Disabled>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<CanBeScannedCD>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
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
				public void Run(ref ScanEnabledJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ScanEnabledJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ScanEnabledJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ScanEnabledJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ScanEnabledJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ScanEnabledJob job, EntityManager entityManager)
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

			public NativeArray<ScanRequestCD> scanRequestCDs;

			public NativeArray<PugScanReturnCode> returnCodes;

			public EntityCommandBuffer ecb;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in CanBeScannedCD canBeScanned)
			{
				for (int i = 0; i < scanRequestCDs.Length; i++)
				{
					if (scanRequestCDs[i].typeOfRequest == PugScanType.HideMarker && scanRequestCDs[i].objectToScan.Equals(canBeScanned.objectData))
					{
						ecb.AddComponent<Disabled>(entity);
					}
					else if (scanRequestCDs[i].typeOfRequest == PugScanType.Summon && scanRequestCDs[i].objectToScan.Equals(canBeScanned.objectData))
					{
						returnCodes[i] = PugScanReturnCode.AlreadyExists;
					}
					else if (scanRequestCDs[i].typeOfRequest == PugScanType.Scan && returnCodes[i] == PugScanReturnCode.NotFound && scanRequestCDs[i].objectToScan.Equals(canBeScanned.objectData))
					{
						returnCodes[i] = PugScanReturnCode.AlreadyScanned;
						break;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__CanBeScannedCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr2, k));
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
		private struct SummonEntityJob : IJob
		{
			public BufferLookup<ContainedObjectsBuffer> containedObjectBufferLookup;

			public NativeArray<ScanRequestCD> scanRequestCDs;

			public NativeList<PugScanReturnCode> returnCodes;

			public EntityCommandBuffer ecb;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			[ReadOnly]
			public ComponentLookup<WallBossCD> wallBossLookup;

			public float worldScale;

			public void Execute()
			{
				for (int i = 0; i < scanRequestCDs.Length; i++)
				{
					ScanRequestCD scanRequestCD = scanRequestCDs[i];
					if (scanRequestCD.typeOfRequest != PugScanType.Summon || returnCodes[i] != PugScanReturnCode.NotFound)
					{
						continue;
					}
					float3 position = new float3(0f, 0f, 0f);
					if (scanRequestCD.objectToScan.objectID == ObjectID.WallBoss)
					{
						float num = 875f * worldScale;
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.WallBoss, databaseBankCD.databaseBankBlob);
						if (wallBossLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
						{
							num = componentData.distanceFromCore * worldScale;
						}
						float num2 = math.atan2(scanRequestCD.position.x, scanRequestCD.position.z);
						float num3 = -2f;
						float x = num2 + num3 * 0.0174533f;
						float z = math.cos(x) * num;
						float x2 = math.sin(x) * num;
						position = new float3(x2, 0f, z);
					}
					Entity e = EntityUtility.CreateEntity(ecb, scanRequestCD.objectToScan.objectID, 1, databaseBankCD.databaseBankBlob);
					ecb.SetComponent(e, LocalTransform.FromPosition(position));
					if (scanRequestCD.consumeItemFromInventory)
					{
						DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectBufferLookup[scanRequestCDs[i].inventory];
						ContainedObjectsBuffer value = dynamicBuffer[scanRequestCD.inventorySlot];
						value.objectData.amount--;
						if (value.objectData.amount <= 0)
						{
							value = default(ContainedObjectsBuffer);
						}
						dynamicBuffer[scanRequestCD.inventorySlot] = value;
					}
					returnCodes[i] = PugScanReturnCode.SuccessfullySpawned;
					break;
				}
			}
		}

		[BurstCompile]
		private struct SendScanResponseJob : IJob
		{
			public NativeArray<ScanRequestCD> scanRequestCDs;

			public NativeArray<PugScanReturnCode> returnCodes;

			public EntityArchetype responseRpcArchetype;

			public EntityCommandBuffer ecb;

			public void Execute()
			{
				for (int i = 0; i < scanRequestCDs.Length; i++)
				{
					if (scanRequestCDs[i].sendResponse)
					{
						Entity e = ecb.CreateEntity(responseRpcArchetype);
						ecb.SetComponent(e, new PugScanResponseRpc
						{
							code = returnCodes[i]
						});
						ecb.SetComponent(e, new SendRpcCommandRequest
						{
							TargetConnection = scanRequestCDs[i].sourceConnectionEntity
						});
					}
				}
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<ScannerCD> __ScannerCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_RO_ComponentLookup;

			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<PugScanCD> __PugScan_PugScanCD_RO_ComponentLookup;

			public ScanDisabledJob.InternalCompilerQueryAndHandleData __PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle;

			public ScanEnabledJob.InternalCompilerQueryAndHandleData __PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<WallBossCD> __WallBossCD_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
				__ScannerCD_RO_ComponentLookup = state.GetComponentLookup<ScannerCD>(isReadOnly: true);
				__ConnectionAdminLevelCD_RO_ComponentLookup = state.GetComponentLookup<ConnectionAdminLevelCD>(isReadOnly: true);
				__ContainedObjectsBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
				__PugScan_PugScanCD_RO_ComponentLookup = state.GetComponentLookup<PugScanCD>(isReadOnly: true);
				__PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__WallBossCD_RO_ComponentLookup = state.GetComponentLookup<WallBossCD>(isReadOnly: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_00006E96_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00006E96_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00006E96_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery _scanQuery;

		private EntityQuery _scanRequestQuery;

		private EntityArchetype _responseRpcArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_80437353_0;

		private EntityQuery __query_80437353_1;

		private EntityQuery __query_80437353_2;

		private EntityQuery __query_80437353_3;

		private EntityQuery __query_80437353_4;

		private EntityQuery __query_80437353_5;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<WorldScaleCD>();
			_scanQuery = __query_80437353_0;
			_scanRequestQuery = __query_80437353_1;
			_responseRpcArchetype = state.EntityManager.CreateArchetype(typeof(PugScanResponseRpc), typeof(SendRpcCommandRequest));
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			if (!_scanRequestQuery.IsEmpty || !_scanQuery.IsEmpty)
			{
				BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_80437353_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
				EntityCommandBuffer ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged);
				PugDatabase.DatabaseBankCD singleton2 = __query_80437353_3.GetSingleton<PugDatabase.DatabaseBankCD>();
				JobHandle outJobHandle;
				NativeList<Entity> nativeList = _scanQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
				JobHandle outJobHandle2;
				NativeList<ScanRequestCD> nativeList2 = _scanRequestQuery.ToComponentDataListAsync<ScanRequestCD>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle2);
				NativeList<PugScanReturnCode> returnCodes = new NativeList<PugScanReturnCode>(8, state.WorldUpdateAllocator);
				state.Dependency = JobHandle.CombineDependencies(outJobHandle, outJobHandle2, state.Dependency);
				state.Dependency = IJobExtensions.Schedule(new VerifyScannerAllowedJob
				{
					containedObjectBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
					scannerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScannerCD_RO_ComponentLookup, ref state),
					adminLevelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup, ref state),
					worldIsReadOnly = __query_80437353_4.GetSingleton<WorldInfoCD>().guestMode,
					scanRequestCDs = nativeList2.AsDeferredJobArray(),
					returnCodes = returnCodes,
					databaseBankCD = singleton2
				}, state.Dependency);
				state.Dependency = __ScheduleViaJobChunkExtension_0(new ScanDisabledJob
				{
					containedObjectBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref state),
					pugScanLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PugScan_PugScanCD_RO_ComponentLookup, ref state),
					scanEntities = nativeList.AsDeferredJobArray(),
					scanRequestCDs = nativeList2.AsDeferredJobArray(),
					returnCodes = returnCodes.AsDeferredJobArray(),
					ecb = ecb
				}, __TypeHandle.__PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				state.Dependency = __ScheduleViaJobChunkExtension_1(new ScanEnabledJob
				{
					scanRequestCDs = nativeList2.AsDeferredJobArray(),
					returnCodes = returnCodes.AsDeferredJobArray(),
					ecb = ecb
				}, __TypeHandle.__PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				state.Dependency = IJobExtensions.Schedule(new SummonEntityJob
				{
					containedObjectBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref state),
					scanRequestCDs = nativeList2.AsDeferredJobArray(),
					returnCodes = returnCodes,
					ecb = ecb,
					databaseBankCD = singleton2,
					wallBossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WallBossCD_RO_ComponentLookup, ref state),
					worldScale = __query_80437353_5.GetSingleton<WorldScaleCD>().Value
				}, state.Dependency);
				state.Dependency = IJobExtensions.Schedule(new SendScanResponseJob
				{
					ecb = ecb,
					scanRequestCDs = nativeList2.AsDeferredJobArray(),
					returnCodes = returnCodes.AsDeferredJobArray(),
					responseRpcArchetype = _responseRpcArchetype
				}, state.Dependency);
				singleton.CreateCommandBuffer(state.WorldUnmanaged).DestroyEntity(_scanRequestQuery, EntityQueryCaptureMode.AtRecord);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ScanDisabledJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugScan_PugScanServerSystem_ScanDisabledJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(ScanEnabledJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugScan_PugScanServerSystem_ScanEnabledJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugScanCD>();
			__query_80437353_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ScanRequestCD>();
			__query_80437353_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_80437353_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_80437353_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_80437353_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldScaleCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_80437353_5 = entityQueryBuilder2.Build(ref state);
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
			((PugScanServerSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00006E96_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugScanServerSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugScanServerSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
