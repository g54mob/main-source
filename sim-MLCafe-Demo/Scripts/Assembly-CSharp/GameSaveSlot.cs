using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelName;

	[SerializeField]
	private TMP_Text labelLevel;

	[SerializeField]
	private TMP_Text labelBudget;

	[SerializeField]
	private TMP_Text labelGameMode;

	[SerializeField]
	private TMP_Text labelDay;

	[SerializeField]
	private TMP_Text labelDate;

	[SerializeField]
	private ButtonField button;

	[SerializeField]
	private Image[] images;

	[SerializeField]
	private TMP_Text labelVersion;

	[SerializeField]
	private Image difficultyImage;

	[SerializeField]
	private Sprite[] difficultyIcons;

	[SerializeField]
	private string[] difficultyTextKeys;

	private GameDataPreview fileData;

	[SerializeField]
	private bool slotNotValid;

	public GameDataPreview GetData()
	{
		return fileData;
	}

	public void InitSlot(int index, SaveFileMeta meta)
	{
		fileData = meta.files[index];
		labelName.text = fileData.cafeName;
		labelLevel.text = fileData.level.ToString();
		labelBudget.text = fileData.budget.ToString();
		labelGameMode.text = LocalizationManager.GetLocalizedString(difficultyTextKeys[fileData.gamemode], LocalizationDataTable.Tables.UI);
		labelDay.text = fileData.day.ToString();
		labelDate.text = fileData.lastPlayed.ToString();
		difficultyImage.sprite = difficultyIcons[fileData.gamemode];
		if (!DataPersistenceManager.IsGameVersionCompatible(fileData.version))
		{
			labelVersion.text = ((fileData.version != null && fileData.version != string.Empty) ? ("Verion " + fileData.version.ToString() + " is not compatible anymore...") : "Save File Version - not found...");
			slotNotValid = true;
			SetInvalidColors();
		}
	}

	public void LoadSaveSlot()
	{
		if (!slotNotValid)
		{
			GameManager.StartExistingGame(fileData.fileName, fileData.gamemode);
		}
	}

	public void SetInvalidColors()
	{
		Image[] array = images;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = Color.red;
		}
		labelVersion.color = Color.red;
		button.enabled = false;
	}
}
