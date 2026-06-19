using CommandMinion;
using Inventory;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;

namespace PlayerEquipment
{
	public struct AttackWithEquipmentLookup
	{
		[ReadOnly]
		public ComponentLookup<CooldownCD> cooldownLookup;

		[ReadOnly]
		public ComponentLookup<WarmupCD> warmupLookup;

		[ReadOnly]
		public ComponentLookup<DurabilityCD> durabilityLookup;

		[ReadOnly]
		public ComponentLookup<MeleeWeaponCD> meleeWeaponLookup;

		[ReadOnly]
		public ComponentLookup<HasWeaponDamageCD> hasWeaponDamageLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectBuffer;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer;

		[ReadOnly]
		public ComponentLookup<RangeWeaponCD> rangedWeaponLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public ComponentLookup<SecondaryUseCD> secondaryUseLookup;

		[ReadOnly]
		public ComponentLookup<ConsumesManaCD> consumesManaLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		[ReadOnly]
		public ComponentLookup<CommandMinionWeaponCD> commandMinionWeaponLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> doorLookup;

		[ReadOnly]
		public ComponentLookup<AffectObjectWhenMelodyPlayedCD> affectObjectWhenMelodyPlayedLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> reduceDurabilityOfEquippedLookup;

		public ComponentLookup<QueueHitTriggerCD> queueHitLookup;

		public ComponentLookup<AttackWithEquipmentTag> attackWithEquipmentLookup;

		public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public ComponentLookup<RangedWeaponSpawnProjectileTriggerTag> rangedWeaponSpawnProjectileTriggerTagLookup;

		public ComponentLookup<BeamWeaponSpawnProjectileTriggerTag> beamWeaponSpawnProjectileTriggerTagLookup;
	}
}
