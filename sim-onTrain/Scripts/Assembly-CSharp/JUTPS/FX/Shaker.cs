using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Shaker")]
	public class Shaker : MonoBehaviour
	{
		public Transform ShakeTarget;

		[Range(0f, 60f)]
		public float MaxAngle = 5f;

		[Range(0f, 1f)]
		public float ShakeIntensity = 1f;

		[Range(0f, 20f)]
		public float ShakeStartIntensity = 3f;

		[Range(0f, 20f)]
		public float ShakeEndIntensity = 3f;

		[Range(0f, 20f)]
		public float ShakeSpeed = 2f;

		private float CurrentTime;

		private float ShakeDuration;

		public bool AwaysShaking;

		private float CurrentShakeIntensity;

		[HideInInspector]
		public bool IsShaking;

		private float CoordX;

		private float CoordY;

		private float CoordZ;

		private float RotX;

		private float RotY;

		private float RotZ;

		private Vector3 ShakingEulerRotation;

		private static Shaker currentCameraInstance;

		public Vector3 GetShakeLocalEulerRotation => ShakingEulerRotation;

		public Quaternion GetShakeLocalRotation => Quaternion.Euler(ShakingEulerRotation);

		private void Start()
		{
			CoordX = Random.Range(-1000, 1000);
			CoordY = Random.Range(-1000, 1000);
			CoordZ = Random.Range(-1000, 1000);
			if (ShakeTarget == null)
			{
				ShakeTarget = base.transform;
			}
		}

		private void Update()
		{
			CurrentShakeIntensity = Mathf.Clamp(CurrentShakeIntensity, 0f, 1f);
			float num = CurrentShakeIntensity * CurrentShakeIntensity;
			float time = Time.time * ShakeSpeed;
			RotX = ShakeIntensity * num * MaxAngle * PerlinNoise(CoordX, time);
			RotY = ShakeIntensity * num * MaxAngle * PerlinNoise(CoordY, time);
			RotZ = ShakeIntensity * num * MaxAngle * PerlinNoise(CoordZ, time);
			ShakingEulerRotation.Set(RotX, RotY, RotZ);
			ShakeTarget.localEulerAngles = ShakingEulerRotation;
			if (!AwaysShaking)
			{
				if (IsShaking)
				{
					StartShaking();
				}
				else
				{
					EndShaking();
				}
			}
			else
			{
				StartShaking();
			}
			if (CurrentTime < ShakeDuration)
			{
				CurrentTime += Time.deltaTime;
				IsShaking = true;
			}
			else
			{
				IsShaking = false;
			}
		}

		private void EndShaking()
		{
			CurrentShakeIntensity -= ShakeEndIntensity * Time.deltaTime;
		}

		private void StartShaking()
		{
			CurrentShakeIntensity += ShakeStartIntensity * Time.deltaTime;
		}

		public static Shaker GetCurrentCameraInstance()
		{
			if (currentCameraInstance == null)
			{
				if (Camera.current != null)
				{
					currentCameraInstance = Camera.current.GetComponent<Shaker>();
					return currentCameraInstance;
				}
				Debug.LogWarning("Camera Current no found");
				return null;
			}
			if (Camera.current != null && Camera.current != currentCameraInstance.GetComponent<Camera>())
			{
				currentCameraInstance = Camera.current.GetComponent<Shaker>();
				return currentCameraInstance;
			}
			return currentCameraInstance;
		}

		public void Shake(float Speed = 3f, float Duration = 0.5f, float StartIntensity = 15f, float EndIntensity = 3f, float MaxRotationAngle = 5f, float Intensity = 1f)
		{
			CurrentTime = 0f;
			ShakeSpeed = Speed;
			ShakeDuration = Duration;
			ShakeStartIntensity = StartIntensity;
			ShakeEndIntensity = EndIntensity;
			MaxAngle = MaxRotationAngle;
			ShakeIntensity = Intensity;
		}

		public float PerlinNoise(float coordinate, float time)
		{
			return 1f - 2f * Mathf.PerlinNoise(coordinate + time, coordinate + time);
		}
	}
}
