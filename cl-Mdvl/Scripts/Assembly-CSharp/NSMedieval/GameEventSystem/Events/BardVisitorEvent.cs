using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.BardVisitorEvent", "")]
	public class BardVisitorEvent : RoleVisitorEvent
	{
		public BardVisitorEvent()
		{
		}

		protected override string GetVisitorBlueprintId()
		{
			return "bard_visitor_1";
		}

		protected override HumanoidInstance GetNpcInstance()
		{
			return MonoSingleton<NPCManager>.Instance.SpawnBardVisitor("bard_visitor_1", OriginVillage.GetRandomBodyType(), Vector3.zero, "bard", OriginVillage, this);
		}

		public BardVisitorEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
