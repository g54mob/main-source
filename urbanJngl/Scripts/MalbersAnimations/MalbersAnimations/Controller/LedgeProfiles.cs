using System;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class LedgeProfiles
	{
		public string name = "Ledge Grab";

		[Tooltip("State Enter Status to Activate while")]
		public int EnterStatus;

		[Tooltip("Max Vertical Speed Needed to Check this Profile")]
		public float MaxVSpeed;

		[Tooltip("Check the Last State as a condition to activate the profile")]
		public StateID LastState;

		[Tooltip("Cast a Ray Upwards to check if there's a roof blocking the ledge")]
		public bool CheckUpwards;

		[Tooltip("The Ledge will be check only if the character is grounded")]
		public bool OnlyGrounded;

		[Tooltip("Forward Length Multiplier applied to the Global Length")]
		public float ForwardMultiplier = 1f;

		[Tooltip("Height Offset to cast the Ray for checking a ledge")]
		[Min(0f)]
		public float Height = 1.5f;

		[Tooltip("Ray to check if we have found a ledge")]
		[Min(0f)]
		public float LedgeExitDistance = 0.25f;

		[Tooltip("If the Animation Normalized Time of this state (Ledge Grab) is greater Exit Animation time,\n the State will Allow Exit()... so other states can try activate themselves.")]
		[Range(0f, 1f)]
		public float ExitTime = 0.9f;

		[Tooltip("Horizontal(X) and Vertical(Y) values needed to apply offset movement to have better alignment with the Ledge")]
		public Vector2 AlingOffset;

		[Tooltip("Align the character to the Wall's normal direction")]
		public bool Orient = true;

		[Tooltip("Smoothness value to align the character to the wall")]
		[Hide("Orient", false)]
		[Min(0f)]
		public float OrientSmoothness = 10f;

		public bool AdditivePosition;

		[Hide("AdditivePosition", false)]
		[Min(0f)]
		public float HeightSpeed = 0.5f;

		[Hide("AdditivePosition", false)]
		[Min(0f)]
		public float ForwardSpeed = 0.5f;

		[Hide("AdditivePosition", false)]
		public AnimationCurve HeightCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.45f, 1f), new Keyframe(0.55f, 0f), new Keyframe(1f, 0f));

		[Hide("AdditivePosition", false)]
		public AnimationCurve ForwardCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.45f, 0f), new Keyframe(0.55f, 1f), new Keyframe(1f, 1f));
	}
}
