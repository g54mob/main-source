using TMPro;
using UnityEngine;

public class SaveFileManager : MonoBehaviour
{
	public GameObject[] noSaveFileHolders;

	public GameObject[] saveFileExistsHolders;

	public TextMeshProUGUI[] dayTexts;

	public TextMeshProUGUI[] moneyTexts;

	public TextMeshProUGUI[] modeTexts;

	public int curSaveFileDeleting = -1;

	public GameObject areYouSureYouWantToDelete;

	public int curSaveFileCreating = -1;

	public GameObject selectModeMenu;

	private void OnEnable()
	{
		LoadAllSaveFileValues();
	}

	private void LoadAllSaveFileValues()
	{
		for (int i = 0; i < 3; i++)
		{
			if (SaveSystem.TryGetDayAndMoney(i, out var day, out var money, out var endlessMode))
			{
				saveFileExistsHolders[i].SetActive(value: true);
				noSaveFileHolders[i].SetActive(value: false);
				string miscText = JSONAccess.Instance.GetMiscText("UI Text", "NIGHT");
				miscText = miscText.Replace("<NIGHT NUMBER>", day.ToString());
				dayTexts[i].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				dayTexts[i].text = miscText;
				moneyTexts[i].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				moneyTexts[i].text = "$" + money.ToString("0.00");
				if (endlessMode)
				{
					modeTexts[i].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
					modeTexts[i].text = JSONAccess.Instance.GetMiscText("UI Text", "ENDLESS MODE");
				}
				else
				{
					modeTexts[i].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
					modeTexts[i].text = JSONAccess.Instance.GetMiscText("UI Text", "DEMO MODE");
				}
			}
			else
			{
				saveFileExistsHolders[i].SetActive(value: false);
				noSaveFileHolders[i].SetActive(value: true);
			}
		}
	}

	public void CreateNewSave(int index)
	{
		selectModeMenu.SetActive(value: true);
		curSaveFileCreating = index;
	}

	public void ConfirmCreateNewSave(bool endlessMode)
	{
		PlayerPrefs.SetInt("CurSaveSlot", curSaveFileCreating);
		PlayerPrefs.SetInt("EventSeedSet" + curSaveFileCreating, 0);
	}

	public void SelectSaveFile(int index)
	{
		PlayerPrefs.SetInt("CurSaveSlot", index);
	}

	public void TryToDeleteSaveFile(int index)
	{
		curSaveFileDeleting = index;
		areYouSureYouWantToDelete.SetActive(value: true);
	}

	public void ConfirmDeleteSaveFile()
	{
		SaveSystem.ResetSave(curSaveFileDeleting);
		LoadAllSaveFileValues();
	}
}
