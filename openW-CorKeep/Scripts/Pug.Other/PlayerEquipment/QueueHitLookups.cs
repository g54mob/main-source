using Pug.Properties;
using Unity.Collections;
using Unity.Entities;

namespace PlayerEquipment
{
	public struct QueueHitLookups
	{
		[ReadOnly]
		public ComponentLookup<DurabilityCD> durabilityLookup;

		[ReadOnly]
		public ComponentLookup<MeleeWeaponCD> meleeWeaponLookup;

		[ReadOnly]
		public ComponentLookup<RangeWeaponCD> rangeWeaponLookup;

		[ReadOnly]
		public ComponentLookup<BeamWeaponCD> beamWeaponLookup;

		[ReadOnly]
		public ComponentLookup<MoveFreelyWeaponCD> moveFreelyWeaponLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public ComponentLookup<HasWeaponDamageCD> hasWeaponDamageLookup;

		[ReadOnly]
		public ComponentLookup<WeaponDamageCD> weaponDamageLookup;

		[ReadOnly]
		public ComponentLookup<LeaveTrailCD> leaveTrailLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		public ComponentLookup<ControlledByOtherEntityCD> controlledByOTherEntityLookup;

		public ComponentLookup<QueueHitTriggerCD> queueHitTriggerLookup;
	}
}
