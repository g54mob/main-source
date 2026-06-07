using UnityEngine;

namespace MicahW.PointGrass
{
	public class FreeCam : MonoBehaviour
	{
		public float lookSpeed = 7.5f;

		public float moveSpeed = 5f;

		public float moveAccel = 30f;

		public float fastSpeed = 15f;

		private float currentPitch;

		private float currentYaw;

		private Vector3 currentVelocity;

		private void Start()
		{
			currentPitch = base.transform.rotation.eulerAngles.x;
			currentYaw = base.transform.rotation.eulerAngles.y;
			currentVelocity = Vector3.zero;
		}

		private void Update()
		{
			Vector2 vector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), (Input.GetKey(KeyCode.E) ? 1f : 0f) + (Input.GetKey(KeyCode.Q) ? (-1f) : 0f), Input.GetAxis("Vertical"));
			float num = (Input.GetKey(KeyCode.LeftShift) ? fastSpeed : moveSpeed);
			currentPitch = (currentPitch - lookSpeed * vector.y) % 360f;
			currentYaw = (currentYaw + lookSpeed * vector.x) % 360f;
			base.transform.rotation = Quaternion.AngleAxis(currentYaw, Vector3.up) * Quaternion.AngleAxis(currentPitch, Vector3.right);
			Vector3 target = base.transform.TransformDirection(direction) * num;
			currentVelocity = Vector3.MoveTowards(currentVelocity, target, moveAccel * Time.deltaTime);
			base.transform.position += currentVelocity * Time.deltaTime;
		}
	}
}
