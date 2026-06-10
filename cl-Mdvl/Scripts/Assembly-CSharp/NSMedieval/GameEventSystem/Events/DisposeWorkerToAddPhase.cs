using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("DisposeWorkerToAddPhase", "")]
	public class DisposeWorkerToAddPhase : GameEventLinearPhaseBase
	{
		private IWorkerPhaseDataHolder ExternalDataHolder => base.EventInstance as IWorkerPhaseDataHolder;

		private HumanoidInstance HumanoidToAdd
		{
			get
			{
				return ExternalDataHolder.HumanoidToAdd;
			}
			set
			{
				ExternalDataHolder.HumanoidToAdd = value;
			}
		}

		public DisposeWorkerToAddPhase()
		{
		}

		public override bool OnStart()
		{
			VerifyEventIsCompatible();
			GameEventPhaseBase.Logger.Info("Disposing HumanoidToAdd instance");
			HumanoidToAdd.DontSpawnCarcassOnDispose = true;
			HumanoidToAdd.SkipHistoryOnDeath = true;
			MonoSingleton<WorkerController>.Instance.RemoveWorker(HumanoidToAdd);
			HumanoidToAdd.Dispose();
			HumanoidToAdd = null;
			return true;
		}

		private void VerifyEventIsCompatible()
		{
			if (!(base.EventInstance is IWorkerPhaseDataHolder))
			{
				throw new Exception("Incompatible event type for this phase! The event instance must implement the IWorkerPhaseDataHolder interface.");
			}
		}

		protected override bool TickShouldEnd()
		{
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public DisposeWorkerToAddPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
