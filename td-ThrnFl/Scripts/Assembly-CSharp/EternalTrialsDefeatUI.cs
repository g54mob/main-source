using System.Collections;
using MPUIKIT;
using Rewired;
using TMPro;
using UnityEngine;

public class EternalTrialsDefeatUI : IUIAnimationSequence
{
	public GameObject parentObject;

	public CanvasGroup mainFrameCG;

	public UIFrame frame;

	public ThronefallUIElement continueButton;

	public AudioSource audioSource;

	public TextMeshProUGUI stageDisplay;

	[Header("Main Frame")]
	public TextMeshProUGUI baseScore;

	public TextMeshProUGUI stageBonus;

	public TextMeshProUGUI overallScore;

	public TextMeshProUGUI bestScore;

	public TextMeshProUGUI levelDisplay;

	public TextMeshProUGUI xpDisplay;

	public TextMeshProUGUI levelUpLevelDisplay;

	public TextMeshProUGUI levelUpRewardDescription;

	public TextMeshProUGUI defeatDisplay;

	public TextMeshProUGUI baseScoreName;

	public TextMeshProUGUI stageBonusName;

	public GameObject newHighscoreIndicator;

	public GameObject progressionBarParent;

	public GameObject regularMaxLevel;

	public GameObject rewardWaitIndicator;

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

	public ThronefallUIElement rewardAcceptButton;

	public UIFrame rewardFrame;

	public AnimationCurve popShowCurve;

	public AnimationCurve bumpCurve;

	public AnimationCurve scoreFillWiggle;

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

	private bool inAnimation;

	private bool inScoreUnroll;

	private int baseScoreThisRound;

	private int stageBonusThisRound;

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
		if (input != null && input.GetButtonDown("Interact") && inScoreUnroll)
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

	public override IEnumerator PlayAnimation(UIFrame contextFrame)
	{
		inAnimation = true;
		inScoreUnroll = false;
		skipScoringAnimation = false;
		perkManager = PerkManager.instance;
		input = ReInput.players.GetPlayer(0);
		parentObject.SetActive(value: true);
		yield return StartCoroutine(ETDefeatAnimationSequence());
		contextFrame.Select(continueButton);
		yield return null;
	}

	public override void Reset()
	{
		parentObject.SetActive(value: false);
	}

	private IEnumerator ETDefeatAnimationSequence()
	{
		defeatDisplay.text = TextTranslator.Translate("Menu/Defeat") + ".";
		stageDisplay.text = "<style=Body Bold>" + TextTranslator.Translate("Menu/Stage") + "<style=Body Numerals> " + (EternalTrialsRunManager.CurrentRun.stage + 1);
		baseScore.gameObject.SetActive(value: false);
		baseScoreName.gameObject.SetActive(value: false);
		stageBonus.gameObject.SetActive(value: false);
		stageBonusName.gameObject.SetActive(value: false);
		dividerParent.SetActive(value: false);
		progressionBarORMaxLevelParent.SetActive(value: false);
		levelDisplay.gameObject.SetActive(value: false);
		newHighscoreIndicator.SetActive(value: false);
		regularMaxLevel.SetActive(value: false);
		progressionBarParent.SetActive(value: true);
		mainFrameCG.alpha = 0f;
		parentObject.SetActive(value: true);
		float mainFrameFadeTimer = 0f;
		float fadeTime = 0.25f;
		while (mainFrameFadeTimer < fadeTime)
		{
			mainFrameFadeTimer += Time.unscaledDeltaTime;
			mainFrameCG.alpha = mainFrameFadeTimer / fadeTime;
			yield return null;
		}
		mainFrameCG.alpha = 1f;
		Time.timeScale = 0f;
		int num = EternalTrialsRunManager.CurrentRun.score + EternalTrialsRunManager.CurrentRun.StageBonusScore;
		bool newHighscore = num > LevelProgressManager.instance.EternalTrialsHighscore;
		LevelProgressManager.instance.EternalTrialsHighscore = Mathf.Max(LevelProgressManager.instance.EternalTrialsHighscore, num);
		currentScoringAnimation = StartCoroutine(UnrollScores());
		while (currentScoringAnimation != null)
		{
			yield return null;
		}
		if (skipScoringAnimation)
		{
			SkipUnrollScores();
		}
		if (newHighscore)
		{
			newHighscoreIndicator.SetActive(value: true);
			yield return StartCoroutine(PopShowTransform(newHighscoreIndicator.transform, ThronefallAudioManager.Instance.audioContent.NewHighscore, popShowCurve, 0.5f));
			yield return new WaitForSecondsRealtime(minorWaitStep);
		}
		else
		{
			newHighscoreIndicator.SetActive(value: false);
		}
		int xpToGive = EternalTrialsRunManager.CurrentRun.score + EternalTrialsRunManager.CurrentRun.StageBonusScore;
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
		SteamManager.Instance.UploadHighscore(LevelProgressManager.instance.EternalTrialsHighscore, "Eternal Trials Season 4");
		SaveLoadManager.instance.SaveGame();
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

	private void EnableRewardDisplayUI(Equippable e)
	{
		levelUpLevelDisplay.text = "NEW PERK";
		if (e is EquippableWeapon)
		{
			levelDisplay.text = "NEW WEAPON";
		}
		else if (e is EquippableMutation)
		{
			levelDisplay.text = "NEW MUTATOR";
		}
		else if (e is EquippableBuildingUpgrade)
		{
			levelDisplay.text = "NEW UPGRADE";
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
		baseScoreThisRound = EternalTrialsRunManager.CurrentRun.score;
		stageBonusThisRound = EternalTrialsRunManager.CurrentRun.StageBonusScore;
		overallScoreThisRound = 0;
		animationNextScore = 0;
		baseScore.text = baseScoreThisRound.ToString();
		stageBonus.text = stageBonusThisRound.ToString();
		overallScore.text = overallScoreThisRound.ToString();
		bestScore.text = LevelProgressManager.instance.EternalTrialsHighscore.ToString();
		dividerParent.SetActive(value: true);
		StartCoroutine(PopShowTransform(dividerParent.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, popShowCurve, animationStepB));
		baseScoreName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(baseScoreName.transform, null, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		baseScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(baseScore.transform, null, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(baseScoreThisRound, animationStepA);
		stageBonusName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(stageBonusName.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		stageBonus.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(stageBonus.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildA, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(stageBonusThisRound, animationStepA);
		currentScoringAnimation = null;
	}

	private void SkipUnrollScores()
	{
		baseScoreThisRound = EternalTrialsRunManager.CurrentRun.score;
		stageBonusThisRound = EternalTrialsRunManager.CurrentRun.StageBonusScore;
		overallScoreThisRound = baseScoreThisRound + stageBonusThisRound;
		baseScore.text = baseScoreThisRound.ToString();
		stageBonus.text = stageBonusThisRound.ToString();
		overallScore.text = overallScoreThisRound.ToString();
		newHighscoreIndicator.SetActive(SceneTransitionManager.instance.TotalScoreFromLastMatchIsNewPersonalRecord);
		bestScore.text = SceneTransitionManager.instance.LevelDataFromLastMatch.highscoreBest.ToString();
		dividerParent.SetActive(value: true);
		baseScoreName.gameObject.SetActive(value: true);
		baseScore.gameObject.SetActive(value: true);
		stageBonusName.gameObject.SetActive(value: true);
		stageBonus.gameObject.SetActive(value: true);
		dividerParent.transform.localScale = Vector3.one;
		baseScoreName.transform.localScale = Vector3.one;
		baseScore.transform.localScale = Vector3.one;
		stageBonusName.transform.localScale = Vector3.one;
		stageBonus.transform.localScale = Vector3.one;
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
