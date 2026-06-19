using CommandMinion;
using Inventory;
using Pug.Automation;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace PlayerEquipment
{
	public struct LookupEquipmentUpdateData
	{
		[ReadOnly]
		public ComponentLookup<SecondaryUseCD> secondaryUseLookup;

		[ReadOnly]
		public ComponentLookup<CooldownCD> cooldownLookup;

		[ReadOnly]
		public ComponentLookup<WarmupCD> warmupLookup;

		[ReadOnly]
		public ComponentLookup<ConsumesManaCD> consumeManaLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesLookup;

		[ReadOnly]
		public ComponentLookup<ParchmentRecipeCD> parchementRecipeLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		public ComponentLookup<AttackWithEquipmentTag> attackWithEquipmentLookup;

		public BufferLookup<InventoryChangeBuffer> inventoryUpdateBuffer;

		[ReadOnly]
		public ComponentLookup<CattleCD> cattleLookup;

		[ReadOnly]
		public ComponentLookup<PetCandyCD> petCandyLookup;

		[ReadOnly]
		public ComponentLookup<PotionCD> potionLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		public ComponentLookup<PlayAnimationStateCD> playAnimationStateLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		public ComponentLookup<WaitingForEatableSlotConsumeResultCD> waitingForEatableSlotConsumeResultLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		[ReadOnly]
		public BufferLookup<AdaptiveEntityBuffer> adaptiveEntityBufferLookup;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public ComponentLookup<ResizableTileSizeCD> sizeVariationLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> indestructibleLookup;

		public ComponentLookup<PlantCD> plantLookup;

		[ReadOnly]
		public ComponentLookup<CritterCD> critterLookup;

		[ReadOnly]
		public ComponentLookup<FireflyCD> fireflyLookup;

		[ReadOnly]
		public ComponentLookup<RequiresDrillCD> requiresDrillLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> surfacePriorityLookup;

		[ReadOnly]
		public ComponentLookup<ElectricityCD> electricityLookup;

		[ReadOnly]
		public ComponentLookup<EventTerminalCD> eventTerminalLookup;

		[ReadOnly]
		public ComponentLookup<WaterSourceCD> waterSourceLookup;

		[ReadOnly]
		public ComponentLookup<PaintToolCD> paintToolLookup;

		public ComponentLookup<PaintableObjectCD> paintableObjectLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> growingLookup;

		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> reduceDurabilityOfEquippedTagLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup;

		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public ComponentLookup<DontDropSelfCD> dontDropSelfLookup;

		public ComponentLookup<DontDropLootCD> dontDropLootLookup;

		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<DestructibleObjectCD> destructibleLookup;

		[ReadOnly]
		public ComponentLookup<CanBeRemovedByWaterCD> canBeRemovedByWaterLookup;

		[ReadOnly]
		public ComponentLookup<GroundDecorationCD> groundDecorationLookup;

		[ReadOnly]
		public ComponentLookup<DiggableCD> diggableLookup;

		[ReadOnly]
		public ComponentLookup<PseudoTileCD> pseudoTileLookup;

		[ReadOnly]
		public ComponentLookup<DontBlockDiggingCD> dontBlockDiggingLookup;

		[ReadOnly]
		public ComponentLookup<FullnessCD> fullnessLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> inventoryBufferLookup;

		[ReadOnly]
		public ComponentLookup<AnvilCD> anvilLookup;

		[ReadOnly]
		public ComponentLookup<WayPointCD> waypointLookup;

		[ReadOnly]
		public ComponentLookup<CraftingCD> craftingLookup;

		[ReadOnly]
		public ComponentLookup<ProximityTriggerCD> proximityTriggerLookup;

		[ReadOnly]
		public ComponentLookup<CommandMinionWeaponCD> commandMinionLookup;

		[ReadOnly]
		public ComponentLookup<RootPlantCD> rootPlantLookup;

		public ComponentLookup<TriggerSelectEnemyToAttackForMinionCommandCD> triggerSelectNewEnemyToAttackCommandLookup;

		public ComponentLookup<TriggerAnimationOnDeathCD> triggerAnimationOnDeathLookup;

		public ComponentLookup<MoveToPredictedByEntityDestroyedCD> moveToPredictedByEntityDestroyedLookup;

		public ComponentLookup<HasExplodedCD> hasExplodedLookup;
	}
}
