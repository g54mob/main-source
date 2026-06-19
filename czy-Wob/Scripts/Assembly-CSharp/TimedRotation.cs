using UnityEngine;

public class TimedRotation
{
	public Vector3 testTarget;

	public float testRotationTime;

	private GameObject associatedObject;

	private float currentTime;

	private float targetRotationTime;

	private float maxRot = 75f;

	private float dampingMultiplier = 12f;

	private Vector3 motionMultiplier;

	private Vector3 rotationSpeed;

	private Vector3 targetRotation;

	private bool isLimb;

	private bool hasStarted;

	private bool considerX = true;

	private bool considerY = true;

	private bool considerZ = true;

	private int numGroundedLegsRequired;

	private SmartMotion.MotionFinishedCallback storedCallback;

	private GameObject yReferenceObj;

	private LegController controllerRef;

	public TimedRotation(GameObject obj)
	{
		associatedObject = obj;
		ConfigurableJoint component = associatedObject.GetComponent<ConfigurableJoint>();
		if (component != null)
		{
			yReferenceObj = component.connectedBody.gameObject;
		}
		InitializeTimedRotation(testTarget, testRotationTime);
	}

	public void SetController(LegController newRef)
	{
		controllerRef = newRef;
	}

	public void SetIsLimb(bool value)
	{
		isLimb = value;
	}

	public void InitializeTimedRotation(Vector3 rot, float rotationTime, bool considerX = true, bool considerY = false, bool considerZ = true, int numGroundedLegsRequired = 0)
	{
		currentTime = 0f;
		targetRotationTime = rotationTime;
		targetRotation = rot;
		this.considerX = considerX;
		this.considerY = considerY;
		this.considerZ = considerZ;
		this.numGroundedLegsRequired = numGroundedLegsRequired;
		rotationSpeed = new Vector3(maxRot, maxRot, maxRot);
	}

	public void StartTimedRotation(SmartMotion.MotionFinishedCallback callback, Vector3 motionMultiplier)
	{
		hasStarted = true;
		storedCallback = callback;
		this.motionMultiplier = motionMultiplier;
	}

	private void FinishMotion()
	{
		hasStarted = false;
		storedCallback();
		storedCallback = null;
	}

	public void FixedUpdate()
	{
		if (hasStarted && currentTime < targetRotationTime)
		{
			FixedUpdateTorque();
		}
	}

	public void FixedUpdateTorque()
	{
		currentTime += Time.fixedDeltaTime;
		if (numGroundedLegsRequired > 0 && controllerRef.GetNumberOfGroundedLegs() < numGroundedLegsRequired)
		{
			if (currentTime >= targetRotationTime)
			{
				FinishMotion();
			}
			return;
		}
		Vector3 vector = GetTargetRotation();
		Vector3 currentRotation = GetCurrentRotation();
		Vector3 targetRot = new Vector3(Mathf.LerpAngle(currentRotation.x, vector.x, currentTime / targetRotationTime), Mathf.LerpAngle(currentRotation.y, vector.y, currentTime / targetRotationTime), Mathf.LerpAngle(currentRotation.z, vector.z, currentTime / targetRotationTime));
		float angleDiff = AngleUtil.GetAngleDiff(currentRotation.x, targetRot.x);
		float angleDiff2 = AngleUtil.GetAngleDiff(currentRotation.y, targetRot.y);
		float angleDiff3 = AngleUtil.GetAngleDiff(currentRotation.z, targetRot.z);
		float num = ((!isLimb) ? controllerRef.GetBodyStrength(associatedObject) : controllerRef.GetLimbStrength(associatedObject));
		float num2 = rotationSpeed.x * num;
		float num3 = rotationSpeed.y * num;
		float num4 = rotationSpeed.z * num;
		float num5 = 1f;
		float num6 = 1f;
		float num7 = 1f;
		if (angleDiff > num2)
		{
			num5 = num2 / angleDiff;
		}
		if (angleDiff2 > num3)
		{
			num6 = num3 / angleDiff2;
		}
		if (angleDiff3 > num4)
		{
			num7 = num4 / angleDiff3;
		}
		num5 *= motionMultiplier.x;
		num6 *= motionMultiplier.y;
		num7 *= motionMultiplier.z;
		Vector3 torque = PhysicalAnimationUtil.GetTorqueForTargetAngle(restoreSpeed: new Vector3(num5, num6, num7), currentRot: currentRotation, targetRot: targetRot, dampingMultiplier: dampingMultiplier);
		if (isLimb)
		{
			controllerRef.TorqueLeg(associatedObject, torque, applyLimbCompensation: false, modifyLegStrength: true, restoreTension: true, rawTorque: false, useTorqueDamping: false);
		}
		else
		{
			controllerRef.TorqueBody(associatedObject, torque, applyLimbCompensation: false, modifyLegStrength: true, useTorqueDamping: false);
		}
		if (currentTime >= targetRotationTime)
		{
			FinishMotion();
		}
	}

	private Vector3 GetCurrentRotation()
	{
		return associatedObject.transform.eulerAngles;
	}

	private Vector3 GetTargetRotation()
	{
		float x = targetRotation.x;
		float y = targetRotation.y;
		float z = targetRotation.z;
		Vector3 eulerAngles = associatedObject.transform.eulerAngles;
		if (!considerX)
		{
			x = eulerAngles.x;
		}
		if (!considerY)
		{
			y = ((!isLimb) ? eulerAngles.y : yReferenceObj.transform.eulerAngles.y);
		}
		if (!considerZ)
		{
			z = eulerAngles.z;
		}
		return new Vector3(x, y, z);
	}
}
