using System.Collections;
using System.Collections.Generic;
using App.Data;
using Aux;
using Localization;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : ActiveComponent
{
	[SceneBind("BtnsHolder/NewGame")]
	public Button NewGame;

	[SceneBind("BtnsHolder/LoadGame")]
	public Button LoadGame;

	[SceneBind("BtnsHolder/LoadGame/Text")]
	public Text LoadGameText;

	[SceneBind("BtnsHolder/Continue")]
	private Button Continue;

	[SceneBind("BtnsHolder/Community")]
	public Button Community;

	[SceneBind("BtnsHolder/AchivementsButton")]
	public Button AchivementsButton;

	[SceneBind("BtnsHolder/ReviewButton")]
	public Button ReviewButton;

	[SceneBind("BtnsHolder/ContinueHover")]
	private Image ContinueHover;

	[SceneBind("BtnsHolder/Exit")]
	private Button Exit;

	[SceneBind("NewGameWindow")]
	private NewGameView NewGameWindow;

	[SceneBind("BtnsHolder/Settings")]
	public Button Settings;

	[SceneBind("LoadGameWindow")]
	private LoadGameView LoadGameWindow;

	[SceneBind("SettingsWindow")]
	public SettingsWindow SettingsWindow;

	[SceneBind("EducationalWindow")]
	private Image EducationalWindow;

	[SceneBind("EducationalWindow/Close")]
	private Button EducationalWindowClose;

	[SceneBind("CommunityWindow")]
	private CommunityWindow CommunityWindow;

	[SceneBind("AchivementWindow")]
	private AchivementView AchivementsWindow;

	[SceneBind("HoverLoadMenu")]
	private Image HoverLoad;

	[SceneBind("AttentionContinue")]
	private Image AttentionContinue;

	[SceneBind("AttentionContinue/Accept")]
	private Button AttentionContinueAccept;

	[SceneBind("AttentionContinue/Cancel")]
	private Button AttentionContinueCancel;

	[SceneBind("AttentionQuit")]
	private Transform AttentionQuit;

	[SceneBind("AttentionQuit/Accept")]
	private Button AttentionQuitAccept;

	[SceneBind("AttentionQuit/Cancel")]
	private Button AttentionQuitCancel;

	[SceneBind("Promocode")]
	public InputField Promocode;

	[SceneBind("HoverPromo")]
	public Image HoverPromo;

	[SceneBind("Check")]
	public Button Check;

	[SceneBind("Discord")]
	public UrlButton Discord;

	[SceneBind("Survey")]
	public UrlButton Survey;

	[SceneBind("HoverPromo/HoverText")]
	public Text HoverText;

	[SceneBind("IntroScreen", true)]
	public IntroView introView;

	[SceneBind("BtnsHolder/OutroButton")]
	public Button outroButton;

	[SceneBind("BtnsHolder/EduBtn")]
	private Button EduBtn;

	[SceneBind("Outro")]
	private OutroController outro;

	[SceneBind("Loading")]
	public RectTransform loading;

	[SceneBind("SavingLayer")]
	public Saving SavingLayer;

	private Controller controller;

	private MessageBox.Result MessageBoxSaveGameClicked = new MessageBox.Result();

	private MessageBox.Result MessageBoxSaveStorageClicked = new MessageBox.Result();

	private MessageBox.Result MessageBoxCloudSyncClicked = new MessageBox.Result();

	public Dictionary<string, GameObject> Themes = new Dictionary<string, GameObject>();

	private string loadPath = "";

	private float startTimer = -1000f;

	private string code;

	public bool mainMenuInited;

	public Texture2D SteamDeckCursor;

	private void CheckEsc()
	{
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			flag = true;
		}
		if (ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks > 0)
			{
				return;
			}
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		if (NewGameWindow.checkpointView.gameObject.activeSelf)
		{
			NewGameWindow.checkpointView.CloseClick();
		}
		else if (NewGameWindow.AttentionRewrite.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
			NewGameWindow.AttentionRewrite.gameObject.SetActive(value: false);
		}
		else if (AttentionContinue.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
			AttentionContinue.gameObject.SetActive(value: false);
		}
		else if (NewGameWindow.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
			NewGameWindow.gameObject.SetActive(value: false);
		}
		else if (LoadGameWindow.gameObject.activeSelf && !LoadGameWindow.attentionRewrite.gameObject.activeSelf && !LoadGameWindow.AttentionDelete.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
			LoadGameWindow.gameObject.SetActive(value: false);
		}
		else
		{
			if (LoadGameWindow.gameObject.activeSelf)
			{
				return;
			}
			if (SettingsWindow.gameObject.activeSelf && !SettingsWindow.AttentionDelete.gameObject.activeSelf)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
				SettingsWindow.gameObject.SetActive(value: false);
			}
			else if (!SettingsWindow.gameObject.activeSelf)
			{
				if (CommunityWindow.gameObject.activeSelf)
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
					CommunityWindow.gameObject.SetActive(value: false);
				}
				else if (EducationalWindow.gameObject.activeSelf)
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
					EducationalWindow.gameObject.SetActive(value: false);
				}
				else if (AchivementsWindow.gameObject.activeSelf)
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
					AchivementsWindow.gameObject.SetActive(value: false);
				}
				else if (outro.gameObject.activeSelf)
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
					outro.gameObject.SetActive(value: false);
				}
			}
		}
	}

	private void CloseAll()
	{
		NewGameWindow.gameObject.SetActive(value: false);
		LoadGameWindow.gameObject.SetActive(value: false);
		SettingsWindow.gameObject.SetActive(value: false);
		CommunityWindow.gameObject.SetActive(value: false);
		EducationalWindow.gameObject.SetActive(value: false);
		outro.gameObject.SetActive(value: false);
		AchivementsWindow.gameObject.SetActive(value: false);
	}

	private void NewGameClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseAll();
		NewGameWindow.gameObject.SetActive(value: true);
		NewGameWindow.Redraw(startNew: true);
		Redraw();
	}

	private void OpenEduWindow()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseAll();
		EducationalWindow.gameObject.SetActive(value: true);
		Redraw();
	}

	private void LoadGameClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseAll();
		LoadGameWindow.gameObject.SetActive(value: true);
		Redraw();
		LoadGameWindow.Redraw();
	}

	private void SettingsClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseAll();
		SettingsWindow.gameObject.SetActive(value: true);
		SettingsWindow.RedrawRewiredStates();
		Redraw();
	}

	private void StartOutro()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Story");
		CloseAll();
		outro.Init();
		Redraw();
	}

	private void AchivementButtonClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseAll();
		AchivementsWindow.Init();
	}

	private void CommunityClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseAll();
		CommunityWindow.gameObject.SetActive(value: true);
		CommunityWindow.Redraw();
		Redraw();
	}

	private IEnumerator ContinueClick()
	{
		loading.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetActive(state: false);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		outro.gameObject.SetActive(value: false);
		AchivementsWindow.gameObject.SetActive(value: false);
		string text = "";
		foreach (PreviewData item in ActiveComponent.Model.globalSaves.Preview)
		{
			if (item.isLastRun == 1)
			{
				text = item.saveName;
				ActiveComponent.Model.curPreview = item;
			}
		}
		string saveNameTemplate = Logic.GetSaveNameTemplate(playerPostfix: false);
		ActiveComponent.Model.globalSaves.Preview.ForEach(delegate(PreviewData i)
		{
			i.isLastRun = 0;
		});
		int num = ActiveComponent.Model.globalSaves.Preview.FindIndex((PreviewData x) => x.autoSaved == 1 && x.showName == ActiveComponent.Model.curPreview.showName);
		PreviewData previewData = ((num == -1) ? null : ActiveComponent.Model.globalSaves.Preview[num]);
		if (previewData == null)
		{
			previewData = new PreviewData();
			previewData.saveName = "PLAYER" + ActiveComponent.Model.globalSaves.newGames;
			ActiveComponent.Model.globalSaves.newGames++;
			previewData.autoSaved = 1;
			ActiveComponent.Model.globalSaves.Preview.Add(previewData);
			num = ActiveComponent.Model.globalSaves.Preview.Count - 1;
		}
		Logic.WriteSaveGame(saveNameTemplate + previewData.saveName, Logic.LoadSaveGame(saveNameTemplate + ActiveComponent.Model.curPreview.saveName));
		string saveName = previewData.saveName;
		previewData = Logic.DeserializeObject<PreviewData>(Logic.SerializeObject(ActiveComponent.Model.curPreview));
		previewData.saveName = saveName;
		previewData.autoSaved = 1;
		ActiveComponent.Model.globalSaves.Preview[num] = previewData;
		ActiveComponent.Model.curPreview = previewData;
		Logic.UpdateGlobalSaves();
		loadPath = "WTL_saves_game_id" + text;
		StartCoroutine(WaitOneFrame());
		yield return null;
	}

	public IEnumerator WaitOneFrame()
	{
		ActiveComponent.Program.cursor.SetActive(state: false);
		ActiveComponent.Model.LoadingSave = true;
		int i = 0;
		while (i < 30)
		{
			yield return new WaitForEndOfFrame();
			int num = i + 1;
			i = num;
		}
		ActiveComponent._controller.Run(loadPath);
		Redraw();
		base.gameObject.SetActive(value: false);
	}

	private void AttentionContinueYes()
	{
		ActiveComponent.Model.LoadingSave = true;
		ActiveComponent.Program.cursor.SetActive(state: false);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		string text = "";
		foreach (PreviewData item in ActiveComponent.Model.globalSaves.Preview)
		{
			if (item.isLastRun == 1)
			{
				text = item.saveName;
				ActiveComponent.Model.curPreview = item;
			}
		}
		Logic.UpdateGlobalSaves();
		ActiveComponent._controller.Run("WTL_saves_game_id" + text);
		Redraw();
		base.gameObject.SetActive(value: false);
		AttentionContinue.gameObject.SetActive(value: false);
	}

	private void AttentionContinueNo()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionContinue.gameObject.SetActive(value: false);
	}

	private void ExitClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		Logic.UpdateGlobalSaves();
		try
		{
			Steam.ForceShutdown();
		}
		catch
		{
		}
		Application.Quit();
	}

	private void CloudSaveClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		if (Steam.IsCloudEnabled())
		{
			MessageBoxSaveGameClicked = MessageBox.Warning("SAVEGAMETYPEHD", "SAVEGAMECAUTIONHD", MessageBox.Features.None);
		}
		else
		{
			MessageBoxSaveGameClicked = MessageBox.Warning("SAVEGAMETYPECLOUD", "SAVEGAMECAUTIONCLOUD", MessageBox.Features.None);
		}
	}

	public void Redraw()
	{
		ContinueHover.gameObject.SetActive(ActiveComponent.Model.globalSaves.Preview.Count == 0);
		Continue.gameObject.SetActive(ActiveComponent.Model.globalSaves.Preview.Count != 0);
		foreach (PreviewData item in ActiveComponent.Model.globalSaves.Preview)
		{
			if (item.isLastRun == 1 && item.buggleScore > 0)
			{
				return;
			}
		}
		ContinueHover.gameObject.SetActive(value: true);
		Continue.gameObject.SetActive(value: false);
	}

	private void CheckCode()
	{
		bool flag = Logic.WasPromoCode(code);
		if (Logic.CheckPromoCode(code))
		{
			if (flag)
			{
				HoverText.text = Logic.ColorTransform("WARNING", TextResources.GetString("PROMOWAS"));
			}
			else
			{
				HoverText.text = Logic.GetPromoText(code);
			}
			Promocode.text = "";
		}
		else
		{
			HoverText.text = Logic.ColorTransform("BAD", TextResources.GetString("PROMOERROR"));
		}
		startTimer = Time.time;
		HoverPromo.gameObject.SetActive(value: true);
	}

	private void CodeChange(string val)
	{
		code = val.ToLower();
	}

	private void RunReplay(string replayName)
	{
		NewGameWindow.checkpointView.CheckpointClick(0, 0, rewrite: false);
		ActiveComponent._controller.Run("WTL_saves", replayName);
	}

	public void ActiveTheme(string KeyName)
	{
		foreach (KeyValuePair<string, GameObject> theme in Themes)
		{
			theme.Value.gameObject.SetActive(value: false);
		}
		Themes[KeyName.ToLower()].gameObject.SetActive(value: true);
	}

	protected override void OnInit()
	{
		mainMenuInited = false;
		GameObject[] array = GameObject.FindGameObjectsWithTag("SecondaryCamera");
		GameObject.Find("Main Camera").GetComponent<Camera>();
		GameObject[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].GetComponent<Camera>().aspect = (float)Screen.width / (float)Screen.height;
		}
		bool flag = (PlayerPrefs.GetInt("WTL_options") & 2) != 0;
		bool flag2 = Steam.IsCloudEnabled();
		if (flag && !flag2)
		{
			MessageBox.Warning("SAVEGAMECLOUDONLY", "SAVEGAMECLOUDONLYINFO");
		}
		else if (!flag && flag2)
		{
			MessageBoxCloudSyncClicked = MessageBox.Warning("SAVEGAMELOCALONLY", "SAVEGAMELOCALONLYINFO", MessageBox.Features.None);
		}
		if (Steam.IsAvailable())
		{
			GameObject gameObject = GameObject.Find("SaveGameHD");
			if ((bool)gameObject)
			{
				gameObject.GetComponent<Button>().onClick.AddListener(CloudSaveClick);
			}
			gameObject = GameObject.Find("SaveGameCloud");
			if ((bool)gameObject)
			{
				gameObject.GetComponent<Button>().onClick.AddListener(CloudSaveClick);
			}
		}
		SetSaveModeCloud(Steam.IsCloudEnabled(), promptCloudSync: false);
		SceneBindContainer.BindObjects(this, base.transform);
		SavingLayer.gameObject.SetActive(value: false);
		ActiveComponent.Program.mainMenu.loading.gameObject.SetActive(value: false);
		Survey.Init();
		Discord.Init();
		Continue.onClick.AddListener(delegate
		{
			StartCoroutine(ContinueClick());
		});
		NewGame.onClick.AddListener(NewGameClick);
		Check.onClick.AddListener(CheckCode);
		HoverPromo.gameObject.SetActive(value: false);
		Promocode.onValueChanged.AddListener(CodeChange);
		Exit.onClick.AddListener(ExitClick);
		outro.Init();
		outro.gameObject.SetActive(value: false);
		outroButton.onClick.AddListener(StartOutro);
		if (ActiveComponent.Model.globalSaves.maxLockedZoom < 0f)
		{
			ActiveComponent.Model.globalSaves.maxLockedZoom = ActiveComponent._staticData.Settings.ZoomClickHoverValueMobile;
			ActiveComponent.Model.globalSaves.enableLockZoom = false;
		}
		ActiveComponent.Model.globalSaves.maxLockedZoom = Mathf.Max(ActiveComponent._staticData.Settings.MinZoom, ActiveComponent.Model.globalSaves.maxLockedZoom);
		ActiveComponent.Model.globalSaves.maxLockedZoom = Mathf.Min(ActiveComponent._staticData.Settings.MaxLockInterractZoom, ActiveComponent.Model.globalSaves.maxLockedZoom);
		CommunityWindow.Init();
		CommunityWindow.gameObject.SetActive(value: false);
		AchivementsWindow.gameObject.SetActive(value: false);
		for (int num = 0; num < ActiveComponent.Model.globalSaves.Preview.Count; num++)
		{
			if (ActiveComponent.Model.globalSaves.Preview[num].buggleScore <= 0)
			{
				ActiveComponent.Model.globalSaves.Preview.RemoveAt(num);
				num--;
			}
		}
		NewGameWindow.Init();
		NewGameWindow.gameObject.SetActive(value: false);
		EducationalWindow.gameObject.SetActive(value: false);
		EducationalWindowClose.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
			ActiveComponent.Program.cursor.SetPosition(EduBtn.transform.position);
			EducationalWindow.gameObject.SetActive(value: false);
		});
		LoadGameWindow.Init();
		introView.Init();
		introView.gameObject.SetActive(value: false);
		LoadGameWindow.gameObject.SetActive(value: false);
		EduBtn.onClick.AddListener(OpenEduWindow);
		LoadGame.onClick.AddListener(LoadGameClick);
		Community.onClick.AddListener(CommunityClick);
		AchivementsButton.onClick.AddListener(AchivementButtonClick);
		HoverLoad.gameObject.SetActive(value: false);
		ActiveComponent.Model.globalSaves.version = Program.GetVersionString();
		AttentionContinueAccept.onClick.AddListener(AttentionContinueYes);
		AttentionContinueCancel.onClick.AddListener(AttentionContinueNo);
		AttentionContinue.gameObject.SetActive(value: false);
		Settings.onClick.AddListener(SettingsClick);
		Survey.gameObject.SetActive(value: false);
		new List<string>();
		array2 = GameObject.FindGameObjectsWithTag("THEME");
		foreach (GameObject i2 in array2)
		{
			if (ActiveComponent._staticData.Themes.FindIndex((BaseItem j) => j.KeyName.ToLower() == i2.name.ToLower()) >= 0)
			{
				Themes.Add(i2.name.ToLower(), i2);
				i2.gameObject.SetActive(value: false);
			}
		}
		foreach (BaseItem theme in ActiveComponent._staticData.Themes)
		{
			if (!theme.isPromo && !ActiveComponent.Model.globalSaves.unlockedMainThemes.Contains(theme.KeyName.ToLower()))
			{
				ActiveComponent.Model.globalSaves.unlockedMainThemes.Add(theme.KeyName.ToLower());
			}
		}
		for (int num2 = 0; num2 < ActiveComponent.Model.globalSaves.unlockedPromoCats.Count; num2++)
		{
			ActiveComponent.Model.globalSaves.unlockedPromoCats[num2] = ActiveComponent.Model.globalSaves.unlockedPromoCats[num2].ToLower();
		}
		for (int num3 = 0; num3 < ActiveComponent.Model.globalSaves.unlockedMainThemes.Count; num3++)
		{
			ActiveComponent.Model.globalSaves.unlockedMainThemes[num3] = ActiveComponent.Model.globalSaves.unlockedMainThemes[num3].ToLower();
		}
		ActiveComponent.Model.globalSaves.activeTheme = ActiveComponent.Model.globalSaves.activeTheme.ToLower();
		if (ActiveComponent.Model.globalSaves.useRandomTheme)
		{
			int count = ActiveComponent.Model.globalSaves.unlockedMainThemes.Count;
			ActiveComponent.Model.globalSaves.activeTheme = ActiveComponent.Model.globalSaves.unlockedMainThemes[Random.Range(0, count)];
		}
		SettingsWindow.Init();
		SettingsWindow.gameObject.SetActive(value: false);
		ActiveTheme(ActiveComponent.Model.globalSaves.activeTheme);
		string text = Commandline.GetString(0);
		if (!History.IsReplayFile(text))
		{
			text = Commandline.GetString(1);
			if (!History.IsReplayFile(text))
			{
				text = Commandline.GetString("-replay");
			}
		}
		if (text.Length > 0)
		{
			RunReplay(text);
			return;
		}
		Redraw();
		base.gameObject.transform.root.GetComponent<Canvas>().pixelPerfect = ActiveComponent.Model.globalSaves.video == 0;
		if (ActiveComponent.Model.firstLoad)
		{
			if (ActiveComponent.Model.globalSaves.unlockedPromoCats.Count > 0)
			{
				Steam.UnlockAchievement("ACHIEVEMENT_16");
			}
			Logic.CheckEpochAchivments();
			if (ActiveComponent.Model.globalSaves.passedTasks.ContainsKey(ActiveComponent._staticData.Epochs[ActiveComponent._staticData.Epochs.Count - 1].End))
			{
				Steam.UnlockAchievement("ACHIEVEMENT_9");
			}
			if (ActiveComponent.Model.globalSaves.passedTasks.ContainsKey("G/B DIVIDE"))
			{
				Steam.UnlockAchievement("ACHIEVEMENT_3");
			}
		}
		Promocode.gameObject.SetActive(value: false);
		Check.gameObject.SetActive(value: false);
		foreach (DateEvent dateEvent in ActiveComponent._staticData.DateEvents)
		{
			if (dateEvent.IsValid() && ActiveComponent.Model.firstLoad)
			{
				Steam.UnlockAchievement(dateEvent.Achievement);
			}
		}
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		if (ActiveComponent.Model.firstLoad)
		{
			foreach (string gainedAchivement in ActiveComponent.Model.globalSaves.gainedAchivements)
			{
				Steam.UnlockAchievement(gainedAchivement);
			}
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Music_For_Menu", SoundGroup.MUSIC, loop: true, ActiveComponent.Model.globalSaves.musicVolume);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Music_For_Story", SoundGroup.MUSIC, loop: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Music_For_Gameplay", SoundGroup.MUSIC, loop: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Music_For_Gameplay", SoundGroup.MUSIC, loop: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Music_For_Story", SoundGroup.MUSIC, loop: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Music_For_Gameplay", SoundGroup.MUSIC, loop: true);
		ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Menu");
		if (ActiveComponent.Model.globalSaves.showOutro)
		{
			ActiveComponent.Model.globalSaves.showOutro = false;
			StartOutro();
		}
		QualitySettings.asyncUploadBufferSize = 4;
		Rect worldRect = Helper.GetWorldRect(base.transform.root.GetComponent<RectTransform>());
		GameObject gameObject2 = GameObject.Find("CanvasScaleTemplate");
		Rect worldRect2 = Helper.GetWorldRect(gameObject2.GetComponent<RectTransform>());
		float num4 = Mathf.Min(worldRect.width / worldRect2.width, worldRect.height / worldRect2.height);
		RectTransform component = base.transform.parent.GetComponent<RectTransform>();
		float num5 = base.transform.root.localScale.x;
		if (num4 < 1f)
		{
			gameObject2.transform.localScale *= num4;
			ActiveComponent.Model.spriteRenderScale = num4;
			num5 *= num4;
		}
		Vector2 sizeDelta = new Vector2(worldRect.width / num5, worldRect.height / num5);
		component.sizeDelta = sizeDelta;
		num5 = (Model.sizeMultCoef = num5 * ActiveComponent._controller.GameScreen.transform.localScale.x);
		sizeDelta = new Vector2(worldRect.width / num5, worldRect.height / num5);
		ActiveComponent._controller.SizeHelper.sizeDelta = sizeDelta;
		outro.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(worldRect.width / num5, worldRect.height / num5);
		if (!ActiveComponent.Model.firstLoad)
		{
			Logic.SendAnalytics("APP_START", new Dictionary<string, object>
			{
				{
					"version",
					Program.GetShortVersion()
				},
				{
					"cohort_day",
					ActiveComponent.Model.globalSaves.cohort_day
				},
				{
					"user_id_ab",
					ActiveComponent.Model.globalSaves.user_id_ab
				}
			});
		}
		Redraw();
		MoveCursorToBtn();
		if (!ActiveComponent.Model.firstLoad)
		{
			ActiveComponent.Program.cursor.SetPosition(LoadGame.transform.position);
		}
		mainMenuInited = true;
		if (ActiveComponent.Model.globalSaves.ForcedDisableController && !Logic.IsSteamDeckRunning())
		{
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Debug.LogError("C");
			Logic.GetModel().CurInputDeviceIsController = false;
			Cursor.SetCursor(ActiveComponent.Program.cursor.cursorSprite, Vector2.zero, CursorMode.Auto);
			Cursor.visible = true;
			ActiveComponent.Program.cursor.curImg.enabled = false;
		}
		if (Logic.IsSteamDeckRunning())
		{
			Cursor.SetCursor(SteamDeckCursor, Vector2.zero, CursorMode.Auto);
			Cursor.visible = true;
			Model.steamDeckRunning = true;
			GameObject.Find("SaveGameHD").gameObject.SetActive(value: false);
			GameObject.Find("SaveGameCloud").gameObject.SetActive(value: false);
		}
		ActiveComponent.Model.ReadyToPlay = true;
		ReviewButton.onClick.AddListener(OpenSteamReview);
	}

	private void OpenSteamReview()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Application.OpenURL("steam://openurl/https://store.steampowered.com/app/619150/#review_create");
	}

	public void MoveCursorToBtn()
	{
		if (ContinueHover.gameObject.activeSelf)
		{
			if (ActiveComponent.Model.globalSaves.Preview.Count == 0)
			{
				ActiveComponent.Program.cursor.SetPosition(NewGame.transform.position);
			}
			else
			{
				ActiveComponent.Program.cursor.SetPosition(LoadGame.transform.position);
			}
		}
		else
		{
			ActiveComponent.Program.cursor.SetPosition(Continue.transform.position);
		}
	}

	private void SetSaveModeCloud(bool state, bool promptCloudSync = true)
	{
		GameObject gameObject = GameObject.Find("SaveGameHD");
		GameObject gameObject2 = GameObject.Find("SaveGameCloud");
		if ((bool)gameObject2 && (bool)gameObject)
		{
			Image component = gameObject.GetComponent<Image>();
			Button component2 = gameObject.GetComponent<Button>();
			Image component3 = gameObject2.GetComponent<Image>();
			Button component4 = gameObject2.GetComponent<Button>();
			bool flag = (component2.enabled = !state);
			component.enabled = flag;
			flag = (component4.enabled = state);
			component3.enabled = flag;
			ActiveComponent.Model.globalSaves.Set(SaveFlags.CloudSync, state);
			Steam.SetCloudEnabled(state);
			if (state && promptCloudSync)
			{
				MessageBoxSaveStorageClicked = MessageBox.Info("SAVESSYNCTOCLOUD", "SAVESSYNCTOCLOUDINFO", MessageBox.Features.Confirm);
			}
		}
	}

	private bool IsSaveModeCloud()
	{
		GameObject gameObject = GameObject.Find("SaveGameCloud");
		if (!gameObject)
		{
			return false;
		}
		return gameObject.GetComponent<Image>().enabled;
	}

	private bool SyncSaves()
	{
		string text = Logic.LoadLocalSaveGame("WTL_saves_global");
		if (text == null)
		{
			return false;
		}
		if (text.Length > 0)
		{
			HashSet<int> hashSet = new HashSet<int>();
			GlobalSaves globalSaves = JsonConvert.DeserializeObject<GlobalSaves>(text);
			if (globalSaves.Preview != null)
			{
				for (int i = 0; i < globalSaves.Preview.Count; i++)
				{
					if (globalSaves.Preview[i] == null)
					{
						globalSaves.Preview.RemoveAt(i);
						i--;
					}
				}
				foreach (PreviewData item in globalSaves.Preview)
				{
					if (item != null)
					{
						hashSet.Add(item.GetHash());
					}
				}
				for (int j = 0; j < globalSaves.Preview.Count; j++)
				{
					if (j < ActiveComponent.Model.globalSaves.Preview.Count)
					{
						PreviewData s = ActiveComponent.Model.globalSaves.Preview[j];
						int num = Helper.VersionStringToInt(s.version);
						if (!hashSet.Add(s.GetHash()))
						{
							PreviewData previewData = globalSaves.Preview.Find((PreviewData previewData2) => previewData2.GetHash() == s.GetHash());
							if (previewData != null && previewData.version != null && (Helper.VersionStringToInt(previewData.version) > num || previewData.date > s.date))
							{
								s = previewData;
								Debug.LogError("!!! Save collision overwritten with newer: " + s.date.AsString() + " -> " + previewData.date.AsString());
							}
						}
					}
					else
					{
						ActiveComponent.Model.globalSaves.Preview.Add(globalSaves.Preview[j]);
					}
				}
			}
		}
		Logic.UpdateGlobalSaves();
		if (Logic.SyncLocalSavesWithCloud() != Steam.GetNumSavesInCloud())
		{
			Debug.LogError("WTF?");
			return false;
		}
		return true;
	}

	private void Update()
	{
		if (base.IsInited)
		{
			if (MessageBoxSaveGameClicked.Yes())
			{
				bool flag = IsSaveModeCloud();
				SetSaveModeCloud(!flag);
			}
			if (MessageBoxSaveStorageClicked.Yes())
			{
				SyncSaves();
			}
			if (MessageBoxCloudSyncClicked.Yes())
			{
				SyncSaves();
			}
			CheckEsc();
			if (base.IsInited && Promocode.gameObject.activeSelf && (double)(Time.time - startTimer) > 1.5)
			{
				HoverPromo.gameObject.SetActive(value: false);
			}
		}
	}
}
