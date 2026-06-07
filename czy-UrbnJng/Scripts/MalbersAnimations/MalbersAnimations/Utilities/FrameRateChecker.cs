using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Frame Rate")]
	public class FrameRateChecker : MonoBehaviour
	{
		[HelpBox]
		public string Description = "Shorcuts to limit your game framerate (Shift+F1/F2/F3/F4/F5/F6  for 10/20/30/60/120/Reset fps)";

		private void Update()
		{
		}
	}
}
