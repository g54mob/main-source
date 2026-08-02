using System;
using System.Collections;
using System.Collections.Generic;
using HQFPSTemplate.Equipment;
using UnityEngine;

public class WrenchController : MonoBehaviour
{
	public MeleeWeapon meleeWeapon;

	public float repairAmount = 100f;

	public float repairCastDelay = 0.15f;

	public CollectableItemData wrenchData;

	public PropBase currentTarget;

	public static bool isWrenchActive;

	private Grabber grabber;

	private TSPlayerController player;

	private PlayerInventory playerInventory;

	private Interactor interactor;

	private EastUpPlayerItemManager itemManager;

	private bool isShowingInteraction;

	private bool isRepairing;

	private PropBase lastShownTarget;

	private float lastShownHealth;

	private float fullHealthTime = -1f;

	private void OnEnable()
	{
		isWrenchActive = true;
		if (meleeWeapon != null)
		{
			meleeWeapon.isBlockedToUse = true;
		}
		if (player == null)
		{
			TSPlayerController componentInParent = GetComponentInParent<TSPlayerController>();
			if (componentInParent != null)
			{
				SetParameters(componentInParent);
			}
		}
		if (player == null && Singleton<TSNetworkObjetManager>.Instance != null)
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(SetParameters);
		}
	}

	private void OnDisable()
	{
		isWrenchActive = false;
		HideUI();
		currentTarget = null;
		lastShownTarget = null;
		if (meleeWeapon != null)
		{
			meleeWeapon.isBlockedToUse = true;
		}
	}

	private void SetParameters(TSPlayerController controller)
	{
		if (controller.isLocalPlayer)
		{
			player = controller;
			grabber = controller.GetComponent<Grabber>();
			playerInventory = controller.GetComponent<PlayerInventory>();
			interactor = controller.GetComponent<Interactor>();
			itemManager = controller.GetComponent<EastUpPlayerItemManager>();
		}
	}

	private void Update()
	{
		if (player == null || grabber == null || interactor == null)
		{
			return;
		}
		if (!TrainGameManager.isInputActive)
		{
			if (isShowingInteraction)
			{
				HideUI();
			}
			return;
		}
		if (grabber.IsDismantleMode)
		{
			if (isShowingInteraction)
			{
				HideUI();
			}
			currentTarget = null;
			return;
		}
		if (grabber.selectedGrabbleObject != null)
		{
			if (isShowingInteraction)
			{
				HideUI();
			}
			currentTarget = null;
			lastShownTarget = null;
			if (meleeWeapon != null)
			{
				meleeWeapon.isBlockedToUse = false;
			}
			return;
		}
		PropBase detectedPropBase = interactor.detectedPropBase;
		if (detectedPropBase != null)
		{
			currentTarget = detectedPropBase;
		}
		else if (!(currentTarget != null) || !Input.GetKey(KeyCode.Mouse1))
		{
			currentTarget = null;
		}
		if (lastShownTarget != currentTarget)
		{
			fullHealthTime = -1f;
		}
		bool flag = fullHealthTime > 0f && Time.time - fullHealthTime >= 1f;
		if (flag)
		{
			fullHealthTime = -1f;
		}
		float b = ((currentTarget != null) ? currentTarget.health : 0f);
		if ((!isShowingInteraction || lastShownTarget != currentTarget || !Mathf.Approximately(lastShownHealth, b) || flag) && !Input.GetKey(KeyCode.Mouse1))
		{
			ShowUI();
		}
		HandleRepairInput();
		HandleMoveInput();
		if (meleeWeapon != null)
		{
			meleeWeapon.isBlockedToUse = !(currentTarget != null) || !currentTarget.IsDamaged;
		}
	}

	private void ShowUI()
	{
		if (!(InteractionPanel.Instance == null))
		{
			if (InteractionPanel.Instance.IsBottomInfoLocked)
			{
				InteractionPanel.Instance.UnlockAndHideBottomInfo();
			}
			InteractionPanel.Instance.HideInteraction();
			bool flag = currentTarget != null;
			bool flag2 = flag && (currentTarget.GetComponentInChildren<GroundController>() != null || currentTarget.GetComponentInChildren<WallController>() != null || currentTarget.GetComponentInChildren<RoofController>() != null);
			bool flag3 = flag && currentTarget.IsDamaged;
			bool flag4 = flag;
			bool flag5 = flag && !flag2;
			float holdDuration = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.removeHoldDuration : 1f);
			KeyCode keyCode = ((Singleton<UserPrefencesManager>.Instance != null) ? Singleton<UserPrefencesManager>.Instance.keyData.BuildKey : KeyCode.B);
			List<InteractionData> obj = new List<InteractionData>
			{
				new InteractionData(keyCode, "Build")
			};
			bool isDisabled = !flag3;
			obj.Add(new InteractionData(KeyCode.Mouse0, "Repair", hasHoldAction: false, 1f, null, null, null, null, isDisabled));
			Action onHoldComplete = delegate
			{
				HandleRemove();
			};
			isDisabled = !flag4;
			obj.Add(new InteractionData(KeyCode.Mouse1, "Remove", hasHoldAction: true, holdDuration, onHoldComplete, null, null, null, isDisabled));
			isDisabled = !flag5;
			obj.Add(new InteractionData(KeyCode.Mouse2, "Move", hasHoldAction: false, 1f, null, null, null, null, isDisabled));
			List<InteractionData> interactionDataList = obj;
			InteractionPanel.Instance.ShowBottomInfoInteractionsOverlay(interactionDataList);
			bool flag6 = fullHealthTime > 0f && Time.time - fullHealthTime < 1f;
			if (flag && (currentTarget.IsDamaged || flag6))
			{
				string message = $"{currentTarget.GetDisplayName()} ({currentTarget.health:F0}/{currentTarget.maxHealth:F0})";
				InteractionPanel.Instance.ShowInteractionOverlay(currentTarget.transform, player.transform, KeyCode.None, message);
			}
			isShowingInteraction = true;
			lastShownTarget = currentTarget;
			lastShownHealth = (flag ? currentTarget.health : 0f);
		}
	}

	private void HandleRepairInput()
	{
		if (Input.GetMouseButtonDown(0) && currentTarget != null && currentTarget.IsDamaged && !isRepairing && CanUseWrench())
		{
			StartCoroutine(RepairCoroutine());
		}
	}

	private void HandleMoveInput()
	{
		if (Input.GetMouseButtonDown(2) && currentTarget != null)
		{
			HandleMove();
		}
	}

	private IEnumerator RepairCoroutine()
	{
		isRepairing = true;
		PropBase target = currentTarget;
		yield return new WaitForSeconds(repairCastDelay);
		if (target != null && target.IsDamaged)
		{
			target.Heal(repairAmount);
			DecreaseDurability();
			PlayHitSound(target.transform.position);
			if (TrainBuildManager.Instance != null && target.data != null)
			{
				TrainBuildManager.Instance.CmdUpdateObjectHealth(target.transform.localPosition, target.data.itemName, target.assignedWagonID, target.health);
			}
			if (!target.IsDamaged)
			{
				fullHealthTime = Time.time;
			}
			if (currentTarget == target)
			{
				ShowUI();
			}
		}
		isRepairing = false;
		if (currentTarget == target)
		{
			ShowUI();
		}
	}

	private void HandleRemove()
	{
		Debug.Log("[remove] HandleRemove called | currentTarget: " + ((currentTarget != null) ? currentTarget.name : "null") + " | playerInventory: " + ((playerInventory != null) ? "OK" : "null"));
		if (currentTarget == null || playerInventory == null)
		{
			return;
		}
		Debug.Log($"[remove] target components: Wall={currentTarget.GetComponentInChildren<WallController>() != null} | Roof={currentTarget.GetComponentInChildren<RoofController>() != null} | Ground={currentTarget.GetComponentInChildren<GroundController>() != null} | Grabbable={currentTarget.GetComponent<GrabbableObject>() != null}");
		WallController componentInChildren = currentTarget.GetComponentInChildren<WallController>();
		if (componentInChildren != null)
		{
			Debug.Log("[remove] -> WallController.Remove");
			componentInChildren.Remove(playerInventory);
			AfterAction();
			return;
		}
		RoofController componentInChildren2 = currentTarget.GetComponentInChildren<RoofController>();
		if (componentInChildren2 != null)
		{
			Debug.Log("[remove] -> RoofController.Remove");
			componentInChildren2.Remove(playerInventory);
			AfterAction();
			return;
		}
		GroundController componentInChildren3 = currentTarget.GetComponentInChildren<GroundController>();
		if (componentInChildren3 != null)
		{
			Debug.Log("[remove] -> GroundController.Remove");
			componentInChildren3.Remove(playerInventory);
			AfterAction();
			return;
		}
		GrabbableObject component = currentTarget.GetComponent<GrabbableObject>();
		if (component != null)
		{
			Debug.Log("[remove] -> GrabbableObject.Remove (fallback)");
			component.Remove(playerInventory);
			AfterAction();
		}
		else
		{
			Debug.Log("[remove] -> NO removal path found!");
		}
	}

	private void HandleMove()
	{
		if (!(currentTarget == null) && !(grabber == null) && !(player == null) && !(currentTarget.GetComponentInChildren<GroundController>() != null) && !(currentTarget.GetComponentInChildren<WallController>() != null) && !(currentTarget.GetComponentInChildren<RoofController>() != null))
		{
			GrabbableObject component = currentTarget.GetComponent<GrabbableObject>();
			if (component != null)
			{
				component.Dismantle(grabber, player);
				AfterAction();
			}
		}
	}

	private void AfterAction()
	{
		HideUI();
		currentTarget = null;
		lastShownTarget = null;
	}

	private bool CanUseWrench()
	{
		if (itemManager == null || itemManager.lastSelectedSlot == null)
		{
			return true;
		}
		InventoryItem inventoryItem = itemManager.lastSelectedSlot.InventoryItem;
		if (inventoryItem == null)
		{
			return true;
		}
		return inventoryItem.CanUse();
	}

	private void DecreaseDurability()
	{
		if (!(itemManager == null) && !(itemManager.lastSelectedSlot == null))
		{
			InventoryItem inventoryItem = itemManager.lastSelectedSlot.InventoryItem;
			if (!(inventoryItem == null) && !(wrenchData == null) && wrenchData.hasDurability)
			{
				inventoryItem.DecreaseDurability(wrenchData.durabilityDecreasePerUse);
			}
		}
	}

	private void PlayHitSound(Vector3 position)
	{
		if (!(meleeWeapon == null) && !(NetworkSoundPlayer.Instance == null))
		{
			MeleeWeaponInfo meleeWeaponInfo = meleeWeapon.EInfo as MeleeWeaponInfo;
			if (!(meleeWeaponInfo == null) && meleeWeaponInfo.MeleeSettings != null && meleeWeaponInfo.MeleeSettings.Swings != null && meleeWeaponInfo.MeleeSettings.Swings.Length != 0)
			{
				NetworkSoundPlayer.Instance.PlaySound(meleeWeaponInfo.MeleeSettings.Swings[0].networkHitSound, position);
			}
		}
	}

	private void HideUI()
	{
		if (InteractionPanel.Instance != null)
		{
			if (InteractionPanel.Instance.IsBottomInfoLocked)
			{
				InteractionPanel.Instance.UnlockAndHideBottomInfo();
			}
			InteractionPanel.Instance.HideInteraction();
		}
		isShowingInteraction = false;
		lastShownTarget = null;
	}
}
