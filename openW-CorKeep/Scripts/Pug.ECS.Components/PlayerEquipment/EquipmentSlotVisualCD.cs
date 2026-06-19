using Unity.Entities;
using Unity.NetCode;

namespace PlayerEquipment
{
	public struct EquipmentSlotVisualCD : IComponentData, IQueryTypeParameter
	{
		public TickTimer windupSoundTimer;

		public int lastWindupTier;

		public int lastConditionStackTier;

		public bool warmupWasActive;

		public bool warmupWasStopped;

		public NetworkTick previousLastInteractPressedOnCooldownTick;
	}
}
