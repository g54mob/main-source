using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.Automation;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class EventTerminalSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct AlwaysActiveConnectionsInitialized : IComponentData, IQueryTypeParameter
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TerminalFullyInitialized : IComponentData, IQueryTypeParameter
	{
	}

	public struct EndTerminalEvent : IComponentData, IQueryTypeParameter
	{
		public bool completed;

		public float timer;
	}

	[NoAlias]
	[BurstCompile]
	private struct EventTerminalSystem_5B58F4C8_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00001D8D_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00001D8D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00001D8D_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public EntityCommandBuffer ecb;

		public EntityArchetype electricityEntityArchetypeLocal;

		[ReadOnly]
		public NativeList<ConnectionAndDirection> allConnectionTypesLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<NearbyEntitiesTrackerCD> __nearbyTrackerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EventTerminalCD> __eventTerminalTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		public BufferTypeHandle<AlwaysActiveConnectionsBuffer> __alwaysActiveConnectionsTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref NearbyEntitiesTrackerCD nearbyTracker, [NoAlias] in LocalTransform transform, [NoAlias] in EventTerminalCD eventTerminal, [NoAlias] in ObjectDataCD objectData, DynamicBuffer<AlwaysActiveConnectionsBuffer> alwaysActiveConnections)
		{
			nearbyTracker.radius = eventTerminal.radius;
			int2 size = PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseLocal).prefabTileSize - new int2(1, 1);
			for (int i = 0; i < allConnectionTypesLocal.Length; i++)
			{
				CreateElectricityEntity(ecb, entity, electricityEntityArchetypeLocal, transform.Position, size, alwaysActiveConnections, allConnectionTypesLocal[i], onlyCreateAlwaysActiveConnections: true, out var result);
				ecb.AppendToBuffer(entity, result);
			}
			ecb.AddComponent<AlwaysActiveConnectionsInitialized>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __nearbyTrackerTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __eventTerminalTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			BufferAccessor<AlwaysActiveConnectionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __alwaysActiveConnectionsTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr5, i), bufferAccessor[i]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr5, j), bufferAccessor[j]);
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr5, k), bufferAccessor[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr5, l), bufferAccessor[l]);
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00001D8D_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00001D8D_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<EventTerminalSystem_5B58F4C8_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct EventTerminalSystem_5B58F4C8_LambdaJob_1_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00001D91_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00001D91_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00001D91_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public EntityCommandBuffer ecb;

		public double time;

		public float deltaTime;

		public EntityArchetype keepAreaEnabledArchetypeLocal;

		public EntityArchetype electricityEntityArchetypeLocal;

		public EntityArchetype triggerelectricityEntityArchetypeLocal;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public NativeList<ConnectionAndDirection> allConnectionTypesLocal;

		public int playerCount;

		public ComponentLookup<ElectricitySourceCD> electricitySourceLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<EventTerminalCD> __eventTerminalTypeHandle;

		public BufferTypeHandle<EventTerminalElectricityEntityBuffer> __electricityEntitiesTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		public BufferTypeHandle<EventTerminalSequenceBuffer> __sequenceTypeHandle;

		public BufferTypeHandle<AlwaysActiveConnectionsBuffer> __alwaysActiveConnectionsTypeHandle;

		public BufferTypeHandle<NearbyEntitiesBufferCD> __nearbyEntitiesTypeHandle;

		[ReadOnly]
		public ComponentLookup<TerminalFullyInitialized> __EventTerminalSystem_TerminalFullyInitialized_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MusicAreaCD> __MusicAreaCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemySpawnerPlatformCD> __EnemySpawnerPlatformCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ElectricitySourceCD> __Pug_Automation_ElectricitySourceCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref EventTerminalCD eventTerminal, DynamicBuffer<EventTerminalElectricityEntityBuffer> electricityEntities, [NoAlias] in LocalTransform transform, DynamicBuffer<EventTerminalSequenceBuffer> sequence, DynamicBuffer<AlwaysActiveConnectionsBuffer> alwaysActiveConnections, DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (sequence.Length < 1)
			{
				return;
			}
			if (!__EventTerminalSystem_TerminalFullyInitialized_ComponentLookup.HasComponent(entity))
			{
				int2 size = PugDatabase.GetEntityObjectInfo(__ObjectDataCD_ComponentLookup[entity].objectID, databaseLocal).prefabTileSize - new int2(1, 1);
				NativeList<EventTerminalElectricityEntityBuffer> nativeList = new NativeList<EventTerminalElectricityEntityBuffer>(Allocator.Temp);
				for (int i = 0; i < electricityEntities.Length; i++)
				{
					nativeList.Add(electricityEntities[i]);
				}
				electricityEntities.Clear();
				for (int j = 0; j < allConnectionTypesLocal.Length; j++)
				{
					if (CreateElectricityEntity(ecb, entity, electricityEntityArchetypeLocal, transform.Position, size, alwaysActiveConnections, allConnectionTypesLocal[j], onlyCreateAlwaysActiveConnections: false, out var result))
					{
						ecb.AppendToBuffer(entity, result);
					}
					else
					{
						ecb.AppendToBuffer(entity, nativeList[j]);
					}
				}
				nativeList.Dispose();
				ecb.AddComponent<TerminalFullyInitialized>(entity);
				return;
			}
			if (!eventTerminal.terminalIsActive)
			{
				eventTerminal.terminalIsActive = true;
				eventTerminal.timer = eventTerminal.duration * 3f / 4f;
				eventTerminal.currentElementTime = (float)time;
				if (__MusicAreaCD_ComponentLookup.HasComponent(entity))
				{
					MusicAreaCD component = __MusicAreaCD_ComponentLookup[entity];
					component.isInactive = false;
					ecb.SetComponent(entity, component);
				}
				Entity e = ecb.CreateEntity(keepAreaEnabledArchetypeLocal);
				ecb.SetComponent(e, new EnableEntitiesInCircleCD
				{
					Center = transform.Position.RoundToInt2(),
					Radius = eventTerminal.radius + 5f
				});
				ecb.SetComponent(e, new EnableEntitiesTimerCD
				{
					RemainingTime = eventTerminal.duration + 5f
				});
			}
			DistanceToPlayerCD distanceToPlayerCD = __DistanceToPlayerCD_ComponentLookup[entity];
			eventTerminal.anyPlayerIsInsideZone = distanceToPlayerCD.minDistanceSq < eventTerminal.radiusSq;
			bool flag = distanceToPlayerCD.minDistanceSq > 1600f;
			int num = 0;
			for (int k = 0; k < nearbyEntities.Length; k++)
			{
				if (__PlayerGhost_ComponentLookup.HasComponent(nearbyEntities[k].entity))
				{
					num++;
				}
			}
			int num2 = math.max(eventTerminal.anyPlayerIsInsideZone ? 1 : 0, num);
			eventTerminal.timerSpeed = ((num2 == 0) ? 0f : ((num2 < math.max(1, playerCount)) ? 0.5f : 1f));
			if (!eventTerminal.anyPlayerIsInsideZone)
			{
				eventTerminal.timer += deltaTime;
				eventTerminal.timer = math.min(eventTerminal.timer, eventTerminal.duration);
				if (eventTerminal.timer >= eventTerminal.duration)
				{
					flag = true;
				}
			}
			else
			{
				eventTerminal.timer -= deltaTime * eventTerminal.timerSpeed;
			}
			if ((flag || eventTerminal.timer < 2f) && __MusicAreaCD_ComponentLookup.HasComponent(entity))
			{
				MusicAreaCD component2 = __MusicAreaCD_ComponentLookup[entity];
				if (!component2.isInactive)
				{
					component2.isInactive = true;
					ecb.SetComponent(entity, component2);
				}
			}
			if (flag || eventTerminal.timer <= 0f)
			{
				ecb.AddComponent(entity, new EndTerminalEvent
				{
					completed = !flag,
					timer = (flag ? 0f : 2f)
				});
				ecb.RemoveComponent<TerminalActiveCD>(entity);
				eventTerminal.terminalIsActive = false;
				eventTerminal.timer = 0f;
				eventTerminal.prevSequenceIndex = -1;
				eventTerminal.currentSequenceIndex = 0;
				NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collisionWorld.SphereCastAll(transform.Position, eventTerminal.radius, float3.zero, 0f, ref outHits, new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 512u
				}))
				{
					for (int l = 0; l < outHits.Length; l++)
					{
						Entity entity2 = outHits[l].Entity;
						if (__ObjectDataCD_ComponentLookup.HasComponent(entity2) && __EnemySpawnerPlatformCD_ComponentLookup.HasComponent(entity2))
						{
							EnemySpawnerPlatformCD component3 = __EnemySpawnerPlatformCD_ComponentLookup[entity2];
							component3.timer.Stop();
							component3.isSpawning = false;
							ecb.SetComponent(entity2, component3);
						}
					}
				}
				outHits.Dispose();
				for (int m = 0; m < electricityEntities.Length; m++)
				{
					EventTerminalElectricityEntityBuffer value = electricityEntities[m];
					if (value.isActive && !value.keepConnectionActive)
					{
						value.isActive = false;
						ElectricitySourceCD component4 = __Pug_Automation_ElectricitySourceCD_ComponentLookup[electricityEntities[m].entity];
						component4.sourceEnergy = 0;
						ecb.SetComponent(electricityEntities[m].entity, component4);
						Entity e2 = ecb.CreateEntity(triggerelectricityEntityArchetypeLocal);
						ecb.SetComponent(e2, new ElectricityTriggerUpdateNearbyCD
						{
							position = transform.Position.RoundToInt2()
						});
						electricityEntities[m] = value;
					}
				}
			}
			else
			{
				if (!eventTerminal.terminalIsActive)
				{
					return;
				}
				int currentSequenceIndex = eventTerminal.currentSequenceIndex;
				while ((double)eventTerminal.currentElementTime <= time)
				{
					if (eventTerminal.prevSequenceIndex >= 0)
					{
						EventTerminalSequenceBuffer eventTerminalSequenceBuffer = sequence[eventTerminal.prevSequenceIndex];
						if (eventTerminalSequenceBuffer.action == EventTerminalAction.Hold)
						{
							SetConnectionsEnabled(ecb, electricitySourceLookup, triggerelectricityEntityArchetypeLocal, eventTerminalSequenceBuffer.target, value: false, ref electricityEntities, in transform);
						}
					}
					EventTerminalSequenceBuffer eventTerminalSequenceBuffer2 = sequence[eventTerminal.currentSequenceIndex];
					switch (eventTerminalSequenceBuffer2.action)
					{
					case EventTerminalAction.ToggleOn:
					case EventTerminalAction.Hold:
						SetConnectionsEnabled(ecb, electricitySourceLookup, triggerelectricityEntityArchetypeLocal, eventTerminalSequenceBuffer2.target, value: true, ref electricityEntities, in transform);
						break;
					case EventTerminalAction.ToggleOff:
						SetConnectionsEnabled(ecb, electricitySourceLookup, triggerelectricityEntityArchetypeLocal, eventTerminalSequenceBuffer2.target, value: false, ref electricityEntities, in transform);
						break;
					}
					eventTerminal.currentElementTime += eventTerminalSequenceBuffer2.duration;
					eventTerminal.prevSequenceIndex = eventTerminal.currentSequenceIndex;
					eventTerminal.currentSequenceIndex++;
					if (eventTerminal.currentSequenceIndex >= sequence.Length)
					{
						eventTerminal.currentSequenceIndex = eventTerminal.loopIndex;
					}
					if (eventTerminal.currentSequenceIndex == currentSequenceIndex)
					{
						break;
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __eventTerminalTypeHandle);
			BufferAccessor<EventTerminalElectricityEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __electricityEntitiesTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			BufferAccessor<EventTerminalSequenceBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __sequenceTypeHandle);
			BufferAccessor<AlwaysActiveConnectionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __alwaysActiveConnectionsTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor4 = chunk.GetBufferAccessor(ref __nearbyEntitiesTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), bufferAccessor2[i], bufferAccessor3[i], bufferAccessor4[i]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), bufferAccessor2[j], bufferAccessor3[j], bufferAccessor4[j]);
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), bufferAccessor2[k], bufferAccessor3[k], bufferAccessor4[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l), bufferAccessor2[l], bufferAccessor3[l], bufferAccessor4[l]);
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00001D91_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00001D91_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<EventTerminalSystem_5B58F4C8_LambdaJob_1_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct EventTerminalSystem_5B58F4C8_LambdaJob_2_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00001D95_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00001D95_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00001D95_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public EntityCommandBuffer ecb;

		public float deltaTime;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedBufferLookup;

		public Unity.Mathematics.Random rnd;

		public BiomeLookup biomeLookupLocal;

		public FixedList32Bytes<Biome> gemstoneBiomes;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<EventTerminalCD> __eventTerminalTypeHandle;

		public ComponentTypeHandle<EndTerminalEvent> __endTerminalEventTypeHandle;

		public ComponentTypeHandle<ImmunityZoneCD> __immunityZoneTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref EventTerminalCD eventTerminal, [NoAlias] ref EndTerminalEvent endTerminalEvent, [NoAlias] ref ImmunityZoneCD immunityZone, [NoAlias] in LocalTransform transform, [NoAlias] in ObjectDataCD objectData)
		{
			endTerminalEvent.timer -= deltaTime;
			if (endTerminalEvent.completed && (!endTerminalEvent.completed || !(endTerminalEvent.timer <= 2f)))
			{
				return;
			}
			if (endTerminalEvent.completed && objectData.variation != 1)
			{
				immunityZone.removeImmunityZone = true;
				ecb.SetComponent(entity, new ObjectDataCD
				{
					objectID = objectData.objectID,
					amount = objectData.amount,
					variation = 1
				});
				ecb.AddComponent<BlockSaveCD>(entity);
			}
			if (endTerminalEvent.timer <= 1.1f)
			{
				ecb.AddComponent<ManuallyTriggerDestroyNearbyEntitiesCD>(entity);
			}
			if (endTerminalEvent.completed && endTerminalEvent.timer <= 0f)
			{
				if (eventTerminal.lootTable != LootTableID.Empty)
				{
					NativeList<ObjectDataCD> items = new NativeList<ObjectDataCD>(Allocator.Temp);
					biomeLookupLocal.TryFindNearbyBiomeFromSelection(transform.Position.RoundToInt2(), gemstoneBiomes, out var biome);
					ObjectID objectID = biome switch
					{
						Biome.Nature => ObjectID.NatureGemstone, 
						Biome.Sea => ObjectID.SeaGemstone, 
						Biome.Desert => ObjectID.DesertGemstone, 
						_ => ObjectID.None, 
					};
					if (objectID != ObjectID.None)
					{
						ObjectDataCD value = new ObjectDataCD
						{
							objectID = objectID,
							amount = rnd.NextInt(2, 4)
						};
						items.Add(in value);
					}
					items.Add(new ObjectDataCD
					{
						objectID = ObjectID.CrystalMerchantSpawnItem,
						amount = 1
					});
					Entity e = EntityUtility.CreateEntityWithItems(ecb, transform.Position.RoundToInt3(), ObjectID.AlienChest, 1, items, databaseLocal, containedBufferLookup, 1);
					items.Dispose();
					ecb.AddComponent(e, new CantBeAttackedForDurationCD
					{
						Timer = 1f
					});
					ecb.AddComponent<CantBeAttackedCD>(e);
					ecb.AddComponent(e, new AddRandomLootCD
					{
						lootTableID = eventTerminal.lootTable
					});
				}
				ecb.RemoveComponent<BlockSaveCD>(entity);
				ecb.RemoveComponent<EndTerminalEvent>(entity);
				ecb.RemoveComponent<EventTerminalCD>(entity);
			}
			else if (!endTerminalEvent.completed)
			{
				ecb.RemoveComponent<EndTerminalEvent>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __eventTerminalTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __endTerminalEventTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __immunityZoneTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EndTerminalEvent>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ImmunityZoneCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EndTerminalEvent>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ImmunityZoneCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EndTerminalEvent>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ImmunityZoneCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EventTerminalCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EndTerminalEvent>(nativeArrayPtr3, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ImmunityZoneCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00001D95_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00001D95_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<EventTerminalSystem_5B58F4C8_LambdaJob_2_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EventTerminalCD> __EventTerminalCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<AlwaysActiveConnectionsBuffer> __AlwaysActiveConnectionsBuffer_RO_BufferTypeHandle;

		public ComponentTypeHandle<EventTerminalCD> __EventTerminalCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<EventTerminalElectricityEntityBuffer> __EventTerminalElectricityEntityBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<EventTerminalSequenceBuffer> __EventTerminalSequenceBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentLookup<TerminalFullyInitialized> __EventTerminalSystem_TerminalFullyInitialized_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MusicAreaCD> __MusicAreaCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemySpawnerPlatformCD> __EnemySpawnerPlatformCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ElectricitySourceCD> __Pug_Automation_ElectricitySourceCD_RO_ComponentLookup;

		public ComponentTypeHandle<EndTerminalEvent> __EventTerminalSystem_EndTerminalEvent_RW_ComponentTypeHandle;

		public ComponentTypeHandle<ImmunityZoneCD> __ImmunityZoneCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<NearbyEntitiesTrackerCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__EventTerminalCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EventTerminalCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__AlwaysActiveConnectionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<AlwaysActiveConnectionsBuffer>(isReadOnly: true);
			__EventTerminalCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EventTerminalCD>();
			__EventTerminalElectricityEntityBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<EventTerminalElectricityEntityBuffer>();
			__EventTerminalSequenceBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<EventTerminalSequenceBuffer>(isReadOnly: true);
			__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
			__EventTerminalSystem_TerminalFullyInitialized_RO_ComponentLookup = state.GetComponentLookup<TerminalFullyInitialized>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__MusicAreaCD_RO_ComponentLookup = state.GetComponentLookup<MusicAreaCD>(isReadOnly: true);
			__DistanceToPlayerCD_RO_ComponentLookup = state.GetComponentLookup<DistanceToPlayerCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__EnemySpawnerPlatformCD_RO_ComponentLookup = state.GetComponentLookup<EnemySpawnerPlatformCD>(isReadOnly: true);
			__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup = state.GetComponentLookup<ElectricitySourceCD>(isReadOnly: true);
			__EventTerminalSystem_EndTerminalEvent_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EndTerminalEvent>();
			__ImmunityZoneCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ImmunityZoneCD>();
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		}
	}

	private const int SOURCE_AMOUNT = 18;

	private const float MIN_DISTANCE_SQ_TO_PLAYER_TO_STOP_EVENT = 1600f;

	private FixedList32Bytes<Biome> secondRingBiomes;

	private EntityArchetype keepAreaEnabledArchetype;

	private EntityArchetype electricityEntityArchetype;

	private EntityArchetype triggerelectricityEntityArchetype;

	private NativeList<ConnectionAndDirection> allConnectionTypes;

	private BiomeLookup biomeLookup;

	private EntityQuery playerQuery;

	private EntityQuery merchantsQ;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_888482715_0;

	private EntityQuery __query_888482715_1;

	private EntityQuery __query_888482715_2;

	private EntityQuery __query_888482715_3;

	private EntityQuery __query_888482715_4;

	private EntityQuery __query_888482715_5;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		RequireForUpdate(__query_888482715_3);
		keepAreaEnabledArchetype = base.EntityManager.CreateArchetype(typeof(EnableEntitiesInCircleCD), typeof(EnableEntitiesTimerCD));
		electricityEntityArchetype = base.EntityManager.CreateArchetype(typeof(ElectricitySourceCD), typeof(ElectricityConnectionCD), typeof(LocalTransform));
		triggerelectricityEntityArchetype = base.EntityManager.CreateArchetype(typeof(ElectricityTriggerUpdateNearbyCD));
		allConnectionTypes = new NativeList<ConnectionAndDirection>(Allocator.Persistent);
		foreach (ConnectionAndDirection value2 in Enum.GetValues(typeof(ConnectionAndDirection)))
		{
			ConnectionAndDirection value = value2;
			allConnectionTypes.Add(in value);
		}
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(PlayerGhost) };
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		playerQuery = GetEntityQuery(entityQueryDesc2);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(MerchantCD),
			typeof(ObjectDataCD)
		};
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
		merchantsQ = GetEntityQuery(entityQueryDesc3);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(EventTerminalCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc4 = entityQueryDesc;
		RequireForUpdate(GetEntityQuery(entityQueryDesc4));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (allConnectionTypes.IsCreated)
		{
			allConnectionTypes.Dispose();
		}
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.OnStartRunning();
		biomeLookup = (__query_888482715_4.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_888482715_5.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		biomeLookup.Dispose();
		base.OnStopRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime * UnityEngine.Time.timeScale;
		EntityArchetype keepAreaEnabledArchetypeLocal = keepAreaEnabledArchetype;
		EntityArchetype electricityEntityArchetypeLocal = electricityEntityArchetype;
		EntityArchetype triggerelectricityEntityArchetypeLocal = triggerelectricityEntityArchetype;
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		NativeList<ConnectionAndDirection> allConnectionTypesLocal = allConnectionTypes;
		BufferLookup<ContainedObjectsBuffer> containedBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		int playerCount = playerQuery.CalculateEntityCount();
		Unity.Mathematics.Random rnd = PugRandom.GetRng();
		NativeArray<ObjectDataCD> nativeArray = merchantsQ.ToComponentDataArray<ObjectDataCD>(Allocator.Temp);
		BiomeLookup biomeLookupLocal = biomeLookup;
		FixedList32Bytes<Biome> gemstoneBiomes = new FixedList32Bytes<Biome>
		{
			Biome.Nature,
			Biome.Sea,
			Biome.Desert
		};
		EventTerminalSystem_5B58F4C8_LambdaJob_0_Execute(ref databaseLocal, ref ecb, ref electricityEntityArchetypeLocal, ref allConnectionTypesLocal);
		ComponentLookup<ElectricitySourceCD> electricitySourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup, ref base.CheckedStateRef);
		EventTerminalSystem_5B58F4C8_LambdaJob_1_Execute(ref databaseLocal, ref ecb, ref time, ref deltaTime, ref keepAreaEnabledArchetypeLocal, ref electricityEntityArchetypeLocal, ref triggerelectricityEntityArchetypeLocal, ref collisionWorld, ref allConnectionTypesLocal, ref playerCount, ref electricitySourceLookup);
		EventTerminalSystem_5B58F4C8_LambdaJob_2_Execute(ref databaseLocal, ref ecb, ref deltaTime, ref containedBufferLookup, ref rnd, ref biomeLookupLocal, ref gemstoneBiomes);
		nativeArray.Dispose();
		base.OnUpdate();
	}

	private static void SetConnectionsEnabled(EntityCommandBuffer ecb, ComponentLookup<ElectricitySourceCD> electricitySourceLookup, EntityArchetype triggerelectricityEntityArchetypeLocal, ConnectionAndDirection target, bool value, ref DynamicBuffer<EventTerminalElectricityEntityBuffer> electricityEntities, in LocalTransform transform)
	{
		for (int i = 0; i < 8; i++)
		{
			if (((uint)target & (uint)(1 << i)) != 0)
			{
				EventTerminalElectricityEntityBuffer value2 = electricityEntities[i];
				value2.isActive = value;
				electricityEntities[i] = value2;
				ElectricitySourceCD component = electricitySourceLookup[value2.entity];
				component.sourceEnergy = (value ? 18 : 0);
				ecb.SetComponent(value2.entity, component);
				Entity e = ecb.CreateEntity(triggerelectricityEntityArchetypeLocal);
				ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
				{
					position = transform.Position.RoundToInt2()
				});
			}
		}
	}

	private static bool CreateElectricityEntity(EntityCommandBuffer ecb, Entity entity, EntityArchetype electricityEntityArchetype, float3 position, int2 size, DynamicBuffer<AlwaysActiveConnectionsBuffer> alwaysActiveConnections, ConnectionAndDirection connectionAndDirection, bool onlyCreateAlwaysActiveConnections, out EventTerminalElectricityEntityBuffer result)
	{
		bool flag = false;
		for (int i = 0; i < alwaysActiveConnections.Length; i++)
		{
			if (alwaysActiveConnections[i].connection == connectionAndDirection)
			{
				flag = true;
				break;
			}
		}
		if ((onlyCreateAlwaysActiveConnections && !flag) || (!onlyCreateAlwaysActiveConnections && flag))
		{
			result = default(EventTerminalElectricityEntityBuffer);
			return false;
		}
		Entity entity2 = ecb.CreateEntity(electricityEntityArchetype);
		float3 float5 = position + GetPositionFromConnectionAndDirection(connectionAndDirection, size);
		ecb.SetComponent(entity2, LocalTransform.FromPosition(float5));
		ElectricityDirectionMask directionFromConnectionAndDirection = GetDirectionFromConnectionAndDirection(connectionAndDirection);
		ecb.SetComponent(entity2, new ElectricityConnectionCD
		{
			direction = directionFromConnectionAndDirection,
			mode = CircuitConnectionMode.None,
			position = float5.RoundToInt2(),
			prioritize = false
		});
		if (flag)
		{
			ecb.SetComponent(entity2, new ElectricitySourceCD
			{
				sourceEnergy = 18
			});
		}
		result = new EventTerminalElectricityEntityBuffer
		{
			entity = entity2,
			isActive = flag,
			keepConnectionActive = flag
		};
		return true;
	}

	public static ElectricityDirectionMask GetDirectionFromConnectionAndDirection(ConnectionAndDirection connectionAndDirection)
	{
		switch (connectionAndDirection)
		{
		case ConnectionAndDirection.BR_Down:
		case ConnectionAndDirection.BL_Down:
			return ElectricityDirectionMask.South;
		case ConnectionAndDirection.BL_Left:
		case ConnectionAndDirection.TL_Left:
			return ElectricityDirectionMask.West;
		case ConnectionAndDirection.TR_Up:
		case ConnectionAndDirection.TL_Up:
			return ElectricityDirectionMask.North;
		case ConnectionAndDirection.TR_Right:
		case ConnectionAndDirection.BR_Right:
			return ElectricityDirectionMask.East;
		default:
			return ElectricityDirectionMask.All;
		}
	}

	public static float3 GetPositionFromConnectionAndDirection(ConnectionAndDirection connectionAndDirection, int2 size)
	{
		int2 int5 = size / 2;
		switch (connectionAndDirection)
		{
		case ConnectionAndDirection.BL_Down:
		case ConnectionAndDirection.BL_Left:
			return new float3(-int5.x, 0f, -int5.y);
		case ConnectionAndDirection.TL_Left:
		case ConnectionAndDirection.TL_Up:
			return new float3(-int5.x, 0f, int5.y);
		case ConnectionAndDirection.TR_Up:
		case ConnectionAndDirection.TR_Right:
			return new float3(int5.x, 0f, int5.y);
		case ConnectionAndDirection.BR_Right:
		case ConnectionAndDirection.BR_Down:
			return new float3(int5.x, 0f, -int5.y);
		default:
			return new float3(0f, 0f, 0f);
		}
	}

	private void EventTerminalSystem_5B58F4C8_LambdaJob_0_Execute(ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref EntityCommandBuffer ecb, ref EntityArchetype electricityEntityArchetypeLocal, ref NativeList<ConnectionAndDirection> allConnectionTypesLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AlwaysActiveConnectionsBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		EventTerminalSystem_5B58F4C8_LambdaJob_0_Job value = new EventTerminalSystem_5B58F4C8_LambdaJob_0_Job
		{
			databaseLocal = databaseLocal,
			ecb = ecb,
			electricityEntityArchetypeLocal = electricityEntityArchetypeLocal,
			allConnectionTypesLocal = allConnectionTypesLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__nearbyTrackerTypeHandle = __TypeHandle.__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__eventTerminalTypeHandle = __TypeHandle.__EventTerminalCD_RO_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle,
			__alwaysActiveConnectionsTypeHandle = __TypeHandle.__AlwaysActiveConnectionsBuffer_RO_BufferTypeHandle
		};
		if (!__query_888482715_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			EventTerminalSystem_5B58F4C8_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_888482715_0, jobPtr);
		}
		databaseLocal = value.databaseLocal;
		ecb = value.ecb;
		electricityEntityArchetypeLocal = value.electricityEntityArchetypeLocal;
		allConnectionTypesLocal = value.allConnectionTypesLocal;
	}

	private void EventTerminalSystem_5B58F4C8_LambdaJob_1_Execute(ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref EntityCommandBuffer ecb, ref double time, ref float deltaTime, ref EntityArchetype keepAreaEnabledArchetypeLocal, ref EntityArchetype electricityEntityArchetypeLocal, ref EntityArchetype triggerelectricityEntityArchetypeLocal, ref CollisionWorld collisionWorld, ref NativeList<ConnectionAndDirection> allConnectionTypesLocal, ref int playerCount, ref ComponentLookup<ElectricitySourceCD> electricitySourceLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalElectricityEntityBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalSequenceBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AlwaysActiveConnectionsBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalSystem_TerminalFullyInitialized_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MusicAreaCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		EventTerminalSystem_5B58F4C8_LambdaJob_1_Job value = new EventTerminalSystem_5B58F4C8_LambdaJob_1_Job
		{
			databaseLocal = databaseLocal,
			ecb = ecb,
			time = time,
			deltaTime = deltaTime,
			keepAreaEnabledArchetypeLocal = keepAreaEnabledArchetypeLocal,
			electricityEntityArchetypeLocal = electricityEntityArchetypeLocal,
			triggerelectricityEntityArchetypeLocal = triggerelectricityEntityArchetypeLocal,
			collisionWorld = collisionWorld,
			allConnectionTypesLocal = allConnectionTypesLocal,
			playerCount = playerCount,
			electricitySourceLookup = electricitySourceLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__eventTerminalTypeHandle = __TypeHandle.__EventTerminalCD_RW_ComponentTypeHandle,
			__electricityEntitiesTypeHandle = __TypeHandle.__EventTerminalElectricityEntityBuffer_RW_BufferTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__sequenceTypeHandle = __TypeHandle.__EventTerminalSequenceBuffer_RO_BufferTypeHandle,
			__alwaysActiveConnectionsTypeHandle = __TypeHandle.__AlwaysActiveConnectionsBuffer_RO_BufferTypeHandle,
			__nearbyEntitiesTypeHandle = __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle,
			__EventTerminalSystem_TerminalFullyInitialized_ComponentLookup = __TypeHandle.__EventTerminalSystem_TerminalFullyInitialized_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup,
			__MusicAreaCD_ComponentLookup = __TypeHandle.__MusicAreaCD_RO_ComponentLookup,
			__DistanceToPlayerCD_ComponentLookup = __TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup,
			__PlayerGhost_ComponentLookup = __TypeHandle.__PlayerGhost_RO_ComponentLookup,
			__EnemySpawnerPlatformCD_ComponentLookup = __TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentLookup,
			__Pug_Automation_ElectricitySourceCD_ComponentLookup = __TypeHandle.__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup
		};
		if (!__query_888482715_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			EventTerminalSystem_5B58F4C8_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_888482715_1, jobPtr);
		}
		databaseLocal = value.databaseLocal;
		ecb = value.ecb;
		time = value.time;
		deltaTime = value.deltaTime;
		keepAreaEnabledArchetypeLocal = value.keepAreaEnabledArchetypeLocal;
		electricityEntityArchetypeLocal = value.electricityEntityArchetypeLocal;
		triggerelectricityEntityArchetypeLocal = value.triggerelectricityEntityArchetypeLocal;
		collisionWorld = value.collisionWorld;
		allConnectionTypesLocal = value.allConnectionTypesLocal;
		playerCount = value.playerCount;
		electricitySourceLookup = value.electricitySourceLookup;
	}

	private void EventTerminalSystem_5B58F4C8_LambdaJob_2_Execute(ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref EntityCommandBuffer ecb, ref float deltaTime, ref BufferLookup<ContainedObjectsBuffer> containedBufferLookup, ref Unity.Mathematics.Random rnd, ref BiomeLookup biomeLookupLocal, ref FixedList32Bytes<Biome> gemstoneBiomes)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EventTerminalSystem_EndTerminalEvent_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ImmunityZoneCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		EventTerminalSystem_5B58F4C8_LambdaJob_2_Job value = new EventTerminalSystem_5B58F4C8_LambdaJob_2_Job
		{
			databaseLocal = databaseLocal,
			ecb = ecb,
			deltaTime = deltaTime,
			containedBufferLookup = containedBufferLookup,
			rnd = rnd,
			biomeLookupLocal = biomeLookupLocal,
			gemstoneBiomes = gemstoneBiomes,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__eventTerminalTypeHandle = __TypeHandle.__EventTerminalCD_RW_ComponentTypeHandle,
			__endTerminalEventTypeHandle = __TypeHandle.__EventTerminalSystem_EndTerminalEvent_RW_ComponentTypeHandle,
			__immunityZoneTypeHandle = __TypeHandle.__ImmunityZoneCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle
		};
		if (!__query_888482715_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			EventTerminalSystem_5B58F4C8_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_888482715_2, jobPtr);
		}
		databaseLocal = value.databaseLocal;
		ecb = value.ecb;
		deltaTime = value.deltaTime;
		containedBufferLookup = value.containedBufferLookup;
		rnd = value.rnd;
		biomeLookupLocal = value.biomeLookupLocal;
		gemstoneBiomes = value.gemstoneBiomes;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<AlwaysActiveConnectionsInitialized>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EventTerminalCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AlwaysActiveConnectionsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EventTerminalElectricityEntityBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesTrackerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_888482715_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<EndTerminalEvent>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EventTerminalSequenceBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AlwaysActiveConnectionsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NearbyEntitiesBufferCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<TerminalActiveCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AlwaysActiveConnectionsInitialized>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EventTerminalCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EventTerminalElectricityEntityBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_888482715_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AlwaysActiveConnectionsInitialized>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EventTerminalCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EndTerminalEvent>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ImmunityZoneCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_888482715_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_888482715_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_888482715_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_888482715_5 = entityQueryBuilder2.Build(ref state);
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
	public EventTerminalSystem()
	{
	}
}
