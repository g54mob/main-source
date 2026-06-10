using System.IO;
using NSMedieval.State;

namespace NSMedieval.DebugEvents
{
	public struct CreatureDied : IDebugEvent
	{
		public ushort CreatureId;

		public bool IsNaturalDeath;

		public string WorkerName;

		public int FullWorkerId;

		public byte TypeId => 7;

		public DebugEventCategory Category => DebugEventCategory.Event;

		public CreatureDied(CreatureBase creature, bool isNaturalDeath)
		{
			if (creature == null)
			{
				CreatureId = 0;
				IsNaturalDeath = false;
				WorkerName = null;
				FullWorkerId = 0;
			}
			else
			{
				CreatureId = DebugEventLog.GetShortCreatureId(creature);
				IsNaturalDeath = isNaturalDeath;
				WorkerName = null;
				FullWorkerId = 0;
			}
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(CreatureId);
			writer.Write(IsNaturalDeath);
		}

		public void ReadBytes(BinaryReader reader)
		{
			CreatureId = reader.ReadUInt16();
			IsNaturalDeath = reader.ReadBoolean();
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Creature Died";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return $"'{WorkerName}', natural: {IsNaturalDeath}, id: {FullWorkerId}";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}

		public void ApplyState(DebugEventWindowModelContext context)
		{
			CreatureInfo creatureInfo = context.ShortIdToCreatureInfo[CreatureId];
			FullWorkerId = creatureInfo.Id;
			WorkerName = creatureInfo.Name;
			context.StateSnapshot.ShortIdToState.Remove(CreatureId);
		}
	}
}
