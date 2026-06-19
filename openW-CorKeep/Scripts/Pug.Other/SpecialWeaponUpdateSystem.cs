using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using PlayerState;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using Unity.Transforms;

[UpdateInGroup(typeof(PresentationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct SpecialWeaponUpdateSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1035980960_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			public IntPtr item7_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ClientInput>, InternalCompilerInterface.UncheckedRefRO<ClientInputNonPartialStateCD>, InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<PlayerGhost>, InternalCompilerInterface.UncheckedRefRO<PlayerAimPositionCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ClientInput>, InternalCompilerInterface.UncheckedRefRO<ClientInputNonPartialStateCD>, InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<PlayerGhost>, InternalCompilerInterface.UncheckedRefRO<PlayerAimPositionCD>>(InternalCompilerInterface.UnsafeGetUncheckedRefRO<ClientInput>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<ClientInputNonPartialStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlayerStateCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquippedObjectCD>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquipmentSlotCD>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlayerGhost>(item6_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlayerAimPositionCD>(item7_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ClientInput> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<ClientInputNonPartialStateCD> item2_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<PlayerStateCD> item3_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> item4_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotCD> item5_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<PlayerGhost> item6_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<PlayerAimPositionCD> item7_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ClientInputNonPartialStateCD>(isReadOnly: true);
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				item5_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
				item6_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
				item7_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlayerAimPositionCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
				item5_ComponentTypeHandle_RO.Update(ref systemState);
				item6_ComponentTypeHandle_RO.Update(ref systemState);
				item7_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO),
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RO),
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RO),
					item7_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item7_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ClientInput>, InternalCompilerInterface.UncheckedRefRO<ClientInputNonPartialStateCD>, InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<PlayerGhost>, InternalCompilerInterface.UncheckedRefRO<PlayerAimPositionCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ClientInput>, InternalCompilerInterface.UncheckedRefRO<ClientInputNonPartialStateCD>, InternalCompilerInterface.UncheckedRefRO<PlayerStateCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, InternalCompilerInterface.UncheckedRefRO<PlayerGhost>, InternalCompilerInterface.UncheckedRefRO<PlayerAimPositionCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
			state.EntityManager.CompleteDependencyBeforeRO<ClientInputNonPartialStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAimPositionCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1035980960_0.TypeHandle __IFE_1035980960_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<PredictedGhost> __Unity_NetCode_PredictedGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BeamWeaponCD> __BeamWeaponCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BeamWeaponAttackCD> __BeamWeaponAttackCD_RO_ComponentLookup;

		public BufferLookup<PlayerChainTargetsBuffer> __PlayerChainTargetsBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<AnimationOrientationCD> __AnimationOrientationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1035980960_0_TypeHandle = new IFE_1035980960_0.TypeHandle(ref state);
			__Unity_NetCode_PredictedGhost_RO_ComponentLookup = state.GetComponentLookup<PredictedGhost>(isReadOnly: true);
			__BeamWeaponCD_RO_ComponentLookup = state.GetComponentLookup<BeamWeaponCD>(isReadOnly: true);
			__BeamWeaponAttackCD_RO_ComponentLookup = state.GetComponentLookup<BeamWeaponAttackCD>(isReadOnly: true);
			__PlayerChainTargetsBuffer_RW_BufferLookup = state.GetBufferLookup<PlayerChainTargetsBuffer>();
			__AnimationOrientationCD_RO_ComponentLookup = state.GetComponentLookup<AnimationOrientationCD>(isReadOnly: true);
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1035980960_0;

	private EntityQuery __query_1035980960_1;

	private EntityQuery __query_1035980960_2;

	private EntityQuery __query_1035980960_3;

	public void OnUpdate(ref SystemState state)
	{
		__query_1035980960_1.TryGetSingleton<WorldInfoCD>(out var value);
		__query_1035980960_2.TryGetSingleton<PugDatabase.DatabaseBankCD>(out var value2);
		__query_1035980960_3.TryGetSingleton<NetworkTime>(out var value3);
		ComponentLookup<PredictedGhost> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_PredictedGhost_RO_ComponentLookup, ref state);
		ComponentLookup<BeamWeaponCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BeamWeaponCD_RO_ComponentLookup, ref state);
		foreach (var (uncheckedRefRO8, uncheckedRefRO9, uncheckedRefRO10, uncheckedRefRO11, uncheckedRefRO12, uncheckedRefRO13, uncheckedRefRO14, entity2) in IFE_1035980960_0.Query(__query_1035980960_0, __TypeHandle.__IFE_1035980960_0_TypeHandle, ref state))
		{
			if (Manager.memory.GetEntityMono(entity2) is PlayerController { visuallyEquippedContainedObject: var visuallyEquippedContainedObject } playerController)
			{
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(visuallyEquippedContainedObject.objectID, value2.databaseBankBlob);
				ClientInput clientInput = uncheckedRefRO8.ValueRO;
				clientInput.SetButtonState(CommandInputButtonStateNames.Interact_HeldDown, uncheckedRefRO9.ValueRO.interactHeldDown);
				bool flag = uncheckedRefRO10.ValueRO.HasAnyState(PlayerStateEnum.SpawningFromCore | PlayerStateEnum.Death | PlayerStateEnum.VehicleRiding | PlayerStateEnum.Sitting);
				bool interactHeldDown = uncheckedRefRO9.ValueRO.interactHeldDown;
				bool flag2 = entityObjectInfo.objectType == ObjectType.DrillTool;
				bool flag3 = flag2 && visuallyEquippedContainedObject.amount > 0 && interactHeldDown && !flag;
				playerController.specialWeaponHandler.UpdateDrillTool(flag3, flag2, visuallyEquippedContainedObject);
				ObjectType num = ((entityObjectInfo.objectID != ObjectID.None) ? entityObjectInfo.objectType : ObjectType.NonUsable);
				bool beamToolEquipped = num == ObjectType.BeamWeapon;
				BeamWeaponAttackCD beamWeaponAttackCD = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__BeamWeaponAttackCD_RO_ComponentLookup, ref state, entity2);
				bool flag4 = BeamTargetUpdateSystem.BeamTargetUpdateJob.IsBeamActive(currentTick: EntityUtility.GetCurrentTickOnClientNoFraction(entity2, value3, componentLookup), objectType: num, equippedObjectCD: in uncheckedRefRO11.ValueRO, interactHeldDown: interactHeldDown, playerStateCD: in uncheckedRefRO10.ValueRO, worldInfoCD: in value, playerGhost: in uncheckedRefRO13.ValueRO, equipmentSlotCD: in uncheckedRefRO12.ValueRO, clientInput: in clientInput, beamWeaponAttackCD: in beamWeaponAttackCD);
				DynamicBuffer<PlayerChainTargetsBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__PlayerChainTargetsBuffer_RW_BufferLookup, ref state, entity2);
				AnimationOrientationCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__AnimationOrientationCD_RO_ComponentLookup, ref state, entity2);
				PlayerStateCD componentAfterCompletingDependency2 = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup, ref state, entity2);
				LocalTransform componentAfterCompletingDependency3 = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, entity2);
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(visuallyEquippedContainedObject.objectID, value2.databaseBankBlob);
				componentLookup2.TryGetComponent(primaryPrefabEntity, out var componentData);
				playerController.specialWeaponHandler.UpdateBeamWeaponVisuals(flag4, beamToolEquipped, visuallyEquippedContainedObject, uncheckedRefRO14.ValueRO, componentAfterCompletingDependency, componentAfterCompletingDependency2, componentAfterCompletingDependency3, bufferAfterCompletingDependency, componentData);
				bool useRangedLoopAnimation = componentData.useRangedLoopAnimation;
				playerController.specialWeaponHandler.SetDrillingAnimation(!useRangedLoopAnimation && (flag3 || flag4));
				playerController.specialWeaponHandler.SetLoopRangedAnimation(useRangedLoopAnimation && (flag3 || flag4));
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInputNonPartialStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerAimPositionCD>();
		__query_1035980960_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1035980960_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1035980960_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1035980960_3 = entityQueryBuilder2.Build(ref state);
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
		((SpecialWeaponUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SpecialWeaponUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
