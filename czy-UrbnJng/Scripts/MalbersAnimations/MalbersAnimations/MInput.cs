using System;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/malbers-input")]
	[AddComponentMenu("Malbers/Input/MInput")]
	public class MInput : MonoBehaviour, IInputSource, IAnimatorListener
	{
		public IInputSystem Input_System;

		public List<InputRow> inputs = new List<InputRow>();

		public List<InputRow> AllInputs = new List<InputRow>();

		public List<MInputMap> actionMaps = new List<MInputMap>();

		public int ActiveMapIndex;

		public MInputMap DefaultMap;

		public MInputMap ActiveMap;

		[Tooltip("Reset All inputs if the Component is Disabled.")]
		public bool ResetAllInputsOnDisable = true;

		public bool showInputEvents;

		[Tooltip("It will reset the Inputs to False if the Game Window Loses Focus")]
		public bool ResetOnFocusLost;

		public UnityEvent OnInputEnabled = new UnityEvent();

		public UnityEvent OnInputDisabled = new UnityEvent();

		public BoolEvent OnUsingGamePad = new BoolEvent();

		[Tooltip("Inputs won't work on Time.Scale = 0")]
		public BoolReference IgnoreOnPause = new BoolReference(value: true);

		public string PlayerID = "Player0";

		protected bool usingGamePad;

		protected Vector3 currentMousePosition;

		public bool MoveCharacter { get; set; }

		public Action<Vector3> OnMoveAxis { get; set; } = delegate
		{
		};

		public Vector3 MoveAxis { get; set; }

		Transform IInputSource.transform => base.transform;

		Transform IAnimatorListener.transform => base.transform;

		private void Awake()
		{
			Initialize();
		}

		public void SetMap(int map)
		{
			if (map == 0)
			{
				ActiveMap = DefaultMap;
				ActiveMapIndex = 0;
			}
			else
			{
				int num = Mathf.Clamp(map - 1, 0, actionMaps.Count);
				ActiveMap = actionMaps[num];
				ActiveMapIndex = num + 1;
			}
		}

		public virtual void RemapInput(string name, KeyCode newKeyCode)
		{
			InputRow inputRow = ActiveMap.inputs.Find((InputRow inputs) => inputs.name == name);
			if (inputRow != null && inputRow.type == InputType.Key)
			{
				inputRow.key = newKeyCode;
			}
		}

		public virtual void RemapInput(string name, string newInput)
		{
			InputRow inputRow = ActiveMap.inputs.Find((InputRow inputs) => inputs.name == name);
			if (inputRow != null && inputRow.type == InputType.Input)
			{
				inputRow.input = newInput;
			}
		}

		public virtual void SetMap(string map)
		{
			if (DefaultMap.name == map)
			{
				ResetMap();
				return;
			}
			int num = actionMaps.FindIndex((MInputMap x) => x.name == map);
			if (num != -1)
			{
				ActiveMap = actionMaps[num];
				ActiveMapIndex = num + 1;
			}
			else
			{
				Debug.Log("No Action Map was found with the name: " + map);
			}
		}

		public virtual void ResetMap()
		{
			ActiveMap = DefaultMap;
			ActiveMapIndex = 0;
		}

		protected virtual void Initialize()
		{
			InitializeDefaultMap();
			AllInputs = new List<InputRow>(inputs);
			if (actionMaps.Count > 0)
			{
				foreach (MInputMap actionMap in actionMaps)
				{
					AllInputs = AllInputs.Concat(actionMap.inputs).ToList();
				}
			}
			Input_System = DefaultInput.GetInputSystem(PlayerID);
			foreach (InputRow allInput in AllInputs)
			{
				allInput.InputSystem = Input_System;
			}
		}

		public virtual void InitializeDefaultMap()
		{
			DefaultMap = new MInputMap
			{
				name = new StringReference("Default"),
				inputs = inputs
			};
		}

		private void OnApplicationFocus(bool focus)
		{
			if (!focus && ResetOnFocusLost)
			{
				ResetInputs();
			}
		}

		public virtual void Enable(bool val)
		{
			base.enabled = val;
		}

		protected virtual void OnEnable()
		{
			OnInputEnabled.Invoke();
			SetMap(ActiveMapIndex);
		}

		protected virtual void OnDisable()
		{
			if (Application.isPlaying && base.gameObject.activeInHierarchy)
			{
				OnInputDisabled.Invoke();
				if (ResetAllInputsOnDisable)
				{
					ResetInputs();
				}
			}
		}

		public virtual void ResetInputs()
		{
			foreach (InputRow input in inputs)
			{
				if (input.ResetOnDisable && input.Active)
				{
					BoolEvent onInputChanged = input.OnInputChanged;
					bool arg = (input.InputValue = false);
					onInputChanged.Invoke(arg);
				}
			}
			foreach (MInputMap actionMap in actionMaps)
			{
				foreach (InputRow input2 in actionMap.inputs)
				{
					if (input2.ResetOnDisable && input2.Active)
					{
						BoolEvent onInputChanged2 = input2.OnInputChanged;
						bool arg = (input2.InputValue = false);
						onInputChanged2.Invoke(arg);
					}
				}
			}
		}

		private void Update()
		{
			SetInput();
		}

		protected virtual void SetInput()
		{
			if (IgnoreOnPause.Value && Time.timeScale == 0f)
			{
				return;
			}
			foreach (InputRow input in ActiveMap.inputs)
			{
				_ = input.GetValue;
			}
			CheckDevice();
		}

		protected virtual void CheckDevice()
		{
			if (IsJoystickInput())
			{
				if (!usingGamePad)
				{
					usingGamePad = true;
					OnUsingGamePad.Invoke(arg0: true);
				}
			}
			else if (IsMouseAndKeyboard() && usingGamePad)
			{
				usingGamePad = false;
				OnUsingGamePad.Invoke(arg0: false);
			}
			currentMousePosition = Input.mousePosition;
		}

		protected virtual bool IsJoystickInput()
		{
			if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Joystick1Button8) || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button10) || Input.GetKey(KeyCode.Joystick1Button11) || Input.GetKey(KeyCode.Joystick1Button12) || Input.GetKey(KeyCode.Joystick1Button13) || Input.GetKey(KeyCode.Joystick1Button14) || Input.GetKey(KeyCode.Joystick1Button15) || Input.GetKey(KeyCode.Joystick1Button16) || Input.GetKey(KeyCode.Joystick1Button17) || Input.GetKey(KeyCode.Joystick1Button18) || Input.GetKey(KeyCode.Joystick1Button19))
			{
				return true;
			}
			return false;
		}

		protected virtual bool IsMouseAndKeyboard()
		{
			if (Input.anyKey || Input.GetMouseButton(0))
			{
				return true;
			}
			if ((Input.mousePosition - currentMousePosition).sqrMagnitude > 0.01f)
			{
				return true;
			}
			return false;
		}

		public virtual void EnableInput(string name, bool value)
		{
			string[] array = name.Split(',');
			foreach (string text in array)
			{
				for (int j = 0; j < AllInputs.Count; j++)
				{
					if (AllInputs[j].name == text)
					{
						AllInputs[j].Active = value;
					}
				}
			}
		}

		public virtual void ResetOnDisableInput(string name, bool value)
		{
			string[] array = name.Split(',');
			foreach (string text in array)
			{
				for (int j = 0; j < AllInputs.Count; j++)
				{
					if (AllInputs[j].name == text)
					{
						AllInputs[j].ResetOnDisable = value;
					}
				}
			}
		}

		public virtual void IgnoreOnPauseInput(string name, bool value)
		{
			string[] array = name.Split(',');
			foreach (string text in array)
			{
				for (int j = 0; j < AllInputs.Count; j++)
				{
					if (AllInputs[j].name == text)
					{
						AllInputs[j].ignoreOnPause.Value = value;
					}
				}
			}
		}

		public virtual void SetInput(string name, bool value)
		{
			for (int i = 0; i < AllInputs.Count; i++)
			{
				if (AllInputs[i].name == name)
				{
					AllInputs[i].InputValue = value;
				}
			}
		}

		public virtual void ResetInput(string name)
		{
			for (int i = 0; i < AllInputs.Count; i++)
			{
				if (AllInputs[i].name == name)
				{
					AllInputs[i].InputValue = false;
				}
			}
		}

		public virtual void EnableInput(string name)
		{
			EnableInput(name, value: true);
		}

		public virtual void DisableInput(string name)
		{
			EnableInput(name, value: false);
		}

		public virtual bool IsActive(string name)
		{
			return GetInput(name)?.Active ?? false;
		}

		public virtual InputRow FindInput(string name)
		{
			if (ActiveMap == null)
			{
				return null;
			}
			return ActiveMap.inputs.Find((InputRow item) => item.name == name);
		}

		public IInputAction GetInput(string name)
		{
			return AllInputs.Find((InputRow item) => item.name == name);
		}

		public void ConnectInput(string name, UnityAction<bool> action)
		{
			if (string.IsNullOrEmpty(name))
			{
				return;
			}
			foreach (InputRow item in AllInputs.FindAll((InputRow item) => item.name == name))
			{
				item.InputChanged.AddListener(action);
			}
		}

		public void DisconnectInput(string name, UnityAction<bool> action)
		{
			if (string.IsNullOrEmpty(name))
			{
				return;
			}
			foreach (InputRow item in AllInputs.FindAll((InputRow item) => item.name == name))
			{
				item.InputChanged.RemoveListener(action);
			}
		}

		public void PlayerInput(IInputSource player)
		{
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
