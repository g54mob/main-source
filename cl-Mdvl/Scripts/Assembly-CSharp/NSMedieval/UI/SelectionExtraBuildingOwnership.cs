using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SelectionExtraBuildingOwnership : SelectionExtraWindowView
	{
		[SerializeField]
		private LayoutGroupView workerCheckboxParent;

		[SerializeField]
		private GameObject checkboxesParent;

		[SerializeField]
		private TMP_Text tempOwnerText;

		[NonSerialized]
		private BaseBuildingInstance selectedBuilding;

		[NonSerialized]
		private Dictionary<HumanoidInstance, WorkerToggleLayoutItemView> checkboxesDictionary = new Dictionary<HumanoidInstance, WorkerToggleLayoutItemView>();

		public override void Initialize()
		{
			base.Initialize();
			MonoSingleton<WorkerController>.Instance.WorkerNameChangedEvent += OnWorkerNameChanged;
		}

		public void UpdatePanel(BaseBuildingInstance selectedBuilding)
		{
			if (selectedBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				Hide();
				return;
			}
			if (!selectedBuilding.Blueprint.CanHaveOwner)
			{
				Hide();
				return;
			}
			if (selectedBuilding.GetRoom() != null && selectedBuilding.GetRoom().RoomType.Prison)
			{
				Hide();
				return;
			}
			this.selectedBuilding = selectedBuilding;
			Show();
			if (this.selectedBuilding.BuildingOwnershipInfo.TempOwner != null)
			{
				tempOwnerText.gameObject.SetActive(value: true);
				tempOwnerText.text = MonoSingleton<LocalizationController>.Instance.GetText("bed_temporary_owner");
				checkboxesParent.SetActive(value: false);
				return;
			}
			tempOwnerText.gameObject.SetActive(value: false);
			checkboxesParent.SetActive(value: true);
			GenerateCheckboxesAndSelectCurrent(GlobalSaveController.CurrentVillageData.Workers);
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				GenerateCheckboxesAndSelectCurrent(caravan.Workers);
			}
			InitializeToggleCallbacks();
		}

		public override void Hide()
		{
			selectedBuilding = null;
			base.Hide();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnWorkerRemoved;
				MonoSingleton<WorkerController>.Instance.WorkerNameChangedEvent -= OnWorkerNameChanged;
			}
		}

		private void OnWorkerNameChanged(HumanoidInstance humanoidInstance)
		{
			if (selectedBuilding != null && !selectedBuilding.HasDisposed)
			{
				checkboxesDictionary.TryGetValue(humanoidInstance, out var value);
				if (!(value == null))
				{
					value.SetData(humanoidInstance.Info.GetFullName(), selectedBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance));
				}
			}
		}

		private void GenerateCheckboxesAndSelectCurrent(IEnumerable<HumanoidInstance> workers)
		{
			foreach (HumanoidInstance worker in workers)
			{
				if (!checkboxesDictionary.ContainsKey(worker))
				{
					WorkerToggleLayoutItemView component = UnityEngine.Object.Instantiate(workerCheckboxParent.Prefab, workerCheckboxParent.transform).GetComponent<WorkerToggleLayoutItemView>();
					checkboxesDictionary.Add(worker, component);
					component.SetData(worker.Info.GetFullName(), selectedBuilding.BuildingOwnershipInfo.IsOwner(worker));
					component.SetWorkerInstance(worker);
				}
				else
				{
					checkboxesDictionary[worker].SetData(worker.Info.GetFullName(), selectedBuilding.BuildingOwnershipInfo.IsOwner(worker));
					checkboxesDictionary[worker].Toggle.SetIsOnWithoutNotify(selectedBuilding.BuildingOwnershipInfo.IsOwner(worker));
				}
			}
		}

		private void InitializeToggleCallbacks()
		{
			foreach (WorkerToggleLayoutItemView value in checkboxesDictionary.Values)
			{
				WorkerToggleLayoutItemView boliv = value;
				boliv.Toggle.onValueChanged.RemoveAllListeners();
				boliv.Toggle.onValueChanged.AddListener(delegate(bool value)
				{
					HumanoidInstance humanoidInstance = boliv.HumanoidInstance;
					if (IsWorkerSleepingOnBed(humanoidInstance, selectedBuilding))
					{
						boliv.Toggle.SetIsOnWithoutNotify(value: true);
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("bed_owner_cant_change"));
					}
					else if (AnyWorkerExceptNewlySelectedSleepingOn(selectedBuilding, humanoidInstance))
					{
						boliv.Toggle.SetIsOnWithoutNotify(value: false);
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("bed_owner_cant_change"));
					}
					else if (!MonoSingleton<ReservationManager>.Instance.IsReserved(selectedBuilding) && humanoidInstance.IsSleeping)
					{
						if (!PathfinderUtil.IsPathPossible(humanoidInstance, selectedBuilding))
						{
							boliv.Toggle.SetIsOnWithoutNotify(value: false);
							MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("building_unreachable"));
						}
						else
						{
							TurnOffCheckboxes();
							selectedBuilding.BuildingOwnershipInfo.SetOwnerFromUI(humanoidInstance, selectedBuilding);
							humanoidInstance.GetGoapAgent()?.Abort();
							boliv.Toggle.SetIsOnWithoutNotify(value: true);
						}
					}
					else if (value)
					{
						HumanoidInstance owner = selectedBuilding.BuildingOwnershipInfo.Owner;
						if (owner != null && owner != humanoidInstance && MonoSingleton<ReservationManager>.Instance.IsReservedBy(selectedBuilding, owner))
						{
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(selectedBuilding, owner);
						}
						TurnOffCheckboxes();
						boliv.Toggle.SetIsOnWithoutNotify(value: true);
						selectedBuilding.BuildingOwnershipInfo.SetOwnerFromUI(humanoidInstance, selectedBuilding);
						if (humanoidInstance.IsSleeping)
						{
							humanoidInstance.GetGoapAgent()?.Abort();
						}
					}
					else
					{
						selectedBuilding.BuildingOwnershipInfo.ClearOwner();
					}
				});
				void TurnOffCheckboxes()
				{
					foreach (WorkerToggleLayoutItemView value2 in checkboxesDictionary.Values)
					{
						if (value2 != boliv && value2.Toggle.IsActive())
						{
							value2.Toggle.SetIsOnWithoutNotify(value: false);
							selectedBuilding.BuildingOwnershipInfo.ClearOwner();
						}
					}
				}
			}
		}

		private void OnWorkerRemoved(HumanoidInstance humanoidInstance)
		{
			if ((humanoidInstance.HasDisposed || humanoidInstance.WorkerBehaviour.IsBanished) && checkboxesDictionary.ContainsKey(humanoidInstance))
			{
				WorkerToggleLayoutItemView workerToggleLayoutItemView = checkboxesDictionary[humanoidInstance];
				checkboxesDictionary.Remove(humanoidInstance);
				UnityEngine.Object.Destroy(workerToggleLayoutItemView.gameObject);
				LayoutRebuilder.MarkLayoutForRebuild(workerCheckboxParent.GetComponent<RectTransform>());
			}
		}

		private void Start()
		{
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnWorkerRemoved;
		}

		private bool IsWorkerSleepingOnBed(ISleepAgent sleepAgent, BaseBuildingInstance bed)
		{
			if (sleepAgent != null && MonoSingleton<ReservationManager>.Instance.IsReservedBy(bed, sleepAgent))
			{
				return sleepAgent.IsSleeping;
			}
			return false;
		}

		private bool AnyWorkerSleepingOn(BaseBuildingInstance bed)
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (IsWorkerSleepingOnBed(worker, bed))
				{
					return true;
				}
			}
			return false;
		}

		private bool AnyWorkerExceptNewlySelectedSleepingOn(BaseBuildingInstance bed, HumanoidInstance humanoidToIgnore)
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (worker != humanoidToIgnore && IsWorkerSleepingOnBed(worker, bed))
				{
					return true;
				}
			}
			return false;
		}
	}
}
