using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/malbers-input")]
	[AddComponentMenu("Malbers/Input/Malbers Input")]
	public class MalbersInput : MInput
	{
		private ICharacterMove mCharacterMove;

		public InputAxis Horizontal = new InputAxis("Horizontal", active: true, isRaw: true);

		public InputAxis Vertical = new InputAxis("Vertical", active: true, isRaw: true);

		public InputAxis UpDown = new InputAxis("UpDown", active: false, isRaw: true);

		public float horizontal;

		public float vertical;

		public float upDown;

		public Vector3Event MovementEvent = new Vector3Event();

		public virtual void SetMoveCharacter(bool val)
		{
			base.MoveCharacter = val;
		}

		protected void InitializeCharacter()
		{
			mCharacterMove = GetComponent<ICharacterMove>();
			base.MoveCharacter = true;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (UpDown.active)
			{
				try
				{
					Input.GetAxis(UpDown.name);
				}
				catch
				{
				}
			}
			mCharacterMove?.Move(Vector3.zero);
		}

		private void CheckUpDown()
		{
			_ = UpDown.active;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			mCharacterMove?.Move(Vector3.zero);
		}

		protected override void Initialize()
		{
			base.Initialize();
			InitializeCharacter();
			InputAxis inputAxis = Horizontal;
			InputAxis inputAxis2 = Vertical;
			IInputSystem inputSystem = (UpDown.InputSystem = Input_System);
			IInputSystem inputSystem2 = (inputAxis2.InputSystem = inputSystem);
			inputAxis.InputSystem = inputSystem2;
		}

		public virtual void UpAxis(bool input)
		{
			if (upDown != -1f)
			{
				upDown = (input ? 1 : 0);
			}
		}

		public virtual void DownAxis(bool input)
		{
			upDown = (input ? (-1) : 0);
		}

		private void Update()
		{
			SetInput();
		}

		protected override void SetInput()
		{
			if (!IgnoreOnPause.Value || Time.timeScale != 0f)
			{
				horizontal = Horizontal.GetAxis;
				vertical = Vertical.GetAxis;
				upDown = UpDown.GetAxis;
				base.MoveAxis = new Vector3(horizontal, upDown, vertical);
				base.OnMoveAxis(base.MoveAxis);
				MovementEvent.Invoke(base.MoveAxis);
				mCharacterMove?.SetInputAxis(base.MoveCharacter ? base.MoveAxis : Vector3.zero);
				base.SetInput();
			}
		}

		protected override bool IsJoystickInput()
		{
			if (horizontal != 0f && Mathf.Abs(horizontal) < 1f)
			{
				return true;
			}
			if (vertical != 0f && Mathf.Abs(vertical) < 1f)
			{
				return true;
			}
			return base.IsJoystickInput();
		}

		public virtual void Horizontal_Enable(bool value)
		{
			Horizontal.active = value;
		}

		public virtual void UpDown_Enable(bool value)
		{
			UpDown.active = value;
		}

		public virtual void Vertical_Enable(bool value)
		{
			Vertical.active = value;
		}

		public void ResetInputAxis()
		{
			base.MoveAxis = Vector3.zero;
		}
	}
}
