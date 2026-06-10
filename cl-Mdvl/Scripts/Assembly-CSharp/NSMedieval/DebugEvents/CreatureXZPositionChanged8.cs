using System;
using System.IO;

namespace NSMedieval.DebugEvents
{
	public struct CreatureXZPositionChanged8 : IDebugEvent
	{
		public ushort WorkerId;

		public byte PackedData;

		public int DeltaX;

		public int DeltaZ;

		public byte TypeId => 9;

		public DebugEventCategory Category => DebugEventCategory.StateChange;

		public CreatureXZPositionChanged8(ushort workerId, int deltaX, int deltaZ)
		{
			WorkerId = workerId;
			PackedData = 0;
			byte b = (byte)Math.Abs(deltaX);
			byte b2 = (byte)Math.Abs(deltaZ);
			if (deltaX < 0)
			{
				b |= 8;
			}
			if (deltaZ < 0)
			{
				b2 |= 8;
			}
			PackedData = (byte)(b << 4);
			PackedData |= b2;
			DeltaX = deltaX;
			DeltaZ = deltaZ;
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(WorkerId);
			writer.Write(PackedData);
		}

		public void ReadBytes(BinaryReader reader)
		{
			WorkerId = reader.ReadUInt16();
			PackedData = reader.ReadByte();
			DeltaX = PackedData >> 4;
			DeltaZ = PackedData & 0xF;
			if ((DeltaX & 8) != 0)
			{
				DeltaX = -(DeltaX & 7);
			}
			if ((DeltaZ & 8) != 0)
			{
				DeltaZ = -(DeltaZ & 7);
			}
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "CreatureXZPositionChanged8";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return "CreatureXZPositionChanged8";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}

		public void ApplyState(DebugEventWindowModelContext context)
		{
			CreatureState value = context.StateSnapshot.ShortIdToState[WorkerId];
			ref Vec3Int gridPosition = ref value.GridPosition;
			gridPosition += new Vec3Int(DeltaX, 0, DeltaZ);
			context.StateSnapshot.ShortIdToState[WorkerId] = value;
		}

		public override string ToString()
		{
			return string.Format("{0} DeltaX: {1}, DeltaZ: {2}", "CreatureXZPositionChanged8", DeltaX, DeltaZ);
		}
	}
}
