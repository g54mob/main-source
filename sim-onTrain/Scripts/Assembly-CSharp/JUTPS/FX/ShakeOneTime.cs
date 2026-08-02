using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Shake One Time")]
	public class ShakeOneTime : MonoBehaviour
	{
		public Shaker ShakerToShake;

		public bool ShakeOnAwake = true;

		[Range(0f, 1f)]
		public float ShakeIntensity = 1f;

		[Range(0f, 50f)]
		public float ShakeStartIntensity = 50f;

		[Range(0f, 20f)]
		public float ShakeEndIntensity = 5f;

		[Range(0f, 20f)]
		public float ShakeSpeed = 5f;

		[Range(0f, 20f)]
		public float MaxAngle = 15f;

		[Range(0f, 20f)]
		public float ShakeDuration = 1f;

		public float ShakeRadious = 50f;

		private void Start()
		{
			if (ShakeOnAwake)
			{
				Shake(ShakeRadious);
			}
		}

		public void Shake(float Radious = 10f)
		{
			if (ShakerToShake == null)
			{
				if (Shaker.GetCurrentCameraInstance() != null)
				{
					Shaker currentCameraInstance = Shaker.GetCurrentCameraInstance();
					float num = Mathf.Lerp(1f, 0f, Vector3.Distance(currentCameraInstance.transform.position, base.transform.position) / Radious);
					currentCameraInstance.Shake(ShakeSpeed, ShakeDuration, ShakeStartIntensity, ShakeEndIntensity, MaxAngle, num * ShakeIntensity);
				}
			}
			else
			{
				ShakerToShake.Shake(ShakeSpeed, ShakeDuration, ShakeStartIntensity, ShakeEndIntensity, MaxAngle, ShakeIntensity);
			}
		}
	}
}
