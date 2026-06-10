using System.IO;

namespace NSMedieval.DebugEvents
{
	public struct TimeTickedBatched : IDebugEvent
	{
		public uint Ticks;

		public byte TypeId => 8;

		public DebugEventCategory Category => DebugEventCategory.StateChange;

		public void WriteBytes(BinaryWriter writer)
		{
			if (Ticks < 65535)
			{
				writer.Write((ushort)Ticks);
				return;
			}
			writer.Write(ushort.MaxValue);
			writer.Write(Ticks);
		}

		public void ReadBytes(BinaryReader reader)
		{
			Ticks = reader.ReadUInt16();
			if (Ticks == 65535)
			{
				Ticks = reader.ReadUInt32();
			}
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "TimeAdvanced";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return "TimeAdvanced";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}
	}
}
