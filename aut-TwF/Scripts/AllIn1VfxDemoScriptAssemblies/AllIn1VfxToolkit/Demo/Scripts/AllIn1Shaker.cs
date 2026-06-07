using UnityEngine;

namespace AllIn1VfxToolkit.Demo.Scripts
{
	public class AllIn1Shaker : MonoBehaviour
	{
		[SerializeField]
		private Vector3 maximumTranslationShake = Vector3.one;

		[SerializeField]
		private Vector3 maximumAngularShake = Vector3.one * 15f;

		[SerializeField]
		private float shakeFrequency = 25f;

		[SerializeField]
		private float shakeSmoothingExponent = 1f;

		[SerializeField]
		private float shakeRecoverPerSecond = 1f;

		public static AllIn1Shaker i;

		private float currentShakeAmount;

		private float seed;

		private void Awake()
		{
			if (i != null && i != this)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				i = this;
			}
			seed = Random.value;
		}

		private void Update()
		{
			float shake = SmoothShakeToApply();
			ShakePosition(shake);
			ShakeRotation(shake);
			currentShakeAmount = Mathf.Clamp01(currentShakeAmount - shakeRecoverPerSecond * Time.deltaTime);
		}

		private float SmoothShakeToApply()
		{
			return Mathf.Pow(currentShakeAmount, shakeSmoothingExponent);
		}

		private void ShakeRotation(float shake)
		{
			base.transform.localRotation = Quaternion.Euler(new Vector3(maximumAngularShake.x * (Mathf.PerlinNoise(seed + 3f, Time.time * shakeFrequency) * 2f - 1f), maximumAngularShake.y * (Mathf.PerlinNoise(seed + 4f, Time.time * shakeFrequency) * 2f - 1f), maximumAngularShake.z * (Mathf.PerlinNoise(seed + 5f, Time.time * shakeFrequency) * 2f - 1f)) * shake);
		}

		private void ShakePosition(float shake)
		{
			base.transform.localPosition = new Vector3(maximumTranslationShake.x * (Mathf.PerlinNoise(seed, Time.time * shakeFrequency) * 2f - 1f), maximumTranslationShake.y * (Mathf.PerlinNoise(seed + 1f, Time.time * shakeFrequency) * 2f - 1f), maximumTranslationShake.z * (Mathf.PerlinNoise(seed + 2f, Time.time * shakeFrequency) * 2f - 1f)) * shake;
		}

		public void DoCameraShake(float shakeAmount)
		{
			currentShakeAmount = shakeAmount;
		}
	}
}
