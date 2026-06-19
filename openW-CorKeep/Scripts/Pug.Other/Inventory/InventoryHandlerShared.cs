using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;

namespace Inventory
{
	public struct InventoryHandlerShared
	{
		public PugDatabase.DatabaseBankCD databaseBankCD;

		public SkillTalentsTableCD skillTalentsTableCD;

		public UpgradeCostsTableCD upgradeCostsTableCD;

		public InventoryAuxDataSystemDataCD inventoryAuxDataSystemDataCD;

		public EntityCommandBuffer ecb;

		public bool isFirstTimeFullyPredictingTick;

		public bool isServer;

		public NetworkTick currentTick;

		[ReadOnly]
		public ComponentLookup<CantBeSoldCD> cantBeSoldLookup;

		[ReadOnly]
		public ComponentLookup<CookedFoodCD> cookedFoodLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		public BufferLookup<InventoryBuffer> inventoryLookup;

		[ReadOnly]
		public ComponentLookup<VendingMachineCD> vendingMachineLookup;

		[ReadOnly]
		public ComponentLookup<PetOwnerCD> petOwnerLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<NameCD> nameLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> mealsEatenLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleCD> breedToggleLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> cattleLookUp;

		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public ComponentLookup<DurabilityCD> durabilityLookup;

		public ComponentLookup<CraftingCD> craftingLookup;

		[ReadOnly]
		public ComponentLookup<CookingIngredientCD> ingredientLookup;

		[ReadOnly]
		public ComponentLookup<AnvilCD> anvilLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<PrioritizedRepairMaterialCD> prioritizedRepairMaterialLookup;

		[ReadOnly]
		public ComponentLookup<ExtraInventoryCD> extraInventorySizeLookup;

		[ReadOnly]
		public ComponentLookup<FullnessCD> fullnessLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		public ComponentLookup<TriggerAnimationOnDeathCD> triggerAnimationOnDeathCD;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		public ComponentLookup<ParchmentRecipeCD> parchmentRecipeLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		[ReadOnly]
		public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup;

		public BufferLookup<PetTalentBuffer> petTalentBuffer;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

		[ReadOnly]
		public BufferLookup<CanCraftObjectsBuffer> canCraftObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

		public BufferLookup<LockedObjectsBuffer> lockedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<VendingMachineItemBuffer> vendingMachineItemBufferLookup;

		public BufferLookup<InventorySlotRequirementBuffer> inventorySlotRequirementBufferLookup;

		public BufferLookup<SkillTalentConditionsBuffer> skillTalentConditionsBufferLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsEffectsBufferLookup;

		[ReadOnly]
		public ComponentLookup<FlowerCD> flowerLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public ComponentLookup<AnimationOrientationCD> animationOrientationLookup;

		[ReadOnly]
		public ComponentLookup<ExtractableCD> extractableLookup;

		public ComponentLookup<ObjectFilteringCD> objectFilteringLookup;

		public InventoryHandlerShared(ref SystemState state, PugDatabase.DatabaseBankCD database, SkillTalentsTableCD skillTalentsTable, UpgradeCostsTableCD upgradeCostsTable, InventoryAuxDataSystemDataCD inventoryAuxDataSystemData)
		{
			currentTick = default(NetworkTick);
			ecb = default(EntityCommandBuffer);
			isFirstTimeFullyPredictingTick = false;
			isServer = state.WorldUnmanaged.IsServer();
			databaseBankCD = database;
			skillTalentsTableCD = skillTalentsTable;
			upgradeCostsTableCD = upgradeCostsTable;
			inventoryAuxDataSystemDataCD = inventoryAuxDataSystemData;
			cantBeSoldLookup = state.GetComponentLookup<CantBeSoldCD>(isReadOnly: true);
			cookedFoodLookup = state.GetComponentLookup<CookedFoodCD>(isReadOnly: true);
			objectCategoryTagsLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			levelLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
			inventoryLookup = state.GetBufferLookup<InventoryBuffer>();
			vendingMachineLookup = state.GetComponentLookup<VendingMachineCD>(isReadOnly: true);
			petOwnerLookup = state.GetComponentLookup<PetOwnerCD>(isReadOnly: true);
			localTransformLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			nameLookup = state.GetComponentLookup<NameCD>(isReadOnly: true);
			mealsEatenLookup = state.GetComponentLookup<MealsEatenCD>(isReadOnly: true);
			breedToggleLookup = state.GetComponentLookup<BreedToggleCD>(isReadOnly: true);
			cattleLookUp = state.GetComponentLookup<CattleCD>(isReadOnly: true);
			entityDestroyedLookup = state.GetComponentLookup<EntityDestroyedCD>();
			durabilityLookup = state.GetComponentLookup<DurabilityCD>();
			craftingLookup = state.GetComponentLookup<CraftingCD>();
			ingredientLookup = state.GetComponentLookup<CookingIngredientCD>(isReadOnly: true);
			anvilLookup = state.GetComponentLookup<AnvilCD>(isReadOnly: true);
			objectDataLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			prioritizedRepairMaterialLookup = state.GetComponentLookup<PrioritizedRepairMaterialCD>(isReadOnly: true);
			extraInventorySizeLookup = state.GetComponentLookup<ExtraInventoryCD>(isReadOnly: true);
			fullnessLookup = state.GetComponentLookup<FullnessCD>(isReadOnly: true);
			petLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			triggerAnimationOnDeathCD = state.GetComponentLookup<TriggerAnimationOnDeathCD>();
			playerGhostLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			simulateLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
			parchmentRecipeLookup = state.GetComponentLookup<ParchmentRecipeCD>(isReadOnly: true);
			ghostEffectEventBufferPointerLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			overrideAlwaysAllowToBeTrashedLookup = state.GetComponentLookup<OverrideLegendaryForSlotRequirementsCD>(isReadOnly: true);
			petTalentBuffer = state.GetBufferLookup<PetTalentBuffer>();
			levelEntitiesBufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
			canCraftObjectsBufferLookup = state.GetBufferLookup<CanCraftObjectsBuffer>(isReadOnly: true);
			summarizedConditionsBufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			containedObjectsBufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
			lockedObjectsBufferLookup = state.GetBufferLookup<LockedObjectsBuffer>();
			vendingMachineItemBufferLookup = state.GetBufferLookup<VendingMachineItemBuffer>(isReadOnly: true);
			inventorySlotRequirementBufferLookup = state.GetBufferLookup<InventorySlotRequirementBuffer>();
			skillTalentConditionsBufferLookup = state.GetBufferLookup<SkillTalentConditionsBuffer>();
			ghostEffectEventBufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			summarizedConditionsEffectsBufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			flowerLookup = state.GetComponentLookup<FlowerCD>(isReadOnly: true);
			randomLookup = state.GetComponentLookup<RandomCD>();
			moveToPredictedByCombatInteractionLookup = state.GetComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD>();
			ownerLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			factionLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			isExplosiveLookup = state.GetComponentLookup<IsExplosiveCD>(isReadOnly: true);
			animationOrientationLookup = state.GetComponentLookup<AnimationOrientationCD>(isReadOnly: true);
			extractableLookup = state.GetComponentLookup<ExtractableCD>(isReadOnly: true);
			objectFilteringLookup = state.GetComponentLookup<ObjectFilteringCD>();
		}

		public void Update(ref SystemState state, EntityCommandBuffer ecb, NetworkTime networkTime)
		{
			currentTick = networkTime.ServerTick;
			isFirstTimeFullyPredictingTick = networkTime.IsFirstTimeFullyPredictingTick;
			this.ecb = ecb;
			isServer = state.WorldUnmanaged.IsServer();
			cantBeSoldLookup.Update(ref state);
			cookedFoodLookup.Update(ref state);
			objectCategoryTagsLookup.Update(ref state);
			levelLookup.Update(ref state);
			inventoryLookup.Update(ref state);
			vendingMachineLookup.Update(ref state);
			petOwnerLookup.Update(ref state);
			localTransformLookup.Update(ref state);
			nameLookup.Update(ref state);
			mealsEatenLookup.Update(ref state);
			breedToggleLookup.Update(ref state);
			cattleLookUp.Update(ref state);
			entityDestroyedLookup.Update(ref state);
			durabilityLookup.Update(ref state);
			craftingLookup.Update(ref state);
			ingredientLookup.Update(ref state);
			anvilLookup.Update(ref state);
			objectDataLookup.Update(ref state);
			prioritizedRepairMaterialLookup.Update(ref state);
			extraInventorySizeLookup.Update(ref state);
			fullnessLookup.Update(ref state);
			petLookup.Update(ref state);
			triggerAnimationOnDeathCD.Update(ref state);
			playerGhostLookup.Update(ref state);
			simulateLookup.Update(ref state);
			parchmentRecipeLookup.Update(ref state);
			ghostEffectEventBufferPointerLookup.Update(ref state);
			overrideAlwaysAllowToBeTrashedLookup.Update(ref state);
			petTalentBuffer.Update(ref state);
			levelEntitiesBufferLookup.Update(ref state);
			canCraftObjectsBufferLookup.Update(ref state);
			summarizedConditionsBufferLookup.Update(ref state);
			containedObjectsBufferLookup.Update(ref state);
			lockedObjectsBufferLookup.Update(ref state);
			vendingMachineItemBufferLookup.Update(ref state);
			inventorySlotRequirementBufferLookup.Update(ref state);
			skillTalentConditionsBufferLookup.Update(ref state);
			ghostEffectEventBufferLookup.Update(ref state);
			summarizedConditionsEffectsBufferLookup.Update(ref state);
			flowerLookup.Update(ref state);
			randomLookup.Update(ref state);
			moveToPredictedByCombatInteractionLookup.Update(ref state);
			ownerLookup.Update(ref state);
			factionLookup.Update(ref state);
			isExplosiveLookup.Update(ref state);
			animationOrientationLookup.Update(ref state);
			extractableLookup.Update(ref state);
			objectFilteringLookup.Update(ref state);
		}
	}
}
