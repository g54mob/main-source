using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class GlobalKeybindingManager : MonoSingleton<GlobalKeybindingManager>, IObserver
	{
		private readonly List<(GameObject, Action)> escapeKeyActions = new List<(GameObject, Action)>();

		private bool blockEscapeKey;

		public bool SkipNextOrderKeyPress { get; set; }

		public void BlockEscapeKey(bool block)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalKeybindingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Escape key is now blocked: ");
				messageBuilder.AppendFormatted(block);
			}
			Log.Trace(messageBuilder);
			blockEscapeKey = block;
		}

		public void SubscribeToEscapeKey(Action action, GameObject gameObject)
		{
			bool isEnabled;
			if (escapeKeyActions.Count > 0 && escapeKeyActions.Contains((gameObject, action)))
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalKeybindingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Skipping Subscribing to escape key: ");
					messageBuilder.AppendFormatted(gameObject.name);
					messageBuilder.AppendLiteral(". Object already subscribed");
				}
				Log.Trace(messageBuilder);
			}
			else
			{
				escapeKeyActions.Insert(0, (gameObject, action));
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalKeybindingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Subscribing to escape key: ");
					messageBuilder.AppendFormatted(gameObject.name);
				}
				Log.Trace(messageBuilder);
			}
		}

		public void UnsubscribeFromEscapeKey(Action action, GameObject gameObject)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(42, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalKeybindingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Attempting Unsubscribing from escape key: ");
				messageBuilder.AppendFormatted(gameObject.name);
			}
			Log.Trace(messageBuilder);
			if (escapeKeyActions.Count > 0 && escapeKeyActions.Contains((gameObject, action)))
			{
				escapeKeyActions.Remove((gameObject, action));
				messageBuilder = new FVLogTraceInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalKeybindingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Unsubscribed from escape key: ");
					messageBuilder.AppendFormatted(gameObject.name);
				}
				Log.Trace(messageBuilder);
			}
		}

		private void OnEscapeKey()
		{
			if (blockEscapeKey)
			{
				return;
			}
			bool flag = false;
			using PooledHashSet<(GameObject, Action)> pooledHashSet = HashSetPool<(GameObject, Action)>.GetJanitor();
			foreach (var escapeKeyAction in escapeKeyActions)
			{
				if (!escapeKeyAction.Item1.activeSelf)
				{
					pooledHashSet.Add(escapeKeyAction);
					continue;
				}
				escapeKeyAction.Item2();
				flag = true;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalKeybindingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Executing escape key action: ");
					messageBuilder.AppendFormatted(escapeKeyAction.Item1.name);
				}
				Log.Trace(messageBuilder);
				break;
			}
			foreach (var item in pooledHashSet)
			{
				escapeKeyActions.Remove(item);
			}
			if (!flag && MonoSingleton<UIController>.IsInstantiated() && MonoSingleton<UIController>.Instance.InGameMenu != null)
			{
				MonoSingleton<UIController>.Instance.InGameMenu.SceneUIManager.ShowNewView("InGameMenuView");
			}
		}

		private void OnLeftControlEvent()
		{
			MonoSingleton<UIController>.Instance.ShowActionInfo(new List<string>
			{
				ActionInfoUtils.ScrollWheelLayer,
				ActionInfoUtils.ClickLayer
			}, overrideExisting: false);
		}

		private void OnLeftControlUpEvent()
		{
			MonoSingleton<UIController>.Instance.HideIfActiveActionInfo(new List<string>
			{
				ActionInfoUtils.ScrollWheelLayer,
				ActionInfoUtils.ClickLayer
			});
		}

		private void OnLeftShiftEvent()
		{
			MonoSingleton<UIController>.Instance.ShowActionInfo(new List<string> { ActionInfoUtils.CameraLockScrollWheelLayer }, overrideExisting: false);
		}

		private void OnLeftShiftUpEvent()
		{
			MonoSingleton<UIController>.Instance.HideIfActiveActionInfo(new List<string> { ActionInfoUtils.CameraLockScrollWheelLayer });
		}

		private void ToggleResourcePileForbid()
		{
			ToggleMultiSelectOfType((ResourcePileView pileView) => pileView.ResourcePileInstance.IsForbidden, delegate(ResourcePileView pileView, bool newValue)
			{
				pileView.ResourcePileInstance.IsForbidden = newValue;
			});
		}

		private void ToggleBuildingsAllowForbid()
		{
			bool valueToSet = false;
			bool valueChosen = false;
			ForSelectedOfType<SelectableObject, BaseBuildingInstance>(delegate(SelectableObject viewObj)
			{
				BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)viewObj.GetAsWorldObject();
				if (baseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
				{
					if (!valueChosen)
					{
						valueChosen = true;
						valueToSet = !baseBuildingInstance.IsForbidden;
					}
					baseBuildingInstance.IsForbidden = valueToSet;
				}
			});
		}

		private void SetResourcePileUrgentHaul()
		{
			ForSelectedOfType(delegate(ResourcePileView pileView)
			{
				pileView.ResourcePileInstance.IsUrgentHaul = true;
			});
		}

		private void SetChopping()
		{
			ForSelectedOfType(delegate(TreeView treeView)
			{
				treeView.GiveOrder(OrderType.Chopping);
			});
		}

		private void SetDeconstruct()
		{
			ForSelectedOfType<SelectableObject, BaseBuildingInstance>(delegate(SelectableObject viewObj)
			{
				BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)viewObj.GetAsWorldObject();
				if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished)
				{
					baseBuildingInstance.SetMarkedForDestruction(value: true);
				}
			});
		}

		private IEnumerator<TView> EnumerateSelectedOfType<TView>() where TView : SelectableObject
		{
			return EnumerateSelectedOfType<TView, WorldObject>();
		}

		private IEnumerator<TView> EnumerateSelectedOfType<TView, TInstance>() where TView : SelectableObject where TInstance : WorldObject
		{
			if (!MonoSingleton<SelectableObjectManager>.IsInstantiated())
			{
				yield break;
			}
			HashSet<SelectableObject> selectedObjects = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects;
			if (selectedObjects.Count == 0)
			{
				yield break;
			}
			List<SelectableObject> selectionCopy = ListPool<SelectableObject>.Get();
			selectionCopy.AddRange(selectedObjects);
			foreach (SelectableObject item in selectionCopy)
			{
				if (item is TView val)
				{
					WorldObject asWorldObject = val.GetAsWorldObject();
					if (asWorldObject != null && !asWorldObject.HasDisposed && asWorldObject is TInstance)
					{
						yield return val;
					}
				}
			}
			ListPool<SelectableObject>.Return(selectionCopy);
		}

		private void ToggleMultiSelectOfType<TView>(Func<TView, bool> boolFieldGetter, Action<TView, bool> boolFieldSetter) where TView : SelectableObject
		{
			ToggleMultiSelectOfType<TView, WorldObject>(boolFieldGetter, boolFieldSetter);
		}

		private void ToggleMultiSelectOfType<TView, TInstance>(Func<TView, bool> boolFieldGetter, Action<TView, bool> boolFieldSetter) where TView : SelectableObject where TInstance : WorldObject
		{
			IEnumerator<TView> enumerator = EnumerateSelectedOfType<TView, TInstance>();
			if (enumerator.MoveNext())
			{
				TView current = enumerator.Current;
				bool arg = !boolFieldGetter(current);
				do
				{
					boolFieldSetter(enumerator.Current, arg);
				}
				while (enumerator.MoveNext());
				MultiSelectPanelManager.RefreshData();
			}
		}

		private void ForSelectedOfType<TView>(Action<TView> operation) where TView : SelectableObject
		{
			ForSelectedOfType<TView, WorldObject>(operation);
		}

		private void ForSelectedOfType<TView, TInstance>(Action<TView> operation) where TView : SelectableObject where TInstance : WorldObject
		{
			IEnumerator<TView> enumerator = EnumerateSelectedOfType<TView, TInstance>();
			if (enumerator.MoveNext())
			{
				do
				{
					operation(enumerator.Current);
				}
				while (enumerator.MoveNext());
				MultiSelectPanelManager.RefreshData();
			}
		}

		private void Start()
		{
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Escape, OnEscapeKey, activeOnWorldMap: true, activeOnPhotoMode: true);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.LeftControl, OnLeftControlEvent);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToUpEvent(KeyInputEvent.LeftControl, OnLeftControlUpEvent);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.UrgentHaul, SetResourcePileUrgentHaul);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Deconstructing, SetDeconstruct);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Chopping, SetChopping);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToUpEvent(KeyInputEvent.LeftShift, OnLeftShiftUpEvent);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.LeftShift, OnLeftShiftEvent);
		}
	}
}
