using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.WorldMap;

namespace Managers
{
	public class WorkersViewManager : MonoSingleton<WorkersViewManager>
	{
		public List<HumanoidInstance> Workers { get; private set; } = new List<HumanoidInstance>();

		public event Action WorkersListUpdatedEvent;

		private void Start()
		{
			Workers = new List<HumanoidInstance>();
			MonoSingleton<World>.Instance.MapLoadedEvent += OnInitialize;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent += OnWorkerCreated;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnWorkerRemoved;
			MonoSingleton<WorkerController>.Instance.WorkerNameChangedEvent += OnWorkerNameChanged;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnInitialize;
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent -= OnWorkerCreated;
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnWorkerRemoved;
				MonoSingleton<WorkerController>.Instance.WorkerNameChangedEvent -= OnWorkerNameChanged;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.SelectNextWorkerEvent -= OnSelectNextWorker;
			}
			base.OnDestroy();
			Workers.Clear();
			Workers = null;
			this.WorkersListUpdatedEvent = null;
		}

		private void NotifyListUpdate()
		{
			this.WorkersListUpdatedEvent?.Invoke();
		}

		private void OnGameLoaded(bool fromSave)
		{
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return;
			}
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				foreach (HumanoidInstance worker in caravan.Workers)
				{
					if (!Workers.Any((HumanoidInstance w) => w == worker || w.UniqueId == worker.UniqueId))
					{
						OnWorkerCreated(worker);
					}
				}
			}
			foreach (CaravanInstance item in GlobalSaveController.CurrentVillageData.WorldMapData.CaravansInPreparation)
			{
				foreach (HumanoidInstance worker2 in item.Workers)
				{
					if (!Workers.Any((HumanoidInstance w) => w == worker2 || w.UniqueId == worker2.UniqueId))
					{
						OnWorkerCreated(worker2);
					}
				}
			}
		}

		private void OnWorkerCreated(HumanoidInstance humanoid)
		{
			if (!Workers.Contains(humanoid))
			{
				Workers.Add(humanoid);
			}
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				SortWorkers();
				NotifyListUpdate();
			});
		}

		private void OnCaravanStart(CaravanInstance caravanInstance)
		{
			SortWorkers();
			NotifyListUpdate();
		}

		private void OnWorkerRemoved(HumanoidInstance humanoid)
		{
			if (!humanoid.IsInIncognitoMode())
			{
				int num = Workers.IndexOf(humanoid);
				if (num >= 0)
				{
					Workers.RemoveAt(num);
				}
			}
			else
			{
				SortWorkers();
			}
			NotifyListUpdate();
		}

		private void OnWorkerNameChanged(HumanoidInstance obj)
		{
			SortWorkers();
			NotifyListUpdate();
		}

		private void SortWorkers()
		{
			Workers.Sort(HumanoidUtils.CompareWorkersSort);
		}

		private void OnInitialize(bool afterLoad)
		{
			MonoSingleton<UIController>.Instance.SelectNextWorkerEvent += OnSelectNextWorker;
		}

		private void OnSelectNextWorker()
		{
			if (Workers.Count == 0)
			{
				return;
			}
			int index = 0;
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 0)
			{
				foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
				{
					if (selectedObject is WorkerView { HumanoidInstance: var humanoidInstance })
					{
						index = (Workers.IndexOf(humanoidInstance) + 1) % Workers.Count;
						break;
					}
				}
			}
			HumanoidInstance humanoidInstance2 = Workers[index];
			MonoSingleton<SelectableObjectManager>.Instance.SelectObject(humanoidInstance2.GetAgentView<WorkerView>());
		}
	}
}
