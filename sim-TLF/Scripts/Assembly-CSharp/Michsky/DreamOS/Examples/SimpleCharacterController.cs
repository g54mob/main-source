using UnityEngine;
using UnityEngine.InputSystem;

namespace Michsky.DreamOS.Examples
{
	public class SimpleCharacterController : MonoBehaviour
	{
		public Transform cameraTransform;

		public float moveSpeed = 5f;

		public float rotationSpeed = 200f;

		public float cameraSensitivity = 2f;

		private Rigidbody rb;

		private float cameraRotationX;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			float num = Keyboard.current[Key.D].ReadValue() - Keyboard.current[Key.A].ReadValue();
			float num2 = 0f - (Keyboard.current[Key.S].ReadValue() - Keyboard.current[Key.W].ReadValue());
			Vector3 vector = (base.transform.forward * num2 + base.transform.right * num) * moveSpeed * Time.deltaTime;
			rb.MovePosition(rb.position + vector);
			float num3 = Mouse.current.delta.x.ReadValue() * cameraSensitivity * Time.deltaTime;
			float num4 = (0f - Mouse.current.delta.y.ReadValue()) * cameraSensitivity * Time.deltaTime;
			cameraRotationX += num4;
			cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);
			cameraTransform.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);
			base.transform.Rotate(Vector3.up * num3);
		}
	}
}
