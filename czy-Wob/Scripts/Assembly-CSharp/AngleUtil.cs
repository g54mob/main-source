using UnityEngine;

public class AngleUtil : MonoBehaviour
{
	public static float GetDistanceFromRotation(Vector3 currentRot, Vector3 targetRot)
	{
		return Quaternion.Angle(Quaternion.Euler(currentRot), Quaternion.Euler(targetRot));
	}

	public static float AngleSubtract(float a, float b)
	{
		a %= 360f;
		b %= 360f;
		float num = a - b;
		if (num > 180f)
		{
			num -= 360f;
		}
		else if (num < -180f)
		{
			num += 360f;
		}
		return num;
	}

	public static float GetAngleDiff(float a, float b)
	{
		float num = Mathf.Abs(a - b);
		if (num >= 180f)
		{
			num = Mathf.Abs(num - 360f);
		}
		return num;
	}

	public static float GetHalfAngleDiff(float a, float b)
	{
		float num = Mathf.Abs(a - b);
		if (num >= 90f)
		{
			num = Mathf.Abs(num - 180f);
		}
		return num;
	}

	public static float GetYFacingAngle(Transform targetToFace, Transform actor)
	{
		return GetYFacingAngle(targetToFace.position, actor.position);
	}

	public static float GetYFacingAngle(Vector3 targetPos, Transform actor)
	{
		return GetYFacingAngle(targetPos, actor.position);
	}

	public static float GetYFacingAngle(Vector3 targetPos, Vector3 actorPos)
	{
		Vector3 vector = actorPos - targetPos;
		float num = Mathf.Atan2(vector.z, vector.x);
		return 0f - 57.29578f * num;
	}

	public static float GetPositiveBoundAngle(float angle)
	{
		if (angle >= 0f && angle <= 360f)
		{
			return angle;
		}
		while (angle < 0f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle %= 360f;
		}
		return angle;
	}

	public static float GetPositiveBoundHalfAngle(float angle)
	{
		if (angle >= 0f && angle <= 180f)
		{
			return angle;
		}
		while (angle < 0f)
		{
			angle += 180f;
		}
		if (angle > 180f)
		{
			angle %= 180f;
		}
		return angle;
	}
}
