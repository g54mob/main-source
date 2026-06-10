using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("AddFriendlinessPhase", "")]
	public class AddFriendlinessPhase : SingleExecutePhaseBase
	{
		[SerializeField]
		private string factionBlueprintId;

		[SerializeField]
		private float friendlinessAmount;

		private const string fvs_factionBlueprintId = "factionBlueprintId";

		private const string fvs_friendlinessAmount = "friendlinessAmount";

		public AddFriendlinessPhase(string factionBlueprintId, float friendlinessAmount)
		{
			this.factionBlueprintId = factionBlueprintId;
			this.friendlinessAmount = friendlinessAmount;
		}

		protected override void Execute()
		{
			(GameEventPhaseBase.GetFactionInstanceByBlueprintId(factionBlueprintId) ?? throw new Exception("Faction with blueprint ID '" + factionBlueprintId + "' not found. This should not happen!")).AddFriendliness(friendlinessAmount);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("factionBlueprintId", factionBlueprintId);
			serializer.Write("friendlinessAmount", friendlinessAmount);
		}

		public AddFriendlinessPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			factionBlueprintId = deserializer.ReadString("factionBlueprintId");
			friendlinessAmount = deserializer.ReadFloat("friendlinessAmount");
		}
	}
}
