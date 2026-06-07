using System.Collections;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AfterMatchUIManager : MonoBehaviour
{
	[Header("Score Screen")]
	[SerializeField]
	private GameObject scoreScreenUI;

	[SerializeField]
	private TMP_Text ingameHighscore;

	[SerializeField]
	private TMP_Text goldBonus;

	[SerializeField]
	private TMP_Text mutationBonus;

	[SerializeField]
	private TMP_Text totalScore;

	[SerializeField]
	private GameObject newPersonalBest;

	[Header("Graphs")]
	[SerializeField]
	private GameObject graphs;

	[SerializeField]
	private GraphDrawer graphDrawerA;

	[SerializeField]
	private GraphDrawer graphDrawerB;

	[Header("Leveling")]
	[SerializeField]
	private GameObject levelingProgressUI;

	[SerializeField]
	private TMP_Text currentLevelTxt1;

	[SerializeField]
	private RectTransform levelingBarBack;

	[SerializeField]
	private RectTransform levelingBarFront;

	[SerializeField]
	private TMP_Text xpDisplay;

	[SerializeField]
	private Image rewardPreview1;

	[Header("Rewards")]
	[SerializeField]
	private GameObject rewardDisplayUI;

	[SerializeField]
	private TMP_Text currentLevelTxt2;

	[SerializeField]
	private Image rewardPreview2;

	[SerializeField]
	private TMP_Text itemName;

	[SerializeField]
	private TMP_Text itemDescription;

	[Header("Max Level")]
	[SerializeField]
	private GameObject maxLevelReachedUI;

	[SerializeField]
	private GameObject demoLockedUI;

	[Header("Settings")]
	[SerializeField]
	private float timeToFillUpABar = 5f;

	[SerializeField]
	private float waitAtBeginning = 0.25f;

	[SerializeField]
	private float waitAfterFillingUpABar = 0.25f;

	[SerializeField]
	private float waitBeforeYouCanInteract = 0.25f;

	private PerkManager perkManager;

	private MetaLevel nextMetaLevel;

	private Player input;

	private void Start()
	{
		perkManager = PerkManager.instance;
		StartCoroutine(ShowRewards());
		input = ReInput.players.GetPlayer(0);
	}

	private IEnumerator ShowRewards()
	{
		EnableScoreUI();
		ingameHighscore.text = SceneTransitionManager.instance.IngameScoreFromLastMatch.ToString();
		goldBonus.text = "+" + SceneTransitionManager.instance.GoldBonusScoreFromLastMatch;
		mutationBonus.text = "+" + SceneTransitionManager.instance.MutatorBonusScoreFromLastMatch;
		totalScore.text = SceneTransitionManager.instance.TotalScoreFromLastMatch.ToString();
		newPersonalBest.SetActive(SceneTransitionManager.instance.TotalScoreFromLastMatchIsNewPersonalRecord);
		yield return new WaitForSeconds(waitAtBeginning);
		while (!input.GetButtonDown("Interact"))
		{
			yield return null;
		}
		int xpToGive = SceneTransitionManager.instance.TotalScoreFromLastMatch;
		yield return SelectNextMetaLevel();
		EnableLevelingProgressUI();
		currentLevelTxt1.text = "Level " + perkManager.level;
		rewardPreview1.sprite = nextMetaLevel.reward.icon;
		UpdateLevelingBar();
		yield return new WaitForSeconds(waitAtBeginning);
		float xPTrickleSpeed = (float)nextMetaLevel.requiredXp / timeToFillUpABar;
		float xpTrickle = 0f;
		while (xpToGive > 0)
		{
			xpTrickle += xPTrickleSpeed * Time.deltaTime;
			int num = (int)xpTrickle;
			xpTrickle -= (float)num;
			xpToGive -= num;
			if (xpToGive < 0)
			{
				num -= xpToGive;
			}
			perkManager.xp += num;
			UpdateLevelingBar();
			if (perkManager.xp >= nextMetaLevel.requiredXp)
			{
				yield return new WaitForSeconds(waitAfterFillingUpABar);
				EnableRewardDisplayUI();
				currentLevelTxt2.text = "Level " + (1 + perkManager.level);
				rewardPreview2.sprite = nextMetaLevel.reward.icon;
				itemName.text = nextMetaLevel.reward.displayName;
				itemDescription.text = nextMetaLevel.reward.description;
				yield return new WaitForSeconds(waitBeforeYouCanInteract);
				while (!input.GetButtonDown("Interact"))
				{
					yield return null;
				}
				perkManager.xp -= nextMetaLevel.requiredXp;
				perkManager.level++;
				yield return SelectNextMetaLevel();
				xPTrickleSpeed = (float)nextMetaLevel.requiredXp / timeToFillUpABar;
				currentLevelTxt1.text = "Level " + perkManager.level;
				rewardPreview1.sprite = nextMetaLevel.reward.icon;
				EnableLevelingProgressUI();
			}
			yield return null;
		}
		yield return null;
		while (!input.GetButtonDown("Interact"))
		{
			yield return null;
		}
		LevelProgressManager.instance.GetLevelDataForScene(SceneTransitionManager.instance.ComingFromGameplayScene).SaveScoreAndStatsToBestIfBest(_endOfMatch: true);
		SteamManager.Instance.UploadHighscore(SceneTransitionManager.instance.TotalScoreFromLastMatch, SceneTransitionManager.instance.ComingFromGameplayScene);
		SaveLoadManager.instance.SaveGame();
		SceneTransitionManager.instance.TransitionFromEndScreenToLevelSelect();
	}

	private IEnumerator SelectNextMetaLevel()
	{
		nextMetaLevel = perkManager.NextMetaLevel;
		if (nextMetaLevel == null)
		{
			EnableMaxLevelReachedUI();
			yield return new WaitForSeconds(waitBeforeYouCanInteract);
			while (!input.GetButtonDown("Interact"))
			{
				yield return null;
			}
			SceneTransitionManager.instance.TransitionFromEndScreenToLevelSelect();
			StopAllCoroutines();
			yield return null;
		}
	}

	private void DisableAllUI()
	{
		levelingProgressUI.SetActive(value: false);
		rewardDisplayUI.SetActive(value: false);
		maxLevelReachedUI.SetActive(value: false);
		graphs.SetActive(value: false);
		scoreScreenUI.SetActive(value: false);
		demoLockedUI.SetActive(value: false);
	}

	private void EnableLevelingProgressUI()
	{
		DisableAllUI();
		levelingProgressUI.SetActive(value: true);
	}

	private void EnableRewardDisplayUI()
	{
		DisableAllUI();
		rewardDisplayUI.SetActive(value: true);
	}

	private void EnableMaxLevelReachedUI()
	{
		DisableAllUI();
		maxLevelReachedUI.SetActive(value: true);
	}

	private void EnableDemoLockedUI()
	{
		DisableAllUI();
		demoLockedUI.SetActive(value: true);
	}

	private void EnableGraphsUI()
	{
		DisableAllUI();
		graphs.SetActive(value: false);
	}

	private void EnableScoreUI()
	{
		DisableAllUI();
		scoreScreenUI.SetActive(value: true);
	}

	private void UpdateLevelingBar()
	{
		xpDisplay.text = perkManager.xp + " / " + nextMetaLevel.requiredXp;
		SetLevelingParPercentage((float)perkManager.xp / (float)nextMetaLevel.requiredXp);
	}

	private void SetLevelingParPercentage(float _percentage)
	{
		float width = levelingBarBack.rect.width;
		float num = width * _percentage;
		levelingBarFront.localScale = new Vector3(_percentage, 1f, 1f);
		levelingBarFront.localPosition = new Vector3(num / 2f - width / 2f, 0f, 0f);
	}
}
