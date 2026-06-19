using System.Collections.Generic;
using UnityEngine;

public class RotationRestore : MonoBehaviour
{
	public Vector3 targetRotation;

	public bool debugDisable;

	private GameObject yReferenceObj;

	private RestoreProfile currentRestoreProfile;

	public float defaultMinimumCorrectionLimitVel;

	public float defaultMaximumCorrectionVal = 10f;

	public float defaultRestoreFlipMultiplier = 0.1f;

	public float defaultAgainstVelMultiplier;

	private float maxRotBase = 70f;

	private float bouncinessUpdateVelMax = 50f;

	private Dictionary<GameObject, float> bouncinessLowDict = new Dictionary<GameObject, float>();

	private Dictionary<GameObject, float> bouncinessHighDict = new Dictionary<GameObject, float>();

	private float defaultRestoreTorqueMultiplier = 30f;

	private float defaultUngroundedMultiplier;

	private float forcedRestorationOverrideMultiplier = 1f;

	private float forcedRestorationOverrideTimer;

	private bool hasTargetRotMod;

	private Vector3 targetRotMod = Vector3.zero;

	private Limb limbRef;

	private Rigidbody connectedRigidbody;

	private LegController controllerRef;

	private void Awake()
	{
		yReferenceObj = GetComponent<ConfigurableJoint>().connectedBody.gameObject;
		if (yReferenceObj.GetComponent<ConfigurableJoint>() != null)
		{
			yReferenceObj = yReferenceObj.GetComponent<ConfigurableJoint>().connectedBody.gameObject;
		}
		connectedRigidbody = yReferenceObj.GetComponent<Rigidbody>();
		targetRotation = base.transform.localEulerAngles;
		CreateRestoreProfile();
	}

	private void CreateRestoreProfile()
	{
		currentRestoreProfile = default(RestoreProfile);
		currentRestoreProfile.minimumCorrectionLimitVel = defaultMinimumCorrectionLimitVel;
		currentRestoreProfile.maximumCorrectionVal = defaultMaximumCorrectionVal;
		currentRestoreProfile.restoreFlipMultiplier = defaultRestoreFlipMultiplier;
		currentRestoreProfile.againstVelMultiplier = defaultAgainstVelMultiplier;
		currentRestoreProfile.restoreTorqueMultiplier = defaultRestoreTorqueMultiplier;
		currentRestoreProfile.ungroundedMultiplier = defaultUngroundedMultiplier;
	}

	private void CreateDebugRestoreProfile()
	{
		currentRestoreProfile = default(RestoreProfile);
		currentRestoreProfile.minimumCorrectionLimitVel = 0f;
		currentRestoreProfile.maximumCorrectionVal = 10f;
		currentRestoreProfile.restoreFlipMultiplier = 1f;
		currentRestoreProfile.againstVelMultiplier = 0.25f;
		currentRestoreProfile.restoreTorqueMultiplier = 30f;
		currentRestoreProfile.ungroundedMultiplier = 0.25f;
	}

	public void SetControllerRef(LegController controller)
	{
		controllerRef = controller;
	}

	public float GetDistanceFromTargetRotation()
	{
		return AngleUtil.GetDistanceFromRotation(GetCurrentRotation(), GetTargetRotation());
	}

	public Limb GetLimbRef()
	{
		if (limbRef == null)
		{
			limbRef = GetComponent<Limb>();
		}
		return limbRef;
	}

	public void AllowRestorationOverride(float timer)
	{
		forcedRestorationOverrideTimer = timer;
	}

	public void FixedUpdateRestore(Vector3 multiplier)
	{
		if (debugDisable)
		{
			return;
		}
		float num = multiplier.x;
		float num2 = multiplier.y;
		float num3 = multiplier.z;
		Vector3 targetRot = GetTargetRotation();
		Vector3 currentRotation = GetCurrentRotation();
		float angleDiff = AngleUtil.GetAngleDiff(currentRotation.x, targetRot.x);
		float angleDiff2 = AngleUtil.GetAngleDiff(currentRotation.y, targetRot.y);
		float angleDiff3 = AngleUtil.GetAngleDiff(currentRotation.z, targetRot.z);
		float limbStrength = GetLimbRef().GetLimbStrength();
		float num4 = maxRotBase * limbStrength;
		float num5 = maxRotBase * limbStrength;
		float num6 = maxRotBase * limbStrength;
		if (angleDiff * num > num4)
		{
			num = num4 / angleDiff;
		}
		if (angleDiff2 * num2 > num5)
		{
			num2 = num5 / angleDiff2;
		}
		if (angleDiff3 * num3 > num6)
		{
			num3 = num6 / angleDiff3;
		}
		bool num7 = controllerRef.IsLegGrounded(base.gameObject);
		if (!num7)
		{
			float num8 = currentRestoreProfile.ungroundedMultiplier;
			if (hasTargetRotMod)
			{
				num8 = 1f;
			}
			if (forcedRestorationOverrideTimer > 0f && Random.value >= 0.1f)
			{
				num8 = forcedRestorationOverrideMultiplier;
			}
			num *= num8;
			num2 *= num8;
			num3 *= num8;
		}
		if (forcedRestorationOverrideTimer > 0f)
		{
			forcedRestorationOverrideTimer -= Time.fixedDeltaTime;
		}
		Vector3 torque = PhysicalAnimationUtil.GetTorqueForTargetAngle(restoreSpeed: new Vector3(num, num2, num3), currentRot: currentRotation, targetRot: targetRot, dampingMultiplier: currentRestoreProfile.restoreTorqueMultiplier);
		Vector3 vector = RelativeAngularVelocity();
		if (!num7)
		{
			if ((vector.x > 0f && torque.x < 0f) || (vector.x < 0f && torque.x > 0f))
			{
				torque = ((!(vector.x > 0f - currentRestoreProfile.minimumCorrectionLimitVel) || !(vector.x < currentRestoreProfile.minimumCorrectionLimitVel) || !(Mathf.Abs(vector.x) < currentRestoreProfile.minimumCorrectionLimitVel)) ? new Vector3((0f - torque.x) * currentRestoreProfile.restoreFlipMultiplier, torque.y, torque.z) : new Vector3(torque.x * currentRestoreProfile.againstVelMultiplier, torque.y, torque.z));
			}
			if ((vector.y > 0f && torque.y < 0f) || (vector.y < 0f && torque.y > 0f))
			{
				torque = ((!(vector.y > 0f - currentRestoreProfile.minimumCorrectionLimitVel) || !(vector.y < currentRestoreProfile.minimumCorrectionLimitVel) || !(Mathf.Abs(vector.y) < currentRestoreProfile.minimumCorrectionLimitVel)) ? new Vector3(torque.x, (0f - torque.y) * currentRestoreProfile.restoreFlipMultiplier, torque.z) : new Vector3(torque.x, torque.y * currentRestoreProfile.againstVelMultiplier, torque.z));
			}
			if ((vector.z > 0f && torque.z < 0f) || (vector.z < 0f && torque.z > 0f))
			{
				torque = ((!(vector.z > 0f - currentRestoreProfile.minimumCorrectionLimitVel) || !(vector.z < currentRestoreProfile.minimumCorrectionLimitVel) || !(Mathf.Abs(vector.z) < currentRestoreProfile.minimumCorrectionLimitVel)) ? new Vector3(torque.x, torque.y, (0f - torque.z) * currentRestoreProfile.restoreFlipMultiplier) : new Vector3(torque.x, torque.y, torque.z * currentRestoreProfile.againstVelMultiplier));
			}
		}
		if (vector.magnitude > currentRestoreProfile.maximumCorrectionVal)
		{
			torque = Vector3.zero;
		}
		controllerRef.TorqueLeg(base.gameObject, torque, applyLimbCompensation: false, modifyLegStrength: true, restoreTension: false, rawTorque: false, useTorqueDamping: true, useFuckedUpTorqueDamping: false, dampX: false);
	}

	private Vector3 RelativeAngularVelocity()
	{
		return base.transform.InverseTransformVector(connectedRigidbody.angularVelocity);
	}

	private void UpdateSpringiness()
	{
		for (int i = 0; i < base.transform.parent.childCount; i++)
		{
			GameObject gameObject = base.transform.parent.GetChild(i).gameObject;
			SoftJointLimit lowAngularXLimit = gameObject.GetComponent<ConfigurableJoint>().lowAngularXLimit;
			SoftJointLimit highAngularXLimit = gameObject.GetComponent<ConfigurableJoint>().highAngularXLimit;
			if (!bouncinessLowDict.ContainsKey(gameObject))
			{
				bouncinessLowDict[gameObject] = lowAngularXLimit.bounciness;
				bouncinessHighDict[gameObject] = highAngularXLimit.bounciness;
			}
			float curValue = bouncinessUpdateVelMax - Mathf.Clamp(RelativeAngularVelocity().magnitude, 0f, bouncinessUpdateVelMax);
			lowAngularXLimit.bounciness = bouncinessLowDict[gameObject] * MathUtil.GetDampPercentage(curValue, 0f, bouncinessUpdateVelMax, 0f, 1f);
			highAngularXLimit.bounciness = bouncinessHighDict[gameObject] * MathUtil.GetDampPercentage(curValue, 0f, bouncinessUpdateVelMax, 0f, 1f);
			gameObject.GetComponent<ConfigurableJoint>().lowAngularXLimit = lowAngularXLimit;
			gameObject.GetComponent<ConfigurableJoint>().highAngularXLimit = highAngularXLimit;
		}
	}

	private Vector3 GetCurrentRotation()
	{
		return base.transform.eulerAngles;
	}

	public void SetTargetRotMod(Vector3 newMod)
	{
		targetRotMod = newMod;
		hasTargetRotMod = true;
	}

	public void ClearTargetRotMod()
	{
		hasTargetRotMod = false;
		targetRotMod = Vector3.zero;
	}

	private Vector3 GetTargetRotation()
	{
		return new Vector3(targetRotation.x, yReferenceObj.transform.eulerAngles.y, targetRotation.z) + targetRotMod;
	}
}
