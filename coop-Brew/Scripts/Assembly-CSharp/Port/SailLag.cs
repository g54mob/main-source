using UnityEngine;

namespace Port
{
	public class SailLag : MonoBehaviour
	{
		[Tooltip("How quickly the sail catches up (lower = more lag, more dramatic)")]
		[SerializeField]
		private float followSpeed;

		[Tooltip("Max angle the sail can lag behind (degrees)")]
		[SerializeField]
		private float maxLagAngle;

		[Tooltip("Gentle idle sway even when stationary (degrees)")]
		[SerializeField]
		private float idleSwayAmount;

		[Tooltip("Idle sway speed")]
		[SerializeField]
		private float idleSwaySpeed;

		private Quaternion localRestRotation;

		private Quaternion smoothedWorldRotation;

		private float swayOffset;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
