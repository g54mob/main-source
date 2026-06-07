using UnityEngine;

namespace DV.Interaction
{
	public class GrabHandlerGizmo : AGrabHandler
	{
		private Vector3 startLocalPositionInParent;

		public float maxDistanceFromStart = 1.3f;

		public override bool IsItem => false;

		protected override void Start()
		{
			base.Start();
			base.enabled = false;
		}

		public override Vector3 GetAnchor()
		{
			return Vector3.zero;
		}

		public override Vector3 GetAxis()
		{
			return Vector3.right;
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			startLocalPositionInParent = WorldToParentLocal(startWorldPosition);
		}

		public override void FeedPosition(Vector3 worldPosition)
		{
			Vector3 vector = ParentLocalToWorld(startLocalPositionInParent);
			Vector3 vector2 = worldPosition - vector;
			if (Vector3.SqrMagnitude(vector2) > maxDistanceFromStart * maxDistanceFromStart)
			{
				base.transform.position = vector + vector2.normalized * maxDistanceFromStart;
			}
			else
			{
				base.transform.position = worldPosition;
			}
		}

		public override void EndInteraction()
		{
			base.EndInteraction();
			base.enabled = false;
		}

		private Vector3 WorldToParentLocal(Vector3 worldPos)
		{
			if (base.transform.parent == null)
			{
				return worldPos;
			}
			return base.transform.parent.InverseTransformPoint(worldPos);
		}

		private Vector3 ParentLocalToWorld(Vector3 localInParent)
		{
			if (base.transform.parent == null)
			{
				return localInParent;
			}
			return base.transform.parent.TransformPoint(localInParent);
		}

		public override bool AllowPickupAndThrow()
		{
			return false;
		}
	}
}
