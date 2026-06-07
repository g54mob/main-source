using System.Collections;
using System.Collections.Generic;
using App.Data;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class ComicsController : ActiveComponent
{
	[SceneBind("Ok")]
	private Button okBtn;

	[SceneBind("Slides")]
	private Transform slidersHolder;

	[SceneBind("ChooseWindow")]
	public Transform ChooseWindow;

	[SceneBind("NextClick")]
	private Button NextClick;

	[SceneBind("ChooseWindow/Header/Text")]
	private Text chooseWindowHeader;

	[SceneBind("ChooseWindow/Body/ComicsText")]
	private Text chooseWindowText;

	[SceneBind("ChooseWindow/Body/ProgressText")]
	private Text chooseWindowProgress;

	[SceneBind("ChooseWindow/Body/Exit")]
	private Button exitButton;

	[SceneBind("ChooseWindow/Body/Bronze")]
	private Button BronzeChooseWindow;

	[SceneBind("ChooseWindow/Body/Silver")]
	private Button SilverChooseWindow;

	[SceneBind("ChooseWindow/Body/Gold")]
	private Button GoldChooseWindow;

	[SceneBind("ChooseWindow/Body/Silver/ScoreSlider")]
	private BoundedSlider SilverScoreSlider;

	[SceneBind("ChooseWindow/Body/Gold")]
	private BoundedSlider GoldScoreSlider;

	[SceneBind("ChooseWindow/Body/EpochScoreSlider")]
	public BoundedSlider EpochScoreSlider;

	[SceneBind("SpeedLayerIphoneX")]
	private RectTransform speedLayerIphoneX;

	[SceneBind("SpeedLayer/MinusTime")]
	private Button prevPageButton;

	[SceneBind("SpeedLayer")]
	private RectTransform speedLayer;

	[SceneBind("SpeedLayer/PlusTime")]
	private Button nextButton;

	[SceneBind("Tutorial")]
	private TutorialList tutorial;

	[SceneBind("SlideText")]
	private Text slideTextHolder;

	private Sprite[] sprites;

	private Image[] slides;

	private string[] slideTexts;

	private int currentSlide;

	private List<Button> medalButtons = new List<Button>();

	private Comics comics;

	private int maxSprite;

	private Color greenColor;

	private Color redColor;

	private Color greyColor;

	private List<Sprite> emptyMedalSprites = new List<Sprite>();

	private Sprite bronzeMedalSprite;

	private Sprite silverMedalSprite;

	private Sprite goldMedalSprite;

	private RectTransform lastTutorialButton;

	private bool enableMobileSwipe;

	private bool chooseWereActive;

	private int CurrentSprite
	{
		get
		{
			return currentSlide;
		}
		set
		{
			value = Mathf.Max(0, value);
			value = Mathf.Min(sprites.Length - 1, value);
			int num = currentSlide % slides.Length;
			int num2 = currentSlide / slides.Length;
			int num3 = value % slides.Length;
			int num4 = value / slides.Length;
			if (num2 != num4)
			{
				for (int i = 0; i < Mathf.Min(slides.Length, sprites.Length - num4 * slides.Length); i++)
				{
					slides[i].sprite = sprites[num4 * slides.Length + i];
				}
			}
			for (int j = num; j <= num3; j++)
			{
				slides[j].gameObject.SetActive(value: true);
			}
			for (int k = num3 + 1; k <= num; k++)
			{
				slides[k].gameObject.SetActive(value: false);
			}
			currentSlide = value;
			maxSprite = Mathf.Max(maxSprite, value);
			if (maxSprite == sprites.Length - 1)
			{
				okBtn.GetComponent<Image>().color = greenColor;
				okBtn.GetComponentInChildren<Text>().text = TextResources.GetString("COMPLETE_COMICS");
				okBtn.gameObject.SetActive(value: true);
				ActiveComponent.Model.P.completedComicses.Add(comics.KeyName);
			}
			slideTextHolder.text = slideTexts[value];
		}
	}

	private void SetPrevNextButtonIntercatible()
	{
		Helper.ButtonInteractible(prevPageButton, CurrentSprite >= slides.Length, greenColor, greyColor);
		Helper.ButtonInteractible(nextButton, CurrentSprite < sprites.Length - 1, greenColor, greyColor);
	}

	private void PrevPage()
	{
		if (CurrentSprite >= 6 && CurrentSprite >= slides.Length && prevPageButton.interactable)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			CurrentSprite -= CurrentSprite % slides.Length + 1;
			SetPrevNextButtonIntercatible();
		}
	}

	private void Next()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (CurrentSprite == maxSprite)
		{
			int currentSprite = CurrentSprite + 1;
			CurrentSprite = currentSprite;
		}
		else
		{
			CurrentSprite = Mathf.Min(CurrentSprite + slides.Length, maxSprite);
		}
		SetPrevNextButtonIntercatible();
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		slides = slidersHolder.GetComponentsInChildren<Image>();
		okBtn.onClick.AddListener(delegate
		{
			QuestLine.UpdateComicsesScore();
			base.gameObject.SetActive(value: false);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			comics.End();
		});
		BronzeChooseWindow.onClick.AddListener(delegate
		{
			MedalClick(1);
		});
		SilverChooseWindow.onClick.AddListener(delegate
		{
			MedalClick(2);
		});
		GoldChooseWindow.onClick.AddListener(delegate
		{
			MedalClick(3);
		});
		medalButtons.Add(BronzeChooseWindow);
		medalButtons.Add(SilverChooseWindow);
		medalButtons.Add(GoldChooseWindow);
		prevPageButton.onClick.AddListener(PrevPage);
		NextClick.onClick.AddListener(delegate
		{
			if (!ActiveComponent.Model.CurInputDeviceIsController)
			{
				Next();
			}
		});
		nextButton.onClick.AddListener(Next);
		exitButton.onClick.AddListener(delegate
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Gameplay");
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
		});
		greenColor = Logic.GetColor("GREEN");
		redColor = Logic.GetColor("RED");
		greyColor = Logic.GetColor("GREY");
		emptyMedalSprites.Add(Logic.LoadSprite("EPOCH_BRONZE_LOCKED"));
		emptyMedalSprites.Add(Logic.LoadSprite("EPOCH_SILVER_LOCKED"));
		emptyMedalSprites.Add(Logic.LoadSprite("EPOCH_GOLD_LOCKED"));
		bronzeMedalSprite = Logic.LoadSprite("EPOCH_BRONZE");
		silverMedalSprite = Logic.LoadSprite("EPOCH_SILVER");
		goldMedalSprite = Logic.LoadSprite("EPOCH_GOLD");
		lastTutorialButton = tutorial.GetComponentsInChildren<Button>()[^1].GetComponent<RectTransform>();
		tutorial.Init();
		tutorial.gameObject.SetActive(value: false);
		EpochScoreSlider.gameObject.SetActive(value: false);
	}

	private string[] GetSlideTexts(int id)
	{
		string[] texts = comics.GetTexts(id);
		for (int i = 1; i < texts.Length; i++)
		{
			if (texts[i] == null)
			{
				texts[i] = ((i % slides.Length == 0) ? "" : texts[i - 1]);
			}
		}
		return texts;
	}

	private void MedalClick(int id)
	{
		Logic.SendAnalytics("COMICS_COMICS_OPEN", new Dictionary<string, object>
		{
			{ "keyName", comics.KeyName },
			{ "medal", id }
		});
		comics.UpdateComicsState();
		QuestLine.SetCurrentQuest(comics.KeyName);
		QuestLine.GetCurrentQuest().SetOpened(state: true);
		okBtn.gameObject.SetActive(ActiveComponent.Model.P.completedComicses.Contains(comics.KeyName));
		ChooseWindow.gameObject.SetActive(value: false);
		slidersHolder.gameObject.SetActive(value: true);
		prevPageButton.gameObject.SetActive(value: true);
		nextButton.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetPosition(nextButton.transform.position);
		slideTextHolder.gameObject.SetActive(value: true);
		slidersHolder.gameObject.transform.localScale = Vector3.one + Vector3.one * (slideTextHolder.gameObject.GetComponent<RectTransform>().rect.width - 1078f) * 0.0005f;
		sprites = comics.GetSprites(id);
		slideTexts = GetSlideTexts(id);
		Image[] array = slides;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < Mathf.Min(sprites.Length, slides.Length); j++)
		{
			slides[j].sprite = sprites[j];
		}
		maxSprite = (currentSlide = 0);
		CurrentSprite = 0;
		SetPrevNextButtonIntercatible();
	}

	public void ExitClick()
	{
		base.gameObject.SetActive(value: false);
	}

	protected override void RightSwipe()
	{
		PrevPage();
	}

	protected override void LeftSwipe()
	{
		Next();
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			if (CurrentSprite >= slides.Length)
			{
				PrevPage();
			}
		}
		else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && CurrentSprite < sprites.Length - 1)
		{
			Next();
		}
		if (!ChooseWindow.gameObject.activeSelf && ActiveComponent.Model.CurInputDeviceIsController && base.gameObject.activeInHierarchy && ActiveComponent.Program.joyInput.lmbUp && Helper.GetWorldRect(NextClick.GetComponent<RectTransform>()).Contains(Logic.GetMouseInWorld()))
		{
			Next();
		}
	}

	private IEnumerator WaitForTutorialEnd()
	{
		yield return tutorial.WaitForUserAction();
		tutorial.gameObject.SetActive(value: false);
		Logic.GetModel().P.comicsTutorialCompleted = true;
	}

	public void Init(Comics comics)
	{
		base.Init();
		this.comics = comics;
		dragDistance = (float)Screen.height * 5f / 100f;
		okBtn.GetComponent<Image>().color = redColor;
		okBtn.GetComponentInChildren<Text>().text = TextResources.GetString("SKIP_COMICS");
		if (comics.StoryComics)
		{
			MedalClick(3);
			return;
		}
		chooseWereActive = true;
		slideTextHolder.gameObject.SetActive(value: false);
		okBtn.gameObject.SetActive(value: false);
		prevPageButton.gameObject.SetActive(value: false);
		nextButton.gameObject.SetActive(value: false);
		ChooseWindow.gameObject.SetActive(value: true);
		slidersHolder.gameObject.SetActive(value: false);
		int[] scoresBorderInt = comics.ScoresBorderInt;
		GameObject gameObject = Helper.GetObjFromResources("Prefabs/LineOnSlider") as GameObject;
		Vector2 sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
		sizeDelta.y = EpochScoreSlider.GetComponent<RectTransform>().sizeDelta.y;
		gameObject.GetComponent<RectTransform>().sizeDelta = sizeDelta;
		EpochScoreSlider.SetUpBounds(comics.ScoresBorderInt, Logic.ColorsArray, matchToBounds: false, gameObject);
		EpochScoreSlider.maxValue = scoresBorderInt[2];
		EpochScoreSlider.minValue = scoresBorderInt[0];
		int sumComicsScore = comics.GetSumComicsScore();
		EpochScoreSlider.value = sumComicsScore;
		SilverScoreSlider.minValue = scoresBorderInt[0];
		SilverScoreSlider.maxValue = scoresBorderInt[1];
		GoldScoreSlider.minValue = scoresBorderInt[0];
		GoldScoreSlider.maxValue = scoresBorderInt[2];
		SilverScoreSlider.value = sumComicsScore;
		GoldScoreSlider.value = sumComicsScore;
		SilverScoreSlider.gameObject.SetActive((float)sumComicsScore < SilverScoreSlider.maxValue);
		GoldScoreSlider.gameObject.SetActive((float)sumComicsScore < GoldScoreSlider.maxValue);
		chooseWindowText.text = TextResources.GetString(comics.Texts);
		Helper.ButtonInteractible(BronzeChooseWindow, interactible: true, bronzeMedalSprite, emptyMedalSprites[0]);
		Helper.ButtonInteractible(SilverChooseWindow, interactible: true, silverMedalSprite, emptyMedalSprites[1]);
		Helper.ButtonInteractible(GoldChooseWindow, interactible: true, goldMedalSprite, emptyMedalSprites[2]);
		ActiveComponent.Program.cursor.SetPosition(GoldChooseWindow.transform.position);
		if (EpochScoreSlider.value != EpochScoreSlider.maxValue)
		{
			Helper.ButtonInteractible(BronzeChooseWindow, interactible: false, bronzeMedalSprite, emptyMedalSprites[0]);
			Helper.ButtonInteractible(SilverChooseWindow, interactible: false, silverMedalSprite, emptyMedalSprites[1]);
			Helper.ButtonInteractible(GoldChooseWindow, interactible: false, goldMedalSprite, emptyMedalSprites[2]);
			if (EpochScoreSlider.value >= (float)scoresBorderInt[0])
			{
				Helper.ButtonInteractible(BronzeChooseWindow, interactible: true, bronzeMedalSprite, emptyMedalSprites[0]);
				ActiveComponent.Program.cursor.SetPosition(BronzeChooseWindow.transform.position);
			}
			if (EpochScoreSlider.value >= (float)scoresBorderInt[1])
			{
				Helper.ButtonInteractible(SilverChooseWindow, interactible: true, silverMedalSprite, emptyMedalSprites[1]);
				ActiveComponent.Program.cursor.SetPosition(SilverChooseWindow.transform.position);
			}
		}
		if (!Logic.GetModel().P.comicsTutorialCompleted && comics.KeyName == "ANTIQC" && !Logic.GetModel().globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TutorialPopup");
		}
	}
}
