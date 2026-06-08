using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleWindow3 : MonoBehaviour
{
	private const float TAP_MAXTIME = 0.07f;

	private const int MAX_HISTORY_LINES = 10;

	private const bool ENABLE_DOUBLE_SPACE_LOGIC = true;

	private const int COMMAND_TEXT_LIMIT = 100;

	private const float CURSOR_WIDTH = 8f;

	private const float CURSOR_HEIGHT = 20f;

	private const float CURSOR_BLINK_TIME = 0.5f;

	private const float AUTO_KEY_INITIAL_DELEY = 0.6f;

	private const float AUTO_KEY_PERIOD = 0.075f;

	private const int TOTAL_HACK_SCROLL_COUNT = 4;

	private const float SCROLL_DELAY = 0.05f;

	public static ConsoleWindow3 Instance = null;

	private bool _notProcessingSpaceThisUpdate;

	private bool _predictedTextShowingThisUpdate;

	public float BigSizeWidthMultiplier = 2f;

	public float BigSizeHeightMultiplier = 3.5f;

	public Color SpecialHeaderTextColor = Color.yellow;

	public Color CursorColor = Color.green;

	public Text minMaxButtonText;

	private string _commandText = string.Empty;

	private string activeCommandText = string.Empty;

	private string _lastCommandText = string.Empty;

	private List<ICommandable> _commandableObjects = new List<ICommandable>();

	private List<ConsoleMessage> _consoleWindowAllTextHistory = new List<ConsoleMessage>();

	private List<string> _commandHistory = new List<string>(500);

	private int _commandHistoryIndex = -1;

	private int _cursorPosition;

	private int commandCursorPosition;

	private Texture2D _cursorTexture;

	private float _cursorShowTimer;

	private bool _showCursor;

	private bool _isSmall = true;

	private bool _textChanged;

	private bool _firstUpdate = true;

	private bool _backspaceIsPressed;

	private bool _deleteIsPressed;

	private float _backspaceAutoTimer;

	private float _deleteAutoTimer;

	private bool _predictedTextVisible;

	private string _predictedCommandNameOnly = string.Empty;

	private int _countOfCommandMatches;

	private List<string> _commandMatches = new List<string>();

	private bool _predictedHelpTextVisible;

	private string _predictedHelpCommandNameOnly = string.Empty;

	private string _predictedHelpCommandEndOnly = string.Empty;

	private Text _consoleText;

	private Scrollbar _verticalScrollbar;

	private Scrollbar _horizontalScrollbar;

	private Image _cursor;

	private RectTransform _mainRectTransform;

	private Text _hiddenCommandLine;

	private Text _hiddenCurorPosText;

	private Text _predictionTextHidden;

	private RectTransform _hiddenPredictionRect;

	private RectTransform _predictionBackgroundRect;

	private Text _predictionText;

	private Text _cursorCharacter;

	private int _startFont;

	private Vector2 _smallSizeDelta;

	private Vector2 _bigSizeDelta;

	private float tapLengthTimer;

	private bool _processEnterKey;

	private Vector3 _initialWindowPosition;

	private bool isTrackingCommandCounts;

	private bool isWaitingForSVCommand;

	private int countCommandsAtSV;

	private int countCommandsTotal;

	private char[] sep_semi = new char[1] { ';' };

	private char[] sep_tab = new char[1] { '\t' };

	private char[] sep_tabspace = new char[2] { ' ', '\t' };

	private bool _shouldScrollToEnd;

	private float _scrollDelay;

	private int _scrollCounter;

	private bool _forceConsoleRefresh;

	private string currentFrameInputString = string.Empty;

	private StringBuilder finalConsoleText;

	private List<int> lineEndPositionList;

	private int lenCurrentLine;

	private string currentLineVal = string.Empty;

	private static char[] _validAlphaChars = new char[53]
	{
		'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
		'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
		'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
		'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
		'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
		'Y', 'Z', '?'
	};

	private static char[] _validNonAlphaChars = new char[26]
	{
		' ', '\t', '1', '2', '3', '4', '5', '6', '7', '8',
		'9', '0', '!', '@', '#', '$', '%', '^', '&', '*',
		'(', ')', '-', '_', '+', '='
	};

	private static char[] _validNonAlphaCharsNoSpace = new char[24]
	{
		'1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
		'!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
		'-', '_', '+', '='
	};

	private bool isInConfirmState;

	private string confirmCommandText = string.Empty;

	private List<CommandDefinition> allCommandsBucketList;

	public bool CommandBeingEntered
	{
		get
		{
			return _commandText.Length > 0;
		}
	}

	public bool IsDisabled { get; set; }

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	public bool NotProcessingSpace
	{
		get
		{
			return _notProcessingSpaceThisUpdate && ShouldNotProcessSpacePress();
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		Transform transform = base.transform.FindChild("TextMaskImage");
		if (transform != null)
		{
			transform = transform.FindChild("ConsoleText");
			if (transform != null)
			{
				_consoleText = transform.gameObject.GetComponent<Text>();
				if (_consoleText != null)
				{
					transform = _consoleText.transform.FindChild("HiddenCommandLine");
					if (transform != null)
					{
						_hiddenCommandLine = transform.gameObject.GetComponent<Text>();
						if (_hiddenCommandLine != null)
						{
							transform = _hiddenCommandLine.transform.FindChild("PredictionTextHidden");
							if (transform != null)
							{
								_predictionTextHidden = transform.gameObject.GetComponent<Text>();
								if (_predictionTextHidden != null)
								{
									_hiddenPredictionRect = _predictionTextHidden.gameObject.GetComponent<RectTransform>();
									transform = _predictionTextHidden.transform.FindChild("PredictionBackground");
									if (transform != null)
									{
										_predictionBackgroundRect = transform.gameObject.GetComponent<RectTransform>();
										transform = transform.FindChild("PredictionText");
										if (transform != null)
										{
											_predictionText = transform.gameObject.GetComponent<Text>();
										}
									}
								}
							}
						}
					}
					transform = _consoleText.transform.FindChild("HiddenCursorPosText");
					if (transform != null)
					{
						_hiddenCurorPosText = transform.gameObject.GetComponent<Text>();
						if (_hiddenCurorPosText != null)
						{
							transform = _hiddenCurorPosText.transform.FindChild("Cursor");
							if (transform != null)
							{
								_cursor = transform.gameObject.GetComponent<Image>();
								if (_cursor != null)
								{
									transform = _cursor.transform.FindChild("CursorCharacter");
									if (transform != null)
									{
										_cursorCharacter = transform.gameObject.GetComponent<Text>();
									}
								}
							}
						}
					}
				}
			}
		}
		transform = base.transform.FindChild("VertScrollbar");
		if (transform != null)
		{
			_verticalScrollbar = transform.gameObject.GetComponent<Scrollbar>();
		}
		transform = base.transform.FindChild("HorizScrollbar");
		if (transform != null)
		{
			_horizontalScrollbar = transform.gameObject.GetComponent<Scrollbar>();
		}
		_mainRectTransform = GetComponent<RectTransform>();
		_smallSizeDelta = _mainRectTransform.sizeDelta;
		_bigSizeDelta = new Vector2(_smallSizeDelta.x * BigSizeWidthMultiplier, _smallSizeDelta.y * BigSizeHeightMultiplier);
		_initialWindowPosition = _mainRectTransform.position;
		if (_consoleText == null || _verticalScrollbar == null || _cursor == null || _hiddenCurorPosText == null || _hiddenCommandLine == null || _horizontalScrollbar == null || _predictionText == null || _predictionTextHidden == null || _cursorCharacter == null)
		{
			Debug.LogError("Could not find all components of ConsoleWindow3");
		}
		_startFont = _consoleText.fontSize;
		_cursorShowTimer = 0.5f;
		isTrackingCommandCounts = !GameSaveFile.Get("HNT_SV_INPUT", false);
	}

	public void AddCommandableObject(ICommandable commandableObject)
	{
		_commandableObjects.Add(commandableObject);
		RegisterCommandableObject(commandableObject);
	}

	public void RemoveCommandableObject(ICommandable commandableObject)
	{
		if (_commandableObjects.Contains(commandableObject))
		{
			_commandableObjects.Remove(commandableObject);
		}
	}

	public void RegisterCommandableObject(ICommandable commandableObject)
	{
	}

	private void OnDestroy()
	{
		while (_commandableObjects.Count > 0)
		{
			RemoveCommandableObject(_commandableObjects[0]);
		}
	}

	private void PrivateSendConsoleMessage(string message, ConsoleMessageType messageType)
	{
		_consoleWindowAllTextHistory.Add(new ConsoleMessage(message, messageType));
		if (_consoleWindowAllTextHistory.Count > 50)
		{
			int num = _consoleWindowAllTextHistory.Count - 50;
			for (int i = 0; i < num; i++)
			{
				_consoleWindowAllTextHistory.RemoveAt(0);
				ClearFirstLine();
			}
		}
		InsertLineAtEnd();
		RefreshCurrentLine();
		ScrollToEnd();
	}

	public static void SendConsoleResponse(string message, ConsoleMessageType messageType)
	{
		if (Instance != null)
		{
			Instance.PrivateSendConsoleMessage(message, messageType);
		}
		else
		{
			Debug.LogWarning("ConsoleWindow3 not instantiated - " + message);
		}
	}

	private void ScrollToEnd()
	{
		_shouldScrollToEnd = true;
		_scrollDelay = 0.05f;
		_scrollCounter = 0;
	}

	private void ScrollToEndForReals()
	{
		_verticalScrollbar.value = 0f;
		_horizontalScrollbar.value = CalcEndScrollPosForCommandLine();
		if (++_scrollCounter < 4)
		{
			_scrollDelay = 0.05f;
			return;
		}
		_shouldScrollToEnd = false;
		_scrollDelay = 0f;
	}

	private float CalcEndScrollPosForCommandLine()
	{
		if (_cursorPosition < 30 && _horizontalScrollbar.value == 0f)
		{
			return 0f;
		}
		float num = _cursorPosition;
		foreach (ConsoleMessage item in _consoleWindowAllTextHistory)
		{
			if ((float)item.Message.Length > num)
			{
				num = item.Message.Length;
			}
		}
		return (float)_cursorPosition / num;
	}

	public void InjectCommandText(string commandText)
	{
		_commandText = commandText;
		AttemptExecuteCommand();
	}

	private void Update()
	{
		_predictedTextShowingThisUpdate = !string.IsNullOrEmpty(_predictedCommandNameOnly) || !string.IsNullOrEmpty(_predictedHelpCommandNameOnly);
		_notProcessingSpaceThisUpdate = ShouldNotProcessSpacePress();
		if (GlobalSettings.ShowingGameOverlayWindow)
		{
			return;
		}
		if (_processEnterKey)
		{
			_processEnterKey = false;
			AttemptExecuteCommand();
			_forceConsoleRefresh = true;
		}
		if (_scrollDelay > 0f)
		{
			_scrollDelay -= Time.deltaTime;
		}
		if (_shouldScrollToEnd && _scrollDelay <= 0f)
		{
			ScrollToEndForReals();
		}
		_cursorShowTimer -= Time.deltaTime;
		if (_cursorShowTimer <= 0f)
		{
			_cursorShowTimer = 0.5f;
			_showCursor = !_showCursor;
			_cursor.enabled = _showCursor;
			_cursorCharacter.enabled = _showCursor;
		}
		if (Input.GetKeyDown(KeyCode.F8))
		{
			ToggleWindowSize();
		}
		else if (Input.GetButtonDown("Up") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			if (_verticalScrollbar.value < 1f)
			{
				float num = 14f / (float)_consoleText.fontSize;
				_verticalScrollbar.value += 0.47f * num;
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
		}
		else if (Input.GetButtonDown("Down") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			if (_verticalScrollbar.value > 0f)
			{
				float num2 = 14f / (float)_consoleText.fontSize;
				_verticalScrollbar.value -= 0.47f * num2;
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
		}
		else if (Input.GetButtonDown("Left") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			if (_horizontalScrollbar.value > 0f)
			{
				float num3 = 14f / (float)_consoleText.fontSize;
				_horizontalScrollbar.value -= 0.47f * num3;
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
		}
		else if (Input.GetButtonDown("Right") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			if (_horizontalScrollbar.value < 1f)
			{
				float num4 = 14f / (float)_consoleText.fontSize;
				_horizontalScrollbar.value += 0.47f * num4;
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
		}
		else if (Input.GetKeyDown(KeyCode.PageUp))
		{
			if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				if (_verticalScrollbar.value < 1f)
				{
					float num5 = 14f / (float)_consoleText.fontSize;
					_verticalScrollbar.value += 0.47f * num5;
				}
				else
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
				}
			}
			else if (_horizontalScrollbar.value > 0f)
			{
				float num6 = 14f / (float)_consoleText.fontSize;
				_horizontalScrollbar.value -= 0.47f * num6;
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
		}
		else if (Input.GetKeyDown(KeyCode.PageDown))
		{
			if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				if (_verticalScrollbar.value > 0f)
				{
					float num7 = 14f / (float)_consoleText.fontSize;
					_verticalScrollbar.value -= 0.47f * num7;
				}
				else
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
				}
			}
			else if (_horizontalScrollbar.value < 1f)
			{
				float num8 = 14f / (float)_consoleText.fontSize;
				_horizontalScrollbar.value += 0.47f * num8;
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
		}
		if (CommonMethods.ControlKeyIsBeingPressed())
		{
			if (Input.GetKeyDown(KeyCode.PageUp) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				if (_consoleText.fontSize < 24)
				{
					AdjustFontSize(1);
					ConfigFile.SaveSetting("ConsoleFontSize", _consoleText.fontSize.ToString());
				}
				else
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
				}
			}
			else if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				if (_consoleText.fontSize > 8)
				{
					AdjustFontSize(-1);
					ConfigFile.SaveSetting("ConsoleFontSize", _consoleText.fontSize.ToString());
				}
				else
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
				}
			}
			else if (Input.GetKeyDown(KeyCode.Home))
			{
				SetFontSize(14);
				ConfigFile.SaveSetting("ConsoleFontSize", _startFont.ToString());
			}
			else if (Input.GetKeyDown(KeyCode.A))
			{
				_cursorPosition = 0;
				_forceConsoleRefresh = false;
				UpdateConsoleTextDisplay(false);
				_textChanged = true;
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				_cursorPosition = _commandText.Length;
				_forceConsoleRefresh = false;
				UpdateConsoleTextDisplay(false);
				ScrollToEnd();
				_textChanged = true;
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				if (_cursorPosition > 0)
				{
					_commandText = _commandText.Substring(_cursorPosition);
					_cursorPosition = 0;
					_forceConsoleRefresh = false;
					UpdateConsoleTextDisplay(false);
					_textChanged = true;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Backspace) && _cursorPosition > 0)
			{
				int num9 = 0;
				int num10 = 0;
				for (int num11 = _cursorPosition - 1; num11 >= 0; num11--)
				{
					num10++;
					if (_commandText[num11] == ' ')
					{
						num9 = num11;
						break;
					}
				}
				string text = string.Empty;
				if (num9 > 0)
				{
					text = _commandText.Substring(0, num9);
				}
				string text2 = _commandText.Substring(_cursorPosition);
				_commandText = text + text2;
				_cursorPosition -= num10;
				if (_cursorPosition > _commandText.Length)
				{
					_cursorPosition = _commandText.Length;
				}
				else if (_cursorPosition < 0)
				{
					_cursorPosition = 0;
				}
				_forceConsoleRefresh = false;
				UpdateConsoleTextDisplay(false);
				_textChanged = true;
			}
		}
		string commandText = _commandText;
		int count = _consoleWindowAllTextHistory.Count;
		int cursorPosition = _cursorPosition;
		CheckForArrowKeysCursorMove();
		if (!CheckForArrowKeysCommandHistoryCycle() && Input.anyKey)
		{
			currentFrameInputString = Input.inputString;
			CheckForAlphaKeyPress();
		}
		if (CommandBeingEntered)
		{
			if (Input.anyKey && !_predictedTextVisible)
			{
				if (currentFrameInputString == string.Empty)
				{
					currentFrameInputString = Input.inputString;
				}
				CheckForNonAlphaCharactersForPrompt();
			}
			CheckForSpecialCaseCharactersForPrompt();
			CheckForBackspaceOrDelete();
		}
		CheckForTextEntryStateChange();
		if (_commandText != commandText)
		{
			_forceConsoleRefresh = false;
			UpdateConsoleTextDisplay(false);
			ScrollToEnd();
			_textChanged = true;
		}
		else if (_forceConsoleRefresh || count != _consoleWindowAllTextHistory.Count)
		{
			_forceConsoleRefresh = false;
			ScrollToEnd();
		}
		else if (cursorPosition != _cursorPosition)
		{
			_forceConsoleRefresh = false;
			UpdateConsoleTextDisplay(false);
			ScrollToEnd();
		}
		if (_firstUpdate)
		{
			_firstUpdate = false;
			ResetConsoleText(false);
			Input.ResetInputAxes();
			int result;
			if (int.TryParse(ConfigFile.GetSetting("ConsoleFontSize"), out result))
			{
				SetFontSize(result);
			}
		}
		_predictionBackgroundRect.sizeDelta = _hiddenPredictionRect.sizeDelta;
	}

	public void SetFontSize(int size)
	{
		_consoleText.fontSize = size;
		_hiddenCurorPosText.fontSize = size;
		_cursorCharacter.fontSize = size;
		_hiddenCommandLine.fontSize = size;
		_predictionTextHidden.fontSize = size;
		_predictionText.fontSize = size;
		float num = (float)size / 14f;
		RectTransform rectTransform = _cursor.rectTransform;
		_cursorCharacter.transform.parent = null;
		rectTransform.localScale = new Vector3(num, num, 1f);
		_cursorCharacter.transform.parent = _cursor.transform;
	}

	private void AdjustFontSize(int delta)
	{
		_consoleText.fontSize += delta;
		_hiddenCurorPosText.fontSize += delta;
		_cursorCharacter.fontSize += delta;
		_hiddenCommandLine.fontSize += delta;
		_predictionTextHidden.fontSize += delta;
		_predictionText.fontSize += delta;
		float num = (float)_consoleText.fontSize / 14f;
		RectTransform rectTransform = _cursor.rectTransform;
		_cursorCharacter.transform.parent = null;
		rectTransform.localScale = new Vector3(num, num, 1f);
		_cursorCharacter.transform.parent = _cursor.transform;
	}

	private bool ShouldNotProcessSpacePress()
	{
		return !_predictedTextShowingThisUpdate && _commandText.Length > 0 && _cursorPosition >= _commandText.Length && _commandText[_commandText.Length - 1] == ' ';
	}

	private void UpdateConsoleTextDisplay(bool completeRefresh)
	{
		UpdateConsoleTextDisplay(completeRefresh, false);
	}

	private void UpdateConsoleTextDisplay(bool completeRefresh, bool ignoreCurrentLine)
	{
		try
		{
			while (_consoleWindowAllTextHistory.Count > 50)
			{
				_consoleWindowAllTextHistory.RemoveAt(0);
				ClearFirstLine();
			}
			if (finalConsoleText == null)
			{
				finalConsoleText = new StringBuilder(10000);
				lineEndPositionList = new List<int>(50);
			}
			else if (completeRefresh)
			{
				finalConsoleText.Remove(0, finalConsoleText.Length);
				lineEndPositionList.Clear();
			}
			if (completeRefresh)
			{
				int count = _consoleWindowAllTextHistory.Count;
				for (int i = 0; i < count; i++)
				{
					ConsoleMessage consoleMessage = _consoleWindowAllTextHistory[i];
					string empty = string.Empty;
					ConsoleMessageFormat format = consoleMessage.Format;
					if (format != ConsoleMessageFormat.SmallFont && format == ConsoleMessageFormat.HeaderFont)
					{
						empty = string.Format("<color=white>==={0}===</color>", consoleMessage.Message.ToUpper());
					}
					else
					{
						Color32 color = GetConsoleTextColor(consoleMessage.Type);
						string arg = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
						empty = string.Format("<color=#{0}>{1}</color>", arg, consoleMessage.Message);
					}
					finalConsoleText.AppendLine(empty);
					lineEndPositionList.Add(empty.Length);
				}
			}
			if (!ignoreCurrentLine)
			{
				RefreshCurrentLine();
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("Error updating console!!! " + ex.Message);
		}
	}

	private void InsertLineAtEnd()
	{
		if (finalConsoleText == null)
		{
			finalConsoleText = new StringBuilder(10000);
			lineEndPositionList = new List<int>(50);
		}
		int count = _consoleWindowAllTextHistory.Count;
		ConsoleMessage consoleMessage = _consoleWindowAllTextHistory[count - 1];
		string empty = string.Empty;
		ConsoleMessageFormat format = consoleMessage.Format;
		if (format != ConsoleMessageFormat.SmallFont && format == ConsoleMessageFormat.HeaderFont)
		{
			empty = string.Format("<color=white>==={0}===</color>", consoleMessage.Message.ToUpper());
		}
		else
		{
			Color32 color = GetConsoleTextColor(consoleMessage.Type);
			string arg = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
			empty = string.Format("<color=#{0}>{1}</color>", arg, consoleMessage.Message);
		}
		finalConsoleText.AppendLine(empty);
		lineEndPositionList.Add(empty.Length);
		FormatSpaces();
		_consoleText.text = finalConsoleText.ToString() + currentLineVal;
	}

	private void ClearFirstLine()
	{
		int num = -1;
		if (lineEndPositionList.Count > 0)
		{
			num = lineEndPositionList[0] + 1;
			lineEndPositionList.RemoveAt(0);
		}
		if (num > -1)
		{
			finalConsoleText.Remove(0, num + 1);
		}
	}

	private void InsertNewLine()
	{
		AddTextToConsole(new ConsoleMessage("> ", ConsoleMessageType.None));
	}

	private void RefreshCurrentLine()
	{
		string text = ((!string.IsNullOrEmpty(_predictedCommandNameOnly) || _countOfCommandMatches <= 0) ? "><color=#00000000>_</color>" : "*>");
		currentLineVal = text + _commandText;
		_hiddenCommandLine.text = text.Replace(' ', '_') + _commandText.Replace(' ', '_');
		string text2 = text.Replace(' ', '_');
		if (_cursorPosition <= _commandText.Length)
		{
			text2 += _commandText.Substring(0, _cursorPosition).Replace(' ', '_');
		}
		_hiddenCurorPosText.text = text2;
		_cursorCharacter.text = string.Empty;
		if (_cursorPosition < _commandText.Length)
		{
			_cursorCharacter.text = _commandText[_cursorPosition].ToString();
		}
		if (_predictedTextVisible && !string.IsNullOrEmpty(_predictedCommandNameOnly))
		{
			string text3 = string.Empty;
			if (activeCommandText.Length < _predictedCommandNameOnly.Length)
			{
				text3 = _predictedCommandNameOnly.Substring(activeCommandText.Length);
			}
			string text4 = string.Format("<color=#00000000>{0}</color>", text3);
			currentLineVal += text4;
			_predictionTextHidden.text = text3;
			_predictionText.text = text3;
			_predictionTextHidden.enabled = true;
			if (_cursorPosition >= _commandText.Length && text3.Length > 0)
			{
				_cursorCharacter.text = text3[0].ToString();
			}
		}
		else if (_predictedHelpTextVisible && !string.IsNullOrEmpty(_predictedHelpCommandNameOnly))
		{
			string text5 = string.Format("<color=#00000000>{0}</color>", _predictedHelpCommandEndOnly);
			currentLineVal += text5;
			_predictionTextHidden.text = _predictedHelpCommandEndOnly;
			_predictionText.text = _predictedHelpCommandEndOnly;
			_predictionTextHidden.enabled = true;
			if (_cursorPosition >= _commandText.Length && _predictedHelpCommandEndOnly.Length > 0)
			{
				_cursorCharacter.text = _predictedHelpCommandEndOnly[0].ToString();
			}
		}
		else
		{
			_predictionTextHidden.enabled = false;
			string text6 = "<color=#00000000>__</color>";
			currentLineVal += text6;
		}
		int length = currentLineVal.Length;
		int num = -1;
		int num2 = 0;
		for (int num3 = length - 1; num3 >= 0; num3--)
		{
			if (currentLineVal[num3] == ' ')
			{
				num = num3;
				num2++;
			}
			else if (num >= 0)
			{
				string text7 = string.Empty;
				for (int i = 0; i < num2; i++)
				{
					text7 += "_";
				}
				string value = "<color=#00000000>" + text7 + "</color>";
				currentLineVal.Remove(num, num2);
				currentLineVal.Insert(num, value);
				num = -1;
				num2 = 0;
			}
		}
		if (num >= 0)
		{
			string text8 = string.Empty;
			for (int j = 0; j < num2; j++)
			{
				text8 += "_";
			}
			string value2 = "<color=#00000000>" + text8 + "</color>";
			currentLineVal.Remove(num, num2);
			currentLineVal.Insert(num, value2);
			num = -1;
			num2 = 0;
		}
		_consoleText.text = finalConsoleText.ToString() + currentLineVal;
	}

	private void FormatSpaces()
	{
		int length = finalConsoleText.Length;
		int num = -1;
		int num2 = 0;
		for (int num3 = length - 1; num3 >= 0; num3--)
		{
			if (finalConsoleText[num3] == ' ')
			{
				num = num3;
				num2++;
			}
			else if (num >= 0)
			{
				string text = string.Empty;
				for (int i = 0; i < num2; i++)
				{
					text += "_";
				}
				string text2 = "<color=#00000000>" + text + "</color>";
				finalConsoleText.Remove(num, num2);
				finalConsoleText.Insert(num, text2);
				List<int> list2;
				List<int> list = (list2 = lineEndPositionList);
				int index2;
				int index = (index2 = lineEndPositionList.Count - 1);
				index2 = list2[index2];
				list[index] = index2 + (text2.Length - num2);
				num = -1;
				num2 = 0;
			}
		}
		if (num >= 0)
		{
			string text3 = string.Empty;
			for (int j = 0; j < num2; j++)
			{
				text3 += "_";
			}
			string text4 = "<color=#00000000>" + text3 + "</color>";
			finalConsoleText.Insert(num, text4);
			List<int> list4;
			List<int> list3 = (list4 = lineEndPositionList);
			int index2;
			int index3 = (index2 = lineEndPositionList.Count - 1);
			index2 = list4[index2];
			list3[index3] = index2 + (text4.Length - num2);
			num = -1;
			num2 = 0;
		}
	}

	private Color GetConsoleTextColor(ConsoleMessageType messagetype)
	{
		Color result = _consoleText.color;
		switch (messagetype)
		{
		case ConsoleMessageType.Info:
			result = new Color(0.75f, 0.75f, 0.75f);
			break;
		case ConsoleMessageType.SpecialInfo:
			result = SpecialHeaderTextColor;
			break;
		case ConsoleMessageType.TriggerActivatedWarning:
		case ConsoleMessageType.TriggerDeactivatedWarning:
			result = GlobalSettings.Constants.ORANGE;
			break;
		case ConsoleMessageType.Warning:
		case ConsoleMessageType.DisasterWarning:
		case ConsoleMessageType.UpgradeStateChange:
			result = Color.yellow;
			break;
		case ConsoleMessageType.Error:
			result = Color.red;
			break;
		case ConsoleMessageType.Healthy:
			result = Color.white;
			break;
		case ConsoleMessageType.Notification:
			result = new Color(0.5f, 1f, 0.5f);
			break;
		case ConsoleMessageType.Benefit:
			result = Color.blue;
			result.r = 0.5f;
			result.g = 0.5f;
			break;
		case ConsoleMessageType.JIL_Good:
			result = Color.white;
			result.r = 0.384f;
			result.g = 0.867f;
			result.b = 0.976f;
			break;
		case ConsoleMessageType.JIL_Warning:
			result = Color.yellow;
			break;
		case ConsoleMessageType.JIL_Error:
			result = Color.red;
			break;
		case ConsoleMessageType.JIL_Info:
			result = Color.white;
			break;
		}
		return result;
	}

	public void SetWindowPositionSmall()
	{
		_isSmall = true;
		_mainRectTransform.sizeDelta = _smallSizeDelta;
		ScrollToEnd();
		minMaxButtonText.text = "max";
	}

	public void SetWindowPositionLarge()
	{
		_isSmall = false;
		_mainRectTransform.sizeDelta = _bigSizeDelta;
		ScrollToEnd();
		minMaxButtonText.text = "min";
	}

	public void ToggleWindowSize()
	{
		if (_isSmall)
		{
			SetWindowPositionLarge();
		}
		else
		{
			SetWindowPositionSmall();
		}
	}

	private void CheckForArrowKeysCursorMove()
	{
		bool flag = Input.GetButtonDown("Left") && CommonMethods.ControlKeyIsBeingPressed();
		bool flag2 = Input.GetButtonDown("Right") && CommonMethods.ControlKeyIsBeingPressed();
		if (flag && !flag2)
		{
			if (_cursorPosition > 0)
			{
				_cursorPosition--;
			}
		}
		else if (!flag && flag2 && _cursorPosition < _commandText.Length)
		{
			_cursorPosition++;
		}
	}

	private bool CheckForArrowKeysCommandHistoryCycle()
	{
		if (IsDisabled)
		{
			return false;
		}
		bool flag = Input.GetButtonDown("Up") && CommonMethods.ControlKeyIsBeingPressed();
		bool flag2 = Input.GetButtonDown("Down") && CommonMethods.ControlKeyIsBeingPressed();
		bool flag3 = Input.GetKeyDown(KeyCode.C) && CommonMethods.ControlKeyIsBeingPressed();
		if (flag2)
		{
			if (_commandHistory.Count > 0)
			{
				if (_commandHistoryIndex == -1 && _commandText.Length > 0)
				{
					ClearCommandInput(false);
				}
				else if (_commandHistoryIndex < _commandHistory.Count - 1)
				{
					_commandHistoryIndex++;
					if (_commandHistoryIndex < 0 || _commandHistoryIndex >= _commandHistory.Count)
					{
						_commandHistoryIndex = 0;
					}
					_commandText = _commandHistory[_commandHistoryIndex];
					activeCommandText = _commandText;
					_cursorPosition = _commandText.Length;
				}
				else
				{
					ClearCommandInput(false);
				}
			}
			else
			{
				ClearCommandInput(false);
			}
		}
		else if (flag3)
		{
			ClearCommandInput(true);
		}
		else if (flag && _commandHistory.Count > 0)
		{
			_commandHistoryIndex--;
			if (_commandHistoryIndex < 0 || _commandHistoryIndex >= _commandHistory.Count)
			{
				_commandHistoryIndex = _commandHistory.Count - 1;
			}
			_commandText = _commandHistory[_commandHistoryIndex];
			activeCommandText = _commandText;
			_cursorPosition = _commandText.Length;
		}
		return flag || flag2;
	}

	private void ClearCommandInput(bool clearKey)
	{
		if (clearKey && _commandText.Length > 0)
		{
			Input.ResetInputAxes();
		}
		ResetConsoleText(true);
		ClearTextPredictionState();
	}

	private void CheckForSpecificKeyPress(char[] validChars)
	{
		if (!Input.anyKey || currentFrameInputString.Length <= 0)
		{
			return;
		}
		bool flag = false;
		string text = currentFrameInputString;
		int num = validChars.Length;
		int length = currentFrameInputString.Length;
		for (int i = 0; i < length; i++)
		{
			char c = currentFrameInputString[i];
			for (int j = 0; j < num; j++)
			{
				if (validChars[j] == c)
				{
					flag = true;
					text = c.ToString();
					break;
				}
			}
		}
		if (flag)
		{
			if (_cursorPosition >= _commandText.Length)
			{
				_commandText += text;
			}
			else
			{
				_commandText = _commandText.Insert(_cursorPosition, text);
			}
			_cursorPosition++;
			if (_commandText.Length > 100)
			{
				_cursorPosition = 100;
				_commandText = _commandText.Substring(0, 100);
			}
			activeCommandText = _commandText;
		}
	}

	private bool AnyLowMem(char[] chrArray, char chr)
	{
		int num = chrArray.Length;
		for (int i = 0; i < num; i++)
		{
			if (chrArray[i] == chr)
			{
				return true;
			}
		}
		return false;
	}

	private void CheckForAlphaKeyPress()
	{
		if (!IsDisabled)
		{
			CheckForSpecificKeyPress(_validAlphaChars);
		}
	}

	private void CheckForNonAlphaCharactersForPrompt()
	{
		if (!IsDisabled)
		{
			if (!NotProcessingSpace)
			{
				CheckForSpecificKeyPress(_validNonAlphaChars);
			}
			else
			{
				CheckForSpecificKeyPress(_validNonAlphaCharsNoSpace);
			}
		}
	}

	private void CheckForSpecialCaseCharactersForPrompt()
	{
		if (IsDisabled)
		{
			return;
		}
		string text = string.Empty;
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			text += " ";
		}
		if (text.Length > 0)
		{
			if (_cursorPosition >= text.Length)
			{
				_commandText += text;
			}
			else
			{
				_commandText = _commandText.Insert(_cursorPosition, text);
			}
			_cursorPosition += text.Length;
			if (_commandText.Length > 100)
			{
				_cursorPosition = 100;
				_commandText = _commandText.Substring(0, 100);
			}
			activeCommandText = _commandText;
		}
	}

	private void CheckForBackspaceOrDelete()
	{
		if (IsDisabled)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		if (Input.GetKey(KeyCode.Backspace) && !CommonMethods.ControlKeyIsBeingPressed())
		{
			if (!_backspaceIsPressed)
			{
				_backspaceAutoTimer = 0f;
				_backspaceIsPressed = true;
				flag = true;
			}
		}
		else
		{
			_backspaceIsPressed = false;
		}
		if (Input.GetKey(KeyCode.Delete))
		{
			if (!_deleteIsPressed)
			{
				_deleteAutoTimer = 0f;
				_deleteIsPressed = true;
				flag2 = true;
			}
		}
		else
		{
			_deleteIsPressed = false;
		}
		if (_backspaceIsPressed)
		{
			_backspaceAutoTimer -= Time.deltaTime;
			if (_backspaceAutoTimer <= 0f && _commandText.Length > 0 && _cursorPosition > 0)
			{
				_commandText = _commandText.Remove(_cursorPosition - 1, 1);
				activeCommandText = _commandText;
				_cursorPosition--;
				if (flag)
				{
					_backspaceAutoTimer = 0.6f;
				}
				else
				{
					_backspaceAutoTimer = 0.075f;
				}
			}
		}
		if (!_deleteIsPressed)
		{
			return;
		}
		_deleteAutoTimer -= Time.deltaTime;
		if (_deleteAutoTimer <= 0f && _commandText.Length > 0 && _cursorPosition < _commandText.Length)
		{
			_commandText = _commandText.Remove(_cursorPosition, 1);
			activeCommandText = _commandText;
			if (flag2)
			{
				_deleteAutoTimer = 0.6f;
			}
			else
			{
				_deleteAutoTimer = 0.075f;
			}
		}
	}

	public void ResetConsoleText(bool ignoreConsoleUpdate)
	{
		_commandText = string.Empty;
		activeCommandText = _commandText;
		_cursorPosition = 0;
		_commandHistoryIndex = -1;
		if (!ignoreConsoleUpdate)
		{
			UpdateConsoleTextDisplay(false);
		}
	}

	private void ClearTextPredictionState()
	{
		_predictedTextVisible = false;
		_predictedCommandNameOnly = string.Empty;
		_lastCommandText = activeCommandText;
		_countOfCommandMatches = 0;
		commandCursorPosition = 0;
		CommandTree.ResetQueuedMatch();
		_predictedHelpTextVisible = false;
		_predictedHelpCommandNameOnly = string.Empty;
		_predictedHelpCommandEndOnly = string.Empty;
	}

	private void CheckForTextEntryStateChange()
	{
		if (IsDisabled)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		if (Input.anyKeyDown)
		{
			flag = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
			flag2 = Input.GetKeyDown(KeyCode.Escape);
			flag3 = Input.GetKeyDown(KeyCode.Space);
			flag4 = Input.GetKeyDown(KeyCode.Tab);
			flag5 = Input.GetButtonDown("Semicolon");
		}
		if (flag)
		{
			_processEnterKey = true;
		}
		if (flag2)
		{
			ClearCommandInput(true);
		}
		else if (_predictedTextVisible && (flag3 || flag4 || flag5))
		{
			bool flag6 = false;
			int length = _commandText.Length;
			for (int i = 0; i < length; i++)
			{
				if (_commandText[i] != ' ' && _commandText[i] != '\t')
				{
					flag6 = true;
					break;
				}
			}
			if (flag6)
			{
				if (_cursorPosition > 0 && (_commandText[_cursorPosition - 1] == ' ' || _commandText[_cursorPosition - 1] == '\t'))
				{
					if (_cursorPosition == _commandText.Length)
					{
						_commandText = _commandText.TrimEnd(sep_tabspace);
					}
					_cursorPosition--;
				}
				int num = _predictedCommandNameOnly.Length - (_cursorPosition - commandCursorPosition);
				string text = _predictedCommandNameOnly.Substring(_predictedCommandNameOnly.Length - num);
				text += " ";
				if (flag5)
				{
					text += ";";
				}
				_commandText = _commandText.Insert(_cursorPosition, text);
				_cursorPosition = _commandText.Length;
				ClearTextPredictionState();
			}
			activeCommandText = _commandText;
		}
		else if (_predictedHelpTextVisible && (flag3 || flag4 || flag5))
		{
			if (_commandText.Length >= 4 && (_commandText[0] == 'h' || _commandText[0] == 'H') && _commandText.ToLower().StartsWith("help"))
			{
				_commandText = _commandText.Substring(0, 5) + _predictedHelpCommandNameOnly;
			}
			else if (_commandText.StartsWith("?"))
			{
				_commandText = _commandText.Substring(0, 2) + _predictedHelpCommandNameOnly;
			}
			_cursorPosition = _commandText.Length;
			ClearTextPredictionState();
			activeCommandText = _commandText;
		}
		else if (flag5 && !string.IsNullOrEmpty(_commandText))
		{
			_commandText = _commandText.Insert(_cursorPosition, ";");
			activeCommandText = _commandText;
			_cursorPosition = _commandText.Length;
			ClearTextPredictionState();
		}
		else
		{
			if (!(_lastCommandText != activeCommandText))
			{
				return;
			}
			if (!_predictedCommandNameOnly.StartsWith(_commandText))
			{
				commandCursorPosition = 0;
				ClearTextPredictionState();
				string text2 = _commandText;
				commandCursorPosition = _commandText.LastIndexOf(';') + 1;
				if (commandCursorPosition > 0)
				{
					int length2 = _commandText.Length;
					for (int num2 = length2 - 1; num2 >= 0; num2--)
					{
						if (_commandText[num2] == ';')
						{
							text2 = _commandText.Substring(num2 + 1);
							break;
						}
					}
					while (commandCursorPosition < _commandText.Length && _commandText[commandCursorPosition] == ' ')
					{
						commandCursorPosition++;
					}
				}
				if (text2.Length > 0)
				{
					activeCommandText = text2;
					activeCommandText = activeCommandText.TrimStart();
					string text3 = activeCommandText;
					int length3 = activeCommandText.Length;
					for (int num3 = length3 - 1; num3 >= 0; num3--)
					{
						if (activeCommandText[num3] == ' ' || activeCommandText[num3] == '\t')
						{
							text3 = activeCommandText.Substring(num3);
							break;
						}
					}
					if (text3.Length > 0 && _cursorPosition <= commandCursorPosition + text3.Length)
					{
						string uniqueFullCommandTextFromAllObjects = GetUniqueFullCommandTextFromAllObjects(text2, _commandMatches, false, out _countOfCommandMatches);
						if (!string.IsNullOrEmpty(uniqueFullCommandTextFromAllObjects))
						{
							_predictedTextVisible = true;
							_lastCommandText = activeCommandText;
							_predictedCommandNameOnly = uniqueFullCommandTextFromAllObjects;
						}
					}
					if ((_predictedTextVisible || _countOfCommandMatches != 0) && CommandTree.HasMatch)
					{
						CommandTree.ResetQueuedMatch();
					}
				}
			}
			else if (string.IsNullOrEmpty(_commandText))
			{
				ClearTextPredictionState();
			}
			if ((_commandText.Length > 4 && (_commandText[0] == 'h' || _commandText[0] == 'H') && _commandText.ToLower().StartsWith("help")) || (_commandText.Length > 1 && _commandText.StartsWith("?")))
			{
				AttemptPredictedCommandForHelpCommand(_commandText);
			}
		}
	}

	private void AttemptPredictedCommandForHelpCommand(string rawCommand)
	{
		_predictedHelpTextVisible = false;
		_predictedHelpCommandNameOnly = string.Empty;
		_predictedHelpCommandEndOnly = string.Empty;
		string text = ((!rawCommand.ToLower().StartsWith("help")) ? rawCommand.Substring(1) : rawCommand.Substring(4));
		string[] array = text.Split(sep_tabspace, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length != 0)
		{
			text = array.First();
			int countOfAllMatches;
			string uniqueFullCommandTextFromAllObjects = GetUniqueFullCommandTextFromAllObjects(text, true, out countOfAllMatches);
			if (!string.IsNullOrEmpty(uniqueFullCommandTextFromAllObjects))
			{
				_predictedHelpTextVisible = true;
				_predictedHelpCommandNameOnly = uniqueFullCommandTextFromAllObjects;
				_predictedHelpCommandEndOnly = uniqueFullCommandTextFromAllObjects.Substring(text.Length, uniqueFullCommandTextFromAllObjects.Length - text.Length);
			}
		}
	}

	private void AttemptExecuteCommand()
	{
		bool flag = false;
		if (_commandText.Length > 0)
		{
			string text = _commandText;
			if (!string.IsNullOrEmpty(_predictedCommandNameOnly))
			{
				text = _predictedCommandNameOnly;
			}
			else if (!string.IsNullOrEmpty(_predictedHelpCommandNameOnly))
			{
				if (_commandText.ToLower().StartsWith("help"))
				{
					_commandText = _commandText.Substring(0, 5) + _predictedHelpCommandNameOnly;
				}
				else if (_commandText.StartsWith("?"))
				{
					_commandText = _commandText.Substring(0, 2) + _predictedHelpCommandNameOnly;
				}
				text = _commandText;
			}
			AddTextToConsole(new ConsoleMessage("> " + text, ConsoleMessageType.None));
			AddCommandToHistory(text);
			string[] array = _commandText.Split(sep_semi, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder stringBuilder = new StringBuilder();
			bool flag2 = _commandText[_commandText.Length - 1] == ';';
			_commandText = string.Empty;
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string updatedCommand = array[i];
				if (updatedCommand[0] == ' ' || updatedCommand[updatedCommand.Length - 1] == ' ')
				{
					updatedCommand = updatedCommand.Trim();
				}
				string empty = string.Empty;
				bool flag3 = i == num - 1;
				empty = ((!flag3 || string.IsNullOrEmpty(_predictedCommandNameOnly)) ? updatedCommand : _predictedCommandNameOnly);
				flag = AttemptProcessWithCommandTree(empty, out updatedCommand);
				if (flag3 && (flag || !string.IsNullOrEmpty(updatedCommand)))
				{
					_predictedCommandNameOnly = string.Empty;
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(updatedCommand);
			}
			if (flag2)
			{
				stringBuilder.Append(";");
			}
			_commandText = stringBuilder.ToString();
			if (!flag)
			{
				bool flag4 = false;
				int length = _commandText.Length;
				for (int j = 0; j < length; j++)
				{
					if (_commandText[j] == ';')
					{
						flag4 = true;
						break;
					}
				}
				if (flag4)
				{
					bool flag5 = false;
					string[] array2 = _commandText.Split(sep_semi, StringSplitOptions.RemoveEmptyEntries);
					string[] array3 = array2;
					foreach (string text2 in array3)
					{
						string text3 = text2;
						if (text3[0] == ' ' || text3[text3.Length - 1] == ' ')
						{
							text3 = text3.Trim();
						}
						if (string.IsNullOrEmpty(text3))
						{
							continue;
						}
						bool flag6 = false;
						if (GlobalSettings.UseCommandTree && AttemptProcessWithCommandTree(text3))
						{
							flag6 = true;
						}
						if (!flag6)
						{
							bool commandQueued = false;
							if (ProcessCommandText(text3, true, out commandQueued))
							{
								flag5 = true;
							}
						}
					}
					flag = flag5;
				}
				else
				{
					string text4 = (string.IsNullOrEmpty(_predictedCommandNameOnly) ? _commandText : _predictedCommandNameOnly);
					bool flag7 = false;
					if (GlobalSettings.UseCommandTree)
					{
						flag = AttemptProcessWithCommandTree(text4);
						if (flag)
						{
							flag7 = true;
						}
					}
					if (!flag7)
					{
						bool commandQueued2 = false;
						flag = ProcessCommandText(text4, false, out commandQueued2);
					}
				}
			}
		}
		else
		{
			InsertNewLine();
			RefreshCurrentLine();
		}
		ScrollToEnd();
		if (!flag)
		{
			return;
		}
		ResetConsoleText(false);
		ClearTextPredictionState();
		RefreshCurrentLine();
		if (isTrackingCommandCounts)
		{
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				countCommandsAtSV++;
			}
			countCommandsTotal++;
			if (countCommandsTotal < 15)
			{
				return;
			}
			if (countCommandsAtSV <= 3)
			{
				if (GameSaveFile.Get("HNT_SV_INPUT_CT", 0) < 5)
				{
					HintManager.PushHint(new UseSchematicHint());
					GameSaveFile.Save("HNT_SV_INPUT_CT", GameSaveFile.Get("HNT_SV_INPUT_CT", 0) + 1);
					isWaitingForSVCommand = true;
				}
				else if (!GameSaveFile.Get("HNT_SV_INPUT", false))
				{
					GameSaveFile.Save("HNT_SV_INPUT", true);
				}
			}
			isTrackingCommandCounts = false;
		}
		else if (isWaitingForSVCommand && GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			HintManager.HintCompleted(typeof(UseSchematicHint));
			isWaitingForSVCommand = false;
		}
	}

	private bool AttemptProcessWithCommandTree(string rawCommand)
	{
		string updatedCommand = string.Empty;
		return AttemptProcessWithCommandTree(rawCommand, out updatedCommand);
	}

	private bool AttemptProcessWithCommandTree(string rawCommand, out string updatedCommand)
	{
		updatedCommand = rawCommand;
		bool exactMatch = false;
		CommandNode foundNode = null;
		string[] array = rawCommand.Split(sep_tabspace, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length > 0 && CommandTree.FindBestMatch(array[0], out exactMatch, out foundNode) && exactMatch)
		{
			switch (foundNode.CommandType)
			{
			case CommandTypeEnum.AliasCommand:
			{
				updatedCommand = foundNode.Data.ToString();
				List<string> list = null;
				bool flag = true;
				do
				{
					flag = false;
					if (!updatedCommand.Contains(";"))
					{
						continue;
					}
					if (list == null)
					{
						list = new List<string>();
					}
					string[] array2 = updatedCommand.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
					int num = array2.Length;
					for (int i = 0; i < num; i++)
					{
						CommandNode foundNode2 = null;
						string text = array2[i].Trim();
						if (!list.Contains(text))
						{
							if (CommandTree.FindBestMatch(text, out exactMatch, out foundNode2) && exactMatch)
							{
								updatedCommand = updatedCommand.Replace(text, foundNode2.Data.ToString());
								flag = true;
							}
							list.Add(text);
						}
					}
				}
				while (flag);
				if (array.Length > 1 && updatedCommand.Contains("$"))
				{
					int num2 = array.Length;
					for (int j = 1; j < num2; j++)
					{
						string text2 = array[j];
						string text3 = text2[0].ToString().ToLower();
						string value = string.Empty;
						switch (text3)
						{
						default:
						{
							int num3;
							if (num3 == 1)
							{
								value = "$r";
								break;
							}
							int result = 0;
							if (int.TryParse(text3, out result))
							{
								value = "$x";
							}
							else
							{
								Debug.LogWarning(string.Format("Unknown argument type provided: {0}", text3));
							}
							break;
						}
						case "d":
						case "a":
							value = "$d";
							break;
						}
						if (!string.IsNullOrEmpty(value) && updatedCommand.Contains(value))
						{
							int num4 = updatedCommand.IndexOf(value);
							int num5 = updatedCommand.IndexOf(' ', num4 + 1);
							if (num5 < 0 || (updatedCommand.IndexOf(';', num4 + 1) > -1 && updatedCommand.IndexOf(';', num4 + 1) < num5))
							{
								num5 = updatedCommand.IndexOf(';', num4 + 1);
							}
							if (num5 < 0 || (updatedCommand.IndexOf('(', num4 + 1) > -1 && updatedCommand.IndexOf('(', num4 + 1) < num5))
							{
								num5 = updatedCommand.IndexOf('(', num4 + 1);
							}
							if (num5 < 0)
							{
								num5 = updatedCommand.Length;
							}
							string text4 = updatedCommand.Substring(num4, num5 - num4);
							text4 = text4.Replace("(", string.Empty);
							text4 = text4.Replace(")", string.Empty);
							updatedCommand = updatedCommand.Replace("(" + text4 + ")", array[j]);
							updatedCommand = updatedCommand.Replace(text4, array[j]);
						}
					}
					if (updatedCommand.Contains('$'))
					{
						int num6 = 0;
						do
						{
							num6 = updatedCommand.IndexOf("($");
							if (num6 > 0)
							{
								int num7 = updatedCommand.IndexOf(")", num6);
								if (num7 < 0)
								{
									num7 = updatedCommand.Length - 1;
								}
								num7++;
								string oldValue = updatedCommand.Substring(num6, num7 - num6);
								updatedCommand = updatedCommand.Replace(oldValue, string.Empty);
							}
						}
						while (num6 > 0);
						if (updatedCommand.Contains('$'))
						{
							Debug.LogError(string.Format("There's still a parameter in the alias command.  Shouldn't be possible.  Current command value: {0}", updatedCommand));
						}
					}
				}
				return false;
			}
			case CommandTypeEnum.ObjectCommand:
			{
				bool commandQueued2 = false;
				return ProcessCommandText((ICommandable)foundNode.Data, foundNode, rawCommand, false, out commandQueued2);
			}
			case CommandTypeEnum.MultiObjectCommand:
			{
				bool commandQueued = false;
				return ProcessCommandText((ICommandable)foundNode.FirstData, foundNode, rawCommand, false, out commandQueued);
			}
			}
		}
		return false;
	}

	private void AddCommandToHistory(string commandText)
	{
		if (commandText[0] == 't' && commandText.StartsWith("toggle "))
		{
			commandText = commandText.Substring(7);
		}
		if (_commandHistory.Contains(commandText))
		{
			_commandHistory.Remove(commandText);
		}
		_commandHistory.Add(commandText);
	}

	private bool ProcessCommandText(string commandText, bool partOfMultiCommand, out bool commandQueued)
	{
		commandQueued = false;
		if (GlobalSettings.GameIsOver)
		{
			return true;
		}
		List<ExecutedCommand> list = new List<ExecutedCommand>();
		string[] array = commandText.Split(sep_tabspace, StringSplitOptions.RemoveEmptyEntries);
		string text = commandText;
		List<string> list2 = null;
		List<int> list3 = null;
		if (array.Length > 0)
		{
			List<string> list4 = new List<string>();
			if (CheckForSpecialCaseCommand(array))
			{
				return true;
			}
			text = array[0];
			list2 = new List<string>();
			list3 = new List<int>();
			for (int i = 1; i < array.Length; i++)
			{
				int result;
				if (int.TryParse(array[i], out result))
				{
					list3.Add(result);
					continue;
				}
				result = -1;
				if (array[i].Length >= 2)
				{
					string actualName = string.Empty;
					result = DroneManager.Instance.GetDroneNumberFromName(array[i], out actualName);
					if (result != -1)
					{
						_commandHistory[_commandHistory.Count - 1] = _commandHistory.Last().Replace(array[i], actualName);
					}
				}
				if (result == -1)
				{
					list2.Add(array[i]);
				}
				else
				{
					list3.Add(result);
				}
			}
			int count = _commandableObjects.Count;
			for (int j = 0; j < count; j++)
			{
				ICommandable commandable = _commandableObjects[j];
				List<CommandDefinition> list5 = commandable.QueryAvailableCommands();
				int countOfAllMatches;
				string uniqueFullCommand = GetUniqueFullCommand(text, list5, true, false, out countOfAllMatches);
				if (list4.Contains(uniqueFullCommand))
				{
					continue;
				}
				int count2 = list5.Count;
				for (int k = 0; k < count2; k++)
				{
					CommandDefinition commandDefinition = list5[k];
					if ((GlobalSettings.cheatMode || !commandDefinition.DeveloperCommand) && !commandDefinition.IsHelpOnly && uniqueFullCommand == commandDefinition.CommandName)
					{
						list4.Add(uniqueFullCommand);
						list.Add(new ExecutedCommand(commandDefinition, list2, list3, commandText));
					}
				}
			}
		}
		bool flag = false;
		string empty = string.Empty;
		int count3 = list.Count;
		if (count3 > 0)
		{
			empty = list[0].Command.CommandName;
			if (count3 > 1)
			{
				bool flag2 = false;
				for (int l = 1; l < count3; l++)
				{
					if (list[l].Command.CommandName != empty)
					{
						flag2 = true;
						break;
					}
				}
				flag = !flag2;
			}
			else
			{
				flag = true;
			}
		}
		if (!flag && _countOfCommandMatches <= 1)
		{
			switch (text)
			{
			case "power":
			case "remote":
			case "transport":
			case "reroute":
			{
				bool flag3 = text == "power" || text == "remote";
				bool flag4 = !flag3 && text == "transport";
				bool flag5 = !flag3 && !flag4 && text == "reroute";
				if (GlobalSettings.GameState.ThePlayer.MyShip == null)
				{
					break;
				}
				List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
				int count4 = itemsCopy.Count;
				for (int m = 0; m < count4; m++)
				{
					BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)itemsCopy[m];
					if ((!flag3 || !(baseShipUpgrade.CommandValue == "remote")) && (!flag4 || !(baseShipUpgrade.CommandValue == "transport")) && (!flag5 || !(baseShipUpgrade.CommandValue == "reroute")))
					{
						continue;
					}
					list.Clear();
					if (list2 == null)
					{
						list2 = new List<string>();
					}
					if (list3 == null)
					{
						list3 = new List<int>();
					}
					List<CommandDefinition> list6 = baseShipUpgrade.QueryAvailableCommands();
					if (list6.Count > 0)
					{
						list.Add(new ExecutedCommand(list6[0], list2, list3, commandText));
						flag = true;
						Debug.LogError("Manually set command for ship upgrade ('" + baseShipUpgrade.Name + "'), though the command line code insisted there was nothing to process the command.");
						if (GameSaveFile.Get("O_DBG", false))
						{
							SystemMessageManager.ShowSystemMessage("Msg From Dev to Player: The command you entered\nwas about to fail due to a known but unresolved\nbug, and we have 'manually' fixed it!\n\nWe don't yet know why this happens,\nso any information you can provide us that led\nto this message will help.\n\nSilence this message in the Options menu.", ConsoleMessageType.Error);
						}
					}
					else
					{
						Debug.LogError("Didn't find any commands for QueryAvailableCommands on ship upgrade ('" + baseShipUpgrade.Name + "') when done manually");
						if (GameSaveFile.Get("O_DBG", false))
						{
							SystemMessageManager.ShowSystemMessage("Msg From Dev to Player: The command you entered\nwas about to fail due to a known but unresolved\nbug.  We have tried to manually correct it, but have failed,\nand the command won't work on this ship.\n\nWe don't yet know why this happens,\nso any information you can provide us will help.\n\nSilence this message in the Options menu.", ConsoleMessageType.Error);
						}
					}
					break;
				}
				break;
			}
			}
		}
		if (flag)
		{
			bool flag6 = false;
			try
			{
				for (int n = 0; n < count3; n++)
				{
					ExecutedCommand executedCommand = list[n];
					if (isInConfirmState)
					{
						if (confirmCommandText.ToLower() == executedCommand.Command.CommandNameLower)
						{
							executedCommand.RequestConfirmed = true;
						}
						isInConfirmState = false;
						confirmCommandText = string.Empty;
					}
					List<ICommandable> list7 = _commandableObjects.ToList();
					int count5 = list7.Count;
					for (int num = 0; num < count5; num++)
					{
						ICommandable commandableObject = _commandableObjects[num];
						if (SendCommandToObject(commandableObject, executedCommand, commandText, partOfMultiCommand, out commandQueued) || commandQueued)
						{
							flag6 = true;
							break;
						}
					}
					if (flag6)
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				PrivateSendConsoleMessage("Internal error processing command!!", ConsoleMessageType.Error);
				Debug.LogError(string.Format("intercepted exception while processing command: {0}, {1}", ex.Message, ex.StackTrace));
			}
			if (!flag6)
			{
				PrivateSendConsoleMessage("Command not processed", ConsoleMessageType.Info);
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			}
			else
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandSuccess);
			}
			return true;
		}
		PrivateSendConsoleMessage("Unrecognized command: " + text, ConsoleMessageType.Error);
		if (_countOfCommandMatches > 1)
		{
			string text2 = "Related commands: ";
			bool flag7 = true;
			int count6 = _commandMatches.Count;
			for (int num2 = 0; num2 < count6; num2++)
			{
				string text3 = _commandMatches[num2];
				if (!flag7)
				{
					text2 += ", ";
				}
				text2 += text3;
				if (flag7)
				{
					flag7 = false;
				}
			}
			PrivateSendConsoleMessage(text2, ConsoleMessageType.Error);
		}
		PrivateSendConsoleMessage("use 'help' for list of known commands", ConsoleMessageType.Info);
		GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
		ScrollToEnd();
		ResetConsoleText(false);
		return false;
	}

	private bool ProcessCommandText(ICommandable commandableObject, CommandNode commandNode, string commandText, bool partOfMultiCommand, out bool commandQueued)
	{
		commandQueued = false;
		if (GlobalSettings.GameIsOver)
		{
			return true;
		}
		string[] array = commandText.Split(sep_tabspace, StringSplitOptions.RemoveEmptyEntries);
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		if (array.Length > 0)
		{
			if (CheckForSpecialCaseCommand(array))
			{
				return true;
			}
			for (int i = 1; i < array.Length; i++)
			{
				int result;
				if (int.TryParse(array[i], out result))
				{
					list2.Add(result);
				}
				else
				{
					list.Add(array[i]);
				}
			}
		}
		bool flag = false;
		if (commandNode.DataCount() > 1)
		{
			bool flag2 = false;
			if (commandNode.moProcessVerificationMethod != null)
			{
				flag2 = commandNode.moProcessVerificationMethod(commandNode.CommandText, list2);
			}
			else
			{
				flag2 = true;
				Debug.LogWarning(string.Format("Multiple results found for '{0}' but no 'searchResponseMessage' method provided.  Ignoring command.  Provide that method to show the player a message.", commandNode.CommandText));
			}
			if (flag2)
			{
				return true;
			}
		}
		try
		{
			ExecutedCommand executedCommand = new ExecutedCommand(commandNode.ObjectCommandDefinition, list, list2, commandText);
			if (isInConfirmState)
			{
				if (confirmCommandText.ToLower() == executedCommand.Command.CommandNameLower)
				{
					executedCommand.RequestConfirmed = true;
				}
				isInConfirmState = false;
				confirmCommandText = string.Empty;
			}
			if (SendCommandToObject(commandableObject, executedCommand, commandText, partOfMultiCommand, out commandQueued) || commandQueued)
			{
				flag = true;
			}
		}
		catch (Exception ex)
		{
			PrivateSendConsoleMessage("Internal error processing command!!", ConsoleMessageType.Error);
			Debug.LogError(string.Format("intercepted exception while processing command: {0}, {1}", ex.Message, ex.StackTrace));
		}
		if (!flag)
		{
			PrivateSendConsoleMessage("Command not processed", ConsoleMessageType.Info);
		}
		return true;
	}

	private bool SendCommandToObject(ICommandable commandableObject, ExecutedCommand commandToExecute, string commandText, bool partOfMultiCommand, out bool commandQueued)
	{
		commandQueued = false;
		commandableObject.ExecuteCommand(commandToExecute, partOfMultiCommand);
		if (commandToExecute.Handled)
		{
			HelpTextManager.Instance.ProcessExecutedCommand(commandToExecute.Command.CommandName);
		}
		if (commandToExecute.Handled && !commandToExecute.Queued && !commandToExecute.RequestConfirmation)
		{
			ScrollToEnd();
			return true;
		}
		if (commandToExecute.Queued && !commandToExecute.RequestConfirmation)
		{
			commandQueued = true;
			return true;
		}
		if (commandToExecute.RequestConfirmation)
		{
			isInConfirmState = true;
			confirmCommandText = commandToExecute.Command.CommandName;
			return true;
		}
		return false;
	}

	private bool CheckForSpecialCaseCommand(string[] commandArguments)
	{
		bool flag = false;
		string text = commandArguments[0].ToLower();
		List<string> list = null;
		if (text[0] == 'd' || text[0] == 'a')
		{
			string text2 = string.Empty;
			int num = commandArguments.Length;
			bool flag2 = false;
			for (int i = 0; i < num; i++)
			{
				string s = commandArguments[i].Substring(1);
				int result = 0;
				if (int.TryParse(s, out result))
				{
					text2 = text2 + " " + commandArguments[i];
					continue;
				}
				flag2 = true;
				break;
			}
			if (!flag2)
			{
				string text3 = "toggle";
				string text4 = text3 + " " + text2;
				bool flag3 = false;
				if (GlobalSettings.UseCommandTree)
				{
					flag3 = AttemptProcessWithCommandTree(text4);
				}
				if (!flag3)
				{
					bool commandQueued = false;
					ProcessCommandText(text4, false, out commandQueued);
				}
				flag = true;
			}
		}
		else if (text[0] == '?' || (text[0] == 'h' && "help".StartsWith(text)))
		{
			string text5 = string.Empty;
			foreach (string text6 in commandArguments)
			{
				text5 = text5 + text6 + " ";
			}
			flag = true;
			AddTextToConsole(new ConsoleMessage(string.Empty, ConsoleMessageType.None));
			bool flag4 = false;
			if (commandArguments.Length == 1 || commandArguments[1] == "all")
			{
				UpdateConsoleTextDisplay(false);
				ScrollToEnd();
				GameplayManager.Instance.ShowHelpManualWindow();
				return true;
			}
			if (GlobalSettings.cheatMode && commandArguments.Length > 1 && commandArguments[1].ToLower() == "dev")
			{
				DisplayAllDeveloperCommands();
				return true;
			}
			bool flag5 = commandArguments.Length >= 2 && commandArguments[1].Length == 3 && commandArguments[1].ToLower() == "all";
			bool flag6 = commandArguments.Length >= 2 && (flag5 || (commandArguments[1][0] == 's' && "shortcuts".StartsWith(commandArguments[1].ToLower())));
			List<CommandDefinition> list2 = new List<CommandDefinition>();
			string text7 = string.Empty;
			foreach (ICommandable commandableObject in _commandableObjects)
			{
				bool flag7 = false;
				List<CommandDefinition> list3;
				if (commandArguments.Length > 1)
				{
					list3 = commandableObject.QueryAvailableCommands();
					if (!flag5)
					{
						List<CommandDefinition> commands = CommandHelper.GetCommands("GlobalCommands");
						commands.AddRange(CommandHelper.GetCommands("ShortcutCommands"));
						commands.AddRange(CommandHelper.GetCommands("ShipUpgradeTransporter"));
						commands.AddRange(CommandHelper.GetCommands("ShipUpgradePowerManager"));
						commands.AddRange(CommandHelper.GetCommands("ShipUpgradeRemotePower"));
						foreach (CommandDefinition item in commands)
						{
							if ((item.DeveloperCommand && !GlobalSettings.cheatMode) || item.HideFromAutoComplete)
							{
								continue;
							}
							if (item.ShortcutCmd)
							{
								if (flag6 && !list2.Contains(item))
								{
									list2.Add(item);
								}
							}
							else
							{
								list3.Add(item);
							}
						}
						bool flag8 = false;
						bool flag9 = false;
						string text8 = string.Empty;
						int num2 = commandArguments.Length;
						for (int k = 1; k < num2; k++)
						{
							if (!string.IsNullOrEmpty(text8))
							{
								text8 += " ";
								flag9 = true;
							}
							text8 += commandArguments[k].ToString().ToLower();
						}
						text7 = text8;
						foreach (CommandDefinition item2 in list3)
						{
							if (!flag6 && item2.ShortcutCmd)
							{
								continue;
							}
							if (flag6 && item2.ShortcutCmd)
							{
								if (flag6 && !list2.Contains(item2))
								{
									list2.Add(item2);
								}
							}
							else
							{
								if (item2.HideFromAutoComplete || (item2.DeveloperCommand && !GlobalSettings.cheatMode))
								{
									continue;
								}
								bool flag10 = false;
								bool flag11 = false;
								if (item2.CommandName == text8)
								{
									flag11 = true;
									flag10 = true;
								}
								else if (flag9 && item2.CommandName.StartsWith(text8))
								{
									flag10 = true;
								}
								if (!flag10 || (list != null && list.Contains(item2.CommandName)))
								{
									continue;
								}
								if (list == null)
								{
									list = new List<string>();
								}
								flag8 = true;
								list.Add(item2.CommandName);
								AddTextToConsole(new ConsoleMessage("<b>" + item2.CommandName + "</b>:", ConsoleMessageType.None));
								string text9 = "\t";
								text9 = ((!(item2.Description != string.Empty)) ? (text9 + "[ no desc ]") : (text9 + item2.Description));
								AddTextToConsole(new ConsoleMessage(text9, ConsoleMessageType.None));
								if (item2.DetailedDescription.Count == 0)
								{
									if (item2.Example != string.Empty)
									{
										AddTextToConsole(new ConsoleMessage("\t\t" + item2.Example, ConsoleMessageType.None, ConsoleMessageFormat.SmallFont));
									}
								}
								else
								{
									if (item2.Example != string.Empty)
									{
										AddTextToConsole(new ConsoleMessage("\t\t" + item2.Example, ConsoleMessageType.None, ConsoleMessageFormat.SmallFont));
									}
									AddTextToConsole(item2.DetailedDescription);
								}
								if (item2.ModList != null && item2.ModList.Count > 0)
								{
									AddTextToConsole(new ConsoleMessage("\n\t\tFor help with modifications see manual entry", ConsoleMessageType.Info, ConsoleMessageFormat.Normal));
								}
								if (flag11)
								{
									return true;
								}
							}
						}
						if (!flag)
						{
							flag = flag8;
						}
						continue;
					}
				}
				else
				{
					list3 = commandableObject.QueryContextCommands();
				}
				if (!flag4)
				{
					flag4 = true;
					List<CommandDefinition> commands2 = CommandHelper.GetCommands("GlobalCommands");
					foreach (CommandDefinition item3 in commands2)
					{
						if (item3.DeveloperCommand || item3.HideFromAutoComplete)
						{
							continue;
						}
						if (item3.ShortcutCmd)
						{
							if (flag6 && !list2.Contains(item3))
							{
								list2.Add(item3);
							}
						}
						else
						{
							DisplayBasicCommandInfo(item3);
						}
					}
					AddTextToConsole(new ConsoleMessage(string.Empty, ConsoleMessageType.None));
				}
				CommandDefinition command;
				foreach (CommandDefinition item4 in list3)
				{
					command = item4;
					if (command.DeveloperCommand || command.InternalCmd)
					{
						continue;
					}
					if (command.ShortcutCmd)
					{
						if (flag6 && !list2.Any((CommandDefinition x) => x.CommandName == command.CommandName))
						{
							list2.Add(command);
						}
						continue;
					}
					if (!flag7)
					{
						AddTextToConsole(new ConsoleMessage(commandableObject.CommandHeader, ConsoleMessageType.None, ConsoleMessageFormat.HeaderFont));
						flag7 = true;
					}
					if (!string.IsNullOrEmpty(command.CommandName))
					{
						DisplayBasicCommandInfo(command);
						continue;
					}
					string description = command.Description;
					AddTextToConsole(new ConsoleMessage(description, ConsoleMessageType.None, ConsoleMessageFormat.Normal));
				}
				if (flag7)
				{
					AddTextToConsole(new ConsoleMessage(string.Empty, ConsoleMessageType.None));
				}
			}
			if (flag6)
			{
				List<CommandDefinition> commands3 = CommandHelper.GetCommands("ShortcutCommands");
				CommandDefinition command2;
				foreach (CommandDefinition item5 in commands3)
				{
					command2 = item5;
					if (!command2.DeveloperCommand && !list2.Any((CommandDefinition x) => x.CommandName == command2.CommandName))
					{
						list2.Add(command2);
					}
				}
				if (list2.Count > 0)
				{
					if (flag5)
					{
						AddTextToConsole(new ConsoleMessage("Shortcuts", ConsoleMessageType.None, ConsoleMessageFormat.HeaderFont));
					}
					else
					{
						AddTextToConsole(new ConsoleMessage("<b>Shortcuts</b>:", ConsoleMessageType.None));
					}
					foreach (CommandDefinition item6 in list2)
					{
						if (!string.IsNullOrEmpty(item6.CommandName))
						{
							DisplayBasicCommandInfo(item6);
							continue;
						}
						string description2 = item6.Description;
						AddTextToConsole(new ConsoleMessage(description2, ConsoleMessageType.None, ConsoleMessageFormat.Normal));
					}
				}
			}
			if (commandArguments.Length > 1 && commandArguments[1].ToString().ToLower() != "all" && (list == null || list.Count == 0))
			{
				if (string.IsNullOrEmpty(text7))
				{
					AddTextToConsole(new ConsoleMessage("No results found for '" + commandArguments[1] + "'", ConsoleMessageType.Warning));
				}
				else
				{
					AddTextToConsole(new ConsoleMessage("No results found for '" + text7 + "'", ConsoleMessageType.Warning));
				}
			}
			UpdateConsoleTextDisplay(false);
			ScrollToEnd();
		}
		else if (text == "clear")
		{
			_consoleWindowAllTextHistory.Clear();
			_commandHistoryIndex = -1;
			ResetConsoleText(true);
			UpdateConsoleTextDisplay(true, true);
			flag = true;
		}
		return flag;
	}

	private void DisplayAllDeveloperCommands()
	{
		foreach (ICommandable commandableObject in _commandableObjects)
		{
			bool flag = false;
			foreach (CommandDefinition item in commandableObject.QueryAvailableCommands())
			{
				if (item.DeveloperCommand)
				{
					if (!flag)
					{
						AddTextToConsole(new ConsoleMessage(commandableObject.CommandHeader, ConsoleMessageType.None, ConsoleMessageFormat.HeaderFont));
						flag = true;
					}
					DisplayBasicCommandInfo(item);
				}
			}
		}
		string message = "\nNot Installed Upgrade Commands Follow:\n";
		AddTextToConsole(new ConsoleMessage(message, ConsoleMessageType.None, ConsoleMessageFormat.HeaderFont));
		foreach (ICommandable commandableObject2 in _commandableObjects)
		{
			foreach (CommandDefinition item2 in commandableObject2.QueryDeveloperSpecialCaseCommands())
			{
				DisplayBasicCommandInfo(item2);
			}
		}
	}

	private void DisplayBasicCommandInfo(CommandDefinition command)
	{
		string text = "\t<b>" + command.CommandName + "</b>";
		if (command.Description != string.Empty)
		{
			text = text + ": " + command.Description;
		}
		AddTextToConsole(new ConsoleMessage(text, ConsoleMessageType.None));
		if (command.Example != string.Empty)
		{
			AddTextToConsole(new ConsoleMessage("\t\t" + command.Example, ConsoleMessageType.None, ConsoleMessageFormat.SmallFont));
		}
	}

	private string GetUniqueFullCommand(string substringCommand, List<CommandDefinition> commands, bool exactMatch, bool allowHelpCommands, out int countOfAllMatches)
	{
		return GetUniqueFullCommand(substringCommand, commands, exactMatch, allowHelpCommands, null, out countOfAllMatches);
	}

	private string GetUniqueFullCommand(string substringCommand, List<CommandDefinition> commands, bool exactMatch, bool allowHelpCommands, List<string> matchingCommands, out int countOfAllMatches)
	{
		if (matchingCommands != null)
		{
			matchingCommands.Clear();
		}
		int countOfAllPotentialMatches;
		string text = InternalGetCommand(substringCommand, commands, exactMatch, allowHelpCommands, matchingCommands, out countOfAllMatches, out countOfAllPotentialMatches);
		if (exactMatch && string.IsNullOrEmpty(text) && countOfAllPotentialMatches == 1)
		{
			int countOfAllMatches2;
			string text2 = InternalGetCommand(substringCommand, commands, false, allowHelpCommands, null, out countOfAllMatches2, out countOfAllPotentialMatches);
			if (!string.IsNullOrEmpty(text2))
			{
				text = InternalGetCommand(text2, commands, exactMatch, allowHelpCommands, null, out countOfAllMatches2, out countOfAllPotentialMatches);
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		return substringCommand;
	}

	private static string InternalGetCommand(string substringCommand, List<CommandDefinition> commands, bool exactMatch, bool allowHelpCommands, List<string> matchingCommands, out int countOfAllMatches, out int countOfAllPotentialMatches)
	{
		countOfAllPotentialMatches = 0;
		countOfAllMatches = 0;
		string text = null;
		string text2 = substringCommand.ToLower();
		int count = commands.Count;
		for (int i = 0; i < count; i++)
		{
			CommandDefinition commandDefinition = commands[i];
			if (commandDefinition.DeveloperCommand || commandDefinition.InternalCmd || commandDefinition.CommandName == null || (!allowHelpCommands && commandDefinition.IsHelpOnly) || commandDefinition.HideFromAutoComplete)
			{
				continue;
			}
			bool flag = commandDefinition.CommandNameLower.StartsWith(text2);
			if (flag)
			{
				countOfAllPotentialMatches++;
			}
			if ((exactMatch || !flag) && (!exactMatch || !(commandDefinition.CommandNameLower == text2)))
			{
				continue;
			}
			if (text == null && countOfAllMatches == 0)
			{
				countOfAllMatches++;
				text = commandDefinition.CommandName;
				if (matchingCommands != null && !matchingCommands.Contains(commandDefinition.CommandName))
				{
					matchingCommands.Add(commandDefinition.CommandName);
				}
			}
			else if (commandDefinition.CommandName != text)
			{
				text = null;
				countOfAllMatches++;
				if (matchingCommands != null && !matchingCommands.Contains(commandDefinition.CommandName))
				{
					matchingCommands.Add(commandDefinition.CommandName);
				}
			}
		}
		return text;
	}

	private string GetUniqueFullCommandTextFromAllObjects(string startingCommandText, bool allowHelpCommands, out int countOfAllMatches)
	{
		return GetUniqueFullCommandTextFromAllObjects(startingCommandText, null, allowHelpCommands, out countOfAllMatches);
	}

	private string GetUniqueFullCommandTextFromAllObjects(string startingCommandText, List<string> matchingCommands, bool allowHelpCommands, out int countOfAllMatches)
	{
		if (matchingCommands != null)
		{
			matchingCommands.Clear();
		}
		countOfAllMatches = 0;
		string text = startingCommandText;
		int length = startingCommandText.Length;
		for (int num = length - 1; num >= 0; num--)
		{
			if (startingCommandText[num] == ' ' || startingCommandText[num] == '\t')
			{
				text = startingCommandText.Substring(num);
				break;
			}
		}
		if (text.Length == 0)
		{
			return null;
		}
		text = text.Trim();
		if (text.Length == 0)
		{
			return null;
		}
		if (allCommandsBucketList == null)
		{
			allCommandsBucketList = new List<CommandDefinition>(100);
		}
		else
		{
			allCommandsBucketList.Clear();
		}
		int count = _commandableObjects.Count;
		for (int i = 0; i < count; i++)
		{
			ICommandable commandable = _commandableObjects[i];
			allCommandsBucketList.AddRange(commandable.QueryAvailableCommands());
		}
		allCommandsBucketList.AddRange(CommandHelper.GetCommands("GlobalCommands"));
		allCommandsBucketList.AddRange(CommandHelper.GetAliasCommands());
		string uniqueFullCommand = GetUniqueFullCommand(text, allCommandsBucketList, false, allowHelpCommands, matchingCommands, out countOfAllMatches);
		if (uniqueFullCommand != text)
		{
			return uniqueFullCommand;
		}
		return null;
	}

	public Rect GetConsoleRect()
	{
		return _mainRectTransform.rect;
	}

	public void OnDrag()
	{
		Vector3 position = new Vector3(Mathf.Clamp(Input.mousePosition.x + _mainRectTransform.rect.width, 0f, _initialWindowPosition.x), Mathf.Clamp(Input.mousePosition.y - _mainRectTransform.rect.height, _initialWindowPosition.y, (float)Screen.height - _mainRectTransform.rect.height), Input.mousePosition.z);
		base.transform.position = position;
	}

	private void AddTextToConsole(ConsoleMessage msgObject)
	{
		_consoleWindowAllTextHistory.Add(msgObject);
		if (finalConsoleText == null)
		{
			finalConsoleText = new StringBuilder(10000);
			lineEndPositionList = new List<int>(50);
		}
		ConsoleMessage consoleMessage = _consoleWindowAllTextHistory[_consoleWindowAllTextHistory.Count - 1];
		string empty = string.Empty;
		ConsoleMessageFormat format = consoleMessage.Format;
		if (format != ConsoleMessageFormat.SmallFont && format == ConsoleMessageFormat.HeaderFont)
		{
			empty = string.Format("<color=white>==={0}===</color>", consoleMessage.Message.ToUpper());
		}
		else
		{
			Color32 color = GetConsoleTextColor(consoleMessage.Type);
			string arg = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
			empty = string.Format("<color=#{0}>{1}</color>", arg, consoleMessage.Message);
		}
		bool flag = false;
		if (_consoleWindowAllTextHistory.Count > 50)
		{
			int num = _consoleWindowAllTextHistory.Count - 50;
			for (int i = 0; i < num; i++)
			{
				_consoleWindowAllTextHistory.RemoveAt(0);
				flag = true;
				ClearFirstLine();
			}
		}
		finalConsoleText.AppendLine(empty);
		lineEndPositionList.Add(empty.Length);
		FormatSpaces();
		if (flag)
		{
			_consoleText.text = finalConsoleText.ToString() + currentLineVal;
		}
	}

	private void AddTextToConsole(List<ConsoleMessage> msgObjectList)
	{
		foreach (ConsoleMessage msgObject in msgObjectList)
		{
			if (msgObject.Type != ConsoleMessageType.HiddenOnConsole)
			{
				AddTextToConsole(msgObject);
			}
		}
	}
}
