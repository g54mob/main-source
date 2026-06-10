using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.ShamanVisitorEvent", "")]
	public class ShamanVisitorEvent : RoleVisitorEvent
	{
		public ShamanVisitorEvent()
		{
		}

		protected override string GetVisitorBlueprintId()
		{
			if (!string.IsNullOrEmpty(base.Blueprint.NpcId))
			{
				return base.Blueprint.NpcId;
			}
			return "shaman_visitor_1";
		}

		protected override HumanoidInstance GetNpcInstance()
		{
			return MonoSingleton<NPCManager>.Instance.SpawnShamanVisitor("shaman_visitor_1", OriginVillage.GetRandomBodyType(), Vector3.zero, "shaman", OriginVillage, this);
		}

		public ShamanVisitorEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
