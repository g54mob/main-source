using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.DevConsole
{
	public class DeveloperConsole : DeveloperView, IObserver
	{
		[Header("UI Components")]
		[SerializeField]
		private Text consoleText;

		[SerializeField]
		private InputField inputField;

		private List<string> usedCommands = new List<string>();

		private int commandIterator;

		private ConsumeFlag ClearConsoleMessagesText()
		{
			consoleText.text = string.Empty;
			return ConsumeFlag.CONSUME;
		}

		public override void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (!active)
			{
				commandIterator = 0;
			}
			else
			{
				ClearInputField();
			}
		}

		public override void SetupPanel(DeveloperPanelCategory category)
		{
		}

		public override void Reset()
		{
			ClearInputField();
		}

		private void Start()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			MonoSingleton<DeveloperConsoleController>.Instance.Attach(this);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			if (MonoSingleton<DeveloperConsoleController>.IsInstantiated())
			{
				MonoSingleton<DeveloperConsoleController>.Instance.Detach(this);
			}
		}

		private void OnTick(float deltaTime)
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.Return) && inputField.text != string.Empty)
			{
				AddMessageToConsole($">> {inputField.text}", ConsoleMessageType.Command);
				SendInput(inputField.text);
				if (!usedCommands.DefaultIfEmpty(string.Empty).Last().Equals(inputField.text))
				{
					usedCommands.Add(inputField.text);
				}
				ClearInputField();
				commandIterator = 0;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				inputField.text = IterateUsedCommands(-1);
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				inputField.text = IterateUsedCommands(1);
			}
		}

		private void ClearInputField()
		{
			inputField.Select();
			inputField.ActivateInputField();
			inputField.text = string.Empty;
		}

		private string IterateUsedCommands(int step)
		{
			if (usedCommands.Count == 0)
			{
				return null;
			}
			ClearInputField();
			if (commandIterator == 0)
			{
				commandIterator = usedCommands.Count;
			}
			else
			{
				commandIterator = (((commandIterator == 1 && step < 0) || (commandIterator == usedCommands.Count && step > 0)) ? commandIterator : (commandIterator + step));
			}
			return usedCommands.ElementAt(commandIterator - 1);
		}

		private ConsumeFlag AddMessageToConsole(string message, ConsoleMessageType messageType = ConsoleMessageType.Standard)
		{
			switch (messageType)
			{
			case ConsoleMessageType.Error:
				message = MessageAsError(message);
				break;
			case ConsoleMessageType.Warning:
				message = MessageAsWarrning(message);
				break;
			case ConsoleMessageType.Command:
				message = MessageAsCommand(message);
				break;
			}
			consoleText.text += $"{message}\n";
			return ConsumeFlag.CONSUME;
		}

		private string MessageAsError(string message)
		{
			return $"<color=red>{message}</color>";
		}

		private string MessageAsWarrning(string message)
		{
			return $"<color=yellow>{message}</color>";
		}

		private string MessageAsCommand(string message)
		{
			return $"<color=green>{message}</color>";
		}

		private void SendInput(string input)
		{
			string[] array = input.Split((char[])null);
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand(array[0], array.Skip(1).ToArray());
		}
	}
}
