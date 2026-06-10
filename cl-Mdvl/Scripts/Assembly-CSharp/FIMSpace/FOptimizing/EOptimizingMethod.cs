using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public enum EOptimizingMethod
	{
		[Tooltip("Using just Unity's Culling Groups API, detection sphere and static distance ranges from initial position")]
		Static = 0,
		[Tooltip("No Unity's Culing Groups API involved, just Optimizers Manager different interval clocks")]
		Dynamic = 1,
		[Tooltip("Detecting if object stays in one place, then using refreshing Culling Groups API with Optimizers Manager clocks to effectively detect object visibility and detect distances like Dynamic method")]
		Effective = 2,
		[Tooltip("Defining optimization levels with trigger colliders setup")]
		TriggerBased = 3
	}
}
