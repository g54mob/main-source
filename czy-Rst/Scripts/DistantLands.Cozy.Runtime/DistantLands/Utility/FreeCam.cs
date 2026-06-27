using UnityEngine;

namespace DistantLands.Utility
{
	public class FreeCam : MonoBehaviour
	{
		public float normalSpeed = 5f;

		public float fastSpeedMultiplier = 2f;

		public float rotationSpeed = 2f;

		private float currentSpeedMultiplier = 1f;

		private void Update()
		{
			HandleInput();
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else if (Input.GetMouseButtonDown(0))
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}

		private void HandleInput()
		{
			currentSpeedMultiplier = (Input.GetKey(KeyCode.LeftShift) ? fastSpeedMultiplier : 1f);
			float num = normalSpeed * currentSpeedMultiplier;
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			float y = (Input.GetKey(KeyCode.E) ? 1 : (Input.GetKey(KeyCode.Q) ? (-1) : 0));
			Vector3 normalized = new Vector3(axis, y, axis2).normalized;
			Vector3 translation = base.transform.TransformDirection(normalized) * num * Time.deltaTime;
			base.transform.Translate(translation, Space.World);
			float angle = Input.GetAxis("Mouse X") * rotationSpeed;
			float angle2 = (0f - Input.GetAxis("Mouse Y")) * rotationSpeed;
			base.transform.Rotate(Vector3.up, angle, Space.World);
			base.transform.Rotate(Vector3.right, angle2, Space.Self);
		}
	}
}
