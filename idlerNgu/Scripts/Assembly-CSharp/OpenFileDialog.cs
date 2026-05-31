using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Kongregate;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OpenFileDialog : MonoBehaviour
{
	public ImportExport importExport;

	public HoverTooltip tooltip;

	public PlayerTime autosaveTime;

	public Character character;

	public KongregateAPIBehaviour api;

	public AGAPI AGAPI;

	public ConfirmationBox box;

	public Button fileSaveButton;

	public Button fileLoadButton;

	public Button onlineSaveButton;

	public Button onlineLoadButton;

	public Button standaloneSave;

	public Button standaloneLoad;

	private PlayerTime onlineSaveTime = new PlayerTime();

	private PlayerTime manualOnlineSaveTime = new PlayerTime();

	private PlayerTime onlineLoadTime = new PlayerTime();

	private PlayerTime manualOnlineLoadTime = new PlayerTime();

	private PlayerTime standaloneBackupSaveTime = new PlayerTime();

	private UnityAction yesAction;

	private UnityAction noAction;

	public bool firstAutosave = true;

	public static Action<string> OpenFileResult;

	[DllImport("__Internal")]
	private static extern void TextUploadClick();

	[DllImport("__Internal")]
	private static extern void TextUploadClickMainMenu();

	[DllImport("__Internal")]
	private static extern void DownloadText(string filename, string data);

	[DllImport("__Internal")]
	private static extern void SyncFiles();

	[DllImport("__Internal")]
	private static extern void WindowAlert(string message);

	private IEnumerator LoadText(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		try
		{
			PlayerData dataFromString = importExport.getDataFromString(www.text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				Debug.Log(dataFromString);
				tooltip.showOverrideTooltip("File couldn't be loaded- very old version or a broken save.", 3f);
				yield break;
			}
			if (dataFromString.version > character.getVersion())
			{
				tooltip.showOverrideTooltip("This file you tried to load is from a LATER verison of the game than this- it can't be loaded or else time paradox stuff would happen. Sorry!", 3f);
				yield break;
			}
		}
		catch (Exception ex)
		{
			tooltip.showTooltip("Failed to Load File: " + ex.Message);
			yield break;
		}
		if (OpenFileResult != null)
		{
			OpenFileResult(www.text);
		}
		string url2 = "https://www.nguidle.com/getTime.php";
		character.menuSwapper.swapMenu(0);
		character.inventoryController.updateItemStats();
		character.inventoryController.updateBonuses();
		character.buttons.updateButtons();
		Epoch.Current();
		WWW www2 = new WWW(url2);
		yield return new WaitForSeconds(0.9f);
		int t = ((!www2.isDone || !string.IsNullOrEmpty(www2.error)) ? Epoch.Current() : int.Parse(www2.text));
		importExport.loadBase64ToData(www.text);
		int num = Epoch.SecondsElapsed(character.lastTime, t);
		if (character.ignoreOfflineProgress)
		{
			character.ignoreOfflineProgress = false;
			tooltip.showOverrideTooltip("Sorry, I had to toss your offline progress just this once for the update. Forgive plz", 3f);
			yield break;
		}
		if (num > 10)
		{
			if (num > 31536000)
			{
				num = 31536000;
			}
			character.addOfflineProgress(num);
		}
		character.menuSwapper.swapMenu(0);
		character.inventoryController.updateItemStats();
		character.inventoryController.updateBonuses();
		character.buttons.updateButtons();
		character.refreshMenus();
		tooltip.displayState();
		character.introMenu.intro();
		character.adventureController.zoneSelector.changeZone(character.adventure.zone);
		character.adventureController.wipeEnemy();
		if (character.curEnergy > character.totalCapEnergy())
		{
			character.removeAllEnergy();
			character.curEnergy = character.totalCapEnergy();
			character.idleEnergy = character.curEnergy;
			if (character.arbitrary.instaTrain)
			{
				character.idleEnergy -= 12L;
				character.training.attackEnergy[0] += 6L;
				character.training.defenseEnergy[0] += 6L;
			}
			tooltip.showOverrideTooltip("All of your Energy had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.magic.curMagic > character.totalCapMagic())
		{
			character.removeAllMagic();
			character.magic.curMagic = character.totalCapMagic();
			character.magic.idleMagic = character.magic.curMagic;
			tooltip.showOverrideTooltip("All of your Magic had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.res3.res3On && character.res3.curRes3 > character.totalCapRes3())
		{
			character.removeAllRes3();
			character.res3.curRes3 = character.totalCapRes3();
			character.res3.idleRes3 = character.res3.curRes3;
			tooltip.showOverrideTooltip("All of your " + character.res3.res3Name + "  had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
	}

	private void FileSelected(string url)
	{
		StartCoroutine(LoadText(url));
	}

	private void FileSelectedMainMenu(string url)
	{
		StartCoroutine(LoadTextMainMenu(url));
	}

	private void Start()
	{
		autosaveTime.reset();
		autosaveTime.setTime(5f);
		manualOnlineLoadTime.setTime(manualLoadTime());
		manualOnlineSaveTime.setTime(manualSaveTime());
		standaloneBackupSaveTime.reset();
		if (character.platform == platform.Kong || character.platform == platform.AG)
		{
			standaloneSave.gameObject.SetActive(value: false);
			standaloneLoad.gameObject.SetActive(value: false);
			onlineSaveButton.gameObject.SetActive(value: true);
			onlineLoadButton.gameObject.SetActive(value: true);
			fileSaveButton.gameObject.SetActive(value: true);
			fileLoadButton.gameObject.SetActive(value: true);
		}
		else if (character.platform == platform.Kartridge)
		{
			onlineSaveButton.gameObject.SetActive(value: false);
			onlineLoadButton.gameObject.SetActive(value: false);
			fileSaveButton.gameObject.SetActive(value: false);
			fileLoadButton.gameObject.SetActive(value: false);
			standaloneSave.gameObject.SetActive(value: true);
			standaloneLoad.gameObject.SetActive(value: true);
		}
		else if (character.platform == platform.Steam)
		{
			onlineSaveButton.gameObject.SetActive(value: false);
			onlineLoadButton.gameObject.SetActive(value: false);
			fileSaveButton.gameObject.SetActive(value: false);
			fileLoadButton.gameObject.SetActive(value: false);
			standaloneSave.gameObject.SetActive(value: true);
			standaloneLoad.gameObject.SetActive(value: true);
		}
		else
		{
			onlineSaveButton.gameObject.SetActive(value: false);
			onlineLoadButton.gameObject.SetActive(value: false);
			fileSaveButton.gameObject.SetActive(value: false);
			fileLoadButton.gameObject.SetActive(value: false);
			standaloneSave.gameObject.SetActive(value: true);
			standaloneLoad.gameObject.SetActive(value: true);
		}
	}

	private int saveTime()
	{
		return 3600;
	}

	private int manualSaveTime()
	{
		return 120;
	}

	private int loadTime()
	{
		return 1200;
	}

	private int manualLoadTime()
	{
		return 120;
	}

	private int standaloneBackupTime()
	{
		return 1800;
	}

	public int autoSaveTime()
	{
		if (firstAutosave)
		{
			return 60;
		}
		return 30;
	}

	private void Update()
	{
		if (autosaveTime.totalseconds < (double)autoSaveTime() && character.mainMenu.doneInitialLoad)
		{
			autosaveTime.advanceTime(Time.deltaTime);
		}
		if (autosaveTime.totalseconds >= (double)autoSaveTime())
		{
			if (character.platform == platform.Kartridge)
			{
				quicklySaveStandalone();
			}
			else if (character.platform == platform.Steam)
			{
				quicklySaveSteam();
				Invoke("saveGamestateToSteamCloud", 1f);
			}
			else
			{
				quicklySave();
			}
			firstAutosave = false;
			autosaveTime.reset();
		}
		if (character.platform == platform.Kong || character.platform == platform.AG)
		{
			if (onlineLoadTime.totalseconds < (double)loadTime() && character.mainMenu.doneInitialLoad)
			{
				onlineLoadTime.advanceTime(Time.deltaTime);
			}
			if (manualOnlineLoadTime.totalseconds < (double)manualLoadTime() && character.mainMenu.doneInitialLoad)
			{
				manualOnlineLoadTime.advanceTime(Time.deltaTime);
			}
			if (onlineSaveTime.totalseconds < (double)saveTime() && character.mainMenu.doneInitialLoad)
			{
				onlineSaveTime.advanceTime(Time.deltaTime);
			}
			if (manualOnlineSaveTime.totalseconds < (double)manualSaveTime() && character.mainMenu.doneInitialLoad)
			{
				manualOnlineSaveTime.advanceTime(Time.deltaTime);
			}
			if (character.settings.dailySaveRewardTime.totalseconds < 84600.0 && character.mainMenu.doneInitialLoad)
			{
				character.settings.dailySaveRewardTime.advanceTime(Time.deltaTime);
			}
			if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
			{
				fileSaveButton.image.color = new Color(0.6f, 1f, 0.6f);
			}
			else
			{
				fileSaveButton.image.color = Color.white;
			}
			if (onlineSaveTime.totalseconds >= (double)saveTime())
			{
				if (character.platform == platform.Kong)
				{
					StartCoroutine(uploadSave(forced: false));
				}
				else if (character.platform == platform.AG)
				{
					StartCoroutine(uploadAGSave(forced: false));
				}
				onlineSaveTime.reset();
				onlineSaveTime.setTime(UnityEngine.Random.Range(0f, 30f));
			}
		}
		else if (character.platform == platform.Kartridge)
		{
			if (standaloneBackupSaveTime.totalseconds < (double)standaloneBackupTime() && character.mainMenu.doneInitialLoad)
			{
				standaloneBackupSaveTime.advanceTime(Time.deltaTime);
			}
			if (standaloneBackupSaveTime.totalseconds >= (double)standaloneBackupTime())
			{
				doStandaloneBackupSave();
				firstAutosave = false;
				standaloneBackupSaveTime.reset();
			}
			if (character.settings.dailySaveRewardTime.totalseconds < 84600.0 && character.mainMenu.doneInitialLoad)
			{
				character.settings.dailySaveRewardTime.advanceTime(Time.deltaTime);
			}
			if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
			{
				standaloneSave.image.color = new Color(0.6f, 1f, 0.6f);
			}
			else
			{
				standaloneSave.image.color = Color.white;
			}
		}
		else if (character.platform == platform.Steam)
		{
			if (standaloneBackupSaveTime.totalseconds < (double)standaloneBackupTime() && character.mainMenu.doneInitialLoad)
			{
				standaloneBackupSaveTime.advanceTime(Time.deltaTime);
			}
			if (standaloneBackupSaveTime.totalseconds >= (double)standaloneBackupTime())
			{
				doStandaloneBackupSave();
				firstAutosave = false;
				standaloneBackupSaveTime.reset();
			}
			if (character.settings.dailySaveRewardTime.totalseconds < 84600.0 && character.mainMenu.doneInitialLoad)
			{
				character.settings.dailySaveRewardTime.advanceTime(Time.deltaTime);
			}
			if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
			{
				standaloneSave.image.color = new Color(0.6f, 1f, 0.6f);
			}
			else
			{
				standaloneSave.image.color = Color.white;
			}
		}
	}

	public void startSave()
	{
		StartCoroutine(saveFile());
	}

	public IEnumerator saveFile()
	{
		yield return StartCoroutine(setTime());
		Save();
	}

	public IEnumerator setTime()
	{
		Epoch.Current();
		string url = "https://www.nguidle.com/getTime.php";
		WWW www2 = new WWW(url);
		yield return new WaitForSeconds(1f);
		int lastTime = ((!www2.isDone || !string.IsNullOrEmpty(www2.error)) ? Epoch.Current() : int.Parse(www2.text));
		character.lastTime = lastTime;
	}

	public void Save()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
			{
				character.settings.dailySaveRewardTime.reset();
				tooltip.showTooltip("You (tried) to manually save your file today! Here's " + character.addAP(200) + " AP as a bribe!", 3f);
			}
			string base64Data = importExport.getBase64Data();
			DownloadText("NGUSave-Build-" + character.getVersion() + "-" + DateTime.Now.ToString("MMMM-dd-HH-mm"), base64Data);
		}
	}

	public void Load()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			TextUploadClick();
		}
		character.tooltip.displayState();
	}

	public void loadFileBrowserMainMenu()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			TextUploadClickMainMenu();
		}
	}

	public void quicklySave()
	{
		character.lastTime = Epoch.Current();
		string base64Data = importExport.getBase64Data();
		quickSave(base64Data);
	}

	public void quicklySaveStandalone()
	{
		character.lastTime = Epoch.Current();
		string base64Data = importExport.getBase64Data();
		quickSaveStandalone(base64Data);
	}

	public void quicklySaveSteam()
	{
		character.lastTime = Epoch.Current();
		string base64Data = importExport.getBase64Data();
		quickSaveSteam(base64Data);
	}

	public void quickSave(string base64SaveData)
	{
		string path = $"{Application.persistentDataPath}/NGUSave.txt";
		try
		{
			FileStream fileStream;
			if (File.Exists(path))
			{
				File.WriteAllText(path, string.Empty);
				fileStream = File.Open(path, FileMode.Open);
			}
			else
			{
				fileStream = File.Create(path);
			}
			fileStream.Close();
			File.WriteAllText(path, base64SaveData);
			if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				SyncFiles();
			}
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Save: " + ex.Message);
		}
	}

	public void quickSaveStandalone(string base64SaveData)
	{
		try
		{
			File.WriteAllText($"{Application.persistentDataPath}/NGUSave.txt", base64SaveData);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Save: " + ex.Message);
		}
	}

	public void quickSaveSteam(string base64SaveData)
	{
		try
		{
			File.WriteAllText($"{Application.persistentDataPath}/NGUSaveSteam.txt", base64SaveData);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Save: " + ex.Message);
		}
	}

	public void doStandaloneBackupSave()
	{
		if (character.platform == platform.Kartridge)
		{
			character.lastTime = Epoch.Current();
			string base64Data = importExport.getBase64Data();
			backupSave(base64Data);
		}
		else if (character.platform == platform.Steam)
		{
			character.lastTime = Epoch.Current();
			string base64Data2 = importExport.getBase64Data();
			backupSaveSteam(base64Data2);
		}
	}

	public void backupSave(string base64SaveData)
	{
		try
		{
			File.WriteAllText($"{Application.persistentDataPath}/NGUBackup2.txt", base64SaveData);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Save: " + ex.Message);
		}
		try
		{
			File.WriteAllText($"{Application.persistentDataPath}/NGUBackup.txt", base64SaveData);
		}
		catch (Exception ex2)
		{
			PlatformSafeMessage("Failed to Save: " + ex2.Message);
		}
	}

	public void backupSaveSteam(string base64SaveData)
	{
		try
		{
			File.WriteAllText($"{Application.persistentDataPath}/NGUSteamBackup2.txt", base64SaveData);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Save: " + ex.Message);
		}
		try
		{
			File.WriteAllText($"{Application.persistentDataPath}/NGUSteamBackup.txt", base64SaveData);
		}
		catch (Exception ex2)
		{
			PlatformSafeMessage("Failed to Save: " + ex2.Message);
		}
	}

	public void quickSave(string base64SaveData, string customPath)
	{
		string text = string.Format(customPath);
		if (text == "")
		{
			return;
		}
		try
		{
			FileStream fileStream;
			if (File.Exists(text))
			{
				File.WriteAllText(text, string.Empty);
				fileStream = File.Open(text, FileMode.Open);
			}
			else
			{
				fileStream = File.Create(text);
			}
			fileStream.Close();
			File.WriteAllText(text, base64SaveData);
			if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				SyncFiles();
			}
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Save: " + ex.Message);
		}
	}

	public void deleteLocalSave()
	{
		string path = $"{Application.persistentDataPath}/NGUSave.txt";
		if (File.Exists(path))
		{
			File.WriteAllText(path, string.Empty);
		}
		Debug.Log(File.Exists(path));
	}

	public bool quickLoad()
	{
		string path = $"{Application.persistentDataPath}/NGUSave.txt";
		string text = "";
		try
		{
			if (!File.Exists(path))
			{
				return false;
			}
			text = File.ReadAllText(path);
		}
		catch (Exception ex)
		{
			Debug.Log("hi");
			PlatformSafeMessage("Failed to Load: " + ex.Message);
			return false;
		}
		try
		{
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				return false;
			}
			if (dataFromString.version > character.getVersion())
			{
				return false;
			}
			importExport.loadBase64ToData(text);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public void setLocalSave()
	{
		string path = $"{Application.persistentDataPath}/NGUSave.txt";
		string text = "";
		try
		{
			if (!File.Exists(path))
			{
				character.mainMenu.setLocalSaveValidity(validity: false);
				return;
			}
			text = File.ReadAllText(path);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Load: " + ex.Message);
			character.mainMenu.setLocalSaveValidity(validity: false);
			return;
		}
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(text);
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				character.mainMenu.setLocalSaveValidity(validity: false);
				return;
			}
			if (dataFromString.version > character.getVersion())
			{
				character.mainMenu.setLocalSaveValidity(validity: false);
				return;
			}
			character.mainMenu.setLocalSave(saveDataFromString);
			character.mainMenu.setLocalPlayerData(dataFromString);
			character.mainMenu.setLocalSaveValidity(validity: true);
		}
		catch (Exception)
		{
			character.mainMenu.setLocalSaveValidity(validity: false);
		}
	}

	public void setLocalSaveSteam()
	{
		string path = $"{Application.persistentDataPath}/NGUSaveSteam.txt";
		string text = "";
		try
		{
			if (!File.Exists(path))
			{
				character.mainMenu.setLocalSaveValidity(validity: false);
				return;
			}
			text = File.ReadAllText(path);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Load: " + ex.Message);
			character.mainMenu.setLocalSaveValidity(validity: false);
			return;
		}
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(text);
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				character.mainMenu.setLocalSaveValidity(validity: false);
				return;
			}
			if (dataFromString.version > character.getVersion())
			{
				character.mainMenu.setLocalSaveValidity(validity: false);
				return;
			}
			character.mainMenu.setLocalSave(saveDataFromString);
			character.mainMenu.setLocalPlayerData(dataFromString);
			character.mainMenu.setLocalSaveValidity(validity: true);
		}
		catch (Exception)
		{
			character.mainMenu.setLocalSaveValidity(validity: false);
		}
	}

	public void setKartBackupSave()
	{
		string path = $"{Application.persistentDataPath}/NGUBackup.txt";
		string text = "";
		try
		{
			if (!File.Exists(path))
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				return;
			}
			text = File.ReadAllText(path);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Load: " + ex.Message);
			character.mainMenu.setCloudSaveValidity(validity: false);
			return;
		}
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(text);
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				return;
			}
			if (dataFromString.version > character.getVersion())
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				return;
			}
			character.mainMenu.setCloudSave(saveDataFromString);
			character.mainMenu.setCloudPlayerData(dataFromString);
			character.mainMenu.setCloudSaveValidity(validity: true);
		}
		catch (Exception)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
		}
	}

	public void setAutosave()
	{
		switch (character.platform)
		{
		case platform.Steam:
			setLocalSaveSteam();
			break;
		case platform.Kong:
			setLocalSave();
			break;
		case platform.Kartridge:
			setLocalSave();
			break;
		case platform.AG:
			break;
		}
	}

	public void setCloudSave()
	{
		switch (character.platform)
		{
		case platform.Steam:
			setCloudSaveSteam();
			break;
		case platform.Kong:
			setCloudSaveKong();
			break;
		case platform.Kartridge:
			setKartBackupSave();
			break;
		case platform.AG:
			break;
		}
	}

	public void setCloudSaveKong()
	{
		StartCoroutine(fetchCloudSaveKong());
	}

	private IEnumerator fetchCloudSaveKong()
	{
		string url = "https://www.nguidle.com/loadKongOnline2.php";
		WWWForm wWWForm = new WWWForm();
		if (api.retrieveKongID() == 0)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
			yield break;
		}
		wWWForm.AddField("SecretCode", character.API.getToken());
		wWWForm.AddField("KongID", api.retrieveKongID());
		wWWForm.AddField("UserName", api.kongName);
		WWW www = new WWW(url, wWWForm);
		yield return www;
		if (www.error != null)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
			yield break;
		}
		if (www.text == "")
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
			yield break;
		}
		string text = www.text;
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(text);
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				yield break;
			}
			if (dataFromString.version > character.getVersion())
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				yield break;
			}
			character.mainMenu.setCloudSave(saveDataFromString);
			character.mainMenu.setCloudPlayerData(dataFromString);
			character.mainMenu.setCloudSaveValidity(validity: true);
		}
		catch (Exception)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
		}
	}

	public bool quickLoad(string customPath)
	{
		string text = string.Format(customPath);
		if (text == "")
		{
			return false;
		}
		string text2 = "";
		try
		{
			if (!File.Exists(text))
			{
				return false;
			}
			text2 = File.ReadAllText(text);
		}
		catch (Exception ex)
		{
			Debug.Log("hi");
			PlatformSafeMessage("Failed to Load: " + ex.Message);
			return false;
		}
		try
		{
			PlayerData dataFromString = importExport.getDataFromString(text2);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				return false;
			}
			if (dataFromString.version > character.getVersion())
			{
				return false;
			}
			importExport.loadBase64ToData(text2);
		}
		catch (Exception ex2)
		{
			character.tooltip.showTooltip("Failed to Load: " + ex2.Message, 2f);
			return false;
		}
		return true;
	}

	public void initialLoad()
	{
		string path = $"{Application.persistentDataPath}/NGUSave.txt";
		string base64Data = "";
		try
		{
			if (!File.Exists(path))
			{
				return;
			}
			base64Data = File.ReadAllText(path);
		}
		catch (Exception ex)
		{
			PlatformSafeMessage("Failed to Load: " + ex.Message);
		}
		try
		{
			importExport.loadBase64ToData(base64Data);
		}
		catch (Exception)
		{
		}
	}

	public void quicklyLoad()
	{
		if (File.Exists($"{Application.persistentDataPath}/NGUSave.txt"))
		{
			quickLoad();
			character.refreshMenus();
		}
	}

	private static void PlatformSafeMessage(string message)
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			WindowAlert(message);
		}
		else
		{
			Debug.Log(message);
		}
	}

	public void onlineSave()
	{
		StartCoroutine(uploadSave(forced: false));
	}

	public IEnumerator uploadSave(bool forced)
	{
		string url = "https://www.nguidle.com/saveKongOnline2.php";
		Epoch.Current();
		string url2 = "https://www.nguindustries.net/getTime.php";
		WWW www2 = new WWW(url2);
		yield return new WaitForSeconds(1f);
		int lastTime = ((!www2.isDone || !string.IsNullOrEmpty(www2.error)) ? Epoch.Current() : int.Parse(www2.text));
		character.lastTime = lastTime;
		string base64Data = importExport.getBase64Data();
		WWWForm wWWForm = new WWWForm();
		if (api.retrieveKongID() == 0)
		{
			yield break;
		}
		wWWForm.AddField("KongID", api.retrieveKongID());
		wWWForm.AddField("SecretCode", character.API.getToken());
		wWWForm.AddField("UserName", api.kongName);
		wWWForm.AddField("UserSave", base64Data);
		WWW www3 = new WWW(url, wWWForm);
		yield return www3;
		if (www3.error != null)
		{
			tooltip.showOverrideTooltip("Oh snap, something screwed up when trying to save! Probably your internet sucked. Try again later!", 3f);
			yield break;
		}
		if (forced)
		{
			tooltip.showOverrideTooltip("Game successfully saved online!", 3f);
		}
		onlineSaveTime.reset();
		manualOnlineSaveTime.reset();
		onlineLoadTime.reset();
		manualOnlineLoadTime.reset();
	}

	private string secretKongCode()
	{
		return "GGGGBabyBabyBaby";
	}

	public IEnumerator uploadAGSave(bool forced)
	{
		string url = "https://www.nguidle.com/saveAGOnline.php";
		Epoch.Current();
		string url2 = "https://www.nguidle.com/getTime.php";
		WWW www2 = new WWW(url2);
		yield return new WaitForSeconds(1f);
		int lastTime = ((!www2.isDone || !string.IsNullOrEmpty(www2.error)) ? Epoch.Current() : int.Parse(www2.text));
		character.lastTime = lastTime;
		string base64Data = importExport.getBase64Data();
		WWWForm wWWForm = new WWWForm();
		if (character.AGAPI.AGID == "")
		{
			Debug.Log("wuh oh");
			yield break;
		}
		wWWForm.AddField("SecretCode", importExport.CalculateSha256Hash("That" + character.AGAPI.AGID + "FuckingElephant69" + character.AGAPI.AGID));
		wWWForm.AddField("AGID", character.AGAPI.AGID);
		wWWForm.AddField("UserName", character.playerName);
		wWWForm.AddField("UserSave", base64Data);
		WWW www3 = new WWW(url, wWWForm);
		yield return www3;
		if (www3.error != null)
		{
			tooltip.showOverrideTooltip("Oh snap, something screwed up when trying to save! Probably your internet sucked. Try again later!", 3f);
			yield break;
		}
		if (forced)
		{
			tooltip.showOverrideTooltip("Game successfully saved online!", 3f);
		}
		onlineSaveTime.reset();
		manualOnlineSaveTime.reset();
		onlineLoadTime.reset();
		manualOnlineLoadTime.reset();
	}

	public void ManualOnlineSave()
	{
		if (character.platform == platform.Kong)
		{
			if (api.retrieveKongID() == 0)
			{
				tooltip.showOverrideTooltip("Sorry guest, you'll need a Kongregate Account to be able to use online saves. I can't tell you guys apart otherwise. Please, forgive me :C.", 3f);
				return;
			}
			if (manualOnlineSaveTime.totalseconds < (double)manualSaveTime())
			{
				tooltip.showOverrideTooltip("You need to wait <b>" + ((double)manualSaveTime() - manualOnlineSaveTime.totalseconds).ToString("###") + "</b> seconds to manually save online!", 3f);
				return;
			}
			onlineSaveTime.reset();
			manualOnlineSaveTime.reset();
			onlineLoadTime.reset();
			manualOnlineLoadTime.reset();
			StartCoroutine(uploadSave(forced: true));
		}
		else if (character.platform == platform.AG)
		{
			if (character.AGAPI.AGID == "")
			{
				tooltip.showOverrideTooltip("Sorry guest, you'll need an Armor Games Account to be able to use online saves. I can't tell you guys apart otherwise. Please, forgive me :C.", 3f);
				return;
			}
			if (manualOnlineSaveTime.totalseconds < (double)manualSaveTime())
			{
				tooltip.showOverrideTooltip("You need to wait <b>" + ((double)manualSaveTime() - manualOnlineSaveTime.totalseconds).ToString("###") + "</b> seconds to manually save online!", 3f);
				return;
			}
			onlineSaveTime.reset();
			manualOnlineSaveTime.reset();
			onlineLoadTime.reset();
			manualOnlineLoadTime.reset();
			StartCoroutine(uploadAGSave(forced: true));
		}
	}

	public void cancel()
	{
	}

	public void onlineLoad()
	{
		StartCoroutine(getLoad(forced: false));
	}

	public void onlineAGLoad()
	{
		StartCoroutine(getAGLoad(forced: false));
	}

	public void beginOnlineLoad()
	{
		StartCoroutine(getLoad(forced: false));
	}

	public void engageOnlineLoad()
	{
		StartCoroutine(getLoad(forced: true));
		onlineSaveTime.reset();
		manualOnlineSaveTime.reset();
		onlineLoadTime.reset();
		manualOnlineLoadTime.reset();
	}

	public void engageAGOnlineLoad()
	{
		StartCoroutine(getAGLoad(forced: true));
		onlineSaveTime.reset();
		manualOnlineSaveTime.reset();
		onlineLoadTime.reset();
		manualOnlineLoadTime.reset();
	}

	private IEnumerator getLoad(bool forced)
	{
		string url = "https://www.nguidle.com/loadKongOnline2.php";
		string url2 = "https://www.nguidle.com/getTime.php";
		WWWForm wWWForm = new WWWForm();
		if (api.retrieveKongID() == 0)
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("Sorry guest, you'll need a Kongregate Account to be able to use online saves. I can't tell you guys apart otherwise. Please, forgive me :C", 3f);
			}
			yield break;
		}
		wWWForm.AddField("SecretCode", character.API.getToken());
		wWWForm.AddField("KongID", api.retrieveKongID());
		wWWForm.AddField("UserName", api.kongName);
		WWW www = new WWW(url, wWWForm);
		yield return www;
		if (www.error != null)
		{
			tooltip.showOverrideTooltip("Uh oh! The online load failed! Either you have no save or your internet's weird.", 3f);
			yield break;
		}
		if (www.text == "")
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("No online save found. Have you saved your game online before this?", 3f);
			}
			yield break;
		}
		string saveData = www.text;
		Epoch.Current();
		WWW www2 = new WWW(url2);
		yield return new WaitForSeconds(2f);
		int t = ((!www2.isDone || !string.IsNullOrEmpty(www2.error)) ? Epoch.Current() : int.Parse(www2.text));
		importExport.loadBase64ToData(saveData);
		character.inventoryController.updateItemStats();
		character.inventoryController.updateBonuses();
		int num = Epoch.SecondsElapsed(character.lastTime, t);
		if (character.ignoreOfflineProgress)
		{
			character.ignoreOfflineProgress = false;
			tooltip.showOverrideTooltip("Sorry, I had to toss your offline progress just this once for the update. FORGIve plz", 3f);
		}
		else if (num > 10)
		{
			if (num > 31536000)
			{
				num = 31536000;
			}
			character.addOfflineProgress(num);
		}
		character.menuSwapper.swapMenu(0);
		character.inventoryController.updateItemStats();
		character.buttons.updateButtons();
		character.refreshMenus();
		character.adventureController.zoneSelector.changeZone(character.adventure.zone);
		character.adventureController.wipeEnemy();
		if (character.curEnergy > character.totalCapEnergy())
		{
			character.removeAllEnergy();
			character.curEnergy = character.totalCapEnergy();
			character.idleEnergy = character.curEnergy;
			if (character.arbitrary.instaTrain)
			{
				character.idleEnergy -= 12L;
				character.training.attackEnergy[0] += 6L;
				character.training.defenseEnergy[0] += 6L;
			}
			tooltip.showOverrideTooltip("All of your Energy had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.magic.curMagic > character.totalCapMagic())
		{
			character.removeAllMagic();
			character.magic.curMagic = character.totalCapMagic();
			character.magic.idleMagic = character.magic.curMagic;
			tooltip.showOverrideTooltip("All of your Magic had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.res3.res3On && character.res3.curRes3 > character.totalCapRes3())
		{
			character.removeAllRes3();
			character.res3.curRes3 = character.totalCapRes3();
			character.res3.idleRes3 = character.res3.curRes3;
			tooltip.showOverrideTooltip("All of your " + character.res3.res3Name + "  had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		tooltip.displayState();
		character.introMenu.intro();
		character.introMenu.intro();
	}

	private IEnumerator getAGLoad(bool forced)
	{
		manualOnlineLoadTime.reset();
		string url = "https://www.nguidle.com/loadAGOnline.php";
		string url2 = "https://www.nguidle.com/getTime.php";
		WWWForm wWWForm = new WWWForm();
		if (character.AGAPI.AGID == "")
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("Sorry guest, you'll need an Armor Games Account to be able to use online saves. I can't tell you guys apart otherwise. Please, forgive me :C", 3f);
			}
			yield break;
		}
		wWWForm.AddField("SecretCode", importExport.CalculateSha256Hash("That" + character.AGAPI.AGID + "FuckingElephant69" + character.AGAPI.AGID));
		wWWForm.AddField("AGID", AGAPI.AGID);
		wWWForm.AddField("UserName", character.playerName);
		WWW www = new WWW(url, wWWForm);
		yield return www;
		if (www.error != null)
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("Uh oh! The online load failed! Either you have no save or your internet's had a hiccup.", 3f);
			}
			yield break;
		}
		if (www.text == "")
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("No online save found. Have you saved your game online before this?", 3f);
			}
			yield break;
		}
		string saveData = www.text;
		Epoch.Current();
		WWW www2 = new WWW(url2);
		yield return new WaitForSeconds(2f);
		int t = ((!www2.isDone || !string.IsNullOrEmpty(www2.error)) ? Epoch.Current() : int.Parse(www2.text));
		importExport.loadBase64ToData(saveData);
		character.inventoryController.updateItemStats();
		character.inventoryController.updateBonuses();
		int num = Epoch.SecondsElapsed(character.lastTime, t);
		if (character.ignoreOfflineProgress)
		{
			character.ignoreOfflineProgress = false;
			tooltip.showOverrideTooltip("Sorry, I had to toss your offline progress just this once for the update. FORGIve plz", 3f);
		}
		else if (num > 10)
		{
			if (num > 31536000)
			{
				num = 31536000;
			}
			character.addOfflineProgress(num);
		}
		character.menuSwapper.swapMenu(0);
		character.inventoryController.updateItemStats();
		character.buttons.updateButtons();
		character.refreshMenus();
		character.adventureController.zoneSelector.changeZone(character.adventure.zone);
		character.adventureController.wipeEnemy();
		if (character.curEnergy > character.totalCapEnergy())
		{
			character.removeAllEnergy();
			character.curEnergy = character.totalCapEnergy();
			character.idleEnergy = character.curEnergy;
			if (character.arbitrary.instaTrain)
			{
				character.idleEnergy -= 12L;
				character.training.attackEnergy[0] += 6L;
				character.training.defenseEnergy[0] += 6L;
			}
			tooltip.showOverrideTooltip("All of your Energy had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.magic.curMagic > character.totalCapMagic())
		{
			character.removeAllMagic();
			character.magic.curMagic = character.totalCapMagic();
			character.magic.idleMagic = character.magic.curMagic;
			tooltip.showOverrideTooltip("All of your Magic had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.res3.res3On && character.res3.curRes3 > character.totalCapRes3())
		{
			character.removeAllRes3();
			character.res3.curRes3 = character.totalCapRes3();
			character.res3.idleRes3 = character.res3.curRes3;
			tooltip.showOverrideTooltip("All of your " + character.res3.res3Name + "  had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		character.introMenu.intro();
		tooltip.displayState();
		character.introMenu.intro();
	}

	public void ManualOnlineLoad()
	{
		if (character.platform == platform.Kong)
		{
			if (api.retrieveKongID() == 0)
			{
				tooltip.showOverrideTooltip("Sorry guest, you'll need a Kongregate Account to be able to use online saves. I can't tell you guys apart otherwise. Please, forgive me :C.");
				return;
			}
			if (manualOnlineLoadTime.totalseconds < (double)manualLoadTime())
			{
				tooltip.showOverrideTooltip("You need to wait <b>" + ((double)manualLoadTime() - manualOnlineLoadTime.totalseconds).ToString("##0") + "</b> seconds to load your online save!", 3f);
				return;
			}
			yesAction = engageOnlineLoad;
			noAction = cancel;
			box.displayBox("Are you sure you want to load your online file?", yesAction, noAction);
		}
		else if (character.platform == platform.AG)
		{
			if (character.AGAPI.AGID == "")
			{
				tooltip.showOverrideTooltip("Sorry guest, you'll need a Armour Games Account to be able to use online saves. I can't tell you guys apart otherwise. Please, forgive me :C.");
				return;
			}
			if (manualOnlineLoadTime.totalseconds < (double)manualLoadTime())
			{
				tooltip.showOverrideTooltip("You need to wait <b>" + ((double)manualLoadTime() - manualOnlineLoadTime.totalseconds).ToString("##0") + "</b> seconds to load your online save!", 3f);
				return;
			}
			yesAction = engageAGOnlineLoad;
			noAction = cancel;
			box.displayBox("Are you sure you want to load your online file?", yesAction, noAction);
		}
	}

	public string onlineSaveTimeRemaining()
	{
		return ((double)saveTime() - onlineSaveTime.totalseconds).ToString("###,##0");
	}

	public void beginOfflineProgress()
	{
	}

	public void startSaveAdvice()
	{
		InvokeRepeating("showSaveAdvice", 0f, 1f);
	}

	public void showSaveAdvice()
	{
		tooltip.showTooltip("Clicking this button will open a dialogue box to save your game. It's a good habit to make regular backups! You'll gain a <b>" + character.checkAPAdded(200L) + " AP bonus</b> when you save your game, once per day!\n\nTwo automated saves are written every 30 minutes named NGUBackup.txt and NGUBackup2.txt - they're in the same folder as the autosave!\n\nTime until next save AP reward: " + dailySaveTimeLeft());
	}

	public void showLoadAdvice()
	{
		tooltip.showTooltip("This will open a dialog to select a save file to load.");
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public void hideSaveAdvice()
	{
		CancelInvoke("showSaveAdvice");
		tooltip.hideTooltip();
	}

	public void startSaveStandalone()
	{
		if (character.platform == platform.Kartridge || character.platform == platform.Steam)
		{
			if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
			{
				character.settings.dailySaveRewardTime.reset();
				tooltip.showTooltip("You (tried) to manually save your file today! Here's " + character.addAP(200) + " AP as a bribe!", 3f);
			}
			PlayerPrefs.GetString("savedPath", Application.persistentDataPath);
			string text = StandaloneFileBrowser.SaveFilePanel("Save Yer Game", Application.persistentDataPath, "NGUSave-Build-" + character.getVersion() + "-" + DateTime.Now.ToString("MMMM-dd-HH-mm"), "txt");
			PlayerPrefs.SetString("savedPath", text);
			character.lastTime = Epoch.Current();
			string base64Data = importExport.getBase64Data();
			quickSave(base64Data, text);
		}
	}

	public void startLoadStandalone()
	{
		if (character.platform != platform.Kartridge && character.platform != platform.Steam)
		{
			return;
		}
		PlayerPrefs.GetString("savedPath", Application.persistentDataPath);
		string[] array = StandaloneFileBrowser.OpenFilePanel("Load Yer Game", Application.persistentDataPath, "txt", multiselect: false);
		if (array.Length == 0)
		{
			return;
		}
		PlayerPrefs.SetString("savedPath", array[0]);
		if (quickLoad(array[0]))
		{
			character.inventoryController.updateItemStats();
			character.inventoryController.updateBonuses();
			int t = Epoch.Current();
			int num = Epoch.SecondsElapsed(character.lastTime, t);
			if (num < 0)
			{
				num = 0;
			}
			character.addOfflineProgress(num);
			character.menuSwapper.swapMenu(0);
			character.inventoryController.updateItemStats();
			character.inventoryController.updateBonuses();
			character.adventureController.zoneSelector.changeZone(character.adventure.zone);
			character.adventureController.zoneDropdown.RefreshShownValue();
			character.buttons.updateButtons();
			tooltip.displayState();
			character.refreshMenus();
			if (character.curEnergy > character.totalCapEnergy())
			{
				character.removeAllEnergy();
				character.curEnergy = character.totalCapEnergy();
				character.idleEnergy = character.curEnergy;
				if (character.arbitrary.instaTrain)
				{
					character.idleEnergy -= 12L;
					character.training.attackEnergy[0] += 6L;
					character.training.defenseEnergy[0] += 6L;
				}
				tooltip.showOverrideTooltip("All of your Energy had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
			}
			if (character.magic.curMagic > character.totalCapMagic())
			{
				character.removeAllMagic();
				character.magic.curMagic = character.totalCapMagic();
				character.magic.idleMagic = character.magic.curMagic;
				tooltip.showOverrideTooltip("All of your Magic had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
			}
			if (character.res3.res3On && character.res3.curRes3 > character.totalCapRes3())
			{
				character.removeAllRes3();
				character.res3.curRes3 = character.totalCapRes3();
				character.res3.idleRes3 = character.res3.curRes3;
				tooltip.showOverrideTooltip("All of your " + character.res3.res3Name + "  had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
			}
			if (character.platform == platform.Kartridge && KartridgeBindings.KongregateAPI_IsReady())
			{
				string text = KartridgeBindings.KongregateServices_GetUsername();
				if (text == "")
				{
					text = "Bob";
				}
				character.playerName = text;
			}
		}
		else if (character.platform == platform.Kartridge)
		{
			tooltip.showOverrideTooltip("Error: File not recognised as an NGU save, or file is from a later build of NGU Idle. Check NGU Idle in your Kartridge Library to see if there's an update for the game!", 2f);
		}
		else
		{
			tooltip.showOverrideTooltip("Error: File not recognised as an NGU save, or file is from a later build of NGU Idle. Check if there's an update for the game!", 2f);
		}
		if (character.firstTimePlaying)
		{
			character.introMenu.intro();
		}
	}

	public string dailySaveTimeLeft()
	{
		if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
		{
			return "READY";
		}
		return NumberOutput.timeOutput(82800.0 - character.settings.dailySaveRewardTime.totalseconds);
	}

	public bool loadintoGame(SaveData saveData)
	{
		try
		{
			importExport.loadData(saveData);
		}
		catch (Exception ex)
		{
			tooltip.showOverrideTooltip("Issue loading initial file - crap. Error was:\n\n" + ex.Message, 3f);
			return false;
		}
		character.inventoryController.updateItemStats();
		character.inventoryController.updateBonuses();
		int t = Epoch.Current();
		int num = Epoch.SecondsElapsed(character.lastTime, t);
		if (num < 0)
		{
			num = 0;
		}
		if (num > 31536000)
		{
			num = 31536000;
		}
		if (num > 10)
		{
			character.addOfflineProgress(num);
		}
		character.menuSwapper.swapMenu(0);
		character.inventoryController.updateItemStats();
		character.inventoryController.updateBonuses();
		character.adventureController.zoneSelector.changeZone(character.adventure.zone);
		character.adventureController.zoneDropdown.RefreshShownValue();
		character.buttons.updateButtons();
		tooltip.displayState();
		character.refreshMenus();
		if (character.curEnergy > character.totalCapEnergy())
		{
			character.removeAllEnergy();
			character.curEnergy = character.totalCapEnergy();
			character.idleEnergy = character.curEnergy;
			if (character.arbitrary.instaTrain)
			{
				character.idleEnergy -= 12L;
				character.training.attackEnergy[0] += 6L;
				character.training.defenseEnergy[0] += 6L;
			}
			tooltip.showOverrideTooltip("All of your Energy had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.magic.curMagic > character.totalCapMagic())
		{
			character.removeAllMagic();
			character.magic.curMagic = character.totalCapMagic();
			character.magic.idleMagic = character.magic.curMagic;
			tooltip.showOverrideTooltip("All of your Magic had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.res3.res3On && character.res3.curRes3 > character.totalCapRes3())
		{
			character.removeAllRes3();
			character.res3.curRes3 = character.totalCapRes3();
			character.res3.idleRes3 = character.res3.curRes3;
			tooltip.showOverrideTooltip("All of your " + character.res3.res3Name + "  had to be unallocated due to a quirk in loading files between the browser-based and standalone versions.", 4f);
		}
		if (character.platform == platform.Kartridge && KartridgeBindings.KongregateAPI_IsReady())
		{
			string text = KartridgeBindings.KongregateServices_GetUsername();
			if (text == "")
			{
				text = "Bob";
			}
			character.playerName = text;
		}
		if (character.platform == platform.Steam)
		{
			character.steamAPI.setSteamNameOnFile();
		}
		return true;
	}

	public bool loadFileMainMenuStandalone()
	{
		if (character.platform != platform.Kartridge && character.platform != platform.Steam)
		{
			return false;
		}
		PlayerPrefs.GetString("savedPath", Application.persistentDataPath);
		string[] array = StandaloneFileBrowser.OpenFilePanel("Load Yer Game", Application.persistentDataPath, "txt", multiselect: false);
		if (array.Length == 0)
		{
			return false;
		}
		PlayerPrefs.SetString("savedPath", array[0]);
		string text = "";
		try
		{
			if (!File.Exists(array[0]))
			{
				tooltip.showOverrideTooltip("Issue fetching file from pc. Try a different file.", 3f);
				return false;
			}
			text = File.ReadAllText(array[0]);
		}
		catch (Exception)
		{
			tooltip.showOverrideTooltip("Error finding file - might be corrupted?", 3f);
			return false;
		}
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(text);
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				tooltip.showOverrideTooltip("File corrupt or from outdated version of game and can't be loaded, sorry :c", 3f);
				return false;
			}
			if (dataFromString.version > character.getVersion())
			{
				tooltip.showOverrideTooltip("The file you're trying to load is from a LATER build of the game - go to your Kartridge Library and update NGU! ", 3f);
				return false;
			}
			loadintoGame(saveDataFromString);
			return true;
		}
		catch (Exception)
		{
			tooltip.showOverrideTooltip("Error unpacking File - might be corrupted?", 3f);
			return false;
		}
	}

	public bool saveGamestateToSteamCloud()
	{
		try
		{
			string base64Data = importExport.getBase64Data();
			byte[] bytes = Encoding.UTF8.GetBytes(base64Data);
			character.steamAPI.writeToSteamCloud(bytes);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public void setCloudSaveSteam()
	{
		character.steamAPI.fetchSteamCloud();
	}

	public void setCloudSaveSteam(string base64SaveData)
	{
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(base64SaveData);
			PlayerData dataFromString = importExport.getDataFromString(base64SaveData);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				return;
			}
			if (dataFromString.version > character.getVersion())
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				return;
			}
			character.mainMenu.setCloudSave(saveDataFromString);
			character.mainMenu.setCloudPlayerData(dataFromString);
			character.mainMenu.setCloudSaveValidity(validity: true);
		}
		catch (Exception)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
		}
	}

	private IEnumerator LoadTextMainMenu(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error != null)
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("Hm, whatever you selected couldn't be loaded. Try a different file?", 3f);
			}
			character.mainMenu.finishBrowserFileLoad(success: false);
			yield break;
		}
		if (www.text == "")
		{
			if (!character.firstTimePlaying)
			{
				tooltip.showOverrideTooltip("File not found. No, really! Try a different file?", 3f);
			}
			character.mainMenu.finishBrowserFileLoad(success: false);
			yield break;
		}
		string text = www.text;
		try
		{
			SaveData saveDataFromString = importExport.getSaveDataFromString(text);
			PlayerData dataFromString = importExport.getDataFromString(text);
			if ((dataFromString == null || dataFromString.version < 361) && Application.platform != RuntimePlatform.WindowsEditor)
			{
				tooltip.showOverrideTooltip("File is from a very outdated version of NGU, sorry!", 3f);
				character.mainMenu.finishBrowserFileLoad(success: false);
			}
			else if (dataFromString.version > character.getVersion())
			{
				tooltip.showOverrideTooltip("File is from a future version of NGU. Try refreshing the page to update the game!", 3f);
				character.mainMenu.finishBrowserFileLoad(success: false);
			}
			else if (loadintoGame(saveDataFromString))
			{
				character.mainMenu.finishBrowserFileLoad(success: true);
			}
			else
			{
				character.mainMenu.finishBrowserFileLoad(success: false);
			}
		}
		catch (Exception)
		{
			character.mainMenu.finishBrowserFileLoad(success: false);
		}
	}
}
