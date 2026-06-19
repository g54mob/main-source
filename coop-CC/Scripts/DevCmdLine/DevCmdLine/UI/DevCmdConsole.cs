using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DevCmdLine.UI
{
	public class DevCmdConsole : MonoBehaviour
	{
		[SerializeField]
		private GameObject _container;

		[SerializeField]
		private TextMeshProUGUI _output;

		[SerializeField]
		private TMP_InputField _input;

		[SerializeField]
		private Scrollbar _scrollbar;

		[SerializeField]
		private UnityEvent _onConsoleClosed;

		[Space]
		[SerializeField]
		private DevCmdOptionsManagerUI _optionsUI;

		private bool _isOpen;

		private int _firstIndex;

		private int _entriesBuilt;

		private int _historyOffset = -1;

		private bool _hasTabbedOnce;

		private static List<string> _entries = new List<string>();

		private static List<string> _cmdHistory = new List<string>();

		private static StringBuilder _outputBuilder = new StringBuilder();

		private static DevCmdConsole _instance;

		private const int MAX_CHARACTERS_COUNT = 9999;

		public static bool isOpen
		{
			get
			{
				if (_instance != null)
				{
					return _instance._isOpen;
				}
				return false;
			}
		}

		public static void OpenConsole(DevCmdStartingSelectedButton starting)
		{
			if (_instance != null)
			{
				_instance.OpenConsoleInternal(starting);
			}
		}

		public static void CloseConsole()
		{
			if (_instance != null)
			{
				_instance.CloseConsoleInternal(invokeCallback: false);
			}
		}

		public static void ToggleConsole(DevCmdStartingSelectedButton starting)
		{
			if (_instance != null)
			{
				_instance.ToggleConsoleInternal(starting);
			}
		}

		public static void CloseConsoleWithCallback()
		{
			if (_instance != null)
			{
				_instance.CloseConsoleInternal(invokeCallback: true);
			}
		}

		public static void ClearConsole()
		{
			if (_instance != null)
			{
				_instance.ClearConsoleInternal();
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
			Application.logMessageReceivedThreaded += OnLogReceived;
		}

		private static void OnLogReceived(string condition, string stacktrace, LogType type)
		{
			lock (_entries)
			{
				string text;
				switch (type)
				{
				case LogType.Log:
					text = condition;
					break;
				case LogType.Warning:
					text = "<color=yellow>" + condition + "</color>";
					break;
				case LogType.Error:
				case LogType.Assert:
				case LogType.Exception:
					text = "<color=red>" + condition + "</color>";
					break;
				default:
					throw new InvalidEnumArgumentException();
				}
				if (text.Length > 9999 - Environment.NewLine.Length)
				{
					text = "<color=red>Log message too large!</color>";
				}
				_entries.Add(text);
			}
		}

		private void Awake()
		{
			_container.SetActive(value: false);
			_input.onValueChanged.AddListener(OnResetTabbed);
			_instance = this;
		}

		private void Update()
		{
			if (!_isOpen)
			{
				return;
			}
			lock (_entries)
			{
				if (_entriesBuilt < _entries.Count)
				{
					while (_entriesBuilt < _entries.Count)
					{
						_outputBuilder.AppendLine(_entries[_entriesBuilt]);
						_entriesBuilt++;
					}
					int i;
					for (i = 0; _outputBuilder.Length - i > 9999; i += _entries[_firstIndex++].Length + Environment.NewLine.Length)
					{
					}
					if (i > 0)
					{
						_outputBuilder.Remove(0, i);
					}
					_output.text = _outputBuilder.ToString();
					_scrollbar.value = 0f;
				}
			}
			if (!(EventSystem.current != null))
			{
				return;
			}
			if (EventSystem.current.currentSelectedGameObject == _input.gameObject)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				if (Keyboard.current != null)
				{
					flag = Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame;
					flag2 = Keyboard.current.tabKey.wasPressedThisFrame;
					flag3 = Keyboard.current.upArrowKey.wasPressedThisFrame;
					flag4 = Keyboard.current.downArrowKey.wasPressedThisFrame;
				}
				if (Gamepad.current != null)
				{
					flag = flag || Gamepad.current.buttonSouth.wasPressedThisFrame;
					flag3 = flag3 || Gamepad.current.leftStick.up.wasPressedThisFrame || Gamepad.current.dpad.up.wasPressedThisFrame;
					flag4 = flag4 || Gamepad.current.leftStick.down.wasPressedThisFrame || Gamepad.current.dpad.down.wasPressedThisFrame;
					flag5 = flag5 || Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current.leftStick.right.wasPressedThisFrame || Gamepad.current.dpad.right.wasPressedThisFrame;
				}
				if (flag)
				{
					try
					{
						string text = _input.text;
						if (!string.IsNullOrWhiteSpace(text))
						{
							_cmdHistory.Add(text);
							_historyOffset = -1;
							DevCmdManager.RunCommand(text);
						}
						return;
					}
					finally
					{
						_input.text = "";
						_input.caretPosition = 0;
						if (EventSystem.current != null)
						{
							EventSystem.current.SetSelectedGameObject(_input.gameObject);
							_input.OnPointerClick(new PointerEventData(EventSystem.current));
						}
					}
				}
				if (flag5)
				{
					EventSystem.current.SetSelectedGameObject(_optionsUI.GetFirstOption());
				}
				else if (flag2)
				{
					string text2 = _input.text;
					if (string.IsNullOrWhiteSpace(text2))
					{
						return;
					}
					_input.text = DevCmdManager.CompleteCmd(text2);
					_input.caretPosition = _input.text.Length;
					if (_hasTabbedOnce)
					{
						string[] completeOptions = DevCmdManager.GetCompleteOptions(_input.text);
						if (completeOptions.Length != 0)
						{
							string text3 = "";
							string[] array = completeOptions;
							foreach (string text4 in array)
							{
								text3 = text3 + text4 + "\n";
							}
							Debug.Log(text3);
						}
					}
					_hasTabbedOnce = true;
				}
				else if (_cmdHistory.Count > 0)
				{
					if (flag3)
					{
						_historyOffset = Mathf.Min(_historyOffset + 1, _cmdHistory.Count - 1);
						_input.text = _cmdHistory[_cmdHistory.Count - (1 + _historyOffset)];
						_input.caretPosition = _input.text.Length;
					}
					else if (flag4)
					{
						_historyOffset = Mathf.Max(_historyOffset - 1, 0);
						_input.text = _cmdHistory[_cmdHistory.Count - (1 + _historyOffset)];
						_input.caretPosition = _input.text.Length;
					}
				}
			}
			else
			{
				bool flag6 = false;
				if (Keyboard.current != null)
				{
					flag6 = Keyboard.current.escapeKey.wasPressedThisFrame;
				}
				if (Gamepad.current != null)
				{
					flag6 = flag6 || Gamepad.current.buttonEast.wasPressedThisFrame;
				}
				if (flag6)
				{
					_optionsUI.GoBack();
				}
			}
		}

		private void OnResetTabbed(string value)
		{
			_hasTabbedOnce = false;
		}

		private void OpenConsoleInternal(DevCmdStartingSelectedButton starting)
		{
			if (_isOpen)
			{
				return;
			}
			_isOpen = true;
			_container.SetActive(value: true);
			_input.text = "";
			_input.caretPosition = 0;
			_optionsUI.SetInitials(_input);
			if (EventSystem.current != null)
			{
				switch (starting)
				{
				case DevCmdStartingSelectedButton.Input:
					EventSystem.current.SetSelectedGameObject(_input.gameObject);
					_input.OnPointerClick(new PointerEventData(EventSystem.current));
					break;
				case DevCmdStartingSelectedButton.Option:
					EventSystem.current.SetSelectedGameObject(_optionsUI.GetFirstOption());
					break;
				default:
					Debug.LogError("[DevCmdLine] Unexpected enum type!");
					break;
				}
			}
		}

		private void CloseConsoleInternal(bool invokeCallback)
		{
			if (_isOpen)
			{
				_isOpen = false;
				_container.SetActive(value: false);
				if (invokeCallback && _onConsoleClosed != null)
				{
					_onConsoleClosed.Invoke();
				}
			}
		}

		private void ToggleConsoleInternal(DevCmdStartingSelectedButton starting)
		{
			if (_isOpen)
			{
				CloseConsoleInternal(invokeCallback: false);
			}
			else
			{
				OpenConsoleInternal(starting);
			}
		}

		private void ClearConsoleInternal()
		{
			lock (_entries)
			{
				_entries.Clear();
				_entriesBuilt = 0;
				_output.text = "";
				_outputBuilder.Clear();
			}
		}
	}
}
