using System.IO;
using NSMedieval.State;

namespace NSMedieval.DebugEvents
{
	public struct CreatureRegistered : IDebugEvent
	{
		public int CreatureId;

		public ushort CreatureShortId;

		public string CreatureName;

		public CreatureType CreatureType;

		public byte TypeId => 6;

		public DebugEventCategory Category => DebugEventCategory.Event | DebugEventCategory.StateChange;

		public CreatureRegistered(CreatureBase creature)
		{
			if (creature == null)
			{
				CreatureId = 0;
				CreatureShortId = 0;
				CreatureName = null;
				CreatureType = CreatureType.None;
				return;
			}
			CreatureId = creature.UniqueId;
			CreatureShortId = 0;
			string creatureName = ((!(creature is AnimalInstance animalInstance)) ? creature.GetFullName() : (animalInstance.AnimalType.ToString() + " " + animalInstance.Blueprint?.GetID() + " " + animalInstance.GetFullName()));
			CreatureName = creatureName;
			CreatureType creatureType = ((creature is AnimalInstance) ? CreatureType.Animal : ((creature is HumanoidInstance humanoidInstance) ? (humanoidInstance.IsWorker() ? CreatureType.Worker : CreatureType.NPC) : CreatureType.None));
			CreatureType = creatureType;
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(CreatureId);
			writer.Write(CreatureShortId);
			writer.Write(CreatureName);
			writer.Write((ushort)CreatureType);
		}

		public void ReadBytes(BinaryReader reader)
		{
			CreatureId = reader.ReadInt32();
			CreatureShortId = reader.ReadUInt16();
			CreatureName = reader.ReadString();
			ushort creatureType = reader.ReadUInt16();
			CreatureType = (CreatureType)creatureType;
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "New Creature";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return $"'{CreatureName}' (id {CreatureId})";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}

		public void ApplyState(DebugEventWindowModelContext context)
		{
			context.ShortIdToCreatureInfo[CreatureShortId] = new CreatureInfo
			{
				Id = CreatureId,
				Name = CreatureName,
				Type = CreatureType
			};
		}
	}
}
