using System;
using System.Collections.Generic;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("CheckBoolPhaseBase", "")]
	public abstract class CheckBoolPhaseBase : GameEventBranchingPhaseBase
	{
		private const int FALSE_INDEX = 0;

		private const int TRUE_INDEX = 1;

		protected CheckBoolPhaseBase()
		{
			nextPhases = new List<GameEventPhaseBase> { null, null };
		}

		protected abstract bool EvaluateExpression();

		protected override int TickNextPhaseIndex()
		{
			if (!EvaluateExpression())
			{
				return 0;
			}
			return 1;
		}

		public CheckBoolPhaseBase NextPhaseOnTrue(GameEventPhaseBase nextPhase)
		{
			nextPhases[1] = nextPhase;
			return this;
		}

		public CheckBoolPhaseBase NextPhaseOnFalse(GameEventPhaseBase nextPhase)
		{
			nextPhases[0] = nextPhase;
			return this;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public CheckBoolPhaseBase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
