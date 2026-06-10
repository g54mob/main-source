using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.GlobalStats;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GlobalStatModifyPhase", "")]
	public class GlobalStatModifyPhase : SingleExecutePhaseBase
	{
		[SerializeField]
		private readonly string globalStatId;

		[SerializeField]
		private readonly float addValue;

		public GlobalStatModifyPhase(string globalStatId, float addValue)
		{
			this.globalStatId = globalStatId;
			this.addValue = addValue;
		}

		protected override void Execute()
		{
			GlobalStatInstance globalStatInstance = MonoSingleton<GlobalStatManager>.Instance.GetGlobalStatInstance(globalStatId);
			if (globalStatInstance == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\GlobalStatModifyPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Global stat with ID ");
					messageBuilder.AppendFormatted(globalStatId);
					messageBuilder.AppendLiteral(" not found");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				globalStatInstance.AddToValue(addValue);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("globalStatId", globalStatId);
			serializer.Write("addValue", addValue);
		}

		public GlobalStatModifyPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			globalStatId = deserializer.ReadString("addValue");
			addValue = deserializer.ReadFloat("addValue");
		}
	}
}
