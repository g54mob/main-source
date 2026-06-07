using System.Collections.Generic;
using UnityEngine;

namespace CommandTerminal
{
	public class Terminal : MonoBehaviour
	{
		[Header("Window")]
		[Range(0f, 1f)]
		[SerializeField]
		private float MaxHeight = 0.7f;

		[SerializeField]
		[Range(0f, 1f)]
		private float SmallTerminalRatio = 0.33f;

		[Range(100f, 6000f)]
		[SerializeField]
		private float ToggleSpeed = 360f;

		[SerializeField]
		public TerminalKeyboardInputProvider inputProvider;

		[SerializeField]
		internal int BufferSize = 512;

		[Header("Input")]
		[SerializeField]
		protected Font ConsoleFont;

		[SerializeField]
		private string InputCaret = ">";

		[SerializeField]
		private bool ShowGUIButtons;

		[SerializeField]
		private bool RightAlignButtons;

		[Header("Theme")]
		[Range(0f, 1f)]
		[SerializeField]
		private float InputContrast;

		[Range(0f, 1f)]
		[SerializeField]
		private float InputAlpha = 0.5f;

		[SerializeField]
		private Color BackgroundColor = Color.black;

		[SerializeField]
		private Color ForegroundColor = Color.white;

		[SerializeField]
		private Color ShellColor = Color.white;

		[SerializeField]
		private Color InputColor = Color.cyan;

		[SerializeField]
		private Color WarningColor = Color.yellow;

		[SerializeField]
		private Color ErrorColor = Color.red;

		private TerminalState state;

		private TextEditor editor_state;

		private bool input_fix;

		private bool move_cursor;

		private bool last_input_was_tab;

		private string[] completion_buffer;

		private int completion_index;

		internal bool initial_open;

		private Rect window;

		private float current_open_t;

		private float open_target;

		private float real_window_size;

		private string command_text;

		private string cached_command_text;

		private Vector2 scroll_position;

		private GUIStyle window_style;

		private GUIStyle label_style;

		private GUIStyle input_style;

		private Texture2D background_texture;

		private Texture2D input_background_texture;

		public static CommandLog Buffer { get; internal set; }

		public static CommandShell Shell { get; internal set; }

		public static CommandHistory History { get; internal set; }

		public static CommandAutocomplete Autocomplete { get; internal set; }

		public static bool IssuedError => Shell.IssuedErrorMessage != null;

		public bool IsClosed
		{
			get
			{
				if (state == TerminalState.Close)
				{
					return Mathf.Approximately(current_open_t, open_target);
				}
				return false;
			}
		}

		private bool IsTabOrShiftTab
		{
			get
			{
				if (!Event.current.Equals(Event.KeyboardEvent("tab")))
				{
					if (Event.current.type == EventType.KeyDown && Event.current.shift)
					{
						return Event.current.character == '\t';
					}
					return false;
				}
				return true;
			}
		}

		public static void Log(string format, params object[] message)
		{
			Log(TerminalLogType.ShellMessage, format, message);
		}

		public static void Log(TerminalLogType type, string format, params object[] message)
		{
			Buffer.HandleLog(string.Format(format, message), type);
		}

		public void SetState(TerminalState new_state)
		{
			input_fix = true;
			cached_command_text = command_text;
			command_text = "";
			switch (new_state)
			{
			case TerminalState.Close:
				open_target = 0f;
				editor_state = null;
				break;
			case TerminalState.OpenSmall:
				open_target = (float)Screen.height * MaxHeight * SmallTerminalRatio;
				if (current_open_t > open_target)
				{
					open_target = 0f;
					state = TerminalState.Close;
					return;
				}
				real_window_size = open_target;
				scroll_position.y = 2.1474836E+09f;
				break;
			default:
				real_window_size = (float)Screen.height * MaxHeight;
				open_target = real_window_size;
				break;
			}
			state = new_state;
			inputProvider.SetTerminalOpen(state != TerminalState.Close);
		}

		public void ToggleState(TerminalState new_state)
		{
			if (state == new_state)
			{
				SetState(TerminalState.Close);
			}
			else
			{
				SetState(new_state);
			}
		}

		private void Awake()
		{
			if (ConsoleFont == null)
			{
				ConsoleFont = Font.CreateDynamicFontFromOSFont("Courier New", 16);
				Debug.LogWarning("Command Console Warning: Please assign a font.");
			}
			if (GetComponent<TerminalKeyboardHandler>() == null)
			{
				base.gameObject.AddComponent<TerminalKeyboardHandler>();
			}
			command_text = "";
			cached_command_text = command_text;
			SetupWindow();
			SetupInput();
			SetupLabels();
			Shell.RegisterCommands();
			if (IssuedError)
			{
				Log(TerminalLogType.Error, "Error: {0}", Shell.IssuedErrorMessage);
			}
			foreach (KeyValuePair<string, CommandInfo> command in Shell.Commands)
			{
				if (!command.Value.secret)
				{
					Autocomplete.Register(command.Value);
				}
			}
		}

		private void OnGUI()
		{
			if (ShowGUIButtons)
			{
				DrawGUIButtons();
			}
			if (IsClosed)
			{
				base.enabled = false;
				return;
			}
			HandleOpenness();
			window = GUILayout.Window(88, window, DrawConsole, string.Empty, window_style);
		}

		private void SetupWindow()
		{
			real_window_size = (float)Screen.height * MaxHeight / 3f;
			window = new Rect(0f, current_open_t - real_window_size, Screen.width, real_window_size);
			background_texture = new Texture2D(1, 1);
			background_texture.SetPixel(0, 0, BackgroundColor);
			background_texture.Apply();
			window_style = new GUIStyle();
			window_style.normal.background = background_texture;
			window_style.padding = new RectOffset(4, 4, 4, 4);
			window_style.normal.textColor = ForegroundColor;
			window_style.font = ConsoleFont;
		}

		private void SetupLabels()
		{
			label_style = new GUIStyle();
			label_style.font = ConsoleFont;
			label_style.normal.textColor = ForegroundColor;
			label_style.wordWrap = true;
		}

		private void SetupInput()
		{
			input_style = new GUIStyle();
			input_style.padding = new RectOffset(4, 4, 4, 4);
			input_style.font = ConsoleFont;
			input_style.fixedHeight = (float)ConsoleFont.fontSize * 1.6f;
			input_style.normal.textColor = InputColor;
			Color color = new Color
			{
				r = BackgroundColor.r - InputContrast,
				g = BackgroundColor.g - InputContrast,
				b = BackgroundColor.b - InputContrast,
				a = InputAlpha
			};
			input_background_texture = new Texture2D(1, 1);
			input_background_texture.SetPixel(0, 0, color);
			input_background_texture.Apply();
			input_style.normal.background = input_background_texture;
		}

		protected virtual void DrawConsole(int Window2D)
		{
			GUILayout.BeginVertical();
			scroll_position = GUILayout.BeginScrollView(scroll_position, false, false, GUIStyle.none, GUIStyle.none);
			GUILayout.FlexibleSpace();
			if (completion_buffer != null && last_input_was_tab)
			{
				DrawCompletions();
			}
			else
			{
				DrawLogs();
			}
			GUILayout.EndScrollView();
			if (IsTabOrShiftTab)
			{
				scroll_position.y = 2.1474836E+09f;
			}
			if (move_cursor)
			{
				CursorToEnd();
				move_cursor = false;
			}
			if (Event.current.Equals(Event.KeyboardEvent("escape")))
			{
				last_input_was_tab = false;
				SetState(TerminalState.Close);
			}
			else if (Event.current.Equals(Event.KeyboardEvent("return")) || Event.current.Equals(Event.KeyboardEvent("[enter]")))
			{
				last_input_was_tab = false;
				EnterCommand();
			}
			else if (Event.current.Equals(Event.KeyboardEvent("up")))
			{
				command_text = History.Previous();
				last_input_was_tab = false;
				move_cursor = true;
			}
			else if (Event.current.Equals(Event.KeyboardEvent("down")))
			{
				last_input_was_tab = false;
				command_text = History.Next();
			}
			else if (IsTabOrShiftTab)
			{
				last_input_was_tab = true;
				CompleteCommand(Event.current.shift);
				move_cursor = true;
			}
			else if (Event.current.type == EventType.KeyDown && Event.current.character != '\t')
			{
				if (!Event.current.shift)
				{
					last_input_was_tab = false;
				}
				if (inputProvider.GetButtonDown())
				{
					if (Event.current.shift)
					{
						ToggleState(TerminalState.OpenFull);
					}
					else
					{
						ToggleState(TerminalState.OpenSmall);
					}
				}
			}
			if (!last_input_was_tab)
			{
				Autocomplete.lastInput = null;
			}
			GUILayout.BeginHorizontal();
			if (InputCaret != "")
			{
				GUILayout.Label(InputCaret, input_style, GUILayout.Width(ConsoleFont.fontSize));
			}
			GUI.SetNextControlName("command_text_field");
			command_text = GUILayout.TextField(command_text, input_style);
			if (input_fix && command_text.Length > 0)
			{
				command_text = cached_command_text;
				input_fix = false;
			}
			if (initial_open)
			{
				GUI.FocusControl("command_text_field");
				initial_open = false;
			}
			if (ShowGUIButtons && GUILayout.Button("| run", input_style, GUILayout.Width(Screen.width / 10)))
			{
				EnterCommand();
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		}

		private void DrawLogs()
		{
			foreach (LogItem log in Buffer.Logs)
			{
				label_style.normal.textColor = GetLogColor(log.type);
				GUILayout.Label(log.message, label_style);
			}
		}

		private void DrawCompletions()
		{
			for (int i = 0; i < completion_buffer.Length; i++)
			{
				label_style.normal.textColor = ((i == completion_index) ? WarningColor : ForegroundColor);
				GUILayout.Label(completion_buffer[i], label_style);
			}
			label_style.normal.textColor = InputColor;
			if (Shell.Commands.TryGetValue(completion_buffer[completion_index].ToUpper(), out var value))
			{
				GUILayout.Label("", label_style);
				if (!string.IsNullOrEmpty(value.help))
				{
					GUILayout.Label(value.help, label_style);
				}
				string text = ((value.min_arg_count == value.max_arg_count) ? $"{value.min_arg_count} args" : ((value.max_arg_count < 0) ? $"{value.min_arg_count}+ args" : $"{value.min_arg_count} - {value.max_arg_count} args"));
				GUILayout.Label("  [" + text + "]", label_style);
			}
		}

		private void DrawGUIButtons()
		{
			int fontSize = ConsoleFont.fontSize;
			GUILayout.BeginArea(new Rect(RightAlignButtons ? (Screen.width - 7 * fontSize) : 0, current_open_t, 7 * fontSize, fontSize * 2));
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Small", window_style))
			{
				ToggleState(TerminalState.OpenSmall);
			}
			else if (GUILayout.Button("Full", window_style))
			{
				ToggleState(TerminalState.OpenFull);
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		private void HandleOpenness()
		{
			float num = ToggleSpeed * Time.unscaledDeltaTime;
			if (current_open_t < open_target)
			{
				current_open_t += num;
				if (current_open_t > open_target)
				{
					current_open_t = open_target;
				}
			}
			else
			{
				if (!(current_open_t > open_target))
				{
					if (input_fix)
					{
						input_fix = false;
					}
					return;
				}
				current_open_t -= num;
				if (current_open_t < open_target)
				{
					current_open_t = open_target;
				}
			}
			window = new Rect(0f, current_open_t - real_window_size, Screen.width, real_window_size);
		}

		private void EnterCommand()
		{
			Log(TerminalLogType.Input, "{0}", command_text);
			Shell.RunCommand(command_text);
			History.Push(command_text);
			if (IssuedError)
			{
				Log(TerminalLogType.Error, "Error: {0}", Shell.IssuedErrorMessage);
			}
			command_text = "";
			scroll_position.y = 2.1474836E+09f;
		}

		private void CompleteCommand(bool backwards)
		{
			string inputText = ((Autocomplete.lastInput == null) ? command_text : Autocomplete.lastInput);
			(string[] all, int index) tuple = Autocomplete.Complete(inputText, backwards);
			string[] item = tuple.all;
			int item2 = tuple.index;
			int num = item.Length;
			if (num != 0)
			{
				command_text = item[item2];
			}
			if (num > 1)
			{
				completion_buffer = item;
				completion_index = item2;
			}
			else
			{
				completion_buffer = null;
				completion_index = 0;
			}
		}

		private void CursorToEnd()
		{
			if (editor_state == null)
			{
				editor_state = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
			}
			editor_state.MoveCursorToPosition(new Vector2(999f, 999f));
		}

		internal void HandleUnityLog(string message, string stack_trace, LogType type)
		{
			Buffer.HandleLog(message, stack_trace, (TerminalLogType)type);
			scroll_position.y = 2.1474836E+09f;
		}

		private Color GetLogColor(TerminalLogType type)
		{
			switch (type)
			{
			case TerminalLogType.Message:
				return ForegroundColor;
			case TerminalLogType.Warning:
				return WarningColor;
			case TerminalLogType.Input:
				return InputColor;
			case TerminalLogType.ShellMessage:
				return ShellColor;
			default:
				return ErrorColor;
			}
		}
	}
}
