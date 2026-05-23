using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/ResourceCreatedEvent", fileName = "ResourceCreatedEvent", order = 0)]
	public class ResourceCreatedEventSO : MainThreadEventSO<Resource>
	{
	}
}
