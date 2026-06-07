using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Lever : ControlSpec, INotchedSpec
	{
		[Header("Rigidbody")]
		public float rigidbodyMass = 30f;

		public float rigidbodyDrag = 15f;

		public float rigidbodyAngularDrag;

		public float blockDrag;

		public float blockAngularDrag;

		public bool zeroCenterOfMass;

		[Header("Lever")]
		public bool invertDirection;

		[Tooltip("Optional")]
		public Transform interactionPoint;

		public float maxForceAppliedMagnitude = float.PositiveInfinity;

		public float pullingForceMultiplier = 1f;

		public float scrollWheelHoverScroll = 0.025f;

		public float scrollWheelSpring;

		[Header("Notches")]
		public bool useSteppedJoint = true;

		public bool steppedValueUpdate = true;

		public int notches = 20;

		public bool useInnerLimitSpring;

		public int innerLimitMinNotch;

		public int innerLimitMaxNotch;

		[Header("Hinge Joint")]
		public Vector3 jointAxis = Vector3.up;

		public bool useSpring = true;

		public float jointSpring = 100f;

		public float jointDamper;

		public bool useLimits = true;

		public float jointLimitMin;

		public float jointLimitMax;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip notch;

		public AudioClip drag;

		public AudioClip limitHit;

		public bool limitVibration;

		public override InteractableTag InteractableTag => InteractableTag.Lever;

		public bool IsNotched => useSteppedJoint;

		public int NotchCount => notches;

		private void OnValidate()
		{
			if (nonVrStaticInteractionArea != null && nonVrStaticInteractionArea.gameObject.activeInHierarchy)
			{
				Debug.LogWarning("nonVrStaticInteractionArea gameObject must be disabled in prefabs! Forcing disable on nonVrStaticInteractionArea gameObject", this);
				nonVrStaticInteractionArea.gameObject.SetActive(value: false);
			}
		}
	}
}
