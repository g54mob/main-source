using DV.VRTK_Extensions;
using UnityEngine;

public class LineHandSnapper : AHandPoseSnapper
{
	public Transform lineStart;

	public float lineLength = 1f;

	public float minAngle;

	public float maxAngle = 360f;

	private bool justGrabbed;

	private float polarity;

	public override bool HoldPosition => true;

	public override Transform HoldTransform => lineStart;

	private void Awake()
	{
		if (lineStart == null)
		{
			Debug.LogError("LineHandSnapper component on " + base.gameObject.name + " has no lineStart assigned, can't work without it!", this);
		}
	}

	public override void EnterInteraction(VRTK_HandPoseController_DV _)
	{
		justGrabbed = true;
	}

	public override Vector3 AdjustPosition(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		return VectorUtils.ClosestPointOnLine(lineStart.position, lineStart.TransformPoint(Vector3.up * lineLength), sourcePosition);
	}

	public override Quaternion AdjustRotation(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		Vector3 normalized = (lineStart.position + Vector3.Project(handRoot - lineStart.position, lineStart.up) - handRoot).normalized;
		Vector3 normalized2 = (lineStart.position - lineStart.TransformPoint(Vector3.up * lineLength)).normalized;
		if (justGrabbed)
		{
			justGrabbed = false;
			Vector3 lhs = Vector3.Cross(sourceForward, sourceUp);
			polarity = Mathf.Sign(Vector3.Dot(lhs, normalized2));
		}
		float num = Vector3.SignedAngle(normalized, lineStart.right, normalized2);
		if (polarity < 0f)
		{
			num += 180f;
		}
		num *= polarity;
		num = ClampAngle(num, minAngle, maxAngle);
		num *= polarity;
		Vector3 direction = Quaternion.AngleAxis(num, Vector3.up) * Vector3.right;
		direction = lineStart.TransformDirection(direction);
		direction *= polarity;
		normalized2 *= polarity;
		Vector3 upwards = -Vector3.Cross(normalized2, -direction);
		if (!(direction == Vector3.zero))
		{
			return Quaternion.LookRotation(direction, upwards);
		}
		return Quaternion.identity;
	}

	private static float ClampAngle(float current, float min, float max)
	{
		float num = Mathf.Abs((min - max + 180f) % 360f - 180f) * 0.5f;
		float target = min + num;
		float num2 = Mathf.Abs(Mathf.DeltaAngle(current, target)) - num;
		if (num2 > 0f)
		{
			current = Mathf.MoveTowardsAngle(current, target, num2);
		}
		return current;
	}

	private void OnDrawGizmosSelected()
	{
		if (!(lineStart == null))
		{
			Vector3 position = lineStart.position;
			Vector3 vector = lineStart.TransformPoint(Vector3.up * lineLength);
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(position, vector);
			Gizmos.DrawSphere(position, 0.01f);
			Gizmos.DrawSphere(vector, 0.01f);
		}
	}
}
