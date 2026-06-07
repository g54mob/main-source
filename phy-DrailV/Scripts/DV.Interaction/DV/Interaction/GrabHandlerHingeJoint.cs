using UnityEngine;

namespace DV.Interaction
{
	public class GrabHandlerHingeJoint : AGrabHandler
	{
		private const float REFERENCE_ANGLE_INVERSE = 1f / 90f;

		public bool resetTargetPositionOnUngrab;

		public bool invertFeedValueDirection;

		private HingeJoint hj;

		private float startTargetPosition;

		private Vector3 startLocalPositionInParent;

		private float newTargetPosition;

		private bool isMovingDisabled;

		private float hingeAngle;

		public override bool IsItem => false;

		protected override void Start()
		{
			base.Start();
			hj = GetComponent<HingeJoint>();
			if (!hj)
			{
				Debug.LogError("GrabHandlerHingeJoint couldn't find a HingeJoint", this);
			}
			else if (hj.useLimits)
			{
				hingeAngle = hj.limits.max - hj.limits.min;
			}
			else
			{
				hingeAngle = 90f;
			}
			base.enabled = false;
		}

		public override Vector3 GetAnchor()
		{
			return hj.anchor;
		}

		public override Vector3 GetAxis()
		{
			return hj.axis;
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			startLocalPositionInParent = WorldToParentLocal(startWorldPosition);
			startTargetPosition = (newTargetPosition = hj.spring.targetPosition);
			base.enabled = true;
		}

		public override void FeedPosition(Vector3 worldPosition)
		{
			Vector3 anchor = GetAnchor();
			Vector3 axis = GetAxis();
			Vector3 vector = base.transform.InverseTransformPoint(ParentLocalToWorld(startLocalPositionInParent)) - anchor;
			Vector3 vector2 = base.transform.InverseTransformPoint(worldPosition) - anchor;
			Debug.DrawLine(base.transform.TransformPoint(anchor), base.transform.TransformPoint(vector), Color.green);
			Debug.DrawLine(base.transform.TransformPoint(anchor), base.transform.TransformPoint(vector2), Color.blue);
			float num = Vector3.SignedAngle(vector, vector2, axis);
			newTargetPosition = startTargetPosition + num;
			if (newTargetPosition > 180f)
			{
				newTargetPosition -= 360f;
			}
			else if (newTargetPosition < -180f)
			{
				newTargetPosition += 360f;
			}
		}

		public override void FeedValue(float value)
		{
			newTargetPosition += value * (float)((!invertFeedValueDirection) ? 1 : (-1)) * hingeAngle * (1f / 90f);
			newTargetPosition = Mathf.Clamp(newTargetPosition, hj.spring.targetPosition - 90f, hj.spring.targetPosition + 90f);
			if (hj.useLimits)
			{
				newTargetPosition = Mathf.Clamp(newTargetPosition, hj.limits.min, hj.limits.max);
			}
			if (newTargetPosition > 180f)
			{
				newTargetPosition -= 360f;
			}
			else if (newTargetPosition < -180f)
			{
				newTargetPosition += 360f;
			}
		}

		public override bool AllowFeedValue()
		{
			return true;
		}

		public override void EndInteraction()
		{
			base.EndInteraction();
			if (resetTargetPositionOnUngrab)
			{
				ResetSpring();
				ResetSpring();
				ResetSpring();
			}
			base.enabled = false;
		}

		private void ResetSpring()
		{
			JointSpring spring = hj.spring;
			spring.targetPosition = 0f;
			newTargetPosition = 0f;
			hj.spring = spring;
		}

		private void FixedUpdate()
		{
			if (!isMovingDisabled)
			{
				JointSpring spring = hj.spring;
				spring.targetPosition = newTargetPosition;
				hj.spring = spring;
			}
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

		public void SetMovingDisabled(bool disabled)
		{
			isMovingDisabled = disabled;
		}
	}
}
