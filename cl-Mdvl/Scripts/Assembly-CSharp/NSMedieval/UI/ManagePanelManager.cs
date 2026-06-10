using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ManagePanelManager : WorkerPanelManager
	{
		[NonSerialized]
		public HumanoidInstance WorkerToCopy;

		[SerializeField]
		private Transform groupNameParent;

		[SerializeField]
		private GameObject jobNamePrefab;

		[SerializeField]
		private ProfileEditManager profileEditManager;

		[SerializeField]
		private ApparelEditManager apparelEditManager;

		private bool saveEnabled;

		public event Action ProfileEditedEvent;

		public event Action<string, string> ProfileDeletedEvent;

		public event Action<string, string> ProfileChangedEvent;

		protected override void Start()
		{
			base.Start();
			MonoSingleton<TaskController>.Instance.WaitFor(0.11f).Then(delegate
			{
				saveEnabled = true;
			});
		}

		public void ShowEditPanel(ManageGroup manageGroup, string selectedPreset)
		{
			if ((manageGroup.SlotType & (EquipmentSlotType.Head | EquipmentSlotType.Body | EquipmentSlotType.BodyArmor)) != EquipmentSlotType.None)
			{
				apparelEditManager.ShowPanel(this, manageGroup, selectedPreset);
			}
			else
			{
				profileEditManager.ShowPanel(this, manageGroup, selectedPreset);
			}
		}

		public void InvokeProfileEditedEvent()
		{
			this.ProfileEditedEvent?.Invoke();
		}

		public void InvokeProfileDeletedEvent(string groupId, string presetId)
		{
			this.ProfileDeletedEvent?.Invoke(groupId, presetId);
		}

		public void InvokeProfileChangedEvent(string groupId, string presetId)
		{
			this.ProfileChangedEvent?.Invoke(groupId, presetId);
		}

		public override void PasteToWorker(HumanoidInstance worker)
		{
			HumanoidInstance workerToCopy = WorkerToCopy;
			if (workerToCopy == null || workerToCopy == worker || worker?.WorkerBehaviour == null)
			{
				return;
			}
			if (!worker.WorkerBehaviour.IsDrafting)
			{
				worker.WorkerBehaviour.SetCombatMode(workerToCopy.WorkerBehaviour.CombatMode);
			}
			worker.WorkerBehaviour.SetSelfTendingAllowed(workerToCopy.WorkerBehaviour.IsAllowedSelfTending);
			worker.WorkerBehaviour.UseRallyPoints = workerToCopy.WorkerBehaviour.UseRallyPoints;
			worker.WorkerBehaviour.SelectedManagePresets.Dictionary.Clear();
			string value;
			string key;
			foreach (KeyValuePair<string, string> item in workerToCopy.WorkerBehaviour.SelectedManagePresets.Dictionary)
			{
				item.Deconstruct(out value, out key);
				string key2 = value;
				string value2 = key;
				worker.WorkerBehaviour.SelectedManagePresets.Dictionary[key2] = value2;
			}
			using PooledDictionary<string, string> pooledDictionary = worker.WorkerBehaviour.SelectedManagePresets.Dictionary.ToPooledDictionaryJanitor();
			foreach (KeyValuePair<string, string> item2 in pooledDictionary)
			{
				item2.Deconstruct(out key, out value);
				string groupId = key;
				string presetId = value;
				worker.WorkerBehaviour.UpdateSingleManagePreset(groupId, presetId);
			}
		}

		public void DisableInput()
		{
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			MonoSingleton<RtsCamera>.Instance.BlockCameraMovement(block: true);
		}

		public void EnableInput()
		{
			MonoSingleton<RtsCamera>.Instance.BlockCameraMovement(block: false);
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
		}

		protected override void OnHelpClick()
		{
			MonoSingleton<UIController>.Instance.ShowAlmanacEntry("Gameplaytipsmanage");
		}

		public override void Hide()
		{
			EnableInput();
			WorkerToCopy = null;
			if (apparelEditManager.IsVisible || profileEditManager.IsVisible)
			{
				apparelEditManager.Hide();
				profileEditManager.Hide();
				return;
			}
			base.Hide();
			if (MonoSingleton<World>.IsInstantiated() && MonoSingleton<GlobalSaveController>.IsInstantiated() && GlobalSaveController.CurrentVillageData != null && saveEnabled)
			{
				Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.SaveUserPresets();
			}
		}
	}
}
