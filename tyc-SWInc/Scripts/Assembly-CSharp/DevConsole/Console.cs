using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using StatementParser;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DevConsole
{
	[Serializable]
	public class Console : MonoBehaviour, ISerializationCallbackReceiver
	{
		public RectTransform ConsoleRect;

		public RectTransform HelpRect;

		public InputFieldNoSelect MainInput;

		public Scrollbar MainScroll;

		public Scrollbar HelpScroll;

		public Text MainText;

		public Text HelpText;

		public float LineHeight;

		private int HelpOffset;

		[SerializeField]
		private bool dontDestroyOnLoad;

		[Range(8f, 20f)]
		public int fontSize;

		private const int TEXT_AREA_OFFSET = 7;

		private bool helpEnabled = true;

		private int numHelpCommandsToShow = 5;

		private float helpWindowWidth = 256f;

		private const int WARNING_THRESHOLD = 14000;

		private const int DANGER_THRESHOLD = 15000;

		private const int AUTOCLEAR_THRESHOLD = 16000;

		private List<CommandBase> consoleCommands;

		private List<string> candidates = new List<string>();

		private int selectedCandidate;

		private List<string> history = new List<string>();

		private int selectedHistory;

		public static Console Singleton;

		private bool opening;

		private bool closed = true;

		private bool showHelp = true;

		private bool inHistory;

		private bool showTimeStamp;

		private float numLinesThreshold;

		public float ConsoleHeightRatio = 1f / 3f;

		private float maxConsoleHeight;

		private float currentConsoleHeight;

		private Vector2 helpWindowScroll = Vector2.zero;

		[HideInInspector]
		[SerializeField]
		private string serializedConsoleText = string.Empty;

		private string[] newConsoleText = new string[10000];

		private int _consoleTextLength;

		private int _consoleTextPos;

		private string lastText = string.Empty;

		private int currentScoll;

		[SerializeField]
		private Settings extraSettings;

		private bool _initialized;

		public bool InitializeGame = true;

		private int _cPos;

		private int _cSel;

		private bool _isDragging;

		private StringBuilder _stringCache = new StringBuilder();

		private float openTime;

		private bool closing;

		private static List<string> _argCache = new List<string>();

		private static Regex TagRegex = new Regex("\\G\\<(([^\\>]+)(\\=[^\\>]+)?)\\>.+\\<\\/\\2\\>");

		private float _lastEx;

		private int _lastExCount;

		private string inputText
		{
			get
			{
				return MainInput.text;
			}
			set
			{
				MainInput.text = value;
			}
		}

		public static bool verbose
		{
			get
			{
				return Singleton.extraSettings.logVerbose;
			}
			set
			{
				Singleton.extraSettings.logVerbose = value;
			}
		}

		public static bool isOpen
		{
			get
			{
				if (Singleton != null)
				{
					return !Singleton.closed;
				}
				return false;
			}
		}

		private void Awake()
		{
			if (base.enabled)
			{
				if (Singleton != null)
				{
					Singleton.transform.SetParent(base.transform.parent, false);
					Singleton.transform.SetAsLastSibling();
					Singleton.gameObject.SetActive(true);
					UnityEngine.Object.Destroy(base.gameObject);
					Example component = GetComponent<Example>();
					if (component != null)
					{
						component.enabled = false;
					}
					return;
				}
				Singleton = this;
				if (Options.SaveConsole)
				{
					string path = Path.Combine(Utilities.GetRoot(), "ConsoleHistory.txt");
					if (File.Exists(path))
					{
						try
						{
							history.AddRange(File.ReadAllLines(path));
						}
						catch (Exception)
						{
						}
					}
				}
				if (base.transform.parent != null)
				{
					base.transform.SetAsLastSibling();
				}
				if (extraSettings.showDebugLog)
				{
					Application.logMessageReceived += LogCallback;
				}
			}
			if (InitializeGame)
			{
				GameData.InitializeNow();
			}
		}

		public static void SaveConsole()
		{
			if (Singleton != null && Singleton.dontDestroyOnLoad)
			{
				Singleton.transform.SetParent(null, false);
				UnityEngine.Object.DontDestroyOnLoad(Singleton);
				Singleton.gameObject.SetActive(false);
			}
		}

		private void OnEnable()
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			if (consoleCommands == null)
			{
				consoleCommands = new List<CommandBase>();
			}
			if (extraSettings.defaultCommands)
			{
				AddCommands(new Command("CLEAR", Clear, "Clears the console"), new Command<int>("CLEAR_X", ClearX, "Clears all but the last X lines of the console"), new Command<bool>("SHOW_ON_ERROR", delegate(bool x)
				{
					Options.SetAndSave("ConsoleOnError", x);
				}, "Whether to show the console when an error occurs"), new Command<bool>("SHOW_TIMESTAMP", ShowTimeStamp, "Whether to show the time stamp for each command"), new Command("HELP", delegate
				{
					HelpCommand(false);
				}, "Shows a list of all Commands available"), new Command("HELP_ALPHA", delegate
				{
					HelpCommand(true);
				}, "Shows a list of all Commands available in alphabetical order"), new Command<int>("SET_FONT_SIZE", SetFontSize, "Sets the font size of the Console"), new Command<bool>("TOGGLE_ERRORS", ShowLog, "Whether to print internal errors"), new Command<bool>("TOGGLE_VERBOSE", ShowVerbose, "Whether errors should be printed with stacktrace"), new Command("CLEAR_HISTORY", delegate
				{
					history.Clear();
				}, "Clear console history"));
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnEndEdit()
		{
			if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)) && !string.IsNullOrEmpty(MainInput.text))
			{
				string[] array = MainInput.text.SplitByNewLines();
				for (int i = 0; i < array.Length; i++)
				{
					PrintInput(array[i]);
				}
				MainInput.text = string.Empty;
				candidates.Clear();
				showHelp = true;
			}
		}

		public void TextChanged()
		{
			if (inHistory)
			{
				inHistory = false;
				showHelp = true;
			}
		}

		public void Scroll(BaseEventData ee)
		{
			PointerEventData pointerEventData = ee as PointerEventData;
			if (pointerEventData != null)
			{
				int num = Mathf.Max(0, _consoleTextLength - GetMaxLines());
				MainScroll.value = Mathf.Clamp01(MainScroll.value - pointerEventData.scrollDelta.y / (float)num);
			}
		}

		public void StartDrag()
		{
			_isDragging = true;
		}

		public void RefreshText()
		{
			if (!CanvasUpdateRegistry.IsRebuildingGraphics())
			{
				MainText.text = GetConsoleText();
			}
		}

		private void Update()
		{
			RefreshOpenState();
			if ((!closed && !closing && !InputController.IsBound(InputController.Keys.NewConsole)) || InputController.GetKeyDown(InputController.Keys.NewConsole, true))
			{
				if (closed || closing)
				{
					Open();
				}
				else
				{
					Close();
				}
			}
			if (closed)
			{
				return;
			}
			InputController.InputEnabled = false;
			if (_isDragging)
			{
				ConsoleHeightRatio = Mathf.Clamp(1f - (Input.mousePosition.y - 12f) / (float)Screen.height, 0.1f, 1f);
				MainScroll.size = 1f / (float)Mathf.Max(1, _consoleTextLength - GetMaxLines() + 1);
				RefreshText();
				if (Input.GetMouseButtonUp(0))
				{
					_isDragging = false;
				}
			}
			bool flag = opening || closing;
			if (Input.GetKeyDown(KeyCode.Period) && (inputText.ToUpper().StartsWith("EXECUTE ") || inputText.ToUpper().StartsWith("LIST_SCOPE_MEMBERS ")))
			{
				showHelp = true;
			}
			if (Input.GetKeyDown(KeyCode.Tab) && candidates.Count != 0)
			{
				if (inputText.ToUpper().StartsWith("EXECUTE "))
				{
					FixCursorPos(7);
				}
				else if (inputText.ToUpper().StartsWith("LIST_SCOPE_MEMBERS "))
				{
					FixCursorPos(18);
				}
				else
				{
					bool flag2 = false;
					foreach (CommandBase consoleCommand in consoleCommands)
					{
						if (inputText.ToUpper().StartsWith(consoleCommand.name.ToUpper()))
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						inputText += candidates[selectedCandidate];
					}
					else
					{
						inputText = candidates[selectedCandidate];
					}
					inputText += " ";
					if (!inputText.ToUpper().StartsWith("EXECUTE"))
					{
						inputText.ToUpper().StartsWith("LIST_SCOPE_MEMBERS");
					}
					candidates.Clear();
					SetCursorPos(inputText.Length);
				}
			}
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
			{
				candidates.Clear();
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if ((inHistory || inputText == string.Empty) && history.Count != 0)
				{
					selectedHistory = Mathf.Clamp(selectedHistory + (inHistory ? 1 : 0), 0, history.Count - 1);
					inputText = history[selectedHistory];
					showHelp = false;
					inHistory = true;
					lastText = inputText;
					SetCursorPos(inputText.Length);
				}
				else if (inputText != string.Empty && !inHistory)
				{
					selectedCandidate = Mathf.Clamp(--selectedCandidate, 0, candidates.Count - 1);
				}
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if ((inHistory || inputText == string.Empty) && history.Count != 0)
				{
					selectedHistory = Mathf.Clamp(selectedHistory - (inHistory ? 1 : 0), 0, history.Count - 1);
					inputText = history[selectedHistory];
					showHelp = false;
					inHistory = true;
					lastText = inputText;
					SetCursorPos(inputText.Length);
				}
				else if (inputText != string.Empty && !inHistory)
				{
					selectedCandidate = Mathf.Clamp(++selectedCandidate, 0, candidates.Count - 1);
				}
			}
			if (!flag)
			{
				if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
				{
					MainInput.selectionAnchorPosition = _cSel;
					MainInput.selectionFocusPosition = _cPos;
				}
				if (!MainInput.isFocused)
				{
					MainInput.ActivateInputField();
				}
				_cPos = MainInput.selectionFocusPosition;
				_cSel = MainInput.selectionAnchorPosition;
			}
			HelpRect.gameObject.SetActive(false);
			if (!showHelp || !helpEnabled || !(inputText.Trim() != string.Empty))
			{
				return;
			}
			ShowHelp();
			if (candidates.Count == 0)
			{
				return;
			}
			if (HelpOffset > selectedCandidate)
			{
				HelpOffset = selectedCandidate;
			}
			else if (HelpOffset + numHelpCommandsToShow <= selectedCandidate)
			{
				HelpOffset = selectedCandidate - numHelpCommandsToShow + 1;
			}
			HelpOffset = Mathf.Clamp(HelpOffset, 0, Mathf.Max(0, candidates.Count - numHelpCommandsToShow));
			HelpRect.gameObject.SetActive(true);
			string text = string.Empty;
			int num = 0;
			for (int i = 0; i < numHelpCommandsToShow; i++)
			{
				int num2 = i + HelpOffset;
				if (num2 >= candidates.Count)
				{
					break;
				}
				string text2 = candidates[num2];
				text = text + ((num2 == selectedCandidate) ? ("<color=yellow>" + text2 + "</color>") : text2) + "\n";
				num++;
			}
			HelpRect.sizeDelta = new Vector2(helpWindowWidth, num * 16 + 8);
			if (candidates.Count > numHelpCommandsToShow)
			{
				HelpScroll.gameObject.SetActive(true);
				HelpScroll.value = (float)HelpOffset / (float)(candidates.Count - numHelpCommandsToShow);
				HelpText.text = text;
			}
			else
			{
				HelpScroll.gameObject.SetActive(false);
				HelpText.text = text;
			}
		}

		private void FixCursorPos(int len)
		{
			int cursorPos = GetCursorPos();
			int[] array = DotSearchBack(inputText, Mathf.Clamp(cursorPos, 0, inputText.Length - 1));
			array[1] = Mathf.Max(array[1], len);
			string text = candidates[selectedCandidate];
			inputText = inputText.Remove(array[1] + 1, cursorPos - array[1] - 1).Insert(array[1] + 1, text);
			candidates.Clear();
			SetCursorPos(array[1] + text.Length + 1);
		}

		public int GetMaxLines()
		{
			return Mathf.FloorToInt(((float)Screen.height * ConsoleHeightRatio - 30f) / LineHeight);
		}

		private string GetConsoleText()
		{
			_stringCache.Clear();
			if (newConsoleText.Length != 0)
			{
				int maxLines = GetMaxLines();
				int num = Mathf.CeilToInt(MainScroll.value * (float)Mathf.Max(0, _consoleTextLength - maxLines));
				int i = 0;
				bool flag = true;
				int num2 = _consoleTextPos - _consoleTextLength;
				if (num2 < 0)
				{
					num2 = Mathf.Max(0, newConsoleText.Length + num2);
				}
				for (; i < maxLines && num + i < _consoleTextLength; i++)
				{
					if (!flag)
					{
						_stringCache.Append('\n');
					}
					flag = false;
					_stringCache.Append(newConsoleText[(num2 + num + i) % newConsoleText.Length]);
				}
			}
			return _stringCache.ToString();
		}

		public static void Open()
		{
			if (!(Singleton == null) && !isOpen)
			{
				Singleton.MainInput.gameObject.SetActive(true);
				Singleton.MainInput.ActivateInputField();
				if (Singleton.closed)
				{
					Singleton.closed = false;
					Singleton.closing = false;
					Singleton.opening = true;
					Singleton.openTime = Time.realtimeSinceStartup;
				}
			}
		}

		public static void Close()
		{
			if (!(Singleton == null) && isOpen)
			{
				GUIUtility.keyboardControl = 0;
				if (!Singleton.closed)
				{
					Singleton.closing = true;
					Singleton.opening = false;
					Singleton.openTime = Time.realtimeSinceStartup;
				}
			}
		}

		private void RefreshOpenState()
		{
			if (opening || closing)
			{
				float num = Time.realtimeSinceStartup - openTime;
				float time = extraSettings.curve[extraSettings.curve.length - 1].time;
				if (num > time)
				{
					if (opening)
					{
						opening = false;
						closed = false;
						showHelp = true;
					}
					else
					{
						closing = false;
						closed = true;
						InputController.InputEnabled = true;
						MainInput.text = string.Empty;
						Singleton.MainInput.gameObject.SetActive(false);
					}
				}
				else
				{
					currentConsoleHeight = extraSettings.curve.Evaluate(closing ? (time - num) : num) * (float)Mathf.RoundToInt((float)Screen.height / Options.UISize * ConsoleHeightRatio);
				}
			}
			else
			{
				currentConsoleHeight = ((!closed) ? Mathf.RoundToInt((float)Screen.height / Options.UISize * ConsoleHeightRatio) : 0);
			}
			ConsoleRect.sizeDelta = new Vector2(ConsoleRect.sizeDelta.x, currentConsoleHeight);
		}

		private void GetHelp(Type tp, string rest, bool addParan = true, BindingFlags b = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
		{
			HashSet<string> hashSet = tp.GetFields(b).WhereSelect((FieldInfo x) => !x.IsSpecialName, (FieldInfo x) => x.Name).ToHashSet();
			hashSet.AddRange(tp.GetProperties(b).WhereSelect((PropertyInfo x) => !x.IsSpecialName, (PropertyInfo x) => x.Name));
			hashSet.AddRange(tp.GetMethods(b).WhereSelect((MethodInfo x) => !x.IsSpecialName, (MethodInfo x) => (!addParan) ? x.Name : (x.Name + "(" + ((x.GetParameters().Length == 0) ? ")" : ""))));
			if (!addParan)
			{
				hashSet.AddRange(tp.GetMembers(b).WhereSelect((MemberInfo x) =>
				{
					Type type;
					return (object)(type = x as Type) != null && type.IsEnum;
				}, (MemberInfo x) => x.Name));
			}
			GetHelp(hashSet, rest);
		}

		private void GetHelp(IEnumerable<string> cand, string rest)
		{
			string rr = rest.ToUpper();
			candidates.AddRange(from x in cand
				where x.ToUpper().StartsWith(rr)
				orderby x
				select x);
			if (candidates.Count == 1 && candidates[0] == rest)
			{
				candidates.Clear();
			}
		}

		private void ShowHelp()
		{
			string text = string.Empty;
			if (candidates.Count != 0 && selectedCandidate >= 0 && candidates.Count > selectedCandidate)
			{
				text = candidates[selectedCandidate];
			}
			candidates.Clear();
			if (inputText.ToUpper().StartsWith("EXECUTE "))
			{
				string text2 = inputText.Substring(8);
				int num = GetCursorPos() - 9;
				int[] array = DotSearchBack(text2, Mathf.Clamp(num, 0, text2.Length - 1));
				if (array[1] > -1)
				{
					try
					{
						LineParse.TreeNode node = LineParse.Parse(text2.Substring(array[0], array[1] - array[0]));
						string rest = text2.Substring(array[1] + 1, num - array[1]);
						Type type = LineParse.GetType(node, Example.ParserInstance);
						if (type != null)
						{
							GetHelp(type, rest, true, LineParse.GetBindings(Example.ParserInstance.IsProtected()));
						}
					}
					catch (Exception)
					{
					}
				}
				else if (text2.Length > 0)
				{
					GetHelp(typeof(Example.ParserWorld), text2);
				}
			}
			else if (inputText.ToUpper().StartsWith("LIST_SCOPE_MEMBERS "))
			{
				string text3 = inputText.Substring(19);
				int num2 = GetCursorPos() - 20;
				int[] array2 = DotSearchBack(text3, Mathf.Clamp(num2, 0, text3.Length - 1));
				if (array2[1] > -1)
				{
					try
					{
						string err;
						string fullErr;
						Type scopeType = Example.GetScopeType(text3.Substring(array2[0], array2[1] - array2[0]), out err, out fullErr);
						if (scopeType != null)
						{
							string rest2 = text3.Substring(array2[1] + 1, num2 - array2[1]);
							GetHelp(scopeType, rest2, false);
						}
					}
					catch (Exception)
					{
					}
				}
				else
				{
					GetHelp(from x in Example.GetValidScopeTypes()
						select x.Name, text3);
				}
			}
			else
			{
				for (int num3 = 0; num3 < consoleCommands.Count; num3++)
				{
					if (consoleCommands[num3].ShouldHide())
					{
						continue;
					}
					if (inputText.EndsWith(" ") && inputText.ToUpper().StartsWith(consoleCommands[num3].name.ToUpper() + " "))
					{
						string[] array3 = ParseArguments(inputText, consoleCommands[num3].name.Length + 1);
						IEnumerable<string> paramHelp = consoleCommands[num3].GetParamHelp(array3, array3.Length);
						if (paramHelp == null)
						{
							break;
						}
						foreach (string item in paramHelp)
						{
							candidates.Add(item.Contains(' ') ? ("\"" + item + "\"") : item);
						}
						break;
					}
					if (consoleCommands[num3].name.Replace("_", "").ToUpper().StartsWith(inputText.Replace("_", "").ToUpper()))
					{
						candidates.Add(consoleCommands[num3].name);
					}
				}
			}
			if (text == string.Empty)
			{
				selectedCandidate = 0;
				HelpOffset = 0;
				return;
			}
			for (int num4 = 0; num4 < candidates.Count; num4++)
			{
				if (candidates[num4] == text)
				{
					selectedCandidate = num4;
					return;
				}
			}
			selectedCandidate = 0;
			HelpOffset = 0;
		}

		private static string[] ParseArguments(string input, int skip)
		{
			_argCache.Clear();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			for (int i = skip; i < input.Length; i++)
			{
				if (flag)
				{
					if (input[i] == '"')
					{
						flag = false;
						_argCache.Add(stringBuilder.ToString());
						stringBuilder.Clear();
						i++;
					}
					else
					{
						stringBuilder.Append(input[i]);
					}
				}
				else if (input[i] == '"')
				{
					flag = true;
				}
				else if (input[i] == ' ')
				{
					_argCache.Add(stringBuilder.ToString());
					stringBuilder.Clear();
				}
				else
				{
					stringBuilder.Append(input[i]);
				}
			}
			if (stringBuilder.Length > 0)
			{
				_argCache.Add(stringBuilder.ToString());
			}
			return _argCache.ToArray();
		}

		private void SetCursorPos(int pos)
		{
			InputFieldNoSelect mainInput = MainInput;
			int num = (MainInput.selectionFocusPosition = pos);
			int cSel = (mainInput.selectionAnchorPosition = num);
			_cPos = (_cSel = cSel);
		}

		private int GetCursorPos()
		{
			return MainInput.selectionAnchorPosition;
		}

		public static string ColorToHex(Color color)
		{
			string text = "0123456789ABCDEF";
			int num = (int)(color.r * 255f);
			int num2 = (int)(color.g * 255f);
			int num3 = (int)(color.b * 255f);
			return text[(int)Mathf.Floor(num / 16)].ToString() + text[(int)Mathf.Round(num % 16)] + text[(int)Mathf.Floor(num2 / 16)] + text[(int)Mathf.Round(num2 % 16)] + text[(int)Mathf.Floor(num3 / 16)] + text[(int)Mathf.Round(num3 % 16)];
		}

		public static int[] DotSearchBack(string input, int pos)
		{
			if (input.Length == 0)
			{
				return new int[2] { pos, -1 };
			}
			int[] array = new int[2]
			{
				pos,
				(input[pos] == '.') ? pos : (-1)
			};
			int num = 0;
			while (array[0] > 0)
			{
				array[0]--;
				char c = input[array[0]];
				if (c == ')' || c == ']')
				{
					num++;
				}
				else if (num > 0)
				{
					if (c == '(' || c == '[')
					{
						num--;
					}
				}
				else if (c == '.' && array[1] == -1)
				{
					array[1] = array[0];
				}
				else if (!char.IsDigit(c) && !char.IsLetter(c) && c != '.' && c != '$' && c != '_')
				{
					array[0]++;
					break;
				}
			}
			return array;
		}

		public static void Log(string text)
		{
			if (Singleton != null)
			{
				Singleton.BasePrint(text);
			}
		}

		public static void Log(object obj)
		{
			Log(obj.ToString());
		}

		public static void LogInfo(string text)
		{
			if (Singleton != null)
			{
				Singleton.BasePrint(text, Color.cyan);
			}
		}

		public static void LogInfo(object obj)
		{
			LogInfo(obj.ToString());
		}

		public static void LogWarning(string text)
		{
			if (Singleton != null)
			{
				Singleton.BasePrint(text, Color.yellow);
			}
		}

		public static void LogWarning(object obj)
		{
			LogWarning(obj.ToString());
		}

		public static void LogError(string text)
		{
			if (Singleton != null)
			{
				Singleton.BasePrint(text, Color.red);
				if (Options.ConsoleOnError && !isOpen)
				{
					Open();
				}
			}
		}

		public static void LogError(object obj)
		{
			LogError(obj.ToString());
		}

		public static void Log(string text, string color)
		{
			if (Singleton != null)
			{
				Singleton.BasePrint(text, color);
			}
		}

		public static void Log(object obj, string color)
		{
			Log(obj.ToString(), color);
		}

		public static void Log(string text, Color color)
		{
			if (Singleton != null)
			{
				Singleton.BasePrint(text, color);
			}
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
			BasePrintOnGUI(text, color);
		}

		private void BasePrintOnGUI(string text, string color)
		{
			text = "> " + text;
			string value = (showTimeStamp ? ("[" + DateTime.Now.ToShortTimeString() + "]  ") : string.Empty);
			StringBuilder stringBuilder = new StringBuilder(value);
			bool flag = false;
			int num = 0;
			int num2 = -40;
			float num3 = 0f;
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '<')
				{
					if (flag)
					{
						i += num + 1;
						flag = false;
						continue;
					}
					Match match = TagRegex.Match(text, i);
					if (match.Success)
					{
						string text2 = match.Groups[1].Value.ToLower();
						if (text2.StartsWith("color") || text2.StartsWith("size") || text2.Equals("b") || text2.Equals("i"))
						{
							num = match.Groups[2].Value.Length;
							flag = true;
							i += text2.Length + 1;
							continue;
						}
					}
				}
				if (text[i] == '\n')
				{
					stringBuilder.Clear();
					stringBuilder.Append(value);
					num2 = -40;
					num3 = 0f;
				}
				else
				{
					if (text[i] == ' ')
					{
						num2 = i;
					}
					stringBuilder.Append(text[i]);
					num3 += (float)MainText.GetCharWidth(text[i], 14, FontStyle.Normal);
				}
				if (num3 > (float)(Screen.width - 50))
				{
					if (num2 > 0 && i - num2 <= 32)
					{
						text = text.Insert(num2 + 1, "\n");
						i = num2;
					}
					else
					{
						text = text.Insert(i, "\n");
						i--;
					}
					num2 = -40;
				}
			}
			if (color == "000000")
			{
				ForceText(text);
			}
			else
			{
				AddText(text, color);
			}
		}

		private void AddText(string text, string color)
		{
			string[] array = text.SplitByNewLines();
			int num = Mathf.Max(0, array.Length - newConsoleText.Length);
			for (num = 0; num < array.Length; num++)
			{
				string text2 = array[num];
				if (num == 0 && showTimeStamp)
				{
					text2 = "[" + DateTime.Now.ToShortTimeString() + "]  " + text2;
				}
				if (color != "FFFFFF")
				{
					text2 = "<color=#" + color + ">" + text2 + "</color>";
				}
				newConsoleText[_consoleTextPos] = text2;
				_consoleTextPos = (_consoleTextPos + 1) % newConsoleText.Length;
				if (_consoleTextLength < newConsoleText.Length)
				{
					_consoleTextLength++;
				}
			}
			UpdateScrollbar();
			RefreshText();
		}

		private void ForceText(string text)
		{
			string[] array = text.SplitByNewLines();
			int num = Mathf.Max(0, array.Length - newConsoleText.Length);
			foreach (string text2 in array)
			{
				newConsoleText[_consoleTextPos] = text2;
				_consoleTextPos = (_consoleTextPos + 1) % newConsoleText.Length;
				if (_consoleTextLength < newConsoleText.Length)
				{
					_consoleTextLength++;
				}
			}
			RefreshText();
			UpdateScrollbar();
		}

		private void UpdateScrollbar()
		{
			if (!CanvasUpdateRegistry.IsRebuildingGraphics())
			{
				MainScroll.size = 1f / (float)Mathf.Max(1, _consoleTextLength - GetMaxLines());
				MainScroll.value = 1f;
			}
		}

		private void PrintInput(string input)
		{
			inputText = string.Empty;
			if ((history.Count == 0 || history[0] != input) && input.Trim() != string.Empty)
			{
				history.Remove(input);
				history.Insert(0, input);
				if (history.Count > 50)
				{
					history.RemoveAt(history.Count - 1);
				}
			}
			selectedHistory = 0;
			BasePrint(input);
			string[] array = input.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				ExecuteCommandInternal(array[i]);
			}
		}

		public static void SaveHistory()
		{
			if (Options.SaveConsole && Singleton != null)
			{
				try
				{
					File.WriteAllLines(Path.Combine(Utilities.GetRoot(), "ConsoleHistory.txt"), Singleton.history);
				}
				catch (Exception)
				{
				}
			}
		}

		private void OnDestroy()
		{
			if (Options.SaveConsole)
			{
				try
				{
					File.WriteAllLines(Path.Combine(Utilities.GetRoot(), "ConsoleHistory.txt"), history);
				}
				catch (Exception)
				{
				}
			}
		}

		private void LogCallback(string log, string stackTrace, LogType type)
		{
			if (type != LogType.Error && type != LogType.Exception && type != LogType.Assert)
			{
				return;
			}
			try
			{
				if (Time.realtimeSinceStartup - _lastEx < 1f)
				{
					_lastExCount++;
					if (_lastExCount >= 20)
					{
						Application.logMessageReceived -= LogCallback;
						Log("Disabled error logging in console due to spam");
					}
				}
				else
				{
					_lastExCount = 0;
				}
				_lastEx = Time.realtimeSinceStartup;
				BasePrint(log, Color.red);
				if (Options.ConsoleVerbose)
				{
					BasePrint(stackTrace, Color.red);
				}
				if (Options.ConsoleOnError && !isOpen)
				{
					Open();
				}
			}
			catch (Exception exception)
			{
				Application.logMessageReceived -= LogCallback;
				Debug.LogException(exception);
			}
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
			string text = command.ToUpper();
			int num = text.IndexOf(' ');
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			bool flag = false;
			if (text.Length > 0 && text[text.Length - 1] == '?')
			{
				flag = true;
				text = text.Substring(0, text.Length - 1);
			}
			for (int i = 0; i < consoleCommands.Count; i++)
			{
				if (!text.Equals(consoleCommands[i].name.ToUpper()))
				{
					continue;
				}
				if (!consoleCommands[i].CanExecuteOnline())
				{
					LogError("This command is not available for multiplayer");
					break;
				}
				if (flag)
				{
					consoleCommands[i].ShowHelp();
					break;
				}
				consoleCommands[i].Execute(command.Substring(consoleCommands[i].name.Length).Trim());
				if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.Instance.AchievementsDisabled)
				{
					GameSettings.Instance.DisableAllAchievements();
					LogWarning("Achievements have been disabled for this save");
				}
				break;
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
			if (!CommandExists(c.name) && Singleton != null)
			{
				Singleton.consoleCommands.Add(c);
			}
		}

		private static bool CommandExists(string commandName)
		{
			foreach (CommandBase consoleCommand in Singleton.consoleCommands)
			{
				if (consoleCommand.name.ToUpper() == commandName.ToUpper())
				{
					LogError("The command " + commandName + " already exists");
					return true;
				}
			}
			return false;
		}

		public static void RemoveCommand(string commandName)
		{
			foreach (CommandBase consoleCommand in Singleton.consoleCommands)
			{
				if (consoleCommand.name == commandName)
				{
					Singleton.consoleCommands.Remove(consoleCommand);
					Log("Command " + commandName + " removed successfully", Color.green);
					return;
				}
			}
			LogWarning("The command " + commandName + " could not be found");
		}

		private void HelpCommand(bool alpha)
		{
			StringBuilder stringBuilder = new StringBuilder("\n");
			IEnumerable<CommandBase> enumerable2;
			if (!alpha)
			{
				IEnumerable<CommandBase> enumerable = consoleCommands;
				enumerable2 = enumerable;
			}
			else
			{
				IEnumerable<CommandBase> enumerable = consoleCommands.OrderBy((CommandBase x) => x.name);
				enumerable2 = enumerable;
			}
			bool flag = true;
			foreach (CommandBase item in enumerable2)
			{
				if (!item.ShouldHide())
				{
					if (!flag)
					{
						stringBuilder.Append('\n');
					}
					flag = false;
					stringBuilder.Append("<color=#00FFFF>");
					stringBuilder.Append(item.name);
					stringBuilder.Append("</color>");
					if (item.helpText != null)
					{
						stringBuilder.Append(": ");
						stringBuilder.Append(item.helpText);
					}
				}
			}
			Log(stringBuilder.ToString());
		}

		public void Clear()
		{
			_consoleTextLength = 0;
			_consoleTextPos = 0;
			UpdateScrollbar();
			RefreshText();
		}

		public void ClearX(int lines)
		{
			lines = Mathf.Min(_consoleTextLength, lines);
			if (lines > 0)
			{
				_consoleTextLength = lines;
				UpdateScrollbar();
				RefreshText();
			}
		}

		private void ShowVerbose(bool show)
		{
			Options.SetAndSave("ConsoleVerbose", show);
			verbose = show;
		}

		private void ShowLog(bool value)
		{
			if (value)
			{
				Application.logMessageReceived += LogCallback;
			}
			else
			{
				Application.logMessageReceived -= LogCallback;
			}
			Log("Change successful", Color.green);
		}

		private void ShowTimeStamp(bool value)
		{
			showTimeStamp = value;
			Log("Change successful", Color.green);
		}

		private void SetFontSize(int size)
		{
			fontSize = size;
			Log("Change successful", Color.green);
		}

		public static string[] SplitString(string input)
		{
			int num = input.CountLetter('"');
			if (num % 2 == 1)
			{
				throw new ArgumentException("Uneven amount of quotations");
			}
			if (num == 0)
			{
				return input.Split(' ');
			}
			List<string> list = new List<string>();
			string[] array = input.Split(new char[1] { '"' }, StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (i % 2 == 1)
				{
					list.Add(text);
				}
				else if (!string.IsNullOrEmpty(text))
				{
					list.AddRange(text.Split(' '));
				}
			}
			return list.ToArray();
		}
	}
}
