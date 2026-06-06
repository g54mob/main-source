using UnityEngine;

namespace Ezereal
{
	public class EzerealSuspensionBumpDetector : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private float bumpForceThreshold;

		[SerializeField]
		private float cooldownTime;

		[SerializeField]
		private float nextPlayTime;

		private WheelCollider wheelCollider;

		private AudioSource bumpSound;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
