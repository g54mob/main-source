using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SelectionFooterView : UIView
	{
		private static readonly Dictionary<LockState, Action<DoorComponentInstance>> DoorOrderAction = new Dictionary<LockState, Action<DoorComponentInstance>>
		{
			{
				LockState.Locked,
				LockDoor
			},
			{
				LockState.Unlocked,
				UnlockDoor
			},
			{
				LockState.AlwaysOpen,
				AlwaysOpenDoor
			}
		};

		private static readonly Dictionary<LockState, Action<WindowComponentInstance>> WindowOrderActions = new Dictionary<LockState, Action<WindowComponentInstance>>
		{
			{
				LockState.Locked,
				CloseWindow
			},
			{
				LockState.AlwaysOpen,
				OpenWindow
			}
		};

		private static readonly Dictionary<LockState, Action<ShelfComponentInstance>> BarrelOrderActions = new Dictionary<LockState, Action<ShelfComponentInstance>>
		{
			{
				LockState.Locked,
				CloseBarrel
			},
			{
				LockState.AlwaysOpen,
				OpenBarrel
			}
		};

		private static readonly Dictionary<TorchState, Action<FuelConsumerComponentInstance>> FuelConsumerOrderAction = new Dictionary<TorchState, Action<FuelConsumerComponentInstance>>
		{
			{
				TorchState.Off,
				TurnOnFuelConsumer
			},
			{
				TorchState.Burning,
				TurnOffFuelConsumer
			},
			{
				TorchState.FuelMissing,
				TurnOffFuelConsumer
			}
		};

		[SerializeField]
		private LayoutGroupView actionButtonGroup;

		[SerializeField]
		private ToggleGroup workerStancesGroup;

		[SerializeField]
		private ToggleGroup workerDraftedStancesGroup;

		[SerializeField]
		private ToggleGroup doorStateGroup;

		private readonly List<LayoutGroupItemView> actionButtons = new List<LayoutGroupItemView>();

		[NonSerialized]
		private BaseBuildingInstance baseBuildableObject;

		[NonSerialized]
		private DoorComponentInstance door;

		private Dictionary<KeyInputEvent, Action> subscribedActions = new Dictionary<KeyInputEvent, Action>();

		[NonSerialized]
		private HumanoidInstance humanoid;

		public List<LayoutGroupItemView> ActionButtons => actionButtons;

		public ToggleGroup WorkerDraftedStancesGroup => workerDraftedStancesGroup;

		private static void TurnOffFuelConsumer(FuelConsumerComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed)
			{
				instance.TurnOff();
			}
		}

		private static void TurnOnFuelConsumer(FuelConsumerComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed)
			{
				instance.TurnOn();
			}
		}

		private static void LockDoor(DoorComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance.SetDoorOrder(DoorOrder.Lock);
			}
		}

		private static void UnlockDoor(DoorComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance.SetDoorOrder(DoorOrder.Unlock);
			}
		}

		private static void AlwaysOpenDoor(DoorComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance?.SetDoorOrder(DoorOrder.Open);
			}
		}

		private static void CloseWindow(WindowComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance.SetWindowOrder(WindowOrder.Close);
			}
		}

		private static void OpenWindow(WindowComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance.SetWindowOrder(WindowOrder.Open);
			}
		}

		private static void OpenBarrel(ShelfComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance.SetShelfOrder(ShelfOrder.Open);
			}
		}

		private static void CloseBarrel(ShelfComponentInstance instance)
		{
			if (instance != null && !instance.HasDisposed && instance.OwnerBuilding != null && !instance.OwnerBuilding.HasDisposed && instance.OwnerBuilding.OwnedByPlayer())
			{
				instance.SetShelfOrder(ShelfOrder.Close);
			}
		}

		public void InitializeFooter(InfoPanelFooter footerData)
		{
			humanoid = footerData.Humanoid;
			door = footerData.DoorComponentInstance;
			baseBuildableObject = footerData.BaseBuildingInstance;
			UnsubscribeFromAll();
			HandleWorkerStances();
			doorStateGroup.gameObject.SetActive(value: false);
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count >= 2)
			{
				HandleLockableObjectButtonsMultiSelect();
			}
			else
			{
				HandleLockableObjectButtons();
			}
			if (footerData.InfoPanelActions == null)
			{
				RemoveButtonActions(actionButtons, 0, actionButtons.Count);
				actionButtons.SetAllActive(active: false);
				return;
			}
			SubscribeToAll();
			int num = 0;
			if (subscribedActions == null)
			{
				subscribedActions = new Dictionary<KeyInputEvent, Action>();
			}
			foreach (InfoPanelAction infoPanelAction in footerData.InfoPanelActions)
			{
				InfoPanelAction cachedAction = infoPanelAction;
				SelectionInputActionData currentActionData = cachedAction.GetCurrentActionData();
				LayoutGroupItemView button = actionButtons.GetAt(actionButtonGroup, num);
				num++;
				SetButtonData(button, currentActionData);
				ButtonKeyCommandTooltipViewNew tooltipView = button.TooltipNew as ButtonKeyCommandTooltipViewNew;
				UpdateActionButtonTooltip(currentActionData, tooltipView);
				SoundButton soundButton = button.GetComponentInChildren<SoundButton>();
				soundButton.AddCleanListener(delegate
				{
					ActionButtonClick(soundButton, cachedAction);
				});
				if (currentActionData.GetID().Equals("CopyBuilding") || currentActionData.GetID().Equals("ExpandZone") || currentActionData.GetID().Equals("ShrinkZone"))
				{
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						if (MonoSingleton<SelectableObjectManager>.IsInstantiated())
						{
							if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 1)
							{
								button.gameObject.SetActive(value: false);
							}
							else
							{
								button.gameObject.SetActive(value: true);
							}
						}
					});
				}
				KeyInputEvent keyInputEvent = currentActionData.KeyInputEvent;
				if (keyInputEvent != KeyInputEvent.None && ((uint)(keyInputEvent - 59) > 5u || MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count <= 1))
				{
					subscribedActions[currentActionData.KeyInputEvent] = delegate
					{
						RunAction(cachedAction);
					};
					MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(currentActionData.KeyInputEvent, subscribedActions[currentActionData.KeyInputEvent]);
				}
			}
			actionButtons.SetActiveFromIndex(num, active: false);
			RemoveButtonActions(actionButtons, num, actionButtons.Count);
		}

		public override void Hide()
		{
			base.Hide();
			RemoveButtonActions(actionButtons, 0, actionButtons.Count);
			UnsubscribeFromAll();
		}

		private static void RemoveButtonActions(List<LayoutGroupItemView> items, int indexFrom, int indexTo)
		{
			for (int i = indexFrom; i < indexTo; i++)
			{
				LayoutGroupItemView layoutGroupItemView = items[i];
				SoundButton[] componentsInChildren = layoutGroupItemView.GetComponentsInChildren<SoundButton>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j]?.ClearAllListeners();
				}
				Button[] componentsInChildren2 = layoutGroupItemView.GetComponentsInChildren<Button>();
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					componentsInChildren2[j]?.onClick?.RemoveAllListeners();
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			humanoid = null;
			door = null;
			UnsubscribeFromAll();
		}

		private void RunAction(InfoPanelAction action)
		{
			if (base.isActiveAndEnabled)
			{
				action.RunCurrentAction();
				MonoSingleton<SelectableObjectController>.Instance.OnDataUpdated();
			}
		}

		private bool DoorsSelection()
		{
			List<DoorComponentInstance> list = new List<DoorComponentInstance>();
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				WorldObject asWorldObject = selectedObject.GetAsWorldObject();
				if (asWorldObject == null || asWorldObject.HasDisposed)
				{
					continue;
				}
				DoorComponentInstance componentInstance = asWorldObject.Map.DoorComponentManager.GetComponentInstance(asWorldObject);
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					if (componentInstance.OwnerBuilding.FactionOwnership == FactionOwnership.Enemy)
					{
						return false;
					}
					list.Add(componentInstance);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			LockState lockState = list[0].LockState;
			bool flag = true;
			foreach (DoorComponentInstance item in list)
			{
				if (item.LockState != lockState)
				{
					flag = false;
					break;
				}
			}
			LockState currentLockState = ((!flag) ? LockState.Undefined : lockState);
			List<DoorComponentInstance> selectedDoorComponentsCopy = list.ToList();
			doorStateGroup.gameObject.SetActive(value: true);
			HandleLockStateButtons(currentLockState, list[0], ClickAction);
			return true;
			void ClickAction(LockState key)
			{
				foreach (DoorComponentInstance item2 in selectedDoorComponentsCopy)
				{
					if (DoorOrderAction.TryGetValue(key, out var value))
					{
						value?.Invoke(item2);
					}
				}
			}
		}

		private bool WindowsSelection()
		{
			List<WindowComponentInstance> list = new List<WindowComponentInstance>();
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				WorldObject asWorldObject = selectedObject.GetAsWorldObject();
				if (asWorldObject == null || asWorldObject.HasDisposed)
				{
					continue;
				}
				WindowComponentInstance componentInstance = asWorldObject.Map.WindowComponentManager.GetComponentInstance(asWorldObject);
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					if (componentInstance.OwnerBuilding.FactionOwnership == FactionOwnership.Enemy)
					{
						return false;
					}
					list.Add(componentInstance);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			LockState firstLockState = list[0].LockState;
			LockState currentLockState = ((!list.All((WindowComponentInstance sel) => sel.LockState == firstLockState)) ? LockState.Undefined : firstLockState);
			List<WindowComponentInstance> selectedWindowComponentsCopy = list.ToList();
			doorStateGroup.gameObject.SetActive(value: true);
			HandleLockStateButtons(currentLockState, list[0], ClickAction);
			return true;
			void ClickAction(LockState lockState)
			{
				foreach (WindowComponentInstance item in selectedWindowComponentsCopy)
				{
					if (WindowOrderActions.TryGetValue(lockState, out var value))
					{
						value?.Invoke(item);
					}
				}
			}
		}

		private bool FuelConsumersSelection()
		{
			List<FuelConsumerComponentInstance> list = new List<FuelConsumerComponentInstance>();
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				WorldObject asWorldObject = selectedObject.GetAsWorldObject();
				if (asWorldObject == null || asWorldObject.HasDisposed)
				{
					continue;
				}
				FuelConsumerComponentInstance componentInstance = asWorldObject.Map.FuelConsumerComponentManager.GetComponentInstance(asWorldObject);
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					if (componentInstance.OwnerBuilding.FactionOwnership == FactionOwnership.Enemy)
					{
						return false;
					}
					list.Add(componentInstance);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			TorchState torchState = list[0].TorchState;
			List<FuelConsumerComponentInstance> selectedFuelConsumersCopy = list.ToList();
			doorStateGroup.gameObject.SetActive(value: true);
			HandleFuelConsumerButtons(torchState, list[0], ClickAction);
			return true;
			void ClickAction(TorchState lockState)
			{
				foreach (FuelConsumerComponentInstance item in selectedFuelConsumersCopy)
				{
					if (FuelConsumerOrderAction.TryGetValue(lockState, out var value))
					{
						value?.Invoke(item);
					}
				}
			}
		}

		private void HandleFuelConsumerButtons(TorchState currentLockState, FuelConsumerComponentInstance fuelConsumerComponent, Action<TorchState> clickAction)
		{
			CustomGrouppedToggle[] componentsInChildren = doorStateGroup.GetComponentsInChildren<CustomGrouppedToggle>(includeInactive: true);
			int num = 0;
			CustomGrouppedToggle[] array = componentsInChildren;
			foreach (CustomGrouppedToggle customGrouppedToggle in array)
			{
				if (num < 2)
				{
					num++;
				}
				else
				{
					customGrouppedToggle.gameObject.SetActive(value: false);
				}
			}
			componentsInChildren[0].gameObject.SetActive(value: true);
			componentsInChildren[0].onValueChanged.RemoveAllListeners();
			componentsInChildren[0].isOn = fuelConsumerComponent.TorchState != TorchState.Off;
			componentsInChildren[0].GetComponentInChildren<TMP_Text>().SetText(MonoSingleton<LocalizationController>.Instance.GetText(fuelConsumerComponent.Blueprint.TextKeyOn));
			componentsInChildren[0].onValueChanged.AddListener(delegate(bool active)
			{
				if (active)
				{
					clickAction(fuelConsumerComponent.TorchState);
				}
			});
			componentsInChildren[1].gameObject.SetActive(value: true);
			componentsInChildren[1].onValueChanged.RemoveAllListeners();
			componentsInChildren[1].isOn = fuelConsumerComponent.TorchState == TorchState.Off;
			componentsInChildren[1].GetComponentInChildren<TMP_Text>().SetText(MonoSingleton<LocalizationController>.Instance.GetText(fuelConsumerComponent.Blueprint.TextKeyOff));
			componentsInChildren[1].onValueChanged.AddListener(delegate(bool active)
			{
				if (active)
				{
					clickAction(fuelConsumerComponent.TorchState);
				}
			});
		}

		private void HandleLockableObjectButtonsMultiSelect()
		{
			IEnumerable<SelectableObject> enumerable = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Where(delegate(SelectableObject selectableObject)
			{
				WorldObject asWorldObject = selectableObject.GetAsWorldObject();
				if (asWorldObject == null || asWorldObject.HasDisposed)
				{
					return false;
				}
				if (!(asWorldObject is BaseBuildingInstance baseBuildingInstance))
				{
					return false;
				}
				return baseBuildingInstance.GetComponentInstance<DoorComponentInstance>() != null || baseBuildingInstance.GetComponentInstance<WindowComponentInstance>() != null || baseBuildingInstance.GetComponentInstance<FuelConsumerComponentInstance>() != null;
			});
			if (!enumerable.Any())
			{
				return;
			}
			PooledList<BaseBuildingInstance> selectedLockables = ListPool<BaseBuildingInstance>.GetJanitor();
			try
			{
				foreach (SelectableObject item2 in enumerable)
				{
					if (item2.GetAsWorldObject() is BaseBuildingInstance item)
					{
						selectedLockables.Add(item);
					}
				}
				if (selectedLockables.Count != 0 && !selectedLockables.Any((BaseBuildingInstance x) => x.BuildingType != selectedLockables.First().BuildingType) && !DoorsSelection() && !WindowsSelection())
				{
					FuelConsumersSelection();
				}
			}
			finally
			{
				((IDisposable)selectedLockables/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private void HandleLockableObjectButtons()
		{
			if (baseBuildableObject == null || baseBuildableObject.Blueprint == null || baseBuildableObject.ConstructionPhase != ConstructionPhase.Finished || !baseBuildableObject.OwnedByPlayer())
			{
				return;
			}
			DoorComponentInstance doorComponentInstance = baseBuildableObject.Map.DoorComponentManager.GetComponentInstance(baseBuildableObject);
			if (doorComponentInstance != null)
			{
				HandleLockStateButtons(doorComponentInstance.LockState, doorComponentInstance, delegate(LockState state)
				{
					DoorOrderAction[state]?.Invoke(doorComponentInstance);
				});
				doorStateGroup.gameObject.SetActive(value: true);
				return;
			}
			WindowComponentInstance windowComponentInstance = baseBuildableObject.Map.WindowComponentManager.GetComponentInstance(baseBuildableObject);
			if (windowComponentInstance != null)
			{
				HandleLockStateButtons(windowComponentInstance.LockState, windowComponentInstance, delegate(LockState state)
				{
					WindowOrderActions[state]?.Invoke(windowComponentInstance);
				});
				doorStateGroup.gameObject.SetActive(value: true);
				return;
			}
			ShelfComponentInstance shelfComponentInstance = baseBuildableObject.Map.ShelfComponentManager.GetComponentInstance(baseBuildableObject);
			if (shelfComponentInstance != null && shelfComponentInstance.Blueprint.LockStates.Count > 0)
			{
				HandleLockStateButtons(shelfComponentInstance.LockState, shelfComponentInstance, delegate(LockState state)
				{
					BarrelOrderActions[state]?.Invoke(shelfComponentInstance);
				});
				doorStateGroup.gameObject.SetActive(value: true);
				return;
			}
			FuelConsumerComponentInstance fuelConsumerComponentInstance = baseBuildableObject.Map.FuelConsumerComponentManager.GetComponentInstance(baseBuildableObject);
			if (fuelConsumerComponentInstance != null)
			{
				HandleFuelConsumerButtons(fuelConsumerComponentInstance.TorchState, fuelConsumerComponentInstance, delegate(TorchState state)
				{
					FuelConsumerOrderAction[state]?.Invoke(fuelConsumerComponentInstance);
				});
				doorStateGroup.gameObject.SetActive(value: true);
			}
		}

		private void HandleLockStateButtons(LockState currentLockState, ILockable lockable, Action<LockState> clickAction)
		{
			CustomGrouppedToggle[] componentsInChildren = doorStateGroup.GetComponentsInChildren<CustomGrouppedToggle>(includeInactive: true);
			LockState lockStateForOrder = lockable.GetLockStateForOrder();
			for (int i = lockable.LockStates.Count; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.SetActive(value: false);
			}
			int num = 0;
			foreach (LockStateData lockStateData in lockable.LockStates)
			{
				if (num > componentsInChildren.Length)
				{
					Log.Error("Not enough buttons in SerlectionFooterView)", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionFooterView.cs");
					continue;
				}
				componentsInChildren[num].gameObject.SetActive(value: true);
				bool isOn = (lockable.HasOrders ? (lockStateData.LockState == lockStateForOrder) : (currentLockState == lockStateData.LockState));
				if (currentLockState == LockState.Undefined)
				{
					isOn = false;
				}
				componentsInChildren[num].onValueChanged.RemoveAllListeners();
				componentsInChildren[num].isOn = isOn;
				componentsInChildren[num].GetComponentInChildren<TMP_Text>().SetText(MonoSingleton<LocalizationController>.Instance.GetText(lockStateData.TextKey));
				componentsInChildren[num].onValueChanged.AddListener(delegate(bool active)
				{
					if (active)
					{
						clickAction(lockStateData.LockState);
					}
				});
				num++;
			}
		}

		private void HandleWorkerStances()
		{
			workerStancesGroup.gameObject.SetActive(value: false);
			workerDraftedStancesGroup.gameObject.SetActive(value: false);
			if (TutorialManager.IsTutorialActive && !MonoSingleton<TutorialManager>.Instance.AllowCreatureCommands)
			{
				return;
			}
			WorkerBehaviour workerBehaviour = (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.FirstOrDefault() as WorkerView)?.HumanoidInstance.WorkerBehaviour;
			if (workerBehaviour == null)
			{
				return;
			}
			List<WorkerBehaviour> list = new List<WorkerBehaviour>();
			bool flag = false;
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				if (!(selectedObject is WorkerView workerView))
				{
					return;
				}
				if (!(workerView == null) && !workerView.HasDisposed)
				{
					WorkerBehaviour workerBehaviour2 = workerView.HumanoidInstance.WorkerBehaviour;
					if (workerBehaviour2.IsDrafting != workerBehaviour.IsDrafting)
					{
						return;
					}
					list.Add(workerBehaviour2);
					flag = flag || workerBehaviour.CombatMode != workerBehaviour2.CombatMode;
				}
			}
			if (list.Count != 0)
			{
				if (workerBehaviour.IsDrafting)
				{
					UnitCombatModeType[] stances = new UnitCombatModeType[2]
					{
						UnitCombatModeType.DraftedHoldGround,
						UnitCombatModeType.DraftedDefault
					};
					SetupWorkerStanceButtons(list, workerDraftedStancesGroup, stances, flag);
				}
				else
				{
					UnitCombatModeType[] stances2 = new UnitCombatModeType[3]
					{
						UnitCombatModeType.Aggressive,
						UnitCombatModeType.Flee,
						UnitCombatModeType.Neutral
					};
					SetupWorkerStanceButtons(list, workerStancesGroup, stances2, flag);
				}
			}
		}

		private static void SetupWorkerStanceButtons(List<WorkerBehaviour> workers, ToggleGroup toggleGroup, UnitCombatModeType[] stances, bool turnAllButtonsOff)
		{
			toggleGroup.gameObject.SetActive(value: true);
			CustomGrouppedToggle[] componentsInChildren = toggleGroup.GetComponentsInChildren<CustomGrouppedToggle>();
			int num = 0;
			bool interactable = workers.Any((WorkerBehaviour worker) => worker.StancesEnabled());
			WorkerBehaviour workerBehaviour = workers[0];
			foreach (UnitCombatModeType stance in stances)
			{
				if (num >= componentsInChildren.Length)
				{
					Log.Error("Ran out of worker stance toggle buttons while updating UI, this should not happen. Did you add more unit combat modes but didn't add more UI buttons to the prefab?", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\SelectionFooterView.cs");
					break;
				}
				componentsInChildren[num].onValueChanged.RemoveAllListeners();
				componentsInChildren[num].isOn = !turnAllButtonsOff && stance == workerBehaviour.CombatMode;
				componentsInChildren[num].interactable = interactable;
				componentsInChildren[num].onValueChanged.AddListener(delegate(bool active)
				{
					if (!active)
					{
						return;
					}
					foreach (WorkerBehaviour worker in workers)
					{
						if (worker.StancesEnabled())
						{
							worker.SetCombatMode(stance);
						}
					}
				});
				num++;
			}
		}

		private void SetButtonData(LayoutGroupItemView button, SelectionInputActionData actionData)
		{
			button.SetImage(actionData.IconPath);
			button.SetText(1, base.Localize.GetText(LocKeyUtils.GetName(actionData.LocKeys)));
			if (button.TooltipNew is ButtonKeyCommandTooltipViewNew buttonKeyCommandTooltipViewNew)
			{
				if (humanoid != null)
				{
					buttonKeyCommandTooltipViewNew.SetBodyType(humanoid.Info.BodyType);
				}
				buttonKeyCommandTooltipViewNew.Init(actionData.GetID(), actionData.KeyInputEvent);
			}
			HandleWorkerStances();
		}

		private void ActionButtonClick(SoundButton button, InfoPanelAction infoPanelAction)
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			RunAction(infoPanelAction);
			if (infoPanelAction.IsToggle)
			{
				LayoutGroupItemView componentInParent = button.GetComponentInParent<LayoutGroupItemView>();
				if ((object)componentInParent != null)
				{
					SetButtonData(componentInParent, infoPanelAction.GetCurrentActionData());
				}
			}
		}

		private void UpdateActionButtonTooltip(SelectionInputActionData actionData, ButtonKeyCommandTooltipViewNew tooltipView)
		{
			if (!(tooltipView == null))
			{
				KeyInputEvent keyInputEvent = actionData.KeyInputEvent;
				if (actionData.GetID().Equals("forbid") && keyInputEvent.Equals(KeyInputEvent.None))
				{
					keyInputEvent = KeyInputEvent.Allow;
				}
				tooltipView.Init(actionData.GetID(), keyInputEvent);
				tooltipView.RefreshTooltip();
			}
		}

		private void OnCombatModeChanged(HumanoidInstance humanoidInstance)
		{
			if (humanoid?.WorkerBehaviour == null || humanoid != humanoidInstance)
			{
				return;
			}
			CustomGrouppedToggle[] componentsInChildren = workerStancesGroup.GetComponentsInChildren<CustomGrouppedToggle>();
			int num = 0;
			UnitCombatModeType[] unitCombatModeTypes = EnumValues.UnitCombatModeTypes;
			foreach (UnitCombatModeType unitCombatModeType in unitCombatModeTypes)
			{
				if (unitCombatModeType != UnitCombatModeType.None && (int)unitCombatModeType <= componentsInChildren.Length)
				{
					componentsInChildren[num].SetIsOnWithoutNotify(unitCombatModeType == humanoid.WorkerBehaviour.CombatMode);
					num++;
				}
			}
		}

		private void SubscribeToAll()
		{
			if (humanoid?.WorkerBehaviour != null)
			{
				humanoid.WorkerBehaviour.CombatModeChangeEvent += OnCombatModeChanged;
			}
		}

		private void UnsubscribeFromAll()
		{
			if (humanoid?.WorkerBehaviour != null)
			{
				humanoid.WorkerBehaviour.CombatModeChangeEvent -= OnCombatModeChanged;
			}
			if (MonoSingleton<KeybindingManager>.IsInstantiated())
			{
				foreach (KeyValuePair<KeyInputEvent, Action> subscribedAction in subscribedActions)
				{
					MonoSingleton<KeybindingManager>.Instance.UnsubscribeFromEvent(subscribedAction.Key, subscribedAction.Value);
				}
			}
			subscribedActions?.Clear();
		}
	}
}
