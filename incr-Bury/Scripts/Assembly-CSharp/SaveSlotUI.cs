using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class SaveSlotUI : MonoBehaviour
{
	[SerializeField]
	private int slot;

	[Header("UI Groups")]
	[SerializeField]
	private GameObject uiGroup_NewGame;

	[SerializeField]
	private GameObject uiGroup_SavedData;

	[Header("UI")]
	[SerializeField]
	private TMP_Text text_LastPlayedDate;

	[SerializeField]
	private TMP_Text text_PlayTime;

	[SerializeField]
	private TMP_Text text_RoundTotal;

	[SerializeField]
	private TMP_Text text_UpgradesUnlocked;

	[SerializeField]
	private TMP_Text text_SaveFileHeader;

	[Header("Ending Stickers")]
	[SerializeField]
	private GameObject endingSticker_Happiness;

	[SerializeField]
	private GameObject endingSticker_Chainsaw;

	[SerializeField]
	private GameObject endingSticker_BelladonnaBuddy;

	[SerializeField]
	private GameObject endingSticker_Gnome;

	public bool ngMod_NoWalls;

	public bool ngMod_GrowthBoost;

	public bool ngMod_InfiniteHoleMove;

	public bool ngMod_FastAbilityCooldowns;

	public bool ngMod_FromStartTrampoline;

	public bool ngMod_FromStartStarPopper;

	public bool ngMod_FromStartAbilities;

	public bool ngMod_FromStartAutoCoinPickUp;

	public bool ngMod_FromStartHammerAndChainsaw;

	public bool ngMod_InfiniteDaytime;

	public bool ngMod_CutSceneSkip;

	public bool hasSavedDataPresent;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UpdateSlotUI()
	{
		string text = LoadInfoFromSlot();
		if (text == null)
		{
			hasSavedDataPresent = false;
			ShowUiGroup(0);
			endingSticker_Happiness.SetActive(value: false);
			endingSticker_Chainsaw.SetActive(value: false);
			endingSticker_Gnome.SetActive(value: false);
			endingSticker_BelladonnaBuddy.SetActive(value: false);
			text_SaveFileHeader.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SaveSlotInfo_Header", null, FallbackBehavior.UseProjectSettings).Result + " " + slot;
			return;
		}
		hasSavedDataPresent = true;
		ShowUiGroup(1);
		SaveLoadManager.SaveSlotInfo saveSlotInfo = JsonUtility.FromJson<SaveLoadManager.SaveSlotInfo>(text);
		text_SaveFileHeader.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SaveSlotInfo_Header", null, FallbackBehavior.UseProjectSettings).Result + " " + slot;
		text_LastPlayedDate.text = saveSlotInfo.lastPlayedDateTime;
		string result = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SaveSlotInfo_PlayTime", null, FallbackBehavior.UseProjectSettings).Result;
		string result2 = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SaveSlotInfo_Day", null, FallbackBehavior.UseProjectSettings).Result;
		string result3 = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SaveSlotInfo_Upgrades", null, FallbackBehavior.UseProjectSettings).Result;
		text_PlayTime.text = result + saveSlotInfo.playtime;
		text_RoundTotal.text = result2 + saveSlotInfo.roundNumber;
		text_UpgradesUnlocked.text = result3 + saveSlotInfo.upgrades_Unlocked + "/" + saveSlotInfo.upgrades_Total;
		try
		{
			endingSticker_Happiness.SetActive(saveSlotInfo.ending_Happiness);
			endingSticker_Chainsaw.SetActive(saveSlotInfo.ending_Chainsaw);
			endingSticker_Gnome.SetActive(saveSlotInfo.ending_Gnome);
			endingSticker_BelladonnaBuddy.SetActive(saveSlotInfo.ending_BelladonnaBuddy);
		}
		catch
		{
			Debug.Log("Failed To Find Ending Data in save game info, potentially from a previous version. Ignoring! Next save should resolve this!");
			endingSticker_Happiness.SetActive(value: false);
			endingSticker_Chainsaw.SetActive(value: false);
			endingSticker_BelladonnaBuddy.SetActive(value: false);
			endingSticker_Gnome.SetActive(value: false);
		}
		try
		{
			ngMod_NoWalls = saveSlotInfo.ngMod_NoWalls;
			ngMod_GrowthBoost = saveSlotInfo.ngMod_GrowthBoost;
			ngMod_InfiniteHoleMove = saveSlotInfo.ngMod_InfiniteHoleMove;
			ngMod_FastAbilityCooldowns = saveSlotInfo.ngMod_FastAbilityCooldowns;
			ngMod_FromStartTrampoline = saveSlotInfo.ngMod_FromStartTrampoline;
			ngMod_FromStartStarPopper = saveSlotInfo.ngMod_FromStartStarPopper;
			ngMod_FromStartAbilities = saveSlotInfo.ngMod_FromStartAbilities;
			ngMod_FromStartAutoCoinPickUp = saveSlotInfo.ngMod_FromStartAutoCoinPickUp;
			ngMod_FromStartHammerAndChainsaw = saveSlotInfo.ngMod_FromStartHammerAndChainsaw;
			ngMod_InfiniteDaytime = saveSlotInfo.ngMod_InfiniteDaytime;
			ngMod_CutSceneSkip = saveSlotInfo.ngMod_CutSceneSkip;
		}
		catch
		{
			Debug.Log("failed to load NG+ modifiers for this slot");
		}
		if ((ngMod_CutSceneSkip || ngMod_FastAbilityCooldowns || ngMod_FromStartAbilities || ngMod_FromStartAutoCoinPickUp || ngMod_FromStartHammerAndChainsaw || ngMod_FromStartStarPopper || ngMod_FromStartTrampoline || ngMod_GrowthBoost || ngMod_InfiniteDaytime || ngMod_InfiniteHoleMove || ngMod_NoWalls) && !string.IsNullOrEmpty(text_SaveFileHeader.text))
		{
			string text2 = text_SaveFileHeader.text;
			if (text2[text2.Length - 1] != '+')
			{
				text_SaveFileHeader.text += "+";
			}
		}
	}

	public string LoadInfoFromSlot()
	{
		string path = Path.Combine(Application.persistentDataPath, "Demo", $"slot_{slot}_Info.json");
		if (!File.Exists(path))
		{
			return null;
		}
		return File.ReadAllText(path);
	}

	private void HideAllUiGroups()
	{
		uiGroup_NewGame.SetActive(value: false);
		uiGroup_SavedData.SetActive(value: false);
	}

	private void ShowUiGroup(int _index)
	{
		HideAllUiGroups();
		switch (_index)
		{
		case 0:
			uiGroup_NewGame.SetActive(value: true);
			uiGroup_SavedData.SetActive(value: false);
			break;
		case 1:
			uiGroup_NewGame.SetActive(value: false);
			uiGroup_SavedData.SetActive(value: true);
			break;
		}
	}

	public void OnClicked_AreWeLoadingDataOrIsThisNewGame()
	{
		MenuToGameBridger.Singleton.loadDataOnNextGameSceneLoad = hasSavedDataPresent;
	}
}
