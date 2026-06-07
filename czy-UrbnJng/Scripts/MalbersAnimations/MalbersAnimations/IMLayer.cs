using UnityEngine;

namespace MalbersAnimations
{
	public interface IMLayer
	{
		LayerMask Layer { get; set; }

		QueryTriggerInteraction TriggerInteraction { get; set; }
	}
}
