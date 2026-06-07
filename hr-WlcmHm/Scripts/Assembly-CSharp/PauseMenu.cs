using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	private GameObject pauseMenu;

	public bool isPaused;

	private GameObject gameOverMenu;

	private GameObject killMenu;

	private GameObject restartMenu;

	private GameObject settingsMenu;

	private GameObject levelsMenu;

	private GameObject bushVignette;

	private GameObject confirmHome;

	private GameObject confirmExit;

	private InventoryUI inventoryUI;

	private PlayerController playerController;

	private FirstPersonController _firstPersonController;

	public bool isPoliceScene;

	private void Awake()
	{
		isPaused = false;
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		gameOverMenu = GameObject.Find("GameOverMenu");
		killMenu = GameObject.Find("KillMenu");
		restartMenu = GameObject.Find("RestartMenu");
		settingsMenu = GameObject.Find("SettingsMenu");
		levelsMenu = GameObject.Find("LevelsMenu");
		bushVignette = GameObject.Find("BushVignette");
		confirmHome = GameObject.Find("ConfirmHome");
		confirmExit = GameObject.Find("ConfirmExit");
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		_firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
	}

	private void Start()
	{
		SetActiveIfNotNull(ref gameOverMenu, isActive: false);
		SetActiveIfNotNull(ref killMenu, isActive: false);
		SetActiveIfNotNull(ref restartMenu, isActive: false);
		SetActiveIfNotNull(ref settingsMenu, isActive: false);
		SetActiveIfNotNull(ref levelsMenu, isActive: false);
		SetActiveIfNotNull(ref bushVignette, isActive: false);
		SetActiveIfNotNull(ref confirmHome, isActive: false);
		SetActiveIfNotNull(ref confirmExit, isActive: false);
		SetActiveIfNotNull(ref pauseMenu, isActive: false);
		inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!isPaused && !restartMenu.activeSelf && !gameOverMenu.activeSelf && !killMenu.activeSelf && !playerController.DialogueBox.activeSelf)
			{
				PauseGame();
			}
			else if (isPaused && (pauseMenu.activeSelf || settingsMenu.activeSelf || levelsMenu.activeSelf))
			{
				ResumeGame();
			}
		}
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(value: false);
		settingsMenu.SetActive(value: false);
		levelsMenu.SetActive(value: false);
		Time.timeScale = 1f;
		isPaused = false;
		_firstPersonController.EnableInput();
	}

	public void PauseGame()
	{
		pauseMenu.SetActive(value: true);
		Time.timeScale = 0f;
		isPaused = true;
		_firstPersonController.DisableInput();
		if (confirmHome.activeSelf || confirmExit.activeSelf || settingsMenu.activeSelf || levelsMenu.activeSelf)
		{
			confirmHome.SetActive(value: false);
			confirmExit.SetActive(value: false);
			settingsMenu.SetActive(value: false);
			levelsMenu.SetActive(value: false);
		}
	}

	public void RestartGame()
	{
		if (!isPoliceScene)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
		{
			SceneManager.LoadScene("Day2_Ceremony_Outside_Nighttime");
		}
	}

	public void OpenInventory()
	{
		inventoryUI.ToggleCamera();
	}

	public void LoadScene(string name)
	{
		pauseMenu.SetActive(value: false);
		Time.timeScale = 1f;
		isPaused = false;
		SceneManager.LoadScene(name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void SetPause(bool setPause)
	{
		isPaused = setPause;
	}

	public void StartGameOver()
	{
		SetActiveIfNotNull(ref gameOverMenu, isActive: true);
	}

	public void ShowRestartMenu()
	{
		restartMenu.GetComponent<CanvasGroup>().alpha = 0f;
		SetActiveIfNotNull(ref restartMenu, isActive: true);
		_firstPersonController.DisableInput();
	}

	public void ShowBushVignette(bool setActive)
	{
		bushVignette.SetActive(setActive);
	}

	public void SetKillTransition(bool setBool)
	{
		killMenu.SetActive(setBool);
	}

	private void SetActiveIfNotNull(ref GameObject obj, bool isActive)
	{
		if (obj != null)
		{
			obj.SetActive(isActive);
		}
		else
		{
			obj = pauseMenu;
		}
	}
}
