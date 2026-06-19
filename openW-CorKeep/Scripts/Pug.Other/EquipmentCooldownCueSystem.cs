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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
public struct EquipmentCooldownCueSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_390453492_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<EquipmentSlotCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<EquipmentSlotVisualCD>(item2_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<EquipmentSlotCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<EquipmentSlotVisualCD> item2_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<EquipmentSlotCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<EquipmentSlotVisualCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotVisualCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_390453492_0.TypeHandle __IFE_390453492_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_390453492_0_TypeHandle = new IFE_390453492_0.TypeHandle(ref state);
		}
	}

	private const float sfxCooldownSoundCooldownSeconds = 0.35f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_390453492_0;

	private EntityQuery __query_390453492_1;

	private EntityQuery __query_390453492_2;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
	}

	public void OnUpdate(ref SystemState state)
	{
		__query_390453492_1.TryGetSingleton<NetworkTime>(out var value);
		uint simulationTickRate = (uint)__query_390453492_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		foreach (var item3 in IFE_390453492_0.Query(__query_390453492_0, __TypeHandle.__IFE_390453492_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRW<EquipmentSlotCD> item = item3.Item1;
			InternalCompilerInterface.UncheckedRefRW<EquipmentSlotVisualCD> item2 = item3.Item2;
			NetworkTick lastInteractPressedOnCooldownTick = item.ValueRO.lastInteractPressedOnCooldownTick;
			NetworkTick previousLastInteractPressedOnCooldownTick = item2.ValueRW.previousLastInteractPressedOnCooldownTick;
			if (!lastInteractPressedOnCooldownTick.IsValid || (previousLastInteractPressedOnCooldownTick.IsValid && lastInteractPressedOnCooldownTick.IsSameOrOlderThan(previousLastInteractPressedOnCooldownTick)))
			{
				break;
			}
			if (previousLastInteractPressedOnCooldownTick.IsValid && NetworkTimeUtilities.TimeBetweenTicksInSeconds(previousLastInteractPressedOnCooldownTick, value.ServerTick, simulationTickRate) < 0.35f)
			{
				item.ValueRW.lastInteractPressedOnCooldownTick = NetworkTick.Invalid;
				continue;
			}
			AudioManager.SfxUI(SfxID.ui_cooldown_1_14_2, 0.85f, reuse: false, 0.1f, 0f);
			item2.ValueRW.previousLastInteractPressedOnCooldownTick = lastInteractPressedOnCooldownTick;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquipmentSlotCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquipmentSlotVisualCD>();
		__query_390453492_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_390453492_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_390453492_2 = entityQueryBuilder2.Build(ref state);
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
		((EquipmentCooldownCueSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((EquipmentCooldownCueSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EquipmentCooldownCueSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
