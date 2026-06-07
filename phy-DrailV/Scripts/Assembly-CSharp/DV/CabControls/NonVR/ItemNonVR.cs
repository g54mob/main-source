using System;
using System.Collections.Generic;
using DV.CabControls.Spec;
using DV.Interaction;
using DV.Items.Snapping;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class ItemNonVR : ItemBase
	{
		[NonSerialized]
		public bool isHoverableWhileHeld;

		private GrabHandlerItem grabHandler;

		private HashSet<Collider> triggerColliders = new HashSet<Collider>();

		public override bool IsTwoHanded => false;

		public override void AssignForceDropAnchor(Transform forceDropTransform)
		{
			grabHandler.forcedDropAnchor = forceDropTransform;
		}

		protected override void Setup()
		{
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerItem>(base.gameObject, base.SpecItem.colliderGameObjects);
			if (useApproach != ItemUseApproach.None)
			{
				isHoverableWhileHeld = true;
				grabHandler.isUsable = true;
				grabHandler.continuousUse = useApproach == ItemUseApproach.Continuous;
			}
			grabHandler.Grabbed += OnGrabbed;
			grabHandler.UnGrabbed += OnUnGrabbed;
		}

		private void OnGrabbed()
		{
			ItemSnapPointBase itemSnapPointBase = (base.IsSnapped ? base.SnappableItem.SnappedTo : null);
			if (itemSnapPointBase != null)
			{
				itemSnapPointBase.UnsnapItem();
			}
			FireGrabbed();
			GameObject[] colliderGameObjects = base.SpecItem.colliderGameObjects;
			for (int i = 0; i < colliderGameObjects.Length; i++)
			{
				Collider[] components = colliderGameObjects[i].GetComponents<Collider>();
				foreach (Collider collider in components)
				{
					if (collider.isTrigger)
					{
						triggerColliders.Add(collider);
					}
					else
					{
						collider.isTrigger = true;
					}
				}
			}
			grabHandler.ItemUsed += Use;
			grabHandler.ItemUnUsed += UnUse;
		}

		private void OnUnGrabbed()
		{
			FireUngrabbed();
			GameObject[] colliderGameObjects = base.SpecItem.colliderGameObjects;
			for (int i = 0; i < colliderGameObjects.Length; i++)
			{
				Collider[] components = colliderGameObjects[i].GetComponents<Collider>();
				foreach (Collider collider in components)
				{
					if (!triggerColliders.Contains(collider))
					{
						collider.isTrigger = false;
					}
				}
			}
			triggerColliders.Clear();
			grabHandler.ItemUsed -= Use;
			grabHandler.ItemUnUsed -= UnUse;
		}

		protected override void AddItemReparenting()
		{
			base.gameObject.AddComponent<ItemReparentingNonVR>();
		}

		public override bool IsGrabbed()
		{
			if (grabHandler != null)
			{
				return grabHandler.IsGrabbed();
			}
			return false;
		}

		public override void ForceEndInteraction()
		{
			grabHandler.ForceEndInteraction();
		}
	}
}
