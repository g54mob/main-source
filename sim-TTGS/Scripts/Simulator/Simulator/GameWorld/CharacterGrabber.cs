using UnityEngine;

namespace Simulator.GameWorld
{
	public class CharacterGrabber : CharacterComponent, IGrabber, IGiver
	{
		[SerializeField]
		private Transform m_grabAnchor;

		[SerializeField]
		private LayerMask m_collisionLayerMask;

		private IGrabbable m_grabbable;

		protected IGrabbable CurrentGrabbable => m_grabbable;

		public Transform GrabAnchor => m_grabAnchor;

		public ClippingObjectBehaviour.ELayerType ClippingLayerType => ClippingObjectBehaviour.ELayerType.NO_CLIPPING;

		public bool CanGrab(IGrabbable grabbable)
		{
			return CurrentGrabbable == null;
		}

		public bool Grab(IGrabbable grabbable)
		{
			if (CanGrab(grabbable) && (CurrentGrabbable == null || Drop(out var _)))
			{
				m_grabbable = grabbable;
				OnGrab(grabbable);
				grabbable.OnGrabbedBy(this);
				return true;
			}
			return false;
		}

		public IGrabbable GetGrabbable()
		{
			return CurrentGrabbable;
		}

		public bool HasGrabbable(out IGrabbable grabbable)
		{
			grabbable = CurrentGrabbable;
			return grabbable != null;
		}

		public bool Drop(out IGrabbable grabbable)
		{
			if (CurrentGrabbable != null && CurrentGrabbable.CanBeDropped() && FindDropPosition(out var worldPosition))
			{
				grabbable = CurrentGrabbable;
				OnDrop(CurrentGrabbable);
				CurrentGrabbable.OnDroppedBy(this, worldPosition);
				m_grabbable = null;
				return true;
			}
			grabbable = null;
			return false;
		}

		public bool FindDropPosition(out Vector3 worldPosition)
		{
			if (IsValidToDrop(0f, out worldPosition))
			{
				return true;
			}
			for (int i = 1; i < 6; i++)
			{
				float num = 30f * (float)i;
				if (IsValidToDrop(num, out worldPosition))
				{
					return true;
				}
				num = 0f - num;
				if (IsValidToDrop(num, out worldPosition))
				{
					return true;
				}
			}
			worldPosition = base.transform.parent.position + new Vector3(0f, -0.3f, 0f);
			return true;
		}

		private bool IsValidToDrop(float angle, out Vector3 worldPosition)
		{
			Vector3 direction = Quaternion.Euler(0f, angle, 0f) * base.transform.forward;
			Vector3 position = Quaternion.Euler(0f, angle, 0f) * base.transform.localPosition;
			worldPosition = base.transform.parent.TransformPoint(position);
			return !Physics.Raycast(base.transform.parent.position, direction, 0.5f, m_collisionLayerMask, QueryTriggerInteraction.Ignore);
		}

		public bool CanGive(out IGrabbable grabbable)
		{
			grabbable = CurrentGrabbable;
			return grabbable != null;
		}

		public IGrabbable GiveTo(IGrabber grabber)
		{
			IGrabbable currentGrabbable = CurrentGrabbable;
			if (CurrentGrabbable != null)
			{
				OnGive(CurrentGrabbable);
				CurrentGrabbable.OnGivenBy(this);
				m_grabbable = null;
				if (grabber != null)
				{
					currentGrabbable.OnGivenTo(grabber);
				}
			}
			return currentGrabbable;
		}

		protected virtual void OnGrab(IGrabbable grabbable)
		{
			grabbable.transform.Anchor(GrabAnchor);
			if (grabbable.GrabbableData != null)
			{
				grabbable.transform.SetLocalPositionAndRotation(grabbable.GrabbableData.GrabAnchor.LocalPosition, grabbable.GrabbableData.GrabAnchor.LocalRotation);
			}
		}

		protected virtual void OnDrop(IGrabbable grabbable)
		{
			grabbable.transform.SetParent(null);
		}

		protected virtual void OnGive(IGrabbable grabbable)
		{
			grabbable.transform.SetParent(null);
		}
	}
}
