using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PlayerEquipment;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Physics.GraphicsIntegration;

namespace PlayerState
{
	public readonly struct ChangePlayerStateAspect : IAspect, IQueryTypeParameter, IAspectCreate<ChangePlayerStateAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<ChangePlayerStateAspect>
		{
			private BufferLookup<AnimationBuffer> ChangePlayerStateAspect_animationBufferBAc;

			private ComponentLookup<AnimationBufferPointer> ChangePlayerStateAspect_animationBufferPointerCAc;

			private ComponentLookup<AnimationOrientationCD> ChangePlayerStateAspect_animationOrientationCDCAc;

			[ReadOnly]
			private ComponentLookup<CharacterTypeCD> ChangePlayerStateAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentLookup<ClientInput> ChangePlayerStateAspect_clientInputCAc;

			private BufferLookup<ConditionsBuffer> ChangePlayerStateAspect_conditionsBufferBAc;

			private BufferLookup<ContainedObjectsBuffer> ChangePlayerStateAspect_containedObjectsBufferBAc;

			private ComponentLookup<ControllingOtherEntityCD> ChangePlayerStateAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentLookup<EquipmentCD> ChangePlayerStateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> ChangePlayerStateAspect_equippedObjectCDCAc;

			private BufferLookup<GhostEffectEventBuffer> ChangePlayerStateAspect_effectEventBufferBAc;

			private ComponentLookup<GhostEffectEventBufferPointerCD> ChangePlayerStateAspect_effectEventBufferPointerCDCAc;

			[ReadOnly]
			private ComponentLookup<HealthCD> ChangePlayerStateAspect_healthCDCAc;

			private ComponentLookup<HungerCD> ChangePlayerStateAspect_hungerCDCAc;

			[ReadOnly]
			private ComponentLookup<PlacementCD> ChangePlayerStateAspect_placementCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerColliderCD> ChangePlayerStateAspect_playerColliderCDCAc;

			[ReadOnly]
			private ComponentLookup<EquipmentSlotCD> ChangePlayerStateAspect_equipmentSlotCDCAc;

			private ComponentLookup<PlayerInvincibilityCD> ChangePlayerStateAspect_playerInvincibilityCDCAc;

			private ComponentLookup<PlayerMovementCD> ChangePlayerStateAspect_playerMovementCDCAc;

			private ComponentLookup<PlayerMovementForceCD> ChangePlayerStateAspect_playerMovementForceCDCAc;

			private ComponentLookup<PlayerOrientationCD> ChangePlayerStateAspect_playerOrientationCDCAc;

			private ComponentLookup<PlayerRoutineCD> ChangePlayerStateAspect_playerRoutineCDCAc;

			private ComponentLookup<AnticipationCD> ChangePlayerStateAspect_anticipationCDCAc;

			private ComponentLookup<BoatRidingStateCD> ChangePlayerStateAspect_boatRidingStateCDCAc;

			private ComponentLookup<CastingStateCD> ChangePlayerStateAspect_castingStateCDCAc;

			private ComponentLookup<DeathStateCD> ChangePlayerStateAspect_deathStateCDCAc;

			private ComponentLookup<DigStateCD> ChangePlayerStateAspect_digStateCDCAc;

			private ComponentLookup<FishingMiniGameStateCD> ChangePlayerStateAspect_fishingMiniGameStateCDCAc;

			private ComponentLookup<FishingStateCD> ChangePlayerStateAspect_fishingStateCDCAc;

			private ComponentLookup<FlattenStateCD> ChangePlayerStateAspect_flattenStateCDCAc;

			private ComponentLookup<MinecartRidingStateCD> ChangePlayerStateAspect_minecartRidingStateCDCAc;

			private ComponentLookup<PlaceObjectPlayerStateCD> ChangePlayerStateAspect_placeObjectStateCDCAc;

			private ComponentLookup<PlaceWaterStateCD> ChangePlayerStateAspect_placeWaterStateCDCAc;

			private ComponentLookup<PlayerSleepStateCD> ChangePlayerStateAspect_sleepStateCDCAc;

			private ComponentLookup<PlayerStateCD> ChangePlayerStateAspect_playerStateCDCAc;

			private ComponentLookup<RefillWaterStateCD> ChangePlayerStateAspect_refillWaterStateCDCAc;

			private ComponentLookup<ReleaseStateCD> ChangePlayerStateAspect_releaseStateCDCAc;

			private ComponentLookup<SittingStateCD> ChangePlayerStateAspect_sittingStateCDCAc;

			private ComponentLookup<SpawningFromCoreStateCD> ChangePlayerStateAspect_spawningFromCoreStateCDCAc;

			private ComponentLookup<TeleportingStateCD> ChangePlayerStateAspect_teleportingCDCAc;

			private ComponentLookup<UseOffHandStateCD> ChangePlayerStateAspect_useOffHandStateCDCAc;

			private ComponentLookup<VehicleRidingStateCD> ChangePlayerStateAspect_vehicleRidingStateCAc;

			private ComponentLookup<ReceivedPushbackCD> ChangePlayerStateAspect_receivePushbackCDCAc;

			private BufferLookup<SummarizedConditionEffectsBuffer> ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc;

			private ComponentLookup<PhysicsGraphicalSmoothing> ChangePlayerStateAspect_physicsGraphicalSmoothingCAc;

			public ChangePlayerStateAspect this[Entity entity] => new ChangePlayerStateAspect(ChangePlayerStateAspect_animationBufferBAc[entity], ChangePlayerStateAspect_animationBufferPointerCAc.GetRefRW(entity), ChangePlayerStateAspect_animationOrientationCDCAc.GetRefRW(entity), ChangePlayerStateAspect_characterTypeCDCAc.GetRefRO(entity), ChangePlayerStateAspect_clientInputCAc.GetRefRO(entity), ChangePlayerStateAspect_conditionsBufferBAc[entity], ChangePlayerStateAspect_containedObjectsBufferBAc[entity], ChangePlayerStateAspect_controllingOtherEntityCDCAc.GetRefRW(entity), ChangePlayerStateAspect_equipmentCDCAc.GetRefRO(entity), ChangePlayerStateAspect_equippedObjectCDCAc.GetRefRO(entity), ChangePlayerStateAspect_effectEventBufferBAc[entity], ChangePlayerStateAspect_effectEventBufferPointerCDCAc.GetRefRW(entity), ChangePlayerStateAspect_healthCDCAc.GetRefRO(entity), ChangePlayerStateAspect_hungerCDCAc.GetRefRW(entity), ChangePlayerStateAspect_placementCDCAc.GetRefRO(entity), ChangePlayerStateAspect_playerColliderCDCAc.GetRefRO(entity), ChangePlayerStateAspect_equipmentSlotCDCAc.GetRefRO(entity), ChangePlayerStateAspect_playerInvincibilityCDCAc.GetRefRW(entity), ChangePlayerStateAspect_playerMovementCDCAc.GetRefRW(entity), ChangePlayerStateAspect_playerMovementForceCDCAc.GetRefRW(entity), ChangePlayerStateAspect_playerOrientationCDCAc.GetRefRW(entity), ChangePlayerStateAspect_playerRoutineCDCAc.GetRefRW(entity), ChangePlayerStateAspect_anticipationCDCAc.GetRefRW(entity), ChangePlayerStateAspect_boatRidingStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_castingStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_deathStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_digStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_fishingMiniGameStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_fishingStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_flattenStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_minecartRidingStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_placeObjectStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_placeWaterStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_sleepStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_playerStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_refillWaterStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_releaseStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_sittingStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_spawningFromCoreStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_teleportingCDCAc.GetRefRW(entity), ChangePlayerStateAspect_useOffHandStateCDCAc.GetRefRW(entity), ChangePlayerStateAspect_vehicleRidingStateCAc.GetRefRW(entity), ChangePlayerStateAspect_receivePushbackCDCAc.GetRefRW(entity), ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc[entity], entity, ChangePlayerStateAspect_physicsGraphicalSmoothingCAc.GetRefRW(entity));

			public Lookup(ref SystemState state)
			{
				ChangePlayerStateAspect_animationBufferBAc = state.GetBufferLookup<AnimationBuffer>();
				ChangePlayerStateAspect_animationBufferPointerCAc = state.GetComponentLookup<AnimationBufferPointer>();
				ChangePlayerStateAspect_animationOrientationCDCAc = state.GetComponentLookup<AnimationOrientationCD>();
				ChangePlayerStateAspect_characterTypeCDCAc = state.GetComponentLookup<CharacterTypeCD>(isReadOnly: true);
				ChangePlayerStateAspect_clientInputCAc = state.GetComponentLookup<ClientInput>(isReadOnly: true);
				ChangePlayerStateAspect_conditionsBufferBAc = state.GetBufferLookup<ConditionsBuffer>();
				ChangePlayerStateAspect_containedObjectsBufferBAc = state.GetBufferLookup<ContainedObjectsBuffer>();
				ChangePlayerStateAspect_controllingOtherEntityCDCAc = state.GetComponentLookup<ControllingOtherEntityCD>();
				ChangePlayerStateAspect_equipmentCDCAc = state.GetComponentLookup<EquipmentCD>(isReadOnly: true);
				ChangePlayerStateAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				ChangePlayerStateAspect_effectEventBufferBAc = state.GetBufferLookup<GhostEffectEventBuffer>();
				ChangePlayerStateAspect_effectEventBufferPointerCDCAc = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
				ChangePlayerStateAspect_healthCDCAc = state.GetComponentLookup<HealthCD>(isReadOnly: true);
				ChangePlayerStateAspect_hungerCDCAc = state.GetComponentLookup<HungerCD>();
				ChangePlayerStateAspect_placementCDCAc = state.GetComponentLookup<PlacementCD>(isReadOnly: true);
				ChangePlayerStateAspect_playerColliderCDCAc = state.GetComponentLookup<PlayerColliderCD>(isReadOnly: true);
				ChangePlayerStateAspect_equipmentSlotCDCAc = state.GetComponentLookup<EquipmentSlotCD>(isReadOnly: true);
				ChangePlayerStateAspect_playerInvincibilityCDCAc = state.GetComponentLookup<PlayerInvincibilityCD>();
				ChangePlayerStateAspect_playerMovementCDCAc = state.GetComponentLookup<PlayerMovementCD>();
				ChangePlayerStateAspect_playerMovementForceCDCAc = state.GetComponentLookup<PlayerMovementForceCD>();
				ChangePlayerStateAspect_playerOrientationCDCAc = state.GetComponentLookup<PlayerOrientationCD>();
				ChangePlayerStateAspect_playerRoutineCDCAc = state.GetComponentLookup<PlayerRoutineCD>();
				ChangePlayerStateAspect_anticipationCDCAc = state.GetComponentLookup<AnticipationCD>();
				ChangePlayerStateAspect_boatRidingStateCDCAc = state.GetComponentLookup<BoatRidingStateCD>();
				ChangePlayerStateAspect_castingStateCDCAc = state.GetComponentLookup<CastingStateCD>();
				ChangePlayerStateAspect_deathStateCDCAc = state.GetComponentLookup<DeathStateCD>();
				ChangePlayerStateAspect_digStateCDCAc = state.GetComponentLookup<DigStateCD>();
				ChangePlayerStateAspect_fishingMiniGameStateCDCAc = state.GetComponentLookup<FishingMiniGameStateCD>();
				ChangePlayerStateAspect_fishingStateCDCAc = state.GetComponentLookup<FishingStateCD>();
				ChangePlayerStateAspect_flattenStateCDCAc = state.GetComponentLookup<FlattenStateCD>();
				ChangePlayerStateAspect_minecartRidingStateCDCAc = state.GetComponentLookup<MinecartRidingStateCD>();
				ChangePlayerStateAspect_placeObjectStateCDCAc = state.GetComponentLookup<PlaceObjectPlayerStateCD>();
				ChangePlayerStateAspect_placeWaterStateCDCAc = state.GetComponentLookup<PlaceWaterStateCD>();
				ChangePlayerStateAspect_sleepStateCDCAc = state.GetComponentLookup<PlayerSleepStateCD>();
				ChangePlayerStateAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>();
				ChangePlayerStateAspect_refillWaterStateCDCAc = state.GetComponentLookup<RefillWaterStateCD>();
				ChangePlayerStateAspect_releaseStateCDCAc = state.GetComponentLookup<ReleaseStateCD>();
				ChangePlayerStateAspect_sittingStateCDCAc = state.GetComponentLookup<SittingStateCD>();
				ChangePlayerStateAspect_spawningFromCoreStateCDCAc = state.GetComponentLookup<SpawningFromCoreStateCD>();
				ChangePlayerStateAspect_teleportingCDCAc = state.GetComponentLookup<TeleportingStateCD>();
				ChangePlayerStateAspect_useOffHandStateCDCAc = state.GetComponentLookup<UseOffHandStateCD>();
				ChangePlayerStateAspect_vehicleRidingStateCAc = state.GetComponentLookup<VehicleRidingStateCD>();
				ChangePlayerStateAspect_receivePushbackCDCAc = state.GetComponentLookup<ReceivedPushbackCD>();
				ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc = state.GetBufferLookup<SummarizedConditionEffectsBuffer>();
				ChangePlayerStateAspect_physicsGraphicalSmoothingCAc = state.GetComponentLookup<PhysicsGraphicalSmoothing>();
			}

			public void Update(ref SystemState state)
			{
				ChangePlayerStateAspect_animationBufferBAc.Update(ref state);
				ChangePlayerStateAspect_animationBufferPointerCAc.Update(ref state);
				ChangePlayerStateAspect_animationOrientationCDCAc.Update(ref state);
				ChangePlayerStateAspect_characterTypeCDCAc.Update(ref state);
				ChangePlayerStateAspect_clientInputCAc.Update(ref state);
				ChangePlayerStateAspect_conditionsBufferBAc.Update(ref state);
				ChangePlayerStateAspect_containedObjectsBufferBAc.Update(ref state);
				ChangePlayerStateAspect_controllingOtherEntityCDCAc.Update(ref state);
				ChangePlayerStateAspect_equipmentCDCAc.Update(ref state);
				ChangePlayerStateAspect_equippedObjectCDCAc.Update(ref state);
				ChangePlayerStateAspect_effectEventBufferBAc.Update(ref state);
				ChangePlayerStateAspect_effectEventBufferPointerCDCAc.Update(ref state);
				ChangePlayerStateAspect_healthCDCAc.Update(ref state);
				ChangePlayerStateAspect_hungerCDCAc.Update(ref state);
				ChangePlayerStateAspect_placementCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerColliderCDCAc.Update(ref state);
				ChangePlayerStateAspect_equipmentSlotCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerInvincibilityCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerMovementCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerMovementForceCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerOrientationCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerRoutineCDCAc.Update(ref state);
				ChangePlayerStateAspect_anticipationCDCAc.Update(ref state);
				ChangePlayerStateAspect_boatRidingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_castingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_deathStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_digStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_fishingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_flattenStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_minecartRidingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_placeObjectStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_placeWaterStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_sleepStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_refillWaterStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_releaseStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_sittingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_spawningFromCoreStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_teleportingCDCAc.Update(ref state);
				ChangePlayerStateAspect_useOffHandStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_vehicleRidingStateCAc.Update(ref state);
				ChangePlayerStateAspect_receivePushbackCDCAc.Update(ref state);
				ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc.Update(ref state);
				ChangePlayerStateAspect_physicsGraphicalSmoothingCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public BufferAccessor<AnimationBuffer> ChangePlayerStateAspect_animationBufferBa;

			public NativeArray<AnimationBufferPointer> ChangePlayerStateAspect_animationBufferPointerNaC;

			public NativeArray<AnimationOrientationCD> ChangePlayerStateAspect_animationOrientationCDNaC;

			public NativeArray<CharacterTypeCD> ChangePlayerStateAspect_characterTypeCDNaC;

			public NativeArray<ClientInput> ChangePlayerStateAspect_clientInputNaC;

			public BufferAccessor<ConditionsBuffer> ChangePlayerStateAspect_conditionsBufferBa;

			public BufferAccessor<ContainedObjectsBuffer> ChangePlayerStateAspect_containedObjectsBufferBa;

			public NativeArray<ControllingOtherEntityCD> ChangePlayerStateAspect_controllingOtherEntityCDNaC;

			public NativeArray<EquipmentCD> ChangePlayerStateAspect_equipmentCDNaC;

			public NativeArray<EquippedObjectCD> ChangePlayerStateAspect_equippedObjectCDNaC;

			public BufferAccessor<GhostEffectEventBuffer> ChangePlayerStateAspect_effectEventBufferBa;

			public NativeArray<GhostEffectEventBufferPointerCD> ChangePlayerStateAspect_effectEventBufferPointerCDNaC;

			public NativeArray<HealthCD> ChangePlayerStateAspect_healthCDNaC;

			public NativeArray<HungerCD> ChangePlayerStateAspect_hungerCDNaC;

			public NativeArray<PlacementCD> ChangePlayerStateAspect_placementCDNaC;

			public NativeArray<PlayerColliderCD> ChangePlayerStateAspect_playerColliderCDNaC;

			public NativeArray<EquipmentSlotCD> ChangePlayerStateAspect_equipmentSlotCDNaC;

			public NativeArray<PlayerInvincibilityCD> ChangePlayerStateAspect_playerInvincibilityCDNaC;

			public NativeArray<PlayerMovementCD> ChangePlayerStateAspect_playerMovementCDNaC;

			public NativeArray<PlayerMovementForceCD> ChangePlayerStateAspect_playerMovementForceCDNaC;

			public NativeArray<PlayerOrientationCD> ChangePlayerStateAspect_playerOrientationCDNaC;

			public NativeArray<PlayerRoutineCD> ChangePlayerStateAspect_playerRoutineCDNaC;

			public NativeArray<AnticipationCD> ChangePlayerStateAspect_anticipationCDNaC;

			public NativeArray<BoatRidingStateCD> ChangePlayerStateAspect_boatRidingStateCDNaC;

			public NativeArray<CastingStateCD> ChangePlayerStateAspect_castingStateCDNaC;

			public NativeArray<DeathStateCD> ChangePlayerStateAspect_deathStateCDNaC;

			public NativeArray<DigStateCD> ChangePlayerStateAspect_digStateCDNaC;

			public NativeArray<FishingMiniGameStateCD> ChangePlayerStateAspect_fishingMiniGameStateCDNaC;

			public NativeArray<FishingStateCD> ChangePlayerStateAspect_fishingStateCDNaC;

			public NativeArray<FlattenStateCD> ChangePlayerStateAspect_flattenStateCDNaC;

			public NativeArray<MinecartRidingStateCD> ChangePlayerStateAspect_minecartRidingStateCDNaC;

			public NativeArray<PlaceObjectPlayerStateCD> ChangePlayerStateAspect_placeObjectStateCDNaC;

			public NativeArray<PlaceWaterStateCD> ChangePlayerStateAspect_placeWaterStateCDNaC;

			public NativeArray<PlayerSleepStateCD> ChangePlayerStateAspect_sleepStateCDNaC;

			public NativeArray<PlayerStateCD> ChangePlayerStateAspect_playerStateCDNaC;

			public NativeArray<RefillWaterStateCD> ChangePlayerStateAspect_refillWaterStateCDNaC;

			public NativeArray<ReleaseStateCD> ChangePlayerStateAspect_releaseStateCDNaC;

			public NativeArray<SittingStateCD> ChangePlayerStateAspect_sittingStateCDNaC;

			public NativeArray<SpawningFromCoreStateCD> ChangePlayerStateAspect_spawningFromCoreStateCDNaC;

			public NativeArray<TeleportingStateCD> ChangePlayerStateAspect_teleportingCDNaC;

			public NativeArray<UseOffHandStateCD> ChangePlayerStateAspect_useOffHandStateCDNaC;

			public NativeArray<VehicleRidingStateCD> ChangePlayerStateAspect_vehicleRidingStateNaC;

			public NativeArray<ReceivedPushbackCD> ChangePlayerStateAspect_receivePushbackCDNaC;

			public BufferAccessor<SummarizedConditionEffectsBuffer> ChangePlayerStateAspect_summarizedConditionEffectsBufferBa;

			public NativeArray<Entity> ChangePlayerStateAspect_entityNaE;

			public NativeArray<PhysicsGraphicalSmoothing> ChangePlayerStateAspect_physicsGraphicalSmoothingNaC;

			public int Length;

			public ChangePlayerStateAspect this[int index] => new ChangePlayerStateAspect(ChangePlayerStateAspect_animationBufferBa[index], new RefRW<AnimationBufferPointer>(ChangePlayerStateAspect_animationBufferPointerNaC, index), new RefRW<AnimationOrientationCD>(ChangePlayerStateAspect_animationOrientationCDNaC, index), new RefRO<CharacterTypeCD>(ChangePlayerStateAspect_characterTypeCDNaC, index), new RefRO<ClientInput>(ChangePlayerStateAspect_clientInputNaC, index), ChangePlayerStateAspect_conditionsBufferBa[index], ChangePlayerStateAspect_containedObjectsBufferBa[index], new RefRW<ControllingOtherEntityCD>(ChangePlayerStateAspect_controllingOtherEntityCDNaC, index), new RefRO<EquipmentCD>(ChangePlayerStateAspect_equipmentCDNaC, index), new RefRO<EquippedObjectCD>(ChangePlayerStateAspect_equippedObjectCDNaC, index), ChangePlayerStateAspect_effectEventBufferBa[index], new RefRW<GhostEffectEventBufferPointerCD>(ChangePlayerStateAspect_effectEventBufferPointerCDNaC, index), new RefRO<HealthCD>(ChangePlayerStateAspect_healthCDNaC, index), new RefRW<HungerCD>(ChangePlayerStateAspect_hungerCDNaC, index), new RefRO<PlacementCD>(ChangePlayerStateAspect_placementCDNaC, index), new RefRO<PlayerColliderCD>(ChangePlayerStateAspect_playerColliderCDNaC, index), new RefRO<EquipmentSlotCD>(ChangePlayerStateAspect_equipmentSlotCDNaC, index), new RefRW<PlayerInvincibilityCD>(ChangePlayerStateAspect_playerInvincibilityCDNaC, index), new RefRW<PlayerMovementCD>(ChangePlayerStateAspect_playerMovementCDNaC, index), new RefRW<PlayerMovementForceCD>(ChangePlayerStateAspect_playerMovementForceCDNaC, index), new RefRW<PlayerOrientationCD>(ChangePlayerStateAspect_playerOrientationCDNaC, index), new RefRW<PlayerRoutineCD>(ChangePlayerStateAspect_playerRoutineCDNaC, index), new RefRW<AnticipationCD>(ChangePlayerStateAspect_anticipationCDNaC, index), new RefRW<BoatRidingStateCD>(ChangePlayerStateAspect_boatRidingStateCDNaC, index), new RefRW<CastingStateCD>(ChangePlayerStateAspect_castingStateCDNaC, index), new RefRW<DeathStateCD>(ChangePlayerStateAspect_deathStateCDNaC, index), new RefRW<DigStateCD>(ChangePlayerStateAspect_digStateCDNaC, index), new RefRW<FishingMiniGameStateCD>(ChangePlayerStateAspect_fishingMiniGameStateCDNaC, index), new RefRW<FishingStateCD>(ChangePlayerStateAspect_fishingStateCDNaC, index), new RefRW<FlattenStateCD>(ChangePlayerStateAspect_flattenStateCDNaC, index), new RefRW<MinecartRidingStateCD>(ChangePlayerStateAspect_minecartRidingStateCDNaC, index), new RefRW<PlaceObjectPlayerStateCD>(ChangePlayerStateAspect_placeObjectStateCDNaC, index), new RefRW<PlaceWaterStateCD>(ChangePlayerStateAspect_placeWaterStateCDNaC, index), new RefRW<PlayerSleepStateCD>(ChangePlayerStateAspect_sleepStateCDNaC, index), new RefRW<PlayerStateCD>(ChangePlayerStateAspect_playerStateCDNaC, index), new RefRW<RefillWaterStateCD>(ChangePlayerStateAspect_refillWaterStateCDNaC, index), new RefRW<ReleaseStateCD>(ChangePlayerStateAspect_releaseStateCDNaC, index), new RefRW<SittingStateCD>(ChangePlayerStateAspect_sittingStateCDNaC, index), new RefRW<SpawningFromCoreStateCD>(ChangePlayerStateAspect_spawningFromCoreStateCDNaC, index), new RefRW<TeleportingStateCD>(ChangePlayerStateAspect_teleportingCDNaC, index), new RefRW<UseOffHandStateCD>(ChangePlayerStateAspect_useOffHandStateCDNaC, index), new RefRW<VehicleRidingStateCD>(ChangePlayerStateAspect_vehicleRidingStateNaC, index), new RefRW<ReceivedPushbackCD>(ChangePlayerStateAspect_receivePushbackCDNaC, index), ChangePlayerStateAspect_summarizedConditionEffectsBufferBa[index], ChangePlayerStateAspect_entityNaE[index], new RefRW<PhysicsGraphicalSmoothing>(ChangePlayerStateAspect_physicsGraphicalSmoothingNaC, index));
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<AnimationBuffer> ChangePlayerStateAspect_animationBufferBAc;

			private ComponentTypeHandle<AnimationBufferPointer> ChangePlayerStateAspect_animationBufferPointerCAc;

			private ComponentTypeHandle<AnimationOrientationCD> ChangePlayerStateAspect_animationOrientationCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<CharacterTypeCD> ChangePlayerStateAspect_characterTypeCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<ClientInput> ChangePlayerStateAspect_clientInputCAc;

			private BufferTypeHandle<ConditionsBuffer> ChangePlayerStateAspect_conditionsBufferBAc;

			private BufferTypeHandle<ContainedObjectsBuffer> ChangePlayerStateAspect_containedObjectsBufferBAc;

			private ComponentTypeHandle<ControllingOtherEntityCD> ChangePlayerStateAspect_controllingOtherEntityCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentCD> ChangePlayerStateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> ChangePlayerStateAspect_equippedObjectCDCAc;

			private BufferTypeHandle<GhostEffectEventBuffer> ChangePlayerStateAspect_effectEventBufferBAc;

			private ComponentTypeHandle<GhostEffectEventBufferPointerCD> ChangePlayerStateAspect_effectEventBufferPointerCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<HealthCD> ChangePlayerStateAspect_healthCDCAc;

			private ComponentTypeHandle<HungerCD> ChangePlayerStateAspect_hungerCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlacementCD> ChangePlayerStateAspect_placementCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerColliderCD> ChangePlayerStateAspect_playerColliderCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotCD> ChangePlayerStateAspect_equipmentSlotCDCAc;

			private ComponentTypeHandle<PlayerInvincibilityCD> ChangePlayerStateAspect_playerInvincibilityCDCAc;

			private ComponentTypeHandle<PlayerMovementCD> ChangePlayerStateAspect_playerMovementCDCAc;

			private ComponentTypeHandle<PlayerMovementForceCD> ChangePlayerStateAspect_playerMovementForceCDCAc;

			private ComponentTypeHandle<PlayerOrientationCD> ChangePlayerStateAspect_playerOrientationCDCAc;

			private ComponentTypeHandle<PlayerRoutineCD> ChangePlayerStateAspect_playerRoutineCDCAc;

			private ComponentTypeHandle<AnticipationCD> ChangePlayerStateAspect_anticipationCDCAc;

			private ComponentTypeHandle<BoatRidingStateCD> ChangePlayerStateAspect_boatRidingStateCDCAc;

			private ComponentTypeHandle<CastingStateCD> ChangePlayerStateAspect_castingStateCDCAc;

			private ComponentTypeHandle<DeathStateCD> ChangePlayerStateAspect_deathStateCDCAc;

			private ComponentTypeHandle<DigStateCD> ChangePlayerStateAspect_digStateCDCAc;

			private ComponentTypeHandle<FishingMiniGameStateCD> ChangePlayerStateAspect_fishingMiniGameStateCDCAc;

			private ComponentTypeHandle<FishingStateCD> ChangePlayerStateAspect_fishingStateCDCAc;

			private ComponentTypeHandle<FlattenStateCD> ChangePlayerStateAspect_flattenStateCDCAc;

			private ComponentTypeHandle<MinecartRidingStateCD> ChangePlayerStateAspect_minecartRidingStateCDCAc;

			private ComponentTypeHandle<PlaceObjectPlayerStateCD> ChangePlayerStateAspect_placeObjectStateCDCAc;

			private ComponentTypeHandle<PlaceWaterStateCD> ChangePlayerStateAspect_placeWaterStateCDCAc;

			private ComponentTypeHandle<PlayerSleepStateCD> ChangePlayerStateAspect_sleepStateCDCAc;

			private ComponentTypeHandle<PlayerStateCD> ChangePlayerStateAspect_playerStateCDCAc;

			private ComponentTypeHandle<RefillWaterStateCD> ChangePlayerStateAspect_refillWaterStateCDCAc;

			private ComponentTypeHandle<ReleaseStateCD> ChangePlayerStateAspect_releaseStateCDCAc;

			private ComponentTypeHandle<SittingStateCD> ChangePlayerStateAspect_sittingStateCDCAc;

			private ComponentTypeHandle<SpawningFromCoreStateCD> ChangePlayerStateAspect_spawningFromCoreStateCDCAc;

			private ComponentTypeHandle<TeleportingStateCD> ChangePlayerStateAspect_teleportingCDCAc;

			private ComponentTypeHandle<UseOffHandStateCD> ChangePlayerStateAspect_useOffHandStateCDCAc;

			private ComponentTypeHandle<VehicleRidingStateCD> ChangePlayerStateAspect_vehicleRidingStateCAc;

			private ComponentTypeHandle<ReceivedPushbackCD> ChangePlayerStateAspect_receivePushbackCDCAc;

			private BufferTypeHandle<SummarizedConditionEffectsBuffer> ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc;

			private EntityTypeHandle ChangePlayerStateAspect_entityEAc;

			private ComponentTypeHandle<PhysicsGraphicalSmoothing> ChangePlayerStateAspect_physicsGraphicalSmoothingCAc;

			public TypeHandle(ref SystemState state)
			{
				ChangePlayerStateAspect_animationBufferBAc = state.GetBufferTypeHandle<AnimationBuffer>();
				ChangePlayerStateAspect_animationBufferPointerCAc = state.GetComponentTypeHandle<AnimationBufferPointer>();
				ChangePlayerStateAspect_animationOrientationCDCAc = state.GetComponentTypeHandle<AnimationOrientationCD>();
				ChangePlayerStateAspect_characterTypeCDCAc = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
				ChangePlayerStateAspect_clientInputCAc = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
				ChangePlayerStateAspect_conditionsBufferBAc = state.GetBufferTypeHandle<ConditionsBuffer>();
				ChangePlayerStateAspect_containedObjectsBufferBAc = state.GetBufferTypeHandle<ContainedObjectsBuffer>();
				ChangePlayerStateAspect_controllingOtherEntityCDCAc = state.GetComponentTypeHandle<ControllingOtherEntityCD>();
				ChangePlayerStateAspect_equipmentCDCAc = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
				ChangePlayerStateAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				ChangePlayerStateAspect_effectEventBufferBAc = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
				ChangePlayerStateAspect_effectEventBufferPointerCDCAc = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
				ChangePlayerStateAspect_healthCDCAc = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
				ChangePlayerStateAspect_hungerCDCAc = state.GetComponentTypeHandle<HungerCD>();
				ChangePlayerStateAspect_placementCDCAc = state.GetComponentTypeHandle<PlacementCD>(isReadOnly: true);
				ChangePlayerStateAspect_playerColliderCDCAc = state.GetComponentTypeHandle<PlayerColliderCD>(isReadOnly: true);
				ChangePlayerStateAspect_equipmentSlotCDCAc = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
				ChangePlayerStateAspect_playerInvincibilityCDCAc = state.GetComponentTypeHandle<PlayerInvincibilityCD>();
				ChangePlayerStateAspect_playerMovementCDCAc = state.GetComponentTypeHandle<PlayerMovementCD>();
				ChangePlayerStateAspect_playerMovementForceCDCAc = state.GetComponentTypeHandle<PlayerMovementForceCD>();
				ChangePlayerStateAspect_playerOrientationCDCAc = state.GetComponentTypeHandle<PlayerOrientationCD>();
				ChangePlayerStateAspect_playerRoutineCDCAc = state.GetComponentTypeHandle<PlayerRoutineCD>();
				ChangePlayerStateAspect_anticipationCDCAc = state.GetComponentTypeHandle<AnticipationCD>();
				ChangePlayerStateAspect_boatRidingStateCDCAc = state.GetComponentTypeHandle<BoatRidingStateCD>();
				ChangePlayerStateAspect_castingStateCDCAc = state.GetComponentTypeHandle<CastingStateCD>();
				ChangePlayerStateAspect_deathStateCDCAc = state.GetComponentTypeHandle<DeathStateCD>();
				ChangePlayerStateAspect_digStateCDCAc = state.GetComponentTypeHandle<DigStateCD>();
				ChangePlayerStateAspect_fishingMiniGameStateCDCAc = state.GetComponentTypeHandle<FishingMiniGameStateCD>();
				ChangePlayerStateAspect_fishingStateCDCAc = state.GetComponentTypeHandle<FishingStateCD>();
				ChangePlayerStateAspect_flattenStateCDCAc = state.GetComponentTypeHandle<FlattenStateCD>();
				ChangePlayerStateAspect_minecartRidingStateCDCAc = state.GetComponentTypeHandle<MinecartRidingStateCD>();
				ChangePlayerStateAspect_placeObjectStateCDCAc = state.GetComponentTypeHandle<PlaceObjectPlayerStateCD>();
				ChangePlayerStateAspect_placeWaterStateCDCAc = state.GetComponentTypeHandle<PlaceWaterStateCD>();
				ChangePlayerStateAspect_sleepStateCDCAc = state.GetComponentTypeHandle<PlayerSleepStateCD>();
				ChangePlayerStateAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>();
				ChangePlayerStateAspect_refillWaterStateCDCAc = state.GetComponentTypeHandle<RefillWaterStateCD>();
				ChangePlayerStateAspect_releaseStateCDCAc = state.GetComponentTypeHandle<ReleaseStateCD>();
				ChangePlayerStateAspect_sittingStateCDCAc = state.GetComponentTypeHandle<SittingStateCD>();
				ChangePlayerStateAspect_spawningFromCoreStateCDCAc = state.GetComponentTypeHandle<SpawningFromCoreStateCD>();
				ChangePlayerStateAspect_teleportingCDCAc = state.GetComponentTypeHandle<TeleportingStateCD>();
				ChangePlayerStateAspect_useOffHandStateCDCAc = state.GetComponentTypeHandle<UseOffHandStateCD>();
				ChangePlayerStateAspect_vehicleRidingStateCAc = state.GetComponentTypeHandle<VehicleRidingStateCD>();
				ChangePlayerStateAspect_receivePushbackCDCAc = state.GetComponentTypeHandle<ReceivedPushbackCD>();
				ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>();
				ChangePlayerStateAspect_entityEAc = state.GetEntityTypeHandle();
				ChangePlayerStateAspect_physicsGraphicalSmoothingCAc = state.GetComponentTypeHandle<PhysicsGraphicalSmoothing>();
			}

			public void Update(ref SystemState state)
			{
				ChangePlayerStateAspect_animationBufferBAc.Update(ref state);
				ChangePlayerStateAspect_animationBufferPointerCAc.Update(ref state);
				ChangePlayerStateAspect_animationOrientationCDCAc.Update(ref state);
				ChangePlayerStateAspect_characterTypeCDCAc.Update(ref state);
				ChangePlayerStateAspect_clientInputCAc.Update(ref state);
				ChangePlayerStateAspect_conditionsBufferBAc.Update(ref state);
				ChangePlayerStateAspect_containedObjectsBufferBAc.Update(ref state);
				ChangePlayerStateAspect_controllingOtherEntityCDCAc.Update(ref state);
				ChangePlayerStateAspect_equipmentCDCAc.Update(ref state);
				ChangePlayerStateAspect_equippedObjectCDCAc.Update(ref state);
				ChangePlayerStateAspect_effectEventBufferBAc.Update(ref state);
				ChangePlayerStateAspect_effectEventBufferPointerCDCAc.Update(ref state);
				ChangePlayerStateAspect_healthCDCAc.Update(ref state);
				ChangePlayerStateAspect_hungerCDCAc.Update(ref state);
				ChangePlayerStateAspect_placementCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerColliderCDCAc.Update(ref state);
				ChangePlayerStateAspect_equipmentSlotCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerInvincibilityCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerMovementCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerMovementForceCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerOrientationCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerRoutineCDCAc.Update(ref state);
				ChangePlayerStateAspect_anticipationCDCAc.Update(ref state);
				ChangePlayerStateAspect_boatRidingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_castingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_deathStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_digStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_fishingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_flattenStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_minecartRidingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_placeObjectStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_placeWaterStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_sleepStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_playerStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_refillWaterStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_releaseStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_sittingStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_spawningFromCoreStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_teleportingCDCAc.Update(ref state);
				ChangePlayerStateAspect_useOffHandStateCDCAc.Update(ref state);
				ChangePlayerStateAspect_vehicleRidingStateCAc.Update(ref state);
				ChangePlayerStateAspect_receivePushbackCDCAc.Update(ref state);
				ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc.Update(ref state);
				ChangePlayerStateAspect_entityEAc.Update(ref state);
				ChangePlayerStateAspect_physicsGraphicalSmoothingCAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.ChangePlayerStateAspect_animationBufferBa = chunk.GetBufferAccessor(ref ChangePlayerStateAspect_animationBufferBAc);
				result.ChangePlayerStateAspect_animationBufferPointerNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_animationBufferPointerCAc);
				result.ChangePlayerStateAspect_animationOrientationCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_animationOrientationCDCAc);
				result.ChangePlayerStateAspect_characterTypeCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_characterTypeCDCAc);
				result.ChangePlayerStateAspect_clientInputNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_clientInputCAc);
				result.ChangePlayerStateAspect_conditionsBufferBa = chunk.GetBufferAccessor(ref ChangePlayerStateAspect_conditionsBufferBAc);
				result.ChangePlayerStateAspect_containedObjectsBufferBa = chunk.GetBufferAccessor(ref ChangePlayerStateAspect_containedObjectsBufferBAc);
				result.ChangePlayerStateAspect_controllingOtherEntityCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_controllingOtherEntityCDCAc);
				result.ChangePlayerStateAspect_equipmentCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_equipmentCDCAc);
				result.ChangePlayerStateAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_equippedObjectCDCAc);
				result.ChangePlayerStateAspect_effectEventBufferBa = chunk.GetBufferAccessor(ref ChangePlayerStateAspect_effectEventBufferBAc);
				result.ChangePlayerStateAspect_effectEventBufferPointerCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_effectEventBufferPointerCDCAc);
				result.ChangePlayerStateAspect_healthCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_healthCDCAc);
				result.ChangePlayerStateAspect_hungerCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_hungerCDCAc);
				result.ChangePlayerStateAspect_placementCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_placementCDCAc);
				result.ChangePlayerStateAspect_playerColliderCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerColliderCDCAc);
				result.ChangePlayerStateAspect_equipmentSlotCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_equipmentSlotCDCAc);
				result.ChangePlayerStateAspect_playerInvincibilityCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerInvincibilityCDCAc);
				result.ChangePlayerStateAspect_playerMovementCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerMovementCDCAc);
				result.ChangePlayerStateAspect_playerMovementForceCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerMovementForceCDCAc);
				result.ChangePlayerStateAspect_playerOrientationCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerOrientationCDCAc);
				result.ChangePlayerStateAspect_playerRoutineCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerRoutineCDCAc);
				result.ChangePlayerStateAspect_anticipationCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_anticipationCDCAc);
				result.ChangePlayerStateAspect_boatRidingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_boatRidingStateCDCAc);
				result.ChangePlayerStateAspect_castingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_castingStateCDCAc);
				result.ChangePlayerStateAspect_deathStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_deathStateCDCAc);
				result.ChangePlayerStateAspect_digStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_digStateCDCAc);
				result.ChangePlayerStateAspect_fishingMiniGameStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_fishingMiniGameStateCDCAc);
				result.ChangePlayerStateAspect_fishingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_fishingStateCDCAc);
				result.ChangePlayerStateAspect_flattenStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_flattenStateCDCAc);
				result.ChangePlayerStateAspect_minecartRidingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_minecartRidingStateCDCAc);
				result.ChangePlayerStateAspect_placeObjectStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_placeObjectStateCDCAc);
				result.ChangePlayerStateAspect_placeWaterStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_placeWaterStateCDCAc);
				result.ChangePlayerStateAspect_sleepStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_sleepStateCDCAc);
				result.ChangePlayerStateAspect_playerStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_playerStateCDCAc);
				result.ChangePlayerStateAspect_refillWaterStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_refillWaterStateCDCAc);
				result.ChangePlayerStateAspect_releaseStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_releaseStateCDCAc);
				result.ChangePlayerStateAspect_sittingStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_sittingStateCDCAc);
				result.ChangePlayerStateAspect_spawningFromCoreStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_spawningFromCoreStateCDCAc);
				result.ChangePlayerStateAspect_teleportingCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_teleportingCDCAc);
				result.ChangePlayerStateAspect_useOffHandStateCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_useOffHandStateCDCAc);
				result.ChangePlayerStateAspect_vehicleRidingStateNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_vehicleRidingStateCAc);
				result.ChangePlayerStateAspect_receivePushbackCDNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_receivePushbackCDCAc);
				result.ChangePlayerStateAspect_summarizedConditionEffectsBufferBa = chunk.GetBufferAccessor(ref ChangePlayerStateAspect_summarizedConditionEffectsBufferBAc);
				result.ChangePlayerStateAspect_entityNaE = chunk.GetNativeArray(ChangePlayerStateAspect_entityEAc);
				result.ChangePlayerStateAspect_physicsGraphicalSmoothingNaC = chunk.GetNativeArray(ref ChangePlayerStateAspect_physicsGraphicalSmoothingCAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<ChangePlayerStateAspect>, IEnumerator, IDisposable, IEnumerable<ChangePlayerStateAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public ChangePlayerStateAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

			IEnumerator<ChangePlayerStateAspect> IEnumerable<ChangePlayerStateAspect>.GetEnumerator()
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

		public readonly RefRW<PlayerMovementForceCD> playerMovementForceCD;

		public readonly RefRW<PlayerOrientationCD> playerOrientationCD;

		public readonly RefRW<ReleaseStateCD> releaseStateCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly RefRW<AnticipationCD> anticipationCD;

		public readonly RefRW<DeathStateCD> deathStateCD;

		public readonly RefRW<UseOffHandStateCD> useOffHandStateCD;

		public readonly RefRW<PlayerRoutineCD> playerRoutineCD;

		public readonly DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer;

		public readonly RefRW<PlayerMovementCD> playerMovementCD;

		public readonly RefRW<AnimationOrientationCD> animationOrientationCD;

		public readonly DynamicBuffer<GhostEffectEventBuffer> effectEventBuffer;

		public readonly RefRW<GhostEffectEventBufferPointerCD> effectEventBufferPointerCD;

		public readonly RefRO<EquipmentCD> equipmentCD;

		public readonly RefRW<PlayerInvincibilityCD> playerInvincibilityCD;

		public readonly RefRW<TeleportingStateCD> teleportingCD;

		public readonly RefRW<CastingStateCD> castingStateCD;

		public readonly RefRO<HealthCD> healthCD;

		public readonly DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer;

		public readonly RefRW<SpawningFromCoreStateCD> spawningFromCoreStateCD;

		public readonly RefRW<PlayerSleepStateCD> sleepStateCD;

		public readonly RefRW<FishingStateCD> fishingStateCD;

		public readonly RefRW<SittingStateCD> sittingStateCD;

		public readonly RefRW<MinecartRidingStateCD> minecartRidingStateCD;

		public readonly RefRW<HungerCD> hungerCD;

		public readonly RefRW<BoatRidingStateCD> boatRidingStateCD;

		public readonly RefRO<PlayerColliderCD> playerColliderCD;

		public readonly RefRW<VehicleRidingStateCD> vehicleRidingState;

		public readonly RefRW<PhysicsGraphicalSmoothing> physicsGraphicalSmoothing;

		public readonly RefRW<RefillWaterStateCD> refillWaterStateCD;

		public readonly RefRO<PlacementCD> placementCD;

		public readonly RefRO<EquipmentSlotCD> equipmentSlotCD;

		public readonly RefRW<PlaceObjectPlayerStateCD> placeObjectStateCD;

		public readonly RefRW<DigStateCD> digStateCD;

		public readonly RefRW<PlaceWaterStateCD> placeWaterStateCD;

		public readonly RefRW<FlattenStateCD> flattenStateCD;

		public readonly DynamicBuffer<AnimationBuffer> animationBuffer;

		public readonly RefRW<AnimationBufferPointer> animationBufferPointer;

		public readonly DynamicBuffer<ConditionsBuffer> conditionsBuffer;

		public readonly RefRW<ControllingOtherEntityCD> controllingOtherEntityCD;

		public readonly RefRW<ReceivedPushbackCD> receivePushbackCD;

		public readonly RefRW<FishingMiniGameStateCD> fishingMiniGameStateCD;

		public readonly RefRO<ClientInput> clientInput;

		public readonly RefRO<CharacterTypeCD> characterTypeCD;

		public ChangePlayerStateAspect(DynamicBuffer<AnimationBuffer> changeplayerstateaspect_animationbufferDb, RefRW<AnimationBufferPointer> changeplayerstateaspect_animationbufferpointerRef, RefRW<AnimationOrientationCD> changeplayerstateaspect_animationorientationcdRef, RefRO<CharacterTypeCD> changeplayerstateaspect_charactertypecdRef, RefRO<ClientInput> changeplayerstateaspect_clientinputRef, DynamicBuffer<ConditionsBuffer> changeplayerstateaspect_conditionsbufferDb, DynamicBuffer<ContainedObjectsBuffer> changeplayerstateaspect_containedobjectsbufferDb, RefRW<ControllingOtherEntityCD> changeplayerstateaspect_controllingotherentitycdRef, RefRO<EquipmentCD> changeplayerstateaspect_equipmentcdRef, RefRO<EquippedObjectCD> changeplayerstateaspect_equippedobjectcdRef, DynamicBuffer<GhostEffectEventBuffer> changeplayerstateaspect_effecteventbufferDb, RefRW<GhostEffectEventBufferPointerCD> changeplayerstateaspect_effecteventbufferpointercdRef, RefRO<HealthCD> changeplayerstateaspect_healthcdRef, RefRW<HungerCD> changeplayerstateaspect_hungercdRef, RefRO<PlacementCD> changeplayerstateaspect_placementcdRef, RefRO<PlayerColliderCD> changeplayerstateaspect_playercollidercdRef, RefRO<EquipmentSlotCD> changeplayerstateaspect_equipmentslotcdRef, RefRW<PlayerInvincibilityCD> changeplayerstateaspect_playerinvincibilitycdRef, RefRW<PlayerMovementCD> changeplayerstateaspect_playermovementcdRef, RefRW<PlayerMovementForceCD> changeplayerstateaspect_playermovementforcecdRef, RefRW<PlayerOrientationCD> changeplayerstateaspect_playerorientationcdRef, RefRW<PlayerRoutineCD> changeplayerstateaspect_playerroutinecdRef, RefRW<AnticipationCD> changeplayerstateaspect_anticipationcdRef, RefRW<BoatRidingStateCD> changeplayerstateaspect_boatridingstatecdRef, RefRW<CastingStateCD> changeplayerstateaspect_castingstatecdRef, RefRW<DeathStateCD> changeplayerstateaspect_deathstatecdRef, RefRW<DigStateCD> changeplayerstateaspect_digstatecdRef, RefRW<FishingMiniGameStateCD> changeplayerstateaspect_fishingminigamestatecdRef, RefRW<FishingStateCD> changeplayerstateaspect_fishingstatecdRef, RefRW<FlattenStateCD> changeplayerstateaspect_flattenstatecdRef, RefRW<MinecartRidingStateCD> changeplayerstateaspect_minecartridingstatecdRef, RefRW<PlaceObjectPlayerStateCD> changeplayerstateaspect_placeobjectstatecdRef, RefRW<PlaceWaterStateCD> changeplayerstateaspect_placewaterstatecdRef, RefRW<PlayerSleepStateCD> changeplayerstateaspect_sleepstatecdRef, RefRW<PlayerStateCD> changeplayerstateaspect_playerstatecdRef, RefRW<RefillWaterStateCD> changeplayerstateaspect_refillwaterstatecdRef, RefRW<ReleaseStateCD> changeplayerstateaspect_releasestatecdRef, RefRW<SittingStateCD> changeplayerstateaspect_sittingstatecdRef, RefRW<SpawningFromCoreStateCD> changeplayerstateaspect_spawningfromcorestatecdRef, RefRW<TeleportingStateCD> changeplayerstateaspect_teleportingcdRef, RefRW<UseOffHandStateCD> changeplayerstateaspect_useoffhandstatecdRef, RefRW<VehicleRidingStateCD> changeplayerstateaspect_vehicleridingstateRef, RefRW<ReceivedPushbackCD> changeplayerstateaspect_receivepushbackcdRef, DynamicBuffer<SummarizedConditionEffectsBuffer> changeplayerstateaspect_summarizedconditioneffectsbufferDb, Entity changeplayerstateaspect_entityE, RefRW<PhysicsGraphicalSmoothing> changeplayerstateaspect_physicsgraphicalsmoothingRef)
		{
			animationBuffer = changeplayerstateaspect_animationbufferDb;
			animationBufferPointer = changeplayerstateaspect_animationbufferpointerRef;
			animationOrientationCD = changeplayerstateaspect_animationorientationcdRef;
			characterTypeCD = changeplayerstateaspect_charactertypecdRef;
			clientInput = changeplayerstateaspect_clientinputRef;
			conditionsBuffer = changeplayerstateaspect_conditionsbufferDb;
			containedObjectsBuffer = changeplayerstateaspect_containedobjectsbufferDb;
			controllingOtherEntityCD = changeplayerstateaspect_controllingotherentitycdRef;
			equipmentCD = changeplayerstateaspect_equipmentcdRef;
			equippedObjectCD = changeplayerstateaspect_equippedobjectcdRef;
			effectEventBuffer = changeplayerstateaspect_effecteventbufferDb;
			effectEventBufferPointerCD = changeplayerstateaspect_effecteventbufferpointercdRef;
			healthCD = changeplayerstateaspect_healthcdRef;
			hungerCD = changeplayerstateaspect_hungercdRef;
			placementCD = changeplayerstateaspect_placementcdRef;
			playerColliderCD = changeplayerstateaspect_playercollidercdRef;
			equipmentSlotCD = changeplayerstateaspect_equipmentslotcdRef;
			playerInvincibilityCD = changeplayerstateaspect_playerinvincibilitycdRef;
			playerMovementCD = changeplayerstateaspect_playermovementcdRef;
			playerMovementForceCD = changeplayerstateaspect_playermovementforcecdRef;
			playerOrientationCD = changeplayerstateaspect_playerorientationcdRef;
			playerRoutineCD = changeplayerstateaspect_playerroutinecdRef;
			anticipationCD = changeplayerstateaspect_anticipationcdRef;
			boatRidingStateCD = changeplayerstateaspect_boatridingstatecdRef;
			castingStateCD = changeplayerstateaspect_castingstatecdRef;
			deathStateCD = changeplayerstateaspect_deathstatecdRef;
			digStateCD = changeplayerstateaspect_digstatecdRef;
			fishingMiniGameStateCD = changeplayerstateaspect_fishingminigamestatecdRef;
			fishingStateCD = changeplayerstateaspect_fishingstatecdRef;
			flattenStateCD = changeplayerstateaspect_flattenstatecdRef;
			minecartRidingStateCD = changeplayerstateaspect_minecartridingstatecdRef;
			placeObjectStateCD = changeplayerstateaspect_placeobjectstatecdRef;
			placeWaterStateCD = changeplayerstateaspect_placewaterstatecdRef;
			sleepStateCD = changeplayerstateaspect_sleepstatecdRef;
			playerStateCD = changeplayerstateaspect_playerstatecdRef;
			refillWaterStateCD = changeplayerstateaspect_refillwaterstatecdRef;
			releaseStateCD = changeplayerstateaspect_releasestatecdRef;
			sittingStateCD = changeplayerstateaspect_sittingstatecdRef;
			spawningFromCoreStateCD = changeplayerstateaspect_spawningfromcorestatecdRef;
			teleportingCD = changeplayerstateaspect_teleportingcdRef;
			useOffHandStateCD = changeplayerstateaspect_useoffhandstatecdRef;
			vehicleRidingState = changeplayerstateaspect_vehicleridingstateRef;
			receivePushbackCD = changeplayerstateaspect_receivepushbackcdRef;
			summarizedConditionEffectsBuffer = changeplayerstateaspect_summarizedconditioneffectsbufferDb;
			entity = changeplayerstateaspect_entityE;
			physicsGraphicalSmoothing = changeplayerstateaspect_physicsgraphicalsmoothingRef;
		}

		public ChangePlayerStateAspect CreateAspect(Entity entity, ref SystemState systemState)
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
			unsafeList.Add(ComponentType.ReadWrite<ContainedObjectsBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<ControllingOtherEntityCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquipmentCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>());
			unsafeList.Add(ComponentType.ReadOnly<HealthCD>());
			unsafeList.Add(ComponentType.ReadWrite<HungerCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlacementCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerColliderCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquipmentSlotCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerInvincibilityCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerMovementCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerMovementForceCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerOrientationCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerRoutineCD>());
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
			unsafeList.Add(ComponentType.ReadWrite<ReceivedPushbackCD>());
			unsafeList.Add(ComponentType.ReadWrite<SummarizedConditionEffectsBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<PhysicsGraphicalSmoothing>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 45;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadWrite<AnimationBuffer>();
			componentTypes[1] = ComponentType.ReadWrite<AnimationBufferPointer>();
			componentTypes[2] = ComponentType.ReadWrite<AnimationOrientationCD>();
			componentTypes[3] = ComponentType.ReadOnly<CharacterTypeCD>();
			componentTypes[4] = ComponentType.ReadOnly<ClientInput>();
			componentTypes[5] = ComponentType.ReadWrite<ConditionsBuffer>();
			componentTypes[6] = ComponentType.ReadWrite<ContainedObjectsBuffer>();
			componentTypes[7] = ComponentType.ReadWrite<ControllingOtherEntityCD>();
			componentTypes[8] = ComponentType.ReadOnly<EquipmentCD>();
			componentTypes[9] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[10] = ComponentType.ReadWrite<GhostEffectEventBuffer>();
			componentTypes[11] = ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>();
			componentTypes[12] = ComponentType.ReadOnly<HealthCD>();
			componentTypes[13] = ComponentType.ReadWrite<HungerCD>();
			componentTypes[14] = ComponentType.ReadOnly<PlacementCD>();
			componentTypes[15] = ComponentType.ReadOnly<PlayerColliderCD>();
			componentTypes[16] = ComponentType.ReadOnly<EquipmentSlotCD>();
			componentTypes[17] = ComponentType.ReadWrite<PlayerInvincibilityCD>();
			componentTypes[18] = ComponentType.ReadWrite<PlayerMovementCD>();
			componentTypes[19] = ComponentType.ReadWrite<PlayerMovementForceCD>();
			componentTypes[20] = ComponentType.ReadWrite<PlayerOrientationCD>();
			componentTypes[21] = ComponentType.ReadWrite<PlayerRoutineCD>();
			componentTypes[22] = ComponentType.ReadWrite<AnticipationCD>();
			componentTypes[23] = ComponentType.ReadWrite<BoatRidingStateCD>();
			componentTypes[24] = ComponentType.ReadWrite<CastingStateCD>();
			componentTypes[25] = ComponentType.ReadWrite<DeathStateCD>();
			componentTypes[26] = ComponentType.ReadWrite<DigStateCD>();
			componentTypes[27] = ComponentType.ReadWrite<FishingMiniGameStateCD>();
			componentTypes[28] = ComponentType.ReadWrite<FishingStateCD>();
			componentTypes[29] = ComponentType.ReadWrite<FlattenStateCD>();
			componentTypes[30] = ComponentType.ReadWrite<MinecartRidingStateCD>();
			componentTypes[31] = ComponentType.ReadWrite<PlaceObjectPlayerStateCD>();
			componentTypes[32] = ComponentType.ReadWrite<PlaceWaterStateCD>();
			componentTypes[33] = ComponentType.ReadWrite<PlayerSleepStateCD>();
			componentTypes[34] = ComponentType.ReadWrite<PlayerStateCD>();
			componentTypes[35] = ComponentType.ReadWrite<RefillWaterStateCD>();
			componentTypes[36] = ComponentType.ReadWrite<ReleaseStateCD>();
			componentTypes[37] = ComponentType.ReadWrite<SittingStateCD>();
			componentTypes[38] = ComponentType.ReadWrite<SpawningFromCoreStateCD>();
			componentTypes[39] = ComponentType.ReadWrite<TeleportingStateCD>();
			componentTypes[40] = ComponentType.ReadWrite<UseOffHandStateCD>();
			componentTypes[41] = ComponentType.ReadWrite<VehicleRidingStateCD>();
			componentTypes[42] = ComponentType.ReadWrite<ReceivedPushbackCD>();
			componentTypes[43] = ComponentType.ReadWrite<SummarizedConditionEffectsBuffer>();
			componentTypes[44] = ComponentType.ReadWrite<PhysicsGraphicalSmoothing>();
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
			state.EntityManager.CompleteDependencyBeforeRO<ContainedObjectsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<ControllingOtherEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<HealthCD>();
			state.EntityManager.CompleteDependencyBeforeRO<HungerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerColliderCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerInvincibilityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerMovementCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerMovementForceCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerRoutineCD>();
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
			state.EntityManager.CompleteDependencyBeforeRO<ReceivedPushbackCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SummarizedConditionEffectsBuffer>();
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
			state.EntityManager.CompleteDependencyBeforeRW<ContainedObjectsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<ControllingOtherEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<HealthCD>();
			state.EntityManager.CompleteDependencyBeforeRW<HungerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerColliderCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerInvincibilityCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerMovementCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerMovementForceCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerRoutineCD>();
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
			state.EntityManager.CompleteDependencyBeforeRW<ReceivedPushbackCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SummarizedConditionEffectsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<PhysicsGraphicalSmoothing>();
		}
	}
}
