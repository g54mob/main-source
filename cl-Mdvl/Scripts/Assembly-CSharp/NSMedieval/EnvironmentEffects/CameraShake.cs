using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class CameraShake : MonoBehaviour
	{
		[SerializeField]
		public Transform camTransform;

		private readonly Dictionary<CameraShakeStrength, ShakeStrength> cameraShakeStrengths = new Dictionary<CameraShakeStrength, ShakeStrength>();

		private readonly ShakeStrength weakShakeStrength = new ShakeStrength(20f, 10f, 0.2f, 0.02f);

		private readonly ShakeStrength mildShakeStrength = new ShakeStrength(70f, 25f, 0.32f, 0.12f);

		private readonly ShakeStrength strongShakeStrength = new ShakeStrength(160f, 60f, 0.85f, 0.35f);

		private readonly ShakeStrength blueprintStrength = new ShakeStrength(200f, 60f, 0.18f, 0.1f);

		private float maxCameraDistance;

		private float minCameraDistance;

		private float maxCameraShakeDuration;

		private float currentShakeDuration;

		private float shakeAmount;

		private Vector3 originalPos;

		private bool shakeStarted;

		private float shakeDuration;

		private float shakeAmountDampingStep;

		private float currentShakeAmount;

		private float maxCameraShake;

		private float shakeFrequency = 16f;

		private float elapsedTime;

		private Vector3 startPosition;

		private Vector3 targetPosition;

		private void OnEnable()
		{
			originalPos = camTransform.localPosition;
			MonoSingleton<CameraManager>.Instance.CameraShakeEvent += SetupCameraShake;
		}

		private void OnDisable()
		{
			MonoSingleton<CameraManager>.Instance.CameraShakeEvent -= SetupCameraShake;
		}

		private void SetupCameraShake(Vector3 eventPosition, CameraShakeStrength shakeStrength)
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraShake)
			{
				return;
			}
			float num = Vector3.Distance(eventPosition, base.transform.position);
			if (!(num > cameraShakeStrengths[shakeStrength].MaxCameraDistance))
			{
				ResetShake();
				SetCameraShakeParameters(cameraShakeStrengths[shakeStrength]);
				float num2 = Mathf.Clamp(num, minCameraDistance, maxCameraDistance);
				if (shakeStrength == CameraShakeStrength.Blueprint)
				{
					shakeAmount = maxCameraShake;
					currentShakeDuration = maxCameraShakeDuration;
				}
				else
				{
					shakeAmount = (maxCameraDistance - num2) * (maxCameraShake / (maxCameraDistance - minCameraDistance));
					currentShakeDuration = (maxCameraDistance - num2) * (maxCameraShakeDuration / (maxCameraDistance - minCameraDistance));
				}
			}
		}

		private void SetCameraShakeParameters(ShakeStrength shakeStrength)
		{
			maxCameraDistance = shakeStrength.MaxCameraDistance;
			minCameraDistance = shakeStrength.MinCameraDistance;
			maxCameraShakeDuration = shakeStrength.MaxCameraShakeDuration;
			maxCameraShake = shakeStrength.MaxCameraShake;
		}

		private void Update()
		{
			if (camTransform == null)
			{
				return;
			}
			if (currentShakeDuration > 0f)
			{
				if (!shakeStarted)
				{
					shakeDuration = currentShakeDuration;
					currentShakeAmount = shakeAmount;
					shakeAmountDampingStep = shakeAmount / shakeDuration;
					shakeStarted = true;
					startPosition = camTransform.localPosition;
					targetPosition = originalPos + Random.insideUnitSphere * currentShakeAmount;
					elapsedTime = 0f;
				}
				elapsedTime += Time.unscaledDeltaTime;
				if (elapsedTime >= 1f / shakeFrequency)
				{
					startPosition = camTransform.localPosition;
					targetPosition = originalPos + Random.insideUnitSphere * currentShakeAmount;
					elapsedTime = 0f;
				}
				float t = elapsedTime * shakeFrequency;
				camTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
				currentShakeAmount -= shakeAmountDampingStep * Time.unscaledDeltaTime;
				currentShakeDuration -= Time.unscaledDeltaTime;
			}
			else
			{
				ResetShake();
			}
		}

		private void ResetShake()
		{
			currentShakeDuration = 0f;
			camTransform.localPosition = originalPos;
			shakeStarted = false;
		}

		private void Awake()
		{
			cameraShakeStrengths.Add(CameraShakeStrength.Weak, weakShakeStrength);
			cameraShakeStrengths.Add(CameraShakeStrength.Mild, mildShakeStrength);
			cameraShakeStrengths.Add(CameraShakeStrength.Strong, strongShakeStrength);
			cameraShakeStrengths.Add(CameraShakeStrength.Blueprint, blueprintStrength);
		}
	}
}
