using Dissonance;
using Steamworks;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public bool started;

	public Transform cam;

	public Transform camCenter;

	public AudioSource busAudio;

	public GameObject playMenu;

	public GameObject mainMenu;

	public GameObject selectSaveFileMenu;

	private bool unableToPressPlay = true;

	public GameObject restartWarning;

	private void Awake()
	{
		PlayerPrefs.SetInt("", 0);
		Object.FindObjectOfType<DissonanceComms>().LocalPlayerName = PlayerPrefs.GetString("SteamName", "[PLAYER-NAME]");
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Wishlist()
	{
		Application.OpenURL("https://store.steampowered.com/app/3722330/Shift_At_Midnight/");
	}

	public void Video()
	{
		Application.OpenURL("https://youtu.be/ieTKkmTMfSg");
	}

	public void Discord()
	{
		Application.OpenURL("https://discord.gg/9HtMfkvTrQ");
	}

	public void StartGame()
	{
		Invoke("UnableToPressPlay", 1f);
		unableToPressPlay = true;
		PlayerPrefs.SetInt("BALLSBALLSBALLS", 0);
		PlayerPrefs.SetInt("TokenHint", 0);
		PlayerPrefs.SetInt("Day2", 0);
		PlayerPrefs.SetInt("StartDay2", 0);
		PlayerPrefs.SetInt("AskQuestion0", 0);
		PlayerPrefs.SetInt("AskQuestion", 0);
		PlayerPrefs.SetInt("CheckComputerHint", 0);
		PlayerPrefs.SetInt("AskQuestion1", 0);
		PlayerPrefs.SetInt("AskQuestion2", 0);
		PlayerPrefs.SetInt("AskQuestion3", 0);
		PlayerPrefs.SetInt("AskQuestion4", 0);
		PlayerPrefs.SetInt("AskQuestion5", 0);
		PlayerPrefs.SetInt("AskQuestion6", 0);
		PlayerPrefs.SetInt("AskQuestion7", 0);
		PlayerPrefs.SetInt("AskQuestion8", 0);
		PlayerPrefs.SetInt("FirstTimeCompletingTransaction", 0);
		PlayerPrefs.SetString("SteamName", SteamFriends.GetPersonaName());
		LoadGame();
	}

	private void UnableToPressPlay()
	{
		if (unableToPressPlay)
		{
			restartWarning.SetActive(value: true);
		}
	}

	private void LoadGame()
	{
		unableToPressPlay = false;
		playMenu.SetActive(value: true);
		mainMenu.SetActive(value: false);
	}

	public void LoadMenu()
	{
		selectSaveFileMenu.SetActive(value: false);
		playMenu.SetActive(value: false);
		mainMenu.SetActive(value: true);
	}

	private void Update()
	{
		if (started)
		{
			busAudio.volume = Mathf.Lerp(busAudio.volume, 0f, Time.deltaTime);
			cam.position = Vector3.Lerp(cam.position, camCenter.position, Time.deltaTime);
		}
	}
}
