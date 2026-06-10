using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("LoadMainScenePhase", "")]
	public class LoadMainScenePhase : SingleExecutePhaseBase
	{
		public LoadMainScenePhase()
		{
		}

		protected override void Execute()
		{
			MonoSingleton<TravelManager>.Instance.LoadOriginalVillage();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public LoadMainScenePhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
