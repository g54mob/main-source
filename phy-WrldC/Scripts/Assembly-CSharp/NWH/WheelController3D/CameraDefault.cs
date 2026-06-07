using UnityEngine;

namespace NWH.WheelController3D
{
	public class CameraDefault : MonoBehaviour
	{
		public Transform TargetLookAt;

		public float Distance;

		public float DistanceMin = 3f;

		public float DistanceMax = 10f;

		private float mouseX;

		private float mouseY;

		private float startingDistance;

		private float desiredDistance;

		public float X_MouseSensitivity = 5f;

		public float Y_MouseSensitivity = 5f;

		public float MouseWheelSensitivity = 5f;

		public float Y_MinLimit = -40f;

		public float Y_MaxLimit = 80f;

		public float DistanceSmooth = 0.05f;

		private float velocityDistance;

		public Vector3 desiredPosition = Vector3.zero;

		public float X_Smooth = 0.05f;

		public float Y_Smooth = 0.1f;

		private float velX;

		private float velY;

		private float velZ;

		private Vector3 position;

		private void Awake()
		{
			position = base.transform.position;
		}

		private void Start()
		{
			Distance = Mathf.Clamp(Distance, DistanceMin, DistanceMax);
			startingDistance = Distance;
			Reset();
		}

		private void FixedUpdate()
		{
			if (!(TargetLookAt == null))
			{
				HandlePlayerInput();
				CalculateDesiredPosition();
				UpdatePosition();
			}
		}

		public void HandlePlayerInput()
		{
			float num = 0.01f;
			if (Input.GetMouseButton(0))
			{
				mouseX += Input.GetAxis("Mouse X") * X_MouseSensitivity;
				mouseY -= Input.GetAxis("Mouse Y") * Y_MouseSensitivity;
			}
			mouseY = ClampAngle(mouseY, Y_MinLimit, Y_MaxLimit);
			if (Input.GetAxis("Mouse ScrollWheel") < 0f - num || Input.GetAxis("Mouse ScrollWheel") > num)
			{
				desiredDistance = Mathf.Clamp(Distance - Input.GetAxis("Mouse ScrollWheel") * MouseWheelSensitivity, DistanceMin, DistanceMax);
			}
		}

		public void CalculateDesiredPosition()
		{
			Distance = Mathf.SmoothDamp(Distance, desiredDistance, ref velocityDistance, DistanceSmooth);
			desiredPosition = CalculatePosition(mouseY, mouseX, Distance);
		}

		public Vector3 CalculatePosition(float rotationX, float rotationY, float distance)
		{
			Vector3 vector = new Vector3(0f, 0f, 0f - distance);
			Quaternion quaternion = Quaternion.Euler(rotationX, rotationY, 0f);
			return TargetLookAt.position + quaternion * vector;
		}

		public void UpdatePosition()
		{
			float x = Mathf.SmoothDamp(position.x, desiredPosition.x, ref velX, X_Smooth);
			float y = Mathf.SmoothDamp(position.y, desiredPosition.y, ref velY, Y_Smooth);
			float z = Mathf.SmoothDamp(position.z, desiredPosition.z, ref velZ, X_Smooth);
			position = new Vector3(x, y, z);
			base.transform.position = position;
			if (Physics.Raycast(position, Vector3.down, out var hitInfo, 0.7f))
			{
				position = new Vector3(x, hitInfo.point.y + 0.7f, z);
			}
			base.transform.LookAt(TargetLookAt);
		}

		public void Reset()
		{
			mouseX = 0f;
			mouseY = 10f;
			Distance = startingDistance;
			desiredDistance = Distance;
		}

		public float ClampAngle(float angle, float min, float max)
		{
			while (angle < -360f || angle > 360f)
			{
				if (angle < -360f)
				{
					angle += 360f;
				}
				if (angle > 360f)
				{
					angle -= 360f;
				}
			}
			return Mathf.Clamp(angle, min, max);
		}
	}
}
