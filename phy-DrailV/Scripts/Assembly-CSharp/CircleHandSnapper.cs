using System;
using DV.VRTK_Extensions;
using UnityEngine;

public class CircleHandSnapper : AHandPoseSnapper
{
	public Transform centerUpward;

	public float radius = 0.5f;

	private bool justGrabbed;

	private bool flipped;

	public override bool HoldPosition => true;

	public override Transform HoldTransform => centerUpward;

	private void Awake()
	{
		if (centerUpward == null)
		{
			Debug.LogError("CircleHandSnapper component on " + base.gameObject.name + " has no centerUpward assigned, can't work without it!", this);
		}
	}

	public override void EnterInteraction(VRTK_HandPoseController_DV handPoseController)
	{
		justGrabbed = true;
	}

	public override Vector3 AdjustPosition(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		Vector3 position = centerUpward.position;
		Vector3 position2 = centerUpward.InverseTransformPoint(sourcePosition);
		position2.y = 0f;
		position2 = centerUpward.TransformPoint(position2);
		return position + (position2 - position).normalized * radius;
	}

	public override Quaternion AdjustRotation(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		Vector3 position = centerUpward.position;
		Vector3 position2 = centerUpward.InverseTransformPoint(sourcePosition);
		position2.y = 0f;
		position2 = centerUpward.TransformPoint(position2);
		if (position2 == position)
		{
			position2.x += 0.001f;
		}
		Vector3 vector = position + (position2 - position).normalized * radius;
		Vector3 vector2 = Vector3.Cross((vector - position).normalized, centerUpward.up) * (rightHand ? 1f : (-1f));
		if (justGrabbed)
		{
			justGrabbed = false;
			flipped = Vector3.Dot(vector2, sourceRotation * Vector3.right) > 0f;
			if (!rightHand)
			{
				flipped = !flipped;
			}
		}
		if (flipped)
		{
			vector2 = -vector2;
		}
		Vector3 vector3 = VectorUtils.ProjectPointLine(vector, handRoot, handRoot + vector2);
		Vector3 normalized = (vector - vector3).normalized;
		Vector3 vector4 = -Vector3.Cross(vector2, -normalized);
		if (!rightHand)
		{
			vector4 = -vector4;
		}
		if (!(normalized == Vector3.zero))
		{
			return Quaternion.LookRotation(normalized, vector4);
		}
		return Quaternion.identity;
	}

	private void OnDrawGizmosSelected()
	{
		if (!(centerUpward == null))
		{
			Gizmos.color = Color.cyan;
			Vector3 position = centerUpward.position;
			Vector3 forward = centerUpward.forward;
			Vector3 right = centerUpward.right;
			Vector3 vector = position + right * radius;
			for (int i = 1; i <= 16; i++)
			{
				Vector3 vector2 = position + Mathf.Cos((float)i / 16f * (float)Math.PI * 2f) * radius * right + Mathf.Sin((float)i / 16f * (float)Math.PI * 2f) * radius * forward;
				Gizmos.DrawLine(vector, vector2);
				vector = vector2;
			}
			Gizmos.DrawLine(position - right * radius, position + right * radius);
			Gizmos.DrawLine(position - forward * radius, position + forward * radius);
			Gizmos.DrawSphere(position, 0.01f);
		}
	}
}
