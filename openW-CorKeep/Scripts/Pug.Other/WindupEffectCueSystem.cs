using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
public struct WindupEffectCueSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1933546684_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquipmentSlotCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquippedObjectCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<EquipmentSlotVisualCD>(item3_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> item2_ComponentTypeHandle_RO;

			private ComponentTypeHandle<EquipmentSlotVisualCD> item3_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<EquipmentSlotVisualCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotVisualCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1933546684_0.TypeHandle __IFE_1933546684_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<CustomAttackSoundCD> __CustomAttackSoundCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1933546684_0_TypeHandle = new IFE_1933546684_0.TypeHandle(ref state);
			__CustomAttackSoundCD_RO_ComponentLookup = state.GetComponentLookup<CustomAttackSoundCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00006BA9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00006BA9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00006BA9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1933546684_0;

	private EntityQuery __query_1933546684_1;

	private EntityQuery __query_1933546684_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
	}

	public void OnUpdate(ref SystemState state)
	{
		__query_1933546684_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		uint simulationTickRate = (uint)__query_1933546684_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		ComponentLookup<CustomAttackSoundCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CustomAttackSoundCD_RO_ComponentLookup, ref state);
		foreach (var item4 in IFE_1933546684_0.Query(__query_1933546684_0, __TypeHandle.__IFE_1933546684_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD> item = item4.Item1;
			InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD> item2 = item4.Item2;
			InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD> item3 = item4.Item3;
			PlayerController player = Manager.main.player;
			if (player == null)
			{
				continue;
			}
			ref readonly EquipmentSlotCD valueRO = ref item.ValueRO;
			ref readonly EquippedObjectCD valueRO2 = ref item2.ValueRO;
			ref EquipmentSlotVisualCD valueRW = ref item3.ValueRW;
			bool isValid = valueRO.warmupTimer.stopTick.IsValid;
			bool stoppedTriggeredThisFrame = isValid && !valueRW.warmupWasStopped;
			valueRW.warmupWasStopped = isValid;
			player.UpdateWindupSounds(in valueRO, in valueRO2, componentLookup);
			player.UpdateWarmupSounds(in valueRO, in valueRO2, componentLookup, currentTick, stoppedTriggeredThisFrame);
			bool isRunning = valueRO.warmupTimer.isRunning;
			if (isRunning && !valueRW.warmupWasActive)
			{
				player.flashableComponent.Flash(player.warmupCurve, Color.white, valueRO.warmupTimer.GetRemainingSeconds(in currentTick, simulationTickRate));
			}
			else if (!isRunning && valueRW.warmupWasActive)
			{
				player.flashableComponent.CancelAndStopEffect();
			}
			valueRW.warmupWasActive = isRunning;
			player.UpdateAmassSounds();
			player.UpdateQualitySleepSounds();
			if (valueRO.windupTimer.isRunning && valueRO.windupTimer.IsTimerElapsed(currentTick))
			{
				if (!valueRW.windupSoundTimer.isRunning || valueRW.windupSoundTimer.IsTimerElapsed(currentTick))
				{
					AudioManager.Sfx(SfxID.charge_bar_ui_1, player.transform.position, 0.014f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
					valueRW.windupSoundTimer.Start(currentTick, 0.5f, simulationTickRate);
				}
			}
			else
			{
				valueRW.windupSoundTimer.Stop(currentTick);
			}
			int lastWindupTier = valueRW.lastWindupTier;
			valueRW.lastWindupTier = valueRO.currentWindupTier;
			if (valueRO.currentWindupTier > lastWindupTier)
			{
				player.flashableComponent.FlashLinearNoCurve(Color.white, 0.3f);
				Manager.ui.castbar.flashable.FlashLinearNoCurve(Color.white, 0.3f);
				float pitch = 0.93f + (float)valueRO.currentWindupTier * 0.04f;
				AudioManager.Sfx(SfxID.clapper, player.transform.position, 0.1f, pitch, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquipmentSlotVisualCD>();
		__query_1933546684_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1933546684_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1933546684_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00006BA9_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((WindupEffectCueSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((WindupEffectCueSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WindupEffectCueSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}
}
