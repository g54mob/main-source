using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/ResourceWithdrawnEvent", fileName = "ResourceWithdrawnEvent", order = 0)]
	public class ResourceWithdrawnEventSO : MainThreadEventSO<Resource>
	{
	}
}
