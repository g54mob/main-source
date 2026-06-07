using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Puller : ControlSpec, INotchedSpec
	{
		[Header("Rigidbody")]
		public float rigidbodyMass = 5f;

		public float rigidbodyDrag = 15f;

		public bool zeroCenterOfMass;

		[Header("Puller")]
		public BoxCollider insideVolume;

		[Header("Stepped puller")]
		public bool useSteppedPuller;

		public int notches = 20;

		public bool invertDirection;

		public float scrollWheelHoverScroll = 0.025f;

		[Header("Configurable Joint")]
		public bool useCustomConnectionAnchor;

		public Transform connectionAnchor;

		public Transform pivot;

		public float linearLimit = 0.003f;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip notch;

		public AudioClip drag;

		public AudioClip limitHit;

		public override InteractableTag InteractableTag => InteractableTag.Puller;

		public bool IsNotched => useSteppedPuller;

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
