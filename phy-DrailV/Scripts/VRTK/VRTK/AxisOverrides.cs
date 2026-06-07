using System;
using UnityEngine;

namespace VRTK
{
	[Serializable]
	public sealed class AxisOverrides
	{
		public enum ApplyOverrideType
		{
			Never = 0,
			Always = 1,
			DigitalState = 2,
			AxisState = 3,
			SenseAxisState = 4,
			AxisAndSenseAxisState = 5
		}

		[Header("Global Override Settings")]
		[Tooltip("Determines whether to ignore all of the given overrides on an Interaction event.")]
		public bool ignoreAllOverrides = true;

		[Tooltip("Sets the Animation parameter for the interaction type and can be used to change the Idle pose based on interaction type.")]
		public float stateValue = -1f;

		[Header("Thumb Override Settings")]
		[Tooltip("Determines when to apply the given thumb override.")]
		public ApplyOverrideType applyThumbOverride = ApplyOverrideType.Always;

		[Tooltip("The axis override for the thumb on an Interact Touch event. Will only be applicable if the thumb button state is not touched.")]
		[Range(0f, 1f)]
		public float thumbOverride;

		[Header("Index Finger Override Settings")]
		[Tooltip("Determines when to apply the given index finger override.")]
		public ApplyOverrideType applyIndexOverride = ApplyOverrideType.Always;

		[Tooltip("The axis override for the index finger on an Interact Touch event. Will only be applicable if the index finger button state is not touched.")]
		[Range(0f, 1f)]
		public float indexOverride;

		[Header("Middle Finger Override Settings")]
		[Tooltip("Determines when to apply the given middle finger override.")]
		public ApplyOverrideType applyMiddleOverride = ApplyOverrideType.Always;

		[Tooltip("The axis override for the middle finger on an Interact Touch event. Will only be applicable if the middle finger button state is not touched.")]
		[Range(0f, 1f)]
		public float middleOverride;

		[Header("Ring Finger Override Settings")]
		[Tooltip("Determines when to apply the given ring finger override.")]
		public ApplyOverrideType applyRingOverride = ApplyOverrideType.Always;

		[Tooltip("The axis override for the ring finger on an Interact Touch event. Will only be applicable if the ring finger button state is not touched.")]
		[Range(0f, 1f)]
		public float ringOverride;

		[Header("Pinky Finger Override Settings")]
		[Tooltip("Determines when to apply the given pinky finger override.")]
		public ApplyOverrideType applyPinkyOverride = ApplyOverrideType.Always;

		[Tooltip("The axis override for the pinky finger on an Interact Touch event.  Will only be applicable if the pinky finger button state is not touched.")]
		[Range(0f, 1f)]
		public float pinkyOverride;
	}
}
