using DV.CabControls;
using DV.InventorySystem;
using DV.JObjectExtstensions;
using DV.Localization;
using DV.UI;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Items
{
	public class ItemContainer : AItemContainer
	{
		[SerializeField]
		private ItemType allowedItemTypes;

		private const string CONTAINER_ID_SAVE_KEY = "ContainerId";

		private const InventoryActionType VALID_INVENTORY_ACTION_TYPE = InventoryActionType.Add | InventoryActionType.Move | InventoryActionType.Swap | InventoryActionType.Purge | InventoryActionType.Equip | InventoryActionType.Unequip;

		private ItemSaveData itemSaveData;

		private bool ignoreStorageManipulation;

		[SerializeField]
		private Animation openCloseAnimation;

		[SerializeField]
		private string animationNameOpen = "ItemContainerLidOpen";

		[SerializeField]
		private AudioClip openSound;

		[SerializeField]
		private AudioClip closeSound;

		public override string ContainerNameLocalized { get; protected set; }

		public override bool DirectInteractionAllowed => true;

		protected override string ContainerName { get; set; }

		protected virtual bool AddSoundAllowed => true;

		public ItemBase ItemBase { get; private set; }

		protected virtual void Start()
		{
			ItemBase = GetComponent<ItemBase>();
			if (DirectInteractionAllowed)
			{
				ItemBase.Used += ToggleContainerAccess;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				Clear();
				SetupListeners(on: false);
			}
		}

		public override bool ValidItem(GameObject item)
		{
			ItemBase itemBase = ((item != null && item != base.gameObject) ? item.GetComponent<ItemBase>() : null);
			ItemType itemType = ((itemBase != null) ? itemBase.SpecItem.itemType : ItemType.None);
			return (allowedItemTypes & itemType) != 0;
		}

		protected override bool InitializeSpecific()
		{
			itemSaveData = GetComponent<ItemSaveData>();
			if (itemSaveData == null)
			{
				Debug.LogError("ItemContainer: No ItemSaveData component found. Item container ID cannot be saved or loaded.", this);
				return false;
			}
			InventoryItemSpec component = GetComponent<InventoryItemSpec>();
			ContainerName = component.ItemPrefabName;
			ContainerNameLocalized = LocalizationAPI.L(component.LocalizationKey);
			SetupListeners(on: true);
			return true;
		}

		public override bool AddItem(GameObject item, int index)
		{
			if (!base.AddItem(item, index))
			{
				return false;
			}
			ItemBase component = item.GetComponent<ItemBase>();
			component.InContainer = this;
			SingletonBehaviour<StorageController>.Instance.AddItemToStorageItemContainers(component);
			SetupItemListeners(component, on: true);
			if (AddSoundAllowed && SingletonBehaviour<InventoryViewBase>.Instance != null)
			{
				SingletonBehaviour<InventoryViewBase>.Instance.RequestAddSound();
			}
			ItemReparentingBase component2 = component.GetComponent<ItemReparentingBase>();
			if (component2 != null)
			{
				component2.ParentItemExternal(WorldMover.OriginShiftParent, null);
			}
			return true;
		}

		public override bool RemoveItem(int index, bool activateItem, bool dropItem)
		{
			if (!index.IsInRange(0, base.Capacity - 1))
			{
				Debug.LogError(string.Format("{0}: Index {1} is out of range for container with capacity {2}. Ignoring remove operation.", "ItemContainer", index, base.Capacity));
				return false;
			}
			GameObject gameObject = items[index];
			ItemBase itemBase = ((gameObject != null) ? gameObject.GetComponent<ItemBase>() : null);
			if (!base.RemoveItem(index, activateItem, dropItem))
			{
				return false;
			}
			if (!ignoreStorageManipulation)
			{
				if (itemBase.BelongsToPlayer())
				{
					SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorage(itemBase);
				}
				else
				{
					SingletonBehaviour<StorageController>.Instance.RemoveItemFromStorageItemContainers(itemBase);
				}
			}
			if (itemBase != null)
			{
				itemBase.InContainer = null;
				if (dropItem)
				{
					ReparentItemOnRemove(itemBase);
				}
				SetupItemListeners(itemBase, on: false);
			}
			return true;
		}

		private void ReparentItemOnRemove(ItemBase item)
		{
			TrainCar trainCar;
			if (ItemBase.IsBoundToPlayer(includeInStashedContainer: true))
			{
				trainCar = PlayerManager.Car;
			}
			else
			{
				AItemContainer item2 = base.NestedIn.lastNest;
				trainCar = TrainCar.Resolve((item2 != null) ? item2.transform : base.transform);
			}
			Rigidbody receiveForcesFrom;
			Transform transform;
			if (trainCar != null)
			{
				receiveForcesFrom = trainCar.rb;
				transform = trainCar.interior;
			}
			else
			{
				transform = WorldMover.OriginShiftParent;
				receiveForcesFrom = null;
			}
			ItemReparentingBase component = item.GetComponent<ItemReparentingBase>();
			if (component != null)
			{
				component.ParentItemExternal(transform, receiveForcesFrom);
				return;
			}
			Debug.LogError("ItemContainer: Item " + item.name + " doesn't have ItemReparentingBase component. Reparenting won't be done properly. This should not happen.", item);
			item.transform.SetParent(transform, worldPositionStays: true);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePauseRequested += OnGamePaused;
				itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
				itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
				itemSaveData.AfterContainerSaveDataLoaded += PostLoadIdGenerationFallback;
				return;
			}
			itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
			itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
			itemSaveData.AfterContainerSaveDataLoaded -= PostLoadIdGenerationFallback;
			SingletonBehaviour<AppUtil>.Instance.GamePauseRequested -= OnGamePaused;
			if (DirectInteractionAllowed && ItemBase != null)
			{
				ItemBase.Used -= ToggleContainerAccess;
			}
		}

		private void PostLoadIdGenerationFallback(JObject _)
		{
			if (string.IsNullOrWhiteSpace(base.ContainerId) || registry.GetItemContainer(base.ContainerId, nullIsValid: true) != this)
			{
				string text = GenerateId();
				AssignIdAndRegister(text);
				Debug.LogWarning("Container " + base.name + " wasn't registered during standard registration. Registering with newly generated ID: " + text + ". This is expected for starting items only.", this);
			}
		}

		public override void ToggleContainerAccess()
		{
			if (!(SingletonBehaviour<StartingItemsController>.Instance != null) || SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
			{
				AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer = ((activeContainer == this) ? null : this);
				if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryToggleState(CanvasController.ElementType.Inventory);
				}
			}
		}

		private void OnGamePaused()
		{
			if (!(openCloseAnimation == null) && openCloseAnimation.isPlaying)
			{
				AnimationState animationState = openCloseAnimation[animationNameOpen];
				animationState.time = 0f;
				animationState.speed = -1f;
				openCloseAnimation.Play(animationNameOpen);
			}
		}

		private void SetupItemListeners(ItemBase item, bool on)
		{
			if (!(item == null))
			{
				item.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
				item.ItemInventoryStateChanged -= OnItemInventoryStateChanged;
				if (on)
				{
					item.AboutToBeDestroyed += OnItemAboutToBeDestroyed;
					item.ItemInventoryStateChanged += OnItemInventoryStateChanged;
				}
			}
		}

		private void OnItemAboutToBeDestroyed(ItemBase item)
		{
			RemoveItem(item.gameObject, activateItem: false, dropItem: false);
		}

		private void OnItemInventoryStateChanged(ItemBase item, InventoryActionType actionType, InventoryItemState itemState)
		{
			if ((InventoryActionType.Add | InventoryActionType.Move | InventoryActionType.Swap | InventoryActionType.Purge | InventoryActionType.Equip | InventoryActionType.Unequip).HasAnyIntFlag(actionType) && (itemState == InventoryItemState.Disabled || itemState == InventoryItemState.Enabled))
			{
				ignoreStorageManipulation = true;
				RemoveItem(item.gameObject, activateItem: false, dropItem: false);
				ignoreStorageManipulation = false;
			}
		}

		private void OnItemSaveDataLoaded(JObject data)
		{
			string text = data.GetString("ContainerId");
			if (!string.IsNullOrEmpty(text))
			{
				AssignIdAndRegister(text);
			}
		}

		private JObject OnItemSaveDataRequested(JObject data)
		{
			data.SetString("ContainerId", base.ContainerId);
			return data;
		}

		public override void Clear()
		{
			for (int i = 0; i < base.Capacity; i++)
			{
				GameObject gameObject = items[i];
				if (!(gameObject == null))
				{
					ItemBase component = gameObject.GetComponent<ItemBase>();
					if (component.BelongsToPlayer())
					{
						RemoveItem(i, activateItem: false, dropItem: false);
						SingletonBehaviour<StorageController>.Instance.AddItemToLostAndFound(component);
					}
					else
					{
						RemoveItem(i, activateItem: true, dropItem: true);
					}
				}
			}
		}

		public override void PlayInteractionEffects(bool open)
		{
			bool flag = !base.gameObject.activeInHierarchy;
			if (openCloseAnimation != null)
			{
				AnimationState animationState = openCloseAnimation[animationNameOpen];
				if (!open)
				{
					if (flag)
					{
						animationState.time = 0f;
					}
					else if (!openCloseAnimation.isPlaying)
					{
						animationState.time = animationState.length;
					}
					animationState.speed = -1f;
				}
				else
				{
					if (flag)
					{
						animationState.time = 1f;
					}
					else if (!openCloseAnimation.isPlaying)
					{
						animationState.time = 0f;
					}
					animationState.speed = 1f;
				}
				openCloseAnimation.Play(animationNameOpen);
			}
			AudioClip audioClip = (open ? openSound : closeSound);
			if (!(audioClip == null))
			{
				if (flag)
				{
					audioClip.Play2D(1f, playDuringPause: true);
				}
				else
				{
					audioClip.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform).source.ignoreListenerPause = true;
				}
			}
		}
	}
}
