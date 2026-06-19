using NaughtyAttributes;
using UnityEngine;

public class AutomatedMoverSharedAuthoring : MonoBehaviour
{
	public enum CyclingType
	{
		AllMoversEnabledWhenIdle = 0,
		CycleRoundRobinAfterActivation = 1
	}

	public float moveTime;

	public float cooldownTime;

	public bool pickUpDuringMove;

	public bool allowOnlyOneActiveMoverAtATime;

	[ShowIf("allowOnlyOneActiveMoverAtATime")]
	[AllowNesting]
	public CyclingType enabledMovers;

	public bool splitOnMove;

	public bool allowPickupFromInventories;
}
