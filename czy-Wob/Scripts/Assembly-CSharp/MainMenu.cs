using System.Collections;
using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject titleBounceRef;

	public List<GameObject> buttonList;

	public GameObject fileSelectGUI;

	public GameObject optionsGUI;

	public GameObject controlsGUI;

	public GameObject creditsGUI;

	public GameObject languageGUI;

	public GameObject initialBacking;

	public GameObject foodWarningPopup;

	public CanvasGroup foodWarningPopupCanvasGroup;

	public CanvasGroup secretModeSplashCanvasGroup;

	public GameObject secretModeRenderTexture;

	public GameObject fadeObject;

	private bool optionsActive;

	private bool controlsActive;

	private bool languageActive;

	private float initialScaleInTime = 1f;

	private float initialStartDelay = 0.75f;

	private float buttonDelay = 0.1f;

	private float clickScaleTime = 0.5f;

	private Vector3 clickScale = new Vector3(0.5f, 0.5f, 0.5f);

	private Inchworm.EaseStyle scaleStyle = Inchworm.EaseStyle.ElasticOut;

	private Segment currentTitleEase;

	private string bounceSound = "mainMenu_titleBounce";

	private string anyKeySound = "mainMenu_anyKeyPressed";

	private bool hasStarted;

	private Coroutine currentRoutine;

	private Inchworm inchwormRef;

	private EventController eventRef;

	private SceneManagerBase sceneManagerRef;

	private void Awake()
	{
		hasStarted = false;
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetGameLocation(GameLocation.TRANSITION);
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		fadeObject.SetActive(value: false);
		optionsGUI.SetActive(value: false);
		creditsGUI.SetActive(value: false);
		controlsGUI.SetActive(value: false);
		languageGUI.SetActive(value: false);
		foodWarningPopup.SetActive(value: false);
		secretModeSplashCanvasGroup.gameObject.SetActive(value: false);
		initialBacking.SetActive(value: true);
		titleBounceRef.transform.localScale = Vector3.zero;
		for (int i = 0; i < buttonList.Count; i++)
		{
			buttonList[i].transform.localScale = Vector3.zero;
		}
	}

	private void Start()
	{
		eventRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<EventController>(GlobalObject.EVENT_CONTROLLER);
		sceneManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		initialBacking.SetActive(!eventRef.HasShownWarning());
	}

	private IEnumerator WarningRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		float fadeInTime = 0.25f;
		float fadeOutTime = 0.5f;
		initialBacking.SetActive(value: false);
		secretModeSplashCanvasGroup.alpha = 1f;
		secretModeSplashCanvasGroup.gameObject.SetActive(value: true);
		yield return new WaitForSecondsRealtime(5f);
		secretModeRenderTexture.SetActive(value: false);
		float currentTime = fadeOutTime;
		while (currentTime > 0f)
		{
			yield return frameWait;
			currentTime -= Time.deltaTime;
			secretModeSplashCanvasGroup.alpha = Mathf.Max(currentTime / fadeOutTime, 0f);
		}
		secretModeSplashCanvasGroup.alpha = 0f;
		secretModeSplashCanvasGroup.gameObject.SetActive(value: false);
		foodWarningPopup.SetActive(value: true);
		foodWarningPopupCanvasGroup.alpha = 0f;
		currentTime = 0f;
		while (currentTime < fadeInTime)
		{
			yield return frameWait;
			currentTime += Time.deltaTime;
			foodWarningPopupCanvasGroup.alpha = Mathf.Min(currentTime / fadeInTime, 1f);
		}
		foodWarningPopupCanvasGroup.alpha = 1f;
		currentTime = 5f;
		while (currentTime > 0f)
		{
			yield return frameWait;
			currentTime -= Time.deltaTime;
			if (GameControls.actions.Interact.WasPressed)
			{
				break;
			}
		}
		currentTime = fadeOutTime;
		while (currentTime > 0f)
		{
			yield return frameWait;
			currentTime -= Time.deltaTime;
			foodWarningPopupCanvasGroup.alpha = Mathf.Max(currentTime / fadeOutTime, 0f);
		}
		foodWarningPopupCanvasGroup.alpha = 0f;
		foodWarningPopup.SetActive(value: false);
		currentRoutine = null;
		OnWarningRoutineComplete();
	}

	public void OnWarningRoutineComplete()
	{
		eventRef.SetHasShownWarning();
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetGameLocation(GameLocation.MAIN_MENU);
		titleBounceRef.transform.localScale = Vector3.zero;
		currentTitleEase = inchwormRef.RequestEaseToScale(titleBounceRef, Vector3.one, initialScaleInTime, scaleStyle, TitleBounceFinished, Inchworm.EasePriority.Normal, initialStartDelay);
		for (int i = 0; i < buttonList.Count; i++)
		{
			buttonList[i].transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(buttonList[i], Vector3.one, initialScaleInTime, scaleStyle, null, Inchworm.EasePriority.Normal, initialStartDelay + buttonDelay * (float)(i + 1));
		}
	}

	private void Update()
	{
		if (!hasStarted)
		{
			if (!(sceneManagerRef == null) && sceneManagerRef.HasSceneStarted())
			{
				hasStarted = true;
				if (eventRef.HasShownWarning())
				{
					initialBacking.SetActive(value: false);
					OnWarningRoutineComplete();
				}
				else if (currentRoutine == null)
				{
					currentRoutine = StartCoroutine(WarningRoutine());
				}
			}
		}
		else if (currentRoutine == null && GameControls.actions.CloseMenu.WasPressed)
		{
			if (optionsActive)
			{
				CloseOptions();
			}
			else if (controlsActive)
			{
				CloseControls();
			}
			else if (creditsGUI.activeSelf)
			{
				CloseCredits();
			}
			else if (languageActive)
			{
				CloseLanguage();
			}
		}
	}

	public void OnTitleClicked()
	{
		if (currentTitleEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentTitleEase);
			currentTitleEase = null;
		}
		AudioController.Play(bounceSound);
		titleBounceRef.transform.localScale = clickScale;
		currentTitleEase = inchwormRef.RequestEaseToScale(titleBounceRef, Vector3.one, clickScaleTime, scaleStyle, TitleBounceFinished);
	}

	private void TitleBounceFinished()
	{
		currentTitleEase = null;
	}

	public void OnStartButtonClicked()
	{
		fadeObject.SetActive(value: false);
		AudioController.Play(anyKeySound);
		Object.Instantiate(fileSelectGUI);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().OnEnterFileSelect();
	}

	public void OnOptionsButtonClicked()
	{
		optionsActive = true;
		fadeObject.SetActive(value: true);
		optionsGUI.SetActive(value: true);
	}

	public void CloseOptions()
	{
		optionsActive = false;
		fadeObject.SetActive(value: false);
		optionsGUI.SetActive(value: false);
	}

	public void OnLanguageButtonClicked()
	{
		CloseOptions();
		languageActive = true;
		fadeObject.SetActive(value: true);
		languageGUI.SetActive(value: true);
	}

	public void CloseLanguage()
	{
		languageActive = false;
		fadeObject.SetActive(value: false);
		languageGUI.SetActive(value: false);
		OnOptionsButtonClicked();
	}

	public void OnControlsButtonClicked()
	{
		controlsActive = true;
		fadeObject.SetActive(value: true);
		controlsGUI.SetActive(value: true);
	}

	public void CloseControls()
	{
		if (!controlsGUI.GetComponent<ControlsMenuController>().StealCloseInputIfNeeded())
		{
			controlsActive = false;
			fadeObject.SetActive(value: false);
			controlsGUI.SetActive(value: false);
		}
	}

	public void OnCreditsButtonClicked()
	{
		fadeObject.SetActive(value: true);
		creditsGUI.SetActive(value: true);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().OnEnterFileSelect();
	}

	public void CloseCredits()
	{
		fadeObject.SetActive(value: false);
		creditsGUI.SetActive(value: false);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().OnReEnterMainMenu();
	}

	public void OnQuitButtonClicked()
	{
		Application.Quit();
	}
}
