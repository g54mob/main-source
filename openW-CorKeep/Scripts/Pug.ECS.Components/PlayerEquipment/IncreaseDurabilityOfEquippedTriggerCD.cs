using Unity.Entities;

namespace PlayerEquipment
{
	public struct IncreaseDurabilityOfEquippedTriggerCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		public int triggerCounter;
	}
}
