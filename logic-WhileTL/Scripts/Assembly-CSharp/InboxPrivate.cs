using System.Collections;
using System.Collections.Generic;
using App.Data;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class InboxPrivate : ActiveComponent
{
	[SceneBind("Scroll View/Viewport/Content")]
	private RectTransform Content;

	[SceneBind("FullWindow")]
	public Image FullWindow;

	[SceneBind("FullWindow/GoToTree")]
	private Button GoToTree;

	[SceneBind("FullWindow/From")]
	private Text From;

	[SceneBind("FullWindow/To")]
	private Text To;

	[SceneBind("FullWindow/Body")]
	private Text Body;

	[SceneBind("FullWindow/BodyMobile")]
	private Text BodyMobile;

	[SceneBind("FullWindow/Title")]
	private Text Title;

	[SceneBind("FullWindow/Acc")]
	private Text Acc;

	[SceneBind("FullWindow/Time")]
	private Text Time;

	[SceneBind("FullWindow/RewardValue")]
	private Text Reward;

	[SceneBind("FullWindow/ButtonYes")]
	private Button ButtonYes;

	[SceneBind("FullWindow/ButtonRework")]
	private Button ButtonRework;

	[SceneBind("FullWindow/ButtonPatch")]
	private Button ButtonPatch;

	[SceneBind("FullWindow/Back")]
	private Button Back;

	[SceneBind("FullWindow/MaxStartups")]
	private Text MaxStartups;

	[SceneBind("FullWindow/Date")]
	private Text Date;

	[SceneBind("UnreadMails")]
	private UnreadController UnreadMails;

	[SceneBind("UnreadStartups")]
	private UnreadController UnreadStartups;

	[SceneBind("UnreadMoneyLetters")]
	private UnreadController UnreadMoneyLetters;

	[SceneBind("FullWindow/TaskNum")]
	private Text TaskNum;

	[SceneBind("HideCompleted")]
	public Toggle HideCompleted;

	[SceneBind("FullWindow/MoneyLayer")]
	public Image MoneyLayer;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("Scroll View/Scrollbar Vertical")]
	public RectTransform Vertical;

	[SceneBind("View")]
	public RectTransform View;

	private Rect viewRect = Rect.zero;

	private GameObject privateObj;

	public State state;

	private List<GameObject> privates = new List<GameObject>();

	private int skipFrames;

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	private void Update()
	{
		if (base.IsInited)
		{
			skipFrames++;
			if (skipFrames == 5)
			{
				ScrollRect.enabled = Vertical.gameObject.activeSelf;
				sizeFilter.enabled = false;
				layoutGroup.enabled = false;
			}
		}
	}

	private void UpdateVisibilityOnScreen()
	{
		if (skipFrames < 5)
		{
			return;
		}
		foreach (GameObject @private in privates)
		{
			bool flag = viewRect.Contains(@private.transform.position);
			if (flag != @private.gameObject.activeSelf)
			{
				@private.gameObject.SetActive(flag);
			}
		}
	}

	private void OpenInbox(int ml, bool moveCursor = true)
	{
		HideCompleted.gameObject.SetActive(value: false);
		MoneyLayer.gameObject.SetActive(ActiveComponent.Model.P.moneyLetters[ml].Info == 0);
		base.transform.parent.GetComponent<InboxController>().HideBackBtn();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		FullWindow.gameObject.SetActive(value: true);
		ScrollRect.gameObject.SetActive(value: false);
		From.text = TextResources.GetString(ActiveComponent.Model.P.moneyLetters[ml].KeyName + "FROM");
		To.text = ActiveComponent.Model.P.playerUnit.name;
		Title.text = TextResources.GetString(ActiveComponent.Model.P.moneyLetters[ml].KeyName + "T");
		Body.text = TextResources.GetString(ActiveComponent.Model.P.moneyLetters[ml].KeyName);
		BodyMobile.text = TextResources.GetString(ActiveComponent.Model.P.moneyLetters[ml].KeyName);
		Reward.text = Logic.ColorTransform("MONEY", ActiveComponent.Model.P.moneyLetters[ml].Money + "$");
		Date.text = "";
		int money = ml;
		ButtonYes.gameObject.SetActive(value: true);
		if (ActiveComponent.Model.P.moneyLetters[ml].used == 1)
		{
			ButtonYes.gameObject.SetActive(value: false);
			if (moveCursor)
			{
				ActiveComponent.Program.cursor.SetPosition(Back.transform.position);
			}
		}
		else
		{
			ActiveComponent.Program.cursor.SetPosition(ButtonYes.transform.position);
			ButtonYes.onClick.RemoveAllListeners();
			ButtonYes.onClick.AddListener(delegate
			{
				AcceptMoney(money);
			});
		}
		if (ActiveComponent.Model.P.moneyLetters[ml].Info == 1)
		{
			ButtonYes.gameObject.SetActive(value: false);
			if (moveCursor)
			{
				ActiveComponent.Program.cursor.SetPosition(Back.transform.position);
			}
			ActiveComponent.Model.P.moneyLetters[ml].used = 1;
			CheckAchivment();
		}
		Reward.gameObject.SetActive(ActiveComponent.Model.P.moneyLetters[ml].Info == 0);
		ActiveComponent.Model.P.moneyLetters[ml].wasRead = 1;
		Logic.UpdateGameSaves();
		HideCompleted.gameObject.SetActive(value: false);
	}

	private void ChangeHide(bool click)
	{
		ActiveComponent.Model.P.hideOldPrivates = 0;
		if (click)
		{
			ActiveComponent.Model.P.hideOldPrivates = 1;
		}
		Redraw();
	}

	public IEnumerator WaitForUserAction()
	{
		while (state == State.Undefined)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	public void Redraw()
	{
		viewRect = Helper.GetWorldRect(View);
		ScrollRect.enabled = true;
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		foreach (GameObject @private in privates)
		{
			Object.Destroy(@private);
		}
		privates.Clear();
		for (int num = ActiveComponent.Model.P.moneyLetters.Count - 1; num >= 0; num--)
		{
			if (ActiveComponent.Model.P.hideOldPrivates != 1 || ActiveComponent.Model.P.moneyLetters[num].used != 1)
			{
				GameObject gameObject = Object.Instantiate(privateObj, Content.transform.position, Content.transform.rotation).gameObject;
				gameObject.transform.parent = Content.transform;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				PrivateController component = gameObject.GetComponent<PrivateController>();
				component.Init(ActiveComponent.Model.P.moneyLetters[num], num);
				int newI = num;
				gameObject.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenInbox(newI);
				});
				component.Read.onClick.AddListener(delegate
				{
					OpenInbox(newI);
				});
				component.WasRead.onClick.AddListener(delegate
				{
					OpenInbox(newI);
				});
				privates.Add(gameObject);
			}
		}
		state = State.Undefined;
		FullWindow.gameObject.SetActive(value: false);
		ScrollRect.gameObject.SetActive(value: true);
		UnreadMails.Num = Logic.GetCouUnreadTasks();
		ActiveComponent._controller.Unread.Num = Logic.GetUnreadLettersNum();
		UnreadMoneyLetters.Num = Logic.GetCouUnreadMoneyLetters();
		UnreadStartups.Num = Logic.GetCouUnreadStartups();
	}

	private void CheckAchivment()
	{
		if (ActiveComponent.Model.P.moneyLetters.Count < ActiveComponent._staticData.MoneyLetters.Count)
		{
			return;
		}
		foreach (MoneyLetter moneyLetter in ActiveComponent.Model.P.moneyLetters)
		{
			if (moneyLetter.used == 0)
			{
				return;
			}
		}
		Steam.UnlockAchievement("ACHIEVEMENT_18");
	}

	private void AcceptMoney(int ml)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.P.Money += ActiveComponent.Model.P.moneyLetters[ml].Money;
		ActiveComponent.Model.P.moneyLetters[ml].used = 1;
		UnreadMoneyLetters.Num = Logic.GetCouUnreadMoneyLetters();
		ActiveComponent._controller.Unread.Num = Logic.GetUnreadLettersNum();
		CheckAchivment();
		OpenInbox(ml, moveCursor: false);
		Logic.UpdateGameSaves();
	}

	public void BackClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		base.transform.parent.GetComponent<InboxController>().ShowBackBtn();
		FullWindow.gameObject.SetActive(value: false);
		ScrollRect.gameObject.SetActive(value: true);
		HideCompleted.gameObject.SetActive(value: true);
		Redraw();
	}

	private void OpenTaskOnTree()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OpenTaskOnTree);
		}
		else
		{
			BackClick();
			ActiveComponent._controller.CloseInbox();
			ActiveComponent._controller.OpenTree();
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ScrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		viewRect = Helper.GetWorldRect(View);
		sizeFilter = Content.GetComponent<ContentSizeFitter>();
		layoutGroup = Content.GetComponent<GridLayoutGroup>();
		GoToTree.onClick.AddListener(OpenTaskOnTree);
		privateObj = Resources.Load("Prefabs/MoneyObj") as GameObject;
		Back.onClick.AddListener(BackClick);
		UnreadMails.Init();
		UnreadMoneyLetters.Init();
		UnreadStartups.Init();
		HideCompleted.onValueChanged.AddListener(ChangeHide);
		BodyMobile.gameObject.SetActive(value: false);
	}
}
