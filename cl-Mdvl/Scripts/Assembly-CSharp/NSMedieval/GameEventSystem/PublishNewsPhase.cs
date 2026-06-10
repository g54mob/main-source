using System;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("PublishNewsPhase", "")]
	public class PublishNewsPhase : SingleExecutePhaseBase
	{
		[SerializeField]
		public int dialogIndex;

		private const string fvs_dialogIndex = "dialogIndex";

		public PublishNewsPhase(int dialogIndex)
		{
			this.dialogIndex = dialogIndex;
		}

		protected override void Execute()
		{
			GameEventUtil.PublishNews(base.EventInstance, dialogIndex);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("dialogIndex", dialogIndex);
		}

		public PublishNewsPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			dialogIndex = deserializer.ReadInt("dialogIndex");
		}
	}
}
