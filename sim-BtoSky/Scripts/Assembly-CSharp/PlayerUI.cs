using System;
using RainbowArt.CleanFlatUI;
using Suburb;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
	[SerializeField]
	private GameObject interact;

	[SerializeField]
	private TextMeshProUGUI interactText;

	[SerializeField]
	private RectTransform icon;

	[SerializeField]
	private Notification doorLockedUI;

	[SerializeField]
	private Notification rocketNeededUI;

	[SerializeField]
	private Notification cannotGrabItemUI;

	[SerializeField]
	private Notification noIngerdientInFridgeUI;

	[SerializeField]
	private Notification noIngredientInShelfUI;

	[SerializeField]
	private Notification noTrashUI;

	[SerializeField]
	private Notification newDecalUI;

	[SerializeField]
	private Notification newColorUI;

	[SerializeField]
	private Notification cannotDisassembleUI;

	[SerializeField]
	private Notification notEnoughMoneyUI;

	[SerializeField]
	private Notification shoppingBagNeededUI;

	[SerializeField]
	private Notification deviceNeededUI;

	[SerializeField]
	private Notification cpuNeededUI;

	[SerializeField]
	private Notification grainRocketNeededUI;

	[SerializeField]
	private Notification decalEmptyUI;

	[SerializeField]
	private Notification rocketMountExistUI;

	[SerializeField]
	private Notification alreadyPayedUI;

	[SerializeField]
	private GameObject rocketRecordingRaw;

	[SerializeField]
	private Image newColorImage;

	[SerializeField]
	private Image newDecalImage;

	[SerializeField]
	private Notification jobExistUI;

	[SerializeField]
	private GameObject dropKeyUI;

	[SerializeField]
	private GameObject eatKeyUI;

	[SerializeField]
	private GameObject tabCloseKeyUI;

	[SerializeField]
	private GameObject wheelKeyUI;

	[SerializeField]
	private Notification perkAvailableUI;

	[SerializeField]
	private GameObject altInteractionUI;

	[SerializeField]
	private TextMeshProUGUI altInteractionText;

	[SerializeField]
	private RectTransform rcHorizontalLayoutRect;

	[SerializeField]
	private GameObject rcTapCloseKeyUI;

	[SerializeField]
	private GameObject collectScrapKeyUI;

	[SerializeField]
	private GameObject releaseTrashKeyUI;

	private void Awake()
	{
	}

	private void Start()
	{
		GameManager.S.OnAlreadyPayed += S_OnAlreadyPayed;
		GameManager.S.OnRocketMountExist += S_OnRocketMountExist;
		GameManager.S.OnDecalEmpty += S_OnDecalEmpty;
		GameManager.S.OnGrainRocketNeeded += S_OnGrainRocketNeeded;
		GameManager.S.OnCpuNeeded += S_OnCpuNeeded;
		GameManager.S.OnDeviceNeeded += S_OnDeviceNeeded;
		GameManager.S.OnShoppingBagNeeded += S_OnShoppingBagNeeded;
		GameManager.S.OnNotenoughMoney += S_OnNotenoughMoney;
		GameManager.S.OnCannotDisassemble += S_OnCannotDisassemble;
		GameManager.S.OnFurnitureObtained += S_OnFurnitureObtained;
		GameManager.S.OnTrashWrong += S_OnTrashWrong;
		Paint.OnNewColorUnlocked += Paint_OnNewColorUnlocked;
		StickerMachine.OnNewDecalUnlocked += StickerMachine_OnNewDecalUnlocked;
		RcCar.OnControlRc += RcCar_OnControlRc;
		RcCar.OnControlRcDone += RcCar_OnControlRcDone;
		FirstPersonController.S.OnAltInteractionDetected += S_OnAltInteractionDetected;
		FirstPersonController.S.OnAltInteractionUndetected += S_OnAltInteractionUndetected;
		RcCar.InteractableDetected += RcCar_InteractableDetected;
		QuestManager.S.OnParttimeOccupied += S_OnParttimeOccupied;
		GameManager.S.OnCraftingDone += GameManager_OnCraftingDone;
		GameManager.S.OnCookingDone += GameManager_OnCookingDone;
		GameManager.S.OnCraftingTable += GamaManager_OnCraftingTable;
		GameManager.S.OnCookingTable += GameManager_OnCookingTable;
		GameManager.S.player.InteractableDetected += Player_InteractableDetected;
		GameManager.S.OnRocketLaunch += S_OnRocketLaunch;
		GameManager.S.OnRocketLanded += GameManager_RocketLanded;
		GameManager.S.OnConversationStart += GameManager_OnConversationStart;
		GameManager.S.OnEndConversation += GameManager_OnEndConversation;
		GameManager.S.OnComputerInteracted += GameManager_OnComputerInteracted;
		GameManager.S.OnMotorCraftingTableInteracted += GameManager_OnMotorCraftingTableInteracted;
		GameManager.S.OnMotorCraftingDone += Gm_OnMotorCraftingDone;
		GameManager.S.OnOffPlayerUI += Gm_OnOffPlayerUI;
		GameManager.S.OnOnPlayerUI += Gm_OnOnPlayerUI;
		LockedDoor.OnTryOpenLockedDoor += LockedDoor_OnTryOpenLockedDoor;
		SimpleOpenClose.OnTryOpenLockedDoor += SimpleOpenClose_OnTryOpenLockedDoor;
		CraftTable.OnTryUseCraftingTable += CraftTable_OnTryUseCraftingTable;
		FirstPersonController.S.OnFoodInHand += Player_OnFoodInHand;
		FirstPersonController.S.OnItemInHand += Player_OnItemInHand;
		FirstPersonController.S.OnItemOutHand += Player_OnItemOutHand;
		Item.OnTryGrabItemWhenCannot += Item_OnTryGrabItemWhenCannot;
		CookingUI.OnCannotCook += CookingUI_OnCannotCook;
		MotorCraftingUI.OnCannotCraftMotor += MotorCraftingUI_OnCannotCraftMotor;
		BusStop.OnTryTakeBusWithoutRocket += BusStop_OnTryTakeBusWithoutRocket;
		GameManager.S.OnCookingTable += S_OnCookingTable;
		GameManager.S.OnPlayerLevelUp += S_OnPlayerLevelUp;
		PerkUI.OnPerkUnlocked += PerkUI_OnPerkUnlocked;
		LapTop.OnLapTop += LapTop_OnLapTop;
		LapTop.OffLapTop += LapTop_OffLapTop;
		NpcHouse.OnDoorKnocked += NpcHouse_OnDoorKnocked;
		GameManager.S.OnMotorCraftingTableInteracted += S_OnMotorCraftingTableInteracted;
		GameManager.S.OnHandsFull += S_OnHandsFull;
		interact.gameObject.SetActive(value: false);
	}

	private void S_OnAlreadyPayed()
	{
		alreadyPayedUI.ShowNotification();
		AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
	}

	private void S_OnRocketMountExist()
	{
		AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		rocketMountExistUI.ShowNotification();
	}

	private void S_OnDecalEmpty()
	{
		AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		decalEmptyUI.ShowNotification();
	}

	private void S_OnGrainRocketNeeded()
	{
		AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
		grainRocketNeededUI.ShowNotification();
	}

	private void S_OnCpuNeeded()
	{
		AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		cpuNeededUI.ShowNotification();
	}

	private void S_OnDeviceNeeded()
	{
		AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
		deviceNeededUI.ShowNotification();
	}

	private void S_OnRocketLaunch(int obj)
	{
		OffUI();
		rocketRecordingRaw.SetActive(value: true);
	}

	private void S_OnShoppingBagNeeded()
	{
		AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		shoppingBagNeededUI.ShowNotification();
	}

	private void S_OnNotenoughMoney()
	{
		AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		notEnoughMoneyUI.ShowNotification();
	}

	private void S_OnCannotDisassemble()
	{
		cannotDisassembleUI.ShowNotification();
	}

	private void S_OnFurnitureObtained(Furniture obj)
	{
		wheelKeyUI.SetActive(value: true);
	}

	private void S_OnTrashWrong()
	{
		noTrashUI.ShowNotification();
	}

	private void Paint_OnNewColorUnlocked(Color obj)
	{
		AudioManager.S.PlaySFX(AudioManager.S.unlockColor);
		newColorUI.ShowNotification();
		newColorImage.color = obj;
	}

	private void StickerMachine_OnNewDecalUnlocked(Sprite obj)
	{
		AudioManager.S.PlaySFX(AudioManager.S.unlockColor);
		newDecalUI.ShowNotification();
		newDecalImage.sprite = obj;
		newDecalImage.SetNativeSize();
	}

	private void RcCar_OnControlRcDone()
	{
		rcTapCloseKeyUI.gameObject.SetActive(value: false);
		collectScrapKeyUI.gameObject.SetActive(value: false);
		releaseTrashKeyUI.gameObject.SetActive(value: false);
	}

	private void RcCar_OnControlRc()
	{
		collectScrapKeyUI.gameObject.SetActive(value: true);
		rcTapCloseKeyUI.gameObject.SetActive(value: true);
		altInteractionUI.gameObject.SetActive(value: false);
		releaseTrashKeyUI.gameObject.SetActive(value: true);
		LayoutRebuilder.ForceRebuildLayoutImmediate(rcHorizontalLayoutRect);
	}

	private void S_OnAltInteractionUndetected()
	{
		altInteractionUI.SetActive(value: false);
	}

	private void S_OnAltInteractionDetected(string obj)
	{
		altInteractionText.text = obj;
		altInteractionUI.SetActive(value: true);
	}

	private void S_OnHandsFull()
	{
		cannotGrabItemUI.ShowNotification();
	}

	private void SimpleOpenClose_OnTryOpenLockedDoor()
	{
		doorLockedUI.ShowNotification();
	}

	private void S_OnMotorCraftingTableInteracted(object sender, EventArgs e)
	{
		noIngredientInShelfUI.gameObject.SetActive(value: false);
	}

	private void MotorCraftingUI_OnCannotCraftMotor()
	{
		noIngredientInShelfUI.ShowNotification();
	}

	private void NpcHouse_OnDoorKnocked()
	{
		interact.gameObject.SetActive(value: false);
	}

	private void S_OnParttimeOccupied()
	{
		jobExistUI.ShowNotification();
	}

	private void LapTop_OffLapTop()
	{
		tabCloseKeyUI.SetActive(value: false);
	}

	private void LapTop_OnLapTop()
	{
		tabCloseKeyUI.gameObject.SetActive(value: true);
	}

	private void PerkUI_OnPerkUnlocked()
	{
		if (perkAvailableUI.gameObject.activeSelf)
		{
			perkAvailableUI.HideNotification();
		}
	}

	private void S_OnPlayerLevelUp(object sender, EventArgs e)
	{
		if (!perkAvailableUI.gameObject.activeSelf)
		{
			perkAvailableUI.ShowNotification();
		}
	}

	private void S_OnCookingTable(object sender, EventArgs e)
	{
		noIngerdientInFridgeUI.gameObject.SetActive(value: false);
	}

	private void BusStop_OnTryTakeBusWithoutRocket()
	{
		rocketNeededUI.ShowNotification();
	}

	private void CookingUI_OnCannotCook()
	{
		noIngerdientInFridgeUI.ShowNotification();
	}

	private void Item_OnTryGrabItemWhenCannot()
	{
		if (base.gameObject.activeSelf)
		{
			cannotGrabItemUI.ShowNotification();
		}
	}

	private void Player_OnItemOutHand()
	{
		dropKeyUI.gameObject.SetActive(value: false);
		eatKeyUI.gameObject.SetActive(value: false);
		wheelKeyUI.gameObject.SetActive(value: false);
	}

	private void Player_OnItemInHand()
	{
		dropKeyUI.gameObject.SetActive(value: true);
		altInteractionUI.gameObject.SetActive(value: false);
	}

	private void Player_OnFoodInHand()
	{
		dropKeyUI.gameObject.SetActive(value: true);
		eatKeyUI.gameObject.SetActive(value: true);
	}

	private void CraftTable_OnTryUseCraftingTable()
	{
		rocketNeededUI.ShowNotification();
	}

	private void LockedDoor_OnTryOpenLockedDoor()
	{
		doorLockedUI.ShowNotification();
	}

	private void Gm_OnOnPlayerUI()
	{
		OnUI();
	}

	private void Gm_OnOffPlayerUI()
	{
		OffUI();
	}

	private void OnDestroy()
	{
		GameManager.S.OnAlreadyPayed -= S_OnAlreadyPayed;
		GameManager.S.OnRocketMountExist -= S_OnRocketMountExist;
		GameManager.S.OnDecalEmpty -= S_OnDecalEmpty;
		GameManager.S.OnGrainRocketNeeded -= S_OnGrainRocketNeeded;
		GameManager.S.OnCpuNeeded -= S_OnCpuNeeded;
		GameManager.S.OnDeviceNeeded -= S_OnDeviceNeeded;
		GameManager.S.OnRocketLaunch -= S_OnRocketLaunch;
		GameManager.S.OnShoppingBagNeeded -= S_OnShoppingBagNeeded;
		GameManager.S.OnNotenoughMoney -= S_OnNotenoughMoney;
		GameManager.S.OnCannotDisassemble -= S_OnCannotDisassemble;
		GameManager.S.OnFurnitureObtained -= S_OnFurnitureObtained;
		GameManager.S.OnTrashWrong -= S_OnTrashWrong;
		Paint.OnNewColorUnlocked -= Paint_OnNewColorUnlocked;
		StickerMachine.OnNewDecalUnlocked -= StickerMachine_OnNewDecalUnlocked;
		RcCar.OnControlRc -= RcCar_OnControlRc;
		RcCar.OnControlRcDone -= RcCar_OnControlRcDone;
		FirstPersonController.S.OnAltInteractionDetected -= S_OnAltInteractionDetected;
		FirstPersonController.S.OnAltInteractionUndetected -= S_OnAltInteractionUndetected;
		GameManager.S.OnCraftingDone -= GameManager_OnCraftingDone;
		GameManager.S.OnCookingDone -= GameManager_OnCookingDone;
		GameManager.S.OnCraftingTable -= GamaManager_OnCraftingTable;
		GameManager.S.OnCookingTable -= GameManager_OnCookingTable;
		GameManager.S.player.InteractableDetected -= Player_InteractableDetected;
		RcCar.InteractableDetected -= RcCar_InteractableDetected;
		GameManager.S.OnRocketLanded -= GameManager_RocketLanded;
		GameManager.S.OnConversationStart -= GameManager_OnConversationStart;
		GameManager.S.OnEndConversation -= GameManager_OnEndConversation;
		GameManager.S.OnComputerInteracted -= GameManager_OnComputerInteracted;
		GameManager.S.OnMotorCraftingTableInteracted -= GameManager_OnMotorCraftingTableInteracted;
		GameManager.S.OnMotorCraftingDone -= Gm_OnMotorCraftingDone;
		GameManager.S.OnOffPlayerUI -= Gm_OnOffPlayerUI;
		GameManager.S.OnOnPlayerUI -= Gm_OnOnPlayerUI;
		LockedDoor.OnTryOpenLockedDoor -= LockedDoor_OnTryOpenLockedDoor;
		CraftTable.OnTryUseCraftingTable -= CraftTable_OnTryUseCraftingTable;
		FirstPersonController.S.OnFoodInHand -= Player_OnFoodInHand;
		FirstPersonController.S.OnItemInHand -= Player_OnItemInHand;
		FirstPersonController.S.OnItemOutHand -= Player_OnItemOutHand;
		Item.OnTryGrabItemWhenCannot -= Item_OnTryGrabItemWhenCannot;
		GameManager.S.OnCookingTable -= S_OnCookingTable;
		BusStop.OnTryTakeBusWithoutRocket -= BusStop_OnTryTakeBusWithoutRocket;
		CookingUI.OnCannotCook -= CookingUI_OnCannotCook;
		GameManager.S.OnPlayerLevelUp -= S_OnPlayerLevelUp;
		PerkUI.OnPerkUnlocked -= PerkUI_OnPerkUnlocked;
		LapTop.OnLapTop -= LapTop_OnLapTop;
		LapTop.OffLapTop -= LapTop_OffLapTop;
		QuestManager.S.OnParttimeOccupied -= S_OnParttimeOccupied;
		NpcHouse.OnDoorKnocked -= NpcHouse_OnDoorKnocked;
		MotorCraftingUI.OnCannotCraftMotor -= MotorCraftingUI_OnCannotCraftMotor;
		GameManager.S.OnMotorCraftingTableInteracted -= S_OnMotorCraftingTableInteracted;
		SimpleOpenClose.OnTryOpenLockedDoor -= SimpleOpenClose_OnTryOpenLockedDoor;
		GameManager.S.OnHandsFull -= S_OnHandsFull;
	}

	private void RcCar_InteractableDetected(object sender, RcCar.InteractableDetectedArgs e)
	{
		if (e.isdetected)
		{
			interact.gameObject.SetActive(value: true);
			interactText.text = e.interactionText;
			if (interactText.text == "")
			{
				icon.gameObject.SetActive(value: false);
				return;
			}
			interactText.ForceMeshUpdate();
			Vector3 topLeft = interactText.textInfo.characterInfo[0].topLeft;
			icon.anchoredPosition = new Vector2(topLeft.x - 34.5f, icon.anchoredPosition.y);
			icon.gameObject.SetActive(value: true);
		}
		else
		{
			interact.gameObject.SetActive(value: false);
		}
	}

	private void Gm_OnMotorCraftingDone(object sender, EventArgs e)
	{
		OnUI();
	}

	private void GameManager_OnMotorCraftingTableInteracted(object sender, EventArgs e)
	{
		OffUI();
	}

	private void GameManager_OnComputerInteracted(object sender, EventArgs e)
	{
		OffUI();
	}

	private void GameManager_OnEndConversation(object sender, EventArgs e)
	{
		OnUI();
	}

	private void GameManager_OnConversationStart(object sender, GameManager.OnConversatinoStartArg e)
	{
		OffUI();
	}

	private void GameManager_OnCookingDone(object sender, EventArgs e)
	{
		OnUI();
	}

	private void GameManager_OnCookingTable(object sender, EventArgs e)
	{
		OffUI();
	}

	private void GameManager_OnCraftingDone(object sender, EventArgs e)
	{
		OnUI();
	}

	private void GameManager_OnQuitCrafting(object sender, EventArgs e)
	{
		OnUI();
	}

	private void GamaManager_OnCraftingTable(object sender, EventArgs e)
	{
		OffUI();
	}

	private void GameManager_RocketLanded(object sender, EventArgs e)
	{
		OnUI();
		rocketRecordingRaw.SetActive(value: false);
	}

	private void Player_InteractableDetected(object sender, FirstPersonController.InteractableDetectedArgs e)
	{
		if (e.isdetected)
		{
			interact.gameObject.SetActive(value: true);
			interactText.text = e.interactionText;
			if (interactText.text == "")
			{
				icon.gameObject.SetActive(value: false);
				return;
			}
			interactText.ForceMeshUpdate();
			Vector3 topLeft = interactText.textInfo.characterInfo[0].topLeft;
			icon.anchoredPosition = new Vector2(topLeft.x - 34.5f, icon.anchoredPosition.y);
			icon.gameObject.SetActive(value: true);
		}
		else
		{
			interact.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
	}

	public void OffUI()
	{
		base.gameObject.SetActive(value: false);
		rocketRecordingRaw.SetActive(value: false);
		if (doorLockedUI != null)
		{
			doorLockedUI.gameObject.SetActive(value: false);
		}
		if (rocketNeededUI != null)
		{
			rocketNeededUI.gameObject.SetActive(value: false);
		}
		if (cannotGrabItemUI != null)
		{
			cannotGrabItemUI.gameObject.SetActive(value: false);
		}
		if (noIngerdientInFridgeUI != null)
		{
			noIngerdientInFridgeUI.gameObject.SetActive(value: false);
		}
	}

	public void OnUI()
	{
		base.gameObject.SetActive(value: true);
		if (GameManager.S.isRocketMountExist)
		{
			rocketRecordingRaw.SetActive(value: true);
		}
		interact.gameObject.SetActive(value: true);
	}
}
