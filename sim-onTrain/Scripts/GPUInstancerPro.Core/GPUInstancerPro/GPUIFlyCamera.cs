using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIFlyCamera : GPUIInputHandler
	{
		public float mainSpeed = 10f;

		public float shiftSpeed = 30f;

		public float rotationSpeed = 5f;

		private Vector3 _inputVector;

		private Vector3 _rotationEuler;

		protected override void Start()
		{
			base.Start();
			_inputVector = Vector3.zero;
			_rotationEuler = base.transform.rotation.eulerAngles;
		}

		private void Update()
		{
			if (GetMouseButton(1))
			{
				float axis = GetAxis("Mouse Y");
				float axis2 = GetAxis("Mouse X");
				if (Mathf.Abs(axis) < 5f && Mathf.Abs(axis2) < 5f)
				{
					_rotationEuler.x -= axis * rotationSpeed;
					_rotationEuler.y += axis2 * rotationSpeed;
					base.transform.eulerAngles = _rotationEuler;
				}
			}
			CalculateInputVector();
			base.transform.Translate(_inputVector);
		}

		private void CalculateInputVector()
		{
			_inputVector.x = 0f;
			_inputVector.y = 0f;
			_inputVector.z = 0f;
			if (GetKey(KeyCode.W))
			{
				_inputVector.z += 1f;
			}
			if (GetKey(KeyCode.S))
			{
				_inputVector.z -= 1f;
			}
			if (GetKey(KeyCode.A))
			{
				_inputVector.x -= 1f;
			}
			if (GetKey(KeyCode.D))
			{
				_inputVector.x += 1f;
			}
			if (GetKey(KeyCode.Q))
			{
				_inputVector.y -= 1f;
			}
			if (GetKey(KeyCode.E))
			{
				_inputVector.y += 1f;
			}
			if (GetKey(KeyCode.LeftShift))
			{
				_inputVector *= Time.deltaTime * shiftSpeed;
			}
			else
			{
				_inputVector *= Time.deltaTime * mainSpeed;
			}
		}
	}
}
