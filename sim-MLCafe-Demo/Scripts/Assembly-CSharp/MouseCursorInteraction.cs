using System.Collections.Generic;
using System.Linq;
using MLCN_Localization;
using UnityEngine;
using UnityEngine.Events;

public class MouseCursorInteraction : MonoBehaviour
{
	[SerializeField]
	private UIContentAnimator crosshairAnimator;

	private MouseInteractionComponent lastComponent;

	private InteractionDisplayComponent currentInteractionDisplayComponent;

	private List<InteractionDisplayComponent> interactionDisplays = new List<InteractionDisplayComponent>();

	private static MouseCursorInteraction instance;

	private GameObject lastCasted;

	private List<Outline> registeredOutlineComponents = new List<Outline>();

	public static UnityEvent OnClearCasted = new UnityEvent();

	private bool hideAllControls;

	private bool hideCrosshair;

	private bool hideAllInfo;

	private bool isActivated = true;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		if (!ControlIconManager.IsValid())
		{
			ControlIconManager.Validate();
		}
	}

	public static bool IsLookingAtObject(GameObject gameObject)
	{
		return instance.lastCasted == gameObject;
	}

	public static bool IsAnyObjectInFocus()
	{
		return instance.lastCasted != null;
	}

	public static bool HasObjectInFocusComponent<T>()
	{
		if (!(instance.lastCasted != null))
		{
			return false;
		}
		return instance.lastCasted.GetComponent<T>() != null;
	}

	public static void RegisterOutline(Outline outline)
	{
		if (!(instance == null) && !instance.registeredOutlineComponents.Contains(outline))
		{
			instance.registeredOutlineComponents.Add(outline);
		}
	}

	public static void UnregisterOutline(Outline outline)
	{
		if (!(instance == null) && instance.registeredOutlineComponents.Contains(outline))
		{
			instance.registeredOutlineComponents.Remove(outline);
		}
	}

	public static bool IsOutlineRegistered(Outline outline)
	{
		if (instance == null)
		{
			return false;
		}
		return instance.registeredOutlineComponents.Contains(outline);
	}

	public static void SetAllInfo(bool hideAll)
	{
		instance.hideAllInfo = hideAll;
	}

	public static bool AreControlsHidden()
	{
		return instance.hideAllControls;
	}

	private void Update()
	{
		if (!isActivated)
		{
			return;
		}
		if (TransitionManager.IsTransitioning())
		{
			PopupMessageManager.HideAll();
			ControlIconManager.HideAll();
			return;
		}
		UpdateCursorState();
		if (hideAllInfo)
		{
			PopupMessageManager.HideAll();
			ControlIconManager.HideAll();
			if (registeredOutlineComponents.Any((Outline x) => x.enabled))
			{
				HideAllOutlines();
			}
			return;
		}
		GameObject hitObject = RayCaster.GetHitObject(GlobalReferences.GetCharacterController().GetCastLength(), RayCaster.GetDefaultMask());
		if (!hideCrosshair)
		{
			UpdateCrosshair(hitObject);
		}
		if (hideAllControls)
		{
			ControlIconManager.HideAllForced();
		}
		if (hitObject == null && lastCasted != null)
		{
			OnClearCasted.Invoke();
		}
		lastCasted = hitObject;
		CheckMouseInteractionComponent(hitObject);
	}

	public static void Deactivate()
	{
		PopupMessageManager.HideAll();
		ControlIconManager.HideAll();
		instance.UpdateCrosshair(null);
		if (instance.registeredOutlineComponents.Any((Outline x) => x.enabled))
		{
			HideAllOutlines();
		}
		instance.isActivated = false;
	}

	public static void Activate()
	{
		instance.isActivated = true;
	}

	public static void UpdateCursorState()
	{
		switch (GameStateManager.GetCurrentCharacterState())
		{
		case GameStateManager.CharacterState.CharacterMode:
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			break;
		case GameStateManager.CharacterState.MenuOpen:
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			break;
		case GameStateManager.CharacterState.DisableInput:
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			break;
		}
	}

	private void CheckMouseInteractionComponent(GameObject casted)
	{
		if (casted == null || (casted != null && casted.GetComponent<InteractionDisplayComponent>() == null && casted.GetComponent<ItemSocket>() == null) || (casted.GetComponent<ItemSocket>() != null && !casted.GetComponent<ItemSocket>().IsHoldingItem()))
		{
			if (ControlIconManager.IsShowingControls())
			{
				ControlIconManager.HideAll();
			}
			foreach (InteractionDisplayComponent interactionDisplay in interactionDisplays)
			{
				if (interactionDisplay == null)
				{
					if (PopupMessageManager.GetInfoPopUp().IsVisible())
					{
						PopupMessageManager.GetInfoPopUp().HideForce();
					}
				}
				else
				{
					interactionDisplay.HideInfo();
					interactionDisplay.HideOutline();
				}
			}
			interactionDisplays.Clear();
			currentInteractionDisplayComponent = null;
			PopupMessageManager.HideInfoPopups();
			return;
		}
		InteractionDisplayComponent component = casted.GetComponent<InteractionDisplayComponent>();
		currentInteractionDisplayComponent = component;
		if (currentInteractionDisplayComponent == null && casted.GetComponent<ItemSocket>() != null && casted.GetComponent<ItemSocket>().IsHoldingItem())
		{
			currentInteractionDisplayComponent = casted.GetComponent<ItemSocket>().GetItemComponent().GetComponent<InteractionDisplayComponent>();
		}
		foreach (InteractionDisplayComponent interactionDisplay2 in interactionDisplays)
		{
			interactionDisplay2.HideOutline();
			if (currentInteractionDisplayComponent == null)
			{
				interactionDisplay2.HideInfo();
			}
		}
		interactionDisplays.Clear();
		if (currentInteractionDisplayComponent == null)
		{
			if (casted.GetComponent<ItemSocket>() == null || !casted.GetComponent<ItemSocket>().IsHoldingItem())
			{
				return;
			}
			currentInteractionDisplayComponent = casted.GetComponent<ItemSocket>().GetItemComponent().GetComponent<InteractionDisplayComponent>();
			if (currentInteractionDisplayComponent == null)
			{
				return;
			}
		}
		currentInteractionDisplayComponent.ShowInfo();
		if (!hideAllControls)
		{
			currentInteractionDisplayComponent.ShowControls();
		}
		if (!interactionDisplays.Contains(currentInteractionDisplayComponent))
		{
			interactionDisplays.Add(currentInteractionDisplayComponent);
		}
	}

	public static void HideAllOutlines()
	{
		foreach (Outline registeredOutlineComponent in instance.registeredOutlineComponents)
		{
			registeredOutlineComponent.enabled = false;
		}
	}

	private void UpdateOutline(GameObject casted, bool checkChildren = false)
	{
		MouseInteractionComponent mouseInteractionComponent = (checkChildren ? casted.GetComponentInChildren<MouseInteractionComponent>() : casted.GetComponent<MouseInteractionComponent>());
		if (mouseInteractionComponent != null)
		{
			if (lastComponent != null && lastComponent.name != casted.name)
			{
				lastComponent.HideOutline();
				lastComponent = null;
			}
			lastComponent = mouseInteractionComponent;
			if (lastComponent != null)
			{
				lastComponent.ShowOutline();
			}
		}
		else
		{
			ItemSocket component = casted.GetComponent<ItemSocket>();
			if (component != null && component.useSocketInteraction)
			{
				if (component.IsHoldingItem())
				{
					UpdateOutline(component.GetItemComponent().gameObject, checkChildren: true);
				}
				return;
			}
			if (lastComponent != null)
			{
				lastComponent.HideOutline();
				lastComponent = null;
			}
		}
		registeredOutlineComponents.ForEach(delegate(Outline x)
		{
			if (x != null && lastComponent != null && x != lastComponent.GetComponent<Outline>())
			{
				x.enabled = false;
			}
		});
	}

	private void UpdateCrosshair(GameObject casted)
	{
		if (casted == null)
		{
			crosshairAnimator.OnReverseRuntime();
		}
		else if ((bool)casted && lastCasted != casted)
		{
			if (casted.GetComponent<InteractableComponent>() != null && casted.GetComponent<InteractableComponent>().IsInteractable())
			{
				crosshairAnimator.OnPlayRuntime();
			}
			else if (casted.GetComponent<InteractableComponent>() == null)
			{
				crosshairAnimator.OnPlayRuntime();
			}
		}
		else if (casted != null && casted.GetComponent<InteractableComponent>() != null && !casted.GetComponent<InteractableComponent>().IsInteractable())
		{
			crosshairAnimator.OnReverseRuntime();
		}
		else if (casted == null && lastCasted != null)
		{
			crosshairAnimator.OnReverseRuntime();
		}
	}

	private void CheckPopupInfoUpdates(GameObject casted)
	{
		if (casted != null && PopupMessageManager.GetInfoPopUp().IsVisible())
		{
			ItemComponent component = casted.GetComponent<ItemComponent>();
			if (component == null)
			{
				return;
			}
			if (component.item.tag != null && component.item.tag.anomalyFlags > 0)
			{
				MouseInteractionComponent component2 = component.GetComponent<MouseInteractionComponent>();
				string durationAmount = "";
				if (component2 != null)
				{
					durationAmount = (component2.showDurationWhenAvailable ? component2.GetFormattedDuration() : "");
				}
				PopupMessageManager.GetInfoPopUp().ShowProductInfo(component.GetInfo().GetLocalizedName(), component.item.tag.GetFormattedLocalizedTags(), component.useLimitedAmount ? (component.item.amount + "/" + component.item.maxAmount) : "", durationAmount);
			}
			else
			{
				PopupMessageManager.GetInfoPopUp().UpdateMessage(component.GetInfo().GetLocalizedName());
			}
		}
		if (casted == null && PopupMessageManager.GetInfoPopUp().IsVisible())
		{
			PopupMessageManager.GetInfoPopUp().Hide();
		}
	}

	private bool CheckForCastedObject(GameObject casted)
	{
		if (casted == null)
		{
			if (lastComponent != null)
			{
				lastComponent.HideOutline();
				lastComponent = null;
			}
			HideInteractionControl();
			HideRemoveObjectControl();
			PopupMessageManager.GetInfoPopUp().HideMessage();
			return true;
		}
		return false;
	}

	private bool CheckForItemSocketInteraction(GameObject castedObject)
	{
		_ = GlobalReferences.GetCharacterController().socket;
		if (castedObject != null)
		{
			HideInteractionControl();
			HideRemoveObjectControl();
		}
		ItemSocket component = castedObject.GetComponent<ItemSocket>();
		if (component == null)
		{
			return false;
		}
		if (!component.useSocketInteraction)
		{
			return false;
		}
		if (!component.IsHoldingItem())
		{
			return false;
		}
		return CheckForItem(component.GetItemComponent().gameObject);
	}

	private bool CheckBetweenTwoInteractables(GameObject castedObject)
	{
		if (!GlobalReferences.GetCharacterController().socket.IsHoldingItem())
		{
			return false;
		}
		ItemSocket socket = GlobalReferences.GetCharacterController().socket;
		if (castedObject != null)
		{
			HideInteractionControl();
			HideRemoveObjectControl();
		}
		if (castedObject.GetComponent<CustomerCore>() != null)
		{
			if (socket.GetItemComponent().GetComponent<ProductComponent>() == null)
			{
				ShowInteractionControl();
			}
			else
			{
				ShowInteractionControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_give", LocalizationDataTable.Tables.UI));
			}
			return true;
		}
		DeliveryPackage component = castedObject.GetComponent<DeliveryPackage>();
		if (component != null)
		{
			if (!component.IsFull())
			{
				ShowInteractionControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_place", LocalizationDataTable.Tables.UI));
			}
			else
			{
				HideInteractionControl();
			}
			return true;
		}
		CoffeeMixer component2 = castedObject.GetComponent<CoffeeMixer>();
		if (component2 != null)
		{
			if (component2.NeedsItem(socket.GetItemComponent().item) && socket.GetItemComponent().IsToolType())
			{
				ShowInteractionControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_use", LocalizationDataTable.Tables.UI));
			}
			if (component2.NeedsItem(socket.GetItemComponent().item) && !socket.GetItemComponent().IsToolType())
			{
				ShowInteractionControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_add", LocalizationDataTable.Tables.UI));
			}
			return true;
		}
		ItemInfo.ItemType itemType = socket.GetItemComponent().GetInfo().itemType;
		ItemComponent component3 = castedObject.GetComponent<ItemComponent>();
		if (component3 != null)
		{
			if (itemType == ItemInfo.ItemType.Tool)
			{
				ShowInteractionControl();
				PopupMessageManager.GetInfoPopUp().ShowProductInfo(component3.GetInfo().GetLocalizedName(), component3.item.tag.GetFormattedLocalizedTags(), component3.useLimitedAmount ? (component3.item.amount + "/" + component3.item.maxAmount) : "");
			}
			return true;
		}
		DirtComponent component4 = castedObject.GetComponent<DirtComponent>();
		if (component4 != null)
		{
			if (component4.IsNeededItem(socket.GetItemComponent().item))
			{
				ShowInteractionControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_clean", LocalizationDataTable.Tables.UI));
			}
			return true;
		}
		return true;
	}

	private bool CheckForSmogh(GameObject casted)
	{
		if (casted.GetComponent<EntitySmoghComponent>() != null)
		{
			ShowInteractionControl();
			return true;
		}
		return false;
	}

	private bool CheckForServiceCounter(GameObject casted)
	{
		ServiceCounterComponent component = casted.GetComponent<ServiceCounterComponent>();
		if (component != null)
		{
			string localizedString = LocalizationManager.GetLocalizedString("ui_popup_interaction_servicecounter_takecoins", LocalizationDataTable.Tables.UI);
			if (component.HasCoinsOnCounter())
			{
				ShowInteractionControl(localizedString);
			}
			return true;
		}
		return false;
	}

	private bool CheckForCustomer(GameObject casted)
	{
		if (casted.GetComponent<CustomerCore>() != null)
		{
			ShowInteractionControl();
			return true;
		}
		return false;
	}

	private bool CheckForDish(GameObject casted)
	{
		CupComponent component = casted.GetComponent<CupComponent>();
		if (component != null)
		{
			ItemComponent component2 = component.GetComponent<ItemComponent>();
			string text = InventorySystem.GetItemLibrary().itemInfos[component2.item.id].GetLocalizedName();
			if (!component.IsUseable())
			{
				text = "<color=red>" + LocalizationManager.GetLocalizedString("ui_popup_status_dirty", LocalizationDataTable.Tables.UI) + "</color>" + text;
			}
			PopupMessageManager.GetInfoPopUp().ShowProductInfo(text, component2.item.tag.GetFormattedTags(), component2.useLimitedAmount ? (component2.item.amount + "/" + component2.item.maxAmount) : "");
			if (casted.GetComponent<RemovableInstance>() == null)
			{
				ShowInteractionControl();
			}
			else
			{
				ShowRemoveObjectControl();
			}
			return true;
		}
		PopupMessageManager.GetInfoPopUp().HideMessage();
		return false;
	}

	private bool CheckForProduct(GameObject casted)
	{
		ProductComponent component = casted.GetComponent<ProductComponent>();
		if (component != null)
		{
			if (component.IsHoldingProduct())
			{
				Item item = component.GetComponent<ItemComponent>().item;
				string productName = component.GetProductName(byFlavour: true);
				string amount = ((item.maxAmount > 1) ? (item.amount + "/" + item.maxAmount) : "");
				PopupMessageManager.GetInfoPopUp().ShowProductInfo(productName, component.GetProductTagsFormatted(), amount);
				return true;
			}
			PopupMessageManager.GetInfoPopUp().HideProductInfo();
		}
		return false;
	}

	private bool CheckForItem(GameObject casted)
	{
		if (casted.GetComponent<ItemComponent>() != null)
		{
			ItemComponent component = casted.GetComponent<ItemComponent>();
			string localizedName = InventorySystem.GetItemLibrary().itemInfos[component.item.id].GetLocalizedName();
			MouseInteractionComponent component2 = component.GetComponent<MouseInteractionComponent>();
			if (component.item.tag != null && component.item.tag.anomalyFlags > 0)
			{
				string durationAmount = "";
				if (component2 != null)
				{
					durationAmount = (component2.showDurationWhenAvailable ? component2.GetFormattedDuration() : "");
				}
				PopupMessageManager.GetInfoPopUp().ShowProductInfo(localizedName, component.item.tag.GetFormattedLocalizedTags(), component.useLimitedAmount ? (component.item.amount + "/" + component.item.maxAmount) : "", durationAmount);
			}
			else
			{
				PopupMessageManager.GetInfoPopUp().ShowMessage(localizedName);
			}
			if (component2 != null && component2.overrideInteractionInfo)
			{
				string text = "";
				switch (component2.displayInfo.controlType)
				{
				case InteractionDisplayInfo.ControlType.LeftMouseClick:
					ShowInteractionControl(LocalizationManager.GetLocalizedString(component2.displayInfo.msg, LocalizationDataTable.Tables.UI));
					break;
				case InteractionDisplayInfo.ControlType.RightMouseClick:
					if (casted.GetComponent<RemovableInstance>() != null)
					{
						ShowRemoveObjectControl();
						break;
					}
					text = LocalizationManager.GetLocalizedString(component2.displayInfo.overrideRightClick, LocalizationDataTable.Tables.UI);
					ShowRightClickInteractionControl(text);
					break;
				case InteractionDisplayInfo.ControlType.LeftAndRight:
				{
					string localizedString = LocalizationManager.GetLocalizedString(component2.displayInfo.msg, LocalizationDataTable.Tables.UI);
					text = LocalizationManager.GetLocalizedString(component2.displayInfo.overrideRightClick, LocalizationDataTable.Tables.UI);
					ShowInteractionControl(localizedString);
					if (casted.GetComponent<RemovableInstance>() != null)
					{
						ShowRemoveObjectControl();
					}
					else
					{
						ShowRightClickInteractionControl(text);
					}
					break;
				}
				}
				return true;
			}
			if (casted.GetComponent<RemovableInstance>() == null)
			{
				ShowInteractionControl();
			}
			else
			{
				ShowRemoveObjectControl();
			}
			return true;
		}
		PopupMessageManager.GetInfoPopUp().HideMessage();
		return false;
	}

	public static void ShowInteractionControl(string control = "")
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			if (control == "")
			{
				control = LocalizationManager.GetLocalizedString("ui_popup_interaction_interact", LocalizationDataTable.Tables.UI);
			}
			ControlIconManager.GetLeftClickControl().ShowControl(control);
		}
	}

	public static void HideInteractionControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetLeftClickControl().HideControl();
		}
	}

	public static void ShowRightClickInteractionControl(string control = "")
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			if (control == "")
			{
				control = LocalizationManager.GetLocalizedString("ui_popup_interaction_interact", LocalizationDataTable.Tables.UI);
			}
			ControlIconManager.GetRightClickControl().ShowControl(LocalizationManager.GetLocalizedString(control, LocalizationDataTable.Tables.UI));
		}
	}

	public static void ShowPlaceControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetLeftClickControl().ShowControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_place", LocalizationDataTable.Tables.UI));
		}
	}

	public static void HidePlaceControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetLeftClickControl().HideControl();
		}
	}

	public static void ShowRemoveObjectControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetRightClickControl().ShowControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_remove", LocalizationDataTable.Tables.UI));
		}
	}

	public static void HideRemoveObjectControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetRightClickControl().HideControl();
		}
	}

	public static void ShowRotateObjectControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetScrollControl().ShowControl(LocalizationManager.GetLocalizedString("ui_popup_interaction_rotate", LocalizationDataTable.Tables.UI));
		}
	}

	public static void HideRotateObjectControl()
	{
		if (!(instance == null) && !instance.hideAllControls)
		{
			ControlIconManager.GetScrollControl().HideControl();
		}
	}

	public static bool IsValidated()
	{
		return instance != null;
	}
}
