using System;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls;
using DV.InventorySystem;
using DV.Items;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

namespace DV.Game.Tutorial.ItemTracker
{
	public class ItemTracker : IDisposable
	{
		public enum TargetZoneType
		{
			None = 0,
			Container = 1,
			Backpack = 2,
			Hotbar = 3,
			Hands = 4,
			World = 5
		}

		public struct Result
		{
			public static readonly Result Empty = new Result
			{
				SuggestedTarget = SuggestedTarget.None,
				Index = -1,
				TargetItem = null,
				SurroundingContainer = null,
				WorldTransform = null,
				UITransform = null
			};

			public SuggestedTarget SuggestedTarget;

			public int Index;

			public ItemBase OriginalItem;

			public ItemBase TargetItem;

			public AItemContainer SurroundingContainer;

			public Transform WorldTransform;

			public RectTransform UITransform;

			public bool IsDropSuggestion;

			public override bool Equals(object obj)
			{
				if (obj is Result result)
				{
					if (OriginalItem != result.OriginalItem)
					{
						return false;
					}
					if (SuggestedTarget != result.SuggestedTarget)
					{
						return false;
					}
					if (WorldTransform != result.WorldTransform)
					{
						return false;
					}
					if (UITransform != result.UITransform)
					{
						return false;
					}
					if (TargetItem != result.TargetItem)
					{
						return false;
					}
					if (SurroundingContainer != result.SurroundingContainer)
					{
						return false;
					}
					if (Index != result.Index)
					{
						return false;
					}
					if (IsDropSuggestion != result.IsDropSuggestion)
					{
						return false;
					}
					return true;
				}
				return false;
			}

			public int ComputeDistance(Vector3 playerPosition, bool inventoryOpen, AItemContainer activeContainer)
			{
				int num = 0;
				if (IsDropSuggestion)
				{
					return int.MinValue;
				}
				if ((activeContainer != SurroundingContainer && SuggestedTarget != SuggestedTarget.Hands && SuggestedTarget != SuggestedTarget.Hotbar) || SuggestedTarget == SuggestedTarget.LevelUp)
				{
					num += 200;
				}
				if (!inventoryOpen && SuggestedTarget.IsShownInInventoryUI())
				{
					num += 100;
				}
				if (inventoryOpen && SuggestedTarget.IsShownInWorld())
				{
					num += 100;
				}
				if (playerPosition != Vector3.negativeInfinity && !TargetItem.IsBoundToPlayer() && (bool)WorldTransform)
				{
					num += Mathf.Clamp(Mathf.RoundToInt(Vector3.Distance(playerPosition, WorldTransform.position) / 0.5f), 0, 100);
				}
				return num + Mathf.Max(0, Index);
			}
		}

		private List<Result> currentResults = new List<Result>();

		private GameObject[] itemObjects;

		private ItemBase[] items;

		private Transform worldDropHint;

		private bool eventsHooked;

		private bool lastInventoryState;

		private bool lastHotbarState;

		private const int MAX_CONTAINER_STACK_CACHE = 16;

		private static readonly AItemContainer[] NestedContainersCache = new AItemContainer[16];

		private static readonly ItemBase[] NestedItemsCache = new ItemBase[16];

		public Result BestResult { get; private set; }

		public bool ContainerDropMode { get; private set; }

		public AItemContainer ContainerExclusion { get; private set; }

		public ItemBase ContainerItem { get; private set; }

		public TargetZoneType TargetZone { get; private set; }

		public event Action<Result> OnBestResultChanged;

		public event Action<ItemTracker> OnDispose;

		public ItemTracker(GameObject gameObject, AItemContainer containerExclusion = null, TargetZoneType zone = TargetZoneType.None, Transform worldDropHint = null)
		{
			itemObjects = ((!gameObject) ? Array.Empty<GameObject>() : new GameObject[1] { gameObject });
			items = ((!gameObject) ? Array.Empty<ItemBase>() : new ItemBase[1] { gameObject.GetComponent<ItemBase>() });
			ContainerExclusion = containerExclusion;
			ContainerItem = (ContainerExclusion ? ContainerExclusion.GetComponent<ItemBase>() : null);
			ContainerDropMode = zone == TargetZoneType.Container && (bool)containerExclusion;
			TargetZone = zone;
			this.worldDropHint = worldDropHint;
			Update();
			HookEvents();
		}

		public ItemTracker(IEnumerable<GameObject> gameObjects, AItemContainer containerExclusion = null, TargetZoneType zone = TargetZoneType.None, Transform worldDropHint = null)
		{
			itemObjects = gameObjects.ToArray();
			items = new ItemBase[itemObjects.Length];
			ContainerExclusion = containerExclusion;
			ContainerItem = (ContainerExclusion ? ContainerExclusion.GetComponent<ItemBase>() : null);
			ContainerDropMode = zone == TargetZoneType.Container && (bool)containerExclusion;
			TargetZone = zone;
			this.worldDropHint = worldDropHint;
			for (int i = 0; i < itemObjects.Length; i++)
			{
				items[i] = (itemObjects[i] ? itemObjects[i].GetComponent<ItemBase>() : null);
			}
			Update();
			HookEvents();
		}

		public ItemTracker(ItemBase itemBase, AItemContainer containerExclusion = null, TargetZoneType zone = TargetZoneType.None, Transform worldDropHint = null)
		{
			itemObjects = ((!itemBase) ? Array.Empty<GameObject>() : new GameObject[1] { itemBase.gameObject });
			items = ((!itemBase) ? Array.Empty<ItemBase>() : new ItemBase[1] { itemBase });
			ContainerExclusion = containerExclusion;
			ContainerItem = (ContainerExclusion ? ContainerExclusion.GetComponent<ItemBase>() : null);
			ContainerDropMode = zone == TargetZoneType.Container && (bool)containerExclusion;
			TargetZone = zone;
			this.worldDropHint = worldDropHint;
			Update();
			HookEvents();
		}

		public ItemTracker(IEnumerable<ItemBase> itemBases, AItemContainer containerExclusion = null, TargetZoneType zone = TargetZoneType.None, Transform worldDropHint = null)
		{
			items = itemBases.ToArray();
			itemObjects = new GameObject[items.Length];
			ContainerExclusion = containerExclusion;
			ContainerItem = (ContainerExclusion ? ContainerExclusion.GetComponent<ItemBase>() : null);
			ContainerDropMode = zone == TargetZoneType.Container && (bool)containerExclusion;
			TargetZone = zone;
			this.worldDropHint = worldDropHint;
			for (int i = 0; i < items.Length; i++)
			{
				itemObjects[i] = items[i]?.gameObject;
			}
			Update();
			HookEvents();
		}

		private void HookEvents()
		{
			if (!eventsHooked)
			{
				SingletonBehaviour<TutorialHelper>.Instance.RegisterItemTracker(this);
				eventsHooked = true;
			}
		}

		private void UnhookEvents()
		{
			if (eventsHooked)
			{
				SingletonBehaviour<TutorialHelper>.Instance.UnregisterItemTracker(this);
				eventsHooked = false;
			}
		}

		public void Update()
		{
			currentResults.Clear();
			AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
			bool flag = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory);
			bool flag2 = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Hotbar);
			for (int i = 0; i < items.Length; i++)
			{
				ItemBase itemBase = items[i];
				if ((bool)itemBase && (!ContainerExclusion || !(itemBase.InContainer == ContainerExclusion)) && !IsItemInZone(itemBase, TargetZone, ContainerExclusion))
				{
					Result suggestionFor = GetSuggestionFor(itemBase, TargetZone, activeContainer, ContainerExclusion, worldDropHint, checkDropping: true);
					if (suggestionFor.SuggestedTarget != SuggestedTarget.None)
					{
						suggestionFor.OriginalItem = itemBase;
						currentResults.Add(suggestionFor);
					}
				}
			}
			Camera main = Camera.main;
			Vector3 playerPosition = (main ? main.transform.position : Vector3.negativeInfinity);
			Result bestResult;
			if (currentResults.Count > 0)
			{
				bestResult = currentResults[0];
				int num = bestResult.ComputeDistance(playerPosition, flag, activeContainer);
				for (int j = 1; j < currentResults.Count; j++)
				{
					Result result = currentResults[j];
					int num2 = result.ComputeDistance(playerPosition, flag, activeContainer);
					if (num2 < num)
					{
						num = num2;
						bestResult = result;
					}
				}
			}
			else
			{
				bestResult = Result.Empty;
			}
			if (!bestResult.Equals(BestResult) || flag != lastInventoryState || flag2 != lastHotbarState)
			{
				BestResult = bestResult;
				this.OnBestResultChanged?.Invoke(BestResult);
			}
			lastInventoryState = flag;
			lastHotbarState = flag2;
		}

		public void Dispose()
		{
			this.OnDispose?.Invoke(this);
			UnhookEvents();
		}

		public static bool IsItemInZone(ItemBase item, TargetZoneType zone, AItemContainer container = null)
		{
			if (!item)
			{
				return false;
			}
			switch (zone)
			{
			case TargetZoneType.None:
				return false;
			case TargetZoneType.Container:
				if (container != null)
				{
					return item.IsWithin(container);
				}
				return false;
			case TargetZoneType.Backpack:
			{
				int num = SingletonBehaviour<Inventory>.Instance.IndexOf(item.gameObject);
				if (num >= 12)
				{
					return num < 36;
				}
				return false;
			}
			case TargetZoneType.Hotbar:
			{
				int num2 = SingletonBehaviour<Inventory>.Instance.IndexOf(item.gameObject);
				if (num2 >= 0)
				{
					return num2 <= 11;
				}
				return false;
			}
			case TargetZoneType.Hands:
				if (!(SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems[0] == item))
				{
					return SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems[1] == item;
				}
				return true;
			case TargetZoneType.World:
				return !item.IsBoundToPlayer();
			default:
				throw new NotImplementedException($"Zone {zone} is not yet implemented.");
			}
		}

		public static int FindReplacementSlotInHands(ItemBase item, AItemContainer activeContainer)
		{
			AItemContainer topmostContainer = item.TopmostContainer;
			ItemBase itemBase = (topmostContainer ? topmostContainer.GetComponent<ItemBase>() : null);
			bool flag = VRManager.IsVREnabled();
			for (int num = (flag ? 1 : 0); num >= 0; num--)
			{
				ItemBase itemBase2 = SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems[(!flag) ? 1 : num];
				if (!itemBase2 || itemBase2 != itemBase)
				{
					return num;
				}
			}
			return -1;
		}

		public static bool FindFreeSlotInZone(TargetZoneType zone, out int index, AItemContainer container = null)
		{
			switch (zone)
			{
			case TargetZoneType.None:
				index = -1;
				return true;
			case TargetZoneType.Container:
				index = (container ? container.GetFirstFreeSlot() : (-1));
				return index >= 0;
			case TargetZoneType.Backpack:
				index = SingletonBehaviour<Inventory>.Instance.GetFirstFreeBackpackSlot() - 12;
				return index >= 0;
			case TargetZoneType.Hotbar:
				index = SingletonBehaviour<Inventory>.Instance.GetFirstFreeHotbarSlot();
				return index >= 0;
			case TargetZoneType.Hands:
				if (VRManager.IsVREnabled())
				{
					if (SingletonBehaviour<TutorialHelper>.Instance.GrabbedObjects[1] == null)
					{
						index = 1;
					}
					else if (SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems[0] == null)
					{
						index = 0;
					}
					else
					{
						index = -1;
					}
				}
				else
				{
					index = (SingletonBehaviour<TutorialHelper>.Instance.GrabbedObjectRightHand ? (-1) : 0);
				}
				return index >= 0;
			case TargetZoneType.World:
				index = -1;
				return true;
			default:
				throw new NotImplementedException($"Zone {zone} is not yet implemented.");
			}
		}

		private static (AItemContainer container, ItemBase item)[] CrawlNestedContainers(ItemBase item)
		{
			if (item != null && item.InContainer != null)
			{
				NestedContainersCache[0] = item.InContainer;
				NestedItemsCache[0] = item.InContainer.GetComponent<ItemBase>();
				int num = 1;
				AItemContainer item2 = item.InContainer.NestedIn.firstNest;
				while (item2 != null)
				{
					NestedContainersCache[num] = item2;
					NestedItemsCache[num] = item2.GetComponent<ItemBase>();
					item2 = item2.NestedIn.firstNest;
					num++;
					if (num >= 16)
					{
						Debug.LogError($"Container nesting for {item.name} exceeded the allocated cache of {16}, truncating, might produce unexpected results", item);
						break;
					}
				}
				(AItemContainer, ItemBase)[] array = ArrayPool<(AItemContainer, ItemBase)>.New(num);
				for (int i = 0; i < num; i++)
				{
					array[i].Item2 = NestedItemsCache[i];
					array[i].Item1 = NestedContainersCache[i];
				}
				return array;
			}
			return Array.Empty<(AItemContainer, ItemBase)>();
		}

		private static RectTransform FindInventorySlotOn(InventorySectionController controller, int index)
		{
			if (controller == null)
			{
				return null;
			}
			InventoryUIInteractionObserver component = controller.GetComponent<InventoryUIInteractionObserver>();
			if (index < 0 || index >= component.slotObservers.Count)
			{
				return null;
			}
			return component.slotObservers[index].element.transform as RectTransform;
		}

		private static bool IsDragged(InventoryUIController ui, ItemBase item, bool targetInWorld)
		{
			if (!item)
			{
				return false;
			}
			if (VRManager.IsVREnabled())
			{
				return SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems.Contains(item);
			}
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory) && !targetInWorld)
			{
				if (ui.draggedData != null && ui.draggedData.Spec != null)
				{
					return item == ui.draggedData.Spec.GetGameObject().GetComponent<ItemBase>();
				}
				return false;
			}
			if (ui.draggedData != null && ui.draggedData.Spec != null && item == ui.draggedData.Spec.GetGameObject().GetComponent<ItemBase>())
			{
				return true;
			}
			return SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems.Contains(item);
		}

		private static Result GetDropSuggestionFor(ItemBase item, TargetZoneType targetZone, InventoryUIController ui, AItemContainer activeContainer, AItemContainer targetContainer, Transform worldMarker)
		{
			if (IsItemInZone(item, targetZone, targetContainer))
			{
				return new Result
				{
					SuggestedTarget = SuggestedTarget.None,
					Index = -1,
					TargetItem = null,
					SurroundingContainer = targetContainer,
					WorldTransform = null,
					UITransform = null,
					IsDropSuggestion = true
				};
			}
			bool flag = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory);
			bool flag2 = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Hotbar);
			ItemBase itemBase = (targetContainer ? targetContainer.GetComponent<ItemBase>() : null);
			int index;
			if (targetZone == TargetZoneType.Container && itemBase != null && activeContainer != targetContainer)
			{
				if (!itemBase.IsBoundToPlayer() && !SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems.Contains(item))
				{
					targetZone = TargetZoneType.Hands;
				}
				else
				{
					int num = Array.IndexOf(SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems, itemBase);
					if (VRManager.IsVREnabled() && num >= 0 && activeContainer != targetContainer && !flag)
					{
						return new Result
						{
							SuggestedTarget = SuggestedTarget.Hands,
							TargetItem = itemBase,
							SurroundingContainer = null,
							WorldTransform = itemBase.transform,
							UITransform = null,
							Index = num,
							IsDropSuggestion = true
						};
					}
					Result suggestionFor = GetSuggestionFor(itemBase, targetZone, activeContainer, null, worldMarker, checkDropping: false);
					if (suggestionFor.SuggestedTarget != SuggestedTarget.None)
					{
						if ((bool)suggestionFor.WorldTransform && suggestionFor.SuggestedTarget == SuggestedTarget.World)
						{
							ItemContainerAccessPoint componentInChildren = itemBase.GetComponentInChildren<ItemContainerAccessPoint>();
							if ((bool)componentInChildren)
							{
								suggestionFor.WorldTransform = componentInChildren.transform;
							}
						}
						suggestionFor.IsDropSuggestion = true;
						return suggestionFor;
					}
				}
			}
			else if (targetZone == TargetZoneType.Container && activeContainer == targetContainer && FindFreeSlotInZone(TargetZoneType.Container, out index, targetContainer))
			{
				return new Result
				{
					SuggestedTarget = SuggestedTarget.ActiveContainer,
					TargetItem = null,
					SurroundingContainer = targetContainer,
					WorldTransform = null,
					UITransform = (flag ? FindInventorySlotOn(ui.itemContainerController, index) : null),
					Index = index,
					IsDropSuggestion = true
				};
			}
			switch (targetZone)
			{
			case TargetZoneType.World:
				return new Result
				{
					SuggestedTarget = SuggestedTarget.World,
					Index = -1,
					TargetItem = null,
					SurroundingContainer = null,
					WorldTransform = worldMarker,
					UITransform = null,
					IsDropSuggestion = true
				};
			case TargetZoneType.Hotbar:
			{
				if (FindFreeSlotInZone(TargetZoneType.Hotbar, out var index4))
				{
					return new Result
					{
						SuggestedTarget = SuggestedTarget.Hotbar,
						Index = index4,
						TargetItem = null,
						SurroundingContainer = null,
						WorldTransform = null,
						UITransform = (flag ? FindInventorySlotOn(ui.hotbarController, index4) : (SingletonBehaviour<HotbarController>.Instance.GetSlot(index4).transform as RectTransform)),
						IsDropSuggestion = true
					};
				}
				break;
			}
			case TargetZoneType.Backpack:
			{
				if (FindFreeSlotInZone(TargetZoneType.Backpack, out var index3))
				{
					return new Result
					{
						SuggestedTarget = SuggestedTarget.Backpack,
						Index = index3,
						TargetItem = null,
						SurroundingContainer = null,
						WorldTransform = null,
						UITransform = (flag ? FindInventorySlotOn(ui.backpackController, index3) : null),
						IsDropSuggestion = true
					};
				}
				break;
			}
			case TargetZoneType.Hands:
			{
				if (!FindFreeSlotInZone(TargetZoneType.Hands, out var index2))
				{
					index2 = FindReplacementSlotInHands(item, activeContainer);
				}
				if (index2 >= 0)
				{
					return new Result
					{
						SuggestedTarget = SuggestedTarget.Hands,
						Index = index2,
						TargetItem = null,
						SurroundingContainer = null,
						WorldTransform = null,
						UITransform = (flag ? FindInventorySlotOn(ui.handController, index2) : null),
						IsDropSuggestion = true
					};
				}
				if (FindFreeSlotInZone(TargetZoneType.Hotbar, out index2))
				{
					return new Result
					{
						SuggestedTarget = SuggestedTarget.Hotbar,
						Index = index2,
						TargetItem = null,
						SurroundingContainer = null,
						WorldTransform = null,
						UITransform = (flag ? FindInventorySlotOn(ui.hotbarController, index2) : (flag2 ? (SingletonBehaviour<HotbarController>.Instance.GetSlot(index2).transform as RectTransform) : null)),
						IsDropSuggestion = true
					};
				}
				break;
			}
			}
			return new Result
			{
				SuggestedTarget = SuggestedTarget.None,
				Index = -1,
				TargetItem = null,
				SurroundingContainer = null,
				WorldTransform = null,
				UITransform = null,
				IsDropSuggestion = true
			};
		}

		private static Result GetSuggestionFor(ItemBase item, TargetZoneType targetZone, AItemContainer activeContainer, AItemContainer targetContainer, Transform wordMarker, bool checkDropping)
		{
			bool flag = VRManager.IsVREnabled();
			bool flag2 = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory);
			bool flag3 = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Hotbar);
			ItemBase itemBase = (targetContainer ? targetContainer.GetComponent<ItemBase>() : null);
			bool targetInWorld = targetZone == TargetZoneType.World || (targetZone == TargetZoneType.Container && (bool)itemBase && !itemBase.IsBoundToPlayer());
			InventoryUIController componentInChildren = (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance as CanvasController).inventory.GetComponentInChildren<InventoryUIController>(includeInactive: true);
			if (checkDropping && targetZone != TargetZoneType.None && IsDragged(componentInChildren, item, targetInWorld))
			{
				Result dropSuggestionFor = GetDropSuggestionFor(item, targetZone, componentInChildren, activeContainer, targetContainer, wordMarker);
				dropSuggestionFor.IsDropSuggestion = true;
				return dropSuggestionFor;
			}
			ItemBase itemBase2 = item;
			if ((bool)activeContainer)
			{
				if (activeContainer == item.InContainer)
				{
					int index = activeContainer.IndexOf(itemBase2.gameObject);
					return new Result
					{
						Index = index,
						SuggestedTarget = SuggestedTarget.ActiveContainer,
						TargetItem = itemBase2,
						SurroundingContainer = item.InContainer,
						WorldTransform = null,
						UITransform = (flag2 ? FindInventorySlotOn(componentInChildren.itemContainerController, index) : null),
						IsDropSuggestion = false
					};
				}
				(AItemContainer, ItemBase)[] array = CrawlNestedContainers(item);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Item1 == activeContainer)
					{
						if (i > 0)
						{
							itemBase2 = array[i - 1].Item2;
						}
						int index2 = activeContainer.IndexOf(itemBase2.gameObject);
						return new Result
						{
							Index = index2,
							SuggestedTarget = SuggestedTarget.ActiveContainer,
							TargetItem = itemBase2,
							SurroundingContainer = itemBase2.InContainer,
							WorldTransform = null,
							UITransform = (flag2 ? FindInventorySlotOn(componentInChildren.itemContainerController, index2) : null),
							IsDropSuggestion = false
						};
					}
				}
				ItemBase itemBase3 = (item.TopmostContainer ? item.TopmostContainer.GetComponent<ItemBase>() : item);
				if (itemBase3.IsBoundToPlayer() && IsItemInZone(itemBase3, TargetZoneType.Backpack))
				{
					return new Result
					{
						Index = -1,
						TargetItem = itemBase3,
						SuggestedTarget = SuggestedTarget.LevelUp,
						SurroundingContainer = itemBase3?.InContainer,
						WorldTransform = null,
						UITransform = (flag2 ? (componentInChildren.titleHandler.BackpackAccessButton.transform as RectTransform) : null),
						IsDropSuggestion = false
					};
				}
			}
			AItemContainer surroundingContainer;
			if (itemBase2.InContainer != null)
			{
				itemBase2 = itemBase2.TopmostContainer.GetComponent<ItemBase>();
				surroundingContainer = itemBase2.InContainer;
			}
			else
			{
				surroundingContainer = null;
			}
			if (itemBase2.IsBoundToPlayer(includeInStashedContainer: true))
			{
				int num = Array.IndexOf(SingletonBehaviour<TutorialHelper>.Instance.GrabbedItems, itemBase2);
				if (num >= 0)
				{
					return new Result
					{
						Index = num,
						SuggestedTarget = SuggestedTarget.Hands,
						TargetItem = itemBase2,
						SurroundingContainer = surroundingContainer,
						UITransform = (flag2 ? FindInventorySlotOn(componentInChildren.handController, flag ? num : 0) : null),
						WorldTransform = itemBase2.transform,
						IsDropSuggestion = false
					};
				}
				int num2 = SingletonBehaviour<Inventory>.Instance.IndexOf(itemBase2.gameObject);
				if (num2.IsInRange(12, 35))
				{
					int index3 = num2 - 12;
					return new Result
					{
						Index = index3,
						SuggestedTarget = SuggestedTarget.Backpack,
						TargetItem = itemBase2,
						SurroundingContainer = surroundingContainer,
						UITransform = (flag2 ? FindInventorySlotOn(componentInChildren.backpackController, index3) : null),
						WorldTransform = null,
						IsDropSuggestion = false
					};
				}
				if (num2.IsInRange(0, 11))
				{
					int num3 = num2;
					RectTransform uITransform = (flag2 ? FindInventorySlotOn(componentInChildren.hotbarController, num3) : ((!flag3 || VRManager.IsVREnabled()) ? null : (SingletonBehaviour<HotbarController>.Instance.GetSlot(num3).transform as RectTransform)));
					return new Result
					{
						Index = num3,
						SuggestedTarget = SuggestedTarget.Hotbar,
						TargetItem = itemBase2,
						SurroundingContainer = surroundingContainer,
						UITransform = uITransform,
						WorldTransform = null,
						IsDropSuggestion = false
					};
				}
				if (num2.IsInRange(33, 35))
				{
					return new Result
					{
						Index = num2 - 33,
						SuggestedTarget = SuggestedTarget.Belt,
						TargetItem = itemBase2,
						SurroundingContainer = surroundingContainer,
						UITransform = null,
						WorldTransform = itemBase2.transform,
						IsDropSuggestion = false
					};
				}
				return new Result
				{
					Index = -1,
					SuggestedTarget = SuggestedTarget.None,
					TargetItem = null,
					SurroundingContainer = null,
					UITransform = null,
					WorldTransform = null,
					IsDropSuggestion = false
				};
			}
			bool flag4 = item.InContainer != null;
			Transform worldTransform;
			if (flag4)
			{
				ItemContainerAccessPoint componentInChildren2 = itemBase2.GetComponentInChildren<ItemContainerAccessPoint>();
				worldTransform = (componentInChildren2 ? componentInChildren2.transform : itemBase2.transform);
			}
			else
			{
				worldTransform = itemBase2.transform;
			}
			return new Result
			{
				Index = -1,
				SuggestedTarget = (flag4 ? SuggestedTarget.WorldContainer : SuggestedTarget.World),
				TargetItem = itemBase2,
				SurroundingContainer = surroundingContainer,
				UITransform = null,
				WorldTransform = worldTransform,
				IsDropSuggestion = false
			};
		}
	}
}
