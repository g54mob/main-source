using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[Serializable]
	public class RallyPointExtraPanel : SelectionExtraWindowView
	{
		[SerializeField]
		private TMP_InputField rallyPointName;

		[SerializeField]
		private LayoutGroupView entriesContent;

		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private ToggleGroup draftedStanceToggleGroup;

		[SerializeField]
		private SoundButton allowAllButton;

		[SerializeField]
		private SoundButton clearAllButton;

		[SerializeField]
		private CustomToggle armedSettlersToggle;

		[NonSerialized]
		private List<RallyPointListEntry> entries = new List<RallyPointListEntry>();

		[NonSerialized]
		private RallyPointMarkerComponentInstance rallyPoint;

		public void UpdatePanel(InfoPanelRallyPoint infoPanel)
		{
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 1)
			{
				return;
			}
			BaseBuildingInstance baseBuildingInstance = infoPanel.BaseBuildingInstance;
			rallyPoint = baseBuildingInstance?.Map.RallyPointMarkerComponentManager.GetComponentInstance(baseBuildingInstance);
			if (rallyPoint == null)
			{
				Log.Error("No rally point here!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\RallyPointExtraPanel.cs");
				return;
			}
			rallyPoint.RemoveDisposedWorkers();
			Show();
			RefreshListEntries();
			if (MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				rallyPointName.SetTextWithoutNotify(rallyPoint.Name);
			}
			UnitCombatModeType[] array = new UnitCombatModeType[2]
			{
				UnitCombatModeType.DraftedDefault,
				UnitCombatModeType.DraftedHoldGround
			};
			CustomGrouppedToggle[] componentsInChildren = draftedStanceToggleGroup.GetComponentsInChildren<CustomGrouppedToggle>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				CustomGrouppedToggle obj = componentsInChildren[i];
				obj.onValueChanged.RemoveAllListeners();
				UnitCombatModeType draftedStance = array[i];
				obj.isOn = rallyPoint.DraftedStance == draftedStance;
				obj.interactable = true;
				obj.onValueChanged.AddListener(delegate(bool alive)
				{
					if (alive)
					{
						rallyPoint.DraftedStance = draftedStance;
					}
				});
			}
			armedSettlersToggle.isOn = rallyPoint.ArmedSettlersOnly;
		}

		private void Start()
		{
			rallyPointName.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			rallyPointName.onDeselect.AddListener(OnNameEdit);
			rallyPointName.onEndEdit.AddListener(OnNameEdit);
			allowAllButton.AddCleanListener(AllowAll);
			clearAllButton.AddCleanListener(ClearAll);
			armedSettlersToggle.onValueChanged.AddListener(SetArmedSettlersOnly);
		}

		private void OnEnable()
		{
			rallyPoint.ChangedEvent += RefreshListEntries;
			CaravanController instance = MonoSingleton<CaravanController>.Instance;
			instance.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreatedOrReturned));
			CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
			instance2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanCreatedOrReturned));
			MonoSingleton<WorkerController>.Instance.WorkerDiedEvent += OnWorkerDied;
			MonoSingleton<WorkerController>.Instance.WorkerFaintedEvent += OnWorkerFainted;
		}

		private void OnDisable()
		{
			if (rallyPoint != null)
			{
				rallyPoint.ChangedEvent -= RefreshListEntries;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController instance = MonoSingleton<CaravanController>.Instance;
				instance.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreatedOrReturned));
				CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
				instance2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanCreatedOrReturned));
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.WorkerDiedEvent -= OnWorkerDied;
				MonoSingleton<WorkerController>.Instance.WorkerFaintedEvent -= OnWorkerFainted;
			}
		}

		private void OnWorkerFainted(int arg1, int arg2)
		{
			RefreshListEntries();
		}

		private void OnWorkerDied(int remainingCount)
		{
			RefreshListEntries();
		}

		private void OnCaravanCreatedOrReturned(CaravanInstance caravaninstance)
		{
			RefreshListEntries();
		}

		private void SetArmedSettlersOnly(bool state)
		{
			rallyPoint.ArmedSettlersOnly = state;
		}

		private void AllowAll()
		{
			rallyPoint.AssignAllWorkers();
			RefreshListEntries();
		}

		private void ClearAll()
		{
			rallyPoint.ClearAllWorkers();
			RefreshListEntries();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			rallyPointName.onSelect.RemoveAllListeners();
			rallyPointName.onDeselect.RemoveAllListeners();
			rallyPointName.onEndEdit.RemoveAllListeners();
			allowAllButton.RemoveAllListeners();
			clearAllButton.RemoveAllListeners();
			armedSettlersToggle.onValueChanged.RemoveAllListeners();
			rallyPoint = null;
			entries.Clear();
		}

		private void OnNameEdit(string value)
		{
			if (rallyPoint != null)
			{
				rallyPoint.Name = value;
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
		}

		private void RefreshListEntries()
		{
			int num = 0;
			using PooledList<HumanoidInstance> pooledList = WorkerManager.WorkersEverywhere.ToPooledListJanitor();
			pooledList.Sort((HumanoidInstance x, HumanoidInstance y) => x.UniqueId.CompareTo(y.UniqueId));
			foreach (HumanoidInstance item in pooledList)
			{
				entries.GetAt(entriesContent, num).Init(item, rallyPoint);
				num++;
			}
			entries.SetActiveFromIndex(num, active: false);
		}
	}
}
