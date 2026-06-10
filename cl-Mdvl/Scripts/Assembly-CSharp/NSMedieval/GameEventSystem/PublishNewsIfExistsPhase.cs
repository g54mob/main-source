using System;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("PublishNewsIfExistsPhase", "")]
	public class PublishNewsIfExistsPhase : PublishNewsPhase
	{
		protected override void Execute()
		{
			if (dialogIndex < base.Blueprint.Dialogs.Count)
			{
				base.Execute();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public PublishNewsIfExistsPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
