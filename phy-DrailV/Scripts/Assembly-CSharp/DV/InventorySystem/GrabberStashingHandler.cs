using System;
using System.Collections;
using DV.CabControls;
using DV.Interaction;
using DV.Player;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public class GrabberStashingHandler : MonoBehaviour, ItemPositionController.IPositionProvider
	{
		private const float STASH_DURATION = 0.07f;

		private const float STASH_DISTANCE = 0.5f;

		private const int EQUIP_SLOT_INDEX = 0;

		public ItemPositionController itemPositionController;

		public AnimationCurve animationCurve;

		private Grabber grabber;

		private GrabberInteractionHandlerDV interactionHandler;

		private HotbarController hotbarController;

		private Inventory inventory;

		private Coroutine stashCoroutine;

		public Action onFinishCoroutine;

		private IPlayerRig playerRig;

		private float posLerpValue;

		public int Priority => 1;

		private void Awake()
		{
			grabber = GetComponent<Grabber>();
			interactionHandler = GetComponent<GrabberInteractionHandlerDV>();
		}

		private IEnumerator Start()
		{
			while (SingletonBehaviour<HotbarController>.Instance == null || !SingletonBehaviour<HotbarController>.Instance.LoadingFinished)
			{
				yield return null;
			}
			inventory = SingletonBehaviour<Inventory>.Instance;
			hotbarController = SingletonBehaviour<HotbarController>.Instance;
			playerRig = PlayerManager.PlayerTransform.GetComponentInChildren<IPlayerRig>();
			GameObject equippedItemAtSlot = inventory.GetEquippedItemAtSlot(0);
			if (equippedItemAtSlot != null)
			{
				int _ = inventory.IndexOf(equippedItemAtSlot);
				HandleEquipChange(equippedItemAtSlot, _, equipped: true, 0);
			}
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				itemPositionController.Remove(this);
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				grabber.GrabStarted += OnGrabStarted;
				grabber.GrabStopped += OnGrabStopped;
				inventory.InventoryStatusChanged += OnInventoryStatusChanged;
				inventory.ItemContainerRegistry.ActiveContainerItemDropped += OnContainerItemDropped;
				inventory.ItemContainerRegistry.MagazineItemDropped += OnContainerItemDropped;
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += InterruptAnimation;
				hotbarController.OpenChanged += InterruptAnimation;
				return;
			}
			if ((bool)inventory)
			{
				inventory.InventoryStatusChanged -= OnInventoryStatusChanged;
				inventory.ItemContainerRegistry.ActiveContainerItemDropped -= OnContainerItemDropped;
				inventory.ItemContainerRegistry.MagazineItemDropped -= OnContainerItemDropped;
			}
			if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= InterruptAnimation;
			}
			if ((bool)hotbarController)
			{
				hotbarController.OpenChanged -= InterruptAnimation;
			}
		}

		private void OnContainerItemDropped(GameObject item)
		{
			Transform droppedItemTransformValues = item.transform;
			SetDroppedItemTransformValues(droppedItemTransformValues);
		}

		private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState targetState, InventoryActionType targetActionType)
		{
			if (originActionType.HasAnyIntFlag(InventoryActionType.Equip))
			{
				HandleEquipChange(originState.item, originState.slotIndex, equipped: true, originState.equipSlot);
			}
			else if (originActionType.HasAnyIntFlag(InventoryActionType.Unequip))
			{
				HandleEquipChange(originState.item, originState.slotIndex, equipped: false, originState.equipSlot);
			}
			if (originActionType.HasAnyIntFlag(InventoryActionType.Drop))
			{
				Transform droppedItemTransformValues = originState.item.transform;
				SetDroppedItemTransformValues(droppedItemTransformValues);
			}
		}

		private void SetDroppedItemTransformValues(Transform itemTransform)
		{
			Transform attachPoint = playerRig.GetAttachPoint();
			GrabHandlerItem component = itemTransform.GetComponent<GrabHandlerItem>();
			Transform transform = ((component.forcedDropAnchor != null && component.forcedDropAnchor.gameObject.activeInHierarchy) ? component.forcedDropAnchor : attachPoint);
			Vector3 position;
			Quaternion rotation;
			if (!(component == null))
			{
				(position, rotation) = component.GetItemWorldAttachPositionAndRotation(transform);
			}
			else
			{
				Debug.LogError("GrabberStashingHandler: Item is missing GrabHandlerItem component. This should not happen.", this);
				position = transform.position;
				rotation = transform.rotation;
			}
			itemTransform.SetPositionAndRotation(position, rotation);
		}

		private void OnGrabStarted(AGrabHandler grabHandler)
		{
			if (grabHandler.IsItem)
			{
				InterruptAnimation();
				itemPositionController.Add(this);
				InventoryItemSpec component = grabHandler.GetComponent<InventoryItemSpec>();
				if ((bool)component)
				{
					inventory.EquipItem(component.gameObject, hotbarController.SelectedSlot, 0);
				}
			}
		}

		private void HandleEquipChange(GameObject item, int _, bool equipped, int __)
		{
			ItemBase itemBase = ((item != null) ? item.GetComponent<ItemBase>() : null);
			if (itemBase == null)
			{
				Debug.LogError("HandleEquipChange needs a valid itemBase reference.", this);
				return;
			}
			bool flag = itemBase.IsGrabbed();
			if (equipped)
			{
				if (!flag)
				{
					interactionHandler.RequestForceHold(item.GetComponent<AGrabHandler>());
				}
			}
			else if (flag)
			{
				itemBase.ForceEndInteraction();
			}
		}

		private void OnGrabStopped(AGrabHandler grabHandler)
		{
			if (grabHandler.IsItem)
			{
				InterruptAnimation();
				itemPositionController.Remove(this);
				if ((bool)grabHandler.GetComponent<InventoryItemSpec>())
				{
					inventory.UnequipItem(addToInventory: false, 0);
				}
			}
		}

		public void StashToggle(int slot)
		{
			bool flag = (bool)grabber.CurrentItemHeld && inventory.CanAddItem(grabber.CurrentItemHeld.gameObject);
			int num = inventory.IndexOf((grabber.CurrentItemHeld != null) ? grabber.CurrentItemHeld.gameObject : null);
			bool flag2 = hotbarController.HasStashedItem();
			if (slot != num && InventoryUtils.IsValidHotbarIndex(num) && flag && flag2)
			{
				Stash();
				onFinishCoroutine = (Action)Delegate.Combine(onFinishCoroutine, new Action(UnStash));
			}
			else if (flag)
			{
				Stash();
			}
			else if (flag2)
			{
				UnStash();
			}
		}

		public void Stash()
		{
			onFinishCoroutine = delegate
			{
				inventory.UnequipItem(addToInventory: true, 0);
			};
			stashCoroutine = StartCoroutine(StashAnimationCoroutine(direction: false));
		}

		public void UnStash()
		{
			int selectedSlot = hotbarController.SelectedSlot;
			GameObject gameObject = inventory.PeekItemAtSlot(selectedSlot, includeDropped: false);
			if (!(gameObject == null))
			{
				inventory.EquipItem(gameObject, selectedSlot, 0);
				AGrabHandler component = gameObject.GetComponent<AGrabHandler>();
				interactionHandler.RequestForceHold(component);
				onFinishCoroutine = null;
				stashCoroutine = StartCoroutine(StashAnimationCoroutine(direction: true));
			}
		}

		private void InterruptAnimation(ACanvasController<CanvasController.ElementType>.Element element)
		{
			if (element.Type.HasAnyFlag(CanvasController.ElementType.Blockers | CanvasController.ElementType.ExternalCamera))
			{
				InterruptAnimation();
			}
		}

		private void InterruptAnimation()
		{
			if (stashCoroutine != null)
			{
				StopCoroutine(stashCoroutine);
				FinishCoroutine();
			}
		}

		private IEnumerator StashAnimationCoroutine(bool direction)
		{
			if (interactionHandler.IsHoldingLocked)
			{
				yield break;
			}
			interactionHandler.LockHolding();
			float time = Time.time;
			while (Time.time - time < 0.07f)
			{
				float value = (Time.time - time) / 0.07f;
				value = Mathf.Clamp01(value);
				if (direction)
				{
					value = 1f - value;
				}
				value = animationCurve.Evaluate(value);
				posLerpValue = value;
				yield return null;
			}
			FinishCoroutine();
		}

		private void FinishCoroutine()
		{
			posLerpValue = 0f;
			interactionHandler.UnlockHolding();
			stashCoroutine = null;
			onFinishCoroutine?.Invoke();
			onFinishCoroutine = null;
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			return (pos: pos + rot * (Vector3.down * (posLerpValue * 0.5f)), rot: rot, overridePreviousPerc: 1f);
		}
	}
}
