using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Objectives;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.View;
using Objectives;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.GameOverEvent", "")]
	public class GameOverEvent : GameEventInstance
	{
		public GameOverEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			bool num = MonoSingleton<WorkerManager>.Instance.AllWorkers.Any((KeyValuePair<HumanoidInstance, WorkerView> worker) => !worker.Key.HasDied && !worker.Key.HasDisposed);
			ObjectiveInstance activeObjective = MonoSingleton<ObjectiveManager>.Instance.ActiveObjective;
			string overrideDialogImage = ((num && activeObjective != null) ? activeObjective.Blueprint.GameOverEventImage : null);
			if (base.Blueprint.Dialogs[0].Options.Count == 1)
			{
				return PhaseBuilder.LinkPhases(new ShowDialogPhase(0, overrideDialogImage), new LoadHomeScenePhase());
			}
			ShowDialogPhaseBranching showDialogPhaseBranching = new ShowDialogPhaseBranching(0, overrideDialogImage);
			showDialogPhaseBranching.NextPhaseOnChoice(1, new LoadHomeScenePhase());
			return showDialogPhaseBranching;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public GameOverEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
