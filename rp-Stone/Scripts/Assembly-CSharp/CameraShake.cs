using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public bool debugMode;

	public float shakeAmount;

	public float shakeDuration;

	private float startAmount;

	private float startDuration;

	private bool isRunning;

	public bool smooth;

	public float smoothAmount = 5f;

	private float shakeAmountInFrame;

	public static CameraShake singleton { get; private set; }

	private void Awake()
	{
		singleton = this;
	}

	private void Start()
	{
	}

	private void Update()
	{
		shakeAmountInFrame = 0f;
	}

	public void ShakeCamera(float amount, float duration)
	{
		if (AdditionalSettings.isCameraShake && amount != shakeAmountInFrame)
		{
			shakeAmountInFrame = amount;
			shakeAmount += amount;
			startAmount = shakeAmount;
			shakeDuration = Mathf.Max(shakeDuration, duration);
			startDuration = shakeDuration;
			if (!isRunning)
			{
				StartCoroutine(Shake());
			}
		}
	}

	private IEnumerator Shake()
	{
		isRunning = true;
		while (shakeDuration > 0.01f)
		{
			Vector3 euler = Random.insideUnitSphere * shakeAmount;
			euler.z = 0f;
			float num = shakeDuration / startDuration;
			shakeAmount = startAmount * num * num;
			shakeDuration -= Utils.deltaTime;
			if (smooth)
			{
				base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, Quaternion.Euler(euler), Utils.deltaTime * smoothAmount);
			}
			else
			{
				base.transform.localRotation = Quaternion.Euler(euler);
			}
			yield return null;
		}
		base.transform.localRotation = Quaternion.identity;
		isRunning = false;
	}
}
