using Pug.Properties;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;

namespace PlayerEquipment
{
	public struct SpawnProjectilesHelpData
	{
		[ReadOnly]
		public ComponentLookup<RangeWeaponCD> rangedWeaponLookup;

		[ReadOnly]
		public ComponentLookup<BeamWeaponCD> beamWeaponLookup;

		[ReadOnly]
		public ComponentLookup<HasWeaponDamageCD> hasWeaponDamageLookup;

		[ReadOnly]
		public ComponentLookup<DurabilityCD> durabilityLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<WeaponDamageCD> weaponDamageLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> movementSpeedLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public ComponentLookup<PiercingProjectileCD> piercingProjectileLookup;

		[ReadOnly]
		public ComponentLookup<BouncingProjectileCD> bouncingProjectileLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> doorLookup;

		[ReadOnly]
		public ComponentLookup<AffectObjectWhenMelodyPlayedCD> affectObjectWhenMelodyPlayedLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

		public ConditionsTableCD conditionsTableCD;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public EntityCommandBuffer ecb;

		public bool isFirstTimeFullyPredictingTick;

		public TileAccessor tileAccessor;
	}
}
