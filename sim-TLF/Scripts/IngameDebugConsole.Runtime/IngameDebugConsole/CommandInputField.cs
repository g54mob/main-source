using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IngameDebugConsole
{
	public class CommandInputField : TMP_InputField
	{
		private delegate object FieldInfoGetDelegate(object obj);

		private delegate void FieldInfoSetDelegate(object obj, object value);

		[SerializeField]
		private RectTransform commandSuggestionsContainer;

		[SerializeField]
		private TextMeshProUGUI commandSuggestionPrefab;

		[SerializeField]
		private string commandSuggestionHighlightStart = "<color=orange>";

		[SerializeField]
		private string commandSuggestionHighlightEnd = "</color>";

		private DebugLogManager manager;

		private List<ConsoleMethodInfo> matchingCommandSuggestions;

		private List<TextMeshProUGUI> commandSuggestionInstances;

		private int visibleCommandSuggestionInstances;

		private List<int> commandCaretIndexIncrements;

		private string previousCommand;

		private string previousCommandName;

		private int previousParameterCount = -1;

		private int previousCaretPosition = -1;

		private int previousCaretArgumentIndex = -1;

		private string autoCompleteBase;

		private bool hasAutoCompletedNow;

		private CircularBuffer<string> commandHistory;

		private int commandHistoryIndex = -1;

		private string commandBeforeNavigatingHistory;

		private readonly Event poppedEvent = new Event();

		private readonly FieldInfoGetDelegate m_IsCompositionActiveGetter = typeof(TMP_InputField).GetField("m_IsCompositionActive", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue;

		private readonly FieldInfoSetDelegate m_IsTextComponentUpdateRequiredSetter = typeof(TMP_InputField).GetField("m_IsTextComponentUpdateRequired", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SetValue;

		private readonly object boxedTrueValue = true;

		public void Initialize(DebugLogManager manager)
		{
			this.manager = manager;
			commandSuggestionInstances = new List<TextMeshProUGUI>(8);
			matchingCommandSuggestions = new List<ConsoleMethodInfo>(8);
			commandCaretIndexIncrements = new List<int>(8);
			commandHistory = new CircularBuffer<string>(manager.commandHistorySize);
			commandSuggestionsContainer.gameObject.SetActive(value: false);
			base.onValidateInput = (OnValidateInput)Delegate.Combine(base.onValidateInput, new OnValidateInput(OnValidateCommand));
			base.onValueChanged.AddListener(OnEditCommand);
			base.onEndEdit.AddListener(OnEndEditCommand);
			base.onSubmit.AddListener(OnSubmitCommand);
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (manager == null || !manager.IsLogWindowVisible)
			{
				return;
			}
			if (manager.showCommandSuggestions && base.isFocused && base.caretPosition != previousCaretPosition)
			{
				RefreshCommandSuggestions(base.text);
			}
			if (!base.isFocused || commandHistory.Count <= 0)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (commandHistoryIndex == -1)
				{
					commandHistoryIndex = commandHistory.Count - 1;
					commandBeforeNavigatingHistory = base.text;
				}
				else if (--commandHistoryIndex < 0)
				{
					commandHistoryIndex = 0;
				}
				base.text = commandHistory[commandHistoryIndex];
				base.caretPosition = base.text.Length;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) && commandHistoryIndex != -1)
			{
				if (++commandHistoryIndex < commandHistory.Count)
				{
					base.text = commandHistory[commandHistoryIndex];
					return;
				}
				commandHistoryIndex = -1;
				base.text = commandBeforeNavigatingHistory ?? string.Empty;
			}
		}

		public override void OnUpdateSelected(BaseEventData eventData)
		{
			if (!base.isFocused)
			{
				return;
			}
			bool flag = false;
			while (Event.PopEvent(poppedEvent))
			{
				switch (poppedEvent.rawType)
				{
				case EventType.KeyDown:
				{
					flag = true;
					if (poppedEvent.character == '\0' && poppedEvent.modifiers == EventModifiers.None && base.caretPositionInternal == m_CaretPosition && (bool)m_IsCompositionActiveGetter(this))
					{
						break;
					}
					char c;
					switch (poppedEvent.keyCode)
					{
					case KeyCode.Return:
					case KeyCode.KeypadEnter:
						c = '\n';
						break;
					case KeyCode.Tab:
						c = '\t';
						break;
					default:
						c = poppedEvent.character;
						break;
					}
					char c2 = c;
					if (c2 == '\t' || c2 == '\n')
					{
						Append(c2);
					}
					else if (KeyPressed(poppedEvent) == EditState.Finish)
					{
						if (!base.wasCanceled)
						{
							SendOnSubmit();
						}
						DeactivateInputField();
						break;
					}
					m_IsTextComponentUpdateRequiredSetter(this, boxedTrueValue);
					UpdateLabel();
					break;
				}
				case EventType.ValidateCommand:
				case EventType.ExecuteCommand:
					if (poppedEvent.commandName == "SelectAll")
					{
						SelectAll();
						flag = true;
					}
					break;
				}
			}
			if (flag)
			{
				UpdateLabel();
			}
			eventData.Use();
		}

		private char OnValidateCommand(string command, int charIndex, char addedChar)
		{
			switch (addedChar)
			{
			case '\t':
				if (!string.IsNullOrEmpty(command))
				{
					if (string.IsNullOrEmpty(autoCompleteBase))
					{
						autoCompleteBase = command;
					}
					string autoCompleteCommand = DebugLogConsole.GetAutoCompleteCommand(autoCompleteBase, command);
					if (!string.IsNullOrEmpty(autoCompleteCommand) && autoCompleteCommand != command)
					{
						hasAutoCompletedNow = true;
						base.text = autoCompleteCommand;
						base.stringPosition = autoCompleteCommand.Length;
					}
				}
				return '\0';
			case '\n':
				OnSubmitCommand(command);
				return '\0';
			default:
				return addedChar;
			}
		}

		private void OnEditCommand(string command)
		{
			RefreshCommandSuggestions(command);
			if (!hasAutoCompletedNow)
			{
				autoCompleteBase = null;
			}
			else
			{
				hasAutoCompletedNow = false;
			}
		}

		private void OnEndEditCommand(string command)
		{
			if (!commandSuggestionsContainer.gameObject.activeSelf)
			{
				return;
			}
			if (visibleCommandSuggestionInstances > 0 && Input.GetMouseButtonDown(0))
			{
				Vector2 screenPoint = Input.mousePosition;
				Canvas canvas = base.textComponent.canvas;
				Camera cam = ((canvas.renderMode == RenderMode.ScreenSpaceOverlay || (canvas.renderMode == RenderMode.ScreenSpaceCamera && canvas.worldCamera == null)) ? null : ((canvas.worldCamera != null) ? canvas.worldCamera : Camera.main));
				if (RectTransformUtility.RectangleContainsScreenPoint(commandSuggestionsContainer, screenPoint, cam) && RectTransformUtility.ScreenPointToLocalPointInRectangle(commandSuggestionsContainer, screenPoint, cam, out var localPoint))
				{
					localPoint.y -= commandSuggestionsContainer.rect.height;
					for (int i = 0; i < visibleCommandSuggestionInstances; i++)
					{
						if (localPoint.y >= commandSuggestionInstances[i].rectTransform.anchoredPosition.y - commandSuggestionInstances[i].rectTransform.sizeDelta.y * commandSuggestionInstances[i].rectTransform.pivot.y)
						{
							base.text = matchingCommandSuggestions[i].command + ((matchingCommandSuggestions[i].parameters.Length != 0) ? " " : null);
							StartCoroutine(ActivateCommandInputFieldCoroutine());
							return;
						}
					}
				}
			}
			commandSuggestionsContainer.gameObject.SetActive(value: false);
		}

		private void OnSubmitCommand(string command)
		{
			if (manager.clearCommandAfterExecution)
			{
				base.text = string.Empty;
			}
			if (command.Length > 0)
			{
				if (commandHistory.Count == 0 || commandHistory[commandHistory.Count - 1] != command)
				{
					commandHistory.Add(command);
				}
				commandHistoryIndex = -1;
				commandBeforeNavigatingHistory = null;
				DebugLogConsole.ExecuteCommand(command);
				manager.SnapToBottom = true;
			}
		}

		private void RefreshCommandSuggestions(string command)
		{
			if (!manager.showCommandSuggestions)
			{
				return;
			}
			previousCaretPosition = base.caretPosition;
			bool flag = command != previousCommand;
			bool flag2 = false;
			if (flag)
			{
				previousCommand = command;
				matchingCommandSuggestions.Clear();
				commandCaretIndexIncrements.Clear();
				string obj = previousCommandName;
				DebugLogConsole.GetCommandSuggestions(command, matchingCommandSuggestions, commandCaretIndexIncrements, ref previousCommandName, out var numberOfParameters);
				if (obj != previousCommandName || numberOfParameters != previousParameterCount)
				{
					previousParameterCount = numberOfParameters;
					flag2 = true;
				}
			}
			int num = 0;
			int num2 = base.caretPosition;
			for (int i = 0; i < commandCaretIndexIncrements.Count && num2 > commandCaretIndexIncrements[i]; i++)
			{
				num++;
			}
			if (num != previousCaretArgumentIndex)
			{
				previousCaretArgumentIndex = num;
			}
			else if (!flag || !flag2)
			{
				return;
			}
			if (matchingCommandSuggestions.Count == 0)
			{
				OnEndEditCommand(command);
				return;
			}
			if (!commandSuggestionsContainer.gameObject.activeSelf)
			{
				commandSuggestionsContainer.gameObject.SetActive(value: true);
			}
			int count = commandSuggestionInstances.Count;
			int count2 = matchingCommandSuggestions.Count;
			for (int j = 0; j < count2; j++)
			{
				if (j >= visibleCommandSuggestionInstances)
				{
					if (j >= count)
					{
						commandSuggestionInstances.Add(UnityEngine.Object.Instantiate(commandSuggestionPrefab, commandSuggestionsContainer, worldPositionStays: false));
					}
					else
					{
						commandSuggestionInstances[j].gameObject.SetActive(value: true);
					}
					visibleCommandSuggestionInstances++;
				}
				ConsoleMethodInfo consoleMethodInfo = matchingCommandSuggestions[j];
				StringBuilder stringBuilder = manager.sharedStringBuilder.Clear();
				if (num > 0)
				{
					stringBuilder.Append(consoleMethodInfo.command);
				}
				else
				{
					stringBuilder.Append(commandSuggestionHighlightStart).Append(matchingCommandSuggestions[j].command).Append(commandSuggestionHighlightEnd);
				}
				if (consoleMethodInfo.parameters.Length != 0)
				{
					stringBuilder.Append(" ");
					int num3 = num - 1;
					if (num3 >= consoleMethodInfo.parameters.Length)
					{
						num3 = consoleMethodInfo.parameters.Length - 1;
					}
					for (int k = 0; k < consoleMethodInfo.parameters.Length; k++)
					{
						if (num3 != k)
						{
							stringBuilder.Append(consoleMethodInfo.parameters[k]);
						}
						else
						{
							stringBuilder.Append(commandSuggestionHighlightStart).Append(consoleMethodInfo.parameters[k]).Append(commandSuggestionHighlightEnd);
						}
					}
				}
				commandSuggestionInstances[j].text = stringBuilder.ToString();
			}
			for (int num4 = visibleCommandSuggestionInstances - 1; num4 >= count2; num4--)
			{
				commandSuggestionInstances[num4].gameObject.SetActive(value: false);
			}
			visibleCommandSuggestionInstances = count2;
		}

		public IEnumerator ActivateCommandInputFieldCoroutine()
		{
			yield return null;
			bool onFocusSelectAll = base.onFocusSelectAll;
			base.onFocusSelectAll = false;
			ActivateInputField();
			yield return null;
			MoveTextEnd(shift: false);
			base.onFocusSelectAll = onFocusSelectAll;
		}
	}
}
