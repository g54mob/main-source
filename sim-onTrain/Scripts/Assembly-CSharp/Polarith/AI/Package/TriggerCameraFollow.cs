using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Trigger Camera Follow")]
	public sealed class TriggerCameraFollow : MonoBehaviour
	{
		[Tooltip("'CameraFollow' script that should be changed when entering the trigger collider.")]
		[SerializeField]
		private CameraFollow cameraFollow;

		[Tooltip("Movement speed of the 'CameraFollow' script when entering the trigger collider.")]
		[SerializeField]
		private float moveSpeed = 1f;

		[Tooltip("Camera Angle of the 'CameraFollow' script when entering the trigger collider.")]
		[SerializeField]
		private Vector3 cameraAngle = Vector3.up;

		[Tooltip("Target object of the 'CameraFollow' script hat should be focused when entering the triggercollider.")]
		[SerializeField]
		private GameObject target;

		public CameraFollow CameraFollow
		{
			get
			{
				return cameraFollow;
			}
			set
			{
				cameraFollow = value;
			}
		}

		public float MoveSpeed
		{
			get
			{
				return moveSpeed;
			}
			set
			{
				moveSpeed = value;
			}
		}

		public Vector3 CameraAngle
		{
			get
			{
				return cameraAngle;
			}
			set
			{
				cameraAngle = value;
			}
		}

		public GameObject Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			if (CameraFollow != null)
			{
				CameraFollow.MoveSpeed = moveSpeed;
				CameraFollow.Target = target.transform;
			}
		}
	}
}
