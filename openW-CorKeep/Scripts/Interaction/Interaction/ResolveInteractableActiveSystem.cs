using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using Unity.Transforms;

namespace Interaction
{
	[UpdateInGroup(typeof(SetupInteractionSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[BurstCompile]
	public struct ResolveInteractableActiveSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct ResolveInteractableActiveJob : IJobChunk
		{
			[ReadOnly]
			public ComponentTypeHandle<CoreBossSpawnCD> coreBossSpawnCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EventTerminalCD> eventTerminalCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EnemySpawnerPlatformCD> enemySpawnerPlatformCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> localTransformTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ControlledByOtherEntityCD> controlledByOtherEntityCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ToggleInteractionOnVariationCD> toggleInteractionOnValidationCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ObjectDataCD> objectDataCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EntityDestroyedCD> entityDestroyedCDTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<WayPointCD> wayPointCDTypeHandle;

			public ComponentTypeHandle<InteractionCooldownCD> localInteractionCooldownCDTypeHandle;

			public ComponentTypeHandle<InteractableCD> interactableCDTypeHandle;

			[ReadOnly]
			public TileAccessor tileAccessor;

			public NetworkTick currentTick;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				NativeArray<CoreBossSpawnCD> nativeArray = chunk.GetNativeArray(coreBossSpawnCDTypeHandle);
				NativeArray<EventTerminalCD> nativeArray2 = chunk.GetNativeArray(eventTerminalCDTypeHandle);
				NativeArray<EnemySpawnerPlatformCD> nativeArray3 = chunk.GetNativeArray(enemySpawnerPlatformCDTypeHandle);
				NativeArray<LocalTransform> nativeArray4 = chunk.GetNativeArray(localTransformTypeHandle);
				NativeArray<ControlledByOtherEntityCD> nativeArray5 = chunk.GetNativeArray(controlledByOtherEntityCDTypeHandle);
				NativeArray<InteractionCooldownCD> nativeArray6 = chunk.GetNativeArray(localInteractionCooldownCDTypeHandle);
				NativeArray<ToggleInteractionOnVariationCD> nativeArray7 = chunk.GetNativeArray(toggleInteractionOnValidationCDTypeHandle);
				NativeArray<ObjectDataCD> nativeArray8 = chunk.GetNativeArray(objectDataCDTypeHandle);
				NativeArray<WayPointCD> nativeArray9 = chunk.GetNativeArray(wayPointCDTypeHandle);
				bool isCreated = nativeArray.IsCreated;
				bool isCreated2 = nativeArray2.IsCreated;
				bool isCreated3 = nativeArray3.IsCreated;
				bool isCreated4 = nativeArray5.IsCreated;
				bool isCreated5 = nativeArray7.IsCreated;
				bool isCreated6 = nativeArray6.IsCreated;
				bool isCreated7 = nativeArray9.IsCreated;
				for (int i = 0; i < chunk.Count; i++)
				{
					bool flag = chunk.IsComponentEnabled(entityDestroyedCDTypeHandle, i);
					if (isCreated)
					{
						flag |= nativeArray[i].state != CoreBossSpawnState.Activated;
					}
					if (isCreated2)
					{
						flag |= nativeArray2[i].terminalIsActive;
					}
					if (isCreated3)
					{
						bool flag2 = tileAccessor.HasType(nativeArray4[i].Position.RoundToInt2(), TileType.immune);
						flag = flag || flag2;
					}
					if (isCreated4)
					{
						flag |= nativeArray5[i].controlledByEntity != Entity.Null;
					}
					if (isCreated5)
					{
						bool flag3 = nativeArray7[i].variation == nativeArray8[i].variation;
						flag |= nativeArray7[i].toggleType == ToggleInteractionByVariationType.DisableIfVariation == flag3;
					}
					if (isCreated6)
					{
						InteractionCooldownCD value = nativeArray6[i];
						bool flag4 = value.cooldownTimer.isRunning;
						if (flag4 && value.cooldownTimer.IsTimerElapsed(currentTick))
						{
							value.cooldownTimer.Stop(currentTick);
							nativeArray6[i] = value;
							flag4 = false;
						}
						flag = flag || flag4;
					}
					if (isCreated7)
					{
						bool flag5 = nativeArray8[i].amount >= 600;
						flag |= nativeArray9[i].isCoreWaypoint && !flag5;
					}
					chunk.SetComponentEnabled(interactableCDTypeHandle, i, !flag);
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentTypeHandle<CoreBossSpawnCD> __CoreBossSpawnCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EventTerminalCD> __EventTerminalCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EnemySpawnerPlatformCD> __EnemySpawnerPlatformCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ControlledByOtherEntityCD> __ControlledByOtherEntityCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ToggleInteractionOnVariationCD> __Interaction_ToggleInteractionOnVariationCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<WayPointCD> __WayPointCD_RO_ComponentTypeHandle;

			public ComponentTypeHandle<InteractionCooldownCD> __Interaction_InteractionCooldownCD_RW_ComponentTypeHandle;

			public ComponentTypeHandle<InteractableCD> __Interaction_InteractableCD_RW_ComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__CoreBossSpawnCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnCD>(isReadOnly: true);
				__EventTerminalCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EventTerminalCD>(isReadOnly: true);
				__EnemySpawnerPlatformCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnemySpawnerPlatformCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				__ControlledByOtherEntityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ControlledByOtherEntityCD>(isReadOnly: true);
				__Interaction_ToggleInteractionOnVariationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ToggleInteractionOnVariationCD>(isReadOnly: true);
				__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
				__WayPointCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<WayPointCD>(isReadOnly: true);
				__Interaction_InteractionCooldownCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InteractionCooldownCD>();
				__Interaction_InteractableCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InteractableCD>();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000003E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000003E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000003E_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_586669778_0;

		private EntityQuery __query_586669778_1;

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
			_tileAccessor.Update(ref state);
			EntityQuery _query_586669778_ = __query_586669778_0;
			__query_586669778_1.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = JobChunkExtensions.ScheduleParallel(new ResolveInteractableActiveJob
			{
				coreBossSpawnCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__CoreBossSpawnCD_RO_ComponentTypeHandle, ref state),
				eventTerminalCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EventTerminalCD_RO_ComponentTypeHandle, ref state),
				enemySpawnerPlatformCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentTypeHandle, ref state),
				localTransformTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle, ref state),
				controlledByOtherEntityCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ControlledByOtherEntityCD_RO_ComponentTypeHandle, ref state),
				toggleInteractionOnValidationCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Interaction_ToggleInteractionOnVariationCD_RO_ComponentTypeHandle, ref state),
				objectDataCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle, ref state),
				entityDestroyedCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle, ref state),
				wayPointCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__WayPointCD_RO_ComponentTypeHandle, ref state),
				localInteractionCooldownCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Interaction_InteractionCooldownCD_RW_ComponentTypeHandle, ref state),
				interactableCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Interaction_InteractableCD_RW_ComponentTypeHandle, ref state),
				tileAccessor = _tileAccessor,
				currentTick = value.ServerTick
			}, _query_586669778_, state.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithPresent<InteractableCD, EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform, ObjectDataCD>();
			__query_586669778_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_586669778_1 = entityQueryBuilder2.Build(ref state);
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
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000003E_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((ResolveInteractableActiveSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((ResolveInteractableActiveSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ResolveInteractableActiveSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ResolveInteractableActiveSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
