using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	[SerializeField]
	private float shakeForce = 1f;

	[SerializeField]
	private float shakeSpeed = 1f;

	[SerializeField]
	private float shakeDamping = 1f;

	[SerializeField]
	private float delay = 1f;

	private Transform cameraParent;

	private Coroutine shakeCoroutine;

	private void Awake()
	{
		cameraParent = base.transform.parent;
	}

	public void Shake(float shakeForce, float shakeSpeed, float shakeDamping, float delay = 0f)
	{
		this.StartCoroutineCheckingVar(ShakeCoroutine(shakeForce, shakeSpeed, shakeDamping, delay), ref shakeCoroutine, stopCoroutineIfRunning: true);
	}

	public void Shake()
	{
		this.StartCoroutineCheckingVar(ShakeCoroutine(shakeForce, shakeSpeed, shakeDamping, delay), ref shakeCoroutine, stopCoroutineIfRunning: true);
	}

	private IEnumerator ShakeCoroutine(float shakeForce, float shakeSpeed, float shakeDamping, float delay)
	{
		yield return new WaitForSeconds(delay);
		float initShakeForce = shakeForce;
		_ = Quaternion.identity;
		Quaternion startRotation = cameraParent.transform.localRotation;
		int dir = 1;
		Quaternion nextRotation = startRotation * Quaternion.AngleAxis(shakeForce, cameraParent.transform.up);
		while (shakeForce > 0f)
		{
			shakeForce -= Time.deltaTime * shakeDamping;
			if (Quaternion.Angle(cameraParent.transform.localRotation, nextRotation) == 0f)
			{
				dir *= -1;
				nextRotation = startRotation * Quaternion.AngleAxis((float)dir * shakeForce, Quaternion.AngleAxis(Random.Range(-90, 90), cameraParent.transform.forward) * cameraParent.transform.up);
			}
			cameraParent.transform.localRotation = Quaternion.RotateTowards(cameraParent.transform.localRotation, nextRotation, shakeSpeed * shakeForce / initShakeForce * Time.deltaTime);
			yield return null;
		}
		cameraParent.transform.localRotation = startRotation;
		shakeCoroutine = null;
	}
}
