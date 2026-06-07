using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dissonance;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StoreManager : NetworkBehaviour
{
	public bool demo;

	public Transform npcSpawnPoint;

	public Transform carSpawnPoint;

	public GameObject storeStats;

	public GameObject truckHolder;

	private Queue<string> hintQueue = new Queue<string>();

	public TextMeshProUGUI hintText;

	public GameObject hintCanv;

	public GameObject huntUI;

	public GameObject storeUI;

	public TextMeshProUGUI hygieneText;

	public TextMeshProUGUI stockText;

	public TextMeshProUGUI hygieneText2;

	public TextMeshProUGUI stockText2;

	public TextMeshProUGUI ratingText;

	public TextMeshProUGUI ratingText2;

	public TextMeshProUGUI ratingText3;

	public TextMeshProUGUI ratingText4;

	public Image ratingImage;

	public float hygiene;

	public float stock;

	public float storeRating;

	public StoreTravelPoints storePoints;

	public PlayerManager playerMan;

	private Vector3 playerLastPos;

	public bool inHunt;

	public GameObject storeLights;

	public GameObject hazardLights;

	public GameObject offLights;

	public Image volumeBar;

	public Image scentBar;

	public float volume;

	public GameObject goBackInsideWarning;

	public AudioMixer audioMixer;

	public GameObject huntObj;

	public HuntManager huntMan;

	public AudioSource huntAmbientMusic;

	public AudioSource huntChaseMusic;

	public bool beingChased;

	public int doppelsLetThru;

	public int diffusersActivated;

	public TextMeshProUGUI diffusersText;

	public List<PlayerManager> playerMans;

	public EggDiffuser[] diffusers;

	public AudioSource hoverAudio;

	public int examinationsRemaining = 5;

	public GameObject inconsistencyDetected;

	public GameObject consistencyDetected;

	public GameObject outOfQuestions;

	public GameObject huntExplanation;

	public GameObject huntExplanation2;

	public TextMeshProUGUI secondsLeftText;

	private int secondsLeft;

	public GameObject startBus;

	public Outline[] ventOutlines;

	public TextMeshProUGUI explanationText;

	public TextMeshProUGUI tokenBalanceText;

	public Interactable purchaseTokenBTN;

	public GameObject[] allCoins;

	public Outline vendingOutline;

	public Transform bearTrapTemplate;

	public Transform bearTrapTemplateRed;

	public Transform landmineTemplate;

	public Transform landmineTemplateRed;

	public Transform stunMineTemplate;

	public Transform stunMineTemplateRed;

	public Transform explosiveTemplate;

	public Transform explosiveTemplateRed;

	public Transform posterTemplate;

	public Transform pottedPlantTemplate;

	public Transform pottedPlantTemplateRed;

	public Transform waterCoolerTemplate;

	public Transform waterCoolerTemplateRed;

	public Transform basketRackTemplate;

	public Transform basketRackTemplateRed;

	public Transform atmTemplate;

	public Transform atmTemplateRed;

	public Transform mailboxTemplate;

	public Transform mailboxTemplateRed;

	public Transform trashCanTemplate;

	public Transform trashCanTemplateRed;

	public Transform bannerTemplate;

	public Transform bannerTemplateRed;

	public Transform floorMatTemplate;

	public Transform floorMatTemplateRed;

	public Transform sunglassesRackTemplate;

	public Transform sunglassesRackTemplateRed;

	public Transform booksTemplate;

	public Transform booksTemplateRed;

	public Transform bobbleHeadTemplate;

	public Transform bobbleHeadTemplateRed;

	public Transform burgerTemplate;

	public Transform burgerTemplateRed;

	public Transform plant1Template;

	public Transform plant1TemplateRed;

	public Transform plant2Template;

	public Transform plant2TemplateRed;

	public Transform plant3Template;

	public Transform plant3TemplateRed;

	public Transform plant4Template;

	public Transform plant4TemplateRed;

	public Transform robotTemplate;

	public Transform robotTemplateRed;

	public Transform boomboxTemplate;

	public Transform boomboxTemplateRed;

	public Transform gumballTemplate;

	public Transform gumballTemplateRed;

	public Transform clockTemplate;

	public Transform clockTemplateRed;

	public Transform ivyTemplate;

	public Transform ivyTemplateRed;

	public Transform stringLightsTemplate;

	public Transform stringLightsTemplateRed;

	public Transform painting1Template;

	public Transform painting1TemplateRed;

	public Transform painting2Template;

	public Transform painting2TemplateRed;

	public Transform painting3Template;

	public Transform painting3TemplateRed;

	public Transform deerTemplate;

	public Transform deerTemplateRed;

	private bool alreadyCompleted;

	public int amountOfCompletions;

	public GameObject minusTimeObj;

	public TextMeshProUGUI minusTimeText;

	public TextMeshProUGUI timeChangeText;

	public float quota = 50f;

	public float showingRevenue;

	public float actualRevenue;

	public TextMeshProUGUI revenueText;

	public TextMeshProUGUI addRevenueText;

	public TextMeshProUGUI minusRevenueText;

	public PlayAudioArray moneyAudioArray;

	public GameObject day1Obj;

	public GameObject[] dayObjs;

	public Transform[] aimlessPatrolPoints;

	public GameObject canvas;

	public GameObject dialogueTutorialCanv;

	public float questionCooldown;

	public float maxQuestionCooldown;

	public GameObject dumpster;

	public Outline dumpsterOutline;

	public DissonanceComms comms;

	public List<string> dissonanceIds;

	public List<string> steamIds;

	public GameObject rToReload;

	public GameObject noMoreAmmo;

	public Transform gasPumpOrigin;

	public GameObject standFurtherBackWarning;

	public Outline flashlightOutline;

	public Animator flashlightOutlineAnim;

	public int flashlightsOnAmount;

	public TextMeshProUGUI mandatoryRevenueText;

	public ToggleInMultiplayer[] multiplayerToggleScripts;

	public GameObject poster;

	public Transform posterSpawnPos;

	public bool todayWasSetDayObj;

	private bool everyoneCompleted;

	private bool alreadyStarted;

	public Color greenColor;

	public Color redColor;

	public Color goldColor;

	public TextMeshProUGUI alertText;

	public Image alertBG;

	public AudioSource alertErrorAudio;

	public AudioSource alertSuccessAudio;

	public AudioSource alertGoldAudio;

	public GameObject alertObj;

	public GameObject forestGate;

	public GameObject[] openForestGates;

	public Transform inStoreTP;

	public bool huntHappened;

	public bool alreadyEndedHuntToday;

	public GameObject objectiveCanvas;

	public TextMeshProUGUI objectiveText;

	public TextMeshProUGUI amountToLookAtObjectiveText;

	private bool alreadyDone;

	public Hittable frontDoorBarricade;

	public GameObject coin;

	public GameObject[] pickupObjs;

	public GameObject[] thrownObjs;

	public GameObject cctvCam;

	public Volume globalVolume;

	public VolumeProfile normalProfile;

	public static StoreManager Instance { get; private set; }

	public void FlashlightToggled(int change)
	{
		if (base.isServer)
		{
			FlashlightToggledRpc(change);
		}
		else
		{
			FlashlightToggledCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	private void FlashlightToggledCmd(int change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(change);
		SendCommandInternal("System.Void StoreManager::FlashlightToggledCmd(System.Int32)", 825526884, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void FlashlightToggledRpc(int change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(change);
		SendRPCInternal("System.Void StoreManager::FlashlightToggledRpc(System.Int32)", -371933349, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ToggleMultiplayerObjects()
	{
		if (!base.isServer)
		{
			ToggleMultiplayerObjectsCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void ToggleMultiplayerObjectsCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreManager::ToggleMultiplayerObjectsCmd()", 2009489567, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ToggleMultiplayerObjectsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::ToggleMultiplayerObjectsRpc()", 1115284812, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Invoke("LoadAllPlayerMans", 1f);
		Instance = this;
	}

	private void StartHuntNoMatterWhat()
	{
		doppelsLetThru = 3;
		CheckForHunt();
	}

	public void AddDissonanceDictionary(string dissonanceId, string steamId)
	{
		if (base.isServer)
		{
			AddDissonanceDictionaryRpc(dissonanceId, steamId);
		}
		else
		{
			AddDissonanceDictionaryCmd(dissonanceId, steamId);
		}
	}

	[Command(requiresAuthority = false)]
	private void AddDissonanceDictionaryCmd(string dissonanceId, string steamId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(dissonanceId);
		writer.WriteString(steamId);
		SendCommandInternal("System.Void StoreManager::AddDissonanceDictionaryCmd(System.String,System.String)", -5834949, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AddDissonanceDictionaryRpc(string dissonanceId, string steamId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(dissonanceId);
		writer.WriteString(steamId);
		SendRPCInternal("System.Void StoreManager::AddDissonanceDictionaryRpc(System.String,System.String)", -1835585514, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateDissonanceDictionaryToClients(List<string> dissonanceList, List<string> steamList)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, dissonanceList);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, steamList);
		SendRPCInternal("System.Void StoreManager::UpdateDissonanceDictionaryToClients(System.Collections.Generic.List`1<System.String>,System.Collections.Generic.List`1<System.String>)", 1292774476, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnPoster()
	{
		if (base.isServer)
		{
			NetworkServer.Spawn(Object.Instantiate(poster, posterSpawnPos.position, posterSpawnPos.rotation));
		}
	}

	[ClientRpc]
	public void DisableDumpsterMonster()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::DisableDumpsterMonster()", -1355767409, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void DestroyTutorialStuff()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::DestroyTutorialStuff()", -90380139, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void UpdateCurDayOnAllClients(int curDay_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(curDay_);
		SendRPCInternal("System.Void StoreManager::UpdateCurDayOnAllClients(System.Int32)", 2127445983, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ResetQuestionCooldown()
	{
		switch (GameObject.FindGameObjectsWithTag("Player").Length)
		{
		case 0:
			questionCooldown = 0f;
			maxQuestionCooldown = 0f;
			break;
		case 1:
			questionCooldown = 0f;
			maxQuestionCooldown = 0f;
			break;
		case 2:
			questionCooldown = 5f;
			maxQuestionCooldown = 5f;
			break;
		case 3:
			questionCooldown = 10f;
			maxQuestionCooldown = 10f;
			break;
		case 4:
			questionCooldown = 15f;
			maxQuestionCooldown = 15f;
			break;
		default:
			questionCooldown = 20f;
			maxQuestionCooldown = 20f;
			break;
		}
	}

	public void ChangeRevenue(string text, float money)
	{
		if (base.isServer)
		{
			ChangeRevenueRpc(text, money);
		}
		else
		{
			ChangeRevenueCmd(text, money);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeRevenueCmd(string text, float money)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(text);
		writer.WriteFloat(money);
		SendCommandInternal("System.Void StoreManager::ChangeRevenueCmd(System.String,System.Single)", 1141811976, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeRevenueRpc(string text, float money)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(text);
		writer.WriteFloat(money);
		SendRPCInternal("System.Void StoreManager::ChangeRevenueRpc(System.String,System.Single)", -301554903, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void CollectRatObjective()
	{
		if (base.isServer)
		{
			ChangeRevenue("Rat Catching Bonus", 25f);
		}
	}

	public void CollectRoachObjective()
	{
		if (base.isServer)
		{
			ChangeRevenue("Roach Killing Bonus", 25f);
		}
	}

	public void ThiefCaught()
	{
		ChangeRevenue("Items Returned", 10f);
	}

	public static string FormatTime(int totalSeconds)
	{
		int num = totalSeconds / 60;
		int num2 = totalSeconds % 60;
		return $"{num:D2}:{num2:D2}";
	}

	public void CompleteDay()
	{
		if (!alreadyCompleted)
		{
			alreadyCompleted = true;
			if (base.isServer)
			{
				Invoke("AnotherPlayerCompletedRpc", 0.5f);
				InvokeRepeating("CheckWhosCompletedDay", 1f, 1f);
			}
			else
			{
				Invoke("AnotherPlayerCompletedCmd", 0.5f);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void AnotherPlayerCompletedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreManager::AnotherPlayerCompletedCmd()", -1634492914, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AnotherPlayerCompletedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::AnotherPlayerCompletedRpc()", -970036207, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void LoadAllPlayerNames()
	{
		foreach (PlayerManager playerMan in playerMans)
		{
			playerMan.LoadPlayerName();
		}
	}

	private void CheckWhosCompletedDay()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		new List<GameObject>();
		if (amountOfCompletions >= array.Length && !everyoneCompleted)
		{
			everyoneCompleted = true;
			SaveManager.Instance.money -= EODReportValues.Instance.todayMoneyLost;
			SaveManager.Instance.npcsKilled.AddRange(SaveManager.Instance.npcsKilledTemp);
			if (!todayWasSetDayObj)
			{
				SaveManager.Instance.dayObjsSpawnedBefore.Add(EODReportValues.Instance.todaysDayObjIndex);
			}
			foreach (Npc todaysNpc in CurrentDayManager.Instance.todaysNpcs)
			{
				SaveManager.Instance.spawnedBefore.Add(todaysNpc.id);
			}
			if (!huntHappened)
			{
				SaveManager.Instance.curDifficulty++;
			}
			SaveManager.Instance.curDay++;
			if (demo)
			{
				if (CurrentDayManager.Instance.curDay < 3)
				{
					SaveManager.Instance.Save();
				}
			}
			else
			{
				SaveManager.Instance.Save();
			}
			CancelInvoke();
			Invoke("EODScene", 0.5f);
		}
		amountToLookAtObjectiveText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountToLookAtObjectiveText.text = amountOfCompletions + " / " + array.Length;
	}

	public void EnterCutscene(bool disablePlayerMan = true)
	{
		SpeakingManager.Instance.enabled = false;
		ClientPlayer.Instance.fpsScript.lockCam = true;
		ClientPlayer.Instance.fpsScript.lockMove = true;
		ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = false;
		ClientPlayer.Instance.playerMan.interactMan.enabled = false;
		ClientPlayer.Instance.playerMan.canPause = false;
		if (disablePlayerMan)
		{
			ClientPlayer.Instance.playerMan.enabled = false;
		}
		ClientPlayer.Instance.inventoryMan.PauseInventory();
		ClientPlayer.Instance.inventoryMan.enabled = false;
		ClientPlayer.Instance.inventoryMan.canControlItem = false;
	}

	public void ExitCutscene()
	{
		SpeakingManager.Instance.enabled = true;
		ClientPlayer.Instance.fpsScript.lockCam = false;
		ClientPlayer.Instance.fpsScript.lockMove = false;
		ClientPlayer.Instance.fpsScript.enabled = true;
		ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = true;
		ClientPlayer.Instance.playerMan.interactMan.enabled = true;
		ClientPlayer.Instance.playerMan.canPause = true;
		ClientPlayer.Instance.playerMan.enabled = true;
		ClientPlayer.Instance.inventoryMan.UnpauseInventory();
		ClientPlayer.Instance.inventoryMan.enabled = true;
		ClientPlayer.Instance.inventoryMan.canControlItem = true;
	}

	public void EODScene()
	{
		if (base.isServer)
		{
			NetworkManager.singleton.ServerChangeScene("EODReport");
		}
	}

	public void LoadAllPlayerMans()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GetAllPlayerMansRpc();
		}
		else
		{
			GetAllPlayerMansCmd();
		}
		Invoke("LoadAllPlayerNames", 1f);
	}

	[Command(requiresAuthority = false)]
	private void GetAllPlayerMansCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreManager::GetAllPlayerMansCmd()", 1492654074, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void GetAllPlayerMansRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::GetAllPlayerMansRpc()", 450183469, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChangeTokenBalance(int change)
	{
		if (base.isServer)
		{
			ChangeTokenBalanceRpc(change);
		}
		else
		{
			ChangeTokenBalanceCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeTokenBalanceCmd(int change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(change);
		SendCommandInternal("System.Void StoreManager::ChangeTokenBalanceCmd(System.Int32)", -1909132281, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeTokenBalanceRpc(int change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(change);
		SendRPCInternal("System.Void StoreManager::ChangeTokenBalanceRpc(System.Int32)", -1708323692, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SetTokenBalanceRpc_(int tokens_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(tokens_);
		SendRPCInternal("System.Void StoreManager::SetTokenBalanceRpc_(System.Int32)", 755760193, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SetExaminationsRemaining(int amount)
	{
		examinationsRemaining = 1000;
	}

	[Command(requiresAuthority = false)]
	private void SetExaminationsRemainingCmd(int amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void StoreManager::SetExaminationsRemainingCmd(System.Int32)", 919846512, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SetExaminationsRemainingRpc(int amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		SendRPCInternal("System.Void StoreManager::SetExaminationsRemainingRpc(System.Int32)", -361440761, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Start_()
	{
		Invoke("LoadAllPlayerMans", 1f);
		dumpsterOutline = dumpster.GetComponent<Outline>();
		AmbientMusicSystem.Instance.inHunt = false;
		AstarPath.Instance.Invoke("Scan", 3f);
		AstarPath.Instance.Invoke("Scan", 10f);
		if (alreadyStarted)
		{
			return;
		}
		alreadyStarted = true;
		RedoCoins();
		SetExaminationsRemaining(5);
		audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20f);
		playerMan = ClientPlayer.Instance.playerMan;
		RestockShelf[] restockShelves = Shelves.Instance.restockShelves;
		foreach (RestockShelf restockShelf in restockShelves)
		{
			if ((bool)restockShelf)
			{
				restockShelf.Start_();
			}
		}
		PurchaseManager.Instance.Invoke("LoadTotalBalance", 3f);
		PurchaseManager.Instance.Invoke("GenerateShopNodes", 5f);
		Invoke("CheckQuotaNote", 1f);
		GameObject gameObject = GameObject.FindWithTag("NPC");
		if ((bool)gameObject && (bool)gameObject.GetComponent<StoreBrowseBehaviour>())
		{
			gameObject.GetComponent<StoreBrowseBehaviour>().enabled = true;
		}
	}

	public void SetAlert(string key, string color)
	{
		alertText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		alertText.text = JSONAccess.Instance.GetMiscText("Notifications", key);
		alertObj.SetActive(value: false);
		alertObj.SetActive(value: true);
		switch (color)
		{
		case "green":
			alertBG.color = greenColor;
			alertSuccessAudio.Play();
			break;
		case "red":
			alertBG.color = redColor;
			alertErrorAudio.Play();
			break;
		case "gold":
			alertBG.color = goldColor;
			alertGoldAudio.Play();
			break;
		}
	}

	public void DiffuserActivated()
	{
	}

	public void ActivateVentOutlines()
	{
		if (inHunt)
		{
			Outline[] array = ventOutlines;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
		}
	}

	public void DeactivateVentOutlines()
	{
		Outline[] array = ventOutlines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
	}

	public void StartHazardLights()
	{
		if (base.isServer)
		{
			StartHazardLightsRpc();
		}
		else
		{
			StartHazardLightsCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void StartHazardLightsCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreManager::StartHazardLightsCmd()", -1882131520, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void StartHazardLightsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::StartHazardLightsRpc()", -766277193, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void StartCountingDown()
	{
		Invoke("StartHunt", 59f);
		for (int i = 0; i < 61; i++)
		{
			Invoke("CountDownSeconds", i);
		}
	}

	private void CountDownSeconds()
	{
		secondsLeft--;
		secondsLeftText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		secondsLeftText.text = secondsLeft + " " + JSONAccess.Instance.GetMiscText("UI Text 3", "SECONDS");
	}

	private void HazardLightsHint()
	{
		if (PlayerPrefs.GetInt("Day2") == 1)
		{
			huntExplanation.SetActive(value: true);
		}
		else
		{
			huntExplanation.SetActive(value: true);
		}
	}

	public void HuntObjective()
	{
		NewObjective("Objectives", "Hunt Objective");
	}

	public void StartHunt()
	{
		AmbientMusicSystem.Instance.inHunt = true;
		FinishObjective();
		huntMan.StartHunt();
		inHunt = true;
		hazardLights.SetActive(value: false);
		offLights.SetActive(value: true);
		AddHint("<CROUCH BIND> to crouch");
		NextHint();
		PlayerPrefs.SetInt("BreachOccurred", 1);
		storeUI.SetActive(value: false);
		huntUI.SetActive(value: true);
		ActivateVentOutlines();
		foreach (PlayerManager playerMan in playerMans)
		{
			playerMan.ChangeHuntLight(on: true);
		}
	}

	public void EndHunt()
	{
		if (base.isServer)
		{
			EndHuntRpc();
		}
		else
		{
			EndHuntCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void EndHuntCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreManager::EndHuntCmd()", 980833899, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EndHuntRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::EndHuntRpc()", 31311336, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void BreachCompensation()
	{
		ChangeRevenue("Breach Compensation", 1f);
	}

	private void FixedUpdate()
	{
		if (questionCooldown > -1f)
		{
			questionCooldown -= Time.deltaTime;
		}
		if (inHunt)
		{
			if (beingChased)
			{
				huntAmbientMusic.volume = Mathf.Lerp(huntAmbientMusic.volume, 0f, Time.deltaTime * 0.5f);
				huntChaseMusic.volume = Mathf.Lerp(huntChaseMusic.volume, 0.3f, Time.deltaTime * 0.5f);
			}
			else
			{
				huntAmbientMusic.volume = Mathf.Lerp(huntAmbientMusic.volume, 0.3f, Time.deltaTime * 0.2f);
				huntChaseMusic.volume = Mathf.Lerp(huntChaseMusic.volume, 0f, Time.deltaTime * 0.2f);
			}
		}
		else
		{
			huntAmbientMusic.volume = Mathf.Lerp(huntAmbientMusic.volume, 0f, Time.deltaTime);
			huntChaseMusic.volume = Mathf.Lerp(huntChaseMusic.volume, 0f, Time.deltaTime);
		}
		if (showingRevenue < actualRevenue)
		{
			if (actualRevenue - showingRevenue > 1f)
			{
				showingRevenue += 1f;
				revenueText.color = Color.green;
			}
			else
			{
				showingRevenue = actualRevenue;
				revenueText.color = Color.white;
			}
			moneyAudioArray.PlayAudio();
			revenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			revenueText.text = "$" + showingRevenue.ToString("0.00");
		}
		else if (showingRevenue > actualRevenue)
		{
			if (showingRevenue - actualRevenue > 1f)
			{
				showingRevenue -= 1f;
				revenueText.color = Color.red;
			}
			else
			{
				showingRevenue = actualRevenue;
				revenueText.color = Color.white;
			}
			moneyAudioArray.PlayAudio();
			revenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			revenueText.text = "$" + showingRevenue.ToString("0.00");
		}
		volumeBar.fillAmount = Mathf.Lerp(volumeBar.fillAmount, volume / 1f, Time.deltaTime * 4f);
		if (ClientPlayer.Instance.playerMan.downed)
		{
			volumeBar.fillAmount = 0f;
		}
		if (volumeBar.fillAmount < 0.5f)
		{
			volumeBar.color = Color.white;
		}
		if (volumeBar.fillAmount < 0.66f)
		{
			volumeBar.color = Color.yellow;
		}
		else
		{
			volumeBar.color = Color.red;
		}
		if (scentBar.fillAmount < 0.3f)
		{
			scentBar.color = Color.white;
		}
		if (scentBar.fillAmount < 0.66f)
		{
			scentBar.color = Color.yellow;
		}
		else
		{
			scentBar.color = Color.red;
		}
	}

	public void CheckForHunt()
	{
		if (doppelsLetThru == 0)
		{
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 0.5f);
		}
		else
		{
			Invoke("StartHazardLights", 1f);
		}
	}

	public void NewObjective(string id, string key)
	{
		amountToLookAtObjectiveText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountToLookAtObjectiveText.text = "";
		objectiveCanvas.SetActive(value: false);
		objectiveCanvas.SetActive(value: true);
		objectiveText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		objectiveText.text = JSONAccess.Instance.GetMiscText(id, key);
		StartCoroutine(RevealObjectiveText());
	}

	public void FinishObjective()
	{
		objectiveCanvas.SetActive(value: false);
	}

	private IEnumerator RevealObjectiveText()
	{
		if (alreadyDone)
		{
			yield break;
		}
		objectiveText.ForceMeshUpdate();
		int totalVisibleCharacters = objectiveText.textInfo.characterCount;
		int counter = 0;
		yield return new WaitForSeconds(0.5f);
		while (true)
		{
			int num = counter % (totalVisibleCharacters + 1);
			objectiveText.maxVisibleCharacters = num;
			if (num >= totalVisibleCharacters)
			{
				break;
			}
			counter++;
			yield return new WaitForSeconds(0.03f);
		}
	}

	public void AddHint(string hintId)
	{
		hintQueue.Enqueue(JSONAccess.Instance.GetMiscText("Hints", hintId));
	}

	public void DestroyFrontBarricade()
	{
		if (frontDoorBarricade.gameObject.activeInHierarchy)
		{
			frontDoorBarricade.Hit(500f, base.transform.position);
		}
	}

	public void NextHint()
	{
		if (hintQueue.Count == 0)
		{
			hintCanv.SetActive(value: false);
			return;
		}
		CancelInvoke("NextHint");
		hintCanv.SetActive(value: false);
		hintCanv.SetActive(value: true);
		hintText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		hintText.text = hintQueue.Dequeue();
		Invoke("NextHint", 6f);
	}

	public void RedoCoins()
	{
		if (!base.isServer)
		{
			return;
		}
		List<int> list = new List<int>();
		for (int i = 0; i <= 70; i++)
		{
			list.Add(i);
		}
		for (int num = list.Count - 1; num > 0; num--)
		{
			int index = Random.Range(0, num + 1);
			int value = list[num];
			list[num] = list[index];
			list[index] = value;
		}
		foreach (int item in list.GetRange(0, 20))
		{
			NetworkServer.Spawn(Object.Instantiate(coin, allCoins[item].transform.position, Quaternion.identity));
		}
	}

	public void TriggerNextEvent()
	{
		CurrentDayManager.Instance.Invoke("CompleteOccurrence", 0.5f);
	}

	[Command(requiresAuthority = false)]
	public void NetworkDropObject(int holdingIndex, Vector3 throwPosition, Quaternion rotation, int crateStorage, Vector3 playerForward, InventoryManager inventoryMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(holdingIndex);
		writer.WriteVector3(throwPosition);
		writer.WriteQuaternion(rotation);
		writer.WriteVarInt(crateStorage);
		writer.WriteVector3(playerForward);
		writer.WriteNetworkBehaviour(inventoryMan);
		SendCommandInternal("System.Void StoreManager::NetworkDropObject(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion,System.Int32,UnityEngine.Vector3,InventoryManager)", 182707303, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ServerDropObject(int holdingIndex, Vector3 throwPosition, Quaternion rotation, int crateStorage, Vector3 playerForward, InventoryManager inventoryMan)
	{
		if (base.isServer)
		{
			GameObject gameObject = Object.Instantiate(pickupObjs[holdingIndex], throwPosition, rotation);
			NetworkServer.Spawn(gameObject);
			gameObject.GetComponent<PickupObject>().ChangeAmountOfItems(crateStorage);
			gameObject.GetComponent<Rigidbody>().velocity = playerForward * 5f;
			inventoryMan.IgnoreCollision(inventoryMan.gameObject, gameObject);
		}
	}

	[Command(requiresAuthority = false)]
	public void NetworkThrowObject(int holdingIndex, Vector3 throwPosition, Quaternion rotation, Vector3 playerForward, GameObject charController, float throwForceX)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(holdingIndex);
		writer.WriteVector3(throwPosition);
		writer.WriteQuaternion(rotation);
		writer.WriteVector3(playerForward);
		writer.WriteGameObject(charController);
		writer.WriteFloat(throwForceX);
		SendCommandInternal("System.Void StoreManager::NetworkThrowObject(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,UnityEngine.GameObject,System.Single)", 2102427967, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ServerThrowObject(int holdingIndex, Vector3 throwPosition, Quaternion rotation, Vector3 playerForward, GameObject charController, float throwForceX)
	{
		GameObject obj = Object.Instantiate(thrownObjs[holdingIndex], throwPosition, rotation);
		obj.GetComponent<ThrownObject>().SetPlayerManThrowing(charController);
		NetworkServer.Spawn(obj);
		obj.GetComponent<Rigidbody>().velocity = playerForward * throwForceX;
		obj.GetComponent<Rigidbody>().velocity += base.transform.up * (throwForceX / 10f);
	}

	public void CheckAllRemoteTraps()
	{
		if (base.isServer)
		{
			CheckAllRemoteTrapsRpc();
		}
		else
		{
			CheckAllRemoteTrapsCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void CheckAllRemoteTrapsCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreManager::CheckAllRemoteTrapsCmd()", 821767678, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CheckAllRemoteTrapsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreManager::CheckAllRemoteTrapsRpc()", -1843983871, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void BackToPlayer()
	{
		cctvCam = GameObject.FindWithTag("CCTV").transform.GetChild(0).gameObject;
		List<Volume> list = (from v in Object.FindObjectsOfType<Volume>(includeInactive: true)
			where v.isGlobal
			orderby v.priority descending
			select v).ToList();
		globalVolume = list[0];
		globalVolume.profile = Object.Instantiate(normalProfile);
		ClientPlayer.Instance.inventoryMan.UnpauseInventory();
		ClientPlayer.Instance.playerMan.canPause = true;
		ClientPlayer.Instance.inventoryMan.canControlItem = true;
		ClientPlayer.Instance.fpsScript.lockMove = false;
		ClientPlayer.Instance.fpsScript.lockCam = false;
		cctvCam.SetActive(value: false);
		ClientPlayer.Instance.playerMan.canvas.SetActive(value: true);
		Instance.canvas.SetActive(value: true);
		SpeakingManager.Instance.enabled = true;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_FlashlightToggledCmd__Int32(int change)
	{
		FlashlightToggledRpc(change);
	}

	protected static void InvokeUserCode_FlashlightToggledCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command FlashlightToggledCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_FlashlightToggledCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_FlashlightToggledRpc__Int32(int change)
	{
		flashlightsOnAmount += change;
		GameObject[] array = GameObject.FindGameObjectsWithTag("FlashlightVisible");
		if (flashlightsOnAmount > 0)
		{
			GameObject[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].GetComponent<FlashlightVisible>().FlashlightEnabled();
			}
		}
		else
		{
			GameObject[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].GetComponent<FlashlightVisible>().FlashlightDisabled();
			}
		}
	}

	protected static void InvokeUserCode_FlashlightToggledRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC FlashlightToggledRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_FlashlightToggledRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ToggleMultiplayerObjectsCmd()
	{
		ToggleMultiplayerObjectsRpc();
	}

	protected static void InvokeUserCode_ToggleMultiplayerObjectsCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ToggleMultiplayerObjectsCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_ToggleMultiplayerObjectsCmd();
		}
	}

	protected void UserCode_ToggleMultiplayerObjectsRpc()
	{
		ToggleInMultiplayer[] array = multiplayerToggleScripts;
		foreach (ToggleInMultiplayer toggleInMultiplayer in array)
		{
			if ((bool)toggleInMultiplayer)
			{
				toggleInMultiplayer.SetMultiplayer();
			}
		}
	}

	protected static void InvokeUserCode_ToggleMultiplayerObjectsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ToggleMultiplayerObjectsRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_ToggleMultiplayerObjectsRpc();
		}
	}

	protected void UserCode_AddDissonanceDictionaryCmd__String__String(string dissonanceId, string steamId)
	{
		AddDissonanceDictionaryRpc(dissonanceId, steamId);
	}

	protected static void InvokeUserCode_AddDissonanceDictionaryCmd__String__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AddDissonanceDictionaryCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_AddDissonanceDictionaryCmd__String__String(reader.ReadString(), reader.ReadString());
		}
	}

	protected void UserCode_AddDissonanceDictionaryRpc__String__String(string dissonanceId, string steamId)
	{
		dissonanceIds.Add(dissonanceId);
		steamIds.Add(steamId);
		if (base.isServer)
		{
			UpdateDissonanceDictionaryToClients(dissonanceIds, steamIds);
		}
	}

	protected static void InvokeUserCode_AddDissonanceDictionaryRpc__String__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AddDissonanceDictionaryRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_AddDissonanceDictionaryRpc__String__String(reader.ReadString(), reader.ReadString());
		}
	}

	protected void UserCode_UpdateDissonanceDictionaryToClients__List_00601__List_00601(List<string> dissonanceList, List<string> steamList)
	{
		if (!base.isServer)
		{
			dissonanceIds = dissonanceList;
			steamIds = steamList;
		}
	}

	protected static void InvokeUserCode_UpdateDissonanceDictionaryToClients__List_00601__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateDissonanceDictionaryToClients called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_UpdateDissonanceDictionaryToClients__List_00601__List_00601(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader));
		}
	}

	protected void UserCode_DisableDumpsterMonster()
	{
		DumpsterMonster.Instance.gameObject.SetActive(value: false);
	}

	protected static void InvokeUserCode_DisableDumpsterMonster(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DisableDumpsterMonster called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_DisableDumpsterMonster();
		}
	}

	protected void UserCode_DestroyTutorialStuff()
	{
		TutorialManager.Instance.tutorialObjects.SetActive(value: false);
		TutorialManager.Instance.alreadyDone = true;
		DialogueTutorialManager.Instance.alreadyDone = true;
		TransactionManager.Instance.canTransact = true;
		Object.Destroy(TutorialManager.Instance.gameObject, 2f);
	}

	protected static void InvokeUserCode_DestroyTutorialStuff(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DestroyTutorialStuff called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_DestroyTutorialStuff();
		}
	}

	protected void UserCode_UpdateCurDayOnAllClients__Int32(int curDay_)
	{
		SaveManager.Instance.curDay = curDay_;
	}

	protected static void InvokeUserCode_UpdateCurDayOnAllClients__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateCurDayOnAllClients called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_UpdateCurDayOnAllClients__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ChangeRevenueCmd__String__Single(string text, float money)
	{
		ChangeRevenueRpc(text, money);
	}

	protected static void InvokeUserCode_ChangeRevenueCmd__String__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeRevenueCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_ChangeRevenueCmd__String__Single(reader.ReadString(), reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeRevenueRpc__String__Single(string text, float money)
	{
		if (money < 0f)
		{
			if (text == "Human Killed")
			{
				EODReportValues.Instance.todayMoneyLost += Mathf.Abs(money);
				return;
			}
			minusRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			minusRevenueText.text = JSONAccess.Instance.GetMiscText("Revenue Changes", text) + " -$" + Mathf.Abs(money).ToString("0.00");
			minusRevenueText.gameObject.SetActive(value: false);
			minusRevenueText.gameObject.SetActive(value: true);
			PurchaseManager.Instance.LoadTotalBalance();
			actualRevenue += money;
			EODReportValues.Instance.todayMoneyGained = actualRevenue;
			SaveManager.Instance.money += money;
		}
		else
		{
			SaveManager.Instance.money += money;
			addRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			addRevenueText.text = JSONAccess.Instance.GetMiscText("Revenue Changes", text) + " +$" + Mathf.Abs(money).ToString("0.00");
			addRevenueText.gameObject.SetActive(value: false);
			addRevenueText.gameObject.SetActive(value: true);
			actualRevenue += money;
			EODReportValues.Instance.todayMoneyGained = actualRevenue;
			PurchaseManager.Instance.LoadTotalBalance();
		}
	}

	protected static void InvokeUserCode_ChangeRevenueRpc__String__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeRevenueRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_ChangeRevenueRpc__String__Single(reader.ReadString(), reader.ReadFloat());
		}
	}

	protected void UserCode_AnotherPlayerCompletedCmd()
	{
		AnotherPlayerCompletedRpc();
	}

	protected static void InvokeUserCode_AnotherPlayerCompletedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AnotherPlayerCompletedCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_AnotherPlayerCompletedCmd();
		}
	}

	protected void UserCode_AnotherPlayerCompletedRpc()
	{
		amountOfCompletions++;
		InvokeRepeating("CheckWhosCompletedDay", 0.1f, 1f);
	}

	protected static void InvokeUserCode_AnotherPlayerCompletedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AnotherPlayerCompletedRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_AnotherPlayerCompletedRpc();
		}
	}

	protected void UserCode_GetAllPlayerMansCmd()
	{
		GetAllPlayerMansRpc();
	}

	protected static void InvokeUserCode_GetAllPlayerMansCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GetAllPlayerMansCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_GetAllPlayerMansCmd();
		}
	}

	protected void UserCode_GetAllPlayerMansRpc()
	{
		playerMans.Clear();
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject gameObject in array)
		{
			playerMans.Add(gameObject.GetComponent<PlayerManager>());
			gameObject.GetComponent<PlayerManager>().thirdPersonMan.UpdateHat();
		}
	}

	protected static void InvokeUserCode_GetAllPlayerMansRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GetAllPlayerMansRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_GetAllPlayerMansRpc();
		}
	}

	protected void UserCode_ChangeTokenBalanceCmd__Int32(int change)
	{
		ChangeTokenBalanceRpc(change);
	}

	protected static void InvokeUserCode_ChangeTokenBalanceCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeTokenBalanceCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_ChangeTokenBalanceCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ChangeTokenBalanceRpc__Int32(int change)
	{
		if (base.isServer)
		{
			SaveManager.Instance.tokens += change;
			SetTokenBalanceRpc_(SaveManager.Instance.tokens);
		}
	}

	protected static void InvokeUserCode_ChangeTokenBalanceRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeTokenBalanceRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_ChangeTokenBalanceRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetTokenBalanceRpc___Int32(int tokens_)
	{
		SaveManager.Instance.tokens = tokens_;
		tokenBalanceText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		tokenBalanceText.text = SaveManager.Instance.tokens.ToString();
		if (SaveManager.Instance.tokens < 1)
		{
			purchaseTokenBTN.interactable = false;
			SaveManager.Instance.tokens = 0;
		}
		else if (SaveManager.Instance.tokens >= 1)
		{
			purchaseTokenBTN.interactable = true;
		}
		else
		{
			purchaseTokenBTN.interactable = false;
		}
	}

	protected static void InvokeUserCode_SetTokenBalanceRpc___Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetTokenBalanceRpc_ called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_SetTokenBalanceRpc___Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetExaminationsRemainingCmd__Int32(int amount)
	{
		SetExaminationsRemainingRpc(amount);
	}

	protected static void InvokeUserCode_SetExaminationsRemainingCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetExaminationsRemainingCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_SetExaminationsRemainingCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetExaminationsRemainingRpc__Int32(int amount)
	{
		examinationsRemaining = amount;
	}

	protected static void InvokeUserCode_SetExaminationsRemainingRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetExaminationsRemainingRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_SetExaminationsRemainingRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_StartHazardLightsCmd()
	{
		StartHazardLightsRpc();
	}

	protected static void InvokeUserCode_StartHazardLightsCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command StartHazardLightsCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_StartHazardLightsCmd();
		}
	}

	protected void UserCode_StartHazardLightsRpc()
	{
		forestGate.SetActive(value: true);
		GameObject[] array = openForestGates;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		if (ClientPlayer.Instance.playerMan.inForest)
		{
			ClientPlayer.Instance.teleportPlayer.RequestTeleport(inStoreTP.position);
		}
		huntHappened = true;
		SaveManager.Instance.huntsDone++;
		Computer.Instance.TurnOffComputer();
		if (doppelsLetThru > 1)
		{
			string miscText = JSONAccess.Instance.GetMiscText("UI Text 3", "Hunt Warning 1");
			miscText.Replace("<NUMBER>", doppelsLetThru.ToString());
			explanationText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			explanationText.text = miscText;
		}
		else if (doppelsLetThru == 1)
		{
			huntMan.oneCreature = true;
			explanationText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			explanationText.text = JSONAccess.Instance.GetMiscText("UI Text 3", "Hunt Warning 2");
		}
		else if (doppelsLetThru < 1)
		{
			huntMan.oneCreature = true;
			explanationText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			explanationText.text = JSONAccess.Instance.GetMiscText("UI Text 3", "Hunt Warning 3");
		}
		FinishObjective();
		array = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < array.Length; i++)
		{
			PlayerManager component = array[i].GetComponent<PlayerManager>();
			if (component != null)
			{
				component.enemiesList.Clear();
			}
		}
		hazardLights.SetActive(value: true);
		storeLights.SetActive(value: false);
		Invoke("HazardLightsHint", 4f);
		storeUI.SetActive(value: false);
		HuntPanel.Instance.Invoke("RevealPanel", 18f);
		secondsLeft = 60;
	}

	protected static void InvokeUserCode_StartHazardLightsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC StartHazardLightsRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_StartHazardLightsRpc();
		}
	}

	protected void UserCode_EndHuntCmd()
	{
		EndHuntRpc();
	}

	protected static void InvokeUserCode_EndHuntCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EndHuntCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_EndHuntCmd();
		}
	}

	protected void UserCode_EndHuntRpc()
	{
		AmbientMusicSystem.Instance.inHunt = false;
		if (base.isServer)
		{
			foreach (PlayerManager playerMan in playerMans)
			{
				playerMan.ChangeHuntLight(on: false);
			}
			GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
			for (int i = 0; i < array.Length; i++)
			{
				NetworkServer.Destroy(array[i]);
			}
			Invoke("BreachCompensation", 4f);
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 4f);
		}
		doppelsLetThru = 0;
		huntMan.oneCreature = false;
		DeactivateVentOutlines();
		if (!alreadyEndedHuntToday)
		{
			alreadyEndedHuntToday = true;
			GameObject[] array = GameObject.FindGameObjectsWithTag("Egg");
			for (int i = 0; i < array.Length; i++)
			{
				Object.Destroy(array[i]);
			}
			if (this.playerMan.inventoryMan.holdingIndex == 9)
			{
				this.playerMan.inventoryMan.DestroyObject();
			}
			this.playerMan.TurnOffAllDetectionArrows();
			this.playerMan.ChangeTimeSpentOutside(0f);
			this.playerMan.localTimeSpentOutside = 0f;
			for (int j = 0; j < this.playerMan.timeDetected.Length; j++)
			{
				this.playerMan.ChangeTimeDetected(-2f, j);
			}
			hazardLights.SetActive(value: false);
			offLights.SetActive(value: false);
			storeLights.SetActive(value: true);
			inHunt = false;
			storeUI.SetActive(value: true);
			huntUI.SetActive(value: false);
			this.playerMan.timeSpentOutside = 0f;
			goBackInsideWarning.SetActive(value: false);
			AddHint("They are gone. You are now safe.");
			if (PlayerPrefs.GetInt("FirstHuntDone") != 1)
			{
				PlayerPrefs.SetInt("FirstHuntDone", 1);
				AddHint("Each failed assault strengthens them. Next time, surviving won’t be so easy.");
			}
			NextHint();
		}
	}

	protected static void InvokeUserCode_EndHuntRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EndHuntRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_EndHuntRpc();
		}
	}

	protected void UserCode_NetworkDropObject__Int32__Vector3__Quaternion__Int32__Vector3__InventoryManager(int holdingIndex, Vector3 throwPosition, Quaternion rotation, int crateStorage, Vector3 playerForward, InventoryManager inventoryMan)
	{
		if (base.isServer)
		{
			GameObject gameObject = Object.Instantiate(pickupObjs[holdingIndex], throwPosition, rotation);
			NetworkServer.Spawn(gameObject);
			gameObject.GetComponent<PickupObject>().ChangeAmountOfItems(crateStorage);
			gameObject.GetComponent<Rigidbody>().velocity = playerForward * 5f;
			inventoryMan.IgnoreCollision(inventoryMan.gameObject, gameObject);
		}
	}

	protected static void InvokeUserCode_NetworkDropObject__Int32__Vector3__Quaternion__Int32__Vector3__InventoryManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command NetworkDropObject called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_NetworkDropObject__Int32__Vector3__Quaternion__Int32__Vector3__InventoryManager(reader.ReadVarInt(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVarInt(), reader.ReadVector3(), reader.ReadNetworkBehaviour<InventoryManager>());
		}
	}

	protected void UserCode_NetworkThrowObject__Int32__Vector3__Quaternion__Vector3__GameObject__Single(int holdingIndex, Vector3 throwPosition, Quaternion rotation, Vector3 playerForward, GameObject charController, float throwForceX)
	{
		GameObject obj = Object.Instantiate(thrownObjs[holdingIndex], throwPosition, rotation);
		obj.GetComponent<ThrownObject>().SetPlayerManThrowing(charController);
		NetworkServer.Spawn(obj);
		obj.GetComponent<Rigidbody>().velocity = playerForward * throwForceX;
		obj.GetComponent<Rigidbody>().velocity += base.transform.up * (throwForceX / 10f);
	}

	protected static void InvokeUserCode_NetworkThrowObject__Int32__Vector3__Quaternion__Vector3__GameObject__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command NetworkThrowObject called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_NetworkThrowObject__Int32__Vector3__Quaternion__Vector3__GameObject__Single(reader.ReadVarInt(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVector3(), reader.ReadGameObject(), reader.ReadFloat());
		}
	}

	protected void UserCode_CheckAllRemoteTrapsCmd()
	{
		CheckAllRemoteTrapsRpc();
	}

	protected static void InvokeUserCode_CheckAllRemoteTrapsCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CheckAllRemoteTrapsCmd called on client.");
		}
		else
		{
			((StoreManager)obj).UserCode_CheckAllRemoteTrapsCmd();
		}
	}

	protected void UserCode_CheckAllRemoteTrapsRpc()
	{
		if (!base.isServer)
		{
			return;
		}
		foreach (PlayerManager playerMan in playerMans)
		{
			playerMan.inventoryMan.CheckIfRemotesStillOn();
		}
	}

	protected static void InvokeUserCode_CheckAllRemoteTrapsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CheckAllRemoteTrapsRpc called on server.");
		}
		else
		{
			((StoreManager)obj).UserCode_CheckAllRemoteTrapsRpc();
		}
	}

	static StoreManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::FlashlightToggledCmd(System.Int32)", InvokeUserCode_FlashlightToggledCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::ToggleMultiplayerObjectsCmd()", InvokeUserCode_ToggleMultiplayerObjectsCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::AddDissonanceDictionaryCmd(System.String,System.String)", InvokeUserCode_AddDissonanceDictionaryCmd__String__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::ChangeRevenueCmd(System.String,System.Single)", InvokeUserCode_ChangeRevenueCmd__String__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::AnotherPlayerCompletedCmd()", InvokeUserCode_AnotherPlayerCompletedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::GetAllPlayerMansCmd()", InvokeUserCode_GetAllPlayerMansCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::ChangeTokenBalanceCmd(System.Int32)", InvokeUserCode_ChangeTokenBalanceCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::SetExaminationsRemainingCmd(System.Int32)", InvokeUserCode_SetExaminationsRemainingCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::StartHazardLightsCmd()", InvokeUserCode_StartHazardLightsCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::EndHuntCmd()", InvokeUserCode_EndHuntCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::NetworkDropObject(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion,System.Int32,UnityEngine.Vector3,InventoryManager)", InvokeUserCode_NetworkDropObject__Int32__Vector3__Quaternion__Int32__Vector3__InventoryManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::NetworkThrowObject(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,UnityEngine.GameObject,System.Single)", InvokeUserCode_NetworkThrowObject__Int32__Vector3__Quaternion__Vector3__GameObject__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreManager), "System.Void StoreManager::CheckAllRemoteTrapsCmd()", InvokeUserCode_CheckAllRemoteTrapsCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::FlashlightToggledRpc(System.Int32)", InvokeUserCode_FlashlightToggledRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::ToggleMultiplayerObjectsRpc()", InvokeUserCode_ToggleMultiplayerObjectsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::AddDissonanceDictionaryRpc(System.String,System.String)", InvokeUserCode_AddDissonanceDictionaryRpc__String__String);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::UpdateDissonanceDictionaryToClients(System.Collections.Generic.List`1<System.String>,System.Collections.Generic.List`1<System.String>)", InvokeUserCode_UpdateDissonanceDictionaryToClients__List_00601__List_00601);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::DisableDumpsterMonster()", InvokeUserCode_DisableDumpsterMonster);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::DestroyTutorialStuff()", InvokeUserCode_DestroyTutorialStuff);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::UpdateCurDayOnAllClients(System.Int32)", InvokeUserCode_UpdateCurDayOnAllClients__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::ChangeRevenueRpc(System.String,System.Single)", InvokeUserCode_ChangeRevenueRpc__String__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::AnotherPlayerCompletedRpc()", InvokeUserCode_AnotherPlayerCompletedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::GetAllPlayerMansRpc()", InvokeUserCode_GetAllPlayerMansRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::ChangeTokenBalanceRpc(System.Int32)", InvokeUserCode_ChangeTokenBalanceRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::SetTokenBalanceRpc_(System.Int32)", InvokeUserCode_SetTokenBalanceRpc___Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::SetExaminationsRemainingRpc(System.Int32)", InvokeUserCode_SetExaminationsRemainingRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::StartHazardLightsRpc()", InvokeUserCode_StartHazardLightsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::EndHuntRpc()", InvokeUserCode_EndHuntRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreManager), "System.Void StoreManager::CheckAllRemoteTrapsRpc()", InvokeUserCode_CheckAllRemoteTrapsRpc);
	}
}
