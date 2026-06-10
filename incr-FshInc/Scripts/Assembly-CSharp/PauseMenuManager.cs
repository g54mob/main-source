using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
	private const string PREF_FPS_INDEX = "Setting_FPS_Index";

	[SerializeField]
	private GameObject pauseMenuRoot;

	[SerializeField]
	private CanvasGroup pauseCanvasGroup;

	[SerializeField]
	private float fadeDuration = 0.25f;

	[Header("UI References")]
	public GameObject pauseButtonsPanel;

	public SettingsMenu settingsMenu;

	[Header("Configuration")]
	public string mainMenuSceneName = "MainMenu";

	private bool isPaused;

	public static PauseMenuManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
		ApplyFrameRateSettings();
	}

	private void Start()
	{
		pauseMenuRoot.SetActive(value: false);
		pauseCanvasGroup.alpha = 0f;
		pauseCanvasGroup.interactable = false;
		pauseCanvasGroup.blocksRaycasts = false;
	}

	public void ApplyFrameRateSettings()
	{
		int num = PlayerPrefs.GetInt("Setting_FPS_Index", 2);
		QualitySettings.vSyncCount = 0;
		switch (num)
		{
		case 0:
			Application.targetFrameRate = 30;
			break;
		case 1:
			Application.targetFrameRate = 60;
			break;
		case 2:
			Application.targetFrameRate = 120;
			break;
		case 3:
			Application.targetFrameRate = -1;
			break;
		default:
			Application.targetFrameRate = 120;
			break;
		}
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		ResumeGame();
	}

	private void Update()
	{
		if (!(SceneManager.GetActiveScene().name == mainMenuSceneName) && (!(SceneTransitionManager.Instance != null) || !SceneTransitionManager.Instance.IsTransitioning) && Input.GetKeyDown(KeyCode.Escape))
		{
			HandleEscapeKey();
		}
	}

	private void HandleEscapeKey()
	{
		if (settingsMenu.IsVisible)
		{
			CloseSettings();
		}
		else if (isPaused)
		{
			ResumeGame();
		}
		else
		{
			PauseGame();
		}
	}

	public void PauseGame()
	{
		isPaused = true;
		pauseMenuRoot.SetActive(value: true);
		pauseCanvasGroup.DOKill();
		pauseCanvasGroup.alpha = 0f;
		pauseCanvasGroup.DOFade(1f, fadeDuration).SetUpdate(isIndependentUpdate: true);
		pauseCanvasGroup.interactable = true;
		pauseCanvasGroup.blocksRaycasts = true;
		settingsMenu.HidePanel();
		Time.timeScale = 0f;
		if (DialogueManager.Instance != null && DialogueManager.Instance.isCutsceneActive)
		{
			DialogueManager.Instance.PauseDialogue();
		}
	}

	public void ResumeGame()
	{
		isPaused = false;
		pauseCanvasGroup.DOKill();
		pauseCanvasGroup.DOFade(0f, fadeDuration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			pauseMenuRoot.SetActive(value: false);
		});
		pauseCanvasGroup.interactable = false;
		pauseCanvasGroup.blocksRaycasts = false;
		if (settingsMenu != null)
		{
			settingsMenu.HidePanel();
		}
		Time.timeScale = 1f;
		if (DialogueManager.Instance != null && DialogueManager.Instance.isCutsceneActive)
		{
			DialogueManager.Instance.UnpauseDialogue();
		}
	}

	public void OpenSettings()
	{
		settingsMenu.ShowPanel();
	}

	public void CloseSettings()
	{
		settingsMenu.CloseSettings();
		if (SceneManager.GetActiveScene().name != mainMenuSceneName && pauseButtonsPanel != null)
		{
			pauseButtonsPanel.SetActive(value: true);
		}
	}

	public void ReturnToMainMenu()
	{
		Time.timeScale = 1f;
		if (GameManager.Instance != null)
		{
			GameManager.Instance.SaveGameData();
		}
		if (SceneTransitionManager.Instance != null)
		{
			SceneTransitionManager.Instance.TransitionToScene(mainMenuSceneName);
		}
		else
		{
			SceneManager.LoadScene(mainMenuSceneName);
		}
	}
}
