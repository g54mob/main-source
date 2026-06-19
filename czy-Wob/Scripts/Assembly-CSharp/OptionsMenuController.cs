using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
	public enum TextureQuality
	{
		FULL = 0,
		HALF = 1,
		QUARTER = 2,
		EIGHTH = 3
	}

	public TextMeshProUGUI resolutionDisplay;

	public CoreButtonUnityGUI cycleResLeftButton;

	public CoreButtonUnityGUI cycleResRightButton;

	public CoreButtonUnityGUI applyResolutionButton;

	public TextMeshProUGUI textureQualityDisplay;

	public CoreButtonUnityGUI cycleTextureLeftButton;

	public CoreButtonUnityGUI cycleTextureRightButton;

	public OptionsMenuToggle fullscreenToggle;

	public OptionsMenuToggle borderlessFullscreenToggle;

	public OptionsMenuToggle vsyncToggle;

	public OptionsMenuToggle postFXToggle;

	public OptionsMenuToggle AOToggle;

	public OptionsMenuToggle motionBlurToggle;

	public OptionsMenuToggle DOFToggle;

	public OptionsMenuToggle xAxisInvertToggle;

	public OptionsMenuToggle yAxisInvertToggle;

	public TextMeshProUGUI cameraSensitivityText;

	public CoreSliderUnityGUI cameraSensitivitySlider;

	public TextMeshProUGUI gamepadSensitivityText;

	public CoreSliderUnityGUI gamepadSensitivitySlider;

	public TextMeshProUGUI scrollSensitivityText;

	public CoreSliderUnityGUI scrollSensitivitySlider;

	public TextMeshProUGUI UIscrollSensitivityText;

	public CoreSliderUnityGUI UIscrollSensitivitySlider;

	public TextMeshProUGUI sfxVolumeText;

	public CoreSliderUnityGUI sfxSlider;

	public TextMeshProUGUI musicVolumeText;

	public CoreSliderUnityGUI musicSlider;

	public CoreButtonUnityGUI gameplaySettingsButton;

	public GameObject gameplaySettingsDisabledIndicator;

	public bool fromMainMenu;

	private Resolution currentResolution;

	private bool fullscreen = true;

	private bool borderlessFullscreen;

	private bool vsync = true;

	private bool postFX = true;

	private TextureQuality currentTextureQuality;

	private bool AO = true;

	private bool motionBlur = true;

	private bool depthOfField = true;

	private bool xAxisInverted = true;

	private bool yAxisInverted = true;

	private float cameraSensitivity = 0.5f;

	private float scrollSensitivity = 0.5f;

	private float UIscrollSensitivity = 0.5f;

	private float gamepadSensitivity = 0.5f;

	private float sfxVolume = 1f;

	private float musicVolume = 1f;

	private float resolutionCheckTimer = 0.25f;

	private float resolutionCheckTimerMax = 0.25f;

	private int currentResolutionIndex;

	private int workingResolutionIndex;

	private List<Resolution> allResolutions = new List<Resolution>();

	private void OnEnable()
	{
		if (TutorialController.IsTutorialActive())
		{
			gameplaySettingsButton.interactable = false;
			gameplaySettingsDisabledIndicator.SetActive(value: true);
		}
		else
		{
			gameplaySettingsButton.interactable = true;
			gameplaySettingsDisabledIndicator.SetActive(value: false);
		}
		if (fromMainMenu)
		{
			gameplaySettingsDisabledIndicator.SetActive(value: false);
			gameplaySettingsButton.transform.parent.gameObject.SetActive(value: false);
		}
		LoadSettings();
	}

	private void OnDisable()
	{
		OnCameraSensitivityValueFinalized();
		OnScrollSensitivityValueFinalized();
		OnUIScrollSensitivityValueFinalized();
		OnGamepadSensitivityValueFinalized();
		OnMusicVolumeFinalized();
		OnSFXVolumeFinalized();
	}

	private void Update()
	{
		resolutionCheckTimer -= Time.unscaledDeltaTime;
		if (!(resolutionCheckTimer > 0f))
		{
			resolutionCheckTimer = resolutionCheckTimerMax;
			if (!AreResolutionsEqual(currentResolution, FindCurrentResolution()))
			{
				LoadResolution();
			}
		}
	}

	public void OnApplyResolutionButtonPressed()
	{
		ApplyResolution();
	}

	public void CycleResolutionRight()
	{
		currentResolutionIndex++;
		if (currentResolutionIndex >= allResolutions.Count)
		{
			currentResolutionIndex = allResolutions.Count - 1;
		}
		UpdateResolution(currentResolutionIndex);
	}

	public void CycleResolutionLeft()
	{
		currentResolutionIndex--;
		if (currentResolutionIndex < 0)
		{
			currentResolutionIndex = 0;
		}
		UpdateResolution(currentResolutionIndex);
	}

	public void CycleTextureQualityRight()
	{
		currentTextureQuality--;
		if (currentTextureQuality < TextureQuality.FULL)
		{
			currentTextureQuality = TextureQuality.FULL;
		}
		UpdateTextureQuality(currentTextureQuality, apply: true);
	}

	public void CycleTextureQualityLeft()
	{
		currentTextureQuality++;
		if (currentTextureQuality > TextureQuality.EIGHTH)
		{
			currentTextureQuality = TextureQuality.EIGHTH;
		}
		UpdateTextureQuality(currentTextureQuality, apply: true);
	}

	public void ToggleFullscreen()
	{
		SetFullscreen(!fullscreen);
	}

	private void SetFullscreen(bool val)
	{
		fullscreen = val;
		fullscreenToggle.SetToggleState(fullscreen);
		UpdateResolution(workingResolutionIndex);
		ApplyResolution();
		applyResolutionButton.OnPointerExit(null);
		applyResolutionButton.interactable = false;
		borderlessFullscreenToggle.SetLockedStatus(!fullscreen);
		RefreshVsyncLock();
	}

	public void ToggleBorderlessFullscreen()
	{
		SetBorderlessFullscreen(!borderlessFullscreen);
	}

	private void SetBorderlessFullscreen(bool val)
	{
		borderlessFullscreen = val;
		borderlessFullscreenToggle.SetToggleState(borderlessFullscreen);
		GameSettings.StoreBorderlessFullscreen(borderlessFullscreen);
		UpdateResolution(workingResolutionIndex);
		ApplyResolution();
		applyResolutionButton.OnPointerExit(null);
		applyResolutionButton.interactable = false;
		RefreshVsyncLock();
	}

	public void ToggleVsync()
	{
		SetVsync(!vsync);
	}

	private void SetVsync(bool val)
	{
		vsync = val;
		vsyncToggle.SetToggleState(vsync);
		GameSettings.ApplyVsync(vsync, save: true);
		RefreshVsyncLock();
	}

	public void TogglePostFX()
	{
		SetPostFX(!postFX);
	}

	private void SetPostFX(bool val)
	{
		postFX = val;
		postFXToggle.SetToggleState(postFX);
		ApplyPostFX();
		AOToggle.SetLockedStatus(!postFX);
		if (!postFX)
		{
			AOToggle.SetToggleState(state: false);
		}
		else
		{
			AOToggle.SetToggleState(AO);
		}
	}

	private void ApplyPostFX()
	{
		GameSettings.ApplyPostFX(postFX, save: true);
	}

	public void ToggleAO()
	{
		SetAO(!AO);
	}

	private void SetAO(bool val)
	{
		AO = val;
		AOToggle.SetToggleState(AO);
		ApplyAO();
	}

	private void ApplyAO()
	{
		GameSettings.ApplyAO(AO, save: true);
	}

	public void ToggleMotionBlur()
	{
		SetMotionBlur(!motionBlur);
	}

	private void SetMotionBlur(bool val)
	{
		motionBlur = val;
		motionBlurToggle.SetToggleState(motionBlur);
		ApplyMotionBlur();
	}

	private void ApplyMotionBlur()
	{
		GameSettings.ApplyMotionBlur(motionBlur, save: true);
	}

	public void ToggleDepthOfField()
	{
		SetDepthOfField(!depthOfField);
	}

	private void SetDepthOfField(bool val)
	{
		depthOfField = val;
		DOFToggle.SetToggleState(depthOfField);
		ApplyDOF();
	}

	private void ApplyDOF()
	{
		GameSettings.ApplyDOF(depthOfField, save: true);
	}

	public void ToggleXAxisInvert()
	{
		SetXAxisInvert(!xAxisInverted);
	}

	private void SetXAxisInvert(bool val)
	{
		xAxisInverted = val;
		xAxisInvertToggle.SetToggleState(xAxisInverted);
		ApplyXAxisInvert();
	}

	private void ApplyXAxisInvert()
	{
		GameSettings.ApplyXAxisInvert(xAxisInverted, save: true);
	}

	public void ToggleYAxisInvert()
	{
		SetYAxisInvert(!yAxisInverted);
	}

	private void SetYAxisInvert(bool val)
	{
		yAxisInverted = val;
		yAxisInvertToggle.SetToggleState(yAxisInverted);
		ApplyYAxisInvert();
	}

	private void ApplyYAxisInvert()
	{
		GameSettings.ApplyYAxisInvert(yAxisInverted, save: true);
	}

	public void OnCameraSensitivityValueUpdated()
	{
		UpdateCamSliderText();
	}

	public void OnCameraSensitivityValueFinalized()
	{
		float num = (float)Mathf.RoundToInt(cameraSensitivitySlider.value * 100f) / 100f;
		SetCameraSensitivity(num);
	}

	private void SetCameraSensitivity(float val)
	{
		cameraSensitivity = val;
		cameraSensitivitySlider.SetValueWithoutNotify(cameraSensitivity);
		UpdateCamSliderText();
		ApplyCameraSensitivity();
	}

	private void ApplyCameraSensitivity()
	{
		GameSettings.ApplyCameraSensitivity(cameraSensitivity, save: true);
	}

	public void OnGamepadSensitivityValueUpdated()
	{
		UpdateGamepadSliderText();
	}

	public void OnGamepadSensitivityValueFinalized()
	{
		float num = (float)Mathf.RoundToInt(gamepadSensitivitySlider.value * 100f) / 100f;
		SetGamepadSensitivity(num);
	}

	private void SetGamepadSensitivity(float val)
	{
		gamepadSensitivity = val;
		gamepadSensitivitySlider.SetValueWithoutNotify(gamepadSensitivity);
		UpdateGamepadSliderText();
		ApplyGamepadSensitivity();
	}

	private void ApplyGamepadSensitivity()
	{
		GameSettings.ApplyGamepadSensitivity(gamepadSensitivity, save: true);
	}

	public void OnScrollSensitivityValueUpdated()
	{
		UpdateScrollSliderText();
	}

	public void OnScrollSensitivityValueFinalized()
	{
		float num = (float)Mathf.RoundToInt(scrollSensitivitySlider.value * 100f) / 100f;
		SetScrollSensitivity(num);
	}

	private void SetScrollSensitivity(float val)
	{
		scrollSensitivity = val;
		scrollSensitivitySlider.SetValueWithoutNotify(scrollSensitivity);
		UpdateScrollSliderText();
		ApplyScrollSensitivity();
	}

	private void ApplyScrollSensitivity()
	{
		GameSettings.ApplyScrollSensitivity(scrollSensitivity, save: true);
	}

	public void OnUIScrollSensitivityValueUpdated()
	{
		UpdateUIScrollSliderText();
	}

	public void OnUIScrollSensitivityValueFinalized()
	{
		float uIScrollSensitivity = (float)Mathf.RoundToInt(UIscrollSensitivitySlider.value * 100f) / 100f;
		SetUIScrollSensitivity(uIScrollSensitivity);
	}

	private void SetUIScrollSensitivity(float val)
	{
		UIscrollSensitivity = val;
		UIscrollSensitivitySlider.SetValueWithoutNotify(UIscrollSensitivity);
		UpdateUIScrollSliderText();
		ApplyUIScrollSensitivity();
	}

	private void ApplyUIScrollSensitivity()
	{
		GameSettings.ApplyUIScrollSensitivity(UIscrollSensitivity, save: true);
	}

	public void OnSFXVolumeUpdated()
	{
		UpdateSFXVolume(save: false);
	}

	public void OnSFXVolumeFinalized()
	{
		UpdateSFXVolume(save: true);
	}

	private void UpdateSFXVolume(bool save)
	{
		float val = (float)Mathf.RoundToInt(sfxSlider.value * 100f) / 100f;
		SetSFXVolume(val, save);
	}

	private void SetSFXVolume(float val, bool save)
	{
		sfxVolume = val;
		sfxSlider.SetValueWithoutNotify(sfxVolume);
		UpdateSFXSliderText();
		ApplySFXVolume(save);
	}

	private void ApplySFXVolume(bool save)
	{
		GameSettings.ApplySFXVolume(sfxVolume, save);
	}

	public void OnMusicVolumeUpdated()
	{
		UpdateMusicVolume(save: false);
	}

	public void OnMusicVolumeFinalized()
	{
		UpdateMusicVolume(save: true);
	}

	private void UpdateMusicVolume(bool save)
	{
		float val = (float)Mathf.RoundToInt(musicSlider.value * 100f) / 100f;
		SetMusicVolume(val, save);
	}

	private void SetMusicVolume(float val, bool save)
	{
		musicVolume = val;
		musicSlider.SetValueWithoutNotify(musicVolume);
		UpdateMusicSliderText();
		ApplyMusicVolume(save);
	}

	private void ApplyMusicVolume(bool save)
	{
		GameSettings.ApplyMusicVolume(musicVolume, save);
	}

	public void OnRestoreDefaultsButtonPressed()
	{
		GameSettings.RestoreDefaultSettings();
		LoadSettings();
	}

	public static Resolution FindCurrentResolution()
	{
		Resolution result = Screen.currentResolution;
		if (Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen)
		{
			result.width = Screen.width;
			result.height = Screen.height;
		}
		return result;
	}

	private void LoadResolution()
	{
		currentResolution = FindCurrentResolution();
		allResolutions.Clear();
		allResolutions.AddRange(Screen.resolutions);
		bool flag = true;
		if (borderlessFullscreen || !fullscreen)
		{
			flag = false;
		}
		for (int num = allResolutions.Count - 1; num >= 0; num--)
		{
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (AreResolutionsEqual(allResolutions[num], allResolutions[num2], flag))
				{
					allResolutions.RemoveAt(num2);
					break;
				}
			}
		}
		for (int i = 0; i < allResolutions.Count; i++)
		{
			if (AreResolutionsEqual(allResolutions[i], currentResolution, flag))
			{
				currentResolutionIndex = i;
				break;
			}
		}
		workingResolutionIndex = currentResolutionIndex;
		resolutionDisplay.text = GetResolutionDisplayString(currentResolution, flag);
		UpdateResCycleButtons();
		bool flag2 = false;
		if (currentResolutionIndex >= allResolutions.Count)
		{
			flag2 = AreResolutionsEqual(allResolutions[currentResolutionIndex], currentResolution);
		}
		if (flag2)
		{
			applyResolutionButton.OnPointerExit(null);
			applyResolutionButton.interactable = false;
		}
		else
		{
			applyResolutionButton.interactable = true;
			applyResolutionButton.OnPointerExit(null);
		}
	}

	private void LoadFullscreen()
	{
		fullscreen = Screen.fullScreen;
		fullscreenToggle.SetToggleState(fullscreen);
		borderlessFullscreenToggle.SetLockedStatus(!fullscreen);
		RefreshVsyncLock();
	}

	private void LoadBorderlessFullscreen()
	{
		if (Screen.fullScreen)
		{
			borderlessFullscreen = Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen;
		}
		else
		{
			borderlessFullscreen = GameSettings.GetStoredBorderlessFullscreen();
		}
		borderlessFullscreenToggle.SetToggleState(borderlessFullscreen);
		RefreshVsyncLock();
	}

	private void LoadVsync()
	{
		vsync = GameSettings.GetStoredVsync();
		vsyncToggle.SetToggleState(vsync);
		RefreshVsyncLock();
	}

	private void RefreshVsyncLock()
	{
		bool lockedStatus = vsyncToggle.GetLockedStatus();
		if (borderlessFullscreen || !fullscreen)
		{
			vsyncToggle.SetToggleState(state: false);
			vsyncToggle.SetLockedStatus(isLocked: true);
		}
		else
		{
			vsyncToggle.SetToggleState(vsync);
			vsyncToggle.SetLockedStatus(isLocked: false);
		}
		if (lockedStatus != vsyncToggle.GetLockedStatus())
		{
			LoadResolution();
		}
	}

	private void LoadPostFX()
	{
		postFX = GameSettings.GetStoredPostFX();
		postFXToggle.SetToggleState(postFX);
	}

	public void LoadTextureQuality()
	{
		currentTextureQuality = GameSettings.GetStoredTextureQuality();
		UpdateTextureQuality(currentTextureQuality, apply: false);
	}

	private void LoadAO()
	{
		AO = GameSettings.GetStoredAO();
		AOToggle.SetToggleState(AO);
		AOToggle.SetLockedStatus(!postFX);
		if (!postFX)
		{
			AOToggle.SetToggleState(state: false);
		}
	}

	private void LoadMotionBlur()
	{
		motionBlur = GameSettings.GetStoredMotionBlur();
		motionBlurToggle.SetToggleState(motionBlur);
	}

	private void LoadDepthOfField()
	{
		depthOfField = GameSettings.GetStoredDOF();
		DOFToggle.SetToggleState(depthOfField);
	}

	private void LoadXAxisInvert()
	{
		xAxisInverted = GameSettings.GetStoredXAxisInvert();
		xAxisInvertToggle.SetToggleState(xAxisInverted);
	}

	private void LoadYAxisInvert()
	{
		yAxisInverted = GameSettings.GetStoredYAxisInvert();
		yAxisInvertToggle.SetToggleState(yAxisInverted);
	}

	private void LoadCameraSensitivity()
	{
		cameraSensitivity = GameSettings.GetStoredCameraSensitivity();
		cameraSensitivitySlider.SetValueWithoutNotify(cameraSensitivity);
		UpdateCamSliderText();
	}

	private void LoadGamepadSensitivity()
	{
		gamepadSensitivity = GameSettings.GetStoredGamepadSensitivity();
		gamepadSensitivitySlider.SetValueWithoutNotify(gamepadSensitivity);
		UpdateGamepadSliderText();
	}

	private void LoadScrollSensitivity()
	{
		scrollSensitivity = GameSettings.GetStoredScrollSensitivity();
		scrollSensitivitySlider.SetValueWithoutNotify(scrollSensitivity);
		UpdateScrollSliderText();
	}

	private void LoadUIScrollSensitivity()
	{
		UIscrollSensitivity = GameSettings.GetStoredUIScrollSensitivity();
		UIscrollSensitivitySlider.SetValueWithoutNotify(UIscrollSensitivity);
		UpdateUIScrollSliderText();
	}

	private void LoadSFXVolume()
	{
		sfxVolume = GameSettings.GetStoredSFXVolume();
		sfxSlider.SetValueWithoutNotify(sfxVolume);
		UpdateSFXSliderText();
	}

	private void LoadMusicVolume()
	{
		musicVolume = GameSettings.GetStoredMusicVolume();
		musicSlider.SetValueWithoutNotify(musicVolume);
		UpdateMusicSliderText();
	}

	private void UpdateCamSliderText()
	{
		cameraSensitivityText.text = Mathf.RoundToInt(cameraSensitivitySlider.value * 100f) + "%";
	}

	private void UpdateGamepadSliderText()
	{
		gamepadSensitivityText.text = Mathf.RoundToInt(gamepadSensitivitySlider.value * 100f) + "%";
	}

	private void UpdateScrollSliderText()
	{
		scrollSensitivityText.text = Mathf.RoundToInt(scrollSensitivitySlider.value * 100f) + "%";
	}

	private void UpdateUIScrollSliderText()
	{
		UIscrollSensitivityText.text = Mathf.RoundToInt(UIscrollSensitivitySlider.value * 100f) + "%";
	}

	private void UpdateSFXSliderText()
	{
		sfxVolumeText.text = Mathf.RoundToInt(sfxSlider.value * 100f) + "%";
	}

	private void UpdateMusicSliderText()
	{
		musicVolumeText.text = Mathf.RoundToInt(musicSlider.value * 100f) + "%";
	}

	private static bool AreResolutionsEqual(Resolution a, Resolution b, bool checkRefreshRate = true)
	{
		if (a.width != b.width)
		{
			return false;
		}
		if (a.height != b.height)
		{
			return false;
		}
		if (checkRefreshRate && a.refreshRate != b.refreshRate)
		{
			if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows)
			{
				return false;
			}
			if (a.refreshRate != 0 && b.refreshRate != 0)
			{
				return false;
			}
		}
		return true;
	}

	private string GetTextureQualityStringForQuality(TextureQuality q)
	{
		switch (q)
		{
		case TextureQuality.FULL:
			return ScriptLocalization.GUI.GUI_OPTIONS_FULLRES;
		case TextureQuality.HALF:
			return ScriptLocalization.GUI.GUI_OPTIONS_HALFRES;
		case TextureQuality.QUARTER:
			return ScriptLocalization.GUI.GUI_OPTIONS_QUARTRES;
		case TextureQuality.EIGHTH:
			return ScriptLocalization.GUI.GUI_OPTIONS_EIGHTRES;
		default:
			Debug.LogError("No valid texture res found for: " + q);
			return "ERROR";
		}
	}

	private void UpdateTextureQuality(TextureQuality qualityType, bool apply)
	{
		if (apply)
		{
			GameSettings.ApplyTextureQuality(qualityType, save: true);
		}
		textureQualityDisplay.text = GetTextureQualityStringForQuality(qualityType);
		UpdateTextureQualityButtons();
	}

	private void UpdateResolution(int resolutionIndex)
	{
		currentResolutionIndex = resolutionIndex;
		if (currentResolutionIndex >= allResolutions.Count)
		{
			currentResolutionIndex = allResolutions.Count - 1;
		}
		UpdateResCycleButtons();
		if (allResolutions.Count == 0)
		{
			applyResolutionButton.OnPointerExit(null);
			applyResolutionButton.interactable = false;
			return;
		}
		bool includeRefreshRate = true;
		if (borderlessFullscreen || !fullscreen)
		{
			includeRefreshRate = false;
		}
		resolutionDisplay.text = GetResolutionDisplayString(allResolutions[currentResolutionIndex], includeRefreshRate);
		if (AreResolutionsEqual(allResolutions[currentResolutionIndex], currentResolution))
		{
			applyResolutionButton.OnPointerExit(null);
			applyResolutionButton.interactable = false;
		}
		else
		{
			applyResolutionButton.interactable = true;
			applyResolutionButton.OnPointerExit(null);
		}
	}

	private string GetResolutionDisplayString(Resolution res, bool includeRefreshRate)
	{
		string text = res.ToString();
		if (!includeRefreshRate)
		{
			text = text.Substring(0, text.IndexOf('@') - 1);
		}
		return text;
	}

	private void ApplyResolution()
	{
		if (currentResolutionIndex >= allResolutions.Count)
		{
			currentResolutionIndex = allResolutions.Count - 1;
		}
		if (allResolutions.Count != 0)
		{
			FullScreenMode mode = FullScreenMode.Windowed;
			if (fullscreen)
			{
				mode = (borderlessFullscreen ? FullScreenMode.MaximizedWindow : FullScreenMode.ExclusiveFullScreen);
			}
			GameSettings.ApplyResolution(allResolutions[currentResolutionIndex], mode);
			currentResolution = allResolutions[currentResolutionIndex];
			workingResolutionIndex = currentResolutionIndex;
			applyResolutionButton.OnPointerExit(null);
			applyResolutionButton.interactable = false;
		}
	}

	private void UpdateResCycleButtons()
	{
		if (currentResolutionIndex == 0 || allResolutions.Count == 0)
		{
			cycleResLeftButton.OnPointerExit(null);
			cycleResLeftButton.interactable = false;
		}
		else
		{
			cycleResLeftButton.interactable = true;
		}
		if (currentResolutionIndex >= allResolutions.Count - 1 || allResolutions.Count == 0)
		{
			cycleResRightButton.OnPointerExit(null);
			cycleResRightButton.interactable = false;
		}
		else
		{
			cycleResRightButton.interactable = true;
		}
	}

	private void UpdateTextureQualityButtons()
	{
		if (currentTextureQuality == TextureQuality.FULL)
		{
			cycleTextureRightButton.OnPointerExit(null);
			cycleTextureRightButton.interactable = false;
		}
		else
		{
			cycleTextureRightButton.interactable = true;
		}
		if (currentTextureQuality >= TextureQuality.EIGHTH)
		{
			cycleTextureLeftButton.OnPointerExit(null);
			cycleTextureLeftButton.interactable = false;
		}
		else
		{
			cycleTextureLeftButton.interactable = true;
		}
	}

	private void LoadSettings()
	{
		LoadPostFX();
		LoadTextureQuality();
		LoadAO();
		LoadMotionBlur();
		LoadDepthOfField();
		LoadXAxisInvert();
		LoadYAxisInvert();
		LoadCameraSensitivity();
		LoadScrollSensitivity();
		LoadUIScrollSensitivity();
		LoadGamepadSensitivity();
		LoadSFXVolume();
		LoadMusicVolume();
		LoadVsync();
		LoadFullscreen();
		LoadBorderlessFullscreen();
		LoadResolution();
	}
}
