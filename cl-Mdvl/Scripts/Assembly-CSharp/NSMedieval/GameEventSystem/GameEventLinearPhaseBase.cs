using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("GameEventLinearPhaseBase", "")]
	public abstract class GameEventLinearPhaseBase : GameEventPhaseBase
	{
		[SerializeField]
		private GameEventPhaseBase nextPhase;

		private const string fvs_nextPhase = "nextPhase";

		protected abstract bool TickShouldEnd();

		protected GameEventLinearPhaseBase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			nextPhase = null;
		}

		public override GameEventPhaseBase Tick()
		{
			if (TickShouldEnd())
			{
				return nextPhase;
			}
			return this;
		}

		public GameEventLinearPhaseBase LinkNextPhase(GameEventPhaseBase nextPhase)
		{
			this.nextPhase = nextPhase;
			return this;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("nextPhase", nextPhase);
		}

		public GameEventLinearPhaseBase(FVDeserializer deserializer)
			: base(deserializer)
		{
			nextPhase = deserializer.ReadObject<GameEventPhaseBase>("nextPhase");
		}
	}
}
