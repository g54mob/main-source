using System.Collections;
using DV.CabControls;
using DV.Customization.Gadgets;
using DV.Customization.Gadgets.Implementations;
using DV.InventorySystem;
using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;

namespace DV
{
	public class LabelMakerController : GenericGadgetSpawner
	{
		private const string EDIT_REMOVE_KEY = "interaction/edit_remove";

		private GadgetBase lastPlacedLabel;

		private VRTK_InteractableObject_DV interactableObject;

		private int equippedSlot = -1;

		protected override void OnInitialize()
		{
			base.OnInitialize();
			LayerMask layerMask = LayerMask.GetMask("Interactable", "World_Item");
			context.SetupCustomRaycasting(layerMask, null, RaycastScanHandler, RaycastUseHandler);
		}

		private GadgetBase RaycastUseHandler(RaycastHitDV hit, Vector3 previewposition, Quaternion previewrotation)
		{
			ItemBase componentInParent = hit.collider.GetComponentInParent<ItemBase>();
			if ((bool)componentInParent)
			{
				LabelableItem component = componentInParent.GetComponent<LabelableItem>();
				if ((bool)component && component.ValidTarget)
				{
					PrepareForPopupShow();
					component.ShowPopup(OnLabelableItemPopupClosed);
					return null;
				}
			}
			TextGadget componentInParent2 = hit.collider.GetComponentInParent<TextGadget>();
			if ((bool)componentInParent2)
			{
				PrepareForPopupShow();
				componentInParent2.ShowPopup(useExistingText: true, removeButton: true, base.InteractionOrigin, OnGadgetPopupClosed);
			}
			return null;
		}

		private void OnGadgetPopupClosed(bool ok, string text)
		{
			AfterPopupClosed();
		}

		private void OnLabelableItemPopupClosed(PopupResult result)
		{
			AfterPopupClosed();
		}

		private bool RaycastScanHandler(RaycastHitDV hit, out GadgetBase customGadget, out Vector3 previewposition, out Quaternion previewrotation, out Color previewcolor)
		{
			ItemBase componentInParent = hit.collider.GetComponentInParent<ItemBase>();
			if ((bool)componentInParent)
			{
				LabelableItem component = componentInParent.GetComponent<LabelableItem>();
				if ((bool)component && component.ValidTarget)
				{
					customGadget = component.ReferenceGadget;
					previewposition = component.LabelRoot.transform.position;
					previewrotation = component.LabelRoot.transform.rotation;
					previewcolor = (component.LabelRoot.activeInHierarchy ? GadgetSystemUtility.COLOR_HIGHLIGHT_EDIT : GadgetSystemUtility.COLOR_HIGHLIGHT_GOOD);
					TrainCar trainCar = TrainCar.Resolve(component.LabelRoot);
					if ((bool)trainCar)
					{
						previewposition += trainCar.GetNextInteriorPositionOffset();
					}
					if (component.LabelRoot.activeInHierarchy)
					{
						GadgetInteractor.ShowInteractionTextLMB("interaction/edit_remove");
					}
					return true;
				}
			}
			TextGadget componentInParent2 = hit.collider.GetComponentInParent<TextGadget>();
			if ((bool)componentInParent2)
			{
				GadgetBase gadgetBase = (customGadget = componentInParent2.GetComponent<GadgetBase>());
				previewposition = gadgetBase.transform.position;
				previewrotation = gadgetBase.transform.rotation;
				previewcolor = GadgetSystemUtility.COLOR_HIGHLIGHT_EDIT;
				TrainCar trainCar2 = TrainCar.Resolve(componentInParent2.gameObject);
				if ((bool)trainCar2)
				{
					previewposition += trainCar2.GetNextInteriorPositionOffset();
				}
				GadgetInteractor.ShowInteractionTextLMB("interaction/edit_remove");
				return true;
			}
			customGadget = null;
			previewposition = Vector3.zero;
			previewrotation = Quaternion.identity;
			previewcolor = Color.black;
			return false;
		}

		private void PrepareForPopupShow()
		{
			if (VRManager.IsVREnabled())
			{
				interactableObject = GetComponent<VRTK_InteractableObject_DV>();
				equippedSlot = SingletonBehaviour<Inventory>.Instance.GetEquipSlotForItem(base.gameObject);
				if (equippedSlot >= 0)
				{
					interactableObject.ForceStopAllInteractions_Public();
					base.gameObject.SetActive(value: false);
				}
			}
		}

		private void AfterPopupClosed()
		{
			if (VRManager.IsVREnabled() && equippedSlot >= 0 && (bool)interactableObject)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedGrab());
			}
		}

		private IEnumerator DelayedGrab()
		{
			yield return new WaitForEndOfFrame();
			base.gameObject.SetActive(value: true);
			yield return null;
			SingletonBehaviour<Inventory>.Instance.EquipItem(base.gameObject, equippedSlot);
		}

		protected override void OnGadgetPlaced(GadgetBase gadget)
		{
			TextGadget componentInChildren = gadget.GetComponentInChildren<TextGadget>();
			if (componentInChildren == null)
			{
				Debug.LogWarning("LabelMakerController: TextGadget component not found on " + gadget.name + ", this is unexpected.", this);
				return;
			}
			lastPlacedLabel = gadget;
			PrepareForPopupShow();
			componentInChildren.ShowPopup(useExistingText: false, removeButton: false, base.InteractionOrigin, PopupClosedHandler);
		}

		private void PopupClosedHandler(bool ok, string text)
		{
			if (!ok || string.IsNullOrEmpty(text))
			{
				DestroyOnGadgetUnlink component = lastPlacedLabel.GetComponent<DestroyOnGadgetUnlink>();
				if ((bool)component)
				{
					component.Disable();
				}
				lastPlacedLabel.ForceRemove();
				Object.Destroy(lastPlacedLabel.GadgetItem.gameObject);
			}
			if (VRManager.IsVREnabled())
			{
				AfterPopupClosed();
			}
		}
	}
}
