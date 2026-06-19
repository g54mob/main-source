using UnityEngine;

public class Stabilizer : MonoBehaviour
{
	public Vector3 stabilityMultiplier = Vector3.one;

	private Vector3 additionalStabilityMultiplier = Vector3.one;

	private float curveTime;

	private bool isFollowingCurve;

	private AnimationCurveWrapper stabilityCurveX;

	private AnimationCurveWrapper stabilityCurveZ;

	private float ungroundedMixupLimit = 5f;

	private float ungroundedMixupMult = 5f;

	private float groundedTime;

	private float requiredGroundedTime = 0.25f;

	private float timeSinceLastGrounded;

	private float lastGroundedWindow = 0.1f;

	private float timeSinceAnyFootLastGrounded;

	private float anyFootLastGroundedWindow = 0.25f;

	private float anyFootLastGroundedCancelStepWindow = 0.1f;

	private float maxGroundedCheckVelocity = 10f;

	private Vector3 targetRotation;

	private float minDampPercentageX = 1f;

	private float minDampPercentageZ = 1f;

	private float maxDampPercentage = 1f;

	private float currentDampPercentageX;

	private float bodyTorqueMultiplier = 1.25f;

	private float bodyTorqueMultiplierRuckus = 6f;

	private Vector3 minAngleDiff = new Vector3(1f, 0f, 1f);

	private Vector3 maxAngleDiff = new Vector3(75f, 0f, 75f);

	private float currentMinXAngle;

	private float standardXMult = 1f;

	private float standardZMult = 1f;

	private float x;

	private float z;

	private float curveValX;

	private float curveValZ;

	private Vector3 curveTorque = Vector3.zero;

	private string footName = "foot";

	private GameObject foot;

	private bool pauseFootTorque;

	private bool bodyMovementAllowed = true;

	private bool isLockingBodyStability;

	private bool isMakingRuckus;

	private bool hasLockedSteps;

	private Color stabilityColor = new Color(0f, 1f, 0f);

	private Rigidbody bodyRB;

	private GameObject bodySegment;

	private ConfigurableJoint jointRef;

	private LegController controllerRef;

	private bool initialized;

	private bool debugVis;

	private void Awake()
	{
		targetRotation += Vector3.zero;
		foot = base.transform.parent.Find(footName).gameObject;
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 30f);
		animationCurve.AddKey(0.25f, 50f);
		animationCurve.AddKey(0.5f, 0f);
		AnimationCurve animationCurve2 = new AnimationCurve();
		animationCurve2.AddKey(0f, 30f);
		animationCurve2.AddKey(0.25f, 50f);
		animationCurve2.AddKey(0.5f, 0f);
		stabilityCurveX = new AnimationCurveWrapper(animationCurve);
		stabilityCurveZ = new AnimationCurveWrapper(animationCurve2);
		timeSinceAnyFootLastGrounded = anyFootLastGroundedWindow;
		timeSinceLastGrounded = lastGroundedWindow;
		jointRef = GetComponent<ConfigurableJoint>();
	}

	public void SetLegController(LegController controller)
	{
		controllerRef = controller;
	}

	public void PauseFootTorque()
	{
		pauseFootTorque = true;
	}

	public void UnpauseFootTorque()
	{
		pauseFootTorque = false;
	}

	public void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			bodyRB = controllerRef.GetBodySegmentForLeg(base.gameObject).GetComponent<Rigidbody>();
		}
	}

	public void SetBodySegment(GameObject segment)
	{
		bodySegment = segment;
	}

	public void RequestRuckus()
	{
		isMakingRuckus = true;
	}

	public void RequestRuckusEnd()
	{
		isMakingRuckus = false;
	}

	public void Update()
	{
		UpdateGroundedInfo();
	}

	public void FixedUpdate()
	{
		if (isFollowingCurve)
		{
			FollowCurve();
		}
	}

	private void UpdateGroundedInfo()
	{
		if (!(controllerRef == null))
		{
			if (controllerRef.AnyLegGrounded())
			{
				timeSinceAnyFootLastGrounded = 0f;
			}
			else
			{
				timeSinceAnyFootLastGrounded += Time.deltaTime;
			}
			if (ObjectStatusUtil.CheckObjectGrounded(foot, 0.01f, controllerRef.transform.localScale.x))
			{
				timeSinceLastGrounded = 0f;
			}
			else
			{
				timeSinceLastGrounded += Time.deltaTime;
			}
		}
	}

	public void FixedUpdateStabilize(bool xLocked = false, bool zLocked = false)
	{
		if (!(xLocked && zLocked) && !isFollowingCurve && !(bodyRB.angularVelocity.magnitude > maxGroundedCheckVelocity) && !(bodyRB.velocity.magnitude > maxGroundedCheckVelocity) && !(timeSinceAnyFootLastGrounded > anyFootLastGroundedWindow) && !(timeSinceLastGrounded <= lastGroundedWindow))
		{
			currentMinXAngle = minAngleDiff.x;
			currentDampPercentageX = minDampPercentageX;
			bodyMovementAllowed = true;
			float num = 0f;
			float num2 = 0f;
			Vector3 eulerAngles = bodySegment.transform.eulerAngles;
			if (!xLocked && ShouldFollowCurve(eulerAngles.x, targetRotation.x, minAngleDiff.x, maxAngleDiff.x))
			{
				num = standardXMult;
				num2 = standardZMult;
			}
			else if (!zLocked && ShouldFollowCurve(eulerAngles.z, targetRotation.z, minAngleDiff.z, maxAngleDiff.z))
			{
				num = standardXMult / 2f;
				num2 = standardZMult;
			}
			if (AngleUtil.AngleSubtract(eulerAngles.z, targetRotation.z) * stabilityMultiplier.z > 0f)
			{
				num2 *= -1f;
			}
			if (num != 0f || num2 != 0f)
			{
				TakeStep(num, num2);
			}
		}
	}

	public void TakeStep(float x, float z)
	{
		isFollowingCurve = true;
		additionalStabilityMultiplier = new Vector3(x, 0f, z);
		if (isMakingRuckus)
		{
			hasLockedSteps = true;
			controllerRef.LockStabilitySteps();
		}
		if (debugVis)
		{
			GetComponent<Limb>().ShadeLimb(stabilityColor, debugOverride: true);
		}
	}

	private void EndStep()
	{
		curveTime = 0f;
		groundedTime = 0f;
		isFollowingCurve = false;
		if (isLockingBodyStability)
		{
			isLockingBodyStability = false;
			controllerRef.UnlockBodyStability();
		}
		if (hasLockedSteps)
		{
			hasLockedSteps = false;
			controllerRef.UnlockStabilitySteps();
		}
		if (debugVis)
		{
			GetComponent<Limb>().RemoverShade(debugOverride: true);
		}
	}

	private bool ShouldFollowCurve(float currentValue, float targetValue, float minDiff, float maxDiff)
	{
		float angleDiff = AngleUtil.GetAngleDiff(currentValue, targetValue);
		if (angleDiff <= minDiff || angleDiff > maxDiff)
		{
			return false;
		}
		return true;
	}

	private void FollowCurve()
	{
		curveValX = CurveUtil.EvaluateAverageCurveWrapperTime(stabilityCurveX, curveTime, curveTime - Time.fixedDeltaTime);
		curveValZ = CurveUtil.EvaluateAverageCurveWrapperTime(stabilityCurveZ, curveTime, curveTime - Time.fixedDeltaTime);
		Vector3 eulerAngles = bodySegment.transform.eulerAngles;
		x = curveValX * MathUtil.GetDampPercentage(Mathf.Abs(AngleUtil.GetAngleDiff(eulerAngles.x, targetRotation.x)), 0f, currentMinXAngle, currentDampPercentageX, maxDampPercentage);
		z = curveValZ * MathUtil.GetDampPercentage(Mathf.Abs(AngleUtil.GetAngleDiff(eulerAngles.z, targetRotation.z)), 0f, minAngleDiff.z, minDampPercentageZ, maxDampPercentage);
		if (!isMakingRuckus && controllerRef.IsLegGrounded(controllerRef.GetParallelLeg(base.gameObject)))
		{
			x *= -0.5f;
		}
		if (!isMakingRuckus && timeSinceLastGrounded > ungroundedMixupLimit && Random.value > 0.01f)
		{
			z *= ungroundedMixupMult;
			if (Random.value > 0.5f)
			{
				z *= -1f;
			}
		}
		curveTorque = new Vector3(x * stabilityMultiplier.x * additionalStabilityMultiplier.x, 0f, z * stabilityMultiplier.z * additionalStabilityMultiplier.z);
		controllerRef.TorqueLeg(base.gameObject, curveTorque, applyLimbCompensation: true, modifyLegStrength: true, restoreTension: true, rawTorque: false, isMakingRuckus, useFuckedUpTorqueDamping: true);
		if (!pauseFootTorque)
		{
			controllerRef.TorqueBody(foot, curveTorque, applyLimbCompensation: true, modifyLegStrength: false, useTorqueDamping: true, rawTorque: false, useFuckedUpTorqueDamping: true);
		}
		if (isMakingRuckus)
		{
			curveTorque *= bodyTorqueMultiplierRuckus;
		}
		else
		{
			curveTorque *= bodyTorqueMultiplier;
		}
		if (!controllerRef.IsBodyStabilityLocked())
		{
			isLockingBodyStability = true;
			controllerRef.LockBodyStability(curveTorque);
		}
		if (bodyMovementAllowed && isLockingBodyStability)
		{
			if (!isMakingRuckus)
			{
				controllerRef.StabilizeBody(controllerRef.bodyFront, 45f);
				controllerRef.StabilizeBody(controllerRef.bodyBack, 45f);
			}
			else
			{
				controllerRef.TorqueBody(bodySegment, curveTorque, applyLimbCompensation: true, modifyLegStrength: false, useTorqueDamping: true, rawTorque: false, useFuckedUpTorqueDamping: true);
			}
		}
		if (ObjectStatusUtil.CheckObjectGrounded(foot, 0.01f, controllerRef.transform.localScale.x))
		{
			groundedTime += Time.fixedDeltaTime;
		}
		else
		{
			groundedTime = 0f;
		}
		curveTime += Time.fixedDeltaTime;
		if (curveTime >= stabilityCurveX.GetTotalTime() || groundedTime >= requiredGroundedTime || timeSinceAnyFootLastGrounded > anyFootLastGroundedCancelStepWindow)
		{
			EndStep();
		}
	}
}
