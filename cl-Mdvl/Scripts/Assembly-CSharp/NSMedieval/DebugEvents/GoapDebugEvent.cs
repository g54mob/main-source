using System.IO;
using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.DebugEvents
{
	public struct GoapDebugEvent : IDebugEvent
	{
		public ushort CreatureShortId;

		public ushort EventCode;

		public byte TypeId => 10;

		public DebugEventCategory Category => DebugEventCategory.HiddenEvent;

		public GoapDebugEvent(CreatureBase creature, GoapDebugEventCode code)
		{
			if (creature == null)
			{
				CreatureShortId = 0;
				EventCode = 0;
			}
			else
			{
				CreatureShortId = DebugEventLog.GetShortCreatureId(creature);
				EventCode = (ushort)code;
			}
		}

		public GoapDebugEvent(IGoapAgentOwner agentOwner, GoapDebugEventCode code)
			: this(agentOwner as CreatureBase, code)
		{
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(CreatureShortId);
			writer.Write(EventCode);
		}

		public void ReadBytes(BinaryReader reader)
		{
			CreatureShortId = reader.ReadUInt16();
			EventCode = reader.ReadUInt16();
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Goap Event";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return "Goap Event";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}

		public override string ToString()
		{
			GoapDebugEventCode eventCode = (GoapDebugEventCode)EventCode;
			return eventCode.ToString();
		}
	}
}
