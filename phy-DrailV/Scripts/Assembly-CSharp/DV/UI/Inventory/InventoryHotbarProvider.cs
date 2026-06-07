using System.Collections;
using DV.CabControls;
using DV.Common;
using DV.Interaction;
using DV.InventorySystem;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class InventoryHotbarProvider : AHotbarInventoryProvider
	{
		[NullCheck]
		public AInventoryProvider inventoryProvider;

		[NullCheck]
		public AInventoryUIController inventoryUI;

		private InteractionInput input;

		private CustomFirstPersonController fpsController;

		private Grabber grabber;

		private GrabberStashingHandler stashingHandler;

		private int scrollDirection;

		public override bool IsGameInitialized => inventoryProvider.IsGameInitialized;

		public override DV.InventorySystem.Inventory Inventory => inventoryProvider.Inventory;

		public override bool IsBigInventoryOpen => inventoryUI.IsOpen;

		public override bool IsTimePaused => SingletonBehaviour<AppUtil>.Instance.IsTimePaused;

		public override bool IsHotbarAllowed
		{
			get
			{
				if (!IsGameInitialized)
				{
					return false;
				}
				if (!PlayerCameraSwitcher.IsInFirstPerson || inventoryUI.IsOpen)
				{
					return false;
				}
				if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance && SingletonBehaviour<PlayerCameraSwitcher>.Instance.requestedView != PlayerCameraSwitcher.CameraView.FirstPerson)
				{
					return false;
				}
				if (grabber == null)
				{
					return false;
				}
				if (!GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.Hotbar))
				{
					return false;
				}
				if (!(grabber.CurrentItemHeld == null))
				{
					return CanAddToInventory(grabber.CurrentItemHeld.gameObject);
				}
				return true;
			}
		}

		public override bool IsHotbarButtonHeld => input.HotbarAccessPressed;

		public override int? SlotKey => input.SlotKey;

		public override int MouseScroll => input.MouseScroll * scrollDirection;

		private IEnumerator Start()
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.ScrollDownMeansRight, OnScrollDirectionChanged);
			OnScrollDirectionChanged();
			inventoryUI.SlotClicked += base.HotbarSelectionChanged_Fire;
			while (PlayerManager.PlayerTransform == null)
			{
				yield return null;
			}
			input = new InteractionInput();
			fpsController = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
			grabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
			stashingHandler = PlayerManager.PlayerTransform.GetComponentInChildren<GrabberStashingHandler>();
		}

		private void OnDestroy()
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.ScrollDownMeansRight, OnScrollDirectionChanged);
		}

		private void OnScrollDirectionChanged()
		{
			scrollDirection = ((GamePreferences.Get<int>(Preferences.ScrollDownMeansRight) == 1) ? 1 : (-1));
		}

		public override bool CanAddToInventory(GameObject item)
		{
			if (item == null || item.GetComponent<ItemBase>() == null)
			{
				return false;
			}
			return base.CanAddToInventory(item);
		}

		public override Vector2 GetMouseAxis()
		{
			return input.GetMouseAxis();
		}

		public override void RequestSlowMouse(bool slow)
		{
			if (slow)
			{
				fpsController.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Crawl);
				SingletonBehaviour<ScreenspaceMouse>.Instance.RequestOverride(this, on: false, 1);
			}
			else
			{
				fpsController.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Crawl);
				fpsController.m_MouseLook.RemoveRequest(this);
				SingletonBehaviour<ScreenspaceMouse>.Instance.RemoveRequest(this);
			}
		}

		public override void OnSlotChanged(int slot)
		{
			inventoryUI.SetSelectedSlot(slot);
		}

		public override void StashToggle(int slot)
		{
			stashingHandler.StashToggle(slot);
		}

		public override string GetLocalizedNameForItem(IInventoryItemSpec item)
		{
			if (item is InventoryItemSpec inventoryItemSpec)
			{
				return inventoryItemSpec.LocalizedName;
			}
			Debug.LogError($"Unexpected item {item}", this);
			return "[UNKNOWN]";
		}
	}
}
