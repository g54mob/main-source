using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using Pug.Properties;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

[BurstCompile]
[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct EquipmentPresentationUpdateSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1978689212_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			public BufferAccessor<PlacementSizeByEquipmentTypeBuffer> item5_BufferAccessor;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<EquippedObjectVisualCD>, InternalCompilerInterface.UncheckedRefRO<PlacementCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<EquippedObjectVisualCD>, InternalCompilerInterface.UncheckedRefRO<PlacementCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<EquippedObjectVisualCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlacementCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquippedObjectCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EquipmentSlotCD>(item4_IntPtr, index), item5_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<EquippedObjectVisualCD> item1_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<PlacementCD> item2_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> item3_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotCD> item4_ComponentTypeHandle_RO;

			private BufferTypeHandle<PlacementSizeByEquipmentTypeBuffer> item5_BufferTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<EquippedObjectVisualCD>();
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlacementCD>(isReadOnly: true);
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
				item5_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<PlacementSizeByEquipmentTypeBuffer>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
				item5_BufferTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO),
					item5_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item5_BufferTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<EquippedObjectVisualCD>, InternalCompilerInterface.UncheckedRefRO<PlacementCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<EquippedObjectVisualCD>, InternalCompilerInterface.UncheckedRefRO<PlacementCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<EquippedObjectVisualCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlacementSizeByEquipmentTypeBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1978689212_0.TypeHandle __IFE_1978689212_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ResizableTileSizeCD> __ResizableTileSizeCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1978689212_0_TypeHandle = new IFE_1978689212_0.TypeHandle(ref state);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__ResizableTileSizeCD_RO_ComponentLookup = state.GetComponentLookup<ResizableTileSizeCD>(isReadOnly: true);
			__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001D6B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001D6B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001D6B_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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

	private EntityQuery __query_1978689212_0;

	private EntityQuery __query_1978689212_1;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
	}

	public void OnUpdate(ref SystemState state)
	{
		ComponentLookup<DirectionCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state);
		ComponentLookup<ResizableTileSizeCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ResizableTileSizeCD_RO_ComponentLookup, ref state);
		ComponentLookup<DirectionBasedOnVariationCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state);
		ComponentLookup<ObjectPropertiesCD> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state);
		PugDatabase.DatabaseBankCD singleton = __query_1978689212_1.GetSingleton<PugDatabase.DatabaseBankCD>();
		state.Dependency.Complete();
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<EquippedObjectVisualCD>, InternalCompilerInterface.UncheckedRefRO<PlacementCD>, InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD>, InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD>, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer>> item6 in IFE_1978689212_0.Query(__query_1978689212_0, __TypeHandle.__IFE_1978689212_0_TypeHandle, ref state))
		{
			item6.Deconstruct(out var item, out var item2, out var item3, out var item4, out var item5, out var entity);
			InternalCompilerInterface.UncheckedRefRW<EquippedObjectVisualCD> uncheckedRefRW = item;
			InternalCompilerInterface.UncheckedRefRO<PlacementCD> uncheckedRefRO = item2;
			InternalCompilerInterface.UncheckedRefRO<EquippedObjectCD> uncheckedRefRO2 = item3;
			InternalCompilerInterface.UncheckedRefRO<EquipmentSlotCD> uncheckedRefRO3 = item4;
			DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> dynamicBuffer = item5;
			Entity entity2 = entity;
			EquippedObjectCD valueRO = uncheckedRefRO2.ValueRO;
			ref EquippedObjectVisualCD valueRW = ref uncheckedRefRW.ValueRW;
			bool flag = valueRW.equippedSlotIndex != valueRO.equippedSlotIndex || !valueRW.containedObject.Equals(valueRO.containedObject);
			bool flag2 = valueRW.rotationVariationToPlace != uncheckedRefRO.ValueRO.rotationVariationToPlace;
			bool flag3 = valueRW.nonRotationVariationToPlace != uncheckedRefRO.ValueRO.nonRotationVariationToPlace;
			int num = (PlacementSizeByEquipmentTypeBufferExtensions.HasSizeVariationForEquipment(uncheckedRefRO3.ValueRO.slotType) ? dynamicBuffer.GetElementForEquipment(uncheckedRefRO3.ValueRO.slotType).sizeVariationToPlace : 0);
			bool flag4 = valueRW.sizeVariationToPlace != num;
			valueRW.equippedSlotIndex = valueRO.equippedSlotIndex;
			valueRW.containedObject = valueRO.containedObject;
			valueRW.rotationVariationToPlace = uncheckedRefRO.ValueRO.rotationVariationToPlace;
			valueRW.nonRotationVariationToPlace = uncheckedRefRO.ValueRO.nonRotationVariationToPlace;
			valueRW.sizeVariationToPlace = num;
			PlayerController playerController = (PlayerController)Manager.memory.GetEntityMono(entity2);
			if (!(playerController == null))
			{
				PlacementHandler placementHandler = null;
				EquipmentSlot equippedSlot = playerController.GetEquippedSlot();
				if (equippedSlot is PlaceObjectSlot placeObjectSlot)
				{
					placementHandler = placeObjectSlot.placementHandler;
				}
				else if (equippedSlot is HoeSlot hoeSlot)
				{
					placementHandler = hoeSlot.placementHandler;
				}
				else if (equippedSlot is RoofingToolSlot roofingToolSlot)
				{
					placementHandler = roofingToolSlot.placementHandler;
				}
				else if (equippedSlot is ShovelSlot shovelSlot)
				{
					placementHandler = shovelSlot.placementHandler;
				}
				else if (equippedSlot is SeederSlot seederSlot)
				{
					placementHandler = seederSlot.placementHandler;
				}
				if (!(placementHandler == null))
				{
					bool immediate = flag || flag2 || flag3 || flag4;
					placementHandler.UpdatePlaceIcon(immediate, in uncheckedRefRO.ValueRO, uncheckedRefRO2.ValueRO.containedObject.objectData, dynamicBuffer, uncheckedRefRO3.ValueRO, uncheckedRefRO2.ValueRO.equipmentPrefab, componentLookup, componentLookup2, componentLookup3, componentLookup4, singleton);
					placementHandler.placeableIcon.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquippedObjectVisualCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlacementSizeByEquipmentTypeBuffer>();
		__query_1978689212_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1978689212_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001D6B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((EquipmentPresentationUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EquipmentPresentationUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EquipmentPresentationUpdateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}
}
