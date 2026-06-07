using System;
using System.Collections;
using UnityEngine;

public class RotaryAmplitudeChecker : MonoBehaviour
{
	public const int MIN_REACHED = -1;

	public const int NEUTRAL_REACHED = 0;

	public const int MAX_REACHED = 1;

	public float checkThreshold = 2f;

	public float checkPeriod = 0.2f;

	private HingeJoint joint;

	private HingeJointAngleFix jointAngleFix;

	private bool insideMinAmplitudeRange;

	private bool insideMaxAmplitudeRange;

	public event Action<int> RotaryStateChanged;

	private void Start()
	{
		joint = base.gameObject.GetComponent<HingeJoint>();
		jointAngleFix = base.gameObject.GetComponent<HingeJointAngleFix>();
		if (!jointAngleFix)
		{
			jointAngleFix = base.gameObject.AddComponent<HingeJointAngleFix>();
		}
		insideMinAmplitudeRange = false;
		insideMaxAmplitudeRange = false;
	}

	private void OnEnable()
	{
		StartCoroutine(CheckAmplitudeReached(checkPeriod));
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private IEnumerator CheckAmplitudeReached(float timeout)
	{
		while (joint == null || jointAngleFix == null)
		{
			yield return WaitFor.Seconds(timeout);
		}
		while (true)
		{
			yield return WaitFor.Seconds(timeout);
			if (!insideMinAmplitudeRange && jointAngleFix.Angle <= joint.limits.min + checkThreshold)
			{
				this.RotaryStateChanged?.Invoke(-1);
				insideMinAmplitudeRange = true;
				insideMaxAmplitudeRange = false;
			}
			else if (!insideMaxAmplitudeRange && jointAngleFix.Angle >= joint.limits.max - checkThreshold)
			{
				this.RotaryStateChanged?.Invoke(1);
				insideMaxAmplitudeRange = true;
				insideMinAmplitudeRange = false;
			}
			else if ((insideMinAmplitudeRange || insideMaxAmplitudeRange) && jointAngleFix.Angle < joint.limits.max - checkThreshold && jointAngleFix.Angle > joint.limits.min + checkThreshold)
			{
				this.RotaryStateChanged?.Invoke(0);
				insideMaxAmplitudeRange = false;
				insideMinAmplitudeRange = false;
			}
		}
	}
}
