using System;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("TryBanishWorkerSilentPhase", "")]
	public class TryBanishWorkerSilentPhase : CheckBoolPhaseBase
	{
		[SerializeField]
		private int workerId;

		private const string fvs_workerId = "workerId";

		public TryBanishWorkerSilentPhase(int workerId)
		{
			this.workerId = workerId;
		}

		protected override bool EvaluateExpression()
		{
			HumanoidInstance humanoidInstance = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.FirstOrDefault((HumanoidInstance worker) => worker.UniqueId == workerId);
			if (humanoidInstance == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(59, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\BranchingPhases\\TryBanishWorkerSilentPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Worker with unique ID (");
					messageBuilder.AppendFormatted(workerId);
					messageBuilder.AppendLiteral(") not found. This should not happen!");
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (!NPCStartPositionManager.CheckIfPositionReachableFromEdge(humanoidInstance))
			{
				return false;
			}
			humanoidInstance.DontSpawnCarcassOnDispose = true;
			if (humanoidInstance.HasFainted)
			{
				StatInstance statInstance = humanoidInstance.Stats?.GetStat(StatType.Consciousness);
				if (statInstance != null)
				{
					int num = statInstance.Blueprint.ThresholdTriggers[^1].Trigger + 5;
					statInstance.SetCurrent(num);
				}
			}
			humanoidInstance.WorkerBehaviour.Banish(showConfirmPrompt: false);
			return true;
		}

		public TryBanishWorkerSilentPhase NextPhaseOnSuccess(GameEventPhaseBase nextPhase)
		{
			return (TryBanishWorkerSilentPhase)NextPhaseOnTrue(nextPhase);
		}

		public TryBanishWorkerSilentPhase NextPhaseOnFail(GameEventPhaseBase nextPhase)
		{
			return (TryBanishWorkerSilentPhase)NextPhaseOnFalse(nextPhase);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("workerId", workerId);
		}

		public TryBanishWorkerSilentPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			workerId = deserializer.ReadInt("workerId");
		}
	}
}
