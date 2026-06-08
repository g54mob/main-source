using UnityEngine;

public class LogWindow
{
	private const float LOG_WINDOW_WIDTH = 600f;

	private const float CONTINUE_LABEL_HEIGHT = 30f;

	private const float MARGIN = 15f;

	private const float INITIAL_WINDOW_HEIGHT = 20f;

	private const float INITIAL_WINDOW_DELAY = 1f;

	private const float CONTINUE_BLINK_TIME = 1f;

	private const float WINDOW_GROW_TOTAL_TIME = 0.2f;

	private const float LOADING_MESSAGE_TOTAL_TIME = 1f;

	private const float LOADING_PROGRESS_UPDATE_TIME = 0.4f;

	protected string logText = "n/a";

	private Rect _shipsLogsWindowRect;

	private Rect _growingWindowRect;

	private Rect _logTextRect;

	private Rect _continueLabelRect;

	private Vector2 _scrollPosition = default(Vector2);

	private float _initialDelayTimer;

	private float _continueBlinkTimer;

	private float _loadingMessageDisplayTimer;

	private float _loadingProgressTimer;

	private bool _showActualWindow;

	private bool _textIsFullyDisplayed;

	private bool _showContinueMessage;

	private Texture2D _backgroundTexture;

	private TypedMessageFormatter msgFormatter;

	public bool WindowIsShown { get; protected set; }

	public LogWindow()
	{
		msgFormatter = new TypedMessageFormatter();
		_shipsLogsWindowRect = new Rect((float)(Screen.width / 2) - 300f, 1f, 600f, Screen.height);
		_growingWindowRect = new Rect(_shipsLogsWindowRect.x, (float)(Screen.height / 2) - 10f, _shipsLogsWindowRect.width, 20f);
		_logTextRect = new Rect(15f, 15f, _shipsLogsWindowRect.width - 30f, _shipsLogsWindowRect.height - 30f);
		_continueLabelRect = new Rect(_shipsLogsWindowRect.width / 2f - 105f, (float)Screen.height - 30f - 15f, _shipsLogsWindowRect.width - 30f, 30f);
		Reset();
		ResourceManager.GenerateSemiTransparantBackgroundTexture(ref _backgroundTexture, 1f);
	}

	public void ShowLog(string text)
	{
		ShowLog(">\n> Accessing log", text);
	}

	public void ShowLog(string introText, string text)
	{
		WindowIsShown = true;
		logText = introText;
		msgFormatter.SetRawText(text);
	}

	public bool Update()
	{
		bool onlyAllowSkip = !_showActualWindow || _loadingMessageDisplayTimer > 0f;
		if (!_textIsFullyDisplayed)
		{
			_textIsFullyDisplayed = msgFormatter.Update(onlyAllowSkip, true, ref logText);
			if (_textIsFullyDisplayed || msgFormatter.isYNConditionalShowing)
			{
				_loadingMessageDisplayTimer = 0f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Input.ResetInputAxes();
			WindowIsShown = false;
			Reset();
			return true;
		}
		if (!_showActualWindow)
		{
			if (_initialDelayTimer > 0f)
			{
				_initialDelayTimer -= Time.deltaTime;
			}
			else
			{
				float num = _growingWindowRect.height + 2f * ((float)Screen.height * Time.deltaTime / 0.2f);
				_growingWindowRect = new Rect(_growingWindowRect.x, (float)(Screen.height / 2) - num / 2f, _growingWindowRect.width, num);
				if (num >= (float)Screen.height)
				{
					_showActualWindow = true;
				}
			}
		}
		else
		{
			if (_loadingMessageDisplayTimer > 0f)
			{
				_loadingMessageDisplayTimer -= Time.deltaTime;
				_loadingProgressTimer -= Time.deltaTime;
				if (_loadingProgressTimer <= 0f)
				{
					_loadingProgressTimer = 0.4f;
					logText += ".";
				}
				if (_loadingMessageDisplayTimer <= 0f)
				{
					logText = string.Empty;
				}
			}
			if (_textIsFullyDisplayed)
			{
				_continueBlinkTimer -= Time.deltaTime;
				if (_continueBlinkTimer <= 0f)
				{
					_continueBlinkTimer = 1f;
					_showContinueMessage = !_showContinueMessage;
				}
			}
		}
		return false;
	}

	public void DrawWindow()
	{
		if (WindowIsShown)
		{
			if (_showActualWindow)
			{
				GUI.Window(23, _shipsLogsWindowRect, DrawActualWindow, string.Empty);
			}
			else if (_initialDelayTimer <= 0f)
			{
				GUI.Window(23, _growingWindowRect, DrawEmptyWindow, string.Empty);
			}
			DrawBackgroundTexture();
		}
	}

	protected void DrawActualWindow(int id)
	{
		_scrollPosition = GUI.BeginScrollView(_logTextRect, _scrollPosition, _logTextRect);
		GUI.EndScrollView();
		GUI.DragWindow();
	}

	protected void SetFullText(string text)
	{
		msgFormatter.SetRawText(text);
	}

	private void Reset()
	{
		_initialDelayTimer = 1f;
		_continueBlinkTimer = 1f;
		_showContinueMessage = false;
		_showActualWindow = false;
		_loadingMessageDisplayTimer = 1f;
		_loadingProgressTimer = 0.4f;
		_textIsFullyDisplayed = false;
		msgFormatter.Initalize();
	}

	private void DrawEmptyWindow(int id)
	{
	}

	private void DrawBackgroundTexture()
	{
		GUI.DrawTexture(new Rect(-1f, -1f, Screen.width + 5, Screen.height + 5), _backgroundTexture);
	}
}
