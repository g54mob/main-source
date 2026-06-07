using System.Collections;
using UnityEngine;

public class HJAFDrivenAnimation : MonoBehaviour
{
	[Tooltip("Optional")]
	public Animator animator;

	[Tooltip("A name of the parameter to control, found in \"Animator\" window")]
	public string floatParameterName = "Main";

	[Tooltip("GameObject where HingeJointAngleFix will appear after Start")]
	public GameObject hjafObject;

	public bool debugOverride;

	[Range(0f, 1f)]
	public float debugValue;

	private HingeJointAngleFix hjaf;

	private bool initialized;

	private IEnumerator Start()
	{
		if (!animator)
		{
			animator = GetComponent<Animator>();
		}
		animator.StopPlayback();
		yield return null;
		hjaf = hjafObject.GetComponent<HingeJointAngleFix>();
		initialized = true;
	}

	private void Update()
	{
		if (initialized)
		{
			float value = Mathf.Clamp(debugOverride ? debugValue : hjaf.Percentage, 0f, 0.999f);
			animator.SetFloat(floatParameterName, value);
		}
	}
}
