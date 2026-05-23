using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/ResourceScrappedEvent", fileName = "ResourceScrappedEvent", order = 0)]
	public class ResourceScrappedEvent : MainThreadEventSO<Resource>
	{
	}
}
