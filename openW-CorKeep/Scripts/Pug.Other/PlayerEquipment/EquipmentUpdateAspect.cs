using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PlayerState;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;

namespace PlayerEquipment
{
	public readonly struct EquipmentUpdateAspect : IAspect, IQueryTypeParameter, IAspectCreate<EquipmentUpdateAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<EquipmentUpdateAspect>
		{
			private BufferLookup<AnimationBuffer> EquipmentUpdateAspect_animationBufferBAc;

			private ComponentLookup<AnimationBufferPointer> EquipmentUpdateAspect_animationBufferPointerCAc;

			[ReadOnly]
			private ComponentLookup<AnimationOrientationCD> EquipmentUpdateAspect_animationOrientationCDCAc;

			[ReadOnly]
			private ComponentLookup<CharacterTypeCD> EquipmentUpdateAspect_CharacterTypeCAc;

			[ReadOnly]
			private ComponentLookup<ClientInput> EquipmentUpdateAspect_clientInputCAc;

			private ComponentLookup<CritterDamageFromPlacingCD> EquipmentUpdateAspect_critterDamageFromPlacingCDCAc;

			private BufferLookup<DealDamageToEntityBuffer> EquipmentUpdateAspect_dealDamageToEntityBufferBAc;

			[ReadOnly]
			private ComponentLookup<EquipmentCD> EquipmentUpdateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> EquipmentUpdateAspect_equippedObjectCDCAc;

			private BufferLookup<GhostEffectEventBuffer> EquipmentUpdateAspect_ghostEffectEventBufferBAc;

			private ComponentLookup<GhostEffectEventBufferPointerCD> EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentLookup<HungerCD> EquipmentUpdateAspect_hungerCDCAc;

			[ReadOnly]
			private ComponentLookup<ManaCD> EquipmentUpdateAspect_manaCDCAc;

			[ReadOnly]
			private ComponentLookup<PetOwnerCD> EquipmentUpdateAspect_petOwnerCDCAc;

			private ComponentLookup<PlacementCD> EquipmentUpdateAspect_placementCDCAc;

			private BufferLookup<PlacementSizeByEquipmentTypeBuffer> EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc;

			private ComponentLookup<PlayerAimPositionCD> EquipmentUpdateAspect_playerAimPositionCDCAc;

			private ComponentLookup<PlayerAttackCooldownCD> EquipmentUpdateAspect_playerAttackCooldownCDCAc;

			private ComponentLookup<EquipmentSlotCD> EquipmentUpdateAspect_equipmentSlotCDCAc;

			[ReadOnly]
			private ComponentLookup<EquipmentSlotConstantCD> EquipmentUpdateAspect_equipmentSlotConstantCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerGhost> EquipmentUpdateAspect_playerGhostCAc;

			private ComponentLookup<DigStateCD> EquipmentUpdateAspect_digStateCDCAc;

			private ComponentLookup<FishingMiniGameStateCD> EquipmentUpdateAspect_fishingMiniGameStateCDCAc;

			private ComponentLookup<FishingStateCD> EquipmentUpdateAspect_fishingStateCDCAc;

			private ComponentLookup<FlattenStateCD> EquipmentUpdateAspect_flattenStateCDCAc;

			private ComponentLookup<PlaceObjectPlayerStateCD> EquipmentUpdateAspect_placeObjectStateCDCAc;

			private ComponentLookup<PlaceWaterStateCD> EquipmentUpdateAspect_placeWaterStateCDCAc;

			[ReadOnly]
			private ComponentLookup<PlayerSleepStateCD> EquipmentUpdateAspect_playerSleepStateCDCAc;

			private ComponentLookup<PlayerStateCD> EquipmentUpdateAspect_playerStateCDCAc;

			private ComponentLookup<RefillWaterStateCD> EquipmentUpdateAspect_refillWaterStateCDCAc;

			private ComponentLookup<RandomCD> EquipmentUpdateAspect_randomCDCAc;

			private BufferLookup<SyncedPlayerSharedCooldownTimersCD> EquipmentUpdateAspect_syncedSharedCooldownTimersBAc;

			public EquipmentUpdateAspect this[Entity entity] => new EquipmentUpdateAspect(EquipmentUpdateAspect_animationBufferBAc[entity], EquipmentUpdateAspect_animationBufferPointerCAc.GetRefRW(entity), EquipmentUpdateAspect_animationOrientationCDCAc.GetRefRO(entity), EquipmentUpdateAspect_CharacterTypeCAc.GetRefRO(entity), EquipmentUpdateAspect_clientInputCAc.GetRefRO(entity), EquipmentUpdateAspect_critterDamageFromPlacingCDCAc.GetRefRW(entity), EquipmentUpdateAspect_dealDamageToEntityBufferBAc[entity], EquipmentUpdateAspect_equipmentCDCAc.GetRefRO(entity), EquipmentUpdateAspect_equippedObjectCDCAc.GetRefRO(entity), EquipmentUpdateAspect_ghostEffectEventBufferBAc[entity], EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc.GetRefRW(entity), EquipmentUpdateAspect_hungerCDCAc.GetRefRW(entity), EquipmentUpdateAspect_manaCDCAc.GetRefRO(entity), EquipmentUpdateAspect_petOwnerCDCAc.GetRefRO(entity), EquipmentUpdateAspect_placementCDCAc.GetRefRW(entity), EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc[entity], EquipmentUpdateAspect_playerAimPositionCDCAc.GetRefRW(entity), EquipmentUpdateAspect_playerAttackCooldownCDCAc.GetRefRW(entity), EquipmentUpdateAspect_equipmentSlotCDCAc.GetRefRW(entity), EquipmentUpdateAspect_equipmentSlotConstantCDCAc.GetRefRO(entity), EquipmentUpdateAspect_playerGhostCAc.GetRefRO(entity), EquipmentUpdateAspect_digStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_fishingMiniGameStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_fishingStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_flattenStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_placeObjectStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_placeWaterStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_playerSleepStateCDCAc.GetRefRO(entity), EquipmentUpdateAspect_playerStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_refillWaterStateCDCAc.GetRefRW(entity), EquipmentUpdateAspect_randomCDCAc.GetRefRW(entity), EquipmentUpdateAspect_syncedSharedCooldownTimersBAc[entity], entity);

			public Lookup(ref SystemState state)
			{
				EquipmentUpdateAspect_animationBufferBAc = state.GetBufferLookup<AnimationBuffer>();
				EquipmentUpdateAspect_animationBufferPointerCAc = state.GetComponentLookup<AnimationBufferPointer>();
				EquipmentUpdateAspect_animationOrientationCDCAc = state.GetComponentLookup<AnimationOrientationCD>(isReadOnly: true);
				EquipmentUpdateAspect_CharacterTypeCAc = state.GetComponentLookup<CharacterTypeCD>(isReadOnly: true);
				EquipmentUpdateAspect_clientInputCAc = state.GetComponentLookup<ClientInput>(isReadOnly: true);
				EquipmentUpdateAspect_critterDamageFromPlacingCDCAc = state.GetComponentLookup<CritterDamageFromPlacingCD>();
				EquipmentUpdateAspect_dealDamageToEntityBufferBAc = state.GetBufferLookup<DealDamageToEntityBuffer>();
				EquipmentUpdateAspect_equipmentCDCAc = state.GetComponentLookup<EquipmentCD>(isReadOnly: true);
				EquipmentUpdateAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				EquipmentUpdateAspect_ghostEffectEventBufferBAc = state.GetBufferLookup<GhostEffectEventBuffer>();
				EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
				EquipmentUpdateAspect_hungerCDCAc = state.GetComponentLookup<HungerCD>();
				EquipmentUpdateAspect_manaCDCAc = state.GetComponentLookup<ManaCD>(isReadOnly: true);
				EquipmentUpdateAspect_petOwnerCDCAc = state.GetComponentLookup<PetOwnerCD>(isReadOnly: true);
				EquipmentUpdateAspect_placementCDCAc = state.GetComponentLookup<PlacementCD>();
				EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc = state.GetBufferLookup<PlacementSizeByEquipmentTypeBuffer>();
				EquipmentUpdateAspect_playerAimPositionCDCAc = state.GetComponentLookup<PlayerAimPositionCD>();
				EquipmentUpdateAspect_playerAttackCooldownCDCAc = state.GetComponentLookup<PlayerAttackCooldownCD>();
				EquipmentUpdateAspect_equipmentSlotCDCAc = state.GetComponentLookup<EquipmentSlotCD>();
				EquipmentUpdateAspect_equipmentSlotConstantCDCAc = state.GetComponentLookup<EquipmentSlotConstantCD>(isReadOnly: true);
				EquipmentUpdateAspect_playerGhostCAc = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				EquipmentUpdateAspect_digStateCDCAc = state.GetComponentLookup<DigStateCD>();
				EquipmentUpdateAspect_fishingMiniGameStateCDCAc = state.GetComponentLookup<FishingMiniGameStateCD>();
				EquipmentUpdateAspect_fishingStateCDCAc = state.GetComponentLookup<FishingStateCD>();
				EquipmentUpdateAspect_flattenStateCDCAc = state.GetComponentLookup<FlattenStateCD>();
				EquipmentUpdateAspect_placeObjectStateCDCAc = state.GetComponentLookup<PlaceObjectPlayerStateCD>();
				EquipmentUpdateAspect_placeWaterStateCDCAc = state.GetComponentLookup<PlaceWaterStateCD>();
				EquipmentUpdateAspect_playerSleepStateCDCAc = state.GetComponentLookup<PlayerSleepStateCD>(isReadOnly: true);
				EquipmentUpdateAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>();
				EquipmentUpdateAspect_refillWaterStateCDCAc = state.GetComponentLookup<RefillWaterStateCD>();
				EquipmentUpdateAspect_randomCDCAc = state.GetComponentLookup<RandomCD>();
				EquipmentUpdateAspect_syncedSharedCooldownTimersBAc = state.GetBufferLookup<SyncedPlayerSharedCooldownTimersCD>();
			}

			public void Update(ref SystemState state)
			{
				EquipmentUpdateAspect_animationBufferBAc.Update(ref state);
				EquipmentUpdateAspect_animationBufferPointerCAc.Update(ref state);
				EquipmentUpdateAspect_animationOrientationCDCAc.Update(ref state);
				EquipmentUpdateAspect_CharacterTypeCAc.Update(ref state);
				EquipmentUpdateAspect_clientInputCAc.Update(ref state);
				EquipmentUpdateAspect_critterDamageFromPlacingCDCAc.Update(ref state);
				EquipmentUpdateAspect_dealDamageToEntityBufferBAc.Update(ref state);
				EquipmentUpdateAspect_equipmentCDCAc.Update(ref state);
				EquipmentUpdateAspect_equippedObjectCDCAc.Update(ref state);
				EquipmentUpdateAspect_ghostEffectEventBufferBAc.Update(ref state);
				EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				EquipmentUpdateAspect_hungerCDCAc.Update(ref state);
				EquipmentUpdateAspect_manaCDCAc.Update(ref state);
				EquipmentUpdateAspect_petOwnerCDCAc.Update(ref state);
				EquipmentUpdateAspect_placementCDCAc.Update(ref state);
				EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc.Update(ref state);
				EquipmentUpdateAspect_playerAimPositionCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerAttackCooldownCDCAc.Update(ref state);
				EquipmentUpdateAspect_equipmentSlotCDCAc.Update(ref state);
				EquipmentUpdateAspect_equipmentSlotConstantCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerGhostCAc.Update(ref state);
				EquipmentUpdateAspect_digStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_fishingStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_flattenStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_placeObjectStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_placeWaterStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerSleepStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_refillWaterStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_randomCDCAc.Update(ref state);
				EquipmentUpdateAspect_syncedSharedCooldownTimersBAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public BufferAccessor<AnimationBuffer> EquipmentUpdateAspect_animationBufferBa;

			public NativeArray<AnimationBufferPointer> EquipmentUpdateAspect_animationBufferPointerNaC;

			public NativeArray<AnimationOrientationCD> EquipmentUpdateAspect_animationOrientationCDNaC;

			public NativeArray<CharacterTypeCD> EquipmentUpdateAspect_CharacterTypeNaC;

			public NativeArray<ClientInput> EquipmentUpdateAspect_clientInputNaC;

			public NativeArray<CritterDamageFromPlacingCD> EquipmentUpdateAspect_critterDamageFromPlacingCDNaC;

			public BufferAccessor<DealDamageToEntityBuffer> EquipmentUpdateAspect_dealDamageToEntityBufferBa;

			public NativeArray<EquipmentCD> EquipmentUpdateAspect_equipmentCDNaC;

			public NativeArray<EquippedObjectCD> EquipmentUpdateAspect_equippedObjectCDNaC;

			public BufferAccessor<GhostEffectEventBuffer> EquipmentUpdateAspect_ghostEffectEventBufferBa;

			public NativeArray<GhostEffectEventBufferPointerCD> EquipmentUpdateAspect_ghostEffectEventBufferPointerCDNaC;

			public NativeArray<HungerCD> EquipmentUpdateAspect_hungerCDNaC;

			public NativeArray<ManaCD> EquipmentUpdateAspect_manaCDNaC;

			public NativeArray<PetOwnerCD> EquipmentUpdateAspect_petOwnerCDNaC;

			public NativeArray<PlacementCD> EquipmentUpdateAspect_placementCDNaC;

			public BufferAccessor<PlacementSizeByEquipmentTypeBuffer> EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBa;

			public NativeArray<PlayerAimPositionCD> EquipmentUpdateAspect_playerAimPositionCDNaC;

			public NativeArray<PlayerAttackCooldownCD> EquipmentUpdateAspect_playerAttackCooldownCDNaC;

			public NativeArray<EquipmentSlotCD> EquipmentUpdateAspect_equipmentSlotCDNaC;

			public NativeArray<EquipmentSlotConstantCD> EquipmentUpdateAspect_equipmentSlotConstantCDNaC;

			public NativeArray<PlayerGhost> EquipmentUpdateAspect_playerGhostNaC;

			public NativeArray<DigStateCD> EquipmentUpdateAspect_digStateCDNaC;

			public NativeArray<FishingMiniGameStateCD> EquipmentUpdateAspect_fishingMiniGameStateCDNaC;

			public NativeArray<FishingStateCD> EquipmentUpdateAspect_fishingStateCDNaC;

			public NativeArray<FlattenStateCD> EquipmentUpdateAspect_flattenStateCDNaC;

			public NativeArray<PlaceObjectPlayerStateCD> EquipmentUpdateAspect_placeObjectStateCDNaC;

			public NativeArray<PlaceWaterStateCD> EquipmentUpdateAspect_placeWaterStateCDNaC;

			public NativeArray<PlayerSleepStateCD> EquipmentUpdateAspect_playerSleepStateCDNaC;

			public NativeArray<PlayerStateCD> EquipmentUpdateAspect_playerStateCDNaC;

			public NativeArray<RefillWaterStateCD> EquipmentUpdateAspect_refillWaterStateCDNaC;

			public NativeArray<RandomCD> EquipmentUpdateAspect_randomCDNaC;

			public BufferAccessor<SyncedPlayerSharedCooldownTimersCD> EquipmentUpdateAspect_syncedSharedCooldownTimersBa;

			public NativeArray<Entity> EquipmentUpdateAspect_entityNaE;

			public int Length;

			public EquipmentUpdateAspect this[int index] => new EquipmentUpdateAspect(EquipmentUpdateAspect_animationBufferBa[index], new RefRW<AnimationBufferPointer>(EquipmentUpdateAspect_animationBufferPointerNaC, index), new RefRO<AnimationOrientationCD>(EquipmentUpdateAspect_animationOrientationCDNaC, index), new RefRO<CharacterTypeCD>(EquipmentUpdateAspect_CharacterTypeNaC, index), new RefRO<ClientInput>(EquipmentUpdateAspect_clientInputNaC, index), new RefRW<CritterDamageFromPlacingCD>(EquipmentUpdateAspect_critterDamageFromPlacingCDNaC, index), EquipmentUpdateAspect_dealDamageToEntityBufferBa[index], new RefRO<EquipmentCD>(EquipmentUpdateAspect_equipmentCDNaC, index), new RefRO<EquippedObjectCD>(EquipmentUpdateAspect_equippedObjectCDNaC, index), EquipmentUpdateAspect_ghostEffectEventBufferBa[index], new RefRW<GhostEffectEventBufferPointerCD>(EquipmentUpdateAspect_ghostEffectEventBufferPointerCDNaC, index), new RefRW<HungerCD>(EquipmentUpdateAspect_hungerCDNaC, index), new RefRO<ManaCD>(EquipmentUpdateAspect_manaCDNaC, index), new RefRO<PetOwnerCD>(EquipmentUpdateAspect_petOwnerCDNaC, index), new RefRW<PlacementCD>(EquipmentUpdateAspect_placementCDNaC, index), EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBa[index], new RefRW<PlayerAimPositionCD>(EquipmentUpdateAspect_playerAimPositionCDNaC, index), new RefRW<PlayerAttackCooldownCD>(EquipmentUpdateAspect_playerAttackCooldownCDNaC, index), new RefRW<EquipmentSlotCD>(EquipmentUpdateAspect_equipmentSlotCDNaC, index), new RefRO<EquipmentSlotConstantCD>(EquipmentUpdateAspect_equipmentSlotConstantCDNaC, index), new RefRO<PlayerGhost>(EquipmentUpdateAspect_playerGhostNaC, index), new RefRW<DigStateCD>(EquipmentUpdateAspect_digStateCDNaC, index), new RefRW<FishingMiniGameStateCD>(EquipmentUpdateAspect_fishingMiniGameStateCDNaC, index), new RefRW<FishingStateCD>(EquipmentUpdateAspect_fishingStateCDNaC, index), new RefRW<FlattenStateCD>(EquipmentUpdateAspect_flattenStateCDNaC, index), new RefRW<PlaceObjectPlayerStateCD>(EquipmentUpdateAspect_placeObjectStateCDNaC, index), new RefRW<PlaceWaterStateCD>(EquipmentUpdateAspect_placeWaterStateCDNaC, index), new RefRO<PlayerSleepStateCD>(EquipmentUpdateAspect_playerSleepStateCDNaC, index), new RefRW<PlayerStateCD>(EquipmentUpdateAspect_playerStateCDNaC, index), new RefRW<RefillWaterStateCD>(EquipmentUpdateAspect_refillWaterStateCDNaC, index), new RefRW<RandomCD>(EquipmentUpdateAspect_randomCDNaC, index), EquipmentUpdateAspect_syncedSharedCooldownTimersBa[index], EquipmentUpdateAspect_entityNaE[index]);
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<AnimationBuffer> EquipmentUpdateAspect_animationBufferBAc;

			private ComponentTypeHandle<AnimationBufferPointer> EquipmentUpdateAspect_animationBufferPointerCAc;

			[ReadOnly]
			private ComponentTypeHandle<AnimationOrientationCD> EquipmentUpdateAspect_animationOrientationCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<CharacterTypeCD> EquipmentUpdateAspect_CharacterTypeCAc;

			[ReadOnly]
			private ComponentTypeHandle<ClientInput> EquipmentUpdateAspect_clientInputCAc;

			private ComponentTypeHandle<CritterDamageFromPlacingCD> EquipmentUpdateAspect_critterDamageFromPlacingCDCAc;

			private BufferTypeHandle<DealDamageToEntityBuffer> EquipmentUpdateAspect_dealDamageToEntityBufferBAc;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentCD> EquipmentUpdateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> EquipmentUpdateAspect_equippedObjectCDCAc;

			private BufferTypeHandle<GhostEffectEventBuffer> EquipmentUpdateAspect_ghostEffectEventBufferBAc;

			private ComponentTypeHandle<GhostEffectEventBufferPointerCD> EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentTypeHandle<HungerCD> EquipmentUpdateAspect_hungerCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<ManaCD> EquipmentUpdateAspect_manaCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PetOwnerCD> EquipmentUpdateAspect_petOwnerCDCAc;

			private ComponentTypeHandle<PlacementCD> EquipmentUpdateAspect_placementCDCAc;

			private BufferTypeHandle<PlacementSizeByEquipmentTypeBuffer> EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc;

			private ComponentTypeHandle<PlayerAimPositionCD> EquipmentUpdateAspect_playerAimPositionCDCAc;

			private ComponentTypeHandle<PlayerAttackCooldownCD> EquipmentUpdateAspect_playerAttackCooldownCDCAc;

			private ComponentTypeHandle<EquipmentSlotCD> EquipmentUpdateAspect_equipmentSlotCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotConstantCD> EquipmentUpdateAspect_equipmentSlotConstantCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerGhost> EquipmentUpdateAspect_playerGhostCAc;

			private ComponentTypeHandle<DigStateCD> EquipmentUpdateAspect_digStateCDCAc;

			private ComponentTypeHandle<FishingMiniGameStateCD> EquipmentUpdateAspect_fishingMiniGameStateCDCAc;

			private ComponentTypeHandle<FishingStateCD> EquipmentUpdateAspect_fishingStateCDCAc;

			private ComponentTypeHandle<FlattenStateCD> EquipmentUpdateAspect_flattenStateCDCAc;

			private ComponentTypeHandle<PlaceObjectPlayerStateCD> EquipmentUpdateAspect_placeObjectStateCDCAc;

			private ComponentTypeHandle<PlaceWaterStateCD> EquipmentUpdateAspect_placeWaterStateCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<PlayerSleepStateCD> EquipmentUpdateAspect_playerSleepStateCDCAc;

			private ComponentTypeHandle<PlayerStateCD> EquipmentUpdateAspect_playerStateCDCAc;

			private ComponentTypeHandle<RefillWaterStateCD> EquipmentUpdateAspect_refillWaterStateCDCAc;

			private ComponentTypeHandle<RandomCD> EquipmentUpdateAspect_randomCDCAc;

			private BufferTypeHandle<SyncedPlayerSharedCooldownTimersCD> EquipmentUpdateAspect_syncedSharedCooldownTimersBAc;

			private EntityTypeHandle EquipmentUpdateAspect_entityEAc;

			public TypeHandle(ref SystemState state)
			{
				EquipmentUpdateAspect_animationBufferBAc = state.GetBufferTypeHandle<AnimationBuffer>();
				EquipmentUpdateAspect_animationBufferPointerCAc = state.GetComponentTypeHandle<AnimationBufferPointer>();
				EquipmentUpdateAspect_animationOrientationCDCAc = state.GetComponentTypeHandle<AnimationOrientationCD>(isReadOnly: true);
				EquipmentUpdateAspect_CharacterTypeCAc = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
				EquipmentUpdateAspect_clientInputCAc = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
				EquipmentUpdateAspect_critterDamageFromPlacingCDCAc = state.GetComponentTypeHandle<CritterDamageFromPlacingCD>();
				EquipmentUpdateAspect_dealDamageToEntityBufferBAc = state.GetBufferTypeHandle<DealDamageToEntityBuffer>();
				EquipmentUpdateAspect_equipmentCDCAc = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
				EquipmentUpdateAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				EquipmentUpdateAspect_ghostEffectEventBufferBAc = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
				EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
				EquipmentUpdateAspect_hungerCDCAc = state.GetComponentTypeHandle<HungerCD>();
				EquipmentUpdateAspect_manaCDCAc = state.GetComponentTypeHandle<ManaCD>(isReadOnly: true);
				EquipmentUpdateAspect_petOwnerCDCAc = state.GetComponentTypeHandle<PetOwnerCD>(isReadOnly: true);
				EquipmentUpdateAspect_placementCDCAc = state.GetComponentTypeHandle<PlacementCD>();
				EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc = state.GetBufferTypeHandle<PlacementSizeByEquipmentTypeBuffer>();
				EquipmentUpdateAspect_playerAimPositionCDCAc = state.GetComponentTypeHandle<PlayerAimPositionCD>();
				EquipmentUpdateAspect_playerAttackCooldownCDCAc = state.GetComponentTypeHandle<PlayerAttackCooldownCD>();
				EquipmentUpdateAspect_equipmentSlotCDCAc = state.GetComponentTypeHandle<EquipmentSlotCD>();
				EquipmentUpdateAspect_equipmentSlotConstantCDCAc = state.GetComponentTypeHandle<EquipmentSlotConstantCD>(isReadOnly: true);
				EquipmentUpdateAspect_playerGhostCAc = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
				EquipmentUpdateAspect_digStateCDCAc = state.GetComponentTypeHandle<DigStateCD>();
				EquipmentUpdateAspect_fishingMiniGameStateCDCAc = state.GetComponentTypeHandle<FishingMiniGameStateCD>();
				EquipmentUpdateAspect_fishingStateCDCAc = state.GetComponentTypeHandle<FishingStateCD>();
				EquipmentUpdateAspect_flattenStateCDCAc = state.GetComponentTypeHandle<FlattenStateCD>();
				EquipmentUpdateAspect_placeObjectStateCDCAc = state.GetComponentTypeHandle<PlaceObjectPlayerStateCD>();
				EquipmentUpdateAspect_placeWaterStateCDCAc = state.GetComponentTypeHandle<PlaceWaterStateCD>();
				EquipmentUpdateAspect_playerSleepStateCDCAc = state.GetComponentTypeHandle<PlayerSleepStateCD>(isReadOnly: true);
				EquipmentUpdateAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>();
				EquipmentUpdateAspect_refillWaterStateCDCAc = state.GetComponentTypeHandle<RefillWaterStateCD>();
				EquipmentUpdateAspect_randomCDCAc = state.GetComponentTypeHandle<RandomCD>();
				EquipmentUpdateAspect_syncedSharedCooldownTimersBAc = state.GetBufferTypeHandle<SyncedPlayerSharedCooldownTimersCD>();
				EquipmentUpdateAspect_entityEAc = state.GetEntityTypeHandle();
			}

			public void Update(ref SystemState state)
			{
				EquipmentUpdateAspect_animationBufferBAc.Update(ref state);
				EquipmentUpdateAspect_animationBufferPointerCAc.Update(ref state);
				EquipmentUpdateAspect_animationOrientationCDCAc.Update(ref state);
				EquipmentUpdateAspect_CharacterTypeCAc.Update(ref state);
				EquipmentUpdateAspect_clientInputCAc.Update(ref state);
				EquipmentUpdateAspect_critterDamageFromPlacingCDCAc.Update(ref state);
				EquipmentUpdateAspect_dealDamageToEntityBufferBAc.Update(ref state);
				EquipmentUpdateAspect_equipmentCDCAc.Update(ref state);
				EquipmentUpdateAspect_equippedObjectCDCAc.Update(ref state);
				EquipmentUpdateAspect_ghostEffectEventBufferBAc.Update(ref state);
				EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				EquipmentUpdateAspect_hungerCDCAc.Update(ref state);
				EquipmentUpdateAspect_manaCDCAc.Update(ref state);
				EquipmentUpdateAspect_petOwnerCDCAc.Update(ref state);
				EquipmentUpdateAspect_placementCDCAc.Update(ref state);
				EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc.Update(ref state);
				EquipmentUpdateAspect_playerAimPositionCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerAttackCooldownCDCAc.Update(ref state);
				EquipmentUpdateAspect_equipmentSlotCDCAc.Update(ref state);
				EquipmentUpdateAspect_equipmentSlotConstantCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerGhostCAc.Update(ref state);
				EquipmentUpdateAspect_digStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_fishingMiniGameStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_fishingStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_flattenStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_placeObjectStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_placeWaterStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerSleepStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_playerStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_refillWaterStateCDCAc.Update(ref state);
				EquipmentUpdateAspect_randomCDCAc.Update(ref state);
				EquipmentUpdateAspect_syncedSharedCooldownTimersBAc.Update(ref state);
				EquipmentUpdateAspect_entityEAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.EquipmentUpdateAspect_animationBufferBa = chunk.GetBufferAccessor(ref EquipmentUpdateAspect_animationBufferBAc);
				result.EquipmentUpdateAspect_animationBufferPointerNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_animationBufferPointerCAc);
				result.EquipmentUpdateAspect_animationOrientationCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_animationOrientationCDCAc);
				result.EquipmentUpdateAspect_CharacterTypeNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_CharacterTypeCAc);
				result.EquipmentUpdateAspect_clientInputNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_clientInputCAc);
				result.EquipmentUpdateAspect_critterDamageFromPlacingCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_critterDamageFromPlacingCDCAc);
				result.EquipmentUpdateAspect_dealDamageToEntityBufferBa = chunk.GetBufferAccessor(ref EquipmentUpdateAspect_dealDamageToEntityBufferBAc);
				result.EquipmentUpdateAspect_equipmentCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_equipmentCDCAc);
				result.EquipmentUpdateAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_equippedObjectCDCAc);
				result.EquipmentUpdateAspect_ghostEffectEventBufferBa = chunk.GetBufferAccessor(ref EquipmentUpdateAspect_ghostEffectEventBufferBAc);
				result.EquipmentUpdateAspect_ghostEffectEventBufferPointerCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_ghostEffectEventBufferPointerCDCAc);
				result.EquipmentUpdateAspect_hungerCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_hungerCDCAc);
				result.EquipmentUpdateAspect_manaCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_manaCDCAc);
				result.EquipmentUpdateAspect_petOwnerCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_petOwnerCDCAc);
				result.EquipmentUpdateAspect_placementCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_placementCDCAc);
				result.EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBa = chunk.GetBufferAccessor(ref EquipmentUpdateAspect_placementSizeByEquipmentTypeBufferBAc);
				result.EquipmentUpdateAspect_playerAimPositionCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_playerAimPositionCDCAc);
				result.EquipmentUpdateAspect_playerAttackCooldownCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_playerAttackCooldownCDCAc);
				result.EquipmentUpdateAspect_equipmentSlotCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_equipmentSlotCDCAc);
				result.EquipmentUpdateAspect_equipmentSlotConstantCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_equipmentSlotConstantCDCAc);
				result.EquipmentUpdateAspect_playerGhostNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_playerGhostCAc);
				result.EquipmentUpdateAspect_digStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_digStateCDCAc);
				result.EquipmentUpdateAspect_fishingMiniGameStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_fishingMiniGameStateCDCAc);
				result.EquipmentUpdateAspect_fishingStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_fishingStateCDCAc);
				result.EquipmentUpdateAspect_flattenStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_flattenStateCDCAc);
				result.EquipmentUpdateAspect_placeObjectStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_placeObjectStateCDCAc);
				result.EquipmentUpdateAspect_placeWaterStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_placeWaterStateCDCAc);
				result.EquipmentUpdateAspect_playerSleepStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_playerSleepStateCDCAc);
				result.EquipmentUpdateAspect_playerStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_playerStateCDCAc);
				result.EquipmentUpdateAspect_refillWaterStateCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_refillWaterStateCDCAc);
				result.EquipmentUpdateAspect_randomCDNaC = chunk.GetNativeArray(ref EquipmentUpdateAspect_randomCDCAc);
				result.EquipmentUpdateAspect_syncedSharedCooldownTimersBa = chunk.GetBufferAccessor(ref EquipmentUpdateAspect_syncedSharedCooldownTimersBAc);
				result.EquipmentUpdateAspect_entityNaE = chunk.GetNativeArray(EquipmentUpdateAspect_entityEAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<EquipmentUpdateAspect>, IEnumerator, IDisposable, IEnumerable<EquipmentUpdateAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public EquipmentUpdateAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

			IEnumerator<EquipmentUpdateAspect> IEnumerable<EquipmentUpdateAspect>.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public readonly Entity entity;

		public readonly RefRO<EquipmentCD> equipmentCD;

		public readonly RefRW<EquipmentSlotCD> equipmentSlotCD;

		public readonly RefRO<EquipmentSlotConstantCD> equipmentSlotConstantCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly RefRW<PlayerAttackCooldownCD> playerAttackCooldownCD;

		public readonly RefRO<PlayerGhost> playerGhost;

		public readonly RefRW<PlayerStateCD> playerStateCD;

		public readonly RefRO<CharacterTypeCD> CharacterType;

		public readonly RefRO<ManaCD> manaCD;

		public readonly DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> syncedSharedCooldownTimers;

		public readonly RefRW<FishingStateCD> fishingStateCD;

		public readonly DynamicBuffer<AnimationBuffer> animationBuffer;

		public readonly RefRW<AnimationBufferPointer> animationBufferPointer;

		public readonly RefRW<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerCD;

		public readonly RefRW<PlayerAimPositionCD> playerAimPositionCD;

		public readonly DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer;

		public readonly RefRO<ClientInput> clientInput;

		public readonly RefRO<PetOwnerCD> petOwnerCD;

		public readonly RefRW<PlacementCD> placementCD;

		public readonly RefRW<CritterDamageFromPlacingCD> critterDamageFromPlacingCD;

		public readonly RefRO<AnimationOrientationCD> animationOrientationCD;

		public readonly RefRW<RefillWaterStateCD> refillWaterStateCD;

		public readonly RefRW<PlaceWaterStateCD> placeWaterStateCD;

		public readonly RefRW<DigStateCD> digStateCD;

		public readonly RefRW<FlattenStateCD> flattenStateCD;

		public readonly RefRW<RandomCD> randomCD;

		public readonly RefRW<PlaceObjectPlayerStateCD> placeObjectStateCD;

		public readonly RefRW<HungerCD> hungerCD;

		public readonly DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer;

		public readonly RefRW<FishingMiniGameStateCD> fishingMiniGameStateCD;

		public readonly RefRO<PlayerSleepStateCD> playerSleepStateCD;

		public readonly DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> placementSizeByEquipmentTypeBuffer;

		public EquipmentUpdateAspect(DynamicBuffer<AnimationBuffer> equipmentupdateaspect_animationbufferDb, RefRW<AnimationBufferPointer> equipmentupdateaspect_animationbufferpointerRef, RefRO<AnimationOrientationCD> equipmentupdateaspect_animationorientationcdRef, RefRO<CharacterTypeCD> equipmentupdateaspect_charactertypeRef, RefRO<ClientInput> equipmentupdateaspect_clientinputRef, RefRW<CritterDamageFromPlacingCD> equipmentupdateaspect_critterdamagefromplacingcdRef, DynamicBuffer<DealDamageToEntityBuffer> equipmentupdateaspect_dealdamagetoentitybufferDb, RefRO<EquipmentCD> equipmentupdateaspect_equipmentcdRef, RefRO<EquippedObjectCD> equipmentupdateaspect_equippedobjectcdRef, DynamicBuffer<GhostEffectEventBuffer> equipmentupdateaspect_ghosteffecteventbufferDb, RefRW<GhostEffectEventBufferPointerCD> equipmentupdateaspect_ghosteffecteventbufferpointercdRef, RefRW<HungerCD> equipmentupdateaspect_hungercdRef, RefRO<ManaCD> equipmentupdateaspect_manacdRef, RefRO<PetOwnerCD> equipmentupdateaspect_petownercdRef, RefRW<PlacementCD> equipmentupdateaspect_placementcdRef, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> equipmentupdateaspect_placementsizebyequipmenttypebufferDb, RefRW<PlayerAimPositionCD> equipmentupdateaspect_playeraimpositioncdRef, RefRW<PlayerAttackCooldownCD> equipmentupdateaspect_playerattackcooldowncdRef, RefRW<EquipmentSlotCD> equipmentupdateaspect_equipmentslotcdRef, RefRO<EquipmentSlotConstantCD> equipmentupdateaspect_equipmentslotconstantcdRef, RefRO<PlayerGhost> equipmentupdateaspect_playerghostRef, RefRW<DigStateCD> equipmentupdateaspect_digstatecdRef, RefRW<FishingMiniGameStateCD> equipmentupdateaspect_fishingminigamestatecdRef, RefRW<FishingStateCD> equipmentupdateaspect_fishingstatecdRef, RefRW<FlattenStateCD> equipmentupdateaspect_flattenstatecdRef, RefRW<PlaceObjectPlayerStateCD> equipmentupdateaspect_placeobjectstatecdRef, RefRW<PlaceWaterStateCD> equipmentupdateaspect_placewaterstatecdRef, RefRO<PlayerSleepStateCD> equipmentupdateaspect_playersleepstatecdRef, RefRW<PlayerStateCD> equipmentupdateaspect_playerstatecdRef, RefRW<RefillWaterStateCD> equipmentupdateaspect_refillwaterstatecdRef, RefRW<RandomCD> equipmentupdateaspect_randomcdRef, DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> equipmentupdateaspect_syncedsharedcooldowntimersDb, Entity equipmentupdateaspect_entityE)
		{
			animationBuffer = equipmentupdateaspect_animationbufferDb;
			animationBufferPointer = equipmentupdateaspect_animationbufferpointerRef;
			animationOrientationCD = equipmentupdateaspect_animationorientationcdRef;
			CharacterType = equipmentupdateaspect_charactertypeRef;
			clientInput = equipmentupdateaspect_clientinputRef;
			critterDamageFromPlacingCD = equipmentupdateaspect_critterdamagefromplacingcdRef;
			dealDamageToEntityBuffer = equipmentupdateaspect_dealdamagetoentitybufferDb;
			equipmentCD = equipmentupdateaspect_equipmentcdRef;
			equippedObjectCD = equipmentupdateaspect_equippedobjectcdRef;
			ghostEffectEventBuffer = equipmentupdateaspect_ghosteffecteventbufferDb;
			ghostEffectEventBufferPointerCD = equipmentupdateaspect_ghosteffecteventbufferpointercdRef;
			hungerCD = equipmentupdateaspect_hungercdRef;
			manaCD = equipmentupdateaspect_manacdRef;
			petOwnerCD = equipmentupdateaspect_petownercdRef;
			placementCD = equipmentupdateaspect_placementcdRef;
			placementSizeByEquipmentTypeBuffer = equipmentupdateaspect_placementsizebyequipmenttypebufferDb;
			playerAimPositionCD = equipmentupdateaspect_playeraimpositioncdRef;
			playerAttackCooldownCD = equipmentupdateaspect_playerattackcooldowncdRef;
			equipmentSlotCD = equipmentupdateaspect_equipmentslotcdRef;
			equipmentSlotConstantCD = equipmentupdateaspect_equipmentslotconstantcdRef;
			playerGhost = equipmentupdateaspect_playerghostRef;
			digStateCD = equipmentupdateaspect_digstatecdRef;
			fishingMiniGameStateCD = equipmentupdateaspect_fishingminigamestatecdRef;
			fishingStateCD = equipmentupdateaspect_fishingstatecdRef;
			flattenStateCD = equipmentupdateaspect_flattenstatecdRef;
			placeObjectStateCD = equipmentupdateaspect_placeobjectstatecdRef;
			placeWaterStateCD = equipmentupdateaspect_placewaterstatecdRef;
			playerSleepStateCD = equipmentupdateaspect_playersleepstatecdRef;
			playerStateCD = equipmentupdateaspect_playerstatecdRef;
			refillWaterStateCD = equipmentupdateaspect_refillwaterstatecdRef;
			randomCD = equipmentupdateaspect_randomcdRef;
			syncedSharedCooldownTimers = equipmentupdateaspect_syncedsharedcooldowntimersDb;
			entity = equipmentupdateaspect_entityE;
		}

		public EquipmentUpdateAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadWrite<AnimationBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<AnimationBufferPointer>());
			unsafeList.Add(ComponentType.ReadOnly<AnimationOrientationCD>());
			unsafeList.Add(ComponentType.ReadOnly<CharacterTypeCD>());
			unsafeList.Add(ComponentType.ReadOnly<ClientInput>());
			unsafeList.Add(ComponentType.ReadWrite<CritterDamageFromPlacingCD>());
			unsafeList.Add(ComponentType.ReadWrite<DealDamageToEntityBuffer>());
			unsafeList.Add(ComponentType.ReadOnly<EquipmentCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>());
			unsafeList.Add(ComponentType.ReadWrite<HungerCD>());
			unsafeList.Add(ComponentType.ReadOnly<ManaCD>());
			unsafeList.Add(ComponentType.ReadOnly<PetOwnerCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlacementCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlacementSizeByEquipmentTypeBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAimPositionCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAttackCooldownCD>());
			unsafeList.Add(ComponentType.ReadWrite<EquipmentSlotCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquipmentSlotConstantCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerGhost>());
			unsafeList.Add(ComponentType.ReadWrite<DigStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<FishingMiniGameStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<FishingStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<FlattenStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlaceObjectPlayerStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlaceWaterStateCD>());
			unsafeList.Add(ComponentType.ReadOnly<PlayerSleepStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<RefillWaterStateCD>());
			unsafeList.Add(ComponentType.ReadWrite<RandomCD>());
			unsafeList.Add(ComponentType.ReadWrite<SyncedPlayerSharedCooldownTimersCD>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 32;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadWrite<AnimationBuffer>();
			componentTypes[1] = ComponentType.ReadWrite<AnimationBufferPointer>();
			componentTypes[2] = ComponentType.ReadOnly<AnimationOrientationCD>();
			componentTypes[3] = ComponentType.ReadOnly<CharacterTypeCD>();
			componentTypes[4] = ComponentType.ReadOnly<ClientInput>();
			componentTypes[5] = ComponentType.ReadWrite<CritterDamageFromPlacingCD>();
			componentTypes[6] = ComponentType.ReadWrite<DealDamageToEntityBuffer>();
			componentTypes[7] = ComponentType.ReadOnly<EquipmentCD>();
			componentTypes[8] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[9] = ComponentType.ReadWrite<GhostEffectEventBuffer>();
			componentTypes[10] = ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>();
			componentTypes[11] = ComponentType.ReadWrite<HungerCD>();
			componentTypes[12] = ComponentType.ReadOnly<ManaCD>();
			componentTypes[13] = ComponentType.ReadOnly<PetOwnerCD>();
			componentTypes[14] = ComponentType.ReadWrite<PlacementCD>();
			componentTypes[15] = ComponentType.ReadWrite<PlacementSizeByEquipmentTypeBuffer>();
			componentTypes[16] = ComponentType.ReadWrite<PlayerAimPositionCD>();
			componentTypes[17] = ComponentType.ReadWrite<PlayerAttackCooldownCD>();
			componentTypes[18] = ComponentType.ReadWrite<EquipmentSlotCD>();
			componentTypes[19] = ComponentType.ReadOnly<EquipmentSlotConstantCD>();
			componentTypes[20] = ComponentType.ReadOnly<PlayerGhost>();
			componentTypes[21] = ComponentType.ReadWrite<DigStateCD>();
			componentTypes[22] = ComponentType.ReadWrite<FishingMiniGameStateCD>();
			componentTypes[23] = ComponentType.ReadWrite<FishingStateCD>();
			componentTypes[24] = ComponentType.ReadWrite<FlattenStateCD>();
			componentTypes[25] = ComponentType.ReadWrite<PlaceObjectPlayerStateCD>();
			componentTypes[26] = ComponentType.ReadWrite<PlaceWaterStateCD>();
			componentTypes[27] = ComponentType.ReadOnly<PlayerSleepStateCD>();
			componentTypes[28] = ComponentType.ReadWrite<PlayerStateCD>();
			componentTypes[29] = ComponentType.ReadWrite<RefillWaterStateCD>();
			componentTypes[30] = ComponentType.ReadWrite<RandomCD>();
			componentTypes[31] = ComponentType.ReadWrite<SyncedPlayerSharedCooldownTimersCD>();
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
			state.EntityManager.CompleteDependencyBeforeRO<CritterDamageFromPlacingCD>();
			state.EntityManager.CompleteDependencyBeforeRO<DealDamageToEntityBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<HungerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ManaCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PetOwnerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementSizeByEquipmentTypeBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAimPositionCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAttackCooldownCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotConstantCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRO<DigStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingMiniGameStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<FlattenStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlaceObjectPlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlaceWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<RefillWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<RandomCD>();
			state.EntityManager.CompleteDependencyBeforeRO<SyncedPlayerSharedCooldownTimersCD>();
		}

		public void CompleteDependencyBeforeRW(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRO<AnimationOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<CharacterTypeCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
			state.EntityManager.CompleteDependencyBeforeRW<CritterDamageFromPlacingCD>();
			state.EntityManager.CompleteDependencyBeforeRW<DealDamageToEntityBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRW<HungerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ManaCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PetOwnerCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlacementCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlacementSizeByEquipmentTypeBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAimPositionCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAttackCooldownCD>();
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotConstantCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
			state.EntityManager.CompleteDependencyBeforeRW<DigStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<FishingMiniGameStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<FishingStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<FlattenStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlaceObjectPlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlaceWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerSleepStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<RefillWaterStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<RandomCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SyncedPlayerSharedCooldownTimersCD>();
		}
	}
}
