using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class ToggleSwitch : ControlSpec
	{
		[Header("Toggle switch")]
		public float rbMass = 0.3f;

		public bool zeroCenterOfMass;

		public Vector3 jointAxis = Vector3.forward;

		public float jointLimitMin;

		public float jointLimitMax;

		public float autoOffTimer;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip toggle;

		[Header("VR")]
		public Vector3 touchInteractionAxis = Vector3.up;

		public bool disableTouchUse;

		public override InteractableTag InteractableTag => InteractableTag.ToggleSwitch;

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
