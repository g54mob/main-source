using System.Collections;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class MailboxStartups : ActiveComponent
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

	[SceneBind("Mail/LoadingDisabled")]
	private Image _loadingDisabledImage;

	[SceneBind("ButtonOk")]
	private Button _buttonOk;

	[SceneBind("ButtonYes")]
	private Button _buttonYes;

	[SceneBind("HoverYes")]
	private Button HoverYes;

	[SceneBind("LearnedText")]
	private Text learnedText;

	[SceneBind("ButtonNo")]
	private Button _buttonNo;

	[SceneBind("ButtonTweet")]
	private Button _buttonTweet;

	[SceneBind("AttentionDelete/Hide")]
	public Toggle HideAcceptDelete;

	[SceneBind("AttentionDelete/Accept")]
	private Button AcceptStartupDelete;

	[SceneBind("AttentionDelete/Cancel")]
	private Button CancelStartupdelete;

	[SceneBind("AttentionDelete")]
	private Image Attention;

	[SceneBind("CashIndicator/Text")]
	private Text CashIndicator;

	[SceneBind("StartupsIndicator/Text")]
	private Text StartupsIndicator;

	private AlgoProject _data;

	private const float LOADING_TIME = 1f;

	private bool _isLoading;

	private float _currentTime;

	private bool _isActive;

	public bool denied;

	public State LastResultState;

	private string _lastTemplate = string.Empty;

	private Actions _actions;

	private int curIdDelete;

	private Startup curStartup;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		_buttonNo.onClick.AddListener(DeleteClick);
		_buttonYes.onClick.AddListener(OnYesClicked);
		_buttonOk.onClick.AddListener(OnYesClicked);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		_buttonTweet.gameObject.SetActive(value: false);
		AcceptStartupDelete.onClick.AddListener(DeleteStartupClick);
		HideAcceptDelete.onValueChanged.AddListener(HideDeleteClick);
		CancelStartupdelete.onClick.AddListener(DeleteStartupCancel);
		Attention.gameObject.SetActive(value: false);
		HoverYes.gameObject.SetActive(value: false);
	}

	private void OnTweetClicked()
	{
		_ = _data;
	}

	private void Resolve(State state)
	{
		LastResultState = state;
		Clear();
	}

	private void DeleteStartupClick()
	{
		denied = true;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Resolve(State.Denied);
		Attention.gameObject.SetActive(value: false);
	}

	private void DeleteStartupCancel()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Attention.gameObject.SetActive(value: false);
	}

	public void DeleteClick()
	{
		Attention.gameObject.SetActive(value: true);
		HideAcceptDelete.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.P.hideCancelStartup == 1)
		{
			DeleteStartupClick();
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Attention.gameObject.SetActive(value: true);
		Logic.UpdateGameSaves();
	}

	private void HideDeleteClick(bool click)
	{
		if (click)
		{
			ActiveComponent.Model.P.hideCancelStartup = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideCancelStartup = 0;
		}
		Logic.UpdateGameSaves();
	}

	private void OnYesClicked()
	{
		if (ActiveComponent.Model.curStartup.BaseMoney > ActiveComponent.Model.P.Money)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		else if (!ActiveComponent._controller.construction.gameObject.activeSelf && !ActiveComponent._controller.buy.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !ActiveComponent._controller._gameOverView.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyWindow.gameObject.activeSelf && !ActiveComponent._controller.nicknameController.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyStartup.gameObject.activeSelf && !ActiveComponent._controller.AttentionDay.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			Resolve(State.Accepted);
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
	}

	public void Init(Startup s)
	{
		HideAll();
		curStartup = s;
		_isLoading = true;
		_isActive = true;
		denied = false;
		LastResultState = State.Undefined;
		_currentTime = 0f;
		UpdateButtons(_actions);
	}

	public void Redraw()
	{
		CashIndicator.text = ActiveComponent.Model.P.moneyLetters.Count.ToString();
		CashIndicator.transform.parent.GetComponent<Image>().enabled = ActiveComponent.Model.P.moneyLetters.Count != 0;
		CashIndicator.enabled = ActiveComponent.Model.P.moneyLetters.Count != 0;
		StartupsIndicator.text = ActiveComponent.Model.P.startupQueue.Count.ToString();
		StartupsIndicator.transform.parent.GetComponent<Image>().enabled = ActiveComponent.Model.P.startupQueue.Count != 0;
		StartupsIndicator.enabled = ActiveComponent.Model.P.startupQueue.Count != 0;
		if (curStartup == null)
		{
			_bodyText.text = "";
			_buttonNo.gameObject.SetActive(value: false);
			_buttonYes.gameObject.SetActive(value: false);
			_fromText.gameObject.SetActive(value: false);
			_TaskText.gameObject.SetActive(value: false);
			_titleText.text = TextResources.GetString("emptymail");
			return;
		}
		HoverYes.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.curStartup != null)
		{
			HoverYes.gameObject.SetActive(ActiveComponent.Model.curStartup.BaseMoney > ActiveComponent.Model.P.Money);
		}
		_buttonYes.gameObject.SetActive(value: true);
		_buttonNo.gameObject.SetActive(value: true);
		_bodyText.text = TextResources.GetString(curStartup.KeyName).ToUpper();
		_TaskText.text = TextResources.GetString("AUDIENCE") + " : " + Logic.ColorTransform("WARNING", TextResources.GetString(curStartup.AudienceType));
		Text taskText = _TaskText;
		taskText.text = taskText.text + "\n" + TextResources.GetString("FIRST PAYMENT") + " : " + Logic.ColorTransform("MONEY", curStartup.BaseMoney + "$");
		_titleText.text = TextResources.GetString(curStartup.KeyName + "T").ToUpper();
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
		HoverYes.gameObject.SetActive(value: false);
	}

	private void ShowAll()
	{
		_bodyText.enabled = true;
		_titleText.enabled = true;
		_fromText.enabled = false;
		_TaskText.gameObject.SetActive(value: true);
		_TaskText.enabled = true;
		UpdateButtons(_actions);
		Redraw();
	}

	public void Clear()
	{
		HideAll();
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
