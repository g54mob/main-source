using UnityEngine;

public class LogUI : UIWindow
{
	private const float INITIAL_WINDOW_DELAY = 1f;

	private const float LOADING_MESSAGE_TOTAL_TIME = 1f;

	private const float LOADING_PROGRESS_UPDATE_TIME = 0.4f;

	private const float CONTINUE_BLINK_TIME = 1f;

	private const float WINDOW_GROW_TOTAL_TIME = 0.2f;

	public static LogUI Instance;

	public UITextLabel inputLabel;

	private bool isShowingActualWindow;

	private bool isShowingContinueMessage;

	private float loadingMessageDisplayTimer;

	private float initialDelayTimer;

	private float loadingProgressTimer;

	private float continueBlinkTimer;

	private float originalHeight;

	private float currentHeight;

	private bool isTextFullyDisplayed;

	private RectTransform underlyingRT;

	private TypedMessageFormatter msgFormatter;

	private Color defaultBodyColor = GlobalSettings.Constants.LOG_DEFAULT_COLOR;

	public int Tag { get; private set; }

	private void Awake()
	{
		Instance = this;
		if (screenDimImage != null)
		{
			screenDimImage.gameObject.SetActive(true);
			screenDimImage.enabled = false;
		}
		base.gameObject.SetActive(false);
		inputLabel.label.gameObject.SetActive(false);
		underlyingRT = base.gameObject.GetComponent<RectTransform>();
		originalHeight = underlyingRT.rect.height;
		currentHeight = originalHeight / 2f;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public bool PumpUpdate()
	{
		bool onlyAllowSkip = !isShowingActualWindow || loadingMessageDisplayTimer > 0f;
		if (!isTextFullyDisplayed)
		{
			string logText = bodyLabel.label.text;
			isTextFullyDisplayed = msgFormatter.Update(onlyAllowSkip, false, ref logText);
			bodyLabel.label.text = logText;
			if (isTextFullyDisplayed || msgFormatter.isYNConditionalShowing)
			{
				bodyLabel.label.color = defaultBodyColor;
				loadingMessageDisplayTimer = 0f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Input.ResetInputAxes();
			CloseWindow();
			Reset();
			return true;
		}
		if (!isShowingActualWindow)
		{
			if (initialDelayTimer > 0f)
			{
				initialDelayTimer -= Time.deltaTime;
			}
			else
			{
				base.gameObject.SetActive(true);
				currentHeight -= originalHeight * Time.deltaTime / 0.2f;
				if (currentHeight <= 10f)
				{
					currentHeight = 10f;
				}
				underlyingRT.offsetMax = new Vector2(underlyingRT.offsetMax.x, 0f - currentHeight);
				underlyingRT.offsetMin = new Vector2(underlyingRT.offsetMin.x, currentHeight);
				if (currentHeight <= 10f)
				{
					isShowingActualWindow = true;
					GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSText1);
				}
			}
		}
		else
		{
			if (loadingMessageDisplayTimer > 0f)
			{
				loadingMessageDisplayTimer -= Time.deltaTime;
				loadingProgressTimer -= Time.deltaTime;
				if (loadingProgressTimer <= 0f)
				{
					loadingProgressTimer = 0.4f;
					bodyLabel.label.text += ".";
				}
				if (loadingMessageDisplayTimer <= 0f)
				{
					bodyLabel.label.text = string.Empty;
					bodyLabel.label.color = defaultBodyColor;
				}
			}
			if (isTextFullyDisplayed)
			{
				continueBlinkTimer -= Time.deltaTime;
				if (continueBlinkTimer <= 0f)
				{
					continueBlinkTimer = 1f;
					isShowingContinueMessage = !isShowingContinueMessage;
					if (isShowingContinueMessage)
					{
						if (!inputLabel.gameObject.activeSelf)
						{
							inputLabel.gameObject.SetActive(true);
							inputLabel.label.gameObject.SetActive(true);
						}
						inputLabel.label.text = "Press [ENTER] to Continue...";
					}
					else
					{
						inputLabel.label.text = string.Empty;
					}
				}
			}
		}
		return false;
	}

	public void ShowWindow(string rawText, Color defaultBodyColor)
	{
		ShowWindow(rawText, defaultBodyColor, -1);
	}

	public void ShowWindow(string rawText, Color defaultBodyColor, int tag)
	{
		ShowWindow(">\n> Accessing log", rawText, defaultBodyColor, tag);
	}

	public void ShowWindow(string initialText, string rawText, Color defaultBodyColor)
	{
		ShowWindow(initialText, rawText, defaultBodyColor, -1);
	}

	public void ShowWindow(string initialText, string rawText, Color defaultBodyColor, int tag)
	{
		ShowWindow(initialText, rawText, defaultBodyColor, tag, 1f);
	}

	public void ShowWindow(string initialText, string rawText, Color defaultBodyColor, int tag, float backgroundAlpha)
	{
		Tag = tag;
		Reset();
		if (screenDimImage != null)
		{
			if (!screenDimImage.gameObject.activeSelf)
			{
				screenDimImage.gameObject.SetActive(true);
			}
			screenDimImage.enabled = true;
			Color color = screenDimImage.color;
			color.a = backgroundAlpha;
			screenDimImage.color = color;
		}
		if (msgFormatter == null)
		{
			msgFormatter = new TypedMessageFormatter();
		}
		msgFormatter.Initalize();
		msgFormatter.SetRawText(rawText);
		this.defaultBodyColor = defaultBodyColor;
		bodyLabel.label.color = GlobalSettings.Constants.LOG_DEFAULT_TYPING_COLOR;
		bodyLabel.label.text = initialText;
		base.IsShowing = true;
	}

	public void ForceText(string text)
	{
		bodyLabel.label.text = text;
		isShowingContinueMessage = false;
	}

	public void CloseWindow()
	{
		if (screenDimImage != null)
		{
			screenDimImage.enabled = false;
		}
		base.gameObject.SetActive(false);
		base.IsShowing = false;
	}

	private void Reset()
	{
		initialDelayTimer = 1f;
		continueBlinkTimer = 1f;
		isShowingContinueMessage = false;
		isShowingActualWindow = false;
		loadingMessageDisplayTimer = 1f;
		loadingProgressTimer = 0.4f;
		isTextFullyDisplayed = false;
		inputLabel.gameObject.SetActive(false);
		if (originalHeight < 0f)
		{
			originalHeight = underlyingRT.rect.height;
		}
		currentHeight = originalHeight / 2f;
		underlyingRT.offsetMax = new Vector2(underlyingRT.offsetMax.x, 0f - currentHeight);
		underlyingRT.offsetMin = new Vector2(underlyingRT.offsetMin.x, currentHeight);
		if (msgFormatter != null)
		{
			msgFormatter.Initalize();
		}
	}
}
