using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
	public static OptionsManager Singleton;

	[Header("Settings")]
	public int mouseSens_Setting;

	public int vsync_Setting = 1;

	public int fps_Setting = 1;

	public int res_Fullscreen;

	public int res_Width;

	public int res_Height;

	public int fov_Setting;

	public int invertY_Setting;

	public int screenFilters_Setting;

	public int colorDesaturation_Setting;

	public int toggle_Vaccum_Setting;

	public int toggle_Sprint_Setting;

	public int toggle_PopGun_Setting;

	public int speedrunTimer_Setting;

	public int showHoleUI_Setting;

	public int crosshair_Size_Setting;

	public int crosshair_Color_Setting;

	public int forceUIScale_Setting;

	public int internationalPuzzles_Setting;

	public float uiScale_Setting;

	[Header("Settings Values")]
	public Vector2 mouseSens_Limits;

	public int[] fps_Values = new int[8] { 30, 60, 90, 120, 144, 240, 360, -1 };

	private Resolution[] currentResolutionsList;

	public Vector2 fov_Limits;

	public Vector2 crosshair_Limits;

	[SerializeField]
	private float crosshair_ScaleMult;

	public float crosshair_ScaleMult_InGame;

	[Header("Canvases")]
	[SerializeField]
	private GameObject optionsMenuCanvas;

	[SerializeField]
	private GameObject startingSelection_OptionsMenu;

	[SerializeField]
	private GameObject startingSelection_ControllerRemapMenu;

	[SerializeField]
	private Color textColor_Default;

	[SerializeField]
	private Color textColor_Faded;

	[Header("Value Displays")]
	[SerializeField]
	private TMP_Text textDisplay_sfxVolume;

	[SerializeField]
	private TMP_Text textDisplay_musicVolume;

	[SerializeField]
	private TMP_Text textDisplay_ambientVolume;

	[SerializeField]
	private GameObject checkmark_Fullscreen;

	[SerializeField]
	private TMP_Text textDisplay_Resolution;

	[SerializeField]
	private GameObject checkmark_Vsync;

	[SerializeField]
	private TMP_Text textDisplay_FrameRate;

	[SerializeField]
	private TMP_Text textDisplay_FOV;

	[SerializeField]
	private TMP_Text textDisplay_CameraSens;

	[SerializeField]
	private GameObject checkMark_InvertY;

	[SerializeField]
	private GameObject checkMark_ScreenFilters;

	[SerializeField]
	private GameObject checkMark_ColorDesat;

	[SerializeField]
	private GameObject checkMark_AutoSprint;

	[SerializeField]
	private GameObject checkMark_AutoPopGun;

	[SerializeField]
	private GameObject checkMark_SpeedrunTimer;

	[SerializeField]
	private GameObject checkMark_ShowHoleLevel;

	[SerializeField]
	private GameObject checkMark_ForceUIScale;

	[SerializeField]
	private GameObject checkMark_LocalizedPuzzles;

	[SerializeField]
	private TMP_Text textDisplay_uiScale;

	[SerializeField]
	private TMP_Dropdown resolutionsDropdown;

	[Header("Quit Buttons")]
	[SerializeField]
	private GameObject button_QuitToMainMenu;

	[Header("Flags")]
	public bool invertY_HasChanged;

	public bool fov_HasChanged;

	public bool screenFilters_HasChanged;

	public bool screenFilters_ColorDesaturation_HasChanged;

	[Header("Options SubMenus")]
	public GameObject submenu_Main;

	public GameObject submenu_ControlRebind;

	[Header("Crosshair Related")]
	[SerializeField]
	private Image crosshairImage_Dummy;

	public Color[] crosshair_Color_List;

	public Action OnHudScaleChanged;

	[SerializeField]
	private GameObject uiScaler_OptionsMenuParent;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UnityEngine.Object.DontDestroyOnLoad(optionsMenuCanvas);
		PopulateResolutionsList();
		LoadOptionValuesFromPlayerPrefs();
	}

	private void Start()
	{
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Combine(singleton.ControllerTypeChanged, new Action(ControllerChanged));
		OnHudScaleChanged = (Action)Delegate.Combine(OnHudScaleChanged, new Action(UpdateOptionsMenuHudScaling));
		OptionsMenuCanvas_Hide();
		UpdateOptionsMenuHudScaling();
	}

	private void OnDestroy()
	{
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Remove(singleton.ControllerTypeChanged, new Action(ControllerChanged));
		OnHudScaleChanged = (Action)Delegate.Remove(OnHudScaleChanged, new Action(UpdateOptionsMenuHudScaling));
	}

	private void Update()
	{
	}

	private void PopulateResolutionsList(int minWidth = 800, int minHeight = 600)
	{
		currentResolutionsList = (from r in Screen.resolutions
			where r.width >= minWidth && r.height >= minHeight
			where Mathf.Abs((float)r.width / (float)r.height - 1.3333334f) > 0.01f
			group r by new { r.width, r.height } into g
			select g.First() into r
			orderby r.width, r.height
			select r).ToArray();
	}

	public void LoadOptionValuesFromPlayerPrefs()
	{
		mouseSens_Setting = PlayerPrefs.GetInt("mouseSens", 4);
		vsync_Setting = PlayerPrefs.GetInt("vsync", 1);
		fps_Setting = PlayerPrefs.GetInt("fpsCap", 1);
		res_Fullscreen = PlayerPrefs.GetInt("res_FullScreen", 1);
		res_Width = PlayerPrefs.GetInt("res_Width", Screen.currentResolution.width);
		res_Height = PlayerPrefs.GetInt("res_Height", Screen.currentResolution.height);
		fov_Setting = PlayerPrefs.GetInt("fov", 70);
		invertY_Setting = PlayerPrefs.GetInt("invertY", 0);
		screenFilters_Setting = PlayerPrefs.GetInt("screenFilters", 1);
		colorDesaturation_Setting = PlayerPrefs.GetInt("colorDesat", 0);
		toggle_Sprint_Setting = PlayerPrefs.GetInt("setting_ToggleRun", 0);
		toggle_PopGun_Setting = PlayerPrefs.GetInt("setting_TogglePopGun", 0);
		speedrunTimer_Setting = PlayerPrefs.GetInt("setting_SpeedrunTimer", 0);
		showHoleUI_Setting = PlayerPrefs.GetInt("setting_ShowHoleLevel", 0);
		crosshair_Size_Setting = PlayerPrefs.GetInt("setting_CrosshairSize", 3);
		crosshair_Color_Setting = PlayerPrefs.GetInt("setting_CrosshairColor", 0);
		forceUIScale_Setting = PlayerPrefs.GetInt("ForceUIScale", 0);
		internationalPuzzles_Setting = PlayerPrefs.GetInt("LocalizedPuzzles", 0);
		uiScale_Setting = PlayerPrefs.GetFloat("UiScale", 1f);
		ApplySavedSettings();
		UpdateOptionsMenuUIFromValues();
		screenFilters_ColorDesaturation_HasChanged = true;
		screenFilters_HasChanged = true;
	}

	public void ApplySavedSettings()
	{
		if (vsync_Setting == 0)
		{
			Application.targetFrameRate = fps_Values[fps_Setting];
			QualitySettings.vSyncCount = 0;
		}
		else if (vsync_Setting == 1)
		{
			Application.targetFrameRate = -1;
			QualitySettings.vSyncCount = 1;
		}
		QualitySettings.resolutionScalingFixedDPIFactor = 1f;
	}

	public void SaveMouseSens()
	{
		PlayerPrefs.SetInt("mouseSense", mouseSens_Setting);
	}

	public void HideAllSubMenus()
	{
		submenu_Main.SetActive(value: false);
		submenu_ControlRebind.SetActive(value: false);
	}

	public void ShowSubMenu_Main()
	{
		HideAllSubMenus();
		submenu_Main.SetActive(value: true);
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			EventSystem.current.SetSelectedGameObject(startingSelection_OptionsMenu);
		}
	}

	public void ShowSubMenu_InputBindings()
	{
		HideAllSubMenus();
		submenu_ControlRebind.SetActive(value: true);
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			EventSystem.current.SetSelectedGameObject(startingSelection_ControllerRemapMenu);
		}
	}

	public void OpenInputBindings_SubMenu_Button()
	{
		ShowSubMenu_InputBindings();
	}

	public void OptionsMenuCanvas_Show()
	{
		optionsMenuCanvas.SetActive(value: true);
		ShowSubMenu_Main();
		UpdateOptionsMenuUIFromValues();
		if ((bool)MainMenuManager.Singleton)
		{
			button_QuitToMainMenu.SetActive(value: false);
		}
		else if ((bool)HudManager.Singleton)
		{
			button_QuitToMainMenu.SetActive(value: true);
		}
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			EventSystem.current.SetSelectedGameObject(startingSelection_OptionsMenu);
		}
		PopulateResolutionDropdown();
	}

	public void OptionsMenuCanvas_Hide()
	{
		optionsMenuCanvas.SetActive(value: false);
	}

	public void OptionsMenuCanvas_Hide_Button()
	{
		if ((bool)MainMenuManager.Singleton)
		{
			MainMenuManager.Singleton.MainMenuCanvas_Show();
			OptionsMenuCanvas_Hide();
		}
		else if ((bool)HudManager.Singleton)
		{
			HudManager.Singleton.OnUnpausingGame_Action?.Invoke();
			HudManager.Singleton.ShowUiGroup_Playing();
		}
	}

	public void ChangeVolumeButton_SFX(bool _up)
	{
		if (_up)
		{
			AudioManager.Singleton.sfx_Volume_Base += 0.1f;
		}
		else
		{
			AudioManager.Singleton.sfx_Volume_Base -= 0.1f;
		}
		AudioManager.Singleton.sfx_Volume_Base = Mathf.Clamp(AudioManager.Singleton.sfx_Volume_Base, 0f, 1f);
		PlayerPrefs.SetFloat("sfxVolume", AudioManager.Singleton.sfx_Volume_Base);
		UpdateOptionsMenuUIFromValues();
		AudioManager.Singleton.AudioLevelsChanged_Action?.Invoke();
	}

	public void ChangeVolumeButton_Music(bool _up)
	{
		if (_up)
		{
			AudioManager.Singleton.music_Volume_Base += 0.1f;
		}
		else
		{
			AudioManager.Singleton.music_Volume_Base -= 0.1f;
		}
		AudioManager.Singleton.music_Volume_Base = Mathf.Clamp(AudioManager.Singleton.music_Volume_Base, 0f, 1f);
		PlayerPrefs.SetFloat("musicVolume", AudioManager.Singleton.music_Volume_Base);
		UpdateOptionsMenuUIFromValues();
		AudioManager.Singleton.AudioLevelsChanged_Action?.Invoke();
	}

	public void ChangeVolumeButton_Ambient(bool _up)
	{
		if (_up)
		{
			AudioManager.Singleton.ambient_Volume_Base += 0.1f;
		}
		else
		{
			AudioManager.Singleton.ambient_Volume_Base -= 0.1f;
		}
		AudioManager.Singleton.ambient_Volume_Base = Mathf.Clamp(AudioManager.Singleton.ambient_Volume_Base, 0f, 1f);
		PlayerPrefs.SetFloat("ambientVolume", AudioManager.Singleton.ambient_Volume_Base);
		UpdateOptionsMenuUIFromValues();
		AudioManager.Singleton.AudioLevelsChanged_Action?.Invoke();
	}

	public void ChangeFullscreenButton()
	{
		bool flag = res_Fullscreen == 1;
		flag = !flag;
		if (flag)
		{
			res_Fullscreen = 1;
		}
		else
		{
			res_Fullscreen = 0;
		}
		PlayerPrefs.SetInt("res_FullScreen", res_Fullscreen);
		Screen.SetResolution(res_Width, res_Height, flag);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeToggleSprintButton()
	{
		if (toggle_Sprint_Setting != 1)
		{
			toggle_Sprint_Setting = 1;
		}
		else
		{
			toggle_Sprint_Setting = 0;
		}
		PlayerPrefs.SetInt("setting_ToggleRun", toggle_Sprint_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeTogglePopGunButton()
	{
		if (toggle_PopGun_Setting != 1)
		{
			toggle_PopGun_Setting = 1;
		}
		else
		{
			toggle_PopGun_Setting = 0;
		}
		PlayerPrefs.SetInt("setting_TogglePopGun", toggle_PopGun_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeToggleSpeedrunTimer()
	{
		if (speedrunTimer_Setting != 1)
		{
			speedrunTimer_Setting = 1;
		}
		else
		{
			speedrunTimer_Setting = 0;
		}
		PlayerPrefs.SetInt("setting_SpeedrunTimer", speedrunTimer_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeToggleShowHoleLevel()
	{
		if (showHoleUI_Setting != 1)
		{
			showHoleUI_Setting = 1;
		}
		else
		{
			showHoleUI_Setting = 0;
		}
		PlayerPrefs.SetInt("setting_ShowHoleLevel", showHoleUI_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeToggleForceUIScale()
	{
		if (forceUIScale_Setting != 1)
		{
			forceUIScale_Setting = 1;
		}
		else
		{
			forceUIScale_Setting = 0;
		}
		PlayerPrefs.SetInt("ForceUIScale", forceUIScale_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeResolutionButton(bool _up)
	{
		int currResolutionIndex = GetCurrResolutionIndex();
		Debug.Log("curr RES Index: " + currResolutionIndex);
		currResolutionIndex = ((!_up) ? ((currResolutionIndex - 1 + currentResolutionsList.Length) % currentResolutionsList.Length) : ((currResolutionIndex + 1) % currentResolutionsList.Length));
		res_Width = currentResolutionsList[currResolutionIndex].width;
		res_Height = currentResolutionsList[currResolutionIndex].height;
		bool fullscreen = res_Fullscreen == 1;
		Screen.SetResolution(res_Width, res_Height, fullscreen);
		PlayerPrefs.SetInt("res_Width", res_Width);
		PlayerPrefs.SetInt("res_Height", res_Height);
		UpdateOptionsMenuUIFromValues();
	}

	private int GetCurrResolutionIndex()
	{
		int width = Screen.currentResolution.width;
		int height = Screen.currentResolution.height;
		for (int i = 0; i < currentResolutionsList.Length; i++)
		{
			if (currentResolutionsList[i].width == width && currentResolutionsList[i].height == height)
			{
				return i;
			}
		}
		return currentResolutionsList.Length - 1;
	}

	public void ChangeVsyncButton()
	{
		if (vsync_Setting != 1)
		{
			vsync_Setting = 1;
		}
		else
		{
			vsync_Setting = 0;
		}
		PlayerPrefs.SetInt("vsync", vsync_Setting);
		ApplySavedSettings();
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeFPSButton(bool _up)
	{
		if (_up)
		{
			if (fps_Setting >= fps_Values.Length - 1)
			{
				return;
			}
			fps_Setting++;
		}
		else
		{
			if (fps_Setting <= 0)
			{
				return;
			}
			fps_Setting--;
		}
		PlayerPrefs.SetInt("fpsCap", fps_Setting);
		ApplySavedSettings();
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeFOVButton(bool _up)
	{
		if (_up)
		{
			if ((float)fov_Setting < fov_Limits.y)
			{
				fov_Setting++;
			}
		}
		else if ((float)fov_Setting > fov_Limits.x)
		{
			fov_Setting--;
		}
		PlayerPrefs.SetInt("fov", fov_Setting);
		fov_HasChanged = true;
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeMouseSensButton(bool _up)
	{
		if (_up)
		{
			if ((float)mouseSens_Setting < mouseSens_Limits.y)
			{
				mouseSens_Setting++;
			}
		}
		else if (mouseSens_Setting > 0)
		{
			mouseSens_Setting--;
		}
		PlayerPrefs.SetInt("mouseSens", mouseSens_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeInvertYButton()
	{
		if (invertY_Setting != 1)
		{
			invertY_Setting = 1;
		}
		else
		{
			invertY_Setting = 0;
		}
		invertY_HasChanged = true;
		PlayerPrefs.SetInt("invertY", invertY_Setting);
		ApplySavedSettings();
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeScreenFiltersButton()
	{
		if (screenFilters_Setting != 1)
		{
			screenFilters_Setting = 1;
		}
		else
		{
			screenFilters_Setting = 0;
		}
		screenFilters_HasChanged = true;
		PlayerPrefs.SetInt("screenFilters", screenFilters_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeColorDesaturationButton()
	{
		if (colorDesaturation_Setting != 1)
		{
			colorDesaturation_Setting = 1;
		}
		else
		{
			colorDesaturation_Setting = 0;
		}
		screenFilters_ColorDesaturation_HasChanged = true;
		PlayerPrefs.SetInt("colorDesat", colorDesaturation_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void UpdateOptionsMenuUIFromValues()
	{
		textDisplay_sfxVolume.text = LocTableHelpers.GetStringFromTable("OptionsMenu_Volume_SFX") + " " + Mathf.Round(AudioManager.Singleton.sfx_Volume_Base * 100f) + "%";
		textDisplay_musicVolume.text = LocTableHelpers.GetStringFromTable("OptionsMenu_Volume_Music") + " " + Mathf.Round(AudioManager.Singleton.music_Volume_Base * 100f) + "%";
		textDisplay_ambientVolume.text = LocTableHelpers.GetStringFromTable("OptionsMenu_Volume_Ambient") + " " + Mathf.Round(AudioManager.Singleton.ambient_Volume_Base * 100f) + "%";
		checkmark_Fullscreen.SetActive(res_Fullscreen == 1);
		textDisplay_Resolution.text = res_Width + "x" + res_Height;
		checkmark_Vsync.SetActive(vsync_Setting == 1);
		if (checkmark_Vsync.activeSelf)
		{
			textDisplay_FrameRate.color = textColor_Faded;
		}
		else
		{
			textDisplay_FrameRate.color = textColor_Default;
		}
		if (fps_Values[fps_Setting] == -1)
		{
			textDisplay_FrameRate.text = LocTableHelpers.GetStringFromTable("OptionsMenu_FPS_LimitLabel") + " N/A";
		}
		else
		{
			textDisplay_FrameRate.text = LocTableHelpers.GetStringFromTable("OptionsMenu_FPS_LimitLabel") + " " + fps_Values[fps_Setting];
		}
		textDisplay_FOV.text = LocTableHelpers.GetStringFromTable("OptionsMenu_FOV") + " " + fov_Setting;
		textDisplay_CameraSens.text = LocTableHelpers.GetStringFromTable("OptionsMenu_CameraSens") + " " + mouseSens_Setting;
		checkMark_InvertY.SetActive(invertY_Setting == 1);
		checkMark_ScreenFilters.SetActive(screenFilters_Setting == 1);
		checkMark_ColorDesat.SetActive(colorDesaturation_Setting == 1);
		checkMark_AutoSprint.SetActive(toggle_Sprint_Setting == 1);
		checkMark_AutoPopGun.SetActive(toggle_PopGun_Setting == 1);
		checkMark_SpeedrunTimer.SetActive(speedrunTimer_Setting == 1);
		checkMark_ShowHoleLevel.SetActive(showHoleUI_Setting == 1);
		checkMark_ForceUIScale.SetActive(forceUIScale_Setting == 1);
		checkMark_LocalizedPuzzles.SetActive(internationalPuzzles_Setting == 1);
		textDisplay_uiScale.text = LocTableHelpers.GetStringFromTable("Menu_UiScale") + " " + (uiScale_Setting * 100f).ToString("F0") + "%";
		crosshairImage_Dummy.gameObject.transform.localScale = crosshair_ScaleMult * (float)crosshair_Size_Setting * Vector3.one;
		crosshairImage_Dummy.color = crosshair_Color_List[crosshair_Color_Setting];
	}

	public void ButtonClick_QuitToMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
		OptionsMenuCanvas_Hide();
	}

	private void ControllerChanged()
	{
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			if (submenu_Main.activeSelf)
			{
				EventSystem.current.SetSelectedGameObject(startingSelection_OptionsMenu);
			}
			else if (submenu_ControlRebind.activeSelf)
			{
				EventSystem.current.SetSelectedGameObject(startingSelection_ControllerRemapMenu);
			}
		}
	}

	public void OnResolutionDropDownOpen()
	{
	}

	public void PopulateResolutionDropdown()
	{
		resolutionsDropdown.ClearOptions();
		List<string> list = new List<string>();
		int value = 0;
		for (int i = 0; i < currentResolutionsList.Length; i++)
		{
			Resolution resolution = currentResolutionsList[i];
			string item = $"{resolution.width} x {resolution.height}";
			list.Add(item);
			if (resolution.width == Screen.width && resolution.height == Screen.height)
			{
				value = i;
			}
		}
		resolutionsDropdown.AddOptions(list);
		resolutionsDropdown.value = value;
		resolutionsDropdown.RefreshShownValue();
	}

	public void NewResolutionChosen(int _index)
	{
	}

	public void ApplyResolutionButton()
	{
		Resolution resolution = currentResolutionsList[resolutionsDropdown.value];
		Debug.Log("Resolution: " + resolution.width + "," + resolution.height);
		if (resolution.width != Screen.width || resolution.height != Screen.height)
		{
			Debug.Log("Not our current resolution, changing!");
			Screen.SetResolution(resolution.width, resolution.height, res_Fullscreen == 1);
			res_Width = resolution.width;
			res_Height = resolution.height;
			PlayerPrefs.SetInt("res_Width", res_Width);
			PlayerPrefs.SetInt("res_Height", res_Height);
		}
	}

	public void ChangeCrosshairSizeButton(bool _up)
	{
		if (_up)
		{
			crosshair_Size_Setting++;
		}
		else
		{
			crosshair_Size_Setting--;
		}
		crosshair_Size_Setting = Mathf.Clamp(crosshair_Size_Setting, Mathf.RoundToInt(crosshair_Limits.x), Mathf.RoundToInt(crosshair_Limits.y));
		PlayerPrefs.SetInt("setting_CrosshairSize", crosshair_Size_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeCrosshairColorButton(bool _up)
	{
		if (_up)
		{
			crosshair_Color_Setting++;
		}
		else
		{
			crosshair_Color_Setting--;
		}
		crosshair_Color_Setting = Mathf.Clamp(crosshair_Color_Setting, 0, 9);
		PlayerPrefs.SetInt("setting_CrosshairColor", crosshair_Color_Setting);
		UpdateOptionsMenuUIFromValues();
	}

	public void ChangeLocalizedPuzzlesButton()
	{
		if (internationalPuzzles_Setting != 1)
		{
			SetLocalizedPuzzles(_enable: true);
		}
		else
		{
			SetLocalizedPuzzles(_enable: false);
		}
		UpdateOptionsMenuUIFromValues();
	}

	public void SetLocalizedPuzzles(bool _enable)
	{
		if (_enable)
		{
			internationalPuzzles_Setting = 1;
		}
		else
		{
			internationalPuzzles_Setting = 0;
		}
		PlayerPrefs.SetInt("LocalizedPuzzles", internationalPuzzles_Setting);
	}

	public void ChangeUiScaleButton(bool _up)
	{
		if (_up)
		{
			uiScale_Setting += 0.05f;
		}
		else
		{
			uiScale_Setting -= 0.05f;
		}
		uiScale_Setting = Mathf.Clamp(uiScale_Setting, 0.5f, 1f);
		PlayerPrefs.SetFloat("UiScale", uiScale_Setting);
		UpdateOptionsMenuUIFromValues();
		OnHudScaleChanged?.Invoke();
	}

	private void UpdateOptionsMenuHudScaling()
	{
		uiScaler_OptionsMenuParent.transform.localScale = Vector3.one * uiScale_Setting;
	}
}
