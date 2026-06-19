using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PlacementIndicator;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using Unity.Transforms;

namespace PlayerEquipment
{
	public readonly struct AttackWithEquipmentAspect : IAspect, IQueryTypeParameter, IAspectCreate<AttackWithEquipmentAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<AttackWithEquipmentAspect>
		{
			private ComponentLookup<AnimationOrientationCD> AttackWithEquipmentAspect_animationOrientationCDCAc;

			private ComponentLookup<BeamWeaponAttackCD> AttackWithEquipmentAspect_beamWeaponAttackCDCAc;

			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> AttackWithEquipmentAspect_equippedObjectCDCAc;

			private BufferLookup<GhostEffectEventBuffer> AttackWithEquipmentAspect_ghostEffectEventBufferBAc;

			private ComponentLookup<GhostEffectEventBufferPointerCD> AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentLookup<ManaCD> AttackWithEquipmentAspect_playerManaCDCAc;

			private BufferLookup<NewConditionsBuffer> AttackWithEquipmentAspect_newConditionsBufferBAc;

			[ReadOnly]
			private ComponentLookup<PlacementIndicatorCD> AttackWithEquipmentAspect_placementIndicatorCDCAc;

			private ComponentLookup<PlayerAttackCooldownCD> AttackWithEquipmentAspect_attackCooldownTimerCDCAc;

			private ComponentLookup<EquipmentSlotCD> AttackWithEquipmentAspect_equipmentSlotCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerGhost> AttackWithEquipmentAspect_playerGhostCAc;

			private BufferLookup<SyncedPlayerSharedCooldownTimersCD> AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc;

			[ReadOnly]
			private ComponentLookup<GhostOwner> AttackWithEquipmentAspect_ghostOwnerCAc;

			[ReadOnly]
			private ComponentLookup<LocalTransform> AttackWithEquipmentAspect_localTransformCAc;

			public AttackWithEquipmentAspect this[Entity entity] => new AttackWithEquipmentAspect(AttackWithEquipmentAspect_animationOrientationCDCAc.GetRefRW(entity), AttackWithEquipmentAspect_beamWeaponAttackCDCAc.GetRefRW(entity), AttackWithEquipmentAspect_equippedObjectCDCAc.GetRefRO(entity), AttackWithEquipmentAspect_ghostEffectEventBufferBAc[entity], AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc.GetRefRW(entity), AttackWithEquipmentAspect_playerManaCDCAc.GetRefRW(entity), AttackWithEquipmentAspect_newConditionsBufferBAc[entity], AttackWithEquipmentAspect_placementIndicatorCDCAc.GetRefRO(entity), AttackWithEquipmentAspect_attackCooldownTimerCDCAc.GetRefRW(entity), AttackWithEquipmentAspect_equipmentSlotCDCAc.GetRefRW(entity), AttackWithEquipmentAspect_playerGhostCAc.GetRefRO(entity), AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc[entity], entity, AttackWithEquipmentAspect_ghostOwnerCAc.GetRefRO(entity), AttackWithEquipmentAspect_localTransformCAc.GetRefRO(entity));

			public Lookup(ref SystemState state)
			{
				AttackWithEquipmentAspect_animationOrientationCDCAc = state.GetComponentLookup<AnimationOrientationCD>();
				AttackWithEquipmentAspect_beamWeaponAttackCDCAc = state.GetComponentLookup<BeamWeaponAttackCD>();
				AttackWithEquipmentAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				AttackWithEquipmentAspect_ghostEffectEventBufferBAc = state.GetBufferLookup<GhostEffectEventBuffer>();
				AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
				AttackWithEquipmentAspect_playerManaCDCAc = state.GetComponentLookup<ManaCD>();
				AttackWithEquipmentAspect_newConditionsBufferBAc = state.GetBufferLookup<NewConditionsBuffer>();
				AttackWithEquipmentAspect_placementIndicatorCDCAc = state.GetComponentLookup<PlacementIndicatorCD>(isReadOnly: true);
				AttackWithEquipmentAspect_attackCooldownTimerCDCAc = state.GetComponentLookup<PlayerAttackCooldownCD>();
				AttackWithEquipmentAspect_equipmentSlotCDCAc = state.GetComponentLookup<EquipmentSlotCD>();
				AttackWithEquipmentAspect_playerGhostCAc = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc = state.GetBufferLookup<SyncedPlayerSharedCooldownTimersCD>();
				AttackWithEquipmentAspect_ghostOwnerCAc = state.GetComponentLookup<GhostOwner>(isReadOnly: true);
				AttackWithEquipmentAspect_localTransformCAc = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				AttackWithEquipmentAspect_animationOrientationCDCAc.Update(ref state);
				AttackWithEquipmentAspect_beamWeaponAttackCDCAc.Update(ref state);
				AttackWithEquipmentAspect_equippedObjectCDCAc.Update(ref state);
				AttackWithEquipmentAspect_ghostEffectEventBufferBAc.Update(ref state);
				AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				AttackWithEquipmentAspect_playerManaCDCAc.Update(ref state);
				AttackWithEquipmentAspect_newConditionsBufferBAc.Update(ref state);
				AttackWithEquipmentAspect_placementIndicatorCDCAc.Update(ref state);
				AttackWithEquipmentAspect_attackCooldownTimerCDCAc.Update(ref state);
				AttackWithEquipmentAspect_equipmentSlotCDCAc.Update(ref state);
				AttackWithEquipmentAspect_playerGhostCAc.Update(ref state);
				AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc.Update(ref state);
				AttackWithEquipmentAspect_ghostOwnerCAc.Update(ref state);
				AttackWithEquipmentAspect_localTransformCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public NativeArray<AnimationOrientationCD> AttackWithEquipmentAspect_animationOrientationCDNaC;

			public NativeArray<BeamWeaponAttackCD> AttackWithEquipmentAspect_beamWeaponAttackCDNaC;

			public NativeArray<EquippedObjectCD> AttackWithEquipmentAspect_equippedObjectCDNaC;

			public BufferAccessor<GhostEffectEventBuffer> AttackWithEquipmentAspect_ghostEffectEventBufferBa;

			public NativeArray<GhostEffectEventBufferPointerCD> AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDNaC;

			public NativeArray<ManaCD> AttackWithEquipmentAspect_playerManaCDNaC;

			public BufferAccessor<NewConditionsBuffer> AttackWithEquipmentAspect_newConditionsBufferBa;

			public NativeArray<PlacementIndicatorCD> AttackWithEquipmentAspect_placementIndicatorCDNaC;

			public NativeArray<PlayerAttackCooldownCD> AttackWithEquipmentAspect_attackCooldownTimerCDNaC;

			public NativeArray<EquipmentSlotCD> AttackWithEquipmentAspect_equipmentSlotCDNaC;

			public NativeArray<PlayerGhost> AttackWithEquipmentAspect_playerGhostNaC;

			public BufferAccessor<SyncedPlayerSharedCooldownTimersCD> AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBa;

			public NativeArray<Entity> AttackWithEquipmentAspect_entityNaE;

			public NativeArray<GhostOwner> AttackWithEquipmentAspect_ghostOwnerNaC;

			public NativeArray<LocalTransform> AttackWithEquipmentAspect_localTransformNaC;

			public int Length;

			public AttackWithEquipmentAspect this[int index] => new AttackWithEquipmentAspect(new RefRW<AnimationOrientationCD>(AttackWithEquipmentAspect_animationOrientationCDNaC, index), new RefRW<BeamWeaponAttackCD>(AttackWithEquipmentAspect_beamWeaponAttackCDNaC, index), new RefRO<EquippedObjectCD>(AttackWithEquipmentAspect_equippedObjectCDNaC, index), AttackWithEquipmentAspect_ghostEffectEventBufferBa[index], new RefRW<GhostEffectEventBufferPointerCD>(AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDNaC, index), new RefRW<ManaCD>(AttackWithEquipmentAspect_playerManaCDNaC, index), AttackWithEquipmentAspect_newConditionsBufferBa[index], new RefRO<PlacementIndicatorCD>(AttackWithEquipmentAspect_placementIndicatorCDNaC, index), new RefRW<PlayerAttackCooldownCD>(AttackWithEquipmentAspect_attackCooldownTimerCDNaC, index), new RefRW<EquipmentSlotCD>(AttackWithEquipmentAspect_equipmentSlotCDNaC, index), new RefRO<PlayerGhost>(AttackWithEquipmentAspect_playerGhostNaC, index), AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBa[index], AttackWithEquipmentAspect_entityNaE[index], new RefRO<GhostOwner>(AttackWithEquipmentAspect_ghostOwnerNaC, index), new RefRO<LocalTransform>(AttackWithEquipmentAspect_localTransformNaC, index));
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<AnimationOrientationCD> AttackWithEquipmentAspect_animationOrientationCDCAc;

			private ComponentTypeHandle<BeamWeaponAttackCD> AttackWithEquipmentAspect_beamWeaponAttackCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> AttackWithEquipmentAspect_equippedObjectCDCAc;

			private BufferTypeHandle<GhostEffectEventBuffer> AttackWithEquipmentAspect_ghostEffectEventBufferBAc;

			private ComponentTypeHandle<GhostEffectEventBufferPointerCD> AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentTypeHandle<ManaCD> AttackWithEquipmentAspect_playerManaCDCAc;

			private BufferTypeHandle<NewConditionsBuffer> AttackWithEquipmentAspect_newConditionsBufferBAc;

			[ReadOnly]
			private ComponentTypeHandle<PlacementIndicatorCD> AttackWithEquipmentAspect_placementIndicatorCDCAc;

			private ComponentTypeHandle<PlayerAttackCooldownCD> AttackWithEquipmentAspect_attackCooldownTimerCDCAc;

			private ComponentTypeHandle<EquipmentSlotCD> AttackWithEquipmentAspect_equipmentSlotCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerGhost> AttackWithEquipmentAspect_playerGhostCAc;

			private BufferTypeHandle<SyncedPlayerSharedCooldownTimersCD> AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc;

			private EntityTypeHandle AttackWithEquipmentAspect_entityEAc;

			[ReadOnly]
			private ComponentTypeHandle<GhostOwner> AttackWithEquipmentAspect_ghostOwnerCAc;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> AttackWithEquipmentAspect_localTransformCAc;

			public TypeHandle(ref SystemState state)
			{
				AttackWithEquipmentAspect_animationOrientationCDCAc = state.GetComponentTypeHandle<AnimationOrientationCD>();
				AttackWithEquipmentAspect_beamWeaponAttackCDCAc = state.GetComponentTypeHandle<BeamWeaponAttackCD>();
				AttackWithEquipmentAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				AttackWithEquipmentAspect_ghostEffectEventBufferBAc = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
				AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
				AttackWithEquipmentAspect_playerManaCDCAc = state.GetComponentTypeHandle<ManaCD>();
				AttackWithEquipmentAspect_newConditionsBufferBAc = state.GetBufferTypeHandle<NewConditionsBuffer>();
				AttackWithEquipmentAspect_placementIndicatorCDCAc = state.GetComponentTypeHandle<PlacementIndicatorCD>(isReadOnly: true);
				AttackWithEquipmentAspect_attackCooldownTimerCDCAc = state.GetComponentTypeHandle<PlayerAttackCooldownCD>();
				AttackWithEquipmentAspect_equipmentSlotCDCAc = state.GetComponentTypeHandle<EquipmentSlotCD>();
				AttackWithEquipmentAspect_playerGhostCAc = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
				AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc = state.GetBufferTypeHandle<SyncedPlayerSharedCooldownTimersCD>();
				AttackWithEquipmentAspect_entityEAc = state.GetEntityTypeHandle();
				AttackWithEquipmentAspect_ghostOwnerCAc = state.GetComponentTypeHandle<GhostOwner>(isReadOnly: true);
				AttackWithEquipmentAspect_localTransformCAc = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				AttackWithEquipmentAspect_animationOrientationCDCAc.Update(ref state);
				AttackWithEquipmentAspect_beamWeaponAttackCDCAc.Update(ref state);
				AttackWithEquipmentAspect_equippedObjectCDCAc.Update(ref state);
				AttackWithEquipmentAspect_ghostEffectEventBufferBAc.Update(ref state);
				AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				AttackWithEquipmentAspect_playerManaCDCAc.Update(ref state);
				AttackWithEquipmentAspect_newConditionsBufferBAc.Update(ref state);
				AttackWithEquipmentAspect_placementIndicatorCDCAc.Update(ref state);
				AttackWithEquipmentAspect_attackCooldownTimerCDCAc.Update(ref state);
				AttackWithEquipmentAspect_equipmentSlotCDCAc.Update(ref state);
				AttackWithEquipmentAspect_playerGhostCAc.Update(ref state);
				AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc.Update(ref state);
				AttackWithEquipmentAspect_entityEAc.Update(ref state);
				AttackWithEquipmentAspect_ghostOwnerCAc.Update(ref state);
				AttackWithEquipmentAspect_localTransformCAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.AttackWithEquipmentAspect_animationOrientationCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_animationOrientationCDCAc);
				result.AttackWithEquipmentAspect_beamWeaponAttackCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_beamWeaponAttackCDCAc);
				result.AttackWithEquipmentAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_equippedObjectCDCAc);
				result.AttackWithEquipmentAspect_ghostEffectEventBufferBa = chunk.GetBufferAccessor(ref AttackWithEquipmentAspect_ghostEffectEventBufferBAc);
				result.AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_ghostEffectEventBufferPointerCDCAc);
				result.AttackWithEquipmentAspect_playerManaCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_playerManaCDCAc);
				result.AttackWithEquipmentAspect_newConditionsBufferBa = chunk.GetBufferAccessor(ref AttackWithEquipmentAspect_newConditionsBufferBAc);
				result.AttackWithEquipmentAspect_placementIndicatorCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_placementIndicatorCDCAc);
				result.AttackWithEquipmentAspect_attackCooldownTimerCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_attackCooldownTimerCDCAc);
				result.AttackWithEquipmentAspect_equipmentSlotCDNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_equipmentSlotCDCAc);
				result.AttackWithEquipmentAspect_playerGhostNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_playerGhostCAc);
				result.AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBa = chunk.GetBufferAccessor(ref AttackWithEquipmentAspect_syncedSharedCooldownTimersCDBAc);
				result.AttackWithEquipmentAspect_entityNaE = chunk.GetNativeArray(AttackWithEquipmentAspect_entityEAc);
				result.AttackWithEquipmentAspect_ghostOwnerNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_ghostOwnerCAc);
				result.AttackWithEquipmentAspect_localTransformNaC = chunk.GetNativeArray(ref AttackWithEquipmentAspect_localTransformCAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<AttackWithEquipmentAspect>, IEnumerator, IDisposable, IEnumerable<AttackWithEquipmentAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public AttackWithEquipmentAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			internal Enumerator(EntityQuery query, TypeHandle typeHandle)
			{
				_QueryEnumerator = new InternalEntityQueryEnumerator(query);
				_Handle = typeHandle;
				_Resolved = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_QueryEnumerator.Dispose();
			}

			public bool MoveNext()
			{
				if (_QueryEnumerator.MoveNextHotLoop())
				{
					return true;
				}
				return MoveNextCold();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool MoveNextCold()
			{
				ArchetypeChunk chunk;
				bool num = _QueryEnumerator.MoveNextColdLoop(out chunk);
				if (num)
				{
					_Resolved = _Handle.Resolve(chunk);
				}
				return num;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			void IEnumerator.Reset()
			{
				throw new NotImplementedException();
			}

			IEnumerator<AttackWithEquipmentAspect> IEnumerable<AttackWithEquipmentAspect>.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public readonly Entity entity;

		public readonly RefRW<EquipmentSlotCD> equipmentSlotCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly RefRW<PlayerAttackCooldownCD> attackCooldownTimerCD;

		public readonly RefRW<ManaCD> playerManaCD;

		public readonly RefRO<LocalTransform> localTransform;

		public readonly RefRO<GhostOwner> ghostOwner;

		public readonly DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> syncedSharedCooldownTimersCD;

		public readonly RefRW<AnimationOrientationCD> animationOrientationCD;

		public readonly DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer;

		public readonly RefRW<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerCD;

		public readonly RefRO<PlayerGhost> playerGhost;

		public readonly RefRO<PlacementIndicatorCD> placementIndicatorCD;

		public readonly RefRW<BeamWeaponAttackCD> beamWeaponAttackCD;

		public readonly DynamicBuffer<NewConditionsBuffer> newConditionsBuffer;

		public AttackWithEquipmentAspect(RefRW<AnimationOrientationCD> attackwithequipmentaspect_animationorientationcdRef, RefRW<BeamWeaponAttackCD> attackwithequipmentaspect_beamweaponattackcdRef, RefRO<EquippedObjectCD> attackwithequipmentaspect_equippedobjectcdRef, DynamicBuffer<GhostEffectEventBuffer> attackwithequipmentaspect_ghosteffecteventbufferDb, RefRW<GhostEffectEventBufferPointerCD> attackwithequipmentaspect_ghosteffecteventbufferpointercdRef, RefRW<ManaCD> attackwithequipmentaspect_playermanacdRef, DynamicBuffer<NewConditionsBuffer> attackwithequipmentaspect_newconditionsbufferDb, RefRO<PlacementIndicatorCD> attackwithequipmentaspect_placementindicatorcdRef, RefRW<PlayerAttackCooldownCD> attackwithequipmentaspect_attackcooldowntimercdRef, RefRW<EquipmentSlotCD> attackwithequipmentaspect_equipmentslotcdRef, RefRO<PlayerGhost> attackwithequipmentaspect_playerghostRef, DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> attackwithequipmentaspect_syncedsharedcooldowntimerscdDb, Entity attackwithequipmentaspect_entityE, RefRO<GhostOwner> attackwithequipmentaspect_ghostownerRef, RefRO<LocalTransform> attackwithequipmentaspect_localtransformRef)
		{
			animationOrientationCD = attackwithequipmentaspect_animationorientationcdRef;
			beamWeaponAttackCD = attackwithequipmentaspect_beamweaponattackcdRef;
			equippedObjectCD = attackwithequipmentaspect_equippedobjectcdRef;
			ghostEffectEventBuffer = attackwithequipmentaspect_ghosteffecteventbufferDb;
			ghostEffectEventBufferPointerCD = attackwithequipmentaspect_ghosteffecteventbufferpointercdRef;
			playerManaCD = attackwithequipmentaspect_playermanacdRef;
			newConditionsBuffer = attackwithequipmentaspect_newconditionsbufferDb;
			placementIndicatorCD = attackwithequipmentaspect_placementindicatorcdRef;
			attackCooldownTimerCD = attackwithequipmentaspect_attackcooldowntimercdRef;
			equipmentSlotCD = attackwithequipmentaspect_equipmentslotcdRef;
			playerGhost = attackwithequipmentaspect_playerghostRef;
			syncedSharedCooldownTimersCD = attackwithequipmentaspect_syncedsharedcooldowntimerscdDb;
			entity = attackwithequipmentaspect_entityE;
			ghostOwner = attackwithequipmentaspect_ghostownerRef;
			localTransform = attackwithequipmentaspect_localtransformRef;
		}

		public AttackWithEquipmentAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadWrite<AnimationOrientationCD>());
			unsafeList.Add(ComponentType.ReadWrite<BeamWeaponAttackCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>());
			unsafeList.Add(ComponentType.ReadWrite<ManaCD>());
			unsafeList.Add(ComponentType.ReadWrite<NewConditionsBuffer>());
			unsafeList.Add(ComponentType.ReadOnly<PlacementIndicatorCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAttackCooldownCD>());
			unsafeList.Add(ComponentType.ReadWrite<EquipmentSlotCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerGhost>());
			unsafeList.Add(ComponentType.ReadWrite<SyncedPlayerSharedCooldownTimersCD>());
			unsafeList.Add(ComponentType.ReadOnly<GhostOwner>());
			unsafeList.Add(ComponentType.ReadOnly<LocalTransform>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 14;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadWrite<AnimationOrientationCD>();
			componentTypes[1] = ComponentType.ReadWrite<BeamWeaponAttackCD>();
			componentTypes[2] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[3] = ComponentType.ReadWrite<GhostEffectEventBuffer>();
			componentTypes[4] = ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>();
			componentTypes[5] = ComponentType.ReadWrite<ManaCD>();
			componentTypes[6] = ComponentType.ReadWrite<NewConditionsBuffer>();
			componentTypes[7] = ComponentType.ReadOnly<PlacementIndicatorCD>();
			componentTypes[8] = ComponentType.ReadWrite<PlayerAttackCooldownCD>();
			componentTypes[9] = ComponentType.ReadWrite<EquipmentSlotCD>();
			componentTypes[10] = ComponentType.ReadOnly<PlayerGhost>();
			componentTypes[11] = ComponentType.ReadWrite<SyncedPlayerSharedCooldownTimersCD>();
			componentTypes[12] = ComponentType.ReadOnly<GhostOwner>();
			componentTypes[13] = ComponentType.ReadOnly<LocalTransform>();
		}

		public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
		{
			return new Enumerator(query, typeHandle);
		}

		public void CompleteDependencyBeforeRO(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<AnimationOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<BeamWeaponAttackCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ManaCD>();
			state.EntityManager.CompleteDependencyBeforeRO<NewConditionsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementIndicatorCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAttackCooldownCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRO<SyncedPlayerSharedCooldownTimersCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostOwner>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}

		public void CompleteDependencyBeforeRW(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<AnimationOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRW<BeamWeaponAttackCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ManaCD>();
			state.EntityManager.CompleteDependencyBeforeRW<NewConditionsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementIndicatorCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAttackCooldownCD>();
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRW<SyncedPlayerSharedCooldownTimersCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostOwner>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}
	}
}
