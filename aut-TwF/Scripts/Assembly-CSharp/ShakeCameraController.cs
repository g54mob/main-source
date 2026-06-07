using SmoothShakeFree;
using UnityEngine;

public class ShakeCameraController : MonoBehaviour
{
	[SerializeField]
	private SmoothShakeFreePreset defaultPreset;

	[SerializeField]
	private float minShakeAttDistance;

	[SerializeField]
	private float maxShakeAttDistance = 50f;

	[SerializeField]
	private AnimationCurve shakeAttCurve;

	private SmoothShake smoothShake;

	private void Awake()
	{
		smoothShake = GetComponent<SmoothShake>();
	}

	public void ShakeCamera(SmoothShakeFreePreset shakePreset, Vector3 shakeOrigin, float shakeForce)
	{
		Vector3 b = base.transform.position;
		if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, 200f, LayerMask.GetMask("Ground")))
		{
			b = base.transform.position + (hitInfo.point - base.transform.position) * 0.4f;
		}
		float num = Vector3.Distance(shakeOrigin, b);
		num = Mathf.Max(num - minShakeAttDistance, 0f);
		float num2 = shakeAttCurve.Evaluate(Mathf.Clamp01(num / maxShakeAttDistance));
		smoothShake.ShakeMultiplier = num2 * shakeForce;
		smoothShake.StartShake((shakePreset != null) ? shakePreset : defaultPreset);
	}

	public void ShakeCamera(SmoothShakeFreePreset shakePreset)
	{
		smoothShake.ShakeMultiplier = 1f;
		smoothShake.StartShake((shakePreset != null) ? shakePreset : defaultPreset);
	}

	public void StopShakeCamera(bool forceStop = false)
	{
		if (forceStop)
		{
			smoothShake.ForceStop();
		}
		else
		{
			smoothShake.StopShake();
		}
	}
}
