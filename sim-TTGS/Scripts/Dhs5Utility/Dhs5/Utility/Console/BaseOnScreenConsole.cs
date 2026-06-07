using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dhs5.Utility.Console
{
	public abstract class BaseOnScreenConsole<T> : MonoBehaviour where T : BaseOnScreenConsole<T>
	{
		[Header("Inputs")]
		[SerializeField]
		protected InputAction m_openConsoleAction;

		[SerializeField]
		protected InputAction m_closeConsoleAction;

		protected GUIStyle m_inputStyle;

		protected GUIStyle m_validInputStyle;

		protected GUIStyle m_optionStyle;

		protected Color m_transparentBlack01 = new Color(0f, 0f, 0f, 0.1f);

		protected Color m_transparentBlack03 = new Color(0f, 0f, 0f, 0.3f);

		protected Color m_transparentBlack05 = new Color(0f, 0f, 0f, 0.5f);

		protected Color m_transparentBlack07 = new Color(0f, 0f, 0f, 0.7f);

		private bool m_justOpenedConsole;

		private string m_currentInputString;

		private bool m_isCurrentInputValid;

		private Vector2 m_optionsScrollPos;

		private Texture2D _whiteTexture;

		private int m_lastActivationChangeFrame = -1;

		private Dictionary<IConsoleCommand, ValidCommandCallback> m_registeredCommands = new Dictionary<IConsoleCommand, ValidCommandCallback>();

		private List<CommandArray> m_currentInputOptions = new List<CommandArray>();

		private int m_currentlySelectedOptionIndex = -1;

		private List<string> m_previousCommands = new List<string>();

		private int m_previousCommandMarker;

		private string m_currentlyEditedCommand;

		private const string InputControlName = "Command Input";

		private string m_inputStringBeforeChangeCheck;

		private Texture2D WhiteTexture
		{
			get
			{
				if (_whiteTexture == null)
				{
					_whiteTexture = new Texture2D(1, 1);
					_whiteTexture.SetPixel(0, 0, Color.white);
				}
				return _whiteTexture;
			}
		}

		public bool IsActive { get; private set; }

		private static T Instance { get; set; }

		public static event Action<string> ValidatedInConsole;

		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Instance = this as T;
		}

		protected virtual void OnEnable()
		{
			InitInputs();
		}

		protected virtual void OnDisable()
		{
			ClearInputs();
		}

		private void InitStyles()
		{
			m_inputStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleLeft,
				richText = false,
				wordWrap = false,
				fontSize = GetInputFontSize(),
				contentOffset = new Vector2(15f, 0f),
				normal = new GUIStyleState
				{
					textColor = GetInputTextColor()
				}
			};
			m_validInputStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleLeft,
				richText = false,
				wordWrap = false,
				fontSize = GetInputFontSize(),
				contentOffset = new Vector2(15f, 0f),
				normal = new GUIStyleState
				{
					textColor = GetValidInputTextColor()
				}
			};
			m_optionStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleLeft,
				richText = false,
				wordWrap = false,
				fontSize = GetOptionFontSize(),
				contentOffset = new Vector2(20f, 0f),
				normal = new GUIStyleState
				{
					textColor = GetOptionTextColor()
				}
			};
		}

		protected virtual int GetInputFontSize()
		{
			return 40;
		}

		protected virtual Color GetInputTextColor()
		{
			return Color.white;
		}

		protected virtual Color GetValidInputTextColor()
		{
			return Color.green;
		}

		protected virtual int GetOptionFontSize()
		{
			return 30;
		}

		protected virtual Color GetOptionTextColor()
		{
			return Color.white;
		}

		protected virtual void InitInputs()
		{
			RegisterInputs(register: true);
			EnableOpenConsoleInput(enable: true);
			EnableCloseConsoleInput(enable: true);
		}

		protected virtual void ClearInputs()
		{
			EnableOpenConsoleInput(enable: false);
			EnableCloseConsoleInput(enable: false);
			RegisterInputs(register: false);
		}

		private void RegisterInputs(bool register)
		{
			if (m_openConsoleAction != null)
			{
				if (register)
				{
					m_openConsoleAction.performed += OpenConsoleCallback;
				}
				else
				{
					m_openConsoleAction.performed -= OpenConsoleCallback;
				}
			}
			if (m_closeConsoleAction != null)
			{
				if (register)
				{
					m_closeConsoleAction.performed += CloseConsoleCallback;
				}
				else
				{
					m_closeConsoleAction.performed -= CloseConsoleCallback;
				}
			}
		}

		protected void EnableOpenConsoleInput(bool enable)
		{
			if (m_openConsoleAction != null)
			{
				if (enable)
				{
					m_openConsoleAction.Enable();
				}
				else
				{
					m_openConsoleAction.Disable();
				}
			}
		}

		protected void EnableCloseConsoleInput(bool enable)
		{
			if (m_closeConsoleAction != null)
			{
				if (enable)
				{
					m_closeConsoleAction.Enable();
				}
				else
				{
					m_closeConsoleAction.Disable();
				}
			}
		}

		protected void OpenConsole()
		{
			if (!IsActive && m_lastActivationChangeFrame != Time.frameCount)
			{
				m_lastActivationChangeFrame = Time.frameCount;
				IsActive = true;
				m_currentInputString = string.Empty;
				m_justOpenedConsole = true;
				InitStyles();
				OnOpenConsole();
			}
		}

		private void OpenConsoleCallback(InputAction.CallbackContext callbackContext)
		{
			OpenConsole();
		}

		protected void CloseConsole()
		{
			if (IsActive && m_lastActivationChangeFrame != Time.frameCount)
			{
				m_lastActivationChangeFrame = Time.frameCount;
				IsActive = false;
				OnCloseConsole();
			}
		}

		private void CloseConsoleCallback(InputAction.CallbackContext callbackContext)
		{
			CloseConsole();
		}

		protected virtual void OnOpenConsole()
		{
		}

		protected virtual void OnCloseConsole()
		{
		}

		protected void RegisterCommand(IConsoleCommand command, ValidCommandCallback callback)
		{
			if (m_registeredCommands.ContainsKey(command))
			{
				Dictionary<IConsoleCommand, ValidCommandCallback> registeredCommands = m_registeredCommands;
				registeredCommands[command] = (ValidCommandCallback)Delegate.Combine(registeredCommands[command], callback);
			}
			else
			{
				m_registeredCommands.Add(command, callback);
			}
		}

		protected void UnregisterCommand(IConsoleCommand command, ValidCommandCallback callback)
		{
			if (m_registeredCommands.ContainsKey(command))
			{
				Dictionary<IConsoleCommand, ValidCommandCallback> registeredCommands = m_registeredCommands;
				registeredCommands[command] = (ValidCommandCallback)Delegate.Remove(registeredCommands[command], callback);
			}
		}

		protected void UnregisterCommand(IConsoleCommand command)
		{
			m_registeredCommands.Remove(command);
		}

		protected virtual void OnRegisteredCommandsChanged()
		{
			RecomputeOptions();
			RecomputeCurrentInputValidity();
		}

		private void RecomputeOptions()
		{
			m_currentInputOptions.Clear();
			if (!string.IsNullOrWhiteSpace(m_currentInputString))
			{
				foreach (IConsoleCommand key in m_registeredCommands.Keys)
				{
					foreach (CommandArray item in key.GetCommandOptionsStartingWith(m_currentInputString))
					{
						m_currentInputOptions.Add(item);
					}
				}
			}
			m_optionsScrollPos = new Vector2(0f, GetOptionRectHeight() * (float)Mathf.Max(0, m_currentInputOptions.Count - GetMaxOptionsDisplayed()));
			m_currentlySelectedOptionIndex = -1;
		}

		private void FillWithOptionAtIndex(int index)
		{
			m_currentInputString = m_currentInputOptions[index].ToStringWithoutParams();
			OnInputStringChanged();
		}

		private void OnSelectUpOption()
		{
			if (m_currentInputOptions.IsValid())
			{
				m_currentlySelectedOptionIndex = Mathf.Clamp(m_currentlySelectedOptionIndex + 1, 0, m_currentInputOptions.Count - 1);
			}
		}

		private void OnSelectDownOption()
		{
			if (m_currentInputOptions.IsValid())
			{
				m_currentlySelectedOptionIndex = Mathf.Clamp(m_currentlySelectedOptionIndex - 1, -1, m_currentInputOptions.Count - 1);
			}
		}

		private void FillWithSelectedOption()
		{
			if (m_currentlySelectedOptionIndex != -1)
			{
				FillWithOptionAtIndex(m_currentlySelectedOptionIndex);
			}
			else if (m_currentInputOptions.IsValid())
			{
				FillWithOptionAtIndex(0);
			}
		}

		private void RecomputeCurrentInputValidity()
		{
			m_isCurrentInputValid = false;
			foreach (IConsoleCommand key in m_registeredCommands.Keys)
			{
				if (key.IsCommandValid(m_currentInputString, out var _))
				{
					m_isCurrentInputValid = true;
					break;
				}
			}
		}

		private void Validate()
		{
			foreach (var (consoleCommand2, validCommandCallback2) in m_registeredCommands)
			{
				if (consoleCommand2.IsCommandValid(m_currentInputString, out var validCommand))
				{
					validCommandCallback2?.Invoke(validCommand);
				}
			}
			BaseOnScreenConsole<T>.ValidatedInConsole?.Invoke(m_currentInputString);
			AddToPreviousCommands(m_currentInputString);
			m_currentInputString = string.Empty;
		}

		private void AddToPreviousCommands(string cmd)
		{
			if (m_previousCommands.Count > 100)
			{
				m_previousCommands.RemoveAt(0);
			}
			m_previousCommands.Add(cmd);
			m_previousCommandMarker = m_previousCommands.Count;
		}

		private void OnGetPreviousCommand()
		{
			if (m_previousCommands.IsValid())
			{
				m_previousCommandMarker = Mathf.Clamp(m_previousCommandMarker - 1, 0, m_previousCommands.Count - 1);
				m_currentInputString = m_previousCommands[m_previousCommandMarker];
				OnInputStringChanged();
			}
		}

		private void OnGetNextCommand()
		{
			if (m_previousCommands.IsValid())
			{
				m_previousCommandMarker = Mathf.Clamp(m_previousCommandMarker + 1, 0, m_previousCommands.Count);
				m_currentInputString = ((m_previousCommandMarker == m_previousCommands.Count) ? m_currentlyEditedCommand : m_previousCommands[m_previousCommandMarker]);
				OnInputStringChanged();
			}
		}

		private void OnPlayerInput()
		{
			m_currentlyEditedCommand = m_currentInputString;
			m_previousCommandMarker = m_previousCommands.Count;
			OnInputStringChanged();
		}

		private void OnInputStringChanged()
		{
			RecomputeOptions();
			RecomputeCurrentInputValidity();
		}

		private void OnGUI()
		{
			if (IsActive)
			{
				float inputRectHeight = GetInputRectHeight();
				Rect rect = new Rect(0f, (float)Screen.height - inputRectHeight, (float)Screen.width * 0.8f, inputRectHeight);
				bool flag = GUI.GetNameOfFocusedControl() == "Command Input";
				OnHandleEvents(flag);
				OnInputGUI(rect, flag);
				if (flag && !string.IsNullOrWhiteSpace(m_currentInputString))
				{
					OnOptionsGUI(rect.y, rect.width);
				}
			}
		}

		private void OnHandleEvents(bool hasFocus)
		{
			if (!hasFocus || Event.current.type != EventType.KeyDown)
			{
				return;
			}
			switch (Event.current.keyCode)
			{
			case KeyCode.Return:
				Event.current.Use();
				Validate();
				break;
			case KeyCode.Tab:
				FillWithSelectedOption();
				Event.current.Use();
				break;
			case KeyCode.UpArrow:
				if (Event.current.modifiers.HasFlag(EventModifiers.Control))
				{
					OnGetPreviousCommand();
				}
				else
				{
					OnSelectUpOption();
				}
				Event.current.Use();
				break;
			case KeyCode.DownArrow:
				if (Event.current.modifiers.HasFlag(EventModifiers.Control))
				{
					OnGetNextCommand();
				}
				else
				{
					OnSelectDownOption();
				}
				Event.current.Use();
				break;
			}
		}

		private void OnInputGUI(Rect rect, bool hasFocus)
		{
			DrawRect(rect, hasFocus ? m_transparentBlack07 : m_transparentBlack03);
			GUI.SetNextControlName("Command Input");
			BeginInputChangeCheck();
			m_currentInputString = GUI.TextField(rect, m_currentInputString, m_isCurrentInputValid ? m_validInputStyle : m_inputStyle);
			if (EndInputChangeCheck())
			{
				OnPlayerInput();
			}
			if (m_justOpenedConsole)
			{
				m_justOpenedConsole = false;
				GUI.FocusControl("Command Input");
			}
		}

		private void OnOptionsGUI(float y, float width)
		{
			float optionRectHeight = GetOptionRectHeight();
			float num = optionRectHeight * (float)GetMaxOptionsDisplayed();
			Rect rect = new Rect(0f, y - num, width, num);
			Rect viewRect = new Rect(0f, 0f, width - 25f, Mathf.Max(num, optionRectHeight * (float)m_currentInputOptions.Count));
			DrawRect(rect, m_transparentBlack01);
			m_optionsScrollPos = GUI.BeginScrollView(rect, m_optionsScrollPos, viewRect);
			Rect rect2 = new Rect(0f, viewRect.height, viewRect.width, optionRectHeight);
			bool flag = false;
			for (int i = 0; i < m_currentInputOptions.Count; i++)
			{
				flag = m_currentlySelectedOptionIndex == i;
				rect2.y -= optionRectHeight;
				DrawRect(rect2, flag ? Color.black : ((i % 2 == 0) ? m_transparentBlack03 : m_transparentBlack05));
				if (GUI.Button(rect2, m_currentInputOptions[i].ToString(), m_optionStyle))
				{
					FillWithOptionAtIndex(i);
				}
			}
			GUI.EndScrollView();
		}

		protected virtual float GetInputRectHeight()
		{
			return 50f;
		}

		protected virtual float GetOptionRectHeight()
		{
			return 30f;
		}

		protected virtual int GetMaxOptionsDisplayed()
		{
			return 10;
		}

		private void DrawRect(Rect rect, Color color)
		{
			if (Event.current.type == EventType.Repaint)
			{
				Color color2 = GUI.color;
				GUI.color *= color;
				GUI.DrawTexture(rect, WhiteTexture);
				GUI.color = color2;
			}
		}

		public void BeginInputChangeCheck()
		{
			m_inputStringBeforeChangeCheck = m_currentInputString;
		}

		public bool EndInputChangeCheck()
		{
			return m_inputStringBeforeChangeCheck != m_currentInputString;
		}

		private static void CreateInstance()
		{
			new GameObject("OnScreen Console").AddComponent<T>();
		}

		private static T GetInstance()
		{
			if (Instance == null)
			{
				CreateInstance();
			}
			return Instance;
		}

		public static void Init()
		{
			GetInstance();
		}

		public static void Open()
		{
			GetInstance().OpenConsole();
		}

		public static void Close()
		{
			GetInstance().CloseConsole();
		}

		public static bool Register(IConsoleCommand command, ValidCommandCallback callback)
		{
			if (command.IsValid())
			{
				GetInstance().RegisterCommand(command, callback);
				return true;
			}
			return false;
		}

		public static void Unregister(IConsoleCommand command, ValidCommandCallback callback)
		{
			GetInstance().UnregisterCommand(command, callback);
		}

		public static void Unregister(IConsoleCommand command)
		{
			GetInstance().UnregisterCommand(command);
		}
	}
}
