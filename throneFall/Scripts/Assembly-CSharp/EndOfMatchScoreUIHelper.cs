using System.Collections;
using MPUIKIT;
using Rewired;
using TMPro;
using UnityEngine;

public class EndOfMatchScoreUIHelper : MonoBehaviour
{
	[Header("Pre Frame")]
	public GameObject preFrameParent;

	public GameObject mainFrameParent;

	public GameObject preFrameVictory;

	public GameObject preFrameDefeat;

	public RectTransform preFrameMask;

	public CanvasGroup preFrameCG;

	public CanvasGroup mainFrameCG;

	public float preFrameMaskTargetHeight;

	public AnimationCurve preFrameMaskACCurve;

	public float preFrameAnimationTime = 0.75f;

	public float preFrameWaittime;

	public AudioSource audioSource;

	[Header("Main Frame")]
	public TextMeshProUGUI baseScore;

	public TextMeshProUGUI goldScore;

	public TextMeshProUGUI mutatorScore;

	public TextMeshProUGUI noRetriesScore;

	public TextMeshProUGUI overallScore;

	public TextMeshProUGUI bestScore;

	public TextMeshProUGUI levelDisplay;

	public TextMeshProUGUI xpDisplay;

	public TextMeshProUGUI levelUpLevelDisplay;

	public TextMeshProUGUI levelUpRewardDescription;

	public TextMeshProUGUI victoryDisplay;

	public TextMeshProUGUI defeatDisplay;

	public TextMeshProUGUI baseScoreName;

	public TextMeshProUGUI goldBonusName;

	public TextMeshProUGUI MutatorBonusName;

	public TextMeshProUGUI noRetryBonusName;

	public GameObject victoryParent;

	public GameObject defeatParent;

	public GameObject newHighscoreIndicator;

	public GameObject progressionBarParent;

	public GameObject demoMaxLevel;

	public GameObject regularMaxLevel;

	public GameObject rewardWaitIndicator;

	public GameObject victoryButtonsClassic;

	public GameObject defeatButtonsClassic;

	public GameObject victoryButtonsET;

	public GameObject defeatButtonsET;

	public GameObject dividerParent;

	public GameObject progressionBarORMaxLevelParent;

	public GameObject progressionBarOnly;

	public GameObject nextPerk;

	public MPImageBasic xpFill;

	public MPImageBasic nextUnlockIcon;

	public MPImageBasic nextunlockBG;

	public MPImageBasic levelUpRewardIcon;

	public MPImageBasic levelUpRewardBg;

	public MPImageBasic rewardWaitFill;

	public Color weaponBG;

	public Color perkBG;

	public Color mutatorBG;

	public Color perkpointBG;

	public Color buildingUpgradeBG;

	public Color trophyBG;

	public ThronefallUIElement victoryClassicSelectedButton;

	public ThronefallUIElement defeatClassicSelectedButton;

	public ThronefallUIElement victoryETSelectedButton;

	public ThronefallUIElement defeatETSelectedButton;

	public ThronefallUIElement rewardAcceptButton;

	public UIFrame rewardFrame;

	public AnimationCurve popShowCurve;

	public AnimationCurve bumpCurve;

	public AnimationCurve scoreFillWiggle;

	[Header("Animation Sequences")]
	public IUIAnimationSequence eternalTrialsVictory;

	public IUIAnimationSequence eternalTrialsDefeat;

	[Header("Settings")]
	[SerializeField]
	private float timeToFillUpABar = 3f;

	[SerializeField]
	private float waitAtBeginning = 0.25f;

	[SerializeField]
	private float waitAfterFillingUpABar = 0.25f;

	[SerializeField]
	private float waitAfterReward = 2f;

	[SerializeField]
	private float waitWhenMaxLevelAlreadyReached = 0.5f;

	private MetaLevel nextMetaLevel;

	private PerkManager perkManager;

	private Player input;

	private UIFrame frame;

	private bool inAnimation;

	private bool inScoreUnroll;

	private int baseScoreThisRound;

	private int goldScoreThisRound;

	private int mutatorScoreThisRound;

	private int noRetryScoreThisRound;

	private int overallScoreThisRound;

	private int animationNextScore;

	private float defaultWaitStep = 0.5f;

	private float minorWaitStep = 0.25f;

	private float animationStepA = 1.5f;

	private float animationStepB = 0.5f;

	private bool skipScoringAnimation;

	private Coroutine currentScoringAnimation;

	private void Update()
	{
		if (input.GetButtonDown("Interact") && inScoreUnroll)
		{
			if (currentScoringAnimation != null)
			{
				StopCoroutine(currentScoringAnimation);
			}
			currentScoringAnimation = null;
			audioSource.Stop();
			skipScoringAnimation = true;
			inScoreUnroll = false;
		}
	}

	public void OnActivate()
	{
		if ((bool)LocalGamestate.Instance && LocalGamestate.Instance.endScreenShownThisMatch)
		{
			Time.timeScale = 0f;
		}
		else if (!inAnimation)
		{
			if ((bool)LocalGamestate.Instance)
			{
				LocalGamestate.Instance.endScreenShownThisMatch = true;
			}
			inAnimation = true;
			inScoreUnroll = false;
			skipScoringAnimation = false;
			perkManager = PerkManager.instance;
			input = ReInput.players.GetPlayer(0);
			frame = GetComponent<UIFrame>();
			eternalTrialsDefeat.Reset();
			eternalTrialsVictory.Reset();
			mainFrameParent.SetActive(value: false);
			preFrameParent.SetActive(value: true);
			preFrameMask.sizeDelta = new Vector2(preFrameMask.sizeDelta.x, 0f);
			preFrameCG.alpha = 0f;
			if (LocalGamestate.Instance.CurrentState == LocalGamestate.State.AfterMatchVictory)
			{
				preFrameVictory.SetActive(value: true);
				preFrameDefeat.SetActive(value: false);
				audioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.Victory);
			}
			else
			{
				preFrameVictory.SetActive(value: false);
				preFrameDefeat.SetActive(value: true);
				audioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.Defeat);
			}
			StartCoroutine(ActivateAnimation());
		}
	}

	public void OnContinue()
	{
		SceneTransitionManager.instance.TransitionFromEndScreenToLevelSelect();
	}

	public void OnTryAgain()
	{
		SceneTransitionManager.instance.RestartCurrentLevel();
	}

	public void OnTryAgainET()
	{
		EternalTrialsRunManager.CreateFreshRun();
		UIFrameManager.OpenEternalTrialsLoadoutPick();
	}

	public void OnContinueET()
	{
		UIFrameManager.OpenEternalTrialsLoadoutPick();
	}

	public void ToMenuET()
	{
		SceneTransitionManager.instance.TransitionFromEndScreenToLevelSelect();
	}

	private IEnumerator ActivateAnimation()
	{
		float preFrameTimer = 0f;
		while (preFrameTimer < preFrameAnimationTime)
		{
			preFrameTimer += Time.unscaledDeltaTime;
			float num = preFrameMaskACCurve.Evaluate(Mathf.InverseLerp(0f, preFrameAnimationTime, preFrameTimer));
			Vector2 sizeDelta = new Vector2(preFrameMask.sizeDelta.x, Mathf.Lerp(0f, preFrameMaskTargetHeight, num));
			preFrameMask.sizeDelta = sizeDelta;
			preFrameCG.alpha = num;
			yield return null;
		}
		preFrameMask.sizeDelta = new Vector2(preFrameMask.sizeDelta.x, preFrameMaskTargetHeight);
		preFrameCG.alpha = 1f;
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.Classic)
		{
			yield return StartCoroutine(ClassicModeAnimationSequence());
		}
		else if (LocalGamestate.Instance.CurrentState == LocalGamestate.State.AfterMatchVictory)
		{
			yield return StartCoroutine(eternalTrialsVictory.PlayAnimation(frame));
		}
		else
		{
			yield return StartCoroutine(eternalTrialsDefeat.PlayAnimation(frame));
		}
		inAnimation = false;
		yield return null;
	}

	private IEnumerator ClassicModeAnimationSequence()
	{
		victoryDisplay.text = TextTranslator.Translate("Menu/Victory") + ".";
		defeatDisplay.text = TextTranslator.Translate("Menu/Defeat") + ".";
		if (LocalGamestate.Instance.CurrentState == LocalGamestate.State.AfterMatchDefeat)
		{
			victoryParent.SetActive(value: false);
			defeatParent.SetActive(value: true);
		}
		else
		{
			victoryParent.SetActive(value: true);
			defeatParent.SetActive(value: false);
		}
		baseScore.gameObject.SetActive(value: false);
		baseScoreName.gameObject.SetActive(value: false);
		goldScore.gameObject.SetActive(value: false);
		goldBonusName.gameObject.SetActive(value: false);
		mutatorScore.gameObject.SetActive(value: false);
		noRetriesScore.gameObject.SetActive(value: false);
		noRetryBonusName.gameObject.SetActive(value: false);
		MutatorBonusName.gameObject.SetActive(value: false);
		dividerParent.SetActive(value: false);
		progressionBarORMaxLevelParent.SetActive(value: false);
		levelDisplay.gameObject.SetActive(value: false);
		newHighscoreIndicator.SetActive(value: false);
		victoryButtonsClassic.SetActive(value: false);
		defeatButtonsClassic.SetActive(value: false);
		victoryButtonsET.SetActive(value: false);
		defeatButtonsET.SetActive(value: false);
		demoMaxLevel.SetActive(value: false);
		regularMaxLevel.SetActive(value: false);
		progressionBarParent.SetActive(value: true);
		yield return new WaitForSecondsRealtime(preFrameWaittime);
		mainFrameCG.alpha = 0f;
		mainFrameParent.SetActive(value: true);
		float mainFrameFadeTimer = 0f;
		float fadeTime = 0.25f;
		while (mainFrameFadeTimer < fadeTime)
		{
			mainFrameFadeTimer += Time.unscaledDeltaTime;
			mainFrameCG.alpha = mainFrameFadeTimer / fadeTime;
			yield return null;
		}
		mainFrameCG.alpha = 1f;
		preFrameParent.SetActive(value: false);
		Time.timeScale = 0f;
		currentScoringAnimation = StartCoroutine(UnrollScores());
		while (currentScoringAnimation != null)
		{
			yield return null;
		}
		if (skipScoringAnimation)
		{
			SkipUnrollScores();
		}
		if (SceneTransitionManager.instance.TotalScoreFromLastMatchIsNewPersonalRecord)
		{
			newHighscoreIndicator.SetActive(value: true);
			yield return StartCoroutine(PopShowTransform(newHighscoreIndicator.transform, ThronefallAudioManager.Instance.audioContent.NewHighscore, popShowCurve, 0.5f));
			yield return new WaitForSecondsRealtime(minorWaitStep);
		}
		else
		{
			newHighscoreIndicator.SetActive(value: false);
		}
		if (LocalGamestate.Instance.CurrentState == LocalGamestate.State.AfterMatchVictory)
		{
			yield return StartCoroutine(ShowCampaignLevelBeatenRewards());
		}
		int xpToGive = SceneTransitionManager.instance.TotalScoreFromLastMatch;
		if (MatchSaveLoadHandler.CurrentSave != null)
		{
			xpToGive -= MatchSaveLoadHandler.CurrentSave.highestScoreThisRun;
			if (xpToGive < 0)
			{
				xpToGive = 0;
			}
		}
		MatchSaveLoadHandler.SubmitScoreAndSave(SceneTransitionManager.instance.TotalScoreFromLastMatch);
		GetNextMetaLevel();
		if (nextMetaLevel != null)
		{
			nextUnlockIcon.sprite = nextMetaLevel.reward.icon;
			nextunlockBG.color = GetColorForEquippable(nextMetaLevel.reward);
			UpdateLevelingBar();
		}
		levelDisplay.text = TextTranslator.Translate("Menu/Level") + " <style=\"Body Numerals\">" + perkManager.level;
		levelDisplay.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(levelDisplay.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		progressionBarORMaxLevelParent.SetActive(value: true);
		StartCoroutine(PopShowTransform(progressionBarORMaxLevelParent.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(defaultWaitStep);
		inAnimation = true;
		if (nextMetaLevel != null)
		{
			UpdateLevelingBar();
			yield return StartCoroutine(FillUpXPBar(xpToGive));
		}
		else
		{
			yield return new WaitForSecondsRealtime(waitWhenMaxLevelAlreadyReached);
		}
		inAnimation = false;
		LevelProgressManager.instance.GetLevelDataForScene(SceneTransitionManager.instance.ComingFromGameplayScene).SaveScoreAndStatsToBestIfBest(_endOfMatch: true);
		SteamManager.Instance.UploadHighscore(SceneTransitionManager.instance.TotalScoreFromLastMatch, SceneTransitionManager.instance.ComingFromGameplayScene);
		SaveLoadManager.instance.SaveGame();
		if (LocalGamestate.Instance.CurrentState == LocalGamestate.State.AfterMatchDefeat)
		{
			if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.Classic)
			{
				defeatButtonsClassic.SetActive(value: true);
				frame.Select(defeatClassicSelectedButton);
			}
			else
			{
				defeatButtonsET.SetActive(value: true);
				frame.Select(defeatETSelectedButton);
			}
		}
		else if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.Classic)
		{
			victoryButtonsClassic.SetActive(value: true);
			frame.Select(victoryClassicSelectedButton);
		}
		else
		{
			victoryButtonsET.SetActive(value: true);
			frame.Select(victoryETSelectedButton);
		}
	}

	private IEnumerator ShowCampaignLevelBeatenRewards()
	{
		LevelInfo currentLevelInfo = LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName();
		LevelData currentLevelData = LevelProgressManager.instance.GetLevelDataForActiveScene();
		foreach (Equippable e in PerkManager.instance.allEquippables)
		{
			if (e is EquippableBuildingUpgrade)
			{
				continue;
			}
			bool flag = e.unlockRequirement == Equippable.UnlockRequirement.CampaignProgress && e.requiredBeatenLevel.ToString() == currentLevelInfo.displayName && !currentLevelInfo.useSubtitle;
			if (currentLevelData.beatenBest)
			{
				flag = false;
			}
			if (flag)
			{
				audioSource.Stop();
				rewardAcceptButton.gameObject.SetActive(value: false);
				rewardWaitIndicator.SetActive(value: true);
				audioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.LevelUp);
				StartCoroutine(Bump(0.5f, victoryDisplay.transform, null));
				yield return new WaitForSecondsRealtime(0.5f);
				EnableRewardDisplayUI(e);
				float timer = 0f;
				while (timer < waitAfterReward && (timer == 0f || !input.GetButtonDown("Interact")))
				{
					timer += Time.unscaledDeltaTime;
					rewardWaitFill.fillAmount = timer / waitAfterReward;
					yield return null;
				}
				rewardAcceptButton.gameObject.SetActive(value: true);
				rewardWaitIndicator.SetActive(value: false);
				rewardFrame.Select(rewardAcceptButton);
				while (!frame.Interactable)
				{
					yield return null;
				}
				Time.timeScale = 0f;
			}
		}
	}

	private void GetNextMetaLevel()
	{
		nextMetaLevel = perkManager.NextMetaLevel;
		if (nextMetaLevel == null)
		{
			EnableMaxLevelReachedUI();
		}
	}

	private void EnableMaxLevelReachedUI()
	{
		progressionBarParent.SetActive(value: false);
		regularMaxLevel.SetActive(value: true);
		AchievementManager.UnlockAchievement(AchievementManager.Achievements.MAXLEVEL_REACHED);
	}

	private void EnableDemoLockedUI()
	{
		progressionBarParent.SetActive(value: false);
		demoMaxLevel.SetActive(value: true);
	}

	private void EnableRewardDisplayUI(Equippable e)
	{
		levelUpLevelDisplay.text = "NEW PERK";
		if (e is EquippableWeapon)
		{
			levelUpLevelDisplay.text = "NEW WEAPON";
		}
		else if (e is EquippableMutation)
		{
			levelUpLevelDisplay.text = "NEW MUTATOR";
		}
		else if (e is EquippableBuildingUpgrade)
		{
			levelUpLevelDisplay.text = "NEW UPGRADE";
		}
		levelUpRewardIcon.sprite = e.icon;
		levelUpRewardBg.color = GetColorForEquippable(e);
		levelUpRewardDescription.text = "<style=\"Header\"><size=35>" + TextTranslator.Translate(e.LOCIDENTIFIER_NAME) + "</style><style=\"Body Light\"><size=25>\n" + TextTranslator.Translate(e.LOCIDENTIFIER_DESCRIPTION);
		UIFrameManager.ShowLevelUpReward();
	}

	private void UpdateLevelingBar()
	{
		xpDisplay.text = perkManager.xp + " / " + nextMetaLevel.requiredXp;
		xpFill.fillAmount = (float)perkManager.xp / (float)nextMetaLevel.requiredXp;
	}

	private IEnumerator UnrollScores()
	{
		inScoreUnroll = true;
		baseScoreThisRound = SceneTransitionManager.instance.IngameScoreFromLastMatch;
		goldScoreThisRound = SceneTransitionManager.instance.GoldBonusScoreFromLastMatch;
		mutatorScoreThisRound = SceneTransitionManager.instance.MutatorBonusScoreFromLastMatch;
		noRetryScoreThisRound = SceneTransitionManager.instance.NoRetryBonusScoreFromLastMatch;
		overallScoreThisRound = 0;
		animationNextScore = 0;
		baseScore.text = baseScoreThisRound.ToString();
		goldScore.text = goldScoreThisRound.ToString();
		mutatorScore.text = mutatorScoreThisRound.ToString();
		noRetriesScore.text = noRetryScoreThisRound.ToString();
		overallScore.text = overallScoreThisRound.ToString();
		bestScore.text = SceneTransitionManager.instance.LevelDataFromLastMatch.highscoreBest.ToString();
		dividerParent.SetActive(value: true);
		StartCoroutine(PopShowTransform(dividerParent.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, popShowCurve, animationStepB));
		baseScoreName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(baseScoreName.transform, null, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		baseScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(baseScore.transform, null, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(baseScoreThisRound, animationStepA);
		goldBonusName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(goldBonusName.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		goldScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(goldScore.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildA, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(goldScoreThisRound, animationStepA);
		MutatorBonusName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(MutatorBonusName.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		mutatorScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(mutatorScore.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildA, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(mutatorScoreThisRound, animationStepA);
		noRetryBonusName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(noRetryBonusName.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		noRetriesScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(noRetriesScore.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildA, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(noRetryScoreThisRound, animationStepA);
		currentScoringAnimation = null;
	}

	private void SkipUnrollScores()
	{
		baseScoreThisRound = SceneTransitionManager.instance.IngameScoreFromLastMatch;
		goldScoreThisRound = SceneTransitionManager.instance.GoldBonusScoreFromLastMatch;
		mutatorScoreThisRound = SceneTransitionManager.instance.MutatorBonusScoreFromLastMatch;
		noRetryScoreThisRound = SceneTransitionManager.instance.NoRetryBonusScoreFromLastMatch;
		overallScoreThisRound = SceneTransitionManager.instance.TotalScoreFromLastMatch;
		baseScore.text = baseScoreThisRound.ToString();
		goldScore.text = goldScoreThisRound.ToString();
		mutatorScore.text = mutatorScoreThisRound.ToString();
		noRetriesScore.text = noRetryScoreThisRound.ToString();
		overallScore.text = overallScoreThisRound.ToString();
		newHighscoreIndicator.SetActive(SceneTransitionManager.instance.TotalScoreFromLastMatchIsNewPersonalRecord);
		bestScore.text = SceneTransitionManager.instance.LevelDataFromLastMatch.highscoreBest.ToString();
		dividerParent.SetActive(value: true);
		baseScoreName.gameObject.SetActive(value: true);
		baseScore.gameObject.SetActive(value: true);
		goldBonusName.gameObject.SetActive(value: true);
		goldScore.gameObject.SetActive(value: true);
		MutatorBonusName.gameObject.SetActive(value: true);
		mutatorScore.gameObject.SetActive(value: true);
		noRetryBonusName.gameObject.SetActive(value: true);
		noRetriesScore.gameObject.SetActive(value: true);
		dividerParent.transform.localScale = Vector3.one;
		baseScoreName.transform.localScale = Vector3.one;
		baseScore.transform.localScale = Vector3.one;
		goldBonusName.transform.localScale = Vector3.one;
		goldScore.transform.localScale = Vector3.one;
		MutatorBonusName.transform.localScale = Vector3.one;
		mutatorScore.transform.localScale = Vector3.one;
		noRetriesScore.transform.localScale = Vector3.one;
		noRetryBonusName.transform.localScale = Vector3.one;
		overallScore.transform.localScale = Vector3.one;
		StartCoroutine(LockInScoreBump(0.5f));
	}

	private IEnumerator AddToOverallScore(int scoreToAdd, float animTime)
	{
		if (scoreToAdd == 0)
		{
			yield return new WaitForSecondsRealtime(0.15f);
			yield break;
		}
		audioSource.clip = ThronefallAudioManager.Instance.audioContent.PointFill;
		audioSource.loop = true;
		audioSource.Play();
		animationNextScore += scoreToAdd;
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			overallScore.text = Mathf.RoundToInt(Mathf.Lerp(overallScoreThisRound, animationNextScore, Mathf.InverseLerp(0f, animTime, timer))).ToString();
			yield return null;
		}
		overallScoreThisRound = animationNextScore;
		overallScore.text = overallScoreThisRound.ToString();
		audioSource.Stop();
		audioSource.loop = false;
		yield return StartCoroutine(LockInScoreBump(0.5f));
	}

	private IEnumerator LockInScoreBump(float animTime)
	{
		audioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointLockInMajor, 0.85f);
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			overallScore.transform.localScale = Vector3.one * bumpCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		overallScore.transform.localScale = Vector3.one;
	}

	private IEnumerator Bump(float animTime, Transform target, AudioClip clip)
	{
		if ((bool)clip)
		{
			audioSource.PlayOneShot(clip);
		}
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			target.transform.localScale = Vector3.one * bumpCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		target.transform.localScale = Vector3.one;
	}

	private IEnumerator PopShowTransform(Transform target, AudioClip clip, AnimationCurve curve, float animTime)
	{
		if ((bool)clip)
		{
			audioSource.PlayOneShot(clip);
		}
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			target.localScale = Vector3.one * curve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		target.localScale = Vector3.one;
	}

	private IEnumerator FillUpXPBar(int xp)
	{
		int xpToGive = xp;
		float xpFillSpeed = (float)nextMetaLevel.requiredXp / timeToFillUpABar;
		_ = perkManager.xp;
		float xpFillFloat = perkManager.xp;
		audioSource.clip = ThronefallAudioManager.Instance.audioContent.PointFill;
		audioSource.loop = true;
		audioSource.Play();
		float progressionBarWiggleTime = 0f;
		while (xpToGive > 0 && nextMetaLevel != null)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
			progressionBarWiggleTime += Time.unscaledDeltaTime * 10f;
			progressionBarOnly.transform.localScale = Vector3.one * scoreFillWiggle.Evaluate(progressionBarWiggleTime);
			int num = nextMetaLevel.requiredXp - perkManager.xp;
			int num2;
			if (input.GetButtonDown("Interact") || nextMetaLevel == null)
			{
				num2 = xpToGive;
			}
			else
			{
				xpFillFloat += xpFillSpeed * Time.unscaledDeltaTime;
				num2 = Mathf.RoundToInt(xpFillFloat) - perkManager.xp;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			perkManager.xp += num2;
			xpToGive -= num2;
			UpdateLevelingBar();
			if (nextMetaLevel != null && perkManager.xp >= nextMetaLevel.requiredXp)
			{
				audioSource.Stop();
				rewardAcceptButton.gameObject.SetActive(value: false);
				rewardWaitIndicator.SetActive(value: true);
				audioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.LevelUp);
				StartCoroutine(Bump(0.5f, nextPerk.transform, null));
				yield return new WaitForSecondsRealtime(0.5f);
				EnableRewardDisplayUI(nextMetaLevel.reward);
				perkManager.xp = 0;
				xpFillFloat = 0f;
				perkManager.level++;
				GetNextMetaLevel();
				float timer = 0f;
				while (timer < waitAfterReward && (timer == 0f || !input.GetButtonDown("Interact")))
				{
					timer += Time.unscaledDeltaTime;
					rewardWaitFill.fillAmount = timer / waitAfterReward;
					yield return null;
				}
				rewardAcceptButton.gameObject.SetActive(value: true);
				rewardWaitIndicator.SetActive(value: false);
				rewardFrame.Select(rewardAcceptButton);
				while (!frame.Interactable)
				{
					yield return null;
				}
				if (nextMetaLevel != null)
				{
					xpFillSpeed = (float)nextMetaLevel.requiredXp / timeToFillUpABar;
					levelDisplay.text = TextTranslator.Translate("Menu/Level") + " <style=\"Body Numerals\">" + perkManager.level;
					nextUnlockIcon.sprite = nextMetaLevel.reward.icon;
					nextunlockBG.color = GetColorForEquippable(nextMetaLevel.reward);
				}
				Time.timeScale = 0f;
			}
			yield return null;
		}
		progressionBarOnly.transform.localScale = Vector3.one;
		audioSource.Stop();
		audioSource.loop = false;
		StartCoroutine(Bump(animationStepB, progressionBarParent.transform, ThronefallAudioManager.Instance.audioContent.PointLockInMinor));
		yield return new WaitForSecondsRealtime(minorWaitStep);
	}

	private Color GetColorForEquippable(Equippable e)
	{
		Color result = Color.white;
		if (e is EquippableWeapon)
		{
			result = weaponBG;
		}
		if (e is EquippablePerk)
		{
			result = ((!(e.displayName == "Trophy")) ? perkBG : trophyBG);
		}
		if (e is PerkPoint)
		{
			result = perkpointBG;
		}
		if (e is EquippableMutation)
		{
			result = mutatorBG;
		}
		if (e is EquippableBuildingUpgrade)
		{
			result = buildingUpgradeBG;
		}
		return result;
	}

	private void OnDisable()
	{
		inAnimation = false;
	}
}
