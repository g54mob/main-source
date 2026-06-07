using DV.Interaction;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Gizmo : ControlSpec
	{
		public bool behaveAsItem;

		public bool carryingPosition;

		public bool precisionGrab;

		[Header("Static non-vr interaction area - optional")]
		public StaticInteractionArea nonVrStaticInteractionArea;

		[Header("VR")]
		public bool telegrabbable;

		[Header("Audio")]
		public AudioClip collision;

		public ItemCollisionSoundCategory itemCollisionSoundCategory;

		public ItemCollisionSoundCategory ignoredCollisionSoundCategory;

		public override InteractableTag InteractableTag => InteractableTag.Gizmo;

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
