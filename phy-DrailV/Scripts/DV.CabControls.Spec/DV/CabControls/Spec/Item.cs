using DV.ThingTypes;
using UnityEngine;

namespace DV.CabControls.Spec
{
	public class Item : ControlSpec
	{
		[Header("Item")]
		public bool receiveForces = true;

		public bool respawnOnDropThroughFloor = true;

		public bool overrideDefaultRespawnRange;

		public float respawnDistanceRange = 4f;

		public bool allowPlayerRotationXAxisVr = true;

		public bool allowPlayerRotationYAxisVr = true;

		public bool precisionGrab = true;

		public ItemControllerAttachMethod controllerAttachMethod;

		public bool isUprightInBelt;

		public float rigidbodyMass = 1f;

		public float rigidbodyDrag;

		public float rigidbodyAngularDrag = 0.01f;

		public float buoyancy = 1f;

		public bool resetLayersOnAwake = true;

		public int interactionPriority;

		public bool pipaExclusiveInteraction;

		public bool preventNestedGrabWhenUnGrabbed;

		public float coalAmount;

		public SnapPointTypes allowedSnapPointTypes;

		public ItemUseApproach itemUseApproach;

		public StorageType excludeFromStorageSerialization;

		public ItemType itemType = ItemType.SmallItem;

		[Header("Audio")]
		public AudioClip collision;

		public ItemCollisionSoundCategory itemCollisionSoundCategory;

		public ItemCollisionSoundCategory ignoredCollsionSoundCategory;

		public override InteractableTag InteractableTag => InteractableTag.Item;
	}
}
