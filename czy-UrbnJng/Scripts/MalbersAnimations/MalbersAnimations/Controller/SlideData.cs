using System;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct SlideData
	{
		[Tooltip("If is set to true then this Ground Changer can activate the Slide State on the Animal")]
		public bool Slide;

		[Tooltip("If true, then the rotation will be ignored in the Slide State")]
		public bool IgnoreRotation;

		[Tooltip("Minimun Slope Direction Angle to activate the Slide State")]
		[Min(0f)]
		public float MinAngle;

		[Tooltip("Slide activation angle to activate the state. The character needs to be looking/align at the Slope, Default value 180")]
		public float ActivationAngle;

		[Tooltip("Additive Value to add to the Speed of the Slide State")]
		public float AdditiveForwardSpeed;

		[Tooltip("Additive Value to add to the Speed of the Slide State")]
		public float AdditiveHorizontalSpeed;
	}
}
