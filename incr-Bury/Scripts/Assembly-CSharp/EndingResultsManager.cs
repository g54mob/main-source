using System.Collections;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingResultsManager : MonoBehaviour
{
	public static EndingResultsManager Singleton;

	[Header("UI")]
	[SerializeField]
	private GameObject[] allTexts;

	[SerializeField]
	private TMP_Text text_EndingHeader;

	[SerializeField]
	private TMP_Text text_RoundsPlayed;

	[SerializeField]
	private TMP_Text text_MoneyEarned;

	[SerializeField]
	private TMP_Text text_MoneyDropped;

	[SerializeField]
	private TMP_Text text_StarsEarned;

	[SerializeField]
	private TMP_Text text_BerriesGrown;

	[SerializeField]
	private TMP_Text text_PlayTime;

	[SerializeField]
	private TMP_Text text_EndingsFound;

	[Header("Skipping")]
	[SerializeField]
	private Image ui_skipFillImage;

	private float skipTimer_Curr;

	private float skipTimer_FillSpeed = 0.55f;

	private bool hasStartedSceneLoad;

	[Header("Audio")]
	[SerializeField]
	private AudioSource sfx_AudioSource;

	[SerializeField]
	private AudioClip sfx_TextRevealBloop;

	private int queueIndex = -1;

	private float queue_Timer = 0.4f;

	private float queue_Timer_Curr;

	private bool queueIsActive = true;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player[] textFeedbacks;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		AudioManager.Singleton.StopAmbientMusic();
		queue_Timer_Curr = queue_Timer;
		UpdateTextLabels();
		HideAllTexts();
		AchievementChecks();
		if (MenuToGameBridger.Singleton.comingBackToMainMenuFromTrueEnding)
		{
			SaveLoadManager.SaveGlobalSaveData(_ngPlusUnlocked: true);
		}
	}

	private void Update()
	{
		HandleQueue();
		if (Input.anyKey)
		{
			if (skipTimer_Curr < 1f)
			{
				skipTimer_Curr += Time.deltaTime;
			}
		}
		else
		{
			if (skipTimer_Curr >= 1f && !hasStartedSceneLoad)
			{
				SceneManager.LoadScene("MainMenu");
				hasStartedSceneLoad = true;
			}
			skipTimer_Curr -= Time.deltaTime * 2f;
		}
		skipTimer_Curr = Mathf.Clamp(skipTimer_Curr, 0f, 1f);
		UpdateSkipUI();
	}

	private void UpdateSkipUI()
	{
		ui_skipFillImage.fillAmount = skipTimer_Curr;
	}

	public void UpdateTextLabels()
	{
		string result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_Ending", null, FallbackBehavior.UseProjectSettings).Result;
		text_EndingHeader.text = result + " " + MenuToGameBridger.Singleton.endingCompletedString;
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_Rounds", null, FallbackBehavior.UseProjectSettings).Result;
		text_RoundsPlayed.text = result + " " + FormatHelper.FormatNumberWithCommmas(MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_TotalRounds).ToString();
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_MoneyEarned", null, FallbackBehavior.UseProjectSettings).Result;
		text_MoneyEarned.text = result + " $" + FormatHelper.FormatNumberWithCommmas(MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_totalMoney_Earned).ToString();
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_MoneyDropped", null, FallbackBehavior.UseProjectSettings).Result;
		text_MoneyDropped.text = result + " $" + FormatHelper.FormatNumberWithCommmas(MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_totalMoney_Dropped).ToString();
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_StarsEarned", null, FallbackBehavior.UseProjectSettings).Result;
		text_StarsEarned.text = result + " " + FormatHelper.FormatNumberWithCommmas(MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_totalStarOrbs_Earned).ToString();
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_BerriesGrown", null, FallbackBehavior.UseProjectSettings).Result;
		text_BerriesGrown.text = result + " " + FormatHelper.FormatNumberWithCommmas(MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_TotalGrown_TotalBerries).ToString();
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_PlayTime", null, FallbackBehavior.UseProjectSettings).Result;
		text_PlayTime.text = result + " " + FormatHelper.FormatTimeSmartWithMs(MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_totalTimePlayed).ToString();
		int num = 0;
		if (MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_ending_Happiness)
		{
			num++;
		}
		if (MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_ending_Chainsaw)
		{
			num++;
		}
		if (MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_ending_BelladonnaBuddy)
		{
			num++;
		}
		if (MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_ending_Gnome)
		{
			num++;
		}
		result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("ResultsLabel_EndingsFound", null, FallbackBehavior.UseProjectSettings).Result;
		text_EndingsFound.text = result + " " + num + "/4";
	}

	private void HideAllTexts()
	{
		GameObject[] array = allTexts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	private void HandleQueue()
	{
		if (queueIsActive)
		{
			if (queue_Timer_Curr > 0f)
			{
				queue_Timer_Curr -= Time.deltaTime;
			}
			else if (queueIndex + 1 < allTexts.Length)
			{
				queueIndex++;
				allTexts[queueIndex].SetActive(value: true);
				textFeedbacks[queueIndex]?.PlayFeedbacks();
				sfx_AudioSource.pitch = Random.Range(0.9f, 1.05f);
				sfx_AudioSource.PlayOneShot(sfx_TextRevealBloop, AudioManager.Singleton.sfxVolume * 0.6f);
				queue_Timer_Curr = queue_Timer;
			}
			else
			{
				queueIsActive = false;
			}
		}
	}

	private void AchievementChecks()
	{
		if (MenuToGameBridger.Singleton.comingBackToMainMenuFromPigEnding && !AchievementHelper.IsAchievementUnlocked("ACH_Ending_Key"))
		{
			AchievementHelper.UnlockAchievement("ACH_Ending_Key");
		}
		if (MenuToGameBridger.Singleton.comingBackToMainMenuFromTrueEnding && !AchievementHelper.IsAchievementUnlocked("ACH_Ending_True"))
		{
			AchievementHelper.UnlockAchievement("ACH_Ending_True");
		}
		if (MenuToGameBridger.Singleton.comingBackToMainMenuFromBelladonnaEnding && !AchievementHelper.IsAchievementUnlocked("ACH_Ending_Belladonna"))
		{
			AchievementHelper.UnlockAchievement("ACH_Ending_Belladonna");
		}
		if (MenuToGameBridger.Singleton.comingBackToMainMenuFromGnomeEnding && !AchievementHelper.IsAchievementUnlocked("ACH_Ending_Gnome"))
		{
			AchievementHelper.UnlockAchievement("ACH_Ending_Gnome");
		}
		if (MenuToGameBridger.Singleton.duplicated_PlayerData_ForEndResultScreen.saved_totalTimePlayed < 3600f && !AchievementHelper.IsAchievementUnlocked("ACH_Speedrun_AnyEnding"))
		{
			AchievementHelper.UnlockAchievement("ACH_Speedrun_AnyEnding");
		}
		StartCoroutine(WaitASec_ThenCheckFor100PercentAchievement());
	}

	private IEnumerator WaitASec_ThenCheckFor100PercentAchievement()
	{
		yield return new WaitForSeconds(1f);
		MenuToGameBridger.Singleton.HundoPercentCompletionAchievementCheck();
	}
}
