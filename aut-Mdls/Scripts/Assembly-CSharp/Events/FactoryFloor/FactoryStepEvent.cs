using Logic.Threading.Events;
using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/FactoryStepEvent", fileName = "FactoryStepEvent", order = 0)]
	public class FactoryStepEvent : MainThreadEventSO<int>
	{
	}
}
