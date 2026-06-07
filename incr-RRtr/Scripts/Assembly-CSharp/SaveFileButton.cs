using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveFileButton : MonoBehaviour
{
	public string filePath;

	[SerializeField]
	private bool verticalMode;

	[SerializeField]
	private int farmType;

	[Header("References")]
	[SerializeField]
	private TMP_Text saveFileText;

	[SerializeField]
	private TMP_Text resourcesText;

	[SerializeField]
	private TMP_Text timeText;

	[SerializeField]
	private Image layoutImage;

	[SerializeField]
	private Sprite emptySp;

	[SerializeField]
	private Sprite horizontalSp;

	[SerializeField]
	private Sprite verticalSp;

	[SerializeField]
	private Image farmImage;

	[SerializeField]
	private Button savefileButton;

	[SerializeField]
	private Button clearSaveButton;

	[SerializeField]
	private GameObject currentlySelected;

	[SerializeField]
	private GameObject deletedFile;

	private bool deleted;

	[Header("Farms")]
	[SerializeField]
	private Sprite[] farmSprites;

	[SerializeField]
	private Sprite[] crossoverSprites;

	public void SetVisuals(string path)
	{
		filePath = path;
		int biofuel = 0;
		int spareparts = 0;
		float time = 0f;
		try
		{
			Debug.Log("Trying to get savefile info from " + filePath);
			ES3.CacheFile(filePath);
			ES3Settings settings = new ES3Settings(filePath, ES3.Location.Cache);
			biofuel = ES3.Load<int>("biofuel", settings);
			spareparts = ES3.Load<int>("spareParts", settings);
			time = ES3.Load<float>("inGameTimer", settings);
		}
		catch (Exception ex)
		{
			ErrorMessage.ins.ShowMessage("Failed to load " + filePath);
			ErrorMessage.ins.ShowMessage(ex.Message);
			savefileButton.interactable = false;
		}
		bool flag = false;
		if (filePath.Substring(1, 1) == "S")
		{
			flag = true;
		}
		int count = 3;
		if (flag)
		{
			count = 4;
		}
		string text = filePath.Remove(0, count);
		int num = text.IndexOf("-");
		Debug.Log(num + " from " + text);
		int num2 = text.IndexOf("-", num + 1);
		Debug.Log(num2 + " from " + text);
		int length = text.IndexOf("-", num2 + 1);
		Debug.Log(length + " from " + text);
		text = text.Substring(0, length);
		verticalMode = filePath.StartsWith("V");
		if (!flag)
		{
			farmType = int.Parse(filePath.Substring(1, 1));
		}
		else
		{
			farmType = int.Parse(filePath.Substring(2, 1));
		}
		UpdateSaveFileTexts(text, biofuel, spareparts, verticalMode, time, farmType, flag);
	}

	public void SetCurrentlySelected()
	{
		currentlySelected.SetActive(value: true);
	}

	private void UpdateSaveFileTexts(string saveName, int biofuel, int spareparts, bool vertical, float time, int farm, bool crossover)
	{
		saveFileText.text = saveName;
		resourcesText.text = "<sprite index=1>" + biofuel + " <sprite index=0>" + spareparts;
		if (vertical)
		{
			layoutImage.sprite = verticalSp;
		}
		else
		{
			layoutImage.sprite = horizontalSp;
		}
		if (!crossover)
		{
			farmImage.sprite = farmSprites[farm];
		}
		else
		{
			farmImage.sprite = crossoverSprites[farm - 1];
		}
		timeText.text = Mathf.FloorToInt(time / 3600f) + "h";
	}

	public void ClickedLoadSave()
	{
		if (!deleted && !GameManager.ins.isLoadingNewGame)
		{
			StartCoroutine(LoadSave());
		}
	}

	private IEnumerator LoadSave()
	{
		GameManager.ins.isLoadingNewGame = true;
		SaveData.ins.SaveGameData();
		yield return new WaitForSeconds(0.5f);
		GridSystem.ins.loadingScreen.SetActive(value: true);
		yield return new WaitForSeconds(0.5f);
		PersistentFilePath.ins.currentFilePath = filePath;
		PersistentFilePath.ins.closeMainMenuOnReload = true;
		GameManager.ins.isLoadingNewGame = false;
		SceneManager.LoadScene(0);
	}

	public void ClickedClearSave()
	{
		if (!deleted)
		{
			ES3.DeleteFile(filePath);
			SetSaveFileToEmpty();
		}
	}

	public void OpenAreYouSure()
	{
		if (!deleted)
		{
			AreYouSure.ins.SpawnOn(this, clearSaveButton.transform);
		}
	}

	private void SetSaveFileToEmpty()
	{
		deleted = true;
		deletedFile.SetActive(value: true);
	}
}
