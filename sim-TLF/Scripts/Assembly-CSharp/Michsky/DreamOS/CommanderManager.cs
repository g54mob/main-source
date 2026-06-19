using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class CommanderManager : MonoBehaviour
	{
		[Serializable]
		public class CommandItem
		{
			public string commandName = "Command Name";

			public string command = "Actual Command";

			[TextArea(3, 10)]
			public string commandDescription = "Command description";

			[TextArea(3, 10)]
			public string feedbackText;

			public float feedbackDelay;

			public float onProcessDelay;

			public bool includeToHelp = true;

			public UnityEvent onProcessEvent = new UnityEvent();
		}

		public List<CommandItem> commands = new List<CommandItem>();

		[TextArea]
		public string errorText = "is not recognized as a command.";

		[TextArea]
		public string onEnableText = "Welcome to Commander.";

		public string helpCommand = "help";

		public Color textColor;

		public bool enableHelpCommand = true;

		[SerializeField]
		private bool antiFlicker = true;

		[SerializeField]
		private TMP_InputField commandInput;

		[SerializeField]
		private TextMeshProUGUI commandHistory;

		[SerializeField]
		private Scrollbar scrollbar;

		public bool useTypewriterEffect;

		[Range(0.001f, 0.5f)]
		public float typewriterDelay = 0.03f;

		public bool getTimeData = true;

		public Color timeColor = new Color(0f, 255f, 0f);

		private string currentCommand;

		private int commandIndex;

		private string typewriterHelper;

		private RectTransform historyRT;

		private RectTransform historyParentRT;

		private bool isCommandProcessing;

		private int processingCommandIndex = -1;

		private bool pendingProcessEventFired;

		public event Action<string> OnCommandProcessing;

		private void OnEnable()
		{
			commandHistory.text = "";
			commandInput.text = "";
			UpdateColors();
			if (getTimeData && DateAndTimeManager.instance != null)
			{
				UpdateTime();
			}
			commandHistory.text += onEnableText;
			commandInput.ActivateInputField();
			StartCoroutine("FixLayout");
		}

		private void Awake()
		{
			historyRT = commandHistory.GetComponent<RectTransform>();
			historyParentRT = commandHistory.transform.parent.GetComponent<RectTransform>();
		}

		private void Update()
		{
			if (!string.IsNullOrEmpty(commandInput.text) && !(EventSystem.current.currentSelectedGameObject != commandInput.gameObject))
			{
				if (!commandInput.isFocused)
				{
					commandInput.ActivateInputField();
				}
				if (Keyboard.current.enterKey.wasPressedThisFrame)
				{
					ProcessCommand();
				}
			}
		}

		public void UpdateColors()
		{
			commandInput.textComponent.color = textColor;
			commandHistory.color = textColor;
		}

		private void CompleteInterruptedCommand()
		{
			if (!isCommandProcessing)
			{
				return;
			}
			StopCoroutine("WaitForFeedbackDelay");
			StopCoroutine("WaitForProcessDelay");
			StopCoroutine("ApplyTypewriter");
			if (processingCommandIndex >= 0 && processingCommandIndex < commands.Count)
			{
				CommandItem commandItem = commands[processingCommandIndex];
				if (!string.IsNullOrEmpty(typewriterHelper))
				{
					int num = commandHistory.text.LastIndexOf('\n');
					if (num >= 0)
					{
						commandHistory.text = commandHistory.text.Substring(0, num + 1);
					}
					if (getTimeData && DateAndTimeManager.instance != null)
					{
						UpdateTime();
					}
					commandHistory.text += commandItem.feedbackText;
				}
				else if (!string.IsNullOrEmpty(commandItem.feedbackText))
				{
					commandHistory.text += "\n";
					if (getTimeData && DateAndTimeManager.instance != null)
					{
						UpdateTime();
					}
					commandHistory.text += commandItem.feedbackText;
				}
				if (!pendingProcessEventFired)
				{
					commandItem.onProcessEvent.Invoke();
				}
			}
			typewriterHelper = "";
			isCommandProcessing = false;
			processingCommandIndex = -1;
			pendingProcessEventFired = false;
		}

		public void ProcessCommand()
		{
			CompleteInterruptedCommand();
			currentCommand = "";
			commandIndex = -1;
			currentCommand = commandInput.text;
			commandHistory.text += "\n";
			if (getTimeData && DateAndTimeManager.instance != null)
			{
				UpdateTime();
			}
			commandHistory.text += commandInput.text;
			if (enableHelpCommand && currentCommand == helpCommand)
			{
				for (int i = 0; i < commands.Count; i++)
				{
					if (commands[i].includeToHelp)
					{
						commandHistory.text += $"\n[{commands[i].command}] {commands[i].commandDescription} ";
					}
				}
				commandInput.text = "";
				LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
				LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
				StartCoroutine("FixLayout");
				if (scrollbar != null)
				{
					scrollbar.value = 0f;
				}
				this.OnCommandProcessing?.Invoke(helpCommand);
				return;
			}
			for (int j = 0; j < commands.Count; j++)
			{
				if (currentCommand == commands[j].command)
				{
					currentCommand = commands[j].command;
					commandIndex = j;
					break;
				}
			}
			if (commandIndex == -1)
			{
				commandHistory.text += "\n";
				if (getTimeData && DateAndTimeManager.instance != null)
				{
					UpdateTime();
				}
				commandHistory.text = $"{commandHistory.text}'{commandInput.text}' {errorText}";
				commandInput.text = "";
				LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
				LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
				StartCoroutine("FixLayout");
				if (scrollbar != null)
				{
					scrollbar.value = 0f;
				}
				return;
			}
			this.OnCommandProcessing?.Invoke(commands[commandIndex].command);
			isCommandProcessing = true;
			processingCommandIndex = commandIndex;
			pendingProcessEventFired = false;
			if (commands[commandIndex].feedbackText != "")
			{
				StartCoroutine("WaitForFeedbackDelay", commands[commandIndex].feedbackDelay);
			}
			else
			{
				isCommandProcessing = false;
				processingCommandIndex = -1;
			}
			if (commands[commandIndex].onProcessDelay == 0f)
			{
				commands[commandIndex].onProcessEvent.Invoke();
				pendingProcessEventFired = true;
			}
			else
			{
				StartCoroutine("WaitForProcessDelay", commands[commandIndex].onProcessDelay);
			}
			commandInput.text = "";
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
			StartCoroutine("FixLayout");
			if (scrollbar != null)
			{
				scrollbar.value = 0f;
			}
		}

		private IEnumerator ApplyTypewriter(float delay)
		{
			for (int i = 0; i < typewriterHelper.Length; i++)
			{
				commandHistory.text += typewriterHelper[i];
				if (antiFlicker)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
				}
				if (scrollbar != null)
				{
					scrollbar.value = 0f;
				}
				yield return new WaitForSeconds(delay);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
			typewriterHelper = "";
			isCommandProcessing = false;
			processingCommandIndex = -1;
		}

		public void UpdateTime()
		{
			if (getTimeData && DateAndTimeManager.instance != null)
			{
				string arg = ColorUtility.ToHtmlStringRGB(timeColor);
				commandHistory.text = $"{commandHistory.text}<color=#{arg}>[";
				if (DateAndTimeManager.instance.currentHour.ToString().Length == 1)
				{
					commandHistory.text = $"{commandHistory.text}0{DateAndTimeManager.instance.currentHour}:";
				}
				else
				{
					commandHistory.text = $"{commandHistory.text}{DateAndTimeManager.instance.currentHour}:";
				}
				if (DateAndTimeManager.instance.currentMinute.ToString().Length == 1)
				{
					commandHistory.text = $"{commandHistory.text}0{DateAndTimeManager.instance.currentMinute}:";
				}
				else
				{
					commandHistory.text = $"{commandHistory.text}{DateAndTimeManager.instance.currentMinute}:";
				}
				if (DateAndTimeManager.instance.currentSecond.ToString("F0").Length == 1)
				{
					commandHistory.text = string.Format("{0}0{1}", commandHistory.text, DateAndTimeManager.instance.currentSecond.ToString("F0"));
				}
				else
				{
					commandHistory.text = string.Format("{0}{1}", commandHistory.text, DateAndTimeManager.instance.currentSecond.ToString("F0"));
				}
				commandHistory.text = $"{commandHistory.text}]</color> ";
			}
		}

		public void AddToHistory(string text, bool useTypewriter, float typewriterDelay = 0.1f, bool showTime = true)
		{
			commandHistory.text += "\n";
			if (showTime)
			{
				UpdateTime();
			}
			StopCoroutine("ApplyTypewriter");
			if (useTypewriter)
			{
				typewriterHelper = text;
				StartCoroutine("ApplyTypewriter", typewriterDelay);
			}
			else
			{
				commandHistory.text += text;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
			StartCoroutine("FixLayout");
		}

		public void ClearHistory()
		{
			commandHistory.text = "";
			if (getTimeData && DateAndTimeManager.instance != null)
			{
				UpdateTime();
			}
			commandHistory.text += onEnableText;
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
			StartCoroutine("FixLayout");
		}

		public void AddNewCommand()
		{
			commands.Add(null);
		}

		private IEnumerator FixLayout()
		{
			yield return new WaitForSeconds(0.02f);
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
			if (scrollbar != null)
			{
				scrollbar.value = 0f;
			}
		}

		private IEnumerator WaitForFeedbackDelay(float forSec)
		{
			yield return new WaitForSeconds(forSec);
			commandHistory.text += "\n";
			UpdateTime();
			if (commands.Count < commandIndex)
			{
				yield return null;
			}
			if (useTypewriterEffect)
			{
				typewriterHelper = commands[commandIndex].feedbackText;
				StartCoroutine("ApplyTypewriter", typewriterDelay);
			}
			else
			{
				commandHistory.text += commands[commandIndex].feedbackText;
				isCommandProcessing = false;
				processingCommandIndex = -1;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyRT);
			LayoutRebuilder.ForceRebuildLayoutImmediate(historyParentRT);
			StartCoroutine("FixLayout");
		}

		private IEnumerator WaitForProcessDelay(float forSec)
		{
			yield return new WaitForSeconds(forSec);
			commands[commandIndex].onProcessEvent.Invoke();
			pendingProcessEventFired = true;
			StopCoroutine("WaitForProcessDelay");
		}
	}
}
