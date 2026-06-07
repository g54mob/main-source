using UnityEngine;

namespace PSXShadersPro.URP.Demo
{
	public class PlayerController : MonoBehaviour
	{
		public CharacterController controller;

		public float baseSpeed = 5f;

		public float gravity = -9.81f;

		public float jumpHeight = 3f;

		public Transform groundCheck;

		public float groundDistance = 0.4f;

		public LayerMask groundMask;

		private Vector3 velocity;

		private void Update()
		{
			bool flag = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
			if (flag && velocity.y < 0f)
			{
				velocity.y = -2f;
			}
			float num = ((!(Input.GetKey("left shift") && flag)) ? baseSpeed : (baseSpeed * 2f));
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			Vector3 vector = base.transform.right * axis + base.transform.forward * axis2;
			if (vector.magnitude > 1f)
			{
				vector.Normalize();
			}
			controller.Move(vector * num * Time.deltaTime);
			if (Input.GetButtonDown("Jump") && flag)
			{
				velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
			}
			velocity.y += gravity * Time.deltaTime;
			controller.Move(velocity * Time.deltaTime);
		}
	}
}
