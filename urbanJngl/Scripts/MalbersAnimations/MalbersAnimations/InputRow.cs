using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class InputRow : IInputAction
	{
		public string name = "InputName";

		public BoolReference active = new BoolReference(value: true);

		public BoolReference ignoreOnPause = new BoolReference();

		public InputType type;

		public string input = "Value";

		[SearcheableEnum]
		public KeyCode key = KeyCode.A;

		public bool debug;

		public InputButton GetPressed;

		private bool m_Input;

		[Tooltip("When the Input is disabled the input value will set to false and it will send that value to all possible connections")]
		public bool ResetOnDisable = true;

		public UnityEvent OnInputDown = new UnityEvent();

		public UnityEvent OnInputUp = new UnityEvent();

		public UnityEvent OnLongPress = new UnityEvent();

		public UnityEvent OnLongPressReleased = new UnityEvent();

		public UnityEvent OnDoubleTap = new UnityEvent();

		public BoolEvent OnInputChanged = new BoolEvent();

		public UnityEvent OnInputEnable = new UnityEvent();

		public UnityEvent OnInputDisable = new UnityEvent();

		protected IInputSystem inputSystem = new DefaultInput();

		public float DoubleTapTime = 0.3f;

		[Tooltip("Time the Input Should be Pressed")]
		public float LongPressTime = 0.5f;

		[Tooltip("Smooth decrese the acumulated pressed time")]
		public bool SmoothDecrease;

		private bool FirstInputPress;

		private bool InputCompleted;

		private float InputStartTime;

		public UnityEvent OnInputPressed = new UnityEvent();

		public FloatEvent OnInputFloat = new FloatEvent();

		public bool InputValue
		{
			get
			{
				return m_Input;
			}
			set
			{
				if (m_Input != value)
				{
					m_Input = value;
					if (debug)
					{
						Debug.Log($"<color=cyan><B>[Input {name} : {m_Input}]</B></color>");
					}
				}
			}
		}

		public BoolEvent OnInputToggle => OnInputChanged;

		public virtual bool GetValue
		{
			get
			{
				if (!active)
				{
					return false;
				}
				if ((bool)ignoreOnPause)
				{
					return false;
				}
				if (inputSystem == null)
				{
					return false;
				}
				bool inputValue = InputValue;
				switch (GetPressed)
				{
				case InputButton.Press:
					InputValue = ((type == InputType.Input) ? InputSystem.GetButton(input) : Input.GetKey(key));
					if (inputValue != InputValue)
					{
						if (InputValue)
						{
							OnInputDown.Invoke();
						}
						else
						{
							OnInputUp.Invoke();
						}
						OnInputChanged.Invoke(InputValue);
					}
					if (InputValue)
					{
						OnInputPressed.Invoke();
					}
					break;
				case InputButton.Down:
					InputValue = ((type == InputType.Input) ? InputSystem.GetButtonDown(input) : Input.GetKeyDown(key));
					if (inputValue != InputValue)
					{
						if (InputValue)
						{
							OnInputDown.Invoke();
						}
						OnInputChanged.Invoke(InputValue);
					}
					break;
				case InputButton.Up:
					InputValue = ((type == InputType.Input) ? InputSystem.GetButtonUp(input) : Input.GetKeyUp(key));
					if (inputValue != InputValue)
					{
						if (!InputValue)
						{
							OnInputUp.Invoke();
						}
						OnInputChanged.Invoke(InputValue);
					}
					break;
				case InputButton.LongPress:
					InputValue = ((type == InputType.Input) ? InputSystem.GetButton(input) : Input.GetKey(key));
					if (inputValue != InputValue)
					{
						OnInputChanged.Invoke(InputValue);
					}
					if (InputValue)
					{
						if (!FirstInputPress && !InputCompleted)
						{
							FirstInputPress = true;
							InputStartTime = 0f;
							OnInputFloat.Invoke(0f);
							OnInputDown.Invoke();
						}
						else if (!InputCompleted)
						{
							if (InputStartTime >= LongPressTime)
							{
								OnInputFloat.Invoke(1f);
								OnLongPress.Invoke();
								FirstInputPress = false;
								InputCompleted = true;
							}
							else
							{
								InputStartTime += Time.deltaTime;
								OnInputFloat.Invoke(Mathf.Clamp01(InputStartTime / LongPressTime));
							}
						}
						break;
					}
					if (InputCompleted)
					{
						OnLongPressReleased.Invoke();
					}
					if (FirstInputPress)
					{
						if (SmoothDecrease)
						{
							InputStartTime -= Time.deltaTime;
							if (InputStartTime > 0f)
							{
								OnInputFloat.Invoke(Mathf.Clamp01(InputStartTime / LongPressTime));
							}
							else
							{
								ResetLongPress();
							}
						}
						else
						{
							ResetLongPress();
						}
					}
					else
					{
						InputCompleted = false;
					}
					break;
				case InputButton.DoubleTap:
					InputValue = ((type == InputType.Input) ? InputSystem.GetButton(input) : Input.GetKey(key));
					if (inputValue == InputValue)
					{
						break;
					}
					OnInputChanged.Invoke(InputValue);
					if (InputValue)
					{
						if (InputStartTime != 0f && MTools.ElapsedTime(InputStartTime, DoubleTapTime))
						{
							FirstInputPress = false;
						}
						if (!FirstInputPress)
						{
							OnInputDown.Invoke();
							InputStartTime = Time.time;
							FirstInputPress = true;
						}
						else if (Time.time - InputStartTime <= DoubleTapTime)
						{
							FirstInputPress = false;
							InputStartTime = 0f;
							OnDoubleTap.Invoke();
						}
						else
						{
							FirstInputPress = false;
						}
					}
					break;
				case InputButton.Toggle:
					if ((type == InputType.Input) ? InputSystem.GetButtonDown(input) : Input.GetKeyDown(key))
					{
						InputValue = !InputValue;
						OnInputToggle.Invoke(InputValue);
						if (InputValue)
						{
							OnInputDown.Invoke();
						}
						else
						{
							OnInputUp.Invoke();
						}
					}
					break;
				case InputButton.Axis:
				{
					float axis = InputSystem.GetAxis(input);
					InputValue = Mathf.Abs(axis) > 0f;
					if (inputValue != InputValue)
					{
						if (InputValue)
						{
							OnInputDown.Invoke();
						}
						else
						{
							OnInputUp.Invoke();
							OnInputFloat.Invoke(0f);
						}
						OnInputChanged.Invoke(InputValue);
					}
					if (InputValue)
					{
						OnInputPressed.Invoke();
						OnInputFloat.Invoke(axis);
					}
					break;
				}
				}
				return InputValue;
				void ResetLongPress()
				{
					InputStartTime = 0f;
					OnInputUp.Invoke();
					FirstInputPress = false;
					InputCompleted = false;
				}
			}
		}

		public IInputSystem InputSystem
		{
			get
			{
				return inputSystem;
			}
			set
			{
				inputSystem = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public bool Active
		{
			get
			{
				return active.Value;
			}
			set
			{
				active.Value = value;
				if (value)
				{
					OnInputEnable.Invoke();
				}
				else
				{
					OnInputDisable.Invoke();
				}
			}
		}

		public InputButton Button => GetPressed;

		public UnityEvent InputDown => OnInputDown;

		public UnityEvent InputUp => OnInputUp;

		public BoolEvent InputChanged => OnInputChanged;

		public InputRow(KeyCode k)
		{
			active.Value = true;
			type = InputType.Key;
			key = k;
			GetPressed = InputButton.Down;
			inputSystem = new DefaultInput();
			ResetOnDisable = true;
		}

		public InputRow(string input, KeyCode key)
		{
			active.Value = true;
			type = InputType.Key;
			this.key = key;
			this.input = input;
			GetPressed = InputButton.Down;
			inputSystem = new DefaultInput();
			ResetOnDisable = true;
		}

		public InputRow(string unityInput, KeyCode k, InputButton pressed)
		{
			active.Value = true;
			type = InputType.Key;
			key = k;
			input = unityInput;
			GetPressed = InputButton.Down;
			inputSystem = new DefaultInput();
			ResetOnDisable = true;
		}

		public InputRow(string name, string unityInput, KeyCode k, InputButton pressed, InputType itype)
		{
			this.name = name;
			active.Value = true;
			type = itype;
			key = k;
			input = unityInput;
			GetPressed = pressed;
			inputSystem = new DefaultInput();
			ResetOnDisable = true;
		}

		public InputRow(bool active, string name, string unityInput, KeyCode k, InputButton pressed, InputType itype)
		{
			this.name = name;
			this.active.Value = active;
			type = itype;
			key = k;
			input = unityInput;
			GetPressed = pressed;
			inputSystem = new DefaultInput();
			ResetOnDisable = true;
		}

		public InputRow()
		{
			active.Value = true;
			name = "InputName";
			type = InputType.Input;
			input = "Value";
			key = KeyCode.A;
			GetPressed = InputButton.Press;
			inputSystem = new DefaultInput();
			ResetOnDisable = true;
		}
	}
}
