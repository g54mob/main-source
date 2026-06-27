using UnityEngine;

namespace Restory.EventSystems
{
	public class PrioritizedSelection : IPrioritizedSelection
	{
		public NavigationPriority Priority { get; }

		public GameObject TargetNavigation { get; }

		public PrioritizedSelection(GameObject targetNavigation, NavigationPriority priority)
		{
			TargetNavigation = targetNavigation;
			Priority = priority;
		}
	}
}
