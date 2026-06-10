using System.IO;
using NSMedieval.State;
using NSMedieval.Tools;

namespace NSMedieval.DebugEvents
{
	public struct CreatureChanged : IDebugEvent
	{
		public ushort CreatureId;

		public ChangedFields ChangedFields;

		public int NodeIndex;

		public int GoalNameHash;

		public float Health;

		public bool IsDrafted;

		public byte TypeId => 1;

		public DebugEventCategory Category => DebugEventCategory.StateChange;

		public CreatureChanged(CreatureBase creature, Vec3Int position, int goalNameHash, float health, bool drafted, ChangedFields changedFields)
		{
			if (creature == null)
			{
				CreatureId = 0;
				ChangedFields = ChangedFields.None;
				NodeIndex = 0;
				GoalNameHash = 0;
				Health = 0f;
				IsDrafted = false;
				return;
			}
			CreatureId = DebugEventLog.GetShortCreatureId(creature);
			ChangedFields = changedFields;
			if ((changedFields & ChangedFields.Position) != ChangedFields.None)
			{
				NodeIndex = GridDataIndexTools.FastTo1DIndex(position);
			}
			else
			{
				NodeIndex = 0;
			}
			if ((changedFields & ChangedFields.Goal) != ChangedFields.None)
			{
				GoalNameHash = goalNameHash;
			}
			else
			{
				GoalNameHash = 0;
			}
			if ((changedFields & ChangedFields.Health) != ChangedFields.None)
			{
				Health = health;
			}
			else
			{
				Health = 0f;
			}
			if ((changedFields & ChangedFields.Drafted) != ChangedFields.None)
			{
				IsDrafted = drafted;
			}
			else
			{
				IsDrafted = false;
			}
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(CreatureId);
			writer.Write((byte)ChangedFields);
			if ((ChangedFields & ChangedFields.Position) != ChangedFields.None)
			{
				writer.Write(NodeIndex);
			}
			if ((ChangedFields & ChangedFields.Goal) != ChangedFields.None)
			{
				writer.Write(GoalNameHash);
			}
			if ((ChangedFields & ChangedFields.Health) != ChangedFields.None)
			{
				writer.Write(Health);
			}
			if ((ChangedFields & ChangedFields.Drafted) != ChangedFields.None)
			{
				writer.Write(IsDrafted);
			}
		}

		public void ReadBytes(BinaryReader reader)
		{
			CreatureId = reader.ReadUInt16();
			ChangedFields = (ChangedFields)reader.ReadByte();
			if ((ChangedFields & ChangedFields.Position) != ChangedFields.None)
			{
				NodeIndex = reader.ReadInt32();
			}
			if ((ChangedFields & ChangedFields.Goal) != ChangedFields.None)
			{
				GoalNameHash = reader.ReadInt32();
			}
			if ((ChangedFields & ChangedFields.Health) != ChangedFields.None)
			{
				Health = reader.ReadSingle();
			}
			if ((ChangedFields & ChangedFields.Drafted) != ChangedFields.None)
			{
				IsDrafted = reader.ReadBoolean();
			}
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Creature Position Changed";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return "Creature Position Changed";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}

		public void ApplyState(DebugEventWindowModelContext context)
		{
			if (!context.StateSnapshot.ShortIdToState.ContainsKey(CreatureId))
			{
				context.GoalHashToName.TryGetValue(GoalNameHash, out var value);
				context.StateSnapshot.ShortIdToState[CreatureId] = new CreatureState
				{
					GridPosition = GridDataIndexTools.To3DIndex(NodeIndex, in context.MapSize),
					Health = Health,
					GoalName = value
				};
				return;
			}
			CreatureState value2 = context.StateSnapshot.ShortIdToState[CreatureId];
			if ((ChangedFields & ChangedFields.Position) != ChangedFields.None)
			{
				value2.GridPosition = GridDataIndexTools.To3DIndex(NodeIndex, in context.MapSize);
			}
			if ((ChangedFields & ChangedFields.Health) != ChangedFields.None)
			{
				value2.Health = Health;
			}
			if ((ChangedFields & ChangedFields.Goal) != ChangedFields.None)
			{
				context.GoalHashToName.TryGetValue(GoalNameHash, out var value3);
				value2.GoalName = value3 ?? "UNKNOWN_GOAL";
			}
			if ((ChangedFields & ChangedFields.Drafted) != ChangedFields.None)
			{
				value2.IsDrafted = IsDrafted;
			}
			context.StateSnapshot.ShortIdToState[CreatureId] = value2;
		}

		public override string ToString()
		{
			return string.Format("{0} -- {1}: {2}, {3}: ({4}), {5}: {6}, {7}: {8}, {9}: {10}, {11}: {12}", "CreatureChanged", "CreatureId", CreatureId, "ChangedFields", ChangedFields, "NodeIndex", NodeIndex, "GoalNameHash", GoalNameHash, "Health", Health, "IsDrafted", IsDrafted);
		}
	}
}
