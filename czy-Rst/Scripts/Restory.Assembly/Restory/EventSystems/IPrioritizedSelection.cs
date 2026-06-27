using UnityEngine;

namespace Restory.EventSystems
{
	public interface IPrioritizedSelection
	{
		NavigationPriority Priority { get; }

		GameObject TargetNavigation { get; }
	}
}
