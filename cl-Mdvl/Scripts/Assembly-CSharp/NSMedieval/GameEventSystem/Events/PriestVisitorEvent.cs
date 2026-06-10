using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.PriestVisitorEvent", "")]
	public class PriestVisitorEvent : RoleVisitorEvent
	{
		public PriestVisitorEvent()
		{
		}

		protected override string GetVisitorBlueprintId()
		{
			if (!string.IsNullOrEmpty(base.Blueprint.NpcId))
			{
				return base.Blueprint.NpcId;
			}
			return "priest_visitor_1";
		}

		protected override HumanoidInstance GetNpcInstance()
		{
			return MonoSingleton<NPCManager>.Instance.SpawnVisitorPriest(GetVisitorBlueprintId(), OriginVillage.GetRandomBodyType(), Vector3.zero, "priest", OriginVillage, this);
		}

		public PriestVisitorEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
