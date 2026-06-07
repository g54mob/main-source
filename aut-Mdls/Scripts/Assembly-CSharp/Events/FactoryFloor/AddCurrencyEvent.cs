using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/AddCurrencyEvent", fileName = "AddCurrencyEvent")]
	public class AddCurrencyEvent : BaseEvent<AddCurrencyEventDto>
	{
	}
}
