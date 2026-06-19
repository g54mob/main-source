using UnityEngine;

public class PhysicalAnimationUtil : MonoBehaviour
{
	private static float angleDiffMin = 5f;

	private static float angleDiffMax = 80f;

	private static float torqueDampMin = 1f;

	private static float torqueDampMax = 0f;

	public static Vector3 GetTorqueForTargetAngle(Vector3 currentRot, Vector3 targetRot, Vector3 restoreSpeed, float dampingMultiplier)
	{
		if (restoreSpeed.x > 1f || restoreSpeed.y > 1f || restoreSpeed.z > 1f || restoreSpeed.x < 0f || restoreSpeed.y < 0f || restoreSpeed.z < 0f)
		{
			Debug.LogWarning("This will not do what you think it will. Please keep restoreSpeed capped between 0 and 1.");
		}
		return GetDampedTorque(newAngle: new Vector3(Mathf.LerpAngle(currentRot.x, targetRot.x, restoreSpeed.x), Mathf.LerpAngle(currentRot.y, targetRot.y, restoreSpeed.y), Mathf.LerpAngle(currentRot.z, targetRot.z, restoreSpeed.z)), referenceAngle: currentRot, targetAngle: targetRot, dampingMultiplier: dampingMultiplier);
	}

	private static Vector3 GetDampedTorque(Vector3 referenceAngle, Vector3 newAngle, Vector3 targetAngle, float dampingMultiplier)
	{
		if (referenceAngle == newAngle)
		{
			return Vector3.zero;
		}
		Vector3 vector = new Vector3(GetDampedRotationForAxisValue(referenceAngle.x, targetAngle.x), GetDampedRotationForAxisValue(referenceAngle.y, targetAngle.y), GetDampedRotationForAxisValue(referenceAngle.z, targetAngle.z));
		vector *= dampingMultiplier;
		return new Vector3(AngleUtil.AngleSubtract(newAngle.x, referenceAngle.x) * vector.x, AngleUtil.AngleSubtract(newAngle.y, referenceAngle.y) * vector.y, AngleUtil.AngleSubtract(newAngle.z, referenceAngle.z) * vector.z);
	}

	private static float GetDampedRotationForAxisValue(float referenceVal, float targetVal)
	{
		float angleDiff = AngleUtil.GetAngleDiff(referenceVal, targetVal);
		if (angleDiff <= angleDiffMin)
		{
			return 0f;
		}
		angleDiff -= angleDiffMin;
		angleDiff = Mathf.Min(angleDiffMax, angleDiff);
		return (torqueDampMax + (torqueDampMin - torqueDampMax)) * (angleDiff / angleDiffMax);
	}
}
