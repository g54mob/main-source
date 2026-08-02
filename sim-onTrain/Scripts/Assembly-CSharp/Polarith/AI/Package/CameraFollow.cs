using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Camera Follow")]
	[RequireComponent(typeof(Camera))]
	public sealed class CameraFollow : MonoBehaviour
	{
		public enum UpdateType
		{
			FixedUpdate = 0,
			LateUpdate = 1,
			Update = 2
		}

		[Tooltip("Camera that shall follow the target.")]
		[SerializeField]
		private Camera cam;

		[Tooltip("Target camera\u00b4s rotation.")]
		[SerializeField]
		private Vector3 cameraAngle = Vector3.zero;

		[Tooltip("Affects how fast movement changes of the target are applied to the camera.")]
		[SerializeField]
		private float moveSpeed = 3f;

		[Tooltip("Affects how fast movement changes of the target are applied to the camera.")]
		[SerializeField]
		private float rotateLag = 10f;

		[Tooltip("Distance between camera and target.")]
		[SerializeField]
		private float offset = 500f;

		[Tooltip("Target object the camera tries to follow.")]
		[SerializeField]
		private Transform target;

		[Tooltip("Goal object the camera tries to look at.")]
		[SerializeField]
		private Transform goalObject;

		[Tooltip("Decides which parts of Unity\u00b4s update loops will be called.")]
		[SerializeField]
		private UpdateType updateMode;

		public Camera Camera
		{
			get
			{
				return cam;
			}
			set
			{
				cam = value;
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

		public float Offset
		{
			get
			{
				return offset;
			}
			set
			{
				offset = value;
			}
		}

		public Transform Target
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

		public Transform GoalObject
		{
			get
			{
				return goalObject;
			}
			set
			{
				goalObject = value;
			}
		}

		public UpdateType UpdateMode
		{
			get
			{
				return updateMode;
			}
			set
			{
				updateMode = value;
			}
		}

		private void FixedUpdate()
		{
			if (UpdateMode == UpdateType.FixedUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (UpdateMode == UpdateType.LateUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		private void Update()
		{
			if (UpdateMode == UpdateType.Update)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		private void FollowTarget(float deltaTime)
		{
			if (deltaTime > 0f && !(Target == null))
			{
				Vector3 b = new Vector3(Target.position.x, Target.position.y, Target.position.z);
				b -= Camera.transform.forward * Offset;
				float magnitude = (Target.position - Camera.transform.position).magnitude;
				Camera.transform.position = Vector3.Lerp(Camera.transform.position, b, deltaTime * MoveSpeed * magnitude / Offset);
				if (GoalObject == null)
				{
					Camera.transform.rotation = Quaternion.Lerp(Camera.transform.rotation, Quaternion.Euler(CameraAngle.x, CameraAngle.y, CameraAngle.z), Time.deltaTime * rotateLag);
				}
				else
				{
					Camera.transform.rotation = Quaternion.Lerp(Camera.transform.rotation, Quaternion.LookRotation(GoalObject.position - Target.position), Time.deltaTime * rotateLag);
				}
			}
		}
	}
}
