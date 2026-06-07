using Events;
using UnityEngine;

namespace Data.Objectives
{
	[CreateAssetMenu(menuName = "Events/Objectives/ModuleChallenge Item Claimed Event", fileName = "ModuleChallengeItemClaimedEvent")]
	public class ModuleChallengeItemClaimedEvent : BaseEvent<ObjectiveTargetItem>
	{
	}
}
