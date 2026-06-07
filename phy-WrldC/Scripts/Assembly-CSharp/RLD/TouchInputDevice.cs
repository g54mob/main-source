using UnityEngine;

namespace RLD
{
	public class TouchInputDevice : InputDeviceBase
	{
		private int _maxNumberOfTouches;

		public int MaxNumberOfTouches => _maxNumberOfTouches;

		public int TouchCount => Input.touchCount;

		public override InputDeviceType DeviceType => InputDeviceType.Touch;

		public TouchInputDevice(int maxNumberOfTouches)
		{
			_maxNumberOfTouches = Mathf.Max(1, maxNumberOfTouches);
		}

		public override Vector3 GetFrameDelta()
		{
			if (TouchCount != 0)
			{
				return Input.GetTouch(0).deltaPosition;
			}
			return Vector3.zero;
		}

		public override Ray GetRay(Camera camera)
		{
			Ray result = new Ray(Vector3.zero, Vector3.zero);
			if (TouchCount != 0)
			{
				return camera.ScreenPointToRay(Input.GetTouch(0).position);
			}
			return result;
		}

		public override Vector3 GetPositionYAxisUp()
		{
			if (TouchCount != 0)
			{
				return Input.GetTouch(0).position;
			}
			return Vector3.zero;
		}

		public override bool HasPointer()
		{
			return TouchCount != 0;
		}

		public override bool IsButtonPressed(int buttonIndex)
		{
			int touchCount = TouchCount;
			if (buttonIndex >= touchCount || touchCount > MaxNumberOfTouches)
			{
				return false;
			}
			return true;
		}

		public override bool WasButtonPressedInCurrentFrame(int buttonIndex)
		{
			int touchCount = TouchCount;
			if (buttonIndex >= touchCount || touchCount > MaxNumberOfTouches)
			{
				return false;
			}
			return Input.GetTouch(buttonIndex).phase == TouchPhase.Began;
		}

		public override bool WasButtonReleasedInCurrentFrame(int buttonIndex)
		{
			int touchCount = TouchCount;
			if (buttonIndex >= touchCount || touchCount > MaxNumberOfTouches)
			{
				return false;
			}
			Touch touch = Input.GetTouch(buttonIndex);
			if (touch.phase != TouchPhase.Ended)
			{
				return touch.phase == TouchPhase.Canceled;
			}
			return true;
		}

		public override bool WasMoved()
		{
			int touchCount = TouchCount;
			if (touchCount != 0)
			{
				for (int i = 0; i < touchCount; i++)
				{
					if (i >= MaxNumberOfTouches)
					{
						return false;
					}
					if (Input.GetTouch(i).phase == TouchPhase.Moved)
					{
						return true;
					}
				}
			}
			return false;
		}

		protected override void UpateFrameDeltas()
		{
		}
	}
}
