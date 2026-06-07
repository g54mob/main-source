using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _moveForward = new Hotkeys("Move forward")
		{
			Key = KeyCode.W,
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _moveBack = new Hotkeys("Move back")
		{
			Key = KeyCode.S,
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _strafeLeft = new Hotkeys("Strafe left")
		{
			Key = KeyCode.A,
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _strafeRight = new Hotkeys("Strafe right")
		{
			Key = KeyCode.D,
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _moveUp = new Hotkeys("Move up")
		{
			Key = KeyCode.E,
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _moveDown = new Hotkeys("Move down")
		{
			Key = KeyCode.Q,
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _pan = new Hotkeys("Pan")
		{
			UseStrictModifierCheck = false,
			MMouseButton = true
		};

		[SerializeField]
		private Hotkeys _lookAround = new Hotkeys("Look around")
		{
			UseStrictModifierCheck = false,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _orbit = new Hotkeys("Orbit")
		{
			UseStrictModifierCheck = false,
			LAlt = true,
			RMouseButton = true
		};

		[SerializeField]
		private Hotkeys _alternateMoveSpeed = new Hotkeys("Alternate move speed")
		{
			UseStrictModifierCheck = false,
			LShift = true
		};

		public Hotkeys MoveForward => _moveForward;

		public Hotkeys MoveBack => _moveBack;

		public Hotkeys StrafeLeft => _strafeLeft;

		public Hotkeys StrafeRight => _strafeRight;

		public Hotkeys MoveUp => _moveUp;

		public Hotkeys MoveDown => _moveDown;

		public Hotkeys Pan => _pan;

		public Hotkeys LookAround => _lookAround;

		public Hotkeys Orbit => _orbit;

		public Hotkeys AlternateMoveSpeed => _alternateMoveSpeed;
	}
}
