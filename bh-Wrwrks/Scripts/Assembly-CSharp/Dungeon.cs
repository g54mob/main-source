using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Dungeon : MonoBehaviour
{
	public enum Branch
	{
		Crypt = 0,
		Water = 1,
		Orbit = 2
	}

	public enum State
	{
		Intro = 0,
		Combat = 1,
		Shop = 2,
		Prep = 3,
		Perk = 4,
		Bank = 5
	}

	public enum Unlock
	{
		Wizard = 0,
		Goblin = 1,
		Difficulty = 2
	}

	public class LevelInfo
	{
		public List<Monster.Type> monsters = new List<Monster.Type>();

		public int count;

		public int delay = 40;

		public void Add(Monster.Type type, int number)
		{
			if (Instance.moreEnemies && type != Monster.Type.Gold && type != Monster.Type.Gold_Naga && type != Monster.Type.Gold_UFO)
			{
				number = (int)(1.5f * (float)number);
			}
			for (int i = 0; i < number; i++)
			{
				monsters.Add(type);
			}
			monsters = Utils.Shuffle(monsters);
		}
	}

	public Monster.Type testMonster;

	public Perks.Type testPerk;

	public Module.Name testMod;

	public bool godMode;

	public bool testMode;

	public bool demo;

	public AnimationManager animationManager;

	public AudioManager audioManager;

	public SaveManager saveManager;

	public LocalizationManager localizationManager;

	public RestartManager restartManager;

	public Mainmenu mainmenu;

	public Material shadowMat;

	public GameObject healthbarObject;

	public GameObject[] monsterObjects;

	public GameObject[] moduleObjects;

	public GameObject[] modHighlights;

	public GameObject[] modUpgrades;

	public Sprite[] modHighlightUpgrades;

	public GameObject LightningEffect;

	public GameObject StunEffect;

	public UIButton fsButton;

	public UIButton resButton;

	public UIButton sfxButton;

	private static Dungeon _instance;

	public bool targeting;

	public bool movingMods;

	public Plug activePlug;

	public Player player;

	public Board board;

	public Shop shop;

	public Bank bank;

	public Perks perks;

	public Tooltip tooltip;

	public TMP_Text hpText;

	public TMP_Text goldText;

	public TMP_Text waveText;

	public DPS_Meter DPS = new DPS_Meter();

	public GameObject clearPopup;

	public TMP_Text[] clearPopupTexts;

	public bool paused;

	private int _gold;

	public Module hoveredModule;

	public Module draggingModule;

	private int _currLevel = 1;

	public Dictionary<Module, Weapon> weaponMods = new Dictionary<Module, Weapon>();

	private ushort wepcount;

	public State state;

	public Sprite bankIcon;

	public Sprite shopIcon;

	public UIButton toggleShopButton;

	public UIButton nextRoundButton;

	public UIButton toggleBankButton;

	public UIButton toggleStateButton;

	public UIButton dpsButton;

	public bool combat;

	public UIButton gameOverButton;

	public UIButton endlessButton;

	public UIButton retryButton;

	public bool gameover;

	private bool endless;

	public int endlessLevel;

	public List<Unlock> unlockList = new List<Unlock>();

	public List<string> unlockStrings = new List<string>();

	public const int maxDifficulty = 4;

	public BossBar bossBar;

	public List<Monster> livingEnemies = new List<Monster>();

	public List<Module> testmods;

	public static Vector3 menuCamera = new Vector3(-50f, 0f, -50f);

	public static Vector3 gameCamera = new Vector3(0f, 0f, -50f);

	public static (int, int)[] resList = new(int, int)[6]
	{
		(1920, 1080),
		(1440, 810),
		(960, 540),
		(480, 270),
		(2880, 1620),
		(2400, 1350)
	};

	public int res = 1;

	public bool fullscreen;

	private bool soundInBackground = true;

	public bool harderEnemies => difficulty >= 1;

	public bool moreEnemies => difficulty >= 2;

	public bool harderBosses => difficulty >= 3;

	public bool fasterEnemies => difficulty >= 4;

	public LocalizationManager.Locale currentLocale => localizationManager.currentLocale;

	public SaveManager.GameSave saveData => saveManager.saveData;

	public Branch currBranch
	{
		get
		{
			if (demo)
			{
				return Branch.Crypt;
			}
			int num = currLevel % 30;
			if (num == 0)
			{
				return Branch.Orbit;
			}
			if (num <= 10 && num != 0)
			{
				return Branch.Crypt;
			}
			if (num <= 20)
			{
				return Branch.Water;
			}
			return Branch.Orbit;
		}
	}

	public Monster.Type randomMonster
	{
		get
		{
			List<Monster.Type> list = new List<Monster.Type>();
			switch (currBranch)
			{
			case Branch.Crypt:
				list.AddRange(new List<Monster.Type>
				{
					Monster.Type.Soldier,
					Monster.Type.Skull,
					Monster.Type.Archer,
					Monster.Type.Wizard,
					Monster.Type.Redbat
				});
				break;
			case Branch.Water:
				list.AddRange(new List<Monster.Type>
				{
					Monster.Type.Naga_Soldier,
					Monster.Type.Fishbones,
					Monster.Type.Submarine,
					Monster.Type.Red_Jellyfish,
					Monster.Type.Naga_Tank
				});
				break;
			case Branch.Orbit:
				list.AddRange(new List<Monster.Type>
				{
					Monster.Type.UFO_Soldier,
					Monster.Type.Drill,
					Monster.Type.Asteroid_L,
					Monster.Type.Rocket_Soldier,
					Monster.Type.Deathbot
				});
				break;
			}
			return Utils.RandElem(list);
		}
	}

	public static Dungeon Instance => _instance;

	public int currLevel
	{
		get
		{
			return _currLevel;
		}
		set
		{
			_currLevel = value;
			string text = GetText(LocalizationManager.Text.Wave);
			string text2 = GetText(LocalizationManager.Text.Endless);
			if (value <= maxLevel)
			{
				waveText.text = text + " " + value.ToString("00") + "/" + maxLevel.ToString("00");
			}
			else
			{
				waveText.text = text2 + " " + value.ToString("00");
			}
		}
	}

	public int gold
	{
		get
		{
			return _gold;
		}
		set
		{
			if (value > gold && state == State.Combat)
			{
				audioManager.PlaySound(AudioManager.Sound.Gold);
			}
			_gold = value;
			board.TriggerModules(Trigger.Type.Gold);
			shop.CheckPrices();
			goldText.text = $"${_gold}";
		}
	}

	public int maxLevel
	{
		get
		{
			if (!demo)
			{
				return 30;
			}
			return 10;
		}
	}

	public int character => saveData.currCharacter;

	public int difficulty => saveData.currDifficulty;

	public GameObject InstantiateExternal(GameObject g)
	{
		return UnityEngine.Object.Instantiate(g);
	}

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
		Camera.main.transform.position = menuCamera;
		restartManager = UnityEngine.Object.FindObjectOfType<RestartManager>();
		saveManager.CheckDemo();
		saveManager.LoadGame();
		currLevel = 1;
		animationManager.Precook();
	}

	private void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		saveManager.CheckAchievements();
	}

	public void CheckWeapons()
	{
		List<Module> list = new List<Module>(board.modules);
		list.AddRange(board.extraModules);
		foreach (Module item in list)
		{
			if (!(item == null) && item.WEAPON && !weaponMods.ContainsKey(item))
			{
				CreateWeapon(item);
			}
		}
		List<Module> list2 = new List<Module>();
		foreach (Module key in weaponMods.Keys)
		{
			if (!(key == null) && !list.Contains(key))
			{
				list2.Add(key);
			}
		}
		foreach (Module item2 in list2)
		{
			DestroyWeapon(item2);
		}
	}

	public void CreateWeapon(Module m)
	{
		if (!weaponMods.ContainsKey(m))
		{
			Weapon component = UnityEngine.Object.Instantiate(m.weaponObj).GetComponent<Weapon>();
			component.owner = m;
			component.side = wepcount++ % 2;
			weaponMods.Add(m, component);
			component.transform.SetParent(player.transform);
			component.transform.localPosition = Vector3.zero;
		}
	}

	public void DestroyWeapon(Module m)
	{
		if (weaponMods.ContainsKey(m))
		{
			UnityEngine.Object.Destroy(weaponMods[m].gameObject);
			weaponMods.Remove(m);
		}
	}

	public void EndTargeting()
	{
		targeting = false;
		activePlug = null;
	}

	public void ClickPlug(Plug p)
	{
		if (state == State.Combat)
		{
			board.CombatError(p.owner);
		}
		else
		{
			if (movingMods)
			{
				return;
			}
			if (targeting && activePlug != null)
			{
				Plug plug = activePlug;
				if (!activePlug.ConnectTo(p, manual: true))
				{
					if (plug != p)
					{
						audioManager.PlaySound(AudioManager.Sound.UI_Error);
					}
					else
					{
						audioManager.PlaySound(AudioManager.Sound.StartWire);
					}
				}
				else
				{
					audioManager.PlaySound(AudioManager.Sound.StartWire);
					activePlug = null;
					targeting = false;
				}
			}
			else
			{
				audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f);
				activePlug = p;
				targeting = true;
				p.StartConnection();
			}
		}
	}

	public void ToggleShop()
	{
		if (state == State.Shop)
		{
			SetState(State.Prep);
		}
		else if (state == State.Prep)
		{
			SetState(State.Shop);
		}
	}

	public void ToggleBank()
	{
		if (state == State.Bank)
		{
			SetState(State.Prep);
		}
		else if (state == State.Prep)
		{
			SetState(State.Bank);
		}
	}

	public void ToggleState()
	{
		tooltip.Hide(force: true);
		if (toggleStateButton.bg.sprite == bankIcon)
		{
			SetState(State.Bank);
		}
		else if (toggleStateButton.bg.sprite == shopIcon)
		{
			SetState(State.Shop);
		}
	}

	public void SetState(State s)
	{
		State state = this.state;
		this.state = s;
		board.UnhighlightAllUpgrades();
		if (s != State.Shop || state != State.Prep)
		{
			saveData.savedRun = true;
			saveManager.SaveRunData();
		}
		switch (this.state)
		{
		case State.Intro:
			animationManager.LerpZoom(bank.gameObject, Vector3.zero, 8f);
			animationManager.LerpTo(shop.gameObject, new Vector3(shop.transform.position.x, 20f), 15, 0.2f);
			toggleShopButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleShopButton.gameObject, Vector3.zero, 10f, 0.2f);
			animationManager.LerpZoom(perks.gameObject, Vector3.zero, 8f);
			nextRoundButton.hitbox.enabled = true;
			animationManager.LerpZoom(nextRoundButton.gameObject, Vector3.one, 10f, 0.2f);
			toggleBankButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleBankButton.gameObject, Vector3.zero, 10f, 0.2f);
			break;
		case State.Combat:
			animationManager.LerpTo(shop.gameObject, new Vector3(shop.transform.position.x, 20f), 15, 0.2f);
			animationManager.LerpZoom(bank.gameObject, Vector3.zero, 8f);
			animationManager.LerpZoom(perks.gameObject, Vector3.zero, 8f);
			toggleShopButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleShopButton.gameObject, Vector3.zero, 10f);
			nextRoundButton.hitbox.enabled = false;
			animationManager.LerpZoom(nextRoundButton.gameObject, Vector3.zero, 10f);
			animationManager.LerpZoom(dpsButton.gameObject, Vector3.zero, 10f);
			toggleBankButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleBankButton.gameObject, Vector3.zero, 10f);
			toggleStateButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleStateButton.gameObject, Vector3.zero, 10f);
			break;
		case State.Shop:
			animationManager.LerpZoom(perks.gameObject, Vector3.zero, 8f);
			animationManager.LerpZoom(bank.gameObject, Vector3.zero, 8f);
			if (Camera.main.transform.position.x > -20f)
			{
				audioManager.PlaySound(AudioManager.Sound.Shop);
			}
			animationManager.LerpTo(shop.gameObject, new Vector3(shop.transform.position.x, 0f), 15, 0.2f);
			if (shop.gameObject.transform.localScale == Vector3.zero)
			{
				if (shop.transform.localPosition.y != 0f)
				{
					animationManager.LerpZoom(shop.gameObject, Vector3.one, 2f, 0.2f);
				}
				else
				{
					animationManager.LerpZoom(shop.gameObject, Vector3.one, 8f, 0.2f);
				}
			}
			if (state != State.Prep && state != State.Bank)
			{
				toggleStateButton.hitbox.enabled = true;
				animationManager.LerpZoom(toggleStateButton.gameObject, Vector3.one, 10f, 0.2f);
			}
			if (toggleStateButton.bg.sprite == shopIcon || state != State.Prep)
			{
				toggleShopButton.hitbox.enabled = true;
				animationManager.LerpZoom(toggleShopButton.gameObject, Vector3.one, 10f, 0.2f);
			}
			nextRoundButton.hitbox.enabled = false;
			animationManager.LerpZoom(nextRoundButton.gameObject, Vector3.zero, 10f);
			shop.CheckPrices();
			toggleBankButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleBankButton.gameObject, Vector3.zero, 10f);
			toggleShopButton.bg.sprite = currentLocale.hideShopButton;
			toggleStateButton.bg.sprite = bankIcon;
			break;
		case State.Prep:
			animationManager.LerpZoom(shop.gameObject, Vector3.zero, 8f);
			animationManager.LerpZoom(bank.gameObject, Vector3.zero, 8f);
			nextRoundButton.hitbox.enabled = true;
			animationManager.LerpZoom(nextRoundButton.gameObject, Vector3.one, 10f, 0.2f);
			toggleShopButton.bg.sprite = currentLocale.showShopButton;
			toggleBankButton.bg.sprite = currentLocale.showBankButton;
			break;
		case State.Bank:
			animationManager.LerpZoom(shop.gameObject, Vector3.zero, 8f);
			animationManager.LerpZoom(bank.gameObject, Vector3.one, 8f, 0.2f);
			nextRoundButton.hitbox.enabled = false;
			animationManager.LerpZoom(nextRoundButton.gameObject, Vector3.zero, 10f);
			if (Camera.main.transform.position.x > -20f)
			{
				audioManager.PlaySound(AudioManager.Sound.Shop);
			}
			if (state != State.Shop && state != State.Prep)
			{
				toggleStateButton.hitbox.enabled = true;
				animationManager.LerpZoom(toggleStateButton.gameObject, Vector3.one, 10f, 0.2f);
			}
			if (toggleStateButton.bg.sprite == bankIcon || state != State.Prep)
			{
				toggleBankButton.hitbox.enabled = true;
				animationManager.LerpZoom(toggleBankButton.gameObject, Vector3.one, 10f, 0.2f);
			}
			toggleShopButton.hitbox.enabled = false;
			animationManager.LerpZoom(toggleShopButton.gameObject, Vector3.zero, 10f);
			toggleBankButton.bg.sprite = currentLocale.hideBankButton;
			toggleStateButton.bg.sprite = shopIcon;
			break;
		case State.Perk:
			animationManager.LerpZoom(perks.gameObject, Vector3.one, 8f, 0.2f);
			break;
		}
	}

	public void StartRound()
	{
		if (state != State.Combat)
		{
			SetState(State.Combat);
			AudioManager.Music music = AudioManager.Music.Battle;
			if (currBranch == Branch.Orbit)
			{
				music = AudioManager.Music.Battle_Orbit;
			}
			else if (currBranch == Branch.Water)
			{
				music = AudioManager.Music.Battle_Water;
			}
			if (demo)
			{
				music = AudioManager.Music.Battle;
			}
			if (currLevel == 1)
			{
				animationManager.StartCoroutine(animationManager.PopUpBranch(0));
			}
			if (music != AudioManager.Music.Battle_Orbit)
			{
				audioManager.SwitchMusic(music);
			}
			board.TriggerModules(Trigger.Type.Start);
			combat = true;
			StartCoroutine(spawner(GenerateLevel(currLevel)));
		}
	}

	public void EndRound(bool endless = false)
	{
		if (gameover || player.health <= 0)
		{
			return;
		}
		combat = false;
		DPS.ResetDamage();
		if (currLevel == 10 && !demo)
		{
			SteamManager.UnlockAchievement(SaveManager.Achievement.Ach0_Crypt);
			if (!saveData.charUnlocks[1] && !demo)
			{
				unlockList.Add(Unlock.Wizard);
				saveData.charUnlocks[1] = true;
				saveManager.SaveGame();
			}
		}
		if (currLevel == 20 && !demo)
		{
			SteamManager.UnlockAchievement(SaveManager.Achievement.Ach1_Water);
			if (!saveData.charUnlocks[2])
			{
				unlockList.Add(Unlock.Goblin);
				saveData.charUnlocks[2] = true;
				saveManager.SaveGame();
			}
		}
		if (currLevel == maxLevel)
		{
			if (currLevel == 30)
			{
				SteamManager.UnlockAchievement(SaveManager.Achievement.Ach2_Orbit);
			}
			if (saveData.currDifficulty == 4)
			{
				saveData.maxClear = true;
			}
			if (saveData.currDifficulty < 4 && saveData.currDifficulty == saveData.maxDiffUnlock && !this.endless)
			{
				_ = demo;
				unlockList.Add(Unlock.Difficulty);
				saveData.currDifficulty++;
				saveData.maxDiffUnlock++;
				if (!endless)
				{
					SteamManager.UnlockAchievement((SaveManager.Achievement)(3 + (saveData.maxDiffUnlock - 1)));
				}
			}
			saveManager.SaveGame();
		}
		if (currLevel == maxLevel && !endless)
		{
			GameOver(win: true);
		}
		else
		{
			StartCoroutine(EndRoundSequence());
		}
	}

	public void SetEndless(bool s)
	{
		endless = s;
	}

	public void StartEndless()
	{
		gameover = false;
		saveData.savedRun = true;
		saveManager.SaveRunData();
		gameOverButton.transform.localScale = Vector3.zero;
		endlessButton.transform.localScale = Vector3.zero;
		gameOverButton.hitbox.enabled = false;
		endlessButton.hitbox.enabled = false;
		endless = true;
		EndRound(endless: true);
	}

	public void GameOver(bool win)
	{
		if (!gameover)
		{
			gameover = true;
			RestartManager.Instance.win = win;
			saveData.savedRun = false;
			saveManager.SaveGame();
			StartCoroutine(GameOverSequence(win));
		}
	}

	public string GetText(LocalizationManager.Text t)
	{
		return localizationManager.GetText(t);
	}

	private void ParseUnlocks(bool win)
	{
		unlockStrings.Clear();
		if (unlockList.Count == 0)
		{
			return;
		}
		bool flag = unlockList.Count >= 3;
		if (!flag)
		{
			unlockStrings.Add(GetText(LocalizationManager.Text.Unlock));
		}
		foreach (Unlock unlock in unlockList)
		{
			switch (unlock)
			{
			case Unlock.Wizard:
				if (flag)
				{
					unlockStrings.Add(GetText(LocalizationManager.Text.UnlockWizard));
				}
				else
				{
					unlockStrings.Add(GetText(LocalizationManager.Text.Wizard));
				}
				break;
			case Unlock.Goblin:
				if (flag)
				{
					unlockStrings.Add(GetText(LocalizationManager.Text.UnlockGoblin));
				}
				else
				{
					unlockStrings.Add(GetText(LocalizationManager.Text.Goblin));
				}
				break;
			case Unlock.Difficulty:
				if (flag)
				{
					unlockStrings.Add(GetText(LocalizationManager.Text.DifficultyAdd));
				}
				else
				{
					unlockStrings.Add(GetText(LocalizationManager.Text.UnlockDifficulty));
				}
				break;
			}
		}
		unlockList.Clear();
	}

	private IEnumerator GameOverSequence(bool win)
	{
		yield return Wait(90);
		gameOverButton.hitbox.enabled = false;
		endlessButton.hitbox.enabled = false;
		retryButton.hitbox.enabled = false;
		gameOverButton.transform.localScale = Vector3.zero;
		endlessButton.transform.localScale = Vector3.zero;
		retryButton.transform.localScale = Vector3.zero;
		ParseUnlocks(win);
		clearPopupTexts[3].text = (win ? ((demo ? GetText(LocalizationManager.Text.Win) : GetText(LocalizationManager.Text.Win)) + " \n===============\n") : (GetText(LocalizationManager.Text.Lose) + "\n===============\n"));
		clearPopupTexts[3].transform.localPosition = new Vector3(1f / 32f, -0.43f);
		clearPopupTexts[3].alignment = TextAlignmentOptions.Top;
		clearPopupTexts[3].lineSpacing = 0f;
		clearPopupTexts[0].text = "";
		clearPopupTexts[1].text = "";
		clearPopupTexts[2].text = "";
		bool num = (unlockStrings.Count > 0 && unlockStrings.Count < 3) || (demo && win && unlockStrings.Count > 0);
		if (unlockStrings.Count == 0)
		{
			clearPopupTexts[3].lineSpacing = 18.98f;
			unlockStrings.Insert(0, win ? (GetText(LocalizationManager.Text.Congrats) + "\n===============") : (waveText.text + "\n==============="));
		}
		else if (unlockStrings.Count == 1 || unlockStrings.Count == 2)
		{
			_ = demo && win;
		}
		if (num)
		{
			unlockStrings.Add("===============");
		}
		audioManager.PlaySound(win ? AudioManager.Sound.WaveClear : AudioManager.Sound.GameOver);
		animationManager.LerpZoom(clearPopup, Vector3.one, 5f, 0.1f);
		foreach (string unlockString in unlockStrings)
		{
			TMP_Text obj = clearPopupTexts[3];
			obj.text = obj.text + unlockString + "\n";
		}
		unlockStrings.Clear();
		yield return Wait(60);
		if (win)
		{
			animationManager.LerpZoom(endlessButton.gameObject, Vector3.one, 5f, 0.2f);
		}
		else
		{
			animationManager.LerpZoom(retryButton.gameObject, Vector3.one, 5f, 0.2f);
		}
		animationManager.LerpZoom(gameOverButton.gameObject, Vector3.one, 5f, 0.2f);
		if (win)
		{
			animationManager.LerpZoom(dpsButton.gameObject, Vector3.one, 10f, 0.2f);
		}
		yield return Wait(5);
		gameOverButton.hitbox.enabled = true;
		endlessButton.hitbox.enabled = true;
		retryButton.hitbox.enabled = true;
		gameOverButton.transform.localScale = Vector3.one;
		if (win)
		{
			endlessButton.transform.localScale = Vector3.one;
		}
		else
		{
			retryButton.transform.localScale = Vector3.one;
		}
	}

	private IEnumerator EndRoundSequence()
	{
		yield return Wait(60);
		gameOverButton.transform.localScale = Vector3.zero;
		endlessButton.transform.localScale = Vector3.zero;
		retryButton.transform.localScale = Vector3.zero;
		clearPopupTexts[0].text = GetText(LocalizationManager.Text.WaveClear);
		clearPopupTexts[1].text = "================\n";
		clearPopupTexts[2].text = "\n";
		clearPopupTexts[3].text = "";
		_ = gold;
		int reward = Mathf.Min(4 + currLevel, 10) + 3 * board.CountAuras(Aura.Type.PerkDividends);
		audioManager.PlaySound(AudioManager.Sound.WaveClear);
		yield return animationManager.LerpZoom(clearPopup, Vector3.one, 5f, 0.1f);
		yield return WaitCancellable(30);
		TMP_Text obj = clearPopupTexts[1];
		obj.text = obj.text + GetText(LocalizationManager.Text.Reward) + "\n";
		clearPopupTexts[2].text += $"+${reward}\n";
		gold += reward;
		yield return WaitCancellable(30);
		TMP_Text obj2 = clearPopupTexts[1];
		obj2.text = obj2.text + GetText(LocalizationManager.Text.HPBonus) + "\n";
		int num = Mathf.CeilToInt((float)player.health / (float)player.maxHealth / 0.2f);
		clearPopupTexts[2].text += $"+${num}\n";
		gold += num;
		yield return WaitCancellable(90);
		AudioManager.Music m = AudioManager.Music.Title;
		int num2 = currLevel % 30;
		if (num2 == 0 && endless)
		{
			m = AudioManager.Music.Title;
		}
		else if ((num2 >= 20 || num2 == 0) && !demo)
		{
			m = AudioManager.Music.Shop_Orbit;
		}
		else if (num2 >= 10 && !demo)
		{
			m = AudioManager.Music.Shop_Water;
		}
		if (num2 <= 20 || demo || (num2 == 0 && endless))
		{
			audioManager.SwitchMusic(m);
		}
		player.EndRound();
		yield return animationManager.LerpZoom(clearPopup, Vector3.zero, 5f, 0.1f);
		board.TriggerModules(Trigger.Type.End);
		if (currLevel % 30 == 10 && !demo)
		{
			animationManager.TransitionToWater();
			yield return Wait(120);
			yield return Wait(160);
		}
		if (currLevel % 30 == 20 && !demo)
		{
			animationManager.TransitionToSpace();
			yield return Wait(120);
			yield return Wait(160);
		}
		if (endless && currLevel % 30 == 0 && !demo)
		{
			animationManager.TransitionToWoods();
			endlessLevel++;
			yield return Wait(120);
			yield return Wait(190);
		}
		if (endless && demo && currLevel % 10 == 0)
		{
			endlessLevel++;
			animationManager.StartCoroutine(animationManager.PopUpBranch(0));
			yield return Wait(180);
		}
		bool num3 = currLevel % 10 == 3 || currLevel % 10 == 6;
		animationManager.LerpZoom(dpsButton.gameObject, Vector3.one, 10f, 0.2f);
		if (num3)
		{
			shop.Restock();
			perks.Reroll();
			SetState(State.Perk);
		}
		else
		{
			shop.Restock();
			SetState(State.Shop);
		}
		currLevel++;
	}

	public LevelInfo GenerateLevel(int x)
	{
		LevelInfo levelInfo = new LevelInfo();
		levelInfo.count = 0;
		levelInfo.monsters = new List<Monster.Type>();
		if (endless && x > 30)
		{
			int num = x;
			if (currBranch == Branch.Crypt)
			{
				x = 9;
			}
			if (currBranch == Branch.Water)
			{
				x = 19;
			}
			if (currBranch == Branch.Orbit)
			{
				x = 29;
			}
			if (num % 10 == 0)
			{
				x++;
			}
		}
		if (endless && demo)
		{
			x = ((x % 10 == 0) ? 10 : 9);
		}
		switch (x)
		{
		case 0:
		case 1:
			levelInfo.Add(Monster.Type.Zombie, 8);
			break;
		case 2:
			levelInfo.Add(Monster.Type.Zombie, 15);
			levelInfo.Add(Monster.Type.Grunt, 4);
			levelInfo.Add(Monster.Type.Bat, 2);
			break;
		case 3:
			levelInfo.Add(Monster.Type.Zombie, 10);
			levelInfo.Add(Monster.Type.Grunt, 10);
			levelInfo.Add(Monster.Type.Bat, 4);
			break;
		case 4:
			levelInfo.Add(Monster.Type.Grunt, 15);
			levelInfo.Add(Monster.Type.Wizard, 5);
			levelInfo.Add(Monster.Type.Bat, 4);
			break;
		case 5:
			levelInfo.Add(Monster.Type.Grunt, 10);
			levelInfo.Add(Monster.Type.Wizard, 7);
			levelInfo.Add(Monster.Type.Soldier, 10);
			levelInfo.Add(Monster.Type.Bat, 4);
			levelInfo.delay = 30;
			break;
		case 6:
			levelInfo.Add(Monster.Type.Wizard, 8);
			levelInfo.Add(Monster.Type.Skull, 8);
			levelInfo.Add(Monster.Type.Soldier, 20);
			levelInfo.delay = 30;
			break;
		case 7:
			levelInfo.Add(Monster.Type.Skull, 10);
			levelInfo.Add(Monster.Type.Wizard, 10);
			levelInfo.Add(Monster.Type.Archer, 4);
			levelInfo.Add(Monster.Type.Soldier, 20);
			levelInfo.delay = 25;
			break;
		case 8:
			levelInfo.Add(Monster.Type.Skull, 11);
			levelInfo.Add(Monster.Type.Wizard, 11);
			levelInfo.Add(Monster.Type.Redbat, 4);
			levelInfo.Add(Monster.Type.Sapper, 5);
			levelInfo.Add(Monster.Type.Archer, 10);
			levelInfo.Add(Monster.Type.Soldier, 15);
			levelInfo.delay = 25;
			break;
		case 9:
			levelInfo.Add(Monster.Type.Skull, 15);
			levelInfo.Add(Monster.Type.Wizard, 15);
			levelInfo.Add(Monster.Type.Redbat, 6);
			levelInfo.Add(Monster.Type.Sapper, 7);
			levelInfo.Add(Monster.Type.Archer, 15);
			levelInfo.Add(Monster.Type.Soldier, 15);
			levelInfo.delay = 25;
			break;
		case 10:
			levelInfo.monsters.Insert(0, Monster.Type.BOSS_Saint);
			break;
		case 11:
			levelInfo.Add(Monster.Type.Naga, 15);
			levelInfo.Add(Monster.Type.Naga_Soldier, 15);
			levelInfo.Add(Monster.Type.Jellyfish, 15);
			levelInfo.Add(Monster.Type.Tadpole, 3);
			levelInfo.delay = 25;
			break;
		case 12:
			levelInfo.Add(Monster.Type.Naga, 20);
			levelInfo.Add(Monster.Type.Naga_Soldier, 20);
			levelInfo.Add(Monster.Type.Jellyfish, 20);
			levelInfo.Add(Monster.Type.Tadpole, 3);
			levelInfo.delay = 20;
			break;
		case 13:
			levelInfo.Add(Monster.Type.Naga, 15);
			levelInfo.Add(Monster.Type.Naga_Soldier, 25);
			levelInfo.Add(Monster.Type.Jellyfish, 20);
			levelInfo.Add(Monster.Type.Submarine, 8);
			levelInfo.Add(Monster.Type.Tadpole, 3);
			levelInfo.delay = 20;
			break;
		case 14:
			levelInfo.Add(Monster.Type.Naga, 10);
			levelInfo.Add(Monster.Type.Naga_Soldier, 30);
			levelInfo.Add(Monster.Type.Jellyfish, 15);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 5);
			levelInfo.Add(Monster.Type.Submarine, 8);
			levelInfo.Add(Monster.Type.Snake, 8);
			levelInfo.Add(Monster.Type.Tadpole, 3);
			levelInfo.delay = 20;
			break;
		case 15:
			levelInfo.Add(Monster.Type.Naga_Soldier, 30);
			levelInfo.Add(Monster.Type.Jellyfish, 5);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 15);
			levelInfo.Add(Monster.Type.Submarine, 10);
			levelInfo.Add(Monster.Type.Snake, 8);
			levelInfo.Add(Monster.Type.Fishbones, 5);
			levelInfo.delay = 20;
			break;
		case 16:
			levelInfo.Add(Monster.Type.Naga_Soldier, 25);
			levelInfo.Add(Monster.Type.Naga_Tank, 5);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 20);
			levelInfo.Add(Monster.Type.Submarine, 12);
			levelInfo.Add(Monster.Type.Snake, 10);
			levelInfo.Add(Monster.Type.Fishbones, 10);
			levelInfo.delay = 20;
			break;
		case 17:
			levelInfo.Add(Monster.Type.Naga_Soldier, 25);
			levelInfo.Add(Monster.Type.Naga_Tank, 8);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 20);
			levelInfo.Add(Monster.Type.Submarine, 15);
			levelInfo.Add(Monster.Type.Snake, 10);
			levelInfo.Add(Monster.Type.Fishbones, 12);
			levelInfo.delay = 20;
			break;
		case 18:
			levelInfo.Add(Monster.Type.Naga_Soldier, 30);
			levelInfo.Add(Monster.Type.Naga_Tank, 15);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 20);
			levelInfo.Add(Monster.Type.Submarine, 15);
			levelInfo.Add(Monster.Type.Snake, 8);
			levelInfo.Add(Monster.Type.Fishbones, 12);
			levelInfo.Add(Monster.Type.Tadpole, 4);
			levelInfo.delay = 20;
			break;
		case 19:
			levelInfo.Add(Monster.Type.Naga_Soldier, 25);
			levelInfo.Add(Monster.Type.Naga_Tank, 20);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 20);
			levelInfo.Add(Monster.Type.Submarine, 15);
			levelInfo.Add(Monster.Type.Snake, 10);
			levelInfo.Add(Monster.Type.Fishbones, 15);
			levelInfo.Add(Monster.Type.Tadpole, 4);
			levelInfo.delay = 17;
			break;
		case 20:
			levelInfo.Add(Monster.Type.Jellyfish, 5);
			levelInfo.Add(Monster.Type.Red_Jellyfish, 5);
			levelInfo.Add(Monster.Type.BOSS_Squid, 1);
			levelInfo.delay = 17;
			break;
		case 21:
			levelInfo.Add(Monster.Type.Rocket, 20);
			levelInfo.Add(Monster.Type.Asteroid_S, 10);
			levelInfo.Add(Monster.Type.Asteroid_M0, 7);
			levelInfo.Add(Monster.Type.Asteroid_M1, 8);
			levelInfo.Add(Monster.Type.UFO, 20);
			levelInfo.Add(Monster.Type.Charger, 1);
			levelInfo.delay = 17;
			break;
		case 22:
			levelInfo.Add(Monster.Type.Rocket, 25);
			levelInfo.Add(Monster.Type.Asteroid_S, 20);
			levelInfo.Add(Monster.Type.Asteroid_M0, 10);
			levelInfo.Add(Monster.Type.Asteroid_M1, 10);
			levelInfo.Add(Monster.Type.UFO, 25);
			levelInfo.Add(Monster.Type.Charger, 1);
			levelInfo.delay = 12;
			break;
		case 23:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 25);
			levelInfo.Add(Monster.Type.Rocket, 25);
			levelInfo.Add(Monster.Type.Asteroid_S, 5);
			levelInfo.Add(Monster.Type.Asteroid_M0, 13);
			levelInfo.Add(Monster.Type.Asteroid_M1, 12);
			levelInfo.Add(Monster.Type.UFO, 15);
			levelInfo.Add(Monster.Type.Charger, 1);
			levelInfo.delay = 12;
			break;
		case 24:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 30);
			levelInfo.Add(Monster.Type.Rocket, 8);
			levelInfo.Add(Monster.Type.Bot, 3);
			levelInfo.Add(Monster.Type.Asteroid_M0, 13);
			levelInfo.Add(Monster.Type.Asteroid_M1, 12);
			levelInfo.Add(Monster.Type.Asteroid_L, 5);
			levelInfo.Add(Monster.Type.UFO, 10);
			levelInfo.Add(Monster.Type.UFO_Soldier, 10);
			levelInfo.Add(Monster.Type.Charger, 2);
			levelInfo.delay = 12;
			break;
		case 25:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 30);
			levelInfo.Add(Monster.Type.Bot, 8);
			levelInfo.Add(Monster.Type.Asteroid_L, 20);
			levelInfo.Add(Monster.Type.Asteroid_M0, 5);
			levelInfo.Add(Monster.Type.Asteroid_M1, 5);
			levelInfo.Add(Monster.Type.UFO_Soldier, 20);
			levelInfo.Add(Monster.Type.Drill, 8);
			levelInfo.Add(Monster.Type.Charger, 2);
			levelInfo.delay = 12;
			break;
		case 26:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 35);
			levelInfo.Add(Monster.Type.Bot, 9);
			levelInfo.Add(Monster.Type.Asteroid_L, 20);
			levelInfo.Add(Monster.Type.Asteroid_M0, 10);
			levelInfo.Add(Monster.Type.Asteroid_M1, 10);
			levelInfo.Add(Monster.Type.UFO_Soldier, 20);
			levelInfo.Add(Monster.Type.Drill, 10);
			levelInfo.Add(Monster.Type.Charger, 2);
			levelInfo.delay = 12;
			break;
		case 27:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 35);
			levelInfo.Add(Monster.Type.Bot, 8);
			levelInfo.Add(Monster.Type.Deathbot, 2);
			levelInfo.Add(Monster.Type.Asteroid_L, 25);
			levelInfo.Add(Monster.Type.Asteroid_M0, 10);
			levelInfo.Add(Monster.Type.Asteroid_M1, 10);
			levelInfo.Add(Monster.Type.UFO_Soldier, 25);
			levelInfo.Add(Monster.Type.Drill, 15);
			levelInfo.Add(Monster.Type.Charger, 2);
			levelInfo.delay = 12;
			break;
		case 28:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 35);
			levelInfo.Add(Monster.Type.Bot, 10);
			levelInfo.Add(Monster.Type.Deathbot, 7);
			levelInfo.Add(Monster.Type.Asteroid_L, 35);
			levelInfo.Add(Monster.Type.Asteroid_M0, 5);
			levelInfo.Add(Monster.Type.Asteroid_M1, 5);
			levelInfo.Add(Monster.Type.UFO_Soldier, 30);
			levelInfo.Add(Monster.Type.Drill, 15);
			levelInfo.Add(Monster.Type.Charger, 3);
			levelInfo.delay = 12;
			break;
		case 29:
			levelInfo.Add(Monster.Type.Rocket_Soldier, 40);
			levelInfo.Add(Monster.Type.Bot, 8);
			levelInfo.Add(Monster.Type.Deathbot, 8);
			levelInfo.Add(Monster.Type.Asteroid_L, 40);
			levelInfo.Add(Monster.Type.Asteroid_M0, 5);
			levelInfo.Add(Monster.Type.Asteroid_M1, 5);
			levelInfo.Add(Monster.Type.UFO_Soldier, 35);
			levelInfo.Add(Monster.Type.Drill, 15);
			levelInfo.Add(Monster.Type.Charger, 3);
			levelInfo.delay = 12;
			break;
		case 30:
			levelInfo.Add(Monster.Type.Bot, 1);
			levelInfo.Add(Monster.Type.Deathbot, 1);
			levelInfo.Add(Monster.Type.BOSS_Mothership, 1);
			break;
		default:
			levelInfo.Add(Monster.Type.Deathbot, 1);
			levelInfo.delay = 120;
			break;
		}
		int num2 = board.CountAuras(Aura.Type.Force_Gold);
		if ((Utils.RNG(20f) && x % 10 != 0 && x != 1) || num2 > 0)
		{
			if (x > 20 && !demo)
			{
				levelInfo.Add(Monster.Type.Gold_UFO, Mathf.Max(1, num2));
			}
			else if (x > 10 && !demo)
			{
				levelInfo.Add(Monster.Type.Gold_Naga, Mathf.Max(1, num2));
			}
			else
			{
				levelInfo.Add(Monster.Type.Gold, Mathf.Max(1, num2));
			}
		}
		if (moreEnemies)
		{
			levelInfo.delay = (int)(0.7f * (float)levelInfo.delay);
		}
		if (endless)
		{
			int num3 = endlessLevel * (demo ? 1 : 8) + (currLevel - maxLevel);
			float a = 1f - 0.1f * (float)endlessLevel - 0.05f * (float)(currLevel - maxLevel);
			a = Mathf.Max(a, 0.01f);
			for (int i = 0; i < num3; i++)
			{
				levelInfo.Add(randomMonster, 1);
			}
			levelInfo.delay = (int)((float)levelInfo.delay * a);
		}
		return levelInfo;
	}

	public Monster SpawnMonster(Monster.Type m, float fixedAngle = -1f)
	{
		Monster component = UnityEngine.Object.Instantiate(monsterObjects[(int)m]).GetComponent<Monster>();
		livingEnemies.Add(component);
		component.transform.localScale = Vector3.zero;
		animationManager.LerpZoom(component.gameObject, Vector3.one, 10f, 0.1f);
		component.type = m;
		component.Init(fixedAngle);
		if (m.ToString().Contains("BOSS"))
		{
			bossBar.StartBoss(component);
		}
		return component;
	}

	private IEnumerator spawner(LevelInfo level)
	{
		yield return Wait(60);
		List<Monster> pack = new List<Monster>();
		int spawnIndex = 0;
		foreach (Monster.Type m in level.monsters)
		{
			int repeatCount = endlessLevel + 1;
			if (m.ToString().Contains("BOSS"))
			{
				repeatCount = 1 + endlessLevel / 2;
			}
			for (int repeats = 0; repeats < repeatCount; repeats++)
			{
				pack.Clear();
				float ang;
				switch (m)
				{
				case Monster.Type.Bat:
				case Monster.Type.Redbat:
				{
					ang = UnityEngine.Random.Range(0f, 360f);
					int batDelay = 5;
					for (int j = 0; j < 4; j++)
					{
						ang += UnityEngine.Random.Range(-0.35f, 0.35f);
						SpawnMonster(m, ang);
						yield return Wait(batDelay);
					}
					break;
				}
				case Monster.Type.Tadpole:
				{
					ang = UnityEngine.Random.Range(0f, 360f);
					int fishDelay = 4;
					for (int j = 0; j < 4; j++)
					{
						ang += UnityEngine.Random.Range(-0.35f, 0.35f);
						pack.Add(SpawnMonster(m, ang));
						yield return Wait(fishDelay);
					}
					break;
				}
				case Monster.Type.Bot:
				case Monster.Type.Deathbot:
				{
					ang = UnityEngine.Random.Range(0f, MathF.PI * 2f);
					int num = 6;
					for (int i = 0; i < num - 1; i++)
					{
						pack.Add(SpawnMonster(m, ang));
						ang += MathF.PI * 2f / (float)num;
					}
					break;
				}
				default:
					ang = -1f;
					break;
				}
				Monster monster = SpawnMonster(m, ang);
				switch (monster.type)
				{
				case Monster.Type.Bot:
				case Monster.Type.Deathbot:
				{
					pack.Add(monster);
					int dir = Utils.RandSign();
					foreach (Monster item in pack)
					{
						item.GetComponent<Bot>().dir = dir;
					}
					break;
				}
				case Monster.Type.Tadpole:
					pack.Add(monster);
					foreach (Monster item2 in pack)
					{
						item2.GetComponent<Tadpole>().pack = new List<Monster>(pack);
					}
					break;
				}
			}
			int x = UnityEngine.Random.Range(level.delay - 10, level.delay + 11);
			int num2 = (harderEnemies ? 3 : 4);
			if (spawnIndex++ % num2 != 0)
			{
				yield return Wait(x);
			}
			while (livingEnemies.Count > 150)
			{
				yield return Wait(1);
			}
			if (gameover)
			{
				yield break;
			}
		}
		while (livingEnemies.Count > 0)
		{
			yield return null;
		}
		EndRound();
	}

	public static IEnumerator Wait(int x)
	{
		return AnimationManager.Wait(x);
	}

	public static IEnumerator WaitUI(int x)
	{
		return AnimationManager.WaitUI(x);
	}

	public static IEnumerator WaitCancellable(int x)
	{
		for (int i = 0; i < x; i++)
		{
			yield return Wait(1);
			if (Input.GetKeyDown(KeyCode.Mouse0) && !Instance.paused)
			{
				break;
			}
		}
	}

	public void InitBoard()
	{
		State state = State.Intro;
		gold = 10;
		switch (character)
		{
		case 0:
		{
			board.AddModule(testmods[0], 1);
			board.AddModule(testmods[1], 5);
			board.AddModule(testmods[2], 6);
			Plug componentInChildren3 = testmods[1].GetComponentInChildren<Plug>();
			Plug componentInChildren4 = testmods[2].GetComponentInChildren<Plug>();
			Plug p = testmods[0].GetComponentsInChildren<Plug>()[0];
			Plug p2 = testmods[0].GetComponentsInChildren<Plug>()[1];
			componentInChildren3.ConnectTo(p, manual: false);
			componentInChildren4.ConnectTo(p2, manual: false);
			perks.Select(Perks.Type.Fortified, 0, test: true);
			break;
		}
		case 1:
		{
			board.AddModule(testmods[3], 1);
			board.AddModule(testmods[4], 6);
			Plug componentInChildren = testmods[3].GetComponentInChildren<Plug>();
			Plug componentInChildren2 = testmods[4].GetComponentInChildren<Plug>();
			componentInChildren.ConnectTo(componentInChildren2, manual: false);
			perks.Select(Perks.Type.Intellect, 0, test: true);
			break;
		}
		case 2:
			perks.Select(Perks.Type.Goblinized, 0, test: true);
			gold += 5;
			shop.Restock();
			state = State.Shop;
			break;
		}
		foreach (Module testmod in testmods)
		{
			if (!board.modules.Contains(testmod))
			{
				UnityEngine.Object.Destroy(testmod.gameObject);
			}
		}
		testmods.Clear();
		SetState(state);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (paused)
			{
				Unpause();
			}
			else
			{
				Pause();
			}
		}
	}

	public void GetBonusCash(int x, Vector3 pos)
	{
		gold += x;
		animationManager.CreateNumber(x, pos, Number.Type.Cash);
	}

	public Monster GetClosestMonster(Vector3 pos, Monster exclude = null, List<Monster> excludeList = null)
	{
		Monster result = null;
		float num = 9999f;
		foreach (Monster livingEnemy in livingEnemies)
		{
			if ((!(exclude != null) || !(exclude == livingEnemy)) && (excludeList == null || !excludeList.Contains(livingEnemy)))
			{
				float num2 = Vector3.Distance(pos, livingEnemy.transform.position);
				if (num2 < num)
				{
					num = num2;
					result = livingEnemy;
				}
			}
		}
		return result;
	}

	public void Pause()
	{
		if (!paused && !(Camera.main.transform.position != gameCamera))
		{
			Camera.main.transform.position = menuCamera;
			audioManager.PauseGame();
			paused = true;
		}
	}

	public void Unpause()
	{
		if (paused)
		{
			Camera.main.transform.position = gameCamera;
			audioManager.UnpauseGame();
			paused = false;
		}
	}

	public void ResetScene(bool resetGame = false)
	{
		mainmenu.ResetScene(resetGame);
	}

	private void OnApplicationFocus(bool focus)
	{
		_ = soundInBackground;
	}

	public void AddRandomDMG()
	{
		UnityEngine.Random.Range(0, 100);
		DPS.AddDamage(Module.Name.Soulripper, 888, upg: true);
		DPS.AddDamage(Module.Name.Flame, 843445588, upg: true);
		DPS.AddDamage(Module.Name.Cold, 88999998, upg: true);
	}

	public void PrintTriggers()
	{
		string text = "Triggers: \n";
		GameObject[] array = moduleObjects;
		for (int i = 0; i < array.Length; i++)
		{
			Module component = array[i].GetComponent<Module>();
			if (component.triggers.Count == 0)
			{
				continue;
			}
			string text2 = component.name.ToString() + ": ";
			foreach (Trigger trigger in component.triggers)
			{
				text2 = text2 + trigger.ability.ToString() + $" ({trigger.type})" + ", ";
			}
			text = text + text2 + "\n";
		}
		Debug.Log(text);
	}

	public void PrintAuras()
	{
		string text = "Auras: \n";
		GameObject[] array = moduleObjects;
		for (int i = 0; i < array.Length; i++)
		{
			Module component = array[i].GetComponent<Module>();
			if (component.auras.Count == 0)
			{
				continue;
			}
			string text2 = component.name.ToString() + ": ";
			foreach (Aura aura in component.auras)
			{
				text2 = text2 + aura.type.ToString() + $" ({aura.value})" + ", ";
			}
			text = text + text2 + "\n";
		}
		Debug.Log(text);
	}

	public void PrintCollectionMissing()
	{
		string text = "Collection Missing: ";
		for (int i = 0; i < 141; i++)
		{
			if (!saveData.collection.Contains((Module.Name)i))
			{
				string text2 = text;
				Module.Name name = (Module.Name)i;
				text = text2 + name.ToString() + " ";
			}
		}
		Debug.Log(text);
	}

	private IEnumerator cameraPixelTest()
	{
		while (true)
		{
			Camera.main.GetComponent<PixelPerfectCamera>().gridSnapping = PixelPerfectCamera.GridSnapping.PixelSnapping;
			yield return WaitUI(5);
			Camera.main.GetComponent<PixelPerfectCamera>().gridSnapping = PixelPerfectCamera.GridSnapping.UpscaleRenderTexture;
			yield return WaitUI(5);
		}
	}

	private IEnumerator goblinTest()
	{
		while (true)
		{
			for (int i = 0; i < board.modules.Count; i++)
			{
				if (!(board.modules[i] == null))
				{
					Module module = board.modules[i];
					board.RemoveModule(module);
					UnityEngine.Object.Destroy(module.gameObject);
				}
			}
			InitBoard();
			yield return Wait(1);
		}
	}

	private IEnumerator shopTest()
	{
		while (true)
		{
			shop.Restock();
			SetState(State.Shop);
			gold = 9999;
			yield return Wait(1);
		}
	}

	public void PrintSyngergies()
	{
		List<Module.Name> list = new List<Module.Name>();
		List<Module.Name> list2 = new List<Module.Name>();
		List<Module.Name> list3 = new List<Module.Name>();
		List<Module.Name> list4 = new List<Module.Name>();
		List<Module.Name> list5 = new List<Module.Name>
		{
			Module.Name.Collar,
			Module.Name.Horseshoe,
			Module.Name.Treat,
			Module.Name.Doghouse,
			Module.Name.Dogwhistle,
			Module.Name.Brass,
			Module.Name.Juice,
			Module.Name.Biochamber,
			Module.Name.Bone,
			Module.Name.Swipe,
			Module.Name.Grimoire
		};
		List<Module.Name> list6 = new List<Module.Name>
		{
			Module.Name.ManaPot,
			Module.Name.Alchemy,
			Module.Name.Sonic,
			Module.Name.Soulrod,
			Module.Name.Soulripper,
			Module.Name.Curse,
			Module.Name.Repeater,
			Module.Name.Vortex,
			Module.Name.Phial,
			Module.Name.Spellbook,
			Module.Name.Channel
		};
		List<Module.Name> list7 = new List<Module.Name>
		{
			Module.Name.Coolant,
			Module.Name.Wrench,
			Module.Name.Screwdriver
		};
		string text = "Tokens: ";
		int num = 0;
		int num3;
		int num4;
		int num5;
		int num6;
		int num7;
		int num8;
		int num9;
		int num10;
		int num11;
		int num12;
		int num13;
		int num14;
		int num15;
		int num16;
		int num17;
		int num2 = (num3 = (num4 = (num5 = (num6 = (num7 = (num8 = (num9 = (num10 = (num11 = (num12 = (num13 = (num14 = (num15 = (num16 = (num17 = 0)))))))))))))));
		GameObject[] array = moduleObjects;
		foreach (GameObject gameObject in array)
		{
			if (gameObject == null)
			{
				continue;
			}
			Module.Name name = gameObject.GetComponent<Module>().name;
			bool wEAPON = gameObject.GetComponent<Module>().WEAPON;
			if (gameObject.GetComponent<Module>().TOKEN)
			{
				num++;
				text = text + name.ToString() + ", ";
				continue;
			}
			List<Module.Tribe> tribe = Database.GetModData(name).tribe;
			bool flag = Database.GetModData(name).price > 10;
			if (tribe.Contains(Module.Tribe.Pet) || list5.Contains(name))
			{
				list3.Add(name);
				if (flag)
				{
					if (wEAPON)
					{
						num8++;
					}
					else
					{
						num6++;
					}
				}
				else if (wEAPON)
				{
					num9++;
				}
				else
				{
					num7++;
				}
			}
			if (tribe.Contains(Module.Tribe.Wand) || list6.Contains(name))
			{
				list4.Add(name);
				if (flag)
				{
					if (wEAPON)
					{
						num12++;
					}
					else
					{
						num10++;
					}
				}
				else if (wEAPON)
				{
					num13++;
				}
				else
				{
					num11++;
				}
			}
			if (tribe.Contains(Module.Tribe.Mech) || list7.Contains(name))
			{
				list2.Add(name);
				if (flag)
				{
					if (wEAPON)
					{
						num4++;
					}
					else
					{
						num2++;
					}
				}
				else if (wEAPON)
				{
					num5++;
				}
				else
				{
					num3++;
				}
			}
			if (tribe.Count != 0 || list7.Contains(name) || list6.Contains(name) || list5.Contains(name))
			{
				continue;
			}
			list.Add(name);
			if (flag)
			{
				if (wEAPON)
				{
					num16++;
				}
				else
				{
					num14++;
				}
			}
			else if (wEAPON)
			{
				num17++;
			}
			else
			{
				num15++;
			}
		}
		list2.Remove(Module.Name.Collar);
		list4.Remove(Module.Name.Leshy);
		list = new List<Module.Name>(list.Distinct());
		string text2 = "";
		text2 += $"Pets ({list3.Count}):C[{num9}w, {num7}m], R[{num8}w, {num6}m]\n";
		foreach (Module.Name item in list3)
		{
			text2 = text2 + item.ToString() + ", ";
		}
		text2 += $"\nWands ({list4.Count}): C[{num13}w, {num11}m], R[{num12}w, {num10}m]\n";
		foreach (Module.Name item2 in list4)
		{
			text2 = text2 + item2.ToString() + ", ";
		}
		text2 += $"\nMechs ({list2.Count}): C[{num5}w, {num3}m], R[{num4}w, {num2}m]\n";
		foreach (Module.Name item3 in list2)
		{
			text2 = text2 + item3.ToString() + ", ";
		}
		text2 += $"\nGeneric ({list.Count}): C[{num17}w, {num15}m], R[{num16}w, {num14}m]\n";
		foreach (Module.Name item4 in list)
		{
			text2 = text2 + item4.ToString() + ", ";
		}
		text2 += $"\nTotal: {141 - num}";
		Debug.Log(text2);
		Debug.Log(text);
	}

	public void PrintWaveStats()
	{
		string text = "";
		int num = 0;
		float num2 = 0f;
		for (int i = 1; i <= maxLevel; i++)
		{
			LevelInfo levelInfo = GenerateLevel(i);
			int num3 = 0;
			int num4 = 0;
			foreach (Monster.Type monster in levelInfo.monsters)
			{
				if (!monster.ToString().Contains("Gold"))
				{
					num3 += Database.GetMonsterInfo(monster).health;
					num4 += Database.GetMonsterInfo(monster).healthUp;
				}
			}
			float num5 = (float)(levelInfo.delay * levelInfo.monsters.Count) / 60f;
			text += string.Format("Wave {0}: {1} ({2}) - [{3} enemies] {4} [{5}s]\n", i, num3, num4, levelInfo.monsters.Count, (i > 1) ? $"+{100 * (num3 - num) / num}%" : "", num5);
			num2 += num5;
			num = num3;
		}
		Debug.Log(text);
		Debug.Log(num2 / 60f + "mins");
	}

	private void MassAdjustments()
	{
		GameObject[] array = moduleObjects;
		foreach (GameObject gameObject in array)
		{
			if (gameObject.GetComponent<Module>().size == Module.Size.Small)
			{
				gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(1f / 32f, 0f);
				gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2.1875f, 3.75f);
			}
			if (gameObject.GetComponent<Module>().size == Module.Size.Medium)
			{
				gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(1f / 32f, 0f);
				gameObject.GetComponent<BoxCollider2D>().size = new Vector2(4.4375f, 3.75f);
			}
			Plug[] componentsInChildren = gameObject.GetComponentsInChildren<Plug>();
			foreach (Plug plug in componentsInChildren)
			{
				Debug.Log(plug.transform.localPosition.x);
				if ((double)plug.transform.localPosition.x == 19.0 / 32.0)
				{
					plug.transform.localPosition = new Vector3(0.625f, plug.transform.localPosition.y, plug.transform.localPosition.z);
				}
			}
		}
	}

	private void CreateTestDeck()
	{
		List<Module.Name> list = new List<Module.Name>
		{
			Module.Name.Bluechip,
			Module.Name.Repeater,
			Module.Name.Redchip,
			Module.Name.Discharger,
			Module.Name.USB,
			Module.Name.Monitor,
			Module.Name.Wind,
			Module.Name.Fang,
			Module.Name.Balloon,
			Module.Name.Circle,
			Module.Name.MixerTriple
		};
		List<Perks.Type> list2 = new List<Perks.Type> { Perks.Type.Goblinized };
		if (true)
		{
			for (int i = 0; i < 44; i++)
			{
				list2.Add((Perks.Type)i);
			}
		}
		list2.Remove(Perks.Type.Heavy);
		endless = true;
		endlessLevel = 2;
		currLevel = 82;
		foreach (Module.Name item in list)
		{
			UnityEngine.Object.Instantiate(moduleObjects[(int)item]);
		}
		foreach (Perks.Type item2 in list2)
		{
			perks.Select(item2, 0, test: true);
		}
	}
}
