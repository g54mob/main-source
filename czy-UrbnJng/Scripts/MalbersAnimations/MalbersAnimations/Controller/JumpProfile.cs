using System;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct JumpProfile
	{
		public string name;

		[Tooltip("Minimal Vertical Speed to Activate this Jump")]
		[Min(0f)]
		public float VerticalSpeed;

		[Tooltip("Min Distance to Complete the Land when the Jump is on the Highest Point")]
		[Min(0f)]
		public float JumpLandDistance;

		[Tooltip("Animation normalized time to change to fall animation if the ray checks if the animal is falling ")]
		[Range(0f, 1f)]
		public float fallingTime;

		[Tooltip("Set Allow Exit to the Jump Profile (*New)")]
		[Range(0f, 1f)]
		public float ExitTime;

		[Tooltip("Animation normalized time to check if we can end the jump sooner. if its set to zero I will use 0.333 normalize value as default")]
		[MinMaxRange(0f, 1f)]
		public RangedFloat CliffTime;

		[Tooltip("Maximum distance to land on a Cliff")]
		[Min(0f)]
		public float CliffLandDistance;

		public float HeightMultiplier;

		[Tooltip("Forward multiplier to increase/decrease the Forward  Rootmotion speed of the Jump")]
		public float ForwardMultiplier;

		[Tooltip("Extra forward Movement to move the Animal Forward")]
		public float ForwardPressed;

		[Tooltip("Last State the animal was before making the Jump")]
		public StateID LastState;
	}
}
