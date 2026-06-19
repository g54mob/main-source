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
public struct EquipmentConditionBarUISystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2004943641_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<SummarizedConditionsBuffer> item3_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>, DynamicBuffer<SummarizedConditionsBuffer>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquippedObjectCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<EquipmentSlotVisualCD>(item2_IntPtr, index), item3_BufferAccessor[index]);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> item1_ComponentTypeHandle_RO;

			private ComponentTypeHandle<EquipmentSlotVisualCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<SummarizedConditionsBuffer> item3_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<EquipmentSlotVisualCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SummarizedConditionsBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item3_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>, DynamicBuffer<SummarizedConditionsBuffer>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>, DynamicBuffer<SummarizedConditionsBuffer>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotVisualCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SummarizedConditionsBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_2004943641_0.TypeHandle __IFE_2004943641_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<DisplayConditionAsBarWhenEquippedCD> __DisplayConditionAsBarWhenEquippedCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_2004943641_0_TypeHandle = new IFE_2004943641_0.TypeHandle(ref state);
			__DisplayConditionAsBarWhenEquippedCD_RO_ComponentLookup = state.GetComponentLookup<DisplayConditionAsBarWhenEquippedCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2004943641_0;

	private EntityQuery __query_2004943641_1;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
	}

	public void OnUpdate(ref SystemState state)
	{
		CastBarUI equipmentConditionBar = Manager.ui.equipmentConditionBar;
		if (equipmentConditionBar == null)
		{
			return;
		}
		equipmentConditionBar.root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			equipmentConditionBar.DisplayNothing();
			return;
		}
		ComponentLookup<DisplayConditionAsBarWhenEquippedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisplayConditionAsBarWhenEquippedCD_RO_ComponentLookup, ref state);
		ConditionsTableCD singleton = __query_2004943641_1.GetSingleton<ConditionsTableCD>();
		foreach (var item4 in IFE_2004943641_0.Query(__query_2004943641_0, __TypeHandle.__IFE_2004943641_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD> item = item4.Item1;
			InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD> item2 = item4.Item2;
			DynamicBuffer<SummarizedConditionsBuffer> item3 = item4.Item3;
			int num = 0;
			EquippedObjectCD valueRO = item.ValueRO;
			if (componentLookup.TryGetComponent(valueRO.equipmentPrefab, out var componentData))
			{
				ConditionID conditionID = componentData.conditionID;
				if (!singleton.Value.Value.infos[(int)conditionID].isAdditiveWithSelf)
				{
					int maxStacksForWeaponEquipmentConditions = ConditionExtensions.GetMaxStacksForWeaponEquipmentConditions(conditionID);
					num = ConditionExtensions.GetStacks(conditionID, item3[(int)conditionID].value);
					if (num > 0)
					{
						bool windupTimerElapsed = num >= maxStacksForWeaponEquipmentConditions;
						equipmentConditionBar.DisplayWindup(maxStacksForWeaponEquipmentConditions, num, maxStacksForWeaponEquipmentConditions, windupTimerRunning: true, windupTimerElapsed);
					}
					else
					{
						equipmentConditionBar.DisplayNothing();
					}
				}
			}
			else
			{
				equipmentConditionBar.DisplayNothing();
			}
			ref EquipmentSlotVisualCD valueRW = ref item2.ValueRW;
			int lastConditionStackTier = valueRW.lastConditionStackTier;
			valueRW.lastConditionStackTier = num;
			if (num > lastConditionStackTier)
			{
				player.flashableComponent.FlashLinearNoCurve(Color.white, 0.3f);
				Manager.ui.equipmentConditionBar.flashable.FlashLinearNoCurve(Color.white, 0.3f);
				float pitch = 0.93f + (float)num * 0.04f;
				AudioManager.Sfx(SfxID.clapper, player.transform.position, 0.1f, pitch, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquipmentSlotVisualCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SummarizedConditionsBuffer>();
		__query_2004943641_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2004943641_1 = entityQueryBuilder2.Build(ref state);
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
		((EquipmentConditionBarUISystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((EquipmentConditionBarUISystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EquipmentConditionBarUISystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
