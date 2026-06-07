using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.InventorySystem;
using DV.Items;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

namespace DV.Game.Tutorial.ItemTracker
{
	public class ItemPointer : IDisposable
	{
		private readonly ItemTracker tracker;

		private readonly bool trackerOwned;

		private bool wasMessageShown;

		private bool wasUIArrowShown;

		private string message;

		private bool hasMessage;

		private bool localizeMessage;

		private bool showHints;

		private ControlHint hintState;

		public ItemTracker Tracker => tracker;

		private void Construct(string message, bool showHints, bool localizeMessage)
		{
			tracker.OnBestResultChanged += OnResultChanged;
			tracker.OnDispose += OnTrackerDisposed;
			tracker.Update();
			this.message = message;
			hasMessage = !string.IsNullOrEmpty(message);
			this.showHints = showHints;
			this.localizeMessage = localizeMessage;
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += OnCanvasElementToggled;
			OnResultChanged(tracker.BestResult);
		}

		private void OnTrackerDisposed(ItemTracker tracker)
		{
			tracker.OnBestResultChanged -= OnResultChanged;
			tracker.OnDispose -= OnTrackerDisposed;
			Cleanup();
		}

		private void OnCanvasElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
		{
			if (element.Type == CanvasController.ElementType.Inventory || element.Type == CanvasController.ElementType.Hotbar)
			{
				tracker.Update();
			}
		}

		public ItemPointer(GameObject gameObject, AItemContainer containerExclusion, ItemTracker.TargetZoneType target, string message, bool localizeMessage = true, bool showHints = true, Transform worldHint = null)
		{
			tracker = new ItemTracker(gameObject, containerExclusion, target, worldHint);
			trackerOwned = true;
			Construct(message, showHints, localizeMessage);
		}

		public ItemPointer(IEnumerable<GameObject> gameObjects, AItemContainer containerExclusion, ItemTracker.TargetZoneType target, string message, bool localizeMessage = true, bool showHints = true, Transform worldHint = null)
		{
			tracker = new ItemTracker(gameObjects, containerExclusion, target, worldHint);
			trackerOwned = true;
			Construct(message, showHints, localizeMessage);
		}

		public ItemPointer(ItemBase itemBase, AItemContainer containerExclusion, ItemTracker.TargetZoneType target, string message, bool localizeMessage = true, bool showHints = true, Transform worldHint = null)
		{
			tracker = new ItemTracker(itemBase, containerExclusion, target, worldHint);
			trackerOwned = true;
			Construct(message, showHints, localizeMessage);
		}

		public ItemPointer(IEnumerable<ItemBase> itemBases, AItemContainer containerExclusion, ItemTracker.TargetZoneType target, string message, bool localizeMessage = true, bool showHints = true, Transform worldHint = null)
		{
			tracker = new ItemTracker(itemBases, containerExclusion, target, worldHint);
			trackerOwned = true;
			Construct(message, showHints, localizeMessage);
		}

		public ItemPointer(ItemTracker tracker, string message, bool localizeMessage = true, bool showHints = true)
		{
			this.tracker = tracker;
			trackerOwned = false;
			Construct(message, showHints, localizeMessage);
		}

		private void OnResultChanged(ItemTracker.Result result)
		{
			bool flag = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory);
			bool flag2 = (bool)result.TargetItem && (bool)result.TargetItem.GetComponent<AItemContainer>();
			ControlHint controlHint = ControlHint.None;
			bool flag3 = (bool)result.TargetItem && (bool)result.TargetItem.GetComponent<AItemContainer>();
			bool flag4 = flag3 && (bool)result.TargetItem.GetComponentInChildren<ItemContainerAccessPoint>();
			if (VRManager.IsVREnabled() && (!flag || InventoryViewVR.Instance.Input.InventoryButtonPressed) && tracker.TargetZone == ItemTracker.TargetZoneType.Hands && (result.SuggestedTarget == SuggestedTarget.Backpack || result.SuggestedTarget == SuggestedTarget.Hotbar) && result.TargetItem == result.OriginalItem)
			{
				controlHint = ControlHint.QuickSelectVR;
			}
			else if (result.SuggestedTarget == SuggestedTarget.Hotbar && !flag)
			{
				controlHint = ((!VRManager.IsVREnabled() && !result.IsDropSuggestion && tracker.TargetZone != ItemTracker.TargetZoneType.Backpack) ? ControlHint.OpenHotbar : ControlHint.OpenInventory);
			}
			else if (result.SuggestedTarget == SuggestedTarget.Backpack && !flag)
			{
				controlHint = ControlHint.OpenInventory;
			}
			else if (result.SuggestedTarget.IsShownInWorld() && flag && !result.UITransform && !VRManager.IsVREnabled())
			{
				InventoryUIController componentInChildren = (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance as CanvasController).inventory.GetComponentInChildren<InventoryUIController>(includeInactive: true);
				result.UITransform = componentInChildren.closeButton.GetComponent<RectTransform>();
				controlHint = ControlHint.CloseInventory;
			}
			else if (result.IsDropSuggestion && result.SuggestedTarget == SuggestedTarget.World)
			{
				CustomDropOntoHint customDropOntoHint = (flag3 ? result.TargetItem.GetComponent<CustomDropOntoHint>() : null);
				if ((bool)customDropOntoHint)
				{
					result.WorldTransform = customDropOntoHint.Target;
					controlHint = customDropOntoHint.Hint;
				}
				else if (flag3 && !flag4)
				{
					controlHint = ControlHint.GrabItem;
				}
				else if (VRManager.IsVREnabled() && flag3)
				{
					controlHint = ControlHint.OpenWorldContainer;
				}
				else if (!result.WorldTransform)
				{
					controlHint = ControlHint.DropItem;
				}
				else if (!VRManager.IsVREnabled() && flag4)
				{
					controlHint = ControlHint.ItemPlacement;
				}
			}
			else if (result.SuggestedTarget == SuggestedTarget.Hands && !flag && flag2 && result.OriginalItem != result.TargetItem)
			{
				controlHint = ControlHint.OpenHeldContainer;
			}
			else if (result.SuggestedTarget == SuggestedTarget.WorldContainer && VRManager.IsVREnabled())
			{
				controlHint = ControlHint.OpenWorldContainer;
			}
			if (!result.IsDropSuggestion && flag4 && (bool)result.WorldTransform && (bool)result.TargetItem && result.TargetItem.gameObject == result.WorldTransform.gameObject)
			{
				Transform transform = result.TargetItem.transform.Find("[left anchor]");
				if ((bool)transform)
				{
					result.WorldTransform = transform;
				}
				else
				{
					Transform transform2 = result.TargetItem.transform.Find("[right anchor]");
					if ((bool)transform2)
					{
						result.WorldTransform = transform2;
					}
				}
			}
			if (wasUIArrowShown)
			{
				SingletonBehaviour<UITutorialHighlighter>.Instance.Unhighlight();
				wasUIArrowShown = false;
			}
			if (hasMessage)
			{
				SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, result.WorldTransform, Vector3.zero, localizeMessage);
				wasMessageShown = true;
			}
			if ((bool)result.UITransform)
			{
				SingletonBehaviour<UITutorialHighlighter>.Instance.Highlight(result.UITransform);
				wasUIArrowShown = true;
			}
			if (controlHint != hintState && showHints)
			{
				SingletonBehaviour<TutorialHelper>.Instance.ShowControlHint(controlHint);
				hintState = controlHint;
			}
		}

		private void Cleanup()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (hintState != ControlHint.None)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideControlHint();
				}
				if (wasMessageShown)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				}
				if (wasUIArrowShown)
				{
					SingletonBehaviour<UITutorialHighlighter>.Instance.Unhighlight();
				}
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= OnCanvasElementToggled;
			}
		}

		public void Dispose()
		{
			Cleanup();
			tracker.OnBestResultChanged -= OnResultChanged;
			tracker.OnDispose -= OnTrackerDisposed;
			if (trackerOwned)
			{
				tracker.Dispose();
			}
		}
	}
}
