using Inventory;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace PlayerState
{
	public struct LookupStateUpdateData
	{
		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<EnemyActAsDestructibleCD> enemyActAsDestructibleLookup;

		[ReadOnly]
		public ComponentLookup<MoveFreelyWeaponCD> moveFreelyWeaponLookup;

		public ComponentLookup<LocalTransform> localTransformLookup;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		[ReadOnly]
		public ComponentLookup<ParchmentRecipeCD> parchmentRecipeLookup;

		[ReadOnly]
		public ComponentLookup<ScannerCD> scannerLookup;

		[ReadOnly]
		public ComponentLookup<SpawnsItemsOnUseCD> spawnsItemsOnUseLookup;

		public ComponentLookup<LeashedCD> leashedLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public ComponentLookup<OccupiableCD> occupiableLookup;

		[ReadOnly]
		public ComponentLookup<OffHandCD> offHandLookup;

		public ComponentLookup<OctopusBossCD> octopusBossLookup;

		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<SittableCD> sittableLookup;

		public ComponentLookup<MinecartCD> minecartLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		public ComponentLookup<VehicleCD> vehicleLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public BufferLookup<InventoryChangeBuffer> inventoryChangeBuffer;

		public BufferLookup<CraftBuffer> craftBuffer;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> inventoryBufferLookup;

		[ReadOnly]
		public ComponentLookup<AnvilCD> anvilLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> cattleLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleCD> breedToggleLookup;

		[ReadOnly]
		public ComponentLookup<NameCD> nameLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> mealsEatenLookup;

		public ComponentLookup<WaitingForCastingOpenItemResultCD> waitingForCastingOpenItemResultLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		public ComponentLookup<ControlledByOtherEntityCD> controlledByOtherEntityLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		public ComponentLookup<WaitingForConsumedBaitResultCD> waitingForConsumedBaitResultLookup;

		public ComponentLookup<DelayedFishLootCD> delayedFishingLootLookup;

		[ReadOnly]
		public ComponentLookup<BoatCD> boatLookup;
	}
}
