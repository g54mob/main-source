using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
	public Character character;

	public VersionNumbering version;

	public OpenFileDialog openFileDialog;

	private SaveData localSave;

	private PlayerData localPlayerData;

	private bool validLocalSave;

	private SaveData cloudSave;

	private PlayerData cloudPlayerData;

	private bool validCloudSave;

	public List<Sprite> introSprites;

	public GameObject mainMenu;

	public bool doneInitialLoad;

	public Button loadAutosaveButton;

	public Text autosaveInfo;

	public Image bannerLeft;

	public Button loadCloudButton;

	public Text cloudInfo;

	public Image bannerRight;

	public Text buildText;

	public Image leftPic;

	public Image rightPic;

	private void Awake()
	{
		loadAutosaveButton.interactable = false;
		loadCloudButton.interactable = false;
		bannerLeft.gameObject.SetActive(value: false);
		bannerRight.gameObject.SetActive(value: false);
		doneInitialLoad = false;
		startMainMenu();
	}

	public SaveData getlocalSave()
	{
		return localSave;
	}

	public SaveData getCloudSave()
	{
		return cloudSave;
	}

	public bool getlocalSaveValidity()
	{
		return validLocalSave;
	}

	public bool getCloudSaveValidity()
	{
		return validCloudSave;
	}

	private void Start()
	{
		autosaveInfo.text = "<b>Fetching Autosave, one moment...</b>";
		switch (character.platform)
		{
		case platform.Kong:
			cloudInfo.text = "<b>Fetching Cloud Save, one moment...</b>";
			break;
		case platform.Kartridge:
			cloudInfo.text = "<b>Fetching Backup Save, one moment...</b>";
			loadCloudButton.GetComponentInChildren<Text>().text = "<b>Load Backup Save</b>";
			break;
		case platform.Steam:
			cloudInfo.text = "<b>Fetching Steam Cloud, one moment...</b>";
			break;
		default:
			cloudInfo.text = "<b>Fetching Backup Save, one moment...</b>";
			break;
		}
	}

	public void setLocalSave(SaveData retrievedSave)
	{
		localSave = retrievedSave;
	}

	public void setLocalPlayerData(PlayerData retrievedData)
	{
		localPlayerData = retrievedData;
	}

	public void setLocalSaveValidity(bool validity)
	{
		validLocalSave = validity;
		updateAutosavePod();
	}

	public void setCloudSave(SaveData retrievedSave)
	{
		cloudSave = retrievedSave;
	}

	public void setCloudPlayerData(PlayerData retrievedData)
	{
		cloudPlayerData = retrievedData;
	}

	public void setCloudSaveValidity(bool validity)
	{
		validCloudSave = validity;
		updateCloudSavePod();
	}

	public void updateMainMenu()
	{
	}

	public void updateAutosavePod()
	{
		setBanners();
		if (character.platform == platform.Kong)
		{
			if (!validLocalSave)
			{
				loadAutosaveButton.interactable = false;
				autosaveInfo.text = "Hi! Can't seem to find an Autosave. If you're a <b>NEW PLAYER</b> click Start New Game, otherwise try the cloud save?\n\n";
				return;
			}
			loadAutosaveButton.interactable = true;
			autosaveInfo.text = "<b>Autosave\nDetails</b>";
			Text text = autosaveInfo;
			text.text = text.text + "\n\n<b>Total Time played: </b>" + NumberOutput.timeOutput(localPlayerData.totalPlaytime.totalseconds);
			Text text2 = autosaveInfo;
			text2.text = text2.text + "\n\n<b>Total EXP Earned: </b>" + character.display(localPlayerData.stats.totalExp);
		}
		else if (character.platform == platform.Kartridge)
		{
			if (!validLocalSave)
			{
				loadAutosaveButton.interactable = false;
				autosaveInfo.text = "Hi! Can't seem to find an Autosave. If you're a <b>NEW PLAYER</b> click Start New Game, otherwise try the cloud save?\n\n";
				return;
			}
			loadAutosaveButton.interactable = true;
			autosaveInfo.text = "<b>Autosave\nDetails</b>";
			Text text3 = autosaveInfo;
			text3.text = text3.text + "\n\n<b>Total Time played: </b>" + NumberOutput.timeOutput(localPlayerData.totalPlaytime.totalseconds);
			Text text4 = autosaveInfo;
			text4.text = text4.text + "\n\n<b>Total EXP Earned: </b>" + character.display(localPlayerData.stats.totalExp);
		}
		else if (character.platform == platform.Steam)
		{
			if (!validLocalSave)
			{
				loadAutosaveButton.interactable = false;
				autosaveInfo.text = "Hi! Can't seem to find an Autosave. If you're a <b>NEW PLAYER</b> click Start New Game, otherwise try the cloud save?\n\n";
				return;
			}
			loadAutosaveButton.interactable = true;
			autosaveInfo.text = "<b>Autosave\nDetails</b>";
			Text text5 = autosaveInfo;
			text5.text = text5.text + "\n\n<b>Total Time played: </b>" + NumberOutput.timeOutput(localPlayerData.totalPlaytime.totalseconds);
			Text text6 = autosaveInfo;
			text6.text = text6.text + "\n\n<b>Total EXP Earned: </b>" + character.display(localPlayerData.stats.totalExp);
		}
	}

	public void updateCloudSavePod()
	{
		setBanners();
		if (character.platform == platform.Kong)
		{
			if (!validCloudSave)
			{
				loadCloudButton.interactable = false;
				cloudInfo.text = "Hi! Can't seem to find the Cloud Save. If you're a <b>NEW PLAYER</b> click Start New Game, otherwise, check your internet connection?\n\n";
				return;
			}
			loadCloudButton.interactable = true;
			cloudInfo.text = "<b>Cloud\nSave Details</b>";
			Text text = cloudInfo;
			text.text = text.text + "\n\n<b>Total Time played: </b>" + NumberOutput.timeOutput(cloudPlayerData.totalPlaytime.totalseconds);
			Text text2 = cloudInfo;
			text2.text = text2.text + "\n\n<b>Total EXP Earned: </b>" + character.display(cloudPlayerData.stats.totalExp);
		}
		else if (character.platform == platform.Kartridge)
		{
			if (!validCloudSave)
			{
				loadCloudButton.interactable = false;
				cloudInfo.text = "Hi! Can't seem to find the Backup save. If you're a <b>NEW PLAYER</b> click Start New Game, otherwise, try loading a file from your Computer?\n\n";
				return;
			}
			loadCloudButton.interactable = true;
			cloudInfo.text = "<b>Backup\nSave Details</b>";
			Text text3 = cloudInfo;
			text3.text = text3.text + "\n\n<b>Total Time played: </b>" + NumberOutput.timeOutput(cloudPlayerData.totalPlaytime.totalseconds);
			Text text4 = cloudInfo;
			text4.text = text4.text + "\n\n<b>Total EXP Earned: </b>" + character.display(cloudPlayerData.stats.totalExp);
		}
		else if (character.platform == platform.Steam)
		{
			if (!validCloudSave)
			{
				loadCloudButton.interactable = false;
				cloudInfo.text = "Hi! Can't seem to find the Steam Cloud save. If you're a <b>NEW PLAYER</b> click Start New Game, otherwise, check your Steam connection.\n\n";
				return;
			}
			loadCloudButton.interactable = true;
			cloudInfo.text = "<b>Steam Cloud\nSave Details</b>";
			Text text5 = cloudInfo;
			text5.text = text5.text + "\n\n<b>Total Time played: </b>" + NumberOutput.timeOutput(cloudPlayerData.totalPlaytime.totalseconds);
			Text text6 = cloudInfo;
			text6.text = text6.text + "\n\n<b>Total EXP Earned: </b>" + character.display(cloudPlayerData.stats.totalExp);
		}
	}

	public void cloudSaveCheck()
	{
		if (character.platform == platform.Kong && character.API.retrieveKongID() == 0 && !doneInitialLoad)
		{
			cloudInfo.text = "Connection to Kong API taking longer than usual...still trying! Are you logged into Kongregate?";
		}
	}

	public void setBanners()
	{
		if (validLocalSave && validCloudSave)
		{
			if (localPlayerData.totalPlaytime.totalseconds > cloudPlayerData.totalPlaytime.totalseconds)
			{
				bannerLeft.gameObject.SetActive(value: true);
				bannerRight.gameObject.SetActive(value: false);
			}
			else if (localPlayerData.totalPlaytime.totalseconds < cloudPlayerData.totalPlaytime.totalseconds)
			{
				bannerLeft.gameObject.SetActive(value: false);
				bannerRight.gameObject.SetActive(value: true);
			}
			else
			{
				bannerLeft.gameObject.SetActive(value: false);
				bannerRight.gameObject.SetActive(value: false);
			}
		}
		else
		{
			bannerLeft.gameObject.SetActive(value: false);
			bannerRight.gameObject.SetActive(value: false);
		}
	}

	public void loadAutosave()
	{
		if (character.platform == platform.Kong && validLocalSave)
		{
			loadAutosaveKong();
		}
		else if (character.platform == platform.Kartridge && validLocalSave)
		{
			loadAutosaveKart();
		}
		else if (character.platform == platform.Steam && validLocalSave)
		{
			loadAutosaveSteam();
		}
		else
		{
			character.tooltip.showOverrideTooltip("Something happened and the selected save couldn't be loaded :c", 5f);
		}
	}

	public void loadCloudSave()
	{
		if (character.platform == platform.Kong && validCloudSave)
		{
			loadCloudSaveKong();
		}
		else if (character.platform == platform.Kartridge && validCloudSave)
		{
			loadCloudSaveKart();
		}
		else if (character.platform == platform.Steam && validCloudSave)
		{
			loadCloudSaveSteam();
		}
		else
		{
			character.tooltip.showOverrideTooltip("Something happened and the selected save couldn't be loaded :c", 5f);
		}
	}

	public void loadFileSave()
	{
		if (character.platform == platform.Kong)
		{
			loadFileBrowser();
		}
		else if (character.platform == platform.Kartridge)
		{
			loadFileKartridge();
		}
		else if (character.platform == platform.Steam)
		{
			loadFileKartridge();
		}
		else
		{
			character.tooltip.showOverrideTooltip("Something happened and the selected save couldn't be loaded :c", 5f);
		}
	}

	private void loadAutosaveKong()
	{
		try
		{
			openFileDialog.loadintoGame(localSave);
		}
		catch (Exception)
		{
			Debug.Log("bad thing");
			return;
		}
		finishMainMenu();
	}

	private void loadFileKartridge()
	{
		bool flag = false;
		try
		{
			flag = openFileDialog.loadFileMainMenuStandalone();
		}
		catch (Exception)
		{
			return;
		}
		if (flag)
		{
			finishMainMenu();
		}
		else
		{
			character.tooltip.showOverrideTooltip("File was unable to be loaded.", 2f);
		}
	}

	private void loadFileBrowser()
	{
		try
		{
			openFileDialog.loadFileBrowserMainMenu();
		}
		catch (Exception)
		{
		}
	}

	public void finishBrowserFileLoad(bool success)
	{
		if (success)
		{
			finishMainMenu();
		}
	}

	public void loadAutosaveKart()
	{
		try
		{
			openFileDialog.loadintoGame(localSave);
		}
		catch (Exception)
		{
			return;
		}
		finishMainMenu();
	}

	public void loadAutosaveSteam()
	{
		try
		{
			openFileDialog.loadintoGame(localSave);
		}
		catch (Exception)
		{
			return;
		}
		finishMainMenu();
	}

	public void loadCloudSaveKong()
	{
		try
		{
			openFileDialog.loadintoGame(cloudSave);
		}
		catch (Exception)
		{
			return;
		}
		finishMainMenu();
	}

	public void loadCloudSaveSteam()
	{
		try
		{
			openFileDialog.loadintoGame(cloudSave);
		}
		catch (Exception)
		{
			return;
		}
		finishMainMenu();
	}

	public void loadCloudSaveKart()
	{
		try
		{
			openFileDialog.loadintoGame(cloudSave);
		}
		catch (Exception)
		{
			return;
		}
		finishMainMenu();
	}

	public void startNewGame()
	{
		if (character.platform == platform.Steam)
		{
			character.steamAPI.setSteamNameOnFile();
		}
		finishMainMenu();
		character.introMenu.intro();
	}

	public void finishMainMenu()
	{
		doneInitialLoad = true;
		hideMainMenu();
	}

	public void startMainMenu()
	{
		mainMenu.transform.localPosition = new Vector3(0f, 0f);
		setImages();
		updateMiscText();
	}

	public void hideMainMenu()
	{
		mainMenu.transform.localPosition = new Vector3(-5000f, 5000f);
	}

	public void setImages()
	{
		int num = UnityEngine.Random.Range(0, introSprites.Count);
		leftPic.sprite = introSprites[num];
		int num2 = UnityEngine.Random.Range(0, introSprites.Count - 1);
		if (num2 >= num)
		{
			num2++;
		}
		rightPic.sprite = introSprites[num2];
	}

	public void updateMiscText()
	{
		buildText.text = "<b>Build " + character.getVersionAsString() + "</b>";
	}
}
