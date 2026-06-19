using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityConsole
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ConsoleController))]
	public class ConsoleUI : MonoBehaviour, IScrollHandler, IEventSystemHandler
	{
		public Scrollbar Scrollbar;

		public TMP_Text OutputText;

		public ScrollRect OutputArea;

		public InputField InputField;

		public bool IsConsoleOpen => base.enabled;

		public event Action<bool> OnToggleConsole;

		public event Action<string> OnSubmitCommand;

		public event Action OnClearConsole;

		private void Awake()
		{
			InputField.onEndEdit.AddListener(OnSubmit);
			Show(show: false);
		}

		public void ToggleConsole()
		{
			ClearInput();
			base.enabled = !base.enabled;
		}

		public void OpenConsole()
		{
			base.enabled = true;
		}

		public void CloseConsole()
		{
			base.enabled = false;
		}

		private void OnEnable()
		{
			OnToggle(open: true);
		}

		private void OnDisable()
		{
			OnToggle(open: false);
		}

		private void OnToggle(bool open)
		{
			Show(open);
			if (open)
			{
				InputField.ActivateInputField();
			}
			else
			{
				ClearInput();
			}
			if (this.OnToggleConsole != null)
			{
				this.OnToggleConsole(open);
			}
		}

		private void Show(bool show)
		{
			InputField.gameObject.SetActive(show);
			OutputArea.gameObject.SetActive(show);
			Scrollbar.gameObject.SetActive(show);
		}

		public void OnSubmit(string input)
		{
			if (EventSystem.current.alreadySelecting)
			{
				return;
			}
			input = input.Replace('\n', ' ').Replace('\r', ' ');
			if (input.Length > 0)
			{
				if (this.OnSubmitCommand != null)
				{
					this.OnSubmitCommand(input);
				}
				Scrollbar.value = 0f;
				ClearInput();
			}
			InputField.ActivateInputField();
		}

		public void OnScroll(PointerEventData eventData)
		{
			Scrollbar.value += 0.08f * eventData.scrollDelta.y;
		}

		public void AddNewOutputLine(string line)
		{
			int length = OutputText.text.Length;
			if (length > 8192)
			{
				string text = OutputText.text.Substring(length - 8192);
				OutputText.text = text;
			}
			TMP_Text outputText = OutputText;
			outputText.text = outputText.text + Environment.NewLine + line;
		}

		public void ClearOutput()
		{
			OutputText.text = "";
			OutputText.SetLayoutDirty();
			if (this.OnClearConsole != null)
			{
				this.OnClearConsole();
			}
		}

		public void ClearInput()
		{
			SetInputText("");
		}

		public void SetInputText(string input)
		{
			InputField.MoveTextStart(shift: false);
			InputField.text = input;
			InputField.MoveTextEnd(shift: false);
			InputField.caretPosition = InputField.text.Length;
		}

		public void TabComplete()
		{
			List<string> list = ConsoleCommandsDatabase.CommandsMatchingPrefix(InputField.text);
			List<string> list2 = ConsoleCommandsDatabase.CommandsContainingStrings(new string[1] { InputField.text }, ignorePrefix: true);
			if (list.Count == 0)
			{
				if (list2.Count == 0)
				{
					AddNewOutputLine("No command contains \"" + InputField.text + "\"");
					return;
				}
				list = list2;
				list2.Clear();
			}
			if (list.Count == 1)
			{
				SetInputText(list[0]);
				return;
			}
			string text = LongestCommonPrefix(list);
			if (string.Equals(InputField.text, text, StringComparison.OrdinalIgnoreCase))
			{
				AddNewOutputLine("<b>Did you mean...</b>");
				list.Sort();
				for (int i = 0; i < list.Count; i++)
				{
					AddNewOutputLine("    " + list[i]);
				}
				if (list2.Count != 0)
				{
					AddNewOutputLine("<b>Or others containing this term...</b>");
					list2.Sort();
					for (int j = 0; j < list2.Count; j++)
					{
						AddNewOutputLine("    " + list2[j]);
					}
				}
			}
			else
			{
				SetInputText(text);
			}
		}

		private static string LongestCommonPrefix(List<string> strs)
		{
			if (strs == null || strs.Count == 0)
			{
				return "";
			}
			int num = int.MaxValue;
			for (int i = 0; i < strs.Count; i++)
			{
				num = Math.Min(num, strs[i].Length);
			}
			int num2 = 1;
			int num3 = num;
			while (num2 <= num3)
			{
				int num4 = (num2 + num3) / 2;
				if (IsCommonPrefix(strs, num4))
				{
					num2 = num4 + 1;
				}
				else
				{
					num3 = num4 - 1;
				}
			}
			return strs[0].Substring(0, (num2 + num3) / 2);
		}

		private static bool IsCommonPrefix(List<string> strs, int len)
		{
			string value = strs[0].Substring(0, len);
			for (int i = 1; i < strs.Count; i++)
			{
				if (!strs[i].StartsWith(value))
				{
					return false;
				}
			}
			return true;
		}
	}
}
