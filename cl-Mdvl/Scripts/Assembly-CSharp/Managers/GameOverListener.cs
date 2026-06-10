using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.WorldMap;

namespace Managers
{
	public class GameOverListener : MonoSingleton<GameOverListener>
	{
		private void OnEnable()
		{
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnRemoveWorker;
		}

		private void OnDisable()
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnRemoveWorker;
			}
		}

		private void OnRemoveWorker(HumanoidInstance humanoidInstance)
		{
			if (GlobalSaveController.CurrentVillageData.Workers.Count > 1)
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				if (MonoSingleton<GameOverListener>.IsInstantiated() && MonoSingleton<WorldMap>.IsInstantiated() && GlobalSaveController.CurrentVillageData.Workers.Count == 0)
				{
					if (GlobalSaveController.CurrentVillageData.IsSecondMap)
					{
						MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent("game_event_all_dead_second_map");
					}
					else if (MonoSingleton<WorldMap>.Instance.Data.Caravans.Any())
					{
						MonoSingleton<GameSpeedManager>.Instance.EnableSleepSpeed();
					}
					else
					{
						MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent("game_event_all_dead");
					}
				}
			});
		}
	}
}
