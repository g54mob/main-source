using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SaveManager : MonoBehaviour
{
	[Serializable]
	public struct ModSave
	{
		public Module.Name name;

		public int index;

		public bool upgraded;

		public float slider;

		public float dial;

		public float dial360;

		public List<Aura.Type> specialAuras;

		public int counter;
	}

	[Serializable]
	public struct PlugSave
	{
		public int index0;

		public int index1;
	}

	[Serializable]
	public class RunData
	{
		public int currWave = 1;

		public int currDifficulty = 1;

		public int endlessLevel;

		public int gold;

		public List<ModSave> mods = new List<ModSave>();

		public List<PlugSave> plugConnections = new List<PlugSave>();

		public List<Perks.Type> perks = new List<Perks.Type>();

		public List<Module.Name> shopItems = new List<Module.Name>();

		public List<bool> shopUpg = new List<bool>();

		public bool shopLocked;

		public List<Perks.Type> perkItems = new List<Perks.Type>();

		public Dungeon.State state = Dungeon.State.Prep;

		public int playerRes;

		public List<ModSave> bank = new List<ModSave>();
	}

	public enum Language
	{
		English = 0,
		Japanese = 1
	}

	public enum Achievement
	{
		Ach0_Crypt = 0,
		Ach1_Water = 1,
		Ach2_Orbit = 2,
		Difficulty_1 = 3,
		Difficulty_2 = 4,
		Difficulty_3 = 5,
		Difficulty_4 = 6,
		Difficulty_5 = 7
	}

	[Serializable]
	public class VideoPrefs
	{
		public int resolution = 5;

		public bool fullscreen = true;

		public bool stretch;

		public VideoPrefs()
		{
			resolution = 5;
			fullscreen = true;
			stretch = false;
		}
	}

	[Serializable]
	public class GameSave
	{
		public List<bool> charUnlocks = new List<bool> { true, false, false };

		public int maxDiffUnlock;

		public int currDifficulty;

		public int currCharacter;

		public bool screenshake = true;

		public VideoPrefs videoPrefs = new VideoPrefs();

		public float musicScale = 0.5f;

		public float sfxScale = 0.5f;

		public List<Module.Name> collection = new List<Module.Name>
		{
			Module.Name.Sword,
			Module.Name.Horizontal,
			Module.Name.Vertical
		};

		public List<bool> tutorials = new List<bool> { false, false, false };

		public bool savedRun;

		public RunData currentRun;

		public bool soundInBackground = true;

		public Language language;

		public bool maxClear;
	}

	public static List<Aura.Type> permanentAuras = new List<Aura.Type>
	{
		Aura.Type.FoodBuff,
		Aura.Type.MinusCount,
		Aura.Type.BioSpeedBuff
	};

	private List<Module> loadedMods = new List<Module>();

	public static (int, int)[] resList = new(int, int)[10]
	{
		(480, 270),
		(960, 540),
		(1280, 800),
		(1366, 768),
		(1440, 810),
		(1920, 1080),
		(2400, 1350),
		(2560, 1440),
		(2880, 1620),
		(3840, 2160)
	};

	public GameSave saveData;

	public GameObject overlayObj;

	public GameObject clickBlocker;

	public GameObject clickBlockerRight;

	public GameObject[] tutorialMasks;

	private Board board => dungeon.board;

	private Dungeon dungeon => Dungeon.Instance;

	private LocalizationManager localizationManager => Dungeon.Instance.localizationManager;

	public void SaveRunData()
	{
		RunData runData = new RunData();
		runData.currWave = dungeon.currLevel;
		runData.currDifficulty = dungeon.saveData.currDifficulty;
		runData.gold = dungeon.gold;
		runData.endlessLevel = dungeon.endlessLevel;
		foreach (Module item4 in dungeon.board.GetBoard())
		{
			ModSave item = new ModSave
			{
				specialAuras = new List<Aura.Type>(),
				name = item4.name,
				index = item4.index,
				upgraded = item4.UPGRADED,
				slider = -1f,
				dial = -1f,
				dial360 = -1f,
				counter = item4.counter
			};
			foreach (Aura aura in item4.auras)
			{
				if (permanentAuras.Contains(aura.type))
				{
					item.specialAuras.Add(aura.type);
				}
			}
			Slider componentInChildren = item4.GetComponentInChildren<Slider>();
			if (componentInChildren != null)
			{
				item.slider = componentInChildren.GetVal();
			}
			Dial componentInChildren2 = item4.GetComponentInChildren<Dial>();
			if (componentInChildren2 != null)
			{
				item.dial = componentInChildren2.GetAngle();
			}
			Dial360 componentInChildren3 = item4.GetComponentInChildren<Dial360>();
			if (componentInChildren3 != null)
			{
				item.dial360 = componentInChildren3.GetAngle();
			}
			runData.mods.Add(item);
		}
		foreach (Module item5 in dungeon.bank.GetBank())
		{
			ModSave item2 = new ModSave
			{
				specialAuras = new List<Aura.Type>(),
				name = item5.name,
				index = item5.index,
				upgraded = item5.UPGRADED,
				slider = -1f,
				dial = -1f,
				dial360 = -1f,
				counter = item5.counter
			};
			foreach (Aura aura2 in item5.auras)
			{
				if (permanentAuras.Contains(aura2.type))
				{
					item2.specialAuras.Add(aura2.type);
				}
			}
			Slider componentInChildren4 = item5.GetComponentInChildren<Slider>();
			if (componentInChildren4 != null)
			{
				item2.slider = componentInChildren4.GetVal();
			}
			Dial componentInChildren5 = item5.GetComponentInChildren<Dial>();
			if (componentInChildren5 != null)
			{
				item2.dial = componentInChildren5.GetAngle();
			}
			Dial360 componentInChildren6 = item5.GetComponentInChildren<Dial360>();
			if (componentInChildren6 != null)
			{
				item2.dial360 = componentInChildren6.GetAngle();
			}
			runData.bank.Add(item2);
		}
		foreach (PerkDisplay perk in dungeon.perks.perks)
		{
			runData.perks.Add(perk.type);
		}
		int num = 0;
		List<Plug> list = new List<Plug>();
		List<(Plug, Plug)> list2 = new List<(Plug, Plug)>();
		Dictionary<Plug, int> dictionary = new Dictionary<Plug, int>();
		foreach (Module item6 in dungeon.board.GetBoard())
		{
			Plug[] plugs = item6.plugs;
			foreach (Plug plug in plugs)
			{
				if (plug.connected && !list.Contains(plug))
				{
					list.Add(plug.connectedPlug);
					list2.Add((plug, plug.connectedPlug));
				}
				list.Add(plug);
				dictionary.Add(plug, num);
				num++;
			}
		}
		foreach (var item7 in list2)
		{
			PlugSave item3 = new PlugSave
			{
				index0 = dictionary[item7.Item1],
				index1 = dictionary[item7.Item2]
			};
			runData.plugConnections.Add(item3);
		}
		runData.state = dungeon.state;
		if (runData.state == Dungeon.State.Prep || runData.state == Dungeon.State.Combat)
		{
			if (dungeon.toggleStateButton.bg.sprite == dungeon.shopIcon)
			{
				runData.state = Dungeon.State.Bank;
			}
			else
			{
				runData.state = Dungeon.State.Shop;
			}
			if (runData.currWave == 1 && !runData.perks.Contains(Perks.Type.Goblinized))
			{
				runData.state = Dungeon.State.Intro;
			}
		}
		runData.shopItems = new List<Module.Name>
		{
			Module.Name._COUNT,
			Module.Name._COUNT,
			Module.Name._COUNT,
			Module.Name._COUNT,
			Module.Name._COUNT,
			Module.Name._COUNT
		};
		runData.shopUpg = new List<bool> { false, false, false, false, false, false };
		foreach (Module module in dungeon.shop.modules)
		{
			runData.shopItems[module.index] = module.name;
			runData.shopUpg[module.index] = module.shopUpped;
		}
		foreach (UIButton button in dungeon.perks.buttons)
		{
			runData.perkItems.Add((Perks.Type)button.data);
		}
		runData.playerRes = dungeon.player.ressurects;
		saveData.currentRun = runData;
		SaveGame();
	}

	public void LoadRunData(RunData data)
	{
		List<Plug> list = new List<Plug>();
		foreach (ModSave mod in data.mods)
		{
			Module component = UnityEngine.Object.Instantiate(dungeon.moduleObjects[(int)mod.name]).GetComponent<Module>();
			loadedMods.Add(component);
			Plug[] plugs = component.plugs;
			foreach (Plug plug in plugs)
			{
				plug.owner = component;
				list.Add(plug);
			}
			foreach (Aura.Type specialAura in mod.specialAuras)
			{
				component.AddAura(specialAura);
			}
			if (mod.slider != -1f)
			{
				component.GetComponentInChildren<Slider>().Preset(mod.slider);
			}
			if (mod.dial != -1f)
			{
				component.GetComponentInChildren<Dial>().Preset(mod.dial);
			}
			if (mod.dial360 != -1f)
			{
				component.GetComponentInChildren<Dial360>().Preset(mod.dial360);
			}
			board.AddModule(component, mod.index);
			if (mod.upgraded)
			{
				board.UpgradeModule(component, silent: true, load: true);
			}
			component.counter = mod.counter;
		}
		foreach (ModSave item in data.bank)
		{
			Module component2 = UnityEngine.Object.Instantiate(dungeon.moduleObjects[(int)item.name]).GetComponent<Module>();
			loadedMods.Add(component2);
			Plug[] plugs = component2.plugs;
			foreach (Plug plug2 in plugs)
			{
				plug2.owner = component2;
				list.Add(plug2);
			}
			foreach (Aura.Type specialAura2 in item.specialAuras)
			{
				component2.AddAura(specialAura2);
			}
			if (item.slider != -1f)
			{
				component2.GetComponentInChildren<Slider>().Preset(item.slider);
			}
			if (item.dial != -1f)
			{
				component2.GetComponentInChildren<Dial>().Preset(item.dial);
			}
			if (item.dial360 != -1f)
			{
				component2.GetComponentInChildren<Dial360>().Preset(item.dial360);
			}
			dungeon.bank.AddModule(component2, item.index);
			if (item.upgraded)
			{
				board.UpgradeModule(component2, silent: true, load: true, bank: true);
			}
			component2.counter = item.counter;
		}
		foreach (Perks.Type perk in data.perks)
		{
			dungeon.perks.Select(perk, 0, test: true, loaded: true);
		}
		foreach (PlugSave plugConnection in data.plugConnections)
		{
			list[plugConnection.index0].ConnectTo(list[plugConnection.index1], manual: false);
		}
		dungeon.shop.LoadStock(data.shopItems, data.shopUpg);
		if (data.shopLocked != dungeon.shop.locked)
		{
			dungeon.shop.ToggleLock();
		}
		dungeon.perks.LoadPerkStock(data.perkItems);
		dungeon.currLevel = data.currWave;
		saveData.currDifficulty = data.currDifficulty;
		dungeon.gold = data.gold;
		dungeon.endlessLevel = data.endlessLevel;
		dungeon.SetEndless(data.endlessLevel > 0);
		dungeon.SetState(data.state);
		_ = dungeon.currLevel % 30;
		if (!dungeon.demo)
		{
			if (dungeon.currBranch == Dungeon.Branch.Water)
			{
				dungeon.animationManager.InstantWater();
			}
			if (dungeon.currBranch == Dungeon.Branch.Orbit)
			{
				dungeon.animationManager.InstantSpace();
			}
		}
		dungeon.player.ressurects = data.playerRes;
		foreach (Module testmod in dungeon.testmods)
		{
			if (!(testmod == null))
			{
				UnityEngine.Object.Destroy(testmod.gameObject);
			}
		}
		loadedMods.Clear();
	}

	public void UnloadCorruptData()
	{
		foreach (Module loadedMod in loadedMods)
		{
			dungeon.DestroyWeapon(loadedMod);
			UnityEngine.Object.Destroy(loadedMod.gameObject);
		}
		loadedMods.Clear();
	}

	public void SetScreen()
	{
		int preferredRefreshRate = 60;
		QualitySettings.vSyncCount = 0;
		PixelPerfectCamera component = Camera.main.GetComponent<PixelPerfectCamera>();
		(int, int) tuple = resList[saveData.videoPrefs.resolution];
		Screen.SetResolution(tuple.Item1, tuple.Item2, saveData.videoPrefs.fullscreen, preferredRefreshRate);
		if (tuple.Item2 == 800 || tuple.Item2 == 768 || saveData.videoPrefs.stretch)
		{
			float num = 1f;
			component.refResolutionX = (int)(480f * num);
			component.refResolutionY = (int)(270f * num);
			component.assetsPPU = (int)(16f * num);
			component.cropFrame = PixelPerfectCamera.CropFrame.StretchFill;
		}
		else
		{
			component.refResolutionX = 480;
			component.refResolutionY = 270;
			component.assetsPPU = 16;
			component.cropFrame = PixelPerfectCamera.CropFrame.Windowbox;
		}
	}

	public void CheckAchievements()
	{
		if (saveData.maxDiffUnlock > 0)
		{
			SteamManager.UnlockAchievement(Achievement.Ach0_Crypt);
			SteamManager.UnlockAchievement(Achievement.Ach1_Water);
			SteamManager.UnlockAchievement(Achievement.Ach2_Orbit);
			SteamManager.UnlockAchievement(Achievement.Difficulty_1);
		}
		if (saveData.maxDiffUnlock > 1)
		{
			SteamManager.UnlockAchievement(Achievement.Difficulty_2);
		}
		if (saveData.maxDiffUnlock > 2)
		{
			SteamManager.UnlockAchievement(Achievement.Difficulty_3);
		}
		if (saveData.maxDiffUnlock > 3)
		{
			SteamManager.UnlockAchievement(Achievement.Difficulty_4);
		}
		if (saveData.maxClear)
		{
			SteamManager.UnlockAchievement(Achievement.Difficulty_5);
		}
	}

	public void LoadGame()
	{
		string saveDir = GetSaveDir();
		string path = saveDir + "/save.json";
		string path2 = saveDir + "/video.prefs";
		if (File.Exists(path))
		{
			try
			{
				string json = File.ReadAllText(path);
				saveData = JsonUtility.FromJson<GameSave>(json);
			}
			catch
			{
				Debug.Log("Error loading game save");
				File.Create(path).Close();
				saveData = new GameSave();
				if (SteamManager.OnSteamDeck())
				{
					saveData.videoPrefs.resolution = 2;
					saveData.videoPrefs.fullscreen = true;
				}
				if (Application.systemLanguage == SystemLanguage.Japanese)
				{
					saveData.language = Language.Japanese;
				}
				else
				{
					saveData.language = Language.English;
				}
				string contents = JsonUtility.ToJson(saveData);
				File.WriteAllText(path, contents);
			}
		}
		else
		{
			File.Create(path).Close();
			saveData = new GameSave();
			if (SteamManager.OnSteamDeck())
			{
				saveData.videoPrefs.resolution = 2;
				saveData.videoPrefs.fullscreen = true;
			}
			if (Application.systemLanguage == SystemLanguage.Japanese)
			{
				saveData.language = Language.Japanese;
			}
			else
			{
				saveData.language = Language.English;
			}
			string contents2 = JsonUtility.ToJson(saveData);
			File.WriteAllText(path, contents2);
		}
		VideoPrefs videoPrefs = new VideoPrefs();
		if (File.Exists(path2))
		{
			try
			{
				videoPrefs = JsonUtility.FromJson<VideoPrefs>(File.ReadAllText(path2));
			}
			catch
			{
				Debug.Log("Error loading video prefs");
				File.Create(path2).Close();
				videoPrefs = new VideoPrefs();
				if (Screen.currentResolution.height > 1080)
				{
					videoPrefs.resolution = 5;
				}
				if (Screen.currentResolution.height > 1620)
				{
					videoPrefs.resolution = 8;
				}
				if (SteamManager.OnSteamDeck())
				{
					videoPrefs.resolution = 2;
					videoPrefs.fullscreen = true;
				}
				string contents3 = JsonUtility.ToJson(videoPrefs);
				File.WriteAllText(path2, contents3);
			}
		}
		else
		{
			File.Create(path2).Close();
			videoPrefs = new VideoPrefs();
			if (Screen.currentResolution.height > 1080)
			{
				videoPrefs.resolution = 5;
			}
			if (Screen.currentResolution.height > 1620)
			{
				videoPrefs.resolution = 8;
			}
			if (SteamManager.OnSteamDeck())
			{
				videoPrefs.resolution = 2;
				videoPrefs.fullscreen = true;
			}
			string contents4 = JsonUtility.ToJson(videoPrefs);
			File.WriteAllText(path2, contents4);
		}
		saveData.videoPrefs = videoPrefs;
		ApplySettings(!dungeon.restartManager.restarter && !dungeon.restartManager.menuTransition);
	}

	public void ApplySettings(bool intro = false)
	{
		dungeon.localizationManager.SetLang(saveData.language);
		dungeon.audioManager.musicScale = saveData.musicScale * 10f;
		dungeon.audioManager.sfxScale = saveData.sfxScale * 10f;
		if (intro)
		{
			SetScreen();
		}
	}

	public void SaveGame()
	{
		string saveDir = GetSaveDir();
		string path = saveDir + "/save.json";
		string path2 = saveDir + "/video.prefs";
		string contents = JsonUtility.ToJson(saveData);
		File.WriteAllText(path, contents);
		contents = JsonUtility.ToJson(saveData.videoPrefs);
		File.WriteAllText(path2, contents);
	}

	public string GetSaveDir()
	{
		string text = "000";
		text = (SteamManager.Initialized ? SteamManager.GetID() : ((!File.Exists(Application.dataPath + "/steamID.dat")) ? "000" : File.ReadAllText(Application.dataPath + "/steamID.dat")));
		string text2;
		if (text == "000")
		{
			text2 = Application.dataPath + "/OfflineData/";
		}
		else
		{
			text2 = Application.dataPath + "/UserData/" + text + "/";
		}
		text2 = Application.dataPath + "/UserData/" + text + "/";
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		return text2;
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	public void CheckDemo()
	{
		if (!dungeon.demo)
		{
			return;
		}
		int num = 0;
		List<GameObject> list = new List<GameObject>();
		GameObject[] moduleObjects = dungeon.moduleObjects;
		foreach (GameObject item in moduleObjects)
		{
			if (Module.demoMods.Contains((Module.Name)(num++)))
			{
				list.Add(item);
			}
			else
			{
				list.Add(null);
			}
		}
		dungeon.moduleObjects = list.ToArray();
	}

	public void PopupTutorial(int i)
	{
		switch (i)
		{
		case 0:
			StartCoroutine(Tutorial0());
			break;
		case 1:
			StartCoroutine(Tutorial1());
			break;
		}
	}

	public void SetTutorialTip((string, string) tutMessage, Vector3 pos)
	{
		dungeon.tooltip.locked = false;
		dungeon.tooltip.Hide();
		dungeon.tooltip.currMod = null;
		dungeon.tooltip.Set(null, showUpgrade: false, noUpgrade: false, null, tutMessage.Item1, tutMessage.Item2, pos, force: true);
		dungeon.tooltip.locked = true;
	}

	public void EndTutorialTip()
	{
		dungeon.tooltip.locked = false;
		dungeon.tooltip.Hide(force: true);
		if (dungeon.hoveredModule != null)
		{
			dungeon.tooltip.Set(dungeon.hoveredModule, showUpgrade: false, noUpgrade: false, null, "", "", default(Vector3), force: true);
		}
	}

	private IEnumerator Tutorial0()
	{
		clickBlocker.SetActive(value: true);
		yield return Dungeon.Wait(30);
		GameObject g = UnityEngine.Object.Instantiate(tutorialMasks[0]);
		GameObject overlay = UnityEngine.Object.Instantiate(overlayObj);
		g.transform.localScale = Vector3.zero;
		dungeon.audioManager.SetMusicLowpass(active: true);
		overlay.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
		for (int i = 0; i < 10; i++)
		{
			overlay.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, 0.1f);
			yield return null;
		}
		SetTutorialTip(localizationManager.GetTutorialMessage(0), new Vector3(-5f, 3.03125f));
		yield return Dungeon.Wait(10);
		g.transform.localScale = Vector3.zero;
		dungeon.animationManager.LerpZoom(g, Vector3.one, 9f, 0.2f, destroy: false, UI: true);
		g.transform.position = new Vector3(-11.92f, 2.085f, 0f);
		yield return WaitTutorialInput();
		SetTutorialTip(localizationManager.GetTutorialMessage(1), new Vector3(-5f, 1f / 32f));
		yield return WaitTutorialInput();
		SetTutorialTip(localizationManager.GetTutorialMessage(2), new Vector3(-5f, 1.53125f));
		yield return WaitTutorialInput();
		SetTutorialTip(localizationManager.GetTutorialMessage(3), new Vector3(7.30125f, -1.0175f, 0f));
		yield return Dungeon.Wait(10);
		GameObject g2 = UnityEngine.Object.Instantiate(tutorialMasks[1]);
		g2.transform.localScale = Vector3.zero;
		dungeon.animationManager.LerpZoom(g2, Vector3.one, 9f, 0.2f, destroy: false, UI: true);
		clickBlocker.SetActive(value: false);
		clickBlockerRight.SetActive(value: true);
		yield return WaitTutorialInput();
		clickBlockerRight.SetActive(value: false);
		EndTutorialTip();
		saveData.tutorials[0] = true;
		SaveGame();
		dungeon.audioManager.SetMusicLowpass(active: false);
		for (int i = 0; i < 10; i++)
		{
			overlay.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.1f);
			g.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.1f);
			g2.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.1f);
			yield return null;
		}
		UnityEngine.Object.Destroy(overlay);
		UnityEngine.Object.Destroy(g);
		UnityEngine.Object.Destroy(g2);
	}

	private IEnumerator Tutorial1()
	{
		clickBlocker.SetActive(value: true);
		yield return Dungeon.Wait(30);
		GameObject g = UnityEngine.Object.Instantiate(tutorialMasks[2]);
		GameObject g2 = UnityEngine.Object.Instantiate(tutorialMasks[2]);
		GameObject overlay = UnityEngine.Object.Instantiate(overlayObj);
		g.transform.localScale = Vector3.zero;
		g2.transform.localScale = Vector3.zero;
		overlay.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
		dungeon.audioManager.SetMusicLowpass(active: true);
		for (int i = 0; i < 10; i++)
		{
			overlay.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, 0.1f);
			yield return null;
		}
		Vector3 sP = Vector3.zero;
		Vector3 pos = Vector3.zero;
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.name == Module.Name.Sword)
			{
				int index = item.index;
				pos = (((uint)(index - 2) > 2u && (uint)(index - 7) > 2u) ? new Vector3(-4.44875f, 0.47125f, 0f) : new Vector3(1.61f, -3.15f, 0f));
				sP = item.transform.position;
				break;
			}
		}
		SetTutorialTip(localizationManager.GetTutorialMessage(4), pos);
		yield return Dungeon.Wait(10);
		dungeon.animationManager.LerpZoom(g, Vector3.one, 9f, 0.2f, destroy: false, UI: true);
		dungeon.animationManager.LerpZoom(g2, Vector3.one, 9f, 0.2f, destroy: false, UI: true);
		g.transform.position = sP;
		g2.transform.position = dungeon.shop.modules[0].transform.position;
		clickBlocker.SetActive(value: false);
		yield return WaitTutorialInput();
		EndTutorialTip();
		saveData.tutorials[1] = true;
		SaveGame();
		dungeon.audioManager.SetMusicLowpass(active: false);
		for (int i = 0; i < 10; i++)
		{
			overlay.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.1f);
			g.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.1f);
			g2.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.1f);
			yield return null;
		}
		UnityEngine.Object.Destroy(overlay);
		UnityEngine.Object.Destroy(g);
		UnityEngine.Object.Destroy(g2);
	}

	private IEnumerator WaitTutorialInput()
	{
		yield return Dungeon.Wait(30);
		while (!Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse2) && !Input.GetKeyDown(KeyCode.Space))
		{
			yield return null;
		}
	}
}
