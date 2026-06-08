using UnityEngine;

public class BaseWindow
{
	private const float GAMEOVER_WINDOW_WIDTH = 600f;

	private const float CONTINUE_LABEL_HEIGHT = 30f;

	private const float MARGIN = 15f;

	private const float INITIAL_WINDOW_HEIGHT = 20f;

	private const float INITIAL_WINDOW_DELAY = 1f;

	private const float CONTINUE_BLINK_TIME = 1f;

	private const float WINDOW_GROW_TOTAL_TIME = 0.2f;

	private const float LOADING_MESSAGE_TOTAL_TIME = 1f;

	private const float LOADING_PROGRESS_UPDATE_TIME = 0.4f;

	protected string mainDisplayText = "n/a";

	protected string loadedFullText = string.Empty;

	private Rect _gameOverWindowRect;

	private Rect _growingWindowRect;

	private Rect _mainTextAreaRect;

	private Rect _continueLabelRect;

	private Vector2 _scrollPosition = default(Vector2);

	private float _initialDelayTimer;

	private float _continueBlinkTimer;

	private float _loadingMessageDisplayTimer;

	private float _loadingProgressTimer;

	private bool _showActualWindow;

	private bool _textIsFullyDisplayed;

	protected bool showContinueMessage;

	private int _currentTextPosition;

	public bool WindowIsShown { get; protected set; }

	public virtual void ShowWindow()
	{
		WindowIsShown = true;
		_gameOverWindowRect = new Rect((float)(Screen.width / 2) - 300f, 1f, 600f, Screen.height);
		_growingWindowRect = new Rect(_gameOverWindowRect.x, (float)(Screen.height / 2) - 10f, _gameOverWindowRect.width, 20f);
		_mainTextAreaRect = new Rect(15f, 15f, _gameOverWindowRect.width - 30f, _gameOverWindowRect.height - 30f);
		_continueLabelRect = new Rect(_gameOverWindowRect.width / 2f - 105f, (float)Screen.height - 30f - 15f, _gameOverWindowRect.width - 30f, 30f);
		_initialDelayTimer = 1f;
		_continueBlinkTimer = 1f;
		showContinueMessage = false;
		_showActualWindow = false;
		_loadingMessageDisplayTimer = 1f;
		_loadingProgressTimer = 0.4f;
		_textIsFullyDisplayed = false;
		_currentTextPosition = 0;
		GenerateText();
	}

	public void DrawWindow()
	{
		if (WindowIsShown)
		{
			if (_showActualWindow)
			{
				GUI.Window(25, _gameOverWindowRect, DrawWindow, string.Empty);
			}
			else if (_initialDelayTimer <= 0f)
			{
				GUI.Window(25, _growingWindowRect, DrawEmptyWindow, string.Empty);
			}
		}
	}

	public bool Update()
	{
		if (!WindowIsShown)
		{
			return false;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (_textIsFullyDisplayed)
			{
				return true;
			}
			if (_loadingMessageDisplayTimer > 0f || !_textIsFullyDisplayed)
			{
				_loadingMessageDisplayTimer = 0f;
				_textIsFullyDisplayed = true;
				mainDisplayText = loadedFullText;
			}
			return false;
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
					mainDisplayText += ".";
				}
				if (_loadingMessageDisplayTimer <= 0f)
				{
					mainDisplayText = string.Empty;
				}
			}
			else if (!_textIsFullyDisplayed)
			{
				if (_currentTextPosition < loadedFullText.Length)
				{
					int num2 = Mathf.Min(_currentTextPosition + 10, loadedFullText.Length);
					while (_currentTextPosition < num2)
					{
						mainDisplayText += loadedFullText[_currentTextPosition];
						_currentTextPosition++;
					}
				}
				else
				{
					_textIsFullyDisplayed = true;
				}
			}
			if (_textIsFullyDisplayed)
			{
				_continueBlinkTimer -= Time.deltaTime;
				if (_continueBlinkTimer <= 0f)
				{
					_continueBlinkTimer = 1f;
					showContinueMessage = !showContinueMessage;
				}
			}
		}
		return false;
	}

	protected virtual void DrawWindow(int id)
	{
		DrawBackgroundWindowTexture();
		_scrollPosition = GUI.BeginScrollView(_mainTextAreaRect, _scrollPosition, _mainTextAreaRect);
		GUI.EndScrollView();
		GUI.DragWindow();
	}

	private void DrawEmptyWindow(int id)
	{
	}

	protected virtual void GenerateText()
	{
	}

	private void DrawBackgroundTexture()
	{
		GUIStyle style = new GUIStyle();
		GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, style);
	}

	private void DrawBackgroundWindowTexture()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.normal.background = ResourceManager.SemiTransparantBackground70;
		GUI.Box(new Rect(2f, 17f, _gameOverWindowRect.width - 4f, _gameOverWindowRect.height - 20f), string.Empty, gUIStyle);
	}
}
