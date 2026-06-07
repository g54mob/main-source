using DV;
using DV.Utils;
using UnityEngine;

[ExecuteAfter(typeof(CustomFirstPersonController))]
public class CameraDampening : MonoBehaviour
{
	public GameObject cameraGO;

	public AnimationCurve matchingCurve;

	[Range(0f, 30f)]
	public float angleDeviation;

	[Range(0f, 1f)]
	public float matchingLerp;

	[Range(0f, 1f)]
	public float dampingAmount;

	public float dampingAmountSmoothSpeed = 0.6f;

	public float matchingLerpSmoothSpeed = 0.3f;

	private float matchingLerpRefVel;

	private float dampingAmountRefVel;

	private Quaternion dampedRotation;

	protected virtual void OnEnable()
	{
		if (cameraGO == null)
		{
			Debug.LogError("CameraDampening doesn't have cameraGO assigned, disabling self", this);
			base.enabled = false;
		}
		else
		{
			dampedRotation = base.transform.rotation;
		}
	}

	protected virtual void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			base.transform.localRotation = Quaternion.identity;
		}
	}

	protected virtual float GetDamping()
	{
		return 1f;
	}

	protected virtual void Update()
	{
		if (TimeUtil.IsFlowing)
		{
			float damping = GetDamping();
			Quaternion quaternion = ((base.transform.parent == null) ? Quaternion.identity : base.transform.parent.rotation);
			angleDeviation = Quaternion.Angle(base.transform.rotation, quaternion);
			float target = matchingCurve.Evaluate(angleDeviation);
			matchingLerp = Mathf.SmoothDamp(matchingLerp, target, ref matchingLerpRefVel, matchingLerpSmoothSpeed);
			dampedRotation = Quaternion.Lerp(dampedRotation, quaternion, matchingLerp);
			dampingAmount = Mathf.SmoothDamp(dampingAmount, damping, ref dampingAmountRefVel, dampingAmountSmoothSpeed);
			Quaternion rotation = Quaternion.Lerp(quaternion, dampedRotation, dampingAmount);
			base.transform.rotation = rotation;
			Quaternion localRotation = base.transform.localRotation;
			Vector3 eulerAngles = localRotation.eulerAngles;
			eulerAngles.y = 0f;
			localRotation.eulerAngles = eulerAngles;
			base.transform.localRotation = localRotation;
		}
	}
}
