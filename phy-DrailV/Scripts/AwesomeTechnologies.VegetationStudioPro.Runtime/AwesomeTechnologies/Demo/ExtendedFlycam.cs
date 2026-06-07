using UnityEngine;

namespace AwesomeTechnologies.Demo
{
	public class ExtendedFlycam : MonoBehaviour
	{
		public float CameraSensitivity = 90f;

		public float ClimbSpeed = 4f;

		public float NormalMoveSpeed = 10f;

		public float SlowMoveFactor = 0.25f;

		public float FastMoveFactor = 3f;

		private float _rotationX;

		private float _rotationY;

		private void Start()
		{
			_rotationX = base.transform.eulerAngles.y;
			_rotationY = 0f - base.transform.eulerAngles.x;
		}

		private void Update()
		{
			if (Input.GetMouseButton(1))
			{
				_rotationX += Input.GetAxis("Mouse X") * CameraSensitivity * Time.deltaTime;
				_rotationY += Input.GetAxis("Mouse Y") * CameraSensitivity * Time.deltaTime;
				_rotationY = Mathf.Clamp(_rotationY, -90f, 90f);
			}
			Quaternion b = Quaternion.AngleAxis(_rotationX, Vector3.up);
			b *= Quaternion.AngleAxis(_rotationY, Vector3.left);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 4f);
			float num = 1f;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				num = FastMoveFactor;
			}
			if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
			{
				num = SlowMoveFactor;
			}
			base.transform.position += base.transform.forward * NormalMoveSpeed * num * Input.GetAxis("Vertical") * Time.deltaTime;
			base.transform.position += base.transform.right * NormalMoveSpeed * num * Input.GetAxis("Horizontal") * Time.deltaTime;
			float num2 = 0f;
			if (Input.GetKey(KeyCode.Q))
			{
				num2 = -0.5f;
			}
			if (Input.GetKey(KeyCode.E))
			{
				num2 = 0.5f;
			}
			base.transform.position += base.transform.up * NormalMoveSpeed * num * num2 * Time.deltaTime;
		}
	}
}
