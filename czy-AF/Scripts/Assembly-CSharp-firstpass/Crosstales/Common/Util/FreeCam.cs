using UnityEngine;

namespace Crosstales.Common.Util
{
	public class FreeCam : MonoBehaviour
	{
		public float MovementSpeed = 10f;

		public float FastMovementSpeed = 100f;

		public float FreeLookSensitivity = 3f;

		public float ZoomSensitivity = 10f;

		public float FastZoomSensitivity = 50f;

		private Transform tf;

		private bool looking;

		public void Start()
		{
			tf = base.transform;
		}

		public void Update()
		{
			bool flag = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
			float num = (flag ? FastMovementSpeed : MovementSpeed);
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				tf.position += Time.deltaTime * num * -tf.right;
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				tf.position += Time.deltaTime * num * tf.right;
			}
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				tf.position += Time.deltaTime * num * tf.forward;
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				tf.position += Time.deltaTime * num * -tf.forward;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				tf.position += Time.deltaTime * num * tf.up;
			}
			if (Input.GetKey(KeyCode.E))
			{
				tf.position += Time.deltaTime * num * -tf.up;
			}
			if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
			{
				tf.position += Time.deltaTime * num * Vector3.up;
			}
			if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
			{
				tf.position += Time.deltaTime * num * -Vector3.up;
			}
			if (looking)
			{
				Vector3 localEulerAngles = tf.localEulerAngles;
				float y = localEulerAngles.y + Input.GetAxis("Mouse X") * FreeLookSensitivity;
				float x = localEulerAngles.x - Input.GetAxis("Mouse Y") * FreeLookSensitivity;
				localEulerAngles = new Vector3(x, y, 0f);
				tf.localEulerAngles = localEulerAngles;
			}
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (Mathf.Abs(axis) > 0.0001f)
			{
				float num2 = (flag ? FastZoomSensitivity : ZoomSensitivity);
				tf.position += num2 * axis * tf.forward;
			}
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				StartLooking();
			}
			else if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				StopLooking();
			}
		}

		public void OnDisable()
		{
			StopLooking();
		}

		public void StartLooking()
		{
			looking = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		public void StopLooking()
		{
			looking = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
