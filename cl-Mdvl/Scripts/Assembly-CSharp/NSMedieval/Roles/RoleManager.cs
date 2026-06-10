using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.GlobalStats;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.WorldMap;

namespace NSMedieval.Roles
{
	public class RoleManager : MonoSingleton<RoleManager>
	{
		private WardenRoleSettings wardenRoleSettings;

		public event Action RoleViewShownEvent;

		public event Action<Role, HumanoidInstance> RoleRetractedEvent;

		public event Action<Role, HumanoidInstance> RoleChangedEvent;

		public bool HasWardenRole(out HumanoidInstance humanoidInstance)
		{
			humanoidInstance = GetWorkersWithRole().FirstOrDefault((HumanoidInstance hi) => hi.WorkerBehaviour.HumanoidRoleOwner.HasRole("warden"));
			return humanoidInstance != null;
		}

		public IEnumerable<HumanoidInstance> GetWorkersWithRole()
		{
			return MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Where((HumanoidInstance worker) => worker.WorkerBehaviour.HumanoidRoleOwner != null);
		}

		public int CountWorkersWithRole(string roleId, int roleMinLevel, bool includeCaravans = true)
		{
			int num = 0;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (WorkerHasRole(key, roleId, roleMinLevel))
				{
					num++;
				}
			}
			foreach (CaravanInstance caravan in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.Caravans)
			{
				foreach (HumanoidInstance worker in caravan.Workers)
				{
					if (WorkerHasRole(worker, roleId, roleMinLevel))
					{
						num++;
					}
				}
			}
			return num;
			static bool WorkerHasRole(HumanoidInstance worker, string workerRoleId, int workerRoleMinLevel)
			{
				if (!worker.HasDisposed && !worker.HasDied && worker.WorkerBehaviour != null)
				{
					RoleInstance roleInstance = worker.WorkerBehaviour.HumanoidRoleOwner?.RoleInstance;
					if (roleInstance != null && roleInstance.Level >= workerRoleMinLevel && workerRoleId == roleInstance.Blueprint.GetID())
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool AnyWorkersWithRole(string roleId, int roleMinLevel)
		{
			return MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.FirstOrDefault((HumanoidInstance worker) => worker.WorkerBehaviour.HumanoidRoleOwner != null && worker.WorkerBehaviour.HumanoidRoleOwner.RoleInstance != null && worker.WorkerBehaviour.HumanoidRoleOwner.RoleInstance.Level >= roleMinLevel && worker.WorkerBehaviour.HumanoidRoleOwner.RoleInstance.Blueprint.GetID() == roleId) != null;
		}

		public void ShowView(HumanoidInstance humanoidInstance)
		{
			HandleFirstView();
			MonoSingleton<UIController>.Instance.AssignRoleView.SetDataAndShow(humanoidInstance);
		}

		public void OnRoleRetracted(Role role, HumanoidInstance humanoidInstance)
		{
			this.RoleRetractedEvent?.Invoke(role, humanoidInstance);
			this.RoleChangedEvent?.Invoke(role, humanoidInstance);
		}

		public void OnRoleChanged(Role role, HumanoidInstance humanoidInstance)
		{
			this.RoleChangedEvent?.Invoke(role, humanoidInstance);
		}

		private void OnHourUpdate()
		{
			foreach (KeyValuePair<HumanoidInstance, WorkerView> allWorker in MonoSingleton<WorkerManager>.Instance.AllWorkers)
			{
				foreach (Role allItem in Repository<RoleRepository, Role>.Instance.GetAllItems())
				{
					if (allWorker.Key.WorkerBehaviour.HumanoidRoleOwner.CanRoleBeLeveledUp(allItem) && GlobalSaveController.CurrentVillageData.RolesSaveData.AddWorkerRoleNotification(allWorker.Key, allItem.GetID(), allWorker.Key.WorkerBehaviour.HumanoidRoleOwner.RoleLevel))
					{
						string roleNameWithIconAndLevel = HumanoidRoleUtils.GetRoleNameWithIconAndLevel(allItem, allWorker.Key.WorkerBehaviour.HumanoidRoleOwner.RoleLevel + 1, allWorker.Key);
						string messageText = UiUtils.Localize.GetText("eligible_for_role_bbt").Replace("<settler_name>", allWorker.Key.Info.GetFullName()).Replace("<role_name>", roleNameWithIconAndLevel);
						MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, allWorker.Value, follow: true);
					}
				}
			}
		}

		private void HandleFirstView()
		{
			if (!GlobalSaveController.CurrentVillageData.RolesSaveData.ViewShown)
			{
				GlobalSaveController.CurrentVillageData.RolesSaveData.SetViewShown();
				this.RoleViewShownEvent?.Invoke();
			}
		}

		private void OnEnable()
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
		}

		private void OnDisable()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
			}
		}

		private void Start()
		{
			wardenRoleSettings = Repository<WardenRoleSettingsData, WardenRoleSettings>.Instance.GetData<WardenRoleSettings>();
		}

		public int GetLabourerLimit(int wardenRoleLevel)
		{
			return wardenRoleSettings.LabourerLimitPerLevel[wardenRoleLevel];
		}

		public IEnumerable<string> GetLabourerProximityInteractEffectors()
		{
			return wardenRoleSettings.LabourerProximityInteractEffectors;
		}

		public IEnumerable<string> GetPrisonerProximityInteractEffectors()
		{
			return wardenRoleSettings.PrisonerProximityInteractEffectors;
		}

		private void OnDateUpdate()
		{
			TickDailyLevelUpGlobalStats();
		}

		private void TickDailyLevelUpGlobalStats()
		{
			PooledDictionary<Role, int> janitor = DictionaryPool<Role, int>.GetJanitor();
			try
			{
				foreach (HumanoidInstance item in GetWorkersWithRole())
				{
					RoleInstance roleInstance = item.WorkerBehaviour?.HumanoidRoleOwner?.RoleInstance;
					if (roleInstance != null && !(roleInstance.Blueprint == null) && roleInstance.Level != -1 && roleInstance.GetRoleLevel().GlobalStatModifier != null)
					{
						int level = roleInstance.Level;
						Role blueprint = roleInstance.Blueprint;
						if (!janitor.TryAdd(blueprint, level) && janitor[blueprint] < level)
						{
							janitor[blueprint] = level;
						}
					}
				}
				foreach (KeyValuePair<Role, int> item2 in janitor)
				{
					Role key = item2.Key;
					int value = item2.Value;
					if (value == -1 || value > key.MaxLevel)
					{
						continue;
					}
					RoleLevel roleLevel = key.RoleLevels[value];
					GlobalStatInstance globalStatInstance = MonoSingleton<GlobalStatManager>.Instance.GetGlobalStatInstance(roleLevel.GlobalStatModifier.GlobalStatId);
					if (globalStatInstance == null)
					{
						continue;
					}
					float num = Math.Clamp(globalStatInstance.Value + roleLevel.GlobalStatModifier.DailyAddValue, 0f, roleLevel.GlobalStatModifier.ValueCap);
					if (num > globalStatInstance.Value)
					{
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(51, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\RoleManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Adding ");
							messageBuilder.AppendFormatted(roleLevel.GlobalStatModifier.DailyAddValue);
							messageBuilder.AppendLiteral(" to global stat ");
							messageBuilder.AppendFormatted(globalStatInstance.BlueprintId);
							messageBuilder.AppendLiteral(" because you have a level ");
							messageBuilder.AppendFormatted(value);
							messageBuilder.AppendLiteral(" ");
							messageBuilder.AppendFormatted(key.GetID());
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
						globalStatInstance.SetValue(num, allowShowBbt: false);
					}
				}
			}
			finally
			{
				((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
