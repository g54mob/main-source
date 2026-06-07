using System;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabHandlerPuller : AGrabHandler
	{
		private const float INV_SPEED_MULT = 0.0027777778f;

		public bool invertFeedValueDirection;

		private Vector3 startPullerLocalPositionInParent;

		private Vector3 startInteractionLocalPositionInParent;

		private ConfigurableJoint cj;

		private float YlimitMin;

		private float YlimitMax;

		private float deltaY;

		public override bool IsItem => false;

		public event Action<Vector3> PositionChanged;

		protected override void Start()
		{
			base.Start();
			cj = GetComponent<ConfigurableJoint>();
			if (!cj)
			{
				Debug.LogError("GrabHandlerPuller couldn't find a ConfigurableJoint", this);
			}
			float limit = cj.linearLimit.limit;
			YlimitMin = -2f * limit;
			YlimitMax = 0f;
			base.enabled = false;
		}

		public override Vector3 GetAnchor()
		{
			return cj.anchor;
		}

		public override Vector3 GetAxis()
		{
			return cj.axis;
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			startInteractionLocalPositionInParent = WorldToParentLocal(startWorldPosition);
			startPullerLocalPositionInParent = base.transform.localPosition;
			base.enabled = true;
			deltaY = startPullerLocalPositionInParent.y;
		}

		public override void FeedPosition(Vector3 worldPosition)
		{
			Vector3 vector = WorldToParentLocal(worldPosition);
			float y = (startInteractionLocalPositionInParent - vector).y;
			float y2 = Mathf.Clamp(startPullerLocalPositionInParent.y - y, YlimitMin, YlimitMax);
			Vector3 position = base.transform.position;
			base.transform.localPosition = new Vector3(startPullerLocalPositionInParent.x, y2, startPullerLocalPositionInParent.z);
			this.PositionChanged?.Invoke(position);
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

		public override void FeedValue(float value)
		{
			deltaY += value * 0.0027777778f * (float)((!invertFeedValueDirection) ? 1 : (-1));
			float y = Mathf.Clamp(startPullerLocalPositionInParent.y - deltaY, YlimitMin, YlimitMax);
			Vector3 position = base.transform.position;
			base.transform.localPosition = new Vector3(startPullerLocalPositionInParent.x, y, startPullerLocalPositionInParent.z);
			this.PositionChanged?.Invoke(position);
		}

		public override bool AllowFeedValue()
		{
			return true;
		}
	}
}
