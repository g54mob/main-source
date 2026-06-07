using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Rotary : ControlSpec, INotchedSpec
	{
		public float rigidbodyMass = 1f;

		public float rigidbodyAngularDrag = 0.03f;

		public float blockAngularDrag;

		public bool zeroCenterOfMass;

		[Header("Rotary (knob)")]
		public bool invertDirection;

		public float scrollWheelHoverScroll = 1f;

		public bool scrollWheelUseSpringRotation;

		[Header("Notches")]
		public bool useSteppedJoint = true;

		public int notches = 20;

		public bool useInnerLimitSpring;

		public int innerLimitMinNotch;

		public int innerLimitMaxNotch;

		[Header("Hinge Joint")]
		public Vector3 jointAxis = Vector3.up;

		public bool useSpring = true;

		public float jointSpring = 0.5f;

		public float jointDamper;

		public bool useLimits = true;

		public float jointLimitMin;

		public float jointLimitMax;

		public float bounciness;

		public float bounceMinVelocity;

		[Tooltip("A value between joint min and max limit")]
		public float jointStartingPos;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip notch;

		public AudioClip drag;

		public AudioClip limitHit;

		public override InteractableTag InteractableTag => InteractableTag.Rotary;

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
