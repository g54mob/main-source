using UnityEngine;

namespace Dhs5.Utility.Updates
{
	public enum EUpdatePass
	{
		[InspectorName("After Early Update")]
		[Tooltip("Updated after the Early Update of the PlayerLoop")]
		AFTER_EARLY_UPDATE = 0,
		[InspectorName("Classic Update")]
		[Tooltip("Updated just before the Classic Update of the PlayerLoop")]
		CLASSIC_UPDATE = 1,
		[InspectorName("After Update")]
		[Tooltip("Updated after the Classic Update of the PlayerLoop")]
		AFTER_UPDATE = 2,
		[InspectorName("After Late Update")]
		[Tooltip("Updated after the Late Update of the PlayerLoop")]
		AFTER_LATE_UPDATE = 3,
		[InspectorName("Before Fixed Update")]
		[Tooltip("Updated inside the Fixed Update of the PlayerLoop, before the FixedUpdate method")]
		BEFORE_FIXED_UPDATE = 4,
		[InspectorName("After Physics Fixed Update")]
		[Tooltip("Updated inside the Fixed Update of the PlayerLoop, after the Physics Update")]
		AFTER_PHYSICS_FIXED_UPDATE = 5
	}
}
