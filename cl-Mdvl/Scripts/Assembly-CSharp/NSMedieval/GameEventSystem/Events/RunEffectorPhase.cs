using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("RunEffectorPhase", "")]
	public class RunEffectorPhase : SingleExecutePhaseBase
	{
		[SerializeField]
		private readonly string effectorId;

		private const string fvs_effectorId = "effectorId";

		public RunEffectorPhase(string effectorId)
		{
			this.effectorId = effectorId;
		}

		protected override void Execute()
		{
			MonoSingleton<WorkerManager>.Instance.RunEffectorOnAllWorkersOneTime(effectorId);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("effectorId", effectorId);
		}

		public RunEffectorPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			effectorId = deserializer.ReadString("effectorId");
		}
	}
}
