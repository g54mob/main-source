using System.Collections.Generic;
using UnityEngine;

namespace Coherence.Toolkit
{
	public class FixedUpdateInput
	{
		internal struct MouseButton
		{
			public int Button;
		}

		internal struct CustomButton
		{
			public string Name;
		}

		internal interface IInputSource<TButton>
		{
			bool GetButton(TButton button);

			bool GetButtonDown(TButton button);

			bool GetButtonUp(TButton button);
		}

		internal interface IInput : IInputSource<KeyCode>, IInputSource<MouseButton>, IInputSource<CustomButton>
		{
		}

		internal class UnityInputSource : IInput, IInputSource<KeyCode>, IInputSource<MouseButton>, IInputSource<CustomButton>
		{
			public static readonly UnityInputSource Shared;

			public bool AnyKey => false;

			public bool AnyKeyDown => false;

			public bool GetButton(KeyCode keyCode)
			{
				return false;
			}

			public bool GetButtonDown(KeyCode keyCode)
			{
				return false;
			}

			public bool GetButtonUp(KeyCode keyCode)
			{
				return false;
			}

			public bool GetButton(MouseButton button)
			{
				return false;
			}

			public bool GetButtonDown(MouseButton button)
			{
				return false;
			}

			public bool GetButtonUp(MouseButton button)
			{
				return false;
			}

			public bool GetButton(CustomButton button)
			{
				return false;
			}

			public bool GetButtonDown(CustomButton button)
			{
				return false;
			}

			public bool GetButtonUp(CustomButton button)
			{
				return false;
			}
		}

		internal enum ButtonStatus
		{
			None = 0,
			Down = 1,
			Pressed = 2,
			Up = 3
		}

		internal abstract class InputState
		{
			public ButtonStatus Status { get; protected set; }

			public bool IsDown => false;

			public bool IsPressed => false;

			public bool IsUp => false;

			public abstract void Update();

			public abstract void FixedUpdate();
		}

		internal class ButtonState<TButton> : InputState
		{
			public readonly TButton Button;

			private readonly IInputSource<TButton> inputSource;

			private ButtonStatus lastUpdateStatus;

			private int downs;

			private int ups;

			private int releases;

			public ButtonState(TButton button, IInputSource<TButton> source = null)
			{
			}

			public override void FixedUpdate()
			{
			}

			public override void Update()
			{
			}
		}

		private static readonly Dictionary<string, KeyCode> keyCodeByName;

		private readonly IInput input;

		private readonly List<InputState> inputStates;

		private readonly InputState[] keyStates;

		private readonly InputState[] mouseStates;

		private readonly Dictionary<string, InputState> buttonStates;

		private double lastUpdateTime;

		private double lastFixedUpdateTime;

		static FixedUpdateInput()
		{
		}

		internal FixedUpdateInput(IInput input = null)
		{
		}

		internal void Update(bool force = false)
		{
		}

		internal void FixedUpdate(bool force = false)
		{
		}

		public bool GetKey(KeyCode key)
		{
			return false;
		}

		public bool GetKeyDown(KeyCode key)
		{
			return false;
		}

		public bool GetKeyUp(KeyCode key)
		{
			return false;
		}

		public bool GetMouseButton(int button)
		{
			return false;
		}

		public bool GetMouseButtonDown(int button)
		{
			return false;
		}

		public bool GetMouseButtonUp(int button)
		{
			return false;
		}

		public bool GetKey(string name)
		{
			return false;
		}

		public bool GetKeyDown(string name)
		{
			return false;
		}

		public bool GetKeyUp(string name)
		{
			return false;
		}

		public bool GetButton(string buttonName)
		{
			return false;
		}

		public bool GetButtonDown(string buttonName)
		{
			return false;
		}

		public bool GetButtonUp(string buttonName)
		{
			return false;
		}

		private InputState GetOrCreateKeyState(string keyName)
		{
			return null;
		}

		private InputState GetOrCreateKeyState(KeyCode key)
		{
			return null;
		}

		private InputState GetOrCreateMouseState(int mouseButton)
		{
			return null;
		}

		private InputState GetOrCreateButtonState(string buttonName)
		{
			return null;
		}
	}
}
