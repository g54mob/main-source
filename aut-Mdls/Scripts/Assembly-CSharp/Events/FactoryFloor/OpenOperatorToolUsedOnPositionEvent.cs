using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/OpenOperatorToolUsedOnPositionEvent", fileName = "OpenOperatorToolUsedOnPositionEvent", order = 0)]
	public class OpenOperatorToolUsedOnPositionEvent : BaseEvent<Vector3Int>
	{
	}
}
