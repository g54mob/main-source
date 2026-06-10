using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("CheckFactionHostilePhase", "")]
	public class CheckFactionHostilePhase : CheckBoolPhaseBase
	{
		[SerializeField]
		private string factionBlueprintId;

		private const string fvs_factionBlueprintId = "factionBlueprintId";

		public CheckFactionHostilePhase()
		{
		}

		public CheckFactionHostilePhase(string factionBlueprintId)
		{
			this.factionBlueprintId = factionBlueprintId;
		}

		protected override bool EvaluateExpression()
		{
			return (GameEventPhaseBase.GetFactionInstanceByBlueprintId(factionBlueprintId) ?? throw new Exception("Faction with blueprint ID '" + factionBlueprintId + "' not found. This should not happen!")).IsHostile();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("factionBlueprintId", factionBlueprintId);
		}

		public CheckFactionHostilePhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			factionBlueprintId = deserializer.ReadString("factionBlueprintId");
		}
	}
}
