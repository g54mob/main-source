using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("CheckWorkerPresentPhase", "")]
	public class CheckWorkerPresentPhase : CheckBoolPhaseBase
	{
		[SerializeField]
		private int workerId;

		private const string fvs_workerId = "workerId";

		public CheckWorkerPresentPhase()
		{
		}

		public CheckWorkerPresentPhase(int workerId)
		{
			this.workerId = workerId;
		}

		protected override bool EvaluateExpression()
		{
			return MonoSingleton<WorkerManager>.Instance.AnyWorker((HumanoidInstance workerInstance) => workerInstance.UniqueId == workerId);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("workerId", workerId);
		}

		public CheckWorkerPresentPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			workerId = deserializer.ReadInt("workerId");
		}
	}
}
