using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Wheel : ControlSpec
	{
		[Header("RigidBody")]
		public float mass = 1f;

		public float angularDrag = 1f;

		public bool zeroCenterOfMass;

		[Header("Hinge Joint")]
		public Vector3 jointAxis = Vector3.up;

		public bool useSpring;

		public float jointSpring;

		public float springDamper;

		public bool useLimits = true;

		public float jointLimitMin;

		public float jointLimitMax;

		public float bounciness;

		public float bounceMinVelocity;

		[Tooltip("A value between joint min and max limit")]
		public float jointStartingPos;

		public bool invertDirection = true;

		public float scrollWheelHoverScroll = 1f;

		[Header("RotatorTrack")]
		public float rotatorMaxForceMagnitude = 0.1f;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip drag;

		public AudioClip limitHit;

		public float hitTolerance = 0.1f;

		[Header("Haptics")]
		public bool useHaptics = true;

		public float notchAngle = 1f;

		public bool enableWhenTouching;

		public override InteractableTag InteractableTag => InteractableTag.Wheel;

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
