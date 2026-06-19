using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;

namespace PlayerState
{
	public readonly struct ChangePlayerStatePresentationAspect : IAspect, IQueryTypeParameter, IAspectCreate<ChangePlayerStatePresentationAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<ChangePlayerStatePresentationAspect>
		{
			[ReadOnly]
			private ComponentLookup<CharacterTypeCD> ChangePlayerStatePresentationAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentLookup<ClientInput> ChangePlayerStatePresentationAspect_clientInputCAc;

			[ReadOnly]
			private ComponentLookup<ControllingOtherEntityCD> ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> ChangePlayerStatePresentationAspect_equippedObjectCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerClaimedBed> ChangePlayerStatePresentationAspect_playerClaimedBedCAc;

			[ReadOnly]
			private ComponentLookup<DeathStateCD> ChangePlayerStatePresentationAspect_deathStateCDCAc;

			[ReadOnly]
			private ComponentLookup<FishingStateCD> ChangePlayerStatePresentationAspect_fishingStateCAc;

			[ReadOnly]
			private ComponentLookup<PlayerSleepStateCD> ChangePlayerStatePresentationAspect_sleepStateCDCAc;

			private ComponentLookup<PlayerStateCD> ChangePlayerStatePresentationAspect_playerStateCDCAc;

			[ReadOnly]
			private ComponentLookup<SittingStateCD> ChangePlayerStatePresentationAspect_sittingStateCDCAc;

			private ComponentLookup<TeleportingStateCD> ChangePlayerStatePresentationAspect_teleportingStateCDCAc;

			[ReadOnly]
			private ComponentLookup<VehicleRidingStateCD> ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc;

			public ChangePlayerStatePresentationAspect this[Entity entity] => new ChangePlayerStatePresentationAspect(ChangePlayerStatePresentationAspect_characterTypeCDCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_clientInputCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_equippedObjectCDCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_playerClaimedBedCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_deathStateCDCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_fishingStateCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_sleepStateCDCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_playerStateCDCAc.GetRefRW(entity), ChangePlayerStatePresentationAspect_sittingStateCDCAc.GetRefRO(entity), ChangePlayerStatePresentationAspect_teleportingStateCDCAc.GetRefRW(entity), ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc.GetRefRO(entity), entity);

			public Lookup(ref SystemState state)
			{
				ChangePlayerStatePresentationAspect_characterTypeCDCAc = state.GetComponentLookup<CharacterTypeCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_clientInputCAc = state.GetComponentLookup<ClientInput>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc = state.GetComponentLookup<ControllingOtherEntityCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_playerClaimedBedCAc = state.GetComponentLookup<PlayerClaimedBed>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_deathStateCDCAc = state.GetComponentLookup<DeathStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_fishingStateCAc = state.GetComponentLookup<FishingStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_sleepStateCDCAc = state.GetComponentLookup<PlayerSleepStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>();
				ChangePlayerStatePresentationAspect_sittingStateCDCAc = state.GetComponentLookup<SittingStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_teleportingStateCDCAc = state.GetComponentLookup<TeleportingStateCD>();
				ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc = state.GetComponentLookup<VehicleRidingStateCD>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				ChangePlayerStatePresentationAspect_characterTypeCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_clientInputCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_equippedObjectCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_playerClaimedBedCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_deathStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_fishingStateCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_sleepStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_playerStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_sittingStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_teleportingStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public NativeArray<CharacterTypeCD> ChangePlayerStatePresentationAspect_characterTypeCDNaC;

			public NativeArray<ClientInput> ChangePlayerStatePresentationAspect_clientInputNaC;

			public NativeArray<ControllingOtherEntityCD> ChangePlayerStatePresentationAspect_controllingOtherEntityCDNaC;

			public NativeArray<EquippedObjectCD> ChangePlayerStatePresentationAspect_equippedObjectCDNaC;

			public NativeArray<PlayerClaimedBed> ChangePlayerStatePresentationAspect_playerClaimedBedNaC;

			public NativeArray<DeathStateCD> ChangePlayerStatePresentationAspect_deathStateCDNaC;

			public NativeArray<FishingStateCD> ChangePlayerStatePresentationAspect_fishingStateNaC;

			public NativeArray<PlayerSleepStateCD> ChangePlayerStatePresentationAspect_sleepStateCDNaC;

			public NativeArray<PlayerStateCD> ChangePlayerStatePresentationAspect_playerStateCDNaC;

			public NativeArray<SittingStateCD> ChangePlayerStatePresentationAspect_sittingStateCDNaC;

			public NativeArray<TeleportingStateCD> ChangePlayerStatePresentationAspect_teleportingStateCDNaC;

			public NativeArray<VehicleRidingStateCD> ChangePlayerStatePresentationAspect_vehicleRidingStateCDNaC;

			public NativeArray<Entity> ChangePlayerStatePresentationAspect_entityNaE;

			public int Length;

			public ChangePlayerStatePresentationAspect this[int index] => new ChangePlayerStatePresentationAspect(new RefRO<CharacterTypeCD>(ChangePlayerStatePresentationAspect_characterTypeCDNaC, index), new RefRO<ClientInput>(ChangePlayerStatePresentationAspect_clientInputNaC, index), new RefRO<ControllingOtherEntityCD>(ChangePlayerStatePresentationAspect_controllingOtherEntityCDNaC, index), new RefRO<EquippedObjectCD>(ChangePlayerStatePresentationAspect_equippedObjectCDNaC, index), new RefRO<PlayerClaimedBed>(ChangePlayerStatePresentationAspect_playerClaimedBedNaC, index), new RefRO<DeathStateCD>(ChangePlayerStatePresentationAspect_deathStateCDNaC, index), new RefRO<FishingStateCD>(ChangePlayerStatePresentationAspect_fishingStateNaC, index), new RefRO<PlayerSleepStateCD>(ChangePlayerStatePresentationAspect_sleepStateCDNaC, index), new RefRW<PlayerStateCD>(ChangePlayerStatePresentationAspect_playerStateCDNaC, index), new RefRO<SittingStateCD>(ChangePlayerStatePresentationAspect_sittingStateCDNaC, index), new RefRW<TeleportingStateCD>(ChangePlayerStatePresentationAspect_teleportingStateCDNaC, index), new RefRO<VehicleRidingStateCD>(ChangePlayerStatePresentationAspect_vehicleRidingStateCDNaC, index), ChangePlayerStatePresentationAspect_entityNaE[index]);
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<CharacterTypeCD> ChangePlayerStatePresentationAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<ClientInput> ChangePlayerStatePresentationAspect_clientInputCAc;

			[ReadOnly]
			private ComponentTypeHandle<ControllingOtherEntityCD> ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> ChangePlayerStatePresentationAspect_equippedObjectCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerClaimedBed> ChangePlayerStatePresentationAspect_playerClaimedBedCAc;

			[ReadOnly]
			private ComponentTypeHandle<DeathStateCD> ChangePlayerStatePresentationAspect_deathStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<FishingStateCD> ChangePlayerStatePresentationAspect_fishingStateCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerSleepStateCD> ChangePlayerStatePresentationAspect_sleepStateCDCAc;

			private ComponentTypeHandle<PlayerStateCD> ChangePlayerStatePresentationAspect_playerStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<SittingStateCD> ChangePlayerStatePresentationAspect_sittingStateCDCAc;

			private ComponentTypeHandle<TeleportingStateCD> ChangePlayerStatePresentationAspect_teleportingStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<VehicleRidingStateCD> ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc;

			private EntityTypeHandle ChangePlayerStatePresentationAspect_entityEAc;

			public TypeHandle(ref SystemState state)
			{
				ChangePlayerStatePresentationAspect_characterTypeCDCAc = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_clientInputCAc = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc = state.GetComponentTypeHandle<ControllingOtherEntityCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_playerClaimedBedCAc = state.GetComponentTypeHandle<PlayerClaimedBed>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_deathStateCDCAc = state.GetComponentTypeHandle<DeathStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_fishingStateCAc = state.GetComponentTypeHandle<FishingStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_sleepStateCDCAc = state.GetComponentTypeHandle<PlayerSleepStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>();
				ChangePlayerStatePresentationAspect_sittingStateCDCAc = state.GetComponentTypeHandle<SittingStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_teleportingStateCDCAc = state.GetComponentTypeHandle<TeleportingStateCD>();
				ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc = state.GetComponentTypeHandle<VehicleRidingStateCD>(isReadOnly: true);
				ChangePlayerStatePresentationAspect_entityEAc = state.GetEntityTypeHandle();
			}

			public void Update(ref SystemState state)
			{
				ChangePlayerStatePresentationAspect_characterTypeCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_clientInputCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_equippedObjectCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_playerClaimedBedCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_deathStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_fishingStateCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_sleepStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_playerStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_sittingStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_teleportingStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc.Update(ref state);
				ChangePlayerStatePresentationAspect_entityEAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.ChangePlayerStatePresentationAspect_characterTypeCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_characterTypeCDCAc);
				result.ChangePlayerStatePresentationAspect_clientInputNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_clientInputCAc);
				result.ChangePlayerStatePresentationAspect_controllingOtherEntityCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_controllingOtherEntityCDCAc);
				result.ChangePlayerStatePresentationAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_equippedObjectCDCAc);
				result.ChangePlayerStatePresentationAspect_playerClaimedBedNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_playerClaimedBedCAc);
				result.ChangePlayerStatePresentationAspect_deathStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_deathStateCDCAc);
				result.ChangePlayerStatePresentationAspect_fishingStateNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_fishingStateCAc);
				result.ChangePlayerStatePresentationAspect_sleepStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_sleepStateCDCAc);
				result.ChangePlayerStatePresentationAspect_playerStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_playerStateCDCAc);
				result.ChangePlayerStatePresentationAspect_sittingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_sittingStateCDCAc);
				result.ChangePlayerStatePresentationAspect_teleportingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_teleportingStateCDCAc);
				result.ChangePlayerStatePresentationAspect_vehicleRidingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStatePresentationAspect_vehicleRidingStateCDCAc);
				result.ChangePlayerStatePresentationAspect_entityNaE = chunk.GetNativeArray(ChangePlayerStatePresentationAspect_entityEAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<ChangePlayerStatePresentationAspect>, IEnumerator, IDisposable, IEnumerable<ChangePlayerStatePresentationAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public ChangePlayerStatePresentationAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

			IEnumerator<ChangePlayerStatePresentationAspect> IEnumerable<ChangePlayerStatePresentationAspect>.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public readonly Entity entity;

		public readonly RefRW<PlayerStateCD> playerStateCD;

		public readonly RefRO<CharacterTypeCD> characterTypeCD;

		public readonly RefRO<DeathStateCD> deathStateCD;

		public readonly RefRW<TeleportingStateCD> teleportingStateCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly RefRO<PlayerSleepStateCD> sleepStateCD;

		public readonly RefRO<PlayerClaimedBed> playerClaimedBed;

		public readonly RefRO<SittingStateCD> sittingStateCD;

		public readonly RefRO<VehicleRidingStateCD> vehicleRidingStateCD;

		public readonly RefRO<ControllingOtherEntityCD> controllingOtherEntityCD;

		public readonly RefRO<FishingStateCD> fishingState;

		public readonly RefRO<ClientInput> clientInput;

		public ChangePlayerStatePresentationAspect(RefRO<CharacterTypeCD> changeplayerstatepresentationaspect_charactertypecdRef, RefRO<ClientInput> changeplayerstatepresentationaspect_clientinputRef, RefRO<ControllingOtherEntityCD> changeplayerstatepresentationaspect_controllingotherentitycdRef, RefRO<EquippedObjectCD> changeplayerstatepresentationaspect_equippedobjectcdRef, RefRO<PlayerClaimedBed> changeplayerstatepresentationaspect_playerclaimedbedRef, RefRO<DeathStateCD> changeplayerstatepresentationaspect_deathstatecdRef, RefRO<FishingStateCD> changeplayerstatepresentationaspect_fishingstateRef, RefRO<PlayerSleepStateCD> changeplayerstatepresentationaspect_sleepstatecdRef, RefRW<PlayerStateCD> changeplayerstatepresentationaspect_playerstatecdRef, RefRO<SittingStateCD> changeplayerstatepresentationaspect_sittingstatecdRef, RefRW<TeleportingStateCD> changeplayerstatepresentationaspect_teleportingstatecdRef, RefRO<VehicleRidingStateCD> changeplayerstatepresentationaspect_vehicleridingstatecdRef, Entity changeplayerstatepresentationaspect_entityE)
		{
			characterTypeCD = changeplayerstatepresentationaspect_charactertypecdRef;
			clientInput = changeplayerstatepresentationaspect_clientinputRef;
			controllingOtherEntityCD = changeplayerstatepresentationaspect_controllingotherentitycdRef;
			equippedObjectCD = changeplayerstatepresentationaspect_equippedobjectcdRef;
			playerClaimedBed = changeplayerstatepresentationaspect_playerclaimedbedRef;
			deathStateCD = changeplayerstatepresentationaspect_deathstatecdRef;
			fishingState = changeplayerstatepresentationaspect_fishingstateRef;
			sleepStateCD = changeplayerstatepresentationaspect_sleepstatecdRef;
			playerStateCD = changeplayerstatepresentationaspect_playerstatecdRef;
			sittingStateCD = changeplayerstatepresentationaspect_sittingstatecdRef;
			teleportingStateCD = changeplayerstatepresentationaspect_teleportingstatecdRef;
			vehicleRidingStateCD = changeplayerstatepresentationaspect_vehicleridingstatecdRef;
			entity = changeplayerstatepresentationaspect_entityE;
		}

		public ChangePlayerStatePresentationAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadOnly<CharacterTypeCD>());
			unsafeList.Add(ComponentType.ReadOnly<ClientInput>());
			unsafeList.Add(ComponentType.ReadOnly<ControllingOtherEntityCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerClaimedBed>());
			unsafeList.Add(ComponentType.ReadOnly<DeathStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<FishingStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerSleepStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<SittingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<TeleportingStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<VehicleRidingStateCD>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 12;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadOnly<CharacterTypeCD>();
			componentTypes[1] = ComponentType.ReadOnly<ClientInput>();
			componentTypes[2] = ComponentType.ReadOnly<ControllingOtherEntityCD>();
			componentTypes[3] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[4] = ComponentType.ReadOnly<PlayerClaimedBed>();
			componentTypes[5] = ComponentType.ReadOnly<DeathStateCD>();
			componentTypes[6] = ComponentType.ReadOnly<FishingStateCD>();
			componentTypes[7] = ComponentType.ReadOnly<PlayerSleepStateCD>();
			componentTypes[8] = ComponentType.ReadWrite<PlayerStateCD>();
			componentTypes[9] = ComponentType.ReadOnly<SittingStateCD>();
			componentTypes[10] = ComponentType.ReadWrite<TeleportingStateCD>();
			componentTypes[11] = ComponentType.ReadOnly<VehicleRidingStateCD>();
		}

		public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
		{
			return new Enumerator(query, typeHandle);
		}

		public void CompleteDependencyBeforeRO(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<CharacterTypeCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
			state.EntityManager.CompleteDependencyBeforeRO<ControllingOtherEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerClaimedBed>();
			state.EntityManager.CompleteDependencyBeforeRO<DeathStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SittingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<TeleportingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<VehicleRidingStateCD>();
		}

		public void CompleteDependencyBeforeRW(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<CharacterTypeCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
			state.EntityManager.CompleteDependencyBeforeRO<ControllingOtherEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerClaimedBed>();
			state.EntityManager.CompleteDependencyBeforeRO<DeathStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SittingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<TeleportingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<VehicleRidingStateCD>();
		}
	}
}
