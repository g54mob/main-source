using System.Collections;
using System.Collections.Generic;
using Enviro;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Interaction/Player Interaction UI")]
public class PlayerInteractionUI : MonoBehaviour
{
	[Header("Interaction Overlay")]
	public GameObject interactionOverlay;

	public Image holdProgressCircle;

	public Image throwProgressCircle;

	[Header("First Interaction")]
	public GameObject firstInteractionPrompt;

	public Image interactionButton;

	public TextMeshProUGUI interactionText;

	[Header("Second Interaction")]
	public GameObject secondInteractionPrompt;

	public Image secondInteractionButton;

	public TextMeshProUGUI secondInteractionText;

	[Header("Settings & References")]
	public bool startHidden = true;

	public GameManager gameManager;

	[Header("Warning Settings")]
	public GameObject warningIcon;

	public bool isWarningAnimPlayed;

	public Animator warningAnimator;

	[Header("Node UI")]
	public NodeInteractionUI nodeInteractionUI;

	[Header("Pallet UI")]
	public PalletInfoUI palletInfoUI;

	public DeliveryPalletInfoUI deliveryPalletInfoUI;

	[Header("Container UI (Truck/Sack)")]
	public ItemContainerInfoUI containerInfoUI;

	[Header("Hammer Interaction UI")]
	public GameObject hammerInteractionInfo;

	private Coroutine interactableStatusCoroutine;

	private T_Item _cachedItem;

	private BuildingObject _cachedBuildingObj;

	private T_Truck _cachedTruck;

	private T_Pallet _cachedPallet;

	private T_Machine _cachedMachine;

	private T_SortingStation _cachedSortingStation;

	private T_SortingOutput _cachedSortingOutput;

	private T_DeliveryPointInteractable _cachedDeliveryPoint;

	private T_Sack _cachedContainerSack;

	private Interactable _hammerOverrideTarget;

	private InteractionMode _originalPrimaryMode;

	private InteractionMode _originalSecondaryMode;

	private bool _originalEnableSecondary;

	private PrimaryState _originalPrimaryState;

	private SecondaryState _originalSecondaryState;

	private bool _wasLockWarning;

	private void Awake()
	{
		if (gameManager == null)
		{
			gameManager = GameManager.Instance;
		}
		if (startHidden)
		{
			HideImmediate();
		}
	}

	public void SetTarget(Interactable target)
	{
		if (interactableStatusCoroutine != null)
		{
			StopCoroutine(interactableStatusCoroutine);
		}
		RestoreHammerOverride();
		if (target == null)
		{
			HideImmediate();
			if (nodeInteractionUI != null)
			{
				nodeInteractionUI.Hide();
			}
			if (palletInfoUI != null)
			{
				palletInfoUI.Hide();
			}
			if (deliveryPalletInfoUI != null)
			{
				deliveryPalletInfoUI.Hide();
			}
			if (containerInfoUI != null)
			{
				containerInfoUI.Hide();
			}
			if (hammerInteractionInfo != null)
			{
				hammerInteractionInfo.SetActive(value: false);
			}
			return;
		}
		CacheTargetComponents(target);
		T_Item cachedItem = _cachedItem;
		if (cachedItem != null && cachedItem.isNode)
		{
			HideImmediate();
			return;
		}
		if (nodeInteractionUI != null)
		{
			nodeInteractionUI.Hide();
		}
		T_Pallet component = target.GetComponent<T_Pallet>();
		if (component == null && target.targetObj != null)
		{
			component = target.targetObj.GetComponent<T_Pallet>();
		}
		if (component != null && !component.IsEmpty)
		{
			if (palletInfoUI != null)
			{
				palletInfoUI.SetTarget(component);
			}
			if (deliveryPalletInfoUI != null)
			{
				deliveryPalletInfoUI.Hide();
			}
		}
		else
		{
			T_DeliveryPallet component2 = target.GetComponent<T_DeliveryPallet>();
			if (component2 == null && target.targetObj != null)
			{
				component2 = target.targetObj.GetComponent<T_DeliveryPallet>();
			}
			if (component2 != null && component2.TotalItemCount > 0)
			{
				if (palletInfoUI != null)
				{
					palletInfoUI.SetTarget(component2);
				}
				if (deliveryPalletInfoUI != null)
				{
					deliveryPalletInfoUI.Hide();
				}
			}
			else
			{
				if (palletInfoUI != null)
				{
					palletInfoUI.Hide();
				}
				if (deliveryPalletInfoUI != null)
				{
					deliveryPalletInfoUI.Hide();
				}
			}
		}
		bool flag = false;
		T_Truck t_Truck = null;
		if (target.targetObj != null)
		{
			t_Truck = target.targetObj.GetComponent<T_Truck>();
		}
		if (t_Truck == null)
		{
			t_Truck = target.GetComponent<T_Truck>();
		}
		if (t_Truck != null && t_Truck.ItemCount > 0)
		{
			if (containerInfoUI != null)
			{
				containerInfoUI.SetTarget(t_Truck);
			}
			flag = true;
		}
		if (!flag)
		{
			T_Sack t_Sack = null;
			if (target.targetObj != null)
			{
				t_Sack = target.targetObj.GetComponent<T_Sack>();
			}
			if (t_Sack == null)
			{
				t_Sack = target.GetComponent<T_Sack>();
			}
			if (t_Sack != null && t_Sack.ItemCount > 0)
			{
				if (containerInfoUI != null)
				{
					containerInfoUI.SetTarget(t_Sack);
				}
				flag = true;
			}
		}
		if (!flag && containerInfoUI != null)
		{
			containerInfoUI.Hide();
		}
		ShowImmediate();
		SetUI(target);
		interactableStatusCoroutine = StartCoroutine(CheckStatus(target));
	}

	private IEnumerator CheckStatus(Interactable target)
	{
		float statusTimer = 0f;
		while (target != null)
		{
			yield return null;
			if (target == null)
			{
				break;
			}
			UpdateHoldProgress(target);
			statusTimer += Time.deltaTime;
			if (statusTimer >= 0.1f)
			{
				statusTimer = 0f;
				SetUI(target);
				UpdateContainerUI(target);
			}
		}
		HideImmediate();
		if (nodeInteractionUI != null)
		{
			nodeInteractionUI.Hide();
		}
		if (palletInfoUI != null)
		{
			palletInfoUI.Hide();
		}
		if (deliveryPalletInfoUI != null)
		{
			deliveryPalletInfoUI.Hide();
		}
		if (containerInfoUI != null)
		{
			containerInfoUI.Hide();
		}
	}

	private void UpdateContainerUI(Interactable target)
	{
		if (containerInfoUI == null)
		{
			return;
		}
		if (_cachedTruck != null)
		{
			if (_cachedTruck.ItemCount > 0)
			{
				containerInfoUI.SetTarget(_cachedTruck);
			}
			else
			{
				containerInfoUI.Hide();
			}
		}
		else if (_cachedContainerSack != null)
		{
			if (_cachedContainerSack.ItemCount > 0)
			{
				containerInfoUI.SetTarget(_cachedContainerSack);
			}
			else
			{
				containerInfoUI.Hide();
			}
		}
	}

	private void UpdateHoldProgress(Interactable target)
	{
		if (!(holdProgressCircle == null))
		{
			if (target != null && target.IsHolding)
			{
				holdProgressCircle.fillAmount = target.HoldProgress;
			}
			else
			{
				holdProgressCircle.fillAmount = 0f;
			}
		}
	}

	public void HideImmediate()
	{
		if (interactionOverlay != null)
		{
			interactionOverlay.SetActive(value: false);
			firstInteractionPrompt.SetActive(value: false);
			if (holdProgressCircle != null)
			{
				holdProgressCircle.fillAmount = 0f;
			}
			if (hammerInteractionInfo != null)
			{
				hammerInteractionInfo.SetActive(value: false);
			}
			if (interactableStatusCoroutine != null)
			{
				StopCoroutine(interactableStatusCoroutine);
			}
		}
	}

	public void ShowImmediate()
	{
		if (interactionOverlay != null)
		{
			if (warningAnimator != null)
			{
				warningAnimator.ResetTrigger("Warning");
				warningAnimator.SetTrigger("Idle");
			}
			interactionOverlay.SetActive(value: true);
			firstInteractionPrompt.SetActive(value: true);
			isWarningAnimPlayed = false;
		}
	}

	private void SetUI(Interactable target)
	{
		if (interactionText == null)
		{
			return;
		}
		if (target.lockInteractions)
		{
			_wasLockWarning = true;
			interactionButton.gameObject.SetActive(value: false);
			if (secondInteractionPrompt != null)
			{
				secondInteractionPrompt.SetActive(value: false);
			}
			if (!isWarningAnimPlayed)
			{
				if (warningIcon != null)
				{
					warningIcon.SetActive(value: true);
				}
				isWarningAnimPlayed = true;
				if (warningAnimator != null)
				{
					warningAnimator.ResetTrigger("Idle");
					warningAnimator.SetTrigger("Warning");
				}
				string text = LocalizationManager.GetTranslation(target.lockCustomText);
				if (string.IsNullOrEmpty(text))
				{
					text = "NL/" + target.lockCustomText;
				}
				interactionText.text = text;
			}
			return;
		}
		if (_wasLockWarning)
		{
			_wasLockWarning = false;
			isWarningAnimPlayed = false;
			if (warningIcon != null)
			{
				warningIcon.SetActive(value: false);
			}
			if (warningAnimator != null)
			{
				warningAnimator.ResetTrigger("Warning");
				warningAnimator.SetTrigger("Idle");
			}
		}
		T_Item cachedItem = _cachedItem;
		string text2 = ((cachedItem != null && cachedItem.so != null) ? cachedItem.so.Name : target.interactableName);
		GameObject gameObject = ((gameManager.localEquipments != null) ? gameManager.localEquipments.pickupItem : null);
		T_Sack t_Sack = ((gameObject != null) ? gameObject.GetComponent<T_Sack>() : null);
		string text3 = "";
		interactionButton.gameObject.SetActive(value: true);
		bool flag = false;
		BuildingObject cachedBuildingObj = _cachedBuildingObj;
		if (cachedBuildingObj != null && cachedBuildingObj.IsPlaced && target.canHammerInteract && gameManager.localEquipments != null)
		{
			bool flag2 = false;
			T_Equipments localEquipments = gameManager.localEquipments;
			if (localEquipments.equippedIndex >= 0 && localEquipments.equippedIndex < localEquipments.localTools.Count)
			{
				flag2 = localEquipments.localTools[localEquipments.equippedIndex].itemType == ItemType.Hammer;
			}
			bool flag3 = !flag2 && !ShouldBlockHammerInfo();
			if (flag3)
			{
				flag = true;
			}
			if (hammerInteractionInfo != null)
			{
				hammerInteractionInfo.SetActive(flag3);
			}
			if (flag2)
			{
				if (_hammerOverrideTarget != target)
				{
					_hammerOverrideTarget = target;
					_originalPrimaryMode = target.primaryMode;
					_originalSecondaryMode = target.secondaryMode;
					_originalEnableSecondary = target.enableSecondary;
					_originalPrimaryState = target.currentPrimaryState;
					_originalSecondaryState = target.currentSecondaryState;
				}
				string text4 = target.CheckResaleConditions();
				string text5 = target.CheckRelocateConditions();
				if (text4 == null)
				{
					text4 = text5;
				}
				string text6 = text4;
				if (text6 != null)
				{
					target.currentPrimaryState = PrimaryState.None;
					target.primaryMode = InteractionMode.None;
					target.enableSecondary = false;
					interactionButton.gameObject.SetActive(value: false);
					if (secondInteractionPrompt != null)
					{
						secondInteractionPrompt.SetActive(value: false);
					}
					if (!isWarningAnimPlayed)
					{
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: true);
						}
						isWarningAnimPlayed = true;
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Idle");
							warningAnimator.SetTrigger("Warning");
						}
						interactionText.text = text6;
					}
					return;
				}
				target.currentPrimaryState = PrimaryState.Resale;
				target.primaryMode = InteractionMode.Hold;
				target.enableSecondary = true;
				target.currentSecondaryState = SecondaryState.Relocate;
				target.secondaryMode = InteractionMode.Press;
				if (target.secondaryAction != null)
				{
					target.secondaryAction.action.Enable();
				}
				if (warningIcon != null)
				{
					warningIcon.SetActive(value: false);
				}
				if (warningAnimator != null)
				{
					warningAnimator.ResetTrigger("Warning");
					warningAnimator.SetTrigger("Idle");
				}
				if (target.primaryMode != InteractionMode.Press && target.primaryMode != InteractionMode.None)
				{
					string translation = LocalizationManager.GetTranslation(target.primaryMode);
					text3 = text3 + "(" + translation + ") ";
				}
				string text7 = LocalizationManager.GetTranslation(PrimaryState.Resale);
				if (string.IsNullOrEmpty(text7))
				{
					text7 = "Resale";
				}
				text3 += text7;
				if (cachedBuildingObj.buildingItemSO != null)
				{
					text3 = text3 + " $" + cachedBuildingObj.buildingItemSO.Price;
				}
				interactionText.text = text3;
				if (secondInteractionPrompt != null)
				{
					secondInteractionPrompt.SetActive(value: true);
					string text8 = "";
					if (target.secondaryMode != InteractionMode.Press && target.secondaryMode != InteractionMode.None)
					{
						string translation2 = LocalizationManager.GetTranslation(target.secondaryMode);
						text8 = text8 + "(" + translation2 + ") ";
					}
					string text9 = LocalizationManager.GetTranslation(SecondaryState.Relocate);
					if (string.IsNullOrEmpty(text9))
					{
						text9 = "Relocate";
					}
					text8 += text9;
					secondInteractionText.text = text8;
				}
				return;
			}
		}
		if (_hammerOverrideTarget != null)
		{
			RestoreHammerOverride();
			return;
		}
		if (hammerInteractionInfo != null && !flag)
		{
			hammerInteractionInfo.SetActive(value: false);
		}
		if (secondInteractionPrompt != null)
		{
			secondInteractionPrompt.SetActive(value: false);
		}
		if (target.targetObj != null)
		{
			T_Truck cachedTruck = _cachedTruck;
			if (cachedTruck != null && gameManager.localEquipments != null)
			{
				if (gameObject == null && cachedTruck.SackCount > 0)
				{
					target.currentPrimaryState = PrimaryState.Pickup;
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: false);
					}
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Warning");
						warningAnimator.SetTrigger("Idle");
					}
				}
				else if (t_Sack != null)
				{
					target.currentPrimaryState = PrimaryState.Place;
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: false);
					}
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Warning");
						warningAnimator.SetTrigger("Idle");
					}
				}
				else
				{
					target.currentPrimaryState = PrimaryState.None;
					interactionButton.gameObject.SetActive(value: false);
					if (!isWarningAnimPlayed)
					{
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: true);
						}
						isWarningAnimPlayed = true;
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Idle");
							warningAnimator.SetTrigger("Warning");
						}
						string text10 = LocalizationManager.GetTranslation("Required") + " (" + LocalizationManager.GetTranslation("Item_CrateName") + ")";
						interactionText.text = text10;
					}
				}
			}
			T_Machine cachedMachine = _cachedMachine;
			if (cachedMachine != null && gameManager.localEquipments != null)
			{
				if (t_Sack != null)
				{
					if (cachedMachine.HasValidItemsInSack())
					{
						target.currentPrimaryState = PrimaryState.Place;
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: false);
						}
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Warning");
							warningAnimator.SetTrigger("Idle");
						}
					}
					else
					{
						target.currentPrimaryState = PrimaryState.None;
						interactionButton.gameObject.SetActive(value: false);
						if (!isWarningAnimPlayed)
						{
							if (warningIcon != null)
							{
								warningIcon.SetActive(value: true);
							}
							isWarningAnimPlayed = true;
							if (warningAnimator != null)
							{
								warningAnimator.ResetTrigger("Idle");
								warningAnimator.SetTrigger("Warning");
							}
							string text11 = LocalizationManager.GetTranslation("Notification_RejectedItem");
							if (string.IsNullOrEmpty(text11))
							{
								text11 = "NL/ Bu item makineye uygun değil.";
							}
							interactionText.text = text11;
						}
					}
				}
				else
				{
					target.currentPrimaryState = PrimaryState.OnlyName;
				}
			}
		}
		T_Pallet cachedPallet = _cachedPallet;
		if (cachedPallet != null && gameManager.localEquipments != null)
		{
			if (gameObject == null && !cachedPallet.IsEmpty)
			{
				target.currentPrimaryState = PrimaryState.Pickup;
				isWarningAnimPlayed = false;
				if (warningIcon != null)
				{
					warningIcon.SetActive(value: false);
				}
				if (warningAnimator != null)
				{
					warningAnimator.ResetTrigger("Warning");
					warningAnimator.SetTrigger("Idle");
				}
			}
			else if (t_Sack != null)
			{
				T_Sack t_Sack2 = t_Sack;
				if (t_Sack2.ItemCount > 0)
				{
					bool flag4 = false;
					if (cachedPallet.IsEmpty)
					{
						flag4 = true;
					}
					else
					{
						foreach (KeyValuePair<string, int> storedItemCount in t_Sack2.GetStoredItemCounts())
						{
							if (storedItemCount.Key == cachedPallet.PaletItemId)
							{
								flag4 = true;
								break;
							}
						}
					}
					if (flag4)
					{
						target.currentPrimaryState = PrimaryState.Place;
						isWarningAnimPlayed = false;
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: false);
						}
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Warning");
							warningAnimator.SetTrigger("Idle");
						}
					}
					else
					{
						target.currentPrimaryState = PrimaryState.None;
						interactionButton.gameObject.SetActive(value: false);
						if (!isWarningAnimPlayed)
						{
							if (warningIcon != null)
							{
								warningIcon.SetActive(value: true);
							}
							isWarningAnimPlayed = true;
							if (warningAnimator != null)
							{
								warningAnimator.ResetTrigger("Idle");
								warningAnimator.SetTrigger("Warning");
							}
							string text12 = LocalizationManager.GetTranslation("Required") + " (" + (cachedPallet.IsEmpty ? LocalizationManager.GetTranslation("Item_CrateName") : GetItemNameFromId(cachedPallet.PaletItemId)) + ")";
							interactionText.text = text12;
						}
					}
				}
				else
				{
					target.currentPrimaryState = PrimaryState.None;
					interactionButton.gameObject.SetActive(value: false);
					if (!isWarningAnimPlayed)
					{
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: true);
						}
						isWarningAnimPlayed = true;
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Idle");
							warningAnimator.SetTrigger("Warning");
						}
						string text13 = LocalizationManager.GetTranslation("Required") + " (" + LocalizationManager.GetTranslation("Item_CrateName") + ")";
						interactionText.text = text13;
					}
				}
			}
			else
			{
				target.currentPrimaryState = PrimaryState.None;
				interactionButton.gameObject.SetActive(value: false);
				if (!isWarningAnimPlayed)
				{
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: true);
					}
					isWarningAnimPlayed = true;
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Idle");
						warningAnimator.SetTrigger("Warning");
					}
					string text14 = LocalizationManager.GetTranslation("Required") + " (" + LocalizationManager.GetTranslation("Item_CrateName") + ")";
					interactionText.text = text14;
				}
			}
		}
		if (_cachedSortingStation != null && gameManager.localEquipments != null)
		{
			if (t_Sack != null)
			{
				if (t_Sack.ItemCount > 0)
				{
					target.currentPrimaryState = PrimaryState.Place;
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: false);
					}
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Warning");
						warningAnimator.SetTrigger("Idle");
					}
				}
				else
				{
					target.currentPrimaryState = PrimaryState.None;
					interactionButton.gameObject.SetActive(value: false);
					if (!isWarningAnimPlayed)
					{
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: true);
						}
						isWarningAnimPlayed = true;
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Idle");
							warningAnimator.SetTrigger("Warning");
						}
						string text15 = LocalizationManager.GetTranslation("Required") + " (" + LocalizationManager.GetTranslation("Item_CrateName") + ")";
						interactionText.text = text15;
					}
				}
			}
			else
			{
				target.currentPrimaryState = PrimaryState.None;
				interactionButton.gameObject.SetActive(value: false);
				if (!isWarningAnimPlayed)
				{
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: true);
					}
					isWarningAnimPlayed = true;
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Idle");
						warningAnimator.SetTrigger("Warning");
					}
					string text16 = LocalizationManager.GetTranslation("Required") + " (" + LocalizationManager.GetTranslation("Item_CrateName") + ")";
					interactionText.text = text16;
				}
			}
		}
		if (_cachedSortingOutput != null && gameManager.localEquipments != null)
		{
			if (t_Sack != null)
			{
				if (t_Sack.ItemCount > 0)
				{
					target.currentPrimaryState = PrimaryState.Place;
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: false);
					}
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Warning");
						warningAnimator.SetTrigger("Idle");
					}
				}
				else
				{
					target.currentPrimaryState = PrimaryState.None;
					interactionButton.gameObject.SetActive(value: false);
					if (!isWarningAnimPlayed)
					{
						if (warningIcon != null)
						{
							warningIcon.SetActive(value: true);
						}
						isWarningAnimPlayed = true;
						if (warningAnimator != null)
						{
							warningAnimator.ResetTrigger("Idle");
							warningAnimator.SetTrigger("Warning");
						}
						string text17 = LocalizationManager.GetTranslation("Required") + " (" + LocalizationManager.GetTranslation("Item_CrateName") + ")";
						interactionText.text = text17;
					}
				}
			}
			else
			{
				target.currentPrimaryState = PrimaryState.Interact;
			}
		}
		T_DeliveryPointInteractable cachedDeliveryPoint = _cachedDeliveryPoint;
		if (cachedDeliveryPoint != null)
		{
			switch (cachedDeliveryPoint.CurrentState)
			{
			case DeliveryInteractionState.NoContract:
				target.currentPrimaryState = PrimaryState.None;
				interactionButton.gameObject.SetActive(value: false);
				if (!isWarningAnimPlayed)
				{
					if (warningIcon != null)
					{
						warningIcon.SetActive(value: true);
					}
					isWarningAnimPlayed = true;
					if (warningAnimator != null)
					{
						warningAnimator.ResetTrigger("Idle");
						warningAnimator.SetTrigger("Warning");
					}
					interactionText.text = LocalizationManager.GetTranslation("Notification_ContractRequired");
				}
				return;
			case DeliveryInteractionState.ContractExistsNoDelivery:
				target.currentPrimaryState = PrimaryState.Interact;
				target.primaryMode = InteractionMode.Press;
				if (warningIcon != null)
				{
					warningIcon.SetActive(value: false);
				}
				interactionButton.gameObject.SetActive(value: true);
				interactionText.text = LocalizationManager.GetTranslation("DeliveryPoint_SelectContract");
				return;
			case DeliveryInteractionState.DeliveryExistsNoItems:
				target.currentPrimaryState = PrimaryState.Interact;
				target.primaryMode = InteractionMode.Press;
				if (warningIcon != null)
				{
					warningIcon.SetActive(value: false);
				}
				interactionButton.gameObject.SetActive(value: true);
				interactionText.text = LocalizationManager.GetTranslation("DeliveryPoint_SendBack");
				return;
			case DeliveryInteractionState.DeliveryExistsHasItems:
			{
				target.currentPrimaryState = PrimaryState.Interact;
				target.primaryMode = InteractionMode.Hold;
				if (warningIcon != null)
				{
					warningIcon.SetActive(value: false);
				}
				interactionButton.gameObject.SetActive(value: true);
				string translation3 = LocalizationManager.GetTranslation(InteractionMode.Hold);
				string translation4 = LocalizationManager.GetTranslation("DeliveryPoint_CompleteDelivery");
				interactionText.text = "(" + translation3 + ") " + translation4;
				return;
			}
			}
		}
		if (target.primaryMode != InteractionMode.Press && target.primaryMode != InteractionMode.None)
		{
			string text18 = LocalizationManager.GetTranslation(target.primaryMode);
			if (string.IsNullOrEmpty(text18))
			{
				text18 = $"Enum_InteractionMode_{target.primaryMode}";
			}
			text3 = text3 + "(" + text18 + ") ";
		}
		if (target.currentPrimaryState != PrimaryState.None)
		{
			string text19 = LocalizationManager.GetTranslation(target.currentPrimaryState);
			if (string.IsNullOrEmpty(text19))
			{
				text19 = $"Enum_PrimaryState_{target.currentPrimaryState}";
			}
			text3 = text3 + text19 + " - ";
			LocalizationManager.GetTranslation(InteractionMode.Press);
			string text20 = LocalizationManager.GetTranslation(text2);
			if (string.IsNullOrEmpty(text20))
			{
				text20 = "NL/ " + text2;
			}
			text3 += text20;
			interactionText.text = text3;
			if (warningIcon != null)
			{
				warningIcon.SetActive(value: false);
			}
			if (target.currentPrimaryState == PrimaryState.OnlyName)
			{
				interactionButton.gameObject.SetActive(value: false);
				string translation5 = LocalizationManager.GetTranslation(text2);
				if (string.IsNullOrEmpty(translation5))
				{
					interactionText.text = "NL/" + text2;
				}
				else
				{
					interactionText.text = translation5;
				}
			}
		}
		if (!(secondInteractionPrompt != null))
		{
			return;
		}
		if (target.enableSecondary && target.currentSecondaryState != SecondaryState.None)
		{
			secondInteractionPrompt.SetActive(value: true);
			string text21 = "";
			if (target.secondaryMode != InteractionMode.Press && target.secondaryMode != InteractionMode.None)
			{
				string translation6 = LocalizationManager.GetTranslation(target.secondaryMode);
				text21 = text21 + "(" + translation6 + ") ";
			}
			string text22 = LocalizationManager.GetTranslation(target.currentSecondaryState);
			if (string.IsNullOrEmpty(text22))
			{
				text22 = target.currentSecondaryState.ToString();
			}
			text21 += text22;
			secondInteractionText.text = text21;
		}
		else
		{
			secondInteractionPrompt.SetActive(value: false);
		}
	}

	private void CacheTargetComponents(Interactable target)
	{
		GameObject targetObj = target.targetObj;
		_cachedItem = target.GetComponent<T_Item>();
		_cachedBuildingObj = target.GetComponent<BuildingObject>();
		if (_cachedBuildingObj == null && targetObj != null)
		{
			_cachedBuildingObj = targetObj.GetComponent<BuildingObject>();
		}
		if (_cachedBuildingObj == null)
		{
			_cachedBuildingObj = target.GetComponentInParent<BuildingObject>();
		}
		_cachedTruck = ((targetObj != null) ? targetObj.GetComponent<T_Truck>() : null);
		if (_cachedTruck == null)
		{
			_cachedTruck = target.GetComponent<T_Truck>();
		}
		_cachedPallet = ((targetObj != null) ? targetObj.GetComponent<T_Pallet>() : null);
		if (_cachedPallet == null)
		{
			_cachedPallet = target.GetComponent<T_Pallet>();
		}
		_cachedMachine = ((targetObj != null) ? targetObj.GetComponent<T_Machine>() : null);
		_cachedSortingStation = ((targetObj != null) ? targetObj.GetComponent<T_SortingStation>() : null);
		if (_cachedSortingStation == null)
		{
			_cachedSortingStation = target.GetComponent<T_SortingStation>();
		}
		_cachedSortingOutput = ((targetObj != null) ? targetObj.GetComponent<T_SortingOutput>() : null);
		if (_cachedSortingOutput == null)
		{
			_cachedSortingOutput = target.GetComponent<T_SortingOutput>();
		}
		_cachedDeliveryPoint = ((targetObj != null) ? targetObj.GetComponent<T_DeliveryPointInteractable>() : null);
		if (_cachedDeliveryPoint == null)
		{
			_cachedDeliveryPoint = target.GetComponent<T_DeliveryPointInteractable>();
		}
		_cachedContainerSack = null;
		if (_cachedTruck == null)
		{
			_cachedContainerSack = ((targetObj != null) ? targetObj.GetComponent<T_Sack>() : null);
			if (_cachedContainerSack == null)
			{
				_cachedContainerSack = target.GetComponent<T_Sack>();
			}
		}
	}

	private void RestoreHammerOverride()
	{
		if (_hammerOverrideTarget != null)
		{
			_hammerOverrideTarget.primaryMode = _originalPrimaryMode;
			_hammerOverrideTarget.secondaryMode = _originalSecondaryMode;
			_hammerOverrideTarget.enableSecondary = _originalEnableSecondary;
			_hammerOverrideTarget.currentPrimaryState = _originalPrimaryState;
			_hammerOverrideTarget.currentSecondaryState = _originalSecondaryState;
			_hammerOverrideTarget = null;
		}
	}

	private bool ShouldBlockHammerInfo()
	{
		bool num = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
		bool flag = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
		return num || flag;
	}

	private string GetItemNameFromId(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return "";
		}
		if (ItemSOManager.Instance == null)
		{
			return "";
		}
		T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(itemId);
		if (itemSOById == null)
		{
			return "";
		}
		return LocalizationManager.GetTranslation(itemSOById.Name);
	}
}
