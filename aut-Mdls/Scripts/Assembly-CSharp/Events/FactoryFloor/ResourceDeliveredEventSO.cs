using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/ResourceDeliveredEvent", fileName = "ResourceDeliveredEvent", order = 0)]
	public class ResourceDeliveredEventSO : MainThreadEventSO<Resource>
	{
	}
}
