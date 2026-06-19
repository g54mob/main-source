using UnityEngine;
using WorldEnvironment;

namespace Vehicles.Plane
{
	public class AirplaneControllersDriver : MonoBehaviour
	{
		[SerializeField]
		private AirplaneController _controller;

		[Space(5f)]
		[SerializeField]
		private TransformDriver _leftPedal;

		[SerializeField]
		private TransformDriver _leftBrake;

		[SerializeField]
		private TransformDriver _rightPedal;

		[SerializeField]
		private TransformDriver _rightBrake;

		[SerializeField]
		private JoystickDriver _joystick;

		[SerializeField]
		private TransformDriver _throtleHandle;

		[SerializeField]
		private TransformDriver _handBreakHandle;

		[SerializeField]
		private TransformDriver _flapsHandle;

		private void Update()
		{
			_leftPedal.Drive(_controller.Yaw);
			_rightPedal.Drive(_controller.Yaw);
			_joystick.DriveX(_controller.Roll);
			_joystick.DriveY(_controller.Pitch);
			_throtleHandle.Drive(_controller.thrustPercent);
			_handBreakHandle.Drive(_controller.handBreakPercent);
			_flapsHandle.Drive(_controller.Flap);
		}
	}
}
