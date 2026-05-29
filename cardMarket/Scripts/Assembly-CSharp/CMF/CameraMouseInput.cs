using UnityEngine;

namespace CMF
{
	public class CameraMouseInput : CameraInput
	{
		public string mouseHorizontalAxis = "Mouse X";

		public string mouseVerticalAxis = "Mouse Y";

		public string joystickHorizontalAxis = "RJoystick X";

		public string joystickVerticalAxis = "RJoystick Y";

		public string joystickHorizontalAxisPS = "RJoystick X PS";

		public string joystickVerticalAxisPS = "RJoystick Y PS";

		public bool invertHorizontalInput;

		public bool invertVerticalInput;

		public float mouseInputMultiplier = 0.01f;

		public float joystickInputMultiplier = 1f;

		public override float GetHorizontalCameraInput()
		{
			float num = Input.GetAxisRaw(joystickHorizontalAxis);
			if (CSingleton<InputManager>.Instance.m_CurrentGamepad != null && CSingleton<InputManager>.Instance.m_IsControllerActive)
			{
				num = CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.x.value;
			}
			bool flag = false;
			if (Mathf.Abs(num) > 0f && CSingleton<InputManager>.Instance.m_IsControllerActive)
			{
				flag = true;
			}
			else
			{
				num = Input.GetAxisRaw(mouseHorizontalAxis);
			}
			if (Time.timeScale > 0f && Time.deltaTime > 0f)
			{
				num /= Time.deltaTime;
				num *= Time.timeScale;
			}
			else
			{
				num = 0f;
			}
			num = ((!flag) ? (num * mouseInputMultiplier) : (num * joystickInputMultiplier));
			if (invertHorizontalInput)
			{
				num *= -1f;
			}
			return num;
		}

		public override float GetVerticalCameraInput()
		{
			float num = 0f - Input.GetAxisRaw(joystickVerticalAxis);
			if (CSingleton<InputManager>.Instance.m_CurrentGamepad != null && CSingleton<InputManager>.Instance.m_IsControllerActive)
			{
				num = 0f - CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.y.value;
			}
			bool flag = false;
			if (Mathf.Abs(num) > 0f && CSingleton<InputManager>.Instance.m_IsControllerActive)
			{
				flag = true;
			}
			else
			{
				num = 0f - Input.GetAxisRaw(mouseVerticalAxis);
			}
			if (Time.timeScale > 0f && Time.deltaTime > 0f)
			{
				num /= Time.deltaTime;
				num *= Time.timeScale;
			}
			else
			{
				num = 0f;
			}
			num = ((!flag) ? (num * mouseInputMultiplier) : (num * joystickInputMultiplier));
			if (invertVerticalInput)
			{
				num *= -1f;
			}
			return num;
		}
	}
}
