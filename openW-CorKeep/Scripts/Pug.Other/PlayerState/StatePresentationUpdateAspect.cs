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
	public readonly struct StatePresentationUpdateAspect : IAspect, IQueryTypeParameter, IAspectCreate<StatePresentationUpdateAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<StatePresentationUpdateAspect>
		{
			[ReadOnly]
			private ComponentLookup<CharacterTypeCD> StatePresentationUpdateAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentLookup<ClientInput> StatePresentationUpdateAspect_clientInputCAc;

			[ReadOnly]
			private ComponentLookup<ControllingOtherEntityCD> StatePresentationUpdateAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerClaimedBed> StatePresentationUpdateAspect_playerClaimedBedCAc;

			[ReadOnly]
			private ComponentLookup<DeathStateCD> StatePresentationUpdateAspect_deathStateCDCAc;

			[ReadOnly]
			private ComponentLookup<FishingMiniGameStateCD> StatePresentationUpdateAspect_fishingMiniGameStateCDCAc;

			[ReadOnly]
			private ComponentLookup<FishingStateCD> StatePresentationUpdateAspect_fishingStateCAc;

			[ReadOnly]
			private ComponentLookup<PlayerSleepStateCD> StatePresentationUpdateAspect_sleepStateCAc;

			private ComponentLookup<PlayerStateCD> StatePresentationUpdateAspect_playerStateCDCAc;

			[ReadOnly]
			private ComponentLookup<SittingStateCD> StatePresentationUpdateAspect_sittingStateCDCAc;

			private ComponentLookup<TeleportingStateCD> StatePresentationUpdateAspect_teleportingStateCDCAc;

			[ReadOnly]
			private ComponentLookup<VehicleRidingStateCD> StatePresentationUpdateAspect_vehicleRidingStateCDCAc;

			public StatePresentationUpdateAspect this[Entity entity] => new StatePresentationUpdateAspect(StatePresentationUpdateAspect_characterTypeCDCAc.GetRefRO(entity), StatePresentationUpdateAspect_clientInputCAc.GetRefRO(entity), StatePresentationUpdateAspect_controllingOtherEntityCDCAc.GetRefRO(entity), StatePresentationUpdateAspect_playerClaimedBedCAc.GetRefRO(entity), StatePresentationUpdateAspect_deathStateCDCAc.GetRefRO(entity), StatePresentationUpdateAspect_fishingMiniGameStateCDCAc.GetRefRO(entity), StatePresentationUpdateAspect_fishingStateCAc.GetRefRO(entity), StatePresentationUpdateAspect_sleepStateCAc.GetRefRO(entity), StatePresentationUpdateAspect_playerStateCDCAc.GetRefRW(entity), StatePresentationUpdateAspect_sittingStateCDCAc.GetRefRO(entity), StatePresentationUpdateAspect_teleportingStateCDCAc.GetRefRW(entity), StatePresentationUpdateAspect_vehicleRidingStateCDCAc.GetRefRO(entity), entity);

			public Lookup(ref SystemState state)
			{
				StatePresentationUpdateAspect_characterTypeCDCAc = state.GetComponentLookup<CharacterTypeCD>(isReadOnly: true);
				StatePresentationUpdateAspect_clientInputCAc = state.GetComponentLookup<ClientInput>(isReadOnly: true);
				StatePresentationUpdateAspect_controllingOtherEntityCDCAc = state.GetComponentLookup<ControllingOtherEntityCD>(isReadOnly: true);
				StatePresentationUpdateAspect_playerClaimedBedCAc = state.GetComponentLookup<PlayerClaimedBed>(isReadOnly: true);
				StatePresentationUpdateAspect_deathStateCDCAc = state.GetComponentLookup<DeathStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_fishingMiniGameStateCDCAc = state.GetComponentLookup<FishingMiniGameStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_fishingStateCAc = state.GetComponentLookup<FishingStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_sleepStateCAc = state.GetComponentLookup<PlayerSleepStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>();
				StatePresentationUpdateAspect_sittingStateCDCAc = state.GetComponentLookup<SittingStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_teleportingStateCDCAc = state.GetComponentLookup<TeleportingStateCD>();
				StatePresentationUpdateAspect_vehicleRidingStateCDCAc = state.GetComponentLookup<VehicleRidingStateCD>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				StatePresentationUpdateAspect_characterTypeCDCAc.Update(ref state);
				StatePresentationUpdateAspect_clientInputCAc.Update(ref state);
				StatePresentationUpdateAspect_controllingOtherEntityCDCAc.Update(ref state);
				StatePresentationUpdateAspect_playerClaimedBedCAc.Update(ref state);
				StatePresentationUpdateAspect_deathStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_fishingStateCAc.Update(ref state);
				StatePresentationUpdateAspect_sleepStateCAc.Update(ref state);
				StatePresentationUpdateAspect_playerStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_sittingStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_teleportingStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_vehicleRidingStateCDCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public NativeArray<CharacterTypeCD> StatePresentationUpdateAspect_characterTypeCDNaC;

			public NativeArray<ClientInput> StatePresentationUpdateAspect_clientInputNaC;

			public NativeArray<ControllingOtherEntityCD> StatePresentationUpdateAspect_controllingOtherEntityCDNaC;

			public NativeArray<PlayerClaimedBed> StatePresentationUpdateAspect_playerClaimedBedNaC;

			public NativeArray<DeathStateCD> StatePresentationUpdateAspect_deathStateCDNaC;

			public NativeArray<FishingMiniGameStateCD> StatePresentationUpdateAspect_fishingMiniGameStateCDNaC;

			public NativeArray<FishingStateCD> StatePresentationUpdateAspect_fishingStateNaC;

			public NativeArray<PlayerSleepStateCD> StatePresentationUpdateAspect_sleepStateNaC;

			public NativeArray<PlayerStateCD> StatePresentationUpdateAspect_playerStateCDNaC;

			public NativeArray<SittingStateCD> StatePresentationUpdateAspect_sittingStateCDNaC;

			public NativeArray<TeleportingStateCD> StatePresentationUpdateAspect_teleportingStateCDNaC;

			public NativeArray<VehicleRidingStateCD> StatePresentationUpdateAspect_vehicleRidingStateCDNaC;

			public NativeArray<Entity> StatePresentationUpdateAspect_entityNaE;

			public int Length;

			public StatePresentationUpdateAspect this[int index] => new StatePresentationUpdateAspect(new RefRO<CharacterTypeCD>(StatePresentationUpdateAspect_characterTypeCDNaC, index), new RefRO<ClientInput>(StatePresentationUpdateAspect_clientInputNaC, index), new RefRO<ControllingOtherEntityCD>(StatePresentationUpdateAspect_controllingOtherEntityCDNaC, index), new RefRO<PlayerClaimedBed>(StatePresentationUpdateAspect_playerClaimedBedNaC, index), new RefRO<DeathStateCD>(StatePresentationUpdateAspect_deathStateCDNaC, index), new RefRO<FishingMiniGameStateCD>(StatePresentationUpdateAspect_fishingMiniGameStateCDNaC, index), new RefRO<FishingStateCD>(StatePresentationUpdateAspect_fishingStateNaC, index), new RefRO<PlayerSleepStateCD>(StatePresentationUpdateAspect_sleepStateNaC, index), new RefRW<PlayerStateCD>(StatePresentationUpdateAspect_playerStateCDNaC, index), new RefRO<SittingStateCD>(StatePresentationUpdateAspect_sittingStateCDNaC, index), new RefRW<TeleportingStateCD>(StatePresentationUpdateAspect_teleportingStateCDNaC, index), new RefRO<VehicleRidingStateCD>(StatePresentationUpdateAspect_vehicleRidingStateCDNaC, index), StatePresentationUpdateAspect_entityNaE[index]);
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<CharacterTypeCD> StatePresentationUpdateAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<ClientInput> StatePresentationUpdateAspect_clientInputCAc;

			[ReadOnly]
			private ComponentTypeHandle<ControllingOtherEntityCD> StatePresentationUpdateAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerClaimedBed> StatePresentationUpdateAspect_playerClaimedBedCAc;

			[ReadOnly]
			private ComponentTypeHandle<DeathStateCD> StatePresentationUpdateAspect_deathStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<FishingMiniGameStateCD> StatePresentationUpdateAspect_fishingMiniGameStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<FishingStateCD> StatePresentationUpdateAspect_fishingStateCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerSleepStateCD> StatePresentationUpdateAspect_sleepStateCAc;

			private ComponentTypeHandle<PlayerStateCD> StatePresentationUpdateAspect_playerStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<SittingStateCD> StatePresentationUpdateAspect_sittingStateCDCAc;

			private ComponentTypeHandle<TeleportingStateCD> StatePresentationUpdateAspect_teleportingStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<VehicleRidingStateCD> StatePresentationUpdateAspect_vehicleRidingStateCDCAc;

			private EntityTypeHandle StatePresentationUpdateAspect_entityEAc;

			public TypeHandle(ref SystemState state)
			{
				StatePresentationUpdateAspect_characterTypeCDCAc = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
				StatePresentationUpdateAspect_clientInputCAc = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
				StatePresentationUpdateAspect_controllingOtherEntityCDCAc = state.GetComponentTypeHandle<ControllingOtherEntityCD>(isReadOnly: true);
				StatePresentationUpdateAspect_playerClaimedBedCAc = state.GetComponentTypeHandle<PlayerClaimedBed>(isReadOnly: true);
				StatePresentationUpdateAspect_deathStateCDCAc = state.GetComponentTypeHandle<DeathStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_fishingMiniGameStateCDCAc = state.GetComponentTypeHandle<FishingMiniGameStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_fishingStateCAc = state.GetComponentTypeHandle<FishingStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_sleepStateCAc = state.GetComponentTypeHandle<PlayerSleepStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>();
				StatePresentationUpdateAspect_sittingStateCDCAc = state.GetComponentTypeHandle<SittingStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_teleportingStateCDCAc = state.GetComponentTypeHandle<TeleportingStateCD>();
				StatePresentationUpdateAspect_vehicleRidingStateCDCAc = state.GetComponentTypeHandle<VehicleRidingStateCD>(isReadOnly: true);
				StatePresentationUpdateAspect_entityEAc = state.GetEntityTypeHandle();
			}

			public void Update(ref SystemState state)
			{
				StatePresentationUpdateAspect_characterTypeCDCAc.Update(ref state);
				StatePresentationUpdateAspect_clientInputCAc.Update(ref state);
				StatePresentationUpdateAspect_controllingOtherEntityCDCAc.Update(ref state);
				StatePresentationUpdateAspect_playerClaimedBedCAc.Update(ref state);
				StatePresentationUpdateAspect_deathStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_fishingStateCAc.Update(ref state);
				StatePresentationUpdateAspect_sleepStateCAc.Update(ref state);
				StatePresentationUpdateAspect_playerStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_sittingStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_teleportingStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_vehicleRidingStateCDCAc.Update(ref state);
				StatePresentationUpdateAspect_entityEAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.StatePresentationUpdateAspect_characterTypeCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_characterTypeCDCAc);
				result.StatePresentationUpdateAspect_clientInputNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_clientInputCAc);
				result.StatePresentationUpdateAspect_controllingOtherEntityCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_controllingOtherEntityCDCAc);
				result.StatePresentationUpdateAspect_playerClaimedBedNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_playerClaimedBedCAc);
				result.StatePresentationUpdateAspect_deathStateCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_deathStateCDCAc);
				result.StatePresentationUpdateAspect_fishingMiniGameStateCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_fishingMiniGameStateCDCAc);
				result.StatePresentationUpdateAspect_fishingStateNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_fishingStateCAc);
				result.StatePresentationUpdateAspect_sleepStateNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_sleepStateCAc);
				result.StatePresentationUpdateAspect_playerStateCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_playerStateCDCAc);
				result.StatePresentationUpdateAspect_sittingStateCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_sittingStateCDCAc);
				result.StatePresentationUpdateAspect_teleportingStateCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_teleportingStateCDCAc);
				result.StatePresentationUpdateAspect_vehicleRidingStateCDNaC = chunk.GetNativeArray(ref StatePresentationUpdateAspect_vehicleRidingStateCDCAc);
				result.StatePresentationUpdateAspect_entityNaE = chunk.GetNativeArray(StatePresentationUpdateAspect_entityEAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<StatePresentationUpdateAspect>, IEnumerator, IDisposable, IEnumerable<StatePresentationUpdateAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public StatePresentationUpdateAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

			IEnumerator<StatePresentationUpdateAspect> IEnumerable<StatePresentationUpdateAspect>.GetEnumerator()
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

		public readonly RefRO<DeathStateCD> deathStateCD;

		public readonly RefRO<CharacterTypeCD> characterTypeCD;

		public readonly RefRW<TeleportingStateCD> teleportingStateCD;

		public readonly RefRO<PlayerClaimedBed> playerClaimedBed;

		public readonly RefRO<SittingStateCD> sittingStateCD;

		public readonly RefRO<ClientInput> clientInput;

		public readonly RefRO<VehicleRidingStateCD> vehicleRidingStateCD;

		public readonly RefRO<ControllingOtherEntityCD> controllingOtherEntityCD;

		public readonly RefRO<FishingMiniGameStateCD> fishingMiniGameStateCD;

		public readonly RefRO<FishingStateCD> fishingState;

		public readonly RefRO<PlayerSleepStateCD> sleepState;

		public StatePresentationUpdateAspect(RefRO<CharacterTypeCD> statepresentationupdateaspect_charactertypecdRef, RefRO<ClientInput> statepresentationupdateaspect_clientinputRef, RefRO<ControllingOtherEntityCD> statepresentationupdateaspect_controllingotherentitycdRef, RefRO<PlayerClaimedBed> statepresentationupdateaspect_playerclaimedbedRef, RefRO<DeathStateCD> statepresentationupdateaspect_deathstatecdRef, RefRO<FishingMiniGameStateCD> statepresentationupdateaspect_fishingminigamestatecdRef, RefRO<FishingStateCD> statepresentationupdateaspect_fishingstateRef, RefRO<PlayerSleepStateCD> statepresentationupdateaspect_sleepstateRef, RefRW<PlayerStateCD> statepresentationupdateaspect_playerstatecdRef, RefRO<SittingStateCD> statepresentationupdateaspect_sittingstatecdRef, RefRW<TeleportingStateCD> statepresentationupdateaspect_teleportingstatecdRef, RefRO<VehicleRidingStateCD> statepresentationupdateaspect_vehicleridingstatecdRef, Entity statepresentationupdateaspect_entityE)
		{
			characterTypeCD = statepresentationupdateaspect_charactertypecdRef;
			clientInput = statepresentationupdateaspect_clientinputRef;
			controllingOtherEntityCD = statepresentationupdateaspect_controllingotherentitycdRef;
			playerClaimedBed = statepresentationupdateaspect_playerclaimedbedRef;
			deathStateCD = statepresentationupdateaspect_deathstatecdRef;
			fishingMiniGameStateCD = statepresentationupdateaspect_fishingminigamestatecdRef;
			fishingState = statepresentationupdateaspect_fishingstateRef;
			sleepState = statepresentationupdateaspect_sleepstateRef;
			playerStateCD = statepresentationupdateaspect_playerstatecdRef;
			sittingStateCD = statepresentationupdateaspect_sittingstatecdRef;
			teleportingStateCD = statepresentationupdateaspect_teleportingstatecdRef;
			vehicleRidingStateCD = statepresentationupdateaspect_vehicleridingstatecdRef;
			entity = statepresentationupdateaspect_entityE;
		}

		public StatePresentationUpdateAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadOnly<CharacterTypeCD>());
			unsafeList.Add(ComponentType.ReadOnly<ClientInput>());
			unsafeList.Add(ComponentType.ReadOnly<ControllingOtherEntityCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerClaimedBed>());
			unsafeList.Add(ComponentType.ReadOnly<DeathStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<FishingMiniGameStateCD>());
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
			componentTypes[3] = ComponentType.ReadOnly<PlayerClaimedBed>();
			componentTypes[4] = ComponentType.ReadOnly<DeathStateCD>();
			componentTypes[5] = ComponentType.ReadOnly<FishingMiniGameStateCD>();
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
			state.EntityManager.CompleteDependencyBeforeRO<PlayerClaimedBed>();
			state.EntityManager.CompleteDependencyBeforeRO<DeathStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingMiniGameStateCD>();
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
			state.EntityManager.CompleteDependencyBeforeRO<PlayerClaimedBed>();
			state.EntityManager.CompleteDependencyBeforeRO<DeathStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingMiniGameStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SittingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<TeleportingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<VehicleRidingStateCD>();
		}
	}
}
