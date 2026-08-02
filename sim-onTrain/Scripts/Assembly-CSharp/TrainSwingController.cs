using UnityEngine;

public class TrainSwingController : MonoBehaviour
{
	[Header("Train Reference")]
	[Tooltip("Otomatik bulunur, manuel set edilebilir")]
	public TrainController trainController;

	[Header("Speed Settings")]
	[Tooltip("Maksimum hız değeri (TrainController'dan alınır)")]
	public float maxSpeed = 2f;

	[Header("Roll Settings (Z Axis - Sağa/Sola)")]
	[Tooltip("Maksimum roll açısı (derece)")]
	[Range(0f, 3f)]
	public float maxRollAngle = 0.8f;

	[Tooltip("Roll sallanma hızı")]
	[Range(0.1f, 2f)]
	public float rollFrequency = 0.4f;

	[Header("Vertical Settings (Y Axis - Yukarı/Aşağı)")]
	[Tooltip("Maksimum dikey hareket (metre)")]
	[Range(0f, 0.1f)]
	public float maxVerticalOffset = 0.015f;

	[Tooltip("Dikey titreşim hızı (ray birleşim simülasyonu)")]
	[Range(1f, 10f)]
	public float verticalFrequency = 4f;

	[Header("Smoothing")]
	[Tooltip("Efektlerin ne kadar yumuşak başlayacağı")]
	[Range(0.5f, 5f)]
	public float smoothSpeed = 2f;

	[Tooltip("Sallanmanın başlaması için minimum hız yüzdesi")]
	[Range(0f, 0.3f)]
	public float minSpeedThreshold = 0.05f;

	private float currentSpeed;

	private float smoothedIntensity;

	private Quaternion originalLocalRotation;

	private Vector3 originalLocalPosition;

	private bool isInitialized;

	private float noiseOffsetRoll;

	private float noiseOffsetVertical;

	private float noiseOffsetRoll2;

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		originalLocalRotation = base.transform.localRotation;
		originalLocalPosition = base.transform.localPosition;
		noiseOffsetRoll = (float)base.transform.GetSiblingIndex() * 100f;
		noiseOffsetVertical = (float)base.transform.GetSiblingIndex() * 100f + 50f;
		noiseOffsetRoll2 = (float)base.transform.GetSiblingIndex() * 100f + 25f;
		if (trainController == null)
		{
			trainController = GetComponentInParent<TrainController>();
			if (trainController == null)
			{
				trainController = Object.FindObjectOfType<TrainController>();
			}
		}
		if (trainController != null)
		{
			maxSpeed = trainController.maxSpeed;
		}
		isInitialized = true;
	}

	private void FixedUpdate()
	{
		if (!isInitialized)
		{
			Initialize();
			return;
		}
		if (trainController != null)
		{
			currentSpeed = trainController.GetCurrentSpeed();
		}
		float num = Mathf.Clamp01(currentSpeed / maxSpeed);
		float b = 0f;
		if (num > minSpeedThreshold)
		{
			b = Mathf.Pow(num, 1.5f);
		}
		smoothedIntensity = Mathf.Lerp(smoothedIntensity, b, Time.fixedDeltaTime * smoothSpeed);
		if (smoothedIntensity < 0.01f)
		{
			base.transform.localRotation = originalLocalRotation;
			return;
		}
		float time = Time.time;
		float num2 = Mathf.PerlinNoise(time * rollFrequency + noiseOffsetRoll, 0f) * 2f - 1f;
		float num3 = Mathf.PerlinNoise(time * rollFrequency * 2.3f + noiseOffsetRoll2, 0f) * 2f - 1f;
		float num4 = num2 * 0.7f + num3 * 0.3f;
		float num5 = 1f + num * 0.5f;
		float z = num4 * maxRollAngle * smoothedIntensity;
		float num6 = Mathf.PerlinNoise(time * verticalFrequency * num5 + noiseOffsetVertical, 0.5f) * 2f - 1f;
		float num7 = ((Mathf.PerlinNoise(time * 0.5f + noiseOffsetVertical, 1f) > 0.8f) ? 1.5f : 1f);
		_ = maxVerticalOffset;
		_ = smoothedIntensity;
		Quaternion quaternion = Quaternion.Euler(0f, 0f, z);
		base.transform.localRotation = originalLocalRotation * quaternion;
	}

	public void UpdateSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void SetSpawnTime(float time)
	{
	}

	public void ResetSwing()
	{
		smoothedIntensity = 0f;
		if (isInitialized)
		{
			base.transform.localRotation = originalLocalRotation;
		}
	}

	private void OnDisable()
	{
		if (isInitialized)
		{
			base.transform.localRotation = originalLocalRotation;
		}
	}
}
