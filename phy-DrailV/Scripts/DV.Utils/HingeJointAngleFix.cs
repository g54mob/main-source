using UnityEngine;

public class HingeJointAngleFix : MonoBehaviour
{
	public HingeJoint joint;

	public bool invertPercentage;

	private bool useLocalSpace;

	private Vector3 axis;

	private float angleOffset;

	private float angleRange;

	private Quaternion startRotationInverse;

	private int lastFrameCount = -1;

	private float cachedAngle;

	private float cachedPercentage;

	private Vector3 startLocalPosition;

	private Quaternion startLocalRotation;

	private Vector3 onDisableLocalPosition;

	private Quaternion onDisableLocalRotation;

	public float Angle
	{
		get
		{
			Recalculate();
			return cachedAngle;
		}
	}

	public float Percentage
	{
		get
		{
			Recalculate();
			return cachedPercentage;
		}
	}

	private void Recalculate()
	{
		int frameCount = Time.frameCount;
		if (frameCount != lastFrameCount)
		{
			lastFrameCount = frameCount;
			Quaternion quaternion = (useLocalSpace ? base.transform.localRotation : base.transform.rotation);
			(startRotationInverse * quaternion).ToAngleAxis(out cachedAngle, out var rhs);
			cachedAngle *= Mathf.Sign(Vector3.Dot(axis, rhs));
			if (cachedAngle < -180f)
			{
				cachedAngle += 360f;
			}
			else if (cachedAngle > 180f)
			{
				cachedAngle -= 360f;
			}
			cachedPercentage = (cachedAngle - angleOffset) / angleRange;
			if (invertPercentage)
			{
				cachedPercentage = 1f - cachedPercentage;
			}
		}
	}

	private void Awake()
	{
		if (!joint)
		{
			joint = GetComponent<HingeJoint>();
		}
		if (!joint)
		{
			Debug.LogError("HingeJointAngleFix added to gameobject that doesn't have a HingeJoint, auto-removing the component now.", base.gameObject);
			Object.Destroy(this);
			return;
		}
		useLocalSpace = joint.connectedBody;
		axis = joint.axis;
		bool useLimits = joint.useLimits;
		JointLimits jointLimits = (useLimits ? joint.limits : default(JointLimits));
		angleOffset = (useLimits ? jointLimits.min : (-180f));
		angleRange = (useLimits ? (jointLimits.max - jointLimits.min) : 360f);
		Quaternion rotation = (useLocalSpace ? base.transform.localRotation : base.transform.rotation);
		startRotationInverse = Quaternion.Inverse(rotation);
		startLocalRotation = (onDisableLocalRotation = base.transform.localRotation);
		startLocalPosition = (onDisableLocalPosition = base.transform.localPosition);
	}

	private void OnDisable()
	{
		onDisableLocalRotation = base.transform.localRotation;
		base.transform.localRotation = startLocalRotation;
		onDisableLocalPosition = base.transform.localPosition;
		base.transform.localPosition = startLocalPosition;
	}

	private void OnDestroy()
	{
		base.transform.localPosition = onDisableLocalPosition;
		base.transform.localRotation = onDisableLocalRotation;
	}

	private void OnEnable()
	{
		base.transform.localRotation = onDisableLocalRotation;
		base.transform.localPosition = onDisableLocalPosition;
	}
}
