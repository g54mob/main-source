using System;
using System.Collections;
using System.Collections.Generic;
using Dissonance;
using Dissonance.Audio.Capture;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerManager : NetworkBehaviour
{
	public string playerName;

	public TextMeshProUGUI nameText;

	public float stamina;

	public float maxStamina;

	public Image staminaBar1;

	public Image staminaBar2;

	public bool isRunning;

	public bool staminaPaused;

	public FPSController fpsScript;

	public InventoryManager inventoryMan;

	public GameObject crosshair;

	public Animator cameraHolderAnim;

	public bool paused;

	public GameObject pauseMenu;

	public bool canPause = true;

	public GameObject dmgScreen;

	public GameObject lightDmgScreen;

	public bool damaged;

	public GameObject deathScreen;

	public CameraShake camShake;

	public AudioSource outsideAudio;

	public LayerMask insideMask;

	public bool dead;

	public bool downed;

	private float downedTime;

	private bool pauseDownedTimer;

	public GameObject downedUI;

	public GameObject revivingUI;

	public Image downBar;

	public GameObject downCollider;

	public StoreManager storeMan;

	public float[] timeDetected;

	public GameObject[] detectionArrows;

	public Image[] detectionArrowSprites;

	public Animator detectedUI;

	public Image detectedBar;

	public bool completelyDetected;

	public bool insideVent;

	public Animator headbobAnim;

	public List<GameObject> enemiesList;

	public Animator alertedTheCreatureWarning;

	public AudioMixer audioMixer;

	private float detectionMeterFloat;

	private float sfxFloat;

	private float musicFloat;

	public float localTimeSpentOutside;

	public float timeSpentOutside;

	public GameObject needsEggWarning;

	public GameObject explosiveRemote;

	public AudioSource explosiveRemotePress;

	public bool dontAllowLockCursor;

	public ThirdPersonManager thirdPersonMan;

	public InteractManager interactMan;

	public CharacterController charController;

	public GameObject hitBlood;

	public GameObject deathBlood;

	public GameObject[] limbs;

	public GameObject cameraHolder;

	public GameObject spectatingCamera;

	public GameObject canvas;

	public GameObject howToPlayScreen;

	public DialogueInteractable curNpcScript;

	private bool finished;

	public GameObject stuckUI;

	public bool stuck;

	private bool stuckOnAKey;

	public float scent;

	private DissonanceComms comms;

	private IMicrophoneCapture mic;

	public bool lookingAtShelf;

	public bool lookingAtComputer;

	public GameObject huntLight;

	public List<WeepingAngel> weepingAngels;

	public float timeUntilCanHeal;

	public GameObject freeingFromStuckIndicator;

	public GameObject aOn;

	public GameObject aOff;

	public GameObject dOn;

	public GameObject dOff;

	public float maxAmountOfStucks;

	public float curAmountOfStucks;

	public Image stuckBar1;

	public Image stuckBar2;

	private bool gottenUnstuck;

	private bool cantGetStuck;

	public GameObject customizablesMenu;

	private bool customizablesMenuOpen;

	public bool inside;

	public float lookingAtAngle = 50f;

	public float maxLookDistance = 20f;

	public LayerMask angelRaycastMask;

	private Dictionary<WeepingAngel, bool> angelLookStates = new Dictionary<WeepingAngel, bool>();

	private bool justStoppedPauseTimer = true;

	private bool justStunned = true;

	private bool justUnstunned = true;

	private bool justFire = true;

	private bool justOffFire = true;

	public bool stunned;

	public bool onFire;

	public GameObject stunnedUI;

	public GameObject fireUI;

	private float timeBeforeFireTick;

	public float timeOnFire;

	public float maxHealth = 100f;

	public float health = 100f;

	public float healthIndicatorAdjustment;

	public Image healthBar;

	public Image healthBarIndicator;

	public TextMeshProUGUI healthText;

	public GameObject healUI;

	public bool alreadyVoted;

	public int amountOfVotes;

	public TextMeshProUGUI amountToVoteText;

	private bool completingDay;

	public GameObject quitGameConfirmation;

	public bool inForest;

	public Coroutine curChangeEnvLightingCoroutine;

	public void SetUpHowToPlay()
	{
		howToPlayScreen.SetActive(value: true);
		Invoke("FurtherSetupHowToPlay", 1f);
		Invoke("FurtherSetupHowToPlay", 2f);
		Invoke("FurtherSetupHowToPlay", 3f);
		fpsScript.lockCam = true;
		fpsScript.lockMove = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		canPause = false;
	}

	private void FurtherSetupHowToPlay()
	{
		if (!finished)
		{
			fpsScript.lockCam = true;
			fpsScript.lockMove = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			canPause = false;
		}
	}

	public void FinishHowToPlay()
	{
		finished = true;
		howToPlayScreen.SetActive(value: false);
		fpsScript.lockCam = false;
		fpsScript.lockMove = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		canPause = true;
		PlayerPrefs.SetInt("DoneHowToPlay", 1);
	}

	[ClientRpc]
	public void ChangeHuntLight(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendRPCInternal("System.Void PlayerManager::ChangeHuntLight(System.Boolean)", -927104315, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnEnable()
	{
		storeMan = StoreManager.Instance;
		StoreManager.Instance.Invoke("Start_", 0.1f);
		CurrentDayManager.Instance.Invoke("Start_", 0.1f);
		SaveManager.Instance.Invoke("SetValuesForClients", 1f);
		if ((bool)storeMan)
		{
			storeMan.ToggleMultiplayerObjects();
			canvas.SetActive(value: true);
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<ThirdPersonManager>().Invoke("ResetAnims", 0.1f);
		}
	}

	private void Start()
	{
		StoreManager.Instance.Invoke("LoadAllPlayerMans", 0.1f);
		if (!base.isLocalPlayer)
		{
			base.enabled = false;
			return;
		}
		if (PlayerPrefs.GetInt("DoneHowToPlay", 0) != 1)
		{
			SetUpHowToPlay();
		}
		thirdPersonMan.TurnOffModels();
		stamina = maxStamina;
		ChangeInsideVent(change: false);
		LoadPlayerName();
		nameText.gameObject.SetActive(value: false);
		StoreManager.Instance.AddDissonanceDictionary(UnityEngine.Object.FindObjectOfType<DissonanceComms>().LocalPlayerName, SteamFriends.GetPersonaName());
		comms = UnityEngine.Object.FindObjectOfType<DissonanceComms>();
		if ((bool)comms)
		{
			mic = comms.MicrophoneCapture;
		}
	}

	[ContextMenu("Log All NetworkBehaviours")]
	public void LogAllNetworkBehaviours()
	{
		NetworkIdentity[] array = UnityEngine.Object.FindObjectsOfType<NetworkIdentity>();
		Debug.Log($"[NetIdPrinter] Found {array.Length} NetworkIdentity objects:");
		NetworkIdentity[] array2 = array;
		foreach (NetworkIdentity networkIdentity in array2)
		{
			string text = $"{networkIdentity.gameObject.name} - netId: {networkIdentity.netId}";
			if (networkIdentity.netId == 2341)
			{
				text += "  !!!!!!!!!!!";
			}
			Debug.Log(text);
		}
	}

	public void LoadPlayerName()
	{
		if (base.isServer)
		{
			LoadPlayerNameRpc();
		}
		else
		{
			LoadPlayerNameCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void LoadPlayerNameCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::LoadPlayerNameCmd()", -1945607851, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void LoadPlayerNameRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::LoadPlayerNameRpc()", 1994501430, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void SetPlayerNameCmd(string name)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(name);
		SendCommandInternal("System.Void PlayerManager::SetPlayerNameCmd(System.String)", -1487207151, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SetPlayerNameRpc(string name)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(name);
		SendRPCInternal("System.Void PlayerManager::SetPlayerNameRpc(System.String)", -97822712, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChangeTimeDetected(float change, int index)
	{
		if (base.isServer)
		{
			ChangeTimeDetectedRpc(change, index);
		}
		else
		{
			ChangeTimeDetectedCmd(change, index);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeTimeDetectedCmd(float change, int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(change);
		writer.WriteVarInt(index);
		SendCommandInternal("System.Void PlayerManager::ChangeTimeDetectedCmd(System.Single,System.Int32)", -197176974, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeTimeDetectedRpc(float change, int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(change);
		writer.WriteVarInt(index);
		SendRPCInternal("System.Void PlayerManager::ChangeTimeDetectedRpc(System.Single,System.Int32)", -193451311, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void CallAlertedCreature()
	{
		if (base.isServer)
		{
			CallAlertedCreatureRpc();
		}
		else
		{
			CallAlertedCreatureCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void CallAlertedCreatureCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::CallAlertedCreatureCmd()", -91044783, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CallAlertedCreatureRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::CallAlertedCreatureRpc()", 1932786738, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void AddToEnemiesList(NetworkIdentity obj)
	{
		if (base.isServer)
		{
			AddToEnemiesListRpc(obj.netId);
		}
		else
		{
			AddToEnemiesListCmd(obj.netId);
		}
	}

	[Command(requiresAuthority = false)]
	private void AddToEnemiesListCmd(uint netId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(netId);
		SendCommandInternal("System.Void PlayerManager::AddToEnemiesListCmd(System.UInt32)", 2020563265, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AddToEnemiesListRpc(uint netId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(netId);
		SendRPCInternal("System.Void PlayerManager::AddToEnemiesListRpc(System.UInt32)", 514633016, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDisable()
	{
	}

	[ClientRpc]
	public void SetPoster(CreatingPoster poster)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(poster);
		SendRPCInternal("System.Void PlayerManager::SetPoster(CreatingPoster)", -1863464980, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GetStuck(float amountOfStucks)
	{
		if (base.isServer)
		{
			GetStuckRpc(amountOfStucks);
		}
		else
		{
			GetStuckCmd(amountOfStucks);
		}
	}

	[Command(requiresAuthority = false)]
	public void GetStuckCmd(float amountOfStucks)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(amountOfStucks);
		SendCommandInternal("System.Void PlayerManager::GetStuckCmd(System.Single)", -643207304, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void GetStuckRpc(float amountOfStucks)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(amountOfStucks);
		SendRPCInternal("System.Void PlayerManager::GetStuckRpc(System.Single)", 1406084769, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CanGetStuckAgain()
	{
		cantGetStuck = false;
	}

	private void SwitchStuckKeys()
	{
		if (stuckOnAKey)
		{
			aOn.SetActive(value: true);
			aOff.SetActive(value: false);
			dOn.SetActive(value: false);
			dOff.SetActive(value: true);
		}
		else
		{
			aOn.SetActive(value: false);
			aOff.SetActive(value: true);
			dOn.SetActive(value: true);
			dOff.SetActive(value: false);
		}
		freeingFromStuckIndicator.SetActive(value: false);
		freeingFromStuckIndicator.SetActive(value: true);
		camShake.intensity = 0.025f;
		if (curAmountOfStucks <= 0f && !gottenUnstuck)
		{
			gottenUnstuck = true;
			Invoke("GetUnstuck", 0.3f);
		}
	}

	public void GetUnstuck()
	{
		if (stuck)
		{
			canPause = true;
			thirdPersonMan.GetUnstuck();
			camShake.intensity = 0.2f;
			fpsScript.lockMove = false;
			fpsScript.lockCam = false;
			inventoryMan.UnpauseUseItem();
			stuck = false;
			stuckUI.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		if (stuck)
		{
			stuckBar1.fillAmount = Mathf.Lerp(stuckBar1.fillAmount, curAmountOfStucks / maxAmountOfStucks, Time.deltaTime * 15f);
			stuckBar2.fillAmount = Mathf.Lerp(stuckBar2.fillAmount, curAmountOfStucks / maxAmountOfStucks, Time.deltaTime * 15f);
			stuckBar1.color = Color.Lerp(stuckBar1.color, new Color(0.63f, 0.63f, 0.63f), Time.deltaTime * 2f);
			stuckBar2.color = Color.Lerp(stuckBar2.color, new Color(0.63f, 0.63f, 0.63f), Time.deltaTime * 2f);
			if (stuckOnAKey)
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind1"))))
				{
					stuckBar1.color = Color.white;
					stuckBar2.color = Color.white;
					curAmountOfStucks -= 1f;
					stuckOnAKey = !stuckOnAKey;
					SwitchStuckKeys();
				}
			}
			else if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind3"))))
			{
				stuckBar1.color = Color.white;
				stuckBar2.color = Color.white;
				curAmountOfStucks -= 1f;
				stuckOnAKey = !stuckOnAKey;
				SwitchStuckKeys();
			}
		}
		if (canPause && !downed && !stunned && Input.GetKeyDown(KeyCode.Escape))
		{
			if (!paused)
			{
				if (!SpeakingManager.Instance.inChat)
				{
					if ((bool)TutorialManager.Instance)
					{
						TutorialManager.Instance.tutorialObjCanvasHolderAsWell.SetActive(value: false);
					}
					if ((bool)StoreManager.Instance.dialogueTutorialCanv)
					{
						StoreManager.Instance.dialogueTutorialCanv.SetActive(value: false);
					}
					paused = true;
					SpeakingManager.Instance.CancelAllDialogue();
					crosshair.SetActive(value: false);
					pauseMenu.SetActive(value: true);
					fpsScript.UnlockCursor();
					fpsScript.lockMove = true;
					fpsScript.lockCam = true;
					dontAllowLockCursor = true;
					fpsScript.lookAtState = false;
				}
			}
			else
			{
				Unpause();
			}
		}
		if (customizablesMenuOpen && Input.GetKeyDown(KeyCode.Escape))
		{
			CloseCustomizablesMenu();
		}
	}

	public void OpenCustomizablesMenu()
	{
		customizablesMenuOpen = true;
		inventoryMan.PauseInventory();
		canPause = false;
		crosshair.SetActive(value: false);
		fpsScript.UnlockCursor();
		fpsScript.lockMove = true;
		fpsScript.lockCam = true;
		dontAllowLockCursor = true;
		fpsScript.lookAtState = false;
		customizablesMenu.SetActive(value: true);
		StoreManager.Instance.EnterCutscene(disablePlayerMan: false);
	}

	public void CloseCustomizablesMenu()
	{
		inventoryMan.UnpauseInventory();
		customizablesMenuOpen = false;
		if ((bool)StoreManager.Instance.dialogueTutorialCanv)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: true);
		}
		if ((bool)TutorialManager.Instance)
		{
			TutorialManager.Instance.tutorialObjCanvasHolderAsWell.SetActive(value: true);
		}
		canPause = true;
		crosshair.SetActive(value: true);
		customizablesMenu.SetActive(value: false);
		if (!SpeakingManager.Instance.inChat)
		{
			fpsScript.LockCursor();
			fpsScript.lockMove = false;
			fpsScript.lockCam = false;
		}
		quitGameConfirmation.SetActive(value: false);
		dontAllowLockCursor = false;
		StoreManager.Instance.ExitCutscene();
	}

	private void ChangeInsideStatus(bool on)
	{
		if (base.isServer)
		{
			ChangeInsideStatusRpc(on);
		}
		else
		{
			ChangeInsideStatusCmd(on);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeInsideStatusCmd(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendCommandInternal("System.Void PlayerManager::ChangeInsideStatusCmd(System.Boolean)", 1339926932, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeInsideStatusRpc(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendRPCInternal("System.Void PlayerManager::ChangeInsideStatusRpc(System.Boolean)", 1441554999, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChangeTimeSpentOutside(float time)
	{
		if (timeSpentOutside != time)
		{
			if (base.isServer)
			{
				ChangeTimeSpentOutsideRpc(time);
			}
			else
			{
				ChangeTimeSpentOutsideCmd(time);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeTimeSpentOutsideCmd(float time)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(time);
		SendCommandInternal("System.Void PlayerManager::ChangeTimeSpentOutsideCmd(System.Single)", -978823226, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeTimeSpentOutsideRpc(float time)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(time);
		SendRPCInternal("System.Void PlayerManager::ChangeTimeSpentOutsideRpc(System.Single)", 1544533051, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void FixedUpdate()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		timeUntilCanHeal -= Time.deltaTime;
		if (timeUntilCanHeal < 0f && !downed)
		{
			timeUntilCanHeal = 1f;
			Heal(1f, playHealUI: false);
		}
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, Time.deltaTime * 10f);
		healthBarIndicator.fillAmount = Mathf.Lerp(healthBarIndicator.fillAmount, (health + healthIndicatorAdjustment) / maxHealth, Time.deltaTime * 3f);
		if (weepingAngels.Count > 0)
		{
			Vector3 position = fpsScript.playerCamera.transform.position;
			Vector3 forward = fpsScript.playerCamera.transform.forward;
			foreach (WeepingAngel weepingAngel in weepingAngels)
			{
				if (weepingAngel == null)
				{
					continue;
				}
				if (!angelLookStates.ContainsKey(weepingAngel))
				{
					angelLookStates.Add(weepingAngel, value: false);
				}
				Vector3 vector = weepingAngel.middleOfBody.position - position;
				float magnitude = vector.magnitude;
				bool flag = false;
				if (magnitude <= maxLookDistance)
				{
					Vector3 normalized = vector.normalized;
					if (Vector3.Angle(forward, normalized) <= lookingAtAngle && !Physics.Raycast(position, normalized, out var _, magnitude, angelRaycastMask, QueryTriggerInteraction.Ignore))
					{
						flag = true;
					}
				}
				bool flag2 = angelLookStates[weepingAngel];
				if (flag && !flag2)
				{
					weepingAngel.TogglePlayerLookAt(lookingAt: true);
				}
				else if (!flag && flag2)
				{
					weepingAngel.TogglePlayerLookAt(lookingAt: false);
				}
				angelLookStates[weepingAngel] = flag;
			}
		}
		if (downed)
		{
			if (!pauseDownedTimer)
			{
				if (justStoppedPauseTimer)
				{
					fpsScript.lockMove = false;
					justStoppedPauseTimer = false;
				}
				revivingUI.SetActive(value: false);
				downBar.fillAmount = 1f - downedTime / 30f;
				downedTime -= Time.deltaTime;
			}
			else
			{
				justStoppedPauseTimer = true;
				headbobAnim.SetBool("Running", value: false);
				headbobAnim.SetBool("Walking", value: false);
				thirdPersonMan.legsAnim.SetBool("Walking", value: false);
				thirdPersonMan.legsAnim.SetBool("Running", value: false);
				thirdPersonMan.armsAnim.SetBool("Walking", value: false);
				thirdPersonMan.legsAnim.SetBool("Running", value: false);
				thirdPersonMan.armsAnim.SetBool("Walking", value: false);
				thirdPersonMan.armsAnim.SetBool("Running", value: false);
				thirdPersonMan.bodyAnim.SetBool("Walking", value: false);
				thirdPersonMan.bodyAnim.SetBool("Running", value: false);
				fpsScript.lockMove = true;
				revivingUI.SetActive(value: true);
			}
			_ = downedTime;
			_ = 0f;
		}
		if (dead)
		{
			audioMixer.GetFloat("SFX", out sfxFloat);
			audioMixer.SetFloat("SFX", Mathf.Lerp(sfxFloat, -80f, Time.deltaTime / 4f));
			audioMixer.SetFloat("DeathAudio", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20f);
			audioMixer.GetFloat("Music", out musicFloat);
			audioMixer.SetFloat("Music", Mathf.Lerp(musicFloat, -80f, Time.deltaTime / 4f));
		}
		if (storeMan.inHunt)
		{
			for (int i = 0; i < enemiesList.Count; i++)
			{
				if (timeDetected[i] > 0f)
				{
					detectionArrows[i].SetActive(value: true);
					Color color = detectionArrowSprites[i].color;
					color.a = timeDetected[i];
					detectionArrowSprites[i].color = color;
					detectionArrows[i].transform.rotation = Quaternion.Euler(0f, 0f, GetDamageDirection(enemiesList[i].transform.position));
				}
				else
				{
					detectionArrows[i].SetActive(value: false);
				}
			}
		}
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		Collider[] array = Physics.OverlapSphere(base.transform.position, 0.1f);
		if (array.Length != 0)
		{
			flag3 = false;
			flag4 = false;
			flag5 = false;
			foreach (Collider obj in array)
			{
				if (obj.CompareTag("InsideStore"))
				{
					flag3 = true;
				}
				if (obj.CompareTag("Fire"))
				{
					flag4 = true;
				}
				if (obj.CompareTag("Stun"))
				{
					flag5 = true;
				}
			}
		}
		else
		{
			flag3 = false;
			flag4 = false;
			flag5 = false;
		}
		if (flag3)
		{
			if (!inside)
			{
				ChangeInsideStatus(on: true);
			}
			outsideAudio.volume = Mathf.Lerp(outsideAudio.volume, 0f, Time.deltaTime);
			storeMan.goBackInsideWarning.SetActive(value: false);
			localTimeSpentOutside -= Time.deltaTime;
			if (localTimeSpentOutside < 0f)
			{
				storeMan.goBackInsideWarning.SetActive(value: false);
				localTimeSpentOutside = 0f;
			}
			if (localTimeSpentOutside < 2f)
			{
				ChangeTimeSpentOutside(0f);
			}
		}
		else
		{
			if (inside)
			{
				ChangeInsideStatus(on: false);
			}
			if (storeMan.inHunt)
			{
				storeMan.goBackInsideWarning.SetActive(value: true);
				localTimeSpentOutside += Time.deltaTime * 0.5f;
				if (localTimeSpentOutside > 2f)
				{
					localTimeSpentOutside = 2f;
					ChangeTimeSpentOutside(2f);
				}
			}
			outsideAudio.volume = Mathf.Lerp(outsideAudio.volume, 1f, Time.deltaTime);
		}
		if (flag5)
		{
			if (justStunned)
			{
				stunnedUI.SetActive(value: true);
				stunned = true;
				justStunned = false;
				justUnstunned = true;
				thirdPersonMan.GetStunned();
			}
			fpsScript.moveMultiplier = 0.1f;
			fpsScript.canSprint = false;
			fpsScript.sensitivityMultiplier = 0.1f;
		}
		else if (justUnstunned)
		{
			stunnedUI.SetActive(value: false);
			stunned = false;
			justUnstunned = false;
			justStunned = true;
			thirdPersonMan.GetUnstunned();
			fpsScript.moveMultiplier = 1f;
			fpsScript.canSprint = true;
			fpsScript.sensitivityMultiplier = 1f;
		}
		if (!flag4 && timeOnFire > 0f)
		{
			timeOnFire -= Time.deltaTime * 2f;
			flag4 = true;
		}
		if (flag4)
		{
			if (justFire)
			{
				justFire = false;
				justOffFire = true;
				fireUI.SetActive(value: true);
				onFire = true;
				thirdPersonMan.GetStunned();
			}
			timeOnFire += Time.deltaTime;
			timeBeforeFireTick -= Time.deltaTime;
			if (timeBeforeFireTick < 0f)
			{
				TakeDamage(7f, significantAnim: false);
				timeBeforeFireTick = 0.7f;
			}
		}
		else if (justOffFire)
		{
			justOffFire = false;
			justFire = true;
			fireUI.SetActive(value: false);
			onFire = false;
			thirdPersonMan.GetUnstunned();
		}
		else
		{
			timeBeforeFireTick += Time.deltaTime;
		}
		timeBeforeFireTick = Mathf.Clamp(timeBeforeFireTick, -1f, 0.7f);
		timeOnFire = Mathf.Clamp(timeOnFire, -0.5f, 2f);
		float num = 0f;
		float[] array2 = timeDetected;
		foreach (float num2 in array2)
		{
			if (num2 > num)
			{
				num = num2;
			}
		}
		if (localTimeSpentOutside > num)
		{
			num = localTimeSpentOutside;
		}
		if (num > 0f)
		{
			detectedUI.SetTrigger("Detected");
			detectionMeterFloat = Mathf.Lerp(detectionMeterFloat, num / 2f, Time.deltaTime * 15f);
			detectedBar.fillAmount = detectionMeterFloat;
			if (detectionMeterFloat > 0.95f)
			{
				storeMan.beingChased = true;
				completelyDetected = true;
				detectedBar.color = Color.red;
				if (num > 2f)
				{
					num = 2f;
				}
			}
			else
			{
				storeMan.beingChased = false;
				detectedBar.color = Color.white;
				completelyDetected = false;
			}
		}
		else
		{
			storeMan.beingChased = false;
			detectionMeterFloat = Mathf.Lerp(detectionMeterFloat, num / 2f, Time.deltaTime * 15f);
			detectedBar.fillAmount = detectionMeterFloat;
			detectedBar.color = Color.white;
			completelyDetected = false;
		}
		if (staminaPaused)
		{
			return;
		}
		if (isRunning)
		{
			stamina -= Time.deltaTime;
			staminaBar1.fillAmount = stamina / maxStamina;
			staminaBar2.fillAmount = stamina / maxStamina;
			staminaBar1.color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, 0f), staminaBar1.fillAmount + 0.3f);
			staminaBar2.color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, 0f), staminaBar1.fillAmount + 0.3f);
			if (stamina <= 0f && !staminaPaused)
			{
				staminaPaused = true;
				isRunning = false;
				Invoke("UnpauseStamina", 1.6f);
			}
		}
		else if (stamina <= maxStamina)
		{
			stamina += Time.deltaTime * 2f;
			staminaBar1.fillAmount = stamina / maxStamina;
			staminaBar2.fillAmount = stamina / maxStamina;
			staminaBar1.color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, 0f), staminaBar1.fillAmount + 0.3f);
			staminaBar2.color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, 0f), staminaBar1.fillAmount + 0.3f);
		}
	}

	private float GetDamageDirection(Vector3 enemyPosition)
	{
		Vector3 normalized = (enemyPosition - base.transform.position).normalized;
		Vector3 normalized2 = new Vector3(base.transform.forward.x, 0f, base.transform.forward.z).normalized;
		Vector3 normalized3 = new Vector3(normalized.x, 0f, normalized.z).normalized;
		return Vector3.SignedAngle(normalized2, normalized3, Vector3.up) * -1f;
	}

	public void Heal(float health_, bool playHealUI = true)
	{
		if (base.isLocalPlayer)
		{
			if (playHealUI)
			{
				healUI.SetActive(value: false);
				healUI.SetActive(value: true);
			}
			health += health_;
			if (health > maxHealth)
			{
				health = maxHealth;
			}
			SetHealthUI();
		}
	}

	public void TakeDamage(float damage, bool significantAnim)
	{
		if (base.isServer)
		{
			TakeDamageRpc(damage, significantAnim);
		}
		else
		{
			TakeDamageCmd(damage, significantAnim);
		}
	}

	[Command(requiresAuthority = false)]
	public void TakeDamageCmd(float damage, bool significantAnim)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damage);
		writer.WriteBool(significantAnim);
		SendCommandInternal("System.Void PlayerManager::TakeDamageCmd(System.Single,System.Boolean)", -781121091, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void TakeDamageRpc(float damage, bool significantAnim)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damage);
		writer.WriteBool(significantAnim);
		SendRPCInternal("System.Void PlayerManager::TakeDamageRpc(System.Single,System.Boolean)", -142662922, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SetHealthUI()
	{
		healthText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		healthText.text = health.ToString("0") + " / " + maxHealth.ToString("0");
	}

	private void TakeDamageAnim()
	{
		thirdPersonMan.armsAnim.SetBool("TakeDamage", value: true);
		thirdPersonMan.bodyAnim.SetBool("TakeDamage", value: true);
		thirdPersonMan.legsAnim.SetBool("TakeDamage", value: true);
		Invoke("FinTakeDamageAnim", 0.6f);
	}

	private void FinTakeDamageAnim()
	{
		thirdPersonMan.armsAnim.SetBool("TakeDamage", value: false);
		thirdPersonMan.bodyAnim.SetBool("TakeDamage", value: false);
		thirdPersonMan.legsAnim.SetBool("TakeDamage", value: false);
	}

	private void RecoverDamage()
	{
		damaged = false;
	}

	public void Downed()
	{
		downed = true;
		StoreManager.Instance.rToReload.SetActive(value: false);
		inventoryMan.PauseInventory();
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		Unpause();
		Computer.Instance.StopInteract();
		RestockShelf[] restockShelves = Shelves.Instance.restockShelves;
		foreach (RestockShelf restockShelf in restockShelves)
		{
			if ((bool)restockShelf)
			{
				restockShelf.StopInteract();
			}
		}
		IDCard[] array = UnityEngine.Object.FindObjectsOfType<IDCard>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].StopInteract();
		}
		DialogueInteractable[] array2 = UnityEngine.Object.FindObjectsOfType<DialogueInteractable>();
		foreach (DialogueInteractable obj in array2)
		{
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
		}
		List<Transform> list = new List<Transform>();
		GameObject[] array3 = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array4 = array3;
		foreach (GameObject gameObject in array4)
		{
			if (!gameObject.GetComponent<PlayerManager>().dead && !gameObject.GetComponent<PlayerManager>().downed)
			{
				list.Add(gameObject.transform);
			}
		}
		if (list.Count == 0)
		{
			CancelInvoke("CheckIfAllDowned");
			array4 = array3;
			for (int i = 0; i < array4.Length; i++)
			{
				array4[i].GetComponent<PlayerManager>().Die();
			}
			return;
		}
		CancelInvoke("CheckIfAllDowned");
		if (base.isServer)
		{
			InvokeRepeating("CheckIfAllDowned", 1f, 10f);
		}
		PauseDownedTimer(change: false);
		revivingUI.SetActive(value: false);
		fpsScript.lockMove = false;
		downedUI.SetActive(value: true);
		inventoryMan.PauseInventory();
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		if (base.isServer)
		{
			DownedRpc();
		}
		else
		{
			DownedCmd();
		}
	}

	private void CheckIfAllDowned()
	{
		List<Transform> list = new List<Transform>();
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (!gameObject.GetComponent<PlayerManager>().dead && !gameObject.GetComponent<PlayerManager>().downed)
			{
				list.Add(gameObject.transform);
			}
		}
		if (list.Count == 0)
		{
			CancelInvoke("CheckIfAllDowned");
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].GetComponent<PlayerManager>().Die();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void DownedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::DownedCmd()", -1116365080, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void DownedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::DownedRpc()", 1028368655, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void EveryoneDied()
	{
		if (base.isServer)
		{
			EveryoneDiedRpc();
		}
		else
		{
			EveryoneDiedCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void EveryoneDiedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::EveryoneDiedCmd()", 537789534, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EveryoneDiedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::EveryoneDiedRpc()", 1763336161, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void LoadLatestSave()
	{
		NetworkManager.singleton.ServerChangeScene("Game");
	}

	public void Die()
	{
		if (!dead)
		{
			if (base.isServer)
			{
				DieRpc();
			}
			else
			{
				DieCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void DieCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::DieCmd()", 412882545, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void DieRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::DieRpc()", 1673595090, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void CompleteDay()
	{
	}

	[Command(requiresAuthority = false)]
	private void CompleteDayCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::CompleteDayCmd()", -1977175778, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CompleteDayRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::CompleteDayRpc()", -751629151, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Respawn()
	{
		if (!base.isLocalPlayer)
		{
			nameText.gameObject.SetActive(value: false);
		}
		base.enabled = true;
		camShake.transform.localPosition = Vector3.zero;
		OnEnable();
		inventoryMan.OnEnable();
		fpsScript.OnEnable();
		deathScreen.SetActive(value: false);
		completingDay = false;
		if ((bool)downedUI)
		{
			downedUI.SetActive(value: false);
		}
		downCollider.SetActive(value: false);
		ChangeTimeSpentOutside(0f);
		localTimeSpentOutside = 0f;
		fpsScript.LockCursor();
		inventoryMan.downed = false;
		downed = false;
		fpsScript.downed = false;
		cameraHolderAnim.SetBool("Downed", value: false);
		thirdPersonMan.armsAnim.SetBool("Downed", value: false);
		thirdPersonMan.bodyAnim.SetBool("Downed", value: false);
		thirdPersonMan.legsAnim.SetBool("Downed", value: false);
		canvas.SetActive(value: true);
		storeMan.canvas.SetActive(value: true);
		spectatingCamera.SetActive(value: false);
		cameraHolder.SetActive(value: true);
		base.enabled = true;
		inventoryMan.enabled = true;
		interactMan.enabled = true;
		fpsScript.enabled = true;
		if (base.isServer)
		{
			RespawnRpc();
		}
		else
		{
			RespawnCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void RespawnCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerManager::RespawnCmd()", 1534935559, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RespawnRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerManager::RespawnRpc()", 698845732, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PauseDownedTimer(bool change)
	{
		if (base.isServer)
		{
			PauseDownedTimerRpc(change);
		}
		else
		{
			PauseDownedTimerCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	private void PauseDownedTimerCmd(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendCommandInternal("System.Void PlayerManager::PauseDownedTimerCmd(System.Boolean)", -702769814, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PauseDownedTimerRpc(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendRPCInternal("System.Void PlayerManager::PauseDownedTimerRpc(System.Boolean)", -1575322223, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnFlesh()
	{
		for (int i = 0; i < limbs.Length; i++)
		{
			Rigidbody component = UnityEngine.Object.Instantiate(limbs[i], base.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			NetworkServer.Spawn(component.gameObject);
			component.velocity = UnityEngine.Random.onUnitSphere * UnityEngine.Random.Range(0, 6);
		}
	}

	public void Revive()
	{
		if ((bool)downedUI)
		{
			downedUI.SetActive(value: false);
		}
		downCollider.SetActive(value: false);
		inventoryMan.downed = false;
		downed = false;
		fpsScript.downed = false;
		cameraHolderAnim.SetBool("Downed", value: false);
		thirdPersonMan.armsAnim.SetBool("Downed", value: false);
		thirdPersonMan.bodyAnim.SetBool("Downed", value: false);
		thirdPersonMan.legsAnim.SetBool("Downed", value: false);
		inventoryMan.UnpauseInventory();
		Heal(10f);
		Invoke("UnlockMove", 0.1f);
	}

	private void UnlockMove()
	{
		fpsScript.lockMove = false;
	}

	public void TurnPauseBackOn()
	{
		canPause = true;
	}

	public void TurnPauseOff()
	{
		canPause = false;
	}

	public void TurnOffAllDetectionArrows()
	{
		for (int i = 0; i < detectionArrows.Length; i++)
		{
			detectionArrows[i].SetActive(value: false);
		}
	}

	public void Unpause()
	{
		if ((bool)StoreManager.Instance.dialogueTutorialCanv)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: true);
		}
		if ((bool)TutorialManager.Instance)
		{
			TutorialManager.Instance.tutorialObjCanvasHolderAsWell.SetActive(value: true);
		}
		paused = false;
		crosshair.SetActive(value: true);
		pauseMenu.SetActive(value: false);
		if (!SpeakingManager.Instance.inChat)
		{
			fpsScript.LockCursor();
			fpsScript.lockMove = false;
			fpsScript.lockCam = false;
		}
		quitGameConfirmation.SetActive(value: false);
		dontAllowLockCursor = false;
	}

	private void UnpauseStamina()
	{
		staminaPaused = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		if (other.CompareTag("Vision Cone"))
		{
			other.gameObject.GetComponentInParent<StoreBrowseBehaviour>().playerLookTarget = fpsScript.playerCamera.transform;
		}
		else if (other.CompareTag("EntryDoor"))
		{
			_ = StoreManager.Instance.inHunt;
			other.gameObject.GetComponent<EntryDoor>().Enter();
			fpsScript.lockVolume = true;
			fpsScript.Invoke("UnlockVolume", 1f);
			fpsScript.volume = 0.82f;
			fpsScript.storeMan.volume = 0.82f;
		}
		else if (other.CompareTag("TutorialTrigger"))
		{
			TutorialManager.Instance.StartObjective();
		}
		else if (other.CompareTag("InitialInteractionTrigger"))
		{
			if ((bool)TransactionManager.Instance.curNpcScript && (bool)TransactionManager.Instance.curNpcScript.dialogueInteractable)
			{
				curNpcScript = TransactionManager.Instance.curNpcScript.dialogueInteractable;
			}
			TransactionManager.Instance.Invoke("TriggerInitialInteraction", UnityEngine.Random.Range(0.01f, 1f));
			TurnOffObjectsChild(other.transform.parent.gameObject);
		}
		else if (other.CompareTag("Bear Trap"))
		{
			if (StoreManager.Instance.inHunt)
			{
				alertedTheCreatureWarning.SetTrigger("Alert");
			}
			other.gameObject.GetComponent<BearTrap>().Trap();
			TakeDamage(40f, significantAnim: true);
		}
		else if (other.CompareTag("Landmine"))
		{
			if (StoreManager.Instance.inHunt)
			{
				alertedTheCreatureWarning.SetTrigger("Alert");
			}
			other.gameObject.GetComponent<Landmine>().Trap();
		}
		else if (other.CompareTag("StunMine"))
		{
			if (StoreManager.Instance.inHunt)
			{
				alertedTheCreatureWarning.SetTrigger("Alert");
			}
			other.gameObject.GetComponent<StunMine>().Trap();
		}
		else if (other.CompareTag("VentTrigger"))
		{
			ChangeInsideVent(change: true);
		}
		else if (other.CompareTag("Cobweb"))
		{
			GetStuck(5f);
		}
		else if (other.CompareTag("Trigger"))
		{
			other.gameObject.GetComponent<AnimationEventTrigger>().ExecuteEvent();
		}
		else if (other.CompareTag("EnterForestTrigger"))
		{
			inForest = true;
			if (curChangeEnvLightingCoroutine != null)
			{
				StopCoroutine(curChangeEnvLightingCoroutine);
			}
			curChangeEnvLightingCoroutine = StartCoroutine(ChangeEnvironmentLighting(new Color(0.4f, 0.4f, 0.8f), 0.05f, 3f));
		}
		else if (other.CompareTag("ExitForestTrigger"))
		{
			inForest = false;
			if (curChangeEnvLightingCoroutine != null)
			{
				StopCoroutine(curChangeEnvLightingCoroutine);
			}
			curChangeEnvLightingCoroutine = StartCoroutine(ChangeEnvironmentLighting(Color.black, 0.01f, 3f));
		}
		else if (other.CompareTag("OutOfBounds"))
		{
			ClientPlayer.Instance.teleportPlayer.RequestTeleport(Vector3.zero);
		}
	}

	public IEnumerator ChangeEnvironmentLighting(Color newColor, float newFogDensity, float duration)
	{
		Color initialAmbientColor = RenderSettings.ambientLight;
		float initialFogDensity = RenderSettings.fogDensity;
		float elapsed = 0f;
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / duration;
			RenderSettings.ambientLight = Color.Lerp(initialAmbientColor, newColor, t);
			RenderSettings.fogDensity = Mathf.Lerp(initialFogDensity, newFogDensity, t);
			yield return null;
		}
		RenderSettings.ambientLight = newColor;
		RenderSettings.fogDensity = newFogDensity;
	}

	private void TurnOffObjectsChild(GameObject obj)
	{
		if (base.isServer)
		{
			TurnOffObjectsChildRpc(obj);
		}
		else
		{
			TurnOffObjectsChildCmd(obj);
		}
	}

	[Command(requiresAuthority = false)]
	private void TurnOffObjectsChildCmd(GameObject obj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(obj);
		SendCommandInternal("System.Void PlayerManager::TurnOffObjectsChildCmd(UnityEngine.GameObject)", 1244830359, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TurnOffObjectsChildRpc(GameObject obj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(obj);
		SendRPCInternal("System.Void PlayerManager::TurnOffObjectsChildRpc(UnityEngine.GameObject)", -423084840, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChangeInsideVent(bool change)
	{
		if (base.isServer)
		{
			ChangeInsideVentRpc(change);
		}
		else
		{
			ChangeInsideVentCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeInsideVentCmd(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendCommandInternal("System.Void PlayerManager::ChangeInsideVentCmd(System.Boolean)", -877035621, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeInsideVentRpc(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendRPCInternal("System.Void PlayerManager::ChangeInsideVentRpc(System.Boolean)", 1187304372, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Vision Cone"))
		{
			other.gameObject.GetComponentInParent<StoreBrowseBehaviour>().playerLookTarget = null;
		}
		if (other.CompareTag("VentTrigger"))
		{
			ChangeInsideVent(change: false);
		}
	}

	public KeyCode ConvertStringToKeyCode(string keyName)
	{
		return keyName.ToLower() switch
		{
			"left ctrl" => KeyCode.LeftControl, 
			"LeftControl" => KeyCode.LeftControl, 
			"right ctrl" => KeyCode.RightControl, 
			"left shift" => KeyCode.LeftShift, 
			"LeftShift" => KeyCode.LeftShift, 
			"right shift" => KeyCode.RightShift, 
			"shift" => KeyCode.LeftShift, 
			"ctrl" => KeyCode.LeftControl, 
			_ => (KeyCode)Enum.Parse(typeof(KeyCode), keyName, ignoreCase: true), 
		};
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeHuntLight__Boolean(bool on)
	{
		huntLight.SetActive(on);
	}

	protected static void InvokeUserCode_ChangeHuntLight__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeHuntLight called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeHuntLight__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_LoadPlayerNameCmd()
	{
		LoadPlayerNameRpc();
	}

	protected static void InvokeUserCode_LoadPlayerNameCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command LoadPlayerNameCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_LoadPlayerNameCmd();
		}
	}

	protected void UserCode_LoadPlayerNameRpc()
	{
		if (base.isLocalPlayer)
		{
			if (base.isServer)
			{
				SetPlayerNameRpc(SteamFriends.GetPersonaName());
			}
			else
			{
				SetPlayerNameCmd(SteamFriends.GetPersonaName());
			}
		}
	}

	protected static void InvokeUserCode_LoadPlayerNameRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC LoadPlayerNameRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_LoadPlayerNameRpc();
		}
	}

	protected void UserCode_SetPlayerNameCmd__String(string name)
	{
		SetPlayerNameRpc(name);
	}

	protected static void InvokeUserCode_SetPlayerNameCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetPlayerNameCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_SetPlayerNameCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_SetPlayerNameRpc__String(string name)
	{
		playerName = name;
		nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		nameText.text = playerName;
	}

	protected static void InvokeUserCode_SetPlayerNameRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetPlayerNameRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_SetPlayerNameRpc__String(reader.ReadString());
		}
	}

	protected void UserCode_ChangeTimeDetectedCmd__Single__Int32(float change, int index)
	{
		ChangeTimeDetectedRpc(change, index);
	}

	protected static void InvokeUserCode_ChangeTimeDetectedCmd__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeTimeDetectedCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeTimeDetectedCmd__Single__Int32(reader.ReadFloat(), reader.ReadVarInt());
		}
	}

	protected void UserCode_ChangeTimeDetectedRpc__Single__Int32(float change, int index)
	{
		timeDetected[index] += change;
		if (timeDetected[index] < 0f)
		{
			timeDetected[index] = 0f;
		}
		else if (timeDetected[index] > 2f)
		{
			timeDetected[index] = 2f;
		}
	}

	protected static void InvokeUserCode_ChangeTimeDetectedRpc__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeTimeDetectedRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeTimeDetectedRpc__Single__Int32(reader.ReadFloat(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CallAlertedCreatureCmd()
	{
		CallAlertedCreatureRpc();
	}

	protected static void InvokeUserCode_CallAlertedCreatureCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CallAlertedCreatureCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_CallAlertedCreatureCmd();
		}
	}

	protected void UserCode_CallAlertedCreatureRpc()
	{
		if (!(ClientPlayer.Instance.playerMan != this))
		{
			alertedTheCreatureWarning.SetTrigger("Alert");
		}
	}

	protected static void InvokeUserCode_CallAlertedCreatureRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CallAlertedCreatureRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_CallAlertedCreatureRpc();
		}
	}

	protected void UserCode_AddToEnemiesListCmd__UInt32(uint netId)
	{
		AddToEnemiesListRpc(netId);
	}

	protected static void InvokeUserCode_AddToEnemiesListCmd__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AddToEnemiesListCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_AddToEnemiesListCmd__UInt32(reader.ReadVarUInt());
		}
	}

	protected void UserCode_AddToEnemiesListRpc__UInt32(uint netId)
	{
		if (NetworkClient.spawned.TryGetValue(netId, out var value))
		{
			enemiesList.Add(value.transform.GetChild(0).gameObject);
		}
		else
		{
			Debug.LogWarning($"Object with netId {netId} not found on client!");
		}
	}

	protected static void InvokeUserCode_AddToEnemiesListRpc__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AddToEnemiesListRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_AddToEnemiesListRpc__UInt32(reader.ReadVarUInt());
		}
	}

	protected void UserCode_SetPoster__CreatingPoster(CreatingPoster poster)
	{
		if (base.isLocalPlayer)
		{
			poster.StartCreating(this);
		}
	}

	protected static void InvokeUserCode_SetPoster__CreatingPoster(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetPoster called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_SetPoster__CreatingPoster(reader.ReadNetworkBehaviour<CreatingPoster>());
		}
	}

	protected void UserCode_GetStuckCmd__Single(float amountOfStucks)
	{
		GetStuckRpc(amountOfStucks);
	}

	protected static void InvokeUserCode_GetStuckCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GetStuckCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_GetStuckCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_GetStuckRpc__Single(float amountOfStucks)
	{
		if (base.isLocalPlayer && !cantGetStuck && !downed && !paused)
		{
			canPause = false;
			cantGetStuck = true;
			Invoke("CanGetStuckAgain", 3f);
			thirdPersonMan.GetStuck();
			gottenUnstuck = false;
			maxAmountOfStucks = amountOfStucks;
			curAmountOfStucks = amountOfStucks;
			stuckBar1.fillAmount = curAmountOfStucks / maxAmountOfStucks;
			stuckBar2.fillAmount = curAmountOfStucks / maxAmountOfStucks;
			fpsScript.lockMove = true;
			fpsScript.lockCam = true;
			inventoryMan.PauseUseItem();
			stuck = true;
			stuckUI.SetActive(value: true);
			SwitchStuckKeys();
		}
	}

	protected static void InvokeUserCode_GetStuckRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GetStuckRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_GetStuckRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeInsideStatusCmd__Boolean(bool on)
	{
		ChangeInsideStatusRpc(on);
	}

	protected static void InvokeUserCode_ChangeInsideStatusCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeInsideStatusCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeInsideStatusCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeInsideStatusRpc__Boolean(bool on)
	{
		inside = on;
	}

	protected static void InvokeUserCode_ChangeInsideStatusRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeInsideStatusRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeInsideStatusRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeTimeSpentOutsideCmd__Single(float time)
	{
		ChangeTimeSpentOutsideRpc(time);
	}

	protected static void InvokeUserCode_ChangeTimeSpentOutsideCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeTimeSpentOutsideCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeTimeSpentOutsideCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeTimeSpentOutsideRpc__Single(float time)
	{
		timeSpentOutside = time;
	}

	protected static void InvokeUserCode_ChangeTimeSpentOutsideRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeTimeSpentOutsideRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeTimeSpentOutsideRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_TakeDamageCmd__Single__Boolean(float damage, bool significantAnim)
	{
		TakeDamageRpc(damage, significantAnim);
	}

	protected static void InvokeUserCode_TakeDamageCmd__Single__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command TakeDamageCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_TakeDamageCmd__Single__Boolean(reader.ReadFloat(), reader.ReadBool());
		}
	}

	protected void UserCode_TakeDamageRpc__Single__Boolean(float damage, bool significantAnim)
	{
		if (dead || downed)
		{
			return;
		}
		timeUntilCanHeal = 5f;
		if (significantAnim)
		{
			UnityEngine.Object.Instantiate(hitBlood, base.transform.position, Quaternion.identity);
		}
		if (ClientPlayer.Instance.playerMan != this)
		{
			return;
		}
		if (customizablesMenuOpen)
		{
			CloseCustomizablesMenu();
		}
		GetUnstuck();
		if (PlayerPrefs.GetInt("GodMode") == 1)
		{
			return;
		}
		if (PlayerPrefs.GetInt("CamShake", 1) != 0)
		{
			headbobAnim.SetTrigger("TakeDamage");
		}
		if (significantAnim)
		{
			dmgScreen.SetActive(value: false);
			dmgScreen.SetActive(value: true);
		}
		else
		{
			lightDmgScreen.SetActive(value: false);
			lightDmgScreen.SetActive(value: true);
		}
		camShake.intensity = 0.1f;
		health -= damage;
		SetHealthUI();
		if (health <= 0f)
		{
			health = 0f;
			Downed();
		}
		else
		{
			Invoke("RecoverDamage", 1.7f);
			damaged = true;
		}
		Computer.Instance.StopInteract();
		RestockShelf[] restockShelves = Shelves.Instance.restockShelves;
		foreach (RestockShelf restockShelf in restockShelves)
		{
			if ((bool)restockShelf)
			{
				restockShelf.StopInteract();
			}
		}
		IDCard[] array = UnityEngine.Object.FindObjectsOfType<IDCard>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].StopInteract();
		}
		DialogueInteractable[] array2 = UnityEngine.Object.FindObjectsOfType<DialogueInteractable>();
		foreach (DialogueInteractable obj in array2)
		{
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
			obj.ExitDialogue();
		}
		TakeDamageAnim();
	}

	protected static void InvokeUserCode_TakeDamageRpc__Single__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TakeDamageRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_TakeDamageRpc__Single__Boolean(reader.ReadFloat(), reader.ReadBool());
		}
	}

	protected void UserCode_DownedCmd()
	{
		DownedRpc();
	}

	protected static void InvokeUserCode_DownedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DownedCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_DownedCmd();
		}
	}

	protected void UserCode_DownedRpc()
	{
		downedTime = 30f;
		downCollider.SetActive(value: true);
		inventoryMan.downed = true;
		downed = true;
		fpsScript.downed = true;
		cameraHolderAnim.SetBool("Downed", value: true);
		thirdPersonMan.armsAnim.SetBool("Downed", value: true);
		thirdPersonMan.bodyAnim.SetBool("Downed", value: true);
		thirdPersonMan.legsAnim.SetBool("Downed", value: true);
		inventoryMan.PauseInventory();
		inventoryMan.PauseUseItem();
	}

	protected static void InvokeUserCode_DownedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DownedRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_DownedRpc();
		}
	}

	protected void UserCode_EveryoneDiedCmd()
	{
		EveryoneDiedRpc();
	}

	protected static void InvokeUserCode_EveryoneDiedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EveryoneDiedCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_EveryoneDiedCmd();
		}
	}

	protected void UserCode_EveryoneDiedRpc()
	{
		if (this == ClientPlayer.Instance.playerMan)
		{
			inventoryMan.PauseInventory();
			downedUI.SetActive(value: false);
			storeMan.canvas.SetActive(value: false);
			deathScreen.SetActive(value: true);
			inventoryMan.PauseInventory();
		}
		Invoke("LoadLatestSave", 6.5f);
	}

	protected static void InvokeUserCode_EveryoneDiedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EveryoneDiedRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_EveryoneDiedRpc();
		}
	}

	protected void UserCode_DieCmd()
	{
		DieRpc();
	}

	protected static void InvokeUserCode_DieCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DieCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_DieCmd();
		}
	}

	protected void UserCode_DieRpc()
	{
		if (base.isLocalPlayer)
		{
			StoreManager.Instance.EnterCutscene(disablePlayerMan: false);
			CancelInvoke("CheckIfAllDowned");
			inventoryMan.PauseInventory();
			dead = true;
			canvas.SetActive(value: false);
			spectatingCamera.SetActive(value: true);
			cameraHolder.SetActive(value: false);
			inventoryMan.enabled = false;
			interactMan.enabled = false;
			fpsScript.enabled = false;
			inventoryMan.PauseInventory();
			storeMan.canvas.SetActive(value: false);
		}
		inventoryMan.PauseInventory();
		nameText.gameObject.SetActive(value: false);
		charController.enabled = false;
		downCollider.SetActive(value: false);
		dead = true;
		thirdPersonMan.bodyAnim.gameObject.SetActive(value: false);
		UnityEngine.Object.Instantiate(deathBlood, base.transform.position, Quaternion.identity);
		if (base.isServer)
		{
			SpawnFlesh();
		}
	}

	protected static void InvokeUserCode_DieRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DieRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_DieRpc();
		}
	}

	protected void UserCode_CompleteDayCmd()
	{
		CompleteDayRpc();
	}

	protected static void InvokeUserCode_CompleteDayCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CompleteDayCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_CompleteDayCmd();
		}
	}

	protected void UserCode_CompleteDayRpc()
	{
		charController.enabled = false;
		downCollider.SetActive(value: false);
		thirdPersonMan.bodyAnim.gameObject.SetActive(value: false);
	}

	protected static void InvokeUserCode_CompleteDayRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CompleteDayRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_CompleteDayRpc();
		}
	}

	protected void UserCode_RespawnCmd()
	{
		RespawnRpc();
	}

	protected static void InvokeUserCode_RespawnCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RespawnCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_RespawnCmd();
		}
	}

	protected void UserCode_RespawnRpc()
	{
		charController.enabled = true;
		downCollider.SetActive(value: false);
		dead = false;
		thirdPersonMan.bodyAnim.gameObject.SetActive(value: true);
	}

	protected static void InvokeUserCode_RespawnRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RespawnRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_RespawnRpc();
		}
	}

	protected void UserCode_PauseDownedTimerCmd__Boolean(bool change)
	{
		PauseDownedTimerRpc(change);
	}

	protected static void InvokeUserCode_PauseDownedTimerCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PauseDownedTimerCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_PauseDownedTimerCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_PauseDownedTimerRpc__Boolean(bool change)
	{
		pauseDownedTimer = change;
	}

	protected static void InvokeUserCode_PauseDownedTimerRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PauseDownedTimerRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_PauseDownedTimerRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_TurnOffObjectsChildCmd__GameObject(GameObject obj)
	{
		TurnOffObjectsChildRpc(obj);
	}

	protected static void InvokeUserCode_TurnOffObjectsChildCmd__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command TurnOffObjectsChildCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_TurnOffObjectsChildCmd__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_TurnOffObjectsChildRpc__GameObject(GameObject obj)
	{
		if (obj.transform.childCount > 0)
		{
			obj.transform.GetChild(0).gameObject.SetActive(value: false);
		}
		else
		{
			Debug.LogWarning("Parent has no children to disable.");
		}
	}

	protected static void InvokeUserCode_TurnOffObjectsChildRpc__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOffObjectsChildRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_TurnOffObjectsChildRpc__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_ChangeInsideVentCmd__Boolean(bool change)
	{
		ChangeInsideVentRpc(change);
	}

	protected static void InvokeUserCode_ChangeInsideVentCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeInsideVentCmd called on client.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeInsideVentCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeInsideVentRpc__Boolean(bool change)
	{
		insideVent = change;
	}

	protected static void InvokeUserCode_ChangeInsideVentRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeInsideVentRpc called on server.");
		}
		else
		{
			((PlayerManager)obj).UserCode_ChangeInsideVentRpc__Boolean(reader.ReadBool());
		}
	}

	static PlayerManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::LoadPlayerNameCmd()", InvokeUserCode_LoadPlayerNameCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::SetPlayerNameCmd(System.String)", InvokeUserCode_SetPlayerNameCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::ChangeTimeDetectedCmd(System.Single,System.Int32)", InvokeUserCode_ChangeTimeDetectedCmd__Single__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::CallAlertedCreatureCmd()", InvokeUserCode_CallAlertedCreatureCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::AddToEnemiesListCmd(System.UInt32)", InvokeUserCode_AddToEnemiesListCmd__UInt32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::GetStuckCmd(System.Single)", InvokeUserCode_GetStuckCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::ChangeInsideStatusCmd(System.Boolean)", InvokeUserCode_ChangeInsideStatusCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::ChangeTimeSpentOutsideCmd(System.Single)", InvokeUserCode_ChangeTimeSpentOutsideCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::TakeDamageCmd(System.Single,System.Boolean)", InvokeUserCode_TakeDamageCmd__Single__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::DownedCmd()", InvokeUserCode_DownedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::EveryoneDiedCmd()", InvokeUserCode_EveryoneDiedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::DieCmd()", InvokeUserCode_DieCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::CompleteDayCmd()", InvokeUserCode_CompleteDayCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::RespawnCmd()", InvokeUserCode_RespawnCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::PauseDownedTimerCmd(System.Boolean)", InvokeUserCode_PauseDownedTimerCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::TurnOffObjectsChildCmd(UnityEngine.GameObject)", InvokeUserCode_TurnOffObjectsChildCmd__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerManager), "System.Void PlayerManager::ChangeInsideVentCmd(System.Boolean)", InvokeUserCode_ChangeInsideVentCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::ChangeHuntLight(System.Boolean)", InvokeUserCode_ChangeHuntLight__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::LoadPlayerNameRpc()", InvokeUserCode_LoadPlayerNameRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::SetPlayerNameRpc(System.String)", InvokeUserCode_SetPlayerNameRpc__String);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::ChangeTimeDetectedRpc(System.Single,System.Int32)", InvokeUserCode_ChangeTimeDetectedRpc__Single__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::CallAlertedCreatureRpc()", InvokeUserCode_CallAlertedCreatureRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::AddToEnemiesListRpc(System.UInt32)", InvokeUserCode_AddToEnemiesListRpc__UInt32);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::SetPoster(CreatingPoster)", InvokeUserCode_SetPoster__CreatingPoster);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::GetStuckRpc(System.Single)", InvokeUserCode_GetStuckRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::ChangeInsideStatusRpc(System.Boolean)", InvokeUserCode_ChangeInsideStatusRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::ChangeTimeSpentOutsideRpc(System.Single)", InvokeUserCode_ChangeTimeSpentOutsideRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::TakeDamageRpc(System.Single,System.Boolean)", InvokeUserCode_TakeDamageRpc__Single__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::DownedRpc()", InvokeUserCode_DownedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::EveryoneDiedRpc()", InvokeUserCode_EveryoneDiedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::DieRpc()", InvokeUserCode_DieRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::CompleteDayRpc()", InvokeUserCode_CompleteDayRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::RespawnRpc()", InvokeUserCode_RespawnRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::PauseDownedTimerRpc(System.Boolean)", InvokeUserCode_PauseDownedTimerRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::TurnOffObjectsChildRpc(UnityEngine.GameObject)", InvokeUserCode_TurnOffObjectsChildRpc__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerManager), "System.Void PlayerManager::ChangeInsideVentRpc(System.Boolean)", InvokeUserCode_ChangeInsideVentRpc__Boolean);
	}
}
