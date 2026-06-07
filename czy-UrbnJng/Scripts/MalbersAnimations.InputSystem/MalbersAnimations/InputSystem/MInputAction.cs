using System;
using System.Collections;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MalbersAnimations.InputSystem
{
	[Serializable]
	public class MInputAction : IInputAction
	{
		public InputActionReference reference;

		public BoolReference active = new BoolReference(value: true);

		[Tooltip("If the Input Component gets disable the Input will be set to false and it will send false to all its listeners")]
		public BoolReference ResetOnDisable = new BoolReference(value: true);

		[Tooltip("Input will not work on Time.Scale = 0")]
		public BoolReference ignoreOnPause = new BoolReference();

		public MInputInteraction interaction;

		internal MonoBehaviour MCoroutine;

		private IEnumerator C_Press;

		private IEnumerator C_LongPress;

		public FloatReference DoubleTapTime = new FloatReference(0.3f);

		public FloatReference LongPressTime = new FloatReference(0.5f);

		public FloatReference PressThreshold = new FloatReference(0.5f);

		public FloatReference Vector2Mult = new FloatReference(1f);

		private bool FirstInputPress;

		private bool InputCompleted;

		private float InputStartTime;

		public bool debug;

		public string name = "InputName";

		private bool inputValue;

		public UnityEvent OnInputDown = new UnityEvent();

		public UnityEvent OnInputEnabled = new UnityEvent();

		public UnityEvent OnInputDisabled = new UnityEvent();

		public UnityEvent OnInputUp = new UnityEvent();

		public UnityEvent OnLongPress = new UnityEvent();

		public UnityEvent OnDoubleTap = new UnityEvent();

		public BoolEvent OnInputChanged = new BoolEvent();

		public UnityEvent OnInputPressed = new UnityEvent();

		public FloatEvent OnInputFloatValue = new FloatEvent();

		public Vector2Event OnInputV2Value = new Vector2Event();

		public InputAction action { get; set; }

		public string Name => name;

		public bool Active
		{
			get
			{
				return active.Value;
			}
			set
			{
				active.Value = value;
				if (Application.isPlaying)
				{
					if (value)
					{
						action.Enable();
						OnInputEnabled.Invoke();
					}
					else
					{
						action.Disable();
						OnInputDisabled.Invoke();
					}
				}
			}
		}

		public bool InputValue
		{
			get
			{
				return inputValue;
			}
			set
			{
				if (inputValue != value)
				{
					inputValue = value;
					DebbugInput(value);
				}
			}
		}

		public virtual bool GetValue
		{
			get
			{
				return inputValue;
			}
			set
			{
				inputValue = value;
			}
		}

		public UnityEvent InputDown => OnInputDown;

		public UnityEvent InputUp => OnInputUp;

		public BoolEvent InputChanged => OnInputChanged;

		private void DebbugInput(bool value)
		{
		}

		public void TranslateInput(InputAction.CallbackContext context)
		{
			if (!Active || ((bool)ignoreOnPause && Time.timeScale == 0f))
			{
				return;
			}
			bool flag = InputValue;
			bool flag2 = context.performed || context.started;
			switch (interaction)
			{
			case MInputInteraction.Press:
				InputValue = flag2;
				if (flag != InputValue)
				{
					if (InputValue)
					{
						OnInputDown.Invoke();
						DoPress();
					}
					else
					{
						OnInputUp.Invoke();
					}
					OnInputChanged.Invoke(InputValue);
				}
				break;
			case MInputInteraction.Down:
				if (context.phase == InputActionPhase.Started)
				{
					OnInputDown.Invoke();
					BoolEvent onInputChanged3 = OnInputChanged;
					bool arg = (InputValue = true);
					onInputChanged3.Invoke(arg);
				}
				else if (context.phase == InputActionPhase.Performed)
				{
					BoolEvent onInputChanged4 = OnInputChanged;
					bool arg = (InputValue = false);
					onInputChanged4.Invoke(arg);
				}
				break;
			case MInputInteraction.Up:
				if (context.phase == InputActionPhase.Canceled)
				{
					OnInputUp.Invoke();
					BoolEvent onInputChanged = OnInputChanged;
					bool arg = (InputValue = true);
					onInputChanged.Invoke(arg);
					MCoroutine.StartCoroutine(IEnum_UpRelease());
				}
				break;
			case MInputInteraction.LongPress:
				if (context.phase == InputActionPhase.Performed)
				{
					DoLongPressed();
				}
				else
				{
					if (context.phase != InputActionPhase.Canceled)
					{
						break;
					}
					if (!InputCompleted)
					{
						OnInputUp.Invoke();
						if (C_LongPress != null)
						{
							MCoroutine.StopCoroutine(C_LongPress);
						}
					}
					InputCompleted = false;
					BoolEvent onInputChanged2 = OnInputChanged;
					bool arg = (InputValue = false);
					onInputChanged2.Invoke(arg);
				}
				break;
			case MInputInteraction.DoubleTap:
				InputValue = flag2;
				if (flag == InputValue)
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
					else if (Time.time - InputStartTime <= (float)DoubleTapTime)
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
			case MInputInteraction.Toggle:
				if (context.phase == InputActionPhase.Started)
				{
					InputValue = !InputValue;
					OnInputChanged.Invoke(InputValue);
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
			case MInputInteraction.Float:
			{
				float num = context.action.ReadValue<float>();
				InputValue = num != 0f;
				if (flag != InputValue)
				{
					OnInputChanged.Invoke(InputValue);
					if (InputValue)
					{
						OnInputDown.Invoke();
					}
					else
					{
						OnInputUp.Invoke();
					}
				}
				if (num > PressThreshold.Value)
				{
					OnInputPressed.Invoke();
				}
				if (debug)
				{
					Debug.Log($"<color=cyan><B>[Input {name} : {num}]</B></color>");
				}
				OnInputFloatValue.Invoke(num);
				break;
			}
			case MInputInteraction.Vector2:
			{
				Vector2 vector = context.action.ReadValue<Vector2>();
				InputValue = vector != Vector2.zero;
				if (flag != InputValue)
				{
					OnInputChanged.Invoke(InputValue);
					if (InputValue)
					{
						OnInputDown.Invoke();
					}
					else
					{
						OnInputUp.Invoke();
					}
				}
				if (InputValue)
				{
					OnInputPressed.Invoke();
				}
				if (debug)
				{
					Debug.Log($"<color=cyan><B>[Input {name} : {vector}]</B></color>");
				}
				OnInputV2Value.Invoke(vector * Vector2Mult);
				break;
			}
			}
		}

		private void DoPress()
		{
			if (C_Press != null)
			{
				MCoroutine.StopCoroutine(C_Press);
			}
			C_Press = IEnum_Press();
			MCoroutine.StartCoroutine(C_Press);
		}

		private void DoLongPressed()
		{
			if (C_LongPress != null)
			{
				MCoroutine.StopCoroutine(C_LongPress);
			}
			C_LongPress = IEnum_LongPress();
			MCoroutine.StartCoroutine(C_LongPress);
		}

		private IEnumerator IEnum_Press()
		{
			while (InputValue)
			{
				OnInputPressed.Invoke();
				yield return null;
			}
		}

		private IEnumerator IEnum_UpRelease()
		{
			yield return null;
			BoolEvent onInputChanged = OnInputChanged;
			MInputAction mInputAction = this;
			bool arg = false;
			mInputAction.InputValue = false;
			onInputChanged.Invoke(arg);
		}

		private IEnumerator IEnum_LongPress()
		{
			InputStartTime = Time.time;
			InputCompleted = false;
			OnInputDown.Invoke();
			BoolEvent onInputChanged = OnInputChanged;
			MInputAction mInputAction = this;
			bool arg = true;
			mInputAction.InputValue = true;
			onInputChanged.Invoke(arg);
			while (!InputCompleted)
			{
				float num = (Time.time - InputStartTime) / (float)LongPressTime;
				OnInputFloatValue.Invoke(num);
				if (num >= 1f)
				{
					OnInputFloatValue.Invoke(1f);
					OnLongPress.Invoke();
					InputCompleted = true;
					InputValue = true;
					break;
				}
				yield return null;
			}
		}

		public MInputAction(string name)
		{
			active.Value = true;
			this.name = name;
			interaction = MInputInteraction.Down;
			reference = null;
			action = null;
			DoubleTapTime = new FloatReference(0.3f);
			LongPressTime = new FloatReference(0.5f);
		}

		public MInputAction(string name, MInputInteraction pressed)
		{
			this.name = name;
			active.Value = true;
			interaction = pressed;
			reference = null;
			DoubleTapTime = new FloatReference(0.3f);
			LongPressTime = new FloatReference(0.5f);
		}

		public MInputAction(string name, InputActionReference reference)
		{
			this.name = name;
			active.Value = true;
			interaction = MInputInteraction.Down;
			this.reference = reference;
			DoubleTapTime = new FloatReference(0.3f);
			LongPressTime = new FloatReference(0.5f);
		}

		public MInputAction(string name, InputActionReference reference, MInputInteraction pressed)
		{
			this.name = name;
			active.Value = true;
			interaction = pressed;
			this.reference = reference;
			DoubleTapTime = new FloatReference(0.3f);
			LongPressTime = new FloatReference(0.5f);
		}

		public MInputAction(bool active, string name, MInputInteraction pressed)
		{
			this.name = name;
			this.active.Value = active;
			interaction = pressed;
			DoubleTapTime = new FloatReference(0.3f);
			LongPressTime = new FloatReference(0.5f);
		}

		public MInputAction()
		{
			active.Value = true;
			name = "InputName";
			interaction = MInputInteraction.Press;
			reference = null;
			DoubleTapTime = new FloatReference(0.3f);
			LongPressTime = new FloatReference(0.5f);
		}
	}
}
