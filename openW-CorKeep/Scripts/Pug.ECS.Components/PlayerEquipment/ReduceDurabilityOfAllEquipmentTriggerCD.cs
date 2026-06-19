using Unity.Entities;

namespace PlayerEquipment
{
	public struct ReduceDurabilityOfAllEquipmentTriggerCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		public int damage;

		public float percentage;
	}
}
