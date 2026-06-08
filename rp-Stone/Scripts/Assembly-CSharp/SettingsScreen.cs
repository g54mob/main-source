using UnityEngine;

public class SettingsScreen : DialogNineSlice
{
	private enum Mode
	{
		Audio = 0,
		Video = 1,
		Input = 2,
		Extras = 3
	}

	public SettingsToggleButton toggleButtonPrefab;

	public AsciiString musicLabel;

	public AsciiString sfxLabel;

	public AsciiString ambianceLabel;

	public AsciiString backgroundSfxLabel;

	public AsciiString backgroundSfxLabel2;

	public AsciiString fullScreenLabel;

	public AsciiString antiAliasLabel;

	public AsciiString screenFlashLabel;

	public AsciiString cameraShakeLabel;

	public AsciiString scrollWheelSpeedLabel;

	public AsciiString scrollInvertLabel;

	public int toggleOffsetX = -3;

	public int toggleOffsetY = 1;

	public Slider musicSlider;

	public Slider sfxSlider;

	public Slider ambianceSlider;

	public Slider scrollWheelSpeedSlider;

	public AsciiString discordAddress;

	public AsciiString qqAddress;

	public AsciiString supportEmail;

	public AsciiString copyright;

	public HyperlinkButton discordHyperlink;

	public HyperlinkButton qqHyperlink;

	public DialogButton closeButton;

	public ComboBox resolutionComboBox;

	public DialogButton subscriptionButton;

	private ToggleButtonGroup tabGroup;

	private const string musicKey = "settings_music_enabled";

	private const string sfxKey = "settings_sfx_enabled";

	private const string ambianceKey = "settings_ambiance_enabled";

	private const string MUSIC_VOLUME = "settings_music_volume";

	private const string SFX_VOLUME = "settings_sfx_volume";

	private const string AMBIANCE_VOLUME = "settings_ambiance_volume";

	private const string SCROLL_SPEED = "settings_input_scroll_speed";

	private const string SCROLL_INVERT = "settings_input_scroll_invert";

	private SettingsToggleButton backgroundSfxButton;

	private SettingsToggleButton fullScreenButton;

	private SettingsToggleButton antiAliasButton;

	private SettingsToggleButton screenFlashButton;

	private SettingsToggleButton cameraShakeButton;

	private SettingsToggleButton scrollInvertButton;

	private SettingsToggleButton musicOnOffButton;

	private SettingsToggleButton sfxOnOffButton;

	private SettingsToggleButton ambianceOnOffButton;

	private bool simplifiedChineseMode;

	private Mode mode { get; set; }

	public virtual void Show()
	{
		base.SetState(State.In);
		UpdateAudioUI();
		UpdateVideoUI();
		UpdateInputUI();
		UpdateExtrasUI();
		simplifiedChineseMode = Te.id == "ZH-CN";
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
		SaveSettings();
		SettingsResolutions.singleton.Save();
		AdditionalSettings.Save();
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		tabGroup.UpdateTic();
		if (closeButton != null)
		{
			closeButton.UpdateTic();
		}
		if (mode == Mode.Audio)
		{
			musicSlider.UpdateTic();
			sfxSlider.UpdateTic();
			ambianceSlider.UpdateTic();
			backgroundSfxButton.UpdateTic();
		}
		else if (mode == Mode.Video)
		{
			fullScreenButton.UpdateTic();
			if (fullScreenButton.isOn != Screen.fullScreen)
			{
				fullScreenButton.isOn = Screen.fullScreen;
			}
			antiAliasButton.UpdateTic();
			screenFlashButton.UpdateTic();
			cameraShakeButton.UpdateTic();
			if (resolutionComboBox != null)
			{
				resolutionComboBox.UpdateTic();
			}
		}
		else if (mode == Mode.Input)
		{
			scrollWheelSpeedSlider.UpdateTic();
			scrollInvertButton.UpdateTic();
		}
		else
		{
			_ = mode;
			_ = 3;
		}
		if (simplifiedChineseMode)
		{
			qqHyperlink.UpdateTic();
		}
		else
		{
			discordHyperlink.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY;
		tabGroup.Draw(r, offsetX, offsetY);
		if (closeButton != null)
		{
			closeButton.Draw(r, offsetX, offsetY);
		}
		if (simplifiedChineseMode)
		{
			qqAddress.Draw(r, r.width / 2, r.height - 5);
			qqHyperlink.Draw(r, r.width / 2, r.height - 5);
		}
		else
		{
			discordAddress.Draw(r, r.width / 2, r.height - 5);
			discordHyperlink.Draw(r, r.width / 2, r.height - 5);
		}
		supportEmail.Draw(r, r.width / 2, r.height - 3);
		copyright.Draw(r, r.width / 2, r.height - 2);
		if (mode == Mode.Audio)
		{
			musicLabel.Draw(r, offsetX, offsetY);
			sfxLabel.Draw(r, offsetX, offsetY);
			ambianceLabel.Draw(r, offsetX, offsetY);
			musicSlider.Draw(r, offsetX, offsetY);
			sfxSlider.Draw(r, offsetX, offsetY);
			ambianceSlider.Draw(r, offsetX, offsetY);
			backgroundSfxLabel.Draw(r, offsetX, offsetY);
			backgroundSfxLabel2.Draw(r, offsetX, offsetY);
			backgroundSfxButton.Draw(r, offsetX + backgroundSfxLabel.PositionX + toggleOffsetX, offsetY + backgroundSfxLabel.PositionY + toggleOffsetY);
		}
		else if (mode == Mode.Video)
		{
			fullScreenLabel.Draw(r, offsetX, offsetY);
			fullScreenButton.Draw(r, offsetX + fullScreenLabel.PositionX + toggleOffsetX, offsetY + fullScreenLabel.PositionY + toggleOffsetY);
			antiAliasLabel.Draw(r, offsetX, offsetY);
			antiAliasButton.Draw(r, offsetX + antiAliasLabel.PositionX + toggleOffsetX, offsetY + antiAliasLabel.PositionY + toggleOffsetY);
			if (resolutionComboBox != null)
			{
				resolutionComboBox.Draw(r, offsetX, offsetY);
			}
			screenFlashLabel.Draw(r, offsetX, offsetY);
			screenFlashButton.Draw(r, offsetX + screenFlashLabel.PositionX + toggleOffsetX, offsetY + screenFlashLabel.PositionY + toggleOffsetY);
			cameraShakeLabel.Draw(r, offsetX, offsetY);
			cameraShakeButton.Draw(r, offsetX + cameraShakeLabel.PositionX + toggleOffsetX, offsetY + cameraShakeLabel.PositionY + toggleOffsetY);
		}
		else if (mode == Mode.Input)
		{
			scrollWheelSpeedLabel.Draw(r, offsetX, offsetY);
			scrollWheelSpeedSlider.Draw(r, offsetX, offsetY);
			scrollInvertLabel.Draw(r, offsetX, offsetY);
			scrollInvertButton.Draw(r, offsetX + scrollInvertLabel.PositionX + toggleOffsetX, offsetY + scrollInvertLabel.PositionY + toggleOffsetY);
		}
		else
		{
			_ = mode;
			_ = 3;
		}
	}

	private void UpdateCopyrightText()
	{
		AsciiString asciiString = copyright;
		Version vERSION = Features.VERSION;
		asciiString.SetValue("v" + vERSION.ToString() + " Copyright Martian Rex, Inc.");
	}

	public static void LoadSettings()
	{
		if (PlayerPrefs.HasKey("settings_music_volume"))
		{
			MusicController.singleton.volume = PlayerPrefs.GetFloat("settings_music_volume", 1f);
		}
		else
		{
			MusicController.singleton.volume = (GetBool("settings_music_enabled", defaultValue: true) ? 1f : 0f);
		}
		if (PlayerPrefs.HasKey("settings_sfx_volume"))
		{
			SfxController.singleton.volume = PlayerPrefs.GetFloat("settings_sfx_volume", 1f);
		}
		else
		{
			SfxController.singleton.volume = (GetBool("settings_sfx_enabled", defaultValue: true) ? 1f : 0f);
		}
		if (PlayerPrefs.HasKey("settings_ambiance_volume"))
		{
			AmbianceController.singleton.volume = PlayerPrefs.GetFloat("settings_ambiance_volume", 1f);
		}
		else
		{
			AmbianceController.singleton.volume = (GetBool("settings_ambiance_enabled", defaultValue: true) ? 1f : 0f);
		}
		if (PlayerPrefs.HasKey("settings_input_scroll_speed"))
		{
			InputController.Instance.ScrollSpeed = PlayerPrefs.GetFloat("settings_input_scroll_speed");
		}
		else
		{
			InputController.Instance.ScrollSpeed = 26f;
		}
		if (PlayerPrefs.HasKey("settings_input_scroll_invert"))
		{
			InputController.Instance.InvertScroll = GetBool("settings_input_scroll_invert", defaultValue: false);
		}
		else
		{
			InputController.Instance.InvertScroll = false;
		}
	}

	private void UpdateAudioUI()
	{
		musicSlider.percent = MusicController.singleton.volume;
		sfxSlider.percent = SfxController.singleton.volume;
		ambianceSlider.percent = AmbianceController.singleton.volume;
		backgroundSfxButton.isOn = AdditionalSettings.isBackgroundSfx;
		backgroundSfxButton.JumpAnimation();
		UpdateBackgroundSfxLabel();
	}

	private void UpdateBackgroundSfxLabel()
	{
		string text = Te.xt("tid_button_sfx_unfocused");
		if (text.Length > 20)
		{
			string[] array = Utils.BreakIntoLines(text, 17);
			backgroundSfxLabel2.SetValue(array[0]);
			backgroundSfxLabel.SetValue(array[1]);
		}
		else
		{
			backgroundSfxLabel2.Clear();
			backgroundSfxLabel.SetValue(text);
		}
	}

	private void UpdateVideoUI()
	{
		fullScreenButton.isOn = Screen.fullScreen;
		fullScreenButton.JumpAnimation();
		antiAliasButton.isOn = AdditionalSettings.isAntiAlias;
		antiAliasButton.JumpAnimation();
		screenFlashButton.isOn = AdditionalSettings.isScreenFlash;
		screenFlashButton.JumpAnimation();
		cameraShakeButton.isOn = AdditionalSettings.isCameraShake;
		cameraShakeButton.JumpAnimation();
		UpdateResolutionComboBox();
	}

	private void UpdateInputUI()
	{
		if (scrollWheelSpeedSlider != null)
		{
			scrollWheelSpeedSlider.percent = (InputController.Instance.ScrollSpeed - 0f) / 50f;
			scrollInvertButton.isOn = InputController.Instance.InvertScroll;
			scrollInvertButton.JumpAnimation();
		}
	}

	private void UpdateExtrasUI()
	{
	}

	private void UpdateResolutionComboBox()
	{
		if (resolutionComboBox != null)
		{
			resolutionComboBox.SetValues(SettingsResolutions.singleton.GetResolutionStrings());
			resolutionComboBox.currentIndex = SettingsResolutions.singleton.GetCurrentIndex();
		}
	}

	private void SaveSettings()
	{
		if (MusicController.singleton != null)
		{
			PlayerPrefs.SetFloat("settings_music_volume", MusicController.singleton.volume);
		}
		if (SfxController.singleton != null)
		{
			PlayerPrefs.SetFloat("settings_sfx_volume", SfxController.singleton.volume);
		}
		if (AmbianceController.singleton != null)
		{
			PlayerPrefs.SetFloat("settings_ambiance_volume", AmbianceController.singleton.volume);
		}
		if (InputController.Instance != null)
		{
			PlayerPrefs.SetFloat("settings_input_scroll_speed", InputController.Instance.ScrollSpeed);
			SetBool("settings_input_scroll_invert", InputController.Instance.InvertScroll);
		}
	}

	private static bool GetBool(string key, bool defaultValue)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetInt(key) != 0;
		}
		return defaultValue;
	}

	private void SetBool(string key, bool value)
	{
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}

	private void HandleTabIndexChanged(int newIndex)
	{
		mode = (Mode)newIndex;
	}

	private void HandleMusicPercentChanged(Slider slider)
	{
		MusicController.singleton.volume = slider.percent;
	}

	private void HandleSfxPercentChanged(Slider slider)
	{
		SfxController.singleton.volume = slider.percent;
	}

	private void HandleAmbiancePercentChanged(Slider slider)
	{
		AmbianceController.singleton.volume = slider.percent;
	}

	private void HandleMusicOnOffButtonPressed(DialogButton button)
	{
		MusicController.singleton.volume = (musicOnOffButton.isOn ? 1f : 0f);
	}

	private void HandleSfxOnOffButtonPressed(DialogButton button)
	{
		SfxController.singleton.volume = (sfxOnOffButton.isOn ? 1f : 0f);
	}

	private void HandleAmbianceOnOffButtonPressed(DialogButton button)
	{
		AmbianceController.singleton.volume = (ambianceOnOffButton.isOn ? 1f : 0f);
	}

	private void HandleBackgroundSfxButtonPressed(DialogButton button)
	{
		AdditionalSettings.isBackgroundSfx = !AdditionalSettings.isBackgroundSfx;
	}

	private void HandleFullScreenButtonPressed(DialogButton button)
	{
		Screen.fullScreen = !Screen.fullScreen;
		UpdateResolutionComboBox();
	}

	private void HandleAntiAliasButtonPressed(DialogButton button)
	{
		AdditionalSettings.isAntiAlias = !AdditionalSettings.isAntiAlias;
		GameStates.Singleton.asciiRenderer.ScreenSizeChanged();
	}

	private void HandleScreenFlashButtonPressed(DialogButton button)
	{
		AdditionalSettings.isScreenFlash = !AdditionalSettings.isScreenFlash;
	}

	private void HandleCameraShakeButtonPressed(DialogButton button)
	{
		AdditionalSettings.isCameraShake = !AdditionalSettings.isCameraShake;
	}

	private void HandleScrollSpeedPercentChanged(Slider slider)
	{
		InputController.Instance.ScrollSpeed = slider.percent * 50f + 0f;
	}

	private void HandleScrollInvertButtonPressed(DialogButton button)
	{
		InputController.Instance.InvertScroll = !InputController.Instance.InvertScroll;
	}

	private void HandleOnClickedOutside()
	{
		if (AsciiMouse.singleton.y >= base.lastDrawY && (resolutionComboBox == null || resolutionComboBox.currentState == ComboBox.State.Closed))
		{
			Hide();
		}
	}

	private void HandleCloseButtonPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleResolutionIndexChanged(ComboBox box)
	{
		Utils.Log("Resolution changed to " + box.currentValue);
		SettingsResolutions.singleton.SetResolutionByIndex(box.currentIndex);
	}

	protected override void Start()
	{
		base.Start();
		UpdateCopyrightText();
		if (closeButton != null)
		{
			closeButton.OnPressed += HandleCloseButtonPressed;
		}
		if (resolutionComboBox != null)
		{
			resolutionComboBox.OnIndexChanged += HandleResolutionIndexChanged;
			SettingsResolutions.singleton.Load();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		tabGroup = GetComponent<ToggleButtonGroup>();
		tabGroup.OnIndexChanged += HandleTabIndexChanged;
		backgroundSfxButton = Object.Instantiate(toggleButtonPrefab);
		fullScreenButton = Object.Instantiate(toggleButtonPrefab);
		antiAliasButton = Object.Instantiate(toggleButtonPrefab);
		screenFlashButton = Object.Instantiate(toggleButtonPrefab);
		cameraShakeButton = Object.Instantiate(toggleButtonPrefab);
		scrollInvertButton = Object.Instantiate(toggleButtonPrefab);
		musicSlider.OnPercentChanged += HandleMusicPercentChanged;
		sfxSlider.OnPercentChanged += HandleSfxPercentChanged;
		ambianceSlider.OnPercentChanged += HandleAmbiancePercentChanged;
		backgroundSfxButton.OnPressed += HandleBackgroundSfxButtonPressed;
		fullScreenButton.OnPressed += HandleFullScreenButtonPressed;
		antiAliasButton.OnPressed += HandleAntiAliasButtonPressed;
		screenFlashButton.OnPressed += HandleScreenFlashButtonPressed;
		cameraShakeButton.OnPressed += HandleCameraShakeButtonPressed;
		if (scrollWheelSpeedSlider != null)
		{
			scrollWheelSpeedSlider.OnPercentChanged += HandleScrollSpeedPercentChanged;
			scrollInvertButton.OnPressed += HandleScrollInvertButtonPressed;
		}
		base.OnClickedOutside += HandleOnClickedOutside;
	}

	protected void OnDestroy()
	{
		tabGroup.OnIndexChanged += HandleTabIndexChanged;
		musicSlider.OnPercentChanged -= HandleMusicPercentChanged;
		sfxSlider.OnPercentChanged -= HandleSfxPercentChanged;
		ambianceSlider.OnPercentChanged -= HandleAmbiancePercentChanged;
		backgroundSfxButton.OnPressed -= HandleBackgroundSfxButtonPressed;
		fullScreenButton.OnPressed -= HandleFullScreenButtonPressed;
		antiAliasButton.OnPressed -= HandleAntiAliasButtonPressed;
		screenFlashButton.OnPressed -= HandleScreenFlashButtonPressed;
		cameraShakeButton.OnPressed -= HandleCameraShakeButtonPressed;
		if (scrollWheelSpeedSlider != null)
		{
			scrollWheelSpeedSlider.OnPercentChanged -= HandleScrollSpeedPercentChanged;
			scrollInvertButton.OnPressed -= HandleScrollInvertButtonPressed;
		}
		base.OnClickedOutside -= HandleOnClickedOutside;
		if (closeButton != null)
		{
			closeButton.OnPressed -= HandleCloseButtonPressed;
		}
		if (resolutionComboBox != null)
		{
			resolutionComboBox.OnIndexChanged -= HandleResolutionIndexChanged;
		}
	}
}
