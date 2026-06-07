using UnityEngine;

namespace DV.CabControls.Spec
{
	public class BeltAdjuster : ControlSpec
	{
		public float angleSnappingThreshold = 5f;

		public float maxDistance = 0.5f;

		public SphereCollider collisionCollider;

		public GameObject visualControllerGameObject;

		public GameObject snapPointGameObject;

		public override InteractableTag InteractableTag => InteractableTag.BeltSlot;
	}
}
