using DV.CabControls.Spec;
using UnityEngine;

public class HingeJointDrivenTransformAdjuster : MonoBehaviour
{
	private const int SEARCH_FRAMES_MAX = 5;

	[Header("Controller")]
	public ControlSpec control;

	public bool flipDirection;

	[Header("Target")]
	public Transform target;

	[Header("Markers")]
	public Transform positionA;

	public Transform positionB;

	private HingeJointAngleFix joint;

	private int searchAttempts = 5;

	private void Awake()
	{
		if (control == null)
		{
			Debug.LogError("'control' field is not assigned on HingeJointDrivenTransformAdjuster (" + base.gameObject.name + "), can't work without it!", this);
			base.enabled = false;
		}
	}

	private void OnEnable()
	{
		if (joint == null)
		{
			searchAttempts = 5;
		}
	}

	private void Update()
	{
		if (joint == null)
		{
			joint = control.GetComponent<HingeJointAngleFix>();
			if (joint == null)
			{
				searchAttempts--;
				if (searchAttempts <= 0)
				{
					base.enabled = false;
					Debug.LogError("HingeJointAngleFix wasn't instantiated in time, HingeJointDrivenTransformAdjuster (" + base.gameObject.name + ") can't work without it!", this);
				}
				return;
			}
		}
		float num = joint.Percentage;
		if (flipDirection)
		{
			num = 1f - num;
		}
		target.localPosition = Vector3.Lerp(positionA.localPosition, positionB.localPosition, num);
		target.localRotation = Quaternion.Slerp(positionA.localRotation, positionB.localRotation, num);
	}
}
