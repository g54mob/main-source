using System.Collections;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class MailboxMoney : ActiveComponent
{
	[SceneBind("Mail/FromText")]
	private Text _fromText;

	[SceneBind("Mail/TitleText")]
	private Text _titleText;

	[SceneBind("Mail/TaskText")]
	private Text _TaskText;

	[SceneBind("Mail/BodyText")]
	private Text _bodyText;

	[SceneBind("Mail/Loading")]
	private Image _loadingImage;

	[SceneBind("CashIndicator/Text")]
	private Text CashIndicator;

	[SceneBind("StartupsIndicator/Text")]
	private Text StartupsIndicator;

	[SceneBind("Mail/LoadingDisabled")]
	private Image _loadingDisabledImage;

	[SceneBind("ButtonOk")]
	private Button _buttonOk;

	[SceneBind("ButtonYes")]
	private Button _buttonYes;

	[SceneBind("LearnedText")]
	private Text learnedText;

	[SceneBind("ButtonNo")]
	private Button _buttonNo;

	[SceneBind("ButtonTweet")]
	private Button _buttonTweet;

	private AlgoProject _data;

	private const float LOADING_TIME = 1f;

	private bool _isLoading;

	private float _currentTime;

	private bool _isActive;

	public State LastResultState;

	private string _lastTemplate = string.Empty;

	private Actions _actions;

	public bool acceptCash;

	private MoneyLetter curLetter;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		acceptCash = false;
		_buttonNo.onClick.AddListener(OnNoClicked);
		_buttonYes.onClick.AddListener(OnYesClicked);
		_buttonOk.onClick.AddListener(OnYesClicked);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		_fromText.text = TextResources.GetString("emptymail");
		_buttonNo.GetComponentInChildren<Text>().text = TextResources.GetString("no").ToUpper();
		_buttonNo.gameObject.SetActive(value: false);
		_buttonOk.GetComponentInChildren<Text>().text = TextResources.GetString("ok").ToUpper();
		_buttonTweet.gameObject.SetActive(value: false);
	}

	private void OnTweetClicked()
	{
		_ = _data;
	}

	private void Resolve(State state)
	{
		LastResultState = state;
	}

	private void OnNoClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Resolve(State.Denied);
	}

	private void OnYesClicked()
	{
		if (!ActiveComponent._controller.construction.gameObject.activeSelf && !ActiveComponent._controller.buy.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !ActiveComponent._controller._gameOverView.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyWindow.gameObject.activeSelf && !ActiveComponent._controller.nicknameController.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyStartup.gameObject.activeSelf && !ActiveComponent._controller.AttentionDay.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			acceptCash = true;
			Resolve(State.Accepted);
			ActiveComponent.Model.P.Money += curLetter.Money;
		}
	}

	private void OnTimeout()
	{
	}

	private void UpdateButtons(Actions actions)
	{
		_bodyText.gameObject.SetActive(value: true);
		_titleText.gameObject.SetActive(value: true);
		_TaskText.gameObject.SetActive(value: true);
		_fromText.gameObject.SetActive(value: false);
		Redraw();
	}

	public void Redraw()
	{
		CashIndicator.text = ActiveComponent.Model.P.moneyLetters.Count.ToString();
		CashIndicator.transform.parent.GetComponent<Image>().enabled = ActiveComponent.Model.P.moneyLetters.Count != 0;
		CashIndicator.enabled = ActiveComponent.Model.P.moneyLetters.Count != 0;
		StartupsIndicator.text = ActiveComponent.Model.P.startupQueue.Count.ToString();
		StartupsIndicator.transform.parent.GetComponent<Image>().enabled = ActiveComponent.Model.P.startupQueue.Count != 0;
		StartupsIndicator.enabled = ActiveComponent.Model.P.startupQueue.Count != 0;
		if (curLetter == null)
		{
			_bodyText.text = "";
			_buttonNo.gameObject.SetActive(value: false);
			_buttonYes.gameObject.SetActive(value: false);
			_fromText.gameObject.SetActive(value: false);
			_TaskText.gameObject.SetActive(value: false);
			_titleText.text = TextResources.GetString("emptymail");
			acceptCash = false;
		}
		else
		{
			acceptCash = false;
			_buttonYes.gameObject.SetActive(value: true);
			_bodyText.text = TextResources.GetString(curLetter.KeyName).ToUpper();
			_TaskText.text = TextResources.GetString("MONEY") + " : " + Logic.ColorTransform("MONEY", curLetter.Money + "$");
			_titleText.text = TextResources.GetString(curLetter.KeyName + "T").ToUpper();
		}
	}

	public void Init(MoneyLetter letter)
	{
		HideAll();
		curLetter = letter;
		_isLoading = true;
		_isActive = true;
		LastResultState = State.Undefined;
		_currentTime = 0f;
	}

	private void HideAll()
	{
		_bodyText.enabled = false;
		_TaskText.enabled = false;
		_titleText.enabled = false;
		_fromText.enabled = false;
		_buttonNo.gameObject.SetActive(value: false);
		_buttonYes.gameObject.SetActive(value: false);
		_buttonTweet.gameObject.SetActive(value: false);
		_buttonOk.gameObject.SetActive(value: false);
	}

	private void ShowAll()
	{
		_bodyText.enabled = true;
		_titleText.enabled = true;
		_fromText.enabled = true;
		_TaskText.gameObject.SetActive(value: true);
		_TaskText.enabled = true;
		UpdateButtons(_actions);
	}

	public void Clear()
	{
		HideAll();
		acceptCash = false;
		_loadingImage.enabled = false;
		_loadingDisabledImage.enabled = true;
		_isLoading = false;
		_isActive = false;
		_actions = Actions.Undefined;
		_data = null;
		UpdateButtons(_actions);
	}

	public IEnumerator WaitForUserAction()
	{
		while (LastResultState == State.Undefined)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			OnYesClicked();
		}
		if (base.IsEnabled && _isActive && _isLoading)
		{
			_currentTime += Time.deltaTime;
			float num = _currentTime / 1f;
			_loadingImage.fillAmount = num;
			_loadingDisabledImage.enabled = true;
			_loadingImage.enabled = true;
			if (num > 1f)
			{
				_isLoading = false;
				_loadingImage.enabled = false;
				_loadingDisabledImage.enabled = false;
				ShowAll();
			}
		}
	}
}
