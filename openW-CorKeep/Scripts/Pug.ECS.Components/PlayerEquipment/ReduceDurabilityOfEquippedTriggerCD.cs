using Unity.Entities;

namespace PlayerEquipment
{
	public struct ReduceDurabilityOfEquippedTriggerCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		public int triggerCounter;
	}
}
