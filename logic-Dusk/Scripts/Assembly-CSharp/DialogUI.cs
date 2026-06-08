using UnityEngine;

public class DialogUI : UIWindow
{
	public static DialogUI Instance;

	public UIDialogButtonCollection buttonPanel;

	public UIInput inputBox;

	public Color focusedButtonColor = Color.blue;

	public Color focusedTextColor = Color.white;

	public Color notFocusedButtonColor = Color.white;

	public Color notFocusedTextColor = Color.blue;

	private ModalWindowType currentDialogType;

	private ModalWindowResultDelegate resultDelegate;

	private float delayClose;

	private bool hasResult;

	private ModalWindowResult resultType;

	private bool focusOnInput;

	private bool initialFocusOnInput;

	private bool inputChanged;

	private void Awake()
	{
		Instance = this;
		if (screenDimImage != null)
		{
			screenDimImage.gameObject.SetActive(true);
			screenDimImage.enabled = false;
		}
		base.gameObject.SetActive(false);
		if (inputBox != null)
		{
			inputBox.gameObject.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void Update()
	{
		if (initialFocusOnInput)
		{
			SystemEvents.Instance.eventSystem.SetSelectedGameObject(inputBox.gameObject);
			inputBox.inputField.ActivateInputField();
			inputBox.inputField.onValidateInput = ValidateInput;
			initialFocusOnInput = false;
		}
		if (inputChanged)
		{
			inputBox.RefreshCounter();
			if (!inputBox.characterCounterText.gameObject.activeSelf)
			{
				inputBox.characterCounterText.gameObject.SetActive(true);
			}
		}
	}

	public bool TestKeyInput()
	{
		if (hasResult)
		{
			delayClose -= Time.deltaTime;
			if (delayClose <= 0f)
			{
				hasResult = false;
				CloseDialogWithResult(resultType);
				Input.ResetInputAxes();
				if (DungeonManager.Instance != null)
				{
					DungeonManager.Instance.DisableAllInputForAMoment();
				}
				return true;
			}
			return false;
		}
		ModalWindowResult modalWindowResult = ModalWindowResult.None;
		int num = -1;
		int focusByIndex = -1;
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			num = buttonPanel.FocusedButtonIndex();
		}
		switch (currentDialogType)
		{
		case ModalWindowType.YesNo:
		case ModalWindowType.YesNoCancel:
			if (num == 0 || Input.GetKeyDown(KeyCode.Y))
			{
				modalWindowResult = ModalWindowResult.Yes;
				focusByIndex = 0;
			}
			else if (num == 1 || Input.GetKeyDown(KeyCode.N) || (currentDialogType == ModalWindowType.YesNo && Input.GetKeyDown(KeyCode.Escape)))
			{
				modalWindowResult = ModalWindowResult.No;
				focusByIndex = 1;
			}
			else if (num == 2 || (currentDialogType == ModalWindowType.YesNoCancel && (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape))))
			{
				modalWindowResult = ModalWindowResult.Cancel;
				focusByIndex = 2;
			}
			break;
		case ModalWindowType.OK:
		case ModalWindowType.OKCancel:
		case ModalWindowType.OKCancelInput:
			if (!focusOnInput)
			{
				if (num == 0 || Input.GetKeyDown(KeyCode.O))
				{
					modalWindowResult = ModalWindowResult.OK;
					focusByIndex = 0;
				}
				else if (num == 1 || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.C))
				{
					modalWindowResult = ModalWindowResult.Cancel;
					focusByIndex = 1;
				}
				else if (currentDialogType == ModalWindowType.OK && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
				{
					modalWindowResult = ModalWindowResult.OK;
					focusByIndex = 0;
				}
			}
			else if (num == 0)
			{
				if (inputBox.inputField.text.Trim().Length == 0)
				{
					modalWindowResult = ModalWindowResult.Cancel;
					focusByIndex = 1;
				}
				else
				{
					modalWindowResult = ModalWindowResult.OK;
					focusByIndex = 0;
					Input.ResetInputAxes();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				modalWindowResult = ModalWindowResult.Cancel;
				focusByIndex = 1;
			}
			break;
		case ModalWindowType.ContinueExit:
			if (num == 0 || Input.GetKeyDown(KeyCode.C))
			{
				modalWindowResult = ModalWindowResult.Continue;
				focusByIndex = 0;
			}
			else if (num == 1 || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
			{
				modalWindowResult = ModalWindowResult.Exit;
				focusByIndex = 1;
			}
			break;
		}
		if (!focusOnInput)
		{
			if (modalWindowResult == ModalWindowResult.None)
			{
				if (Input.GetButtonDown("Right"))
				{
					buttonPanel.MoveFocusRight();
				}
				else if (Input.GetButtonDown("Left"))
				{
					buttonPanel.MoveFocusLeft();
				}
				else if (Input.anyKeyDown)
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
			else
			{
				buttonPanel.SetFocusByIndex(focusByIndex);
			}
		}
		if (modalWindowResult != ModalWindowResult.None)
		{
			hasResult = true;
			resultType = modalWindowResult;
			if (num == -1)
			{
				delayClose = 0.05f;
			}
			else
			{
				delayClose = 0f;
			}
		}
		return false;
	}

	public void ShowDialog(string title, string message)
	{
		ShowDialog(title, message, ModalWindowType.OK, null);
	}

	public void ShowDialog(string title, string message, ModalWindowType type, ModalWindowResultDelegate resultDelegate)
	{
		ShowDialog(title, message, type, resultDelegate, 0);
	}

	public void ShowDialog(string title, string message, ModalWindowType type, ModalWindowResultDelegate resultDelegate, int defaultButtonWithFocus)
	{
		ShowDialog(title, message, type, resultDelegate, defaultButtonWithFocus, string.Empty);
	}

	public void ShowDialog(string title, string message, ModalWindowType type, ModalWindowResultDelegate resultDelegate, int defaultButtonWithFocus, string defaultInput)
	{
		if (screenDimImage != null)
		{
			screenDimImage.enabled = true;
			Color color = screenDimImage.color;
			color.a = 0.6f;
			screenDimImage.color = color;
		}
		base.gameObject.SetActive(true);
		if (!string.IsNullOrEmpty(title))
		{
			titleLabel.gameObject.SetActive(true);
			titleLabel.label.text = title;
		}
		else
		{
			titleLabel.gameObject.SetActive(false);
		}
		bodyLabel.label.text = message;
		currentDialogType = type;
		this.resultDelegate = resultDelegate;
		hasResult = false;
		buttonPanel.Clear();
		buttonPanel.gameObject.SetActive(true);
		inputBox.gameObject.SetActive(false);
		inputBox.characterCounterText.gameObject.SetActive(false);
		inputChanged = false;
		switch (type)
		{
		case ModalWindowType.OK:
			buttonPanel.AddButton("[O]K", true);
			break;
		case ModalWindowType.OKCancel:
		case ModalWindowType.OKCancelInput:
			buttonPanel.AddButton("[O]K", true);
			buttonPanel.AddButton("[C]ancel", false);
			if (type == ModalWindowType.OKCancelInput)
			{
				inputBox.gameObject.SetActive(true);
				buttonPanel.gameObject.SetActive(false);
				inputBox.placeholderText.text = defaultInput;
				inputBox.inputField.text = defaultInput;
				inputBox.label.text = defaultInput;
				focusOnInput = true;
				initialFocusOnInput = true;
				inputChanged = true;
			}
			break;
		case ModalWindowType.YesNo:
			buttonPanel.AddButton("[Y]es", true);
			buttonPanel.AddButton("[N]o", false);
			break;
		case ModalWindowType.YesNoCancel:
			buttonPanel.AddButton("[Y]es", true);
			buttonPanel.AddButton("[N]o", false);
			buttonPanel.AddButton("[C]ancel", false);
			break;
		case ModalWindowType.ContinueExit:
			buttonPanel.AddButton("[C]ontinue", true);
			buttonPanel.AddButton("[E]xit", false);
			break;
		}
		if (!inputBox.gameObject.activeSelf && defaultButtonWithFocus != 0)
		{
			for (int i = 0; i < defaultButtonWithFocus; i++)
			{
				buttonPanel.MoveFocusRight();
			}
		}
		GameAudio.Play2DSFX(GameAudio.SoundEnum.UIDialogShow);
		base.IsShowing = true;
	}

	public void CloseDialog()
	{
		hasResult = true;
		resultType = ModalWindowResult.Cancel;
		delayClose = 0.05f;
	}

	private void CloseDialogFinal()
	{
		if (screenDimImage != null)
		{
			screenDimImage.enabled = false;
		}
		base.gameObject.SetActive(false);
		base.IsShowing = false;
	}

	private void CloseDialogWithResult(ModalWindowResult result)
	{
		hasResult = false;
		CloseDialogFinal();
		if (resultDelegate != null)
		{
			if (currentDialogType != ModalWindowType.OKCancelInput)
			{
				resultDelegate(result, "INPUT NOT SUPPORTED");
			}
			else
			{
				resultDelegate(result, inputBox.label.text);
			}
		}
	}

	private char ValidateInput(string text, int charIndex, char addedChar)
	{
		bool flag = false;
		if (inputBox.inputField.text.Length >= inputBox.inputField.characterLimit)
		{
			flag = false;
		}
		else if ((addedChar >= '0' && addedChar <= '9') || (addedChar >= 'A' && addedChar <= 'Z') || (addedChar >= 'a' && addedChar <= 'z'))
		{
			flag = true;
		}
		if (flag)
		{
			inputChanged = true;
			return addedChar;
		}
		CommonAudioHelper.Instance.PlayErrorSound();
		return '\0';
	}
}
