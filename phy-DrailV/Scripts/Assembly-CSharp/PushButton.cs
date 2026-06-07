using System;
using System.Collections;
using DV.Utils;
using UnityEngine;

public class PushButton : MonoBehaviour
{
	public float pushStrength = 0.5f;

	public AudioClip sound;

	private ConfigurableJoint joint;

	private void Start()
	{
		joint = GetComponent<ConfigurableJoint>();
		if (joint == null)
		{
			throw new Exception("PushButton needs a ConfigurableJoint");
		}
		if (joint.linearLimit.limit == 0f)
		{
			Debug.LogError("Joint linear limit is 0, you have to set it");
		}
		if (!sound)
		{
			Debug.LogWarning("Joint has no sound assigned");
		}
		SetJointTargetPosition(pushStrength);
	}

	private void SetJointTargetPosition(float value)
	{
		joint.targetPosition = new Vector3(0f, 0f, value);
		GetComponent<Rigidbody>().WakeUp();
	}

	public void Push()
	{
		SetJointTargetPosition(0f - pushStrength);
		sound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.cabGroup);
		StartCoroutine(ToRestingPosition());
	}

	private IEnumerator ToRestingPosition()
	{
		yield return WaitFor.Seconds(0.1f);
		SetJointTargetPosition(pushStrength);
	}
}
