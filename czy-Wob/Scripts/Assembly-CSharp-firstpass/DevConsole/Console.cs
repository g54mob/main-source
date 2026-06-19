using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SickDev.CommandSystem;
using UnityEngine;

namespace DevConsole
{
	[Serializable]
	public class Console : MonoBehaviour, ISerializationCallbackReceiver
	{
		[SerializeField]
		public bool dontDestroyOnLoad;

		[SerializeField]
		private KeyCode consoleKeyDisable = KeyCode.Escape;

		[Range(8f, 20f)]
		public int fontSize;

		private const int TEXT_AREA_OFFSET = 7;

		private bool helpEnabled = true;

		private int numHelpCommandsToShow = 5;

		private float helpWindowMinWidth = 200f;

		private const int WARNING_THRESHOLD = 15000;

		private const int DANGER_THRESHOLD = 16000;

		private const int AUTOCLEAR_THRESHOLD = 18000;

		private List<CommandBase> candidates = new List<CommandBase>();

		private int selectedCandidate;

		private List<string> history = new List<string>();

		private int selectedHistory;

		private List<KeyValuePair<string, string>> buffer = new List<KeyValuePair<string, string>>();

		private CommandsManager _manager;

		private static Console _singleton;

		private bool opening;

		private bool closed = true;

		private bool showHelp = true;

		private bool inHistory;

		private float numLinesThreshold;

		private float maxConsoleHeight;

		private float currentConsoleHeight;

		private Vector2 consoleScroll = Vector2.zero;

		private Vector2 helpWindowScroll = Vector2.zero;

		[HideInInspector]
		[SerializeField]
		private string serializedConsoleText = string.Empty;

		private StringBuilder consoleText = new StringBuilder();

		private string inputText = string.Empty;

		private string lastText = string.Empty;

		private int numLines;

		private float lineHeight;

		[SerializeField]
		private Settings extraSettings;

		private CommandsManager manager
		{
			get
			{
				if (_manager == null)
				{
					_manager = new CommandsManager();
					manager.AddAssemblyWithCommands("Assembly-CSharp.dll");
					manager.AddAssemblyWithCommands("Assembly-CSharp-firstpass.dll");
					manager.Load();
				}
				return _manager;
			}
		}

		private static Console Singleton
		{
			get
			{
				if (_singleton == null)
				{
					_singleton = UnityEngine.Object.FindObjectOfType<Console>();
				}
				return _singleton;
			}
		}

		public static bool isOpen => !Singleton.closed;

		static Console()
		{
			CommandsManager.onExceptionThrown += Debug.LogException;
			CommandsManager.onMessage += Debug.Log;
		}

		private void Awake()
		{
			if (Singleton != this)
			{
				Debug.LogWarning("There can only be one Console per project");
				UnityEngine.Object.Destroy(this);
				return;
			}
			if (dontDestroyOnLoad)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			if (extraSettings.showDebugLog)
			{
				Application.logMessageReceived += LogCallback;
			}
		}

		public void OnBeforeSerialize()
		{
			serializedConsoleText = consoleText.ToString();
		}

		public void OnAfterDeserialize()
		{
			consoleText.Append(serializedConsoleText);
		}

		private void OnGUI()
		{
			GUISkin skin = GUI.skin;
			if (extraSettings.skin != null)
			{
				GUI.skin = extraSettings.skin;
			}
			Event current = Event.current;
			GUI.skin.textArea.richText = true;
			if (extraSettings.font != null)
			{
				GUI.skin.font = extraSettings.font;
			}
			GUIStyle textArea = GUI.skin.textArea;
			int num = (GUI.skin.textField.fontSize = fontSize);
			textArea.fontSize = num;
			if (isOpen && current.type == EventType.KeyDown && current.keyCode == consoleKeyDisable)
			{
				GUIUtility.keyboardControl = 0;
				StartCoroutine(FadeInOut(closed));
			}
			lineHeight = GUI.skin.textArea.lineHeight;
			bool flag = currentConsoleHeight != maxConsoleHeight && currentConsoleHeight != 0f;
			float num3 = lineHeight * (float)numLines;
			float height = ((num3 > currentConsoleHeight) ? num3 : currentConsoleHeight);
			if (!closed)
			{
				for (int i = 0; i < buffer.Count; i++)
				{
					BasePrintOnGUI(buffer[i].Key, buffer[i].Value);
				}
				buffer.Clear();
				if (!flag)
				{
					GUI.FocusControl("TextField");
				}
				if (current.type == EventType.KeyDown)
				{
					if (!string.IsNullOrEmpty(inputText))
					{
						switch (current.keyCode)
						{
						case KeyCode.Return:
							if (candidates.Count == 0)
							{
								PrintInput(inputText);
							}
							else
							{
								SelectCurrentCandidate();
							}
							break;
						case KeyCode.Tab:
							if (candidates.Count != 0)
							{
								SelectCurrentCandidate();
							}
							break;
						case KeyCode.Escape:
							showHelp = false;
							candidates.Clear();
							break;
						case KeyCode.F1:
							showHelp = true;
							break;
						}
					}
					switch (current.keyCode)
					{
					case KeyCode.UpArrow:
						if ((inHistory || inputText == string.Empty) && history.Count != 0)
						{
							selectedHistory = Mathf.Clamp(selectedHistory + (inHistory ? 1 : 0), 0, history.Count - 1);
							inputText = history[selectedHistory];
							showHelp = false;
							inHistory = true;
							lastText = inputText;
						}
						else if (inputText != string.Empty && !inHistory)
						{
							selectedCandidate = Mathf.Clamp(--selectedCandidate, 0, candidates.Count - 1);
							if ((float)selectedCandidate * lineHeight <= helpWindowScroll.y || (float)selectedCandidate * lineHeight > helpWindowScroll.y + lineHeight * (float)(numHelpCommandsToShow - 1))
							{
								helpWindowScroll = new Vector2(0f, (float)selectedCandidate * lineHeight - 1f * lineHeight);
							}
						}
						SetCursorPos(inputText, inputText.Length);
						break;
					case KeyCode.DownArrow:
						if ((inHistory || inputText == string.Empty) && history.Count != 0)
						{
							selectedHistory = Mathf.Clamp(selectedHistory - (inHistory ? 1 : 0), 0, history.Count - 1);
							inputText = history[selectedHistory];
							showHelp = false;
							inHistory = true;
							lastText = inputText;
						}
						else if (inputText != string.Empty && !inHistory)
						{
							selectedCandidate = Mathf.Clamp(++selectedCandidate, 0, candidates.Count - 1);
							if ((float)selectedCandidate * lineHeight > helpWindowScroll.y + lineHeight * (float)(numHelpCommandsToShow - 2) || (float)selectedCandidate * lineHeight < helpWindowScroll.y)
							{
								helpWindowScroll = new Vector2(0f, (float)selectedCandidate * lineHeight - (float)(numHelpCommandsToShow - 2) * lineHeight);
							}
						}
						SetCursorPos(inputText, inputText.Length);
						break;
					}
				}
				if (lastText != inputText)
				{
					inHistory = false;
					lastText = string.Empty;
				}
				GUI.Box(new Rect(0f, 0f, Screen.width, currentConsoleHeight), new GUIContent());
				GUI.SetNextControlName("TextField");
				GUI.enabled = !opening;
				inputText = GUI.TextField(new Rect(0f, currentConsoleHeight + 0f, Screen.width, 25f), inputText);
				GUI.enabled = true;
				GUI.skin.textArea.normal.background = null;
				GUI.skin.textArea.hover.background = null;
				consoleScroll = GUI.BeginScrollView(new Rect(0f, 0f, Screen.width, currentConsoleHeight), consoleScroll, new Rect(0f, 0f, Screen.width - 20, height));
				GUI.TextArea(new Rect(0f, -5f + currentConsoleHeight - 0f - ((numLines == 0) ? (0f + lineHeight) : num3) + (((float)numLines >= numLinesThreshold - 1f) ? (lineHeight * ((float)numLines - numLinesThreshold)) : 0f), Screen.width, 7f + ((numLines == 0) ? lineHeight : num3)), consoleText.ToString());
				GUI.EndScrollView();
				if (inputText == string.Empty)
				{
					showHelp = true;
				}
			}
			if (showHelp && helpEnabled && inputText.Trim() != string.Empty)
			{
				ShowHelp();
				if (candidates.Count != 0)
				{
					GUI.skin.textArea.normal.background = GUI.skin.textField.normal.background;
					GUI.skin.textArea.hover.background = GUI.skin.textField.hover.background;
					StringBuilder stringBuilder = new StringBuilder();
					float num4 = helpWindowMinWidth;
					for (int j = 0; j < candidates.Count; j++)
					{
						string text = ((candidates[selectedCandidate] == candidates[j]) ? ("<color=yellow>" + candidates[j].signature.raw + "</color>") : candidates[j].signature.raw);
						float x = GUI.skin.textArea.CalcSize(new GUIContent(text)).x;
						num4 = Mathf.Max(num4, x);
						stringBuilder.Append(text + "\n");
					}
					if (candidates.Count > numHelpCommandsToShow)
					{
						helpWindowScroll = GUI.BeginScrollView(new Rect(0f, currentConsoleHeight - (float)numHelpCommandsToShow * lineHeight - 7f, num4, 5f + lineHeight * (float)numHelpCommandsToShow), helpWindowScroll, new Rect(0f, 0f, num4 - 20f, 7f + (float)candidates.Count * lineHeight));
						GUI.TextArea(new Rect(0f, 0f, num4, 7f + (float)candidates.Count * lineHeight), stringBuilder.ToString());
						GUI.EndScrollView();
					}
					else
					{
						GUI.TextArea(new Rect(0f, currentConsoleHeight - 7f - ((candidates.Count > numHelpCommandsToShow) ? ((float)numHelpCommandsToShow * lineHeight) : (lineHeight * (float)candidates.Count)), num4, ((candidates.Count > numHelpCommandsToShow) ? ((float)numHelpCommandsToShow * lineHeight) : (lineHeight * (float)candidates.Count)) + 7f), stringBuilder.ToString());
					}
				}
			}
			GUI.skin = skin;
		}

		private void SelectCurrentCandidate()
		{
			inputText = candidates[selectedCandidate].name;
			showHelp = false;
			candidates.Clear();
			SetCursorPos(inputText, inputText.Length);
		}

		public static void Open()
		{
			if (!isOpen)
			{
				GUIUtility.keyboardControl = 0;
				Singleton.StartCoroutine(Singleton.FadeInOut(open: true));
			}
		}

		public static void Close()
		{
			if (isOpen)
			{
				GUIUtility.keyboardControl = 0;
				Singleton.StartCoroutine(Singleton.FadeInOut(open: false));
			}
		}

		private IEnumerator FadeInOut(bool open)
		{
			if (!opening)
			{
				opening = true;
				maxConsoleHeight = Screen.height / 3;
				numLinesThreshold = maxConsoleHeight / lineHeight;
				closed = false;
				float duration = extraSettings.curve[extraSettings.curve.length - 1].time;
				float time = 0f;
				do
				{
					currentConsoleHeight = maxConsoleHeight * extraSettings.curve.Evaluate(open ? time : (duration - time));
					yield return null;
					time = Mathf.Clamp(time + Time.unscaledDeltaTime, 0f, duration);
				}
				while (time < duration);
				currentConsoleHeight = maxConsoleHeight * extraSettings.curve.Evaluate(open ? time : (duration - time));
				closed = !open;
				if (closed)
				{
					inputText = string.Empty;
				}
				opening = false;
			}
		}

		private void ShowHelp()
		{
			CommandBase[] commands = manager.GetCommands();
			CommandBase commandBase = null;
			if (candidates.Count != 0 && selectedCandidate >= 0 && candidates.Count > selectedCandidate)
			{
				commandBase = candidates[selectedCandidate];
			}
			candidates.Clear();
			for (int i = 0; i < commands.Length; i++)
			{
				if (commands[i].name.ToUpper().StartsWith(inputText.ToUpper()))
				{
					candidates.Add(commands[i]);
				}
			}
			if (commandBase == null)
			{
				selectedCandidate = 0;
				return;
			}
			for (int j = 0; j < candidates.Count; j++)
			{
				if (candidates[j] == commandBase)
				{
					selectedCandidate = j;
					return;
				}
			}
			selectedCandidate = 0;
		}

		private void SetCursorPos(string text, int pos)
		{
			TextEditor obj = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
			obj.text = text;
			obj.cursorIndex = pos;
			obj.selectIndex = pos;
			GUIUtility.ExitGUI();
		}

		public static string ColorToHex(Color color)
		{
			string text = "0123456789ABCDEF";
			int num = (int)(color.r * 255f);
			int num2 = (int)(color.g * 255f);
			int num3 = (int)(color.b * 255f);
			return text[(int)Mathf.Floor(num / 16)].ToString() + text[(int)Mathf.Round(num % 16)] + text[(int)Mathf.Floor(num2 / 16)] + text[(int)Mathf.Round(num2 % 16)] + text[(int)Mathf.Floor(num3 / 16)] + text[(int)Mathf.Round(num3 % 16)];
		}

		public static void Log(string text)
		{
			Singleton.BasePrint(text);
		}

		public static void Log(object obj)
		{
			Log(obj.ToString());
		}

		public static void LogInfo(string text)
		{
			Singleton.BasePrint(text, Color.cyan);
		}

		public static void LogInfo(object obj)
		{
			LogInfo(obj.ToString());
		}

		public static void LogWarning(string text)
		{
			Singleton.BasePrint(text, Color.yellow);
		}

		public static void LogWarning(object obj)
		{
			LogWarning(obj.ToString());
		}

		public static void LogError(string text)
		{
			Singleton.BasePrint(text, Color.red);
		}

		public static void LogError(object obj)
		{
			LogError(obj.ToString());
		}

		public static void Log(string text, string color)
		{
			Singleton.BasePrint(text, color);
		}

		public static void Log(object obj, string color)
		{
			Log(obj.ToString(), color);
		}

		public static void Log(string text, Color color)
		{
			Singleton.BasePrint(text, color);
		}

		public static void Log(object obj, Color color)
		{
			Log(obj.ToString(), color);
		}

		private void BasePrint(string text)
		{
			BasePrint(text, ColorToHex(Color.white));
		}

		private void BasePrint(string text, Color color)
		{
			BasePrint(text, ColorToHex(color));
		}

		private void BasePrint(string text, string color)
		{
			buffer.Add(new KeyValuePair<string, string>(text, color));
		}

		private void BasePrintOnGUI(string text, string color)
		{
			text = "> " + text;
			int num = 1;
			string value = (extraSettings.showTimeStamp ? ("[" + DateTime.Now.ToShortTimeString() + "]  ") : string.Empty);
			StringBuilder stringBuilder = new StringBuilder(value);
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\n')
				{
					num++;
					stringBuilder = new StringBuilder(value);
				}
				else
				{
					stringBuilder.Append(text[i]);
				}
				if (GUI.skin.textArea.CalcSize(new GUIContent(stringBuilder.ToString())).x > (float)(Screen.width - 20))
				{
					text = text.Insert(i, "\n");
					i--;
				}
			}
			text += "\n";
			numLines += num;
			if ((float)numLines >= numLinesThreshold - 1f)
			{
				consoleScroll = new Vector2(0f, consoleScroll.y + 2.1474836E+09f);
			}
			AddText(text, color);
			if (consoleText.Length >= 18000)
			{
				Clear();
				AddText("Buffer cleared automatically\n", ColorToHex(Color.yellow));
			}
			else if (consoleText.Length >= 16000)
			{
				AddText("Buffer size too large. You should clear the console\n", ColorToHex(Color.red));
			}
			else if (consoleText.Length >= 15000)
			{
				AddText("Buffer size too large. You should clear the console\n", ColorToHex(Color.yellow));
			}
		}

		private void AddText(string text, string color)
		{
			consoleText.Append(string.Format("{0}<color=#{1}>{2}</color>", extraSettings.showTimeStamp ? ("[" + DateTime.Now.ToShortTimeString() + "]  ") : string.Empty, color, text));
		}

		private void PrintInput(string input)
		{
			inputText = string.Empty;
			if ((history.Count == 0 || history[0] != input) && input.Trim() != string.Empty)
			{
				history.Insert(0, input);
			}
			selectedHistory = 0;
			BasePrint(input);
			ExecuteCommandInternal(input);
		}

		private void LogCallback(string log, string stackTrace, LogType type)
		{
			Color color;
			switch (type)
			{
			case LogType.Error:
			case LogType.Assert:
			case LogType.Exception:
				color = Color.red;
				break;
			case LogType.Warning:
				color = Color.yellow;
				break;
			default:
				color = Color.cyan;
				break;
			}
			BasePrint(log, color);
			BasePrint(stackTrace, color);
			int num = (int)GUI.skin.textArea.CalcSize(new GUIContent(log)).x;
			while (num >= Screen.width)
			{
				num -= Screen.width;
				numLines++;
			}
			numLines++;
		}

		public static void ExecuteCommand(string command)
		{
			Singleton.ExecuteCommandInternal(command);
		}

		public static void ExecuteCommand(string command, string args)
		{
			Singleton.ExecuteCommandInternal(command + " " + args);
		}

		private void ExecuteCommandInternal(string command)
		{
			CommandExecuter commandExecuter = manager.GetCommandExecuter(command);
			if (commandExecuter.IsValidCommand())
			{
				commandExecuter.Execute();
			}
			else
			{
				Debug.LogError("The command '" + command + "' is not valid");
			}
		}

		public static void AddCommands(params CommandBase[] cs)
		{
			for (int i = 0; i < cs.Length; i++)
			{
				AddCommand(cs[i]);
			}
		}

		public static void AddCommand(CommandBase c)
		{
			Singleton.manager.Add(c);
		}

		[Obsolete]
		public static void RemoveCommand(string commandName)
		{
		}

		[Command(alias = "clear", description = "Clears the console")]
		private static void Clear()
		{
			Singleton.consoleText = new StringBuilder();
			Singleton.numLines = 0;
		}

		[Command(alias = "help", description = "Shows this message")]
		private static void HelpCommand()
		{
			CommandBase[] commands = Singleton.manager.GetCommands();
			StringBuilder stringBuilder = new StringBuilder("List of commands\n");
			for (int i = 0; i < commands.Length; i++)
			{
				stringBuilder.Append(commands[i].name + ((commands[i].description == null) ? string.Empty : (" - " + commands[i].description)));
				if (i < commands.Length - 1)
				{
					stringBuilder.Append('\n');
				}
			}
			LogInfo(stringBuilder.ToString());
		}

		[Command(alias = "changeKey", description = "Changes de key used to open/close the console. Type \"changeKeyHelp\" for extra help")]
		private static void ChangeKey(string key)
		{
		}

		[Command(alias = "changeKeyHelp", description = "Lists all of the possible keys to use with the \"changeKey\" command")]
		private static void ChangeKeyHelp()
		{
			string[] names = Enum.GetNames(typeof(KeyCode));
			StringBuilder stringBuilder = new StringBuilder("\nSPECIAL KEYS 1: ");
			int num = 0;
			for (int i = 0; i < names.Length; i++)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				switch (i)
				{
				case 22:
					stringBuilder2.Append("\n\nNUMERIC KEYS: ");
					num = 0;
					break;
				case 32:
					stringBuilder2.Append("\n\nSPECIAL KEYS 2: ");
					num = 0;
					break;
				case 45:
					stringBuilder2.Append("\n\nALPHA KEYS: ");
					num = 0;
					break;
				case 71:
					stringBuilder2.Append("\n\nKEYPAD KEYS: ");
					num = 0;
					break;
				case 89:
					stringBuilder2.Append("\n\nSPECIAL KEYS 3: ");
					num = 0;
					break;
				case 98:
					stringBuilder2.Append("\n\nF KEYS: ");
					num = 0;
					break;
				case 113:
					stringBuilder2.Append("\n\nSPECIAL KEYS 4: ");
					num = 0;
					break;
				case 134:
					stringBuilder2.Append("\n\nMOUSE: ");
					num = 0;
					break;
				case 141:
					stringBuilder2.Append("\n\nJOYSTICK KEYS: ");
					num = 0;
					break;
				}
				stringBuilder2.Append(string.Format("{0}[{1}]{2}", names[i], i, (i != names.Length - 1) ? "," : ""));
				num += stringBuilder2.Length;
				stringBuilder.Append(stringBuilder2);
				if (num >= 65)
				{
					stringBuilder.Append('\n');
					num = 0;
				}
			}
			LogInfo("Command Info: " + stringBuilder.ToString());
		}

		[Command(alias = "showLog", description = "Whether or not to show Debug.Log and its variants")]
		private static void ShowLog(bool value)
		{
			if (value)
			{
				Application.logMessageReceived += Singleton.LogCallback;
			}
			else
			{
				Application.logMessageReceived -= Singleton.LogCallback;
			}
			Log("Change successful", Color.green);
		}

		[Command(alias = "showTimeStamp", description = "Whether or not to show a time stamp on each message")]
		private static void ShowTimeStamp(bool value)
		{
			Singleton.extraSettings.showTimeStamp = value;
			Log("Change successful", Color.green);
		}

		[Command(alias = "setFontSize", description = "Set the font size used in the console")]
		private static void SetFontSize(int size)
		{
			Singleton.fontSize = size;
			Log("Change successful", Color.green);
		}
	}
}
