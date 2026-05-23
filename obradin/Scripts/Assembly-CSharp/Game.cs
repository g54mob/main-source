using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	public enum Mode
	{
		Exploring = 0,
		InMoment = 1,
		InOffice = 2,
		Intro = 3
	}

	public enum SaveMilestone
	{
		Normal = 0,
		EditFate = 1,
		CorrectFates = 2
	}

	public Mode mode;

	public SceneRoot playSceneRoot;

	public Dialog dialog;

	private const string pauseSceneName = "Pause";

	private const string bookSceneName = "Book";

	private string activeSceneName;

	private bool justFinishedMoment;

	private float bookWantCloseRealtime;

	private static int allowBookUntilFrame;

	private static int blockPauseMenuUntilFrame;

	[SerializeField]
	private List<string> allSceneNames = new List<string>();

	private static bool canOpenBook
	{
		get
		{
			return Time.frameCount <= allowBookUntilFrame;
		}
	}

	public static Game instance { get; private set; }

	public static bool isExploring
	{
		get
		{
			return instance == null || instance.mode == Mode.Exploring;
		}
	}

	public static bool isInMoment
	{
		get
		{
			return instance != null && instance.mode == Mode.InMoment;
		}
	}

	public static bool isInOffice
	{
		get
		{
			return instance != null && instance.mode == Mode.InOffice;
		}
	}

	public static bool dialogIsPlaying
	{
		get
		{
			return instance != null && instance.dialog.isPlaying;
		}
	}

	private bool canOpenPauseMenu
	{
		get
		{
			return !Monitor.blackingOut && Player.instance != null && Player.instance.inputAndMovementEnabled && (dialog == null || !dialog.useMenuClock || !dialog.isPlaying) && Time.frameCount > blockPauseMenuUntilFrame;
		}
	}

	public static void AllowBookForOneFrame()
	{
		allowBookUntilFrame = Time.frameCount + 1;
	}

	public static void BlockPauseMenuForOneFrame()
	{
		blockPauseMenuUntilFrame = Time.frameCount + 1;
	}

	private void Awake()
	{
		instance = this;
		ScreenHelper.ApplyScreenResolution();
		RenderTargetPool.Flush();
	}

	private void Start()
	{
		activeSceneName = base.gameObject.scene.name;
		if (!SceneManager.GetSceneByName("Book").isLoaded)
		{
			SceneManager.LoadScene("Book", LoadSceneMode.Additive);
		}
		if (!SceneManager.GetSceneByName("Pause").isLoaded)
		{
			SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
		}
		if (mode == Mode.Exploring && dialog != null)
		{
			dialog.useMenuClock = true;
		}
		for (int i = 0; i < allSceneNames.Count; i++)
		{
			string sceneName = allSceneNames[i];
			DebugMenu.Add(string.Format("Scenes/{0:00} {1}", i, sceneName), KeyCode.None, delegate
			{
				StartCoroutine(DebugGiveAllAndLoadScene(sceneName));
			});
		}
		DebugMenu.Add("Rapture", KeyCode.None, DebugRapture);
	}

	private void OnEnable()
	{
		SaveData.it.onInventoryReceived.AddListener(OnInventoryReceived);
		SettingsMenu.onDone.AddListener(OnSettingsDone);
		SettingsMenu.onQuit.AddListener(OnSettingsQuit);
	}

	private void OnDisable()
	{
		SaveData.it.onInventoryReceived.RemoveListener(OnInventoryReceived);
		SettingsMenu.onDone.RemoveListener(OnSettingsDone);
		SettingsMenu.onQuit.RemoveListener(OnSettingsQuit);
	}

	private void Update()
	{
		bool buttonDown = RInput.GetButtonDown(28);
		if (buttonDown || (bookWantCloseRealtime > 0f && Time.realtimeSinceStartup < bookWantCloseRealtime + 0.25f))
		{
			if (activeSceneName == "Book")
			{
				if (!CloseBook() && buttonDown)
				{
					bookWantCloseRealtime = Time.realtimeSinceStartup;
				}
			}
			else if (Clock.play.running && Clock.play.time > 1f && canOpenBook && SaveData.it.HaveWatchAndBook())
			{
				ShowBook();
			}
		}
		if (!Monitor.blackingOut && RInput.GetButtonDown(27) && !(activeSceneName == "Book"))
		{
			if (activeSceneName == "Pause")
			{
				if (!(SettingsMenu.it != null))
				{
					ActivateScene(base.gameObject.scene);
				}
			}
			else if (canOpenPauseMenu)
			{
				SaveActive();
				ActivateScene(SceneManager.GetSceneByName("Pause"));
			}
		}
		if (activeSceneName != "Pause")
		{
			SaveData.it.general.playTime += Clock.active.deltaTime;
		}
		SaveData.it.DrawDebug();
	}

	private static void ActivateScene(Scene scene)
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			Scene sceneAt = SceneManager.GetSceneAt(i);
			if (!sceneAt.isLoaded)
			{
				continue;
			}
			GameObject[] rootGameObjects = sceneAt.GetRootGameObjects();
			foreach (GameObject gameObject in rootGameObjects)
			{
				SceneRoot component = gameObject.GetComponent<SceneRoot>();
				if (!(component != null))
				{
					continue;
				}
				component.Activate(sceneAt == scene);
				if (sceneAt == scene)
				{
					if (instance != null)
					{
						instance.activeSceneName = sceneAt.name;
					}
					Monitor.BlackOut(2);
				}
				break;
			}
		}
	}

	public static void LoadMomentScene(string momentId)
	{
		SceneManager.LoadScene(momentId, LoadSceneMode.Single);
	}

	public static bool IsInMoment(string momentId)
	{
		return momentId.StartsWith("d0") && SceneManager.GetSceneByName(momentId).isLoaded;
	}

	public static void LoadExploringScene()
	{
		Monitor.BlackOut(3);
		if (SaveData.it.general.era == 3)
		{
			SceneManager.LoadScene("Office", LoadSceneMode.Single);
		}
		else
		{
			SceneManager.LoadScene("Ship", LoadSceneMode.Single);
		}
	}

	public static void LoadStartingShip()
	{
		Monitor.BlackOut(3);
		SceneManager.LoadScene("Ship", LoadSceneMode.Single);
	}

	public static void LoadIntro()
	{
		Monitor.BlackOut(3);
		SceneManager.LoadScene("Intro", LoadSceneMode.Single);
	}

	public static void LoadTitle()
	{
		Monitor.BlackOut(3);
		SceneManager.LoadScene("Title", LoadSceneMode.Single);
	}

	public static void LoadCredits()
	{
		Monitor.BlackOut(3);
		SceneManager.LoadScene("Credits", LoadSceneMode.Single);
	}

	public static void LoadTally()
	{
		Monitor.BlackOut(3);
		SceneManager.LoadScene("Tally", LoadSceneMode.Single);
	}

	public static void LoadSave(string id)
	{
		if (SaveData.it.Load(id))
		{
			if (SaveData.it.generalRo.momentPlayerSpotId.HasValue())
			{
				LoadMomentScene(SaveData.it.generalRo.momentPlayerSpotId);
			}
			else
			{
				LoadExploringScene();
			}
		}
	}

	public static void SaveActive(SaveMilestone milestone = SaveMilestone.Normal)
	{
		string activeSaveId = Settings.activeSaveId;
		Save(activeSaveId);
		SaveData.MakeBackup(activeSaveId, "Recent");
		switch (milestone)
		{
		case SaveMilestone.EditFate:
			SaveData.MakeBackup(activeSaveId, "EditFate");
			break;
		case SaveMilestone.CorrectFates:
			SaveData.MakeBackup(activeSaveId, "CorrectFates", true);
			break;
		}
	}

	private static void Save(string saveId)
	{
		SaveData.it.Save(saveId);
	}

	public static bool IsValidScene(string sceneName)
	{
		int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath("Assets/Moments/Scenes/" + sceneName + ".unity");
		return buildIndexByScenePath >= 0;
	}

	public void RevealNewBookPages(string momentId)
	{
		ShowBook();
		if (Book.active != null)
		{
			Book.active.RevealNewPages(momentId);
		}
	}

	public bool RevealCompleteChapter(string disasterId)
	{
		ShowBook();
		if (Book.active != null)
		{
			Book.active.RevealCompleteChapter(disasterId);
			return true;
		}
		return false;
	}

	public void RevealBook(bool inOffice = false)
	{
		ShowBook();
		if (Book.active != null)
		{
			if (inOffice)
			{
				Book.active.RevealBookInOffice();
			}
			else
			{
				Book.active.RevealBook();
			}
		}
	}

	public void ShowDialog(string dialogId, Dialog.Extra extra = null)
	{
		if (dialog != null)
		{
			dialog.Play(dialogId, extra);
		}
	}

	public void ShowBook()
	{
		if (dialog == null || !dialog.isPlayingFullscreen)
		{
			Scene sceneByName = SceneManager.GetSceneByName("Book");
			if (sceneByName.isLoaded)
			{
				ActivateScene(sceneByName);
			}
		}
	}

	public bool CloseBook()
	{
		bookWantCloseRealtime = 0f;
		if (Book.canClose)
		{
			ActivateScene(base.gameObject.scene);
			return true;
		}
		return false;
	}

	public void DebugActivatePlayScene()
	{
		ActivateScene(base.gameObject.scene);
	}

	private void OnInventoryReceived(string inventoryId)
	{
		if (inventoryId == "manifest")
		{
			ShowBook();
		}
	}

	private void OnSettingsDone()
	{
		ActivateScene(base.gameObject.scene);
	}

	private void OnSettingsQuit()
	{
		LoadTitle();
	}

	public void OnApplicationFocus(bool focus)
	{
		if (!focus && canOpenPauseMenu)
		{
			SaveActive();
		}
	}

	private IEnumerator DebugGiveAllAndLoadScene(string sceneName)
	{
		yield return new WaitForSeconds(0.1f);
		SaveData.it.DebugGive();
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
	}

	public static void DebugRapture()
	{
		SaveData.it.DebugGive();
		foreach (Phantom item in Util.FindAllInActiveScene<Phantom>())
		{
			item.Force(true);
		}
		foreach (Lantern item2 in Util.FindAllInActiveScene<Lantern>())
		{
			item2.DebugForceOn();
		}
		foreach (VisHiderPartition item3 in Util.FindAllInActiveScene<VisHiderPartition>())
		{
			item3.DebugForceOn();
		}
	}
}
