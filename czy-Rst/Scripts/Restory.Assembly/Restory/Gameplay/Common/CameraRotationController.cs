using UnityEngine;

namespace Restory.Gameplay.Common
{
	public class CameraRotationController : MonoBehaviour
	{
		[SerializeField]
		private float rotationSpeed = 100f;

		[Space]
		[SerializeField]
		private float maxRotationUp = 60f;

		[SerializeField]
		private float maxRotationDown = -60f;

		[SerializeField]
		private float maxRotationLeft = -90f;

		[SerializeField]
		private float maxRotationRight = 90f;

		private Quaternion initialRotation;

		private Vector2 rotationInput;

		private void Start()
		{
			initialRotation = base.transform.rotation;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				base.transform.rotation = initialRotation;
				return;
			}
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			rotationInput = new Vector2(axis, 0f - axis2);
			RotateCamera();
		}

		private void RotateCamera()
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			eulerAngles.x = ((eulerAngles.x > 180f) ? (eulerAngles.x - 360f) : eulerAngles.x);
			eulerAngles.y = ((eulerAngles.y > 180f) ? (eulerAngles.y - 360f) : eulerAngles.y);
			float x = Mathf.Clamp(eulerAngles.x + rotationInput.y * rotationSpeed * Time.deltaTime, maxRotationDown, maxRotationUp);
			float y = Mathf.Clamp(eulerAngles.y + rotationInput.x * rotationSpeed * Time.deltaTime, maxRotationLeft, maxRotationRight);
			base.transform.rotation = Quaternion.Euler(x, y, 0f);
		}
	}
}
