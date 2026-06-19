using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interaction;
using PlayerEquipment;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using Unity.Physics.GraphicsIntegration;

namespace PlayerState
{
	public readonly struct StateUpdateAspect : IAspect, IQueryTypeParameter, IAspectCreate<StateUpdateAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<StateUpdateAspect>
		{
			private BufferLookup<AnimationBuffer> StateUpdateAspect_animationBufferBAc;

			private ComponentLookup<AnimationBufferPointer> StateUpdateAspect_animationBufferPointerCAc;

			private ComponentLookup<AnimationOrientationCD> StateUpdateAspect_animationOrientationCDCAc;

			[ReadOnly]
			private ComponentLookup<CharacterTypeCD> StateUpdateAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentLookup<ClientInput> StateUpdateAspect_clientInputCAc;

			private BufferLookup<ConditionsBuffer> StateUpdateAspect_conditionsBuffersBAc;

			private ComponentLookup<ControllingOtherEntityCD> StateUpdateAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentLookup<CurrentBiomeCD> StateUpdateAspect_currentBiomeCDCAc;

			private BufferLookup<DealDamageToEntityBuffer> StateUpdateAspect_dealDamageToEntityBufferBAc;

			[ReadOnly]
			private ComponentLookup<EffectiveVelocityCD> StateUpdateAspect_effectiveVelocityCDCAc;

			[ReadOnly]
			private ComponentLookup<EquipmentCD> StateUpdateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> StateUpdateAspect_equippedObjectCDCAc;

			private BufferLookup<GhostEffectEventBuffer> StateUpdateAspect_ghostEffectEventBufferBAc;

			private ComponentLookup<GhostEffectEventBufferPointerCD> StateUpdateAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentLookup<HealthCD> StateUpdateAspect_healthCDCAc;

			private ComponentLookup<HungerCD> StateUpdateAspect_hungerCDCAc;

			private ComponentLookup<InteractorCD> StateUpdateAspect_interactorCDCAc;

			[ReadOnly]
			private ComponentLookup<LeashingCD> StateUpdateAspect_leashingCDCAc;

			private ComponentLookup<PlayerAimPositionCD> StateUpdateAspect_playerAimPositionCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerClaimedBed> StateUpdateAspect_playerClaimedBedCAc;

			[ReadOnly]
			private ComponentLookup<PlayerColliderCD> StateUpdateAspect_playerColliderCDCAc;

			private ComponentLookup<PlayerAttackCD> StateUpdateAspect_playerAttackCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerGhost> StateUpdateAspect_playerGhostCAc;

			private ComponentLookup<PlayerInvincibilityCD> StateUpdateAspect_playerInvincibilityCDCAc;

			private ComponentLookup<PlayerMovementCD> StateUpdateAspect_playerMovementCDCAc;

			private ComponentLookup<PlayerMovementForceCD> StateUpdateAspect_playerMovementForceCDCAc;

			private ComponentLookup<PlayerOrientationCD> StateUpdateAspect_playerOrientationCDCAc;

			private ComponentLookup<PlayerRoutineCD> StateUpdateAspect_playerRoutineCDCAc;

			private ComponentLookup<PlayerSpawnCD> StateUpdateAspect_playerSpawnCDCAc;

			private ComponentLookup<AnticipationCD> StateUpdateAspect_anticipationCDCAc;

			private ComponentLookup<BoatRidingStateCD> StateUpdateAspect_boatRidingStateCDCAc;

			private ComponentLookup<CastingStateCD> StateUpdateAspect_castingStateCDCAc;

			private ComponentLookup<DeathStateCD> StateUpdateAspect_deathStateCDCAc;

			private ComponentLookup<DigStateCD> StateUpdateAspect_digStateCDCAc;

			private ComponentLookup<FishingMiniGameStateCD> StateUpdateAspect_fishingMiniGameStateCDCAc;

			private ComponentLookup<FishingStateCD> StateUpdateAspect_fishingStateCDCAc;

			private ComponentLookup<FlattenStateCD> StateUpdateAspect_flattenStateCDCAc;

			private ComponentLookup<MinecartRidingStateCD> StateUpdateAspect_minecartRidingStateCDCAc;

			private ComponentLookup<PlaceObjectPlayerStateCD> StateUpdateAspect_placeObjectStateCDCAc;

			private ComponentLookup<PlaceWaterStateCD> StateUpdateAspect_placeWaterStateCDCAc;

			private ComponentLookup<PlayerSleepStateCD> StateUpdateAspect_sleepStateCDCAc;

			private ComponentLookup<PlayerStateCD> StateUpdateAspect_playerStateCDCAc;

			private ComponentLookup<RefillWaterStateCD> StateUpdateAspect_refillWaterStateCDCAc;

			private ComponentLookup<ReleaseStateCD> StateUpdateAspect_releaseStateCDCAc;

			private ComponentLookup<SittingStateCD> StateUpdateAspect_sittingStateCDCAc;

			private ComponentLookup<SpawningFromCoreStateCD> StateUpdateAspect_spawningFromCoreStateCDCAc;

			private ComponentLookup<TeleportingStateCD> StateUpdateAspect_teleportingStateCDCAc;

			private ComponentLookup<UseOffHandStateCD> StateUpdateAspect_useOffHandStateCDCAc;

			private ComponentLookup<VehicleRidingStateCD> StateUpdateAspect_vehicleRidingStateCAc;

			private ComponentLookup<WalkStateCD> StateUpdateAspect_walkStateCDCAc;

			[ReadOnly]
			private ComponentLookup<CommandDataInterpolationDelay> StateUpdateAspect_commandDataInterpolationDelayCAc;

			private ComponentLookup<PhysicsGraphicalSmoothing> StateUpdateAspect_physicsGraphicalSmoothingCAc;

			public StateUpdateAspect this[Entity entity] => new StateUpdateAspect(StateUpdateAspect_animationBufferBAc[entity], StateUpdateAspect_animationBufferPointerCAc.GetRefRW(entity), StateUpdateAspect_animationOrientationCDCAc.GetRefRW(entity), StateUpdateAspect_characterTypeCDCAc.GetRefRO(entity), StateUpdateAspect_clientInputCAc.GetRefRO(entity), StateUpdateAspect_conditionsBuffersBAc[entity], StateUpdateAspect_controllingOtherEntityCDCAc.GetRefRW(entity), StateUpdateAspect_currentBiomeCDCAc.GetRefRO(entity), StateUpdateAspect_dealDamageToEntityBufferBAc[entity], StateUpdateAspect_effectiveVelocityCDCAc.GetRefRO(entity), StateUpdateAspect_equipmentCDCAc.GetRefRO(entity), StateUpdateAspect_equippedObjectCDCAc.GetRefRO(entity), StateUpdateAspect_ghostEffectEventBufferBAc[entity], StateUpdateAspect_ghostEffectEventBufferPointerCDCAc.GetRefRW(entity), StateUpdateAspect_healthCDCAc.GetRefRW(entity), StateUpdateAspect_hungerCDCAc.GetRefRW(entity), StateUpdateAspect_interactorCDCAc.GetRefRWOptional(entity), StateUpdateAspect_leashingCDCAc.GetRefRO(entity), StateUpdateAspect_playerAimPositionCDCAc.GetRefRW(entity), StateUpdateAspect_playerClaimedBedCAc.GetRefRO(entity), StateUpdateAspect_playerColliderCDCAc.GetRefRO(entity), StateUpdateAspect_playerAttackCDCAc.GetRefRW(entity), StateUpdateAspect_playerGhostCAc.GetRefRO(entity), StateUpdateAspect_playerInvincibilityCDCAc.GetRefRW(entity), StateUpdateAspect_playerMovementCDCAc.GetRefRW(entity), StateUpdateAspect_playerMovementForceCDCAc.GetRefRW(entity), StateUpdateAspect_playerOrientationCDCAc.GetRefRW(entity), StateUpdateAspect_playerRoutineCDCAc.GetRefRW(entity), StateUpdateAspect_playerSpawnCDCAc.GetRefRW(entity), StateUpdateAspect_anticipationCDCAc.GetRefRW(entity), StateUpdateAspect_boatRidingStateCDCAc.GetRefRW(entity), StateUpdateAspect_castingStateCDCAc.GetRefRW(entity), StateUpdateAspect_deathStateCDCAc.GetRefRW(entity), StateUpdateAspect_digStateCDCAc.GetRefRW(entity), StateUpdateAspect_fishingMiniGameStateCDCAc.GetRefRW(entity), StateUpdateAspect_fishingStateCDCAc.GetRefRW(entity), StateUpdateAspect_flattenStateCDCAc.GetRefRW(entity), StateUpdateAspect_minecartRidingStateCDCAc.GetRefRW(entity), StateUpdateAspect_placeObjectStateCDCAc.GetRefRW(entity), StateUpdateAspect_placeWaterStateCDCAc.GetRefRW(entity), StateUpdateAspect_sleepStateCDCAc.GetRefRW(entity), StateUpdateAspect_playerStateCDCAc.GetRefRW(entity), StateUpdateAspect_refillWaterStateCDCAc.GetRefRW(entity), StateUpdateAspect_releaseStateCDCAc.GetRefRW(entity), StateUpdateAspect_sittingStateCDCAc.GetRefRW(entity), StateUpdateAspect_spawningFromCoreStateCDCAc.GetRefRW(entity), StateUpdateAspect_teleportingStateCDCAc.GetRefRW(entity), StateUpdateAspect_useOffHandStateCDCAc.GetRefRW(entity), StateUpdateAspect_vehicleRidingStateCAc.GetRefRW(entity), StateUpdateAspect_walkStateCDCAc.GetRefRW(entity), entity, StateUpdateAspect_commandDataInterpolationDelayCAc.GetRefRO(entity), StateUpdateAspect_physicsGraphicalSmoothingCAc.GetRefRW(entity));

			public Lookup(ref SystemState state)
			{
				StateUpdateAspect_animationBufferBAc = state.GetBufferLookup<AnimationBuffer>();
				StateUpdateAspect_animationBufferPointerCAc = state.GetComponentLookup<AnimationBufferPointer>();
				StateUpdateAspect_animationOrientationCDCAc = state.GetComponentLookup<AnimationOrientationCD>();
				StateUpdateAspect_characterTypeCDCAc = state.GetComponentLookup<CharacterTypeCD>(isReadOnly: true);
				StateUpdateAspect_clientInputCAc = state.GetComponentLookup<ClientInput>(isReadOnly: true);
				StateUpdateAspect_conditionsBuffersBAc = state.GetBufferLookup<ConditionsBuffer>();
				StateUpdateAspect_controllingOtherEntityCDCAc = state.GetComponentLookup<ControllingOtherEntityCD>();
				StateUpdateAspect_currentBiomeCDCAc = state.GetComponentLookup<CurrentBiomeCD>(isReadOnly: true);
				StateUpdateAspect_dealDamageToEntityBufferBAc = state.GetBufferLookup<DealDamageToEntityBuffer>();
				StateUpdateAspect_effectiveVelocityCDCAc = state.GetComponentLookup<EffectiveVelocityCD>(isReadOnly: true);
				StateUpdateAspect_equipmentCDCAc = state.GetComponentLookup<EquipmentCD>(isReadOnly: true);
				StateUpdateAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				StateUpdateAspect_ghostEffectEventBufferBAc = state.GetBufferLookup<GhostEffectEventBuffer>();
				StateUpdateAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
				StateUpdateAspect_healthCDCAc = state.GetComponentLookup<HealthCD>();
				StateUpdateAspect_hungerCDCAc = state.GetComponentLookup<HungerCD>();
				StateUpdateAspect_interactorCDCAc = state.GetComponentLookup<InteractorCD>();
				StateUpdateAspect_leashingCDCAc = state.GetComponentLookup<LeashingCD>(isReadOnly: true);
				StateUpdateAspect_playerAimPositionCDCAc = state.GetComponentLookup<PlayerAimPositionCD>();
				StateUpdateAspect_playerClaimedBedCAc = state.GetComponentLookup<PlayerClaimedBed>(isReadOnly: true);
				StateUpdateAspect_playerColliderCDCAc = state.GetComponentLookup<PlayerColliderCD>(isReadOnly: true);
				StateUpdateAspect_playerAttackCDCAc = state.GetComponentLookup<PlayerAttackCD>();
				StateUpdateAspect_playerGhostCAc = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				StateUpdateAspect_playerInvincibilityCDCAc = state.GetComponentLookup<PlayerInvincibilityCD>();
				StateUpdateAspect_playerMovementCDCAc = state.GetComponentLookup<PlayerMovementCD>();
				StateUpdateAspect_playerMovementForceCDCAc = state.GetComponentLookup<PlayerMovementForceCD>();
				StateUpdateAspect_playerOrientationCDCAc = state.GetComponentLookup<PlayerOrientationCD>();
				StateUpdateAspect_playerRoutineCDCAc = state.GetComponentLookup<PlayerRoutineCD>();
				StateUpdateAspect_playerSpawnCDCAc = state.GetComponentLookup<PlayerSpawnCD>();
				StateUpdateAspect_anticipationCDCAc = state.GetComponentLookup<AnticipationCD>();
				StateUpdateAspect_boatRidingStateCDCAc = state.GetComponentLookup<BoatRidingStateCD>();
				StateUpdateAspect_castingStateCDCAc = state.GetComponentLookup<CastingStateCD>();
				StateUpdateAspect_deathStateCDCAc = state.GetComponentLookup<DeathStateCD>();
				StateUpdateAspect_digStateCDCAc = state.GetComponentLookup<DigStateCD>();
				StateUpdateAspect_fishingMiniGameStateCDCAc = state.GetComponentLookup<FishingMiniGameStateCD>();
				StateUpdateAspect_fishingStateCDCAc = state.GetComponentLookup<FishingStateCD>();
				StateUpdateAspect_flattenStateCDCAc = state.GetComponentLookup<FlattenStateCD>();
				StateUpdateAspect_minecartRidingStateCDCAc = state.GetComponentLookup<MinecartRidingStateCD>();
				StateUpdateAspect_placeObjectStateCDCAc = state.GetComponentLookup<PlaceObjectPlayerStateCD>();
				StateUpdateAspect_placeWaterStateCDCAc = state.GetComponentLookup<PlaceWaterStateCD>();
				StateUpdateAspect_sleepStateCDCAc = state.GetComponentLookup<PlayerSleepStateCD>();
				StateUpdateAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>();
				StateUpdateAspect_refillWaterStateCDCAc = state.GetComponentLookup<RefillWaterStateCD>();
				StateUpdateAspect_releaseStateCDCAc = state.GetComponentLookup<ReleaseStateCD>();
				StateUpdateAspect_sittingStateCDCAc = state.GetComponentLookup<SittingStateCD>();
				StateUpdateAspect_spawningFromCoreStateCDCAc = state.GetComponentLookup<SpawningFromCoreStateCD>();
				StateUpdateAspect_teleportingStateCDCAc = state.GetComponentLookup<TeleportingStateCD>();
				StateUpdateAspect_useOffHandStateCDCAc = state.GetComponentLookup<UseOffHandStateCD>();
				StateUpdateAspect_vehicleRidingStateCAc = state.GetComponentLookup<VehicleRidingStateCD>();
				StateUpdateAspect_walkStateCDCAc = state.GetComponentLookup<WalkStateCD>();
				StateUpdateAspect_commandDataInterpolationDelayCAc = state.GetComponentLookup<CommandDataInterpolationDelay>(isReadOnly: true);
				StateUpdateAspect_physicsGraphicalSmoothingCAc = state.GetComponentLookup<PhysicsGraphicalSmoothing>();
			}

			public void Update(ref SystemState state)
			{
				StateUpdateAspect_animationBufferBAc.Update(ref state);
				StateUpdateAspect_animationBufferPointerCAc.Update(ref state);
				StateUpdateAspect_animationOrientationCDCAc.Update(ref state);
				StateUpdateAspect_characterTypeCDCAc.Update(ref state);
				StateUpdateAspect_clientInputCAc.Update(ref state);
				StateUpdateAspect_conditionsBuffersBAc.Update(ref state);
				StateUpdateAspect_controllingOtherEntityCDCAc.Update(ref state);
				StateUpdateAspect_currentBiomeCDCAc.Update(ref state);
				StateUpdateAspect_dealDamageToEntityBufferBAc.Update(ref state);
				StateUpdateAspect_effectiveVelocityCDCAc.Update(ref state);
				StateUpdateAspect_equipmentCDCAc.Update(ref state);
				StateUpdateAspect_equippedObjectCDCAc.Update(ref state);
				StateUpdateAspect_ghostEffectEventBufferBAc.Update(ref state);
				StateUpdateAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				StateUpdateAspect_healthCDCAc.Update(ref state);
				StateUpdateAspect_hungerCDCAc.Update(ref state);
				StateUpdateAspect_interactorCDCAc.Update(ref state);
				StateUpdateAspect_leashingCDCAc.Update(ref state);
				StateUpdateAspect_playerAimPositionCDCAc.Update(ref state);
				StateUpdateAspect_playerClaimedBedCAc.Update(ref state);
				StateUpdateAspect_playerColliderCDCAc.Update(ref state);
				StateUpdateAspect_playerAttackCDCAc.Update(ref state);
				StateUpdateAspect_playerGhostCAc.Update(ref state);
				StateUpdateAspect_playerInvincibilityCDCAc.Update(ref state);
				StateUpdateAspect_playerMovementCDCAc.Update(ref state);
				StateUpdateAspect_playerMovementForceCDCAc.Update(ref state);
				StateUpdateAspect_playerOrientationCDCAc.Update(ref state);
				StateUpdateAspect_playerRoutineCDCAc.Update(ref state);
				StateUpdateAspect_playerSpawnCDCAc.Update(ref state);
				StateUpdateAspect_anticipationCDCAc.Update(ref state);
				StateUpdateAspect_boatRidingStateCDCAc.Update(ref state);
				StateUpdateAspect_castingStateCDCAc.Update(ref state);
				StateUpdateAspect_deathStateCDCAc.Update(ref state);
				StateUpdateAspect_digStateCDCAc.Update(ref state);
				StateUpdateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				StateUpdateAspect_fishingStateCDCAc.Update(ref state);
				StateUpdateAspect_flattenStateCDCAc.Update(ref state);
				StateUpdateAspect_minecartRidingStateCDCAc.Update(ref state);
				StateUpdateAspect_placeObjectStateCDCAc.Update(ref state);
				StateUpdateAspect_placeWaterStateCDCAc.Update(ref state);
				StateUpdateAspect_sleepStateCDCAc.Update(ref state);
				StateUpdateAspect_playerStateCDCAc.Update(ref state);
				StateUpdateAspect_refillWaterStateCDCAc.Update(ref state);
				StateUpdateAspect_releaseStateCDCAc.Update(ref state);
				StateUpdateAspect_sittingStateCDCAc.Update(ref state);
				StateUpdateAspect_spawningFromCoreStateCDCAc.Update(ref state);
				StateUpdateAspect_teleportingStateCDCAc.Update(ref state);
				StateUpdateAspect_useOffHandStateCDCAc.Update(ref state);
				StateUpdateAspect_vehicleRidingStateCAc.Update(ref state);
				StateUpdateAspect_walkStateCDCAc.Update(ref state);
				StateUpdateAspect_commandDataInterpolationDelayCAc.Update(ref state);
				StateUpdateAspect_physicsGraphicalSmoothingCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public BufferAccessor<AnimationBuffer> StateUpdateAspect_animationBufferBa;

			public NativeArray<AnimationBufferPointer> StateUpdateAspect_animationBufferPointerNaC;

			public NativeArray<AnimationOrientationCD> StateUpdateAspect_animationOrientationCDNaC;

			public NativeArray<CharacterTypeCD> StateUpdateAspect_characterTypeCDNaC;

			public NativeArray<ClientInput> StateUpdateAspect_clientInputNaC;

			public BufferAccessor<ConditionsBuffer> StateUpdateAspect_conditionsBuffersBa;

			public NativeArray<ControllingOtherEntityCD> StateUpdateAspect_controllingOtherEntityCDNaC;

			public NativeArray<CurrentBiomeCD> StateUpdateAspect_currentBiomeCDNaC;

			public BufferAccessor<DealDamageToEntityBuffer> StateUpdateAspect_dealDamageToEntityBufferBa;

			public NativeArray<EffectiveVelocityCD> StateUpdateAspect_effectiveVelocityCDNaC;

			public NativeArray<EquipmentCD> StateUpdateAspect_equipmentCDNaC;

			public NativeArray<EquippedObjectCD> StateUpdateAspect_equippedObjectCDNaC;

			public BufferAccessor<GhostEffectEventBuffer> StateUpdateAspect_ghostEffectEventBufferBa;

			public NativeArray<GhostEffectEventBufferPointerCD> StateUpdateAspect_ghostEffectEventBufferPointerCDNaC;

			public NativeArray<HealthCD> StateUpdateAspect_healthCDNaC;

			public NativeArray<HungerCD> StateUpdateAspect_hungerCDNaC;

			public NativeArray<InteractorCD> StateUpdateAspect_interactorCDNaC;

			public NativeArray<LeashingCD> StateUpdateAspect_leashingCDNaC;

			public NativeArray<PlayerAimPositionCD> StateUpdateAspect_playerAimPositionCDNaC;

			public NativeArray<PlayerClaimedBed> StateUpdateAspect_playerClaimedBedNaC;

			public NativeArray<PlayerColliderCD> StateUpdateAspect_playerColliderCDNaC;

			public NativeArray<PlayerAttackCD> StateUpdateAspect_playerAttackCDNaC;

			public NativeArray<PlayerGhost> StateUpdateAspect_playerGhostNaC;

			public NativeArray<PlayerInvincibilityCD> StateUpdateAspect_playerInvincibilityCDNaC;

			public NativeArray<PlayerMovementCD> StateUpdateAspect_playerMovementCDNaC;

			public NativeArray<PlayerMovementForceCD> StateUpdateAspect_playerMovementForceCDNaC;

			public NativeArray<PlayerOrientationCD> StateUpdateAspect_playerOrientationCDNaC;

			public NativeArray<PlayerRoutineCD> StateUpdateAspect_playerRoutineCDNaC;

			public NativeArray<PlayerSpawnCD> StateUpdateAspect_playerSpawnCDNaC;

			public NativeArray<AnticipationCD> StateUpdateAspect_anticipationCDNaC;

			public NativeArray<BoatRidingStateCD> StateUpdateAspect_boatRidingStateCDNaC;

			public NativeArray<CastingStateCD> StateUpdateAspect_castingStateCDNaC;

			public NativeArray<DeathStateCD> StateUpdateAspect_deathStateCDNaC;

			public NativeArray<DigStateCD> StateUpdateAspect_digStateCDNaC;

			public NativeArray<FishingMiniGameStateCD> StateUpdateAspect_fishingMiniGameStateCDNaC;

			public NativeArray<FishingStateCD> StateUpdateAspect_fishingStateCDNaC;

			public NativeArray<FlattenStateCD> StateUpdateAspect_flattenStateCDNaC;

			public NativeArray<MinecartRidingStateCD> StateUpdateAspect_minecartRidingStateCDNaC;

			public NativeArray<PlaceObjectPlayerStateCD> StateUpdateAspect_placeObjectStateCDNaC;

			public NativeArray<PlaceWaterStateCD> StateUpdateAspect_placeWaterStateCDNaC;

			public NativeArray<PlayerSleepStateCD> StateUpdateAspect_sleepStateCDNaC;

			public NativeArray<PlayerStateCD> StateUpdateAspect_playerStateCDNaC;

			public NativeArray<RefillWaterStateCD> StateUpdateAspect_refillWaterStateCDNaC;

			public NativeArray<ReleaseStateCD> StateUpdateAspect_releaseStateCDNaC;

			public NativeArray<SittingStateCD> StateUpdateAspect_sittingStateCDNaC;

			public NativeArray<SpawningFromCoreStateCD> StateUpdateAspect_spawningFromCoreStateCDNaC;

			public NativeArray<TeleportingStateCD> StateUpdateAspect_teleportingStateCDNaC;

			public NativeArray<UseOffHandStateCD> StateUpdateAspect_useOffHandStateCDNaC;

			public NativeArray<VehicleRidingStateCD> StateUpdateAspect_vehicleRidingStateNaC;

			public NativeArray<WalkStateCD> StateUpdateAspect_walkStateCDNaC;

			public NativeArray<Entity> StateUpdateAspect_entityNaE;

			public NativeArray<CommandDataInterpolationDelay> StateUpdateAspect_commandDataInterpolationDelayNaC;

			public NativeArray<PhysicsGraphicalSmoothing> StateUpdateAspect_physicsGraphicalSmoothingNaC;

			public int Length;

			public StateUpdateAspect this[int index] => new StateUpdateAspect(StateUpdateAspect_animationBufferBa[index], new RefRW<AnimationBufferPointer>(StateUpdateAspect_animationBufferPointerNaC, index), new RefRW<AnimationOrientationCD>(StateUpdateAspect_animationOrientationCDNaC, index), new RefRO<CharacterTypeCD>(StateUpdateAspect_characterTypeCDNaC, index), new RefRO<ClientInput>(StateUpdateAspect_clientInputNaC, index), StateUpdateAspect_conditionsBuffersBa[index], new RefRW<ControllingOtherEntityCD>(StateUpdateAspect_controllingOtherEntityCDNaC, index), new RefRO<CurrentBiomeCD>(StateUpdateAspect_currentBiomeCDNaC, index), StateUpdateAspect_dealDamageToEntityBufferBa[index], new RefRO<EffectiveVelocityCD>(StateUpdateAspect_effectiveVelocityCDNaC, index), new RefRO<EquipmentCD>(StateUpdateAspect_equipmentCDNaC, index), new RefRO<EquippedObjectCD>(StateUpdateAspect_equippedObjectCDNaC, index), StateUpdateAspect_ghostEffectEventBufferBa[index], new RefRW<GhostEffectEventBufferPointerCD>(StateUpdateAspect_ghostEffectEventBufferPointerCDNaC, index), new RefRW<HealthCD>(StateUpdateAspect_healthCDNaC, index), new RefRW<HungerCD>(StateUpdateAspect_hungerCDNaC, index), RefRW<InteractorCD>.Optional(StateUpdateAspect_interactorCDNaC, index), new RefRO<LeashingCD>(StateUpdateAspect_leashingCDNaC, index), new RefRW<PlayerAimPositionCD>(StateUpdateAspect_playerAimPositionCDNaC, index), new RefRO<PlayerClaimedBed>(StateUpdateAspect_playerClaimedBedNaC, index), new RefRO<PlayerColliderCD>(StateUpdateAspect_playerColliderCDNaC, index), new RefRW<PlayerAttackCD>(StateUpdateAspect_playerAttackCDNaC, index), new RefRO<PlayerGhost>(StateUpdateAspect_playerGhostNaC, index), new RefRW<PlayerInvincibilityCD>(StateUpdateAspect_playerInvincibilityCDNaC, index), new RefRW<PlayerMovementCD>(StateUpdateAspect_playerMovementCDNaC, index), new RefRW<PlayerMovementForceCD>(StateUpdateAspect_playerMovementForceCDNaC, index), new RefRW<PlayerOrientationCD>(StateUpdateAspect_playerOrientationCDNaC, index), new RefRW<PlayerRoutineCD>(StateUpdateAspect_playerRoutineCDNaC, index), new RefRW<PlayerSpawnCD>(StateUpdateAspect_playerSpawnCDNaC, index), new RefRW<AnticipationCD>(StateUpdateAspect_anticipationCDNaC, index), new RefRW<BoatRidingStateCD>(StateUpdateAspect_boatRidingStateCDNaC, index), new RefRW<CastingStateCD>(StateUpdateAspect_castingStateCDNaC, index), new RefRW<DeathStateCD>(StateUpdateAspect_deathStateCDNaC, index), new RefRW<DigStateCD>(StateUpdateAspect_digStateCDNaC, index), new RefRW<FishingMiniGameStateCD>(StateUpdateAspect_fishingMiniGameStateCDNaC, index), new RefRW<FishingStateCD>(StateUpdateAspect_fishingStateCDNaC, index), new RefRW<FlattenStateCD>(StateUpdateAspect_flattenStateCDNaC, index), new RefRW<MinecartRidingStateCD>(StateUpdateAspect_minecartRidingStateCDNaC, index), new RefRW<PlaceObjectPlayerStateCD>(StateUpdateAspect_placeObjectStateCDNaC, index), new RefRW<PlaceWaterStateCD>(StateUpdateAspect_placeWaterStateCDNaC, index), new RefRW<PlayerSleepStateCD>(StateUpdateAspect_sleepStateCDNaC, index), new RefRW<PlayerStateCD>(StateUpdateAspect_playerStateCDNaC, index), new RefRW<RefillWaterStateCD>(StateUpdateAspect_refillWaterStateCDNaC, index), new RefRW<ReleaseStateCD>(StateUpdateAspect_releaseStateCDNaC, index), new RefRW<SittingStateCD>(StateUpdateAspect_sittingStateCDNaC, index), new RefRW<SpawningFromCoreStateCD>(StateUpdateAspect_spawningFromCoreStateCDNaC, index), new RefRW<TeleportingStateCD>(StateUpdateAspect_teleportingStateCDNaC, index), new RefRW<UseOffHandStateCD>(StateUpdateAspect_useOffHandStateCDNaC, index), new RefRW<VehicleRidingStateCD>(StateUpdateAspect_vehicleRidingStateNaC, index), new RefRW<WalkStateCD>(StateUpdateAspect_walkStateCDNaC, index), StateUpdateAspect_entityNaE[index], new RefRO<CommandDataInterpolationDelay>(StateUpdateAspect_commandDataInterpolationDelayNaC, index), new RefRW<PhysicsGraphicalSmoothing>(StateUpdateAspect_physicsGraphicalSmoothingNaC, index));
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<AnimationBuffer> StateUpdateAspect_animationBufferBAc;

			private ComponentTypeHandle<AnimationBufferPointer> StateUpdateAspect_animationBufferPointerCAc;

			private ComponentTypeHandle<AnimationOrientationCD> StateUpdateAspect_animationOrientationCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<CharacterTypeCD> StateUpdateAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<ClientInput> StateUpdateAspect_clientInputCAc;

			private BufferTypeHandle<ConditionsBuffer> StateUpdateAspect_conditionsBuffersBAc;

			private ComponentTypeHandle<ControllingOtherEntityCD> StateUpdateAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<CurrentBiomeCD> StateUpdateAspect_currentBiomeCDCAc;

			private BufferTypeHandle<DealDamageToEntityBuffer> StateUpdateAspect_dealDamageToEntityBufferBAc;

			[ReadOnly]
			private ComponentTypeHandle<EffectiveVelocityCD> StateUpdateAspect_effectiveVelocityCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentCD> StateUpdateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> StateUpdateAspect_equippedObjectCDCAc;

			private BufferTypeHandle<GhostEffectEventBuffer> StateUpdateAspect_ghostEffectEventBufferBAc;

			private ComponentTypeHandle<GhostEffectEventBufferPointerCD> StateUpdateAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentTypeHandle<HealthCD> StateUpdateAspect_healthCDCAc;

			private ComponentTypeHandle<HungerCD> StateUpdateAspect_hungerCDCAc;

			private ComponentTypeHandle<InteractorCD> StateUpdateAspect_interactorCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<LeashingCD> StateUpdateAspect_leashingCDCAc;

			private ComponentTypeHandle<PlayerAimPositionCD> StateUpdateAspect_playerAimPositionCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerClaimedBed> StateUpdateAspect_playerClaimedBedCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerColliderCD> StateUpdateAspect_playerColliderCDCAc;

			private ComponentTypeHandle<PlayerAttackCD> StateUpdateAspect_playerAttackCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerGhost> StateUpdateAspect_playerGhostCAc;

			private ComponentTypeHandle<PlayerInvincibilityCD> StateUpdateAspect_playerInvincibilityCDCAc;

			private ComponentTypeHandle<PlayerMovementCD> StateUpdateAspect_playerMovementCDCAc;

			private ComponentTypeHandle<PlayerMovementForceCD> StateUpdateAspect_playerMovementForceCDCAc;

			private ComponentTypeHandle<PlayerOrientationCD> StateUpdateAspect_playerOrientationCDCAc;

			private ComponentTypeHandle<PlayerRoutineCD> StateUpdateAspect_playerRoutineCDCAc;

			private ComponentTypeHandle<PlayerSpawnCD> StateUpdateAspect_playerSpawnCDCAc;

			private ComponentTypeHandle<AnticipationCD> StateUpdateAspect_anticipationCDCAc;

			private ComponentTypeHandle<BoatRidingStateCD> StateUpdateAspect_boatRidingStateCDCAc;

			private ComponentTypeHandle<CastingStateCD> StateUpdateAspect_castingStateCDCAc;

			private ComponentTypeHandle<DeathStateCD> StateUpdateAspect_deathStateCDCAc;

			private ComponentTypeHandle<DigStateCD> StateUpdateAspect_digStateCDCAc;

			private ComponentTypeHandle<FishingMiniGameStateCD> StateUpdateAspect_fishingMiniGameStateCDCAc;

			private ComponentTypeHandle<FishingStateCD> StateUpdateAspect_fishingStateCDCAc;

			private ComponentTypeHandle<FlattenStateCD> StateUpdateAspect_flattenStateCDCAc;

			private ComponentTypeHandle<MinecartRidingStateCD> StateUpdateAspect_minecartRidingStateCDCAc;

			private ComponentTypeHandle<PlaceObjectPlayerStateCD> StateUpdateAspect_placeObjectStateCDCAc;

			private ComponentTypeHandle<PlaceWaterStateCD> StateUpdateAspect_placeWaterStateCDCAc;

			private ComponentTypeHandle<PlayerSleepStateCD> StateUpdateAspect_sleepStateCDCAc;

			private ComponentTypeHandle<PlayerStateCD> StateUpdateAspect_playerStateCDCAc;

			private ComponentTypeHandle<RefillWaterStateCD> StateUpdateAspect_refillWaterStateCDCAc;

			private ComponentTypeHandle<ReleaseStateCD> StateUpdateAspect_releaseStateCDCAc;

			private ComponentTypeHandle<SittingStateCD> StateUpdateAspect_sittingStateCDCAc;

			private ComponentTypeHandle<SpawningFromCoreStateCD> StateUpdateAspect_spawningFromCoreStateCDCAc;

			private ComponentTypeHandle<TeleportingStateCD> StateUpdateAspect_teleportingStateCDCAc;

			private ComponentTypeHandle<UseOffHandStateCD> StateUpdateAspect_useOffHandStateCDCAc;

			private ComponentTypeHandle<VehicleRidingStateCD> StateUpdateAspect_vehicleRidingStateCAc;

			private ComponentTypeHandle<WalkStateCD> StateUpdateAspect_walkStateCDCAc;

			private EntityTypeHandle StateUpdateAspect_entityEAc;

			[ReadOnly]
			private ComponentTypeHandle<CommandDataInterpolationDelay> StateUpdateAspect_commandDataInterpolationDelayCAc;

			private ComponentTypeHandle<PhysicsGraphicalSmoothing> StateUpdateAspect_physicsGraphicalSmoothingCAc;

			public TypeHandle(ref SystemState state)
			{
				StateUpdateAspect_animationBufferBAc = state.GetBufferTypeHandle<AnimationBuffer>();
				StateUpdateAspect_animationBufferPointerCAc = state.GetComponentTypeHandle<AnimationBufferPointer>();
				StateUpdateAspect_animationOrientationCDCAc = state.GetComponentTypeHandle<AnimationOrientationCD>();
				StateUpdateAspect_characterTypeCDCAc = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
				StateUpdateAspect_clientInputCAc = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
				StateUpdateAspect_conditionsBuffersBAc = state.GetBufferTypeHandle<ConditionsBuffer>();
				StateUpdateAspect_controllingOtherEntityCDCAc = state.GetComponentTypeHandle<ControllingOtherEntityCD>();
				StateUpdateAspect_currentBiomeCDCAc = state.GetComponentTypeHandle<CurrentBiomeCD>(isReadOnly: true);
				StateUpdateAspect_dealDamageToEntityBufferBAc = state.GetBufferTypeHandle<DealDamageToEntityBuffer>();
				StateUpdateAspect_effectiveVelocityCDCAc = state.GetComponentTypeHandle<EffectiveVelocityCD>(isReadOnly: true);
				StateUpdateAspect_equipmentCDCAc = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
				StateUpdateAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				StateUpdateAspect_ghostEffectEventBufferBAc = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
				StateUpdateAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
				StateUpdateAspect_healthCDCAc = state.GetComponentTypeHandle<HealthCD>();
				StateUpdateAspect_hungerCDCAc = state.GetComponentTypeHandle<HungerCD>();
				StateUpdateAspect_interactorCDCAc = state.GetComponentTypeHandle<InteractorCD>();
				StateUpdateAspect_leashingCDCAc = state.GetComponentTypeHandle<LeashingCD>(isReadOnly: true);
				StateUpdateAspect_playerAimPositionCDCAc = state.GetComponentTypeHandle<PlayerAimPositionCD>();
				StateUpdateAspect_playerClaimedBedCAc = state.GetComponentTypeHandle<PlayerClaimedBed>(isReadOnly: true);
				StateUpdateAspect_playerColliderCDCAc = state.GetComponentTypeHandle<PlayerColliderCD>(isReadOnly: true);
				StateUpdateAspect_playerAttackCDCAc = state.GetComponentTypeHandle<PlayerAttackCD>();
				StateUpdateAspect_playerGhostCAc = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
				StateUpdateAspect_playerInvincibilityCDCAc = state.GetComponentTypeHandle<PlayerInvincibilityCD>();
				StateUpdateAspect_playerMovementCDCAc = state.GetComponentTypeHandle<PlayerMovementCD>();
				StateUpdateAspect_playerMovementForceCDCAc = state.GetComponentTypeHandle<PlayerMovementForceCD>();
				StateUpdateAspect_playerOrientationCDCAc = state.GetComponentTypeHandle<PlayerOrientationCD>();
				StateUpdateAspect_playerRoutineCDCAc = state.GetComponentTypeHandle<PlayerRoutineCD>();
				StateUpdateAspect_playerSpawnCDCAc = state.GetComponentTypeHandle<PlayerSpawnCD>();
				StateUpdateAspect_anticipationCDCAc = state.GetComponentTypeHandle<AnticipationCD>();
				StateUpdateAspect_boatRidingStateCDCAc = state.GetComponentTypeHandle<BoatRidingStateCD>();
				StateUpdateAspect_castingStateCDCAc = state.GetComponentTypeHandle<CastingStateCD>();
				StateUpdateAspect_deathStateCDCAc = state.GetComponentTypeHandle<DeathStateCD>();
				StateUpdateAspect_digStateCDCAc = state.GetComponentTypeHandle<DigStateCD>();
				StateUpdateAspect_fishingMiniGameStateCDCAc = state.GetComponentTypeHandle<FishingMiniGameStateCD>();
				StateUpdateAspect_fishingStateCDCAc = state.GetComponentTypeHandle<FishingStateCD>();
				StateUpdateAspect_flattenStateCDCAc = state.GetComponentTypeHandle<FlattenStateCD>();
				StateUpdateAspect_minecartRidingStateCDCAc = state.GetComponentTypeHandle<MinecartRidingStateCD>();
				StateUpdateAspect_placeObjectStateCDCAc = state.GetComponentTypeHandle<PlaceObjectPlayerStateCD>();
				StateUpdateAspect_placeWaterStateCDCAc = state.GetComponentTypeHandle<PlaceWaterStateCD>();
				StateUpdateAspect_sleepStateCDCAc = state.GetComponentTypeHandle<PlayerSleepStateCD>();
				StateUpdateAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>();
				StateUpdateAspect_refillWaterStateCDCAc = state.GetComponentTypeHandle<RefillWaterStateCD>();
				StateUpdateAspect_releaseStateCDCAc = state.GetComponentTypeHandle<ReleaseStateCD>();
				StateUpdateAspect_sittingStateCDCAc = state.GetComponentTypeHandle<SittingStateCD>();
				StateUpdateAspect_spawningFromCoreStateCDCAc = state.GetComponentTypeHandle<SpawningFromCoreStateCD>();
				StateUpdateAspect_teleportingStateCDCAc = state.GetComponentTypeHandle<TeleportingStateCD>();
				StateUpdateAspect_useOffHandStateCDCAc = state.GetComponentTypeHandle<UseOffHandStateCD>();
				StateUpdateAspect_vehicleRidingStateCAc = state.GetComponentTypeHandle<VehicleRidingStateCD>();
				StateUpdateAspect_walkStateCDCAc = state.GetComponentTypeHandle<WalkStateCD>();
				StateUpdateAspect_entityEAc = state.GetEntityTypeHandle();
				StateUpdateAspect_commandDataInterpolationDelayCAc = state.GetComponentTypeHandle<CommandDataInterpolationDelay>(isReadOnly: true);
				StateUpdateAspect_physicsGraphicalSmoothingCAc = state.GetComponentTypeHandle<PhysicsGraphicalSmoothing>();
			}

			public void Update(ref SystemState state)
			{
				StateUpdateAspect_animationBufferBAc.Update(ref state);
				StateUpdateAspect_animationBufferPointerCAc.Update(ref state);
				StateUpdateAspect_animationOrientationCDCAc.Update(ref state);
				StateUpdateAspect_characterTypeCDCAc.Update(ref state);
				StateUpdateAspect_clientInputCAc.Update(ref state);
				StateUpdateAspect_conditionsBuffersBAc.Update(ref state);
				StateUpdateAspect_controllingOtherEntityCDCAc.Update(ref state);
				StateUpdateAspect_currentBiomeCDCAc.Update(ref state);
				StateUpdateAspect_dealDamageToEntityBufferBAc.Update(ref state);
				StateUpdateAspect_effectiveVelocityCDCAc.Update(ref state);
				StateUpdateAspect_equipmentCDCAc.Update(ref state);
				StateUpdateAspect_equippedObjectCDCAc.Update(ref state);
				StateUpdateAspect_ghostEffectEventBufferBAc.Update(ref state);
				StateUpdateAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				StateUpdateAspect_healthCDCAc.Update(ref state);
				StateUpdateAspect_hungerCDCAc.Update(ref state);
				StateUpdateAspect_interactorCDCAc.Update(ref state);
				StateUpdateAspect_leashingCDCAc.Update(ref state);
				StateUpdateAspect_playerAimPositionCDCAc.Update(ref state);
				StateUpdateAspect_playerClaimedBedCAc.Update(ref state);
				StateUpdateAspect_playerColliderCDCAc.Update(ref state);
				StateUpdateAspect_playerAttackCDCAc.Update(ref state);
				StateUpdateAspect_playerGhostCAc.Update(ref state);
				StateUpdateAspect_playerInvincibilityCDCAc.Update(ref state);
				StateUpdateAspect_playerMovementCDCAc.Update(ref state);
				StateUpdateAspect_playerMovementForceCDCAc.Update(ref state);
				StateUpdateAspect_playerOrientationCDCAc.Update(ref state);
				StateUpdateAspect_playerRoutineCDCAc.Update(ref state);
				StateUpdateAspect_playerSpawnCDCAc.Update(ref state);
				StateUpdateAspect_anticipationCDCAc.Update(ref state);
				StateUpdateAspect_boatRidingStateCDCAc.Update(ref state);
				StateUpdateAspect_castingStateCDCAc.Update(ref state);
				StateUpdateAspect_deathStateCDCAc.Update(ref state);
				StateUpdateAspect_digStateCDCAc.Update(ref state);
				StateUpdateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				StateUpdateAspect_fishingStateCDCAc.Update(ref state);
				StateUpdateAspect_flattenStateCDCAc.Update(ref state);
				StateUpdateAspect_minecartRidingStateCDCAc.Update(ref state);
				StateUpdateAspect_placeObjectStateCDCAc.Update(ref state);
				StateUpdateAspect_placeWaterStateCDCAc.Update(ref state);
				StateUpdateAspect_sleepStateCDCAc.Update(ref state);
				StateUpdateAspect_playerStateCDCAc.Update(ref state);
				StateUpdateAspect_refillWaterStateCDCAc.Update(ref state);
				StateUpdateAspect_releaseStateCDCAc.Update(ref state);
				StateUpdateAspect_sittingStateCDCAc.Update(ref state);
				StateUpdateAspect_spawningFromCoreStateCDCAc.Update(ref state);
				StateUpdateAspect_teleportingStateCDCAc.Update(ref state);
				StateUpdateAspect_useOffHandStateCDCAc.Update(ref state);
				StateUpdateAspect_vehicleRidingStateCAc.Update(ref state);
				StateUpdateAspect_walkStateCDCAc.Update(ref state);
				StateUpdateAspect_entityEAc.Update(ref state);
				StateUpdateAspect_commandDataInterpolationDelayCAc.Update(ref state);
				StateUpdateAspect_physicsGraphicalSmoothingCAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.StateUpdateAspect_animationBufferBa = chunk.GetBufferAccessor(ref StateUpdateAspect_animationBufferBAc);
				result.StateUpdateAspect_animationBufferPointerNaC = chunk.GetNativeArray(ref StateUpdateAspect_animationBufferPointerCAc);
				result.StateUpdateAspect_animationOrientationCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_animationOrientationCDCAc);
				result.StateUpdateAspect_characterTypeCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_characterTypeCDCAc);
				result.StateUpdateAspect_clientInputNaC = chunk.GetNativeArray(ref StateUpdateAspect_clientInputCAc);
				result.StateUpdateAspect_conditionsBuffersBa = chunk.GetBufferAccessor(ref StateUpdateAspect_conditionsBuffersBAc);
				result.StateUpdateAspect_controllingOtherEntityCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_controllingOtherEntityCDCAc);
				result.StateUpdateAspect_currentBiomeCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_currentBiomeCDCAc);
				result.StateUpdateAspect_dealDamageToEntityBufferBa = chunk.GetBufferAccessor(ref StateUpdateAspect_dealDamageToEntityBufferBAc);
				result.StateUpdateAspect_effectiveVelocityCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_effectiveVelocityCDCAc);
				result.StateUpdateAspect_equipmentCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_equipmentCDCAc);
				result.StateUpdateAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_equippedObjectCDCAc);
				result.StateUpdateAspect_ghostEffectEventBufferBa = chunk.GetBufferAccessor(ref StateUpdateAspect_ghostEffectEventBufferBAc);
				result.StateUpdateAspect_ghostEffectEventBufferPointerCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_ghostEffectEventBufferPointerCDCAc);
				result.StateUpdateAspect_healthCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_healthCDCAc);
				result.StateUpdateAspect_hungerCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_hungerCDCAc);
				result.StateUpdateAspect_interactorCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_interactorCDCAc);
				result.StateUpdateAspect_leashingCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_leashingCDCAc);
				result.StateUpdateAspect_playerAimPositionCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerAimPositionCDCAc);
				result.StateUpdateAspect_playerClaimedBedNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerClaimedBedCAc);
				result.StateUpdateAspect_playerColliderCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerColliderCDCAc);
				result.StateUpdateAspect_playerAttackCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerAttackCDCAc);
				result.StateUpdateAspect_playerGhostNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerGhostCAc);
				result.StateUpdateAspect_playerInvincibilityCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerInvincibilityCDCAc);
				result.StateUpdateAspect_playerMovementCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerMovementCDCAc);
				result.StateUpdateAspect_playerMovementForceCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerMovementForceCDCAc);
				result.StateUpdateAspect_playerOrientationCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerOrientationCDCAc);
				result.StateUpdateAspect_playerRoutineCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerRoutineCDCAc);
				result.StateUpdateAspect_playerSpawnCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerSpawnCDCAc);
				result.StateUpdateAspect_anticipationCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_anticipationCDCAc);
				result.StateUpdateAspect_boatRidingStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_boatRidingStateCDCAc);
				result.StateUpdateAspect_castingStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_castingStateCDCAc);
				result.StateUpdateAspect_deathStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_deathStateCDCAc);
				result.StateUpdateAspect_digStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_digStateCDCAc);
				result.StateUpdateAspect_fishingMiniGameStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_fishingMiniGameStateCDCAc);
				result.StateUpdateAspect_fishingStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_fishingStateCDCAc);
				result.StateUpdateAspect_flattenStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_flattenStateCDCAc);
				result.StateUpdateAspect_minecartRidingStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_minecartRidingStateCDCAc);
				result.StateUpdateAspect_placeObjectStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_placeObjectStateCDCAc);
				result.StateUpdateAspect_placeWaterStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_placeWaterStateCDCAc);
				result.StateUpdateAspect_sleepStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_sleepStateCDCAc);
				result.StateUpdateAspect_playerStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_playerStateCDCAc);
				result.StateUpdateAspect_refillWaterStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_refillWaterStateCDCAc);
				result.StateUpdateAspect_releaseStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_releaseStateCDCAc);
				result.StateUpdateAspect_sittingStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_sittingStateCDCAc);
				result.StateUpdateAspect_spawningFromCoreStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_spawningFromCoreStateCDCAc);
				result.StateUpdateAspect_teleportingStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_teleportingStateCDCAc);
				result.StateUpdateAspect_useOffHandStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_useOffHandStateCDCAc);
				result.StateUpdateAspect_vehicleRidingStateNaC = chunk.GetNativeArray(ref StateUpdateAspect_vehicleRidingStateCAc);
				result.StateUpdateAspect_walkStateCDNaC = chunk.GetNativeArray(ref StateUpdateAspect_walkStateCDCAc);
				result.StateUpdateAspect_entityNaE = chunk.GetNativeArray(StateUpdateAspect_entityEAc);
				result.StateUpdateAspect_commandDataInterpolationDelayNaC = chunk.GetNativeArray(ref StateUpdateAspect_commandDataInterpolationDelayCAc);
				result.StateUpdateAspect_physicsGraphicalSmoothingNaC = chunk.GetNativeArray(ref StateUpdateAspect_physicsGraphicalSmoothingCAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<StateUpdateAspect>, IEnumerator, IDisposable, IEnumerable<StateUpdateAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public StateUpdateAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

			IEnumerator<StateUpdateAspect> IEnumerable<StateUpdateAspect>.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public readonly Entity entity;

		public readonly RefRW<WalkStateCD> walkStateCD;

		public readonly RefRW<PlayerMovementForceCD> playerMovementForceCD;

		public readonly RefRW<PlayerMovementCD> playerMovementCD;

		public readonly RefRW<AnimationOrientationCD> animationOrientationCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly RefRO<LeashingCD> leashingCD;

		public readonly RefRW<PlayerAttackCD> playerAttackCD;

		public readonly RefRW<PlayerStateCD> playerStateCD;

		public readonly RefRW<ReleaseStateCD> releaseStateCD;

		public readonly RefRO<ClientInput> clientInput;

		public readonly RefRW<AnticipationCD> anticipationCD;

		public readonly RefRW<DeathStateCD> deathStateCD;

		public readonly RefRO<PlayerClaimedBed> playerClaimedBed;

		public readonly RefRW<HealthCD> healthCD;

		public readonly DynamicBuffer<ConditionsBuffer> conditionsBuffers;

		public readonly RefRW<HungerCD> hungerCD;

		public readonly RefRO<CharacterTypeCD> characterTypeCD;

		public readonly RefRW<PlayerOrientationCD> playerOrientationCD;

		public readonly RefRW<PlayerInvincibilityCD> playerInvincibilityCD;

		public readonly RefRW<TeleportingStateCD> teleportingStateCD;

		public readonly RefRW<PhysicsGraphicalSmoothing> physicsGraphicalSmoothing;

		public readonly RefRW<CastingStateCD> castingStateCD;

		public readonly RefRO<PlayerGhost> playerGhost;

		public readonly DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer;

		public readonly RefRW<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerCD;

		public readonly RefRW<SpawningFromCoreStateCD> spawningFromCoreStateCD;

		public readonly RefRW<PlayerSleepStateCD> sleepStateCD;

		public readonly RefRW<FishingStateCD> fishingStateCD;

		public readonly RefRO<EquipmentCD> equipmentCD;

		public readonly RefRW<PlayerRoutineCD> playerRoutineCD;

		public readonly DynamicBuffer<AnimationBuffer> animationBuffer;

		public readonly RefRW<PlayerAimPositionCD> playerAimPositionCD;

		public readonly RefRW<MinecartRidingStateCD> minecartRidingStateCD;

		public readonly RefRO<CurrentBiomeCD> currentBiomeCD;

		public readonly RefRW<SittingStateCD> sittingStateCD;

		[Optional]
		public readonly RefRW<InteractorCD> interactorCD;

		public readonly RefRW<BoatRidingStateCD> boatRidingStateCD;

		public readonly RefRO<PlayerColliderCD> playerColliderCD;

		public readonly RefRW<VehicleRidingStateCD> vehicleRidingState;

		public readonly RefRO<EffectiveVelocityCD> effectiveVelocityCD;

		public readonly RefRW<RefillWaterStateCD> refillWaterStateCD;

		public readonly RefRW<PlaceObjectPlayerStateCD> placeObjectStateCD;

		public readonly RefRW<DigStateCD> digStateCD;

		public readonly RefRW<PlaceWaterStateCD> placeWaterStateCD;

		public readonly RefRW<FlattenStateCD> flattenStateCD;

		public readonly RefRW<PlayerSpawnCD> playerSpawnCD;

		public readonly RefRW<AnimationBufferPointer> animationBufferPointer;

		public readonly RefRO<CommandDataInterpolationDelay> commandDataInterpolationDelay;

		public readonly DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer;

		public readonly RefRW<ControllingOtherEntityCD> controllingOtherEntityCD;

		public readonly RefRW<UseOffHandStateCD> useOffHandStateCD;

		public readonly RefRW<FishingMiniGameStateCD> fishingMiniGameStateCD;

		public StateUpdateAspect(DynamicBuffer<AnimationBuffer> stateupdateaspect_animationbufferDb, RefRW<AnimationBufferPointer> stateupdateaspect_animationbufferpointerRef, RefRW<AnimationOrientationCD> stateupdateaspect_animationorientationcdRef, RefRO<CharacterTypeCD> stateupdateaspect_charactertypecdRef, RefRO<ClientInput> stateupdateaspect_clientinputRef, DynamicBuffer<ConditionsBuffer> stateupdateaspect_conditionsbuffersDb, RefRW<ControllingOtherEntityCD> stateupdateaspect_controllingotherentitycdRef, RefRO<CurrentBiomeCD> stateupdateaspect_currentbiomecdRef, DynamicBuffer<DealDamageToEntityBuffer> stateupdateaspect_dealdamagetoentitybufferDb, RefRO<EffectiveVelocityCD> stateupdateaspect_effectivevelocitycdRef, RefRO<EquipmentCD> stateupdateaspect_equipmentcdRef, RefRO<EquippedObjectCD> stateupdateaspect_equippedobjectcdRef, DynamicBuffer<GhostEffectEventBuffer> stateupdateaspect_ghosteffecteventbufferDb, RefRW<GhostEffectEventBufferPointerCD> stateupdateaspect_ghosteffecteventbufferpointercdRef, RefRW<HealthCD> stateupdateaspect_healthcdRef, RefRW<HungerCD> stateupdateaspect_hungercdRef, RefRW<InteractorCD> stateupdateaspect_interactorcdRef, RefRO<LeashingCD> stateupdateaspect_leashingcdRef, RefRW<PlayerAimPositionCD> stateupdateaspect_playeraimpositioncdRef, RefRO<PlayerClaimedBed> stateupdateaspect_playerclaimedbedRef, RefRO<PlayerColliderCD> stateupdateaspect_playercollidercdRef, RefRW<PlayerAttackCD> stateupdateaspect_playerattackcdRef, RefRO<PlayerGhost> stateupdateaspect_playerghostRef, RefRW<PlayerInvincibilityCD> stateupdateaspect_playerinvincibilitycdRef, RefRW<PlayerMovementCD> stateupdateaspect_playermovementcdRef, RefRW<PlayerMovementForceCD> stateupdateaspect_playermovementforcecdRef, RefRW<PlayerOrientationCD> stateupdateaspect_playerorientationcdRef, RefRW<PlayerRoutineCD> stateupdateaspect_playerroutinecdRef, RefRW<PlayerSpawnCD> stateupdateaspect_playerspawncdRef, RefRW<AnticipationCD> stateupdateaspect_anticipationcdRef, RefRW<BoatRidingStateCD> stateupdateaspect_boatridingstatecdRef, RefRW<CastingStateCD> stateupdateaspect_castingstatecdRef, RefRW<DeathStateCD> stateupdateaspect_deathstatecdRef, RefRW<DigStateCD> stateupdateaspect_digstatecdRef, RefRW<FishingMiniGameStateCD> stateupdateaspect_fishingminigamestatecdRef, RefRW<FishingStateCD> stateupdateaspect_fishingstatecdRef, RefRW<FlattenStateCD> stateupdateaspect_flattenstatecdRef, RefRW<MinecartRidingStateCD> stateupdateaspect_minecartridingstatecdRef, RefRW<PlaceObjectPlayerStateCD> stateupdateaspect_placeobjectstatecdRef, RefRW<PlaceWaterStateCD> stateupdateaspect_placewaterstatecdRef, RefRW<PlayerSleepStateCD> stateupdateaspect_sleepstatecdRef, RefRW<PlayerStateCD> stateupdateaspect_playerstatecdRef, RefRW<RefillWaterStateCD> stateupdateaspect_refillwaterstatecdRef, RefRW<ReleaseStateCD> stateupdateaspect_releasestatecdRef, RefRW<SittingStateCD> stateupdateaspect_sittingstatecdRef, RefRW<SpawningFromCoreStateCD> stateupdateaspect_spawningfromcorestatecdRef, RefRW<TeleportingStateCD> stateupdateaspect_teleportingstatecdRef, RefRW<UseOffHandStateCD> stateupdateaspect_useoffhandstatecdRef, RefRW<VehicleRidingStateCD> stateupdateaspect_vehicleridingstateRef, RefRW<WalkStateCD> stateupdateaspect_walkstatecdRef, Entity stateupdateaspect_entityE, RefRO<CommandDataInterpolationDelay> stateupdateaspect_commanddatainterpolationdelayRef, RefRW<PhysicsGraphicalSmoothing> stateupdateaspect_physicsgraphicalsmoothingRef)
		{
			animationBuffer = stateupdateaspect_animationbufferDb;
			animationBufferPointer = stateupdateaspect_animationbufferpointerRef;
			animationOrientationCD = stateupdateaspect_animationorientationcdRef;
			characterTypeCD = stateupdateaspect_charactertypecdRef;
			clientInput = stateupdateaspect_clientinputRef;
			conditionsBuffers = stateupdateaspect_conditionsbuffersDb;
			controllingOtherEntityCD = stateupdateaspect_controllingotherentitycdRef;
			currentBiomeCD = stateupdateaspect_currentbiomecdRef;
			dealDamageToEntityBuffer = stateupdateaspect_dealdamagetoentitybufferDb;
			effectiveVelocityCD = stateupdateaspect_effectivevelocitycdRef;
			equipmentCD = stateupdateaspect_equipmentcdRef;
			equippedObjectCD = stateupdateaspect_equippedobjectcdRef;
			ghostEffectEventBuffer = stateupdateaspect_ghosteffecteventbufferDb;
			ghostEffectEventBufferPointerCD = stateupdateaspect_ghosteffecteventbufferpointercdRef;
			healthCD = stateupdateaspect_healthcdRef;
			hungerCD = stateupdateaspect_hungercdRef;
			interactorCD = stateupdateaspect_interactorcdRef;
			leashingCD = stateupdateaspect_leashingcdRef;
			playerAimPositionCD = stateupdateaspect_playeraimpositioncdRef;
			playerClaimedBed = stateupdateaspect_playerclaimedbedRef;
			playerColliderCD = stateupdateaspect_playercollidercdRef;
			playerAttackCD = stateupdateaspect_playerattackcdRef;
			playerGhost = stateupdateaspect_playerghostRef;
			playerInvincibilityCD = stateupdateaspect_playerinvincibilitycdRef;
			playerMovementCD = stateupdateaspect_playermovementcdRef;
			playerMovementForceCD = stateupdateaspect_playermovementforcecdRef;
			playerOrientationCD = stateupdateaspect_playerorientationcdRef;
			playerRoutineCD = stateupdateaspect_playerroutinecdRef;
			playerSpawnCD = stateupdateaspect_playerspawncdRef;
			anticipationCD = stateupdateaspect_anticipationcdRef;
			boatRidingStateCD = stateupdateaspect_boatridingstatecdRef;
			castingStateCD = stateupdateaspect_castingstatecdRef;
			deathStateCD = stateupdateaspect_deathstatecdRef;
			digStateCD = stateupdateaspect_digstatecdRef;
			fishingMiniGameStateCD = stateupdateaspect_fishingminigamestatecdRef;
			fishingStateCD = stateupdateaspect_fishingstatecdRef;
			flattenStateCD = stateupdateaspect_flattenstatecdRef;
			minecartRidingStateCD = stateupdateaspect_minecartridingstatecdRef;
			placeObjectStateCD = stateupdateaspect_placeobjectstatecdRef;
			placeWaterStateCD = stateupdateaspect_placewaterstatecdRef;
			sleepStateCD = stateupdateaspect_sleepstatecdRef;
			playerStateCD = stateupdateaspect_playerstatecdRef;
			refillWaterStateCD = stateupdateaspect_refillwaterstatecdRef;
			releaseStateCD = stateupdateaspect_releasestatecdRef;
			sittingStateCD = stateupdateaspect_sittingstatecdRef;
			spawningFromCoreStateCD = stateupdateaspect_spawningfromcorestatecdRef;
			teleportingStateCD = stateupdateaspect_teleportingstatecdRef;
			useOffHandStateCD = stateupdateaspect_useoffhandstatecdRef;
			vehicleRidingState = stateupdateaspect_vehicleridingstateRef;
			walkStateCD = stateupdateaspect_walkstatecdRef;
			entity = stateupdateaspect_entityE;
			commandDataInterpolationDelay = stateupdateaspect_commanddatainterpolationdelayRef;
			physicsGraphicalSmoothing = stateupdateaspect_physicsgraphicalsmoothingRef;
		}

		public StateUpdateAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadWrite<AnimationBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<AnimationBufferPointer>());
			unsafeList.Add(ComponentType.ReadWrite<AnimationOrientationCD>());
			unsafeList.Add(ComponentType.ReadOnly<CharacterTypeCD>());
			unsafeList.Add(ComponentType.ReadOnly<ClientInput>());
			unsafeList.Add(ComponentType.ReadWrite<ConditionsBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<ControllingOtherEntityCD>());
			unsafeList.Add(ComponentType.ReadOnly<CurrentBiomeCD>());
			unsafeList.Add(ComponentType.ReadWrite<DealDamageToEntityBuffer>());
			unsafeList.Add(ComponentType.ReadOnly<EffectiveVelocityCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquipmentCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>());
			unsafeList.Add(ComponentType.ReadWrite<HealthCD>());
			unsafeList.Add(ComponentType.ReadWrite<HungerCD>());
			unsafeList.Add(ComponentType.ReadOnly<LeashingCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAimPositionCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerClaimedBed>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerColliderCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAttackCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerGhost>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerInvincibilityCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerMovementCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerMovementForceCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerOrientationCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerRoutineCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerSpawnCD>());
			unsafeList.Add(ComponentType.ReadWrite<AnticipationCD>());
			unsafeList.Add(ComponentType.ReadWrite<BoatRidingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<CastingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<DeathStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<DigStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<FishingMiniGameStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<FishingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<FlattenStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<MinecartRidingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlaceObjectPlayerStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlaceWaterStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerSleepStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<RefillWaterStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<ReleaseStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<SittingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<SpawningFromCoreStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<TeleportingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<UseOffHandStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<VehicleRidingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<WalkStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<CommandDataInterpolationDelay>());
			unsafeList.Add(ComponentType.ReadWrite<PhysicsGraphicalSmoothing>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 51;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadWrite<AnimationBuffer>();
			componentTypes[1] = ComponentType.ReadWrite<AnimationBufferPointer>();
			componentTypes[2] = ComponentType.ReadWrite<AnimationOrientationCD>();
			componentTypes[3] = ComponentType.ReadOnly<CharacterTypeCD>();
			componentTypes[4] = ComponentType.ReadOnly<ClientInput>();
			componentTypes[5] = ComponentType.ReadWrite<ConditionsBuffer>();
			componentTypes[6] = ComponentType.ReadWrite<ControllingOtherEntityCD>();
			componentTypes[7] = ComponentType.ReadOnly<CurrentBiomeCD>();
			componentTypes[8] = ComponentType.ReadWrite<DealDamageToEntityBuffer>();
			componentTypes[9] = ComponentType.ReadOnly<EffectiveVelocityCD>();
			componentTypes[10] = ComponentType.ReadOnly<EquipmentCD>();
			componentTypes[11] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[12] = ComponentType.ReadWrite<GhostEffectEventBuffer>();
			componentTypes[13] = ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>();
			componentTypes[14] = ComponentType.ReadWrite<HealthCD>();
			componentTypes[15] = ComponentType.ReadWrite<HungerCD>();
			componentTypes[16] = ComponentType.ReadOnly<LeashingCD>();
			componentTypes[17] = ComponentType.ReadWrite<PlayerAimPositionCD>();
			componentTypes[18] = ComponentType.ReadOnly<PlayerClaimedBed>();
			componentTypes[19] = ComponentType.ReadOnly<PlayerColliderCD>();
			componentTypes[20] = ComponentType.ReadWrite<PlayerAttackCD>();
			componentTypes[21] = ComponentType.ReadOnly<PlayerGhost>();
			componentTypes[22] = ComponentType.ReadWrite<PlayerInvincibilityCD>();
			componentTypes[23] = ComponentType.ReadWrite<PlayerMovementCD>();
			componentTypes[24] = ComponentType.ReadWrite<PlayerMovementForceCD>();
			componentTypes[25] = ComponentType.ReadWrite<PlayerOrientationCD>();
			componentTypes[26] = ComponentType.ReadWrite<PlayerRoutineCD>();
			componentTypes[27] = ComponentType.ReadWrite<PlayerSpawnCD>();
			componentTypes[28] = ComponentType.ReadWrite<AnticipationCD>();
			componentTypes[29] = ComponentType.ReadWrite<BoatRidingStateCD>();
			componentTypes[30] = ComponentType.ReadWrite<CastingStateCD>();
			componentTypes[31] = ComponentType.ReadWrite<DeathStateCD>();
			componentTypes[32] = ComponentType.ReadWrite<DigStateCD>();
			componentTypes[33] = ComponentType.ReadWrite<FishingMiniGameStateCD>();
			componentTypes[34] = ComponentType.ReadWrite<FishingStateCD>();
			componentTypes[35] = ComponentType.ReadWrite<FlattenStateCD>();
			componentTypes[36] = ComponentType.ReadWrite<MinecartRidingStateCD>();
			componentTypes[37] = ComponentType.ReadWrite<PlaceObjectPlayerStateCD>();
			componentTypes[38] = ComponentType.ReadWrite<PlaceWaterStateCD>();
			componentTypes[39] = ComponentType.ReadWrite<PlayerSleepStateCD>();
			componentTypes[40] = ComponentType.ReadWrite<PlayerStateCD>();
			componentTypes[41] = ComponentType.ReadWrite<RefillWaterStateCD>();
			componentTypes[42] = ComponentType.ReadWrite<ReleaseStateCD>();
			componentTypes[43] = ComponentType.ReadWrite<SittingStateCD>();
			componentTypes[44] = ComponentType.ReadWrite<SpawningFromCoreStateCD>();
			componentTypes[45] = ComponentType.ReadWrite<TeleportingStateCD>();
			componentTypes[46] = ComponentType.ReadWrite<UseOffHandStateCD>();
			componentTypes[47] = ComponentType.ReadWrite<VehicleRidingStateCD>();
			componentTypes[48] = ComponentType.ReadWrite<WalkStateCD>();
			componentTypes[49] = ComponentType.ReadOnly<CommandDataInterpolationDelay>();
			componentTypes[50] = ComponentType.ReadWrite<PhysicsGraphicalSmoothing>();
		}

		public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
		{
			return new Enumerator(query, typeHandle);
		}

		public void CompleteDependencyBeforeRO(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRO<AnimationOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CharacterTypeCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
			state.EntityManager.CompleteDependencyBeforeRO<ConditionsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<ControllingOtherEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CurrentBiomeCD>();
			state.EntityManager.CompleteDependencyBeforeRO<DealDamageToEntityBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<EffectiveVelocityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<HealthCD>();
			state.EntityManager.CompleteDependencyBeforeRO<HungerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LeashingCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAimPositionCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerClaimedBed>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerColliderCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAttackCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerInvincibilityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerMovementCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerMovementForceCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerRoutineCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSpawnCD>();
			state.EntityManager.CompleteDependencyBeforeRO<AnticipationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<BoatRidingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CastingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<DeathStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<DigStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingMiniGameStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FlattenStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<MinecartRidingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlaceObjectPlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlaceWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<RefillWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ReleaseStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SittingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SpawningFromCoreStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<TeleportingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<UseOffHandStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<VehicleRidingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<WalkStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CommandDataInterpolationDelay>();
			state.EntityManager.CompleteDependencyBeforeRO<PhysicsGraphicalSmoothing>();
		}

		public void CompleteDependencyBeforeRW(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CharacterTypeCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
			state.EntityManager.CompleteDependencyBeforeRW<ConditionsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<ControllingOtherEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CurrentBiomeCD>();
			state.EntityManager.CompleteDependencyBeforeRW<DealDamageToEntityBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<EffectiveVelocityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRW<HealthCD>();
			state.EntityManager.CompleteDependencyBeforeRW<HungerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LeashingCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAimPositionCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerClaimedBed>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerColliderCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAttackCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerInvincibilityCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerMovementCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerMovementForceCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerRoutineCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerSpawnCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnticipationCD>();
			state.EntityManager.CompleteDependencyBeforeRW<BoatRidingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<CastingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<DeathStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<DigStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<FishingMiniGameStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<FlattenStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<MinecartRidingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlaceObjectPlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlaceWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<RefillWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ReleaseStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SittingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SpawningFromCoreStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<TeleportingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<UseOffHandStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<VehicleRidingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<WalkStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CommandDataInterpolationDelay>();
			state.EntityManager.CompleteDependencyBeforeRW<PhysicsGraphicalSmoothing>();
		}
	}
}
