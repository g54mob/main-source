using System;
using System.Linq;
using UnityEngine;

namespace UnityConsole
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ConsoleController))]
	public class ConsoleController : MonoBehaviour
	{
		private const int InputHistoryCapacity = 20;

		public ConsoleUI UI;

		public KeyCode ToggleKey = KeyCode.BackQuote;

		public bool CloseOnEscape;

		private readonly ConsoleInputHistory _inputHistory = new ConsoleInputHistory(20);

		public ConsoleInputHistory InputHistory => _inputHistory;

		private void ExecuteCommandDropResult(string input)
		{
			ExecuteCommand(input);
		}

		private void ExecuteCommand(string input)
		{
			string[] array = input.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string command = array[0];
			string[] args = array.Skip(1).ToArray();
			UI.AddNewOutputLine("> " + input);
			ConsoleCommandResult consoleCommandResult = ConsoleCommandsDatabase.ExecuteCommand(command, args);
			UI.AddNewOutputLine(consoleCommandResult.succeeded ? "Done" : "Failed");
			if (!consoleCommandResult.succeeded && !string.IsNullOrEmpty(consoleCommandResult.Output))
			{
				Debug.LogError(consoleCommandResult.Output);
			}
			if (!string.IsNullOrEmpty(consoleCommandResult.Output))
			{
				UI.AddNewOutputLine(consoleCommandResult.Output);
			}
			_inputHistory.AddNewInputEntry(input);
		}

		private void OnEnable()
		{
			UI.OnSubmitCommand += ExecuteCommandDropResult;
			UI.OnClearConsole += _inputHistory.Clear;
		}

		private void OnDisable()
		{
			UI.OnSubmitCommand -= ExecuteCommandDropResult;
			UI.OnClearConsole -= _inputHistory.Clear;
		}

		private void Update()
		{
			if (Input.GetKeyDown(ToggleKey))
			{
				UI.ToggleConsole();
			}
			else if (Input.GetKeyDown(KeyCode.Escape) && CloseOnEscape)
			{
				UI.CloseConsole();
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				NavigateInputHistory(up: true);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				NavigateInputHistory(up: false);
			}
			else if (Input.GetKeyDown(KeyCode.Tab))
			{
				UI.TabComplete();
			}
		}

		private void NavigateInputHistory(bool up)
		{
			string inputText = _inputHistory.Navigate(up);
			UI.SetInputText(inputText);
		}
	}
}
