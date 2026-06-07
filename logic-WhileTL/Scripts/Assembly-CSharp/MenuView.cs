using System.Collections;
using Localization;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuView : ActiveComponent
{
	[SceneBind("Layer")]
	public Button _menuViewLayer;

	[SceneBind("Loading")]
	public RectTransform loading;

	[SceneBind("OverrideWindow")]
	public OverrideSaveView OverrideSaveView;

	[SceneBind("AttentionExit")]
	public RectTransform AttentionExit;

	[SceneBind("AttentionExit/Accept")]
	public Button AttentionExitAccept;

	[SceneBind("AttentionExit/Cancel")]
	public Button AttentionExitCancel;

	[SceneBind("Back")]
	public Button back;

	[SceneBind("ResetTutorials")]
	private Button Reset;

	[SceneBind("Save")]
	public Button Save;

	[SceneBind("Exit")]
	private Button Exit;

	[SceneBind("SavingMenu")]
	private Saving Saving;

	[SceneBind("SoundSlider")]
	public Slider SoundSlider;

	[SceneBind("MusicSlider")]
	public Slider Music;

	[SceneBind("Promocode")]
	public InputField Promocode;

	[SceneBind("HoverPromo")]
	public Image HoverPromo;

	[SceneBind("Check")]
	public Button Check;

	[SceneBind("HoverPromo/HoverText")]
	public Text HoverText;

	private bool exit;

	private string code;

	private Callback<FloatingGamepadTextInputDismissed_t> m_FloatingGamepadTextInputDismissed;

	private bool PromocodeWasFocused;

	private float startTimer = -1000f;

	private bool valueChangedOnFrame;

	private void SaveClick()
	{
		exit = false;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		OverrideSaveView.gameObject.SetActive(value: true);
		OverrideSaveView.Redraw(exit: false);
	}

	private void ResetTutorialsClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.P.evolveBtnTutorial = false;
		ActiveComponent.Model.P.startupConstructionTutorial = 0;
		ActiveComponent.Model.P.basicsTutorial = 0;
		ActiveComponent.Model.P.dropDownTutorial = 0;
		ActiveComponent.Model.P.memoryRNNTutorial = 0;
		ActiveComponent.Model.P.errorTutorial = 0;
		ActiveComponent.Model.P.serversTutorial = 0;
		ActiveComponent.Model.P.catHubTutorial = 0;
		ActiveComponent.Model.P.occAndAccTutorial = 0;
		ActiveComponent.Model.P.maintainAccLevelTutorial = 0;
		ActiveComponent.Model.P.timeTutorial = 0;
		ActiveComponent.Model.P.speedTutorial = 0;
		ActiveComponent.Model.P.copyTutorial = 0;
		ActiveComponent.Model.P.sandboxTutorial = 0;
		ActiveComponent.Model.P.startupTrainTutorial = 0;
		ActiveComponent.Model.P.lastEpochReachedTutorial = 0;
		ActiveComponent.Model.P.startupWeekTutorial = 0;
		if (ActiveComponent.Model.curPreview.startCheckpointKeyName == ActiveComponent._staticData.Checkpoints[0].KeyName)
		{
			ActiveComponent.Model.P.showCustom = 0;
		}
		ActiveComponent.Model.P.redUsersTurorial = 0;
		ActiveComponent.Model.P.elemHierTutorial = 0;
		ActiveComponent.Model.P.meetTheMLtutorial = 0;
		ActiveComponent.Model.P.geneticPopulationTutorial = 0;
		ActiveComponent.Model.P.mutationTutorial = 0;
		ActiveComponent.Model.P.shopTutorial = 0;
		ActiveComponent.Model.P.medalTutorial = 0;
		ActiveComponent.Model.P.lidarsSchemeTutorial = 0;
		ActiveComponent.Model.P.lidarTutorial = 0;
		ActiveComponent.Model.P.crossoverTutorial = 0;
		ActiveComponent.Model.P.mutationRateTutorial = 0;
		ActiveComponent.Model.P.comicsTutorialCompleted = false;
		ActiveComponent.Model.P.customTurorialGeneticWindow = 0;
		ActiveComponent.Model.P.startupComicsTutorial = 0;
		ActiveComponent.Model.P.sandboxTrainableTutorial = 0;
		Logic.UpdateGameSaves();
	}

	private void BackClick()
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		base.gameObject.SetActive(value: false);
	}

	public void Redraw()
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		ActiveComponent.Program.cursor.SetPosition(back.transform.position);
		OverrideSaveView.gameObject.SetActive(value: false);
	}

	private void ExitClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		ResetScene();
	}

	private void ResetScene()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		loading.gameObject.SetActive(value: true);
		Logic.UpdateGameSaves();
		StartCoroutine(WaitSomeTime());
	}

	public IEnumerator WaitSomeTime()
	{
		Resources.UnloadUnusedAssets();
		int i = 0;
		while (i < 30)
		{
			yield return new WaitForEndOfFrame();
			int num = i + 1;
			i = num;
		}
		ActiveComponent._controller.construction.OnUnInit();
		Logic.CreateReloadObject();
		SceneManager.LoadSceneAsync("loading");
	}

	private void CloseAttentionExit()
	{
		AttentionExit.gameObject.SetActive(value: false);
	}

	private void MusicChange(float val)
	{
		ActiveComponent.Model.globalSaves.musicVolume = val;
		ActiveComponent.Sound.SetVolume(SoundGroup.MUSIC, val);
	}

	private void SoundChange(float val)
	{
		ActiveComponent.Model.globalSaves.soundVolume = val;
		ActiveComponent.Sound.SetVolume(SoundGroup.UI, val);
		valueChangedOnFrame = true;
	}

	private void CodeChange(string val)
	{
		if (val != null)
		{
			code = val.ToLower();
		}
	}

	private void CheckCode()
	{
		if (Logic.IsSteamDeckRunning())
		{
			HoverPromo.gameObject.SetActive(value: false);
			return;
		}
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
				Logic.ApplyPromoCats();
				ActiveComponent.Model.P.curCat = ActiveComponent.Model.P.unlockedCatHats.Count - 1;
				ActiveComponent._controller.cat.Redraw();
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

	private void OnFloatingGamepadTextInputDismissed(FloatingGamepadTextInputDismissed_t pCallback)
	{
		string pchText = string.Empty;
		uint cchText = 0u;
		SteamUtils.GetEnteredGamepadTextInput(out pchText, cchText);
		Promocode.text = pchText;
		Promocode.OnDeselect(new BaseEventData(EventSystem.current));
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		loading.gameObject.SetActive(value: false);
		OverrideSaveView.Init();
		back.onClick.AddListener(BackClick);
		_menuViewLayer.onClick.AddListener(BackClick);
		Reset.onClick.AddListener(ResetTutorialsClick);
		Save.onClick.AddListener(SaveClick);
		Exit.onClick.AddListener(ExitClick);
		AttentionExitAccept.onClick.AddListener(ResetScene);
		AttentionExitCancel.onClick.AddListener(CloseAttentionExit);
		AttentionExit.gameObject.SetActive(value: false);
		OverrideSaveView.gameObject.SetActive(value: false);
		SoundSlider.onValueChanged.AddListener(SoundChange);
		Music.onValueChanged.AddListener(MusicChange);
		Saving.Init();
		HoverPromo.gameObject.SetActive(value: false);
		Promocode.onValueChanged.AddListener(CodeChange);
		Check.onClick.AddListener(CheckCode);
		SoundSystem sound = ActiveComponent.Sound;
		float value = (Music.value = ActiveComponent.Model.globalSaves.musicVolume);
		sound.SetVolume(SoundGroup.MUSIC, value);
		SoundSystem sound2 = ActiveComponent.Sound;
		value = (SoundSlider.value = ActiveComponent.Model.globalSaves.soundVolume);
		sound2.SetVolume(SoundGroup.UI, value);
		if (Logic.IsSteamDeckRunning())
		{
			Promocode.gameObject.SetActive(value: false);
			Check.gameObject.SetActive(value: false);
			HoverPromo.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (Input.GetMouseButtonUp(0) && valueChangedOnFrame)
		{
			valueChangedOnFrame = false;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			flag = true;
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			CheckCode();
		}
		if (ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks > 0)
			{
				return;
			}
			flag = true;
		}
		if (Promocode.gameObject.activeSelf)
		{
			if (Logic.IsSteamDeckRunning())
			{
				bool isFocused = Promocode.isFocused;
				if (isFocused && !PromocodeWasFocused)
				{
					SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, 0, 0, 0, 0);
				}
				if (isFocused != PromocodeWasFocused)
				{
					PromocodeWasFocused = isFocused;
				}
			}
			if (!Logic.IsSteamDeckRunning() && (ActiveComponent.Model.CurInputDeviceIsController || ActiveComponent.Model.globalSaves.ForcedVisualKeyBoard))
			{
				bool isFocused2 = Promocode.isFocused;
				if (isFocused2 && !PromocodeWasFocused)
				{
					ActiveComponent.Model.Keyboard.SetInput(Promocode);
				}
				if (isFocused2 != PromocodeWasFocused)
				{
					PromocodeWasFocused = isFocused2;
				}
			}
		}
		if (flag && !loading.gameObject.activeInHierarchy && OverrideSaveView.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			OverrideSaveView.gameObject.SetActive(value: false);
		}
		if (Promocode.gameObject.activeSelf && (double)(Time.time - startTimer) > 1.5)
		{
			HoverPromo.gameObject.SetActive(value: false);
		}
	}
}
