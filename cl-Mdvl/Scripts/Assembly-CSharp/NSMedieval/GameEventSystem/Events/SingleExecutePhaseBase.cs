using System;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("SingleExecutePhaseBase", "")]
	public abstract class SingleExecutePhaseBase : GameEventLinearPhaseBase
	{
		protected SingleExecutePhaseBase()
		{
		}

		protected abstract void Execute();

		public override bool OnStart()
		{
			Execute();
			return true;
		}

		protected override bool TickShouldEnd()
		{
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public SingleExecutePhaseBase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
