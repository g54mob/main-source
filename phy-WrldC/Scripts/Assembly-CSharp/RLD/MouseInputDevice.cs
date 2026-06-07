using UnityEngine;

namespace RLD
{
	public class MouseInputDevice : InputDeviceBase
	{
		private Vector3 _frameDelta;

		private Vector3 _mousePosInLastFrame;

		public override InputDeviceType DeviceType => InputDeviceType.Mouse;

		public MouseInputDevice()
		{
			_frameDelta = Vector3.zero;
			_mousePosInLastFrame = Input.mousePosition;
		}

		public override Vector3 GetFrameDelta()
		{
			return _frameDelta;
		}

		public override Ray GetRay(Camera camera)
		{
			return camera.ScreenPointToRay(Input.mousePosition);
		}

		public override Vector3 GetPositionYAxisUp()
		{
			return Input.mousePosition;
		}

		public override bool HasPointer()
		{
			return Input.mousePresent;
		}

		public override bool IsButtonPressed(int buttonIndex)
		{
			return Input.GetMouseButton(buttonIndex);
		}

		public override bool WasButtonPressedInCurrentFrame(int buttonIndex)
		{
			return Input.GetMouseButtonDown(buttonIndex);
		}

		public override bool WasButtonReleasedInCurrentFrame(int buttonIndex)
		{
			return Input.GetMouseButtonUp(buttonIndex);
		}

		public override bool WasMoved()
		{
			if (Input.GetAxis("Mouse X") == 0f)
			{
				return Input.GetAxis("Mouse Y") != 0f;
			}
			return true;
		}

		protected override void UpateFrameDeltas()
		{
			_frameDelta = Input.mousePosition - _mousePosInLastFrame;
			_mousePosInLastFrame = Input.mousePosition;
		}
	}
}
