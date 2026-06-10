using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationBot : MonoBehaviour
{
	public static SimulationBot Instance;

	[Header("Simulation Settings")]
	[Range(1f, 50f)]
	public float timeScale = 20f;

	public double targetMoney = 1500.0;

	public float shopThinkTime = 0.5f;

	[Header("Game References")]
	public FishingManager fishingManager;

	public SkillManager skillManager;

	public PlayerManager playerManager;

	public ReelInMinigame clickingMiniGame;

	public BiteIndicatorMinigame biteIndicatorMiniGame;

	public ZoneMapController zoneMapController;

	public MenuUIManager menuUIManager;

	public SkillTreePanel SkillTreePanel;

	public bool isRunning;

	private float startTime;

	private int expeditionCount;

	private List<string> logLines = new List<string>();

	public bool autoSelectTile = true;

	private bool lastExpeditionFailed;

	[Tooltip("How many times the bot clicks per Game Second. Normal players are ~6-10.")]
	public int clicksPerSecond = 8;

	[Tooltip("Max REAL seconds the bot waits for a cast to resolve before force-retrying. Lower = faster recovery from freezes.")]
	public float stuckCastTimeout = 0.5f;

	[Header("Bite Indicator Skill (0=bad, 1=perfect)")]
	[Range(0f, 1f)]
	[Tooltip("0 = clicks randomly anywhere on the bar. 1 = always clicks in the center (perfect). 0.5 = average player aim.")]
	public float reactionSkillLevel = 0.5f;

	private void Start()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
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
		if (isRunning)
		{
			Time.timeScale = timeScale;
			RefreshReferences();
		}
	}

	private void RefreshReferences()
	{
		fishingManager = FishingManager.Instance;
		skillManager = SkillManager.Instance;
		playerManager = PlayerManager.Instance;
		clickingMiniGame = ReelInMinigame.Instance;
		menuUIManager = MenuUIManager.Instance;
		biteIndicatorMiniGame = BiteIndicatorMinigame.Instance;
		zoneMapController = ZoneMapController.Instance;
		SkillTreePanel = SkillTreePanel.Instance;
		Debug.Log("Bot arrived in " + SceneManager.GetActiveScene().name + ". References refreshed.");
	}

	[ContextMenu("Start Simulation")]
	public void StartSimulation()
	{
		Debug.Log("[Bot] StartSimulation() called.");
		if (isRunning)
		{
			Debug.LogWarning("[Bot] Already running! Click Stop or wait for it to finish.");
			return;
		}
		RefreshReferences();
		bool flag = false;
		if (GameManager.Instance == null)
		{
			Debug.LogError("[Bot] MISSING: GameManager.Instance is null. Are you in MenuScene?");
			flag = true;
		}
		if (zoneMapController == null)
		{
			Debug.LogError("[Bot] MISSING: ZoneMapController not found. Assign it in the Inspector or ensure it's in the scene.");
			flag = true;
		}
		if (menuUIManager == null)
		{
			Debug.LogWarning("[Bot] WARNING: MenuUIManager not found. Shopping panel navigation may fail.");
		}
		if (SkillTreePanel == null)
		{
			Debug.LogWarning("[Bot] WARNING: SkillTreePanel not found. Skill purchasing will be skipped.");
		}
		if (flag)
		{
			Debug.LogError("[Bot] Startup aborted due to missing critical references (see above). Fix these before running.");
			return;
		}
		if (GameManager.Instance.totalMoney >= targetMoney)
		{
			Debug.LogWarning($"[Bot] totalMoney ({GameManager.Instance.totalMoney}) is already >= targetMoney ({targetMoney}). The main loop won't run. Increase targetMoney.");
		}
		Debug.Log($"[Bot] All checks passed. Starting simulation. Target: {targetMoney}G | TimeScale: {timeScale}x");
		isRunning = true;
		Time.timeScale = timeScale;
		startTime = Time.time;
		expeditionCount = 0;
		logLines.Clear();
		logLines.Add("Timestamp,TotalMoney,ChangeAmount,EventType,FishName,FishRarity,SkillID,Expedition");
		StartCoroutine(GameLoop());
	}

	private IEnumerator GameLoop()
	{
		Debug.Log("<color=orange>[Bot State] GameLoop started. Waiting 0.1s...</color>");
		yield return new WaitForSeconds(0.1f);
		Log("Initial", 0);
		Debug.Log($"[Bot] GameLoop running. CurrentMoney={GameManager.Instance.totalMoney} | Target={targetMoney}");
		if (!(GameManager.Instance.totalMoney < targetMoney) || !isRunning)
		{
			Debug.LogWarning("[Bot] GameLoop while-condition is FALSE immediately — money already at target or isRunning=false. Skipping to EndSimulation.");
		}
		while (GameManager.Instance.totalMoney < targetMoney && isRunning)
		{
			bool flag = true;
			try
			{
				Debug.Log($"<color=white><b>[Bot State] === LOOP START | Expedition #{expeditionCount + 1} | Money: {GameManager.Instance.totalMoney:F0}G ===</b></color>");
			}
			catch (Exception arg)
			{
				Debug.LogError($"<color=red>[Bot CRASH] Exception at loop start: {arg}</color>");
				flag = false;
			}
			if (!flag)
			{
				yield return new WaitForSeconds(1f);
				continue;
			}
			Debug.Log("<color=orange>[Bot State] Step 1: Traveling to highest pond...</color>");
			yield return StartCoroutine(GoToHighestPond());
			Debug.Log($"<color=orange>[Bot State] Step 1 Done. FishingManager found: {fishingManager != null}</color>");
			expeditionCount++;
			Debug.Log($"<color=orange>[Bot State] Step 2: Starting fishing day (expedition #{expeditionCount})...</color>");
			double moneyBeforeExpedition = GameManager.Instance.totalMoney;
			yield return StartCoroutine(SimulateFishingDaySafe());
			double num = GameManager.Instance.totalMoney - moneyBeforeExpedition;
			Debug.Log($"<color=orange>[Bot State] Step 2 Done. Fishing day complete. Earned: {num:F0}G</color>");
			Debug.Log("<color=orange>[Bot State] Step 3: Returning to lobby...</color>");
			yield return StartCoroutine(ReturnToLobby());
			Debug.Log("<color=orange>[Bot State] Step 3 Done. Back in lobby.</color>");
			Debug.Log("<color=orange>[Bot State] Step 4: Shopping phase...</color>");
			double nextZoneCost = GetNextZoneCost();
			bool shouldSaveForZone = nextZoneCost > 0.0 && GameManager.Instance.totalMoney >= nextZoneCost * 0.25;
			if (shouldSaveForZone)
			{
				Debug.Log($"<color=cyan>[Bot] Saving up! Have {GameManager.Instance.totalMoney:F0}G (>= 25% of next zone cost {nextZoneCost:F0}G). Skipping upgrades.</color>");
			}
			yield return StartCoroutine(TryBuyNextArea());
			if (!shouldSaveForZone)
			{
				yield return StartCoroutine(TryBuyRandomUpgrades());
			}
			Debug.Log($"[Bot] Step 4 Done. Money after shopping: {GameManager.Instance.totalMoney:F0}G");
		}
		Debug.Log("[Bot] GameLoop exited. Ending simulation.");
		EndSimulation();
	}

	private IEnumerator SimulateFishingDaySafe()
	{
		IEnumerator enumerator = SimulateFishingDay();
		while (true)
		{
			object current;
			try
			{
				if (!enumerator.MoveNext())
				{
					break;
				}
				current = enumerator.Current;
			}
			catch (Exception ex)
			{
				Debug.LogError("<color=red>[Bot CRASH] Exception in SimulateFishingDay: " + ex.Message + "\n" + ex.StackTrace + "</color>");
				ForceResetFishingState();
				break;
			}
			yield return current;
		}
	}

	private IEnumerator TryBuyRandomUpgrades()
	{
		Debug.Log("<color=cyan>[Bot Action] TryBuyRandomUpgrades Start</color>");
		yield return null;
		Debug.Log("<color=cyan>[Bot Action] Entering Skill Tree Panel...</color>");
		if (menuUIManager != null)
		{
			menuUIManager.OnUpgradesButtonClicked();
		}
		bool flag = false;
		while (true)
		{
			List<SkillNodeUI> purchasableSkills = GetPurchasableSkills();
			if (purchasableSkills.Count == 0)
			{
				break;
			}
			SkillNodeUI skillNodeUI = purchasableSkills[UnityEngine.Random.Range(0, purchasableSkills.Count)];
			SkillTreePanel.AttemptUnlockSkill(skillNodeUI);
			flag = true;
			Debug.Log("Bot: Purchased upgrade '" + skillNodeUI.skillData.name + "'");
		}
		if (!flag)
		{
			Debug.Log("Bot: Cannot afford any skills (or all maxed).");
		}
		else
		{
			Debug.Log("Bot: No more affordable skills remaining.");
		}
		if (menuUIManager != null)
		{
			menuUIManager.OnZonesButtonClicked();
		}
		Debug.Log("<color=cyan>[Bot Action] TryBuyRandomUpgrades End</color>");
	}

	private List<SkillNodeUI> GetPurchasableSkills()
	{
		List<SkillNodeUI> list = new List<SkillNodeUI>();
		if (SkillTreePanel == null || SkillTreePanel.allSkillNodes == null)
		{
			Debug.LogWarning("Bot: SkillTreePanel reference is missing or empty.");
			return list;
		}
		foreach (SkillNodeUI allSkillNode in SkillTreePanel.allSkillNodes)
		{
			Skill skillData = allSkillNode.skillData;
			if (!(skillData == null) && SkillManager.Instance.GetSkillLevel(skillData.ID) < skillData.MaxLevel && SkillManager.Instance.ArePrerequisitesMet(skillData))
			{
				double num = SkillManager.Instance.CalculateUpgradeCost(skillData);
				if (GameManager.Instance.totalMoney >= num)
				{
					list.Add(allSkillNode);
				}
			}
		}
		return list;
	}

	private IEnumerator ReturnToLobby()
	{
		Debug.Log("<color=cyan>[Bot Wait] Returning to Lobby...</color>");
		if (GameManager.Instance != null)
		{
			GameManager.Instance.isPassiveIncomePaused = true;
		}
		if (PlayerManager.Instance != null)
		{
			PlayerManager.Instance.ReturnToMenu();
			Debug.Log("<color=yellow>[Bot Wait] Waiting for Scene Load (MenuScene)...</color>");
			yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "MenuScene");
			Debug.Log("<color=yellow>[Bot Wait] Scene Loaded: MenuScene.</color>");
			if (GameManager.Instance != null)
			{
				GameManager.Instance.isPassiveIncomePaused = false;
			}
			Debug.Log("<color=cyan>[Bot Action] Arrived in Lobby.</color>");
		}
		else
		{
			Debug.LogError("Bot: PlayerManager not found! Cannot return to menu.");
		}
	}

	private double GetNextZoneCost()
	{
		if (zoneMapController == null)
		{
			return -1.0;
		}
		foreach (ZoneData allZone in zoneMapController.allZones)
		{
			if (!allZone.isUnlocked)
			{
				return GameManager.Instance.GetEffectiveZoneUnlockCost(allZone);
			}
		}
		return -1.0;
	}

	private IEnumerator TryBuyNextArea()
	{
		Debug.Log("<color=cyan>[Bot Action] TryBuyNextArea Start</color>");
		if (zoneMapController == null)
		{
			Debug.LogWarning("<color=cyan>[Bot Action] TryBuyNextArea: zoneMapController == null, Early Exit</color>");
			yield break;
		}
		foreach (ZoneData zone in zoneMapController.allZones)
		{
			if (!zone.isUnlocked)
			{
				double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(zone);
				if (GameManager.Instance.totalMoney >= effectiveZoneUnlockCost)
				{
					Debug.Log($"<color=green>Bot: Buying Area {zone.zoneName} for {effectiveZoneUnlockCost} G</color>");
					yield return new WaitForSeconds(0.5f);
					GameManager.Instance.UnlockZone(zone);
					yield return new WaitForSeconds(0.5f);
					Debug.Log("<color=cyan>[Bot Action] TryBuyNextArea End (Bought Area)</color>");
				}
				else
				{
					Debug.Log("<color=cyan>[Bot Action] TryBuyNextArea End (Cannot Afford)</color>");
				}
				yield break;
			}
		}
		Debug.Log("<color=cyan>[Bot Action] TryBuyNextArea End (No more locked zones)</color>");
	}

	private IEnumerator GoToHighestPond()
	{
		Debug.Log("<color=cyan>[Bot Action] GoToHighestPond Start</color>");
		if (zoneMapController == null)
		{
			Debug.LogError("Bot: ZoneMapController reference is missing! Cannot go to pond.");
			yield break;
		}
		if (GameManager.Instance != null)
		{
			GameManager.Instance.isPassiveIncomePaused = true;
		}
		int num = -1;
		for (int num2 = zoneMapController.allZones.Count - 1; num2 >= 0; num2--)
		{
			if (zoneMapController.allZones[num2].isUnlocked)
			{
				num = num2;
				break;
			}
		}
		if (num < 0)
		{
			Debug.LogError("Bot: No unlocked zones found! Stopping.");
			yield break;
		}
		int num3 = num;
		if (num3 > 0 && lastExpeditionFailed)
		{
			num3--;
			Debug.Log("<color=yellow>Bot: Last expedition failed (0 fish). Retreating to: " + zoneMapController.allZones[num3].zoneName + "</color>");
		}
		else
		{
			Debug.Log("Bot: Heading to highest zone: " + zoneMapController.allZones[num3].zoneName);
		}
		GameManager.Instance.SelectZone(zoneMapController.allZones[num3]);
		float timeWaited = 0f;
		Debug.Log("<color=yellow>[Bot Wait] Waiting for fishingManager to be assigned (Scene Load)...</color>");
		while (fishingManager == null)
		{
			timeWaited += Time.unscaledDeltaTime;
			if (timeWaited > 5f)
			{
				Debug.LogError("<color=red>[Bot Wait] Timed out waiting for Pond Scene to load.</color>");
				yield break;
			}
			yield return null;
		}
		Debug.Log("<color=yellow>[Bot Wait] fishingManager assigned.</color>");
		timeWaited = 0f;
		while (playerManager != null && playerManager.currentEnergy <= 0 && timeWaited < 1f)
		{
			timeWaited += Time.unscaledDeltaTime;
			yield return null;
		}
		Debug.Log($"<color=yellow>[Bot Wait] PlayerManager ready. Energy: {playerManager?.currentEnergy}</color>");
		if (GameManager.Instance != null)
		{
			GameManager.Instance.isPassiveIncomePaused = false;
		}
		Debug.Log("<color=cyan>[Bot Action] GoToHighestPond End</color>");
	}

	private bool IsExpeditionActive()
	{
		if (fishingManager == null)
		{
			return false;
		}
		return fishingManager.IsFishing();
	}

	private void Log(string eventType, int change, string fishName = "", string rarity = "", string skillID = "")
	{
		float num = Time.time - startTime;
		double totalMoney = GameManager.Instance.totalMoney;
		string item = $"{num:F2},{totalMoney},{change},{eventType},{fishName},{rarity},{skillID},{expeditionCount}";
		logLines.Add(item);
	}

	private void EndSimulation()
	{
		isRunning = false;
		Time.timeScale = 1f;
		string text = Path.Combine(Application.dataPath, "DayLoopLog.csv");
		File.WriteAllLines(text, logLines);
		Debug.Log("Simulation Finished. Log saved to " + text);
	}

	public IEnumerator OnClickingMiniGame()
	{
		FishingManager fManager = FishingManager.Instance;
		ReelInMinigame reelGame = fManager.reelInMinigame;
		if (reelGame == null)
		{
			yield break;
		}
		float waited = 0f;
		while (!reelGame.IsActive && waited < 0.5f)
		{
			waited += Time.unscaledDeltaTime;
			yield return null;
		}
		if (!reelGame.IsActive)
		{
			yield break;
		}
		float clickAccumulator = 0f;
		while (fManager.IsReeling && reelGame.IsActive)
		{
			clickAccumulator += (float)clicksPerSecond * Time.deltaTime;
			int num = Mathf.FloorToInt(clickAccumulator);
			clickAccumulator -= (float)num;
			for (int i = 0; i < num; i++)
			{
				reelGame.OnClick();
				if (!fManager.IsReeling || !reelGame.IsActive)
				{
					break;
				}
			}
			yield return null;
		}
	}

	public IEnumerator OnReactionMiniGame()
	{
		FishingManager fManager = FishingManager.Instance;
		BiteIndicatorMinigame biteGame = fManager?.biteIndicatorMinigame;
		if (biteGame == null)
		{
			yield break;
		}
		float waited = 0f;
		while (!biteGame.IsMinigameActive && waited < 0.5f)
		{
			if (!fManager.IsInBiteGame)
			{
				yield break;
			}
			waited += Time.unscaledDeltaTime;
			yield return null;
		}
		if (biteGame.IsMinigameActive)
		{
			biteGame.SimulateClick();
		}
	}

	private IEnumerator WaitUntilOrTimeout(Func<bool> condition, float timeoutSeconds, Action<bool> result = null)
	{
		float elapsed = 0f;
		while (!condition() && elapsed < timeoutSeconds)
		{
			elapsed += Time.unscaledDeltaTime;
			yield return null;
		}
		bool obj = elapsed < timeoutSeconds;
		result?.Invoke(obj);
	}

	private void LogCastBlockers(FishingManager fManager)
	{
		Debug.LogWarning("<color=red>========== [Bot Diagnostic] CAST BLOCKER DUMP ==========</color>");
		Debug.LogWarning($"  FishingState:           {fManager.currentState} (need Idle)");
		Debug.LogWarning($"  IsIdle:                 {fManager.IsIdle}");
		Debug.LogWarning("  currentBobberObject:    " + ((fManager.currentBobberObject != null) ? fManager.currentBobberObject.name : "null"));
		Debug.LogWarning($"  activeBobbers.Count:    {fManager.activeBobbers.Count}");
		Debug.LogWarning($"  dayEnded:               {playerManager.dayEnded}");
		Debug.LogWarning($"  currentEnergy:          {playerManager.currentEnergy}");
		Debug.LogWarning($"  EnergyCostPerCast:      {((PlayerStats.Instance != null) ? PlayerStats.Instance.EnergyCostPerCast : (-1))}");
		float num = Time.time - GetLastCastTime(fManager);
		Debug.LogWarning($"  Cast cooldown:          timeSinceLastCast={num:F3}s, CAST_COOLDOWN=0.5s, blocked={num < 0.5f}");
		bool flag = DialogueManager.Instance != null && DialogueManager.Instance.isCutsceneActive;
		Debug.LogWarning($"  DialogueManager block:  {flag}");
		bool flag2 = CutsceneManager.Instance != null && CutsceneManager.Instance.IsBlockingFishing;
		Debug.LogWarning($"  CutsceneManager block:  {flag2}");
		bool flag3 = KrakenEventManager.Instance != null && KrakenEventManager.Instance.IsBossSequenceActive;
		Debug.LogWarning($"  KrakenEvent block:      {flag3}");
		Debug.LogWarning($"  EndOfGamePanel.IsVisible: {EndOfGamePanel.IsVisible}");
		Debug.LogWarning($"  PlayerManager.IsDemoFinished: {PlayerManager.IsDemoFinished}");
		bool flag4 = playerManager.endOfDayPanel != null && playerManager.endOfDayPanel.gameObject.activeInHierarchy;
		Debug.LogWarning($"  EndOfDayPanel active:   {flag4}");
		Bobber[] array = UnityEngine.Object.FindObjectsOfType<Bobber>();
		Debug.LogWarning($"  Scene Bobber count:     {array.Length}");
		Bobber[] array2 = array;
		foreach (Bobber bobber in array2)
		{
			Debug.LogWarning($"    - Bobber: {bobber.gameObject.name} (instanceID={bobber.gameObject.GetInstanceID()})");
		}
		bool isVisible = FishCaughtAlert.IsVisible;
		Debug.LogWarning($"  FishCaughtAlert.IsVisible: {isVisible}");
		NewFishDiscoveryPanel discoveryPanel = fManager.discoveryPanel;
		bool flag5 = discoveryPanel != null && discoveryPanel.IsShowing;
		Debug.LogWarning($"  DiscoveryPanel.IsShowing: {flag5}");
		Debug.LogWarning($"  FishingManager.enabled: {fManager.enabled}");
		Debug.LogWarning($"  Time.timeScale:         {Time.timeScale}");
		Debug.LogWarning($"  Time.time:              {Time.time:F2}");
		Debug.LogWarning("<color=red>========== [Bot Diagnostic] END DUMP ==========</color>");
	}

	private float GetLastCastTime(FishingManager fManager)
	{
		try
		{
			FieldInfo field = typeof(FishingManager).GetField("lastCastTime", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				return (float)field.GetValue(fManager);
			}
		}
		catch
		{
		}
		return -1f;
	}

	private void ForceResetFishingState()
	{
		FishingManager instance = FishingManager.Instance;
		if (instance == null)
		{
			return;
		}
		Debug.LogWarning($"<color=red>[Bot Recovery] Force-resetting FishingManager from state: {instance.currentState}</color>");
		if (instance.biteIndicatorMinigame != null)
		{
			instance.biteIndicatorMinigame.gameObject.SetActive(value: false);
		}
		if (instance.reelInMinigame != null)
		{
			instance.reelInMinigame.ToggleVisibility(visible: false);
		}
		if (instance.currentBobberObject != null)
		{
			UnityEngine.Object.Destroy(instance.currentBobberObject);
			instance.currentBobberObject = null;
		}
		foreach (GameObject activeBobber in instance.activeBobbers)
		{
			if (activeBobber != null)
			{
				UnityEngine.Object.Destroy(activeBobber);
			}
		}
		instance.activeBobbers.Clear();
		instance.currentBobber = null;
		instance.enabled = true;
		instance.currentState = FishingManager.FishingState.Idle;
	}

	private IEnumerator SimulateFishingDay()
	{
		Debug.Log("<color=orange>[Bot State] SimulateFishingDay Start</color>");
		PlayerStats playerStats = PlayerStats.Instance;
		FishingManager fManager = FishingManager.Instance;
		if (playerStats == null)
		{
			Debug.LogError("<color=red>[Bot CRASH] PlayerStats.Instance is null! Scene may not be ready.</color>");
			yield break;
		}
		if (fManager == null)
		{
			Debug.LogError("<color=red>[Bot CRASH] FishingManager.Instance is null!</color>");
			yield break;
		}
		if (playerManager == null)
		{
			Debug.LogError("<color=red>[Bot CRASH] playerManager is null!</color>");
			yield break;
		}
		bool dayEndedEarly = false;
		int consecutiveFailedCasts = 0;
		Func<bool> dayOver = delegate
		{
			if (playerManager == null)
			{
				return true;
			}
			if (playerManager.endOfDayPanel == null)
			{
				return playerManager.dayEnded;
			}
			return playerManager.dayEnded || playerManager.endOfDayPanel.gameObject.activeInHierarchy;
		};
		Debug.Log($"<color=orange>[Bot State] Energy: {playerManager.currentEnergy} | CostPerCast: {playerStats.EnergyCostPerCast} | dayOver: {dayOver()}</color>");
		if (playerManager.currentEnergy <= 0)
		{
			Debug.LogWarning("<color=yellow>[Bot Wait] Energy is 0 — waiting for PlayerManager.Start() to initialize...</color>");
			float waitedForEnergy = 0f;
			while (playerManager.currentEnergy <= 0 && waitedForEnergy < 1f)
			{
				waitedForEnergy += Time.unscaledDeltaTime;
				yield return null;
			}
			Debug.Log($"<color=yellow>[Bot Wait] After wait: Energy={playerManager.currentEnergy} (waited {waitedForEnergy:F2}s)</color>");
		}
		int castNumber = 0;
		float lastHeartbeat = Time.unscaledTime;
		while (playerManager.currentEnergy >= playerStats.EnergyCostPerCast && !dayOver())
		{
			castNumber++;
			float num = Time.unscaledTime - lastHeartbeat;
			if (num > 2f)
			{
				Debug.LogWarning($"<color=red>[Bot HEARTBEAT] {num:F1}s since last cast — stalling! State={fManager.currentState}</color>");
				LogCastBlockers(fManager);
			}
			lastHeartbeat = Time.unscaledTime;
			if (!fManager.IsIdle)
			{
				Debug.LogWarning($"<color=yellow>[Bot Recovery] Pre-cast: Not Idle (state={fManager.currentState}). Waiting briefly...</color>");
				bool becameIdle = false;
				yield return StartCoroutine(WaitUntilOrTimeout(() => fManager.IsIdle || dayOver(), stuckCastTimeout, delegate(bool met)
				{
					becameIdle = met;
				}));
				if (dayOver())
				{
					dayEndedEarly = true;
					break;
				}
				if (!becameIdle)
				{
					Debug.LogWarning("<color=red>[Bot Recovery] Still not Idle after timeout. Dumping state:</color>");
					LogCastBlockers(fManager);
					consecutiveFailedCasts++;
					if (consecutiveFailedCasts < 3)
					{
						continue;
					}
					Debug.LogWarning("<color=red>[Bot Recovery] Too many consecutive failures — force-resetting FishingManager.</color>");
					ForceResetFishingState();
					consecutiveFailedCasts = 0;
					yield return null;
				}
			}
			Tile tile;
			if (GameGrid.Instance != null && GameGrid.Instance.AllTiles.Count > 0)
			{
				List<Tile> allTiles = GameGrid.Instance.AllTiles;
				tile = allTiles[UnityEngine.Random.Range(0, allTiles.Count)];
			}
			else
			{
				tile = UnityEngine.Object.FindObjectOfType<Tile>();
			}
			if (tile == null)
			{
				Debug.LogWarning("<color=red>[Bot Error] Could not find any tiles to fish on! Stopping day.</color>");
				break;
			}
			_ = fManager.currentState;
			int currentEnergy = playerManager.currentEnergy;
			fManager.OnTileClicked(tile);
			if (playerManager.currentEnergy == currentEnergy)
			{
				Debug.LogWarning($"<color=red>[Bot Recovery] Cast #{castNumber} was REJECTED!</color>");
				LogCastBlockers(fManager);
				consecutiveFailedCasts++;
				if (consecutiveFailedCasts >= 3)
				{
					Debug.LogWarning("<color=red>[Bot Recovery] Too many rejected casts — force-resetting.</color>");
					ForceResetFishingState();
					consecutiveFailedCasts = 0;
					yield return null;
				}
				else
				{
					yield return new WaitForSeconds(0.6f);
				}
				continue;
			}
			consecutiveFailedCasts = 0;
			bool resolvedB = false;
			yield return StartCoroutine(WaitUntilOrTimeout(() => fManager.IsInBiteGame || fManager.IsReeling || fManager.IsIdle || dayOver(), stuckCastTimeout, delegate(bool met)
			{
				resolvedB = met;
			}));
			if (!resolvedB)
			{
				continue;
			}
			if (dayOver())
			{
				dayEndedEarly = true;
				break;
			}
			if (fManager.IsInBiteGame)
			{
				yield return StartCoroutine(OnReactionMiniGame());
				bool resolvedC = false;
				yield return StartCoroutine(WaitUntilOrTimeout(() => fManager.IsReeling || fManager.IsIdle || dayOver(), stuckCastTimeout, delegate(bool met)
				{
					resolvedC = met;
				}));
				if (dayOver())
				{
					dayEndedEarly = true;
					break;
				}
			}
			if (fManager.IsReeling)
			{
				yield return StartCoroutine(OnClickingMiniGame());
			}
			bool resolvedE = false;
			yield return StartCoroutine(WaitUntilOrTimeout(() => fManager.IsIdle || dayOver(), stuckCastTimeout, delegate(bool met)
			{
				resolvedE = met;
			}));
			if (!resolvedE)
			{
				Debug.LogWarning("<color=red>[Bot Wait] Timed out waiting for idle after reel.</color>");
			}
			if (dayOver())
			{
				dayEndedEarly = true;
				break;
			}
			yield return null;
		}
		Debug.Log($"<color=orange>[Bot State] End of Day. Out of energy? {playerManager.currentEnergy < playerStats.EnergyCostPerCast} | DayEnded early? {dayEndedEarly}</color>");
		if (!playerManager.dayEnded)
		{
			playerManager.EndDay();
		}
		Debug.Log("<color=yellow>[Bot Wait] Waiting for EndOfDayPanel...</color>");
		yield return StartCoroutine(WaitUntilOrTimeout(() => playerManager.endOfDayPanel.gameObject.activeInHierarchy, 3f));
		Debug.Log("<color=yellow>[Bot Wait] EndOfDayPanel is active.</color>");
		int count = playerManager.inventory.caughtFish.Count;
		if (count == 0)
		{
			lastExpeditionFailed = true;
			Debug.Log("<color=red>Bot: Caught 0 fish. Marking expedition as Failed.</color>");
		}
		else
		{
			lastExpeditionFailed = false;
			Debug.Log($"Bot: Caught {count} fish. Expedition Success.");
		}
		Debug.Log("<color=yellow>[Bot Wait] Waiting for EndOfDayPanel buttons (data commit)...</color>");
		float panelWait = 0f;
		while (panelWait < 2f)
		{
			panelWait += Time.unscaledDeltaTime;
			if (playerManager.endOfDayPanel.returnToMenuButton != null && playerManager.endOfDayPanel.returnToMenuButton.gameObject.activeSelf)
			{
				break;
			}
			yield return null;
		}
		Debug.Log($"<color=yellow>[Bot Wait] EndOfDayPanel ready (waited {panelWait:F2}s unscaled).</color>");
		Debug.Log("<color=orange>[Bot State] SimulateFishingDay End</color>");
	}
}
