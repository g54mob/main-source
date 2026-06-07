using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Button : ControlSpec
	{
		[Header("Button")]
		public bool createRigidbody = true;

		public bool useJoints = true;

		public float pushStrength = 0.5f;

		public float linearLimit = 0.003f;

		public Vector3 pushLocalOffset;

		public bool isToggle;

		public bool isTogglingBack;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip press;

		public AudioClip toggleOn;

		public AudioClip toggleOff;

		public bool play2DAudio;

		[Header("VR")]
		public bool disableTouchUse;

		public VRControllerButton overrideUseButton;

		public override InteractableTag InteractableTag => InteractableTag.Button;

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
