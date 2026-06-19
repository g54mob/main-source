using Unity.Entities;
using Unity.NetCode;

namespace PlayerEquipment
{
	public struct EquipmentSlotCD : IComponentData, IQueryTypeParameter
	{
		public EquipmentSlotType slotType;

		[GhostField]
		public float currentWindup;

		[GhostField]
		public SecondaryUseCD secondaryUse;

		[GhostField]
		public WarmupCD warmupCD;

		[GhostField]
		public TickTimer windupTimer;

		[GhostField]
		public float currentWindupMultiplier;

		[GhostField]
		public bool atMaxWindup;

		[GhostField]
		public int currentWindupTier;

		[GhostField]
		public bool summonMinion;

		[GhostField]
		public bool interactIsPendingToBeUsed;

		[GhostField]
		public bool secondInteractIsPendingToBeUsed;

		[GhostField]
		public bool secondInteractBlockedUntilRelease;

		[GhostField]
		public bool windupCanceled;

		[GhostField]
		public TickTimer warmupTimer;

		[GhostField]
		public NetworkTick lastInteractPressedOnCooldownTick;

		public readonly EquipmentSlotType GetSlotType()
		{
			return slotType;
		}

		public static EquipmentSlotCD GetDefaultValues(bool secondInteractBlockedUntilRelease)
		{
			return new EquipmentSlotCD
			{
				slotType = EquipmentSlotType.NonUsableSlot,
				currentWindupMultiplier = 1f,
				secondInteractBlockedUntilRelease = secondInteractBlockedUntilRelease
			};
		}
	}
}
