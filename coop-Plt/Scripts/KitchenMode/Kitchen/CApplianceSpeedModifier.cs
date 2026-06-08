using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceSpeedModifier : IEffectType, IAttachableProperty, IComponentData
	{
		public bool AffectsAllProcesses;

		public int Process;

		public float Speed;

		public float BadSpeed;
	}
}
