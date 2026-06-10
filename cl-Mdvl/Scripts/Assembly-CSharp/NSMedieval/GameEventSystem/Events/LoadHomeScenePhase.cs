using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("LoadHomeScenePhase", "")]
	public class LoadHomeScenePhase : SingleExecutePhaseBase
	{
		public LoadHomeScenePhase()
		{
		}

		protected override void Execute()
		{
			MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadHomeScene();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public LoadHomeScenePhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
