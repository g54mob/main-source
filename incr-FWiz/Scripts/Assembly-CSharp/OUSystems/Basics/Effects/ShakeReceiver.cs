using UnityEngine;

namespace OUSystems.Basics.Effects
{
	public class ShakeReceiver : MonoBehaviour
	{
		private float _trauma;

		private Vector3 _lastPosition;

		private Vector3 _lastRotation;

		[Tooltip("Maximum trauma that the reciever can get.")]
		public float MaximumTrauma;

		[Tooltip("Exponent for calculating the shake factor. Useful for creating different effect fade outs")]
		public float TraumaExponent;

		[Tooltip("Maximum angle that the gameobject can shake. In euler angles.")]
		public Vector3 MaximumAngularShake;

		[Tooltip("Maximum translation that the gameobject can receive when applying the shake effect.")]
		public Vector3 MaximumTranslationShake;

		public bool DestroyOnComplete;

		public void Set(float maximumTrauma, float exponent, Vector3 angularShake, Vector3 translationShake, bool destroyOnComplete)
		{
		}

		private void Update()
		{
		}

		public void InduceShake(float Stress)
		{
		}

		public void ClearShake()
		{
		}
	}
}
