using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
	public static SettingsManager Instance;

	private GameControls gameControls;

	[SerializeField]
	private GameObject UI;

	[SerializeField]
	private GameObject settingsMenu;

	[SerializeField]
	private GameObject menuWindow;

	private bool tutorialOpen;

	[SerializeField]
	private Animator sceneTransitionAnimator;

	private bool playSceneTransition;

	[SerializeField]
	private TextMeshProUGUI buttonPreviewText;

	private List<string> creditNames = new List<string> { "TheShelfman", "Icoso", "KenneyNL" };

	[SerializeField]
	private Animator controlsWindowAnimator;

	private bool controlsWindowOpen;

	[SerializeField]
	private GameObject mouseKeyboardControls;

	[SerializeField]
	private GameObject gamepadControls;

	[SerializeField]
	private Animator achievementsWindowAnimator;

	private bool achievementsWindowOpen;

	[SerializeField]
	private GameObject creditsWindow;

	[SerializeField]
	private Slider sfxSlider;

	private float sfxVolume;

	[SerializeField]
	private Slider musicSlider;

	private float musicVolume;

	[SerializeField]
	private SoundManager uiSoundManager;

	private void Awake()
	{
		Instance = this;
		gameControls = new GameControls();
		settingsMenu.SetActive(value: false);
	}

	private void OnEnable()
	{
		gameControls.Enable();
	}

	private void OnDisable()
	{
		gameControls.Disable();
	}

	private void Start()
	{
		gameControls.Game.UI_Switch.performed += UI_Switch;
		gameControls.Game.Pause.performed += Pause;
		playSceneTransition = PlayerPrefs.HasKey("playSceneTransition") && PlayerPrefs.GetInt("playSceneTransition") == 1;
		if (playSceneTransition)
		{
			StartCoroutine(PlaySceneTransition(transitionIn: true));
		}
		LoadVolume();
	}

	private void Update()
	{
		if (Keyboard.current.pKey.isPressed)
		{
			OnResetButtonPressed();
		}
		gamepadControls.SetActive(GamepadCursor.Instance.IsGamepadActive());
		mouseKeyboardControls.SetActive(!GamepadCursor.Instance.IsGamepadActive());
	}

	private void UI_Switch(InputAction.CallbackContext context)
	{
		UI.SetActive(!UI.activeInHierarchy);
	}

	private void Pause(InputAction.CallbackContext context)
	{
		OnPauseButtonPressed();
	}

	public bool IsSettingsOpen()
	{
		return settingsMenu.activeInHierarchy;
	}

	public void OnPauseButtonPressed()
	{
		if (creditsWindow.activeInHierarchy)
		{
			creditsWindow.SetActive(value: false);
			menuWindow.SetActive(value: true);
			if (controlsWindowOpen)
			{
				OpenControlsWindow();
			}
			if (achievementsWindowOpen)
			{
				OpenAchievementsWindow();
			}
			return;
		}
		if (TutorialController.Instance.PlayingTutorial())
		{
			if (!tutorialOpen)
			{
				tutorialOpen = true;
				TutorialController.Instance.TemporarilyCloseTutorial();
				settingsMenu.SetActive(value: true);
			}
			else
			{
				tutorialOpen = false;
				TutorialController.Instance.ReopenTutorial();
				settingsMenu.SetActive(value: false);
			}
			return;
		}
		if (!settingsMenu.activeInHierarchy && !UI.activeInHierarchy)
		{
			UI.SetActive(value: true);
		}
		settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
		if (settingsMenu.activeInHierarchy)
		{
			if (controlsWindowOpen)
			{
				OpenControlsWindow();
			}
			if (achievementsWindowOpen)
			{
				OpenAchievementsWindow();
			}
		}
		if (!settingsMenu.activeInHierarchy)
		{
			buttonPreviewText.text = "";
		}
	}

	public void OnResumeButtonPressed()
	{
		settingsMenu.SetActive(value: false);
		buttonPreviewText.text = "";
	}

	public void OnResetButtonPressed()
	{
		if (SteamAchievementManager.Instance.HasTilesToShowAsUnlocked())
		{
			SteamAchievementManager.Instance.ShowUnlockedTile();
		}
		else
		{
			StartCoroutine(PlaySceneTransition(transitionIn: false));
		}
	}

	private IEnumerator PlaySceneTransition(bool transitionIn)
	{
		if (transitionIn)
		{
			if (playSceneTransition)
			{
				sceneTransitionAnimator.Play("anim-scene_transition_in");
			}
		}
		else
		{
			sceneTransitionAnimator.Play("anim-scene_transition_out");
			yield return new WaitForSeconds(1f);
			PlayerPrefs.SetInt("playSceneTransition", 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void OnExitButtonPressed()
	{
		Application.Quit();
	}

	private void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("playSceneTransition", 0);
	}

	public void ShowButtonPreviewText(string _text)
	{
		if (creditNames.Contains(_text))
		{
			buttonPreviewText.text = _text;
		}
		else
		{
			buttonPreviewText.text = ((_text == "") ? "" : LocalizationController.Instance.GetLabelTranslation(_text));
		}
	}

	public void OpenControlsWindow()
	{
		if (achievementsWindowOpen)
		{
			OpenAchievementsWindow();
		}
		controlsWindowOpen = !controlsWindowOpen;
		controlsWindowAnimator.Play(controlsWindowOpen ? "anim_controls_window_appear" : "anim_controls_window_disappear");
	}

	public void OpenAchievementsWindow()
	{
		if (controlsWindowOpen)
		{
			OpenControlsWindow();
		}
		achievementsWindowOpen = !achievementsWindowOpen;
		achievementsWindowAnimator.Play(achievementsWindowOpen ? "anim_achievements_window_appear" : "anim_achievements_window_disappear");
	}

	public void OpenCreditsWindow()
	{
		if (controlsWindowOpen)
		{
			OpenControlsWindow();
		}
		if (achievementsWindowOpen)
		{
			OpenAchievementsWindow();
		}
		creditsWindow.SetActive(!creditsWindow.activeInHierarchy);
		menuWindow.SetActive(!creditsWindow.activeInHierarchy);
	}

	public void CloseCreditsWindow()
	{
		creditsWindow.SetActive(value: false);
		menuWindow.SetActive(value: true);
	}

	private void LoadVolume()
	{
		sfxVolume = (PlayerPrefs.HasKey("sfxVolume") ? PlayerPrefs.GetFloat("sfxVolume") : 0.5f);
		sfxSlider.value = sfxVolume;
		musicVolume = (PlayerPrefs.HasKey("musicVolume") ? PlayerPrefs.GetFloat("musicVolume") : 0.5f);
		musicSlider.value = musicVolume;
		UpdateSFXVolume();
		UpdateMusicVolume();
	}

	public float GetSFXVolume()
	{
		return sfxVolume;
	}

	private void UpdateSFXVolume()
	{
		SoundManager[] array = Object.FindObjectsOfType<SoundManager>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetVolume();
		}
	}

	public void SetSFXVolume()
	{
		sfxVolume = sfxSlider.value;
		PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
		UpdateSFXVolume();
	}

	public float GetMusicVolume()
	{
		return musicVolume;
	}

	private void UpdateMusicVolume()
	{
		Object.FindObjectOfType<MusicManager>().SetVolume();
	}

	public void SetMusicVolume()
	{
		musicVolume = musicSlider.value;
		PlayerPrefs.SetFloat("musicVolume", musicVolume);
		UpdateMusicVolume();
	}

	public SoundManager GetUISoundManager()
	{
		return uiSoundManager;
	}
}
