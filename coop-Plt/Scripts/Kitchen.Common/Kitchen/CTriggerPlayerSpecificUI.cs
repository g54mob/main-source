using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CTriggerPlayerSpecificUI : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsTriggered;

		public Entity TriggerEntity;

		public bool UseGrab;

		public CTriggerPlayerSpecificUI Reset()
		{
			return new CTriggerPlayerSpecificUI
			{
				IsTriggered = false,
				TriggerEntity = default(Entity),
				UseGrab = UseGrab
			};
		}
	}
}
