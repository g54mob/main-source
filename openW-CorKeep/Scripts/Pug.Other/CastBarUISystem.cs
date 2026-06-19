using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using PlayerState;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
public struct CastBarUISystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_227978018_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<CastingStateCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<FishingStateCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlayerStateCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<CastingStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquipmentSlotCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<FishingStateCD>(item4_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<PlayerStateCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<CastingStateCD> item2_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotCD> item3_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<FishingStateCD> item4_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<CastingStateCD>(isReadOnly: true);
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<FishingStateCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<CastingStateCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<FishingStateCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<CastingStateCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<FishingStateCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CastingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingStateCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_227978018_0.TypeHandle __IFE_227978018_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_227978018_0_TypeHandle = new IFE_227978018_0.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_227978018_0;

	private EntityQuery __query_227978018_1;

	public void OnUpdate(ref SystemState state)
	{
		CastBarUI castbar = Manager.ui.castbar;
		if (castbar == null)
		{
			return;
		}
		castbar.root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (Manager.main.player == null)
		{
			castbar.DisplayNothing();
			return;
		}
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		__query_227978018_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		float serverTickFraction = value.ServerTickFraction;
		foreach (var item5 in IFE_227978018_0.Query(__query_227978018_0, __TypeHandle.__IFE_227978018_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRO<PlayerStateCD> item = item5.Item1;
			InternalCompilerInterface.UncheckedRefRO<CastingStateCD> item2 = item5.Item2;
			InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD> item3 = item5.Item3;
			InternalCompilerInterface.UncheckedRefRO<FishingStateCD> item4 = item5.Item4;
			TickTimer castTimer = item2.ValueRO.castTimer;
			EquipmentSlotCD valueRO = item3.ValueRO;
			FishingStateCD valueRO2 = item4.ValueRO;
			if (item.ValueRO.HasAnyState(PlayerStateEnum.Casting) && castTimer.isRunning && !castTimer.IsTimerElapsed(serverTick))
			{
				float elapsedSeconds = castTimer.GetElapsedSeconds(serverTick, serverTickFraction, simulationTickRate);
				float num = NetworkTimeUtilities.TicksToSeconds(castTimer.targetTicks, simulationTickRate);
				float elapsedRatio = math.clamp(elapsedSeconds / num, 0f, 1f);
				castbar.DisplayNormal(elapsedRatio);
			}
			else if (valueRO.secondaryUse.hasSecondaryUse && valueRO.windupTimer.isRunning)
			{
				TickTimer windupTimer = valueRO.windupTimer;
				float lifespan = (float)windupTimer.targetTicks / (float)simulationTickRate;
				float elapsedSeconds2 = windupTimer.GetElapsedSeconds(serverTick, serverTickFraction, simulationTickRate);
				int windupTiers = valueRO.secondaryUse.windupTiers;
				bool isRunning = windupTimer.isRunning;
				bool windupTimerElapsed = windupTimer.IsTimerElapsed(serverTick);
				castbar.DisplayWindup(lifespan, elapsedSeconds2, windupTiers, isRunning, windupTimerElapsed);
			}
			else if (item.ValueRO.HasAnyState(PlayerStateEnum.Fishing) && valueRO2.castTimer.isRunning && !valueRO2.castTimer.IsTimerElapsed(serverTick))
			{
				float elapsedSeconds3 = valueRO2.castTimer.GetElapsedSeconds(serverTick, serverTickFraction, simulationTickRate);
				float num2 = NetworkTimeUtilities.TicksToSeconds(valueRO2.castTimer.targetTicks, simulationTickRate);
				float elapsedRatio2 = math.clamp(elapsedSeconds3 / num2, 0f, 1f);
				castbar.DisplayNormal(elapsedRatio2);
			}
			else
			{
				castbar.DisplayNothing();
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<CastingStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<FishingStateCD>();
		__query_227978018_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_227978018_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((CastBarUISystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CastBarUISystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
