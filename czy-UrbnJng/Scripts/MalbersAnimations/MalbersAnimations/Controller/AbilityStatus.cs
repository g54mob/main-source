using UnityEngine;

namespace MalbersAnimations.Controller
{
	public enum AbilityStatus
	{
		PlayOneTime = 0,
		[InspectorName("Charged or Hold Input Down")]
		Charged = 1,
		ActiveByTime = 2,
		Toggle = 3,
		Forever = 4
	}
}
