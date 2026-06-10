using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Tilemaps;

public class FishingManager : MonoBehaviour
{
	public enum FishingState
	{
		Idle = 0,
		Casting = 1,
		WaitingForBite = 2,
		BiteIndicator = 3,
		Reacting = 4,
		ReelingIn = 5,
		FishCaught = 6,
		FishLost = 7
	}

	public FishingState currentState;

	public Inventory inventory;

	public PlayerManager playerManager;

	public ReelInMinigame reelInMinigame;

	public BiteIndicatorMinigame biteIndicatorMinigame;

	public GameObject bobberPrefab;

	public Tile currentTile;

	private Vector3 lastBobberPosition;

	[Header("Tutorials")]
	public DialogueSequenceSO firstCastTutorial;

	private const string FirstCastTutorKey = "FirstCastTutorSeen";

	public CaughtFish potentialFish;

	public NewFishDiscoveryPanel discoveryPanel;

	[Header("Idle Hint System")]
	public SuperTextMesh idleHintText;

	private float idleStartTime;

	private const float IDLE_HINT_DELAY = 5f;

	private bool isPerfectCatch;

	private bool isEndOfDaySequenceRunning;

	private float lastCastTime = -1f;

	private const float CAST_COOLDOWN = 0.5f;

	private float reelInStartTime;

	private float currentCatchDuration;

	private List<FishHabitat> activeHabitats = new List<FishHabitat>();

	[SerializeField]
	public Tilemap waterTilemap;

	[SerializeField]
	private Tilemap landTilemap;

	public GameObject currentBobberObject;

	public Bobber currentBobber;

	public List<GameObject> activeBobbers = new List<GameObject>();

	private int expectedCatchAmount = 1;

	private float maxFailedClicks;

	private bool hasFailedThisTrip;

	private const float RARITY_PROTECTION_THRESHOLD = 0.9f;

	public static FishingManager Instance { get; private set; }

	public bool IsCasting => currentState == FishingState.Casting;

	public bool IsCastingOrWaiting
	{
		get
		{
			if (currentState != FishingState.Casting)
			{
				return currentState == FishingState.WaitingForBite;
			}
			return true;
		}
	}

	public bool IsReeling => currentState == FishingState.ReelingIn;

	public bool IsInBiteGame => currentState == FishingState.BiteIndicator;

	public bool IsIdle => currentState == FishingState.Idle;

	public bool IsFishing()
	{
		if (currentState == FishingState.Idle)
		{
			return currentBobberObject != null;
		}
		return true;
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		currentState = FishingState.Idle;
		idleStartTime = Time.time;
		if (idleHintText != null)
		{
			idleHintText.fade = 0f;
			idleHintText.Rebuild();
		}
		if (reelInMinigame != null)
		{
			reelInMinigame.ToggleVisibility(visible: false);
		}
		if (biteIndicatorMinigame != null)
		{
			biteIndicatorMinigame.gameObject.SetActive(value: false);
		}
		isEndOfDaySequenceRunning = false;
		maxFailedClicks = 0f;
		hasFailedThisTrip = false;
	}

	public static void RegisterHabitat(FishHabitat habitat)
	{
		if (Instance != null && !Instance.activeHabitats.Contains(habitat))
		{
			Instance.activeHabitats.Add(habitat);
		}
	}

	public static void UnregisterHabitat(FishHabitat habitat)
	{
		if (Instance != null)
		{
			Instance.activeHabitats.Remove(habitat);
		}
	}

	public void OnTileHoverEntered(Tile tile)
	{
		if (!PlayerManager.Instance.dayEnded && currentState == FishingState.Idle && (!(DialogueManager.Instance != null) || !DialogueManager.Instance.isCutsceneActive) && (!(CutsceneManager.Instance != null) || !CutsceneManager.Instance.IsBlockingFishing) && !EndOfGamePanel.IsVisible && CameraController.Instance != null)
		{
			CameraController.Instance.PanTowards(tile.transform.position);
		}
	}

	public void OnTileHoverExited(Tile tile)
	{
	}

	public void OnTileClicked(Tile clickedTile)
	{
		if (PlayerManager.Instance.dayEnded || Time.time - lastCastTime < 0.5f || currentBobberObject != null || currentState != FishingState.Idle || playerManager.currentEnergy < PlayerStats.Instance.EnergyCostPerCast || (DialogueManager.Instance != null && DialogueManager.Instance.isCutsceneActive) || (CutsceneManager.Instance != null && CutsceneManager.Instance.IsBlockingFishing) || (KrakenEventManager.Instance != null && KrakenEventManager.Instance.IsBossSequenceActive) || EndOfGamePanel.IsVisible)
		{
			return;
		}
		Debug.Log("TILE CLICKED: " + base.gameObject.name);
		playerManager.UseEnergy();
		currentState = FishingState.Casting;
		currentTile = clickedTile;
		lastBobberPosition = currentTile.transform.position;
		lastCastTime = Time.time;
		if (CameraController.Instance != null)
		{
			CameraController.Instance.ZoomToTarget(currentTile.transform.position);
		}
		currentBobberObject = Object.Instantiate(bobberPrefab, lastBobberPosition, Quaternion.identity);
		currentBobber = currentBobberObject.GetComponent<Bobber>();
		activeBobbers.Add(currentBobberObject);
		if (!(currentBobber != null))
		{
			return;
		}
		currentBobber.onFishBite.AddListener(OnBite);
		int num = ((PlayerStats.Instance.TripleCatchChance > 0f) ? 2 : ((PlayerStats.Instance.DoubleCatchChance > 0f) ? 1 : 0));
		if (num <= 0)
		{
			return;
		}
		foreach (Tile adjacentWaterTile in GetAdjacentWaterTiles(currentTile, num))
		{
			GameObject gameObject = Object.Instantiate(bobberPrefab, adjacentWaterTile.transform.position, Quaternion.identity);
			Bobber component = gameObject.GetComponent<Bobber>();
			if (component != null)
			{
				component.SetAsVisualOnly();
			}
			activeBobbers.Add(gameObject);
		}
	}

	private bool IsWaterAtWorldPos(Vector3 worldPos)
	{
		Vector3Int position = waterTilemap.WorldToCell(worldPos);
		bool num = waterTilemap.HasTile(position);
		bool flag = landTilemap != null && landTilemap.HasTile(position);
		if (num)
		{
			return !flag;
		}
		return false;
	}

	private List<Tile> GetAdjacentWaterTiles(Tile centerTile, int count)
	{
		List<Tile> list = new List<Tile>();
		if (GameGrid.Instance == null || GameGrid.Instance.AllTiles == null)
		{
			return list;
		}
		foreach (Tile allTile in GameGrid.Instance.AllTiles)
		{
			if (!(allTile == centerTile) && Vector3.Distance(allTile.transform.position, centerTile.transform.position) < 1.6f)
			{
				list.Add(allTile);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			int index = Random.Range(i, list.Count);
			Tile value = list[index];
			list[index] = list[i];
			list[i] = value;
		}
		List<Tile> list2 = new List<Tile>();
		for (int j = 0; j < count && j < list.Count; j++)
		{
			list2.Add(list[j]);
		}
		return list2;
	}

	public void OnBite()
	{
		currentState = FishingState.BiteIndicator;
		isPerfectCatch = false;
		expectedCatchAmount = 1;
		float tripleCatchChance = PlayerStats.Instance.TripleCatchChance;
		if (tripleCatchChance > 0f && Random.value <= tripleCatchChance * 0.01f)
		{
			expectedCatchAmount = 3;
		}
		else
		{
			float doubleCatchChance = PlayerStats.Instance.DoubleCatchChance;
			if (doubleCatchChance > 0f && Random.value <= doubleCatchChance * 0.01f)
			{
				expectedCatchAmount = 2;
			}
		}
		int num = 0;
		foreach (GameObject activeBobber in activeBobbers)
		{
			if (activeBobber == null)
			{
				continue;
			}
			Bobber component = activeBobber.GetComponent<Bobber>();
			if (component != null && num < expectedCatchAmount)
			{
				if (component != currentBobber)
				{
					component.TriggerVisualBite();
				}
				num++;
			}
		}
		VFXPooler.Instance.PlayEffect("FishBite", lastBobberPosition);
		float autoHookChance = PlayerStats.Instance.AutoHookChance;
		if (autoHookChance > 0f && Random.value <= autoHookChance * 0.01f)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.auto.hooked");
			isPerfectCatch = true;
			NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), lastBobberPosition, Color.yellow);
			float reactionTime = PlayerStats.Instance.ReactionTime;
			StartCoroutine(biteIndicatorMinigame.StartMinigame(this, reactionTime, autoHooked: true));
		}
		else
		{
			float reactionTime2 = PlayerStats.Instance.ReactionTime;
			StartCoroutine(biteIndicatorMinigame.StartMinigame(this, reactionTime2));
		}
	}

	public void OnBiteIndicatorResult(bool playerClicked, bool perfectTiming)
	{
		if (currentState != FishingState.BiteIndicator)
		{
			return;
		}
		if (!playerClicked)
		{
			CaughtFish randomFish = GetRandomFish();
			if (randomFish != null)
			{
				AnalyticsLogger.Instance.LogFishMissed(randomFish.fishName, randomFish.rarityName, GameManager.Instance.totalMoney, randomFish.value, randomFish.xpValue);
			}
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.miss.bite");
			NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), lastBobberPosition, Color.red);
			FishLost("Missed the bite!");
		}
		else
		{
			isPerfectCatch = perfectTiming;
			if (perfectTiming)
			{
				LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.notif.perfect.catch");
				NotificationManager.Instance.ShowNotification(localizedString2.GetLocalizedString(), lastBobberPosition, Color.yellow);
			}
			StartReelInMinigame();
		}
	}

	public void OnReelInResult(bool success)
	{
		if (currentState != FishingState.ReelingIn)
		{
			return;
		}
		currentCatchDuration = Time.time - reelInStartTime;
		if (success)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.fish.caught");
			NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), lastBobberPosition, Color.green);
			FishCaught();
			return;
		}
		if (potentialFish != null)
		{
			AnalyticsLogger.Instance.LogFishMissed(potentialFish.fishName, potentialFish.rarityName, GameManager.Instance.totalMoney, potentialFish.value, potentialFish.xpValue, currentCatchDuration);
			float completionClicks = reelInMinigame.CompletionClicks;
			int requiredClicks = reelInMinigame.RequiredClicks;
			float num = ((requiredClicks > 0) ? (completionClicks / (float)requiredClicks) : 1f);
			if (num < 0.9f)
			{
				maxFailedClicks = Mathf.Max(maxFailedClicks, completionClicks);
				hasFailedThisTrip = true;
				Debug.Log($"[RarityProtection] Recorded fail: {completionClicks:F0}/{requiredClicks} clicks ({num * 100f:F0}%) — max clicks this trip: {maxFailedClicks:F0}");
			}
		}
		LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.notif.got.away");
		NotificationManager.Instance.ShowNotification(localizedString2.GetLocalizedString(), lastBobberPosition, Color.red);
		FishLost("The fish got away!");
	}

	private void FishCaught()
	{
		currentState = FishingState.FishCaught;
		potentialFish.isPerfectCatch = isPerfectCatch;
		if (expectedCatchAmount == 3)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.triple.catch");
			potentialFish.isTripleCatch = true;
			NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), currentTile.transform.position, Color.magenta);
		}
		else if (expectedCatchAmount == 2)
		{
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.notif.double.catch");
			potentialFish.isDoubleCatch = true;
			NotificationManager.Instance.ShowNotification(localizedString2.GetLocalizedString(), currentTile.transform.position, Color.cyan);
		}
		inventory.AddFish(potentialFish);
		VFXPooler.Instance.PlayEffect("FishCatch", currentTile.transform.position);
		string fishName = potentialFish.fishName;
		bool isLastCast = playerManager.currentEnergy <= 0;
		bool isNewDiscovery = !FishLogManager.Instance.HasCaughtSpecies(potentialFish.fishName);
		int finalXPGain = FishLogManager.Instance.GetFinalXPGain(potentialFish);
		AchievementManager.Instance?.NotifyXpEarned(finalXPGain);
		int fishLevel = FishLogManager.Instance.GetFishLevel(fishName);
		int fishXP = FishLogManager.Instance.GetFishXP(fishName);
		int xpForNextLevel = potentialFish.fish.GetXpForNextLevel(fishLevel);
		potentialFish.xpValue = finalXPGain;
		FishLogManager.Instance.LogFish(potentialFish);
		SteamAchievementManager.Instance.NotifyFishCaught(potentialFish);
		if (isPerfectCatch)
		{
			AchievementManager.Instance?.NotifyPerfectCatch();
		}
		else
		{
			AchievementManager.Instance?.NotifyNonPerfectCatch();
		}
		if (expectedCatchAmount >= 2)
		{
			AchievementManager.Instance?.NotifyMultiCatch();
			if (expectedCatchAmount >= 3)
			{
				AchievementManager.Instance?.NotifyTripleCatch();
				if (SteamAchievementManager.Instance != null)
				{
					SteamAchievementManager.Instance.NotifyTripleCatch();
				}
			}
			else if (SteamAchievementManager.Instance != null)
			{
				SteamAchievementManager.Instance.NotifyDoubleCatch();
			}
		}
		else
		{
			AchievementManager.Instance?.NotifyNonMultiCatch();
		}
		AnalyticsLogger.Instance.LogFishCaught(potentialFish.fishName, potentialFish.rarityName, GameManager.Instance.totalMoney, potentialFish.value, potentialFish.xpValue, currentCatchDuration);
		StartCoroutine(HandleCatchUISequence(isNewDiscovery, isLastCast, potentialFish, fishLevel, fishXP, xpForNextLevel));
	}

	private void Update()
	{
		HandleIdleHint();
	}

	private void HandleIdleHint()
	{
		if (!(idleHintText == null))
		{
			bool num = currentState == FishingState.Idle && !PlayerManager.Instance.dayEnded && (DialogueManager.Instance == null || !DialogueManager.Instance.isCutsceneActive);
			bool flag = Time.time - idleStartTime >= 5f;
			float num2 = ((num && flag) ? 1f : 0f);
			float fade = idleHintText.fade;
			if (Mathf.Abs(fade - num2) > 0.001f)
			{
				fade = Mathf.MoveTowards(fade, num2, Time.deltaTime * 2f);
				idleHintText.fade = fade;
				idleHintText.Rebuild();
			}
			else if (fade != num2)
			{
				idleHintText.fade = num2;
				idleHintText.Rebuild();
			}
		}
	}

	private IEnumerator HandleCatchUISequence(bool isNewDiscovery, bool isLastCast, CaughtFish caughtFish, int fishLevel, int currentXp, int xpToNext)
	{
		if (isNewDiscovery)
		{
			discoveryPanel.ShowDiscovery(caughtFish);
			yield return new WaitUntil(() => !discoveryPanel.IsShowing);
			yield return new WaitForSeconds(0.2f);
		}
		if (FishCaughtAlert.Instance != null)
		{
			FishCaughtAlert.TriggerAlert(caughtFish, fishLevel, currentXp, xpToNext, isLastCast);
		}
		ResetState();
	}

	private void FishLost(string reason)
	{
		ResetState();
	}

	private void ResetState()
	{
		foreach (GameObject activeBobber in activeBobbers)
		{
			if (activeBobber != null)
			{
				Bobber component = activeBobber.GetComponent<Bobber>();
				if (component != null)
				{
					component.AnimateReelOut(currentTile.transform.position, 0.4f);
				}
				else
				{
					Object.Destroy(activeBobber);
				}
			}
		}
		activeBobbers.Clear();
		currentBobberObject = null;
		currentBobber = null;
		if (CameraController.Instance != null)
		{
			CameraController.Instance.ResetZoom();
		}
		if (playerManager.currentEnergy <= 0)
		{
			StartCoroutine(EndOfDaySequence());
		}
		else
		{
			StartCoroutine(IdleDelay());
		}
	}

	private IEnumerator EndOfDaySequence()
	{
		if (isEndOfDaySequenceRunning)
		{
			yield break;
		}
		isEndOfDaySequenceRunning = true;
		float timeout = Time.time + 10f;
		yield return new WaitUntil(() => !FishCaughtAlert.IsVisible || Time.time > timeout);
		if (FishCaughtAlert.IsVisible)
		{
			Debug.LogWarning("[FishingManager] FishCaughtAlert timed out — force-hiding to prevent soft lock.");
			if (FishCaughtAlert.Instance != null)
			{
				FishCaughtAlert.Instance.ForceHide();
			}
		}
		if (KrakenEventManager.Instance != null)
		{
			yield return new WaitUntil(() => !KrakenEventManager.Instance.IsBossSequenceActive);
		}
		playerManager.EndDay();
		isEndOfDaySequenceRunning = false;
	}

	private IEnumerator IdleDelay()
	{
		yield return new WaitForSeconds(1f);
		currentState = FishingState.Idle;
		idleStartTime = Time.time;
	}

	private void StartReelInMinigame()
	{
		currentState = FishingState.ReelingIn;
		reelInStartTime = Time.time;
		potentialFish = GetRandomFish();
		if (potentialFish != null)
		{
			potentialFish.isPerfectCatch = isPerfectCatch;
		}
		if (potentialFish == null)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.got.away");
			NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), lastBobberPosition, Color.red);
			FishLost("It got away...");
		}
		else
		{
			StartCoroutine(reelInMinigame.StartMinigame(potentialFish, this, lastBobberPosition, isPerfectCatch));
		}
	}

	private CaughtFish GetRandomFish()
	{
		ZoneData currentZone = GameManager.Instance.currentZone;
		if (currentZone == null || currentZone.possibleCatches == null || currentZone.possibleCatches.Count == 0)
		{
			return null;
		}
		Dictionary<Fish, float> dictionary = new Dictionary<Fish, float>();
		float num = 0f;
		Vector3 position = currentTile.transform.position;
		foreach (FishEncounterData possibleCatch in currentZone.possibleCatches)
		{
			Fish fishSpecies = possibleCatch.fishSpecies;
			float num2 = 100f;
			float num3 = 0f;
			foreach (FishHabitat activeHabitat in activeHabitats)
			{
				num3 += activeHabitat.GetBoostPercentage(fishSpecies, position);
			}
			num2 *= 1f + num3;
			Debug.Log($"Fish: {fishSpecies.speciesName} | Base: {100:F0} | Boost: +{num3 * 100f:F1}% | Final: {num2:F1}");
			dictionary.Add(fishSpecies, num2);
			num += num2;
		}
		Fish fish = null;
		if (num > 0f)
		{
			float num4 = Random.Range(0f, num);
			float num5 = 0f;
			foreach (KeyValuePair<Fish, float> item in dictionary)
			{
				num5 += item.Value;
				if (num4 <= num5)
				{
					fish = item.Key;
					break;
				}
			}
		}
		if (fish == null)
		{
			fish = currentZone.possibleCatches[Random.Range(0, currentZone.possibleCatches.Count)].fishSpecies;
		}
		if (FishLogManager.Instance != null && FishLogManager.Instance.TotalGlobalFishCaught == 0)
		{
			List<Fish> list = new List<Fish>();
			foreach (FishEncounterData possibleCatch2 in currentZone.possibleCatches)
			{
				RarityData rarityData = possibleCatch2.fishSpecies.GetRarityData(FishRarity.Common);
				if (rarityData != null && rarityData.clicks <= 15)
				{
					list.Add(possibleCatch2.fishSpecies);
				}
			}
			Fish fish2 = ((list.Count > 0) ? list[Random.Range(0, list.Count)] : fish);
			RarityData rarityData2 = fish2.GetRarityData(FishRarity.Common);
			if (rarityData2 != null)
			{
				Debug.Log($"[FirstCatch] Guaranteeing Common {fish2.speciesName} ({rarityData2.clicks} clicks) for first-ever catch");
				return new CaughtFish(fish2, rarityData2);
			}
		}
		Dictionary<FishRarity, float> levelModifiedRarityWeights = fish.GetLevelModifiedRarityWeights(fish.currentLevel);
		float num6 = Mathf.Max(0f, PlayerStats.Instance.GetRareChanceZoneSynergyMultiplier(currentZone.currentLevel));
		float num7 = 0f;
		foreach (FishRarity item2 in levelModifiedRarityWeights.Keys.ToList())
		{
			if (item2 != FishRarity.Common)
			{
				levelModifiedRarityWeights[item2] *= num6;
			}
			num7 += levelModifiedRarityWeights[item2];
		}
		FishRarity rolledRarity = FishRarity.Common;
		if (num7 <= 0f)
		{
			Debug.LogError("Total rarity chance for zone '" + currentZone.zoneName + "' is zero. Falling back to Common. If using a Rarity Override, make sure the 'Rarity Overrides' list is not empty and that at least one 'Chance Weight' is greater than 0.");
			rolledRarity = FishRarity.Common;
		}
		else
		{
			float num8 = Random.Range(0f, num7);
			float num9 = 0f;
			foreach (KeyValuePair<FishRarity, float> item3 in levelModifiedRarityWeights)
			{
				num9 += item3.Value;
				if (num8 <= num9)
				{
					rolledRarity = item3.Key;
					break;
				}
			}
		}
		rolledRarity = ApplyRarityProtection(rolledRarity, fish);
		RarityData rarityData3 = fish.GetRarityData(rolledRarity);
		if (rarityData3 == null)
		{
			Debug.LogError("Fish '" + fish.speciesName + "' has no rarity data defined in its ScriptableObject, or the list is empty. Cannot create CaughtFish object.");
			return null;
		}
		return new CaughtFish(fish, rarityData3);
	}

	private FishRarity ApplyRarityProtection(FishRarity rolledRarity, Fish fish)
	{
		if (!hasFailedThisTrip || rolledRarity == FishRarity.Common)
		{
			return rolledRarity;
		}
		float num = ((PlayerStats.Instance != null) ? PlayerStats.Instance.ClicksRequiredMultiplier : 1f);
		float num2 = maxFailedClicks / 0.9f;
		FishRarity fishRarity;
		for (fishRarity = rolledRarity; fishRarity > FishRarity.Common; fishRarity--)
		{
			RarityData rarityData = fish.GetRarityData(fishRarity);
			if (rarityData != null && (float)rarityData.clicks * num <= num2)
			{
				break;
			}
		}
		if (fishRarity != rolledRarity)
		{
			int num3 = fish.GetRarityData(rolledRarity)?.clicks ?? 0;
			Debug.Log($"[RarityProtection] Downgraded {rolledRarity}→{fishRarity} for {fish.speciesName} " + $"(needs {Mathf.CeilToInt((float)num3 * num)}, player max {maxFailedClicks:F0}, capacity {num2:F0})");
		}
		return fishRarity;
	}
}
