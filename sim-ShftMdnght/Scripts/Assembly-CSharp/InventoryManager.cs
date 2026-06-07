using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : NetworkBehaviour
{
	public int curInventorySlot;

	public int maxInventorySlots = 2;

	public int[] inventoryIds;

	public int[] inventoryAmounts;

	public TextMeshProUGUI[] inventoryAmountTexts;

	public GameObject[] inventoryAmountTextFades;

	public GameObject[] holdingObjs;

	public GameObject[] itemCanvases;

	public Animator[] holdingAnims;

	public Transform[] dropAnchors;

	public int[] maxStack;

	public Sprite[] objSprites;

	public Image[] inventorySprites;

	public Image[] inventorySprites_;

	public Animator[] inventorySlots;

	public Sprite emptySprite;

	public Animator pistolAnim;

	public Animator shotgunAnim;

	public int holdingIndex = -1;

	public Transform throwAnchor;

	public Collider playerCol;

	public Collider justThrownCol;

	public LayerMask throwObstacle;

	public CharacterController characterController;

	public List<Collider> collidersToCheck;

	public Transform playerCam;

	public CameraShake camShake;

	public Recoil recoil;

	private bool canShoot = true;

	public bool canControlItem = true;

	public PlayerManager playerMan;

	public GameObject flashlightLight;

	public LayerMask shootable;

	public LayerMask cleanable;

	public GameObject hitParticle;

	public Animator mopAnim;

	private bool hasTrash;

	public int[] crateStorages;

	private GameObject returnObj;

	public int[] trash;

	public RemoteTrap[] remoteTraps;

	public Animator trashBagAnim;

	public GameObject killMarker;

	public GameObject hitMarker;

	public GameObject mopReturned;

	public AudioSource pistolDryShot;

	private float taskCompletion;

	private float taskCompletionMax;

	public Image completingTaskFillAmount;

	public Image completingBoardFillAmount;

	public Image completingExplosiveFillAmount;

	public Image completingHeal;

	private Transform bearTrapTemplate;

	private Transform bearTrapTemplateRed;

	private Transform landmineTemplate;

	private Transform landmineTemplateRed;

	private Transform stunMineTemplate;

	private Transform stunMineTemplateRed;

	private Transform explosiveTemplate;

	private Transform explosiveTemplateRed;

	private Transform posterTemplate;

	private Transform pottedPlantTemplate;

	private Transform pottedPlantTemplateRed;

	private Transform waterCoolerTemplate;

	private Transform waterCoolerTemplateRed;

	private Transform basketRackTemplate;

	private Transform basketRackTemplateRed;

	private Transform atmTemplate;

	private Transform atmTemplateRed;

	private Transform mailboxTemplate;

	private Transform mailboxTemplateRed;

	private Transform trashCanTemplate;

	private Transform trashCanTemplateRed;

	private Transform bannerTemplate;

	private Transform bannerTemplateRed;

	private Transform floorMatTemplate;

	private Transform floorMatTemplateRed;

	private Transform sunglassesRackTemplate;

	private Transform sunglassesRackTemplateRed;

	private Transform booksTemplate;

	private Transform booksTemplateRed;

	private Transform bobbleHeadTemplate;

	private Transform bobbleHeadTemplateRed;

	private Transform burgerTemplate;

	private Transform burgerTemplateRed;

	private Transform plant1Template;

	private Transform plant1TemplateRed;

	private Transform plant2Template;

	private Transform plant2TemplateRed;

	private Transform plant3Template;

	private Transform plant3TemplateRed;

	private Transform plant4Template;

	private Transform plant4TemplateRed;

	private Transform robotTemplate;

	private Transform robotTemplateRed;

	private Transform boomboxTemplate;

	private Transform boomboxTemplateRed;

	private Transform gumballTemplate;

	private Transform gumballTemplateRed;

	private Transform clockTemplate;

	private Transform clockTemplateRed;

	private Transform ivyTemplate;

	private Transform ivyTemplateRed;

	private Transform stringLightsTemplate;

	private Transform stringLightsTemplateRed;

	private Transform painting1Template;

	private Transform painting1TemplateRed;

	private Transform painting2Template;

	private Transform painting2TemplateRed;

	private Transform painting3Template;

	private Transform painting3TemplateRed;

	private Transform deerTemplate;

	private Transform deerTemplateRed;

	public LayerMask trapObstacles;

	public GameObject placedLandmine;

	public GameObject placedStunMine;

	public GameObject placedbearTrap;

	public GameObject placedExplosive;

	public GameObject placedPoster;

	public GameObject placedPottedPlant;

	public GameObject placedWaterCooler;

	public GameObject placedBasketRack;

	public GameObject placedATM;

	public GameObject placedMailbox;

	public GameObject placedTrashcan;

	public GameObject placedBanner;

	public GameObject placedFloorMat;

	public GameObject placedSunglassesRack;

	public GameObject placedBooks;

	public GameObject placedBobbleHead;

	public GameObject placedBurger;

	public GameObject placedPlant1;

	public GameObject placedPlant2;

	public GameObject placedPlant3;

	public GameObject placedPlant4;

	public GameObject placedRobot;

	public GameObject placedBoombox;

	public GameObject placedGumball;

	public GameObject placedClock;

	public GameObject placedIvy;

	public GameObject placedStringLights;

	public GameObject placedPainting1;

	public GameObject placedPainting2;

	public GameObject placedPainting3;

	public GameObject placedDeer;

	private bool letGoOfInteract;

	public Animator explosiveHeldAnim;

	public Animator landmineHeldAnim;

	public Animator stunMineHeldAnim;

	public Animator bearTrapHeldAnim;

	public Animator plankHeldAnim;

	public InteractManager interactMan;

	private Barricade curBarricade;

	public GameObject promptObj;

	public LayerMask blocksPlacementLayerMask;

	public LayerMask smallItemPlacementLayerMask;

	public LayerMask posterPlacementLayerMask;

	public bool alreadyPlacing;

	public Animator alertedTheCreatureWarning;

	private bool justStartPlacingTrap;

	public GameObject explosiveRemote;

	public StoreManager storeMan;

	public ThirdPersonManager thirdPersonMan;

	public Transform playerShootPoint;

	public Transform flamethrowerShootPoint;

	public CharacterController charController;

	public bool downed;

	public GameObject spillCam;

	public bool hasThrownIntoPulverizerBefore;

	public bool tasking;

	public GameObject emotiscopeSearching;

	public GameObject emotiscopeScanning;

	public GameObject emotiscopeFound;

	public LayerMask emotiscopeLayer;

	public TextMeshProUGUI emotiscopeEmotionText;

	public GameObject scanningDataSfx;

	public Image scanBar;

	private float curScan;

	public AudioSource flashlightToggle;

	public bool gunJammed;

	public GameObject[] gunVines;

	public Animator gasPumpTrigger;

	public Animator duckAnim;

	public Transform gasPumpOrigin;

	public float gasPumpCurDistance;

	public ParticleSystem gasPumpGasParticles;

	public ParticleSystem gasPumpSmokeParticles;

	public AudioSource gasPumpShootSfx;

	public AudioSource gasPumpEmptySfx;

	public Transform thirdPersonGasPump;

	public LayerMask petrolTankLayer;

	public bool inventoryPaused;

	public GameObject inventoryUIHolder;

	public GameObject healthUIHolder;

	public TextMeshProUGUI flamethrowerAmmoText;

	public int flamethrowerAmmo;

	public GameObject flamethrowerThrown;

	public bool hasGun;

	public AudioSource flamethrowerFireLoop;

	private bool justStartedGasPump = true;

	private bool justStoppedGasPump = true;

	public int rotationIndex;

	private bool canAttack = true;

	private bool justStopLookingAtDi;

	private DialogueInteractable lastDi;

	public GameObject[] pistolBulletIcons;

	private bool reloading;

	public Image reloadBar;

	private Coroutine reloadRoutine;

	public GameObject[] shotgunBulletIcons;

	public Image reloadShotgunBar;

	private int curEnemyShotIndex;

	public GameObject[] meleeHitParticles;

	[SyncVar]
	public ulong steamId;

	public bool alreadyLoadedInventory;

	public ulong NetworksteamId
	{
		get
		{
			return steamId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref steamId, 1uL, null);
		}
	}

	public void PauseInventory()
	{
		if (base.isLocalPlayer)
		{
			if (flashlightLight.activeInHierarchy)
			{
				storeMan.FlashlightToggled(-1);
			}
			flashlightLight.SetActive(value: false);
			inventoryPaused = true;
			inventoryUIHolder.SetActive(value: false);
			healthUIHolder.SetActive(value: false);
		}
	}

	public void UnpauseInventory()
	{
		if (base.isLocalPlayer && !playerMan.downed && !playerMan.dead)
		{
			inventoryPaused = false;
			inventoryUIHolder.SetActive(value: true);
			healthUIHolder.SetActive(value: true);
			UpdateInventorySlotsUI();
		}
	}

	public void ChangeInventorySlot(int slot)
	{
		if (!tasking && !inventoryPaused)
		{
			PauseUseItem();
			if (slot == curInventorySlot)
			{
				UpdateCurInventorySlot(-1);
			}
			else
			{
				UpdateHoldingIndex(inventoryIds[slot]);
				UpdateCurInventorySlot(slot);
			}
			UpdateInventorySlotsUI();
		}
	}

	public void UpdateInventorySlotsUI()
	{
		Animator[] array = inventorySlots;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetBool("On", value: false);
		}
		if (curInventorySlot != -1)
		{
			UnpauseUseItem();
			inventorySlots[curInventorySlot].SetBool("On", value: true);
		}
		else
		{
			PauseUseItem();
		}
		for (int j = 0; j < maxInventorySlots; j++)
		{
			if (inventoryAmounts[j] <= 1)
			{
				inventoryAmountTextFades[j].SetActive(value: false);
				inventoryAmountTexts[j].text = "";
			}
			else
			{
				inventoryAmountTextFades[j].SetActive(value: true);
				inventoryAmountTexts[j].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				inventoryAmountTexts[j].text = inventoryAmounts[j].ToString();
			}
			if (inventoryIds[j] == -1)
			{
				inventorySprites[j].sprite = emptySprite;
				inventorySprites_[j].sprite = emptySprite;
			}
			else
			{
				inventorySprites[j].sprite = objSprites[inventoryIds[j]];
				inventorySprites_[j].sprite = objSprites[inventoryIds[j]];
			}
		}
		if (!base.isServer)
		{
			UpdateInventoryForHostCmd(inventoryIds, inventoryAmounts, trash);
		}
	}

	[Command(requiresAuthority = false)]
	private void UpdateInventoryForHostCmd(int[] inventoryIds_, int[] inventoryAmounts_, int[] trash_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002EInt32_005B_005D(writer, inventoryIds_);
		GeneratedNetworkCode._Write_System_002EInt32_005B_005D(writer, inventoryAmounts_);
		GeneratedNetworkCode._Write_System_002EInt32_005B_005D(writer, trash_);
		SendCommandInternal("System.Void InventoryManager::UpdateInventoryForHostCmd(System.Int32[],System.Int32[],System.Int32[])", 1328088373, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void CheckIfRemotesStillOn()
	{
		for (int i = 0; i < inventoryIds.Length; i++)
		{
			if (inventoryIds[i] == 42 && remoteTraps[i] == null)
			{
				inventoryIds[i] = -1;
				inventoryAmounts[i] = 0;
				UpdateInventorySlotsUI();
			}
		}
	}

	public void SetRemoteTrap(RemoteTrap trap)
	{
		remoteTraps[curInventorySlot] = trap;
	}

	private void Explode()
	{
		remoteTraps[curInventorySlot].Press();
		explosiveRemote.SetActive(value: false);
		remoteTraps[curInventorySlot] = null;
	}

	[ClientRpc]
	public void SetMaxInventorySlots(int slots)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(slots);
		SendRPCInternal("System.Void InventoryManager::SetMaxInventorySlots(System.Int32)", 2115869122, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GunJam()
	{
		gunJammed = true;
		GameObject[] array = gunVines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}

	public void GunUnjam()
	{
		gunJammed = false;
		GameObject[] array = gunVines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	[ClientRpc]
	public void Pulverized()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void InventoryManager::Pulverized()", -1211250264, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void OnEnable()
	{
		storeMan = StoreManager.Instance;
		bearTrapTemplate = storeMan.bearTrapTemplate;
		bearTrapTemplateRed = storeMan.bearTrapTemplateRed;
		explosiveTemplate = storeMan.explosiveTemplate;
		explosiveTemplateRed = storeMan.explosiveTemplateRed;
		posterTemplate = storeMan.posterTemplate;
		pottedPlantTemplate = storeMan.pottedPlantTemplate;
		pottedPlantTemplateRed = storeMan.pottedPlantTemplateRed;
		waterCoolerTemplate = storeMan.waterCoolerTemplate;
		waterCoolerTemplateRed = storeMan.waterCoolerTemplateRed;
		basketRackTemplate = storeMan.basketRackTemplate;
		basketRackTemplateRed = storeMan.basketRackTemplateRed;
		atmTemplate = storeMan.atmTemplate;
		atmTemplateRed = storeMan.atmTemplateRed;
		mailboxTemplate = storeMan.mailboxTemplate;
		mailboxTemplateRed = storeMan.mailboxTemplateRed;
		trashCanTemplate = storeMan.trashCanTemplate;
		trashCanTemplateRed = storeMan.trashCanTemplateRed;
		bannerTemplate = storeMan.bannerTemplate;
		bannerTemplateRed = storeMan.bannerTemplateRed;
		floorMatTemplate = storeMan.floorMatTemplate;
		floorMatTemplateRed = storeMan.floorMatTemplateRed;
		sunglassesRackTemplate = storeMan.sunglassesRackTemplate;
		sunglassesRackTemplateRed = storeMan.sunglassesRackTemplateRed;
		booksTemplate = storeMan.booksTemplate;
		booksTemplateRed = storeMan.booksTemplateRed;
		bobbleHeadTemplate = storeMan.bobbleHeadTemplate;
		bobbleHeadTemplateRed = storeMan.bobbleHeadTemplateRed;
		burgerTemplate = storeMan.burgerTemplate;
		burgerTemplateRed = storeMan.burgerTemplateRed;
		plant1Template = storeMan.plant1Template;
		plant1TemplateRed = storeMan.plant1TemplateRed;
		plant2Template = storeMan.plant2Template;
		plant2TemplateRed = storeMan.plant2TemplateRed;
		plant3Template = storeMan.plant3Template;
		plant3TemplateRed = storeMan.plant3TemplateRed;
		plant4Template = storeMan.plant4Template;
		plant4TemplateRed = storeMan.plant4TemplateRed;
		robotTemplate = storeMan.robotTemplate;
		robotTemplateRed = storeMan.robotTemplateRed;
		boomboxTemplate = storeMan.boomboxTemplate;
		boomboxTemplateRed = storeMan.boomboxTemplateRed;
		gumballTemplate = storeMan.gumballTemplate;
		gumballTemplateRed = storeMan.gumballTemplateRed;
		clockTemplate = storeMan.clockTemplate;
		clockTemplateRed = storeMan.clockTemplateRed;
		ivyTemplate = storeMan.ivyTemplate;
		ivyTemplateRed = storeMan.ivyTemplateRed;
		stringLightsTemplate = storeMan.stringLightsTemplate;
		stringLightsTemplateRed = storeMan.stringLightsTemplateRed;
		painting1Template = storeMan.painting1Template;
		painting1TemplateRed = storeMan.painting1TemplateRed;
		painting2Template = storeMan.painting2Template;
		painting2TemplateRed = storeMan.painting2TemplateRed;
		painting3Template = storeMan.painting3Template;
		painting3TemplateRed = storeMan.painting3TemplateRed;
		deerTemplate = storeMan.deerTemplate;
		deerTemplateRed = storeMan.deerTemplateRed;
		landmineTemplate = storeMan.landmineTemplate;
		landmineTemplateRed = storeMan.landmineTemplateRed;
		stunMineTemplate = storeMan.stunMineTemplate;
		stunMineTemplateRed = storeMan.stunMineTemplateRed;
	}

	private void Start()
	{
		if (!base.isLocalPlayer)
		{
			base.enabled = false;
			return;
		}
		SaveManager.Instance.Invoke("SetValuesForClients", 1f);
		SaveManager.Instance.Invoke("SetValuesForClients", 5f);
		SaveManager.Instance.Invoke("SetValuesForClients", 10f);
	}

	private void TokenHint()
	{
	}

	private void UpdateHoldingIndex(int index)
	{
		holdingIndex = index;
		if (base.isServer)
		{
			UpdateHoldingIndexRpc(index);
		}
		else
		{
			UpdateHoldingIndexCmd(index);
		}
	}

	[Command(requiresAuthority = false)]
	private void UpdateHoldingIndexCmd(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		SendCommandInternal("System.Void InventoryManager::UpdateHoldingIndexCmd(System.Int32)", -778121653, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateHoldingIndexRpc(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		SendRPCInternal("System.Void InventoryManager::UpdateHoldingIndexRpc(System.Int32)", 1240371800, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void IgnoreCollision(GameObject a, GameObject b)
	{
		Collider collider = null;
		Collider collider2 = null;
		if ((bool)a.GetComponent<CharacterController>())
		{
			collider = a.GetComponent<CharacterController>();
		}
		else if ((bool)a.GetComponent<PickupObject>())
		{
			collider = a.GetComponent<PickupObject>().col;
		}
		if ((bool)b.GetComponent<CharacterController>())
		{
			collider2 = b.GetComponent<CharacterController>();
		}
		else if ((bool)b.GetComponent<PickupObject>())
		{
			collider2 = b.GetComponent<PickupObject>().col;
		}
		if ((bool)collider && (bool)collider2)
		{
			Physics.IgnoreCollision(collider, collider2);
			if (base.isServer)
			{
				IgnoreCollisionRpc(a, b);
			}
			else
			{
				IgnoreCollisionCmd(a, b);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void IgnoreCollisionCmd(GameObject a, GameObject b)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(a);
		writer.WriteGameObject(b);
		SendCommandInternal("System.Void InventoryManager::IgnoreCollisionCmd(UnityEngine.GameObject,UnityEngine.GameObject)", 685732076, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void IgnoreCollisionRpc(GameObject a, GameObject b)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(a);
		writer.WriteGameObject(b);
		SendRPCInternal("System.Void InventoryManager::IgnoreCollisionRpc(UnityEngine.GameObject,UnityEngine.GameObject)", 1287012993, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator StopIgnoreCollision(GameObject a, GameObject b)
	{
		yield return new WaitForSeconds(0.4f);
		StopIgnoreCollisionRpc(a, b);
	}

	[ClientRpc]
	private void StopIgnoreCollisionRpc(GameObject a, GameObject b)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(a);
		writer.WriteGameObject(b);
		SendRPCInternal("System.Void InventoryManager::StopIgnoreCollisionRpc(UnityEngine.GameObject,UnityEngine.GameObject)", 2116535209, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ToggleBearTrapRadii(bool on)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Bear Trap");
		foreach (GameObject gameObject in array)
		{
			if (!gameObject.GetComponent<BearTrap>().caught)
			{
				if (on)
				{
					gameObject.GetComponent<BearTrap>().EnableRadius();
				}
				else
				{
					gameObject.GetComponent<BearTrap>().DisableRadius();
				}
			}
		}
	}

	public void ToggleLandmineRadii(bool on)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Landmine");
		foreach (GameObject gameObject in array)
		{
			if (on)
			{
				gameObject.GetComponent<Landmine>().EnableRadius();
			}
			else
			{
				gameObject.GetComponent<Landmine>().DisableRadius();
			}
		}
	}

	public void ToggleStunMineRadii(bool on)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("StunMine");
		foreach (GameObject gameObject in array)
		{
			if (!gameObject.GetComponent<StunMine>().caught)
			{
				if (on)
				{
					gameObject.GetComponent<StunMine>().EnableRadius();
				}
				else
				{
					gameObject.GetComponent<StunMine>().DisableRadius();
				}
			}
		}
	}

	public void PickupNewObj(int index, int amountOfItems)
	{
		if (downed)
		{
			return;
		}
		if (index == 2)
		{
			ChangeHasGun(hasGun_: true);
		}
		canAttack = true;
		gasPumpOrigin = StoreManager.Instance.gasPumpOrigin;
		gasPumpCurDistance = 0f;
		if (index == -5)
		{
			if (base.isLocalPlayer)
			{
				StoreManager.Instance.SetAlert("Token Found!", "gold");
				StoreManager.Instance.ChangeTokenBalance(1);
			}
			return;
		}
		if (flashlightLight.activeInHierarchy)
		{
			storeMan.FlashlightToggled(-1);
		}
		flashlightLight.SetActive(value: false);
		GameObject[] array2;
		if (base.isServer)
		{
			if (index == 5)
			{
				GameObject[] array = GameObject.FindGameObjectsWithTag("Mop");
				int num = 0;
				bool flag = false;
				GameObject obj = null;
				array2 = array;
				foreach (GameObject gameObject in array2)
				{
					if (!flag)
					{
						flag = true;
						obj = gameObject;
					}
					num++;
					if (num > 5)
					{
						NetworkServer.Destroy(obj);
					}
				}
			}
			if (index == 3)
			{
				GameObject[] array3 = GameObject.FindGameObjectsWithTag("ToiletPaper");
				int num2 = 0;
				bool flag2 = false;
				GameObject obj2 = null;
				array2 = array3;
				foreach (GameObject gameObject2 in array2)
				{
					if (!flag2)
					{
						flag2 = true;
						obj2 = gameObject2;
					}
					num2++;
					if (num2 > 30)
					{
						NetworkServer.Destroy(obj2);
					}
				}
			}
			if (index == 2)
			{
				GameObject[] array4 = GameObject.FindGameObjectsWithTag("Pistol");
				int num3 = 0;
				bool flag3 = false;
				GameObject obj3 = null;
				array2 = array4;
				foreach (GameObject gameObject3 in array2)
				{
					if (!flag3)
					{
						flag3 = true;
						obj3 = gameObject3;
					}
					num3++;
					if (num3 > 5)
					{
						NetworkServer.Destroy(obj3);
					}
				}
			}
			if (index == 11)
			{
				GameObject[] array5 = GameObject.FindGameObjectsWithTag("Emotiscope");
				int num4 = 0;
				bool flag4 = false;
				GameObject obj4 = null;
				array2 = array5;
				foreach (GameObject gameObject4 in array2)
				{
					if (!flag4)
					{
						flag4 = true;
						obj4 = gameObject4;
					}
					num4++;
					if (num4 > 5)
					{
						NetworkServer.Destroy(obj4);
					}
				}
			}
			if (index == 4)
			{
				GameObject[] array6 = GameObject.FindGameObjectsWithTag("Flashlight");
				int num5 = 0;
				bool flag5 = false;
				GameObject obj5 = null;
				array2 = array6;
				foreach (GameObject gameObject5 in array2)
				{
					if (!flag5)
					{
						flag5 = true;
						obj5 = gameObject5;
					}
					num5++;
					if (num5 > 5)
					{
						NetworkServer.Destroy(obj5);
					}
				}
			}
		}
		if (!base.isLocalPlayer)
		{
			return;
		}
		StoreManager.Instance.noMoreAmmo.SetActive(value: false);
		bool flag6 = false;
		for (int j = 0; j < maxInventorySlots; j++)
		{
			if (inventoryIds[j] >= 0 && inventoryIds[j] == index && inventoryAmounts[j] < maxStack[inventoryIds[j]])
			{
				inventoryAmounts[j]++;
				flag6 = true;
				inventoryIds[j] = index;
				UpdateCurInventorySlot(j);
				UpdateInventorySlotsUI();
				PauseUseItem();
				UnpauseUseItem();
				ChangePlayerCrateStorage(playerMan.inventoryMan.curInventorySlot, amountOfItems);
				break;
			}
		}
		if (!flag6)
		{
			for (int k = 0; k < maxInventorySlots; k++)
			{
				if (inventoryIds[k] == -1)
				{
					inventoryAmounts[k]++;
					flag6 = true;
					inventoryIds[k] = index;
					UpdateCurInventorySlot(k);
					UpdateInventorySlotsUI();
					PauseUseItem();
					UnpauseUseItem();
					ChangePlayerCrateStorage(playerMan.inventoryMan.curInventorySlot, amountOfItems);
					break;
				}
			}
		}
		if (!flag6)
		{
			return;
		}
		if (holdingIndex == 15)
		{
			GasPumpHoses.Instance.DisconnectRope(base.transform);
			GasPumpHoses.Instance.ChangeRopeBulge(base.transform, bulgeOn: false);
		}
		StoreManager.Instance.Invoke("CheckAllRemoteTraps", 0.2f);
		alreadyPlacing = false;
		completingBoardFillAmount.gameObject.SetActive(value: false);
		completingTaskFillAmount.gameObject.SetActive(value: false);
		completingExplosiveFillAmount.gameObject.SetActive(value: false);
		if (curInventorySlot >= 0)
		{
			for (int l = 0; l < pistolBulletIcons.Length; l++)
			{
				if (l < crateStorages[curInventorySlot])
				{
					pistolBulletIcons[l].SetActive(value: true);
				}
				else
				{
					pistolBulletIcons[l].SetActive(value: false);
				}
			}
			flamethrowerAmmoText.text = crateStorages[curInventorySlot].ToString("0");
		}
		if (holdingIndex == 6 && trash[curInventorySlot] != 0)
		{
			StoreManager.Instance.SetAlert("Must take trash out back to the dumpster!", "red");
			Vector3 direction = dropAnchors[holdingIndex].position - base.transform.position;
			Vector3 throwPosition = dropAnchors[holdingIndex].position;
			if (Physics.Raycast(base.transform.position, direction, out var hitInfo, 1f, throwObstacle))
			{
				throwPosition = hitInfo.point;
			}
			if (base.isServer)
			{
				StoreManager.Instance.ServerDropObject(index, throwPosition, dropAnchors[holdingIndex].rotation, crateStorages[curInventorySlot], playerCam.forward, this);
			}
			else
			{
				StoreManager.Instance.NetworkDropObject(index, throwPosition, dropAnchors[holdingIndex].rotation, crateStorages[curInventorySlot], playerCam.forward, this);
			}
			return;
		}
		CancelReload();
		trash[curInventorySlot] = 0;
		if (index == 5)
		{
			spillCam.SetActive(value: true);
		}
		UpdateHoldingIndex(index);
		UnpauseUseItem();
		array2 = holdingObjs;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].SetActive(value: false);
		}
		holdingObjs[holdingIndex].SetActive(value: true);
		array2 = itemCanvases;
		foreach (GameObject gameObject6 in array2)
		{
			if ((bool)gameObject6)
			{
				gameObject6.SetActive(value: false);
			}
		}
		itemCanvases[holdingIndex].SetActive(value: true);
		letGoOfInteract = false;
	}

	public void ChangePlayerCrateStorage(int invSlot, int value)
	{
		if (invSlot != -1)
		{
			crateStorages[invSlot] = value;
		}
		if (base.isServer)
		{
			ChangeCrateStorageRpc(invSlot, value);
		}
		else
		{
			ChangeCrateStorageCmd(invSlot, value);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeCrateStorageCmd(int invSlot, int value)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(invSlot);
		writer.WriteVarInt(value);
		SendCommandInternal("System.Void InventoryManager::ChangeCrateStorageCmd(System.Int32,System.Int32)", 1808402878, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeCrateStorageRpc(int invSlot, int value)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(invSlot);
		writer.WriteVarInt(value);
		SendRPCInternal("System.Void InventoryManager::ChangeCrateStorageRpc(System.Int32,System.Int32)", -797273345, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Update()
	{
		if (playerMan.paused)
		{
			return;
		}
		if (Input.GetKeyDown("1"))
		{
			ChangeInventorySlot(0);
		}
		if (Input.GetKeyDown("2"))
		{
			ChangeInventorySlot(1);
		}
		if (Input.GetKeyDown("3") && maxInventorySlots > 2)
		{
			ChangeInventorySlot(2);
		}
		if (Input.GetKeyDown("4") && maxInventorySlots > 3)
		{
			ChangeInventorySlot(3);
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis > 0f)
		{
			int num = curInventorySlot - 1;
			if (curInventorySlot == -1)
			{
				num = 0;
			}
			else if (num < 0)
			{
				num = maxInventorySlots - 1;
			}
			ChangeInventorySlot(num);
		}
		else if (axis < 0f)
		{
			int num2 = curInventorySlot + 1;
			if (curInventorySlot == -1)
			{
				num2 = 0;
			}
			else if (num2 >= maxInventorySlots)
			{
				num2 = 0;
			}
			ChangeInventorySlot(num2);
		}
		if (!canControlItem || holdingIndex == -1)
		{
			return;
		}
		switch (holdingIndex)
		{
		case 0:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			break;
		case 1:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				ThrowObject();
			}
			break;
		case 2:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) && !reloading)
			{
				if (crateStorages[curInventorySlot] > 0)
				{
					if (canShoot)
					{
						if (gunJammed)
						{
							StoreManager.Instance.SetAlert("[ GUN JAMMED ]", "red");
							break;
						}
						crateStorages[curInventorySlot]--;
						if (crateStorages[curInventorySlot] < 1)
						{
							StoreManager.Instance.rToReload.SetActive(value: true);
						}
						pistolBulletIcons[crateStorages[curInventorySlot]].SetActive(value: false);
						Shoot(50f);
						if (PlayerPrefs.GetInt("CamShake", 1) != 0)
						{
							playerMan.fpsScript.headbobAnim.SetTrigger("Shoot");
						}
						pistolAnim.SetTrigger("Shoot");
						camShake.intensity = 0.13f;
						canShoot = false;
						Invoke("CanShoot", 0.26f);
					}
				}
				else
				{
					StoreManager.Instance.rToReload.SetActive(value: true);
					pistolDryShot.Play();
				}
			}
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))) && !reloading && crateStorages[curInventorySlot] < 6)
			{
				holdingAnims[holdingIndex].SetTrigger("Reload");
				reloadRoutine = StartCoroutine(Reload());
			}
			break;
		case 3:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				ThrowObject();
			}
			break;
		case 4:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				flashlightToggle.Play();
				flashlightLight.SetActive(!flashlightLight.activeInHierarchy);
				thirdPersonMan.ToggleFlashlight(flashlightLight.activeInHierarchy);
				if (flashlightLight.activeInHierarchy)
				{
					storeMan.FlashlightToggled(1);
				}
				else
				{
					storeMan.FlashlightToggled(-1);
				}
			}
			break;
		case 5:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				mopAnim.SetBool("Clean", value: true);
				thirdPersonMan.ToggleMop(on: true);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				mopAnim.SetBool("Clean", value: false);
				thirdPersonMan.ToggleMop(on: false);
			}
			break;
		case 6:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				if (trash[curInventorySlot] == 0)
				{
					DropObject();
				}
				else
				{
					StoreManager.Instance.SetAlert("Must take trash out back to the dumpster!", "red");
				}
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				mopAnim.SetBool("Clean", value: true);
				thirdPersonMan.ToggleMop(on: true);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				mopAnim.SetBool("Clean", value: false);
				thirdPersonMan.ToggleMop(on: false);
			}
			break;
		case 7:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			taskCompletionMax = 1.6f;
			RaycastHit hitInfo29;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				bearTrapTemplateRed.gameObject.SetActive(value: false);
				bearTrapHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				completingTaskFillAmount.fillAmount = 0f;
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				bearTrapTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo29, 3.7f, trapObstacles))
			{
				if (Physics.OverlapSphere(new Vector3(hitInfo29.point.x, hitInfo29.point.y + 1f, hitInfo29.point.z), 0.56f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					bearTrapTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					bearTrapTemplateRed.position = hitInfo29.point;
					bearTrapTemplateRed.gameObject.SetActive(value: true);
					bearTrapTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo29.collider.gameObject.layer == 9)
				{
					if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						if (justStartPlacingTrap)
						{
							bearTrapTemplate.position = hitInfo29.point;
							bearTrapTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							justStartPlacingTrap = false;
						}
						tasking = true;
						bearTrapTemplateRed.gameObject.SetActive(value: false);
						alreadyPlacing = true;
						bearTrapHeldAnim.SetBool("Placing", value: true);
						if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
						{
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: true);
						}
						completingTaskFillAmount.gameObject.SetActive(value: true);
						taskCompletion += Time.deltaTime;
						ClientPlayer.Instance.fpsScript.lockCam = true;
						ClientPlayer.Instance.fpsScript.lockMove = true;
						completingTaskFillAmount.fillAmount = taskCompletion / taskCompletionMax;
						if (taskCompletion > taskCompletionMax)
						{
							bearTrapTemplateRed.gameObject.SetActive(value: false);
							alreadyPlacing = false;
							bearTrapHeldAnim.SetBool("Placing", value: false);
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
							taskCompletion = 0f;
							bearTrapTemplate.position = hitInfo29.point;
							bearTrapTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							PlaceItem(playerMan, "bear trap", bearTrapTemplate.position, bearTrapTemplate.rotation);
							completingTaskFillAmount.fillAmount = 0f;
							ClientPlayer.Instance.fpsScript.lockCam = false;
							ClientPlayer.Instance.fpsScript.lockMove = false;
							bearTrapTemplate.gameObject.SetActive(value: false);
							DestroyObject();
							tasking = false;
						}
					}
					else
					{
						tasking = false;
						justStartPlacingTrap = true;
						alreadyPlacing = false;
						bearTrapTemplateRed.gameObject.SetActive(value: false);
						bearTrapHeldAnim.SetBool("Placing", value: false);
						bearTrapTemplate.gameObject.SetActive(value: true);
						bearTrapTemplate.position = hitInfo29.point;
						bearTrapTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
						playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
						completingTaskFillAmount.gameObject.SetActive(value: false);
						taskCompletion = 0f;
						ClientPlayer.Instance.fpsScript.lockCam = false;
						ClientPlayer.Instance.fpsScript.lockMove = false;
					}
				}
				else
				{
					tasking = false;
					bearTrapTemplateRed.gameObject.SetActive(value: false);
					alreadyPlacing = false;
					bearTrapHeldAnim.SetBool("Placing", value: false);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					completingTaskFillAmount.fillAmount = 0f;
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
					bearTrapTemplate.gameObject.SetActive(value: false);
				}
			}
			else if (!interactMan.holdInteracting)
			{
				tasking = false;
				bearTrapTemplateRed.gameObject.SetActive(value: false);
				alreadyPlacing = false;
				bearTrapHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				ClientPlayer.Instance.fpsScript.lockCam = false;
				ClientPlayer.Instance.fpsScript.lockMove = false;
				bearTrapTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 8:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			taskCompletionMax = 2f;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				promptObj.SetActive(value: false);
				plankHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				completingBoardFillAmount.fillAmount = 0f;
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				DropObject();
			}
			if (interactMan.curInteractable == null)
			{
				break;
			}
			if (interactMan.curInteractable.gameObject.TryGetComponent<Barricade>(out var component))
			{
				curBarricade = component;
				if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
				{
					tasking = true;
					plankHeldAnim.SetBool("Placing", value: true);
					if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
					{
						playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: true);
					}
					completingBoardFillAmount.gameObject.SetActive(value: true);
					taskCompletion += Time.deltaTime;
					ClientPlayer.Instance.fpsScript.lockCam = true;
					ClientPlayer.Instance.fpsScript.lockMove = true;
				}
				else
				{
					tasking = false;
					plankHeldAnim.SetBool("Placing", value: false);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					completingBoardFillAmount.gameObject.SetActive(value: false);
					taskCompletion = 0f;
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
				}
				completingBoardFillAmount.fillAmount = taskCompletion / taskCompletionMax;
				if (taskCompletion > taskCompletionMax)
				{
					tasking = false;
					component.Place();
					plankHeldAnim.SetBool("Placing", value: false);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					taskCompletion = 0f;
					completingBoardFillAmount.fillAmount = 0f;
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
					DestroyObject();
					tasking = false;
				}
			}
			else if (!interactMan.holdInteracting)
			{
				tasking = false;
				plankHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				completingBoardFillAmount.fillAmount = 0f;
				ClientPlayer.Instance.fpsScript.lockCam = false;
				ClientPlayer.Instance.fpsScript.lockMove = false;
			}
			break;
		}
		case 9:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			break;
		case 10:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			taskCompletionMax = 1.6f;
			RaycastHit hitInfo3;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				explosiveTemplateRed.gameObject.SetActive(value: false);
				explosiveHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				completingExplosiveFillAmount.fillAmount = 0f;
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				explosiveTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo3, 3.7f, trapObstacles))
			{
				if (Physics.OverlapSphere(new Vector3(hitInfo3.point.x, hitInfo3.point.y + 1f, hitInfo3.point.z), 0.56f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					explosiveTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					explosiveTemplateRed.position = hitInfo3.point;
					explosiveTemplateRed.gameObject.SetActive(value: true);
					explosiveTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo3.collider.gameObject.layer == 9)
				{
					if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						tasking = true;
						if (justStartPlacingTrap)
						{
							explosiveTemplate.position = hitInfo3.point;
							explosiveTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							justStartPlacingTrap = false;
						}
						explosiveTemplateRed.gameObject.SetActive(value: false);
						alreadyPlacing = true;
						explosiveHeldAnim.SetBool("Placing", value: true);
						if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
						{
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: true);
						}
						completingExplosiveFillAmount.gameObject.SetActive(value: true);
						taskCompletion += Time.deltaTime;
						ClientPlayer.Instance.fpsScript.lockCam = true;
						ClientPlayer.Instance.fpsScript.lockMove = true;
						completingExplosiveFillAmount.fillAmount = taskCompletion / taskCompletionMax;
						if (taskCompletion > taskCompletionMax)
						{
							DestroyObject();
							explosiveTemplateRed.gameObject.SetActive(value: false);
							alreadyPlacing = false;
							explosiveHeldAnim.SetBool("Placing", value: false);
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
							taskCompletion = 0f;
							explosiveTemplate.position = hitInfo3.point;
							explosiveTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							PlaceItem(playerMan, "explosive", explosiveTemplate.position, explosiveTemplate.rotation);
							explosiveRemote.SetActive(value: true);
							completingExplosiveFillAmount.fillAmount = 0f;
							ClientPlayer.Instance.fpsScript.lockCam = false;
							ClientPlayer.Instance.fpsScript.lockMove = false;
							explosiveTemplate.gameObject.SetActive(value: false);
							tasking = false;
							PickupNewObj(42, 1);
						}
					}
					else
					{
						tasking = false;
						justStartPlacingTrap = true;
						alreadyPlacing = false;
						explosiveTemplateRed.gameObject.SetActive(value: false);
						explosiveHeldAnim.SetBool("Placing", value: false);
						explosiveTemplate.gameObject.SetActive(value: true);
						explosiveTemplate.position = hitInfo3.point;
						explosiveTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
						playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
						completingExplosiveFillAmount.gameObject.SetActive(value: false);
						taskCompletion = 0f;
						ClientPlayer.Instance.fpsScript.lockCam = false;
						ClientPlayer.Instance.fpsScript.lockMove = false;
					}
				}
				else
				{
					tasking = false;
					explosiveTemplateRed.gameObject.SetActive(value: false);
					alreadyPlacing = false;
					explosiveHeldAnim.SetBool("Placing", value: false);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					completingExplosiveFillAmount.fillAmount = 0f;
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
					explosiveTemplate.gameObject.SetActive(value: false);
				}
			}
			else if (!interactMan.holdInteracting)
			{
				tasking = false;
				explosiveTemplateRed.gameObject.SetActive(value: false);
				alreadyPlacing = false;
				explosiveHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				ClientPlayer.Instance.fpsScript.lockCam = false;
				ClientPlayer.Instance.fpsScript.lockMove = false;
				explosiveTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 11:
		{
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			float maxDistance = 3f;
			if (Physics.Raycast(playerCam.position, playerCam.forward, out var hitInfo25, maxDistance, emotiscopeLayer))
			{
				justStopLookingAtDi = true;
				DialogueInteractable dialogueInteractable = hitInfo25.collider.GetComponent<DialogueInteractable>();
				if (dialogueInteractable == null)
				{
					dialogueInteractable = hitInfo25.collider.GetComponentInParent<DialogueInteractable>();
				}
				if (!(dialogueInteractable != null))
				{
					break;
				}
				lastDi = dialogueInteractable;
				SetEmotionText(dialogueInteractable);
				if (curScan < 2f)
				{
					if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind8"))))
					{
						scanningDataSfx.SetActive(value: true);
						playerMan.fpsScript.lockCam = true;
						playerMan.fpsScript.lockMove = true;
						curScan += Time.deltaTime;
					}
					else
					{
						scanningDataSfx.SetActive(value: false);
						playerMan.fpsScript.lockCam = false;
						playerMan.fpsScript.lockMove = false;
						curScan -= Time.deltaTime;
					}
					scanBar.fillAmount = curScan / 2f;
					emotiscopeScanning.SetActive(value: true);
					emotiscopeSearching.SetActive(value: false);
					emotiscopeFound.SetActive(value: false);
					if (curScan < 0f)
					{
						curScan = 0f;
					}
					break;
				}
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind8"))) && curScan > 1.9f)
				{
					if (dialogueInteractable.cantBeAskedAboutMood)
					{
						StoreManager.Instance.SetAlert("No response.", "red");
						break;
					}
					if (!dialogueInteractable.interactable)
					{
						StoreManager.Instance.SetAlert("This person is busy right now.", "red");
						break;
					}
					dialogueInteractable.Interact(playerMan);
					dialogueInteractable.dialogueOptionsCanvas.SetActive(value: false);
					lastDi.AskQuestion("Mood");
				}
				curScan = 2f;
				emotiscopeScanning.SetActive(value: false);
				emotiscopeSearching.SetActive(value: false);
				emotiscopeFound.SetActive(value: true);
			}
			else if (justStopLookingAtDi)
			{
				justStopLookingAtDi = false;
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				curScan = 0f;
				emotiscopeScanning.SetActive(value: false);
				emotiscopeSearching.SetActive(value: true);
				emotiscopeFound.SetActive(value: false);
			}
			break;
		}
		case 12:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo30;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo30, 3.7f, blocksPlacementLayerMask))
			{
				if (hitInfo30.collider.gameObject.layer == 8)
				{
					posterTemplate.gameObject.SetActive(value: true);
					posterTemplate.position = hitInfo30.point;
					posterTemplate.rotation = Quaternion.LookRotation(hitInfo30.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						ClientPlayer.Instance.fpsScript.lockCam = true;
						ClientPlayer.Instance.fpsScript.lockMove = true;
						posterTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "poster", posterTemplate.position, posterTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					posterTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				posterTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 13:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				if (base.isServer)
				{
					GotARatRpc();
				}
				else
				{
					GotARatCmd();
				}
				ThrowObject();
			}
			break;
		case 14:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				ThrowObject();
			}
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind8"))))
			{
				thirdPersonMan.SqueakDuck();
				duckAnim.SetTrigger("Squeak");
			}
			break;
		case 15:
		{
			if (Physics.Raycast(new Ray(playerCam.position, playerCam.forward), out var _, 1f, petrolTankLayer))
			{
				StoreManager.Instance.standFurtherBackWarning.SetActive(value: true);
			}
			else
			{
				StoreManager.Instance.standFurtherBackWarning.SetActive(value: false);
			}
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				if (justStartedGasPump)
				{
					GasPumpHoses.Instance.ChangeRopeBulge(base.transform, bulgeOn: true);
					justStoppedGasPump = true;
					justStartedGasPump = false;
				}
				float num5 = Vector3.Distance(gasPumpOrigin.position, base.transform.position);
				if (gasPumpCurDistance >= num5)
				{
					gasPumpCurDistance = num5;
					ParticleSystem.EmissionModule emission = gasPumpGasParticles.emission;
					ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
					rateOverTime.constant = 35f;
					emission.rateOverTime = rateOverTime;
					thirdPersonMan.ChangeGasPumpParticles(on: true);
					gasPumpShootSfx.volume = Mathf.Lerp(gasPumpShootSfx.volume, 0.22f, Time.deltaTime * 3f);
					gasPumpEmptySfx.volume = Mathf.Lerp(gasPumpEmptySfx.volume, 0f, Time.deltaTime * 3f);
					ParticleSystem.EmissionModule emission2 = gasPumpSmokeParticles.emission;
					ParticleSystem.MinMaxCurve rateOverTime2 = emission2.rateOverTime;
					rateOverTime2.constant = 0f;
					emission2.rateOverTime = rateOverTime2;
				}
				else
				{
					thirdPersonMan.ChangeGasPumpParticles(on: false);
					gasPumpShootSfx.volume = Mathf.Lerp(gasPumpShootSfx.volume, 0f, Time.deltaTime * 3f);
					gasPumpEmptySfx.volume = Mathf.Lerp(gasPumpEmptySfx.volume, 0.3f, Time.deltaTime * 3f);
					ParticleSystem.EmissionModule emission3 = gasPumpSmokeParticles.emission;
					ParticleSystem.MinMaxCurve rateOverTime3 = emission3.rateOverTime;
					rateOverTime3.constant = 10f;
					emission3.rateOverTime = rateOverTime3;
				}
				gasPumpCurDistance += Time.deltaTime * 5f;
				gasPumpTrigger.SetBool("Holding", value: true);
			}
			else
			{
				if (justStoppedGasPump)
				{
					thirdPersonMan.ChangeGasPumpParticles(on: false);
					GasPumpHoses.Instance.ChangeRopeBulge(base.transform, bulgeOn: false);
					justStoppedGasPump = false;
					justStartedGasPump = true;
				}
				gasPumpTrigger.SetBool("Holding", value: false);
				gasPumpShootSfx.volume = 0f;
				gasPumpEmptySfx.volume = 0f;
				ParticleSystem.EmissionModule emission4 = gasPumpGasParticles.emission;
				ParticleSystem.MinMaxCurve rateOverTime4 = emission4.rateOverTime;
				rateOverTime4.constant = 0f;
				emission4.rateOverTime = rateOverTime4;
				ParticleSystem.EmissionModule emission5 = gasPumpSmokeParticles.emission;
				ParticleSystem.MinMaxCurve rateOverTime5 = emission5.rateOverTime;
				rateOverTime5.constant = 0f;
				emission5.rateOverTime = rateOverTime5;
			}
			if (gasPumpCurDistance > 0f)
			{
				gasPumpCurDistance -= Time.deltaTime;
			}
			break;
		}
		case 16:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo7;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				pottedPlantTemplateRed.gameObject.SetActive(value: false);
				pottedPlantTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo7, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b4 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					pottedPlantTemplateRed.rotation = Quaternion.Slerp(pottedPlantTemplateRed.rotation, b4, Time.deltaTime * 20f);
					pottedPlantTemplate.rotation = Quaternion.Slerp(pottedPlantTemplate.rotation, b4, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo7.point.x, hitInfo7.point.y + 1f, hitInfo7.point.z), 0.17f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						pottedPlantTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					pottedPlantTemplateRed.position = hitInfo7.point;
					pottedPlantTemplateRed.gameObject.SetActive(value: true);
					pottedPlantTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo7.collider.gameObject.layer == 9)
				{
					pottedPlantTemplateRed.gameObject.SetActive(value: false);
					pottedPlantTemplate.gameObject.SetActive(value: true);
					pottedPlantTemplate.position = hitInfo7.point;
					if (rotationIndex == 0)
					{
						pottedPlantTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						pottedPlantTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "potted plant", pottedPlantTemplate.position, pottedPlantTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					pottedPlantTemplateRed.gameObject.SetActive(value: false);
					pottedPlantTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				pottedPlantTemplateRed.gameObject.SetActive(value: false);
				pottedPlantTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 17:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo12;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				waterCoolerTemplateRed.gameObject.SetActive(value: false);
				waterCoolerTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo12, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b6 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					waterCoolerTemplateRed.rotation = Quaternion.Slerp(waterCoolerTemplateRed.rotation, b6, Time.deltaTime * 20f);
					waterCoolerTemplate.rotation = Quaternion.Slerp(waterCoolerTemplate.rotation, b6, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo12.point.x, hitInfo12.point.y + 1f, hitInfo12.point.z), 0.17f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						waterCoolerTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					waterCoolerTemplateRed.position = hitInfo12.point;
					waterCoolerTemplateRed.gameObject.SetActive(value: true);
					waterCoolerTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo12.collider.gameObject.layer == 9)
				{
					waterCoolerTemplateRed.gameObject.SetActive(value: false);
					waterCoolerTemplate.gameObject.SetActive(value: true);
					waterCoolerTemplate.position = hitInfo12.point;
					if (rotationIndex == 0)
					{
						waterCoolerTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						waterCoolerTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "water cooler", waterCoolerTemplate.position, waterCoolerTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					waterCoolerTemplateRed.gameObject.SetActive(value: false);
					waterCoolerTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				waterCoolerTemplateRed.gameObject.SetActive(value: false);
				waterCoolerTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 18:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo10;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				basketRackTemplateRed.gameObject.SetActive(value: false);
				basketRackTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo10, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b5 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					basketRackTemplateRed.rotation = Quaternion.Slerp(basketRackTemplateRed.rotation, b5, Time.deltaTime * 20f);
					basketRackTemplate.rotation = Quaternion.Slerp(basketRackTemplate.rotation, b5, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo10.point.x, hitInfo10.point.y + 1f, hitInfo10.point.z), 0.17f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						basketRackTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					basketRackTemplateRed.position = hitInfo10.point;
					basketRackTemplateRed.gameObject.SetActive(value: true);
					basketRackTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo10.collider.gameObject.layer == 9)
				{
					basketRackTemplateRed.gameObject.SetActive(value: false);
					basketRackTemplate.gameObject.SetActive(value: true);
					basketRackTemplate.position = hitInfo10.point;
					if (rotationIndex == 0)
					{
						basketRackTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						basketRackTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "basket rack", basketRackTemplate.position, basketRackTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					basketRackTemplateRed.gameObject.SetActive(value: false);
					basketRackTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				basketRackTemplateRed.gameObject.SetActive(value: false);
				basketRackTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 19:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo19;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				atmTemplateRed.gameObject.SetActive(value: false);
				atmTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo19, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b11 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					atmTemplateRed.rotation = Quaternion.Slerp(atmTemplateRed.rotation, b11, Time.deltaTime * 20f);
					atmTemplate.rotation = Quaternion.Slerp(atmTemplate.rotation, b11, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo19.point.x, hitInfo19.point.y + 1f, hitInfo19.point.z), 0.17f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						atmTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					atmTemplateRed.position = hitInfo19.point;
					atmTemplateRed.gameObject.SetActive(value: true);
					atmTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo19.collider.gameObject.layer == 9)
				{
					atmTemplateRed.gameObject.SetActive(value: false);
					atmTemplate.gameObject.SetActive(value: true);
					atmTemplate.position = hitInfo19.point;
					if (rotationIndex == 0)
					{
						atmTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						atmTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "atm", atmTemplate.position, atmTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					atmTemplateRed.gameObject.SetActive(value: false);
					atmTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				atmTemplateRed.gameObject.SetActive(value: false);
				atmTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 20:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo4;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				mailboxTemplateRed.gameObject.SetActive(value: false);
				mailboxTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo4, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					mailboxTemplateRed.rotation = Quaternion.Slerp(mailboxTemplateRed.rotation, b, Time.deltaTime * 20f);
					mailboxTemplate.rotation = Quaternion.Slerp(mailboxTemplate.rotation, b, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo4.point.x, hitInfo4.point.y + 1f, hitInfo4.point.z), 0.313f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						mailboxTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					mailboxTemplateRed.position = hitInfo4.point;
					mailboxTemplateRed.gameObject.SetActive(value: true);
					mailboxTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo4.collider.gameObject.layer == 9)
				{
					mailboxTemplateRed.gameObject.SetActive(value: false);
					mailboxTemplate.gameObject.SetActive(value: true);
					mailboxTemplate.position = hitInfo4.point;
					if (rotationIndex == 0)
					{
						mailboxTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						mailboxTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "mailbox", mailboxTemplate.position, mailboxTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					mailboxTemplateRed.gameObject.SetActive(value: false);
					mailboxTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				mailboxTemplateRed.gameObject.SetActive(value: false);
				mailboxTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 21:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo32;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				trashCanTemplateRed.gameObject.SetActive(value: false);
				trashCanTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo32, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b18 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					trashCanTemplateRed.rotation = Quaternion.Slerp(trashCanTemplateRed.rotation, b18, Time.deltaTime * 20f);
					trashCanTemplate.rotation = Quaternion.Slerp(trashCanTemplate.rotation, b18, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo32.point.x, hitInfo32.point.y + 1f, hitInfo32.point.z), 0.22f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						trashCanTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					trashCanTemplateRed.position = hitInfo32.point;
					trashCanTemplateRed.gameObject.SetActive(value: true);
					trashCanTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo32.collider.gameObject.layer == 9)
				{
					trashCanTemplateRed.gameObject.SetActive(value: false);
					trashCanTemplate.gameObject.SetActive(value: true);
					trashCanTemplate.position = hitInfo32.point;
					if (rotationIndex == 0)
					{
						trashCanTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						trashCanTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "trashcan", trashCanTemplate.position, trashCanTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					trashCanTemplateRed.gameObject.SetActive(value: false);
					trashCanTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				trashCanTemplateRed.gameObject.SetActive(value: false);
				trashCanTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 22:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo24;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				bannerTemplateRed.gameObject.SetActive(value: false);
				bannerTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo24, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b15 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					bannerTemplateRed.rotation = Quaternion.Slerp(bannerTemplateRed.rotation, b15, Time.deltaTime * 20f);
					bannerTemplate.rotation = Quaternion.Slerp(bannerTemplate.rotation, b15, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo24.point.x, hitInfo24.point.y + 1f, hitInfo24.point.z), 0.17f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						bannerTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					bannerTemplateRed.position = hitInfo24.point;
					bannerTemplateRed.gameObject.SetActive(value: true);
					bannerTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo24.collider.gameObject.layer == 9)
				{
					bannerTemplateRed.gameObject.SetActive(value: false);
					bannerTemplate.gameObject.SetActive(value: true);
					bannerTemplate.position = hitInfo24.point;
					if (rotationIndex == 0)
					{
						bannerTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						bannerTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "banner", bannerTemplate.position, bannerTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					bannerTemplateRed.gameObject.SetActive(value: false);
					bannerTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				bannerTemplateRed.gameObject.SetActive(value: false);
				bannerTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 23:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo22;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				floorMatTemplateRed.gameObject.SetActive(value: false);
				floorMatTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo22, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b14 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					floorMatTemplateRed.rotation = Quaternion.Slerp(floorMatTemplateRed.rotation, b14, Time.deltaTime * 20f);
					floorMatTemplate.rotation = Quaternion.Slerp(floorMatTemplate.rotation, b14, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo22.point.x, hitInfo22.point.y + 1f, hitInfo22.point.z), 0.17f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						floorMatTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					floorMatTemplateRed.position = hitInfo22.point;
					floorMatTemplateRed.gameObject.SetActive(value: true);
					floorMatTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo22.collider.gameObject.layer == 9)
				{
					floorMatTemplateRed.gameObject.SetActive(value: false);
					floorMatTemplate.gameObject.SetActive(value: true);
					floorMatTemplate.position = hitInfo22.point;
					if (rotationIndex == 0)
					{
						floorMatTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						floorMatTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "floor mat", floorMatTemplate.position, floorMatTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					floorMatTemplateRed.gameObject.SetActive(value: false);
					floorMatTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				floorMatTemplateRed.gameObject.SetActive(value: false);
				floorMatTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 24:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo18;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				sunglassesRackTemplateRed.gameObject.SetActive(value: false);
				sunglassesRackTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo18, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b10 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					sunglassesRackTemplateRed.rotation = Quaternion.Slerp(sunglassesRackTemplateRed.rotation, b10, Time.deltaTime * 20f);
					sunglassesRackTemplate.rotation = Quaternion.Slerp(sunglassesRackTemplate.rotation, b10, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo18.point.x, hitInfo18.point.y + 1f, hitInfo18.point.z), 0.22f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						sunglassesRackTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					sunglassesRackTemplateRed.position = hitInfo18.point;
					sunglassesRackTemplateRed.gameObject.SetActive(value: true);
					sunglassesRackTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo18.collider.gameObject.layer == 9)
				{
					sunglassesRackTemplateRed.gameObject.SetActive(value: false);
					sunglassesRackTemplate.gameObject.SetActive(value: true);
					sunglassesRackTemplate.position = hitInfo18.point;
					if (rotationIndex == 0)
					{
						sunglassesRackTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						sunglassesRackTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "sunglasses rack", sunglassesRackTemplate.position, sunglassesRackTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					sunglassesRackTemplateRed.gameObject.SetActive(value: false);
					sunglassesRackTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				sunglassesRackTemplateRed.gameObject.SetActive(value: false);
				sunglassesRackTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 25:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo21;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				booksTemplateRed.gameObject.SetActive(value: false);
				booksTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo21, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b13 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					booksTemplateRed.rotation = Quaternion.Slerp(booksTemplateRed.rotation, b13, Time.deltaTime * 20f);
					booksTemplate.rotation = Quaternion.Slerp(booksTemplate.rotation, b13, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo21.point.x, hitInfo21.point.y + 1f, hitInfo21.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						booksTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					booksTemplateRed.position = hitInfo21.point;
					booksTemplateRed.gameObject.SetActive(value: true);
					booksTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo21.collider.gameObject.layer == 9 || hitInfo21.collider.gameObject.layer == 10)
				{
					booksTemplateRed.gameObject.SetActive(value: false);
					booksTemplate.gameObject.SetActive(value: true);
					booksTemplate.position = hitInfo21.point;
					if (rotationIndex == 0)
					{
						booksTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						booksTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "books", booksTemplate.position, booksTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					booksTemplateRed.gameObject.SetActive(value: false);
					booksTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				booksTemplateRed.gameObject.SetActive(value: false);
				booksTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 26:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo17;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				bobbleHeadTemplateRed.gameObject.SetActive(value: false);
				bobbleHeadTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo17, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b9 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					bobbleHeadTemplateRed.rotation = Quaternion.Slerp(bobbleHeadTemplateRed.rotation, b9, Time.deltaTime * 20f);
					bobbleHeadTemplate.rotation = Quaternion.Slerp(bobbleHeadTemplate.rotation, b9, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo17.point.x, hitInfo17.point.y + 1f, hitInfo17.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						bobbleHeadTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					bobbleHeadTemplateRed.position = hitInfo17.point;
					bobbleHeadTemplateRed.gameObject.SetActive(value: true);
					bobbleHeadTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo17.collider.gameObject.layer == 9 || hitInfo17.collider.gameObject.layer == 10)
				{
					bobbleHeadTemplateRed.gameObject.SetActive(value: false);
					bobbleHeadTemplate.gameObject.SetActive(value: true);
					bobbleHeadTemplate.position = hitInfo17.point;
					if (rotationIndex == 0)
					{
						bobbleHeadTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						bobbleHeadTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "bobble head", bobbleHeadTemplate.position, bobbleHeadTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					bobbleHeadTemplateRed.gameObject.SetActive(value: false);
					bobbleHeadTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				bobbleHeadTemplateRed.gameObject.SetActive(value: false);
				bobbleHeadTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 27:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo20;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				burgerTemplateRed.gameObject.SetActive(value: false);
				burgerTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo20, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b12 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					burgerTemplateRed.rotation = Quaternion.Slerp(burgerTemplateRed.rotation, b12, Time.deltaTime * 20f);
					burgerTemplate.rotation = Quaternion.Slerp(burgerTemplate.rotation, b12, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo20.point.x, hitInfo20.point.y + 1f, hitInfo20.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						burgerTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					burgerTemplateRed.position = hitInfo20.point;
					burgerTemplateRed.gameObject.SetActive(value: true);
					burgerTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo20.collider.gameObject.layer == 9 || hitInfo20.collider.gameObject.layer == 10)
				{
					burgerTemplateRed.gameObject.SetActive(value: false);
					burgerTemplate.gameObject.SetActive(value: true);
					burgerTemplate.position = hitInfo20.point;
					if (rotationIndex == 0)
					{
						burgerTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						burgerTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "burger", burgerTemplate.position, burgerTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					burgerTemplateRed.gameObject.SetActive(value: false);
					burgerTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				burgerTemplateRed.gameObject.SetActive(value: false);
				burgerTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 28:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo31;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				plant1TemplateRed.gameObject.SetActive(value: false);
				plant1Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo31, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b17 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					plant1TemplateRed.rotation = Quaternion.Slerp(plant1TemplateRed.rotation, b17, Time.deltaTime * 20f);
					plant1Template.rotation = Quaternion.Slerp(plant1Template.rotation, b17, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo31.point.x, hitInfo31.point.y + 1f, hitInfo31.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						plant1TemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					plant1TemplateRed.position = hitInfo31.point;
					plant1TemplateRed.gameObject.SetActive(value: true);
					plant1Template.gameObject.SetActive(value: false);
				}
				else if (hitInfo31.collider.gameObject.layer == 9 || hitInfo31.collider.gameObject.layer == 10)
				{
					plant1TemplateRed.gameObject.SetActive(value: false);
					plant1Template.gameObject.SetActive(value: true);
					plant1Template.position = hitInfo31.point;
					if (rotationIndex == 0)
					{
						plant1Template.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						plant1Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "plant1", plant1Template.position, plant1Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					plant1TemplateRed.gameObject.SetActive(value: false);
					plant1Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				plant1TemplateRed.gameObject.SetActive(value: false);
				plant1Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 29:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo5;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				plant2TemplateRed.gameObject.SetActive(value: false);
				plant2Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo5, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b2 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					plant2TemplateRed.rotation = Quaternion.Slerp(plant2TemplateRed.rotation, b2, Time.deltaTime * 20f);
					plant2Template.rotation = Quaternion.Slerp(plant2Template.rotation, b2, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo5.point.x, hitInfo5.point.y + 1f, hitInfo5.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						plant2TemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					plant2TemplateRed.position = hitInfo5.point;
					plant2TemplateRed.gameObject.SetActive(value: true);
					plant2Template.gameObject.SetActive(value: false);
				}
				else if (hitInfo5.collider.gameObject.layer == 9 || hitInfo5.collider.gameObject.layer == 10)
				{
					plant2TemplateRed.gameObject.SetActive(value: false);
					plant2Template.gameObject.SetActive(value: true);
					plant2Template.position = hitInfo5.point;
					if (rotationIndex == 0)
					{
						plant2Template.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						plant2Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "plant2", plant2Template.position, plant2Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					plant2TemplateRed.gameObject.SetActive(value: false);
					plant2Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				plant2TemplateRed.gameObject.SetActive(value: false);
				plant2Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 30:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo13;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				plant3TemplateRed.gameObject.SetActive(value: false);
				plant3Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo13, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b7 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					plant3TemplateRed.rotation = Quaternion.Slerp(plant3TemplateRed.rotation, b7, Time.deltaTime * 20f);
					plant3Template.rotation = Quaternion.Slerp(plant3Template.rotation, b7, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo13.point.x, hitInfo13.point.y + 1f, hitInfo13.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						plant3TemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					plant3TemplateRed.position = hitInfo13.point;
					plant3TemplateRed.gameObject.SetActive(value: true);
					plant3Template.gameObject.SetActive(value: false);
				}
				else if (hitInfo13.collider.gameObject.layer == 9 || hitInfo13.collider.gameObject.layer == 10)
				{
					plant3TemplateRed.gameObject.SetActive(value: false);
					plant3Template.gameObject.SetActive(value: true);
					plant3Template.position = hitInfo13.point;
					if (rotationIndex == 0)
					{
						plant3Template.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						plant3Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "plant3", plant3Template.position, plant3Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					plant3TemplateRed.gameObject.SetActive(value: false);
					plant3Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				plant3TemplateRed.gameObject.SetActive(value: false);
				plant3Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 31:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo6;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				plant4TemplateRed.gameObject.SetActive(value: false);
				plant4Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo6, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b3 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					plant4TemplateRed.rotation = Quaternion.Slerp(plant4TemplateRed.rotation, b3, Time.deltaTime * 20f);
					plant4Template.rotation = Quaternion.Slerp(plant4Template.rotation, b3, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo6.point.x, hitInfo6.point.y + 1f, hitInfo6.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						plant4TemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					plant4TemplateRed.position = hitInfo6.point;
					plant4TemplateRed.gameObject.SetActive(value: true);
					plant4Template.gameObject.SetActive(value: false);
				}
				else if (hitInfo6.collider.gameObject.layer == 9 || hitInfo6.collider.gameObject.layer == 10)
				{
					plant4TemplateRed.gameObject.SetActive(value: false);
					plant4Template.gameObject.SetActive(value: true);
					plant4Template.position = hitInfo6.point;
					if (rotationIndex == 0)
					{
						plant4Template.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						plant4Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "plant4", plant4Template.position, plant4Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					plant4TemplateRed.gameObject.SetActive(value: false);
					plant4Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				plant4TemplateRed.gameObject.SetActive(value: false);
				plant4Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 32:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo16;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				robotTemplateRed.gameObject.SetActive(value: false);
				robotTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo16, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b8 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					robotTemplateRed.rotation = Quaternion.Slerp(robotTemplateRed.rotation, b8, Time.deltaTime * 20f);
					robotTemplate.rotation = Quaternion.Slerp(robotTemplate.rotation, b8, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo16.point.x, hitInfo16.point.y + 1f, hitInfo16.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						robotTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					robotTemplateRed.position = hitInfo16.point;
					robotTemplateRed.gameObject.SetActive(value: true);
					robotTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo16.collider.gameObject.layer == 9 || hitInfo16.collider.gameObject.layer == 10)
				{
					robotTemplateRed.gameObject.SetActive(value: false);
					robotTemplate.gameObject.SetActive(value: true);
					robotTemplate.position = hitInfo16.point;
					if (rotationIndex == 0)
					{
						robotTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						robotTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "robot", robotTemplate.position, robotTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					robotTemplateRed.gameObject.SetActive(value: false);
					robotTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				robotTemplateRed.gameObject.SetActive(value: false);
				robotTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 33:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo26;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				boomboxTemplateRed.gameObject.SetActive(value: false);
				boomboxTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo26, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b16 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					boomboxTemplateRed.rotation = Quaternion.Slerp(boomboxTemplateRed.rotation, b16, Time.deltaTime * 20f);
					boomboxTemplate.rotation = Quaternion.Slerp(boomboxTemplate.rotation, b16, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo26.point.x, hitInfo26.point.y + 1f, hitInfo26.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						boomboxTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					boomboxTemplateRed.position = hitInfo26.point;
					boomboxTemplateRed.gameObject.SetActive(value: true);
					boomboxTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo26.collider.gameObject.layer == 9 || hitInfo26.collider.gameObject.layer == 10)
				{
					boomboxTemplateRed.gameObject.SetActive(value: false);
					boomboxTemplate.gameObject.SetActive(value: true);
					boomboxTemplate.position = hitInfo26.point;
					if (rotationIndex == 0)
					{
						boomboxTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						boomboxTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "boombox", boomboxTemplate.position, boomboxTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					boomboxTemplateRed.gameObject.SetActive(value: false);
					boomboxTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				boomboxTemplateRed.gameObject.SetActive(value: false);
				boomboxTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 34:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo33;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				gumballTemplateRed.gameObject.SetActive(value: false);
				gumballTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo33, 3.7f, trapObstacles))
			{
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))))
				{
					rotationIndex++;
					if (rotationIndex >= 5)
					{
						rotationIndex = 0;
					}
				}
				if (rotationIndex != 0)
				{
					Quaternion b19 = Quaternion.Euler(0f, 90f * (float)rotationIndex, 0f);
					gumballTemplateRed.rotation = Quaternion.Slerp(gumballTemplateRed.rotation, b19, Time.deltaTime * 20f);
					gumballTemplate.rotation = Quaternion.Slerp(gumballTemplate.rotation, b19, Time.deltaTime * 20f);
				}
				if (Physics.OverlapSphere(new Vector3(hitInfo33.point.x, hitInfo33.point.y + 1f, hitInfo33.point.z), 0.22f, smallItemPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					if (rotationIndex == 0)
					{
						gumballTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					gumballTemplateRed.position = hitInfo33.point;
					gumballTemplateRed.gameObject.SetActive(value: true);
					gumballTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo33.collider.gameObject.layer == 9 || hitInfo33.collider.gameObject.layer == 10)
				{
					gumballTemplateRed.gameObject.SetActive(value: false);
					gumballTemplate.gameObject.SetActive(value: true);
					gumballTemplate.position = hitInfo33.point;
					if (rotationIndex == 0)
					{
						gumballTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					}
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						gumballTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "gumball", gumballTemplate.position, gumballTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					gumballTemplateRed.gameObject.SetActive(value: false);
					gumballTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				gumballTemplateRed.gameObject.SetActive(value: false);
				gumballTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 35:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo28;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				clockTemplateRed.gameObject.SetActive(value: false);
				clockTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo28, 3.7f, blocksPlacementLayerMask))
			{
				if (hitInfo28.collider.gameObject.layer == 8)
				{
					clockTemplateRed.gameObject.SetActive(value: false);
					clockTemplate.gameObject.SetActive(value: true);
					clockTemplate.position = hitInfo28.point;
					clockTemplate.rotation = Quaternion.LookRotation(hitInfo28.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						clockTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "clock", clockTemplate.position, clockTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					clockTemplateRed.gameObject.SetActive(value: false);
					clockTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				clockTemplateRed.gameObject.SetActive(value: false);
				clockTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 36:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo9;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				ivyTemplateRed.gameObject.SetActive(value: false);
				ivyTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo9, 3.7f, trapObstacles))
			{
				if (hitInfo9.collider.gameObject.layer == 8)
				{
					ivyTemplateRed.gameObject.SetActive(value: false);
					ivyTemplate.gameObject.SetActive(value: true);
					ivyTemplate.position = hitInfo9.point;
					ivyTemplate.rotation = Quaternion.LookRotation(hitInfo9.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						ivyTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "ivy", ivyTemplate.position, ivyTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					ivyTemplateRed.gameObject.SetActive(value: false);
					ivyTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				ivyTemplateRed.gameObject.SetActive(value: false);
				ivyTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 37:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo8;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				stringLightsTemplateRed.gameObject.SetActive(value: false);
				stringLightsTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo8, 5f, trapObstacles))
			{
				if (hitInfo8.collider.gameObject.layer == 8)
				{
					stringLightsTemplateRed.gameObject.SetActive(value: false);
					stringLightsTemplate.gameObject.SetActive(value: true);
					stringLightsTemplate.position = hitInfo8.point;
					stringLightsTemplate.rotation = Quaternion.LookRotation(hitInfo8.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						stringLightsTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "string lights", stringLightsTemplate.position, stringLightsTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					stringLightsTemplateRed.gameObject.SetActive(value: false);
					stringLightsTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				stringLightsTemplateRed.gameObject.SetActive(value: false);
				stringLightsTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 38:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo23;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				painting1TemplateRed.gameObject.SetActive(value: false);
				painting1Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo23, 3.7f, trapObstacles))
			{
				if (hitInfo23.collider.gameObject.layer == 8)
				{
					painting1TemplateRed.gameObject.SetActive(value: false);
					painting1Template.gameObject.SetActive(value: true);
					painting1Template.position = hitInfo23.point;
					painting1Template.rotation = Quaternion.LookRotation(hitInfo23.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						painting1Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "painting1", painting1Template.position, painting1Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					painting1TemplateRed.gameObject.SetActive(value: false);
					painting1Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				painting1TemplateRed.gameObject.SetActive(value: false);
				painting1Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 39:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo11;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				painting2TemplateRed.gameObject.SetActive(value: false);
				painting2Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo11, 3.7f, trapObstacles))
			{
				if (hitInfo11.collider.gameObject.layer == 8)
				{
					painting2TemplateRed.gameObject.SetActive(value: false);
					painting2Template.gameObject.SetActive(value: true);
					painting2Template.position = hitInfo11.point;
					painting2Template.rotation = Quaternion.LookRotation(hitInfo11.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						painting2Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "painting2", painting2Template.position, painting2Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					painting2TemplateRed.gameObject.SetActive(value: false);
					painting2Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				painting2TemplateRed.gameObject.SetActive(value: false);
				painting2Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 40:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo2;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				painting3TemplateRed.gameObject.SetActive(value: false);
				painting3Template.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo2, 3.7f, trapObstacles))
			{
				if (hitInfo2.collider.gameObject.layer == 8)
				{
					painting3TemplateRed.gameObject.SetActive(value: false);
					painting3Template.gameObject.SetActive(value: true);
					painting3Template.position = hitInfo2.point;
					painting3Template.rotation = Quaternion.LookRotation(hitInfo2.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						painting3Template.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "painting3", painting3Template.position, painting3Template.rotation);
						DestroyObject();
					}
				}
				else
				{
					painting3TemplateRed.gameObject.SetActive(value: false);
					painting3Template.gameObject.SetActive(value: false);
				}
			}
			else
			{
				painting3TemplateRed.gameObject.SetActive(value: false);
				painting3Template.gameObject.SetActive(value: false);
			}
			break;
		}
		case 41:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			RaycastHit hitInfo27;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				deerTemplateRed.gameObject.SetActive(value: false);
				deerTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo27, 3.7f, trapObstacles))
			{
				if (hitInfo27.collider.gameObject.layer == 8)
				{
					deerTemplateRed.gameObject.SetActive(value: false);
					deerTemplate.gameObject.SetActive(value: true);
					deerTemplate.position = hitInfo27.point;
					deerTemplate.rotation = Quaternion.LookRotation(hitInfo27.normal);
					if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						deerTemplate.gameObject.SetActive(value: false);
						PlaceItem(playerMan, "deer", deerTemplate.position, deerTemplate.rotation);
						DestroyObject();
					}
				}
				else
				{
					deerTemplateRed.gameObject.SetActive(value: false);
					deerTemplate.gameObject.SetActive(value: false);
				}
			}
			else
			{
				deerTemplateRed.gameObject.SetActive(value: false);
				deerTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 42:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind8"))))
			{
				Invoke("Explode", 0.3f);
				playerMan.explosiveRemotePress.Play();
				PauseInventory();
				Invoke("DestroyObject", 0.5f);
				Invoke("UnpauseInventory", 0.5f);
			}
			break;
		case 43:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				DropObject();
				break;
			}
			taskCompletionMax = 1f;
			if (Input.GetKey(KeyCode.Mouse0))
			{
				completingHeal.gameObject.SetActive(value: true);
				taskCompletion += Time.deltaTime;
				if (taskCompletion >= taskCompletionMax)
				{
					completingHeal.gameObject.SetActive(value: false);
					taskCompletion = 0f;
					DestroyObject();
					playerMan.Heal(30f);
				}
			}
			else
			{
				taskCompletion = 0f;
				completingHeal.gameObject.SetActive(value: false);
			}
			completingHeal.fillAmount = taskCompletion / taskCompletionMax;
			break;
		case 44:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				DropObject();
				break;
			}
			taskCompletionMax = 2f;
			if (Input.GetKey(KeyCode.Mouse0))
			{
				completingHeal.gameObject.SetActive(value: true);
				taskCompletion += Time.deltaTime;
				if (taskCompletion >= taskCompletionMax)
				{
					completingHeal.gameObject.SetActive(value: false);
					taskCompletion = 0f;
					DestroyObject();
					playerMan.Heal(150f);
				}
			}
			else
			{
				taskCompletion = 0f;
				completingHeal.gameObject.SetActive(value: false);
			}
			completingHeal.fillAmount = taskCompletion / taskCompletionMax;
			break;
		case 45:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (crateStorages[curInventorySlot] > 0)
				{
					if (canShoot)
					{
						if (gunJammed)
						{
							StoreManager.Instance.SetAlert("[ GUN JAMMED ]", "red");
							break;
						}
						holdingAnims[holdingIndex].SetTrigger("Aim");
						CancelReload();
						crateStorages[curInventorySlot]--;
						if (crateStorages[curInventorySlot] < 1)
						{
							StoreManager.Instance.rToReload.SetActive(value: true);
						}
						shotgunBulletIcons[crateStorages[curInventorySlot]].SetActive(value: false);
						ShootShotgun(15f);
						if (PlayerPrefs.GetInt("CamShake", 1) != 0)
						{
							recoil.GenerateRecoil();
						}
						shotgunAnim.SetTrigger("Shoot");
						canShoot = false;
						Invoke("CanShoot", 0.45f);
					}
				}
				else
				{
					StoreManager.Instance.rToReload.SetActive(value: true);
					pistolDryShot.Play();
				}
			}
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind10"))) && !reloading && crateStorages[curInventorySlot] < 5)
			{
				reloadRoutine = StartCoroutine(ReloadShotgun());
			}
			break;
		case 46:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				ThrowObject();
			}
			break;
		case 47:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse1))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
				canAttack = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				ThrowObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
			{
				canAttack = false;
				Invoke("CanAttack", 0.35f);
				if (PlayerPrefs.GetInt("CamShake", 1) != 0)
				{
					playerMan.fpsScript.headbobAnim.SetTrigger("Melee");
				}
				holdingAnims[holdingIndex].SetFloat("AttackSpeed", 1f);
				int num6 = UnityEngine.Random.Range(1, 3);
				holdingAnims[holdingIndex].SetTrigger("Attack" + num6);
				MeleeAttack(80f, 1);
			}
			break;
		case 48:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse1))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
				canAttack = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				ThrowObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
			{
				canAttack = false;
				Invoke("CanAttack", 0.45f);
				if (PlayerPrefs.GetInt("CamShake", 1) != 0)
				{
					playerMan.fpsScript.headbobAnim.SetTrigger("Melee");
				}
				holdingAnims[holdingIndex].SetFloat("AttackSpeed", 0.8f);
				int num3 = UnityEngine.Random.Range(1, 3);
				holdingAnims[holdingIndex].SetTrigger("Attack" + num3);
				MeleeAttack(150f, 2);
			}
			break;
		case 49:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse1))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
				canAttack = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				ThrowObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
			{
				canAttack = false;
				Invoke("CanAttack", 0.27f);
				if (PlayerPrefs.GetInt("CamShake", 1) != 0)
				{
					playerMan.fpsScript.headbobAnim.SetTrigger("Melee");
				}
				holdingAnims[holdingIndex].SetFloat("AttackSpeed", 1.25f);
				int num4 = UnityEngine.Random.Range(1, 3);
				holdingAnims[holdingIndex].SetTrigger("Attack" + num4);
				MeleeAttack(50f, 0);
			}
			break;
		case 50:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (crateStorages[curInventorySlot] > 0)
			{
				if (Input.GetKey(KeyCode.Mouse0) && canAttack)
				{
					flamethrowerFireLoop.volume = Mathf.Lerp(flamethrowerFireLoop.volume, 1f, Time.deltaTime * 3f);
					canAttack = false;
					Invoke("CanAttack", 0.07f);
					ShootFlamethrower();
				}
				else
				{
					flamethrowerFireLoop.volume = Mathf.Lerp(flamethrowerFireLoop.volume, 0f, Time.deltaTime * 3f);
				}
			}
			else if (canAttack)
			{
				StoreManager.Instance.noMoreAmmo.SetActive(value: true);
				canAttack = false;
			}
			else
			{
				flamethrowerFireLoop.volume = Mathf.Lerp(flamethrowerFireLoop.volume, 0f, Time.deltaTime * 3f);
			}
			break;
		case 51:
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))))
			{
				DropObject();
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				holdingAnims[holdingIndex].SetTrigger("Throw");
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				ThrowObject();
			}
			break;
		case 52:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			taskCompletionMax = 1.6f;
			RaycastHit hitInfo15;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				landmineTemplateRed.gameObject.SetActive(value: false);
				landmineHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				completingTaskFillAmount.fillAmount = 0f;
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				landmineTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo15, 3.7f, trapObstacles))
			{
				if (Physics.OverlapSphere(new Vector3(hitInfo15.point.x, hitInfo15.point.y + 1f, hitInfo15.point.z), 0.56f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					landmineTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					landmineTemplateRed.position = hitInfo15.point;
					landmineTemplateRed.gameObject.SetActive(value: true);
					landmineTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo15.collider.gameObject.layer == 9)
				{
					if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						if (justStartPlacingTrap)
						{
							landmineTemplate.position = hitInfo15.point;
							landmineTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							justStartPlacingTrap = false;
						}
						tasking = true;
						landmineTemplateRed.gameObject.SetActive(value: false);
						alreadyPlacing = true;
						landmineHeldAnim.SetBool("Placing", value: true);
						if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
						{
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: true);
						}
						completingTaskFillAmount.gameObject.SetActive(value: true);
						taskCompletion += Time.deltaTime;
						ClientPlayer.Instance.fpsScript.lockCam = true;
						ClientPlayer.Instance.fpsScript.lockMove = true;
						completingTaskFillAmount.fillAmount = taskCompletion / taskCompletionMax;
						if (taskCompletion > taskCompletionMax)
						{
							landmineTemplateRed.gameObject.SetActive(value: false);
							alreadyPlacing = false;
							landmineHeldAnim.SetBool("Placing", value: false);
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
							taskCompletion = 0f;
							landmineTemplate.position = hitInfo15.point;
							landmineTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							PlaceItem(playerMan, "landmine", landmineTemplate.position, landmineTemplate.rotation);
							completingTaskFillAmount.fillAmount = 0f;
							ClientPlayer.Instance.fpsScript.lockCam = false;
							ClientPlayer.Instance.fpsScript.lockMove = false;
							landmineTemplate.gameObject.SetActive(value: false);
							DestroyObject();
							tasking = false;
						}
					}
					else
					{
						tasking = false;
						justStartPlacingTrap = true;
						alreadyPlacing = false;
						landmineTemplateRed.gameObject.SetActive(value: false);
						landmineHeldAnim.SetBool("Placing", value: false);
						landmineTemplate.gameObject.SetActive(value: true);
						landmineTemplate.position = hitInfo15.point;
						landmineTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
						playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
						completingTaskFillAmount.gameObject.SetActive(value: false);
						taskCompletion = 0f;
						ClientPlayer.Instance.fpsScript.lockCam = false;
						ClientPlayer.Instance.fpsScript.lockMove = false;
					}
				}
				else
				{
					tasking = false;
					landmineTemplateRed.gameObject.SetActive(value: false);
					alreadyPlacing = false;
					landmineHeldAnim.SetBool("Placing", value: false);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					completingTaskFillAmount.fillAmount = 0f;
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
					landmineTemplate.gameObject.SetActive(value: false);
				}
			}
			else if (!interactMan.holdInteracting)
			{
				tasking = false;
				landmineTemplateRed.gameObject.SetActive(value: false);
				alreadyPlacing = false;
				landmineHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				ClientPlayer.Instance.fpsScript.lockCam = false;
				ClientPlayer.Instance.fpsScript.lockMove = false;
				landmineTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		case 53:
		{
			if (Input.GetKeyUp(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
			{
				letGoOfInteract = true;
			}
			if (!letGoOfInteract)
			{
				break;
			}
			taskCompletionMax = 1.6f;
			RaycastHit hitInfo;
			if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind9"))) && !tasking && !interactMan.holdInteracting)
			{
				stunMineTemplateRed.gameObject.SetActive(value: false);
				stunMineHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				completingTaskFillAmount.fillAmount = 0f;
				playerMan.fpsScript.lockCam = false;
				playerMan.fpsScript.lockMove = false;
				stunMineTemplate.gameObject.SetActive(value: false);
				DropObject();
			}
			else if (Physics.Raycast(playerCam.position, playerCam.forward, out hitInfo, 3.7f, trapObstacles))
			{
				if (Physics.OverlapSphere(new Vector3(hitInfo.point.x, hitInfo.point.y + 1f, hitInfo.point.z), 0.56f, blocksPlacementLayerMask).Length != 0 && !alreadyPlacing)
				{
					stunMineTemplateRed.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
					stunMineTemplateRed.position = hitInfo.point;
					stunMineTemplateRed.gameObject.SetActive(value: true);
					stunMineTemplate.gameObject.SetActive(value: false);
				}
				else if (hitInfo.collider.gameObject.layer == 9)
				{
					if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						if (justStartPlacingTrap)
						{
							stunMineTemplate.position = hitInfo.point;
							stunMineTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							justStartPlacingTrap = false;
						}
						tasking = true;
						stunMineTemplateRed.gameObject.SetActive(value: false);
						alreadyPlacing = true;
						stunMineHeldAnim.SetBool("Placing", value: true);
						if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
						{
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: true);
						}
						completingTaskFillAmount.gameObject.SetActive(value: true);
						taskCompletion += Time.deltaTime;
						ClientPlayer.Instance.fpsScript.lockCam = true;
						ClientPlayer.Instance.fpsScript.lockMove = true;
						completingTaskFillAmount.fillAmount = taskCompletion / taskCompletionMax;
						if (taskCompletion > taskCompletionMax)
						{
							stunMineTemplateRed.gameObject.SetActive(value: false);
							alreadyPlacing = false;
							stunMineHeldAnim.SetBool("Placing", value: false);
							playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
							taskCompletion = 0f;
							stunMineTemplate.position = hitInfo.point;
							stunMineTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
							PlaceItem(playerMan, "stun mine", stunMineTemplate.position, stunMineTemplate.rotation);
							completingTaskFillAmount.fillAmount = 0f;
							ClientPlayer.Instance.fpsScript.lockCam = false;
							ClientPlayer.Instance.fpsScript.lockMove = false;
							stunMineTemplate.gameObject.SetActive(value: false);
							DestroyObject();
							tasking = false;
						}
					}
					else
					{
						tasking = false;
						justStartPlacingTrap = true;
						alreadyPlacing = false;
						stunMineTemplateRed.gameObject.SetActive(value: false);
						stunMineHeldAnim.SetBool("Placing", value: false);
						stunMineTemplate.gameObject.SetActive(value: true);
						stunMineTemplate.position = hitInfo.point;
						stunMineTemplate.rotation = Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f);
						playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
						completingTaskFillAmount.gameObject.SetActive(value: false);
						taskCompletion = 0f;
						ClientPlayer.Instance.fpsScript.lockCam = false;
						ClientPlayer.Instance.fpsScript.lockMove = false;
					}
				}
				else
				{
					tasking = false;
					stunMineTemplateRed.gameObject.SetActive(value: false);
					alreadyPlacing = false;
					stunMineHeldAnim.SetBool("Placing", value: false);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					completingTaskFillAmount.fillAmount = 0f;
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
					stunMineTemplate.gameObject.SetActive(value: false);
				}
			}
			else if (!interactMan.holdInteracting)
			{
				tasking = false;
				stunMineTemplateRed.gameObject.SetActive(value: false);
				alreadyPlacing = false;
				stunMineHeldAnim.SetBool("Placing", value: false);
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				ClientPlayer.Instance.fpsScript.lockCam = false;
				ClientPlayer.Instance.fpsScript.lockMove = false;
				stunMineTemplate.gameObject.SetActive(value: false);
			}
			break;
		}
		}
	}

	private void CanAttack()
	{
		canAttack = true;
	}

	[Command(requiresAuthority = false)]
	public void GotARatCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void InventoryManager::GotARatCmd()", -970574288, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void GotARatRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void InventoryManager::GotARatRpc()", -249167193, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void AskMood()
	{
		lastDi.AskQuestion("Mood");
	}

	public void SetEmotionText(DialogueInteractable dialogueScript)
	{
		if (JSONAccess.Instance == null)
		{
			Debug.LogError("JSONAccess.Instance is null (cannot read encrypted Dialogue files).");
			return;
		}
		string text = ((lastDi != null) ? lastDi.dialogueId : null);
		if (!string.IsNullOrWhiteSpace(text))
		{
			string dialogueText = JSONAccess.Instance.GetDialogueText(text, "MoodValue");
			if (!string.IsNullOrEmpty(dialogueText) && dialogueText != "[TNF]" && dialogueText != "[TEXT KEY NOT FOUND IN FILES]")
			{
				emotiscopeEmotionText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				emotiscopeEmotionText.text = dialogueText;
			}
			else
			{
				string dialogueText2 = JSONAccess.Instance.GetDialogueText("UI Text 4", "Unable to Read Emotion");
				emotiscopeEmotionText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				emotiscopeEmotionText.text = NormalizeFallback(dialogueText2);
			}
		}
	}

	private static string NormalizeFallback(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}
		if (value == "[TNF]" || value == "[TEXT KEY NOT FOUND IN FILES]")
		{
			return string.Empty;
		}
		return value;
	}

	private void PlaceItem(PlayerManager playerMan, string type, Vector3 pos, Quaternion rot)
	{
		if (base.isServer)
		{
			PlaceItemRpc(playerMan, type, pos, rot);
		}
		else
		{
			PlaceItemCmd(playerMan, type, pos, rot);
		}
	}

	[Command(requiresAuthority = false)]
	private void PlaceItemCmd(PlayerManager playerMan, string type, Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		writer.WriteString(type);
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendCommandInternal("System.Void InventoryManager::PlaceItemCmd(PlayerManager,System.String,UnityEngine.Vector3,UnityEngine.Quaternion)", 1401757144, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ActuallySetRemoteTrap(GameObject obj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(obj);
		SendRPCInternal("System.Void InventoryManager::ActuallySetRemoteTrap(UnityEngine.GameObject)", 866295710, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PlaceItemRpc(PlayerManager playerMan, string type, Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		writer.WriteString(type);
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendRPCInternal("System.Void InventoryManager::PlaceItemRpc(PlayerManager,System.String,UnityEngine.Vector3,UnityEngine.Quaternion)", -248112589, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void AddTrash()
	{
		if (base.isLocalPlayer)
		{
			trashBagAnim.SetTrigger("AddTrash");
			trash[curInventorySlot]++;
		}
	}

	public void UpdateCurInventorySlot(int slot)
	{
		curInventorySlot = slot;
		if (base.isServer)
		{
			UpdateCurInventorySlotRpc(slot);
		}
		else
		{
			UpdateCurInventorySlotCmd(slot);
		}
	}

	[Command(requiresAuthority = false)]
	private void UpdateCurInventorySlotCmd(int slot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(slot);
		SendCommandInternal("System.Void InventoryManager::UpdateCurInventorySlotCmd(System.Int32)", -578290526, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateCurInventorySlotRpc(int slot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(slot);
		SendRPCInternal("System.Void InventoryManager::UpdateCurInventorySlotRpc(System.Int32)", 1261329349, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator Reload()
	{
		reloading = true;
		float duration = 2.3f;
		float elapsed = 0f;
		reloadBar.gameObject.SetActive(value: true);
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			reloadBar.fillAmount = Mathf.Clamp01(elapsed / duration);
			yield return null;
		}
		reloadBar.gameObject.SetActive(value: false);
		reloading = false;
		crateStorages[curInventorySlot] = pistolBulletIcons.Length;
		GameObject[] array = pistolBulletIcons;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
			StoreManager.Instance.rToReload.SetActive(value: false);
		}
	}

	public void CancelReload()
	{
		if (reloadRoutine != null)
		{
			StopCoroutine(reloadRoutine);
			reloadRoutine = null;
		}
		StoreManager.Instance.rToReload.SetActive(value: false);
		reloadBar.gameObject.SetActive(value: false);
		reloadShotgunBar.gameObject.SetActive(value: false);
		reloading = false;
	}

	private IEnumerator ReloadShotgun()
	{
		holdingAnims[holdingIndex].SetTrigger("Reload");
		reloading = true;
		float duration = 0.6f;
		float elapsed = 0f;
		reloadShotgunBar.gameObject.SetActive(value: true);
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			reloadShotgunBar.fillAmount = Mathf.Clamp01(elapsed / duration);
			yield return null;
		}
		reloadShotgunBar.gameObject.SetActive(value: false);
		reloading = false;
		crateStorages[curInventorySlot]++;
		GameObject[] array = shotgunBulletIcons;
		foreach (GameObject gameObject in array)
		{
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(value: true);
				break;
			}
		}
		StoreManager.Instance.rToReload.SetActive(value: false);
		if (crateStorages[curInventorySlot] < shotgunBulletIcons.Length)
		{
			reloadRoutine = StartCoroutine(ReloadShotgun());
		}
	}

	public void ShootFlamethrower()
	{
		if (base.isServer)
		{
			StoreManager.Instance.ServerThrowObject(holdingIndex, flamethrowerShootPoint.position, flamethrowerShootPoint.rotation, flamethrowerShootPoint.forward, base.gameObject, 20f);
		}
		else
		{
			StoreManager.Instance.NetworkThrowObject(holdingIndex, flamethrowerShootPoint.position, flamethrowerShootPoint.rotation, flamethrowerShootPoint.forward, base.gameObject, 20f);
		}
		camShake.intensity = 0.05f;
		crateStorages[curInventorySlot]--;
		flamethrowerAmmoText.text = crateStorages[curInventorySlot].ToString("0");
		if (crateStorages[curInventorySlot] <= 0)
		{
			StoreManager.Instance.noMoreAmmo.SetActive(value: true);
		}
	}

	private void OnDisable()
	{
		CancelReload();
	}

	private void AlertSameEnemy()
	{
		StopCoroutine(Reload());
		reloadBar.gameObject.SetActive(value: false);
		reloading = false;
		if (StoreManager.Instance.inHunt)
		{
			playerMan.ChangeTimeDetected(5f, curEnemyShotIndex);
		}
	}

	public void MeleeAttack(float damage, int hitParticle)
	{
		thirdPersonMan.MeleeAttack();
		if (!Physics.Raycast(new Ray(playerShootPoint.position, playerShootPoint.forward), out var hitInfo, 3f, shootable))
		{
			return;
		}
		Hittable componentInParent = hitInfo.collider.GetComponentInParent<Hittable>();
		if (componentInParent != null)
		{
			if (componentInParent != null)
			{
				if (hitInfo.collider.gameObject.CompareTag("Head"))
				{
					damage *= 2f;
				}
				if ((bool)componentInParent.enemy)
				{
					curEnemyShotIndex = playerMan.enemiesList.IndexOf(componentInParent.enemy.gameObject);
					Invoke("AlertSameEnemy", 0f);
					Invoke("AlertSameEnemy", 0.02f);
					Invoke("AlertSameEnemy", 0.05f);
					Invoke("AlertSameEnemy", 0.07f);
					Invoke("AlertSameEnemy", 0.1f);
					Invoke("AlertSameEnemy", 0.12f);
					Invoke("AlertSameEnemy", 0.15f);
					Invoke("AlertSameEnemy", 0.17f);
					Invoke("AlertSameEnemy", 0.2f);
					Invoke("AlertSameEnemy", 0.22f);
					Invoke("AlertSameEnemy", 0.25f);
					Invoke("AlertSameEnemy", 0.27f);
					Invoke("AlertSameEnemy", 0.3f);
				}
				componentInParent.Hit(damage, base.transform.position, alwaysTriggerDamageReaction: true);
				if (componentInParent.causeHitMarker)
				{
					hitMarker.SetActive(value: false);
					hitMarker.SetActive(value: true);
				}
			}
		}
		else if (hitInfo.collider.GetComponentInParent<PlayerManager>() != null)
		{
			hitInfo.collider.GetComponentInParent<PlayerManager>().TakeDamage(30f, significantAnim: true);
			hitMarker.SetActive(value: false);
			hitMarker.SetActive(value: true);
		}
		else
		{
			UnityEngine.Object.Instantiate(meleeHitParticles[hitParticle], hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
		}
	}

	public void Shoot(float damage)
	{
		if (HuntManager.Instance != null && StoreManager.Instance.inHunt)
		{
			Enemy enemy = UnityEngine.Object.FindObjectOfType<Enemy>();
			if ((bool)enemy)
			{
				if (GetXZDistance(enemy.transform, base.transform) < 20f)
				{
					enemy.ChaseNonPlayerTarget(base.transform.position);
				}
				alertedTheCreatureWarning.SetTrigger("Alert");
			}
		}
		thirdPersonMan.ShootGun();
		if (!Physics.Raycast(new Ray(playerShootPoint.position, playerShootPoint.forward), out var hitInfo, 100f, shootable))
		{
			return;
		}
		Hittable componentInParent = hitInfo.collider.GetComponentInParent<Hittable>();
		if (componentInParent != null)
		{
			if (hitInfo.collider.gameObject.CompareTag("Head"))
			{
				damage *= 2f;
			}
			if ((bool)componentInParent.enemy)
			{
				curEnemyShotIndex = playerMan.enemiesList.IndexOf(componentInParent.enemy.gameObject);
				Invoke("AlertSameEnemy", 0f);
				Invoke("AlertSameEnemy", 0.02f);
				Invoke("AlertSameEnemy", 0.05f);
				Invoke("AlertSameEnemy", 0.07f);
				Invoke("AlertSameEnemy", 0.1f);
				Invoke("AlertSameEnemy", 0.12f);
				Invoke("AlertSameEnemy", 0.15f);
				Invoke("AlertSameEnemy", 0.17f);
				Invoke("AlertSameEnemy", 0.2f);
				Invoke("AlertSameEnemy", 0.22f);
				Invoke("AlertSameEnemy", 0.25f);
				Invoke("AlertSameEnemy", 0.27f);
				Invoke("AlertSameEnemy", 0.3f);
			}
			componentInParent.Hit(damage, base.transform.position, alwaysTriggerDamageReaction: true);
			if (componentInParent.causeHitMarker)
			{
				hitMarker.SetActive(value: false);
				hitMarker.SetActive(value: true);
			}
		}
		else if (hitInfo.collider.GetComponentInParent<PlayerManager>() != null)
		{
			hitInfo.collider.GetComponentInParent<PlayerManager>().TakeDamage(30f, significantAnim: true);
			hitMarker.SetActive(value: false);
			hitMarker.SetActive(value: true);
		}
		else
		{
			UnityEngine.Object.Instantiate(hitParticle, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
		}
	}

	public void ShootShotgun(float damage)
	{
		if (HuntManager.Instance != null && StoreManager.Instance.inHunt)
		{
			Enemy enemy = UnityEngine.Object.FindObjectOfType<Enemy>();
			if ((bool)enemy)
			{
				if (GetXZDistance(enemy.transform, base.transform) < 20f)
				{
					enemy.ChaseNonPlayerTarget(base.transform.position);
				}
				alertedTheCreatureWarning.SetTrigger("Alert");
			}
		}
		thirdPersonMan.ShootGun();
		for (int i = 0; i < 7; i++)
		{
			float angle = UnityEngine.Random.Range(0f, 15f);
			Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
			Vector3 direction = Quaternion.AngleAxis(angle, onUnitSphere) * playerShootPoint.forward;
			if (!Physics.Raycast(new Ray(playerShootPoint.position, direction), out var hitInfo, 100f, shootable))
			{
				continue;
			}
			Hittable componentInParent = hitInfo.collider.GetComponentInParent<Hittable>();
			if (componentInParent != null)
			{
				float num = damage;
				if (hitInfo.collider.gameObject.CompareTag("Head"))
				{
					num *= 2f;
				}
				if ((bool)componentInParent.enemy)
				{
					curEnemyShotIndex = playerMan.enemiesList.IndexOf(componentInParent.enemy.gameObject);
					Invoke("AlertSameEnemy", 0f);
					Invoke("AlertSameEnemy", 0.1f);
					Invoke("AlertSameEnemy", 0.2f);
					Invoke("AlertSameEnemy", 0.3f);
				}
				componentInParent.Hit(num, base.transform.position, alwaysTriggerDamageReaction: true);
				if (componentInParent.causeHitMarker)
				{
					hitMarker.SetActive(value: false);
					hitMarker.SetActive(value: true);
				}
			}
			else if (hitInfo.collider.GetComponentInParent<PlayerManager>() != null)
			{
				hitInfo.collider.GetComponentInParent<PlayerManager>().TakeDamage(10f, significantAnim: true);
				hitMarker.SetActive(value: false);
				hitMarker.SetActive(value: true);
			}
			else
			{
				UnityEngine.Object.Instantiate(hitParticle, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			}
		}
	}

	private float GetXZDistance(Transform a, Transform b)
	{
		Vector3 position = a.position;
		Vector3 position2 = b.position;
		position.y = 0f;
		position2.y = 0f;
		return Vector3.Distance(position, position2);
	}

	private static bool TryGetCleanable(Collider c, out Spill spill, out Moppable mop)
	{
		spill = c.GetComponentInParent<Spill>();
		mop = (spill ? null : c.GetComponentInParent<Moppable>());
		if (!(spill != null))
		{
			return mop != null;
		}
		return true;
	}

	public void CleanSpill()
	{
		Vector3 position = playerCam.transform.position;
		Vector3 forward = playerCam.transform.forward;
		Collider[] array = Physics.OverlapSphere(position, 0.5f, cleanable);
		if (array.Length != 0)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (TryGetCleanable(array2[i], out var spill, out var mop))
				{
					if (spill != null)
					{
						spill.Clean();
					}
					else
					{
						mop.Clean();
					}
					return;
				}
			}
		}
		bool queriesHitBackfaces = Physics.queriesHitBackfaces;
		Physics.queriesHitBackfaces = true;
		if (Physics.Raycast(position, forward, out var hitInfo, 3f, cleanable, QueryTriggerInteraction.Collide) && TryGetCleanable(hitInfo.collider, out var spill2, out var mop2))
		{
			if (spill2 != null)
			{
				spill2.Clean();
			}
			else
			{
				mop2.Clean();
			}
		}
		Physics.queriesHitBackfaces = queriesHitBackfaces;
	}

	public void PauseUseItem()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		Invoke("CheckConstrictedInteractables", 0.1f);
		canControlItem = false;
		canAttack = true;
		StoreManager.Instance.noMoreAmmo.SetActive(value: false);
		if ((bool)StoreManager.Instance && (bool)StoreManager.Instance.dumpsterOutline)
		{
			StoreManager.Instance.dumpsterOutline.enabled = false;
		}
		bearTrapTemplate.gameObject.SetActive(value: false);
		bearTrapTemplateRed.gameObject.SetActive(value: false);
		explosiveTemplate.gameObject.SetActive(value: false);
		explosiveTemplateRed.gameObject.SetActive(value: false);
		posterTemplate.gameObject.SetActive(value: false);
		pottedPlantTemplate.gameObject.SetActive(value: false);
		pottedPlantTemplateRed.gameObject.SetActive(value: false);
		waterCoolerTemplate.gameObject.SetActive(value: false);
		waterCoolerTemplateRed.gameObject.SetActive(value: false);
		basketRackTemplate.gameObject.SetActive(value: false);
		basketRackTemplateRed.gameObject.SetActive(value: false);
		atmTemplate.gameObject.SetActive(value: false);
		atmTemplateRed.gameObject.SetActive(value: false);
		mailboxTemplate.gameObject.SetActive(value: false);
		mailboxTemplateRed.gameObject.SetActive(value: false);
		trashCanTemplate.gameObject.SetActive(value: false);
		trashCanTemplateRed.gameObject.SetActive(value: false);
		bannerTemplate.gameObject.SetActive(value: false);
		bannerTemplateRed.gameObject.SetActive(value: false);
		floorMatTemplate.gameObject.SetActive(value: false);
		floorMatTemplateRed.gameObject.SetActive(value: false);
		sunglassesRackTemplate.gameObject.SetActive(value: false);
		sunglassesRackTemplateRed.gameObject.SetActive(value: false);
		booksTemplate.gameObject.SetActive(value: false);
		booksTemplateRed.gameObject.SetActive(value: false);
		bobbleHeadTemplate.gameObject.SetActive(value: false);
		bobbleHeadTemplateRed.gameObject.SetActive(value: false);
		burgerTemplate.gameObject.SetActive(value: false);
		burgerTemplateRed.gameObject.SetActive(value: false);
		plant1Template.gameObject.SetActive(value: false);
		plant1TemplateRed.gameObject.SetActive(value: false);
		plant2Template.gameObject.SetActive(value: false);
		plant2TemplateRed.gameObject.SetActive(value: false);
		plant3Template.gameObject.SetActive(value: false);
		plant3TemplateRed.gameObject.SetActive(value: false);
		plant4Template.gameObject.SetActive(value: false);
		plant4TemplateRed.gameObject.SetActive(value: false);
		robotTemplate.gameObject.SetActive(value: false);
		robotTemplateRed.gameObject.SetActive(value: false);
		boomboxTemplate.gameObject.SetActive(value: false);
		boomboxTemplateRed.gameObject.SetActive(value: false);
		gumballTemplate.gameObject.SetActive(value: false);
		gumballTemplateRed.gameObject.SetActive(value: false);
		clockTemplate.gameObject.SetActive(value: false);
		clockTemplateRed.gameObject.SetActive(value: false);
		ivyTemplate.gameObject.SetActive(value: false);
		ivyTemplateRed.gameObject.SetActive(value: false);
		stringLightsTemplate.gameObject.SetActive(value: false);
		stringLightsTemplateRed.gameObject.SetActive(value: false);
		painting1Template.gameObject.SetActive(value: false);
		painting1TemplateRed.gameObject.SetActive(value: false);
		painting2Template.gameObject.SetActive(value: false);
		painting2TemplateRed.gameObject.SetActive(value: false);
		painting3Template.gameObject.SetActive(value: false);
		painting3TemplateRed.gameObject.SetActive(value: false);
		deerTemplate.gameObject.SetActive(value: false);
		deerTemplateRed.gameObject.SetActive(value: false);
		thirdPersonMan.DropObj();
		GameObject[] array = itemCanvases;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		if (holdingIndex == -1)
		{
			return;
		}
		if (holdingIndex == 4 && flashlightLight.activeInHierarchy)
		{
			storeMan.FlashlightToggled(-1);
		}
		CancelReload();
		if (curInventorySlot >= 0)
		{
			for (int j = 0; j < pistolBulletIcons.Length; j++)
			{
				pistolBulletIcons[j].SetActive(j < crateStorages[curInventorySlot]);
			}
			for (int k = 0; k < shotgunBulletIcons.Length; k++)
			{
				shotgunBulletIcons[k].SetActive(k < crateStorages[curInventorySlot]);
			}
			flamethrowerAmmoText.text = crateStorages[curInventorySlot].ToString("0");
		}
		holdingObjs[holdingIndex].SetActive(value: false);
		itemCanvases[holdingIndex].SetActive(value: false);
		if (holdingIndex == 15)
		{
			GasPumpHoses.Instance.DisconnectRope(base.transform);
			GasPumpHoses.Instance.ChangeRopeBulge(base.transform, bulgeOn: false);
		}
		if (holdingIndex == 7)
		{
			ToggleBearTrapRadii(on: false);
		}
		if (holdingIndex == 52)
		{
			ToggleLandmineRadii(on: false);
		}
		if (holdingIndex == 53)
		{
			ToggleStunMineRadii(on: false);
		}
	}

	public void UnpauseUseItem()
	{
		flamethrowerFireLoop.volume = 0f;
		rotationIndex = 0;
		Invoke("CheckConstrictedInteractables", 0.1f);
		canControlItem = true;
		flashlightLight.SetActive(value: false);
		alreadyPlacing = false;
		letGoOfInteract = true;
		StoreManager.Instance.noMoreAmmo.SetActive(value: false);
		if (holdingIndex != -1)
		{
			thirdPersonMan.EquipObj(holdingIndex);
			holdingObjs[holdingIndex].SetActive(value: true);
			itemCanvases[holdingIndex].SetActive(value: true);
			if (curInventorySlot >= 0)
			{
				for (int i = 0; i < pistolBulletIcons.Length; i++)
				{
					pistolBulletIcons[i].SetActive(i < crateStorages[curInventorySlot]);
				}
				for (int j = 0; j < shotgunBulletIcons.Length; j++)
				{
					shotgunBulletIcons[j].SetActive(j < crateStorages[curInventorySlot]);
				}
				flamethrowerAmmoText.text = crateStorages[curInventorySlot].ToString("0");
			}
			if (holdingIndex == 6 && curInventorySlot >= 0)
			{
				if (trash[curInventorySlot] <= 10)
				{
					trashBagAnim.SetTrigger(trash[curInventorySlot].ToString());
				}
				else
				{
					trashBagAnim.SetTrigger("10");
				}
				if (trash[curInventorySlot] > 0)
				{
					StoreManager.Instance.dumpsterOutline.enabled = true;
				}
			}
			if (holdingIndex == 15)
			{
				GasPumpHoses.Instance.ConnectRope(base.transform);
			}
			if (holdingIndex == 7)
			{
				ToggleBearTrapRadii(on: true);
			}
			if (holdingIndex == 52)
			{
				ToggleLandmineRadii(on: true);
			}
			if (holdingIndex == 53)
			{
				ToggleStunMineRadii(on: true);
			}
		}
		Invoke("TurnOffTaskingObjs", 0.1f);
	}

	private void TurnOffTaskingObjs()
	{
		completingBoardFillAmount.gameObject.SetActive(value: false);
		completingTaskFillAmount.gameObject.SetActive(value: false);
		completingExplosiveFillAmount.gameObject.SetActive(value: false);
	}

	private void PlayAddTrashAnim()
	{
		trashBagAnim.SetTrigger("AddTrash");
	}

	private void CanShoot()
	{
		canShoot = true;
	}

	private void ChangeHasGun(bool hasGun_)
	{
		if (base.isServer)
		{
			ChangeHasGunRpc(hasGun_);
		}
		else
		{
			ChangeHasGunCmd(hasGun_);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeHasGunCmd(bool hasGun_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(hasGun_);
		SendCommandInternal("System.Void InventoryManager::ChangeHasGunCmd(System.Boolean)", -67772487, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeHasGunRpc(bool hasGun_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(hasGun_);
		SendRPCInternal("System.Void InventoryManager::ChangeHasGunRpc(System.Boolean)", -789954002, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void DropObject()
	{
		if (ClientPlayer.Instance != GetComponent<ClientPlayer>())
		{
			return;
		}
		StoreManager.Instance.noMoreAmmo.SetActive(value: false);
		StoreManager.Instance.standFurtherBackWarning.SetActive(value: false);
		if (flashlightLight.activeInHierarchy)
		{
			storeMan.FlashlightToggled(-1);
		}
		Invoke("CheckConstrictedInteractables", 0.5f);
		StoreManager.Instance.rToReload.SetActive(value: false);
		if ((bool)spillCam)
		{
			spillCam.SetActive(value: false);
		}
		CancelReload();
		bool flag = false;
		inventoryAmounts[curInventorySlot]--;
		if (inventoryAmounts[curInventorySlot] <= 0)
		{
			flag = true;
			thirdPersonMan.DropObj();
			if (curInventorySlot != -1)
			{
				inventoryIds[curInventorySlot] = -1;
				UpdateInventorySlotsUI();
			}
		}
		else
		{
			holdingObjs[holdingIndex].SetActive(value: false);
			holdingObjs[holdingIndex].SetActive(value: true);
			UnpauseUseItem();
			UpdateInventorySlotsUI();
		}
		if (holdingIndex != -1)
		{
			if (holdingIndex == 2)
			{
				ChangeHasGun(hasGun_: false);
			}
			if (holdingIndex == 15)
			{
				GasPumpHoses.Instance.DisconnectRope(base.transform);
				GasPumpHoses.Instance.ChangeRopeBulge(base.transform, bulgeOn: false);
			}
			if (holdingIndex == 7)
			{
				ToggleBearTrapRadii(on: false);
			}
			if (holdingIndex == 52)
			{
				ToggleLandmineRadii(on: false);
			}
			if (holdingIndex == 53)
			{
				ToggleStunMineRadii(on: false);
			}
			playerMan.fpsScript.walkSpeed = 4.5f;
			playerMan.fpsScript.canRun = true;
			if (StoreManager.Instance.pickupObjs[holdingIndex] != null)
			{
				if (flag)
				{
					holdingObjs[holdingIndex].SetActive(value: false);
					itemCanvases[holdingIndex].SetActive(value: false);
				}
				Vector3 direction = dropAnchors[holdingIndex].position - playerCam.position;
				Vector3 throwPosition = dropAnchors[holdingIndex].position;
				if (Physics.Raycast(playerCam.position, direction, out var hitInfo, 1f, throwObstacle))
				{
					throwPosition = hitInfo.point;
				}
				if (base.isServer)
				{
					StoreManager.Instance.ServerDropObject(holdingIndex, throwPosition, dropAnchors[holdingIndex].rotation, crateStorages[curInventorySlot], playerCam.forward, this);
				}
				else
				{
					StoreManager.Instance.NetworkDropObject(holdingIndex, throwPosition, dropAnchors[holdingIndex].rotation, crateStorages[curInventorySlot], playerCam.forward, this);
				}
			}
			else
			{
				holdingObjs[holdingIndex].GetComponent<Animator>().SetTrigger("Return");
				itemCanvases[holdingIndex].SetActive(value: false);
				returnObj = holdingObjs[holdingIndex];
				CancelInvoke("FinishReturnObject");
				Invoke("FinishReturnObject", 0.2f);
			}
			hasTrash = false;
		}
		bearTrapTemplate.gameObject.SetActive(value: false);
		bearTrapTemplateRed.gameObject.SetActive(value: false);
		explosiveTemplate.gameObject.SetActive(value: false);
		explosiveTemplateRed.gameObject.SetActive(value: false);
		posterTemplate.gameObject.SetActive(value: false);
		pottedPlantTemplate.gameObject.SetActive(value: false);
		pottedPlantTemplateRed.gameObject.SetActive(value: false);
		waterCoolerTemplate.gameObject.SetActive(value: false);
		waterCoolerTemplateRed.gameObject.SetActive(value: false);
		basketRackTemplate.gameObject.SetActive(value: false);
		basketRackTemplateRed.gameObject.SetActive(value: false);
		atmTemplate.gameObject.SetActive(value: false);
		atmTemplateRed.gameObject.SetActive(value: false);
		mailboxTemplate.gameObject.SetActive(value: false);
		mailboxTemplateRed.gameObject.SetActive(value: false);
		trashCanTemplate.gameObject.SetActive(value: false);
		trashCanTemplateRed.gameObject.SetActive(value: false);
		bannerTemplate.gameObject.SetActive(value: false);
		bannerTemplateRed.gameObject.SetActive(value: false);
		floorMatTemplate.gameObject.SetActive(value: false);
		floorMatTemplateRed.gameObject.SetActive(value: false);
		sunglassesRackTemplate.gameObject.SetActive(value: false);
		sunglassesRackTemplateRed.gameObject.SetActive(value: false);
		booksTemplate.gameObject.SetActive(value: false);
		booksTemplateRed.gameObject.SetActive(value: false);
		bobbleHeadTemplate.gameObject.SetActive(value: false);
		bobbleHeadTemplateRed.gameObject.SetActive(value: false);
		burgerTemplate.gameObject.SetActive(value: false);
		burgerTemplateRed.gameObject.SetActive(value: false);
		plant1Template.gameObject.SetActive(value: false);
		plant1TemplateRed.gameObject.SetActive(value: false);
		plant2Template.gameObject.SetActive(value: false);
		plant2TemplateRed.gameObject.SetActive(value: false);
		plant3Template.gameObject.SetActive(value: false);
		plant3TemplateRed.gameObject.SetActive(value: false);
		plant4Template.gameObject.SetActive(value: false);
		plant4TemplateRed.gameObject.SetActive(value: false);
		robotTemplate.gameObject.SetActive(value: false);
		robotTemplateRed.gameObject.SetActive(value: false);
		boomboxTemplate.gameObject.SetActive(value: false);
		boomboxTemplateRed.gameObject.SetActive(value: false);
		gumballTemplate.gameObject.SetActive(value: false);
		gumballTemplateRed.gameObject.SetActive(value: false);
		ivyTemplate.gameObject.SetActive(value: false);
		ivyTemplateRed.gameObject.SetActive(value: false);
		stringLightsTemplate.gameObject.SetActive(value: false);
		stringLightsTemplateRed.gameObject.SetActive(value: false);
		painting1Template.gameObject.SetActive(value: false);
		painting1TemplateRed.gameObject.SetActive(value: false);
		painting2Template.gameObject.SetActive(value: false);
		painting2TemplateRed.gameObject.SetActive(value: false);
		painting3Template.gameObject.SetActive(value: false);
		painting3TemplateRed.gameObject.SetActive(value: false);
		deerTemplate.gameObject.SetActive(value: false);
		deerTemplateRed.gameObject.SetActive(value: false);
		if (flag)
		{
			UpdateHoldingIndex(-1);
		}
		thirdPersonMan.DropObj();
		StoreManager.Instance.noMoreAmmo.SetActive(value: false);
	}

	private void FinishReturnObject()
	{
		returnObj.SetActive(value: false);
		returnObj = null;
	}

	public void DestroyObject()
	{
		if (ClientPlayer.Instance == GetComponent<ClientPlayer>())
		{
			StoreManager.Instance.rToReload.SetActive(value: false);
		}
		spillCam.SetActive(value: false);
		StoreManager.Instance.noMoreAmmo.SetActive(value: false);
		StoreManager.Instance.standFurtherBackWarning.SetActive(value: false);
		CancelReload();
		bool flag = false;
		inventoryAmounts[curInventorySlot]--;
		if (inventoryAmounts[curInventorySlot] <= 0)
		{
			flag = true;
			thirdPersonMan.DropObj();
			if (curInventorySlot != -1)
			{
				inventoryIds[curInventorySlot] = -1;
				UpdateInventorySlotsUI();
			}
		}
		else
		{
			holdingObjs[holdingIndex].SetActive(value: false);
			holdingObjs[holdingIndex].SetActive(value: true);
			UnpauseUseItem();
			UpdateInventorySlotsUI();
		}
		if (holdingIndex != -1)
		{
			holdingObjs[holdingIndex].SetActive(value: false);
			itemCanvases[holdingIndex].SetActive(value: false);
			if (holdingIndex == 2)
			{
				ChangeHasGun(hasGun_: false);
			}
			if (holdingIndex == 15)
			{
				GasPumpHoses.Instance.DisconnectRope(base.transform);
				GasPumpHoses.Instance.ChangeRopeBulge(base.transform, bulgeOn: false);
			}
			if (holdingIndex == 7)
			{
				ToggleBearTrapRadii(on: false);
			}
			if (holdingIndex == 52)
			{
				ToggleLandmineRadii(on: false);
			}
			if (holdingIndex == 53)
			{
				ToggleStunMineRadii(on: false);
			}
			if (flag)
			{
				holdingObjs[holdingIndex].SetActive(value: false);
				itemCanvases[holdingIndex].SetActive(value: false);
			}
			hasTrash = false;
		}
		posterTemplate.gameObject.SetActive(value: false);
		if (flag)
		{
			UpdateHoldingIndex(-1);
		}
		thirdPersonMan.DropObj();
	}

	private void ThrowObject()
	{
		playerMan.fpsScript.headbobAnim.SetTrigger("Throw");
		CancelReload();
		bool flag = false;
		inventoryAmounts[curInventorySlot]--;
		if (inventoryAmounts[curInventorySlot] <= 0)
		{
			flag = true;
			thirdPersonMan.DropObj();
			if (curInventorySlot != -1)
			{
				inventoryIds[curInventorySlot] = -1;
				UpdateInventorySlotsUI();
			}
		}
		else
		{
			holdingObjs[holdingIndex].SetActive(value: false);
			holdingObjs[holdingIndex].SetActive(value: true);
			UnpauseUseItem();
			UpdateInventorySlotsUI();
		}
		Vector3 direction = throwAnchor.position - base.transform.position;
		Vector3 throwPosition = throwAnchor.position;
		if (Physics.Raycast(base.transform.position, direction, out var hitInfo, 1f, throwObstacle))
		{
			throwPosition = hitInfo.point;
		}
		if (base.isServer)
		{
			StoreManager.Instance.ServerThrowObject(holdingIndex, throwPosition, throwAnchor.rotation, playerCam.forward, base.gameObject, 20f);
		}
		else
		{
			StoreManager.Instance.NetworkThrowObject(holdingIndex, throwPosition, throwAnchor.rotation, playerCam.forward, base.gameObject, 20f);
		}
		if (flag)
		{
			holdingObjs[holdingIndex].SetActive(value: false);
			itemCanvases[holdingIndex].SetActive(value: false);
			UpdateHoldingIndex(-1);
			thirdPersonMan.DropObj();
		}
	}

	public void CheckConstrictedInteractables()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("ConstrictedInteractable");
		for (int i = 0; i < array.Length; i++)
		{
			ConstrictedInteractable component = array[i].GetComponent<ConstrictedInteractable>();
			if (component != null)
			{
				int curIndex = holdingIndex;
				if (!canControlItem)
				{
					curIndex = -1;
				}
				component.CheckForCurItem(curIndex);
			}
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

	public override void OnStartLocalPlayer()
	{
		NetworksteamId = SteamUser.GetSteamID().m_SteamID;
		CmdSendSteamId(steamId);
	}

	[Command]
	private void CmdSendSteamId(ulong id)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarULong(id);
		SendCommandInternal("System.Void InventoryManager::CmdSendSteamId(System.UInt64)", -833429406, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void LoadInventoryFromLastSave()
	{
		if (alreadyLoadedInventory)
		{
			return;
		}
		alreadyLoadedInventory = true;
		MonoBehaviour.print("____________LOADING INVENTORY");
		SaveManager instance = SaveManager.Instance;
		for (int i = 0; i < instance.steamIds.Count; i++)
		{
			MonoBehaviour.print("____________GOING THRU STEAM IDS");
			if (instance.steamIds[i] != steamId)
			{
				continue;
			}
			MonoBehaviour.print("____________FOUND MY STEAM ID");
			for (int j = 0; j < instance.inventoryIds[i].Count; j++)
			{
				MonoBehaviour.print("____________GOING THRU SAVED OBJECTS " + instance.inventoryIds[i][j] + instance.inventoryAmounts[i][j] + instance.boxStorages[i][j] + instance.trashAmounts[i][j]);
				int num = instance.inventoryIds[i][j];
				if (num != 2 && num != 11 && num != 42 && num != 15 && num != 45 && num != 46)
				{
					inventoryIds[j] = num;
					inventoryAmounts[j] = instance.inventoryAmounts[i][j];
					crateStorages[j] = instance.boxStorages[i][j];
					trash[j] = instance.trashAmounts[i][j];
				}
			}
		}
		MonoBehaviour.print("____________ TRYING TO UPDATE INVENTORY SLOTS");
		UpdateInventorySlotsUI();
		Invoke("UpdateInventorySlotsUI", 0.5f);
		Invoke("UpdateInventorySlotsUI", 1f);
		Invoke("UpdateInventorySlotsUI", 2f);
		MonoBehaviour.print("____________ FINISHED LOADING INVENTORY");
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_UpdateInventoryForHostCmd__Int32_005B_005D__Int32_005B_005D__Int32_005B_005D(int[] inventoryIds_, int[] inventoryAmounts_, int[] trash_)
	{
		inventoryIds = inventoryIds_;
		inventoryAmounts = inventoryAmounts_;
		trash = trash_;
	}

	protected static void InvokeUserCode_UpdateInventoryForHostCmd__Int32_005B_005D__Int32_005B_005D__Int32_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command UpdateInventoryForHostCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_UpdateInventoryForHostCmd__Int32_005B_005D__Int32_005B_005D__Int32_005B_005D(GeneratedNetworkCode._Read_System_002EInt32_005B_005D(reader), GeneratedNetworkCode._Read_System_002EInt32_005B_005D(reader), GeneratedNetworkCode._Read_System_002EInt32_005B_005D(reader));
		}
	}

	protected void UserCode_SetMaxInventorySlots__Int32(int slots)
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		maxInventorySlots = slots;
		switch (slots)
		{
		case 3:
			inventoryUIHolder.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
			break;
		case 4:
			inventoryUIHolder.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
			break;
		default:
			inventoryUIHolder.transform.localScale = Vector3.one;
			break;
		}
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			if (i < maxInventorySlots)
			{
				inventorySlots[i].gameObject.SetActive(value: true);
			}
			else
			{
				inventorySlots[i].gameObject.SetActive(value: false);
			}
		}
	}

	protected static void InvokeUserCode_SetMaxInventorySlots__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetMaxInventorySlots called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_SetMaxInventorySlots__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_Pulverized()
	{
		hasThrownIntoPulverizerBefore = true;
	}

	protected static void InvokeUserCode_Pulverized(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC Pulverized called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_Pulverized();
		}
	}

	protected void UserCode_UpdateHoldingIndexCmd__Int32(int index)
	{
		UpdateHoldingIndexRpc(index);
	}

	protected static void InvokeUserCode_UpdateHoldingIndexCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command UpdateHoldingIndexCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_UpdateHoldingIndexCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_UpdateHoldingIndexRpc__Int32(int index)
	{
		holdingIndex = index;
	}

	protected static void InvokeUserCode_UpdateHoldingIndexRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateHoldingIndexRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_UpdateHoldingIndexRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_IgnoreCollisionCmd__GameObject__GameObject(GameObject a, GameObject b)
	{
		IgnoreCollisionRpc(a, b);
	}

	protected static void InvokeUserCode_IgnoreCollisionCmd__GameObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command IgnoreCollisionCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_IgnoreCollisionCmd__GameObject__GameObject(reader.ReadGameObject(), reader.ReadGameObject());
		}
	}

	protected void UserCode_IgnoreCollisionRpc__GameObject__GameObject(GameObject a, GameObject b)
	{
		if (!a || !b)
		{
			return;
		}
		Collider collider = null;
		Collider collider2 = null;
		if ((bool)a.GetComponent<CharacterController>())
		{
			collider = a.GetComponent<CharacterController>();
		}
		else if ((bool)a.GetComponent<PickupObject>())
		{
			collider = a.GetComponent<PickupObject>().col;
		}
		if ((bool)b.GetComponent<CharacterController>())
		{
			collider2 = b.GetComponent<CharacterController>();
		}
		else if ((bool)b.GetComponent<PickupObject>())
		{
			collider2 = b.GetComponent<PickupObject>().col;
		}
		if ((bool)collider && (bool)collider2)
		{
			Physics.IgnoreCollision(collider, collider2);
			if (base.isServer)
			{
				StartCoroutine(StopIgnoreCollision(a, b));
			}
		}
	}

	protected static void InvokeUserCode_IgnoreCollisionRpc__GameObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC IgnoreCollisionRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_IgnoreCollisionRpc__GameObject__GameObject(reader.ReadGameObject(), reader.ReadGameObject());
		}
	}

	protected void UserCode_StopIgnoreCollisionRpc__GameObject__GameObject(GameObject a, GameObject b)
	{
		if ((bool)a && (bool)b)
		{
			Collider collider = null;
			Collider collider2 = null;
			if ((bool)a.GetComponent<CharacterController>())
			{
				collider = a.GetComponent<CharacterController>();
			}
			if ((bool)a.GetComponent<PickupObject>())
			{
				collider = a.GetComponent<PickupObject>().col;
			}
			if ((bool)b.GetComponent<CharacterController>())
			{
				collider2 = b.GetComponent<CharacterController>();
			}
			if ((bool)b.GetComponent<PickupObject>())
			{
				collider2 = b.GetComponent<PickupObject>().col;
			}
			Physics.IgnoreCollision(collider, collider2, ignore: false);
		}
	}

	protected static void InvokeUserCode_StopIgnoreCollisionRpc__GameObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC StopIgnoreCollisionRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_StopIgnoreCollisionRpc__GameObject__GameObject(reader.ReadGameObject(), reader.ReadGameObject());
		}
	}

	protected void UserCode_ChangeCrateStorageCmd__Int32__Int32(int invSlot, int value)
	{
		ChangeCrateStorageRpc(invSlot, value);
	}

	protected static void InvokeUserCode_ChangeCrateStorageCmd__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeCrateStorageCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_ChangeCrateStorageCmd__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_ChangeCrateStorageRpc__Int32__Int32(int invSlot, int value)
	{
		if (invSlot != -1)
		{
			crateStorages[invSlot] = value;
		}
	}

	protected static void InvokeUserCode_ChangeCrateStorageRpc__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeCrateStorageRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_ChangeCrateStorageRpc__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_GotARatCmd()
	{
		GotARatRpc();
	}

	protected static void InvokeUserCode_GotARatCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GotARatCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_GotARatCmd();
		}
	}

	protected void UserCode_GotARatRpc()
	{
		if ((bool)RatCountdown.Instance)
		{
			RatCountdown.Instance.GotARat();
		}
	}

	protected static void InvokeUserCode_GotARatRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GotARatRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_GotARatRpc();
		}
	}

	protected void UserCode_PlaceItemCmd__PlayerManager__String__Vector3__Quaternion(PlayerManager playerMan, string type, Vector3 pos, Quaternion rot)
	{
		PlaceItemRpc(playerMan, type, pos, rot);
	}

	protected static void InvokeUserCode_PlaceItemCmd__PlayerManager__String__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PlaceItemCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_PlaceItemCmd__PlayerManager__String__Vector3__Quaternion(reader.ReadNetworkBehaviour<PlayerManager>(), reader.ReadString(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_ActuallySetRemoteTrap__GameObject(GameObject obj)
	{
		if (base.isLocalPlayer)
		{
			SetRemoteTrap(obj.GetComponent<RemoteTrap>());
		}
	}

	protected static void InvokeUserCode_ActuallySetRemoteTrap__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallySetRemoteTrap called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_ActuallySetRemoteTrap__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_PlaceItemRpc__PlayerManager__String__Vector3__Quaternion(PlayerManager playerMan, string type, Vector3 pos, Quaternion rot)
	{
		if (base.isServer)
		{
			switch (type)
			{
			case "bear trap":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedbearTrap, pos, rot));
				break;
			case "explosive":
			{
				GameObject obj = UnityEngine.Object.Instantiate(placedExplosive, pos, rot);
				NetworkServer.Spawn(obj);
				ActuallySetRemoteTrap(obj);
				break;
			}
			case "poster":
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(placedPoster, pos, rot);
				NetworkServer.Spawn(gameObject2);
				playerMan.SetPoster(gameObject2.GetComponent<CreatingPoster>());
				break;
			}
			case "potted plant":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPottedPlant, pos, rot));
				break;
			case "water cooler":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedWaterCooler, pos, rot));
				break;
			case "basket rack":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedBasketRack, pos, rot));
				break;
			case "atm":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedATM, pos, rot));
				break;
			case "mailbox":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedMailbox, pos, rot));
				break;
			case "trashcan":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedTrashcan, pos, rot));
				break;
			case "banner":
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(placedBanner, pos, rot);
				NetworkServer.Spawn(gameObject);
				playerMan.SetPoster(gameObject.GetComponent<CreatingPoster>());
				break;
			}
			case "floor mat":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedFloorMat, pos, rot));
				break;
			case "sunglasses rack":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedSunglassesRack, pos, rot));
				break;
			case "books":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedBooks, pos, rot));
				break;
			case "bobble head":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedBobbleHead, pos, rot));
				break;
			case "burger":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedBurger, pos, rot));
				break;
			case "plant1":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPlant1, pos, rot));
				break;
			case "plant2":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPlant2, pos, rot));
				break;
			case "plant3":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPlant3, pos, rot));
				break;
			case "plant4":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPlant4, pos, rot));
				break;
			case "robot":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedRobot, pos, rot));
				break;
			case "boombox":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedBoombox, pos, rot));
				break;
			case "gumball":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedGumball, pos, rot));
				break;
			case "clock":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedClock, pos, rot));
				break;
			case "ivy":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedIvy, pos, rot));
				break;
			case "string lights":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedStringLights, pos, rot));
				break;
			case "painting1":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPainting1, pos, rot));
				break;
			case "painting2":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPainting2, pos, rot));
				break;
			case "painting3":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedPainting3, pos, rot));
				break;
			case "deer":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedDeer, pos, rot));
				break;
			case "landmine":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedLandmine, pos, rot));
				break;
			case "stun mine":
				NetworkServer.Spawn(UnityEngine.Object.Instantiate(placedStunMine, pos, rot));
				break;
			}
		}
	}

	protected static void InvokeUserCode_PlaceItemRpc__PlayerManager__String__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PlaceItemRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_PlaceItemRpc__PlayerManager__String__Vector3__Quaternion(reader.ReadNetworkBehaviour<PlayerManager>(), reader.ReadString(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_UpdateCurInventorySlotCmd__Int32(int slot)
	{
		UpdateCurInventorySlotRpc(slot);
	}

	protected static void InvokeUserCode_UpdateCurInventorySlotCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command UpdateCurInventorySlotCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_UpdateCurInventorySlotCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_UpdateCurInventorySlotRpc__Int32(int slot)
	{
		curInventorySlot = slot;
	}

	protected static void InvokeUserCode_UpdateCurInventorySlotRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateCurInventorySlotRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_UpdateCurInventorySlotRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ChangeHasGunCmd__Boolean(bool hasGun_)
	{
		ChangeHasGunRpc(hasGun_);
	}

	protected static void InvokeUserCode_ChangeHasGunCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeHasGunCmd called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_ChangeHasGunCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeHasGunRpc__Boolean(bool hasGun_)
	{
		hasGun = hasGun_;
	}

	protected static void InvokeUserCode_ChangeHasGunRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeHasGunRpc called on server.");
		}
		else
		{
			((InventoryManager)obj).UserCode_ChangeHasGunRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSendSteamId__UInt64(ulong id)
	{
		NetworksteamId = id;
	}

	protected static void InvokeUserCode_CmdSendSteamId__UInt64(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSendSteamId called on client.");
		}
		else
		{
			((InventoryManager)obj).UserCode_CmdSendSteamId__UInt64(reader.ReadVarULong());
		}
	}

	static InventoryManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::UpdateInventoryForHostCmd(System.Int32[],System.Int32[],System.Int32[])", InvokeUserCode_UpdateInventoryForHostCmd__Int32_005B_005D__Int32_005B_005D__Int32_005B_005D, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::UpdateHoldingIndexCmd(System.Int32)", InvokeUserCode_UpdateHoldingIndexCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::IgnoreCollisionCmd(UnityEngine.GameObject,UnityEngine.GameObject)", InvokeUserCode_IgnoreCollisionCmd__GameObject__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::ChangeCrateStorageCmd(System.Int32,System.Int32)", InvokeUserCode_ChangeCrateStorageCmd__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::GotARatCmd()", InvokeUserCode_GotARatCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::PlaceItemCmd(PlayerManager,System.String,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_PlaceItemCmd__PlayerManager__String__Vector3__Quaternion, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::UpdateCurInventorySlotCmd(System.Int32)", InvokeUserCode_UpdateCurInventorySlotCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::ChangeHasGunCmd(System.Boolean)", InvokeUserCode_ChangeHasGunCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventoryManager), "System.Void InventoryManager::CmdSendSteamId(System.UInt64)", InvokeUserCode_CmdSendSteamId__UInt64, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::SetMaxInventorySlots(System.Int32)", InvokeUserCode_SetMaxInventorySlots__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::Pulverized()", InvokeUserCode_Pulverized);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::UpdateHoldingIndexRpc(System.Int32)", InvokeUserCode_UpdateHoldingIndexRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::IgnoreCollisionRpc(UnityEngine.GameObject,UnityEngine.GameObject)", InvokeUserCode_IgnoreCollisionRpc__GameObject__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::StopIgnoreCollisionRpc(UnityEngine.GameObject,UnityEngine.GameObject)", InvokeUserCode_StopIgnoreCollisionRpc__GameObject__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::ChangeCrateStorageRpc(System.Int32,System.Int32)", InvokeUserCode_ChangeCrateStorageRpc__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::GotARatRpc()", InvokeUserCode_GotARatRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::ActuallySetRemoteTrap(UnityEngine.GameObject)", InvokeUserCode_ActuallySetRemoteTrap__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::PlaceItemRpc(PlayerManager,System.String,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_PlaceItemRpc__PlayerManager__String__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::UpdateCurInventorySlotRpc(System.Int32)", InvokeUserCode_UpdateCurInventorySlotRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(InventoryManager), "System.Void InventoryManager::ChangeHasGunRpc(System.Boolean)", InvokeUserCode_ChangeHasGunRpc__Boolean);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarULong(steamId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarULong(steamId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref steamId, null, reader.ReadVarULong());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref steamId, null, reader.ReadVarULong());
		}
	}
}
