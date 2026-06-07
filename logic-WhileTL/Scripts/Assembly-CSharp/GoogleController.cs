using System;
using System.Collections.Generic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class GoogleController : ActiveComponent
{
	[SceneBind("SearchLineInputField")]
	public InputField searchLineInputField;

	[SceneBind("SearchLineInputField/Placeholder")]
	public Text searchLinePlaceholder;

	[SceneBind("MessagesScrollView/Viewport/Content")]
	public Transform scrollViewContent;

	[SceneBind("MessagesScrollView")]
	public ScrollRect scrollRect;

	[SceneBind("CloseButton")]
	public Button closeButton;

	[SceneBind("F5")]
	public Button F5;

	[SceneBind("NextClickHolder")]
	public Button NextClickHolder;

	[SceneBind("Header")]
	public Text headerText;

	[SceneBind("ExitButton")]
	public Button exitButton;

	[SceneBind("MessagesScrollView/Scrollbar Vertical")]
	public Scrollbar scrollbar;

	public ForumQuest forumQuest;

	private ForumMessageController messagePrefab;

	public Color buttonDisabledColor;

	public Color exitButtonActiveColor;

	public Color closeButtonActiveColor;

	private float timeInactive;

	private int placeholderCurrentSymbol;

	private string placeholderText;

	private int placeholderThreshold;

	private Action exitCallback;

	private bool moveToNext;

	private float oldHeight;

	private int steps;

	private List<ForumMessageController> msgs = new List<ForumMessageController>();

	private int curMsg;

	public string SearchLine
	{
		get
		{
			return searchLineInputField.text;
		}
		set
		{
			searchLineInputField.text = value;
		}
	}

	private void ResetContent()
	{
		Vector3 localPosition = scrollViewContent.localPosition;
		localPosition.y = 0f;
		scrollViewContent.localPosition = localPosition;
	}

	private void Close()
	{
		base.gameObject.SetActive(value: false);
		exitCallback();
	}

	public void Init(ForumQuest forumQuest, Action exitCallback)
	{
		base.Init();
		this.exitCallback = exitCallback;
		this.forumQuest = forumQuest;
		headerText.gameObject.SetActive(value: false);
		headerText.text = forumQuest.GetThemeName();
		closeButton.gameObject.SetActive(value: false);
		SearchLine = "";
		searchLineInputField.interactable = true;
		InitMessages();
		F5.gameObject.SetActive(value: false);
		NextClickHolder.gameObject.SetActive(value: false);
		searchLineInputField.onValueChanged.RemoveAllListeners();
		searchLineInputField.onValueChanged.AddListener(SearchLineListener);
		closeButton.gameObject.SetActive(value: false);
		exitButton.gameObject.SetActive(forumQuest.exitActive);
		ResetContent();
		scrollbar.value = 1f;
		closeButton.onClick.RemoveAllListeners();
		closeButton.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
			if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
			{
				ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
				ActiveComponent._controller.Transition.ActiveOnFade(Close);
			}
			else
			{
				Close();
			}
		});
		closeButton.GetComponentInChildren<Text>().text = forumQuest.ButtonText;
		timeInactive = 0f;
		scrollbar.transform.parent.gameObject.SetActive(value: false);
		if (forumQuest.scrollToMsg != 0)
		{
			SearchLineListener(forumQuest.SearchQuery);
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
		}
		else
		{
			searchLinePlaceholder.text = "";
			placeholderCurrentSymbol = 0;
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", ActiveComponent.Model.globalSaves.soundVolume);
		}
		ActiveComponent.Program.cursor.SetPosition(F5.transform.position);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		buttonDisabledColor = Logic.GetColor("GREY");
		exitButtonActiveColor = Logic.GetColor("RED");
		closeButtonActiveColor = Logic.GetColor("GREEN");
		F5.onClick.AddListener(AddNextMsg);
		NextClickHolder.onClick.AddListener(AddNextMsg);
		messagePrefab = Resources.Load<ForumMessageController>(Logic.GetPrefabPath("Message"));
		exitButton.onClick.AddListener(delegate
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent._controller.Tree.Redraw();
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		});
		placeholderText = TextResources.GetString("ENTER_REQUEST");
		scrollbar.onValueChanged.AddListener(delegate(float x)
		{
			if ((double)x < 1E-05)
			{
				closeButton.gameObject.SetActive(curMsg == forumQuest.Messages.Length);
			}
		});
	}

	public void SearchLineListener(string s)
	{
		SearchLine = forumQuest.SearchQuery.Substring(0, s.Length);
		if (s.Length == forumQuest.SearchQuery.Length)
		{
			searchLineInputField.onValueChanged.RemoveAllListeners();
			searchLineInputField.interactable = false;
			scrollbar.transform.parent.gameObject.SetActive(value: true);
			headerText.gameObject.SetActive(value: true);
			closeButton.gameObject.SetActive(value: false);
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
			F5.gameObject.SetActive(value: true);
			NextClickHolder.gameObject.SetActive(value: true);
		}
		timeInactive = 0f;
	}

	private void Update()
	{
		if (moveToNext)
		{
			if (curMsg != forumQuest.Messages.Length)
			{
				Vector2 anchoredPosition = scrollRect.content.anchoredPosition;
				anchoredPosition.y = (messagePrefab.GetComponent<RectTransform>().sizeDelta.y + scrollRect.content.GetComponent<VerticalLayoutGroup>().spacing) * (float)curMsg * 100f;
				scrollRect.content.anchoredPosition = anchoredPosition;
			}
			else
			{
				Vector2 anchoredPosition2 = scrollRect.content.anchoredPosition;
				anchoredPosition2.y = (messagePrefab.GetComponent<RectTransform>().sizeDelta.y + scrollRect.content.GetComponent<VerticalLayoutGroup>().spacing) * (float)curMsg * 100f;
				scrollRect.content.anchoredPosition = anchoredPosition2;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape) && exitButton.gameObject.activeSelf)
		{
			exitButton.onClick.Invoke();
			return;
		}
		if (ActiveComponent.Program != null && ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks > 0)
			{
				return;
			}
			if (exitButton.gameObject.activeSelf)
			{
				exitButton.onClick.Invoke();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.F5) && F5.gameObject.activeInHierarchy)
		{
			AddNextMsg();
		}
	}

	private void FixedUpdate()
	{
		if (!base.IsInited || closeButton.gameObject.activeSelf)
		{
			return;
		}
		if (searchLineInputField.text.Length < forumQuest.SearchQuery.Length)
		{
			if (placeholderCurrentSymbol < placeholderText.Length)
			{
				placeholderThreshold = (placeholderThreshold + 1) % 2;
				if (placeholderThreshold % 2 == 0)
				{
					if (forumQuest.autoTyping)
					{
						searchLineInputField.text += "*";
					}
					else
					{
						searchLinePlaceholder.text += placeholderText[placeholderCurrentSymbol++];
					}
				}
			}
			else
			{
				ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
			}
		}
		timeInactive += Time.fixedDeltaTime;
		if (timeInactive >= ActiveComponent._staticData.Settings.GoogleWindowInactiveTime)
		{
			SearchLine = forumQuest.SearchQuery;
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
		}
	}

	private void AddNextMsg()
	{
		if (curMsg != forumQuest.Messages.Length)
		{
			NextClickHolder.gameObject.SetActive(value: true);
			oldHeight = (messagePrefab.GetComponent<RectTransform>().sizeDelta.y + scrollRect.content.GetComponent<VerticalLayoutGroup>().spacing) * (float)curMsg;
			GameObject gameObject = UnityEngine.Object.Instantiate(messagePrefab.gameObject, scrollViewContent);
			msgs.Add(gameObject.GetComponent<ForumMessageController>());
			msgs.LastItem().Init(forumQuest.Messages[curMsg]);
			curMsg++;
			moveToNext = true;
			closeButton.gameObject.SetActive(curMsg == forumQuest.Messages.Length);
			steps = 0;
		}
	}

	public void InitMessages()
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
		foreach (ForumMessageController msg in msgs)
		{
			UnityEngine.Object.Destroy(msg.gameObject);
		}
		msgs.Clear();
		curMsg = 0;
		for (int i = 0; i < forumQuest.scrollToMsg + 1; i++)
		{
			AddNextMsg();
		}
	}
}
