using System;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabHandlerItem : AGrabHandler
	{
		private const float THROW_FORCE_PER_KG = 140f;

		private ICustomNonVRGrabAnchor customGrabAnchor;

		public Transform forcedDropAnchor;

		public override bool IsItem => true;

		public event Action ItemUsed;

		public event Action ItemUnUsed;

		private void Awake()
		{
			customGrabAnchor = GetComponent<ICustomNonVRGrabAnchor>();
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			Transform attachPoint = grabbedBy.Cursor.Rig.GetAttachPoint();
			AttachToAttachPoint(attachPoint, positionStays: false);
			var (localPosition, localRotation) = GetAnchorOffsets();
			base.transform.localPosition = localPosition;
			base.transform.localRotation = localRotation;
		}

		public (Vector3 attachPosition, Quaternion attachRotation) GetItemWorldAttachPositionAndRotation(Transform attachPoint)
		{
			if (attachPoint == null)
			{
				Debug.LogError("GrabHandlerItem: Cannot determine world attach position and rotation, attach point is null. Returning anchor offsets.", this);
				return GetAnchorOffsets();
			}
			(Vector3 anchorPositionOffset, Quaternion anchorRotationOffset) anchorOffsets = GetAnchorOffsets();
			Vector3 item = anchorOffsets.anchorPositionOffset;
			Quaternion item2 = anchorOffsets.anchorRotationOffset;
			Vector3 item3 = attachPoint.TransformPoint(item);
			Quaternion item4 = attachPoint.rotation * item2;
			return (attachPosition: item3, attachRotation: item4);
		}

		private (Vector3 anchorPositionOffset, Quaternion anchorRotationOffset) GetAnchorOffsets()
		{
			if (customGrabAnchor != null)
			{
				return customGrabAnchor.GetGrabAnchor();
			}
			return (anchorPositionOffset: Vector3.zero, anchorRotationOffset: Quaternion.identity);
		}

		public void AttachToAttachPoint(Transform attachPoint, bool positionStays)
		{
			TogglePhysics(on: false);
			base.transform.SetParent(attachPoint, positionStays);
		}

		public override void EndInteraction()
		{
			base.transform.parent = null;
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

		public override void Throw(Vector3 direction)
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.AddForce(direction * component.mass * 140f);
			}
		}

		public override void Use()
		{
			base.IsUsed = true;
			this.ItemUsed?.Invoke();
		}

		public override void UnUse()
		{
			if (base.IsUsed)
			{
				base.IsUsed = false;
				this.ItemUnUsed?.Invoke();
			}
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
