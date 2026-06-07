using UnityEngine;

namespace Brewery.Stand
{
	public class StandBell : MonoBehaviour
	{
		[Header("Animation")]
		[Tooltip("The transform to swing (bell mesh). If null, uses this transform.")]
		[SerializeField]
		private Transform bellTransform;

		[Tooltip("Swing angle in degrees")]
		[SerializeField]
		private float swingAngle;

		[Tooltip("Duration of one full swing cycle (seconds)")]
		[SerializeField]
		private float swingDuration;

		[Tooltip("Number of swing oscillations per ring")]
		[SerializeField]
		private int swingCount;

		[Tooltip("Axis to swing around (local space)")]
		[SerializeField]
		private Vector3 swingAxis;

		private bool _isRinging;

		private Quaternion _originalLocalRotation;

		public static StandBell Instance { get; private set; }

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Ring()
		{
		}

		private void StartSwing()
		{
		}
	}
}
