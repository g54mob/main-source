using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Packages.DevConsole.Commands;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Packages.DevConsole
{
	public class DeveloperConsole : MonoBehaviour
	{
		private struct AutoCompleteItem
		{
			public Component Component { get; private set; }

			public RegisteredCommandInfo? CustomCommandInfo { get; private set; }

			public string DisplayText { get; private set; }

			public GameObject GameObject { get; private set; }

			public MemberInfo Member { get; private set; }

			public string Text { get; private set; }

			public AutoCompleteItem(GameObject obj)
			{
				this = default(AutoCompleteItem);
				GameObject = obj;
				Text = obj.name;
				DisplayText = obj.name;
			}

			public AutoCompleteItem(Component component, bool displayGameObjectName)
			{
				this = default(AutoCompleteItem);
				Component = component;
				Text = component.GetType().Name;
				DisplayText = Text;
				if (displayGameObjectName)
				{
					DisplayText = DisplayText + " - (" + component.gameObject.name + ")";
				}
			}

			public AutoCompleteItem(MemberInfo member)
			{
				this = default(AutoCompleteItem);
				Member = member;
				Text = member.Name;
				if (member.MemberType == MemberTypes.Method)
				{
					MethodInfo methodInfo = (MethodInfo)member;
					ParameterInfo[] parameters = methodInfo.GetParameters();
					DisplayText = string.Format("{0} {1}({2})", (methodInfo.ReturnType == typeof(void)) ? "void" : methodInfo.ReturnType.Name, member.Name, string.Join(", ", parameters.Select((ParameterInfo x) => x.ParameterType.Name).ToArray()));
				}
				else if (member.MemberType == MemberTypes.Property)
				{
					PropertyInfo propertyInfo = (PropertyInfo)member;
					DisplayText = string.Format("{0} {1} {{{2}{3} }}", propertyInfo.PropertyType.Name, propertyInfo.Name, (propertyInfo.GetGetMethod(nonPublic: true) == null) ? string.Empty : " get;", (propertyInfo.GetSetMethod(nonPublic: true) == null) ? string.Empty : " set;");
				}
				else if (member.MemberType == MemberTypes.Field)
				{
					FieldInfo fieldInfo = (FieldInfo)member;
					DisplayText = $"{fieldInfo.FieldType.Name} {fieldInfo.Name}";
				}
				else
				{
					DisplayText = member.Name;
				}
			}

			public AutoCompleteItem(RegisteredCommandInfo command)
			{
				this = default(AutoCompleteItem);
				CustomCommandInfo = command;
				Text = command.CommandText;
				string text = string.Empty;
				for (int i = 0; i < command.Parameters.Length; i++)
				{
					string name = command.Parameters[i].ParameterType.Name;
					string text2 = ((command.ParameterNames.Length <= i) ? string.Empty : (command.ParameterNames[i] ?? string.Empty));
					text = text + " (" + name + ")" + text2;
				}
				DisplayText = string.Format("{0}{1}{2}", (command.ReturnType == typeof(void)) ? string.Empty : (command.ReturnType.Name + " "), command.CommandText, text);
			}
		}

		private struct AutoCompleteSelectedItem
		{
			public int Index { get; private set; }

			public AutoCompleteItem Item { get; private set; }

			public AutoCompleteSelectedItem(AutoCompleteItem item, int index)
			{
				this = default(AutoCompleteSelectedItem);
				Item = item;
				Index = index;
			}
		}

		private List<Button> _autoCompleteButtons;

		[SerializeField]
		private GameObject _autoCompleteEntryParent;

		private float _autoCompleteInitialKeyUpDownTime;

		private List<AutoCompleteItem> _autoCompleteItems;

		private float _autoCompleteKeyUpDownTime;

		[SerializeField]
		private RectTransform _autoCompletePanelTransform;

		[SerializeField]
		private GameObject _autoCompletePopup;

		[SerializeField]
		private Scrollbar _autoCompleteScrollBar;

		private List<Text> _autoCompleteTexts;

		private int _autoCompleteVisibleIndexStart;

		[SerializeField]
		private LogEntryColors _colorSettings;

		private ConsoleCommand _command = new ConsoleCommand();

		[SerializeField]
		private ConsoleInputField _commandInputField;

		private List<LogEntry> _logEntries;

		private List<Button> _logEntryButtons;

		private List<Text> _logEntryComponents;

		[SerializeField]
		private GameObject _logEntryDetails;

		private Text _logEntryDetailsText;

		[SerializeField]
		private GameObject _logEntryParent;

		[SerializeField]
		[FormerlySerializedAs("LogScrollBar")]
		private Scrollbar _logScrollBar;

		private int _logVisibleStartIndex;

		[SerializeField]
		private int _maxLogMessages = 1000;

		[SerializeField]
		private int _maxLogMessagesCleanupCount = 100;

		[SerializeField]
		private int _maxRecentCommands = 20;

		[SerializeField]
		private GameObject _mobileButtonsPanel;

		private List<ConsoleCommand> _recentCommands;

		private int _recentCommandsCurrentIndex;

		private AutoCompleteSelectedItem? _selectedAutoCompleteItem;

		private int _selectedLogDetailsIndex;

		private bool _updatingAutoCompleteScrollBar;

		private bool _updatingLogScrollBar;

		public GameObject AutoCompleteEntryParent
		{
			get
			{
				return _autoCompleteEntryParent;
			}
			set
			{
				_autoCompleteEntryParent = value;
			}
		}

		public RectTransform AutoCompletePanelTransform
		{
			get
			{
				return _autoCompletePanelTransform;
			}
			set
			{
				_autoCompletePanelTransform = value;
			}
		}

		public GameObject AutoCompletePopup
		{
			get
			{
				return _autoCompletePopup;
			}
			set
			{
				_autoCompletePopup = value;
			}
		}

		public Scrollbar AutoCompleteScrollBar
		{
			get
			{
				return _autoCompleteScrollBar;
			}
			set
			{
				_autoCompleteScrollBar = value;
			}
		}

		public LogEntryColors ColorSettings
		{
			get
			{
				return _colorSettings;
			}
			set
			{
				_colorSettings = value;
			}
		}

		public ConsoleInputField CommandInputField
		{
			get
			{
				return _commandInputField;
			}
			set
			{
				_commandInputField = value;
			}
		}

		public bool IsOpen => base.gameObject.activeSelf;

		public GameObject LogEntryDetails
		{
			get
			{
				return _logEntryDetails;
			}
			set
			{
				_logEntryDetails = value;
			}
		}

		public GameObject LogEntryParent
		{
			get
			{
				return _logEntryParent;
			}
			set
			{
				_logEntryParent = value;
			}
		}

		public Scrollbar LogScrollBar
		{
			get
			{
				return _logScrollBar;
			}
			set
			{
				_logScrollBar = value;
			}
		}

		public int MaxLogMessages
		{
			get
			{
				return _maxLogMessages;
			}
			set
			{
				_maxLogMessages = value;
			}
		}

		public int MaxLogMessagesCleanupCount
		{
			get
			{
				return _maxLogMessagesCleanupCount;
			}
			set
			{
				_maxLogMessagesCleanupCount = value;
			}
		}

		public int MaxRecentCommands
		{
			get
			{
				return _maxRecentCommands;
			}
			set
			{
				_maxRecentCommands = value;
			}
		}

		public GameObject MobileButtonsPanel => _mobileButtonsPanel;

		public void AutoCompleteOnScroll(float value)
		{
			if (_updatingAutoCompleteScrollBar)
			{
				return;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				HandleArrowKeyUp(Input.GetKeyDown(KeyCode.UpArrow));
				return;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				HandleArrowKeyDown(Input.GetKeyDown(KeyCode.DownArrow));
				return;
			}
			int num = (int)(value * (float)AutoCompleteScrollBar.numberOfSteps);
			if (num == AutoCompleteScrollBar.numberOfSteps)
			{
				num--;
			}
			if (num != _autoCompleteVisibleIndexStart)
			{
				_autoCompleteVisibleIndexStart = num;
				UpdateVisibleAutoCompleteItems(num);
			}
		}

		public void ClearLog()
		{
			_logEntries.Clear();
			_logVisibleStartIndex = 0;
			UpdateVisibleLogs(0);
			UpdateLogScrollBar();
			LogEntryDetails.SetActive(value: false);
		}

		public void CloseConsole()
		{
			base.gameObject.SetActive(value: false);
		}

		public void ExecuteCommand(string command)
		{
			try
			{
				_command.ParseAndUpdate(command);
				if (_command.CommandSegments.Count > 0)
				{
					List<LogEntry> list = _command.Execute();
					for (int i = 0; i < list.Count; i++)
					{
						Log(list[i]);
					}
					_recentCommands.Add(_command.Clone());
					if (_recentCommands.Count > MaxRecentCommands)
					{
						_recentCommands = _recentCommands.Skip(_recentCommands.Count - MaxRecentCommands).ToList();
					}
					_recentCommandsCurrentIndex = _recentCommands.Count;
				}
			}
			finally
			{
				CommandInputField.text = string.Empty;
				CommandInputField.ActivateInputField();
			}
		}

		public bool HandleInputKeys()
		{
			bool result = false;
			if (Input.GetKey(KeyCode.BackQuote))
			{
				result = true;
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				result = HandleArrowKeyUp(Input.GetKeyDown(KeyCode.UpArrow));
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				result = HandleArrowKeyDown(Input.GetKeyDown(KeyCode.DownArrow));
			}
			else if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Space) || (Input.inputString == "." && !CommandInputField.text.EndsWith(".")) || (Input.inputString == ">" && !CommandInputField.text.EndsWith(">")) || (Input.inputString == "/" && !CommandInputField.text.EndsWith("/") && !CommandInputField.text.EndsWith("\\")) || (Input.inputString == "\\" && !CommandInputField.text.EndsWith("/") && !CommandInputField.text.EndsWith("\\")))
			{
				if (AutoCompletePopup.activeSelf && CommandInputField.IsCursorAtEnd)
				{
					HandleSelectAutoCompleteItem();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Return) && AutoCompletePopup.activeSelf && CommandInputField.IsCursorAtEnd)
			{
				result = true;
				HandleSelectAutoCompleteItem();
			}
			return result;
		}

		public void Log(LogEntry log)
		{
			_logEntries.Add(log);
			if (_logEntries.Count > MaxLogMessages)
			{
				_logEntries = _logEntries.Skip(MaxLogMessagesCleanupCount).ToList();
			}
			if (base.gameObject.activeSelf)
			{
				if (_logVisibleStartIndex != 0)
				{
					_logVisibleStartIndex++;
				}
				_logVisibleStartIndex = Math.Max(0, Math.Min(_logVisibleStartIndex, _logEntries.Count - 10));
				UpdateVisibleLogs(_logVisibleStartIndex);
				UpdateLogScrollBar();
			}
		}

		public void Log(string message, string details, LogType type)
		{
			Log(new LogEntry(message, details, type));
		}

		public void LogOnScroll(float value)
		{
			if (!_updatingLogScrollBar)
			{
				int num = (int)(value * (float)LogScrollBar.numberOfSteps);
				if (num == LogScrollBar.numberOfSteps)
				{
					num--;
				}
				if (num != _logVisibleStartIndex)
				{
					_logVisibleStartIndex = num;
					UpdateVisibleLogs(num);
				}
			}
		}

		public void LogOnScrollWheel(BaseEventData data)
		{
			PointerEventData pointerEventData = (PointerEventData)data;
			_logVisibleStartIndex += (int)pointerEventData.scrollDelta.y;
			_logVisibleStartIndex = Math.Max(0, Math.Min(_logVisibleStartIndex, _logEntries.Count - 10));
			UpdateVisibleLogs(_logVisibleStartIndex);
			UpdateLogScrollBar();
		}

		public void OnAutoCompleteEntryClicked(int selectedIndex)
		{
			int num = _autoCompleteVisibleIndexStart + selectedIndex;
			if (num >= 0 && num < _autoCompleteItems.Count)
			{
				_selectedAutoCompleteItem = new AutoCompleteSelectedItem(_autoCompleteItems[num], num);
				HandleSelectAutoCompleteItem();
			}
		}

		public void OnCommandChanged(string command)
		{
			_command.ParseAndUpdate(command);
			_command.Evaluate();
			UpdateAutoComplete();
		}

		public void OnCommandSubmitted(string command)
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				ExecuteCommand(command);
			}
		}

		public void OnExecuteButtonClicked()
		{
			ExecuteCommand(CommandInputField.text);
		}

		public void OnLogEntryClicked(int componentIndex)
		{
			int num = _logEntries.Count - (_logVisibleStartIndex + componentIndex) - 1;
			if (num >= 0)
			{
				LogEntry logEntry = _logEntries[num];
				string text = logEntry.Message + Environment.NewLine + logEntry.MessageDetails;
				if (_selectedLogDetailsIndex == componentIndex && LogEntryDetails.activeSelf && _logEntryDetailsText.text == text)
				{
					LogEntryDetails.SetActive(value: false);
				}
				else
				{
					_selectedLogDetailsIndex = componentIndex;
					_logEntryDetailsText.text = text;
					SetColors(logEntry.LogType, _logEntryDetailsText);
					LogEntryDetails.SetActive(value: true);
				}
			}
			EventSystem.current.SetSelectedGameObject(null);
		}

		public void OpenConsole()
		{
			base.gameObject.SetActive(value: true);
			UpdateVisibleLogs(0);
			UpdateLogScrollBar();
			CommandInputField.ActivateInputField();
		}

		private void Awake()
		{
			_logEntries = new List<LogEntry>();
			_logEntryComponents = new List<Text>();
			_autoCompleteItems = new List<AutoCompleteItem>();
			_recentCommands = new List<ConsoleCommand>();
			ColorSettings.Initialize();
			_logEntryComponents = (from x in LogEntryParent.GetComponentsInChildren<Text>()
				orderby x.name
				select x).ToList();
			_logEntryButtons = _logEntryComponents.Select((Text x) => x.GetComponent<Button>()).ToList();
			_logEntryDetailsText = LogEntryDetails.GetComponentsInChildren<Text>(includeInactive: true).First();
			_autoCompleteButtons = (from x in AutoCompleteEntryParent.GetComponentsInChildren<Button>(includeInactive: true)
				orderby x.name
				select x).ToList();
			_autoCompleteTexts = _autoCompleteButtons.Select((Button x) => x.GetComponentsInChildren<Text>(includeInactive: true)[0]).ToList();
			LogEntryDetails.SetActive(value: false);
			AutoCompletePanelTransform.gameObject.SetActive(value: false);
			_logEntryComponents.ForEach(delegate(Text x)
			{
				x.text = string.Empty;
			});
			_autoCompleteTexts.ForEach(delegate(Text x)
			{
				x.text = string.Empty;
			});
			Application.logMessageReceived += Log;
			if (Application.isMobilePlatform || Application.isEditor)
			{
				MobileButtonsPanel.SetActive(value: true);
				RectTransform component = MobileButtonsPanel.GetComponent<RectTransform>();
				float scaleFactor = (float)Screen.height / (Mathf.Abs(component.anchoredPosition.y) + component.sizeDelta.y);
				Canvas[] componentsInChildren = GetComponentsInChildren<Canvas>();
				for (int num = 0; num < componentsInChildren.Length; num++)
				{
					componentsInChildren[num].scaleFactor = scaleFactor;
				}
			}
			DevConsoleApi.RegisterCommand("ClearLog", ClearLog);
		}

		private void DeactivateAutoComplete()
		{
			AutoCompletePopup.SetActive(value: false);
		}

		private bool HandleArrowKeyDown(bool initialKeyDown)
		{
			if (initialKeyDown && CommandInputField.IsCursorAtStart)
			{
				_recentCommandsCurrentIndex++;
				if (_recentCommandsCurrentIndex > _recentCommands.Count)
				{
					_recentCommandsCurrentIndex = 0;
				}
				if (_recentCommandsCurrentIndex == _recentCommands.Count)
				{
					CommandInputField.text = string.Empty;
				}
				else
				{
					_command = _recentCommands[_recentCommandsCurrentIndex].Clone();
					CommandInputField.text = _command.ToString();
					CommandInputField.MoveTextEnd(shift: false);
					CommandInputField.MoveTextStart(shift: false);
				}
				return true;
			}
			if (!AutoCompletePanelTransform.gameObject.activeSelf)
			{
				return false;
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (initialKeyDown)
			{
				_autoCompleteInitialKeyUpDownTime = realtimeSinceStartup;
			}
			else if (realtimeSinceStartup - _autoCompleteKeyUpDownTime < 0.1f || realtimeSinceStartup - _autoCompleteInitialKeyUpDownTime < 0.5f)
			{
				return true;
			}
			_autoCompleteKeyUpDownTime = realtimeSinceStartup;
			bool flag = false;
			int num = _autoCompleteVisibleIndexStart;
			if (_selectedAutoCompleteItem.HasValue)
			{
				int num2 = _selectedAutoCompleteItem.Value.Index - 1;
				if (num2 >= 0)
				{
					_selectedAutoCompleteItem = new AutoCompleteSelectedItem(_autoCompleteItems[num2], num2);
					flag = true;
					if (num2 - num < 0)
					{
						num = num2;
					}
					else if (num2 > num + 9)
					{
						num = num2 - 9;
					}
				}
			}
			else if (_autoCompleteItems.Count > 0)
			{
				_selectedAutoCompleteItem = new AutoCompleteSelectedItem(_autoCompleteItems[0], 0);
				flag = true;
				num = 0;
			}
			if (flag)
			{
				_autoCompleteVisibleIndexStart = Math.Max(0, Math.Min(num, _autoCompleteItems.Count - 10));
				UpdateVisibleAutoCompleteItems(_autoCompleteVisibleIndexStart);
				UpdateAutoCompleteScrollBar();
			}
			return true;
		}

		private bool HandleArrowKeyUp(bool initialKeyDown)
		{
			if (initialKeyDown && CommandInputField.IsCursorAtStart)
			{
				_recentCommandsCurrentIndex--;
				if (_recentCommandsCurrentIndex < 0)
				{
					_recentCommandsCurrentIndex = _recentCommands.Count;
				}
				if (_recentCommandsCurrentIndex == _recentCommands.Count)
				{
					CommandInputField.text = string.Empty;
				}
				else
				{
					_command = _recentCommands[_recentCommandsCurrentIndex].Clone();
					CommandInputField.text = _command.ToString();
					CommandInputField.MoveTextEnd(shift: false);
					CommandInputField.MoveTextStart(shift: false);
				}
				return true;
			}
			if (!AutoCompletePanelTransform.gameObject.activeSelf)
			{
				return false;
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (initialKeyDown)
			{
				_autoCompleteInitialKeyUpDownTime = realtimeSinceStartup;
			}
			else if (realtimeSinceStartup - _autoCompleteKeyUpDownTime < 0.1f || realtimeSinceStartup - _autoCompleteInitialKeyUpDownTime < 0.5f)
			{
				return true;
			}
			_autoCompleteKeyUpDownTime = realtimeSinceStartup;
			bool flag = false;
			int num = _autoCompleteVisibleIndexStart;
			if (_selectedAutoCompleteItem.HasValue)
			{
				int num2 = _selectedAutoCompleteItem.Value.Index + 1;
				if (num2 < _autoCompleteItems.Count)
				{
					_selectedAutoCompleteItem = new AutoCompleteSelectedItem(_autoCompleteItems[num2], num2);
					flag = true;
					if (num2 - num > 9)
					{
						num = num2 - 9;
					}
					else if (num2 < num)
					{
						num = num2;
					}
				}
			}
			else if (_autoCompleteItems.Count > 0)
			{
				_selectedAutoCompleteItem = new AutoCompleteSelectedItem(_autoCompleteItems[0], 0);
				num = 0;
				flag = true;
			}
			if (flag)
			{
				_autoCompleteVisibleIndexStart = Math.Max(0, Math.Min(num, _autoCompleteItems.Count - 10));
				UpdateVisibleAutoCompleteItems(_autoCompleteVisibleIndexStart);
				UpdateAutoCompleteScrollBar();
			}
			return true;
		}

		private void HandleSelectAutoCompleteItem()
		{
			if (AutoCompletePopup.activeSelf && _selectedAutoCompleteItem.HasValue)
			{
				ConsoleCommandSegment consoleCommandSegment = _command.CommandSegments.Last();
				AutoCompleteItem item = _selectedAutoCompleteItem.Value.Item;
				switch (consoleCommandSegment.CommandType)
				{
				case ConsoleCommandSegmentType.FindAllChildGameObjects:
				case ConsoleCommandSegmentType.FindChildGameObjects:
					_command.CommandSegments.Add(new GameObjectCommandSegment
					{
						GameObject = item.GameObject,
						CommandText = item.Text,
						CommandType = ConsoleCommandSegmentType.GameObjectSelector,
						Evaluated = true
					});
					break;
				case ConsoleCommandSegmentType.FindChildComponents:
				case ConsoleCommandSegmentType.FindAllChildComponents:
					_command.CommandSegments.Add(new ComponentCommandSegment
					{
						Component = item.Component,
						CommandText = item.Text,
						CommandType = ConsoleCommandSegmentType.ComponentSelector,
						Evaluated = true
					});
					break;
				case ConsoleCommandSegmentType.FindMembers:
				case ConsoleCommandSegmentType.FindAllMembers:
					_command.CommandSegments.Add(new MemberCommandSegment
					{
						Member = item.Member,
						CommandText = item.Text,
						CommandType = ConsoleCommandSegmentType.MemberSelector,
						Evaluated = true
					});
					break;
				case ConsoleCommandSegmentType.GameObjectSelector:
				{
					GameObjectCommandSegment obj4 = (GameObjectCommandSegment)consoleCommandSegment;
					obj4.GameObject = item.GameObject;
					obj4.CommandText = item.Text;
					obj4.Evaluated = true;
					break;
				}
				case ConsoleCommandSegmentType.ComponentSelector:
				{
					ComponentCommandSegment obj3 = (ComponentCommandSegment)consoleCommandSegment;
					obj3.Component = item.Component;
					obj3.CommandText = item.Text;
					obj3.Evaluated = true;
					break;
				}
				case ConsoleCommandSegmentType.MemberSelector:
				{
					MemberCommandSegment obj2 = (MemberCommandSegment)consoleCommandSegment;
					obj2.Member = item.Member;
					obj2.CommandText = item.Text;
					obj2.Evaluated = true;
					break;
				}
				case ConsoleCommandSegmentType.Command:
				{
					CustomCommandSegment obj = (CustomCommandSegment)consoleCommandSegment;
					obj.CommandInfo = item.CustomCommandInfo;
					obj.CommandText = item.Text;
					obj.Evaluated = true;
					break;
				}
				}
				CommandInputField.text = _command.ToString();
				CommandInputField.ActivateInputField();
				CommandInputField.MoveTextEnd(shift: false);
				DeactivateAutoComplete();
			}
		}

		private void PositionAutoCompletePopupAtCursor()
		{
			RectTransform rectTransform = CommandInputField.textComponent.rectTransform;
			TextGenerator cachedTextGenerator = CommandInputField.textComponent.cachedTextGenerator;
			Vector2 cursorPos = cachedTextGenerator.characters[cachedTextGenerator.characterCount - 1].cursorPos;
			float val = rectTransform.position.x + rectTransform.rect.width / 2f - AutoCompletePanelTransform.rect.width;
			Vector3 position = new Vector3(Math.Min(rectTransform.position.x + cursorPos.x + 8f, val), rectTransform.position.y + cursorPos.y, rectTransform.position.z);
			AutoCompletePopup.transform.position = position;
		}

		private void SetColors(LogType logType, Button button)
		{
			switch (logType)
			{
			case LogType.Error:
			case LogType.Exception:
				button.colors = ColorSettings.ErrorColors;
				break;
			case LogType.Warning:
				button.colors = ColorSettings.WarningColors;
				break;
			default:
				button.colors = ColorSettings.MessageColors;
				break;
			}
		}

		private void SetColors(LogType logType, Text text)
		{
			switch (logType)
			{
			case LogType.Error:
			case LogType.Exception:
				text.color = ColorSettings.ErrorColor;
				break;
			case LogType.Warning:
				text.color = ColorSettings.WarningColor;
				break;
			default:
				text.color = ColorSettings.MessageColor;
				break;
			}
		}

		private void UpdateAutoComplete()
		{
			if (_command.CommandSegments.Count > 0)
			{
				ConsoleCommandSegment lastSegment = _command.CommandSegments[_command.CommandSegments.Count - 1];
				if (lastSegment.CommandType == ConsoleCommandSegmentType.FindChildGameObjects || lastSegment.CommandType == ConsoleCommandSegmentType.FindAllChildGameObjects)
				{
					List<GameObject> gameObjectList = ConsoleCommandSegment.GetGameObjectList(lastSegment);
					UpdateAutoComplete(gameObjectList);
				}
				else if (lastSegment.CommandType == ConsoleCommandSegmentType.GameObjectSelector)
				{
					if (((GameObjectCommandSegment)lastSegment).GameObject == null)
					{
						List<GameObject> list = ConsoleCommandSegment.GetGameObjectList(_command.CommandSegments[_command.CommandSegments.Count - 2]);
						if (list != null)
						{
							list = list.Where((GameObject x) => x != null && x.name.ToLower().Contains(lastSegment.CommandText.ToLower())).ToList();
						}
						UpdateAutoComplete(list);
					}
					else
					{
						DeactivateAutoComplete();
					}
				}
				else if (lastSegment.CommandType == ConsoleCommandSegmentType.FindChildComponents || lastSegment.CommandType == ConsoleCommandSegmentType.FindAllChildComponents)
				{
					List<Component> componentList = ConsoleCommandSegment.GetComponentList(lastSegment);
					UpdateAutoComplete(componentList, lastSegment.CommandType == ConsoleCommandSegmentType.FindAllChildComponents);
				}
				else if (lastSegment.CommandType == ConsoleCommandSegmentType.ComponentSelector)
				{
					if (((ComponentCommandSegment)lastSegment).Component == null)
					{
						ConsoleCommandSegment consoleCommandSegment = _command.CommandSegments[_command.CommandSegments.Count - 2];
						List<Component> list2 = ConsoleCommandSegment.GetComponentList(consoleCommandSegment);
						if (list2 != null)
						{
							list2 = list2.Where((Component x) => x != null && x.GetType().Name.ToLower().Contains(lastSegment.CommandText.ToLower())).ToList();
						}
						UpdateAutoComplete(list2, consoleCommandSegment.CommandType == ConsoleCommandSegmentType.FindAllChildComponents);
					}
					else
					{
						DeactivateAutoComplete();
					}
				}
				else if (lastSegment.CommandType == ConsoleCommandSegmentType.FindMembers || lastSegment.CommandType == ConsoleCommandSegmentType.FindAllMembers)
				{
					List<MemberInfo> memberList = ConsoleCommandSegment.GetMemberList(lastSegment);
					UpdateAutoComplete(memberList);
				}
				else if (lastSegment.CommandType == ConsoleCommandSegmentType.MemberSelector)
				{
					if (((MemberCommandSegment)lastSegment).Member == null)
					{
						List<MemberInfo> list3 = ConsoleCommandSegment.GetMemberList(_command.CommandSegments[_command.CommandSegments.Count - 2]);
						if (list3 != null)
						{
							list3 = list3.Where((MemberInfo x) => x.Name.ToLower().Contains(lastSegment.CommandText.ToLower())).ToList();
						}
						UpdateAutoComplete(list3);
					}
					else
					{
						DeactivateAutoComplete();
					}
				}
				else if (lastSegment.CommandType == ConsoleCommandSegmentType.Command)
				{
					if (!((CustomCommandSegment)lastSegment).CommandInfo.HasValue)
					{
						List<RegisteredCommandInfo> commands = CommandEvaluator.RegisteredCommands.Where((RegisteredCommandInfo x) => x.CommandText.ToLower().Contains(lastSegment.CommandText.ToLower())).ToList();
						UpdateAutoComplete(commands);
					}
					else
					{
						DeactivateAutoComplete();
					}
				}
				else
				{
					DeactivateAutoComplete();
				}
			}
			else
			{
				DeactivateAutoComplete();
			}
		}

		private void UpdateAutoComplete(List<RegisteredCommandInfo> commands)
		{
			List<AutoCompleteItem> list = new List<AutoCompleteItem>(_autoCompleteItems.Count);
			if (commands != null)
			{
				List<RegisteredCommandInfo> list2 = commands.OrderByDescending((RegisteredCommandInfo x) => x.CommandText).ToList();
				for (int num = 0; num < list2.Count; num++)
				{
					list.Add(new AutoCompleteItem(list2[num]));
				}
			}
			UpdateAutoComplete(list);
		}

		private void UpdateAutoComplete(List<GameObject> gameObjects)
		{
			List<AutoCompleteItem> list = new List<AutoCompleteItem>(_autoCompleteItems.Count);
			if (gameObjects != null)
			{
				List<GameObject> list2 = (from x in gameObjects
					where x != null
					orderby x.name descending
					select x).ToList();
				for (int num = 0; num < list2.Count; num++)
				{
					list.Add(new AutoCompleteItem(list2[num]));
				}
			}
			UpdateAutoComplete(list);
		}

		private void UpdateAutoComplete(List<Component> components, bool displayGameObjectName)
		{
			List<AutoCompleteItem> list = new List<AutoCompleteItem>(_autoCompleteItems.Count);
			if (components != null)
			{
				List<Component> list2 = (from x in components
					where x != null
					orderby x.GetType().Name descending
					select x).ToList();
				for (int num = 0; num < list2.Count; num++)
				{
					list.Add(new AutoCompleteItem(list2[num], displayGameObjectName));
				}
			}
			UpdateAutoComplete(list);
		}

		private void UpdateAutoComplete(List<MemberInfo> members)
		{
			List<AutoCompleteItem> list = new List<AutoCompleteItem>(_autoCompleteItems.Count);
			if (members != null)
			{
				List<MemberInfo> list2 = members.OrderByDescending((MemberInfo x) => x.Name).ToList();
				for (int num = 0; num < list2.Count; num++)
				{
					list.Add(new AutoCompleteItem(list2[num]));
				}
			}
			UpdateAutoComplete(list);
		}

		private void UpdateAutoComplete(List<AutoCompleteItem> items)
		{
			int num = 0;
			int num2 = 0;
			if (_selectedAutoCompleteItem.HasValue)
			{
				AutoCompleteSelectedItem value = _selectedAutoCompleteItem.Value;
				int index = value.Index;
				num2 = index - _autoCompleteVisibleIndexStart;
				num = items.IndexOf(value.Item);
				if (num == -1)
				{
					if (index == -1)
					{
						num = 0;
					}
					else
					{
						index--;
						while (index >= 0 && num == -1)
						{
							num = items.IndexOf(_autoCompleteItems[index]);
							index--;
						}
						if (num == -1)
						{
							num = 0;
						}
					}
				}
			}
			_autoCompleteItems = items;
			if (num > -1 && num < items.Count)
			{
				_selectedAutoCompleteItem = new AutoCompleteSelectedItem(items[num], num);
			}
			else
			{
				_selectedAutoCompleteItem = null;
			}
			int val = num - num2;
			UpdateVisibleAutoCompleteItems(_autoCompleteVisibleIndexStart = Math.Max(0, Math.Min(val, items.Count - 10)));
			UpdateAutoCompleteScrollBar();
			AutoCompletePopup.SetActive(_autoCompleteItems.Count > 0);
			PositionAutoCompletePopupAtCursor();
		}

		private void UpdateAutoCompleteScrollBar()
		{
			_updatingAutoCompleteScrollBar = true;
			AutoCompleteScrollBar.numberOfSteps = Mathf.Max(_autoCompleteItems.Count - 9, 1);
			AutoCompleteScrollBar.size = ((_autoCompleteItems.Count <= 10) ? 1f : Mathf.Max(1f / (float)(_autoCompleteItems.Count - 10), 0.1f));
			if (_autoCompleteVisibleIndexStart + 10 >= _autoCompleteItems.Count)
			{
				AutoCompleteScrollBar.value = 1f;
			}
			else
			{
				AutoCompleteScrollBar.value = (float)_autoCompleteVisibleIndexStart / (float)AutoCompleteScrollBar.numberOfSteps + 1f / (float)(4 * AutoCompleteScrollBar.numberOfSteps);
			}
			_updatingAutoCompleteScrollBar = false;
		}

		private void UpdateLogScrollBar()
		{
			_updatingLogScrollBar = true;
			LogScrollBar.numberOfSteps = Mathf.Max(_logEntries.Count - 9, 1);
			LogScrollBar.size = ((_logEntries.Count <= 10) ? 1f : Mathf.Max(1f / (float)(_logEntries.Count - 10), 0.1f));
			if (_logVisibleStartIndex + 10 >= _logEntries.Count)
			{
				LogScrollBar.value = 1f;
			}
			else
			{
				LogScrollBar.value = (float)_logVisibleStartIndex / (float)LogScrollBar.numberOfSteps + 1f / (float)(4 * LogScrollBar.numberOfSteps);
			}
			_updatingLogScrollBar = false;
		}

		private void UpdateVisibleAutoCompleteItems(int bottomIndex)
		{
			int num = bottomIndex;
			int? num2 = null;
			float num3 = 0f;
			int num4 = (_selectedAutoCompleteItem.HasValue ? _selectedAutoCompleteItem.Value.Index : (-1));
			for (int i = 0; i < _autoCompleteTexts.Count; i++)
			{
				Text text = _autoCompleteTexts[i];
				if (num < _autoCompleteItems.Count)
				{
					text.text = _autoCompleteItems[num].DisplayText;
				}
				else
				{
					text.text = string.Empty;
					if (!num2.HasValue)
					{
						num2 = i;
					}
				}
				num3 = Mathf.Max(num3, text.preferredWidth);
				Button button = _autoCompleteButtons[i];
				ColorBlock colors = button.colors;
				Color normalColor = colors.normalColor;
				normalColor.a = ((num4 == num) ? 0.5f : 0f);
				colors.normalColor = normalColor;
				button.colors = colors;
				num++;
			}
			float x = Mathf.Min(num3 + 44f, 650f);
			if (num2.HasValue)
			{
				float y = _autoCompleteButtons[num2.Value].GetComponent<RectTransform>().anchoredPosition.y;
				AutoCompletePanelTransform.sizeDelta = new Vector2(x, y);
			}
			else
			{
				AutoCompletePanelTransform.sizeDelta = new Vector2(x, 300f);
			}
		}

		private void UpdateVisibleLogs(int bottomIndex)
		{
			if (_logEntries == null)
			{
				return;
			}
			int num = _logEntries.Count - bottomIndex - 1;
			for (int i = 0; i < 10; i++)
			{
				Text text = _logEntryComponents[i];
				if (num < 0)
				{
					text.text = string.Empty;
				}
				else
				{
					LogEntry logEntry = _logEntries[num];
					text.text = logEntry.Message;
					SetColors(logEntry.LogType, _logEntryButtons[i]);
				}
				num--;
			}
		}
	}
}
