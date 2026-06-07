using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Touchscreen : ControlSpec
	{
		[Header("Touchscreen")]
		public bool useEntireScreen = true;

		public bool createRigidbody = true;

		public bool flipHorizontalCoords;

		public bool flipVerticalCoords;

		public float hoverVerticalOffset;

		public Vector2Int gridSize;

		[Header("VR")]
		[Tooltip("Extension of the button area in meters\nWill have no effect outside of the PIPA range")]
		public float maxVRTolerance;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("Audio")]
		public AudioClip press;

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
