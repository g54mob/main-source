using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private float mouseSensitivity = 5f;

		[SerializeField]
		private float movementSpeed = 5f;

		[SerializeField]
		private float _height = 5f;

		private float _xRotation;

		private float _currentHeight;

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
			_currentHeight = base.transform.parent.position.y;
		}

		private void Update()
		{
			float value = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
			float value2 = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;
			value = Mathf.Clamp(value, -10f, 10f);
			value2 = Mathf.Clamp(value2, -10f, 10f);
			Rotate(value, value2);
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			Vector3 vector = CalculateMovement(axis, axis2);
			Vector3 position = base.transform.parent.position;
			_currentHeight = Mathf.Lerp(_currentHeight, GetHeight(), movementSpeed * Time.deltaTime);
			position += vector * movementSpeed * Time.deltaTime;
			position.y = _currentHeight;
			MoveToPoint(position);
		}

		private void Rotate(float mouseX, float mouseY)
		{
			_xRotation -= mouseY;
			_xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
			base.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
			base.transform.parent.Rotate(Vector3.up * mouseX);
		}

		private Vector3 CalculateMovement(float horizontal, float vertical)
		{
			Vector3 vector = base.transform.right * horizontal + base.transform.forward * vertical;
			vector.y = 0f;
			return vector.normalized;
		}

		private void MoveToPoint(Vector3 targetPoint)
		{
			Vector3 position = base.transform.parent.position;
			position.y = targetPoint.y;
			if (!Physics.Raycast(new Ray(position, targetPoint - position), out var _, 3f))
			{
				base.transform.parent.position = targetPoint;
			}
		}

		private float GetHeight()
		{
			if (Physics.Raycast(new Ray(base.transform.parent.position + Vector3.up * 20f, -base.transform.parent.up), out var hitInfo))
			{
				return hitInfo.point.y + _height;
			}
			return _height;
		}
	}
}
