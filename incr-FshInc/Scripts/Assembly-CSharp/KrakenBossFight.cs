using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KrakenBossFight : MonoBehaviour
{
	[Header("Kraken Fish Data")]
	[Tooltip("The 'Kraken' Fish ScriptableObject. Must have at least one Legendary RarityData entry.")]
	public Fish krakenFishSO;

	[Tooltip("The actual Kraken GameObject in the scene (to be hidden after defeat).")]
	public GameObject krakenModel;

	[Header("Dialogue")]
	[Tooltip("Dialogue played when the player wins the boss fight (Kraken defeat lines).")]
	public DialogueSequenceSO defeatDialogue;

	[Tooltip("Optional: Cutscene played after the defeat dialogue.")]
	public PlayableAsset defeatCutscene;

	[Tooltip("Optional: Dialogue played after the defeat cutscene.")]
	public DialogueSequenceSO postDefeatDialogue;

	[Tooltip("Optional: Dialogue played when the player loses the reel-in. Leave empty to skip.")]
	public DialogueSequenceSO retryDialogue;

	private bool _biteResultReceived;

	private bool _biteSuccess;

	private bool _reelInResultReceived;

	private bool _reelInSuccess;

	private ReelInMinigame ReelInMinigame => FishingManager.Instance?.reelInMinigame;

	private BiteIndicatorMinigame BiteIndicator => FishingManager.Instance?.biteIndicatorMinigame;

	public IEnumerator StartBossFight()
	{
		if (krakenFishSO == null)
		{
			Debug.LogError("[KrakenBossFight] krakenFishSO is not assigned! Skipping boss fight.");
			yield break;
		}
		if (FishingManager.Instance == null)
		{
			Debug.LogError("[KrakenBossFight] FishingManager.Instance is null.");
			yield break;
		}
		ReelInMinigame reel = ReelInMinigame;
		if (reel == null)
		{
			Debug.LogError("[KrakenBossFight] FishingManager.reelInMinigame is null.");
			yield break;
		}
		RarityData rarityData = krakenFishSO.GetRarityData(FishRarity.Legendary);
		if (rarityData == null)
		{
			Debug.LogError("[KrakenBossFight] Kraken Fish SO has no Legendary RarityData!");
			yield break;
		}
		CaughtFish krakenFish = new CaughtFish(krakenFishSO, rarityData);
		UnityEngine.Object.FindObjectOfType<FishTrackerHUD>()?.ForceHide();
		BiteIndicatorMinigame biteIndicator = BiteIndicator;
		if (biteIndicator == null)
		{
			Debug.LogError("[KrakenBossFight] FishingManager.biteIndicator is null!");
			yield break;
		}
		_biteResultReceived = false;
		_biteSuccess = false;
		BiteIndicatorMinigame.OnBiteIndicatorComplete += OnBiteIndicatorComplete;
		float reactionTime = ((PlayerStats.Instance != null) ? (PlayerStats.Instance.ReactionTime * 1.5f) : 1.5f);
		yield return StartCoroutine(biteIndicator.StartMinigame(null, reactionTime));
		yield return new WaitUntil(() => _biteResultReceived);
		BiteIndicatorMinigame.OnBiteIndicatorComplete -= OnBiteIndicatorComplete;
		if (!_biteSuccess)
		{
			yield return StartCoroutine(HandleLose());
			yield break;
		}
		Vector3 spawnWorldPos = ((FishingManager.Instance != null && FishingManager.Instance.currentTile != null) ? FishingManager.Instance.currentTile.transform.position : base.transform.position);
		_reelInResultReceived = false;
		_reelInSuccess = false;
		ReelInMinigame.OnReelInComplete += OnReelInComplete;
		yield return StartCoroutine(reel.StartMinigame(krakenFish, FishingManager.Instance, spawnWorldPos));
		yield return new WaitUntil(() => _reelInResultReceived);
		ReelInMinigame.OnReelInComplete -= OnReelInComplete;
		if (_reelInSuccess)
		{
			yield return StartCoroutine(HandleWin(krakenFish));
		}
		else
		{
			yield return StartCoroutine(HandleLose());
		}
	}

	private void OnBiteIndicatorComplete(bool success, bool perfect)
	{
		_biteSuccess = success;
		_biteResultReceived = true;
	}

	private void OnReelInComplete(bool success)
	{
		_reelInSuccess = success;
		_reelInResultReceived = true;
	}

	private IEnumerator HandleWin(CaughtFish krakenFish)
	{
		Debug.Log("[KrakenBossFight] ✅ Player won the boss fight! Triggering End Game Sequence...");
		int amount = (krakenFish.xpValue = ((FishLogManager.Instance != null) ? FishLogManager.Instance.GetFinalXPGain(krakenFish) : krakenFish.xpValue));
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.LogFish(krakenFish);
		}
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.NotifyXpEarned(amount);
		}
		if (SteamAchievementManager.Instance != null)
		{
			SteamAchievementManager.Instance.NotifyFishCaught(krakenFish);
		}
		if (FishingManager.Instance != null && FishingManager.Instance.inventory != null)
		{
			FishingManager.Instance.inventory.AddFish(krakenFish);
		}
		if (defeatCutscene != null && CutsceneManager.Instance != null)
		{
			CutsceneEntry cutsceneEntry = new CutsceneEntry
			{
				timelineAsset = defeatCutscene,
				playOnce = false,
				skippable = true,
				blockFishing = true,
				showCinematicBars = true,
				hideUI = true
			};
			CutsceneManager.Instance.PlayCutscene(cutsceneEntry);
			yield return new WaitUntil(() => !CutsceneManager.Instance.IsCutsceneActive);
			if (krakenModel != null)
			{
				krakenModel.SetActive(value: false);
			}
		}
		if (FishingManager.Instance != null && FishingManager.Instance.discoveryPanel != null)
		{
			FishingManager.Instance.discoveryPanel.ShowDiscovery(krakenFish);
			yield return new WaitUntil(() => !FishingManager.Instance.discoveryPanel.IsShowing);
			yield return new WaitForSeconds(0.2f);
		}
		if (postDefeatDialogue != null && DialogueManager.Instance != null)
		{
			yield return StartCoroutine(PlayDialogueAndWait(postDefeatDialogue));
		}
		if (KrakenEventManager.Instance != null)
		{
			KrakenEventManager.Instance.MarkKrakenCaught();
		}
		if (SteamAchievementManager.Instance != null)
		{
			SteamAchievementManager.Instance.NotifyKrakenDefeated();
		}
		if (FishingManager.Instance != null)
		{
			FishingManager.Instance.currentState = FishingManager.FishingState.Idle;
			foreach (GameObject activeBobber in FishingManager.Instance.activeBobbers)
			{
				if (activeBobber != null)
				{
					UnityEngine.Object.Destroy(activeBobber);
				}
			}
			FishingManager.Instance.activeBobbers.Clear();
			FishingManager.Instance.currentBobber = null;
			FishingManager.Instance.currentBobberObject = null;
			if (CameraController.Instance != null)
			{
				CameraController.Instance.ResetZoom();
			}
		}
		if (PlayerManager.Instance != null)
		{
			PlayerManager.Instance.dayEnded = true;
		}
		if (FishingManager.Instance != null && FishingManager.Instance.inventory != null)
		{
			List<CaughtFish> caughtFish = FishingManager.Instance.inventory.caughtFish;
			double num = 0.0;
			foreach (CaughtFish item in caughtFish)
			{
				int num2 = (item.isTripleCatch ? 3 : ((!item.isDoubleCatch) ? 1 : 2));
				double num3 = PlayerStats.Instance.GetFishValueZoneSynergyMultiplier(GameManager.Instance.currentZone.currentLevel);
				double num4 = Math.Round(item.value * (double)PlayerStats.Instance.FishValueMultiplier * num3);
				double num5 = (item.isPerfectCatch ? Math.Round(num4 * (double)PlayerStats.Instance.perfectCatchBonusMultiplier - num4) : 0.0);
				num += (num4 + num5) * (double)num2;
			}
			double num6 = ((GameManager.Instance.currentZone != null) ? ((double)GameManager.Instance.currentZone.GetCurrentGoldBonusPercent()) : 0.0);
			double num7 = ((PlayerStats.Instance.SponsorShipBonus > 0f) ? (Math.Round(num * ((double)PlayerStats.Instance.SponsorshipAdditive * 0.01)) * Math.Round(PlayerStats.Instance.SponsorshipMultiplier)) : 0.0);
			num += Math.Round(num * num6) + num7;
			GameManager.Instance.AddEarnings(num, "EndOfDay_Kraken");
			Debug.Log($"[KrakenBossFight] Paid player {num} for day's catch before credits.");
		}
		yield return new WaitForSeconds(0.3f);
		EndOfGamePanel endOfGamePanel = UnityEngine.Object.FindObjectOfType<EndOfGamePanel>(includeInactive: true);
		if (endOfGamePanel != null)
		{
			endOfGamePanel.ShowEndOfGamePanel();
		}
		else
		{
			Debug.LogWarning("[KrakenBossFight] EndOfGamePanel not found in the scene! Cannot show end stats.");
		}
		Debug.Log("[KrakenBossFight] \ud83e\udd91 Kraken End of Game Sequence complete.");
	}

	private IEnumerator HandleLose()
	{
		Debug.Log("[KrakenBossFight] ❌ Player lost the boss fight. Ending day.");
		if (FishingManager.Instance != null)
		{
			FishingManager.Instance.currentState = FishingManager.FishingState.ReelingIn;
			FishingManager.Instance.OnReelInResult(success: false);
		}
		if (retryDialogue != null && DialogueManager.Instance != null)
		{
			yield return StartCoroutine(PlayDialogueAndWait(retryDialogue));
		}
		if (PlayerManager.Instance != null)
		{
			PlayerManager.Instance.EndDay();
		}
	}

	public void PlayKrakenScream()
	{
		SoundManager.PlaySound("KrakenScream");
	}

	[ContextMenu("DEBUG: Instant Catch Kraken")]
	public void Debug_InstantCatchKraken()
	{
		if (krakenFishSO == null)
		{
			Debug.LogError("[KrakenBossFight] krakenFishSO is not assigned!");
			return;
		}
		RarityData rarityData = krakenFishSO.GetRarityData(FishRarity.Legendary);
		if (rarityData == null)
		{
			Debug.LogError("[KrakenBossFight] Kraken Fish SO has no Legendary RarityData!");
			return;
		}
		CaughtFish krakenFish = new CaughtFish(krakenFishSO, rarityData);
		StartCoroutine(HandleWin(krakenFish));
	}

	private IEnumerator PlayDialogueAndWait(DialogueSequenceSO sequence)
	{
		bool done = false;
		DialogueManager.OnDialogueEnd += OnEnd;
		DialogueManager.Instance.ShowDialogue(sequence);
		yield return new WaitUntil(() => done);
		DialogueManager.OnDialogueEnd -= OnEnd;
		void OnEnd()
		{
			done = true;
		}
	}
}
