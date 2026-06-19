using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
	public const float FADE_TIME = 0.5f;

	public const float STATIC_TIME = 1.5f;

	private float _fadeTime = 0.5f;

	private float _staticTime = 1.5f;

	private float _minWidth;

	private const int controllerDisconnectPriority = 999;

	private const int userSignedOutPriority = 1000;

	[Header("Settings:")]
	public readonly float heightPadPixels = 6f;

	public readonly float widthPadPixels = 10f;

	public float textBackgroundAlpha = 0.9f;

	public float backgroundAlpha;

	[Header("References:")]
	public PugText pugText;

	public SpriteRenderer textBackground;

	public SpriteRenderer blackTextBackground;

	public SpriteRenderer background;

	[SerializeField]
	private List<PopUpOption> options;

	private Fader fader;

	private bool _useUnscaledTime = true;

	private bool _menuInputCooldown;

	private Coroutine co;

	private bool fadeOutLocked;

	private Action<PopupResponse> _optionsCallback;

	public Transform optionsTransform;

	private int _priority;

	private bool _optionPressed;

	private Action warningCallBack;

	private float _Time
	{
		get
		{
			if (!_useUnscaledTime)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}
	}

	public bool IsOptionPressed => _optionPressed;

	public List<PopUpOption> Options => options;

	public PopUpOption popUpYesOption => options[1];

	public PopUpOption popUpNoOption => options[0];

	private void Awake()
	{
		fader = new Fader(0f, Fader.FadeFunction.Sin, _Time);
		textBackground.gameObject.SetActive(value: false);
		background.gameObject.SetActive(value: false);
		foreach (PopUpOption option in options)
		{
			option.PopupOptionActivated += OnPopupActivated;
		}
	}

	private void OnPopupActivated(PopUpOption source, PopupResponse response)
	{
		OptionPressed(response);
		Manager.menu.PopMenu();
		if (source.PopsAllMenus)
		{
			Manager.menu.PopAllMenus();
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	public void FadeOutCurrentDisplaySequence()
	{
		FadeOutCurrentDisplaySequence(_fadeTime);
	}

	public void FadeOutCurrentDisplaySequence(float fadeTime)
	{
		_fadeTime = fadeTime;
		if (!fadeOutLocked && co != null)
		{
			StopCoroutine(co);
			StartCoroutine(Co_FadeOut());
		}
	}

	public void StartNewDisplaySequence(string text, string[] formatFields = null, bool menuInputCooldown = true, float fadeTime = 0.5f, float staticTime = 1.5f, bool useUnscaledTime = true, float yPosition = 0f, float textBackgroundAlpha = 1f, bool localize = true, TextManager.FontFace fontFace = TextManager.FontFace.boldMedium, Action<PopupResponse> optionsCallback = null, List<string> options = null, float minWidth = 2f, float backgroundAlpha = 0f, int priority = 0, float textMaxWidth = 0f, bool secondOptionPopsAllMenus = false, bool pauseGame = true, bool holdToConfirm = false, bool localizePlaceholders = true, float accidentalInputBlockDuration = 1f)
	{
		if (_priority > priority && textBackground.gameObject.activeSelf)
		{
			return;
		}
		_optionPressed = false;
		_optionsCallback = optionsCallback;
		_menuInputCooldown = menuInputCooldown;
		popUpYesOption.SetPopsAllMenus(secondOptionPopsAllMenus);
		_priority = priority;
		if (_optionsCallback != null)
		{
			if (options == null)
			{
				Debug.LogError("PopUpText.StartNewDisplaySequence: options callback is defined but no options! Aborting.");
				return;
			}
			Manager.menu.ShowPopUpMenu(options);
			Manager.menu.GetTopMenu().pausesGame = pauseGame;
		}
		_minWidth = minWidth;
		base.transform.SetLocalPositionY(yPosition);
		base.enabled = true;
		if (co != null)
		{
			StopCoroutine(co);
			co = null;
		}
		_useUnscaledTime = useUnscaledTime;
		_fadeTime = fadeTime;
		_staticTime = staticTime;
		this.textBackgroundAlpha = textBackgroundAlpha;
		this.backgroundAlpha = backgroundAlpha;
		if (_menuInputCooldown)
		{
			Manager.input.StartMenuInputCooldown(_fadeTime);
		}
		pugText.gameObject.SetActive(value: true);
		pugText.localize = localize;
		pugText.localizePlaceholders = localizePlaceholders;
		pugText.SetText(text);
		pugText.formatFields = formatFields;
		pugText.SetFont(fontFace);
		pugText.maxWidth = textMaxWidth;
		pugText.Render();
		popUpYesOption.SetHoldToConfirm(holdToConfirm);
		popUpYesOption.SetBlockAccidentalInputDuration(accidentalInputBlockDuration);
		fadeOutLocked = false;
		background.gameObject.SetActive(value: true);
		textBackground.gameObject.SetActive(value: true);
		fader.FadeIn(_fadeTime, _Time);
		UpdateColorAndSize();
		co = StartCoroutine(Co_FadeIn(_optionsCallback != null));
	}

	private IEnumerator Co_FadeIn(bool isQuestionDialogue)
	{
		while (fader.IsFading())
		{
			UpdateColorAndSize();
			yield return Yielders.WaitForEndOfFrame();
		}
		if (!isQuestionDialogue)
		{
			if (_useUnscaledTime)
			{
				yield return Yielders.PauseUnscaled(_staticTime);
			}
			else
			{
				yield return Yielders.Pause(_staticTime);
			}
			yield return Co_FadeOut();
		}
	}

	private IEnumerator Co_FadeOut()
	{
		if (_menuInputCooldown)
		{
			Manager.input.StartMenuInputCooldown(_fadeTime);
		}
		fadeOutLocked = true;
		fader.FadeOut(_fadeTime, _Time);
		while (fader.IsFading())
		{
			UpdateColorAndSize();
			yield return Yielders.WaitForEndOfFrame();
		}
		Clear();
	}

	private void Clear()
	{
		if (co != null)
		{
			StopCoroutine(co);
			co = null;
		}
		fadeOutLocked = false;
		textBackground.gameObject.SetActive(value: false);
		background.gameObject.SetActive(value: false);
		popUpYesOption.SetHoldingToConfirm(isHoldingToConfirm: false);
		pugText.Clear();
		base.enabled = false;
	}

	private void UpdateColorAndSize()
	{
		float num = fader.UpdateFadeValue(_Time);
		float num2 = 2f - num;
		textBackground.color = textBackground.color.ColorWithNewAlpha(textBackgroundAlpha * num);
		background.color = background.color.ColorWithNewAlpha(backgroundAlpha * num);
		Vector2 vector = new Vector2(Mathf.Max(_minWidth, num2 * pugText.dimensions.width + 2f * widthPadPixels * 0.0625f), num2 * pugText.dimensions.height + 2f * heightPadPixels * 0.0625f);
		Vector3 localPosition = Vector3.zero;
		if (_optionsCallback != null)
		{
			float num3 = pugText.dimensions.height / 2f + 0.7f;
			optionsTransform.localPosition = new Vector3(0f, 0f - num3 - 0.5f, 0f);
			localPosition = new Vector3(0f, -0.9f, 0f);
			vector = new Vector2(vector.x, vector.y + 2f);
		}
		textBackground.size = new Vector2((float)(int)(vector.x * 10f) / 10f, (float)(int)(vector.y * 10f) / 10f);
		blackTextBackground.size = textBackground.size;
		textBackground.transform.localPosition = localPosition;
		pugText.SetTempColor(pugText.color.ColorWithNewAlpha(num));
	}

	public void OptionPressed(bool value)
	{
		OptionPressed(new PopupResponse(value ? 1 : 0));
	}

	public void OptionPressed(PopupResponse value)
	{
		if (_optionPressed)
		{
			Debug.LogError("option already pressed");
			return;
		}
		_optionPressed = true;
		_optionsCallback?.Invoke(value);
		co = StartCoroutine(Co_FadeOut());
	}

	public void ShowControllerDisconnectWarning()
	{
		if (_priority <= 999 || !textBackground.gameObject.activeSelf)
		{
			ShowWarningAndWaitForInput("noControllerWarning", 999, ControllerDisconnectWarningCallBack);
		}
	}

	private void ControllerDisconnectWarningCallBack()
	{
	}

	public void ShowUserSignedOutWarning()
	{
		if (_priority <= 1000 || !textBackground.gameObject.activeSelf)
		{
			ShowWarningAndWaitForInput("signedOutWarning", 1000, UserSignedOutWarningCallBack);
		}
	}

	private void UserSignedOutWarningCallBack()
	{
		Manager.load.QueueScene("Title", 0f, 0.5f, FadePresets.blackToBlack);
	}

	private void ShowWarningAndWaitForInput(string text, int priority, Action closedCallBack = null)
	{
		warningCallBack = closedCallBack;
		List<string> list = new List<string> { "cancelDialogue" };
		StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 2f, 1f, localize: true, TextManager.FontFace.boldMedium, WarningCallBack, list, 2f, 0.95f, priority);
	}

	private void WarningCallBack(PopupResponse response)
	{
		warningCallBack?.Invoke();
		warningCallBack = null;
	}
}
