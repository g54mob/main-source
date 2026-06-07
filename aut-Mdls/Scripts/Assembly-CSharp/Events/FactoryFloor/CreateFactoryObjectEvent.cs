using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/CreateFactoryObjectEvent", fileName = "CreateFactoryObjectEvent", order = 0)]
	public class CreateFactoryObjectEvent : BaseEvent<CreateFactoryObjectDto>
	{
	}
}
