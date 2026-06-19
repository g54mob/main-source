using Unity.Entities;
using Unity.NetCode;

namespace PlayerEquipment
{
	public struct PlayerAttackCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public float windupMult;

		[GhostField]
		public bool isWoundup;

		[GhostField]
		public TickTimer hitDuration;

		[GhostField]
		public TickTimer hitDelay;

		[GhostField]
		public int animationToPlayAfterAttack;

		[GhostField]
		public EquipmentSlotType slotType;

		[GhostField]
		public int meleeDamage;

		[GhostField]
		public float lungeForce;

		[GhostField]
		public float recoilForce;

		[GhostField]
		public bool leaveTrail;

		[GhostField]
		public int trails;

		[GhostField]
		public ObjectType objectType;

		[GhostField]
		public float windupForce;

		[GhostField]
		public bool heldItemIsBroken;

		[GhostField]
		public int hitStreak;

		[GhostField]
		public TickTimer spawnStuffOnHitCooldown;

		[GhostField]
		public int currentWindupTier;

		[GhostField]
		public bool didSpawnTrail;
	}
}
