using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.Tutorial
{
	public class RaidTutorialStep : TutorialStep
	{
		public RaidTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_raid_wait")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			DeselectAllDelayed();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: false);
			MonoSingleton<TutorialManager>.Instance.PreventWorldTimeTick = false;
			MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent("game_event_raid_new");
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnGameEventEnded;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: true);
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnGameEventEnded;
		}

		private void OnGameEventEnded(GameEventInstance gameEventInstance)
		{
			if (!(gameEventInstance is RaidEvent))
			{
				return;
			}
			CompleteTask(0);
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				MonoSingleton<DraftController>.Instance.OnEndDraft(key);
			}
		}
	}
}
