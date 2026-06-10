using System;
using System.Collections.Generic;
using System.Linq;
using Models.Type;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Resources;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.View;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerManageRowItem : WorkerPanelGroup
	{
		[SerializeField]
		private GameObject optionsParent;

		[SerializeField]
		private CustomToggle draftButton;

		[SerializeField]
		private ButtonLayoutItemView undraftedStancesButton;

		[SerializeField]
		private CustomToggle selfTendButton;

		[SerializeField]
		private Image selfTendButtonInvalidMarker;

		[SerializeField]
		private CustomToggle useRallyPointsButton;

		[SerializeField]
		private ManageEquipmentLayoutItemView[] equipmentItems;

		[SerializeField]
		private ManageGroupDropdownLayoutItemView foodItem;

		[SerializeField]
		private ManageGroupDropdownLayoutItemView stimulantsItem;

		[NonSerialized]
		private ManagePanelManager managePanelManager;

		private UnitCombatModeType firstUndraftedStance;

		private UnitCombatModeType lastUndraftedStance;

		private bool initialized;

		protected override void OnDestroy()
		{
			UnsubscribeFromWorkerEvents();
			base.OnDestroy();
			if (managePanelManager != null)
			{
				managePanelManager.ProfileEditedEvent -= OnProfileEdited;
				managePanelManager.ProfileDeletedEvent -= OnProfileDeleted;
			}
		}

		public override void SetWorker(HumanoidInstance humanoid, WorkerPanelManager panelManager)
		{
			if (firstUndraftedStance == UnitCombatModeType.None)
			{
				UnitCombatModeType[] unitCombatModeTypes = EnumValues.UnitCombatModeTypes;
				foreach (UnitCombatModeType unitCombatModeType in unitCombatModeTypes)
				{
					if (unitCombatModeType != UnitCombatModeType.None && !unitCombatModeType.IsDrafted())
					{
						if (firstUndraftedStance == UnitCombatModeType.None)
						{
							firstUndraftedStance = unitCombatModeType;
						}
						lastUndraftedStance = unitCombatModeType;
					}
				}
			}
			base.SetWorker(humanoid, panelManager);
			managePanelManager = (ManagePanelManager)panelManager;
			Initialize();
			base.WorkerView.SetHumanoidInstance(humanoid);
			OnCombatModeChanged(humanoid);
			OnDraftStateChanged(humanoid);
			OnCheckDraftButton();
			UpdateItems();
			UnsubscribeFromWorkerEvents();
			SubscribeToWorkerEvents();
		}

		protected override void CopySettings()
		{
			managePanelManager.WorkerToCopy = base.Humanoid;
		}

		protected override void PasteSettings()
		{
			managePanelManager.PasteToWorker(base.Humanoid);
			SetWorker(base.Humanoid, managePanelManager);
		}

		private void UpdateItems()
		{
			if (base.Humanoid == null || base.Humanoid.HasDisposed || base.Worker == null)
			{
				return;
			}
			UpdateSelfTendToggle();
			UpdateUseRallyPointsButton();
			optionsParent.SetActive(!MonoSingleton<CaravanManager>.Instance.IsWorkerInCaravan(base.Humanoid));
			ManageEquipmentLayoutItemView[] array = equipmentItems;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: false);
			}
			array = equipmentItems;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetData(base.Humanoid, delegate(ManageGroup manageGroup, string selectedPresetId)
				{
					managePanelManager.ShowEditPanel(manageGroup, selectedPresetId);
					managePanelManager.ProfileChangedEvent += OnProfileChanged;
				});
			}
			HandleDropdownData(Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID("food_manage_group"), foodItem);
			HandleDropdownData(Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID("stimulants_manage_group"), stimulantsItem);
		}

		private void HandleDropdownData(ManageGroup manageGroup, ManageGroupDropdownLayoutItemView slotObject)
		{
			List<Action> callbacks = new List<Action>();
			List<string> list = new List<string>();
			int defaultValue = 0;
			int num = 0;
			foreach (ManageGroupPreset userPreset in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets)
			{
				string groupId = userPreset.GroupId;
				string presetId = userPreset.GetID();
				if (groupId == manageGroup.GetID())
				{
					string item = userPreset.DisplayName;
					if (!userPreset.GetID().Contains("custom_profile_"))
					{
						item = MonoSingleton<LocalizationController>.Instance.GetText(userPreset.DisplayName);
					}
					list.Add(item);
					callbacks.Add(delegate
					{
						ChangePreset(groupId, presetId);
					});
					base.Worker.SelectedManagePresets.Dictionary.TryAdd(groupId, presetId);
					if (base.Worker.SelectedManagePresets.Dictionary[groupId] == presetId)
					{
						defaultValue = num;
					}
					num++;
				}
			}
			callbacks.Add(delegate
			{
				string selectedPreset = base.Worker.SelectedManagePresets.Dictionary[manageGroup.GetID()];
				managePanelManager.ShowEditPanel(manageGroup, selectedPreset);
				managePanelManager.ProfileChangedEvent += OnProfileChanged;
				slotObject.Dropdown.SetValueWithoutNotify(defaultValue);
			});
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("edit_" + manageGroup.GroupName + "_profiles"));
			slotObject.Dropdown.ClearOptions();
			slotObject.Dropdown.AddOptions(list);
			slotObject.Dropdown.SetValueWithoutNotify(defaultValue);
			slotObject.Dropdown.onValueChanged.RemoveAllListeners();
			slotObject.Dropdown.onValueChanged.AddListener(delegate(int value)
			{
				callbacks[value]();
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ToggleOn");
			});
		}

		private void ChangePreset(string groupId, string presetId)
		{
			base.Worker.UpdateSingleManagePreset(groupId, presetId);
		}

		private void HandleWorkerStances()
		{
			int num = (int)(base.Worker.CombatMode + 1);
			if (num > (int)lastUndraftedStance)
			{
				num = (int)firstUndraftedStance;
			}
			base.Worker.SetCombatMode((UnitCombatModeType)num);
		}

		private void SubscribeToWorkerEvents()
		{
			base.Humanoid.Inventory.OnEquipedEvent += OnInventoryChange;
			base.Humanoid.Inventory.OnDroppedEvent += OnInventoryChange;
			base.Humanoid.Inventory.OnDestroyEvent += OnInventoryChange;
			base.Worker.CombatModeChangeEvent += OnCombatModeChanged;
			base.Worker.ForcedWorkHourChangeEvent += OnForcedHourChanged;
			MonoSingleton<DraftController>.Instance.OnStartDraftEvent += OnDraftStateChanged;
			MonoSingleton<DraftController>.Instance.OnEndDraftEvent += OnDraftStateChanged;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent += OnPlayerTriggeredEvent;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent += OnPlayerTriggeredEvent;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventDiscardedEvent += OnCheckDraftButton;
		}

		private void UnsubscribeFromWorkerEvents()
		{
			if (base.Humanoid != null)
			{
				if (base.Humanoid.Inventory != null)
				{
					base.Humanoid.Inventory.OnEquipedEvent -= OnInventoryChange;
					base.Humanoid.Inventory.OnDroppedEvent -= OnInventoryChange;
					base.Humanoid.Inventory.OnDestroyEvent -= OnInventoryChange;
				}
				if (base.Worker != null)
				{
					base.Worker.CombatModeChangeEvent -= OnCombatModeChanged;
					base.Worker.ForcedWorkHourChangeEvent -= OnForcedHourChanged;
				}
			}
			if (MonoSingleton<DraftController>.IsInstantiated())
			{
				MonoSingleton<DraftController>.Instance.OnStartDraftEvent -= OnDraftStateChanged;
				MonoSingleton<DraftController>.Instance.OnEndDraftEvent -= OnDraftStateChanged;
			}
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= OnPlayerTriggeredEvent;
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent -= OnPlayerTriggeredEvent;
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventDiscardedEvent -= OnCheckDraftButton;
			}
		}

		private void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				managePanelManager.ProfileEditedEvent += OnProfileEdited;
				managePanelManager.ProfileDeletedEvent += OnProfileDeleted;
				undraftedStancesButton.Button.onClick.AddListener(HandleWorkerStances);
				draftButton.onValueChanged.AddListener(OnDraftValueChange);
				selfTendButton.onValueChanged.AddListener(OnSelfTendValueChange);
				useRallyPointsButton.onValueChanged.AddListener(OnUseRallyPointsChange);
			}
		}

		private void OnProfileEdited()
		{
			managePanelManager.ProfileChangedEvent -= OnProfileChanged;
			UpdateItems();
			base.Worker?.RebuildAllowedToConsume();
		}

		private void OnProfileDeleted(string groupId, string deletedProfileId)
		{
			string presetId = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.FirstOrDefault((ManageGroupPreset preset) => preset.GroupId == groupId)?.GetID();
			if (base.Worker.SelectedManagePresets.Dictionary[groupId] == deletedProfileId)
			{
				ChangePreset(groupId, presetId);
			}
		}

		private void OnProfileChanged(string groupId, string profileId)
		{
			if (base.Worker.SelectedManagePresets.Dictionary[groupId] != profileId)
			{
				ChangePreset(groupId, profileId);
			}
		}

		private void OnCombatModeChanged(HumanoidInstance humanoidInstance)
		{
			if (base.Humanoid != humanoidInstance)
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (this == null || base.Humanoid == null || base.Humanoid.HasDisposed || undraftedStancesButton == null)
				{
					undraftedStancesButton.gameObject.SetActive(value: false);
				}
				else
				{
					undraftedStancesButton.SetTextData($"worker_stance_{base.Worker.CombatMode}_desc", MonoSingleton<LocalizationController>.Instance.GetText($"worker_stance_{base.Worker.CombatMode}_title"));
					undraftedStancesButton.gameObject.SetActive(value: true);
					undraftedStancesButton.Button.interactable = !base.Worker.CombatMode.IsDrafted() && base.Worker.StancesEnabled();
				}
			});
		}

		private void OnForcedHourChanged()
		{
			if (undraftedStancesButton == null || undraftedStancesButton.Button == null || base.Worker == null || base.Worker.Humanoid == null || base.Worker.Humanoid.HasDisposed)
			{
				Debug.LogError($"Something is null in OnForcedHourChanged: stancesButton {undraftedStancesButton}");
				Debug.LogError($"Active behaviour: {base.Humanoid?.ActiveBehaviour}, humanoid: {base.Humanoid}");
			}
			else
			{
				undraftedStancesButton.Button.interactable = !base.Worker.CombatMode.IsDrafted() && base.Worker.StancesEnabled();
			}
		}

		private void OnDraftValueChange(bool value)
		{
			base.Humanoid.GetAgentView<WorkerView>().ToggleDraftSingle();
			draftButton.isOn = base.Worker.IsDrafting;
			undraftedStancesButton.Button.interactable = !base.Worker.CombatMode.IsDrafted() && base.Worker.StancesEnabled();
		}

		private void OnDraftStateChanged(HumanoidInstance humanoidInstance)
		{
			if (base.Humanoid == humanoidInstance)
			{
				bool isDrafting = base.Worker.IsDrafting;
				draftButton.SetIsOnWithoutNotify(isDrafting);
				undraftedStancesButton.Button.interactable = !base.Worker.CombatMode.IsDrafted() && base.Worker.StancesEnabled();
			}
		}

		private void OnPlayerTriggeredEvent(PlayerTriggeredEventInstance obj)
		{
			OnCheckDraftButton();
		}

		private void OnCheckDraftButton()
		{
			draftButton.interactable = !base.Humanoid.IsAtEvent();
		}

		private void OnSelfTendValueChange(bool value)
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed && base.Worker != null)
			{
				base.Worker.SetSelfTendingAllowed(value);
				UpdateSelfTendToggle();
			}
		}

		private void OnUseRallyPointsChange(bool value)
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed && base.Worker != null)
			{
				base.Worker.UseRallyPoints = value;
				UpdateUseRallyPointsButton();
			}
		}

		private void UpdateSelfTendToggle()
		{
			if (base.gameObject.activeSelf && base.Humanoid != null && !base.Humanoid.HasDisposed && base.Worker != null)
			{
				selfTendButtonInvalidMarker.gameObject.SetActive(!base.Worker.IsJobActive(JobType.TendWounds));
				selfTendButton.isOn = base.Worker.IsAllowedSelfTending;
				if (!selfTendButton.isOn)
				{
					selfTendButtonInvalidMarker.gameObject.SetActive(value: false);
				}
			}
		}

		private void UpdateUseRallyPointsButton()
		{
			if (base.gameObject.activeSelf && base.Humanoid != null && !base.Humanoid.HasDisposed && base.Worker != null)
			{
				useRallyPointsButton.isOn = base.Worker.UseRallyPoints;
			}
		}

		private void OnInventoryChange(EquipmentInstance instance)
		{
			UpdateItems();
		}
	}
}
