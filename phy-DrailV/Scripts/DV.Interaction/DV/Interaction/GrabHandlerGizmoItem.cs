using System;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabHandlerGizmoItem : AGrabHandler
	{
		[NonSerialized]
		public bool carryingPosition;

		private Transform oldParent;

		private ICustomNonVRGrabAnchor customGrabAnchor;

		public override bool IsItem => false;

		private void Awake()
		{
			customGrabAnchor = GetComponent<ICustomNonVRGrabAnchor>();
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			oldParent = base.transform.parent;
			Transform attachPoint = grabbedBy.Cursor.Rig.GetAttachPoint();
			AttachToAttachPoint(attachPoint, positionStays: true);
			if (carryingPosition)
			{
				if (customGrabAnchor != null)
				{
					(base.transform.localPosition, base.transform.localRotation) = customGrabAnchor.GetGrabAnchor();
				}
				else
				{
					base.transform.localPosition = Vector3.zero;
					base.transform.localRotation = Quaternion.identity;
				}
			}
		}

		public void AttachToAttachPoint(Transform attachPoint, bool positionStays)
		{
			TogglePhysics(on: false);
			base.transform.SetParent(attachPoint, positionStays);
		}

		public override void EndInteraction()
		{
			base.transform.parent = oldParent;
			base.EndInteraction();
			TogglePhysics(on: true);
		}

		public override void FeedPosition(Vector3 worldPosition)
		{
		}

		public override Vector3 GetAnchor()
		{
			return Vector3.zero;
		}

		public override Vector3 GetAxis()
		{
			return Vector3.zero;
		}

		public override bool AllowPickupAndThrow()
		{
			return true;
		}

		public void TogglePhysics(bool on)
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.isKinematic = !on;
			}
		}
	}
}
